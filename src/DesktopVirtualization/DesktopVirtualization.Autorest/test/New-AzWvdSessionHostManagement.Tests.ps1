if(($null -eq $TestName) -or ($TestName -contains 'New-AzWvdSessionHostManagement'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWvdSessionHostManagement.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzWvdSessionHostManagement' {
    It 'CreateExpanded' {
        $management = New-AzWvdSessionHostManagement -SubscriptionId $env.SubscriptionId `
            -ResourceGroupName $env.ResourceGroupPersistent `
            -HostPoolName $env.AutomatedHostpoolPersistent `
            -ScheduledDateTimeZone "UTC" `
            -UpdateLogOffDelayMinute 1 `
            -UpdateMaxVmsRemoved 1 `
            -UpdateLogoffMessage "HostpoolUpdate is great!" `
            -UpdateDeleteOriginalVm

        $management = Get-AzWvdSessionHostManagement -SubscriptionId $env.SubscriptionId `
            -ResourceGroupName $env.ResourceGroupPersistent `
            -HostPoolName $env.AutomatedHostpoolPersistent 

        $management.ScheduledDateTimeZone | Should -Be "UTC"
        $management.UpdateLogOffDelayMinute | Should -Be 1
        $management.UpdateMaxVmsRemoved | Should -Be 1
        $management.UpdateLogoffMessage | Should -Be "HostpoolUpdate is great!"
    }
}
