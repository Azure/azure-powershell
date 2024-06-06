if(($null -eq $TestName) -or ($TestName -contains 'Get-AzWvdSessionHostManagementsOperationStatus'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWvdSessionHostManagementsOperationStatus.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzWvdSessionHostManagementsOperationStatus' {
    It 'List' {
        $sessionHostManagement = Get-AzWvdSessionHostManagementsOperationStatus -SubscriptionId $env.SubscriptionId `
            -ResourceGroupName $env.ResourceGroupPersistent `
            -HostPoolName $env.AutomatedHostpoolPersistent 
        $sessionHostManagement.Count -gt 0 | Should -Be $true
    }

    It 'Get' {
        $sessionHostManagement = Get-AzWvdSessionHostManagementsOperationStatus -SubscriptionId $env.SubscriptionId `
            -ResourceGroupName $env.ResourceGroupPersistent `
            -HostPoolName $env.AutomatedHostpoolPersistent 

        $operationStatusId = $sessionHostManagement[0].Name
        $sessionHostManagement = Get-AzWvdSessionHostManagementsOperationStatus -SubscriptionId $env.SubscriptionId `
            -ResourceGroupName $env.ResourceGroupPersistent `
            -HostPoolName $env.AutomatedHostpoolPersistent `
            -OperationId $operationStatusId
        $sessionHostManagement.Name | Should -Be $operationStatusId
    }
}
