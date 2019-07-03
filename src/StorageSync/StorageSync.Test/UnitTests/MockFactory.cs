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

    /// <summary>
    /// Class MockFactory.
    /// </summary>
    static class MockFactory
    {
        /// <summary>
        /// Configurations the with invalid filenames.
        /// </summary>
        /// <param name="invalidFilenames">The invalid filenames.</param>
        /// <returns>IConfiguration.</returns>
        public static IConfiguration ConfigurationWithInvalidFilenames(IEnumerable<string> invalidFilenames)
        {
            var configurationMockFactory = new Moq.Mock<IConfiguration>();
            configurationMockFactory.Setup(configuration => configuration.InvalidFileNames()).Returns(invalidFilenames);

            return configurationMockFactory.Object;
        }

        /// <summary>
        /// Configurations the length of the with maximum filename.
        /// </summary>
        /// <param name="maxFilenameLength">Maximum length of the filename.</param>
        /// <returns>IConfiguration.</returns>
        public static IConfiguration ConfigurationWithMaximumFilenameLength(int maxFilenameLength)
        {
            var configurationMockFactory = new Moq.Mock<IConfiguration>();
            configurationMockFactory.Setup(configuration => configuration.MaximumFilenameLength()).Returns(maxFilenameLength);

            return configurationMockFactory.Object;
        }

        /// <summary>
        /// Files the name of the with.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>IFileInfo.</returns>
        public static IFileInfo FileWithName(string name)
        {
            var fileInfoMockFactory = new Moq.Mock<IFileInfo>();
            fileInfoMockFactory.SetupGet(fileInfo => fileInfo.Name).Returns(name);

            return fileInfoMockFactory.Object;
        }

        /// <summary>
        /// Configurations the with maximum file size of.
        /// </summary>
        /// <param name="maxFileSize">Maximum size of the file.</param>
        /// <returns>IConfiguration.</returns>
        public static IConfiguration ConfigurationWithMaximumFileSizeOf(int maxFileSize)
        {
            var configurationMockFactory = new Moq.Mock<IConfiguration>();
            configurationMockFactory.Setup(configuration => configuration.MaximumFileSizeInBytes())
                .Returns(maxFileSize);

            return configurationMockFactory.Object;
        }

        /// <summary>
        /// Configurations the with maximum dataset size of.
        /// </summary>
        /// <param name="maxDatasetSize">Maximum size of the dataset.</param>
        /// <returns>IConfiguration.</returns>
        public static IConfiguration ConfigurationWithMaximumDatasetSizeOf(long maxDatasetSize)
        {
            var configurationMockFactory = new Moq.Mock<IConfiguration>();
            configurationMockFactory.Setup(configuration => configuration.MaximumDatasetSizeInBytes())
                .Returns(maxDatasetSize);

            return configurationMockFactory.Object;
        }

        /// <summary>
        /// Directories the with path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>IDirectoryInfo.</returns>
        internal static IDirectoryInfo DirectoryWithPath(string path)
        {
            var directoryInfoMockFactory = new Moq.Mock<IDirectoryInfo>();
            directoryInfoMockFactory.SetupGet(fileInfo => fileInfo.FullName).Returns(path);

            return directoryInfoMockFactory.Object;
        }

        /// <summary>
        /// Files the with size of.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns>IFileInfo.</returns>
        public static IFileInfo FileWithSizeOf(int size)
        {
            var fileInfoMockFactory = new Moq.Mock<IFileInfo>();
            fileInfoMockFactory.SetupGet(fileInfo => fileInfo.Length).Returns(size);

            return fileInfoMockFactory.Object;
        }

        /// <summary>
        /// Directories the name of the with.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>IDirectoryInfo.</returns>
        public static IDirectoryInfo DirectoryWithName(string name)
        {
            var directoryInfoMockFactory = new Moq.Mock<IDirectoryInfo>();
            directoryInfoMockFactory.SetupGet(directoryInfo => directoryInfo.Name).Returns(name);

            return directoryInfoMockFactory.Object;
        }

        /// <summary>
        /// Configurations the with maximum path length of.
        /// </summary>
        /// <param name="maxPathLength">Maximum length of the path.</param>
        /// <returns>IConfiguration.</returns>
        public static IConfiguration ConfigurationWithMaximumPathLengthOf(int maxPathLength)
        {
            var configurationMockFactory = new Moq.Mock<IConfiguration>();
            configurationMockFactory.Setup(configuration => configuration.MaximumPathLength())
                .Returns(maxPathLength);

            return configurationMockFactory.Object;
        }

        /// <summary>
        /// Files the with path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>IFileInfo.</returns>
        public static IFileInfo FileWithPath(string path)
        {
            var fileInfoMockFactory = new Moq.Mock<IFileInfo>();
            fileInfoMockFactory.SetupGet(fileInfo => fileInfo.FullName).Returns(path);

            return fileInfoMockFactory.Object;
        }

        /// <summary>
        /// Configurations the with maximum depth of.
        /// </summary>
        /// <param name="maxDepth">The maximum depth.</param>
        /// <returns>IConfiguration.</returns>
        public static IConfiguration ConfigurationWithMaximumDepthOf(int maxDepth)
        {
            var configurationMockFactory = new Moq.Mock<IConfiguration>();
            configurationMockFactory.Setup(configuration => configuration.MaximumTreeDepth())
                .Returns(maxDepth);

            return configurationMockFactory.Object;
        }

        /// <summary>
        /// Configurations the with valid os versions.
        /// </summary>
        /// <param name="validOsVersions">The valid os versions.</param>
        /// <returns>IConfiguration.</returns>
        public static IConfiguration ConfigurationWithValidOSVersions(List<string> validOsVersions)
        {
            var configurationMockFactory = new Moq.Mock<IConfiguration>();
            configurationMockFactory.Setup(configuration => configuration.ValidOsVersions()).Returns(validOsVersions);

            return configurationMockFactory.Object;
        }

        /// <summary>
        /// Namespaces the size of the with path and.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="size">The size.</param>
        /// <returns>INamespaceInfo.</returns>
        public static INamespaceInfo NamespaceWithPathAndSize(string path, long size)
        {
            var namespaceInfoMock = new Moq.Mock<INamespaceInfo>();
            namespaceInfoMock.SetupGet(namespaceInfo => namespaceInfo.Path).Returns(path);
            namespaceInfoMock.SetupGet(namespaceInfo => namespaceInfo.TotalFileSizeInBytes).Returns(size);

            return namespaceInfoMock.Object;
        }

        /// <summary>
        /// Directories the with given parameters.
        /// </summary>
        /// <param name="root">The root.</param>
        /// <param name="depth">The depth.</param>
        /// <param name="numberOfDirectories">The number of directories.</param>
        /// <param name="numberOfFilesPerDirectory">The number of files per directory.</param>
        /// <param name="totalSize">The total size.</param>
        /// <returns>IDirectoryInfo.</returns>
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

        /// <summary>
        /// Directorieses the with given parameters recursive.
        /// </summary>
        /// <param name="root">The root.</param>
        /// <param name="level">The level.</param>
        /// <param name="numberOfDirectories">The number of directories.</param>
        /// <param name="numberOfFilesPerDirectory">The number of files per directory.</param>
        /// <param name="totalSize">The total size.</param>
        /// <returns>List&lt;IDirectoryInfo&gt;.</returns>
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

        /// <summary>
        /// Creates the file information objects.
        /// </summary>
        /// <param name="root">The root.</param>
        /// <param name="level">The level.</param>
        /// <param name="count">The count.</param>
        /// <param name="totalSize">The total size.</param>
        /// <returns>List&lt;IFileInfo&gt;.</returns>
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
