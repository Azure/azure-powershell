if(($null -eq $TestName) -or ($TestName -contains 'AzStackHCIVMVirtualMachine'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzStackHCIVMVirtualMachine.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzStackHCIVMVirtualMachine' {
    It 'Create Virtual Machine '  {
        {
        New-AzStackHciVMVirtualMachine -Name $env.vmName1 -OsType Windows  -ImageId $env.vmImageId -VmSize "Standard_K8S_v1"  -ComputerName $env.vmName1 -ResourceGroupName $env.newResourceGroupName -CustomLocationId $env.newCustomLocationId -Location $env.location -ProvisionVMAgent:$false -ProvisionVMConfigAgent:$false -SubscriptionId $env.subscriptionId | Select-Object -Property ProvisioningState  | Should -BeExactly "@{ProvisioningState=Succeeded}"   
        }| Should -Not -Throw
    }

    It 'Get'  {
        {
            $config = Get-AzStackHCIVMVirtualMachine -Name  $env.vmName1  -ResourceGroupName $env.resourceGroupName 
            $config.Name | Should -Be  "default"
        } | Should -Not -Throw
    }

    It 'Stop'  {
        {
            Stop-AzStackHCIVMVirtualMachine -Name $env.vmName1  -ResourceGroupName $env.resourceGroupName 
            $config = Get-AzStackHCIVMVirtualMachine -Name $env.vmName1  -ResourceGroupName $env.resourceGroupName 
            $config.StatusPowerState| Should -BeExactly "Stopped"
        } 
    }

    It 'Start'  {
        {
            Start-AzStackHCIVMVirtualMachine -Name $env.vmName1  -ResourceGroupName $env.resourceGroupName 
            $config = Get-AzStackHCIVMVirtualMachine -Name $env.vmName1  -ResourceGroupName $env.resourceGroupName 
            $config.StatusPowerState| Should -BeExactly "Running"
        } 
    }

    It 'Restart'  {
        {
            Restart-AzStackHCIVMVirtualMachine -Name $env.vmName1  -ResourceGroupName $env.resourceGroupName 
            $config = Get-AzStackHCIVMVirtualMachine -Name $env.vmName1  -ResourceGroupName $env.resourceGroupName 
            $config.StatusPowerState| Should -BeExactly "Running"
        } 
    }

    It 'Create Network Interface  ' {
        {
       New-AzStackHciVMNetworkInterface  -Name $env.nicName1 -SubscriptionId $env.subscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -SubnetId $env.SubnetId  | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
   }| Should -Not -Throw
   }

    It 'Add NIC'  {
        {
            Add-AzStackHCIVMVirtualMachineNetworkInterface -Name $env.vmName1  -ResourceGroupName $env.resourceGroupName -NicName $env.nicName1
            $config = Get-AzStackHCIVMVirtualMachine -Name $env.vmName1  -ResourceGroupName $env.resourceGroupName 
            $config.StatusPowerState| Should -BeExactly "Running"
        } | Should -Not -Throw
    }
    It 'Create VHD'  {
        {
                New-AzStackHCIVMVirtualHardDisk -Name $env.vhdName1 -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -SizeGb $env.sizeGb | Select-Object -Property ProvisioningState  | Should -BeExactly "@{ProvisioningState=Succeeded}"
                New-AzStackHCIVMVirtualHardDisk -Name $env.vhdName2 -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -SizeGb $env.sizeGb | Select-Object -Property ProvisioningState  | Should -BeExactly "@{ProvisioningState=Succeeded}"
                New-AzStackHCIVMVirtualHardDisk -Name $env.osDiskName -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -SizeGb $env.sizeGb | Select-Object -Property ProvisioningState  | Should -BeExactly "@{ProvisioningState=Succeeded}"
            }| Should -Not -Throw
    }
    It 'Create vm with osdisk'{ 
            {
                New-AzStackHciVMVirtualMachine -DataDiskName $env.vhdName1  -Name $env.vmName2 -SubscriptionId $env.subscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId  $env.customLocationId -Location $env.location  -OsType $env.osTypeWindows -OsDiskName $env.osDiskName | Select-Object -Property ProvisioningState  | Should -BeExactly "@{ProvisioningState=Succeeded}"
            } | Should -Not -Throw
        }
                 
    It 'Add Data Disk'  {
        {
            Add-AzStackHciVMVirtualMachineDataDisk -Name $env.vmName2 -ResourceGroupName $env.resourceGroupName -DataDiskName $env.vhdName2
            $config = Get-AzStackHCIVMVirtualMachine -Name $env.vmName2 -ResourceGroupName $env.resourceGroupName 
            $config.StatusPowerState| Should -BeExactly "Running"
        }
    }        
                   
    It 'Delete' {
        # Delete VM and verify it is removed
        {
            Remove-AzStackHCIVMVirtualMachine -Name $env.vmName1 -ResourceGroupName $env.resourceGroupName -Force
            $config = Get-AzStackHCIVMVirtualMachine -Name $env.vmName1 -ResourceGroupName $env.resourceGroupName 
            $config | Should -Be $null
        } | Should -Throw
    }
                       
    It 'Delete' {
        # Delete VM and verify it is removed
        {
            Remove-AzStackHCIVMVirtualMachine -Name $env.vmName2 -ResourceGroupName $env.resourceGroupName -Force
            $config = Get-AzStackHCIVMVirtualMachine -Name $env.vmName2 -ResourceGroupName $env.resourceGroupName 
            $config | Should -Be $null
        } | Should -Throw
    }

    It 'Delete resources' {
        {
            # Delete virtual hard disks
          Remove-AzStackHCIVMVirtualHardDisk -Name $env.vhdName1 -SubscriptionId $env.SubscriptionId   $env.resourceGroupName -Force
          $config = Get-AzStackHCIVMVirtualHardDisk -Name $env.vhdName1 -ResourceGroupName $env.resourceGroupName 
          $config | Should -Be $null
          Remove-AzStackHCIVMVirtualHardDisk -Name $env.vhdName2 -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -Force
          $config = Get-AzStackHCIVMVirtualHardDisk -Name $env.vhdName2 -ResourceGroupName $env.resourceGroupName 
          $config | Should -Be $null
          Remove-AzStackHCIVMVirtualHardDisk -Name $env.osDiskName -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -Force
          $config = Get-AzStackHCIVMVirtualHardDisk -Name $env.osDiskName -ResourceGroupName $env.resourceGroupName 
          $config | Should -Be $null
         # Delete network interface
          Remove-AzStackHciVMNetworkInterface -Name $env.nicName1 -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -Force
          $config = Get-AzStackHciVMNetworkInterface -Name $env.nicName1 -ResourceGroupName $env.resourceGroupName 
          $config | Should -Be $null
        }| Should -Throw
    }
}
