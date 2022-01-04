if(($null -eq $TestName) -or ($TestName -contains 'Get-AzLogzMonitorTagRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzLogzMonitorTagRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzLogzMonitorTagRule' {
    It 'Get' {
        $tagRule = Get-AzLogzMonitorTagRule -ResourceGroupName $env.resourceGroup-MonitorName $env.monitorName01
        $tagRule.Name | Should -Be 'default'
    }

    It 'GetViaIdentity' {
        $tagRule = Get-AzLogzMonitorTagRule -ResourceGroupName $env.resourceGroup-MonitorName $env.monitorName01
        $tagRule = Get-AzLogzMonitorTagRule -InputObject $tagRule
        $tagRule.Name | Should -Be 'default'
    }
}
