if(($null -eq $TestName) -or ($TestName -contains 'Get-AzOracleAutonomousDatabaseNationalCharacterSet'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzOracleAutonomousDatabaseNationalCharacterSet.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzOracleAutonomousDatabaseNationalCharacterSet' {
    It 'List' {
        {
            $adbsNCharacterSetList = Get-AzOracleAutonomousDatabaseNationalCharacterSet -Location $env.location
            $adbsNCharacterSetList.CharacterSet.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
