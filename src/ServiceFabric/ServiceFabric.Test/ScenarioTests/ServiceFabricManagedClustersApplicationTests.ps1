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

$appTypeName = Get-ManagedAppTypeName
$v1 = Get-ManagedAppTypeV1Name
$v2 = Get-ManagedAppTypeV2Name
$packageV1 = Get-ManagedAppPackageV1
$packageV2 = Get-ManagedAppPackageV2
$statefulServiceTypeName = Get-ManagedStatefulServiceTypeName
$statelessServiceTypeName = Get-ManagedStatelessServiceTypeName

function Test-ManagedAppType
{
	# Cluster Setup
	$resourceGroupName = "sfmcps-rg-" + (getAssetname)
	$clusterName = "sfmcps-" + (getAssetname)
	$location = "southcentralus"
	$testClientTp = "123BDACDCDFB2C7B250192C6078E47D1E1DB119B"
	$pass = (ConvertTo-SecureString -AsPlainText -Force "TestPass1234!@#")
	Assert-ThrowsContains { Get-AzServiceFabricManagedCluster -ResourceGroupName $resourceGroupName -Name $clusterName } "NotFound"

	$cluster = New-AzServiceFabricManagedCluster -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Location $location `
		-AdminPassword $pass -Sku Standard -ClientCertThumbprint $testClientTp -Verbose
	Assert-AreEqual  "Succeeded" $cluster.ProvisioningState
	Assert-AreEqual  "WaitingForNodes" $cluster.ClusterState

	New-AzServiceFabricManagedNodeType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name pnt -InstanceCount 5 -Primary -AsJob

	#wait for nodetypes
	WaitForAllJob

	# Wait for clusterState
	WaitForManagedClusterReadyStateIfRecord $clusterName $resourceGroupName

	$appTypes = Get-AzServiceFabricManagedClusterApplicationType  -ResourceGroupName $resourceGroupName -ClusterName $clusterName
	Assert-Null $appTypes

	$appType = New-AzServiceFabricManagedClusterApplicationType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName -Verbose
	Assert-AreEqual  "Succeeded" $appType.ProvisioningState

	$appTypeFromGet = Get-AzServiceFabricManagedClusterApplicationType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName
	Assert-NotNull $appTypeFromGet
	Assert-AreEqual $appType.Id $appTypeFromGet.Id

	$tags = @{"test"="tag"}

	$appType = $appTypeFromGet | Set-AzServiceFabricManagedClusterApplicationType -Tag $tags -Verbose
	Assert-AreEqual  "Succeeded" $appType.ProvisioningState

	$appTypeFromGet = Get-AzServiceFabricManagedClusterApplicationType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName
	Assert-NotNull $appTypeFromGet
	Assert-AreEqual $appType.Id $appTypeFromGet.Id
	Assert-HashtableEqual $appType.Tags $appTypeFromGet.Tags

	# Test noop
	$appTypeNoop = $appType | Set-AzServiceFabricManagedClusterApplicationType
	Assert-AreEqual "Succeeded" $appTypeNoop.ProvisioningState
	Assert-AreEqualObjectProperties $appType $appTypeNoop

	$removeResponse = Remove-AzServiceFabricManagedClusterApplicationType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName -Force -PassThru -Verbose
	Assert-True { $removeResponse }
	
	Assert-ThrowsContains { Get-AzServiceFabricManagedClusterApplicationType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName } "NotFound"
}

function Test-ManagedAppTypeVersion
{
	# Cluster Setup
	$resourceGroupName = "sfmcps-rg-" + (getAssetname)
	$clusterName = "sfmcps-" + (getAssetname)
	$location = "southcentralus"
	$testClientTp = "123BDACDCDFB2C7B250192C6078E47D1E1DB119B"
	$pass = (ConvertTo-SecureString -AsPlainText -Force "TestPass1234!@#")
	Assert-ThrowsContains { Get-AzServiceFabricManagedCluster -ResourceGroupName $resourceGroupName -Name $clusterName } "NotFound"

	$cluster = New-AzServiceFabricManagedCluster -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Location $location `
		-AdminPassword $pass -Sku Standard -ClientCertThumbprint $testClientTp -Verbose
	Assert-AreEqual  "Succeeded" $cluster.ProvisioningState
	Assert-AreEqual  "WaitingForNodes" $cluster.ClusterState

	New-AzServiceFabricManagedNodeType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name pnt -InstanceCount 5 -Primary -AsJob

	#wait for nodetypes
	WaitForAllJob

	# Wait for clusterState
	WaitForManagedClusterReadyStateIfRecord $clusterName $resourceGroupName

	Assert-ThrowsContains { Get-AzServiceFabricManagedClusterApplicationTypeVersion -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName } "NotFound"

	$appTypeVersion = New-AzServiceFabricManagedClusterApplicationTypeVersion -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName -Version $v1 -PackageUrl $packageV1 -Verbose
	Assert-AreEqual "Succeeded" $appTypeVersion.ProvisioningState

	$appTypeVersionFromGet = Get-AzServiceFabricManagedClusterApplicationTypeVersion -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName -Version $v1
	Assert-NotNull $appTypeVersionFromGet
	Assert-AreEqual $appTypeVersion.Id $appTypeVersionFromGet.Id

	$tags = @{"test"="tag"}

	$appTypeVersion = $appTypeVersionFromGet | Set-AzServiceFabricManagedClusterApplicationTypeVersion -Tag $tags -Verbose
	Assert-AreEqual "Succeeded" $appTypeVersion.ProvisioningState

	$appTypeVersionFromGet = Get-AzServiceFabricManagedClusterApplicationTypeVersion -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName -Version $v1
	Assert-NotNull $appTypeVersionFromGet
	Assert-AreEqual $appTypeVersion.Id $appTypeVersionFromGet.Id
	Assert-HashtableEqual $appTypeVersion.Tags $appTypeVersionFromGet.Tags

	# Test noop
	$appTypeVersionNoop = $appTypeVersion | Set-AzServiceFabricManagedClusterApplicationTypeVersion
	Assert-AreEqual "Succeeded" $appTypeVersionNoop.ProvisioningState
	Assert-AreEqualObjectProperties $appTypeVersion $appTypeVersionNoop

	$removeResponse = Remove-AzServiceFabricManagedClusterApplicationTypeVersion -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName -Version $v1 -Force -PassThru -Verbose
	Assert-True { $removeResponse }

	$removeResponse = Remove-AzServiceFabricManagedClusterApplicationType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName -Force -PassThru -Verbose
	Assert-True { $removeResponse }

	Assert-ThrowsContains { Get-AzServiceFabricManagedClusterApplicationTypeVersion -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName -Version $v1 } "NotFound"
}

function Test-ManagedApp
{
	# Cluster Setup
	$resourceGroupName = "sfmcps-rg-" + (getAssetname)
	$clusterName = "sfmcps-" + (getAssetname)
	$location = "southcentralus"
	$testClientTp = "123BDACDCDFB2C7B250192C6078E47D1E1DB119B"
	$pass = (ConvertTo-SecureString -AsPlainText -Force "TestPass1234!@#")
	Assert-ThrowsContains { Get-AzServiceFabricManagedCluster -ResourceGroupName $resourceGroupName -Name $clusterName } "NotFound"

	$cluster = New-AzServiceFabricManagedCluster -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Location $location `
		-AdminPassword $pass -Sku Standard -ClientCertThumbprint $testClientTp -Verbose
	Assert-AreEqual  "Succeeded" $cluster.ProvisioningState
	Assert-AreEqual  "WaitingForNodes" $cluster.ClusterState

	New-AzServiceFabricManagedNodeType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name pnt -InstanceCount 5 -Primary -AsJob

	#wait for nodetypes
	WaitForAllJob

	# Wait for clusterState
	WaitForManagedClusterReadyStateIfRecord $clusterName $resourceGroupName

	$appName = getAssetName "testApp"
	$serviceName = getAssetName "testStatelessService"

	$apps = Get-AzServiceFabricManagedClusterApplication -ResourceGroupName $resourceGroupName -ClusterName $clusterName
	Assert-Null $apps

	$app = New-AzServiceFabricManagedClusterApplication -ResourceGroupName $resourceGroupName -ClusterName $clusterName -ApplicationTypeName $appTypeName -ApplicationTypeVersion $v1 -Name $appName -PackageUrl $packageV1 -Verbose
	Assert-AreEqual "Succeeded" $app.ProvisioningState

	$appFromGet = Get-AzServiceFabricManagedClusterApplication -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appName
	Assert-NotNull $appFromGet
	Assert-AreEqual $app.Id $appFromGet.Id

	$service = New-AzServiceFabricManagedClusterService -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Stateless -InstanceCount -1 -ApplicationName $appName -Name $serviceName -Type $statelessServiceTypeName -PartitionSchemeSingleton -Verbose
	Assert-AreEqual "Succeeded" $service.ProvisioningState

	$serviceFromGet = Get-AzServiceFabricManagedClusterService -ResourceGroupName $resourceGroupName -ClusterName $clusterName -ApplicationName $appName -Name $serviceName
	Assert-NotNull $serviceFromGet
	Assert-AreEqual $service.Id $serviceFromGet.Id

	$appTypeVersion = New-AzServiceFabricManagedClusterApplicationTypeVersion -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName -Version $v2 -PackageUrl $packageV2 -Verbose
	Assert-AreEqual "Succeeded" $appTypeVersion.ProvisioningState

	$app = $appFromGet | Set-AzServiceFabricManagedClusterApplication -ApplicationTypeVersion $v2 -HealthCheckStableDurationSec 0 -HealthCheckWaitDurationSec 0 -HealthCheckRetryTimeoutSec 0 `
		-UpgradeDomainTimeoutSec 5000 -UpgradeTimeoutSec 7000 -FailureAction Rollback -UpgradeReplicaSetCheckTimeoutSec 300 -ForceRestart -Verbose
	Assert-AreEqual "Succeeded" $app.ProvisioningState
	Assert-EndsWith $v2 $app.Version
	Assert-True { $app.UpgradePolicy.ForceRestart }
	Assert-AreEqual 300 $app.UpgradePolicy.UpgradeReplicaSetCheckTimeout
	Assert-AreEqual "01:56:40" $app.UpgradePolicy.RollingUpgradeMonitoringPolicy.UpgradeTimeout
	Assert-AreEqual "01:23:20" $app.UpgradePolicy.RollingUpgradeMonitoringPolicy.UpgradeDomainTimeout
	Assert-AreEqual "Rollback" $app.UpgradePolicy.RollingUpgradeMonitoringPolicy.FailureAction

	# Test noop
	$appNoop = $app | Set-AzServiceFabricManagedClusterApplication
	Assert-AreEqual "Succeeded" $appNoop.ProvisioningState
	Assert-AreEqualObjectProperties $app $appNoop

	$removeResponse = Remove-AzServiceFabricManagedClusterApplication -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appName -Force -PassThru -Verbose
	Assert-True { $removeResponse }

	$removeResponse = Remove-AzServiceFabricManagedClusterApplicationType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName -Force -PassThru -Verbose
	Assert-True { $removeResponse }

	Assert-ThrowsContains { Get-AzServiceFabricManagedClusterApplication -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appName } "NotFound"
}

function Test-ManagedService
{
	# Cluster Setup
	$resourceGroupName = "sfmcps-rg-" + (getAssetname)
	$clusterName = "sfmcps-" + (getAssetname)
	$location = "southcentralus"
	$testClientTp = "123BDACDCDFB2C7B250192C6078E47D1E1DB119B"
	$pass = (ConvertTo-SecureString -AsPlainText -Force "TestPass1234!@#")
	Assert-ThrowsContains { Get-AzServiceFabricManagedCluster -ResourceGroupName $resourceGroupName -Name $clusterName } "NotFound"

	$cluster = New-AzServiceFabricManagedCluster -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Location $location `
		-AdminPassword $pass -Sku Standard -ClientCertThumbprint $testClientTp -Verbose
	Assert-AreEqual  "Succeeded" $cluster.ProvisioningState
	Assert-AreEqual  "WaitingForNodes" $cluster.ClusterState

	New-AzServiceFabricManagedNodeType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name pnt -InstanceCount 5 -Primary -AsJob

	#wait for nodetypes
	WaitForAllJob

	# Wait for clusterState
	WaitForManagedClusterReadyStateIfRecord $clusterName $resourceGroupName

	$appName = getAssetName "testApp"
	$statelessServiceName = getAssetName "testStatelessService"
	$statefulServiceName = getAssetName "testStatefulService"

	$app = New-AzServiceFabricManagedClusterApplication -ResourceGroupName $resourceGroupName -ClusterName $clusterName -ApplicationTypeName $appTypeName -ApplicationTypeVersion $v1 -Name $appName -PackageUrl $packageV1 -Verbose
	Assert-AreEqual "Succeeded" $app.ProvisioningState

	$services = Get-AzServiceFabricManagedClusterService -ResourceGroupName $resourceGroupName -ClusterName $clusterName -ApplicationName $appName
	Assert-Null $services

	$statefulService = New-AzServiceFabricManagedClusterService -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Stateful -TargetReplicaSetSize 3 `
		-MinReplicaSetSize 2 -HasPersistedState -ApplicationName $appName -Name $statefulServiceName -Type $statefulServiceTypeName -PartitionSchemeUniformInt64 `
		-PartitionCount 1 -LowKey 0 -HighKey 25 -Verbose
	Assert-AreEqual "Succeeded" $statefulService.ProvisioningState

	$statefulServiceFromGet = Get-AzServiceFabricManagedClusterService -ResourceGroupName $resourceGroupName -ClusterName $clusterName -ApplicationName $appName -Name $statefulServiceName
	Assert-NotNull $statefulServiceFromGet
	Assert-AreEqual $statefulService.Id $statefulServiceFromGet.Id

	$statelessService = New-AzServiceFabricManagedClusterService -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Stateless -InstanceCount -1 `
		-ApplicationName $appName -Name $statelessServiceName -Type $statelessServiceTypeName -PartitionSchemeSingleton -Verbose
	Assert-AreEqual "Succeeded" $statelessService.ProvisioningState

	$statelessServiceFromGet = Get-AzServiceFabricManagedClusterService -ResourceGroupName $resourceGroupName -ClusterName $clusterName -ApplicationName $appName -Name $statelessServiceName
	Assert-NotNull $statelessServiceFromGet
	Assert-AreEqual $statelessService.Id $statelessServiceFromGet.Id

	$replicaRestartWaitDuration = "00:11:00"
	$quorumLossWaitDuration = "00:11:00"
	$standByReplicaKeepDuration = "00:11:00"
	$servicePlacementTimeLimit = "00:11:00"

	$statefulService = $statefulServiceFromGet | Set-AzServiceFabricManagedClusterService -Stateful -ReplicaRestartWaitDuration $replicaRestartWaitDuration -QuorumLossWaitDuration $quorumLossWaitDuration `
		-StandByReplicaKeepDuration $standByReplicaKeepDuration -ServicePlacementTimeLimit $servicePlacementTimeLimit -Verbose
	Assert-AreEqual "Succeeded" $statefulService.ProvisioningState
	Assert-AreEqual $replicaRestartWaitDuration $statefulService.ReplicaRestartWaitDuration
	Assert-AreEqual $quorumLossWaitDuration $statefulService.QuorumLossWaitDuration
	Assert-AreEqual $standByReplicaKeepDuration $statefulService.StandByReplicaKeepDuration
	Assert-AreEqual $servicePlacementTimeLimit $statefulService.ServicePlacementTimeLimit

	# Test noop
	$statefulServiceNoop = $statefulService | Set-AzServiceFabricManagedClusterService -Stateful -Verbose
	Assert-AreEqual "Succeeded" $statefulServiceNoop.ProvisioningState
	Assert-AreEqualObjectProperties $statefulService $statefulServiceNoop

	$minInstancePercentage = 20
	$minInstanceCount = 2

	$statelessService = $statelessServiceFromGet | Set-AzServiceFabricManagedClusterService -Stateless -MinInstancePercentage $minInstancePercentage `
		-MinInstanceCount $minInstanceCount -Verbose
	Assert-AreEqual "Succeeded" $statelessService.ProvisioningState
	Assert-AreEqual $minInstancePercentage $statelessService.MinInstancePercentage
	Assert-AreEqual $minInstanceCount $statelessService.MinInstanceCount

	# Test noop
	$statelessServiceNoop = $statelessService | Set-AzServiceFabricManagedClusterService -Stateless -Verbose
	Assert-AreEqual "Succeeded" $statelessServiceNoop.ProvisioningState
	Assert-AreEqualObjectProperties $statelessService $statelessServiceNoop 

	$removeStatefulServiceResponse = Remove-AzServiceFabricManagedClusterService -ResourceGroupName $resourceGroupName -ClusterName $clusterName -ApplicationName $appName -Name $statefulServiceName -Force -PassThru -Verbose
	Assert-True { $removeStatefulServiceResponse }

	$removeStatelessServiceResponse = Remove-AzServiceFabricManagedClusterService -ResourceGroupName $resourceGroupName -ClusterName $clusterName -ApplicationName $appName -Name $statelessServiceName -Force -PassThru -Verbose
	Assert-True { $removeStatelessServiceResponse }

	$removeAppResponse = Remove-AzServiceFabricManagedClusterApplication -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appName -Force -PassThru -Verbose
	Assert-True { $removeAppResponse }

	$removeAppTypeResponse = Remove-AzServiceFabricManagedClusterApplicationType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName -Force -PassThru -Verbose
	Assert-True { $removeAppTypeResponse }

	Assert-ThrowsContains { Get-AzServiceFabricManagedClusterService -ResourceGroupName $resourceGroupName -ClusterName $clusterName -ApplicationName $appName -Name $statefulServiceName } "NotFound"
	Assert-ThrowsContains { Get-AzServiceFabricManagedClusterService -ResourceGroupName $resourceGroupName -ClusterName $clusterName -ApplicationName $appName -Name $statelessServiceName } "NotFound"
}