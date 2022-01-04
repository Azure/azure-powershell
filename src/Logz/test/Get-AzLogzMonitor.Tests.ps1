if(($null -eq $TestName) -or ($TestName -contains 'Get-AzLogzMonitor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzLogzMonitor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzLogzMonitor' {
    It 'List' {
        $monitorList = Get-AzLogzMonitor
        $monitorList.Count | Should -BeGreaterOrEqual 2
    }

    It 'Get' {
        $monitor = Get-AzLogzMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName01
        $monitor.Name | Should -Be $env.monitorName01
    }

    It 'List1' {
        $monitorList = Get-AzLogzMonitor -ResourceGroupName $env.resourceGroup
        $monitorList.Count | Should -BeGreaterOrEqual 2
    }

    It 'GetViaIdentity' {
        $monitor = Get-AzLogzMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName01
        $monitor = Get-AzLogzMonitor -InputObject $monitor
        $monitor.Name | Should -Be $env.monitorName01
    }
}
