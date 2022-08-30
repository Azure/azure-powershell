if(($null -eq $TestName) -or ($TestName -contains 'New-AzDynatraceMonitorSSOConfig'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDynatraceMonitorSSOConfig.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDynatraceMonitorSSOConfig' {
    It 'CreateExpanded' {
        { New-AzDynatraceMonitorSSOConfig -ResourceGroupName $env.resourceGroup -MonitorName $env.dynatraceName02 -AadDomain "mpliftrlogz20210811outlook.onmicrosoft.com" } | Should -Not -Throw
    }
}
