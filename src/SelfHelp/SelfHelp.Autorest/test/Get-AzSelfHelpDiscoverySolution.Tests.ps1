if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSelfHelpDiscoverySolution'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSelfHelpDiscoverySolution.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSelfHelpDiscoverySolution' {
    It 'List' {
        { 
             Get-AzSelfHelpDiscoverySolution -Scope $env.scope -Filter "ProblemClassificationId eq 'a5db90c3-f147-bce6-83b0-ab5e0aeca1f0'"
             } | Should -Not -Throw
    }
}
