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
Test Enable, Disable autoscale of HDInsight cluster.
#>
function Test-AutoscaleRelatedCommands{

	# Create some resources that will be used throughout test
	try
	{
		# prepare parameter for creating parameter
		$params= Prepare-ClusterCreateParameter

		# test create cluster
		$cluster = New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-StorageAccountResourceId $params.storageAccountResourceId -StorageAccountKey $params.storageAccountKey `
		-HttpCredential $params.httpCredential -SshCredential $params.sshCredential `
		-MinSupportedTlsVersion $params.minSupportedTlsVersion -VirtualNetworkId $params.virtualNetworkId -SubnetName "default"

		Assert-NotNull $cluster

		# test Set-AzHDInsightClusterAutoscaleConfiguration: enable Load-based autoscale
		$loadAutoscaleCluster=Set-AzHDInsightClusterAutoscaleConfiguration -ResourceGroupName $cluster.ResourceGroup `
		-ClusterName $cluster.Name -MinWorkerNodeCount 4 -MaxWorkerNodeCount 5

		Assert-NotNull $loadAutoscaleCluster
		Assert-NotNull $loadAutoscaleCluster.ComputeProfile.Roles[1].AutoscaleConfiguration.Capacity
		Assert-Null $loadAutoscaleCluster.ComputeProfile.Roles[1].AutoscaleConfiguration.Recurrence

		# test Get-AzHDInsightClusterAutoscaleConfiguration
		$autoscale = Get-AzHDInsightClusterAutoscaleConfiguration -ClusterName $cluster.Name -ResourceGroupName $cluster.ResourceGroup
		Assert-AreEqual $autoscale.Capacity.MinInstanceCount  4
		Assert-AreEqual $autoscale.Capacity.MaxInstanceCount  5

		Start-TestSleep -Seconds 20
		# test Remove-AzHDInsightClusterAutoscaleConfiguration
		Remove-AzHDInsightClusterAutoscaleConfiguration -ClusterName $cluster.Name -ResourceGroupName $cluster.ResourceGroup
		
		# test Set-AzHDInsightClusterAutoscaleConfiguration: enable Schedule-based autoscale
		# test New-AzHDInsightAutoscaleScheduleCondition
		$condition1=New-AzHDInsightClusterAutoscaleScheduleCondition -Time 09:00 -WorkerNodeCount 5 -Day Monday,Tuesday
		$condition2=New-AzHDInsightClusterAutoscaleScheduleCondition -Time 08:00 -WorkerNodeCount 4 -Day Friday

		$scheduleAutoscaleCluster=Set-AzHDInsightClusterAutoscaleConfiguration -ResourceGroupName $cluster.ResourceGroup `
		-ClusterName $cluster.Name -Schedule -TimeZone "Pacific Standard Time" -Condition $condition1,$condition2

		Assert-AreEqual $scheduleAutoscaleCluster.ComputeProfile.Roles[1].AutoscaleConfiguration.Recurrence.TimeZone "Pacific Standard Time"
		Assert-AreEqual $scheduleAutoscaleCluster.ComputeProfile.Roles[1].AutoscaleConfiguration.Recurrence.Condition[0].WorkerNodeCount 5
	}
	finally
	{
		# Delete cluster and resource group
		Remove-AzResourceGroup -ResourceGroupName $cluster.ResourceGroup
	}
}
