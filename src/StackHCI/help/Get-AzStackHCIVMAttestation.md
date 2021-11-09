---
external help file: Az.StackHCI-help.xml
Module Name: Az.StackHCI
online version: https://docs.microsoft.com/powershell/module/az.stackhci/get-AzStackHCIVMAttestation
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

### EXAMPLE 1
```powershell
C:\PS\>Get-AzStackHCIVMAttestation
```

Get all guests on cluster.

### EXAMPLE 2
```powershell
C:\PS\>Get-AzStackHCIVMAttestation -Local
```

## PARAMETERS

### -Local
Only retrieve guests with Attestation from the node executing the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### PSCustomObject. Returns following Properties in PSCustomObject.
### Name:            Name of the VM.
### AttestationHost: Host that VM is currently connected.
### Status:          Connection status.
## NOTES

## RELATED LINKS
