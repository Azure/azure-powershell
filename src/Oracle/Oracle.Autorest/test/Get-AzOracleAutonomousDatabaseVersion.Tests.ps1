if(($null -eq $TestName) -or ($TestName -contains 'Get-AzOracleAutonomousDatabaseVersion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzOracleAutonomousDatabaseVersion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzOracleAutonomousDatabaseVersion' {
    It 'List' {
        {
            $adbsVersionList = Get-AzOracleAutonomousDatabaseVersion -Location $env.location
            $adbsVersionList.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
