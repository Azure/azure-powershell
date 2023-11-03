if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzLogzHostMonitor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzLogzHostMonitor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzLogzHostMonitor' {
    It 'Host' {
        { Invoke-AzLogzHostMonitor -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 } | Should -Not -Throw
    }

    It 'HostViaIdentity' {
        { 
            $monitor = Get-AzLogzMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName01
            Invoke-AzLogzHostMonitor -InputObject $monitor
        } | Should -Not -Throw
    }
}
