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
		$params= Prepare-ClusterCreateParameter

		# test create cluster
		$cluster = New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-StorageAccountResourceId $params.storageAccountResourceId -StorageAccountKey $params.storageAccountKey `
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
		$params= Prepare-ClusterCreateParameter -Location "South Central US"
		$encryptionInTransit=$true

		# create cluster
		$cluster=New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-StorageAccountResourceId $params.storageAccountResourceId -StorageAccountKey $params.storageAccountKey `
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
		$params= Prepare-ClusterCreateParameter -location "South Central US"
		$encryptionAtHost=$true
		$workerNodeSize="Standard_DS14_v2"
		$headNodeSize="Standard_DS14_v2"
		$zookeeperNodeSize="Standard_DS14_v2"

		# create cluster
		$cluster=New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-WorkerNodeSize $workerNodeSize -HeadNodeSize $headNodeSize -ZookeeperNodeSize $zookeeperNodeSize `
		-StorageAccountResourceId $params.storageAccountResourceId -StorageAccountKey $params.storageAccountKey `
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
		$params= Prepare-ClusterCreateParameter -location "East US"

		# create autoscale cofiguration
		$autoscaleConfiguration=New-AzHDInsightClusterAutoscaleConfiguration -MinWorkerNodeCount 4 -MaxWorkerNodeCount 5

		# create cluster with load-based autoscale
		$cluster=New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-StorageAccountResourceId $params.storageAccountResourceId -StorageAccountKey $params.storageAccountKey `
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
		$params= Prepare-ClusterCreateParameter -location "East US"

		# create autoscale schedule condition
		$condition1=New-AzHDInsightClusterAutoscaleScheduleCondition -Time "09:00" -WorkerNodeCount 4 -Day Monday,Tuesday
		$condition2=New-AzHDInsightClusterAutoscaleScheduleCondition -Time "08:00" -WorkerNodeCount 5 -Day Friday

		# create autoscale configuration
		$autoscaleConfiguration=New-AzHDInsightClusterAutoscaleConfiguration -TimeZone ([System.TimeZoneInfo]::Local).Id `
		-Condition $condition1,$condition2

		# create cluster with schedule-based autoscale
		$cluster=New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-StorageAccountResourceId $params.storageAccountResourceId -StorageAccountKey $params.storageAccountKey `
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

<#
.SYNOPSIS
Test Create Azure HDInsight Cluster with kafka rest proxy.
#>

function Test-CreateClusterWithKafkaRestProxy{
# Create some resources that will be used throughout test
	try
	{
		# prepare parameter for creating parameter
		$params= Prepare-ClusterCreateParameter -location "South Central US" -clusterType Kafka
		$kafkaClientGroupName="FakeClientGroup"
		$kafkaClientGroupId="00000000-0000-0000-0000-000000000000"
		$disksPerWorkerNode=2

		# test create cluster
		$cluster = New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-StorageAccountResourceId $params.storageAccountResourceId -StorageAccountKey $params.storageAccountKey `
		-HttpCredential $params.httpCredential -SshCredential $params.sshCredential `
		-MinSupportedTlsVersion $params.minSupportedTlsVersion -KafkaClientGroupId  $kafkaClientGroupId `
		-KafkaClientGroupName $kafkaClientGroupName -DisksPerWorkerNode $disksPerWorkerNode `
		-KafkaManagementNodeSize Standard_D4_v2

		Assert-NotNull $cluster
		#test Get-AzHDInsightCluster
		$resultCluster = Get-AzHDInsightCluster -ClusterName $cluster.Name
		Assert-AreEqual $resultCluster.Name  $cluster.Name
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
Test Create Azure HDInsight Cluster with Relay Outbound and Private Link
#>

function Test-CreateClusterWithRelayOutoundAndPrivateLink{

	# Create some resources that will be used throughout test
	try
	{
		# prepare parameter for creating parameter
		$params= Prepare-ClusterCreateParameter -location "South Central US"

		# Private Link requires vnet has firewall, this is difficult to create dynamically, just hardcode here
		$vnetId="/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/virtualNetworks/fakevnet"
		$subnetName="default"

		# create cluster
		$cluster = New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-StorageAccountResourceId $params.storageAccountResourceId -StorageAccountKey $params.storageAccountKey `
		-HttpCredential $params.httpCredential -SshCredential $params.sshCredential `
		-MinSupportedTlsVersion $params.minSupportedTlsVersion `
		-VirtualNetworkId $vnetId -SubnetName $subnetName -Version 3.6 `
		-ResourceProviderConnection Outbound -PrivateLink Enabled

		Assert-AreEqual $cluster.NetworkProperties.ResourceProviderConnection Outbound
		Assert-AreEqual $cluster.NetworkProperties.PrivateLink Enabled
		
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
Test Create Azure HDInsight Cluster with custom ambari database
#>

function Test-CreateClusterWithCustomAmbariDatabase{

	# Create some resources that will be used throughout test
	try
	{
		# prepare parameter for creating parameter
		$params= Prepare-ClusterCreateParameter -location "South Central US"

		# prepare custom ambari database
		$databaseUserName="databaseuser"
		$databasePassword="xxxxxxx"
		$databasePassword=ConvertTo-SecureString $databasePassword -AsPlainText -Force
		$sqlserverCredential=New-Object System.Management.Automation.PSCredential($databaseUserName, $databasePassword)
		$sqlserver="yoursqlserver.database.windows.net"
		$database="yourdatabase"
		$config=New-AzHDInsightClusterConfig

		# create cluster
		$cluster = New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-StorageAccountResourceId $params.storageAccountResourceId -StorageAccountKey $params.storageAccountKey `
		-HttpCredential $params.httpCredential -SshCredential $params.sshCredential `
		-MinSupportedTlsVersion $params.minSupportedTlsVersion `
		-AmbariDatabase $config.AmbariDatabase

		Assert-NotNull $cluster

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
Test Create Azure HDInsight Cluster with compute isolation
#>
function Test-CreateClusterWithComputeIsolation{

	# Create some resources that will be used throughout test
	try
	{
		# prepare parameter for creating parameter
		$params= Prepare-ClusterCreateParameter -location "South Central US"
		$encryptionAtHost=$true
		$workerNodeSize="Standard_E8S_v3"
		$headNodeSize="Standard_E16S_v3"
		$zookeeperNodeSize="Standard_E2S_v3"

		# create cluster
		$cluster=New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-WorkerNodeSize $workerNodeSize -HeadNodeSize $headNodeSize -ZookeeperNodeSize $zookeeperNodeSize `
		-StorageAccountResourceId $params.storageAccountResourceId -StorageAccountKey $params.storageAccountKey `
		-HttpCredential $params.httpCredential -SshCredential $params.sshCredential `
		-MinSupportedTlsVersion $params.minSupportedTlsVersion -EnableComputeIsolation

		Assert-AreEqual $cluster.ComputeIsolationProperties.EnableComputeIsolation $true
		
	}
	finally
	{
		# Delete cluster and resource group
		Remove-AzHDInsightCluster -ClusterName $cluster.Name
		Remove-AzResourceGroup -ResourceGroupName $cluster.ResourceGroup
	}
}
