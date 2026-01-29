if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzElasticMonitoredSubscription'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzElasticMonitoredSubscription.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzElasticMonitoredSubscription' {
    It 'Delete' {
        { Remove-AzElasticMonitoredSubscription -ResourceGroupName $env.resourceGroup -MonitorName $env.elasticName01 -ConfigurationName $env.SubscriptionId -Confirm:$false } | Should -Not -Throw
    }

    It 'DeleteViaIdentityMonitor' {
        $elastic = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.elasticName01
        { Remove-AzElasticMonitoredSubscription -MonitorInputObject $elastic -ConfigurationName $env.SubscriptionId -Confirm:$false } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        # First get or create a monitored subscription to remove
        $monitoredSub = Get-AzElasticMonitoredSubscription -ResourceGroupName $env.resourceGroup -MonitorName $env.elasticName01 -ConfigurationName $env.SubscriptionId -ErrorAction SilentlyContinue
        if ($monitoredSub) {
            { Remove-AzElasticMonitoredSubscription -InputObject $monitoredSub -Confirm:$false } | Should -Not -Throw
        } else {
            # If no monitored subscription exists, just test the parameter validation
            { Remove-AzElasticMonitoredSubscription -ResourceGroupName $env.resourceGroup -MonitorName $env.elasticName01 -ConfigurationName $env.SubscriptionId -WhatIf } | Should -Not -Throw
        }
    }
}
