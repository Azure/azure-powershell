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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using ScenarioTests;
using Xunit;
using Xunit.Abstractions;

namespace StorageSyncTests
{
    /// <summary>
    /// Scenario tests for the independent remote server registration cmdlets.
    /// </summary>
    public class RemoteServerRegistrationTests : StorageSyncTestRunner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteServerRegistrationTests"/> class.
        /// </summary>
        /// <param name="output">The output.</param>
        public RemoteServerRegistrationTests(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// Runs Get-StorageSyncServer, Register-AzStorageSyncServer, and Connect-StorageSyncServer in sequence.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoteServerRegistrationSequence()
        {
            TestRunner.RunTestScript("Test-RemoteServerRegistrationSequence");
        }
    }
}
