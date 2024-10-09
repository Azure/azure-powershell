if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzWvdControlSessionHostUpdate'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzWvdControlSessionHostUpdate.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzWvdControlSessionHostUpdate' {
    It 'PostExpanded' {
        Invoke-AzWvdInitiateSessionHostUpdate -HostPoolName $env.AutomatedHostpoolPersistent -ResourceGroupName $env.ResourceGroupPersistent `
        -SubscriptionId $env.subscriptionId -ScheduledDateTimeZone 'Pacific Standard Time' `
        -UpdateDeleteOriginalVM `
        -UpdateLogOffDelayMinute 0 `
        -UpdateLogOffMessage 'Updating Session Hosts. Will Log off' `
        -UpdateMaxVmsRemoved 1

        Invoke-AzWvdControlSessionHostUpdate -HostPoolName $env.AutomatedHostpoolPersistent -ResourceGroupName $env.ResourceGroupPersistent `
        -SubscriptionId $env.subscriptionId `
        -Action Cancel `
        -CancelMessage "Giving up"
    }
}
