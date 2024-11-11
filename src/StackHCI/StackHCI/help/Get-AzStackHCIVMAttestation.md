---
external help file: Az.StackHCI-help.xml
Module Name: Az.StackHCI
online version: https://learn.microsoft.com/powershell/module/az.stackhci/get-azstackhcivmattestation
schema: 2.0.0
---

# Get-AzStackHCIVMAttestation

## SYNOPSIS
Get-AzStackHCIVMAttestation shows a list of guests added to IMDS Attestation on a node.

## SYNTAX

```
Get-AzStackHCIVMAttestation [-Local] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get-AzStackHCIVMAttestation shows a list of guests added to IMDS Attestation on a node.

## EXAMPLES

### Example 1:
```powershell
Get-AzStackHCIVMAttestation
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

Get all guests with IMDS Attestation on cluster.

### Example 2:
```powershell
Get-AzStackHCIVMAttestation -Local
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

Gets guests with Attestation from the node executing the cmdlet.

## PARAMETERS

### -Local
Only retrieve guests with Attestation from the node executing the cmdlet.

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

### System.Management.Automation.PSObject

## NOTES

## RELATED LINKS
