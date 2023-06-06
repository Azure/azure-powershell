if(($null -eq $TestName) -or ($TestName -contains 'New-AzStackHCIVMVirtualMachine'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStackHCIVMVirtualMachine.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStackHCIVMVirtualMachine' {
    It 'ByImageId' {
        New-AzStackHCIVMVirtualMachine -Name "testVm" -VmSize "Custom" -VmProcessors 4  -VmMemory 8   -SubscriptionId $env.subscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -ImageId $env.vmImageId -OsType "Linux" 
        | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
    }

    It 'ByImageName' {
       New-AzStackHCIVMVirtualMachine -Name "testVm2" -VmSize "Custom" -VmProcessors 4  -VmMemory 8   -SubscriptionId $env.subscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -ImageName $env.vmImageName -OsType "Linux" 
        | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
    }

    It 'ByOsDiskId' {
       New-AzStackHCIVMVirtualMachine -Name "testVm3" -VmSize "Custom" -VmProcessors 4  -VmMemory 8   -SubscriptionId $env.subscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -OsDiskId $env.vmVhdId -OsType "Linux" 
        | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
    }

    It 'ByOsDiskName' {
         New-AzStackHCIVMVirtualMachine -Name "testVm3" -VmSize "Custom" -VmProcessors 4  -VmMemory 8   -SubscriptionId $env.subscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -OsDiskName $env.vmVhdName -OsType "Linux" 
        | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
    }
}
