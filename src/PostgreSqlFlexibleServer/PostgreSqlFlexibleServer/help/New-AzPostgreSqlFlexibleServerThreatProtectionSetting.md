---
external help file: Az.PostgreSqlFlexibleServer-help.xml
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/new-azpostgresqlflexibleserverthreatprotectionsetting
schema: 2.0.0
---

# New-AzPostgreSqlFlexibleServerThreatProtectionSetting

## SYNOPSIS
Create a server's Advanced Threat Protection settings.

## SYNTAX

### CreateExpanded (Default)
```
New-AzPostgreSqlFlexibleServerThreatProtectionSetting -ResourceGroup <String> -ServerName <String>
 [-SubscriptionId <String>] [-State <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzPostgreSqlFlexibleServerThreatProtectionSetting -ResourceGroup <String> -ServerName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzPostgreSqlFlexibleServerThreatProtectionSetting -ResourceGroup <String> -ServerName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a server's Advanced Threat Protection settings.

## EXAMPLES

### Example 1: Enable threat advanced protection in a flexible server
```powershell
New-AzPostgreSqlFlexibleServerThreatProtectionSetting -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server -State Enabled
```

```output
CreationTime                 : 3/22/2026 1:29:08 PM
Id                           : /subscriptions/aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e/resourceGroups/example-resource-group/providers/Microsoft.DBforPostgreSQL/flexibleServers/example-server/advancedThreatProtectionSettings/Default
Name                         : Default
ResourceGroupName            : example-resource-group
State                        : Enabled
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.DBforPostgreSQL/flexibleServers/advancedThreatProtectionSettings
```

Enables threat advanced protection of an Azure Database for PostgreSQL flexible server.
If subscription is not passed explicitly, it's taken from default context.

### Example 2: Disable threat advanced protection in a server
```powershell
New-AzPostgreSqlFlexibleServerThreatProtectionSetting -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server -State Disabled
```

```output
CreationTime                 : 3/22/2026 1:29:08 PM
Id                           : /subscriptions/aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e/resourceGroups/example-resource-group/providers/Microsoft.DBforPostgreSQL/flexibleServers/example-server/advancedThreatProtectionSettings/Default
Name                         : Default
ResourceGroupName            : example-resource-group
State                        : Disabled
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.DBforPostgreSQL/flexibleServers/advancedThreatProtectionSettings
```

Disables threat advanced protection of an Azure Database for PostgreSQL flexible server.
If subscription is not passed explicitly, it's taken from default context.

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

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
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

### -ResourceGroup
The name of the resource group.
The name is case insensitive.

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

### -ServerName
The name of the server.

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

### -State
Specifies the state of the advanced threat protection, whether it is enabled, disabled, or a state has not been applied yet on the server.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdvancedThreatProtectionSettingsModel

## NOTES

## RELATED LINKS
