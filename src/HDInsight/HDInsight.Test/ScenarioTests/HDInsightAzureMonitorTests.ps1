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
Test Get,Enable or Disable Azure Monitor in Azure HDInsight Cluster
#>
function Test-AzureMonitorRelatedCommands{

	# Create some resources that will be used throughout test 
	try
	{
		$location = "East US"
		# prepare parameter for creating parameter
		$params= Prepare-ClusterCreateParameter -location $location

		# create cluster that will be used throughout test
		$cluster = New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-StorageAccountResourceId $params.storageAccountResourceId -StorageAccountKey $params.storageAccountKey `
		-HttpCredential $params.httpCredential -SshCredential $params.sshCredential -Version 5.1 `
		-MinSupportedTlsVersion $params.minSupportedTlsVersion -VirtualNetworkId $params.virtualNetworkId -SubnetName "default"
		Assert-NotNull $cluster

		$workspaceName = Generate-Name("workspace-ps-test")
		$resourceGroupName = $cluster.ResourceGroup

		#create a new Log Analytics Workspace
		$sku = "pernode"
		$workspace = New-AzOperationalInsightsWorkspace -Location $location -Name $workspaceName -ResourceGroupName $resourceGroupName -Sku $sku

		#get workspace's primaryKey
		$keys = Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName $resourceGroupName -Name $workspace.Name
		Assert-NotNull $keys

		#test Get-AzHDInsightAzureMonitor
		$result = Get-AzHDInsightAzureMonitor -ClusterName $cluster.Name -ResourceGroupName $cluster.ResourceGroup
		Assert-Null $result.WorkspaceId
		
		#test Enable-AzHDInsightAzureMonitor
		$workspaceId = $workspace.CustomerId
		$primaryKey = $keys.PrimarySharedKey

		Assert-NotNull $workspaceId
		Assert-NotNull $primaryKey
		Enable-AzHDInsightAzureMonitor -ClusterName $cluster.Name -ResourceGroup $cluster.ResourceGroup -WorkspaceId $workspaceId -Primary  $primaryKey
		
		$result = Get-AzHDInsightAzureMonitor -ClusterName $cluster.Name -ResourceGroupName $cluster.ResourceGroup
		Assert-True {$result.ClusterMonitoringEnabled}
		Assert-AreEqual $result.WorkspaceId $workspaceId
		
		#test Disable-AzHDInsightAzureMonitor
		Disable-AzHDInsightAzureMonitor -ClusterName $cluster.Name -ResourceGroupName $cluster.ResourceGroup
		$result = Get-AzHDInsightAzureMonitor -ClusterName $cluster.Name -ResourceGroupName $cluster.ResourceGroup
		Assert-False {$result.ClusterMonitoringEnabled}
		Assert-Null $result.WorkspaceId
	}
	finally
	{
		# Delete cluster and resource group
		# Remove-AzResourceGroup -ResourceGroupName $cluster.ResourceGroup
	}
}

function Test-AzureMonitorAgentRelatedCommands{

	# Create some resources that will be used throughout test 
	try
	{
		$location = "East US"
		# prepare parameter for creating parameter
		# $params= Prepare-ClusterCreateParameter -location $location

		# create cluster that will be used throughout test
		$cluster = Get-AzHDInsightCluster -ResourceGroupName yuchen-ps-test -ClusterName spark51
		Assert-NotNull $cluster

		$workspaceName = "ps-la"
		$resourceGroupName = $cluster.ResourceGroup

		#create a new Log Analytics Workspace
		$workspace = Get-AzOperationalInsightsWorkspace -Name $workspaceName -ResourceGroupName $resourceGroupName 

		#get workspace's primaryKey
		$keys = Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName $resourceGroupName -Name $workspace.Name
		Assert-NotNull $keys

		#test Enable-HDInsightAzureMonitorAgent
		$workspaceId = $workspace.CustomerId
		$primaryKey = $keys.PrimarySharedKey

		Assert-NotNull $workspaceId
		Assert-NotNull $primaryKey
		Enable-AzHDInsightAzureMonitorAgent -ClusterName $cluster.Name -ResourceGroup $cluster.ResourceGroup -WorkspaceId $workspaceId -Primary  $primaryKey
		
		$result = Get-AzHDInsightAzureMonitorAgent -ClusterName $cluster.Name -ResourceGroupName $cluster.ResourceGroup
		Assert-True {$result.ClusterMonitoringEnabled}
		Assert-AreEqual $result.WorkspaceId $workspaceId
		
		#test Get-HDInsightAzureMonitorAgent
		$result = Get-AzHDInsightAzureMonitorAgent -ClusterName $cluster.Name -ResourceGroupName $cluster.ResourceGroup
		Assert-NotNull $result.WorkspaceId

		#test Disable-HDInsightAzureMonitorAgent
		Disable-AzHDInsightAzureMonitorAgent -ClusterName $cluster.Name -ResourceGroupName $cluster.ResourceGroup
		$result = Get-AzHDInsightAzureMonitorAgent -ClusterName $cluster.Name -ResourceGroupName $cluster.ResourceGroup
		Assert-False {$result.ClusterMonitoringEnabled}
		Assert-Null $result.WorkspaceId
	}
	finally
	{
		# Delete cluster and resource group
		# Remove-AzResourceGroup -ResourceGroupName $cluster.ResourceGroup
	}
}