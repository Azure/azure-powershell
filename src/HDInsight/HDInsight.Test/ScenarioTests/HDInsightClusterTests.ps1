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
Tests HDInsight job submission, monitoring, and output commands.
#>

function Test-HDInsightJobManagementCommands{
	try{
		$clusterName = "ps-test-cluster" 
		$resourceGroupName = "group-ps-test"
		$httpUser="admin"
		$httpPassword = ConvertTo-SecureString "Sanitized" -AsPlainText -Force
		$httpCredential = New-Object System.Management.Automation.PSCredential($httpUser, $httpPassword)
		# test Use-AzHDInsightCluster
		Use-AzHDInsightCluster -ClusterName $clusterName -ResourceGroupName $resourceGroupName -HttpCredential $httpCredential

		# test Get-AzHDInsightProperty
		$property = Get-AzHDInsightProperty  -Location "East Asia"
		Assert-NotNull $property

		# test New-AzHDInsightHiveJobDefinition
		$hiveJob = New-AzHDInsightHiveJobDefinition -Query "select count(*) from default.hivesampletable" -JobName "QuerySampleTable"

		# test Start-AzHDInsightJob
		$jobHive = Start-AzHDInsightJob -ClusterName $clusterName -ResourceGroupName $resourceGroupName -JobDefinition $hiveJob -HttpCredential $httpCredential

		# test Wait-AzHDInsightJob
		$waitJobHive = Wait-AzHDInsightJob -ClusterName $clusterName -ResourceGroupName $resourceGroupName -HttpCredential $httpCredential -JobId  $jobHive.JobId
		Assert-NotNull $waitJobHive

		# test Get-AzHDInsightJob
		$jobStatus = Get-AzHDInsightJob -ClusterName $clusterName -ResourceGroupName $resourceGroupName -HttpCredential $httpCredential -JobId $jobHive.JobId
		Assert-AreEqual $jobStatus.State "SUCCEEDED"

		# test New-AzHDInsightMapReduceJobDefinition
		$mapReduceJob = New-AzHDInsightMapReduceJobDefinition -JarFile "/example/jars/hadoop-mapreduce-examples.jar" -ClassName "pi" -Arguments "10","10" -JobName "PiEstimation"

		$jobMapReduce = Start-AzHDInsightJob -ClusterName $clusterName -ResourceGroupName $resourceGroupName -JobDefinition $mapReduceJob -HttpCredential $httpCredential

		# test Stop-AzHDInsightJob
		Stop-AzHDInsightJob -ClusterName $clusterName -ResourceGroupName $resourceGroupName -HttpCredential $httpCredential -JobId  $jobMapReduce.JobId
		
		$pigJob = New-AzHDInsightPigJobDefinition -Query "SHOW TABLES"
		Assert-NotNull $pigJob

		$sqoopJob = New-AzHDInsightSqoopJobDefinition
		Assert-NotNull $sqoopJob
		
		$streamingJob = New-AzHDInsightStreamingMapReduceJobDefinition -InputPath '/tmp'
		Assert-NotNull $streamingJob
	}
	finally
	{
	}
}

<#
.SYNOPSIS
Test Create Azure HDInsight Cluster With WASB Storage And MSI
#>

function Test-CreateClusterWithWasbAndMSI{
	try{
		# prepare parameter for creating parameter
		$params= Prepare-ClusterCreateParameter
		$clusterParams = @{
			ClusterType                     = $params.clusterType
			ClusterSizeInNodes              = $params.clusterSizeInNodes
			ResourceGroupName               = $params.resourceGroupName
			ClusterName                     = $params.clusterName
			HttpCredential                  = $params.httpCredential
			SshCredential                   = $params.sshCredential
			Location                        = $params.location
			MinSupportedTlsVersion          = $params.minSupportedTlsVersion
			VirtualNetworkId                = $params.virtualNetworkId
			SubnetName                      = $params.subnet
			Version                         = $params.version
			StorageAccountType              = "AzureStorage"
			StorageContainer                = $params.clusterName
			StorageAccountResourceId        = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/hdi-ps-test/providers/Microsoft.Storage/storageAccounts/hdi-storage-wasb"
			StorageAccountManagedIdentity   = "/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/hdi-ps-test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/hdi-test-msi"
        }
		# test create cluster
		$cluster = New-AzHDInsightCluster @clusterParams
		Assert-NotNull $cluster
	}
	finally
	{
		# Delete cluster and resource group
		Remove-AzResourceGroup -ResourceGroupName $params.resourceGroupName
	}
}

<#
.SYNOPSIS
Test Create Entra HDInsight Cluster 
#>

function Test-CreateEntraCluster{
	try{
		 $params= Prepare-ClusterCreateParameter
		 $entraUserFullInfo = @(@{ObjectId = "00000000-0000-0000-0000-000000000000"; Upn = "user@microsoft.com"; DisplayName = "DisplayName" },@{ObjectId = "00000000-0000-0000-0000-000000000000"; Upn = "user@microsoft.com"; DisplayName = "DisplayName" })
		 $clusterParams = @{
			ClusterType                     = $params.clusterType
			ClusterSizeInNodes              = $params.clusterSizeInNodes
			ResourceGroupName               = $params.resourceGroupName
			ClusterName                     = $params.clusterName
			SshCredential                   = $params.sshCredential
			Location                        = $params.location
			MinSupportedTlsVersion          = $params.minSupportedTlsVersion
			VirtualNetworkId                = $params.virtualNetworkId
			SubnetName                      = $params.subnet
			Version                         = $params.version
			StorageContainer                = $params.clusterName
			StorageAccountKey               = $params.storageAccountKey
			StorageAccountResourceId        = $params.storageAccountResourceId
			EntraUserFullInfo               = $entraUserFullInfo
        }
		$resultCluster = New-AzHDInsightCluster @clusterParams
		Set-AzHDInsightGatewayCredential -ResourceGroupName $params.resourceGroupName -ClusterName $params.clusterName -EntraUserFullInfo $entraUserFullInfo
		Assert-NotNull $resultCluster
	}
	finally
	{
		# Delete cluster and resource group
		Remove-AzResourceGroup -ResourceGroupName $params.resourceGroupName
	}
}

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
		-HttpCredential $params.httpCredential -SshCredential $params.sshCredential  -VirtualNetworkId $params.virtualNetworkId -SubnetName "default" `
		-MinSupportedTlsVersion $params.minSupportedTlsVersion -Version $params.version

		Assert-NotNull $cluster
		
		#test Get-AzHDInsightCluster
		$resultCluster = Get-AzHDInsightCluster -ResourceGroupName $params.resourceGroupName -ClusterName $cluster.Name
		Assert-AreEqual $resultCluster.Name  $cluster.Name
		
		#test Set-AzHDInsightClusterSize
		$resizeCluster = Set-AzHDInsightClusterSize -ClusterName $cluster.Name -ResourceGroupName $cluster.ResourceGroup `
		-TargetInstanceCount 3
		Assert-AreEqual $resizeCluster.CoresUsed 32
	}
	finally
	{
		# Delete cluster and resource group
		Remove-AzResourceGroup -ResourceGroupName $params.resourceGroupName
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
		-EncryptionKeyName $encryptionKey.Name -EncryptionKeyVersion $encryptionKey.Version -EncryptionVaultUri $encryptionKey.Vault -VirtualNetworkId $params.virtualNetworkId -SubnetName "default"
		Assert-AreEqual $rotateKeyCluster.DiskEncryption.KeyVersion $encryptionKey.Version
		Assert-AreEqual $rotateKeyCluster.DiskEncryption.KeyName $encryptionKey.Name
	}
	finally
	{
		# Delete cluster and resource group
		# Remove-AzHDInsightCluster -ClusterName $cluster.Name
		Remove-AzResourceGroup -ResourceGroupName $params.resourceGroupName
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
		$params= Prepare-ClusterCreateParameter
		$encryptionInTransit=$true

		# create cluster
		$cluster=New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-StorageAccountResourceId $params.storageAccountResourceId -StorageAccountKey $params.storageAccountKey `
		-HttpCredential $params.httpCredential -SshCredential $params.sshCredential `
		-MinSupportedTlsVersion $params.minSupportedTlsVersion -EncryptionInTransit $encryptionInTransit -VirtualNetworkId $params.virtualNetworkId -SubnetName "default"

		Assert-AreEqual $cluster.EncryptionInTransit $encryptionInTransit
		
	}
	finally
	{
		# Delete cluster and resource group
		# Remove-AzHDInsightCluster -ClusterName $cluster.Name
		Remove-AzResourceGroup -ResourceGroupName $params.resourceGroupName
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
		$params= Prepare-ClusterCreateParameter
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
		-MinSupportedTlsVersion $params.minSupportedTlsVersion -EncryptionAtHost $encryptionAtHost -VirtualNetworkId $params.virtualNetworkId -SubnetName "default"

		Assert-AreEqual $cluster.DiskEncryption.EncryptionAtHost $encryptionAtHost
		
	}
	finally
	{
		# Delete cluster and resource group
		# Remove-AzHDInsightCluster -ClusterName $cluster.Name
		Remove-AzResourceGroup -ResourceGroupName $params.resourceGroupName
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
		$params= Prepare-ClusterCreateParameter

		# create autoscale cofiguration
		$autoscaleConfiguration=New-AzHDInsightClusterAutoscaleConfiguration -MinWorkerNodeCount 4 -MaxWorkerNodeCount 5

		# create cluster with load-based autoscale
		$cluster=New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-StorageAccountResourceId $params.storageAccountResourceId -StorageAccountKey $params.storageAccountKey `
		-HttpCredential $params.httpCredential -SshCredential $params.sshCredential `
		-MinSupportedTlsVersion $params.minSupportedTlsVersion -Version 5.1 `
		-AutoscaleConfiguration $autoscaleConfiguration -VirtualNetworkId $params.virtualNetworkId -SubnetName "default"

		Assert-NotNull $cluster
		Assert-AreEqual $cluster.ComputeProfile.Roles[1].AutoscaleConfiguration.Capacity.MinInstanceCount 4
		Assert-AreEqual $cluster.ComputeProfile.Roles[1].AutoscaleConfiguration.Capacity.MaxInstanceCount 5
	}
	finally
	{
		# Delete cluster and resource group
		Remove-AzHDInsightCluster -ClusterName $cluster.Name -ResourceGroupName $params.resourceGroupName
		Remove-AzResourceGroup -ResourceGroupName $params.resourceGroupName
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
		-AutoscaleConfiguration $autoscaleConfiguration -VirtualNetworkId $params.virtualNetworkId -SubnetName "default"

		Assert-NotNull $cluster
		Assert-NotNull $cluster.ComputeProfile.Roles[1].AutoscaleConfiguration.Recurrence
		Assert-AreEqual $cluster.ComputeProfile.Roles[1].AutoscaleConfiguration.Recurrence.Condition[0].WorkerNodeCount $condition1.WorkerNodeCount
		Assert-AreEqual $cluster.ComputeProfile.Roles[1].AutoscaleConfiguration.Recurrence.Condition[1].WorkerNodeCount $condition2.WorkerNodeCount
	}
	finally
	{
		# Delete cluster and resource group
		# Remove-AzHDInsightCluster -ClusterName $cluster.Name
		Remove-AzResourceGroup -ResourceGroupName $params.resourceGroupName
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
		# Remove-AzHDInsightCluster -ClusterName $cluster.Name
		Remove-AzResourceGroup -ResourceGroupName $params.resourceGroupName
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
		$params= Prepare-ClusterCreateParameter

		# Private Link requires vnet has firewall, this is difficult to create dynamically, just hardcode here
		#"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/virtualNetworks/fakevnet"
		$vnetId= "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/group-ps-test/providers/Microsoft.Network/virtualNetworks/hdi-vn-0"
		$subnetName="default"

		# create cluster
		$cluster = New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-StorageAccountResourceId $params.storageAccountResourceId -StorageAccountKey $params.storageAccountKey `
		-HttpCredential $params.httpCredential -SshCredential $params.sshCredential `
		-MinSupportedTlsVersion $params.minSupportedTlsVersion `
		-VirtualNetworkId $vnetId -SubnetName $subnetName -Version $params.version `
		-ResourceProviderConnection Outbound -PrivateLink Enabled -PublicIpTagType FirstPartyUsage -PublicIpTag HDInsight

		Assert-AreEqual $cluster.NetworkProperties.ResourceProviderConnection Outbound
		Assert-AreEqual $cluster.NetworkProperties.PrivateLink Enabled
		
	}
	finally
	{
		# Remove-AzHDInsightCluster -ClusterName $cluster.Name
		Remove-AzResourceGroup -ResourceGroupName $params.resourceGroupName
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
		$params= Prepare-ClusterCreateParameter

		# prepare custom ambari database
		$databaseUserName="yourusername"
		$databasePassword="******"
		$databasePassword=ConvertTo-SecureString $databasePassword -AsPlainText -Force
	
		$sqlserverCredential=New-Object System.Management.Automation.PSCredential($databaseUserName, $databasePassword)
		$sqlserver="yoursqlserver.database.windows.net"
		$database="customambaridb"

		$config=New-AzHDInsightClusterConfig|Add-AzHDInsightMetastore `
        -SqlAzureServerName $sqlserver -DatabaseName $database `
		-Credential $sqlserverCredential -MetastoreType AmbariDatabase

		# create cluster
		$cluster = New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-StorageAccountResourceId $params.storageAccountResourceId -StorageAccountKey $params.storageAccountKey `
		-HttpCredential $params.httpCredential -SshCredential $params.sshCredential `
		-AmbariDatabase $config.AmbariDatabase

		Assert-NotNull $cluster
		
	}
	finally
	{
		# Delete cluster and resource group
		# Remove-AzHDInsightCluster -ClusterName $cluster.Name
		Remove-AzResourceGroup -ResourceGroupName $params.resourceGroupName
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
		-MinSupportedTlsVersion $params.minSupportedTlsVersion -EnableComputeIsolation -VirtualNetworkId $params.virtualNetworkId -SubnetName "default"

		Assert-AreEqual $cluster.ComputeIsolationProperties.EnableComputeIsolation $true
		
	}
	finally
	{
		# Delete cluster and resource group
		# Remove-AzHDInsightCluster -ClusterName $cluster.Name
		Remove-AzResourceGroup -ResourceGroupName $params.resourceGroupName
	}
}

<#
.SYNOPSIS
Test Create Enable Secure Channel HDInsight Cluster
#>

function Test-ClusterEnableSecureChannelCommands{

	# Create some resources that will be used throughout test
	try
	{
		# prepare parameter for creating parameter
		$params= Prepare-ClusterCreateParameter
		$enableSecureChannel = $true

		# test create cluster
		$cluster = New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-StorageAccountResourceId $params.storageAccountResourceId -StorageAccountKey $params.storageAccountKey `
		-HttpCredential $params.httpCredential -SshCredential $params.sshCredential -Version $params.version `
		-MinSupportedTlsVersion $params.minSupportedTlsVersion -EnableSecureChannel $enableSecureChannel -VirtualNetworkId $params.virtualNetworkId -SubnetName "default"

		Assert-NotNull $cluster
		Assert-AreEqual $cluster.EnableSecureChannel $enableSecureChannel
	}
	finally
	{
		# Delete cluster and resource group
		# Remove-AzHDInsightCluster -ClusterName $cluster.Name
		Remove-AzResourceGroup -ResourceGroupName $params.resourceGroupName
	}
}

<#
.SYNOPSIS
Test Create Azure HDInsight Cluster with availability zones
#>

function Test-CreateClusterWithAvailabilityZones{

	# Create some resources that will be used throughout test
	try
	{
		# prepare parameter for creating parameter
		$params= Prepare-ClusterCreateParameter

		# prepare custom ambari database
		$databaseUserName="yourusername"
		$databasePassword="******"
		$databasePassword=ConvertTo-SecureString $databasePassword -AsPlainText -Force
	
		$sqlserverCredential=New-Object System.Management.Automation.PSCredential($databaseUserName, $databasePassword)
		$sqlserver="yoursqlserver.database.windows.net"
		$ambariDatabase="ambaridb"
		$hiveDatabase ="hivedb"
		$oozieDatabase = "ooziedb"

		$vnetId="/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/virtualNetworks/fakevnet"
		$subnetName="default"

		# Create Ambari metastore
		$config=New-AzHDInsightClusterConfig|Add-AzHDInsightMetastore `
		-SqlAzureServerName $sqlserver -DatabaseName $ambariDatabase `
		-Credential $sqlserverCredential -MetastoreType AmbariDatabase

		# Create Hive metastore
		$config=$config|Add-AzHDInsightMetastore `
		-SqlAzureServerName $sqlserver -DatabaseName $hiveDatabase `
		-Credential $sqlserverCredential -MetastoreType HiveMetastore

		# Create Oozie metastore
		$config=$config|Add-AzHDInsightMetastore `
		-SqlAzureServerName $sqlserver -DatabaseName $oozieDatabase `
		-Credential $sqlserverCredential -MetastoreType OozieMetastore

		# create cluster
		$cluster = New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-StorageAccountResourceId $params.storageAccountResourceId -StorageAccountKey $params.storageAccountKey `
		-HttpCredential $params.httpCredential -SshCredential $params.sshCredential `
		-MinSupportedTlsVersion $params.minSupportedTlsVersion -VirtualNetworkId $vnetId -SubnetName $subnetName `
		-AmbariDatabase $config.AmbariDatabase -HiveMetastore $config.HiveMetastore -OozieMetastore $config.OozieMetastore -Zone "1"

		Assert-NotNull $cluster
	}
	finally
	{
		# Remove-AzHDInsightCluster -ClusterName $cluster.Name
		Remove-AzResourceGroup -ResourceGroupName $params.resourceGroupName
	}
}

<#
.SYNOPSIS
Test Create Azure HDInsight Cluster with private link configuration feature
#>

function Test-CreateClusterWithPrivateLinkConfiguration{

	# Create some resources that will be used throughout test
	try
	{
		# prepare parameter for creating parameter
		$params= Prepare-ClusterCreateParameter

		# Private Link requires vnet has firewall, this is difficult to create dynamically, just hardcode here
		$vnetId= "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/group-ps-test/providers/Microsoft.Network/virtualNetworks/hdi-vn-0"
		$subnetName="default"

		$ipConfigName="ipconfig"
		$privateIPAllocationMethod="dynamic" # the only supported IP allocation method for private link IP configuration is dynamic
		$subnetId=$vnetId+"/subnets/"+$subnetName
		# Create Private IP configuration
		$ipConfiguration= New-AzHDInsightIPConfiguration -Name $ipConfigName -PrivateIPAllocationMethod $privateIPAllocationMethod -SubnetId $subnetId -Primary

		$privateLinkConfigurationName="plconfig"
		$groupId="headnode"
		# Create private link configuration
		$privateLinkConfiguration= New-AzHDInsightPrivateLinkConfiguration -Name $privateLinkConfigurationName -GroupId $groupId -IPConfiguration $ipConfiguration

		# create cluster
		$cluster = New-AzHDInsightCluster -Location $params.location -ResourceGroupName $params.resourceGroupName `
		-ClusterName $params.clusterName -ClusterSizeInNodes $params.clusterSizeInNodes -ClusterType $params.clusterType `
		-StorageAccountResourceId $params.storageAccountResourceId -StorageAccountKey $params.storageAccountKey `
		-HttpCredential $params.httpCredential -SshCredential $params.sshCredential `
		-MinSupportedTlsVersion $params.minSupportedTlsVersion `
		-VirtualNetworkId $vnetId -SubnetName $subnetName `
		-ResourceProviderConnection Outbound -PrivateLink Enabled -PrivateLinkConfiguration $privateLinkConfiguration -Version 5.1

		Assert-AreEqual $cluster.NetworkProperties.ResourceProviderConnection Outbound
		Assert-AreEqual $cluster.NetworkProperties.PrivateLink Enabled
		Assert-NotNull $cluster.PrivateLinkConfigurations
	}
	finally
	{
		# Delete cluster and resource group
		# Remove-AzHDInsightCluster -ClusterName $cluster.Name
		Remove-AzResourceGroup -ResourceGroupName $params.resourceGroupName
	}
}

<#
.SYNOPSIS
Test Update cluster tags
#>

function Test-UpdateClusterTags{
	# Create some resources that will be used throughout test
	try
	{
		# prepare parameter for creating parameter
		#$params= Prepare-ClusterCreateParameter

		$rg="group-ps-test"
		$clusterName="ps-test-cluster"
		# Update cluster tags
		$tags = New-Object 'System.Collections.Generic.Dictionary[System.String,System.String]'
		$tags.Add('Tag3', 'Value3')

		$cluster = Update-AzHDInsightCluster -ResourceGroupName $rg -ClusterName $clusterName -Tag $tags
 	}
	finally
	{
		# Delete cluster and resource group
		# Remove-AzResourceGroup -ResourceGroupName $params.resourceGroupName
 	}
}

<#
.SYNOPSIS
Test Update cluster System Assigned Identity
#>
function Test-UpdateClusterSystemAssigned{
	try
	{
		$rg="group-ps-test"
		$clusterName="ps-test-cluster"

		$cluster = Update-AzHDInsightCluster -ResourceGroupName $rg -ClusterName $clusterName -IdentityType SystemAssigned

		Assert-NotNull $cluster
		Assert-AreEqual $cluster.AssignedIdentity.Type SystemAssigned
	}
	finally
	{
		# Delete cluster and resource group
		# Remove-AzResourceGroup -ResourceGroupName $params.resourceGroupName
	}
}

<#
.SYNOPSIS
Test Update cluster User Assigned Identity
#>
function Test-UpdateClusterUserAssigned{
	try
	{
		$rg="group-ps-test"
		$clusterName="ps-test-cluster"

		# Define the list of Identity IDs
		$identityIds = @(
			"/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/hdi-ps-test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/hdi-test-msi",
			"/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/hdi-ps-test/providers/Microsoft.ManagedIdentity/userAssignedIdentities/hdi-test-msi2"		
		)

		$cluster = Update-AzHDInsightCluster -ResourceGroupName $rg -ClusterName $clusterName -IdentityType UserAssigned -IdentityId $identityIds

		Assert-NotNull $cluster
		Assert-AreEqual $cluster.AssignedIdentity.Type UserAssigned

 	}
	finally
	{
		# Delete cluster and resource group
		# Remove-AzResourceGroup -ResourceGroupName $params.resourceGroupName
	}
}
