---
external help file:
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/update-azpostgresqlflexibleservermigration
schema: 2.0.0
---

# Update-AzPostgreSqlFlexibleServerMigration

## SYNOPSIS
Update an existing migration.
The request body can contain one to many of the mutable properties present in the migration definition.
Certain property update initiate migration state transitions.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzPostgreSqlFlexibleServerMigration -Name <String> -ResourceGroupName <String> -ServerName <String>
 [-SubscriptionId <String>] [-AdminCredentialsSourceServerPassword <SecureString>]
 [-AdminCredentialsTargetServerPassword <SecureString>] [-Cancel <String>]
 [-DbsToCancelMigrationOn <String[]>] [-DbsToMigrate <String[]>] [-DbsToTriggerCutoverOn <String[]>]
 [-MigrateRole <String>] [-MigrationMode <String>] [-MigrationWindowStartTimeInUtc <DateTime>]
 [-OverwriteDbsInTarget <String>] [-SecretParameterSourceServerUsername <String>]
 [-SecretParameterTargetServerUsername <String>] [-SetupLogicalReplicationOnSourceDbIfNeeded <String>]
 [-SourceDbServerFullyQualifiedDomainName <String>] [-SourceDbServerResourceId <String>]
 [-StartDataMigration <String>] [-Tag <Hashtable>] [-TargetDbServerFullyQualifiedDomainName <String>]
 [-TriggerCutover <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzPostgreSqlFlexibleServerMigration -InputObject <IPostgreSqlFlexibleServerIdentity>
 [-AdminCredentialsSourceServerPassword <SecureString>] [-AdminCredentialsTargetServerPassword <SecureString>]
 [-Cancel <String>] [-DbsToCancelMigrationOn <String[]>] [-DbsToMigrate <String[]>]
 [-DbsToTriggerCutoverOn <String[]>] [-MigrateRole <String>] [-MigrationMode <String>]
 [-MigrationWindowStartTimeInUtc <DateTime>] [-OverwriteDbsInTarget <String>]
 [-SecretParameterSourceServerUsername <String>] [-SecretParameterTargetServerUsername <String>]
 [-SetupLogicalReplicationOnSourceDbIfNeeded <String>] [-SourceDbServerFullyQualifiedDomainName <String>]
 [-SourceDbServerResourceId <String>] [-StartDataMigration <String>] [-Tag <Hashtable>]
 [-TargetDbServerFullyQualifiedDomainName <String>] [-TriggerCutover <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityFlexibleServerExpanded
```
Update-AzPostgreSqlFlexibleServerMigration -FlexibleServerInputObject <IPostgreSqlFlexibleServerIdentity>
 -Name <String> [-AdminCredentialsSourceServerPassword <SecureString>]
 [-AdminCredentialsTargetServerPassword <SecureString>] [-Cancel <String>]
 [-DbsToCancelMigrationOn <String[]>] [-DbsToMigrate <String[]>] [-DbsToTriggerCutoverOn <String[]>]
 [-MigrateRole <String>] [-MigrationMode <String>] [-MigrationWindowStartTimeInUtc <DateTime>]
 [-OverwriteDbsInTarget <String>] [-SecretParameterSourceServerUsername <String>]
 [-SecretParameterTargetServerUsername <String>] [-SetupLogicalReplicationOnSourceDbIfNeeded <String>]
 [-SourceDbServerFullyQualifiedDomainName <String>] [-SourceDbServerResourceId <String>]
 [-StartDataMigration <String>] [-Tag <Hashtable>] [-TargetDbServerFullyQualifiedDomainName <String>]
 [-TriggerCutover <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzPostgreSqlFlexibleServerMigration -Name <String> -ResourceGroupName <String> -ServerName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzPostgreSqlFlexibleServerMigration -Name <String> -ResourceGroupName <String> -ServerName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update an existing migration.
The request body can contain one to many of the mutable properties present in the migration definition.
Certain property update initiate migration state transitions.

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

### -AdminCredentialsSourceServerPassword
Password for the user of the source server.

```yaml
Type: System.Security.SecureString
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityFlexibleServerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AdminCredentialsTargetServerPassword
Password for the user of the target server.

```yaml
Type: System.Security.SecureString
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityFlexibleServerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Cancel
Indicates if cancel must be triggered for the entire migration.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityFlexibleServerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DbsToCancelMigrationOn
When you want to trigger cancel for specific databases set 'triggerCutover' to 'True' and the names of the specific databases in this array.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityFlexibleServerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DbsToMigrate
Names of databases to migrate.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityFlexibleServerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DbsToTriggerCutoverOn
When you want to trigger cutover for specific databases set 'triggerCutover' to 'True' and the names of the specific databases in this array.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityFlexibleServerExpanded
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

### -FlexibleServerInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity
Parameter Sets: UpdateViaIdentityFlexibleServerExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MigrateRole
Indicates if roles and permissions must be migrated.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityFlexibleServerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MigrationMode
Mode used to perform the migration: Online or Offline.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityFlexibleServerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MigrationWindowStartTimeInUtc
Start time (UTC) for migration window.

```yaml
Type: System.DateTime
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityFlexibleServerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of migration.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityFlexibleServerExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases: MigrationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OverwriteDbsInTarget
Indicates if databases on the target server can be overwritten when already present.
If set to 'False', when the migration workflow detects that the database already exists on the target server, it will wait for a confirmation.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityFlexibleServerExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecretParameterSourceServerUsername
Gets or sets the name of the user for the source server.
This user doesn't need to be an administrator.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityFlexibleServerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecretParameterTargetServerUsername
Gets or sets the name of the user for the target server.
This user doesn't need to be an administrator.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityFlexibleServerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerName
The name of the server.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SetupLogicalReplicationOnSourceDbIfNeeded
Indicates whether to setup logical replication on source server, if needed.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityFlexibleServerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceDbServerFullyQualifiedDomainName
Fully qualified domain name (FQDN) or IP address of the source server.
This property is optional.
When provided, the migration service will always use it to connect to the source server.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityFlexibleServerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceDbServerResourceId
Identifier of the source database server resource, when 'sourceType' is 'PostgreSQLSingleServer'.
For other source types this must be set to ipaddress:port@username or hostname:port@username.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityFlexibleServerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartDataMigration
Indicates if data migration must start right away.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityFlexibleServerExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Application-specific metadata in the form of key-value pairs.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityFlexibleServerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetDbServerFullyQualifiedDomainName
Fully qualified domain name (FQDN) or IP address of the target server.
This property is optional.
When provided, the migration service will always use it to connect to the target server.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityFlexibleServerExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TriggerCutover
Indicates if cutover must be triggered for the entire migration.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityFlexibleServerExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IMigration

## NOTES

## RELATED LINKS

