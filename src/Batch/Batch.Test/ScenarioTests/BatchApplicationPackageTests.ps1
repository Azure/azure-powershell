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
Tests uploading an application package.
#>
function Test-UploadApplicationPackage
{
    param([string] $applicationName, [string] $applicationVersion, [string]$filePath)

    # Setup
    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    $addAppPack = New-AzBatchApplicationPackage -ResourceGroupName $context.ResourceGroupName -AccountName $context.AccountName -ApplicationName $applicationName -ApplicationVersion $applicationVersion -format "zip" -ActivateOnly
    $subId = $context.Subscription
    $resourceGroup = $context.ResourceGroupName
    $batchAccountName = $context.AccountName

    Assert-AreEqual "/subscriptions/$subId/resourceGroups/$resourceGroup/providers/Microsoft.Batch/batchAccounts/$batchAccountName/applications/$applicationName/versions/$applicationVersion" $addAppPack.Id
    Assert-AreEqual $applicationVersion $addAppPack.Name
}

<#
.SYNOPSIS
Tests can update an application settings
#>
function Test-UpdateApplicationPackage
{
    param([string] $applicationName, [string] $applicationVersion, [string]$filePath)

    # Setup
    $newDisplayName = "application-display-name"
    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    $beforeUpdateApp = Get-AzBatchApplication -ResourceGroupName $context.ResourceGroupName -AccountName $context.AccountName -ApplicationName $applicationName

    $addAppPack = New-AzBatchApplicationPackage -ResourceGroupName $context.ResourceGroupName -AccountName $context.AccountName -ApplicationName $applicationName -ApplicationVersion $applicationVersion -format "zip" -ActivateOnly
    Set-AzBatchApplication -ResourceGroupName $context.ResourceGroupName -AccountName $context.AccountName -ApplicationName $applicationName -displayName $newDisplayName -defaultVersion $applicationVersion

    $afterUpdateApp = Get-AzBatchApplication -ResourceGroupName $context.ResourceGroupName -AccountName $context.AccountName -ApplicationName $applicationName

    Assert-AreEqual $afterUpdateApp.DefaultVersion $applicationVersion
    Assert-AreNotEqual $afterUpdateApp.DefaultVersion $beforeUpdateApp.DefaultVersion
    Assert-AreEqual $afterUpdateApp.AllowUpdates $true
}

<#
.SYNOPSIS
Tests create pool with an application package.
#>
function Test-CreatePoolWithApplicationPackage
{
    param([string] $applicationName, [string] $applicationVersion, [string] $poolId, [string]$filePath)

    # Setup
    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    try
    {
        $addAppPack = New-AzBatchApplicationPackage -ResourceGroupName $context.ResourceGroupName -AccountName $context.AccountName -ApplicationName $applicationName -ApplicationVersion $applicationVersion -format "zip" -ActivateOnly

        Assert-AreEqual $applicationVersion $addAppPack.Name

        $apr1 = New-Object Microsoft.Azure.Commands.Batch.Models.PSApplicationPackageReference
        $apr1.ApplicationId = $applicationName
        $apr1.Version = $applicationVersion
        $apr = [Microsoft.Azure.Commands.Batch.Models.PSApplicationPackageReference[]]$apr1

        # Create a pool with application package reference
        $vmSize = "standard_d1_v2"
        $publisher = "microsoft-azure-batch"
        $offer = "ubuntu-server-container"
        $osSKU = "20-04-lts"
        $nodeAgent = "batch.node.ubuntu 20.04"
        $imageRef = New-Object Microsoft.Azure.Commands.Batch.Models.PSImageReference -ArgumentList @($offer, $publisher, $osSKU)
        $iaasConfiguration = New-Object Microsoft.Azure.Commands.Batch.Models.PSVirtualMachineConfiguration -ArgumentList @($imageRef, $nodeAgent)
        New-AzBatchPool -Id $poolId -VirtualMachineSize "standard_d1_v2" -TargetDedicated 3 -VirtualMachineConfiguration $iaasConfiguration -BatchContext $context -ApplicationPackageReferences $apr
    }
    finally
    {
        Remove-AzBatchApplicationPackage -AccountName $context.AccountName -ApplicationName $applicationName -ResourceGroupName $context.ResourceGroupName -ApplicationVersion $applicationVersion
        Remove-AzBatchApplication  -AccountName $context.AccountName -ApplicationName $applicationName -ResourceGroupName $context.ResourceGroupName
        Remove-AzBatchPool -Id $poolId -Force -BatchContext $context
    }
}

<#
.SYNOPSIS
Tests update pool with an application package.
#>
function Test-UpdatePoolWithApplicationPackage
{
    param([string] $applicationName, [string] $applicationVersion, [string] $poolId, [string]$filePath)

    $context = New-Object Microsoft.Azure.Commands.Batch.Test.ScenarioTests.ScenarioTestContext

    $addAppPack = New-AzBatchApplicationPackage -ResourceGroupName $context.ResourceGroupName -AccountName $context.AccountName -ApplicationName $applicationName -ApplicationVersion $applicationVersion -format "zip" -ActivateOnly

    Assert-AreEqual $applicationVersion $addAppPack.Name

    $getPool = Get-AzBatchPool -Id $poolId -BatchContext $context

    # update pool with application package references
    $apr1 = New-Object Microsoft.Azure.Commands.Batch.Models.PSApplicationPackageReference
    $apr1.ApplicationId = $applicationName
    $apr1.Version = $applicationVersion
    $apr = [Microsoft.Azure.Commands.Batch.Models.PSApplicationPackageReference[]]$apr1

    $getPool.ApplicationPackageReferences = $apr
    $getPool | Set-AzBatchPool -BatchContext $context

    $getPoolWithAPR = get-AzBatchPool -Id $poolId -BatchContext $context
    # pool has application package references
    Assert-AreNotEqual $getPoolWithAPR.ApplicationPackageReferences $null
}
