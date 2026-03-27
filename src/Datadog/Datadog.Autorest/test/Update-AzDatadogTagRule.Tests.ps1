if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDatadogTagRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDatadogTagRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDatadogTagRule' {
    It 'UpdateExpanded' {
        { Update-AzDatadogTagRule -MonitorName $env.monitorName01 -ResourceGroupName $env.resourceGroup -Name default -LogRuleSendSubscriptionLog -LogRuleSendResourceLog } | Should -Not -Throw
    }

    It 'UpdateViaIdentityMonitorExpanded' {
        {
          $obj =  Get-AzDatadogMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName01 
          Update-AzDatadogTagRule -MonitorInputObject $obj -Name default -LogRuleSendSubscriptionLog -LogRuleSendResourceLog
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        {
          $obj =  Get-AzDatadogMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName01 
          Update-AzDatadogTagRule -InputObject $obj -LogRuleSendSubscriptionLog -LogRuleSendResourceLog
        } | Should -Not -Throw
    }
}
