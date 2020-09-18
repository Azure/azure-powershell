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
Test Create and resize Azure HDInsight Cluster
#>

function Test-ClusterRelatedCommands{

	# Create some resources that will be used throughout test
	try
	{
		# prepare parameter for creating parameter
		$params= Prepare-ClusterCreateParameterForWASB

		# test create cluster
		$cluster = New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-DefaultStorageAccountName $params.storageAccountName -DefaultStorageAccountKey $params.storageAccountKey `
		-HttpCredential $params.httpCredential -SshCredential $params.sshCredential `
		-MinSupportedTlsVersion $params.minSupportedTlsVersion

		Assert-NotNull $cluster
		
		#test Get-AzHDInsightCluster
		$resultCluster = Get-AzHDInsightCluster -ClusterName $cluster.Name
		Assert-AreEqual $resultCluster.Name  $cluster.Name
		
		#test Set-AzHDInsightClusterSize
		$resizeCluster = Set-AzHDInsightClusterSize -ClusterName $cluster.Name -ResourceGroupName $cluster.ResourceGroup `
		-TargetInstanceCount 3
		Assert-AreEqual $resizeCluster.CoresUsed 20
	}
	finally
	{
		# Delete cluster and resource group
		Remove-AzHDInsightCluster -ClusterName $cluster.Name
		Remove-AzResourceGroup -ResourceGroupName $cluster.ResourceGroup
	}
}


<#
.SYNOPSIS
Test Create and Rotate Azure HDInsight Cluster with CMK
#>
function Test-CmkClusterRelatedCommands{

	# Create some resources that will be used throughout test
	try
	{
		$location="East US"
		$clusterName="hdi-ps-cmktest"
		$clusterName=Generate-Name($clusterName)
		$vaultName="vault-ps-cmktest"
		$vaultName=Generate-Name($vaultName)
		$keyName="key-ps-cmktest"
		$keyName=Generate-Name($keyName)
		$assignedIdentityName="ami-ps-cmktest"
		$assignedIdentityName=Generate-Name($assignedIdentityName)
		$newKeyName="newkey-ps-cmktest"
		$newKeyName=Generate-Name($newKeyName)

		# test create cluster
		$cluster = Create-CMKCluster -clusterName $clusterName -location $location -vaultName $vaultName -KeyName $keyName -assignedIdentityName $assignedIdentityName
		Assert-NotNull $cluster
		Assert-AreEqual $cluster.DiskEncryption.KeyName $keyName

		#test Set-AzHDInsightClusterDiskEncryptionKey
		$encryptionKey=Create-KeyIdentity -resourceGroupName $cluster.ResourceGroup -vaultName $vaultName -keyName $newKeyName
		$rotateKeyCluster = Set-AzHDInsightClusterDiskEncryptionKey -ClusterName $cluster.Name -ResourceGroupName $cluster.ResourceGroup `
		-EncryptionKeyName $encryptionKey.Name -EncryptionKeyVersion $encryptionKey.Version -EncryptionVaultUri $encryptionKey.Vault
		Assert-AreEqual $rotateKeyCluster.DiskEncryption.KeyVersion $encryptionKey.Version
		Assert-AreEqual $rotateKeyCluster.DiskEncryption.KeyName $encryptionKey.Name
	}
	finally
	{
		# Delete cluster and resource group
		Remove-AzHDInsightCluster -ClusterName $cluster.Name
		Remove-AzResourceGroup -ResourceGroupName $cluster.ResourceGroup
	}
}

<#
.SYNOPSIS
Test Create Azure HDInsight Cluster which Enalbes Encryption In Transit
#>

function Test-CreateClusterWithEncryptionInTransit{

	# Create some resources that will be used throughout test
	try
	{
		# prepare parameter for creating parameter
		$params= Prepare-ClusterCreateParameterForWASB -Location "South Central US"
		$encryptionInTransit=$true

		# create cluster
		$cluster=New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-DefaultStorageAccountName $params.storageAccountName -DefaultStorageAccountKey $params.storageAccountKey `
		-HttpCredential $params.httpCredential -SshCredential $params.sshCredential `
		-MinSupportedTlsVersion $params.minSupportedTlsVersion -EncryptionInTransit $encryptionInTransit

		Assert-AreEqual $cluster.EncryptionInTransit $encryptionInTransit
		
	}
	finally
	{
		# Delete cluster and resource group
		Remove-AzHDInsightCluster -ClusterName $cluster.Name
		Remove-AzResourceGroup -ResourceGroupName $cluster.ResourceGroup
	}
}

<#
.SYNOPSIS
Test Create Azure HDInsight Cluster which enalbes Encryption At Host
#>

function Test-CreateClusterWithEncryptionAtHost{

	# Create some resources that will be used throughout test
	try
	{
		# prepare parameter for creating parameter
		$params= Prepare-ClusterCreateParameterForWASB -location "South Central US"
		$encryptionAtHost=$true
		$workerNodeSize="Standard_DS14_v2"
		$headNodeSize="Standard_DS14_v2"
		$zookeeperNodeSize="Standard_DS14_v2"

		# create cluster
		$cluster=New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-WorkerNodeSize $workerNodeSize -HeadNodeSize $headNodeSize -ZookeeperNodeSize $zookeeperNodeSize `
		-DefaultStorageAccountName $params.storageAccountName -DefaultStorageAccountKey $params.storageAccountKey `
		-HttpCredential $params.httpCredential -SshCredential $params.sshCredential `
		-MinSupportedTlsVersion $params.minSupportedTlsVersion -EncryptionAtHost $encryptionAtHost

		Assert-AreEqual $cluster.DiskEncryption.EncryptionAtHost $encryptionAtHost
		
	}
	finally
	{
		# Delete cluster and resource group
		Remove-AzHDInsightCluster -ClusterName $cluster.Name
		Remove-AzResourceGroup -ResourceGroupName $cluster.ResourceGroup
	}
}

<#
.SYNOPSIS
Test Create Azure HDInsight Cluster with Load-based autoscale
#>

function Test-CreateClusterWithLoadBasedAutoscale{

	# Create some resources that will be used throughout test
	try
	{
		# prepare parameter for creating parameter
		$params= Prepare-ClusterCreateParameterForWASB -location "East US"

		# create autoscale cofiguration
		$autoscaleConfiguration=New-AzHDInsightClusterAutoscaleConfiguration -MinWorkerNodeCount 4 -MaxWorkerNodeCount 5

		# create cluster with load-based autoscale
		$cluster=New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-DefaultStorageAccountName $params.storageAccountName -DefaultStorageAccountKey $params.storageAccountKey `
		-HttpCredential $params.httpCredential -SshCredential $params.sshCredential `
		-MinSupportedTlsVersion $params.minSupportedTlsVersion -Version 4.0 `
		-AutoscaleConfiguration $autoscaleConfiguration

		Assert-NotNull $cluster
		Assert-AreEqual $cluster.ComputeProfile.Roles[1].AutoscaleConfiguration.Capacity.MinInstanceCount 4
		Assert-AreEqual $cluster.ComputeProfile.Roles[1].AutoscaleConfiguration.Capacity.MaxInstanceCount 5
	}
	finally
	{
		# Delete cluster and resource group
		Remove-AzHDInsightCluster -ClusterName $cluster.Name
		Remove-AzResourceGroup -ResourceGroupName $cluster.ResourceGroup
	}
}

<#
.SYNOPSIS
Test Create Azure HDInsight Cluster with Schedule-based autoscale
#>

function Test-CreateClusterWithScheduleBasedAutoscale{

	# Create some resources that will be used throughout test
	try
	{
		# prepare parameter for creating parameter
		$params= Prepare-ClusterCreateParameterForWASB -location "East US"

		# create autoscale schedule condition
		$condition1=New-AzHDInsightClusterAutoscaleScheduleCondition -Time "09:00" -WorkerNodeCount 4 -Day Monday,Tuesday
		$condition2=New-AzHDInsightClusterAutoscaleScheduleCondition -Time "08:00" -WorkerNodeCount 5 -Day Friday

		# create autoscale configuration
		$autoscaleConfiguration=New-AzHDInsightClusterAutoscaleConfiguration -TimeZone ([System.TimeZoneInfo]::Local).Id `
		-Condition $condition1,$condition2

		# create cluster with schedule-based autoscale
		$cluster=New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-DefaultStorageAccountName $params.storageAccountName -DefaultStorageAccountKey $params.storageAccountKey `
		-HttpCredential $params.httpCredential -SshCredential $params.sshCredential `
		-MinSupportedTlsVersion $params.minSupportedTlsVersion -Version 4.0 `
		-AutoscaleConfiguration $autoscaleConfiguration

		Assert-NotNull $cluster
		Assert-NotNull $cluster.ComputeProfile.Roles[1].AutoscaleConfiguration.Recurrence
		Assert-AreEqual $cluster.ComputeProfile.Roles[1].AutoscaleConfiguration.Recurrence.Condition[0].WorkerNodeCount $condition1.WorkerNodeCount
		Assert-AreEqual $cluster.ComputeProfile.Roles[1].AutoscaleConfiguration.Recurrence.Condition[1].WorkerNodeCount $condition2.WorkerNodeCount
	}
	finally
	{
		# Delete cluster and resource group
		Remove-AzHDInsightCluster -ClusterName $cluster.Name
		Remove-AzResourceGroup -ResourceGroupName $cluster.ResourceGroup
	}
}
