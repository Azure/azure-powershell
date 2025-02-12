if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSecurityDefenderForStorage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSecurityDefenderForStorage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSecurityDefenderForStorage' {
    It 'Get' {
        {
            $defenderForStorageSettings = Get-AzSecurityDefenderForStorage -ResourceId $env.ResourceId0
            $defenderForStorageSettings.IsEnabled | Should -Be 'False'
            $defenderForStorageSettings.Type | Should -Be 'Microsoft.Security/defenderForStorageSettings'
        } | Should -Not -Throw
    }
}
