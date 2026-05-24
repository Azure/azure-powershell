---
external help file: Az.PostgreSqlFlexibleServer-help.xml
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/stop-azpostgresqlflexibleservermigration
schema: 2.0.0
---

# Stop-AzPostgreSqlFlexibleServerMigration

## SYNOPSIS
Cancels an active migration.

## SYNTAX

### Cancel (Default)
```
Stop-AzPostgreSqlFlexibleServerMigration -Name <String> -ResourceGroup <String> -ServerName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CancelViaIdentityFlexibleServer
```
Stop-AzPostgreSqlFlexibleServerMigration -Name <String>
 -FlexibleServerInputObject <IPostgreSqlFlexibleServerIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CancelViaIdentity
```
Stop-AzPostgreSqlFlexibleServerMigration -InputObject <IPostgreSqlFlexibleServerIdentity>
 [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Cancels an active migration.

## EXAMPLES

### Example 1: Cancel an active migration in a flexible server
```powershell
Stop-AzPostgreSqlFlexibleServerMigration -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName server-name -Name example-migration
```

```output
AdminCredentialsSourceServerPassword        : 
AdminCredentialsTargetServerPassword        : 
Cancel                                      : 
CurrentStatusError                          : 
CurrentStatusState                          : InProgress
CurrentSubStateDetailCurrentSubState        : PerformingPreRequisiteSteps
CurrentSubStateDetailDbDetail               : {
                                              }
DbsToCancelMigrationOn                      : 
DbsToMigrate                                : {example-database}
DbsToTriggerCutoverOn                       : 
Id                                          : /subscriptions/aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e/resourceGroups/example-resource-group/providers/Microsoft.DBforPostgreSQL/flexibleServers/example-server/migrations/example-migration
InstanceResourceId                          : 
Location                                    : Canada Central
MigrateRole                                 : False
MigrationId                                 : 00000000-0000-0000-0000-000000000000
Mode                                        : Offline
Name                                        : example-migration
Option                                      : ValidateAndMigrate
OverwriteDbsInTarget                        : True
ResourceGroupName                           : example-resource-group
SecretParameterSourceServerUsername         : 
SecretParameterTargetServerUsername         : 
SetupLogicalReplicationOnSourceDbIfNeeded   : True
SourceDbServerFullyQualifiedDomainName      : 
SourceDbServerMetadataLocation              : 
SourceDbServerMetadataSkuName               : 
SourceDbServerMetadataSkuTier               : 
SourceDbServerMetadataStorageMb             : 
SourceDbServerMetadataVersion               : 
SourceDbServerResourceId                    : example-server.postgres.database.azure.com:5432@example-administrator-login
SourceType                                  : OnPremises
SslMode                                     : Prefer
StartDataMigration                          : 
SystemDataCreatedAt                         : 
SystemDataCreatedBy                         : 
SystemDataCreatedByType                     : 
SystemDataLastModifiedAt                    : 
SystemDataLastModifiedBy                    : 
SystemDataLastModifiedByType                : 
Tag                                         : {
                                              }
TargetDbServerFullyQualifiedDomainName      : 
TargetDbServerMetadataLocation              : example-location
TargetDbServerMetadataSkuName               : Standard_D4ads_v5
TargetDbServerMetadataSkuTier               : GeneralPurpose
TargetDbServerMetadataStorageMb             : 131072
TargetDbServerMetadataVersion               : 18
TargetDbServerResourceId                    : /subscriptions/aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e/resourceGroups/example-resource-group/providers/Microsoft.DBforPostgreSQL/flexibleServers/example-migration
TriggerCutover                              : True
Type                                        : Microsoft.DBforPostgreSQL/flexibleServers/migrations
ValidationDetailDbLevelValidationDetail     : 
ValidationDetailServerLevelValidationDetail : 
ValidationDetailStatus                      : 
ValidationDetailValidationEndTimeInUtc      : 
ValidationDetailValidationStartTimeInUtc    : 
WindowEndTimeInUtc                          : 
WindowStartTimeInUtc                        : 3/22/2026 6:16:56 PM
```

Cancels an active migration in an Azure Database for PostgreSQL flexible server with migration name, server name, and subscription explicitly passed as an arguments.
If subscription is not passed explicitly, it's taken from default context.

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

### -FlexibleServerInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity
Parameter Sets: CancelViaIdentityFlexibleServer
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
Parameter Sets: CancelViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of migration.

```yaml
Type: System.String
Parameter Sets: Cancel, CancelViaIdentityFlexibleServer
Aliases: MigrationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

### -ResourceGroup
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Cancel
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
Parameter Sets: Cancel
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
Parameter Sets: Cancel
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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
