if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDatadogMonitorDefaultApplicationKey'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDatadogMonitorDefaultApplicationKey.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDatadogMonitorDefaultApplicationKey' {
    It 'Get' {
        { Get-AzDatadogMonitorDefaultApplicationKey -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $obj = Get-AzDatadogMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName01
            Get-AzDatadogMonitorDefaultApplicationKey -InputObject $obj
        } | Should -Not -Throw
    }
}
