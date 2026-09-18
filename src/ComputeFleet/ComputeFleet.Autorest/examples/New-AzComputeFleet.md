### Example 1: Create a Compute Fleet in Launch mode with a VNet and managed disks
```powershell
$resourceGroupName = "myResourceGroup"
$location = "eastus"
$fleetName = "fleet1"
$vmNamePrefix = "fleet1prefix"
$adminPassword = Read-Host "Enter admin password" -AsSecureString

$subnetId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/Microsoft.Network/virtualNetworks/vnet/subnets/subnet1"
$nsgId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/Microsoft.Network/networkSecurityGroups/nsg"

# Build IPConfiguration
$ipConfig = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetIPConfiguration]::new()
$ipConfig.Name = "nic-ipConfig"
$ipConfig.Primary = $true
$ipConfig.SubnetId = $subnetId
$ipConfig.PublicIPAddressConfigurationName = "nic-publicip"
$ipConfig.IdleTimeoutInMinute = 15

# Build NIC Configuration
$nicConfig = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetNetworkConfiguration]::new()
$nicConfig.Name = "nic"
$nicConfig.Primary = $true
$nicConfig.EnableAcceleratedNetworking = $false
$nicConfig.NetworkSecurityGroupId = $nsgId
$nicConfig.IPConfiguration = @($ipConfig)

# Build StorageProfile
$storageProfile = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetStorageProfile]::new()
$storageProfile.ImageReferencePublisher = "canonical"
$storageProfile.ImageReferenceOffer = "ubuntu-24_04-lts"
$storageProfile.ImageReferenceSku = "server"
$storageProfile.ImageReferenceVersion = "latest"
$storageProfile.OSDiskCreateOption = "fromImage"
$storageProfile.OSDiskCaching = "ReadWrite"
$storageProfile.OSDiskOstype = "Linux"
$storageProfile.ManagedDiskStorageAccountType = "Premium_LRS"

# Build OSProfile
$osProfile = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetOSProfile]::new()
$osProfile.AdminUsername = "azureUser"
$osProfile.ComputerNamePrefix = $fleetName
$osProfile.AdminPassword = $adminPassword

# Build BaseVirtualMachineProfile
$baseVMProfile = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.BaseVirtualMachineProfile]::new()
$baseVMProfile.StorageProfile = $storageProfile
$baseVMProfile.OSProfile = $osProfile
$baseVMProfile.NetworkProfileNetworkApiVersion = "2020-11-01"
$baseVMProfile.NetworkProfileNetworkInterfaceConfiguration = @($nicConfig)
$baseVMProfile.SecurityProfileSecurityType = "TrustedLaunch"
$baseVMProfile.UefiSettingSecureBootEnabled = $true
$baseVMProfile.UefiSettingVTpmEnabled = $false
$baseVMProfile.LicenseType = "None"

# Build VM Sizes Profile
$vmSize1 = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMSizeProfile]::new()
$vmSize1.Name = "Standard_D2s_v3"
$vmSize2 = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMSizeProfile]::new()
$vmSize2.Name = "Standard_D8s_v3"
$vmSizesProfile = @($vmSize1, $vmSize2)

New-AzComputeFleet -Name $fleetName `
    -ResourceGroupName $resourceGroupName `
    -Location $location `
    -Mode "Launch" `
    -VMNamePrefix $vmNamePrefix `
    -VMSizesProfile $vmSizesProfile `
    -ComputeProfileBaseVirtualMachineProfile $baseVMProfile `
    -ComputeProfileComputeApiVersion "2024-11-01" `
    -RegularPriorityProfileCapacity 5 `
    -RegularPriorityProfileMinCapacity 0 `
    -RegularPriorityProfileAllocationStrategy "LowestPrice"
```

```output
Name    Location    ProvisioningState
----    --------    -----------------
fleet1  eastus      Succeeded
```

Creates a Compute Fleet named "fleet1" in Launch mode with a VM name prefix, using Ubuntu 24.04 LTS with TrustedLaunch security, Premium managed disks, and a regular priority profile targeting 5 VMs with LowestPrice allocation strategy. The fleet is configured with a network interface connected to an existing VNet subnet and NSG.

### Example 2: Create a Compute Fleet with a JSON file
```powershell
New-AzComputeFleet -Name "spotfleet1" -ResourceGroupName "myResourceGroup" -JsonFilePath "C:\fleet-config.json"
```

```output
Name        Location    ProvisioningState
----        --------    -----------------
spotfleet1  eastus      Succeeded
```

Creates a Compute Fleet using a JSON configuration file that contains the full fleet specification including compute profile, VM sizes, and priority settings. This approach is useful for complex configurations or when reusing fleet definitions across deployments.