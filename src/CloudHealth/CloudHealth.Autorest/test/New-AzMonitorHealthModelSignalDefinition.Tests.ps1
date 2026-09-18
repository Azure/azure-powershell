if(($null -eq $TestName) -or `
   ($TestName -contains 'New-AzMonitorHealthModelSignalDefinition') -or `
   ($TestName -contains 'New-AzMonitorHealthModelThresholdRuleV2Object') -or `
   ($TestName -contains 'New-AzMonitorHealthModelEvaluationRuleObject') -or `
   ($TestName -contains 'New-AzMonitorHealthModelResourceMetricSignalDefinitionPropertiesObject') -or `
   ($TestName -contains 'New-AzMonitorHealthModelLogAnalyticsQuerySignalDefinitionPropertiesObject') -or `
   ($TestName -contains 'New-AzMonitorHealthModelPrometheusMetricsSignalDefinitionPropertiesObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMonitorHealthModelSignalDefinition.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMonitorHealthModelSignalDefinition' {
    It 'CreateExpanded' {
        {
            $degraded = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 70
            $unhealthy = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 90
            $rules = New-AzMonitorHealthModelEvaluationRuleObject -DegradedRule $degraded -UnhealthyRule $unhealthy
            $property = New-AzMonitorHealthModelResourceMetricSignalDefinitionPropertiesObject -MetricNamespace 'Microsoft.Compute/virtualMachines' -MetricName 'Percentage CPU' -TimeGrain PT5M -AggregationType Average -EvaluationRule $rules -DisplayName 'Create signal' -DataUnit Percent -RefreshInterval PT5M
            $result = New-AzMonitorHealthModelSignalDefinition -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.SignalDefinitionCreateName -Property $property
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.SignalDefinitionCreateName
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}

Describe 'New-AzMonitorHealthModelThresholdRuleV2Object' {
    It '__AllParameterSets' {
        $rule = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 90
        $rule.Operator | Should -Be 'GreaterThan'
        $rule.Threshold | Should -Be 90
    }

}

Describe 'New-AzMonitorHealthModelEvaluationRuleObject' {
    It '__AllParameterSets' {
        $degraded = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 70
        $unhealthy = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 90
        $rule = New-AzMonitorHealthModelEvaluationRuleObject -DegradedRule $degraded -UnhealthyRule $unhealthy
        $rule.UnhealthyRule.Threshold | Should -Be 90
        $rule.DegradedRule.Threshold | Should -Be 70
    }

}

Describe 'New-AzMonitorHealthModelResourceMetricSignalDefinitionPropertiesObject' {
    It '__AllParameterSets' {
        $unhealthy = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 90
        $rule = New-AzMonitorHealthModelEvaluationRuleObject -UnhealthyRule $unhealthy
        $property = New-AzMonitorHealthModelResourceMetricSignalDefinitionPropertiesObject -MetricNamespace 'Microsoft.Compute/virtualMachines' -MetricName 'Percentage CPU' -TimeGrain PT5M -AggregationType Average -EvaluationRule $rule -DisplayName 'CPU signal'
        $property.MetricNamespace | Should -Be 'Microsoft.Compute/virtualMachines'
        $property.MetricName | Should -Be 'Percentage CPU'
        $property.AggregationType | Should -Be 'Average'
    }

}

Describe 'New-AzMonitorHealthModelLogAnalyticsQuerySignalDefinitionPropertiesObject' {
    It '__AllParameterSets' {
        $unhealthy = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 10
        $rule = New-AzMonitorHealthModelEvaluationRuleObject -UnhealthyRule $unhealthy
        $property = New-AzMonitorHealthModelLogAnalyticsQuerySignalDefinitionPropertiesObject -QueryText 'AppExceptions | summarize Count = count()' -ValueColumnName Count -TimeGrain PT15M -EvaluationRule $rule -DisplayName 'Log signal'
        $property.QueryText | Should -Be 'AppExceptions | summarize Count = count()'
        $property.ValueColumnName | Should -Be 'Count'
    }

}

Describe 'New-AzMonitorHealthModelPrometheusMetricsSignalDefinitionPropertiesObject' {
    It '__AllParameterSets' {
        $unhealthy = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 0.05
        $rule = New-AzMonitorHealthModelEvaluationRuleObject -UnhealthyRule $unhealthy
        $property = New-AzMonitorHealthModelPrometheusMetricsSignalDefinitionPropertiesObject -QueryText 'rate(http_requests_failed_total[5m])' -TimeGrain PT5M -EvaluationRule $rule -DisplayName 'Prom signal'
        $property.QueryText | Should -Be 'rate(http_requests_failed_total[5m])'
        $property.DisplayName | Should -Be 'Prom signal'
    }

}
