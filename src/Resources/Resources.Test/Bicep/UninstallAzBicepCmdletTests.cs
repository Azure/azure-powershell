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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Bicep;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.Bicep
{
    public class UninstallAzBicepCmdletTests
    {
        private const string FakeProfileDirectory = "/fake/profile";

        private readonly Mock<ICommandRuntime> commandRuntimeMock;
        private readonly Mock<IDataStore> dataStoreMock;
        private readonly UninstallAzBicepCmdlet cmdlet;
        private readonly string installationDirectory;

        public UninstallAzBicepCmdletTests()
        {
            this.commandRuntimeMock = new Mock<ICommandRuntime>();
            this.commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            this.dataStoreMock = new Mock<IDataStore>();
            this.installationDirectory = Path.Combine(FakeProfileDirectory, "bin");

            var installer = new BicepInstaller(Mock.Of<IBicepDownloader>(), this.dataStoreMock.Object, Mock.Of<IProcessInvoker>(), FakeProfileDirectory);

            this.cmdlet = new UninstallAzBicepCmdlet
            {
                CommandRuntime = this.commandRuntimeMock.Object,
                Installer = installer
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExecuteCmdlet_deletes_installation_directory_when_something_is_installed()
        {
            this.dataStoreMock.Setup(x => x.DirectoryExists(this.installationDirectory)).Returns(true);

            this.cmdlet.ExecuteCmdlet();

            this.dataStoreMock.Verify(x => x.DeleteDirectory(this.installationDirectory), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExecuteCmdlet_is_no_op_when_nothing_is_installed()
        {
            this.dataStoreMock.Setup(x => x.DirectoryExists(this.installationDirectory)).Returns(false);

            this.cmdlet.ExecuteCmdlet();

            this.dataStoreMock.Verify(x => x.DeleteDirectory(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExecuteCmdlet_writes_true_when_PassThru_and_something_removed()
        {
            this.cmdlet.PassThru = true;
            this.dataStoreMock.Setup(x => x.DirectoryExists(this.installationDirectory)).Returns(true);

            this.cmdlet.ExecuteCmdlet();

            this.commandRuntimeMock.Verify(f => f.WriteObject(true), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExecuteCmdlet_writes_false_when_PassThru_and_nothing_removed()
        {
            this.cmdlet.PassThru = true;
            this.dataStoreMock.Setup(x => x.DirectoryExists(this.installationDirectory)).Returns(false);

            this.cmdlet.ExecuteCmdlet();

            this.commandRuntimeMock.Verify(f => f.WriteObject(false), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExecuteCmdlet_does_not_write_object_when_PassThru_is_not_set()
        {
            this.dataStoreMock.Setup(x => x.DirectoryExists(this.installationDirectory)).Returns(true);

            this.cmdlet.ExecuteCmdlet();

            this.commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<object>()), Times.Never);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExecuteCmdlet_does_not_uninstall_when_ShouldProcess_returns_false()
        {
            this.commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            this.dataStoreMock.Setup(x => x.DirectoryExists(this.installationDirectory)).Returns(true);

            this.cmdlet.ExecuteCmdlet();

            this.dataStoreMock.Verify(x => x.DeleteDirectory(It.IsAny<string>()), Times.Never);
        }
    }
}
