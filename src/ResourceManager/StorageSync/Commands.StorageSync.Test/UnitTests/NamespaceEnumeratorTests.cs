using System.Collections.Generic;
using Microsoft.Azure.Commands.StorageSync.Evaluation;
using Microsoft.Azure.Commands.StorageSync.Evaluation.Interfaces;
using Xunit;
using Moq;
using System;

namespace Microsoft.Azure.Commands.StorageSync.Test.UnitTests
{
    public class NamespaceEnumeratorTests
    {
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
