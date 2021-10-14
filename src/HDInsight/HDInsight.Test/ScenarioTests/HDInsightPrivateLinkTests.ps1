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
Test Create Azure HDInsight Cluster with Relay Outbound and Private Link
#>

function Test-PrivateLinkRelatedCommands{

	# Create some resources that will be used throughout test
	try
	{
		# prepare parameter for creating parameter
		$params= Prepare-ClusterCreateParameter -location "South Central US"
		Write-Output $params
		Write-Output $params

		# Private Link requires vnet has firewall, this is difficult to create dynamically,just hardcode here
		$vnetId="/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/virtualNetworks/fakevnet"
		$subnetName="default"

		$ipConfigName="ipconfig"
		$privateIPAllocationMethod="dynamic" # the only supported IP allocation method forprivate link IP configuration is dynamic
		$subnetId=$vnetId+"/subnets/"+$subnetName
		# Create Private IP configuration
		$ipConfiguration= New-AzHDInsightIPConfiguration -Name $ipConfigName -PrivateIPAllocationMethod $privateIPAllocationMethod `
		-SubnetId $subnetId -Primary

		$privateLinkConfigurationName="plconfig"
		$groupId="headnode"
		# Create private link configuration
		$privateLinkConfiguration= New-AzHDInsightPrivateLinkConfiguration -Name $privateLinkConfigurationName `
		-GroupId $groupId -IPConfiguration $ipConfiguration

		# create cluster
		$cluster = New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-StorageAccountResourceId $params.storageAccountResourceId -StorageAccountKey $params.storageAccountKey `
		-HttpCredential $params.httpCredential -SshCredential $params.sshCredential `
		-MinSupportedTlsVersion $params.minSupportedTlsVersion `
		-VirtualNetworkId $vnetId -SubnetName $subnetName -Version 3.6 `
		-ResourceProviderConnection Outbound -PrivateLink Enabled -PrivateLinkConfiguration $privateLinkConfiguration

		Assert-AreEqual $cluster.NetworkProperties.ResourceProviderConnection Outbound
		Assert-AreEqual $cluster.NetworkProperties.PrivateLink Enabled
		Assert-NotNull $cluster.PrivateLinkConfigurations
		
		# Get Private Link Service
		$privateLinkServices= Get-AzHDInsightPrivateLinkResource -ResourceGroupName $cluster.ResourceGroup -ClusterName $cluster.Name

		# Create Private endpoint Connection
		$privateLinkServiceConnectionName="plsc"
		$groupId="headnode"
		$plsConnection=New-AzPrivateLinkServiceConnection -Name $privateLinkServiceConnectionName -GroupId $groupId -PrivateLinkServiceId $cluster.Id

		$virtualNetwork = Get-AzVirtualNetwork -Name fakevnet -ResourceGroupName "rg"
		$subnet = $virtualNetwork | Select-Object -ExpandProperty subnets | Where-Object Name -eq "default"
		$privateEndpointName="privateendpoint"
		$privateEndpoint = New-AzPrivateEndpoint -Name $privateEndpointName -ResourceGroup $cluster.ResourceGroup -Location $cluster.Location -PrivateLinkServiceConnection $plsConnection -Subnet $subnet

		# Get private endpoint connection
		$getPrivateEndpointConnectionResult= Get-AzHDInsightPrivateEndpointConnection -ResourceGroupName $cluster.ResourceGroup -ClusterName $cluster.Name
		$getPrivateEndpointConnectionResult =$getPrivateEndpointConnectionResult[0]
		Assert-AreEqual $getPrivateEndpointConnectionResult.PrivateLinkServiceConnectionState.Status "Approved"

		# Reject Private endpoint connection
		Set-AzHDInsightPrivateEndpointConnection -ResourceId $getPrivateEndpointConnectionResult.Id -PrivateLinkServiceConnectionState "Rejected"

		Start-Sleep -Seconds 30
		$getPrivateEndpointConnectionResult= Get-AzHDInsightPrivateEndpointConnection -ResourceGroupName $cluster.ResourceGroup -ClusterName $cluster.Name
		$getPrivateEndpointConnectionResult =$getPrivateEndpointConnectionResult[0]
		Assert-AreEqual $getPrivateEndpointConnectionResult.PrivateLinkServiceConnectionState.Status "Rejected"

		# Remove Private endpoint connection
		Remove-AzHDInsightPrivateEndpointConnection -ResourceId $getPrivateEndpointConnectionResult.Id
	}
	finally
	{
		# Delete cluster and resource group
		Remove-AzHDInsightCluster -ClusterName $cluster.Name
		Remove-AzResourceGroup -ResourceGroupName $cluster.ResourceGroup
	}
}
