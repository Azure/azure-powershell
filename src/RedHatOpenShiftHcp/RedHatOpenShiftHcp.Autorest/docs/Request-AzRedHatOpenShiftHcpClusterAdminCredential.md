---
external help file:
Module Name: Az.RedHatOpenShiftHcp
online version: https://learn.microsoft.com/powershell/module/az.redhatopenshifthcp/request-azredhatopenshifthcpclusteradmincredential
schema: 2.0.0
---

# Request-AzRedHatOpenShiftHcpClusterAdminCredential

## SYNOPSIS
Request a temporary admin kubeconfig for the cluster and write it ready-to-use.

## SYNTAX

### RequestExpanded (Default)
```
Request-AzRedHatOpenShiftHcpClusterAdminCredential -HcpOpenShiftClusterName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-Context <String>] [-Force] [-OutFile <String>]
 [-PassThru] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RequestViaIdentityExpanded
```
Request-AzRedHatOpenShiftHcpClusterAdminCredential -InputObject <IRedHatOpenShiftHcpIdentity>
 [-Context <String>] [-Force] [-OutFile <String>] [-PassThru] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
One-shot admin credential: generates an RSA-4096 key + CSR locally, sends only the CSR (the private key
never leaves this machine), splices the signed key back into the returned kubeconfig, names the context
'\<cluster\>-admin', and merges it into your kubeconfig (AKS-style).
Replaces the generated cmdlet of the
same name (hidden via the README directive; still callable as
Az.RedHatOpenShiftHcp.internal\Request-AzRedHatOpenShiftHcpClusterAdminCredential).

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

### -Context
Context name to assign.
Defaults to '\<cluster\>-admin'.

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

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use SubscriptionId instead.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Replace the target kubeconfig file entirely instead of merging into it.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: OverwriteExisting

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HcpOpenShiftClusterName
The name of the HcpOpenShiftCluster.

```yaml
Type: System.String
Parameter Sets: RequestExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IRedHatOpenShiftHcpIdentity
Parameter Sets: RequestViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OutFile
Path to write the kubeconfig to.
Defaults to $env:KUBECONFIG (first entry) or ~/.kube/config.
Use '-' to print the kubeconfig to stdout instead of writing a file.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: f

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Also emit the raw credential object (includes ExpirationTimestamp).

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: RequestExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
Defaults to the current Az context subscription.

```yaml
Type: System.String
Parameter Sets: RequestExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IRedHatOpenShiftHcpIdentity

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS

