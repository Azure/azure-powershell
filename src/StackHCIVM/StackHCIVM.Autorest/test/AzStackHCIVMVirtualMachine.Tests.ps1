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
    It 'Create Virtual Machine  '  {
        
        New-AzStackHciVMVirtualMachine -Name manualvmtest2 -OsType Windows  -ImageId "/subscriptions/37908b1f-2848-4c85-b8bf-a2cab2c3b0ba/resourceGroups/vpclus0724-rg/providers/Microsoft.AzureStackHCI/galleryImages/gpuWinUnattend" -VmSize "Standard_K8S_v1"  -ComputerName "manualvmtest2" -ResourceGroupName "vpclus0724-rg" -CustomLocationId "/subscriptions/37908b1f-2848-4c85-b8bf-a2cab2c3b0ba/resourceGroups/vpclus0724-rg/providers/Microsoft.ExtendedLocation/customLocations/myResourceBridge-cl"  -Location "eastus" -ProvisionVMAgent:$false -ProvisionVMConfigAgent:$false -SubscriptionId $env.subscriptionId | Select-Object -Property ProvisioningState  | Should -BeExactly "@{ProvisioningState=Succeeded}"
    
    }

    It 'Get'  {
        {
            $config = Get-AzStackHCIVMVirtualMachine -Name manualvmtest2 -ResourceGroupName $env.resourceGroupName 
            $config.Name | Should -Be  "default"
        } | Should -Not -Throw
    }

    It 'Stop'  {
        {
            Stop-AzStackHCIVMVirtualMachine -Name manualvmtest2 -ResourceGroupName $env.resourceGroupName 
            $config = Get-AzStackHCIVMVirtualMachine -Name manualvmtest2 -ResourceGroupName $env.resourceGroupName 
            $config.StatusPowerState| Should -BeExactly "Stopped"
        } 
    }

    It 'Start'  {
        {
            Start-AzStackHCIVMVirtualMachine -Name manualvmtest2 -ResourceGroupName $env.resourceGroupName 
            $config = Get-AzStackHCIVMVirtualMachine -Name manualvmtest2 -ResourceGroupName $env.resourceGroupName 
            $config.StatusPowerState| Should -BeExactly "Running"
        } 
    }

    It 'Restart'  {
        {
            Restart-AzStackHCIVMVirtualMachine -Name manualvmtest2 -ResourceGroupName $env.resourceGroupName 
            $config = Get-AzStackHCIVMVirtualMachine -Name manualvmtest2 -ResourceGroupName $env.resourceGroupName 
            $config.StatusPowerState| Should -BeExactly "Running"
        } 
    }

    It 'Create Network Interface  '  {
        New-AzStackHciVMNetworkInterface  -Name "testNic1" -SubscriptionId $env.subscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -SubnetId "/subscriptions/37908b1f-2848-4c85-b8bf-a2cab2c3b0ba/resourceGroups/vpclus0724-rg/providers/Microsoft.AzureStackHCI/logicalnetworks/lnet_aug"  | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
    }


    It 'Add NIC'  {
        {
            Add-AzStackHCIVMVirtualMachineNetworkInterface -Name manualvmtest2 -ResourceGroupName $env.resourceGroupName -NicName "testNic1"
            $config = Get-AzStackHCIVMVirtualMachine -Name manualvmtest2 -ResourceGroupName $env.resourceGroupName 
            $config.StatusPowerState| Should -BeExactly "Running"
        } 
    }

    
    It 'Create osdisk'  {
        New-AzStackHCIVMVirtualHardDisk -Name "testOsDisk" -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -SizeGb $env.sizeGb | Select-Object -Property ProvisioningState  | Should -BeExactly "@{ProvisioningState=Succeeded}"
    }
    

    It 'Create VHD'  {
        New-AzStackHCIVMVirtualHardDisk -Name "testVhdDisk1" -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -SizeGb $env.sizeGb | Select-Object -Property ProvisioningState  | Should -BeExactly "@{ProvisioningState=Succeeded}"
    }
    
    It 'Create VHD'  {
        New-AzStackHCIVMVirtualHardDisk -Name "testVhdDisk2" -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -SizeGb $env.sizeGb | Select-Object -Property ProvisioningState  | Should -BeExactly "@{ProvisioningState=Succeeded}"
    }

    It 'Create Network Interface  '  {
        New-AzStackHciVMNetworkInterface  -Name "testNic2" -SubscriptionId $env.subscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -SubnetId "/subscriptions/37908b1f-2848-4c85-b8bf-a2cab2c3b0ba/resourceGroups/vpclus0724-rg/providers/Microsoft.AzureStackHCI/logicalnetworks/lnet_aug"  | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
    }
    
    It 'Create vm with osdisk  '  {
        New-AzStackHciVMVirtualMachine -DataDiskName "testVhdDisk1"  -Name "testvm3" -SubscriptionId $env.subscriptionId -ResourceGroupName $env.resourceGroupName  -NicName testNic2 -CustomLocationId  $env.customLocationId -Location "eastus"  -OsType "Windows" -OsDiskName "testOsDisk" | Select-Object -Property ProvisioningState  | Should -BeExactly "@{ProvisioningState=Succeeded}"
    }

    It 'Add Data Disk'  {
        {
            Add-AzStackHciVMVirtualMachineDataDisk -Name "testvm3" -ResourceGroupName $env.resourceGroupName -DataDiskName "testVhdDisk2"
            $config = Get-AzStackHCIVMVirtualMachine -Name manualvmtest2 -ResourceGroupName $env.resourceGroupName 
            $config.StatusPowerState| Should -BeExactly "Running"
        }
    }        

    It 'Delete' {
         {
        
            Remove-AzStackHCIVMVirtualMachine -Name  manualvmtest2 -ResourceGroupName $env.resourceGroupName -Force
            $config = Get-AzStackHCIVMVirtualMachine -Name manualvmtest2 -ResourceGroupName $env.resourceGroupName 
            $config | Should -Be $null
         } | Should -Throw
    }
    
   It 'Delete disk vm' {
    {
   
       Remove-AzStackHCIVMVirtualMachine -Name  testvm3 -ResourceGroupName $env.resourceGroupName -Force
       $config = Get-AzStackHCIVMVirtualMachine -Name manualvmtest2 -ResourceGroupName $env.resourceGroupName 
       $config | Should -Be $null
    } | Should -Throw
}
}