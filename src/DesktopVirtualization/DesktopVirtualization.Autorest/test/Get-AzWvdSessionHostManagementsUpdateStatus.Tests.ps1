if(($null -eq $TestName) -or ($TestName -contains 'Get-AzWvdSessionHostManagementsUpdateStatus'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWvdSessionHostManagementsUpdateStatus.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzWvdSessionHostManagementsUpdateStatus' {
    It 'List' {
        $sessionHostManagement = Get-AzWvdSessionHostManagementsUpdateStatus -SubscriptionId $env.SubscriptionId `
            -ResourceGroupName $env.ResourceGroupPersistent `
            -HostPoolName $env.AutomatedHostpoolPersistent 
        $sessionHostManagement.Count -gt 0 | Should -Be $true
    }

    It 'Get' {
        $sessionHostManagement = Get-AzWvdSessionHostManagementsUpdateStatus -SubscriptionId $env.SubscriptionId `
            -ResourceGroupName $env.ResourceGroupPersistent `
            -HostPoolName $env.AutomatedHostpoolPersistent 

        $UpdateStatusId = $sessionHostManagement[0].Name
        $sessionHostManagement = Get-AzWvdSessionHostManagementsUpdateStatus -SubscriptionId $env.SubscriptionId `
            -ResourceGroupName $env.ResourceGroupPersistent `
            -HostPoolName $env.AutomatedHostpoolPersistent `
            -OperationId $UpdateStatusId
        $sessionHostManagement.Name | Should -Be $UpdateStatusId
    }
}
