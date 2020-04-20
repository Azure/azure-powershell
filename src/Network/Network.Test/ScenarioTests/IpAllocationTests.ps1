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
function Test-IpAllocation
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement "westus"
    $location = Get-ProviderLocation ResourceManagement "westus"
	$IpGroupsName = Get-ResourceName

    try
    {
        # IpAllocation resource need manually onboard by subscription
        $subId = Get-SubscriptionIdFromResourceGroup $rgname;
        $vnetId = '/subscriptions/' + $subId + '/resourceGroups/' + $rgname + '/providers/Microsoft.Network/virtualNetworks/HypernetVnet1';
		
		$ipAllocationName = 'testIpAllocation'
		New-AzIpAllocation -ResourceName $ipAllocationName -ResourceGroupName $rgname -Location $rglocation -IpAllocationType Hypernet -PrefixLength 29 -PrefixType IPV4 -IpAllocationTag @{"VNetID"=$vnetId;"SubnetName"="HypernetSubnet1"}

		Set-AzIpAllocation -Name $ipAllocationName -ResourceGroupName $rgname -Tag @{'testtag'='tetsvalue'}

		Remove-AzIpAllocation -Name $ipAllocationName -ResourceGroupName $rgname
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
