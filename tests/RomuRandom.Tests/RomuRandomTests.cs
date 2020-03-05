using System;
using Xunit;

namespace RomuRandom.Tests
{
	public class RomuRandomTests
	{
		[Fact]
		public void DieRollInteger()
		{
			var counts = new int[6];
			const int expected = 1_000_000;
			for (int i = 0; i < counts.Length * expected; i++)
				counts[m_random.Next(6)]++;
			for (int i = 0; i < counts.Length; i++)
				Assert.InRange(counts[i], expected * 0.98, expected * 1.02);
		}

		[Fact]
		public void DieRollDouble()
		{
			var counts = new int[6];
			const int expected = 1_000_000;
			for (int i = 0; i < counts.Length * expected; i++)
				counts[(int) (m_random.NextDouble() * 6)]++;
			for (int i = 0; i < counts.Length; i++)
				Assert.InRange(counts[i], expected * 0.98, expected * 1.02);
		}

		[Fact]
		public void Range()
		{
			var counts = new int[10];
			const int expected = 1_000_000;
			for (int i = 0; i < counts.Length * expected; i++)
				counts[m_random.Next(-3, 7) + 3]++;
			for (int i = 0; i < counts.Length; i++)
				Assert.InRange(counts[i], expected * 0.98, expected * 1.02);
		}

		[Fact]
		public void NegativeRange()
		{
			var counts = new int[100];
			const int expected = 100_000;
			for (int i = 0; i < counts.Length * expected; i++)
				counts[m_random.Next(-2_000_000_100, -2_000_000_000) + 2_000_000_100]++;
			for (int i = 0; i < counts.Length; i++)
				Assert.InRange(counts[i], expected * 0.98, expected * 1.02);
		}

		[Fact]
		public void NextZero()
		{
			Assert.Equal(0, m_random.Next(0));
		}

		[Fact]
		public void NextOne()
		{
			Assert.Equal(0, m_random.Next(1));
		}

		[Fact]
		public void MaxValueMustBeNonNegative()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => m_random.Next(-1));
		}

		[Fact]
		public void EmptyRange()
		{
			Assert.Equal(2, m_random.Next(2, 2));
		}

		[Fact]
		public void SingleItemRange()
		{
			Assert.Equal(2, m_random.Next(2, 3));
		}

		[Fact]
		public void MinValueMustBeLessThanMaxValue()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => m_random.Next(2, 1));
		}

		Random m_random = new RomuRandom();
	}
}
