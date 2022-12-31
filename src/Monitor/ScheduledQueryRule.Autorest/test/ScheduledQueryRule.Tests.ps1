if(($null -eq $TestName) -or ($TestName -contains 'ScheduledQueryRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'ScheduledQueryRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'ScheduledQueryRule' {
    It 'CRUD' {
        $dimension = New-AzScheduledQueryRuleDimensionObject -Name Computer -Operator Include -Value *
        $condition=New-AzScheduledQueryRuleConditionObject -Dimension $dimension -Query "Perf | where ObjectName == `"Processor`" and CounterName == `"% Processor Time`" | summarize AggregatedValue = avg(CounterValue) by bin(TimeGenerated, 5m), Computer" -TimeAggregation "Average" -MetricMeasureColumn "AggregatedValue" -Operator "GreaterThan" -Threshold "70" -FailingPeriodNumberOfEvaluationPeriod 1 -FailingPeriodMinFailingPeriodsToAlert 1
        New-AzScheduledQueryRule -Name $env.scheduledQueryRuleName -ResourceGroupName $env.resourceGroupName -Location eastus -DisplayName test-rule -Scope $env.vmId -Severity 4 -WindowSize ([System.TimeSpan]::New(0,10,0)) -EvaluationFrequency ([System.TimeSpan]::New(0,5,0)) -CriterionAllOf $condition

        $rule = Get-AzScheduledQueryRule -Name $env.scheduledQueryRuleName -ResourceGroupName $env.resourceGroupName
        Remove-AzScheduledQueryRule -Name $env.scheduledQueryRuleName -ResourceGroupName $env.resourceGroupName
    }
}