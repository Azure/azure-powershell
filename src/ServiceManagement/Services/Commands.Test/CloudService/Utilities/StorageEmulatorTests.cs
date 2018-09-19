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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService.AzureTools;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Moq;

namespace Microsoft.WindowsAzure.Commands.Test.CloudService.Utilities
{
    
    public class StorageEmulatorTests : SMTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Start_StorageEmulatorInstalled_UseCorrectCommand()
        {
            // Setup 
            string testFolder = @"c:\sample-path";
            string expectedCommand = Path.Combine(testFolder, Resources.StorageEmulatorExe);

            StorageEmulator emulator = new StorageEmulator(@"c:\sample-path");
            Mock<ProcessHelper> commandRunner = new Mock<ProcessHelper>();
            commandRunner.Setup(p=>p.StartAndWaitForProcess(expectedCommand, Resources.StartStorageEmulatorCommandArgument));
            emulator.CommandRunner = commandRunner.Object;

            // Execute
            emulator.Start();

            // Assert
            commandRunner.Verify();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Stop_StorageEmulatorInstalled_UseCorrectCommand()
        {
            // Setup 
            string testFolder = @"c:\sample-path";
            string expectedCommand = Path.Combine(testFolder, Resources.StorageEmulatorExe);

            StorageEmulator emulator = new StorageEmulator(@"c:\sample-path");
            Mock<ProcessHelper> commandRunner = new Mock<ProcessHelper>();
            commandRunner.Setup(p => p.StartAndWaitForProcess(expectedCommand, Resources.StopStorageEmulatorCommandArgument));
            emulator.CommandRunner = commandRunner.Object;

            // Execute
            emulator.Stop();

            // Assert
            commandRunner.Verify();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Start_StorageEmulatorNotInstalled_GetWarning()
        {
            // Setup 
            StorageEmulator emulator = new StorageEmulator(null);
            Mock<ProcessHelper> commandRunner = new Mock<ProcessHelper>();

            // Execute
            emulator.Start();

            // Assert
            Assert.Equal(Resources.WarningWhenStorageEmulatorIsMissing, emulator.Error);
        }
    }
}