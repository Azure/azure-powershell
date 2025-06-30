if(($null -eq $TestName) -or ($TestName -contains 'Get-AzWvdSessionHostProvisioningStatuses'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWvdSessionHostProvisioningStatuses.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzWvdSessionHostProvisioningStatuses' {
    It 'Get' {
        $sessionHostManagement = Get-AzWvdSessionHostProvisioningStatuses -SubscriptionId $env.SubscriptionId `
             -ResourceGroupName $env.ResourceGroupPersistent `
             -HostPoolName $env.AutomatedHostpoolPersistent
        $sessionHostManagement.Count -gt 0 | Should -Be $true
    }
}
