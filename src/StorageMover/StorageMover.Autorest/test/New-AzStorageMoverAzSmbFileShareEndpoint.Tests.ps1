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

}

Describe 'New-AzStorageMoverAzSmbFileShareEndpoint RequestContract' -Tag @('PythonParity', 'Offline') {
    It 'CreateExpandedCrossTenantRequest' {
        $response = @{ properties = @{ endpointType = 'AzureStorageSmbFileShare' } }
        $capture = Invoke-StorageMoverTestRequest -Response $response -Command {
            param($pipeline)
            New-AzStorageMoverAzSmbFileShareEndpoint -Name 'smbsharexto' -SubscriptionId $env.SubscriptionId -ResourceGroupName 'rg' -StorageMoverName 'mover' -StorageAccountResourceId $env.EndpointStorageAccountId -FileShareName $env.EndpointFileShareName -EnableCrossTenantTransfer -AllowedStorageAccount $env.PartnerStorageAccountId -HttpPipelinePrepend $pipeline
        }
        $capture.Requests[0].Method | Should -Be 'PUT'
        $request = ($capture.Requests[0].Content | ConvertFrom-Json).properties
        $request.enableCrossTenantTransfer | Should -Be $true
        $request.allowedStorageAccounts | Should -Be $env.PartnerStorageAccountId

        $capture = Invoke-StorageMoverTestRequest -Response $response -Command {
            param($pipeline)
            New-AzStorageMoverAzSmbFileShareEndpoint -Name 'smbsharexto' -SubscriptionId $env.SubscriptionId -ResourceGroupName 'rg' -StorageMoverName 'mover' -StorageAccountResourceId $env.EndpointStorageAccountId -FileShareName $env.EndpointFileShareName -HttpPipelinePrepend $pipeline
        }
        $request = ($capture.Requests[0].Content | ConvertFrom-Json).properties
        $request.PSObject.Properties.Name | Should -Not -Contain "enableCrossTenantTransfer"
        $request.PSObject.Properties.Name | Should -Not -Contain "allowedStorageAccounts"
    }
}

Describe 'New-AzStorageMoverAzSmbFileShareEndpoint PythonParity' -Tag 'PythonParity' {
    It 'CreateGetAndDeleteSourceEndpointInEastUs' {
        $context = $null
        try {
            $context = New-StorageMoverTestContext -Name 'sm-smb-file-share-source'
            $accountId = "/subscriptions/$($context.SubscriptionId)/resourceGroups/$($context.ResourceGroupName)/providers/Microsoft.Storage/storageAccounts/testaccount"
            $endpoint = New-AzStorageMoverAzSmbFileShareEndpoint @context -Name 'source' -StorageAccountResourceId $accountId -FileShareName 'testshare' -EndpointKind Source
            $endpoint.Property.EndpointType | Should -Be 'AzureStorageSmbFileShare'
            $endpoint.Property.EndpointKind | Should -Be 'Source'
            $endpoint = Get-AzStorageMoverEndpoint @context -Name 'source'
            $endpoint.Property.EndpointKind | Should -Be 'Source'
            $endpoint.Property.StorageAccountResourceId | Should -Be $accountId
            Remove-AzStorageMoverEndpoint @context -Name 'source'
            Invoke-StorageMoverTestFailure -Code ResourceNotFound -Command {
                Get-AzStorageMoverEndpoint @context -Name 'source' -ErrorAction Stop
            }
        } finally {
            Remove-StorageMoverTestContext -Context $context
        }
    }
}
