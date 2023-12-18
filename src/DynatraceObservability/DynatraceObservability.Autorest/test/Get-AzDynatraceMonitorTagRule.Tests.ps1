if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDynatraceMonitorTagRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDynatraceMonitorTagRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDynatraceMonitorTagRule' {
    It 'Get' {
        { Get-AzDynatraceMonitorTagRule -ResourceGroupName $env.resourceGroup -MonitorName $env.dynatraceName01 } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { 
            $obj = Get-AzDynatraceMonitorTagRule -ResourceGroupName $env.resourceGroup -MonitorName $env.dynatraceName01
            Get-AzDynatraceMonitorTagRule -InputObject $obj
        } | Should -Not -Throw
    }
}
