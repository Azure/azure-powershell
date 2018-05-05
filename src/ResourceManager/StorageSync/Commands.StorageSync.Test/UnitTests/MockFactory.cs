using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.StorageSync.Evaluation;

namespace Microsoft.Azure.Commands.StorageSync.Test.UnitTests
{
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
    }
}
