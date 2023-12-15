if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSentinelAlertRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSentinelAlertRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSentinelAlertRule' -Tag 'LiveOnly' {
    It 'UpdateExpanded' {
        $alertRule = Update-AzSentinelAlertRule -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -RuleId $env.UpdateAlertRuleId -Scheduled -Disabled
        $alertRule.Enabled | Should -Be $false
    }

    It 'UpdateViaIdentityExpanded' -skip {
        $alertRule = Get-AzSentinelAlertRule -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -RuleId $env.UpdateViaIdAlertRuleId
        $alertRuleUpdate = Update-AzSentinelAlertRule -InputObject $alertRule -Disabled
        $alertRuleUpdate.Enabled | Should -Be $true
    }
}
