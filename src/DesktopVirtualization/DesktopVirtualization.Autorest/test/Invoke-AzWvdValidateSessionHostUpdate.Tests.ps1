if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzWvdValidateSessionHostUpdate'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzWvdValidateSessionHostUpdate.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzWvdValidateSessionHostUpdate' {
    It 'PostExpanded' {
        Invoke-AzWvdValidateSessionHostUpdate -HostPoolName $env.AutomatedHostpoolPersistent -ResourceGroupName $env.ResourceGroupPersistent `
        -SubscriptionId $env.subscriptionId `
        -Debug -NoWait
    }
}
