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

using Commands.StorSimple.Test;
using Xunit;

namespace Microsoft.Azure.Commands.StorSimple.Test.ScenarioTests
{
    public class ServiceConfigTests : StorSimpleTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateGetDeleteAccessControlRecord()
        {
            RunPowerShellTest("Test-CreateGetDeleteAccessControlRecord");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateUpdateDeleteAccessControlRecord()
        {
            RunPowerShellTest("Test-CreateUpdateDeleteAccessControlRecord");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateGetDeleteStorageAccountCredential()
        {
            RunPowerShellTest("Test-CreateGetDeleteStorageAccountCredential");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateUpdateDeleteStorageAccountCredential()
        {
            RunPowerShellTest("Test-CreateUpdateDeleteStorageAccountCredential");
        }
    }
}