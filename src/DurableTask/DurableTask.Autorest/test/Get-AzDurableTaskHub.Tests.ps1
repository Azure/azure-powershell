if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDurableTaskHub'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDurableTaskHub.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDurableTaskHub' {
    BeforeAll {
        New-AzDurableTaskHub -Name $env.taskHubName -SchedulerName $env.schedulerName -ResourceGroupName $env.resourceGroup
    }

    AfterAll {
        Remove-AzDurableTaskHub -Name $env.taskHubName -SchedulerName $env.schedulerName -ResourceGroupName $env.resourceGroup
    }

    It 'List' {
        $taskHubs = Get-AzDurableTaskHub -SchedulerName $env.schedulerName -ResourceGroupName $env.resourceGroup
        $taskHubs.Name | Should -Contain $env.taskHubName
    }

    It 'Get' {
        $taskHub = Get-AzDurableTaskHub -Name $env.taskHubName -SchedulerName $env.schedulerName -ResourceGroupName $env.resourceGroup
        $taskHub.Name | Should -Be $env.taskHubName
    }

    It 'GetViaIdentity' {
        $taskHub = Get-AzDurableTaskHub -Name $env.taskHubName -SchedulerName $env.schedulerName -ResourceGroupName $env.resourceGroup
        $taskHubById = Get-AzDurableTaskHub -InputObject $taskHub
        $taskHubById.Name | Should -Be $env.taskHubName
    }
}
