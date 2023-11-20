if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAdvisorConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAdvisorConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAdvisorConfiguration' {
    It 'List' {
        $config = Get-AzAdvisorConfiguration
        $config.Count | Should -BeGreaterOrEqual 1
    }

    It 'List1' {
        $config = Get-AzAdvisorConfiguration -resourceGroup $env.resourceGroup
        $config.Count | Should -BeGreaterOrEqual 1
    }
}
