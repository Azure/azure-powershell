---
external help file:
Module Name: Az.PostgreSql
online version: https://docs.microsoft.com/powershell/module/az.postgresql/get-azpostgresqlflexibleserverbackup
schema: 2.0.0
---

# Get-AzPostgreSqlFlexibleServerBackup

## SYNOPSIS
List all the backups for a given server.

## SYNTAX

### List (Default)
```
Get-AzPostgreSqlFlexibleServerBackup -ResourceGroupName <String> -ServerName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzPostgreSqlFlexibleServerBackup -BackupName <String> -ResourceGroupName <String> -ServerName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPostgreSqlFlexibleServerBackup -InputObject <IPostgreSqlIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
List all the backups for a given server.

## EXAMPLES

### Example 1: List all the backups for a given server
```powershell
Get-AzPostgreSqlFlexibleServerBackup -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test
```

```output
Id                                                                                                                                                                            Name                      Type                                              BackupType CompletedTime         Source
--                                                                                                                                                                            ----                      ----                                              ---------- -------------         ------
/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test/backups/backup_637953333961627768 backup_637953333961627768 Microsoft.DBforPostgreSQL/flexibleServers/backups Full       8/5/2022 9:56:36 PM   Automatic
/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test/backups/backup_637954198195749123 backup_637954198195749123 Microsoft.DBforPostgreSQL/flexibleServers/backups Full       8/6/2022 9:56:59 PM   Automatic
/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test/backups/backup_637955062430210149 backup_637955062430210149 Microsoft.DBforPostgreSQL/flexibleServers/backups Full       8/7/2022 9:57:23 PM   Automatic
```

This cmdlet lists all the backups for a given server.

### Example 2: Show the details of a specific backup for a given server
```powershell
Get-AzPostgreSqlFlexibleServerBackup -ResourceGroupName PowershellPostgreSqlTest -ServerName postgresql-test -BackupName backup_637953333961627768
```

```output
Id                                                                                                                                                                            Name                      Type                                              BackupType CompletedTime         Source
--                                                                                                                                                                            ----                      ----                                              ---------- -------------         ------
/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test/backups/backup_637953333961627768 backup_637953333961627768 Microsoft.DBforPostgreSQL/flexibleServers/backups Full       8/5/2022 9:56:36 PM   Automatic
```

This cmdlet shows the details of a specific backup for a given server.

## PARAMETERS

### -BackupName
The name of the backup.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.IPostgreSqlIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -ServerName
The name of the server.

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
The ID of the target subscription.

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

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.IPostgreSqlIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20220120Preview.IServerBackup

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IPostgreSqlIdentity>`: Identity Parameter
  - `[BackupName <String>]`: The name of the backup.
  - `[ConfigurationName <String>]`: The name of the server configuration.
  - `[DatabaseName <String>]`: The name of the database.
  - `[FirewallRuleName <String>]`: The name of the server firewall rule.
  - `[Id <String>]`: Resource identity path
  - `[LocationName <String>]`: The name of the location.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SecurityAlertPolicyName <SecurityAlertPolicyName?>]`: The name of the security alert policy.
  - `[ServerName <String>]`: The name of the server.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[VirtualNetworkRuleName <String>]`: The name of the virtual network rule.

## RELATED LINKS

