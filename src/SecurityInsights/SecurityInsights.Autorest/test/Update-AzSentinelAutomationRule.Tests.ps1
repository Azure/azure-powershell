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
        $automationRuleAction = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.AutomationRuleRunPlaybookAction]::new()
        $automationRuleAction.Order = 1
        $automationRuleAction.ActionType = "RunPlaybook"
        $automationRuleAction.ActionConfigurationLogicAppResourceId = $env.Playbook4LogicAppResourceId
        $automationRuleAction.ActionConfigurationTenantId = $env.Tenant
        $getRule = Get-AzSentinelAutomationRule -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $env.UpdateAutomationRuleId
        $automationRule = Update-AzSentinelAutomationRule -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $env.UpdateAutomationRuleId -Action $automationRuleAction -DisplayName $getRule.DisplayName -Order $getRule.Order -TriggeringLogicIsEnabled
        $automationRule.Action.ActionConfigurationLogicAppResourceId | Should -Be $env.Playbook4LogicAppResourceId
    }

    It 'UpdateViaIdentityExpanded' {
        $automationRuleAction = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.AutomationRuleRunPlaybookAction]::new()
        $automationRuleAction.Order = 1
        $automationRuleAction.ActionType = "RunPlaybook"
        $automationRuleAction.ActionConfigurationLogicAppResourceId = $env.Playbook4LogicAppResourceId
        $automationRuleAction.ActionConfigurationTenantId = $env.Tenant
        $getRule = Get-AzSentinelAutomationRule -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $env.UpdateAutomationRuleId
        $automationRuleUpdate = Update-AzSentinelAutomationRule -InputObject $getRule -Action $automationRuleAction -DisplayName $getRule.DisplayName -Order $getRule.Order -TriggeringLogicIsEnabled
        $automationRuleUpdate.Action.ActionConfigurationLogicAppResourceId | Should -Be $env.Playbook4LogicAppResourceId
    }
}
