---
external help file: Az.ConnectedVMware-help.xml
Module Name: Az.ConnectedVMware
online version: https://learn.microsoft.com/powershell/module/az.connectedvmware/get-azconnectedvmwarevm
schema: 2.0.0
---

# Get-AzConnectedVMwareVM

## SYNOPSIS
Retrieves information about a virtual machine instance.

## SYNTAX

```
Get-AzConnectedVMwareVM -MachineId <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Retrieves information about a virtual machine instance.

## EXAMPLES

### Example 1: Get a specific VM
```powershell
Get-AzConnectedVMwareVM -MachineId "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.HybridCompute/machines/test-machine"
```

```output
ExtendedLocationName                    : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourcegroups/test-rg/providers/microsoft.extendedlocation/customlocations/test-cl
ExtendedLocationType                    : CustomLocation
HardwareProfileCpuHotAddEnabled         : True
HardwareProfileCpuHotRemoveEnabled      : False
HardwareProfileMemoryHotAddEnabled      : True
HardwareProfileMemorySizeMb             : 1024
HardwareProfileNumCoresPerSocket        : 1
HardwareProfileNumCpus                  : 1
Id                                      : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.HybridCompute/machines/test-machine/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineInstances/default
InfrastructureProfileCustomResourceName : d04a3534-2dfa-42c8-8959-83796a1bcac1
InfrastructureProfileFirmwareType       : bios
InfrastructureProfileFolderPath         : ArcPrivateClouds-67
InfrastructureProfileInstanceUuid       : d04a3534-2dfa-42c8-8959-83796a1bcac1
InfrastructureProfileInventoryItemId    :
InfrastructureProfileMoName             : test-machine
InfrastructureProfileMoRefId            : vm-1529269
InfrastructureProfileSmbiosUuid         : 4215b305-5f69-959b-0620-16a5bd8c5fc9
InfrastructureProfileTemplateId         : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/virtualMachineTemplates/test-tmpl
InfrastructureProfileVCenterId          : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/vcenters/test-vc
Name                                    : default
NetworkProfileNetworkInterface          : {{
                                            "ipSettings": {
                                              "allocationMethod": "unset"
                                            },
                                            "name": "nic_1",
                                            "label": "Network adapter 1",
                                            "ipAddresses": [ "10.150.176.100", "fe80::250:56ff:fe95:ecbc", "2404:f801:4800:14:250:56ff:fe95:ecbc" ],
                                            "macAddress": "00:50:56:95:ec:bc",
                                            "networkId": "/subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/VirtualNetworks/test-vnet",
                                            "nicType": "vmxnet3",
                                            "powerOnBoot": "enabled",
                                            "networkMoRefId": "network-563661",
                                            "networkMoName": "VM Network",
                                            "deviceKey": 4000
                                          }}
OSProfileAdminPassword                  :
OSProfileAdminUsername                  :
OSProfileComputerName                   : test-machine
OSProfileGuestId                        : ubuntu64Guest
OSProfileOssku                          : Ubuntu Linux (64-bit)
OSProfileOstype                         : Linux
OSProfileToolsRunningStatus             : guestToolsRunning
OSProfileToolsVersion                   : 10304
OSProfileToolsVersionStatus             : guestToolsUnmanaged
PlacementProfileClusterId               : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/Clusters/test-cluster
PlacementProfileDatastoreId             :
PlacementProfileHostId                  : /subscriptions/204898ee-cd13-4332-b9d4-55ca5c25496d/resourceGroups/test-rg/providers/Microsoft.ConnectedVMwarevSphere/Hosts/test-host
PlacementProfileResourcePoolId          :
PowerState                              : poweredOn
ProvisioningState                       : Succeeded
ResourceGroupName                       : test-rg
ResourceUid                             : 4c9c3021-d32e-48f9-b8ac-9cb14ebf6d75
Statuses                                : {{
                                            "type": "CustomizationCompleted",
                                            "status": "True",
                                            "lastUpdatedAt": "2023-10-06T12:29:36.0000000Z"
                                          }, {
                                            "type": "Ready",
                                            "status": "True",
                                            "lastUpdatedAt": "2023-10-06T12:29:45.2429702Z"
                                          }, {
                                            "type": "Idle",
                                            "status": "True",
                                            "lastUpdatedAt": "2023-10-06T12:29:45.2429702Z"
                                          }}
StorageProfileDisk                      : {{
                                            "name": "disk_1",
                                            "label": "Hard disk 1",
                                            "diskObjectId": "7435-2000",
                                            "diskSizeGB": 10,
                                            "deviceKey": 2000,
                                            "diskMode": "persistent",
                                            "controllerKey": 1000,
                                            "unitNumber": 0,
                                            "diskType": "flat"
                                          }}
StorageProfileScsiController            : {{
                                            "type": "lsilogic",
                                            "controllerKey": 1000,
                                            "scsiCtlrUnitNumber": 7,
                                            "sharing": "noSharing"
                                          }}
SystemDataCreatedAt                     : 10/6/2023 12:28:17 PM
SystemDataCreatedBy                     : xyz
SystemDataCreatedByType                 : User
SystemDataLastModifiedAt                : 10/6/2023 12:48:40 PM
SystemDataLastModifiedBy                : ac9dc5fe-b644-4832-9d03-d9f1ab70c5f7
SystemDataLastModifiedByType            : Application
Type                                    : microsoft.connectedvmwarevsphere/virtualmachineinstances
UefiSettingSecureBootEnabled            : False
```

This command gets a VM Instances of machine names `test-machine`

## PARAMETERS

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

### -MachineId
The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedVMware.Models.IVirtualMachineInstance

## NOTES

## RELATED LINKS
