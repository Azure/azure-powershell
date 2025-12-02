---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/Az.NetworkCloud/new-aznetworkcloudbaremetalmachineconfigurationdataobject
schema: 2.0.0
---

# New-AzNetworkCloudBareMetalMachineConfigurationDataObject

## SYNOPSIS
Create an in-memory object for BareMetalMachineConfigurationData.

## SYNTAX

```
New-AzNetworkCloudBareMetalMachineConfigurationDataObject -BmcCredentialsPassword <SecureString>
 -BmcCredentialsUsername <String> -BmcMacAddress <String> -BootMacAddress <String> -RackSlot <Int64>
 -SerialNumber <String> [-MachineDetail <String>] [-MachineName <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for BareMetalMachineConfigurationData.

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

### -BmcCredentialsPassword
The password of the administrator of the device used during initialization.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BmcCredentialsUsername
The username of the administrator of the device used during initialization.

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

### -BmcMacAddress
The MAC address of the BMC for this machine.

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

### -BootMacAddress
The MAC address associated with the PXE NIC card.

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

### -MachineDetail
The free-form additional information about the machine, e.g.
an asset tag.

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

### -MachineName
The user-provided name for the bare metal machine created from this specification.
If not provided, the machine name will be generated programmatically.

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

### -RackSlot
The slot the physical machine is in the rack based on the BOM configuration.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SerialNumber
The serial number of the machine.
Hardware suppliers may use an alternate value.
For example, service tag.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.BareMetalMachineConfigurationData

## NOTES

## RELATED LINKS
