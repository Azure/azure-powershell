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

using Microsoft.Azure.Commands.Common.Authentication.Utilities;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Commands.Common.Authentication.Test
{
    public class PSNamingUtilitiesTests
    {
        [Theory]
        [InlineData("Az.Accounts", true)]
        [InlineData("aZ.cOMPUTE", true)]
        [InlineData("az.stackhci", true)]
        [InlineData("", false)]
        [InlineData("AzureRM.Profile", false)]
        [InlineData("Az", false)]
        [InlineData("AzAccounts", false)]
        [InlineData("Get-AzContext", false)]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanRecognizeModuleName(string name, bool expected)
        {
            Assert.Equal(expected, PSNamingUtilities.IsModuleName(name));
        }

        [Theory]
        [InlineData("Get-AzContext", true)]
        [InlineData("update-azstorageaccount", true)]
        [InlineData("Remove-AzEverything", true)]
        [InlineData("Get-AzDataFactoryV2", true)]
        [InlineData("", false)]
        [InlineData("Az.Accounts", false)]
        [InlineData("Az", false)]
        [InlineData("NewAzVM", false)]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanRecognizeCmdletName(string name, bool expected)
        {
            Assert.Equal(expected, PSNamingUtilities.IsCmdletName(name));
        }

        [Theory]
        [InlineData("Az.Accounts", true)]
        [InlineData("aZ.cOMPUTE", true)]
        [InlineData("az.stackhci", true)]
        [InlineData("Get-AzContext", true)]
        [InlineData("Remove-AzEverything", true)]
        [InlineData("Get-AzDataFactoryV2", true)]
        [InlineData("", false)]
        [InlineData("Az", false)]
        [InlineData("NewAzVM", false)]
        [Trait(TestTraits.AcceptanceType, TestTraits.CheckIn)]
        public void CanRecognizeModuleOrCmdletName(string name, bool expected)
        {
            Assert.Equal(expected, PSNamingUtilities.IsModuleOrCmdletName(name));
        }
    }
}
