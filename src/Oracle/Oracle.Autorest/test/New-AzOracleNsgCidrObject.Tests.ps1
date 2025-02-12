if(($null -eq $TestName) -or ($TestName -contains 'New-AzOracleNsgCidrObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzOracleNsgCidrObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzOracleNsgCidrObject' {
    It '__AllParameterSets' {
        {
            New-AzOracleNsgCidrObject -Source "source" -DestinationPortRangeMax 0 -DestinationPortRangeMin 1
        } | Should -Not -Throw
    }
}
