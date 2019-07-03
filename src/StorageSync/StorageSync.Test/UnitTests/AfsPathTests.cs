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

using System.IO;

namespace Microsoft.Azure.Commands.StorageSync.Test.UnitTests
{
    using Microsoft.Azure.Commands.StorageSync.Evaluation;
    using System;
    using WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    /// <summary>
    /// Class AfsPathTests.
    /// </summary>
    public class AfsPathTests
    {
        /// <summary>
        /// Defines the test method LocalPathTests.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LocalPathTests()
        {
            char testDriveLetter = 'c';
            string pathUnderTest = string.Format(@"{0}:\plop", testDriveLetter);
            AfsPath path = new AfsPath(pathUnderTest);

            Assert.True(path.Length == pathUnderTest.Length, "invalid path length");

            Assert.True(path.DriveLetter.HasValue && path.DriveLetter.Value == testDriveLetter, 
                $"{nameof(path.DriveLetter)} should be set to {testDriveLetter}");

            Assert.True(path.ComputerName == null, 
                $"{nameof(path.ComputerName)} should not be set");

            Assert.True(path.ShareName == null, 
                $"{nameof(path.ShareName)} should not be set");
        }

        /// <summary>
        /// Defines the test method LengthTests.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LengthTests()
        {
            int testIndex = 0;

            // classic
            Assert.True(new AfsPath(@"c:").Length == 2, $"invalid length, {nameof(testIndex)} = {++testIndex}");
            Assert.True(new AfsPath(@"c:\").Length == 3, $"invalid length, {nameof(testIndex)} = {++testIndex}");
            Assert.True(new AfsPath(@"c:\plop").Length == 7, $"invalid length, {nameof(testIndex)} = {++testIndex}");
            Assert.True(new AfsPath(@"c:\plop1\plop2\plop3\plop4").Length == 26, $"invalid length, {nameof(testIndex)} = {++testIndex}");

            // unc+drive
            Assert.True(new AfsPath(@"\\plop\c$").Length == 2, $"invalid length, {nameof(testIndex)} = {++testIndex}");
            Assert.True(new AfsPath(@"\\plop\c$\").Length == 3, $"invalid length, {nameof(testIndex)} = {++testIndex}");
            Assert.True(new AfsPath(@"\\plop\c$\plop").Length == 7, $"invalid length, {nameof(testIndex)} = {++testIndex}");
            Assert.True(new AfsPath(@"\\plop\c$\plop1\plop2\plop3\plop4").Length == 26, $"invalid length, {nameof(testIndex)} = {++testIndex}");

            // unc+share
            Assert.True(new AfsPath(@"\\plop\share").Length == 0, $"invalid length, {nameof(testIndex)} = {++testIndex}");
            Assert.True(new AfsPath(@"\\plop\share$").Length == 0, $"invalid length, {nameof(testIndex)} = {++testIndex}");
            Assert.True(new AfsPath(@"\\plop\share\").Length == 1, $"invalid length, {nameof(testIndex)} = {++testIndex}");
            Assert.True(new AfsPath(@"\\plop\share\plop").Length == 5, $"invalid length, {nameof(testIndex)} = {++testIndex}");
            Assert.True(new AfsPath(@"\\plop\share\plop1\plop2\plop3\plop4").Length == 24, $"invalid length, {nameof(testIndex)} = {++testIndex}");

            // ext
            Assert.True(new AfsPath(@"\\?\c:").Length == 2, $"invalid length, {nameof(testIndex)} = {++testIndex}");
            Assert.True(new AfsPath(@"\\?\c:\").Length == 3, $"invalid length, {nameof(testIndex)} = {++testIndex}");
            Assert.True(new AfsPath(@"\\?\c:\plop").Length == 7, $"invalid length, {nameof(testIndex)} = {++testIndex}");
            Assert.True(new AfsPath(@"\\?\c:\plop1\plop2\plop3\plop4").Length == 26, $"invalid length, {nameof(testIndex)} = {++testIndex}");

            // ext+unc+drive
            Assert.True(new AfsPath(@"\\?\unc\plop\c$").Length == 2, $"ext+unc+drive: invalid length, {nameof(testIndex)} = {++testIndex}");
            Assert.True(new AfsPath(@"\\?\unc\plop\c$\").Length == 3, $"ext+unc+drive: invalid length, {nameof(testIndex)} = {++testIndex}");
            Assert.True(new AfsPath(@"\\?\unc\plop\c$\plop").Length == 7, $"ext+unc+drive: invalid length, {nameof(testIndex)} = {++testIndex}");
            Assert.True(new AfsPath(@"\\?\unc\plop\c$\plop1\plop2\plop3\plop4").Length == 26, $"ext+unc+drive: invalid length, {nameof(testIndex)} = {++testIndex}");

            // ext+unc+share
            Assert.True(new AfsPath(@"\\?\unc\plop\share").Length == 0, $"ext+unc+share: invalid length, {nameof(testIndex)} = {++testIndex}");
            Assert.True(new AfsPath(@"\\?\unc\plop\share$").Length == 0, $"ext+unc+share: invalid length, {nameof(testIndex)} = {++testIndex}");
            Assert.True(new AfsPath(@"\\?\unc\plop\share\").Length == 1, $"ext+unc+share: invalid length, {nameof(testIndex)} = {++testIndex}");
            Assert.True(new AfsPath(@"\\?\unc\plop\share\plop").Length == 5, $"ext+unc+share: invalid length, {nameof(testIndex)} = {++testIndex}");
            Assert.True(new AfsPath(@"\\?\unc\plop\share\plop1\plop2\plop3\plop4").Length == 24, $"ext+unc+share: invalid length, {nameof(testIndex)} = {++testIndex}");
        }

        /// <summary>
        /// Defines the test method InvalidArgumentTests.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InvalidArgumentTests()
        {
            // classic
            Assert.Throws<ArgumentException>(() => new AfsPath(@""));
            Assert.Throws<ArgumentException>(() => new AfsPath(@"c"));
            Assert.Throws<ArgumentException>(() => new AfsPath(@" :\"));
            Assert.Throws<ArgumentException>(() => new AfsPath(@"\c:\"));
            Assert.Throws<ArgumentException>(() => new AfsPath(@"cc:\"));
            Assert.Throws<ArgumentException>(() => new AfsPath(@"$c"));
            Assert.Throws<ArgumentException>(() => new AfsPath(@":"));
            Assert.Throws<ArgumentException>(() => new AfsPath(@"\"));
            Assert.Throws<ArgumentException>(() => new AfsPath(@"plop"));
            Assert.Throws<ArgumentException>(() => new AfsPath(@"0:\"));

            // unc+drive
            Assert.Throws<ArgumentException>(() => new AfsPath(@"\\plop"));
            Assert.Throws<ArgumentException>(() => new AfsPath(@"\\plop\"));
            Assert.Throws<ArgumentException>(() => new AfsPath(@"\\plop\$"));
            Assert.Throws<ArgumentException>(() => new AfsPath(@"\\\plop\c$"));
            Assert.Throws<ArgumentException>(() => new AfsPath(@"plop\c$"));
            Assert.Throws<ArgumentException>(() => new AfsPath(@"\\plop\\c$"));
            Assert.Throws<ArgumentException>(() => new AfsPath(@"\\p$\c$"));

            // unc+share
            Assert.Throws<ArgumentException>(() => new AfsPath(@"\\\plop\share"));

            // ext
            Assert.Throws<ArgumentException>(() => new AfsPath(@"\\?\c"));
            Assert.Throws<ArgumentException>(() => new AfsPath(@"\\?\c$$"));
            Assert.Throws<ArgumentException>(() => new AfsPath(@"\\??\c:\"));
            Assert.Throws<ArgumentException>(() => new AfsPath(@"\?\c:\plop"));
            Assert.Throws<ArgumentException>(() => new AfsPath(@"\\\?\c:\plop1\plop2\plop3\plop4"));

            // ext+unc+drive
            Assert.Throws<ArgumentException>(() => new AfsPath(@"\\?\u\plop\c$"));
            Assert.Throws<ArgumentException>(() => new AfsPath(@"\\?\n\plop\c$\"));
            Assert.Throws<ArgumentException>(() => new AfsPath(@"\\?\c\plop\c$\plop"));
            Assert.Throws<ArgumentException>(() => new AfsPath(@"\\?\ucn\plop\c$"));
            Assert.Throws<ArgumentException>(() => new AfsPath(@"\\?\unc\?\c$"));
            Assert.Throws<ArgumentException>(() => new AfsPath(@"\\?\unc.\plop\c$"));

            // ext+unc+share
            Assert.Throws<ArgumentException>(() => new AfsPath(@"\\?\unc\\share"));
            Assert.Throws<ArgumentException>(() => new AfsPath(@"\\?\unc\plop"));
        }

#if NETSTANDARD
        [Fact(Skip = "Fails on Linux, needs investigation")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        /// <summary>
        /// Defines the test method DepthTests.
        /// </summary>
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DepthTests()
        {
            // classic
            Assert.True(new AfsPath(Path.Combine(@"c:")).Depth == 1, "invalid depth, expected 1");
            Assert.True(new AfsPath(Path.Combine(@"c:\")).Depth == 1, "invalid depth, expected 1");
            Assert.True(new AfsPath(Path.Combine(@"c:\", "plop")).Depth == 1, "invalid depth, expected 1");
            Assert.True(new AfsPath(Path.Combine(@"c:\", "plop1", "plop2", "plop3", "plop4")).Depth == 4, "invalid depth, expected 4");

            // unc+drive
            Assert.True(new AfsPath(Path.Combine(@"\\plop", "c$")).Depth == 1, "invalid depth, expected 1");
            Assert.True(new AfsPath(Path.Combine(@"\\plop", @"c$\")).Depth == 1, "invalid depth, expected 1");
            Assert.True(new AfsPath(Path.Combine(@"\\plop", "c$", "plop")).Depth == 1, "invalid depth, expected 1");
            Assert.True(new AfsPath(Path.Combine(@"\\plop", "c$", "plop1", "plop2", "plop3", "plop4")).Depth == 4, "invalid depth, expected 4");

            // unc+share
            Assert.True(new AfsPath(Path.Combine(@"\\plop", "share")).Depth == 1, "invalid depth, expected 1");
            Assert.True(new AfsPath(Path.Combine(@"\\plop", "share$")).Depth == 1, "invalid depth, expected 1");
            Assert.True(new AfsPath(Path.Combine(@"\\plop", @"share\")).Depth == 1, "invalid depth, expected 1");
            Assert.True(new AfsPath(Path.Combine(@"\\plop", "share", "plop")).Depth == 1, "invalid depth, expected 1");
            Assert.True(new AfsPath(Path.Combine(@"\\plop", "share", "plop1", "plop2", "plop3", "plop4")).Depth == 4, "invalid depth, expected 4");

            // ext
            Assert.True(new AfsPath(Path.Combine(@"\\?", "c:")).Depth == 1, "invalid depth, expected 1");
            Assert.True(new AfsPath(Path.Combine(@"\\?", @"c:\")).Depth == 1, "invalid depth, expected 1");
            Assert.True(new AfsPath(Path.Combine(@"\\?", "c:", "plop")).Depth == 1, "invalid depth, expected 1");
            Assert.True(new AfsPath(Path.Combine(@"\\?", "c:", "plop1", "plop2", "plop3", "plop4")).Depth == 4, "invalid depth, expected 4");

            // ext+unc+drive
            Assert.True(new AfsPath(Path.Combine(@"\\?", "unc", "plop", "c$")).Depth == 1, "ext+unc+drive: invalid depth, expected 1");
            Assert.True(new AfsPath(Path.Combine(@"\\?", "unc", "plop", @"c$\")).Depth == 1, "ext+unc+drive: invalid depth, expected 1");
            Assert.True(new AfsPath(Path.Combine(@"\\?", "unc", "plop", "c$", "plop")).Depth == 1, "ext+unc+drive: invalid depth, expected 1");
            Assert.True(new AfsPath(Path.Combine(@"\\?", "unc", "plop", "c$", "plop1", "plop2", "plop3", "plop4")).Depth == 4, "ext+unc+drive: invalid depth, expected 4");

            // ext+unc+share
            Assert.True(new AfsPath(Path.Combine(@"\\?", "unc", "plop", "share")).Depth == 1, "ext+unc+share: invalid depth, expected 1");
            Assert.True(new AfsPath(Path.Combine(@"\\?", "unc", "plop", "share$")).Depth == 1, "ext+unc+share: invalid depth, expected 1");
            Assert.True(new AfsPath(Path.Combine(@"\\?", "unc", "plop", @"share\")).Depth == 1, "ext+unc+share: invalid depth, expected 1");
            Assert.True(new AfsPath(Path.Combine(@"\\?", "unc", "plop", "share", "plop")).Depth == 1, "ext+unc+share: invalid depth, expected 1");
            Assert.True(new AfsPath(Path.Combine(@"\\?", "unc", "plop", "share", "plop1", "plop2", "plop3", "plop4")).Depth == 4, "ext+unc+share: invalid depth, expected 4");
        }

#if NETSTANDARD
        [Fact(Skip = "Fails on Linux, needs investigation")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        /// <summary>
        /// Defines the test method UncPathWithDriveTests.
        /// </summary>
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UncPathWithDriveTests()
        {
            string testPath = @"data";
            string testComputerName = "some-computer-name";
            char testDriveLetter = 'c';
            var pathUnderTest = Path.Combine($@"\\{testComputerName}", $"{testDriveLetter}$", testPath);

            AfsPath path = new AfsPath(pathUnderTest);

            Assert.True(path.Length ==  testPath.Length + 3, "invalid path length");

            Assert.True(path.Depth == 1, "invalid depth");

            Assert.True(path.DriveLetter.HasValue && path.DriveLetter.Value == testDriveLetter,
                $"{nameof(path.DriveLetter)} should be set to {testDriveLetter}");

            Assert.True(path.ShareName == null,
                $"{nameof(path.ShareName)} should not be set");

            Assert.True(path.ComputerName == testComputerName,
                $"{nameof(path.ComputerName)} should be set to {testComputerName}");
        }

        /// <summary>
        /// Defines the test method ExtendedUncPathTests.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExtendedUncPathTests()
        {
            Assert.True(ListFiles.EnsureUncPrefixPresent(@"c:\plop") == @"\\?\c:\plop", @"local path case");
            Assert.True(ListFiles.EnsureUncPrefixPresent(@"\\localhost\plop") == @"\\?\unc\localhost\plop", @"\\<server> case");
            Assert.True(ListFiles.EnsureUncPrefixPresent(@"\\?\c:\plop") == @"\\?\c:\plop", @"no-op case with local path");
            Assert.True(ListFiles.EnsureUncPrefixPresent(@"\\?\unc\localhost\plop") == @"\\?\unc\localhost\plop", @"no-op case with network path");
        }
    }
}
