namespace Microsoft.Azure.Commands.StorageSync.Test.UnitTests
{
    using System.Collections.Generic;
    using Evaluation.Interfaces;

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
    }
}
