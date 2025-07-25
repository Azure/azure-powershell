if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDynatraceMonitorSSOConfig'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDynatraceMonitorSSOConfig.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDynatraceMonitorSSOConfig' {
    It 'Get' {
        { Get-AzDynatraceMonitorSSOConfig -ResourceGroupName $env.resourceGroup -MonitorName $env.dynatraceName01 } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { 
            $obj = Get-AzDynatraceMonitorSSOConfig -ResourceGroupName $env.resourceGroup -MonitorName $env.dynatraceName01
            Get-AzDynatraceMonitorSSOConfig -InputObject $obj
        } | Should -Not -Throw
    }
}
