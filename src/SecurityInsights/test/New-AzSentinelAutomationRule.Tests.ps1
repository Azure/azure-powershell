if(($null -eq $TestName) -or ($TestName -contains 'New-AzSentinelAutomationRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSentinelAutomationRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSentinelAutomationRule' {
    It 'CreateExpanded' {
        $automationRuleAction = New-AzSentinelAutomationRuleRunPlaybookActionObject -Order 1 -ActionConfigurationLogicAppResourceId $env.AlertLogicAppResourceId -ActionConfigurationTenantId $env.Tenant
        $automationRule = New-AzSentinelAutomationRule -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Id $env.NewAutomationRuleId -Action $automationRuleAction -DisplayName "Run Playbook to create alerts" -Order 2 `
            -TriggeringLogicIsEnabled -TriggeringLogicTriggersOn Alerts -TriggeringLogicTriggersWhen Created
        $automationRule.DisplayName | Should -Be $env.NewAutomationRule
    }
}
