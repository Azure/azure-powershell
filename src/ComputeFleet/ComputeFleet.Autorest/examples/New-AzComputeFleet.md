### Example 1: Create a Launch mode Compute Fleet with one Linux VM
```powershell
$resourceGroupName = "myResourceGroup"
$location = "centralus"
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
$storageProfile.ManagedDiskStorageAccountType = "Standard_LRS"

# Build OSProfile
$osProfile = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VirtualMachineScaleSetOSProfile]::new()
$osProfile.AdminUsername = "azureUser"
$osProfile.ComputerNamePrefix = $fleetName
$osProfile.AdminPassword = $adminPassword
$osProfile.LinuxConfigurationDisablePasswordAuthentication = $false

# Build BaseVirtualMachineProfile
$baseVMProfile = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.BaseVirtualMachineProfile]::new()
$baseVMProfile.StorageProfile = $storageProfile
$baseVMProfile.OSProfile = $osProfile
$baseVMProfile.NetworkProfileNetworkApiVersion = "2020-11-01"
$baseVMProfile.NetworkProfileNetworkInterfaceConfiguration = @($nicConfig)
$baseVMProfile.SecurityProfileSecurityType = "TrustedLaunch"
$baseVMProfile.UefiSettingSecureBootEnabled = $true
$baseVMProfile.UefiSettingVTpmEnabled = $true

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
    -RegularPriorityProfileCapacity 1 `
    -RegularPriorityProfileMinCapacity 1 `
    -RegularPriorityProfileAllocationStrategy "LowestPrice"
```

```output
Name    Location    ProvisioningState
----    --------    -----------------
fleet1  centralus  Succeeded
```

Creates a Launch mode fleet targeting one Ubuntu 24.04 LTS VM with Trusted Launch security, Standard managed disks, and no public IP address. Replace the subnet and network security group IDs with existing resources in the fleet's subscription and region. The resource group must already exist.

The cmdlet uses the Compute Fleet API version `2026-08-01`. `-ComputeProfileComputeApiVersion` instead selects the Microsoft.Compute API used to provision VMs; it is not the fleet API version. Use `Get-AzComputeFleetVirtualMachine` to check VM launch status. Provisioning this example creates billable resources.

### Example 2: Create a Launch mode fleet from an existing JSON configuration
```powershell
$jsonFilePath = Join-Path -Path $PWD.Path -ChildPath "fleet-config.json"
New-AzComputeFleet -Name "fleet-json" -ResourceGroupName "myResourceGroup" `
    -JsonFilePath $jsonFilePath | Select-Object Name, Location, Mode, ProvisioningState
```

```output
Name       Location  Mode   ProvisioningState
----       --------  ----   -----------------
fleet-json centralus Launch Succeeded
```

Creates a fleet from a JSON file you have prepared. The document must include `location` and the appropriate `properties`, including `mode`, `vmNamePrefix`, `computeProfile`, `vmSizesProfile`, and priority profiles for this Launch mode example. Use `Launch` for `properties.mode`. Do not commit credentials contained in the VM profile to source control.