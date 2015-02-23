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

namespace Microsoft.WindowsAzure.Commands.StorSimple.Test.ScenarioTests
{
    public class DeviceTests : StorSimpleTestBase
    {
        #region Get-AzureStorSimpleDevice
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAllDevices()
        {
            RunPowerShellTest("Test-GetDevices");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAllDevices_ByDeviceId()
        {
            RunPowerShellTest("Test-GetDevices_ByDeviceId");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAllDevices_ByDeviceName()
        {
            RunPowerShellTest("Test-GetDevices_ByDeviceName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAllDevices_ByDeviceType()
        {
            RunPowerShellTest("Test-GetDevices_ByType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetDevices_ByModel()
        {
            RunPowerShellTest("Test-GetDevices_ByModel");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAllDevices_NegativeCase()
        {
            RunPowerShellTest("Test-GetDevices_IncorrectParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetDevices_DetailedResult()
        {
            RunPowerShellTest("Test-GetDevices_DetailedResult");
        }
        #endregion Get-AzureStorSimpleDevice

        #region New-AzureStorSimpleNetworkConfig
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewNetworkConfig_Data0()
        {
            RunPowerShellTest("Test-NewNetworkConfigData0");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewNetworkConfig_Others()
        {
            RunPowerShellTest("Test-NewNetworkConfigOthers");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewNetworkConfig_InvalidParams()
        {
            RunPowerShellTest("Test-NewNetworkConfigInvalidParams");
        }
        
        #endregion

        #region Set-AzureStorSimpleDevice
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeviceConfig_FirstTimeSetup()
        {
            RunPowerShellTest("Test-DeviceConfigFirstTimeSetup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeviceConfig_FullSetup()
        {
            RunPowerShellTest("Test-DeviceConfigFullSetup");
        }
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeviceConfig_InvalidFirstTimeSetup()
        {
            RunPowerShellTest("Test-DeviceConfigInvalidFirstTimeSetup");
        }
        #endregion

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualDeviceConfig()
        {
            RunPowerShellTest("Test-VirtualDeviceConfig");
        }
    }
}