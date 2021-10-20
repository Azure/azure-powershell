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

using System;
using System.Management.Automation.Runspaces;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Test.Mocks
{
    sealed class MockAzContext : IAzContext
    {
        public string HashUserId => "TestUserId";

        public string MacAddress => "TestMacAddress";

        public string OSVersion => "TestOSVersion";

        public Version PowerShellVersion => Version.Parse("0.0.0.0");

        public Version ModuleVersion => Version.Parse("0.0.0.0");

        public Version AzVersion => Version.Parse("0.0.0.0");

        public int Cohort { get; set; } = -1;

        public bool IsInternal => true;

        public Runspace DefaultRunspace => default;

        public void UpdateContext()
        {
        }
    }
}
