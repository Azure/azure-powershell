if(($null -eq $TestName) -or ($TestName -contains 'Get-AzWvdSessionHostConfigurationsOperationStatus'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWvdSessionHostConfigurationsOperationStatus.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzWvdSessionHostConfigurationsOperationStatus' {
    It 'List' {
        $sessionHostConfig = Get-AzWvdSessionHostConfigurationsOperationStatus -SubscriptionId $env.SubscriptionId `
            -ResourceGroupName $env.ResourceGroupPersistent `
            -HostPoolName $env.AutomatedHostpoolPersistent 

        $sessionHostConfig.Count -gt 0 | Should -Be $true
    }

    It 'Get' {

        $sessionHostConfig = Get-AzWvdSessionHostConfigurationsOperationStatus -SubscriptionId $env.SubscriptionId `
            -ResourceGroupName $env.ResourceGroupPersistent `
            -HostPoolName $env.AutomatedHostpoolPersistent 

        $operationStatusId = $sessionHostConfig[0].Name

        $sessionHostConfig = Get-AzWvdSessionHostConfigurationsOperationStatus -SubscriptionId $env.SubscriptionId `
            -ResourceGroupName $env.ResourceGroupPersistent `
            -HostPoolName $env.AutomatedHostpoolPersistent `
            -OperationId $operationStatusId
        $sessionHostConfig.Name | Should -Be $operationStatusId
    }
}
