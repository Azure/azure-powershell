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

using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;

namespace Microsoft.Azure.Commands.KeyVault.Test.ScenarioTests
{
    public class KeyVaultTestFixture : RMTestBase, IDisposable
    {
        public string TagName { get; set; } = "testtag";
        public string TagValue { get; set; } = "testvalue";

        public string ResourceGroupName { get; set; }
        public string Location { get; set; }
        public string PreCreatedVault { get; set; }

        public KeyVaultTestFixture()
        {
        }

        public void Initialize(string className)
        {
            // no op
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
