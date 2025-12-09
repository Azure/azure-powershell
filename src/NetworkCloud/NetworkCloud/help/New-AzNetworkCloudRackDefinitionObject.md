---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/Az.NetworkCloud/new-aznetworkcloudrackdefinitionobject
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

### Example 1: Create rack definition with basic configuration
```powershell
$bmConfig = New-AzNetworkCloudBareMetalMachineConfigurationDataObject -BmcCredentialsPassword (ConvertTo-SecureString -String "P@ssw0rd123!" -AsPlainText -Force) -BmcCredentialsUsername "admin" -BmcMacAddress "00:1a:2b:3c:4d:5e" -BootMacAddress "00:1a:2b:3c:4d:5f" -RackSlot 1 -SerialNumber "ABC123"
New-AzNetworkCloudRackDefinitionObject -NetworkRackId "/subscriptions/subscription-id/resourceGroups/rg/providers/Microsoft.NetworkCloud/networkRacks/rack1" -RackSkuId "sku-123" -RackSerialNumber "RACK-001" -AvailabilityZone "1" -BareMetalMachineConfigurationData @($bmConfig)
```

```output
AvailabilityZone                    : 1
BareMetalMachineConfigurationData   : {Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.BareMetalMachineConfigurationData}
NetworkRackId                       : /subscriptions/subscription-id/resourceGroups/rg/providers/Microsoft.NetworkCloud/networkRacks/rack1
RackLocation                        : 
RackSerialNumber                    : RACK-001
RackSkuId                           : sku-123
StorageApplianceConfigurationData   : {}
```

This example creates a rack definition with bare metal machine configuration.

### Example 2: Create rack definition with storage appliance configuration
```powershell
$storageConfig = @{
    serialNumber = "STORAGE-001"
    adminCredentials = @{
        username = "admin"
        password = "SecurePass123!"
    }
}
New-AzNetworkCloudRackDefinitionObject -NetworkRackId "/subscriptions/subscription-id/resourceGroups/rg/providers/Microsoft.NetworkCloud/networkRacks/rack2" -RackSkuId "sku-456" -RackSerialNumber "RACK-002" -RackLocation "DataCenter-A" -StorageApplianceConfigurationData @($storageConfig)
```

```output
AvailabilityZone                    : 
BareMetalMachineConfigurationData   : {}
NetworkRackId                       : /subscriptions/subscription-id/resourceGroups/rg/providers/Microsoft.NetworkCloud/networkRacks/rack2
RackLocation                        : DataCenter-A
RackSerialNumber                    : RACK-002
RackSkuId                           : sku-456
StorageApplianceConfigurationData   : {System.Collections.Hashtable}
```

This example creates a rack definition with storage appliance configuration and location information.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.IBareMetalMachineConfigurationData[]
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.IStorageApplianceConfigurationData[]
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.RackDefinition

## NOTES

## RELATED LINKS
