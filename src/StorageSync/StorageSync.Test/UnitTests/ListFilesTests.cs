// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.StorageSync.Test.UnitTests
{
    using Microsoft.Azure.Commands.StorageSync.Evaluation;
    using WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    /// <summary>
    /// Class ListFilesTests.
    /// </summary>
    public class ListFilesTests
    {
        /// <summary>
        /// Defines the test method StripUncPathTests.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void StripUncPathTests()
        {
            Assert.True(ListFiles.EnsureUncPrefixIsNotPresent(@"c:\plop") == @"c:\plop", @"no-op case");
            Assert.True(ListFiles.EnsureUncPrefixIsNotPresent(@"\\?\c:\plop") == @"c:\plop", @"\\?\ case");
            Assert.True(ListFiles.EnsureUncPrefixIsNotPresent(@"\\?\unc\localhost\plop") == @"\\localhost\plop", @"\\?\unc\ case");
        }

        /// <summary>
        /// Defines the test method CompleteUncPathTests.
        /// </summary>
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
