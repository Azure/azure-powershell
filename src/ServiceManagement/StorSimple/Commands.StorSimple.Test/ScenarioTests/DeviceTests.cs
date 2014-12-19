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
using Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets;
using Xunit;

namespace Microsoft.Azure.Commands.StorSimple.Test.ScenarioTests
{
    public class DeviceTests : StorSimpleTestBase
    {
        #region Get-AzureStorSimpleDevice
        [Fact]
        [Trait("StorSimpleCmdlets","Get-Device")]
        public void TestGetAllDevices()
        {
            RunPowerShellTest("Test-GetDevices");
        }

        [Fact]
        [Trait("StorSimpleCmdlets","Get-Device")]
        public void TestGetAllDevices_ByDeviceId()
        {
            RunPowerShellTest("Test-GetDevices_ByDeviceId");
        }


        [Fact]
        [Trait("StorSimpleCmdlets","Get-Device")]
        public void TestGetAllDevices_ByDeviceName()
        {
            RunPowerShellTest("Test-GetDevices_ByDeviceName");
        }

        [Fact]
        [Trait("StorSimpleCmdlets","Get-Device")]
        public void TestGetAllDevices_ByDeviceType()
        {
            RunPowerShellTest("Test-GetDevices_ByType");
        }

        [Fact]
        [Trait("StorSimpleCmdlets","Get-Device")]
        public void TestGetDevices_ByModel()
        {
            RunPowerShellTest("Test-GetDevices_ByModel");
        }

        [Fact]
        [Trait("StorSimpleCmdlets","Get-Device")]
        public void TestGetAllDevices_NegativeCase()
        {
            RunPowerShellTest("Test-GetDevices_IncorrectParameters");
        }

        [Fact]
        [Trait("StorSimpleCmdlets","Get-Device")]
        public void TestGetDevices_DetailedResult()
        {
            RunPowerShellTest("Test-GetDevices_DetailedResult");
        }
        #endregion Get-AzureStorSimpleDevice

    }
}