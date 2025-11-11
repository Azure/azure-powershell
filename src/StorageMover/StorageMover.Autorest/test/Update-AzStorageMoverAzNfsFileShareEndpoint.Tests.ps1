if(($null -eq $TestName) -or ($TestName -contains 'Update-AzStorageMoverAzNfsFileShareEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStorageMoverAzNfsFileShareEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzStorageMoverAzNfsFileShareEndpoint' {
    It 'UpdateExpanded' {
        $endpointName = "testNfsFileShareEndpoint" + $env.RandomString
        $description = "Nfs fs endpoint description"
        $updateDescription = "update Nfs fs endpoint Description"
        $endpoint = New-AzStorageMoverAzNfsFileShareEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -StorageAccountResourceId $env.StoraccId -FileShareName "testfs" -Description $description
        $nfsEndpoint = Update-AzStorageMoverAzNfsFileShareEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Description $updateDescription    
        $nfsEndpoint.Name | Should -Be $endpointName
        $nfsEndpoint.Property.Description | Should -Be $updateDescription 

        $nfsEndpoint = Get-AzStorageMoverEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName
        $nfsEndpoint.Name | Should -Be $endpointName
        $nfsEndpoint.Property.Description | Should -Be $updateDescription 
    }

}
