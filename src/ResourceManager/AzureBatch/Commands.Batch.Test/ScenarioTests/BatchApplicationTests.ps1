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
Tests creating a new application
#>
function Test-UploadApplication
{
    param([string]$accountName, [string]$resourceGroup)

	# Setup
	$applicationId = "test"
	$applicationVersion = "foo"

    try
    {
		$addAppPack = New-AzureRmBatchApplication -ResourceGroupName $resourceGroup -AccountName $accountName -ApplicationId $applicationId
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
Tests uploading an application package.
#>
function Test-UploadApplicationPackage
{
    param([string]$accountName, [string]$resourceGroup, [string]$filePath)

	# Setup
	$applicationId = "test"
	$applicationVersion = "foo"
	#Assert-AreEqual $filePath "Resources\foo.zip"
	#Assert-AreEqual $filePath "Resources\foo.zip"

	Assert-AreNotEqual $null $resourceGroup
	Assert-AreNotEqual $null $accountName
	Assert-AreNotEqual $null $applicationId
	Assert-AreNotEqual $null $applicationVersion

    try
    {
		$addAppPack = New-AzureRmBatchApplicationPackage -ResourceGroupName $resourceGroup -AccountName $accountName -ApplicationId $applicationId -ApplicationVersion $applicationVersion -FilePath "D:\ps\azure-powershell-pr\src\ResourceManager\AzureBatch\Commands.Batch.Test\bin\Debug\Resources\foo.zip" -format "zip"
		$getapp = Get-AzureRmBatchApplicationPackage -ResourceGroupName $resourceGroup -AccountName $accountName -ApplicationId $applicationId -ApplicationVersion $applicationVersion
		##
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
Tests can update an application settings
#>
function Test-UpdateApplicationPackage
{
    param([string]$accountName, [string]$resourceGroup, [string]$filePath)

	# Setup
    $applicationId = "test"
	$applicationVersion = "foo"
	$newDisplayName = "application-display-name"

    try
    {
		$addAppPack = New-AzureRmBatchApplicationPackage -ResourceGroupName $resourceGroup -AccountName $accountName -ApplicationId $applicationId -ApplicationVersion $applicationVersion -FilePath $filePath -format "zip"
		$beforeUpdateApp = Get-AzureRmBatchApplicationPackage -ResourceGroupName $resourceGroup -AccountName $accountName -ApplicationId $applicationId -ApplicationVersion $applicationVersion

		Set-AzureRmBatchApplication -ResourceGroupName $resourceGroup -AccountName $accountName -ApplicationId $applicationId -displayName $newDisplayName -defaultVersion $applicationVersion -allowUpdates 
		$afterUpdateApp = Get-AzureRmBatchApplication -ResourceGroupName $resourceGroup -AccountName $accountName -ApplicationId $applicationId

		Assert-AreEqual $afterUpdateApp.DefaultVersion "foo"
		Assert-AreNotEqual $afterUpdateApp.DefaultVersion $beforeUpdateApp.DefaultVersion
		Assert-AreEqual $afterUpdateApp.AllowUpdates $TRUE
    }
    finally
    {
		Remove-AzureRmBatchApplicationPackage -AccountName $accountName -ApplicationId $applicationId -ResourceGroupName $resourceGroup -ApplicationVersion $applicationVersion
    }
}

<#
.SYNOPSIS
Tests create pool with an application package.
#>
function Test-CreatePoolWithApplicationPackage
{
    param([string]$accountName, [string] $poolId, [string]$resourceGroup, [string]$filePath)
	$applicationId = "test"
	$applicationVersion = "foo"


	$context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    Assert-AreNotEqual $null $context
	try
	{

		$addAppPack = New-AzureRmBatchApplicationPackage -ResourceGroupName $resourceGroup -AccountName $accountName -ApplicationId $applicationId -ApplicationVersion $applicationVersion -FilePath $filePath -format "zip"
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
Tests update pool with an application package.
#>
function Test-UpdatePoolWithApplicationPackage
{
    param([string]$accountName, [string] $poolId, [string]$resourceGroup, [string]$filePath)
	$applicationId = "test"
	$applicationVersion = "foo"


	$context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext
    Assert-AreNotEqual $null $context
	try
	{

		$addAppPack = New-AzureRmBatchApplicationPackage -ResourceGroupName $resourceGroup -AccountName $accountName -ApplicationId $applicationId -ApplicationVersion $applicationVersion -FilePath $filePath -format "zip"
		$getapp = Get-AzureRmBatchApplicationPackage -ResourceGroupName $resourceGroup -AccountName $accountName -ApplicationId $applicationId -ApplicationVersion $applicationVersion

		Assert-AreEqual $getapp.Id $addAppPack.Id
		Assert-AreEqual $getapp.Version $addAppPack.Version

		$startTask = New-Object Microsoft.Azure.Commands.Batch.Models.PSStartTask
		$startTask.CommandLine = "cmd /c echo hello"

		$osFamily = "4"
		$targetOSVersion = "*"
		$paasConfiguration = New-Object Microsoft.Azure.Commands.Batch.Models.PSCloudServiceConfiguration -ArgumentList @($osFamily, $targetOSVersion)

		$addPool = New-AzureBatchPool -Id $poolId -CloudServiceConfiguration $paasConfiguration -TargetDedicated 3 -VirtualMachineSize "small" -StartTask $startTask -BatchContext $context
		$getPool = get-AzureBatchPool -Id $poolId -BatchContext $context

		# update pool with application package references
		$apr1 = New-Object Microsoft.Azure.Commands.Batch.Models.PSApplicationPackageReference
		$apr1.ApplicationId = $applicationId
		$apr1.Version = $applicationVersion
		$apr = [Microsoft.Azure.Commands.Batch.Models.PSApplicationPackageReference[]]$apr1

		$getPool.ApplicationPackageReferences = $apr

		$getPool | Set-AzureBatchPool -BatchContext $context

		$getPoolWithAPR = get-AzureBatchPool -Id $poolId -BatchContext $context
		# pool has application package references
		Assert-AreNotEqual $getPoolWithAPR.ApplicationPackageReferences $null
	}
	finally
	{
		Remove-AzureRmBatchApplicationPackage -AccountName $accountName -ApplicationId $applicationId -ResourceGroupName $resourceGroup -ApplicationVersion $applicationVersion
		Remove-AzureBatchPool -Id $poolId -Force -BatchContext $context
	}
}
