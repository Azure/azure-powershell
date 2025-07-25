if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDynatraceMonitorMetricStatus'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDynatraceMonitorMetricStatus.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDynatraceMonitorMetricStatus' {
    It 'Get' {
        {Get-AzDynatraceMonitorMetricStatus -MonitorName $env.dynatraceName01 -ResourceGroupName $env.resourceGroup}  | Should -Not -Throw
    }
}
