if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzSentinelAlertRuleAction'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSentinelAlertRuleAction.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzSentinelAlertRuleAction' {
    It 'Delete' {
        { Remove-AzSentinelAlertRuleAction -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -RuleId $env.RemoveAlertRuleActionRuleId -Id $env.RemoveAlertRuleActionId} | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        $alertRuleAction =  Get-AzSentinelAlertRuleAction -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.workspaceName `
            -RuleId $env.RemoveViaIdAlertRuleActionRuleId -Id $env.RemoveViaIdAlertRuleActionId
        { Remove-AzSentinelAlertRuleAction -InputObject $alertRuleAction } | Should -Not -Throw
    }
}
