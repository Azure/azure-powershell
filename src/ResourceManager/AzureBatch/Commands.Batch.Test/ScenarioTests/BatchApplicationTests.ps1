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
Tests querying for a Batch account that does not exist throws
#>
function Test-UploadApplication
{
    param([string]$accountName, [string]$resourceGroup)

	# Setup
    $location = Get-BatchAccountProviderLocation
	$applicationId = "test"
	$applicationVersion = "foo"

    try
    {
		$addAppPack = Add-AzureRmBatchApplication -ResourceGroupName $resourceGroup -AccountName $accountName -ApplicationId $applicationId
		$getapp = Get-AzureRmBatchApplication -ResourceGroupName $resourceGroup -AccountName $accountName  -ApplicationId $applicationId

		Assert-AreEqual $getapp.Id $addAppPack.Id
    }
    finally
    {
	 	Remove-AzureRmBatchApplication -AccountName $accountName -ApplicationId $applicationId -ResourceGroupName $resourceGroup
    }
}

<#
.SYNOPSIS
Tests querying for a Batch account that does not exist throws
#>
function Test-UploadApplicationPackage
{
    param([string]$accountName, [string]$resourceGroup)

	# Setup
    $location = Get-BatchAccountProviderLocation
	$applicationId = "test"
	$applicationVersion = "foo"

    try
    {
		$addAppPack = Add-AzureRmBatchApplicationPackage -ResourceGroupName $resourceGroup -AccountName $accountName -ApplicationId $applicationId -ApplicationVersion $applicationVersion -FilePath "Resources\foo.zip" -format "zip"
		$getapp = Get-AzureRmBatchApplicationPackage -ResourceGroupName $resourceGroup -AccountName $accountName -ApplicationId $applicationId -ApplicationVersion $applicationVersion

		Assert-AreEqual $getapp.Id $addAppPack.Id
		Assert-AreEqual $getapp.Version $addAppPack.Version

    }
    finally
    {
	 	Remove-AzureRmBatchApplicationPackage -AccountName $accountName -ApplicationId $applicationId -ResourceGroupName $resourceGroup -ApplicationVersion $applicationVersion
    }
}

<#
.SYNOPSIS
Tests querying for a Batch account that does not exist throws
#>
function Test-UpdateApplicationPackage
{
    param([string]$accountName, [string]$resourceGroup)

	# Setup
    $location = Get-BatchAccountProviderLocation
	$applicationId = "test"
	$applicationVersion = "foo"
	$newDisplayName = "application-display-name"

    try
    {
		$addAppPack = Add-AzureRmBatchApplicationPackage -ResourceGroupName $resourceGroup -AccountName $accountName -ApplicationId $applicationId -ApplicationVersion $applicationVersion -FilePath "Resources\foo.zip" -format "zip"
		$beforeUpdateApp = Get-AzureRmBatchApplicationPackage -ResourceGroupName $resourceGroup -AccountName $accountName -ApplicationId $applicationId -ApplicationVersion $applicationVersion

		Set-AzureRmBatchApplication -ResourceGroupName $resourceGroup -AccountName $accountName -ApplicationId $applicationId -displayName $newDisplayName -defaultVersion $applicationVersion -allowUpdates $FALSE
		$afterUpdateApp = Get-AzureRmBatchApplication -ResourceGroupName $resourceGroup -AccountName $accountName -ApplicationId $applicationId

		Assert-AreEqual $afterUpdateApp.DefaultVersion "foo"
		Assert-AreNotEqual $afterUpdateApp.DefaultVersion $beforeUpdateApp.DefaultVersion
		Assert-AreEqual $afterUpdateApp.AllowUpdates $FALSE
    }
    finally
    {
		Remove-AzureRmBatchApplicationPackage -AccountName $accountName -ApplicationId $applicationId -ResourceGroupName $resourceGroup -ApplicationVersion $applicationVersion
    }
}

<#
.SYNOPSIS
Tests querying for a Batch account that does not exist throws
#>
function Test-CreatePoolWithApplicationPackage
{
    param([string]$accountName, [string] $poolId, [string]$resourceGroup)

    $location = Get-BatchAccountProviderLocation
	$applicationId = "test"
	$applicationVersion = "foo"


	$context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    Assert-AreNotEqual $null $context
	try
	{

		$addAppPack = Add-AzureRmBatchApplicationPackage -ResourceGroupName $resourceGroup -AccountName $accountName -ApplicationId $applicationId -ApplicationVersion $applicationVersion -FilePath "Resources\foo.zip" -format "zip"
		$getapp = Get-AzureRmBatchApplicationPackage -ResourceGroupName $resourceGroup -AccountName $accountName -ApplicationId $applicationId -ApplicationVersion $applicationVersion

		Assert-AreEqual $getapp.Id $addAppPack.Id
		Assert-AreEqual $getapp.Version $addAppPack.Version


		$apr1 = New-Object Microsoft.Azure.Commands.Batch.Models.PSApplicationPackageReference
		$apr1.ApplicationId = $applicationId
		$apr1.Version = $applicationVersion
		$apr = [Microsoft.Azure.Commands.Batch.Models.PSApplicationPackageReference[]]$apr1

		# create a pool with apr
		$startTask = New-Object Microsoft.Azure.Commands.Batch.Models.PSStartTask
		$startTask.CommandLine = "cmd /c echo hello"

		$osFamily = "4"
		$targetOSVersion = "*"
		$paasConfiguration = New-Object Microsoft.Azure.Commands.Batch.Models.PSCloudServiceConfiguration -ArgumentList @($osFamily, $targetOSVersion)

		New-AzureBatchPool -Id $poolId -CloudServiceConfiguration $paasConfiguration -TargetDedicated 3 -VirtualMachineSize "small" -StartTask $startTask -BatchContext $context -ApplicationPackageReferences $apr
	}
	finally
	{
		Remove-AzureRmBatchApplicationPackage -AccountName $accountName -ApplicationId $applicationId -ResourceGroupName $resourceGroup -ApplicationVersion $applicationVersion
		Remove-AzureBatchPool -Id $poolId -Force -BatchContext $context
	}
}

<#
.SYNOPSIS
Tests querying for a Batch account that does not exist throws
#>
function Test-UpdatePoolWithApplicationPackage
{
    param([string]$accountName, [string] $poolId, [string]$resourceGroup)
    $location = Get-BatchAccountProviderLocation
	$applicationId = "test"
	$applicationVersion = "foo"


	$context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    Assert-AreNotEqual $null $context
	try
	{

		$addAppPack = Add-AzureRmBatchApplicationPackage -ResourceGroupName $resourceGroup -AccountName $accountName -ApplicationId $applicationId -ApplicationVersion $applicationVersion -FilePath "Resources\foo.zip" -format "zip"
		$getapp = Get-AzureRmBatchApplicationPackage -ResourceGroupName $resourceGroup -AccountName $accountName -ApplicationId $applicationId -ApplicationVersion $applicationVersion

		Assert-AreEqual $getapp.Id $addAppPack.Id
		Assert-AreEqual $getapp.Version $addAppPack.Version

		# create a pool with apr
		$startTask = New-Object Microsoft.Azure.Commands.Batch.Models.PSStartTask
		$startTask.CommandLine = "cmd /c echo hello"

		$osFamily = "4"
		$targetOSVersion = "*"
		$paasConfiguration = New-Object Microsoft.Azure.Commands.Batch.Models.PSCloudServiceConfiguration -ArgumentList @($osFamily, $targetOSVersion)

		$addPool = New-AzureBatchPool -Id $poolId -CloudServiceConfiguration $paasConfiguration -TargetDedicated 3 -VirtualMachineSize "small" -StartTask $startTask -BatchContext $context
		$getPool = get-AzureBatchPool -Id $poolId -BatchContext $context


		$apr1 = New-Object Microsoft.Azure.Commands.Batch.Models.PSApplicationPackageReference
		$apr1.ApplicationId = $applicationId
		$apr1.Version = $applicationVersion
		$apr = [Microsoft.Azure.Commands.Batch.Models.PSApplicationPackageReference[]]$apr1
		# adds APR to a pool
		$getPool.ApplicationPackageReferences = $apr

		$getPool | Set-AzureBatchPool -BatchContext $context

		$getPoolWithAPR = get-AzureBatchPool -Id $poolId -BatchContext $context
		Assert-AreNotEqual $getPoolWithAPR.ApplicationPackageReferences $null
	}
	finally
	{
		Remove-AzureRmBatchApplicationPackage -AccountName $accountName -ApplicationId $applicationId -ResourceGroupName $resourceGroup -ApplicationVersion $applicationVersion
		Remove-AzureBatchPool -Id $poolId -Force -BatchContext $context
	}
}
