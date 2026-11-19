if(($null -eq $TestName) -or ($TestName -contains 'New-AzStorageMoverAzNfsFileShareEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageMoverAzNfsFileShareEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStorageMoverAzNfsFileShareEndpoint' {
    It 'CreateExpanded' {
        $endpointName = "testNfsFileShareEndpoint" + $env.RandomString
        $description = "NFS endpoint description"
        $endpoint = New-AzStorageMoverAzNfsFileShareEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -StorageAccountResourceId $env.StoraccId -FileShareName "testfs" -Description $description
        $endpoint.Name | Should -Be $endpointName
        $endpoint.Property.endpointType | Should -Be "AzureStorageNfsFileShare"
        $endpoint.Property.FileShareName | Should -Be "testfs"
        $endpoint.Property.StorageAccountResourceId | Should -Be $env.StoraccId

        $endpoint = Get-AzStorageMoverEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName
        $endpoint.Name | Should -Be $endpointName
        $endpoint.Property.endpointType | Should -Be "AzureStorageNfsFileShare"
        $endpoint.Property.FileShareName | Should -Be "testfs"
        $endpoint.Property.StorageAccountResourceId | Should -Be $env.StoraccId
    }

}

Describe 'New-AzStorageMoverAzNfsFileShareEndpoint RequestContract' -Tag @('PythonParity', 'Offline') {
    It 'CreateExpandedWithEndpointKindRequest' {
        $capture = Invoke-StorageMoverTestRequest -Response @{ properties = @{ endpointType = 'AzureStorageNfsFileShare' } } -Command {
            param($pipeline)
            New-AzStorageMoverAzNfsFileShareEndpoint -Name 'nfssharekind' -SubscriptionId $env.SubscriptionId -ResourceGroupName 'rg' -StorageMoverName 'mover' -StorageAccountResourceId $env.EndpointStorageAccountId -FileShareName 'testfs' -EndpointKind Target -HttpPipelinePrepend $pipeline
        }
        ($capture.Requests[0].Content | ConvertFrom-Json).properties.endpointKind | Should -Be 'Target'
    }
}

Describe 'New-AzStorageMoverAzNfsFileShareEndpoint PythonParity' -Tag 'PythonParity' {
    It 'CreateGetDeleteTargetAndRejectSource' {
        $context = $null
        try {
            $context = New-StorageMoverTestContext -Name 'sm-nfs-file-share'
            $accountId = "/subscriptions/$($context.SubscriptionId)/resourceGroups/$($context.ResourceGroupName)/providers/Microsoft.Storage/storageAccounts/testaccount"
            $endpoint = New-AzStorageMoverAzNfsFileShareEndpoint @context -Name 'target' -StorageAccountResourceId $accountId -FileShareName 'testshare' -EndpointKind Target -Description 'NFS file share target'
            $endpoint.Property.EndpointKind | Should -Be 'Target'
            $endpoint = Get-AzStorageMoverEndpoint @context -Name 'target'
            $endpoint.Property.FileShareName | Should -Be 'testshare'
            $endpoint.Property.Description | Should -Be 'NFS file share target'
            Remove-AzStorageMoverEndpoint @context -Name 'target'
            Invoke-StorageMoverTestFailure -Code ResourceNotFound -Command { Get-AzStorageMoverEndpoint @context -Name 'target' -ErrorAction Stop }
            Invoke-StorageMoverTestFailure -Command {
                New-AzStorageMoverAzNfsFileShareEndpoint @context -Name 'invalid' -StorageAccountResourceId $accountId -FileShareName 'testshare' -EndpointKind Source -ErrorAction Stop
            }
        } finally {
            Remove-StorageMoverTestContext -Context $context
        }
    }
}
