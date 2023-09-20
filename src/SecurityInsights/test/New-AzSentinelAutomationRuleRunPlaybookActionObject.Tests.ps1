if(($null -eq $TestName) -or ($TestName -contains 'New-AzSentinelAutomationRuleRunPlaybookActionObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSentinelAutomationRuleRunPlaybookActionObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSentinelAutomationRuleRunPlaybookActionObject' {
    It '__AllParameterSets' -skip {
        {
            New-AzSentinelAutomationRuleRunPlaybookActionObject -Order 1 -ActionConfigurationLogicAppResourceId $env.AlertLogicAppResourceId -ActionConfigurationTenantId $env.Tenant
        } | Should -Not -Throw
    }
}
