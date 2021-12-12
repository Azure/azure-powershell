if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSentinelAlertRuleAction'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSentinelAlertRuleAction.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSentinelAlertRuleAction' {
    It 'UpdateExpanded' {
        $alertRuleAction = Update-AzSentinelAlertRuleAction -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.workspaceName `
            -RuleId $env.UpdateAlertRuleActionRuleId -Id $env.UpdateAlertRuleActionId -LogicAppResourceId $env.Playbook3LogicAppResourceId -TriggerUri $env.Playbook3TriggerUrl
        $alertRuleAction.LogicAppResourceId | Should -Be $env.Playbook3LogicAppResourceId
    }

    It 'UpdateViaIdentityExpanded' {
        $alertRuleAction = Get-AzSentinelAlertRuleAction -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.workspaceName `
            -RuleId $env.UpdateViaIdAlertRuleActionRuleId -Id $env.UpdateViaIdAlertRuleActionId
        $alertRuleAction = Update-AzSentinelAlertRuleAction -InputObject $alertRuleAction -LogicAppResourceId $env.Playbook3LogicAppResourceId -TriggerUri $env.Playbook3TriggerUrl
        $alertRuleAction.LogicAppResourceId | Should -Be $env.Playbook3LogicAppResourceId
    }
}
