if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSentinelAlertRuleAction'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSentinelAlertRuleAction.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSentinelAlertRuleAction' {
    It 'List' {
        $alertRuleActions = Get-AzSentinelAlertRuleAction -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -RuleId $env.GetAlertRuleActionRuleId
        $alertRuleActions.Count | Should -BeGreaterorEqual 1
    }

    It 'Get' {
        $alertRuleAction = Get-AzSentinelAlertRuleAction -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -RuleId $env.GetAlertRuleActionRuleId -Id $env.GetAlertRuleActionId
        $alertRuleAction.LogicAppResourceId | Should -Be $env.Playbook1LogicAppResourceId
    }

    It 'GetViaIdentity' {
        $alertRuleAction = Get-AzSentinelAlertRuleAction -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -RuleId $env.GetAlertRuleActionRuleId -Id $env.GetAlertRuleActionId
        $alertRuleActionviaId = Get-AzSentinelAlertRuleAction -InputObject $alertRuleAction
        $alertRuleActionviaId.LogicAppResourceId | Should -Be $env.Playbook1LogicAppResourceId
    }
}
