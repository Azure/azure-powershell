if(($null -eq $TestName) -or ($TestName -contains 'New-AzSentinelAlertRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSentinelAlertRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSentinelAlertRule' {
    It 'Scheduled'  {
        $alertRule = New-AzSentinelAlertRule -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Kind Scheduled -RuleId $env.NewAlertRuleId -Query 'SecurityEvent' -DisplayName $env.NewAlertRuleName -Severity Low `
            -QueryFrequency (New-TimeSpan -Hours 1) -QueryPeriod (New-TimeSpan -Days 1) -TriggerOperator "GreaterThan" -TriggerThreshold 10
        $alertRule.DisplayName | Should -Be $env.NewAlertRuleName
    }
} 
