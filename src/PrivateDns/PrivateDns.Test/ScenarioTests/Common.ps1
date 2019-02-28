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
Gets valid resource group name
#>
function Get-ResourceGroupName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets valid resource name
#>
function Get-ResourceName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets valid virtual network name
#>
function Get-VirtualNetworkName
{
    return getAssetName
}

<#
.SYNOPSIS
Creates a resource group to use in tests
#>
function TestSetup-CreateResourceGroup
{
    $resourceGroupName = Get-ResourceGroupName
	$rglocation = "West US"
    $resourceGroup = New-AzResourceGroup -Name $resourceGroupName -location $rglocation
	return $resourceGroup
}

<#
.SYNOPSIS
Creates a virtual network to use in tests
#>
function TestSetup-CreateVirtualNetwork($resourceGroup)
{
    $virtualNetworkName = Get-VirtualNetworkName
	$location = Get-Location -ProviderNamespace "microsoft.network" -ResourceType "virtualNetworks" -PreferredLocation "West US"  
    $virtualNetwork = New-AzVirtualNetwork -Name $virtualNetworkName -ResourceGroupName $resourceGroup.ResourceGroupName -Location $location -AddressPrefix "10.0.0.0/8"
	return $virtualNetwork
}

function Get-RandomZoneName
{
	$prefix = getAssetName;
	return $prefix + ".pstest.test" ;
}

function Get-TxtOfSpecifiedLength([int] $length)
{
	$returnValue = "";
	for ($i = 0; $i -lt $length ; $i++)
	{
		$returnValue += "a";
	}
	return $returnValue;
}