if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzWorkloadsProviderInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzWorkloadsProviderInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzWorkloadsProviderInstance' {
    It 'Delete' {
        $response = Remove-AzWorkloadsProviderInstance -MonitorName $env.MonitorName -Name $env.sqlProviderName -ResourceGroupName $env.MonitorRg -SubscriptionId $env.WaaSSubscriptionId
        $response.Status | Should -Be $env.ProvisioningState
    }

    It 'DeleteViaIdentity' {
        $response = Remove-AzWorkloadsProviderInstance -InputObject "/subscriptions/$($env.WaaSSubscriptionId)/resourceGroups/$($env.MonitorRg)/providers/Microsoft.Workloads/monitors/$($env.MonitorName)/providerInstances/$($env.hanaProviderName)"
        $response.Status | Should -Be $env.ProvisioningState
    }
}
