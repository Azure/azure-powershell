# ----------------------------------------------------------------------------------
#
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

function Test-StorageAccountManagementPolicy
{
    $rgname = Get-StorageManagementTestResourceName
    $stoname = 'sto' + $rgname
    $location = Get-ProviderLocation_Canary ResourceManagement

    try
    {
        New-AzResourceGroup -Name $rgname -Location $location

        Assert-ThrowsContains {
            New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $location `
                -SkuName Standard_LRS -Kind StorageV2 -RequireUserBoundUserDelegationSas $true
        } 'SasExpirationPeriod'

        $account = New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $location `
            -SkuName Standard_LRS -Kind StorageV2 -AllowSharedKeyAccessForBlob $false `
            -AllowSharedKeyAccessForFile $false -AllowSharedKeyAccessForQueue $false `
            -AllowSharedKeyAccessForTable $false -AllowCrossTenantDelegationSas $false `
            -AllowBlobAccessPoints $false -SasExpirationPeriod '2.00:00:00' `
            -RequireUserBoundUserDelegationSas $false -RequireUserBoundUserDelegationSasAction bLoCk

        foreach ($service in @('Blob', 'File', 'Queue', 'Table'))
        {
            Assert-AreEqual $false $account.AllowSharedKeyAccessForServices.$service.Enabled
        }
        Assert-AreEqual $false $account.AllowCrossTenantDelegationSas
        Assert-AreEqual $false $account.AllowBlobAccessPoints
        Assert-AreEqual $false $account.SasPolicy.RequireUserBoundUserDelegationSas
        Assert-AreEqual 'Block' $account.SasPolicy.RequireUserBoundUserDelegationSasAction

        $account = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname `
            -AllowSharedKeyAccessForBlob $true -AllowSharedKeyAccessForFile $true `
            -AllowSharedKeyAccessForQueue $true -AllowSharedKeyAccessForTable $true `
            -AllowCrossTenantDelegationSas $true -AllowBlobAccessPoints $true
        Assert-AreEqual $true $account.AllowCrossTenantDelegationSas
        Assert-AreEqual $true $account.AllowBlobAccessPoints

        $account = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -AllowSharedKeyAccessForBlob $false
        Assert-AreEqual $false $account.AllowSharedKeyAccessForServices.Blob.Enabled
        foreach ($service in @('File', 'Queue', 'Table'))
        {
            Assert-AreEqual $true $account.AllowSharedKeyAccessForServices.$service.Enabled
        }
        Assert-AreEqual $true $account.AllowBlobAccessPoints

        $account = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname `
            -SasExpirationPeriod '3.00:00:00' -SasExpirationAction Block
        Assert-AreEqual '3.00:00:00' $account.SasPolicy.SasExpirationPeriod
        Assert-AreEqual 'Block' $account.SasPolicy.ExpirationAction
        Assert-AreEqual $false $account.SasPolicy.RequireUserBoundUserDelegationSas
        Assert-AreEqual 'Block' $account.SasPolicy.RequireUserBoundUserDelegationSasAction

        $account = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -RequireUserBoundUserDelegationSas $true
        Assert-AreEqual $true $account.SasPolicy.RequireUserBoundUserDelegationSas
        Assert-AreEqual '3.00:00:00' $account.SasPolicy.SasExpirationPeriod
        Assert-AreEqual 'Block' $account.SasPolicy.ExpirationAction
        Assert-AreEqual 'Block' $account.SasPolicy.RequireUserBoundUserDelegationSasAction

        $account = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname `
            -RequireUserBoundUserDelegationSas $false -RequireUserBoundUserDelegationSasAction lOg `
            -AllowCrossTenantDelegationSas $false -AllowBlobAccessPoints $false
        Assert-AreEqual $false $account.SasPolicy.RequireUserBoundUserDelegationSas
        Assert-AreEqual 'Log' $account.SasPolicy.RequireUserBoundUserDelegationSasAction

        $account = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Tag @{ purpose = 'policy-preservation' }
        Assert-AreEqual $false $account.AllowCrossTenantDelegationSas
        Assert-AreEqual $false $account.AllowBlobAccessPoints
        Assert-AreEqual $false $account.AllowSharedKeyAccessForServices.Blob.Enabled
        Assert-AreEqual $true $account.AllowSharedKeyAccessForServices.File.Enabled
        Assert-AreEqual '3.00:00:00' $account.SasPolicy.SasExpirationPeriod
        Assert-AreEqual 'Log' $account.SasPolicy.RequireUserBoundUserDelegationSasAction

        $account = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname
        Assert-AreEqual $false $account.SasPolicy.RequireUserBoundUserDelegationSas
        Assert-AreEqual $false $account.AllowCrossTenantDelegationSas
        $accounts = @(Get-AzStorageAccount -ResourceGroupName $rgname)
        Assert-AreEqual 1 $accounts.Count
        Assert-AreEqual $false $accounts[0].AllowSharedKeyAccessForServices.Blob.Enabled

        $account = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -SasExpirationPeriod '0.00:00:00'
        Assert-Null $account.SasPolicy
        Assert-ThrowsContains {
            Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -RequireUserBoundUserDelegationSasAction Block
        } 'SasExpirationPeriod'
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

function Test-StorageAccountIpv6Endpoints
{
    $rgname = Get-StorageManagementTestResourceName
    $stoname = 'sto' + $rgname
    $disabledName = 'ipv' + $rgname
    $location = Get-ProviderLocation_Canary ResourceManagement

    try
    {
        New-AzResourceGroup -Name $rgname -Location $location

        $account = New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $location `
            -SkuName Standard_LRS -Kind StorageV2 -PublishIpv6Endpoint $true
        Assert-AreEqual $true $account.DualStackEndpointPreference.PublishIpv6Endpoint
        Assert-NotNull $account.PrimaryEndpoints.Ipv6Endpoints

        $account = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname
        Assert-AreEqual $true $account.DualStackEndpointPreference.PublishIpv6Endpoint
        Assert-NotNull $account.PrimaryEndpoints.Ipv6Endpoints

        $account = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Tag @{ purpose = 'ipv6-preservation' }
        Assert-AreEqual $true $account.DualStackEndpointPreference.PublishIpv6Endpoint

        $account = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -PublishIpv6Endpoint $false
        Assert-AreEqual $false $account.DualStackEndpointPreference.PublishIpv6Endpoint
        Assert-Null $account.PrimaryEndpoints.Ipv6Endpoints

        $account = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname
        Assert-AreEqual $false $account.DualStackEndpointPreference.PublishIpv6Endpoint
        Assert-Null $account.PrimaryEndpoints.Ipv6Endpoints

        $account = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -PublishIpv6Endpoint $true
        Assert-AreEqual $true $account.DualStackEndpointPreference.PublishIpv6Endpoint

        $account = New-AzStorageAccount -ResourceGroupName $rgname -Name $disabledName -Location $location `
            -SkuName Standard_LRS -Kind StorageV2 -PublishIpv6Endpoint $false
        Assert-AreEqual $false $account.DualStackEndpointPreference.PublishIpv6Endpoint
        Assert-Null $account.PrimaryEndpoints.Ipv6Endpoints

        $accounts = @(Get-AzStorageAccount -ResourceGroupName $rgname)
        Assert-AreEqual 2 $accounts.Count
        Assert-AreEqual $true ($accounts | Where-Object StorageAccountName -EQ $stoname).DualStackEndpointPreference.PublishIpv6Endpoint
        Assert-AreEqual $false ($accounts | Where-Object StorageAccountName -EQ $disabledName).DualStackEndpointPreference.PublishIpv6Endpoint
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

function Test-StorageAccountTurboTier
{
    $rgname = Get-StorageManagementTestResourceName
    $stoname = 'sto' + $rgname
    $location = Get-ProviderLocation_Canary ResourceManagement

    try
    {
        New-AzResourceGroup -Name $rgname -Location $location
        foreach ($percent in @(9, 101))
        {
            Assert-ThrowsContains {
                New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $location `
                    -SkuName Standard_LRS -Kind StorageV2 -TurboTierTargetPercent $percent
            } 'TurboTierTargetPercent'
        }
        $account = New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $location `
            -SkuName Standard_LRS -Kind StorageV2 -AccessTier Hot -TurboTierStatus eNaBlEd -TurboTierTargetPercent 10
        Assert-AreEqual 'Enabled' $account.TurboTier.Status
        Assert-AreEqual 10 $account.TurboTier.TargetPercent

        $account = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -TurboTierStatus eNaBlEd
        Assert-AreEqual 'Enabled' $account.TurboTier.Status
        Assert-AreEqual 10 $account.TurboTier.TargetPercent

        $account = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -TurboTierTargetPercent 100
        Assert-AreEqual 'Enabled' $account.TurboTier.Status
        Assert-AreEqual 100 $account.TurboTier.TargetPercent

        $account = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname
        Assert-AreEqual 'Enabled' $account.TurboTier.Status
        Assert-AreEqual 100 $account.TurboTier.TargetPercent
        $accounts = @(Get-AzStorageAccount -ResourceGroupName $rgname)
        Assert-AreEqual 1 $accounts.Count
        Assert-AreEqual 100 $accounts[0].TurboTier.TargetPercent

        $account = Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -TurboTierStatus dIsAbLeD
        Assert-AreEqual 'Disabled' $account.TurboTier.Status
        Assert-ThrowsContains {
            Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -TurboTierTargetPercent 9
        } 'TurboTierTargetPercent'
        Assert-ThrowsContains {
            Set-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -TurboTierTargetPercent 101
        } 'TurboTierTargetPercent'
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

function Test-StorageContainerBlobAccessPointAttachment
{
    $fixture = $null
    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne 'Playback')
    {
        $fixturePath = [Environment]::GetEnvironmentVariable('AZURE_STORAGE_MANAGEMENT_TEST_FIXTURES')
        if ([string]::IsNullOrWhiteSpace($fixturePath))
        {
            throw 'Set AZURE_STORAGE_MANAGEMENT_TEST_FIXTURES to the recording fixture file.'
        }
        $fixture = (Get-Content -LiteralPath $fixturePath -Raw | ConvertFrom-Json).ManagementApi.Attachment
    }

    $values = @{}
    foreach ($field in @('ResourceGroupName', 'AccountName', 'ConfigurationName', 'UniqueId'))
    {
        $values[$field] = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetVariable(
            "Attachment$field", [string]$fixture.$field)
        if ([string]::IsNullOrWhiteSpace($values[$field]))
        {
            throw "The attachment recording fixture requires $field."
        }
    }
    $scope = @{
        ResourceGroupName = $values.ResourceGroupName
        StorageAccountName = $values.AccountName
    }
    $name = 'container' + (Get-StorageManagementTestResourceName)
    $created = $false

    try
    {
        $container = New-AzRmStorageContainer @scope -Name $name `
            -BlobAccessPointConfigurationName $values.ConfigurationName `
            -BlobAccessPointConfigurationUniqueId $values.UniqueId
        $created = $true
        Assert-AreEqual $values.ConfigurationName $container.BlobAccessPointConfiguration.BlobAccessPointConfigurationName
        Assert-AreEqual $values.UniqueId $container.BlobAccessPointConfiguration.BlobAccessPointConfigurationUniqueId

        $container = Update-AzRmStorageContainer @scope -Name $name -Metadata @{ purpose = 'attachment-update' }
        Assert-AreEqual 'attachment-update' $container.Metadata['purpose']
        $container = Get-AzRmStorageContainer @scope -Name $name
        Assert-AreEqual $values.ConfigurationName $container.BlobAccessPointConfiguration.BlobAccessPointConfigurationName
        Assert-AreEqual $values.UniqueId $container.BlobAccessPointConfiguration.BlobAccessPointConfigurationUniqueId
        $listed = @(Get-AzRmStorageContainer @scope | Where-Object Name -EQ $name)
        Assert-AreEqual 1 $listed.Count
        Assert-AreEqual $values.UniqueId $listed[0].BlobAccessPointConfiguration.BlobAccessPointConfigurationUniqueId
    }
    finally
    {
        if ($created)
        {
            Remove-AzRmStorageContainer @scope -Name $name -Force
        }
    }
}
