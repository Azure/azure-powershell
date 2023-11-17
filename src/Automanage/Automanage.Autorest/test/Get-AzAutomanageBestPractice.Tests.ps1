if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAutomanageBestPractice'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAutomanageBestPractice.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAutomanageBestPractice' {
    It 'List' {
        { Get-AzAutomanageBestPractice } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzAutomanageBestPractice -Name AzureBestPracticesProduction } | Should -Not -Throw
    }
}
