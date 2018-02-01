using Microsoft.Azure.Commands.Common.Strategies.Compute;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Common.Strategies.UnitTest.Compute
{
    public class ImageVersionTest
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CompareToTest()
        {
            var a = ImageVersion.Parse("1.23.456");
            var b = ImageVersion.Parse("1.23");
            var c = ImageVersion.Parse("01.023");
            var d = ImageVersion.Parse("1.23.457");
            Assert.Equal(1, a.CompareTo(b));
            Assert.Equal(-1, b.CompareTo(a));
            Assert.Equal(0, b.CompareTo(c));
            Assert.Equal(-1, a.CompareTo(d));
            Assert.Equal(1, d.CompareTo(a));
        }
    }
}
