if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzWvdInitiateSessionHostUpdate'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzWvdInitiateSessionHostUpdate.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzWvdInitiateSessionHostUpdate' {
    It 'PostExpanded' {

        Invoke-AzWvdInitiateSessionHostUpdate -HostPoolName $env.AutomatedHostpoolPersistent -ResourceGroupName $env.ResourceGroupPersistent `
        -SubscriptionId $env.subscriptionId -ScheduledDateTimeZone 'Pacific Standard Time' `
        -UpdateDeleteOriginalVM `
        -UpdateLogOffDelayMinute 0 `
        -UpdateLogOffMessage 'Updating Session Hosts. Will Log off' `
        -UpdateMaxVmsRemoved 1 
    }
}
