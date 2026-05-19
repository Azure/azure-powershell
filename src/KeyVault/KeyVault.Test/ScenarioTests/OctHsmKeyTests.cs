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
using Xunit;

namespace Microsoft.Azure.Commands.KeyVault.Test.ScenarioTests
{
    /// <summary>
    /// Scenario tests for oct (AES) HSM-backed keys on a Premium Azure Key Vault.
    /// These exercise the end-to-end -KeyType oct -Destination HSM path which
    /// the service stores as kty == 'oct-HSM'.
    ///
    /// Recorded with Azure Test Framework: run once in Record mode against a
    /// real Premium vault, commit the generated SessionRecords/*.json files,
    /// and CI replays them in Playback mode. See OctHsmKeyTests.ps1.
    /// </summary>
    public class OctHsmKeyTests : KeyVaultTestRunner
    {
        public OctHsmKeyTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateOctHsmKey()
        {
            TestRunner.RunTestScript("Test-CreateOctHsmKey");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateOctHsmKeyAllSizes()
        {
            TestRunner.RunTestScript("Test-CreateOctHsmKeyAllSizes");
        }

            }
        }
