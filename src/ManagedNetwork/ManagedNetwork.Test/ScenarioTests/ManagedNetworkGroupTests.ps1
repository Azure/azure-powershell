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
Gets or sets origin with the running endpoint
#>
function Test-GetSetManagedNetworkGroup
{
	$resourceGroup = "MNCRG"
	$managedNetworkName = "PowershellTestMNforGroup"
	$managedNetworkName2 = "PowershellTestMNforGroup_2"
	$name = "TestGroup"
	$location = "West US 2"

	
	[System.Collections.Generic.List[String]]$virtualNetworkList = @()

	$vnet1 = "/subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-PowerShell/providers/Microsoft.Network/virtualnetworks/Mesh1"
	$vnet2 = "/subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-PowerShell/providers/Microsoft.Network/virtualnetworks/Mesh2"
	$vnet3 = "/subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-PowerShell/providers/Microsoft.Network/virtualnetworks/Mesh3"
	$virtualNetworkList.Add($vnet1)
	$virtualNetworkList.Add($vnet2)
	$virtualNetworkList.Add($vnet3)

	[System.String[]]$virtualNetworkArray = $virtualNetworkList
	$scope = New-AzManagedNetworkScope -VirtualNetworkIdList $virtualNetworkArray

	New-AzManagedNetwork -ResourceGroupName $resourceGroup -Name $managedNetworkName -scope $scope -Location $location -Force
	New-AzManagedNetwork -ResourceGroupName $resourceGroup -Name $managedNetworkName2 -scope $scope -Location $location -Force


	$managedNetwork = Get-AzManagedNetwork -ResourceGroupName $resourceGroup -Name $managedNetworkName2

	[System.Collections.Generic.List[String]]$virtualNetworkGroupList = @()	
	$virtualNetworkGroupList.Add($vnet1)
	$virtualNetworkGroupList.Add($vnet2)
	[System.String[]]$virtualNetworkGroupArray = $virtualNetworkGroupList

	New-AzManagedNetworkGroup -ResourceGroupName $resourceGroup -ManagedNetworkName $managedNetworkName -Name $name -Location $location -VirtualNetworkIdList $virtualNetworkGroupArray -Force
	$managedNetworkGroupResult = Get-AzManagedNetworkGroup -ResourceGroupName $resourceGroup -ManagedNetworkName $managedNetworkName -Name $name
	Assert-AreEqual $name $managedNetworkGroupResult.Name
	Assert-AreEqual $location $managedNetworkGroupResult.Location

	[System.Collections.Generic.List[String]]$virtualNetworkGroupList2 = @()	
	$virtualNetworkGroupList2.Add($vnet1)
	[System.String[]]$virtualNetworkGroupArray2 = $virtualNetworkGroupList2

	New-AzManagedNetworkGroup -ManagedNetworkObject $managedNetwork -Name $name -Location $location -VirtualNetworkIdList $virtualNetworkGroupArray2 -Force
	$managedNetworkGroupResult2 = Get-AzManagedNetworkGroup -ResourceGroupName $resourceGroup -ManagedNetworkName $managedNetworkName2 -Name $name
	Assert-AreEqual $name $managedNetworkGroupResult2.Name
	Assert-AreEqual $location $managedNetworkGroupResult2.Location
}