if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzMonitorHealthModelSignalDefinition'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzMonitorHealthModelSignalDefinition.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzMonitorHealthModelSignalDefinition' {
    It 'Delete' {
        {
            $degraded = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 70
            $unhealthy = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 90
            $rules = New-AzMonitorHealthModelEvaluationRuleObject -DegradedRule $degraded -UnhealthyRule $unhealthy
            $property = New-AzMonitorHealthModelResourceMetricSignalDefinitionPropertiesObject -MetricNamespace 'Microsoft.Compute/virtualMachines' -MetricName 'Percentage CPU' -TimeGrain PT5M -AggregationType Average -EvaluationRule $rules -DisplayName 'Delete signal' -DataUnit Percent
            New-AzMonitorHealthModelSignalDefinition -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.SignalDefinitionDeleteName -Property $property | Out-Null
            $deleted = Remove-AzMonitorHealthModelSignalDefinition -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.SignalDefinitionDeleteName -PassThru
            $deleted | Should -BeTrue
            { Get-AzMonitorHealthModelSignalDefinition -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -Name $env.SignalDefinitionDeleteName -ErrorAction Stop } | Should -Throw
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentityHealthmodel' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}
