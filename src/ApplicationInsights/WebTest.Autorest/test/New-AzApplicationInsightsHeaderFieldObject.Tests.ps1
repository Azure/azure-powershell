if(($null -eq $TestName) -or ($TestName -contains 'New-AzApplicationInsightsHeaderFieldObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzApplicationInsightsHeaderFieldObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzApplicationInsightsHeaderFieldObject' {
    It '__AllParameterSets' {
        { New-AzApplicationInsightsHeaderFieldObject -Name 'version' -Value '2.0.1' } | Should -Not -Throw
    }
}
