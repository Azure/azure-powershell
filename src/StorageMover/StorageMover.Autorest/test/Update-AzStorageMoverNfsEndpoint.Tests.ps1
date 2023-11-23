if(($null -eq $TestName) -or ($TestName -contains 'Update-AzStorageMoverNfsEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStorageMoverNfsEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzStorageMoverNfsEndpoint' {
    It 'UpdateExpanded' {
        $endpointName = "testNfsEndpoint2" + $env.RandomString
        $description = "Nfs endpoint description"
        $updateDescription = "update Nfs endpoint Description"
        $nfsVersion = "NFSv3"
        $endpointHost = "10.0.0.1"
        $export = "/"
        $nfsEndpoint = New-AzStorageMoverNfsEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Host $endpointHost -Export $export -NfsVersion $nfsVersion -Description $description 
        $nfsEndpoint = Update-AzStorageMoverNfsEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Description $updateDescription    
        $nfsEndpoint.Name | Should -Be $endpointName
        $nfsEndpoint.Property.Description | Should -Be $updateDescription 

        $nfsEndpoint = Get-AzStorageMoverEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName
        $nfsEndpoint.Name | Should -Be $endpointName
        $nfsEndpoint.Property.Description | Should -Be $updateDescription 
    }
}
