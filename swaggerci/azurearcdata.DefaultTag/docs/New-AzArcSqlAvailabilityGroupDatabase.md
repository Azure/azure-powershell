---
external help file:
Module Name: Az.Arc
online version: https://learn.microsoft.com/powershell/module/az.arc/new-azarcsqlavailabilitygroupdatabase
schema: 2.0.0
---

# New-AzArcSqlAvailabilityGroupDatabase

## SYNOPSIS
Creates or update database in an Arc Sql Availability Group.

## SYNTAX

```
New-AzArcSqlAvailabilityGroupDatabase -Name <String> -ResourceGroupName <String>
 -SqlAvailabilityGroupName <String> -Location <String> [-SubscriptionId <String>] [-GroupDatabaseId <String>]
 [-Tag <Hashtable>] [-Value <ISqlAvailabilityGroupDatabaseReplicaResourceProperties[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or update database in an Arc Sql Availability Group.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -GroupDatabaseId
ID GUID of the database for availability group.

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

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of SQL Availability Group Database

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SqlAvailabilityGroupDatabaseName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the Azure resource group

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlAvailabilityGroupName
Name of SQL Availability Group

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the Azure subscription

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
Array of Arc Sql Availability Group Database Replicas.
To construct, see NOTES section for VALUE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Arc.Models.Api20230315Preview.ISqlAvailabilityGroupDatabaseReplicaResourceProperties[]
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

### Microsoft.Azure.PowerShell.Cmdlets.Arc.Models.Api20230315Preview.ISqlAvailabilityGroupDatabaseResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`VALUE <ISqlAvailabilityGroupDatabaseReplicaResourceProperties[]>`: Array of Arc Sql Availability Group Database Replicas.
  - `[DatabaseStateDesc <String>]`: Description of the database state of the availability replica.
  - `[IsCommitParticipant <Boolean?>]`: Whether this replica is transaction committer.
  - `[IsLocal <Boolean?>]`: Whether the availability database is local.
  - `[IsPrimaryReplica <Boolean?>]`: Returns 1 if the replica is primary, or 0 if it is a secondary replica.
  - `[IsSuspended <Boolean?>]`: Whether this data movement is suspended.
  - `[ReplicaName <String>]`: the database replica name.
  - `[SuspendReasonDesc <String>]`: Description of the database suspended state reason.
  - `[SynchronizationHealthDesc <String>]`: Description of the health of database.
  - `[SynchronizationStateDesc <String>]`: Description of the data-movement state.

## RELATED LINKS

