if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDynatraceMonitorSSODetail'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDynatraceMonitorSSODetail.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDynatraceMonitorSSODetail' {
    It 'GetExpanded' {
        { Get-AzDynatraceMonitorSSOConfig -ResourceGroupName $env.resourceGroup -MonitorName $env.dynatraceName01 } | Should -Not -Throw
    }
}
