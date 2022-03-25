---
external help file:
Module Name: Az.StackHCI
online version: https://docs.microsoft.com/powershell/module/az.stackhci/get-azstackhcivmattestation
schema: 2.0.0
---

# Get-AzStackHCIVMAttestation

## SYNOPSIS
Get-AzStackHCIVMAttestation shows a list of guests added to IMDS Attestation on a node.

## SYNTAX

```
Get-AzStackHCIVMAttestation [-Local] [<CommonParameters>]
```

## DESCRIPTION
Get-AzStackHCIVMAttestation shows a list of guests added to IMDS Attestation on a node.

## EXAMPLES

### Example 1: 
```powershell
Get-AzStackHCIVMAttestation
```

Get all guests with IMDS Attestation on cluster.

### Example 2: 
```powershell
Get-AzStackHCIVMAttestation -Local
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Management.Automation.PSObject

## NOTES

ALIASES

## RELATED LINKS

