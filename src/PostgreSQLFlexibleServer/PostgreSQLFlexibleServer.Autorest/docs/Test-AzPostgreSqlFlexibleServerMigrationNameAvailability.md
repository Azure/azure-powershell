---
external help file:
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/test-azpostgresqlflexibleservermigrationnameavailability
schema: 2.0.0
---

# Test-AzPostgreSqlFlexibleServerMigrationNameAvailability

## SYNOPSIS
Checks if a proposed migration name is valid and available.

## SYNTAX

### CheckExpanded (Default)
```
Test-AzPostgreSqlFlexibleServerMigrationNameAvailability -ResourceGroupName <String> -ServerName <String>
 -Name <String> -Type <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Check
```
Test-AzPostgreSqlFlexibleServerMigrationNameAvailability -ResourceGroupName <String> -ServerName <String>
 -Parameter <IMigrationNameAvailability> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CheckViaIdentity
```
Test-AzPostgreSqlFlexibleServerMigrationNameAvailability -InputObject <IPostgreSqlFlexibleServerIdentity>
 -Parameter <IMigrationNameAvailability> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CheckViaIdentityExpanded
```
Test-AzPostgreSqlFlexibleServerMigrationNameAvailability -InputObject <IPostgreSqlFlexibleServerIdentity>
 -Name <String> -Type <String> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CheckViaJsonFilePath
```
Test-AzPostgreSqlFlexibleServerMigrationNameAvailability -ResourceGroupName <String> -ServerName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CheckViaJsonString
```
Test-AzPostgreSqlFlexibleServerMigrationNameAvailability -ResourceGroupName <String> -ServerName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Checks if a proposed migration name is valid and available.

## EXAMPLES

### Example 1: Check if a migration name is available
```powershell
Test-AzPostgreSqlFlexibleServerMigrationNameAvailability -ResourceGroupName "myResourceGroup" -TargetDbServerName "myTargetPostgreSqlServer" -MigrationName "my-new-migration" -SubscriptionId "12345678-1234-1234-1234-123456789abc"
```

```output
Name      : my-new-migration
Available : True
Reason    : 
Message   : Migration name is available
```

Checks if the specified migration name is available for the target PostgreSQL Flexible Server.

### Example 2: Check availability for an already used migration name
```powershell
Test-AzPostgreSqlFlexibleServerMigrationNameAvailability -ResourceGroupName "production-rg" -TargetDbServerName "prod-postgresql-01" -MigrationName "existing-migration" -SubscriptionId "12345678-1234-1234-1234-123456789abc"
```

```output
Name      : existing-migration
Available : False
Reason    : AlreadyExists
Message   : Migration name 'existing-migration' is already in use for this server
```

Checks availability for a migration name that is already in use, returning details about why it's not available.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity
Parameter Sets: CheckViaIdentity, CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Check operation

```yaml
Type: System.String
Parameter Sets: CheckViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Check operation

```yaml
Type: System.String
Parameter Sets: CheckViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the migration to check for validity and availability.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Availability of a migration name.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationNameAvailability
Parameter Sets: Check, CheckViaIdentity
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
Parameter Sets: Check, CheckExpanded, CheckViaJsonFilePath, CheckViaJsonString
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
Parameter Sets: Check, CheckExpanded, CheckViaJsonFilePath, CheckViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Check, CheckExpanded, CheckViaJsonFilePath, CheckViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
Type of resource.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationNameAvailability

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigrationNameAvailability

## NOTES

## RELATED LINKS

