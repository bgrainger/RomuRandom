using Xunit;

namespace RomuRandom.Tests
{
	public class RomuTrioTests
	{
		[Fact]
		public void Seed1()
		{
			var romu = new RomuTrio(1);
			Assert.Equal(0ul, romu.Next());
			Assert.Equal(15241094284759029579ul, romu.Next());
			Assert.Equal(14228190636816728064ul, romu.Next());
			Assert.Equal(9245692497819074560ul, romu.Next());
			Assert.Equal(3245149784193262381ul, romu.Next());
			Assert.Equal(10585644977753597478ul, romu.Next());
			Assert.Equal(16032099025152174981ul, romu.Next());
			Assert.Equal(17649606395402505574ul, romu.Next());
			Assert.Equal(2323050993333518052ul, romu.Next());
			Assert.Equal(6749583881042357715ul, romu.Next());
		}

		[Fact]
		public void Seed1000()
		{
			var romu = new RomuTrio(1000);
			Assert.Equal(0ul, romu.Next());
			Assert.Equal(4083679874939944184ul, romu.Next());
			Assert.Equal(5750955986663768064ul, romu.Next());
			Assert.Equal(3873716890589200384ul, romu.Next());
			Assert.Equal(5897606139096791380ul, romu.Next());
			Assert.Equal(17518489592504290213ul, romu.Next());
			Assert.Equal(737995529199925702ul, romu.Next());
			Assert.Equal(9106968870370318736ul, romu.Next());
			Assert.Equal(18193074540492164209ul, romu.Next());
			Assert.Equal(16891491649798056587ul, romu.Next());
			Assert.Equal(10123272550865808951ul, romu.Next());
		}

		[Fact]
		public void ThreeSeeds()
		{
			var romu = new RomuTrio(1, 2, 3);
			Assert.Equal(1ul, romu.Next());
			Assert.Equal(8829794706857985505ul, romu.Next());
			Assert.Equal(14228190636816728064ul, romu.Next());
			Assert.Equal(7047022733925001397ul, romu.Next());
			Assert.Equal(11050715128277420919ul, romu.Next());
			Assert.Equal(15593090640687002226ul, romu.Next());
			Assert.Equal(14298535238241843967ul, romu.Next());
			Assert.Equal(9040807352800326898ul, romu.Next());
			Assert.Equal(12281801464384231352ul, romu.Next());
			Assert.Equal(4171818046650149538ul, romu.Next());
		}
	}
}
