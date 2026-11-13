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

using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Runtime.InteropServices;
using FluentAssertions;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Bicep;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.Bicep
{
    public class GetAzBicepVersionCmdletTests : RMTestBase
    {
        private static readonly string FakeProfileDirectory = Path.Combine(Path.DirectorySeparatorChar.ToString(), "fake", "profile");

        private static string ExpectedFileName => RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "bicep.exe" : "bicep";

        private readonly Mock<ICommandRuntime> commandRuntimeMock;
        private readonly Mock<IDataStore> dataStoreMock;
        private readonly GetAzBicepVersionCmdlet cmdlet;
        private readonly string installationDirectory;
        private readonly string installedPath;
        private readonly string metadataPath;

        public GetAzBicepVersionCmdletTests()
        {
            this.commandRuntimeMock = new Mock<ICommandRuntime>();
            this.dataStoreMock = new Mock<IDataStore>();
            this.installationDirectory = Path.Combine(FakeProfileDirectory, "bin");
            this.installedPath = Path.Combine(this.installationDirectory, ExpectedFileName);
            this.metadataPath = Path.Combine(this.installationDirectory, ".bicep-version");

            var installer = new BicepInstaller(Mock.Of<IBicepDownloader>(), this.dataStoreMock.Object, Mock.Of<IProcessInvoker>(), FakeProfileDirectory);

            this.cmdlet = new GetAzBicepVersionCmdlet
            {
                CommandRuntime = this.commandRuntimeMock.Object,
                Installer = installer
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExecuteCmdlet_writes_nothing_when_nothing_is_installed()
        {
            this.dataStoreMock.Setup(x => x.FileExists(this.installedPath)).Returns(false);

            this.cmdlet.ExecuteCmdlet();

            this.commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<object>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExecuteCmdlet_writes_the_installed_version_from_the_default_slot()
        {
            this.dataStoreMock.Setup(x => x.FileExists(this.installedPath)).Returns(true);
            this.dataStoreMock.Setup(x => x.FileExists(this.metadataPath)).Returns(true);
            this.dataStoreMock.Setup(x => x.ReadFileAsText(this.metadataPath)).Returns("0.30.1");

            var written = new List<PSBicepVersion>();
            this.commandRuntimeMock
                .Setup(f => f.WriteObject(It.IsAny<object>()))
                .Callback<object>(obj => written.Add((PSBicepVersion)obj));

            this.cmdlet.ExecuteCmdlet();

            written.Should().ContainSingle();
            written[0].Version.Should().Be("0.30.1");
            written[0].Path.Should().Be(this.installedPath);
        }
    }
}
