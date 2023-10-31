if(($null -eq $TestName) -or ($TestName -contains 'AzStackHCIVmVirtualMachine'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzStackHCIVmVirtualMachine.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzStackHCIVmVirtualMachine' {
    It 'Create Virtual Machine  '  {
        New-AzStackHCIVMImage -Name  $env.vmImageName -ImagePath  $env.imagePath  -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -OSType $env.osTypeLinux | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
        New-AzStackHciVMLogicalNetwork  -Name $env.lnetName -SubscriptionId $env.subscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -VmSwitchName $env.vmSwitchName | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
        New-AzStackHciVMVirtualMachine -Name $env.vmName -OsType $env.osTypeLinux  -ImageName $env.vmImageName -VmSize $env.vmSize -AdminUsername $env.adminUsername -ComputerName $env.vmName -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId  -Location $env.location | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
    
    }

    It 'Add Nic'  {
        {
            New-AzStackHCIVMNetworkInterface  -Name $env.nicName -SubscriptionId $env.subscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -SubnetName $env.lnetName | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
            Add-AzStackHCIVMVirtualMachineNic  -Name $env.vmName -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId  -NicNames $env.nicName | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
        } | Should -Not -Throw
    }

    It 'Remove Nic'  {
        {
            Remove-AzStackHCIVMVirtualMachineNic  -Name $env.vmName -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId  -NicNames $env.nicName | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
        } | Should -Not -Throw
    }

    It 'Add Disk '  {
        {
            New-AzStackHCIVMVirtualHardDisk -Name $env.vhdName -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -SizeGb $env.sizeGb | Select-Object -Property ProvisioningState  | Should -BeExactly "@{ProvisioningState=Succeeded}"
            Add-AzStackHCIVMVirtualMachineDataDisk  -Name $env.vmName -ResourceGroupName $env.resourceGroupName  -DataDiskNames $env.vhdName | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
        } | Should -Not -Throw
    }

    It 'Remove Disk '  {
        {
            Remove-AzStackHCIVMVirtualMachineDataDisk  -Name $env.vmName -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId   -DataDiskNames $env.vhdName | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
        } | Should -Not -Throw
    }

    It 'Get'  {
        {
            $config = Get-AzStackHCIVMVirtualMachine -Name $env.vmName -ResourceGroupName $env.resourceGroupName 
            $config.Name | Should -Be  "default"
        } | Should -Not -Throw
    }

    It 'Stop'  {
        {
            Stop-AzStackHCIVMVirtualMachine -Name $env.vmName -ResourceGroupName $env.resourceGroupName 
        } | Should -Not -Throw
    }

    It 'Start'  {
        {
            Start-AzStackHCIVMVirtualMachine -Name $env.vmName -ResourceGroupName $env.resourceGroupName 
        } | Should -Not -Throw
    }


    It 'Delete'{
        {

            Remove-AzStackHCIVMVirtualMachine -Name  $env.vmName -ResourceGroupName $env.resourceGroupName -Force
            Remove-AzStackHCIVMNetworkInterface -Name  $env.nicName -ResourceGroupName $env.resourceGroupName -Force
            Remove-AzStackHCIVMLogicalNetwork -Name  $env.lnetName -ResourceGroupName $env.resourceGroupName -Force
            Remove-AzStackHCIVMImage -Name $env.vmImageName -ResourceGroupName $env.resourceGroupName -Force
            Remove-AzStackHCIVMVirtualHardDisk -Name $env.vhdName -ResourceGroupName $env.resourceGroupName -Force
            $config = Get-AzStackHCIVMVirtualMachine -Name $env.vmName -ResourceGroupName $env.resourceGroupName 
            $config | Should -Be $null
        } | Should -Throw
    }

}
