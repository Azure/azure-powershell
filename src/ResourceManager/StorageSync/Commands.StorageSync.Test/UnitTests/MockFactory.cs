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
    using Evaluation.Interfaces;
    using System;

    static class MockFactory
    {
        public static IConfiguration ConfigurationWithInvalidFilenames(IEnumerable<string> invalidFilenames)
        {
            var configurationMockFactory = new Moq.Mock<IConfiguration>();
            configurationMockFactory.Setup(configuration => configuration.InvalidFileNames()).Returns(invalidFilenames);

            return configurationMockFactory.Object;
        }

        public static IConfiguration ConfigurationWithMaximumFilenameLength(int maxFilenameLength)
        {
            var configurationMockFactory = new Moq.Mock<IConfiguration>();
            configurationMockFactory.Setup(configuration => configuration.MaximumFilenameLength()).Returns(maxFilenameLength);

            return configurationMockFactory.Object;
        }

        public static IFileInfo FileWithName(string name)
        {
            var fileInfoMockFactory = new Moq.Mock<IFileInfo>();
            fileInfoMockFactory.SetupGet(fileInfo => fileInfo.Name).Returns(name);

            return fileInfoMockFactory.Object;
        }

        public static IConfiguration ConfigurationWithMaximumFileSizeOf(int maxFileSize)
        {
            var configurationMockFactory = new Moq.Mock<IConfiguration>();
            configurationMockFactory.Setup(configuration => configuration.MaximumFileSizeInBytes())
                .Returns(maxFileSize);

            return configurationMockFactory.Object;
        }

        public static IConfiguration ConfigurationWithMaximumDatasetSizeOf(long maxDatasetSize)
        {
            var configurationMockFactory = new Moq.Mock<IConfiguration>();
            configurationMockFactory.Setup(configuration => configuration.MaximumDatasetSizeInBytes())
                .Returns(maxDatasetSize);

            return configurationMockFactory.Object;
        }

        internal static IDirectoryInfo DirectoryWithPath(string path)
        {
            var directoryInfoMockFactory = new Moq.Mock<IDirectoryInfo>();
            directoryInfoMockFactory.SetupGet(fileInfo => fileInfo.FullName).Returns(path);

            return directoryInfoMockFactory.Object;
        }

        public static IFileInfo FileWithSizeOf(int size)
        {
            var fileInfoMockFactory = new Moq.Mock<IFileInfo>();
            fileInfoMockFactory.SetupGet(fileInfo => fileInfo.Length).Returns(size);

            return fileInfoMockFactory.Object;
        }

        public static IDirectoryInfo DirectoryWithName(string name)
        {
            var directoryInfoMockFactory = new Moq.Mock<IDirectoryInfo>();
            directoryInfoMockFactory.SetupGet(directoryInfo => directoryInfo.Name).Returns(name);

            return directoryInfoMockFactory.Object;
        }

        public static IConfiguration ConfigurationWithMaximumPathLengthOf(int maxPathLength)
        {
            var configurationMockFactory = new Moq.Mock<IConfiguration>();
            configurationMockFactory.Setup(configuration => configuration.MaximumPathLength())
                .Returns(maxPathLength);

            return configurationMockFactory.Object;
        }

        public static IFileInfo FileWithPath(string path)
        {
            var fileInfoMockFactory = new Moq.Mock<IFileInfo>();
            fileInfoMockFactory.SetupGet(fileInfo => fileInfo.FullName).Returns(path);

            return fileInfoMockFactory.Object;
        }

        public static IConfiguration ConfigurationWithMaximumDepthOf(int maxDepth)
        {
            var configurationMockFactory = new Moq.Mock<IConfiguration>();
            configurationMockFactory.Setup(configuration => configuration.MaximumTreeDepth())
                .Returns(maxDepth);

            return configurationMockFactory.Object;
        }

        public static IConfiguration ConfigurationWithValidOSVersions(List<string> validOsVersions)
        {
            var configurationMockFactory = new Moq.Mock<IConfiguration>();
            configurationMockFactory.Setup(configuration => configuration.ValidOsVersions()).Returns(validOsVersions);

            return configurationMockFactory.Object;
        }

        public static INamespaceInfo NamespaceWithPathAndSize(string path, long size)
        {
            var namespaceInfoMock = new Moq.Mock<INamespaceInfo>();
            namespaceInfoMock.SetupGet(namespaceInfo => namespaceInfo.Path).Returns(path);
            namespaceInfoMock.SetupGet(namespaceInfo => namespaceInfo.TotalFileSizeInBytes).Returns(size);

            return namespaceInfoMock.Object;
        }

        public static IDirectoryInfo DirectoryWithGivenParameters(
            string root, 
            int depth,
            int numberOfDirectories, 
            int numberOfFilesPerDirectory,
            long totalSize)
        {
            var plop = new Moq.Mock<IDirectoryInfo>();
            var name = $"root";
            var fullname = $"{root}\\{name}";
            var sizeForFiles = totalSize >> 1;
            var sizeForDirs = totalSize - sizeForFiles;

            var hierarchyDirs = DirectoriesWithGivenParametersRecursive(
                root: fullname,
                level: depth,
                numberOfDirectories: numberOfDirectories,
                numberOfFilesPerDirectory: numberOfFilesPerDirectory,
                totalSize: sizeForDirs);

            var hierarchyFiles = CreateFileInfoObjects(
                root: fullname,
                level: depth,
                count: numberOfFilesPerDirectory,
                totalSize: sizeForFiles);

            plop.SetupGet(obj => obj.Name).Returns(name);
            plop.SetupGet(obj => obj.FullName).Returns(fullname);
            plop.Setup(obj => obj.EnumerateDirectories()).Returns(hierarchyDirs);
            plop.Setup(obj => obj.EnumerateFiles()).Returns(hierarchyFiles);
            plop.Setup(obj => obj.Exists()).Returns(true);

            return plop.Object;
        }

        private static List<IDirectoryInfo> DirectoriesWithGivenParametersRecursive(string root, int level, int numberOfDirectories, int numberOfFilesPerDirectory, long totalSize)
        {
            var remainingSize = totalSize;
            var random = new Random();
            List<IDirectoryInfo> LevelDirectories = new List<IDirectoryInfo>();

            var configuration = new List<Tuple<string, string, List<IDirectoryInfo>, List<IFileInfo>>>();
            for (int i = 0; i < numberOfDirectories; ++i)
            {
                int remainingInt32 = (int)Math.Min(int.MaxValue, remainingSize);
                var sizeForBatch = remainingInt32 == 0 || i == numberOfDirectories - 1 ? remainingInt32 : random.Next(0, remainingInt32);
                remainingSize -= sizeForBatch;

                var sizeForFolders = (level <= 1) ? 0 : sizeForBatch >> 1;
                var sizeForFiles = sizeForBatch - sizeForFolders;

                var name = $"dir_{level}_{i}";
                var fullname = $"{root}\\{name}";

                var dirConfig = (level <= 1) ? new List<IDirectoryInfo> { } : DirectoriesWithGivenParametersRecursive(fullname, level - 1, numberOfDirectories, numberOfFilesPerDirectory, sizeForFolders);
                var fileConfig = CreateFileInfoObjects(fullname, level, numberOfFilesPerDirectory, sizeForFiles);
                configuration.Add(Tuple.Create(name, fullname, dirConfig, fileConfig));
            }

            foreach (var config in configuration)
            {
                var tmp = new Moq.Mock<IDirectoryInfo>();
                var name = config.Item1;
                var fullname = config.Item2;

                tmp.SetupGet(obj => obj.Name).Returns(name);
                tmp.SetupGet(obj => obj.FullName).Returns(fullname);
                tmp.Setup(obj => obj.EnumerateDirectories()).Returns(config.Item3);
                tmp.Setup(obj => obj.EnumerateFiles()).Returns(config.Item4);
                LevelDirectories.Add(tmp.Object);
            }

            return LevelDirectories;
        }

        private static List<IFileInfo> CreateFileInfoObjects(string root, int level, int count, long totalSize)
        {
            var remainingSize = totalSize;
            var random = new Random();
            List<IFileInfo> result = new List<IFileInfo>();

            for (int i = 0; i < count; ++i)
            {
                int remainingInt32 = (int)Math.Min(int.MaxValue, remainingSize);
                var sizeForFile = remainingInt32 == 0 || i == count - 1 ? remainingInt32 : random.Next(0, remainingInt32);
                remainingSize -= sizeForFile;

                var tmp = new Moq.Mock<IFileInfo>();
                var name = $"file_{level}_{i}";
                tmp.SetupGet(obj => obj.Name).Returns(name);
                tmp.SetupGet(obj => obj.FullName).Returns($"{root}\\{name}");
                tmp.SetupGet(obj => obj.Length).Returns(sizeForFile);
                result.Add(tmp.Object);
            }

            return result;
        }
    }
}
