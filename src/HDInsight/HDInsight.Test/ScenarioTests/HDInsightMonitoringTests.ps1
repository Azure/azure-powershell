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
Test Get,Enable or Disable Azure HDInsight Cluster monitoring
#>
function Test-MonitoringRelatedCommands{

	# Create some resources that will be used throughout test 
	try
	{
		$location = "EastUS"
		# prepare parameter for creating parameter
		$params= Prepare-ClusterCreateParameter

		# test create cluster
		$cluster = New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-StorageAccountResourceId $params.storageAccountResourceId -StorageAccountKey $params.storageAccountKey `
		-HttpCredential $params.httpCredential -SshCredential $params.sshCredential `
		-MinSupportedTlsVersion $params.minSupportedTlsVersion -VirtualNetworkId $params.virtualNetworkId -SubnetName "default"

		$workspaceName = Generate-Name("workspace-ps-test")
		$resourceGroupName = $cluster.ResourceGroup

		#create a new Log Analytics Workspace
		$sku = "pernode"
		$workspace = New-AzOperationalInsightsWorkspace -Location $location -Name $workspaceName -ResourceGroupName $resourceGroupName -Sku $sku

		#get workspace's primaryKey
		$keys = Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName $resourceGroupName -Name $workspace.Name
		Assert-NotNull $keys
		#test Get-AzHDInsightMonitoring
		$result = Get-AzHDInsightMonitoring -ClusterName $cluster.Name -ResourceGroupName $cluster.ResourceGroup
		Assert-Null $result.WorkspaceId
		
		#test Enable-AzHDInsightmonitoring
		$workspaceId = $workspace.CustomerId
		$primaryKey = $keys.PrimarySharedKey

		Assert-NotNull $workspaceId
		Assert-NotNull $primaryKey
		Enable-AzHDInsightMonitoring -ClusterName $cluster.Name -ResourceGroup $cluster.ResourceGroup -WorkspaceId $workspaceId -Primary  $primaryKey
		
		$result = Get-AzHDInsightMonitoring -ClusterName $cluster.Name -ResourceGroupName $cluster.ResourceGroup
		Assert-True {$result.ClusterMonitoringEnabled}
		Assert-AreEqual $result.WorkspaceId $workspaceId
		
		#test Disable-AzHDInsightMonitoring
		Disable-AzHDInsightMonitoring -ClusterName $cluster.Name -ResourceGroupName $cluster.ResourceGroup
		$result = Get-AzHDInsightMonitoring -ClusterName $cluster.Name -ResourceGroupName $cluster.ResourceGroup
		Assert-False {$result.ClusterMonitoringEnabled}
		Assert-Null $result.WorkspaceId

	}
	finally
	{
		# Delete cluster and resource group
		Remove-AzResourceGroup -ResourceGroupName $cluster.ResourceGroup
	}
}
