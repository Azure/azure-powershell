---
external help file: Az.StackHCI-help.xml
Module Name: Az.StackHCI
online version: https://docs.microsoft.com/powershell/module/az.stackhci/disable-azstackhciattestation
schema: 2.0.0
---

# Disable-AzStackHCIAttestation

## SYNOPSIS
Disable-AzStackHCIAttestation disables IMDS Attestation on the host

## SYNTAX

```
Disable-AzStackHCIAttestation [[-ComputerName] <String>] [-Credential <PSCredential>] [-RemoveVM]
 [<CommonParameters>]
```

## DESCRIPTION
Disable-AzStackHCIAttestation disables IMDS Attestation on the host

## EXAMPLES

### EXAMPLE 1
```powershell
C:\PS\>Disable-AzStackHCIAttestation -Remove
```

Remove all guests from IMDS Attestation before disabling on cluster nodes.

### EXAMPLE 2
```powershell
C:\PS\>Disable-AzStackHCIAttestation -ComputerName "host1"
```

## PARAMETERS

### -ComputerName
Specifies the AzureStack HCI host to perform the operation on.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Credential
Specifies the credential for the ComputerName.
Default is the current user executing the Cmdlet.

```yaml
Type: PSCredential
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: [System.Management.Automation.PSCredential]::Empty
Accept pipeline input: False
Accept wildcard characters: False
```

### -RemoveVM
Specifies the guests on each node should be removed from IMDS Attestation before disabling on cluster.
Disable cannot continue before guests are removed.

```yaml
Type: SwitchParameter
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
### PSCustomObject. Returns following Properties in PSCustomObject
### Cluster:     Name of cluster
### Node:        Name of the host.
### Attestation: IMDS Attestation status.

## NOTES

## RELATED LINKS
