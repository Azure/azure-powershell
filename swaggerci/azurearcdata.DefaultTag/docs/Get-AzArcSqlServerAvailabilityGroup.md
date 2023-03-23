---
external help file:
Module Name: Az.Arc
online version: https://learn.microsoft.com/powershell/module/az.arc/get-azarcsqlserveravailabilitygroup
schema: 2.0.0
---

# Get-AzArcSqlServerAvailabilityGroup

## SYNOPSIS
Retrieves an Arc Sql Server availability group.

## SYNTAX

### List (Default)
```
Get-AzArcSqlServerAvailabilityGroup -ResourceGroupName <String> -SqlServerInstanceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzArcSqlServerAvailabilityGroup -ResourceGroupName <String> -SqlAvailabilityGroupName <String>
 -SqlServerInstanceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzArcSqlServerAvailabilityGroup -InputObject <IArcIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Retrieves an Arc Sql Server availability group.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Arc.Models.IArcIdentity
Parameter Sets: GetViaIdentity
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
Parameter Sets: Get, List
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
Parameter Sets: Get
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
Parameter Sets: Get, List
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
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

