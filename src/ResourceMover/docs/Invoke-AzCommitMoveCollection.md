---
external help file:
Module Name: Az.RegionMove
online version: https://docs.microsoft.com/en-us/powershell/module/az.regionmove/invoke-azcommitmovecollection
schema: 2.0.0
---

# Invoke-AzCommitMoveCollection

## SYNOPSIS


## SYNTAX

### CommitExpanded (Default)
```
Invoke-AzCommitMoveCollection -MoveCollectionName <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-MoveResource <String[]>] [-ValidateOnly] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Commit
```
Invoke-AzCommitMoveCollection -MoveCollectionName <String> -ResourceGroupName <String>
 -SubscriptionId <String> -Body <ICommitRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CommitViaIdentity
```
Invoke-AzCommitMoveCollection -InputObject <IRegionMoveIdentity> -Body <ICommitRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CommitViaIdentityExpanded
```
Invoke-AzCommitMoveCollection -InputObject <IRegionMoveIdentity> [-MoveResource <String[]>] [-ValidateOnly]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION


## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

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

### -Body
Defines the request body for commit operation.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.Api20191001Preview.ICommitRequest
Parameter Sets: Commit, CommitViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.IRegionMoveIdentity
Parameter Sets: CommitViaIdentity, CommitViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MoveCollectionName
.

```yaml
Type: System.String
Parameter Sets: Commit, CommitExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MoveResource
Gets or sets the list of move resources ARM id's.

```yaml
Type: System.String[]
Parameter Sets: CommitExpanded, CommitViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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
.

```yaml
Type: System.String
Parameter Sets: Commit, CommitExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Subscription ID.

```yaml
Type: System.String
Parameter Sets: Commit, CommitExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValidateOnly
Gets or sets a value indicating whether the operation needs to only run pre-requisite.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CommitExpanded, CommitViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.Api20191001Preview.ICommitRequest

### Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.IRegionMoveIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.Api20191001Preview.IOperationStatus

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


BODY <ICommitRequest>: Defines the request body for commit operation.
  - `[MoveResource <String[]>]`: Gets or sets the list of move resources ARM id's.
  - `[ValidateOnly <Boolean?>]`: Gets or sets a value indicating whether the operation needs to only run pre-requisite.

INPUTOBJECT <IRegionMoveIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[MoveCollectionName <String>]`: 
  - `[MoveResourceName <String>]`: 
  - `[ResourceGroupName <String>]`: 
  - `[SubscriptionId <String>]`: The Subscription ID.

## RELATED LINKS

