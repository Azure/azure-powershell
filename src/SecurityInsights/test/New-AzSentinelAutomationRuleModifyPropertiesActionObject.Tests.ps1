if(($null -eq $TestName) -or ($TestName -contains 'New-AzSentinelAutomationRuleModifyPropertiesActionObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSentinelAutomationRuleModifyPropertiesActionObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSentinelAutomationRuleModifyPropertiesActionObject' {
    It '__AllParameterSets' -skip {
        {
            New-AzSentinelAutomationRuleModifyPropertiesActionObject -Order 1 -ActionConfigurationSeverity High
        } | Should -Not -Throw
    }
}
