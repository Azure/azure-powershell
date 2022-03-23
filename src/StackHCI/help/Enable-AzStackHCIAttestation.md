---
external help file: Az.StackHCI-help.xml
Module Name: Az.StackHCI
online version: https://docs.microsoft.com/powershell/module/az.stackhci/enable-azstackhciattestation
schema: 2.0.0
---

# Enable-AzStackHCIAttestation

## SYNOPSIS
Enable-AzStackHCIAttestation configures the host and enables specified guests for IMDS attestation.

## SYNTAX

```
Enable-AzStackHCIAttestation [[-ComputerName] <String>] [-Credential <PSCredential>] [-AddVM] [-Force]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Enable-AzStackHCIAttestation configures the host and enables specified guests for IMDS attestation.

## EXAMPLES

### EXAMPLE 1
```powershell
Enable-AzStackHCIAttestation -AddVM
```

Invoking on one of the cluster node.

### EXAMPLE 2
```powershell
Enable-AzStackHCIAttestation -ComputerName "host1" -AddVM
```

Invoking from WAC/Management node and adding all existing VMs cluster-wide

## PARAMETERS

### -AddVM
After enabling each cluster node for Attestation, add all guests on each node.

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

### -ComputerName
Specifies the AzureStack HCI host to perform the operation on.
Note: this host should match the host of VMName.

```yaml
Type: System.String
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
Type: System.Management.Automation.PSCredential
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: [System.Management.Automation.PSCredential]::Empty
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
No confirmation.

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

### PSCustomObject. Returns following Properties in PSCustomObject
### Cluster:     Name of cluster
### Node:        Name of the host.
### Attestation: IMDS Attestation status.
## NOTES

## RELATED LINKS
