---
external help file:
Module Name: Az.StackHCI
online version: https://docs.microsoft.com/powershell/module/az.stackhci/get-azstackhciremotesupportaccess
schema: 2.0.0
---

# Get-AzStackHCIRemoteSupportAccess

## SYNOPSIS
Gets Remote Support Access.

## SYNTAX

```
Get-AzStackHCIRemoteSupportAccess [-Cluster] [-IncludeExpired] [<CommonParameters>]
```

## DESCRIPTION
Gets remote support access.

## EXAMPLES

### Example 1: 
```powershell
Get-AzStackHCIRemoteSupportAccess -Cluster
```

```output
Microsoft.AzureStack.Deployment.RemoteSupport is loaded already ...
Getting RemoteSupport Access on this node
Retrieving Remote Support access. IncludeExpired is set to 'False'


State         : Active
CreatedAt     : 3/29/2022 10:30:55 AM +00:00
UpdatedAt     : 3/29/2022 10:30:55 AM +00:00
TargetService : PowerShell
AccessLevel   : Diagnostics
ExpiresAt     : 3/30/2022 10:30:55 AM +00:00
SasCredential :
```

Get remote access across a cluster

### Example 2: 
```powershell
Get-AzStackHCIRemoteSupportAccess -Cluster -IncludeExpired
```

```output
Microsoft.AzureStack.Deployment.RemoteSupport is loaded already ...
Getting RemoteSupport Access on this node
Retrieving Remote Support access. IncludeExpired is set to 'True'


State         : Active
CreatedAt     : 3/29/2022 10:30:55 AM +00:00
UpdatedAt     : 3/29/2022 10:30:55 AM +00:00
TargetService : PowerShell
AccessLevel   : Diagnostics
ExpiresAt     : 3/30/2022 10:30:55 AM +00:00
SasCredential :
```

Get remote access across a cluster with expired entries

## PARAMETERS

### -Cluster
Optional.
Defaults to false.
Indicates whether to show remote support sessions across cluster.

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

### -IncludeExpired
Optional.
Defaults to false.
Indicates whether to include past expired entries.

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

### System.Boolean

## NOTES

ALIASES

## RELATED LINKS

