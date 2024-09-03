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
        New-AzStackHciVMVirtualMachine -Name manualvmtest50 -OsType Windows  -ImageId "/subscriptions/37908b1f-2848-4c85-b8bf-a2cab2c3b0ba/resourceGroups/vpclus0724-rg/providers/Microsoft.AzureStackHCI/galleryImages/gpuWinUnattend" -VmSize "Standard_K8S_v1"  -ComputerName "manualvmtest50" -ResourceGroupName "vpclus0724-rg" -CustomLocationId "/subscriptions/37908b1f-2848-4c85-b8bf-a2cab2c3b0ba/resourceGroups/vpclus0724-rg/providers/Microsoft.ExtendedLocation/customLocations/myResourceBridge-cl"  -Location "eastus" -ProvisionVMAgent:$false -ProvisionVMConfigAgent:$false -SubscriptionId $env.subscriptionId | Select-Object -Property ProvisioningState  | Should -BeExactly "@{ProvisioningState=Succeeded}"   
        }| Should -Not -Throw
    }

    It 'Get'  {
        {
            $config = Get-AzStackHCIVMVirtualMachine -Name manualvmtest50 -ResourceGroupName $env.resourceGroupName 
            $config.Name | Should -Be  "default"
        } | Should -Not -Throw
    }

    It 'Stop'  {
        {
            Stop-AzStackHCIVMVirtualMachine -Name manualvmtest50 -ResourceGroupName $env.resourceGroupName 
            $config = Get-AzStackHCIVMVirtualMachine -Name manualvmtest50 -ResourceGroupName $env.resourceGroupName 
            $config.StatusPowerState| Should -BeExactly "Stopped"
        } 
    }

    It 'Start'  {
        {
            Start-AzStackHCIVMVirtualMachine -Name manualvmtest50 -ResourceGroupName $env.resourceGroupName 
            $config = Get-AzStackHCIVMVirtualMachine -Name manualvmtest50 -ResourceGroupName $env.resourceGroupName 
            $config.StatusPowerState| Should -BeExactly "Running"
        } 
    }

    It 'Restart'  {
        {
            Restart-AzStackHCIVMVirtualMachine -Name manualvmtest50 -ResourceGroupName $env.resourceGroupName 
            $config = Get-AzStackHCIVMVirtualMachine -Name manualvmtest50 -ResourceGroupName $env.resourceGroupName 
            $config.StatusPowerState| Should -BeExactly "Running"
        } 
    }

    It 'Create Network Interface  ' {
         {
        New-AzStackHciVMNetworkInterface  -Name "testNic11" -SubscriptionId $env.subscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -SubnetId "/subscriptions/37908b1f-2848-4c85-b8bf-a2cab2c3b0ba/resourceGroups/vpclus0724-rg/providers/Microsoft.AzureStackHCI/logicalnetworks/lnet_aug"  | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
        New-AzStackHciVMNetworkInterface  -Name "testNic2" -SubscriptionId $env.subscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -SubnetId "/subscriptions/37908b1f-2848-4c85-b8bf-a2cab2c3b0ba/resourceGroups/vpclus0724-rg/providers/Microsoft.AzureStackHCI/logicalnetworks/lnet_aug"  | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
    }| Should -Not -Throw
    }

    It 'Add NIC'  {
        {
            Add-AzStackHCIVMVirtualMachineNetworkInterface -Name manualvmtest50 -ResourceGroupName $env.resourceGroupName -NicName "testNic11"
            $config = Get-AzStackHCIVMVirtualMachine -Name manualvmtest50 -ResourceGroupName $env.resourceGroupName 
            $config.StatusPowerState| Should -BeExactly "Running"
        } | Should -Not -Throw
    }
    It 'Create VHD'  {
        {
                New-AzStackHCIVMVirtualHardDisk -Name "testVhdDisk2" -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -SizeGb $env.sizeGb | Select-Object -Property ProvisioningState  | Should -BeExactly "@{ProvisioningState=Succeeded}"
                New-AzStackHCIVMVirtualHardDisk -Name "testVhdDisk21" -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -SizeGb $env.sizeGb | Select-Object -Property ProvisioningState  | Should -BeExactly "@{ProvisioningState=Succeeded}"
                New-AzStackHCIVMVirtualHardDisk -Name "testOsDisk1" -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -SizeGb $env.sizeGb | Select-Object -Property ProvisioningState  | Should -BeExactly "@{ProvisioningState=Succeeded}"
            }| Should -Not -Throw
    }
    It 'Create vm with osdisk'{ 
            {
                New-AzStackHciVMVirtualMachine -DataDiskName "testVhdDisk2"  -Name "testvm4" -SubscriptionId $env.subscriptionId -ResourceGroupName $env.resourceGroupName  -NicName testNic2 -CustomLocationId  $env.customLocationId -Location "eastus"  -OsType "Windows" -OsDiskName "testOsDisk1" | Select-Object -Property ProvisioningState  | Should -BeExactly "@{ProvisioningState=Succeeded}"
            } | Should -Not -Throw
        }
                 
    It 'Add Data Disk'  {
        {
            Add-AzStackHciVMVirtualMachineDataDisk -Name "testvm4" -ResourceGroupName $env.resourceGroupName -DataDiskName "testVhdDisk21"
            $config = Get-AzStackHCIVMVirtualMachine -Name testvm4 -ResourceGroupName $env.resourceGroupName 
            $config.StatusPowerState| Should -BeExactly "Running"
        }
    }        
                   
    It 'Delete' {
        # Delete VM and verify it is removed
        {
            Remove-AzStackHCIVMVirtualMachine -Name "manualvmtest50" -ResourceGroupName $env.resourceGroupName -Force
            $config = Get-AzStackHCIVMVirtualMachine -Name "manualvmtest50" -ResourceGroupName $env.resourceGroupName 
            $config | Should -Be $null
        } | Should -Throw
    }
                       
    It 'Delete' {
        # Delete VM and verify it is removed
        {
            Remove-AzStackHCIVMVirtualMachine -Name "testvm4" -ResourceGroupName $env.resourceGroupName -Force
            $config = Get-AzStackHCIVMVirtualMachine -Name "testvm4" -ResourceGroupName $env.resourceGroupName 
            $config | Should -Be $null
        } | Should -Throw
    }

    It 'Delete resources' {
        {
            # Delete virtual hard disks
          Remove-AzStackHCIVMVirtualHardDisk -Name "testVhdDisk2" -SubscriptionId $env.SubscriptionId   $env.resourceGroupName -Force
          $config = Get-AzStackHCIVMVirtualHardDisk -Name "testVhdDisk2" -ResourceGroupName $env.resourceGroupName 
          $config | Should -Be $null
          Remove-AzStackHCIVMVirtualHardDisk -Name "testVhdDisk21" -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -Force
          $config = Get-AzStackHCIVMVirtualHardDisk -Name "testVhdDisk21" -ResourceGroupName $env.resourceGroupName 
          $config | Should -Be $null
          Remove-AzStackHCIVMVirtualHardDisk -Name "testOsDisk1" -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -Force
          $config = Get-AzStackHCIVMVirtualHardDisk -Name "testOsDisk1" -ResourceGroupName $env.resourceGroupName 
          $config | Should -Be $null
      
          # Delete network interface
          Remove-AzStackHciVMNetworkInterface -Name "testNic2" -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -Force
          $config = Get-AzStackHciVMNetworkInterface -Name "testNic2" -ResourceGroupName $env.resourceGroupName 
          $config | Should -Be $null
         # Delete network interface
          Remove-AzStackHciVMNetworkInterface -Name "testNic11" -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -Force
          $config = Get-AzStackHciVMNetworkInterface -Name "testNic11" -ResourceGroupName $env.resourceGroupName 
          $config | Should -Be $null
        }| Should -Throw
    }
}
