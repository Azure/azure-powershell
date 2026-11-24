if(($null -eq $TestName) -or ($TestName -contains 'New-AzStorageMoverAzStorageContainerEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }

  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageMoverAzStorageContainerEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStorageMoverAzStorageContainerEndpoint PythonParity' -Tag 'PythonParity' {
    It 'CrossTenantDefaultsValidationAndAllowListLifecycle' {
        $context = $null
        try {
            $context = New-StorageMoverTestContext -Name 'sm-blob-cross-tenant'
            $default = New-AzStorageMoverAzStorageContainerEndpoint @context -Name 'default' -StorageAccountResourceId $env.ScenarioStorageAccountId -BlobContainerName 'testcontainer'
            $default.Property.EnableCrossTenantTransfer | Should -Be $false
            @($default.Property.AllowedStorageAccount).Count | Should -Be 0
            Invoke-StorageMoverTestFailure -Command {
                New-AzStorageMoverAzStorageContainerEndpoint @context -Name 'cross-tenant' -StorageAccountResourceId $env.ScenarioStorageAccountId -BlobContainerName 'testcontainer' -EnableCrossTenantTransfer -ErrorAction Stop
            }

            $partners = @(
                '/subscriptions/22222222-2222-2222-2222-222222222222/resourceGroups/partner-rg/providers/Microsoft.Storage/storageAccounts/partnerone',
                '/subscriptions/22222222-2222-2222-2222-222222222222/resourceGroups/partner-rg/providers/Microsoft.Storage/storageAccounts/partnertwo',
                '/subscriptions/33333333-3333-3333-3333-333333333333/resourceGroups/partner-rg/providers/Microsoft.Storage/storageAccounts/partnerthree'
            )
            $endpoint = New-AzStorageMoverAzStorageContainerEndpoint @context -Name 'cross-tenant' -StorageAccountResourceId $env.ScenarioStorageAccountId -BlobContainerName 'testcontainer' -EndpointKind Source -EnableCrossTenantTransfer -AllowedStorageAccount $partners[0..1]
            $endpoint.Property.EnableCrossTenantTransfer | Should -Be $true
            @($endpoint.Property.AllowedStorageAccount).Count | Should -Be 2
            $endpoint = Get-AzStorageMoverEndpoint @context -Name 'cross-tenant'
            $endpoint.Property.EndpointKind | Should -Be 'Source'
            $endpoint.Property.AllowedStorageAccount | Should -Contain $partners[0]
            $endpoint.Property.AllowedStorageAccount | Should -Contain $partners[1]

            $endpoint = Update-AzStorageMoverAzStorageContainerEndpoint @context -Name 'cross-tenant' -AllowedStorageAccount $partners[2]
            @($endpoint.Property.AllowedStorageAccount).Count | Should -Be 1
            $endpoint.Property.AllowedStorageAccount | Should -Contain $partners[2]
            $endpoint.Property.EnableCrossTenantTransfer | Should -Be $true
            $endpoint = Update-AzStorageMoverAzStorageContainerEndpoint @context -Name 'cross-tenant' -Description 'Allow-list preserved'
            $endpoint.Property.Description | Should -Be 'Allow-list preserved'
            $endpoint.Property.AllowedStorageAccount | Should -Contain $partners[2]
            $endpoint.Property.EnableCrossTenantTransfer | Should -Be $true

            $endpoint = Update-AzStorageMoverAzStorageContainerEndpoint @context -Name 'cross-tenant' -EnableCrossTenantTransfer:$false -AllowedStorageAccount @()
            $endpoint.Property.EnableCrossTenantTransfer | Should -Be $false
            @($endpoint.Property.AllowedStorageAccount).Count | Should -Be 0
            $endpoint = Get-AzStorageMoverEndpoint @context -Name 'cross-tenant'
            $endpoint.Property.EnableCrossTenantTransfer | Should -Be $false
            @($endpoint.Property.AllowedStorageAccount).Count | Should -Be 0
            foreach ($name in @('default', 'cross-tenant')) {
                Remove-AzStorageMoverEndpoint @context -Name $name
                Invoke-StorageMoverTestFailure -Code ResourceNotFound -Command { Get-AzStorageMoverEndpoint @context -Name $name -ErrorAction Stop }
            }
        } finally {
            Remove-StorageMoverTestContext -Context $context
        }
    }
}

Describe 'New-AzStorageMoverAzStorageContainerEndpoint' {
    It 'CreateExpanded' {
        $endpointName = "containerEndpoint1" + $env.RandomString
        $endpoint = New-AzStorageMoverAzStorageContainerEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -BlobContainerName $env.ContainerName -StorageMoverName $env.InitialStoMoverName -StorageAccountResourceId $env.StoraccId
        $endpoint.Name | Should -Be $endpointName
        $endpoint.Property.endpointType | Should -Be "AzureStorageBlobContainer"
        $endpoint.Property.blobContainerName | Should -Be $env.ContainerName

        $endpoint = Get-AzStorageMoverEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName
        $endpoint.Name | Should -Be $endpointName
        $endpoint.Property.endpointType | Should -Be "AzureStorageBlobContainer"
        $endpoint.Property.blobContainerName | Should -Be $env.ContainerName
    }

    It 'CreateExpandedCrossTenant' {
        $endpoint = New-AzStorageMoverAzStorageContainerEndpoint -Name "blobxt" -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.EndpointStoMoverName -StorageAccountResourceId $env.EndpointStorageAccountId -BlobContainerName $env.EndpointContainerName -EndpointKind Target -EnableCrossTenantTransfer -AllowedStorageAccount $env.PartnerStorageAccountId
        $endpoint.Property.EndpointKind | Should -Be "Target"
        $endpoint.Property.EnableCrossTenantTransfer | Should -Be $true
        $endpoint.Property.AllowedStorageAccount | Should -Be $env.PartnerStorageAccountId
    }
}
