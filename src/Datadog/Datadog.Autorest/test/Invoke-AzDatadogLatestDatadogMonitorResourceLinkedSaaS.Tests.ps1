if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzDatadogLatestDatadogMonitorResourceLinkedSaaS'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzDatadogLatestDatadogMonitorResourceLinkedSaaS.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzDatadogLatestDatadogMonitorResourceLinkedSaaS' {
    It 'Latest' {
        { Invoke-AzDatadogLatestDatadogMonitorResourceLinkedSaaS -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 } | Should -Not -Throw
    }

    It 'LatestViaIdentity' {
        {
            $obj = Get-AzDatadogMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName01
            Invoke-AzDatadogLatestDatadogMonitorResourceLinkedSaaS -InputObject $obj
        } | Should -Not -Throw
    }
}
