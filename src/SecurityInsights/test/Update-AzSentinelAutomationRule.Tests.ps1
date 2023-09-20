if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSentinelAutomationRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSentinelAutomationRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSentinelAutomationRule' {
    It 'UpdateExpanded' {
        $getRule = Get-AzSentinelAutomationRule -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $env.GetAutomationRuleId
        $automationRuleAction = New-AzSentinelAutomationRuleRunPlaybookActionObject -Order 2 -ActionConfigurationLogicAppResourceId $env.UpdateLogicAppResourceId -ActionConfigurationTenantId $env.Tenant
        $automationRuleActionList = $getRule.Action + $automationRuleAction
        $automationRule = Update-AzSentinelAutomationRule -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $env.UpdateAutomationRuleId -Action $automationRuleActionList -DisplayName $getRule.DisplayName -Order $getRule.Order -TriggeringLogicIsEnabled
        $automationRule.Action.ActionConfigurationLogicAppResourceId | Should -Be $env.Playbook4LogicAppResourceId
    }

    It 'UpdateViaIdentityExpanded' {
        $getRule = Get-AzSentinelAutomationRule -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $env.GetAutomationRuleId
        $automationRuleAction = New-AzSentinelAutomationRuleRunPlaybookActionObject -Order 3 -ActionConfigurationLogicAppResourceId $env.UpdateLogicAppResourceId -ActionConfigurationTenantId $env.Tenant
        $automationRuleActionList = $getRule.Action + $automationRuleAction
        $automationRuleUpdate = Update-AzSentinelAutomationRule -InputObject $getRule -Action $automationRuleActionList -DisplayName $getRule.DisplayName -Order $getRule.Order -TriggeringLogicIsEnabled
        $automationRuleUpdate.Action.ActionConfigurationLogicAppResourceId | Should -Be $env.Playbook4LogicAppResourceId
    }
}
