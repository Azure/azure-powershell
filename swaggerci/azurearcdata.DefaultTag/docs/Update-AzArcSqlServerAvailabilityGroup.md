---
external help file:
Module Name: Az.Arc
online version: https://learn.microsoft.com/powershell/module/az.arc/update-azarcsqlserveravailabilitygroup
schema: 2.0.0
---

# Update-AzArcSqlServerAvailabilityGroup

## SYNOPSIS
Updates an existing Availability Group.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzArcSqlServerAvailabilityGroup -ResourceGroupName <String> -SqlAvailabilityGroupName <String>
 -SqlServerInstanceName <String> [-SubscriptionId <String>] [-AvailabilityGroupId <String>]
 [-AvailabilityGroupName <String>] [-ConfigureAvailabilityModeDesc <String>]
 [-ConfigureBackupPriority <Int32>] [-ConfigureCreateDate <DateTime>] [-ConfigureEndpointUrl <String>]
 [-ConfigureFailoverModeDesc <String>] [-ConfigureModifyDate <DateTime>]
 [-ConfigurePrimaryRoleAllowConnectionsDesc <String>] [-ConfigureReadOnlyRoutingUrl <String>]
 [-ConfigureReadWriteRoutingUrl <String>] [-ConfigureSecondaryRoleAllowConnectionsDesc <String>]
 [-ConfigureSeedingModeDesc <String>] [-ConfigureSessionTimeout <Int32>]
 [-StateAvailabilityGroupReplicaRole <String>] [-StateConnectedStateDesc <String>]
 [-StateLastConnectErrorDescription <String>] [-StateLastConnectErrorTimestamp <DateTime>]
 [-StateOperationalStateDesc <String>] [-StateRecoveryHealthDesc <String>]
 [-StateSynchronizationHealthDesc <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzArcSqlServerAvailabilityGroup -InputObject <IArcIdentity> [-AvailabilityGroupId <String>]
 [-AvailabilityGroupName <String>] [-ConfigureAvailabilityModeDesc <String>]
 [-ConfigureBackupPriority <Int32>] [-ConfigureCreateDate <DateTime>] [-ConfigureEndpointUrl <String>]
 [-ConfigureFailoverModeDesc <String>] [-ConfigureModifyDate <DateTime>]
 [-ConfigurePrimaryRoleAllowConnectionsDesc <String>] [-ConfigureReadOnlyRoutingUrl <String>]
 [-ConfigureReadWriteRoutingUrl <String>] [-ConfigureSecondaryRoleAllowConnectionsDesc <String>]
 [-ConfigureSeedingModeDesc <String>] [-ConfigureSessionTimeout <Int32>]
 [-StateAvailabilityGroupReplicaRole <String>] [-StateConnectedStateDesc <String>]
 [-StateLastConnectErrorDescription <String>] [-StateLastConnectErrorTimestamp <DateTime>]
 [-StateOperationalStateDesc <String>] [-StateRecoveryHealthDesc <String>]
 [-StateSynchronizationHealthDesc <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates an existing Availability Group.

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

### -AvailabilityGroupId
ID GUID of the availability group.

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

### -AvailabilityGroupName
the availability group name.

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

### -ConfigureAvailabilityModeDesc
Availability Synchronization mode description of availability group replica.

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

### -ConfigureBackupPriority
Represents the user-specified priority for performing backups on this replica relative to the other replicas in the same availability group.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigureCreateDate
Date that the replica was created.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigureEndpointUrl
Mirroring endpoint URL of availability group replica

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

### -ConfigureFailoverModeDesc
failover mode description of the availability group replica.

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

### -ConfigureModifyDate
Date that the replica was modified.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurePrimaryRoleAllowConnectionsDesc
Allowed the connections for primary role of the availability group replica.

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

### -ConfigureReadOnlyRoutingUrl
Connectivity endpoint (URL) of the read only availability replica.

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

### -ConfigureReadWriteRoutingUrl
Connectivity endpoint (URL) of the read write availability replica.

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

### -ConfigureSecondaryRoleAllowConnectionsDesc
Allowed the connections for secondary role of availability group replica.

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

### -ConfigureSeedingModeDesc
Describes seeding mode.

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

### -ConfigureSessionTimeout
The time-out period of availability group session replica, in seconds.

```yaml
Type: System.Int32
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Arc.Models.IArcIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the Azure resource group

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlServerInstanceName
Name of SQL Server Instance

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StateAvailabilityGroupReplicaRole
Role description of the availability group replica.

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

### -StateConnectedStateDesc
Connected state description of the availability group replica.

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

### -StateLastConnectErrorDescription
Last connect error description of the availability group replica.

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

### -StateLastConnectErrorTimestamp
Last connect error time stamp of the availability group replica.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StateOperationalStateDesc
Operation state description of the availability group replica

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

### -StateRecoveryHealthDesc
Recovery health description of the availability group replica.

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

### -StateSynchronizationHealthDesc
Synchronization health description of the availability group replica.

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

### -SubscriptionId
The ID of the Azure subscription

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Arc.Models.IArcIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Arc.Models.Api20230315Preview.ISqlServerAvailabilityGroupResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IArcIdentity>`: Identity Parameter
  - `[ActiveDirectoryConnectorName <String>]`: The name of the Active Directory connector instance
  - `[DataControllerName <String>]`: The name of the data controller
  - `[DatabaseName <String>]`: Name of the database
  - `[FailoverGroupName <String>]`: The name of the Failover Group
  - `[Id <String>]`: Resource identity path
  - `[PostgresInstanceName <String>]`: Name of Postgres Instance
  - `[ResourceGroupName <String>]`: The name of the Azure resource group
  - `[SqlAvailabilityGroupDatabaseName <String>]`: Name of SQL Availability Group Database
  - `[SqlAvailabilityGroupName <String>]`: Name of SQL Availability Group
  - `[SqlManagedInstanceName <String>]`: Name of SQL Managed Instance
  - `[SqlServerInstanceName <String>]`: Name of SQL Server Instance
  - `[SubscriptionId <String>]`: The ID of the Azure subscription

## RELATED LINKS

