---
external help file:
Module Name: Az.ComputeFleet
online version: https://learn.microsoft.com/powershell/module/az.computefleet/update-azcomputefleet
schema: 2.0.0
---

# Update-AzComputeFleet

## SYNOPSIS
update a Fleet

## SYNTAX

### UpdateViaIdentity (Default)
```
Update-AzComputeFleet -InputObject <IComputeFleetIdentity> -Resource <IFleet> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzComputeFleet -Name <String> -ResourceGroupName <String> -Resource <IFleet> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
update a Fleet

## EXAMPLES

### Example 1: Update a compute fleet resource by ResourceGroupName and FleetName
```powershell
$fleet = Get-AzComputeFleet -SubscriptionId $env.SubscriptionId -ResourceGroupName "test-fleet" -FleetName "testFleet"
$securedPassword = ConvertTo-SecureString -AsPlainText "[Sanitized]" -Force
$fleet.ComputeProfileBaseVirtualMachineProfile.OSProfileAdminPassword = $securedPassword
$fleet.AcceleratorCountMax = 3
Update-AzComputeFleet -ResourceGroupName "test-fleet" -FleetName "testFleet" -Resource $fleet
```

```output
AcceleratorCountMax                                  : 3
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
TimeCreated                                          : 11/14/2024 11:33:52 PM
Type                                                 : Microsoft.AzureFleet/fleets
UniqueId                                             : 7bbd33a5-6486-406d-9fe1-e6b051f28cc3
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

This command updates a compute fleet resource by ResourceGroupName and FleetName.

### Example 2: Update a compute fleet resource by Identity
```powershell
$fleet = Get-AzComputeFleet -SubscriptionId "ca8520e1-3c83-4b64-bb99-60a64673daa3" -ResourceGroupName "test-fleet" -FleetName "testFleet"
$securedPassword = ConvertTo-SecureString -AsPlainText "[Sanitized]" -Force
$fleet.ComputeProfileBaseVirtualMachineProfile.OSProfileAdminPassword = $securedPassword
$fleet.MemoryInGiBMax = 500
Update-AzComputeFleet -InputObject $fleet -Resource $fleet
```

```output
AcceleratorCountMax                                  : 3
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
MemoryInGiBMax                                       : 500
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
TimeCreated                                          : 11/14/2024 11:33:52 PM
Type                                                 : Microsoft.AzureFleet/fleets
UniqueId                                             : 7bbd33a5-6486-406d-9fe1-e6b051f28cc3
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

This command updates a compute fleet resource by identity.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeFleetIdentity
Parameter Sets: UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Compute Fleet

```yaml
Type: System.String
Parameter Sets: Update
Aliases: FleetName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Resource
An Compute Fleet resource

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleet
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Update
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeFleetIdentity

### Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleet

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleet

## NOTES

## RELATED LINKS

