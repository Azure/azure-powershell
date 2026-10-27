if(($null -eq $TestName) -or ($TestName -contains 'New/Update-AzStorageMoverAzSmbFileShareEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageMoverAzSmbFileShareEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New/Update-AzStorageMoverAzSmbFileShareEndpoint' {
    It 'Create and update' {
        $endpointName = "fseendpoint1" + $env.RandomString
        $fsendpoint = New-AzStorageMoverAzSmbFileShareEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -StorageAccountResourceId $env.StoraccId -FileShareName "testfs" -Description "New smb file share endpoint"
        $fsendpoint.Name | Should -Be $endpointName
        $fsendpoint.Property.EndpointType | Should -Be "AzureStorageSmbFileShare"
        $fsendpoint.Property.Description | Should -Be "New smb file share endpoint"
        $fsendpoint.Property.FileShareName | Should -Be "testfs"
        $fsendpoint.Property.StorageAccountResourceId | Should -Be $env.StoraccId

        $endpointName2 = "fseendpoint2" + $env.RandomString
        $fsendpoint = New-AzStorageMoverSmbFileShareEndpoint -Name $endpointName2 -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -StorageAccountResourceId $env.StoraccId -FileShareName "testfs" -Description "New smb file share endpoint"
        $fsendpoint.Name | Should -Be $endpointName2
        $fsendpoint.Property.EndpointType | Should -Be "AzureStorageSmbFileShare"
        $fsendpoint.Property.Description | Should -Be "New smb file share endpoint"
        $fsendpoint.Property.FileShareName | Should -Be "testfs"
        $fsendpoint.Property.StorageAccountResourceId | Should -Be $env.StoraccId
        
        $fsendpoint = Get-AzStorageMoverEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName
        $fsendpoint.Name | Should -Be $endpointName
        $fsendpoint.Property.EndpointType | Should -Be "AzureStorageSmbFileShare"
        $fsendpoint.Property.Description | Should -Be "New smb file share endpoint"
        $fsendpoint.Property.FileShareName | Should -Be "testfs"
        $fsendpoint.Property.StorageAccountResourceId | Should -Be $env.StoraccId

        $fsendpoint = Get-AzStorageMoverEndpoint -Name $endpointName2 -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName
        $fsendpoint.Name | Should -Be $endpointName2
        $fsendpoint.Property.EndpointType | Should -Be "AzureStorageSmbFileShare"
        $fsendpoint.Property.Description | Should -Be "New smb file share endpoint"
        $fsendpoint.Property.FileShareName | Should -Be "testfs"
        $fsendpoint.Property.StorageAccountResourceId | Should -Be $env.StoraccId

        $fsendpoint = Update-AzStorageMoverAzSmbFileShareEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Description "updated file share endpoint"
        $fsendpoint.Name | Should -Be $endpointName
        $fsendpoint.Property.EndpointType | Should -Be "AzureStorageSmbFileShare"
        $fsendpoint.Property.Description | Should -Be "updated file share endpoint"
        $fsendpoint.Property.FileShareName | Should -Be "testfs"
        $fsendpoint.Property.StorageAccountResourceId | Should -Be $env.StoraccId

        $fsendpoint = Update-AzStorageMoverSmbFileShareEndpoint -Name $endpointName2 -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Description "updated file share endpoint"
        $fsendpoint.Name | Should -Be $endpointName2
        $fsendpoint.Property.EndpointType | Should -Be "AzureStorageSmbFileShare"
        $fsendpoint.Property.Description | Should -Be "updated file share endpoint"
        $fsendpoint.Property.FileShareName | Should -Be "testfs"
        $fsendpoint.Property.StorageAccountResourceId | Should -Be $env.StoraccId

        $fsendpoint = Get-AzStorageMoverEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName
        $fsendpoint.Name | Should -Be $endpointName
        $fsendpoint.Property.EndpointType | Should -Be "AzureStorageSmbFileShare"
        $fsendpoint.Property.Description | Should -Be "updated file share endpoint"
        $fsendpoint.Property.FileShareName | Should -Be "testfs"
        $fsendpoint.Property.StorageAccountResourceId | Should -Be $env.StoraccId

        $fsendpoint = Get-AzStorageMoverEndpoint -Name $endpointName2 -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName
        $fsendpoint.Name | Should -Be $endpointName2
        $fsendpoint.Property.EndpointType | Should -Be "AzureStorageSmbFileShare"
        $fsendpoint.Property.Description | Should -Be "updated file share endpoint"
        $fsendpoint.Property.FileShareName | Should -Be "testfs"
        $fsendpoint.Property.StorageAccountResourceId | Should -Be $env.StoraccId
    }

    It 'CreateExpandedWithEndpointKind' {
        $endpointName = "smbsharext"
        $endpoint = New-AzStorageMoverAzSmbFileShareEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.EndpointStoMoverName -StorageAccountResourceId $env.EndpointStorageAccountId -FileShareName $env.EndpointFileShareName -EndpointKind Source
        $endpoint.Property.EndpointType | Should -Be "AzureStorageSmbFileShare"
        $endpoint.Property.EndpointKind | Should -Be "Source"

        $endpoint = Get-AzStorageMoverEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.EndpointStoMoverName
        $endpoint.Property.EndpointKind | Should -Be "Source"
    }

    It 'CreateExpandedCrossTenantRequest' {
        # The service does not accept cross-tenant settings on Azure SMB file share endpoints yet, so this checks the request offline.
        Mock -CommandName New-AzStorageMoverEndpoint -ModuleName Az.StorageMover.custom -MockWith { [pscustomobject]@{ Property = $Property } }
        $endpoint = New-AzStorageMoverAzSmbFileShareEndpoint -Name "smbsharexto" -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.EndpointStoMoverName -StorageAccountResourceId $env.EndpointStorageAccountId -FileShareName $env.EndpointFileShareName -EnableCrossTenantTransfer -AllowedStorageAccount $env.PartnerStorageAccountId
        $request = $endpoint.Property.ToJsonString() | ConvertFrom-Json
        $request.enableCrossTenantTransfer | Should -Be $true
        $request.allowedStorageAccounts | Should -Be $env.PartnerStorageAccountId

        $endpoint = New-AzStorageMoverAzSmbFileShareEndpoint -Name "smbsharexto" -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.EndpointStoMoverName -StorageAccountResourceId $env.EndpointStorageAccountId -FileShareName $env.EndpointFileShareName
        $request = $endpoint.Property.ToJsonString() | ConvertFrom-Json
        $request.PSObject.Properties.Name | Should -Not -Contain "enableCrossTenantTransfer"
        $request.PSObject.Properties.Name | Should -Not -Contain "allowedStorageAccounts"
    }
}
