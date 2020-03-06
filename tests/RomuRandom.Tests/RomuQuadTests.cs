using Romu;
using Xunit;

namespace RomuRandom.Tests
{
	public class RomuQuadTests
	{
		[Fact]
		public void Seed1()
		{
			var romu = new RomuQuad(1);
			Assert.Equal(0ul, romu.Next());
			Assert.Equal(1ul, romu.Next());
			Assert.Equal(8411941474585081029ul, romu.Next());
			Assert.Equal(17582750459659983897ul, romu.Next());
			Assert.Equal(11906216351335510786ul, romu.Next());
			Assert.Equal(1286341907435558312ul, romu.Next());
			Assert.Equal(8856954513250554415ul, romu.Next());
			Assert.Equal(14338203730875005386ul, romu.Next());
			Assert.Equal(5182183334170314651ul, romu.Next());
			Assert.Equal(10377177704337728552ul, romu.Next());
		}

		[Fact]
		public void SeedNegative1()
		{
			var romu = new RomuQuad(-1);
			Assert.Equal(0ul, romu.Next());
			Assert.Equal(18446744073709551615ul, romu.Next());
			Assert.Equal(10039306198751841082ul, romu.Next());
			Assert.Equal(863993614050092006ul, romu.Next());
			Assert.Equal(16584126584812846518ul, romu.Next());
			Assert.Equal(6384801533933559435ul, romu.Next());
			Assert.Equal(11194560677047186988ul, romu.Next());
			Assert.Equal(10146585673640365666ul, romu.Next());
			Assert.Equal(9712990932255882571ul, romu.Next());
			Assert.Equal(11298847356842188120ul, romu.Next());
		}

		[Fact]
		public void FourSeeds()
		{
			var romu = new RomuQuad(1, 2,3, 4);
			Assert.Equal(2ul, romu.Next());
			Assert.Equal(4503599627370500ul, romu.Next());
			Assert.Equal(15187511025750758165ul, romu.Next());
			Assert.Equal(14994429473373881959ul, romu.Next());
			Assert.Equal(4552565341231374125ul, romu.Next());
			Assert.Equal(18035035012574374668ul, romu.Next());
			Assert.Equal(1730100196680423838ul, romu.Next());
			Assert.Equal(6504681700816491977ul, romu.Next());
			Assert.Equal(16223105444287774094ul, romu.Next());
			Assert.Equal(13586108397339980565ul, romu.Next());
		}
	}
}
