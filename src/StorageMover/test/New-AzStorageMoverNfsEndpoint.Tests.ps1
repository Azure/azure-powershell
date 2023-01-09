if(($null -eq $TestName) -or ($TestName -contains 'New-AzStorageMoverNfsEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageMoverNfsEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStorageMoverNfsEndpoint' {
    It 'CreateExpanded' {
        $endpointName = "testNfsEndpoint" + $env.RandomString
        $description = "Nfs endpoint description"
        $nfsVersion = "NFSv3"
        $endpointHost = "10.0.0.1"
        $export = "/"
        $nfsEndpoint = New-AzStorageMoverNfsEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName -Host $endpointHost -Export $export -NfsVersion $nfsVersion -Description $description 
        $nfsEndpoint.Name | Should -Be $endpointName
        $nfsEndpoint.Property.endpointType | Should -Be "NfsMount"
        $nfsEndpoint.Property.host | Should -Be $endpointHost 
        $nfsEndpoint.Property.export | Should -Be $export

        $nfsEndpoint = Get-AzStorageMoverEndpoint -Name $endpointName -ResourceGroupName $env.ResourceGroupName -StorageMoverName $env.InitialStoMoverName
        $nfsEndpoint.Name | Should -Be $endpointName
        $nfsEndpoint.Property.endpointType | Should -Be "NfsMount"
        $nfsEndpoint.Property.host | Should -Be $endpointHost 
        $nfsEndpoint.Property.export | Should -Be $export
    }
}
