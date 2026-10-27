if(($null -eq $TestName) -or ($TestName -contains 'Update-AzStorageMoverAzStorageContainerEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStorageMoverAzStorageContainerEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzStorageMoverAzStorageContainerEndpoint' {
    It 'UpdateExpanded' {
        $endpointName = "containerEndpoint2" + $env.RandomString
        $description = "initial description"
        $endpoint = New-AzStorageMoverAzStorageContainerEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -BlobContainerName $env.ContainerName -StorageMoverName $env.InitialStoMoverName -StorageAccountResourceId $env.StoraccId -Description $initialDescription
        $updateDescription = "update description"
        $endpoint = Update-AzStorageMoverAzStorageContainerEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Description $updateDescription
        $endpoint.Property.Description | Should -Be $updateDescription
        $endpoint.Name | Should -Be $endpointName

        $endpoint = Get-AzStorageMoverEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName
        $endpoint.Property.Description | Should -Be $updateDescription
        $endpoint.Name | Should -Be $endpointName
    }

    It 'UpdateExpandedCrossTenant' {
        $endpointName = "blobxt"
        New-AzStorageMoverAzStorageContainerEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.EndpointStoMoverName -StorageAccountResourceId $env.EndpointStorageAccountId -BlobContainerName $env.EndpointContainerName -EndpointKind Target -EnableCrossTenantTransfer -AllowedStorageAccount $env.PartnerStorageAccountId | Out-Null

        $endpoint = Update-AzStorageMoverAzStorageContainerEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.EndpointStoMoverName -AllowedStorageAccount $env.PartnerStorageAccountId, $env.CrossTenantStorageAccountId
        $endpoint.Property.EnableCrossTenantTransfer | Should -Be $true
        @($endpoint.Property.AllowedStorageAccount).Count | Should -Be 2

        $endpoint = Update-AzStorageMoverAzStorageContainerEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.EndpointStoMoverName -EnableCrossTenantTransfer:$false -AllowedStorageAccount @()
        $endpoint.Property.EnableCrossTenantTransfer | Should -Be $false
        @($endpoint.Property.AllowedStorageAccount).Count | Should -Be 0

        $endpoint = Get-AzStorageMoverEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.EndpointStoMoverName
        $endpoint.Property.EndpointKind | Should -Be "Target"
        $endpoint.Property.EnableCrossTenantTransfer | Should -Be $false
    }
}
