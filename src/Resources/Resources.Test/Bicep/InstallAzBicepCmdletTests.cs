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
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Text;
using FluentAssertions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Bicep;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.Bicep
{
    public class InstallAzBicepCmdletTests
    {
        private const string FakeProfileDirectory = "/fake/profile";

        private static string ExpectedFileName => RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "bicep.exe" : "bicep";

        private readonly Mock<ICommandRuntime> commandRuntimeMock;
        private readonly Mock<IBicepDownloader> downloaderMock;
        private readonly Mock<IDataStore> dataStoreMock;
        private readonly InstallAzBicepCmdlet cmdlet;

        public InstallAzBicepCmdletTests()
        {
            this.commandRuntimeMock = new Mock<ICommandRuntime>();
            this.commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            this.downloaderMock = new Mock<IBicepDownloader>();
            this.dataStoreMock = new Mock<IDataStore>();

            var installer = new BicepInstaller(this.downloaderMock.Object, this.dataStoreMock.Object, Mock.Of<IProcessInvoker>(), FakeProfileDirectory);

            this.cmdlet = new InstallAzBicepCmdlet
            {
                CommandRuntime = this.commandRuntimeMock.Object,
                Installer = installer
            };
        }

        private string VersionedPath(string version)
            => Path.Combine(FakeProfileDirectory, "bin", "bicep-" + version, ExpectedFileName);

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExecuteCmdlet_installs_latest_version_when_version_not_specified()
        {
            this.downloaderMock.Setup(x => x.GetLatestReleaseTag()).Returns("v0.30.1");
            var expectedPath = this.VersionedPath("0.30.1");
            this.dataStoreMock.Setup(x => x.FileExists(expectedPath)).Returns(false);
            this.downloaderMock.Setup(x => x.DownloadFile(It.IsAny<string>())).Returns(Encoding.UTF8.GetBytes("bits"));

            this.cmdlet.ExecuteCmdlet();

            this.downloaderMock.Verify(x => x.GetLatestReleaseTag(), Times.Once);
            this.downloaderMock.Verify(x => x.GetAvailableReleaseTags(), Times.Never);
            this.dataStoreMock.Verify(x => x.WriteFile(expectedPath, It.IsAny<byte[]>()), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExecuteCmdlet_installs_exact_version_when_version_specified()
        {
            this.cmdlet.Version = "0.26.54";
            this.downloaderMock.Setup(x => x.GetAvailableReleaseTags()).Returns(new[] { "v0.26.54", "v0.25.0" });
            var expectedPath = this.VersionedPath("0.26.54");
            this.dataStoreMock.Setup(x => x.FileExists(expectedPath)).Returns(false);
            this.downloaderMock.Setup(x => x.DownloadFile(It.IsAny<string>())).Returns(Encoding.UTF8.GetBytes("bits"));

            this.cmdlet.ExecuteCmdlet();

            this.downloaderMock.Verify(x => x.GetLatestReleaseTag(), Times.Never);
            this.dataStoreMock.Verify(x => x.WriteFile(expectedPath, It.IsAny<byte[]>()), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExecuteCmdlet_is_no_op_when_requested_version_already_cached()
        {
            this.cmdlet.Version = "0.26.54";
            this.downloaderMock.Setup(x => x.GetAvailableReleaseTags()).Returns(new[] { "v0.26.54" });
            var expectedPath = this.VersionedPath("0.26.54");
            this.dataStoreMock.Setup(x => x.FileExists(expectedPath)).Returns(true);

            this.cmdlet.ExecuteCmdlet();

            this.downloaderMock.Verify(x => x.DownloadFile(It.IsAny<string>()), Times.Never);
            this.dataStoreMock.Verify(x => x.WriteFile(It.IsAny<string>(), It.IsAny<byte[]>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExecuteCmdlet_throws_when_no_release_matches_requested_version()
        {
            this.cmdlet.Version = "9.9.9";
            this.downloaderMock.Setup(x => x.GetAvailableReleaseTags()).Returns(new[] { "v0.26.54", "v0.25.0" });

            FluentActions.Invoking(() => this.cmdlet.ExecuteCmdlet())
                .Should().Throw<AzPSApplicationException>();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExecuteCmdlet_writes_PSBicepVersion_when_PassThru_is_set()
        {
            this.cmdlet.PassThru = true;
            this.downloaderMock.Setup(x => x.GetLatestReleaseTag()).Returns("v0.30.1");
            var expectedPath = this.VersionedPath("0.30.1");
            this.dataStoreMock.Setup(x => x.FileExists(expectedPath)).Returns(false);
            this.downloaderMock.Setup(x => x.DownloadFile(It.IsAny<string>())).Returns(Encoding.UTF8.GetBytes("bits"));

            PSBicepVersion written = null;
            this.commandRuntimeMock
                .Setup(f => f.WriteObject(It.IsAny<object>()))
                .Callback<object>(obj => written = obj as PSBicepVersion);

            this.cmdlet.ExecuteCmdlet();

            written.Should().NotBeNull();
            written.Version.Should().Be("0.30.1");
            written.Path.Should().Be(expectedPath);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExecuteCmdlet_does_not_write_object_when_PassThru_is_not_set()
        {
            this.downloaderMock.Setup(x => x.GetLatestReleaseTag()).Returns("v0.30.1");
            var expectedPath = this.VersionedPath("0.30.1");
            this.dataStoreMock.Setup(x => x.FileExists(expectedPath)).Returns(false);
            this.downloaderMock.Setup(x => x.DownloadFile(It.IsAny<string>())).Returns(Encoding.UTF8.GetBytes("bits"));

            this.cmdlet.ExecuteCmdlet();

            this.commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<object>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExecuteCmdlet_does_not_install_when_ShouldProcess_returns_false()
        {
            this.commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(false);

            this.cmdlet.ExecuteCmdlet();

            this.downloaderMock.Verify(x => x.GetLatestReleaseTag(), Times.Never);
            this.downloaderMock.Verify(x => x.GetAvailableReleaseTags(), Times.Never);
            this.dataStoreMock.Verify(x => x.WriteFile(It.IsAny<string>(), It.IsAny<byte[]>()), Times.Never);
        }
    }
}
