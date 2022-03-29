---
external help file:
Module Name: Az.StackHCI
online version: https://docs.microsoft.com/powershell/module/az.stackhci/disable-azstackhciattestation
schema: 2.0.0
---

# Disable-AzStackHCIAttestation

## SYNOPSIS
Disable-AzStackHCIAttestation disables IMDS Attestation on the host

## SYNTAX

```
Disable-AzStackHCIAttestation [[-ComputerName] <String>] [-Credential <PSCredential>] [-Force] [-RemoveVM]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Disable-AzStackHCIAttestation disables IMDS Attestation on the host

## EXAMPLES

### Example 1: 
```powershell
Disable-AzStackHCIAttestation -RemoveVM
```

```output
ComputerName   Status Expiration
------------   ------ ----------
HCINODE2     Inactive
```

Remove all guests from IMDS Attestation before disabling on cluster nodes.

## PARAMETERS

### -ComputerName
Specifies the AzureStack HCI host to perform the operation on.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
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
Default value: None
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
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RemoveVM
Specifies the guests on each node should be removed from IMDS Attestation before disabling on cluster.
Disable cannot continue before guests are removed.

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

### System.Management.Automation.PSObject

## NOTES

ALIASES

## RELATED LINKS

