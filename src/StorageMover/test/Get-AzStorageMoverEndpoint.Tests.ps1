if(($null -eq $TestName) -or ($TestName -contains 'Get-AzStorageMoverEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStorageMoverEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzStorageMoverEndpoint' {
    It 'List' {
        $endpointList = Get-AzStorageMoverEndpoint -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent
        $endpointList.Count | Should -BeGreaterOrEqual 1 
    }

    It 'Get' {
        $containerEndpoint = Get-AzStorageMoverEndpoint -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent -Name $env.ContainerEndpointName
        $containerEndpoint.Property.endpointType | Should -Be "AzureStorageBlobContainer"
        $containerEndpoint.Property.blobContainerName | Should -Be $env.ContainerName
        
        $nfsEndpoint = Get-AzStorageMoverEndpoint -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.StorageMoverNameWithAgent -Name $env.NfsEndpointName
        $nfsEndpoint.Property.endpointType | Should -Be "NfsMount"
        $nfsEndpoint.Property.host | Should -Be "10.0.0.1"
        $nfsEndpoint.Property.export | Should -Be "/"
    }
}
