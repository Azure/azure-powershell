#----------------------------------------------------------------------------------

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

function Check-CmdletReturnType
{
    param($cmdletName, $cmdletReturn)

    $cmdletData = Get-Command $cmdletName
    Assert-NotNull $cmdletData
    [array]$cmdletReturnTypes = $cmdletData.OutputType.Name | Foreach-Object { return ($_ -replace "Microsoft.Azure.Commands.Network.Models.","") }
    [array]$cmdletReturnTypes = $cmdletReturnTypes | Foreach-Object { return ($_ -replace "System.","") }
    $realReturnType = $cmdletReturn.GetType().Name -replace "Microsoft.Azure.Commands.Network.Models.",""
    return $cmdletReturnTypes -contains $realReturnType
}

<#
.SYNOPSIS
Test creating new IpGroups
#>
function Test-IpGroupsCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement "westus"
    $location = Get-ProviderLocation ResourceManagement "westus"
	$IpGroupsName = Get-ResourceName

    try
    {
      # Create the resource group
      New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

      # Create IpGroup
	  $actualIpGroup = New-AzIpGroup -ResourceGroupName $rgname -location $location -Name $IpGroupsName -IpAddress 10.0.0.0/24,11.9.0.0/24
      $expectedIpGroup = Get-AzIpGroup -ResourceGroupName $rgname -Name $IpGroupsName
	  Assert-AreEqual $expectedIpGroup.ResourceGroupName $actualIpGroup.ResourceGroupName	
      Assert-AreEqual $expectedIpGroup.Name $actualIpGroup.Name

	  # Delete IpGroup
	  $deleteIpGroup = Remove-AzIpGroup -ResourceGroupName $rgname -Name $IpGroupsName -PassThru -Force
      Assert-AreEqual true $deleteIpGroup

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
