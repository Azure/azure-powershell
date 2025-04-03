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
Test list and restart the hosts of Azure HDInsight Cluster
#>

function Test-HostRelatedCommands{

	# Create some resources that will be used throughout test
	try
	{
		# prepare parameter for creating parameter
		$params= Prepare-ClusterCreateParameter

		# create cluster that will be used throughout test
		$cluster = New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-StorageAccountResourceId $params.storageAccountResourceId -StorageAccountKey $params.storageAccountKey `
		-HttpCredential $params.httpCredential -SshCredential $params.sshCredential `
		-MinSupportedTlsVersion $params.minSupportedTlsVersion -VirtualNetworkId $params.virtualNetworkId -SubnetName "default"
		Assert-NotNull $cluster

		# test Get-AzHDInsightHost
		$result = Get-AzHDInsightHost -ResourceGroupName $cluster.ResourceGroup -ClusterName $cluster.Name 
		Assert-NotNull $result
		
		# test Restart-AzHDInsightHost
		$workernode1= $result|Where-Object {$_.Name -like "wn1*"}
		$resizeCluster = $workernode1 | Restart-AzHDInsightHost -ResourceGroupName $cluster.ResourceGroup -ClusterName $cluster.Name
	}
	finally
	{
		# Delete cluster and resource group
		Remove-AzResourceGroup -ResourceGroupName $cluster.ResourceGroup
	}
}
