if(($null -eq $TestName) -or ($TestName -contains 'Update-AzMonitorHealthModelSignalDefinition'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzMonitorHealthModelSignalDefinition.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzMonitorHealthModelSignalDefinition' {
    It 'UpdateExpanded' {
        {
            $degraded = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 75
            $unhealthy = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 95
            $rules = New-AzMonitorHealthModelEvaluationRuleObject -DegradedRule $degraded -UnhealthyRule $unhealthy
            $property = New-AzMonitorHealthModelResourceMetricSignalDefinitionPropertiesObject -MetricNamespace 'Microsoft.Compute/virtualMachines' -MetricName 'Percentage CPU' -TimeGrain PT5M -AggregationType Average -EvaluationRule $rules -DisplayName 'Updated signal definition' -DataUnit Percent
            $result = Update-AzMonitorHealthModelSignalDefinition -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.SignalDefinitionName -Property $property
            $result | Should -Not -BeNullOrEmpty
            $result.Name | Should -Be $env.SignalDefinitionName
            ($result | ConvertTo-Json -Depth 20) | Should -Match 'Updated signal definition'
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityHealthmodelExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}
