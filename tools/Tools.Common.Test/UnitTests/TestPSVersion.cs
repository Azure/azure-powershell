using Tools.Common.Models;
using Xunit;

namespace Tools.Common.Test
{
    public class TestPSVersion
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConstructor()
        {
            var v1 = new AzurePSVersion("11.0.20");
            Assert.Equal(11, v1.Major);
            Assert.Equal(0, v1.Minor);
            Assert.Equal(20, v1.Patch);
            Assert.False(v1.IsPreview);
            Assert.Null(v1.Label);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEqual()
        {
            Assert.True(new AzurePSVersion("1.0.0") == new AzurePSVersion("1.0.0"));
        }
    }
}
