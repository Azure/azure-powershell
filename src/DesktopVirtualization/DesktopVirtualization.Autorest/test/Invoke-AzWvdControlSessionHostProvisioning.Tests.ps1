if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzWvdControlSessionHostProvisioning'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzWvdControlSessionHostProvisioning.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzWvdControlSessionHostProvisioning' {
    It 'PostExpanded' {
             Update-AzWvdSessionHostManagement -ProvisioningInstanceCount 3 -ResourceGroup $env.ResourceGroupPersistent -HostPoolName $env.SHPHostPoolPersistent -SubscriptionId $env.subscriptionId
             Invoke-AzWvdControlSessionHostProvisioning -HostPoolName $env.SHPHostPoolPersistent -ResourceGroupName $env.ResourceGroupPersistent -SubscriptionId $env.subscriptionId -CancelMessage "Giving up" -NoWait
    }
}
