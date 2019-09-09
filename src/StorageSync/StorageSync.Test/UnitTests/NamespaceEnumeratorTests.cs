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
    using System.Collections.Generic;
    using Microsoft.Azure.Commands.StorageSync.Evaluation;
    using Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces;
    using Xunit;
    using Moq;
    using System;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;

    /// <summary>
    /// Class NamespaceEnumeratorTests.
    /// </summary>
    public class NamespaceEnumeratorTests
    {
        /// <summary>
        /// Defines the test method EnumerationTotals.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnumerationTotals()
        {
            var nsEnumerator = new NamespaceEnumerator();
            int depth = 3;
            int numberOfSubdirs = 5;
            int numberOfFilesPerDirectory = 3;
            int totalBytes = 1024 * 1024;
            NamespaceInfo nsInfo = nsEnumerator.Run(MockFactory.DirectoryWithGivenParameters(
                root: "c:", 
                depth: depth, 
                numberOfDirectories: numberOfSubdirs, 
                numberOfFilesPerDirectory: numberOfFilesPerDirectory, 
                totalSize: totalBytes));

            Assert.True(nsInfo != null, "namespace information was returned");
            Assert.True(nsInfo.IsComplete, "namespace scan is complete");

            int totalDirs = ((int)Math.Pow(numberOfSubdirs, depth + 1) - 1) / (numberOfSubdirs - 1);
            int totalFiles = totalDirs * numberOfFilesPerDirectory;
            Assert.True(nsInfo.NumberOfDirectories == totalDirs, "number of directories is as expected");
            Assert.True(nsInfo.NumberOfFiles == totalFiles, "number of files is as expected");
            Assert.True(nsInfo.TotalFileSizeInBytes == totalBytes, "size is as expected");
        }
    }
}
