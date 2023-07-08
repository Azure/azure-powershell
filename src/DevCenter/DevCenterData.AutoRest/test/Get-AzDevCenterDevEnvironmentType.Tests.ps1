if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterDevEnvironmentType'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterDevEnvironmentType.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterDevEnvironmentType' {
    It 'List' -skip {
        $listOfEnvTypes = Get-AzDevCenterDevEnvironmentType -Endpoint $env.endpoint -ProjectName $env.projectName
        $listOfEnvTypes.Count | Should -Be 1

        $listOfEnvTypes = Get-AzDevCenterDevEnvironmentType -DevCenter $env.devCenterName -ProjectName $env.projectName
        $listOfEnvTypes.Count | Should -Be 1
    
    }
}
