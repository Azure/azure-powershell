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
}
