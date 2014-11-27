# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Tests creating new simple resource group.
#>
function Test-PublicIpAddressCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $location = Get-ProviderLocation ResourceManagement

    try 
    {
        # Test
        $actual = New-AzureResourceGroup -Name $rgname -Location $location -Tags @{Name = "testtag"; Value = "testval"} 
        $expected = Get-AzureResourceGroup -Name $rgname

        # Assert
        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
        Assert-AreEqual $expected.Tags[0]["Name"] $actual.Tags[0]["Name"]
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}