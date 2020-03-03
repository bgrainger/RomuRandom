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
	/// Implements the "RomuQuad" generator from <a href="http://romu-random.org/">romu-random.org</a>.
	/// </summary>
	public sealed class RomuQuad
	{
		/// <summary>
		/// Initializes a new instance of <see cref="RomuQuad"/>, seeded with the current time.
		/// </summary>
		public RomuQuad()
		{
			_zState = unchecked((ulong) DateTime.UtcNow.Ticks);
		}

		/// <summary>
		/// Initializes a new instance of <see cref="RomuQuad"/> with the specified seed.
		/// </summary>
		/// <param name="seed">The non-zero seed for the random number generator.</param>
		public RomuQuad(int seed)
		{
			if (seed == 0)
				throw new ArgumentOutOfRangeException(nameof(seed), "seed must not be zero");
			_zState = unchecked((ulong) seed);
		}

		/// <summary>
		/// Implements <code>romuQuad_random</code> from <a href="http://romu-random.org/code.c">romu-random.org</a>.
		/// </summary>
		public ulong Next()
		{
			ulong wp = _wState, xp = _xState, yp = _yState, zp = _zState;
			_wState = 15241094284759029579u * zp; // a-mult
#if !NETSTANDARD1_0
			_xState = zp + BitOperations.RotateLeft(wp, 52);           // b-rotl, c-add
#else
			_xState = zp + RotateLeft(wp, 52);           // b-rotl, c-add
#endif
			_yState = yp - xp;                    // d-sub
			_zState = yp + wp;                    // e-add
#if !NETSTANDARD1_0
			_zState = BitOperations.RotateLeft(_zState,19);            // f-rotl
#else
			_zState = RotateLeft(_zState,19);            // f-rotl
#endif
			return xp;

#if NETSTANDARD1_0
			static ulong RotateLeft(ulong value, int offset) => (value << offset) | (value >>(64 - offset));
#endif
		}

		ulong _wState;
		ulong _xState;
		ulong _yState;
		ulong _zState;
	}
}
