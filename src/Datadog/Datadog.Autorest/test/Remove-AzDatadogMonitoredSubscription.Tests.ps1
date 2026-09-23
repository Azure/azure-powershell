if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDatadogMonitoredSubscription'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDatadogMonitoredSubscription.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDatadogMonitoredSubscription' {
    It 'Delete' {
        { Remove-AzDatadogMonitoredSubscription -ConfigurationName default -MonitorName $env.monitorName01 -ResourceGroupName $env.resourceGroup } | Should -Not -Throw
    }

    It 'DeleteViaIdentityMonitor' {
        {
   	    	$obj = Get-AzDatadogMonitor -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01
		    Remove-AzDatadogMonitoredSubscription -ConfigurationName default -MonitorInputObject $obj
       	} | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    
}
