---
external help file: Az.NetworkCloud-help.xml
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
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for RackDefinition.

## EXAMPLES

### Example 1: Create an in-memory object for RackDefinition.
```powershell
$password = ConvertTo-SecureString "********" -AsPlainText -Force
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
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IBareMetalMachineConfigurationData[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IStorageApplianceConfigurationData[]
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.RackDefinition

## NOTES

## RELATED LINKS
