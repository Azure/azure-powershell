---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/Az.NetworkCloud/new-AzNetworkCloudRackDefinitionObject
schema: 2.0.0
---

# New-AzNetworkCloudRackDefinitionObject

## SYNOPSIS
Create an in-memory object for RackDefinition.

## SYNTAX

```
New-AzNetworkCloudRackDefinitionObject -NetworkRackId <String> -RackSerialNumber <String> -RackSkuId <String>
 [-AvailabilityZone <String>] [-BareMetalMachineConfigurationData <IBareMetalMachineConfigurationData[]>]
 [-RackLocation <String>] [-StorageApplianceConfigurationData <IStorageApplianceConfigurationData[]>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for RackDefinition.

## EXAMPLES

### Example 1: Create an in-memory object for RackDefinition.
```powershell
$password = ConvertTo-SecureString "1qaz@WSX" -AsPlainText
$bmmConfigurationData = New-AzNetworkCloudBareMetalMachineConfigurationDataObject -BmcCredentialsPassword $password -BmcCredentialsUsername "username" -BmcMacAddress "00:BB:CC:DD:EE:FF" -BootMacAddress "00:BB:CC:DD:EE:FF" -RackSlot 1 -SerialNumber "serialNumber" -MachineDetail "machineDetail" -MachineName "machineName"
$saConfigurationData = New-AzNetworkCloudStorageApplianceConfigurationDataObject -AdminCredentialsPassword $password -AdminCredentialsUsername "username" -RackSlot 1 -SerialNumber "serialNumber" -StorageApplianceName "storageApplianceName"

$object = New-AzNetworkCloudRackDefinitionObject -NetworkRackId "/subscriptions/subscriptionId/resourceGroups/resourceGroup/providers/Microsoft.Network/virtualNetworks/vNet/subnets/Subnet" -RackSerialNumber "aa5678" -RackSkuId "/subscriptions/subscriptionId/providers/Microsoft.NetworkCloud/rackSkus/VNearEdge1_Compute_DellR750_16C2M" -AvailabilityZone "1" -BareMetalMachineConfigurationData $bmmConfigurationData -RackLocation "Foo Datacenter, Floor 3, Aisle 9, Rack 2" -StorageApplianceConfigurationData $saConfigurationData

Write-Host ($object | Format-List | Out-String)
```

```output
AvailabilityZone                  : 1
BareMetalMachineConfigurationData : {{
                                      "bmcCredentials": {
                                        "password": "redacted",
                                        "username": "username"
                                      },
                                      "bmcMacAddress": "00:BB:CC:DD:EE:FF",
                                      "bootMacAddress": "00:BB:CC:DD:EE:FF",
                                      "machineDetails": "machineDetail",
                                      "machineName": "machineName",
                                      "rackSlot": 1,
                                      "serialNumber": "serialNumber"
                                    }}
NetworkRackId                     : /subscriptions/subscription/resourceGroups/resourceGroup/providers/Microsoft.Network/virtualNetworks/vNet/subnets/Subnet
RackLocation                      : Foo Datacenter, Floor 3, Aisle 9, Rack 2
RackSerialNumber                  : aa5678
RackSkuId                         : /subscriptions/subscriptionId/providers/Microsoft.NetworkCloud/rackSkus/VNearEdge1_Compute_DellR750_16C2M
StorageApplianceConfigurationData : {{
                                      "adminCredentials": {
                                        "password": "redacted",
                                        "username": "username"
                                      },
                                      "rackSlot": 1,
                                      "serialNumber": "serialNumber",
                                      "storageApplianceName": "storageApplianceName"
                                    }}
```

Create an in-memory object for RackDefinition.

## PARAMETERS

### -AvailabilityZone
The zone name used for this rack when created.
Availability zones are used for workload placement.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BareMetalMachineConfigurationData
The unordered list of bare metal machine configuration.
To construct, see NOTES section for BAREMETALMACHINECONFIGURATIONDATA properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20230701.IBareMetalMachineConfigurationData[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkRackId
The resource ID of the network rack that matches this rack definition.

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

### -RackLocation
The free-form description of the rack's location.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RackSerialNumber
The unique identifier for the rack within Network Cloud cluster.
An alternate unique alphanumeric value other than a serial number may be provided if desired.

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

### -RackSkuId
The resource ID of the sku for the rack being added.

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

### -StorageApplianceConfigurationData
The list of storage appliance configuration data for this rack.
To construct, see NOTES section for STORAGEAPPLIANCECONFIGURATIONDATA properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20230701.IStorageApplianceConfigurationData[]
Parameter Sets: (All)
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20230701.RackDefinition

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`BAREMETALMACHINECONFIGURATIONDATA <IBareMetalMachineConfigurationData[]>`: The unordered list of bare metal machine configuration.
  - `BmcCredentialsPassword <SecureString>`: The password of the administrator of the device used during initialization.
  - `BmcCredentialsUsername <String>`: The username of the administrator of the device used during initialization.
  - `BmcMacAddress <String>`: The MAC address of the BMC for this machine.
  - `BootMacAddress <String>`: The MAC address associated with the PXE NIC card.
  - `RackSlot <Int64>`: The slot the physical machine is in the rack based on the BOM configuration.
  - `SerialNumber <String>`: The serial number of the machine. Hardware suppliers may use an alternate value. For example, service tag.
  - `[MachineDetail <String>]`: The free-form additional information about the machine, e.g. an asset tag.
  - `[MachineName <String>]`: The user-provided name for the bare metal machine created from this specification.         If not provided, the machine name will be generated programmatically.

`STORAGEAPPLIANCECONFIGURATIONDATA <IStorageApplianceConfigurationData[]>`: The list of storage appliance configuration data for this rack.
  - `AdminCredentialsPassword <SecureString>`: The password of the administrator of the device used during initialization.
  - `AdminCredentialsUsername <String>`: The username of the administrator of the device used during initialization.
  - `RackSlot <Int64>`: The slot that storage appliance is in the rack based on the BOM configuration.
  - `SerialNumber <String>`: The serial number of the appliance.
  - `[StorageApplianceName <String>]`: The user-provided name for the storage appliance that will be created from this specification.

## RELATED LINKS

