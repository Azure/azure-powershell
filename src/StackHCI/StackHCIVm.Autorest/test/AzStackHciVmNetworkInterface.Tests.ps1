if(($null -eq $TestName) -or ($TestName -contains 'AzStackHCIVmNetworkInterface'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzStackHCIVmNetworkInterface.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzStackHCIVmNetworkInterface' {
    It 'Create Network Interface  '  {
        New-AzStackHciVMLogicalNetwork  -Name $env.lnetName -SubscriptionId $env.subscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -VmSwitchName $env.vmSwitchName | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
        New-AzStackHciVMNetworkInterface  -Name $env.nicName -SubscriptionId $env.subscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -SubnetName $env.lnetName | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
    }

    It 'List'  {
        {
            $config = Get-AzStackHCIVMNetworkInterface -ResourceGroupName $env.resourceGroupName
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get'  {
        {
            $config = Get-AzStackHCIVMNetworkInterface -Name $env.nicName -ResourceGroupName $env.resourceGroupName 
            $config.Name | Should -Be  $env.nicName
        } | Should -Not -Throw
    }


    It 'Delete'{
        {
            Remove-AzStackHCIVMNetworkInterface -Name  $env.nicName -ResourceGroupName $env.resourceGroupName -Force
            Remove-AzStackHCIVMLogicalNetwork -Name  $env.lnetName -ResourceGroupName $env.resourceGroupName -Force
            $config = Get-AzStackHCIVMNetworkInterface -Name  $env.nicName -ResourceGroupName $env.resourceGroupName 
            $config | Should -Be $null
        } | Should -Throw
    }

} 