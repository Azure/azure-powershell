if(($null -eq $TestName) -or ($TestName -contains 'New-AzMonitorHealthModelSignalDefinition'))
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
            $degraded.Operator | Should -Be 'GreaterThan'
            $degraded.Threshold | Should -Be 70
            $unhealthy.Operator | Should -Be 'GreaterThan'
            $unhealthy.Threshold | Should -Be 90
            $rules.DegradedRule.Threshold | Should -Be 70
            $rules.UnhealthyRule.Threshold | Should -Be 90
            $property = New-AzMonitorHealthModelResourceMetricSignalDefinitionPropertiesObject -MetricNamespace 'Microsoft.Compute/virtualMachines' -MetricName 'Percentage CPU' -TimeGrain PT5M -AggregationType Average -EvaluationRule $rules -DisplayName 'Create signal' -DataUnit Percent -RefreshInterval PT5M
            $property.MetricNamespace | Should -Be 'Microsoft.Compute/virtualMachines'
            $property.MetricName | Should -Be 'Percentage CPU'
            $property.TimeGrain | Should -Be 'PT5M'
            $property.AggregationType | Should -Be 'Average'
            $property.DisplayName | Should -Be 'Create signal'
            $property.DataUnit | Should -Be 'Percent'
            $property.RefreshInterval | Should -Be 'PT5M'
            $property.SignalKind | Should -Be 'AzureResourceMetric'
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

    $localQuerySignalCases = @(
        @{ Kind = 'LogAnalyticsQuery'; QueryText = 'AppExceptions | summarize Count = count()'; TimeGrain = 'PT15M'; Threshold = 10; ValueColumnName = 'Count'; DisplayName = 'Log signal' }
        @{ Kind = 'PrometheusMetricsQuery'; QueryText = 'rate(http_requests_failed_total[5m])'; TimeGrain = 'PT5M'; Threshold = 0.05; ValueColumnName = $null; DisplayName = $null }
    )

    It 'Local <Kind> query signal' -TestCases $localQuerySignalCases {
        param($Kind, $QueryText, $TimeGrain, $Threshold, $ValueColumnName, $DisplayName)
        $unhealthy = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold $Threshold
        $rule = New-AzMonitorHealthModelEvaluationRuleObject -UnhealthyRule $unhealthy
        if ($Kind -eq 'LogAnalyticsQuery') {
            $property = New-AzMonitorHealthModelLogAnalyticsQuerySignalDefinitionPropertiesObject -QueryText $QueryText -ValueColumnName $ValueColumnName -TimeGrain $TimeGrain -EvaluationRule $rule -DisplayName $DisplayName
            $property.ValueColumnName | Should -Be $ValueColumnName
        } else {
            $property = New-AzMonitorHealthModelPrometheusMetricsSignalDefinitionPropertiesObject -QueryText $QueryText -TimeGrain $TimeGrain -EvaluationRule $rule
        }

        $property.QueryText | Should -Be $QueryText
        $property.TimeGrain | Should -Be $TimeGrain
        $property.SignalKind | Should -Be $Kind
        $property.EvaluationRule.UnhealthyRule.Threshold | Should -Be $Threshold

        $serialized = $property.ToJsonString() | ConvertFrom-Json
        $serialized.evaluationRules.PSObject.Properties.Name | Should -Not -Contain 'degradedRule'
        if ($null -ne $DisplayName) {
            $property.DisplayName | Should -Be $DisplayName
        } else {
            $serialized.PSObject.Properties.Name | Should -Not -Contain 'displayName'
        }
    }

}
