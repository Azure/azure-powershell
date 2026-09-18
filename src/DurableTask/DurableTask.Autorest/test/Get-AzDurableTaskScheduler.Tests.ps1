if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDurableTaskScheduler'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDurableTaskScheduler.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDurableTaskScheduler' {
    It 'List' {
        $schedulers = Get-AzDurableTaskScheduler -ResourceGroupName $env.resourceGroup
        $schedulers.Name | Should -Contain $env.schedulerName
    }

    It 'Get' {
        $scheduler = Get-AzDurableTaskScheduler -Name $env.schedulerName -ResourceGroupName $env.resourceGroup
        $scheduler.Name | Should -Be $env.schedulerName
    }

    It 'GetViaIdentity' {
        $scheduler = Get-AzDurableTaskScheduler -Name $env.schedulerName -ResourceGroupName $env.resourceGroup
        $schedulerById = Get-AzDurableTaskScheduler -InputObject $scheduler
        $schedulerById.Name | Should -Be $env.schedulerName
    }
}
