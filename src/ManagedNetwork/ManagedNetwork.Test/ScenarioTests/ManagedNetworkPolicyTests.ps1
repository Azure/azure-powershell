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
function Test-GetSetManagedNetworkPolicy
{
	$resourceGroup = "MNCRG"
	$managedNetworkName = "PowershellTestMNforPolicy"
	$groupnameHubSpoke = "TestGroup"
	$groupnameMesh = "TestGroupMesh"
	$policyNameHubSpoke = "TestPolicyHubSpoke"
	$policyNameMesh = "TestPolicyMesh"
	$location = "West US 2"

	
	[System.Collections.Generic.List[String]]$virtualNetworkList = @()
	$vnet1 = "/subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Spoke11"
	$vnet2 = "/subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Spoke12"
	$vnet3 = "/subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Hub"
	$vnet4 = "/subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Spoke4"
	$vnet5 = "/subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Spoke5"
	$vnet6 = "/subscriptions/18ba8369-92e4-4d70-8b1e-937660bde798/resourceGroups/MNC-Portal/providers/Microsoft.Network/virtualNetworks/Spoke6"
	$virtualNetworkList.Add($vnet1)
	$virtualNetworkList.Add($vnet2)
	$virtualNetworkList.Add($vnet3)
	$virtualNetworkList.Add($vnet4)
	$virtualNetworkList.Add($vnet5)
	$virtualNetworkList.Add($vnet6)
	[System.String[]]$virtualNetworkArray = $virtualNetworkList

	$scope = New-AzManagedNetworkScope -VirtualNetworkIdList $virtualNetworkArray
	New-AzManagedNetwork -ResourceGroupName $resourceGroup -Name $managedNetworkName -scope $scope -Location $location -Force
	$managedNetwork = Get-AzManagedNetwork -ResourceGroupName $resourceGroup -Name $managedNetworkName

	[System.Collections.Generic.List[String]]$virtualNetworkGroupList = @()	
	$virtualNetworkGroupList.Add($vnet1)
	$virtualNetworkGroupList.Add($vnet2)
	[System.String[]]$virtualNetworkGroupArray = $virtualNetworkGroupList;

	New-AzManagedNetworkGroup -ResourceGroupName $resourceGroup -ManagedNetworkName $managedNetworkName -Name $groupnameHubSpoke -Location $location -VirtualNetworkIdList $virtualNetworkGroupArray -Force
	$SpokeGroupResult = Get-AzManagedNetworkGroup -ResourceGroupName $resourceGroup -ManagedNetworkName $managedNetworkName -Name $groupnameHubSpoke
	

	[System.Collections.Generic.List[String]]$meshgroupList = @()	
	$meshgroupList.Add($vnet4)
	$meshgroupList.Add($vnet5)
	$meshgroupList.Add($vnet6)
	[System.String[]] $meshgroupArray = $meshgroupList
	New-AzManagedNetworkGroup -ResourceGroupName $resourceGroup -ManagedNetworkName $managedNetworkName -Name $groupnameMesh -Location $location -VirtualNetworkIdList $meshgroupArray -Force
	$MeshGroupResult = Get-AzManagedNetworkGroup -ResourceGroupName $resourceGroup -ManagedNetworkName $managedNetworkName -Name $groupnameMesh

	$PeeringPolicyType = "HubAndSpokeTopology"
	$hub = $vnet3
	[System.Collections.Generic.List[String]]$spokes = @()
	$spokes.Add($SpokeGroupResult.Id)
	[System.String[]] $spokesArray = $spokes
	New-AzManagedNetworkPeeringPolicy -ResourceGroupName $resourceGroup -ManagedNetworkName $managedNetworkName -Name $policyNameHubSpoke -Location $location -Hub $hub -SpokeList $spokesArray -PeeringPolicyType $PeeringPolicyType -Force
	$managedNetworkPolicyResult = Get-AzManagedNetworkPeeringPolicy -ResourceGroupName $resourceGroup -ManagedNetworkName $managedNetworkName -Name $policyNameHubSpoke
	Assert-AreEqual $policyNameHubSpoke $managedNetworkPolicyResult.Name
	Assert-AreEqual $location $managedNetworkPolicyResult.Location
	Assert-AreEqual $hub $managedNetworkPolicyResult.Properties.Hub.Id


	$PeeringPolicyTypeMesh = "MeshTopology"
	[System.Collections.Generic.List[String]]$mesh = @()	
	$mesh.Add($MeshGroupResult.id)
	[System.String[]] $meshArray = $mesh
	New-AzManagedNetworkPeeringPolicy -ManagedNetworkObject $managedNetwork -Name $policyNameMesh -Location $location -Mesh $meshArray -PeeringPolicyType $PeeringPolicyTypeMesh -Force
	$meshPolicyResult = Get-AzManagedNetworkPeeringPolicy -ResourceGroupName $resourceGroup -ManagedNetworkName $managedNetworkName -Name $policyNameMesh
	Assert-AreEqual $policyNameMesh $meshPolicyResult.Name
	Assert-AreEqual $location $meshPolicyResult.Location
}