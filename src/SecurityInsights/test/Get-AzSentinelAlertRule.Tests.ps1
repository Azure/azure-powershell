if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSentinelAlertRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSentinelAlertRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSentinelAlertRule' {
    It 'List' {
        $alertRules = Get-AzSentinelAlertRule -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName
        $alertRules.Count | Should -BeGreaterorEqual 1
    }

    It 'Get' {
        $alertRule = Get-AzSentinelAlertRule -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -RuleId $env.GetUpdateAlertRuleID
        $alertRule.Name | Should -Be $env.GetUpdateAlertRuleID
    }

    It 'GetViaIdentity' {
        $alertRule = Get-AzSentinelAlertRule -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -RuleId $env.GetUpdateAlertRuleID
        $alertRuleViaId = Get-AzSentinelAlertRule -InputObject $alertRule
        $alertRuleViaId.Name | Should -Be $env.GetUpdateAlertRuleID
    }

    It 'GetViaIdentityWorkspace' {
        $workspace = Get-AzOperationalInsightsWorkspace -Name $workspaceName
        $alertRuleViaWSId = Get-AzSentinelAlertRule -WorkspaceInputObject $workspace -RuleId $env.GetUpdateAlertRuleID
        $alertRuleViaWSId.Name | Should -Be $env.GetUpdateAlertRuleID
    }
}
