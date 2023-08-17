if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzStorageMoverEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzStorageMoverEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzStorageMoverEndpoint' {
    It 'Delete' {
        $endpointName = "containerEndpoint2" + $env.RandomString
        $endpoint = New-AzStorageMoverAzStorageContainerEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -BlobContainerName $env.ContainerName -StorageMoverName $env.InitialStoMoverName -StorageAccountResourceId $env.StoraccId

        Remove-AzStorageMoverEndpoint -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent -Name $endpointName 
        $endpointList = Get-AzStorageMoverEndpoint -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent
        $endpointList.Name | Should -Not -Contain $endpointName
    }
}
