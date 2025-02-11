---
external help file:
Module Name: Az.ScVmm
online version: https://learn.microsoft.com/powershell/module/az.scvmm/add-azscvmmnetworkinterface
schema: 2.0.0
---

# Add-AzScVmmNetworkInterface

## SYNOPSIS
The operation to Create a virtual machine network interface.

## SYNTAX

```
Add-AzScVmmNetworkInterface -MachineId <String> -NetworkProfileNetworkInterface <INetworkInterfaceUpdate[]>
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to Create a virtual machine network interface.

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

### -NetworkProfileNetworkInterface
Gets or sets the list of network interfaces associated with the virtual machine.
To construct, see NOTES section for NETWORKPROFILENETWORKINTERFACE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.INetworkInterfaceUpdate[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IVirtualMachineInstance

## NOTES

## RELATED LINKS

