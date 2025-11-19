if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDurableTaskHub'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDurableTaskHub.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDurableTaskHub' {
    It 'Delete' {
        New-AzDurableTaskHub -Name $env.taskHubName -SchedulerName $env.schedulerName -ResourceGroupName $env.resourceGroup
        Remove-AzDurableTaskHub -Name $env.taskHubName -SchedulerName $env.schedulerName -ResourceGroupName $env.resourceGroup
        { Get-AzDurableTaskHub -Name $env.taskHubName -SchedulerName $env.schedulerName -ResourceGroupName $env.resourceGroup -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        $taskHub = New-AzDurableTaskHub -Name $env.taskHubName -SchedulerName $env.schedulerName -ResourceGroupName $env.resourceGroup
        Remove-AzDurableTaskHub -InputObject $taskHub
        { Get-AzDurableTaskHub -Name $env.taskHubName -SchedulerName $env.schedulerName -ResourceGroupName $env.resourceGroup -ErrorAction Stop } | Should -Throw
    }
}
