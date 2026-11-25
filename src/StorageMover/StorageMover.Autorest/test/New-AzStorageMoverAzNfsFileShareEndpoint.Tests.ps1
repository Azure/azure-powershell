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

    It 'CreateExpandedWithEndpointKindRequest' {
        Mock -CommandName New-AzStorageMoverEndpoint -ModuleName Az.StorageMover.custom -MockWith { [pscustomobject]@{ Property = $Property } }
        $endpoint = New-AzStorageMoverAzNfsFileShareEndpoint -Name "nfssharekind" -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.EndpointStoMoverName -StorageAccountResourceId $env.EndpointStorageAccountId -FileShareName "testfs" -EndpointKind Target
        ($endpoint.Property.ToJsonString() | ConvertFrom-Json).endpointKind | Should -Be "Target"
    }
}
