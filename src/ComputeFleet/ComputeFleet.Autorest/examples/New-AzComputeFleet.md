### Example 1: Create a new compute fleet resource by ResourceGroupName and FleetName
```powershell
$fleet = Get-AzComputeFleet -ResourceGroupName "test-fleet" -FleetName "testFleet2"
$securedPassword = ConvertTo-SecureString -AsPlainText "[Sanitized]" -Force
$fleet.ComputeProfileBaseVirtualMachineProfile.OSProfileAdminPassword = $securedPassword
New-AzComputeFleet -ResourceGroupName "test-fleet" -FleetName "testFleet" -Resource $fleet
```

```output
AcceleratorCountMax                                  : 5
AcceleratorCountMin                                  : 
AdditionalLocationProfile                            : 
AdditionalVirtualMachineCapabilityHibernationEnabled : 
AdditionalVirtualMachineCapabilityUltraSsdEnabled    : 
ComputeProfileBaseVirtualMachineProfile              : {
                                                         "osProfile": {
                                                           "computerNamePrefix": "testfleet",
                                                           "adminUsername": "azureuser"
                                                         },
                                                         "storageProfile": {
                                                           "imageReference": {
                                                             "publisher": "canonical",
                                                             "offer": "ubuntu-24_04-lts",
                                                             "sku": "server",
                                                             "version": "latest"
                                                           },
                                                           "osDisk": {
                                                             "managedDisk": {
                                                               "storageAccountType": "Premium_LRS"
                                                             },
                                                             "caching": "ReadWrite",
                                                             "createOption": "fromImage",
                                                             "osType": "Linux"
                                                           }
                                                         },
                                                         "networkProfile": {
                                                           "networkInterfaceConfigurations": [
                                                             {
                                                               "properties": {
                                                                 "networkSecurityGroup": {
                                                                   "id": "/subscriptions/ca8520e1-3c83-4b64-bb99-60a64673daa3/resourceGroups/t
                                                       est-fleet/providers/Microsoft.Network/networkSecurityGroups/basicNsgvnet-centralus-2-ni
                                                       c01"
                                                                 },
                                                                 "primary": true,
                                                                 "enableAcceleratedNetworking": false,
                                                                 "ipConfigurations": [
                                                                   {
                                                                     "properties": {
                                                                       "subnet": {
                                                                         "id": "/subscriptions/ca8520e1-3c83-4b64-bb99-60a64673daa3/resourceGr
                                                       oups/test-fleet/providers/Microsoft.Network/virtualNetworks/vnet-centralus-2/subnets/sn
                                                       et-centralus-1"
                                                                       },
                                                                       "publicIPAddressConfiguration": {
                                                                         "properties": {
                                                                           "idleTimeoutInMinutes": 15
                                                                         },
                                                                         "name": "vnet-centralus-2-nic01-publicip"
                                                                       },
                                                                       "primary": true
                                                                     },
                                                                     "name": "vnet-centralus-2-nic01-ipConfig"
                                                                   }
                                                                 ]
                                                               },
                                                               "name": "vnet-centralus-2-nic01"
                                                             }
                                                           ],
                                                           "networkApiVersion": "2020-11-01"
                                                         },
                                                         "securityProfile": {
                                                           "uefiSettings": {
                                                             "secureBootEnabled": true,
                                                             "vTpmEnabled": false
                                                           },
                                                           "securityType": "TrustedLaunch"
                                                         },
                                                         "licenseType": "None"
                                                       }
ComputeProfileComputeApiVersion                      : 2023-09-01
ComputeProfilePlatformFaultDomainCount               : 1
DataDiskCountMax                                     : 
DataDiskCountMin                                     : 
Id                                                   : /subscriptions/ca8520e1-3c83-4b64-bb99-60a64673daa3/resourceGroups/test-fleet/providers
                                                       /Microsoft.AzureFleet/fleets/testFleet
IdentityPrincipalId                                  : 
IdentityTenantId                                     : 
IdentityType                                         : 
IdentityUserAssignedIdentity                         : {
                                                       }
LocalStorageInGiBMax                                 : 
LocalStorageInGiBMin                                 : 
Location                                             : centralus
MemoryInGiBMax                                       : 100
MemoryInGiBMin                                       : 
MemoryInGiBPerVcpuMax                                : 
MemoryInGiBPerVcpuMin                                : 
Name                                                 : testFleet
NetworkBandwidthInMbpsMax                            : 
NetworkBandwidthInMbpsMin                            : 
NetworkInterfaceCountMax                             : 
NetworkInterfaceCountMin                             : 
PlanName                                             : 
PlanProduct                                          : 
PlanPromotionCode                                    : 
PlanPublisher                                        : 
PlanVersion                                          : 
ProvisioningState                                    : Succeeded
RdmaNetworkInterfaceCountMax                         : 
RdmaNetworkInterfaceCountMin                         : 
RegularPriorityProfileAllocationStrategy             : 
RegularPriorityProfileCapacity                       : 
RegularPriorityProfileMinCapacity                    : 
ResourceGroupName                                    : test-fleet
SpotPriorityProfileAllocationStrategy                : LowestPrice
SpotPriorityProfileCapacity                          : 1
SpotPriorityProfileEvictionPolicy                    : Delete
SpotPriorityProfileMaintain                          : True
SpotPriorityProfileMaxPricePerVM                     : 
SpotPriorityProfileMinCapacity                       : 
SystemDataCreatedAt                                  : 
SystemDataCreatedBy                                  : 
SystemDataCreatedByType                              : 
SystemDataLastModifiedAt                             : 
SystemDataLastModifiedBy                             : 
SystemDataLastModifiedByType                         : 
Tag                                                  : {
                                                       }
TimeCreated                                          : 11/18/2024 2:47:47 AM
Type                                                 : Microsoft.AzureFleet/fleets
UniqueId                                             : a20afdb9-995b-417c-9f2c-5facc83a7c80
VCpuCountMax                                         : 5
VCpuCountMin                                         : 
VMAttributeAcceleratorManufacturer                   : 
VMAttributeAcceleratorSupport                        : Included
VMAttributeAcceleratorType                           : 
VMAttributeArchitectureType                          : 
VMAttributeBurstableSupport                          : Excluded
VMAttributeCpuManufacturer                           : 
VMAttributeExcludedVmsize                            : 
VMAttributeLocalStorageDiskType                      : 
VMAttributeLocalStorageSupport                       : Included
VMAttributeRdmaSupport                               : Excluded
VMAttributeVmcategory                                : 
VMSizesProfile                                       : {{
                                                         "name": "Standard_D2s_v3"
                                                       }, {
                                                         "name": "Standard_D4s_v3"
                                                       }, {
                                                         "name": "Standard_E2s_v3"
                                                       }}
Zone                                                 : 
```

This command creates a new compute fleet resource by ResourceGroupName and FleetName.

### Example 2: Create a new compute fleet resource by Identity
```powershell
$fleet = Get-AzComputeFleet -SubscriptionId "ca8520e1-3c83-4b64-bb99-60a64673daa3" -ResourceGroupName "test-fleet" -FleetName "testFleet"
New-AzComputeFleet -InputObject $fleet -Resource $fleet
```

```output
AcceleratorCountMax                                  : 5
AcceleratorCountMin                                  : 
AdditionalLocationProfile                            : 
AdditionalVirtualMachineCapabilityHibernationEnabled : 
AdditionalVirtualMachineCapabilityUltraSsdEnabled    : 
ComputeProfileBaseVirtualMachineProfile              : {
                                                         "osProfile": {
                                                           "computerNamePrefix": "testfleet",
                                                           "adminUsername": "azureuser"
                                                         },
                                                         "storageProfile": {
                                                           "imageReference": {
                                                             "publisher": "canonical",
                                                             "offer": "ubuntu-24_04-lts",
                                                             "sku": "server",
                                                             "version": "latest"
                                                           },
                                                           "osDisk": {
                                                             "managedDisk": {
                                                               "storageAccountType": "Premium_LRS"
                                                             },
                                                             "caching": "ReadWrite",
                                                             "createOption": "fromImage",
                                                             "osType": "Linux"
                                                           }
                                                         },
                                                         "networkProfile": {
                                                           "networkInterfaceConfigurations": [
                                                             {
                                                               "properties": {
                                                                 "networkSecurityGroup": {
                                                                   "id": "/subscriptions/ca8520e1-3c83-4b64-bb99-60a64673daa3/resourceGroups/t
                                                       est-fleet/providers/Microsoft.Network/networkSecurityGroups/basicNsgvnet-centralus-2-ni
                                                       c01"
                                                                 },
                                                                 "primary": true,
                                                                 "enableAcceleratedNetworking": false,
                                                                 "ipConfigurations": [
                                                                   {
                                                                     "properties": {
                                                                       "subnet": {
                                                                         "id": "/subscriptions/ca8520e1-3c83-4b64-bb99-60a64673daa3/resourceGr
                                                       oups/test-fleet/providers/Microsoft.Network/virtualNetworks/vnet-centralus-2/subnets/sn
                                                       et-centralus-1"
                                                                       },
                                                                       "publicIPAddressConfiguration": {
                                                                         "properties": {
                                                                           "idleTimeoutInMinutes": 15
                                                                         },
                                                                         "name": "vnet-centralus-2-nic01-publicip"
                                                                       },
                                                                       "primary": true
                                                                     },
                                                                     "name": "vnet-centralus-2-nic01-ipConfig"
                                                                   }
                                                                 ]
                                                               },
                                                               "name": "vnet-centralus-2-nic01"
                                                             }
                                                           ],
                                                           "networkApiVersion": "2020-11-01"
                                                         },
                                                         "securityProfile": {
                                                           "uefiSettings": {
                                                             "secureBootEnabled": true,
                                                             "vTpmEnabled": false
                                                           },
                                                           "securityType": "TrustedLaunch"
                                                         },
                                                         "licenseType": "None"
                                                       }
ComputeProfileComputeApiVersion                      : 2023-09-01
ComputeProfilePlatformFaultDomainCount               : 1
DataDiskCountMax                                     : 
DataDiskCountMin                                     : 
Id                                                   : /subscriptions/ca8520e1-3c83-4b64-bb99-60a64673daa3/resourceGroups/test-fleet/providers
                                                       /Microsoft.AzureFleet/fleets/testFleet
IdentityPrincipalId                                  : 
IdentityTenantId                                     : 
IdentityType                                         : 
IdentityUserAssignedIdentity                         : {
                                                       }
LocalStorageInGiBMax                                 : 
LocalStorageInGiBMin                                 : 
Location                                             : centralus
MemoryInGiBMax                                       : 100
MemoryInGiBMin                                       : 
MemoryInGiBPerVcpuMax                                : 
MemoryInGiBPerVcpuMin                                : 
Name                                                 : testFleet
NetworkBandwidthInMbpsMax                            : 
NetworkBandwidthInMbpsMin                            : 
NetworkInterfaceCountMax                             : 
NetworkInterfaceCountMin                             : 
PlanName                                             : 
PlanProduct                                          : 
PlanPromotionCode                                    : 
PlanPublisher                                        : 
PlanVersion                                          : 
ProvisioningState                                    : Succeeded
RdmaNetworkInterfaceCountMax                         : 
RdmaNetworkInterfaceCountMin                         : 
RegularPriorityProfileAllocationStrategy             : 
RegularPriorityProfileCapacity                       : 
RegularPriorityProfileMinCapacity                    : 
ResourceGroupName                                    : test-fleet
SpotPriorityProfileAllocationStrategy                : LowestPrice
SpotPriorityProfileCapacity                          : 1
SpotPriorityProfileEvictionPolicy                    : Delete
SpotPriorityProfileMaintain                          : True
SpotPriorityProfileMaxPricePerVM                     : 
SpotPriorityProfileMinCapacity                       : 
SystemDataCreatedAt                                  : 
SystemDataCreatedBy                                  : 
SystemDataCreatedByType                              : 
SystemDataLastModifiedAt                             : 
SystemDataLastModifiedBy                             : 
SystemDataLastModifiedByType                         : 
Tag                                                  : {
                                                       }
TimeCreated                                          : 11/18/2024 2:47:47 AM
Type                                                 : Microsoft.AzureFleet/fleets
UniqueId                                             : a20afdb9-995b-417c-9f2c-5facc83a7c80
VCpuCountMax                                         : 5
VCpuCountMin                                         : 
VMAttributeAcceleratorManufacturer                   : 
VMAttributeAcceleratorSupport                        : Included
VMAttributeAcceleratorType                           : 
VMAttributeArchitectureType                          : 
VMAttributeBurstableSupport                          : Excluded
VMAttributeCpuManufacturer                           : 
VMAttributeExcludedVmsize                            : 
VMAttributeLocalStorageDiskType                      : 
VMAttributeLocalStorageSupport                       : Included
VMAttributeRdmaSupport                               : Excluded
VMAttributeVmcategory                                : 
VMSizesProfile                                       : {{
                                                         "name": "Standard_D2s_v3"
                                                       }, {
                                                         "name": "Standard_D4s_v3"
                                                       }, {
                                                         "name": "Standard_E2s_v3"
                                                       }}
Zone                                                 : 
```

This command creates a new compute fleet resource by Identity.

