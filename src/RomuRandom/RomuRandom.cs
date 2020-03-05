// Copyright 2020 Bradley Grainger
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     https://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;

namespace RomuRandom
{
	/// <summary>
	/// Provides an implementation of <see cref="System.Random"/> that uses <see cref="RomuTrio"/> to generate its random numbers.
	/// </summary>
	public sealed class RomuRandom : Random
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RomuRandom"/> class, using a time-dependent default seed value.
		/// </summary>
		public RomuRandom()
			: this(Environment.TickCount)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RomuRandom"/> class, using the specified seed value.
		/// </summary>
		/// <param name="seed">A number used to calculate a starting value for the pseudo-random number sequence.</param>
		public RomuRandom(int seed)
		{
			_rng = new RomuTrio(seed);

			// because we use the seed to populate _zState, not _xState, the first return value
			// is always zero; discard it
			_rng.Next();
		}

		/// <summary>
		/// Returns a non-negative random integer.
		/// </summary>
		/// <returns>A 32-bit signed integer that is greater than or equal to 0 and less than <see cref="int.MaxValue"/>.</returns>
		public override int Next() => GenerateNext(0, int.MaxValue);

		/// <summary>
		/// Returns a non-negative random integer that is less than the specified maximum.
		/// </summary>
		/// <param name="maxValue">The exclusive upper bound of the random number to be generated. <paramref name="maxValue"/> must be greater than or equal to 0.</param>
		/// <returns>A 32-bit signed integer that is greater than or equal to 0, and less than <paramref name="maxValue"/>; that is, the range of return values ordinarily
		/// includes 0 but not <paramref name="maxValue"/>. However, if <paramref name="maxValue"/> equals 0, <paramref name="maxValue"/> is returned.</returns>
		public override int Next(int maxValue)
		{
			if (maxValue < 0)
				throw new ArgumentOutOfRangeException(nameof(maxValue), maxValue, "maxValue must be non-negative");

			return GenerateNext(0, maxValue);
		}

		/// <summary>
		/// Returns a random integer that is within a specified range.
		/// </summary>
		/// <param name="minValue">The inclusive lower bound of the random number returned.</param>
		/// <param name="maxValue">The exclusive upper bound of the random number returned. <paramref name="maxValue"/> must be greater than or equal to <paramref name="minValue"/>.</param>
		/// <returns>A 32-bit signed integer greater than or equal to <paramref name="minValue"/> and less than <paramref name="maxValue"/>;
		/// that is, the range of return values includes <paramref name="minValue"/> but not <paramref name="maxValue"/>. If <paramref name="minValue"/>
		/// equals <paramref name="maxValue"/>, <paramref name="minValue"/> is returned.</returns>
		public override int Next(int minValue, int maxValue)
		{
			if (minValue > maxValue)
				throw new ArgumentOutOfRangeException(nameof(maxValue), maxValue, $"maxValue must be greater than minValue ({minValue})");

			return GenerateNext(minValue, maxValue);
		}

		/// <summary>
		/// Fills the elements of a specified array of bytes with random numbers.
		/// </summary>
		/// <param name="buffer">An array of bytes to contain random numbers.</param>
		public override void NextBytes(byte[] buffer)
		{
			if (buffer == null)
				throw new ArgumentNullException(nameof(buffer));

			for (var i = 0; i < buffer.Length; i++)
				buffer[i] = unchecked((byte) _rng.Next());
		}

#if !NETSTANDARD1_0 && !NETSTANDARD2_0
		/// <summary>
		/// Fills the elements of a specified span of bytes with random numbers.
		/// </summary>
		/// <param name="buffer">The array to be filled with random numbers.</param>
		public override void NextBytes(Span<byte> buffer)
		{
			for (int i = 0; i < buffer.Length; i++)
				buffer[i] = unchecked((byte) _rng.Next());
		}
#endif

		/// <summary>
		/// Returns a random floating-point number between 0.0 and 1.0.
		/// </summary>
		/// <returns>A double-precision floating point number that is greater than or equal to 0.0, and less than 1.0.</returns>
		protected override double Sample()
		{
			// random_real_64 from http://mumble.net/~campbell/tmp/random_real.c
			return _rng.Next() * Math.Pow(2, -64);
		}

		private int GenerateNext(int minValue, int maxValue)
		{
			var range = (uint) ((long) maxValue - minValue);
			if (range <= 1)
				return minValue;

			var threshold = ((uint) -range) % range;
			while (true)
			{
				var r = _rng.Next();
				if (r >= threshold)
				{
					var value = unchecked((uint) (r % range));
					return unchecked((int) ((uint) minValue + value));
				}
			}
		}

		readonly RomuTrio _rng;
	}
}
