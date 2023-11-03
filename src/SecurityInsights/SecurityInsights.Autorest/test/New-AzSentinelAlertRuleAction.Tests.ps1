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
        $alertRule = New-AzSentinelAlertRule -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Kind Scheduled -RuleId $env.NewalertRuleActionRuleId -Query "SecurityEvent | take 1" -DisplayName $env.NewalertRuleActionRuleName -Severity Informational `
            -QueryFrequency (New-TimeSpan -Hours 1) -QueryPeriod (New-TimeSpan -Days 1) -TriggerOperator "GreaterThan" -TriggerThreshold 1
        $alertRuleAction =  New-AzSentinelAlertRuleAction -ResourceGroupName $env.ResourceGroupName `
            -Id $env.NewAlertRuleActionId -RuleId $env.NewalertRuleActionRuleId -WorkspaceName $env.workspaceName -LogicAppResourceId $env.Playbook1LogicAppResourceId `
            -TriggerUri $env.Playbook1TriggerUrl
        $alertRuleAction.LogicAppResourceId | Should -Be $env.Playbook1LogicAppResourceId
    }
}
