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

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class AEMExtensionTests : ComputeTestRunner
    {
        public AEMExtensionTests(Xunit.Abstractions.ITestOutputHelper output)
        : base(output)
        {
        }


        [Fact(Skip = "Need service team to re-record test after changes to the ClientRuntime.")]
        [Trait("Re-record", "ClientRuntime changes")]
        public void TestAEMExtensionBasicWindowsWAD()
        {
            TestRunner.RunTestScript("Test-AEMExtensionBasicWindowsWAD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionBasicWindows()
        {
            TestRunner.RunTestScript("Test-AEMExtensionBasicWindows");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAEMExtensionAdvancedWindowsWAD()
        {
            TestRunner.RunTestScript("Test-AEMExtensionAdvancedWindowsWAD");
        }

        [Fact(Skip = "Need service team to re-record test after changes to the ClientRuntime.")]
        [Trait("Re-record", "ClientRuntime changes")]
        public void TestAEMExtensionAdvancedWindows()
        {
            TestRunner.RunTestScript("Test-AEMExtensionAdvancedWindows");
        }

        [Fact(Skip = "Need service team to re-record test after changes to the ClientRuntime.")]
        [Trait("Re-record", "ClientRuntime changes")]
        public void TestAEMExtensionAdvancedWindowsMD()
        {
            TestRunner.RunTestScript("Test-AEMExtensionAdvancedWindowsMD");
        }
    }
}