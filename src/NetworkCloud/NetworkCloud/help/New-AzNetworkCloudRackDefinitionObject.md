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

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

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
