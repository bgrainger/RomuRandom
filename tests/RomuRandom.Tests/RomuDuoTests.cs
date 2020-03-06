using Romu;
using Xunit;

namespace RomuRandom.Tests
{
	public class RomuDuoTests
	{
		[Fact]
		public void Seed1()
		{
			var romu = new RomuDuo(1);
			Assert.Equal(0ul, romu.Next());
			Assert.Equal(15241094284759029579ul, romu.Next());
			Assert.Equal(10666103186410274816ul, romu.Next());
			Assert.Equal(12956788498585303815ul, romu.Next());
			Assert.Equal(8486441079326769463ul, romu.Next());
			Assert.Equal(2373551033348051550ul, romu.Next());
			Assert.Equal(10003256602856207724ul, romu.Next());
			Assert.Equal(4669124565037773249ul, romu.Next());
			Assert.Equal(10655693834798971811ul, romu.Next());
			Assert.Equal(3487178542431509811ul, romu.Next());
		}

		[Fact]
		public void SeedNegative1()
		{
			var romu = new RomuDuo(-1);
			Assert.Equal(0ul, romu.Next());
			Assert.Equal(3205649788950522037ul, romu.Next());
			Assert.Equal(6411299577901044074ul, romu.Next());
			Assert.Equal(2082275244517482851ul, romu.Next());
			Assert.Equal(4591672078256323753ul, romu.Next());
			Assert.Equal(7558422119120640637ul, romu.Next());
			Assert.Equal(10754078505426094992ul, romu.Next());
			Assert.Equal(6671804195509426422ul, romu.Next());
			Assert.Equal(12430949857410599120ul, romu.Next());
			Assert.Equal(13792996980988152038ul, romu.Next());
		}

		[Fact]
		public void ThreeSeeds()
		{
			var romu = new RomuDuo(1, 2);
			Assert.Equal(1ul, romu.Next());
			Assert.Equal(12035444495808507542ul, romu.Next());
			Assert.Equal(6091112088061520053ul, romu.Next());
			Assert.Equal(15247473810760332814ul, romu.Next());
			Assert.Equal(4016093660068235111ul, romu.Next());
			Assert.Equal(4041301874668610437ul, romu.Next());
			Assert.Equal(1544744609702868527ul, romu.Next());
			Assert.Equal(9070204474037005789ul, romu.Next());
			Assert.Equal(8832412314208222048ul, romu.Next());
			Assert.Equal(4071963928619261017ul, romu.Next());
		}
	}
}
