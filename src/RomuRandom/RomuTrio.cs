// Copyright 2020 Mark A. Overton
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
#if !NETSTANDARD1_0
using System.Numerics;
#endif

namespace RomuRandom
{
	/// <summary>
	/// Implements the "RomuTrio" generator from <a href="http://romu-random.org/">romu-random.org</a>.
	/// </summary>
	public sealed class RomuTrio
	{
		/// <summary>
		/// Initializes a new instance of <see cref="RomuTrio"/>, seeded with the current time.
		/// </summary>
		public RomuTrio()
		{
			_zState = unchecked((ulong) DateTime.UtcNow.Ticks);
		}

		/// <summary>
		/// Initializes a new instance of <see cref="RomuTrio"/> with the specified seed.
		/// </summary>
		/// <param name="seed">The non-zero seed for the random number generator.</param>
		public RomuTrio(int seed)
		{
			if (seed == 0)
				throw new ArgumentOutOfRangeException(nameof(seed), "seed must not be zero");
			_zState = unchecked((ulong) seed);
		}

		/// <summary>
		/// Initializes a new instance of <see cref="RomuTrio"/> with the specified seeds.
		/// </summary>
		public RomuTrio(ulong seed1, ulong seed2, ulong seed3)
		{
			if (seed1 == 0 && seed2 == 0 && seed3 == 0)
				throw new ArgumentOutOfRangeException(nameof(seed1), "At least one seed must be non-zero.");
			_xState = seed1;
			_yState = seed2;
			_zState = seed3;
		}

		/// <summary>
		/// Implements <code>romuTrio_random</code> from <a href="http://romu-random.org/code.c">romu-random.org</a>.
		/// </summary>
		public ulong Next()
		{
			ulong xp = _xState;
			_xState = 15241094284759029579u * _zState;
			_zState -= _yState;
			_yState -= xp;
#if !NETSTANDARD1_0
			_yState = BitOperations.RotateLeft(_yState, 12);
			 _zState = BitOperations.RotateLeft(_zState, 44);
#else
			static ulong RotateLeft(ulong value, int offset) => (value << offset) | (value >>(64 - offset));
			_yState = RotateLeft(_yState, 12);
			 _zState = RotateLeft(_zState, 44);
#endif
			return xp;
		}

		ulong _xState;
		ulong _yState;
		ulong _zState;
	}
}
