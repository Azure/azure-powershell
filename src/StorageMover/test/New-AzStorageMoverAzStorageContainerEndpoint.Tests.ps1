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
}
