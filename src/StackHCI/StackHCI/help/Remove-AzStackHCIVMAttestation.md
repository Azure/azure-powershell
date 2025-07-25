---
external help file: Az.StackHCI-help.xml
Module Name: Az.StackHCI
online version: https://learn.microsoft.com/powershell/module/az.stackhci/remove-azstackhcivmattestation
schema: 2.0.0
---

# Remove-AzStackHCIVMAttestation

## SYNOPSIS
Remove-AzStackHCIVMAttestation removes guests from AzureStack HCI IMDS Attestation.

## SYNTAX

### VMName (Default)
```
Remove-AzStackHCIVMAttestation [-VMName] <String[]> [-Force] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### VMObject
```
Remove-AzStackHCIVMAttestation [-Force] [-VM] <Object[]> [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### RemoveAll
```
Remove-AzStackHCIVMAttestation [-Force] [-RemoveAll] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Remove-AzStackHCIVMAttestation removes guests from AzureStack HCI IMDS Attestation.

## EXAMPLES

### Example 1:
```powershell
Remove-AzStackHCIVMAttestation -RemoveAll
```

```output
Name        AttestationHost       Status
----        ---------------       ------
183hcinode1 HCINODE2        Disconnected
bhat2       HCINODE2        Disconnected
ppnt3n1     HCINODE2        Disconnected
ppt3n0      HCINODE2        Disconnected
ppt5pn0     HCINODE2        Disconnected
ppt6pn0     HCINODE2        Disconnected
ppt7pn0     HCINODE2        Disconnected
```

Removing all guests on current node

## PARAMETERS

### -Force
No confirmations.

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

### -RemoveAll
Specifies a switch that will remove all guest VMs from Attestation on the current node

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RemoveAll
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VM
Specifies an array of VM objects from Get-VM.

```yaml
Type: System.Object[]
Parameter Sets: VMObject
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -VMName
Specifies an array of guest VMs to enable.

```yaml
Type: System.String[]
Parameter Sets: VMName
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
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

### System.Object[]

### System.String[]

## OUTPUTS

### System.Management.Automation.PSObject

## NOTES

## RELATED LINKS
