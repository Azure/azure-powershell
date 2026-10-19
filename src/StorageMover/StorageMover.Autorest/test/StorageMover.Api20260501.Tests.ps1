if(($null -eq $TestName) -or ($TestName -contains 'StorageMover.Api20260501'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'StorageMover.Api20260501.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

# Scenarios for the API 2026-05-01 additions. Before recording, create these storage accounts in the test
# resource group: smt2605eks0fri (eastus2euap) with blob container xtcontainer and file share xtshare, and
# smt2605aks0fri (eastus) with blob container xtcontainer. The cross-tenant job also needs a partner tenant with
# storage account smt2605bks0fri and storage mover smxtpartner-ks0fri (eastus, resource group
# storagemover-xtenant-test) holding a cross-tenant Target endpoint test-xttarget that allows smt2605aks0fri.
# Supply the partner tenant and subscription through SM_XT_PARTNER_TENANT and SM_XT_PARTNER_SUBSCRIPTION while
# recording; the recording stores placeholder IDs instead. Cross-tenant settings on Azure SMB file share endpoints
# are covered by the offline tests because the service does not support them yet.
Describe 'StorageMover.Api20260501' {
    BeforeAll {
        $suffix = 'ks0fri'
        $resourceGroupName = $env.ResourceGroupName
        $endpointsMoverName = "smapi2605e$suffix"
        $crossTenantMoverName = "smapi2605x$suffix"
        $accountPrefix = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$resourceGroupName/providers/Microsoft.Storage/storageAccounts"
        $endpointsAccountId = "$accountPrefix/smt2605e$suffix"
        $hostAccountId = "$accountPrefix/smt2605a$suffix"
        $partnerTenantId = if ($env:SM_XT_PARTNER_TENANT) { $env:SM_XT_PARTNER_TENANT } else { '22222222-2222-2222-2222-222222222222' }
        $partnerSubscriptionId = if ($env:SM_XT_PARTNER_SUBSCRIPTION) { $env:SM_XT_PARTNER_SUBSCRIPTION } else { '11111111-1111-1111-1111-111111111111' }
        $partnerResourceGroupId = "/subscriptions/$partnerSubscriptionId/resourceGroups/storagemover-xtenant-test"
        $partnerAccountId = "$partnerResourceGroupId/providers/Microsoft.Storage/storageAccounts/smt2605b$suffix"
        $partnerEndpointName = 'test-xttarget'
        $partnerEndpointId = "$partnerResourceGroupId/providers/Microsoft.StorageMover/storageMovers/smxtpartner-$suffix/endpoints/$partnerEndpointName"

        New-AzStorageMover -ResourceGroupName $resourceGroupName -Name $endpointsMoverName -Location $env.Location | Out-Null
        New-AzStorageMover -ResourceGroupName $resourceGroupName -Name $crossTenantMoverName -Location 'eastus' | Out-Null
    }

    AfterAll {
        foreach ($moverName in @($endpointsMoverName, $crossTenantMoverName)) {
            Remove-AzStorageMover -ResourceGroupName $resourceGroupName -Name $moverName -Force -ErrorAction SilentlyContinue
        }
    }

    It 'AzStorageContainerEndpointCrossTenant' {
        $endpoint = @{ Name = 'blobxt'; ResourceGroupName = $resourceGroupName; StorageMoverName = $endpointsMoverName }
        $created = New-AzStorageMoverAzStorageContainerEndpoint @endpoint -StorageAccountResourceId $endpointsAccountId -BlobContainerName 'xtcontainer' -EndpointKind Target -EnableCrossTenantTransfer -AllowedStorageAccount $partnerAccountId
        $replaced = Update-AzStorageMoverAzStorageContainerEndpoint @endpoint -AllowedStorageAccount $partnerAccountId, $hostAccountId
        $disabled = Update-AzStorageMoverAzStorageContainerEndpoint @endpoint -EnableCrossTenantTransfer:$false -AllowedStorageAccount @()
        $fetched = Get-AzStorageMoverEndpoint @endpoint

        $created.Property.EndpointKind | Should -Be 'Target'
        $created.Property.EnableCrossTenantTransfer | Should -Be $true
        @($created.Property.AllowedStorageAccount).Count | Should -Be 1
        $created.Property.AllowedStorageAccount[0] | Should -Be $partnerAccountId
        $replaced.Property.EnableCrossTenantTransfer | Should -Be $true
        @($replaced.Property.AllowedStorageAccount).Count | Should -Be 2
        $disabled.Property.EnableCrossTenantTransfer | Should -Be $false
        @($disabled.Property.AllowedStorageAccount).Count | Should -Be 0
        $fetched.Property.EndpointKind | Should -Be 'Target'
        $fetched.Property.EnableCrossTenantTransfer | Should -Be $false
    }

    It 'AzSmbFileShareEndpointKind' {
        $endpoint = @{ Name = 'smbsharext'; ResourceGroupName = $resourceGroupName; StorageMoverName = $endpointsMoverName }
        $created = New-AzStorageMoverAzSmbFileShareEndpoint @endpoint -StorageAccountResourceId $endpointsAccountId -FileShareName 'xtshare' -EndpointKind Source
        $fetched = Get-AzStorageMoverEndpoint @endpoint

        $created.Property.EndpointType | Should -Be 'AzureStorageSmbFileShare'
        $created.Property.EndpointKind | Should -Be 'Source'
        $fetched.Property.EndpointKind | Should -Be 'Source'
    }

    # The service accepts SourceType but does not return it, so these scenarios check creation and EndpointKind.
    It 'NfsEndpointFsxEfsSource' {
        $endpoint = @{ Name = 'nfsfsx'; ResourceGroupName = $resourceGroupName; StorageMoverName = $endpointsMoverName }
        $created = New-AzStorageMoverNfsEndpoint @endpoint -Host '10.0.0.5' -Export '/export' -SourceType 'FSX-EFS' -EndpointKind Source
        $fetched = Get-AzStorageMoverEndpoint @endpoint

        $created.Property.EndpointType | Should -Be 'NfsMount'
        $created.Property.EndpointKind | Should -Be 'Source'
        $fetched.Property.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'SmbEndpointFsxSmbSource' {
        $endpoint = @{ Name = 'smbfsx'; ResourceGroupName = $resourceGroupName; StorageMoverName = $endpointsMoverName }
        $created = New-AzStorageMoverSmbEndpoint @endpoint -Host '10.0.0.6' -ShareName 'share' -SourceType 'FSX-SMB' -EndpointKind Source
        $fetched = Get-AzStorageMoverEndpoint @endpoint

        $created.Property.EndpointType | Should -Be 'SmbMount'
        $created.Property.EndpointKind | Should -Be 'Source'
        $fetched.Property.ProvisioningState | Should -Be 'Succeeded'
    }

    It 'JobDefinitionCrossTenant' {
        $mover = @{ ResourceGroupName = $resourceGroupName; StorageMoverName = $crossTenantMoverName }
        New-AzStorageMoverProject @mover -Name 'xtproject' | Out-Null
        New-AzStorageMoverAzStorageContainerEndpoint @mover -Name 'blobsource' -StorageAccountResourceId $hostAccountId -BlobContainerName 'xtcontainer' -EndpointKind Source -EnableCrossTenantTransfer -AllowedStorageAccount $partnerAccountId | Out-Null
        $created = New-AzStorageMoverJobDefinition @mover -ProjectName 'xtproject' -Name 'xtjob' -JobType CloudToCloud -CopyMode Additive -SourceName 'blobsource' -TargetName $partnerEndpointName -IsCrossTenantJob -CrossTenantEndpointTenantId $partnerTenantId -CrossTenantEndpointResourceId $partnerEndpointId
        $fetched = Get-AzStorageMoverJobDefinition @mover -ProjectName 'xtproject' -Name 'xtjob'

        $created.IsCrossTenantJob | Should -Be $true
        $created.CrossTenantEndpointTenantId | Should -Be $partnerTenantId
        $created.CrossTenantEndpointResourceId | Should -Be $partnerEndpointId
        $fetched.IsCrossTenantJob | Should -Be $true
        $fetched.TargetName | Should -Be $partnerEndpointName
        $fetched.CrossTenantEndpointResourceId | Should -Be $partnerEndpointId
    }
}
