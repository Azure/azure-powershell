if(($null -eq $TestName) -or ($TestName -contains 'New-AzSentinelAlertRuleAction'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSentinelAlertRuleAction.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSentinelAlertRuleAction' {
    It 'CreateExpanded' {
        Get-AzSentinelAlertRule -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -RuleId $env.GetUpdateAlertRuleID
        $alertRuleAction = New-AzSentinelAlertRuleAction -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.workspaceName`
            -Id $env.NewAlertRuleActionId -RuleId $env.GetUpdateAlertRuleID  -LogicAppResourceId $env.IncidentLogicAppResourceId `
            -TriggerUri $env.IncidentLogicAppTriggerUri
        $alertRuleAction.LogicAppResourceId | Should -Be $env.IncidentLogicAppResourceId
    }
}
