namespace Microsoft.Azure.Commands.StorageSync.Test.UnitTests
{
    using Microsoft.Azure.Commands.StorageSync.Evaluation;
    using Xunit;

    public class ListFilesTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void StripUncPathTests()
        {
            Assert.True(ListFiles.EnsureUncPrefixIsNotPresent(@"c:\plop") == @"c:\plop", @"no-op case");
            Assert.True(ListFiles.EnsureUncPrefixIsNotPresent(@"\\?\c:\plop") == @"c:\plop", @"\\?\ case");
            Assert.True(ListFiles.EnsureUncPrefixIsNotPresent(@"\\?\unc\localhost\plop") == @"\\localhost\plop", @"\\?\unc\ case");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CompleteUncPathTests()
        {
            Assert.True(ListFiles.EnsureUncPrefixPresent(@"c:\plop") == @"\\?\c:\plop", @"local path case");
            Assert.True(ListFiles.EnsureUncPrefixPresent(@"\\localhost\plop") == @"\\?\unc\localhost\plop", @"\\<server> case");
            Assert.True(ListFiles.EnsureUncPrefixPresent(@"\\?\c:\plop") == @"\\?\c:\plop", @"no-op case with local path");
            Assert.True(ListFiles.EnsureUncPrefixPresent(@"\\?\unc\localhost\plop") == @"\\?\unc\localhost\plop", @"no-op case with network path");
        }
    }
}
