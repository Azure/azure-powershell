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

using System;
using System.IO;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Common.Test.Common
{
    public class GeneralTests
    {
        [Fact]
        public void IsValidDirectoryPathReturnsTrueForExistingFolders()
        {
            Assert.True(FileUtilities.IsValidDirectoryPath(Path.GetTempPath()));
            Assert.True(FileUtilities.IsValidDirectoryPath(Directory.GetCurrentDirectory()));
            Assert.True(FileUtilities.IsValidDirectoryPath("C:\\"));
        }

        [Fact]
        public void IsValidDirectoryPathReturnsFalseForFilePaths()
        {
            Assert.False(FileUtilities.IsValidDirectoryPath(Path.GetTempPath() + "\\file.tst"));
            Assert.False(FileUtilities.IsValidDirectoryPath(Path.GetTempPath() + "\\" + Guid.NewGuid() + "\\file.tst"));
            Assert.False(FileUtilities.IsValidDirectoryPath("C:\\file.tst"));
        }

        [Fact]
        public void IsValidDirectoryPathReturnsFalseForNonExistingFolders()
        {
            Assert.False(FileUtilities.IsValidDirectoryPath(""));
            Assert.False(FileUtilities.IsValidDirectoryPath(null));
            Assert.False(FileUtilities.IsValidDirectoryPath(Path.GetTempPath() + "\\" + Guid.NewGuid()));
            Assert.False(FileUtilities.IsValidDirectoryPath("XYZ:\\"));
        }
    }
}
