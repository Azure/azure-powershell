if(($null -eq $TestName) -or ($TestName -contains 'Get-AzElasticMonitoredSubscription'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzElasticMonitoredSubscription.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzElasticMonitoredSubscription' {
    It 'List' {
        { Get-AzElasticMonitoredSubscription -ResourceGroupName $env.resourceGroup -MonitorName $env.elasticName01 } | Should -Not -Throw
    }

    It 'GetViaIdentityMonitor' {
        $elastic = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.elasticName01
        { Get-AzElasticMonitoredSubscription -MonitorInputObject $elastic -ConfigurationName $env.SubscriptionId } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzElasticMonitoredSubscription -ResourceGroupName $env.resourceGroup -MonitorName $env.elasticName01 -ConfigurationName $env.SubscriptionId } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        $elastic = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.elasticName01
        $monitoredSub = Get-AzElasticMonitoredSubscription -ResourceGroupName $env.resourceGroup -MonitorName $env.elasticName01 -ConfigurationName $env.SubscriptionId
        { Get-AzElasticMonitoredSubscription -InputObject $monitoredSub } | Should -Not -Throw
    }
}
