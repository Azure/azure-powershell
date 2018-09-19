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

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    [TestClass]
    public class ServiceManagementCleanUp : ServiceManagementTest
    {

        /// <summary>
        /// Clean up any resouces left from tests
        /// </summary>
        [TestMethod(), TestCategory(Category.CleanUp), Priority(1), Owner("hylee"), Description("Clean up any resouces left from tests")]
        public void CleanUp()
        {
            vmPowershellCmdlets = new ServiceManagementCmdletTestHelper();
            try
            {
                vmPowershellCmdlets.RunPSScript("Get-AzureService | Remove-AzureService -DeleteAll -Force");
            }
            catch
            {
            }

            try
            {
                vmPowershellCmdlets.RunPSScript("Get-AzureDisk | Remove-AzureDisk -DeleteVHD");
            }
            catch
            {
            }

            try
            {
                vmPowershellCmdlets.RunPSScript(@"Get-AzureVMImage | where {$_.Category -eq 'User'} | Remove-AzureVMImage -DeleteVHD");
            }
            catch
            {
            }

            try
            {
                vmPowershellCmdlets.RunPSScript("Remove-AzureVNetConfig");
            }
            catch
            {
            }

            try
            {
                vmPowershellCmdlets.RunPSScript("Get-AzureAffinityGroup | Remove-AzureAffinityGroup");
            }
            catch
            {
            }

            try
            {
                vmPowershellCmdlets.RunPSScript("Get-AzureReservedIP | Remove-AzureReservedIP -Force");
            }
            catch
            {
            }
        }
    }
}
