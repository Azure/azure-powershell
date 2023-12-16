if(($null -eq $TestName) -or ($TestName -contains 'Get-AzLogzMonitorSSOConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzLogzMonitorSSOConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzLogzMonitorSSOConfiguration' {
    It 'Get' {
        $sso = Get-AzLogzMonitorSSOConfiguration -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01
        $sso.Name | Should -Be 'default'
    }

    It 'GetViaIdentity' {
        $sso = Get-AzLogzMonitorSSOConfiguration -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01
        $sso = Get-AzLogzMonitorSSOConfiguration -InputObject $sso
        $sso.Name | Should -Be 'default'
    }
}
