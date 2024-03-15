---
external help file: Az.StackHCI-help.xml
Module Name: Az.StackHCI
online version: https://learn.microsoft.com/powershell/module/az.stackhci/add-azstackhcivmattestation
schema: 2.0.0
---

# Add-AzStackHCIVMAttestation

## SYNOPSIS
Add-AzStackHCIVMAttestation configures guests for AzureStack HCI IMDS Attestation.

## SYNTAX

### VMName (Default)
```
Add-AzStackHCIVMAttestation [-VMName] <String[]> [-Force] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### VMObject
```
Add-AzStackHCIVMAttestation [-Force] [-VM] <Object[]> [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### AddAll
```
Add-AzStackHCIVMAttestation [-Force] [-AddAll] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Add-AzStackHCIVMAttestation configures guests for AzureStack HCI IMDS Attestation.

## EXAMPLES

### Example 1:
```powershell
Add-AzStackHCIVMAttestation -AddAll
```

```output
Name        AttestationHost    Status
----        ---------------    ------
183hcinode1 HCINODE2        Connected
bhat2       HCINODE2        Connected
ppnt3n1     HCINODE2        Connected
ppt3n0      HCINODE2        Connected
ppt5pn0     HCINODE2        Connected
ppt6pn0     HCINODE2        Connected
ppt7pn0     HCINODE2        Connected
```

Adding all guests on current node

### Example 2:
```powershell
Invoke-Command -ScriptBlock {Add-AzStackHCIVMAttestation -VMName "bhat2", "ppt7pn0"} -ComputerName "HCINODE2"
```

```output
Name            : bhat2
AttestationHost : HCINODE2
Status          : Connected
PSComputerName  : HCINODE2
RunspaceId      : 1ec3f1f5-832d-47d3-a5db-2a43ef3fdfdf

Name            : ppt7pn0
AttestationHost : HCINODE2
Status          : Connected
PSComputerName  : HCINODE2
RunspaceId      : 1ec3f1f5-832d-47d3-a5db-2a43ef3fdfdf
```

Invoking from the management node/WAC

## PARAMETERS

### -AddAll
Specifies a switch that will add all current guest VMs on host to IMDS Attestation on the current node.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AddAll
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
