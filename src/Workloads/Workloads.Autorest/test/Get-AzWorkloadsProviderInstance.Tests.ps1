if(($null -eq $TestName) -or ($TestName -contains 'Get-AzWorkloadsProviderInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWorkloadsProviderInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzWorkloadsProviderInstance' {
    It 'List' {
        $providerResponseList = Get-AzWorkloadsProviderInstance -MonitorName $env.MonitorName -ResourceGroupName $env.MonitorRg -SubscriptionId $env.WaaSSubscriptionId
        $providerResponseList.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $providerResponse = Get-AzWorkloadsProviderInstance -MonitorName $env.MonitorName -Name $env.nwProviderName -ResourceGroupName $env.MonitorRg -SubscriptionId $env.WaaSSubscriptionId
        $providerResponse.Name | Should -Be $env.nwProviderName
    }

    It 'GetViaId' {
        $providerResponse = Get-AzWorkloadsProviderInstance -InputObject "/subscriptions/$($env.WaaSSubscriptionId)/resourceGroups/$($env.MonitorRg)/providers/Microsoft.Workloads/monitors/$($env.MonitorName)/providerInstances/$($env.nwProviderName)"
        $providerResponse.Name | Should -Be $env.nwProviderName
    }
}
