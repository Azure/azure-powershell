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

$clusterName = Get-ClusterName
$resourceGroupName = Get-ResourceGroupName
$appTypeName = Get-AppTypeName
$v1 = Get-AppTypeV1Name
$v2 = Get-AppTypeV2Name
$packageV1 = Get-AppPackageV1
$packageV2 = Get-AppPackageV2
$serviceTypeName = Get-ServiceTypeName

function Test-AppType
{
	$appType = Get-AzServiceFabricApplicationType -ResourceGroupName $resourceGroupName -ClusterName $clusterName
	Assert-Null $appType

	$appType = New-AzServiceFabricApplicationType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName -Verbose
	Assert-AreEqual  "Succeeded" $appType.ProvisioningState

	$appTypeFromGet = Get-AzServiceFabricApplicationType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName
	Assert-NotNull $appTypeFromGet
	Assert-AreEqual $appType.Id $appTypeFromGet.Id

	$removeResponse = Remove-AzServiceFabricApplicationType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName -Force -PassThru -Verbose
	Assert-True { $removeResponse }
	
	Assert-ThrowsContains { Get-AzServiceFabricApplicationType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName } "NotFound"
}

function Test-AppTypeVersion
{
	$appTypeVersion = Get-AzServiceFabricApplicationTypeVersion -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName
	Assert-Null $appTypeVersion

	$appTypeVersion = New-AzServiceFabricApplicationTypeVersion -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName -Version $v1 -PackageUrl $packageV1 -Verbose
	Assert-AreEqual "Succeeded" $appTypeVersion.ProvisioningState

	$appTypeVersionFromGet = Get-AzServiceFabricApplicationTypeVersion -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName -Version $v1
	Assert-NotNull $appTypeVersionFromGet
	Assert-AreEqual $appTypeVersion.Id $appTypeVersionFromGet.Id

	$removeResponse = Remove-AzServiceFabricApplicationTypeVersion -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName -Version $v1 -Force -PassThru -Verbose
	Assert-True { $removeResponse }

	$removeResponse = Remove-AzServiceFabricApplicationType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName -Force -PassThru -Verbose
	Assert-True { $removeResponse }

	Assert-ThrowsContains { Get-AzServiceFabricApplicationTypeVersion -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName -Version $v1 } "NotFound"
}

function Test-App
{
	$appName = getAssetName "testApp"
	$serviceName = getAssetName "testService"
	$serviceName = "$($appName)~$($serviceName)"

	$app = Get-AzServiceFabricApplication -ResourceGroupName $resourceGroupName -ClusterName $clusterName
	Assert-Null $app

	$app = New-AzServiceFabricApplication -ResourceGroupName $resourceGroupName -ClusterName $clusterName -ApplicationTypeName $appTypeName -ApplicationTypeVersion $v1 -Name $appName -PackageUrl $packageV1 -Verbose
	Assert-AreEqual "Succeeded" $app.ProvisioningState

	$appFromGet = Get-AzServiceFabricApplication -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appName
	Assert-NotNull $appFromGet
	Assert-AreEqual $app.Id $appFromGet.Id

	$service = New-AzServiceFabricService -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Stateless -InstanceCount -1 -ApplicationName $appName -Name $serviceName -Type $serviceTypeName -PartitionSchemeSingleton -Verbose
	Assert-AreEqual "Succeeded" $service.ProvisioningState

	$appTypeVersion = New-AzServiceFabricApplicationTypeVersion -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName -Version $v2 -PackageUrl $packageV2 -Verbose
	Assert-AreEqual "Succeeded" $appTypeVersion.ProvisioningState

	$app = Update-AzServiceFabricApplication -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appName -ApplicationTypeVersion $v2 `
		-ApplicationParameter @{Mode="decimal"} -HealthCheckStableDurationSec 0 -HealthCheckWaitDurationSec 0 -HealthCheckRetryTimeoutSec 0 `
		-UpgradeDomainTimeoutSec 5000 -UpgradeTimeoutSec 7000 -FailureAction Rollback -UpgradeReplicaSetCheckTimeoutSec 300 -ForceRestart -Verbose
	Assert-AreEqual "Succeeded" $app.ProvisioningState
	Assert-AreEqual $v2 $app.TypeVersion
	Assert-AreEqual "decimal" $app.Parameters["Mode"]
	Assert-True { $app.UpgradePolicy.ForceRestart }
	Assert-AreEqual "00:05:00" $app.UpgradePolicy.UpgradeReplicaSetCheckTimeout
	Assert-AreEqual "01:56:40" $app.UpgradePolicy.RollingUpgradeMonitoringPolicy.UpgradeTimeout
	Assert-AreEqual "01:23:20" $app.UpgradePolicy.RollingUpgradeMonitoringPolicy.UpgradeDomainTimeout
	Assert-AreEqual "Rollback" $app.UpgradePolicy.RollingUpgradeMonitoringPolicy.FailureAction

	$app = Update-AzServiceFabricApplication -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appName -MinimumNodeCount 1 -MaximumNodeCount 4 -Verbose
	Assert-AreEqual 1 $app.MinimumNodes
	Assert-AreEqual 4 $app.MaximumNodes

	# Test noop
	$appNoop = $app | Update-AzServiceFabricApplication -Verbose
	Assert-AreEqual "Succeeded" $appNoop.ProvisioningState
	Assert-AreEqualObjectPropertiesExcept $app $appNoop @("ETag")

	$removeResponse = Remove-AzServiceFabricApplication -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appName -Force -PassThru -Verbose
	Assert-True { $removeResponse }

	$removeResponse = Remove-AzServiceFabricApplicationType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName -Force -PassThru -Verbose
	Assert-True { $removeResponse }

	Assert-ThrowsContains { Get-AzServiceFabricApplication -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appName } "NotFound"
}

function Test-Service
{
	$appName = getAssetName "testApp"
	$serviceName = getAssetName "testService"
	$serviceName = "$($appName)~$($serviceName)"

	$app = New-AzServiceFabricApplication -ResourceGroupName $resourceGroupName -ClusterName $clusterName -ApplicationTypeName $appTypeName -ApplicationTypeVersion $v1 -Name $appName -PackageUrl $packageV1 -Verbose
	Assert-AreEqual "Succeeded" $app.ProvisioningState

	$service = Get-AzServiceFabricService -ResourceGroupName $resourceGroupName -ClusterName $clusterName -ApplicationName $appName
	Assert-Null $service

	$service = New-AzServiceFabricService -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Stateless -InstanceCount -1 -ApplicationName $appName -Name $serviceName -Type $serviceTypeName -PartitionSchemeSingleton -Verbose
	Assert-AreEqual "Succeeded" $service.ProvisioningState

	$serviceFromGet = Get-AzServiceFabricService -ResourceGroupName $resourceGroupName -ClusterName $clusterName -ApplicationName $appName -Name $serviceName
	Assert-NotNull $serviceFromGet
	Assert-AreEqual $service.Id $serviceFromGet.Id

	$removeResponse = Remove-AzServiceFabricService -ResourceGroupName $resourceGroupName -ClusterName $clusterName -ApplicationName $appName -Name $serviceName -Force -PassThru -Verbose
	Assert-True { $removeResponse }

	$removeRespoetnse = Remove-AzServiceFabricApplication -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appName -Force -PassThru -Verbose
	Assert-True { $removeResponse }

	$removeResponse = Remove-AzServiceFabricApplicationType -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $appTypeName -Force -PassThru -Verbose
	Assert-True { $removeResponse }

	Assert-ThrowsContains { Get-AzServiceFabricService -ResourceGroupName $resourceGroupName -ClusterName $clusterName -ApplicationName $appName -Name $serviceName } "NotFound"
}