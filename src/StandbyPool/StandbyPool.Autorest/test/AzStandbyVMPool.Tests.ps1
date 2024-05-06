if(($null -eq $TestName) -or ($TestName -contains 'AzStandbyVMPool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzStandbyVMPool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzStandbyVMPool' {
    It 'CreateExpanded' {
        {
            $standbyvmpool = New-AzStandbyVMPool -Name testPool -ResourceGroupName test-rg -SubscriptionId $env.SubscriptionId -Location eastus -VMSSId "/subscriptions/$($env.SubscriptionId)/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachineScaleSets/test-vmss" -MaxReadyCapacity 1 -VMState Running
            $standbyvmpool.Name | Should -Be testPool
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $standbyvmpool = Get-AzStandbyVMPool -Name testPool -ResourceGroupName test-rg -SubscriptionId $env.SubscriptionId
            $standbyvmpool.Name | Should -Be testPool
        } | Should -Not -Throw
    }

    It 'Update' {
        {
            $standbyvmpool = Update-AzStandbyVMPool -Name testPool -ResourceGroupName test-rg -SubscriptionId $env.SubscriptionId -MaxReadyCapacity 2
            $standbyvmpool.Name | Should -Be testPool
            $standbyvmpool.ElasticityProfileMaxReadyCapacity | Should -Be 2
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzStandbyVMPool -Name testPool -ResourceGroupName test-rg -SubscriptionId $env.SubscriptionId -NoWait
        } | Should -Not -Throw
    }

}
