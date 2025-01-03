---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/Az.NetworkCloud/new-AzNetworkCloudBareMetalMachineConfigurationDataObject
schema: 2.0.0
---

# New-AzNetworkCloudBareMetalMachineConfigurationDataObject

## SYNOPSIS
Create an in-memory object for BareMetalMachineConfigurationData.

## SYNTAX

```
New-AzNetworkCloudBareMetalMachineConfigurationDataObject -BmcCredentialsPassword <SecureString>
 -BmcCredentialsUsername <String> -BmcMacAddress <String> -BootMacAddress <String> -RackSlot <Int64>
 -SerialNumber <String> [-MachineDetail <String>] [-MachineName <String>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for BareMetalMachineConfigurationData.

## EXAMPLES

### Example 1: Create an in-memory object for BareMetalMachineConfigurationData.
```powershell
$password = ConvertTo-SecureString "********" -AsPlainText -Force

New-AzNetworkCloudBareMetalMachineConfigurationDataObject -BmcCredentialsPassword $password -BmcCredentialsUsername username -BmcMacAddress "00:BB:CC:DD:EE:FF" -BootMacAddress "00:BB:CC:DD:EE:FF" -RackSlot 1 -SerialNumber serialNumber -MachineDetail machineDetail -MachineName machineName
```

```output
BmcConnectionString BmcMacAddress     BootMacAddress    MachineDetail MachineName RackSlot SerialNumber
------------------- -------------     --------------    ------------- ----------- -------- ------------
                    00:BB:CC:DD:EE:FF 00:BB:CC:DD:EE:FF machineDetail machineName 1        serialNumber
```

Create an in-memory object for BareMetalMachineConfigurationData.

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.BareMetalMachineConfigurationData

## NOTES

## RELATED LINKS
