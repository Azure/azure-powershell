---
external help file:
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
New-AzPostgreSqlFlexibleServerThreatProtectionSetting -ResourceGroupName <String> -ServerName <String>
 [-SubscriptionId <String>] [-State <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzPostgreSqlFlexibleServerThreatProtectionSetting -ResourceGroupName <String> -ServerName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzPostgreSqlFlexibleServerThreatProtectionSetting -ResourceGroupName <String> -ServerName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a server's Advanced Threat Protection settings.

## EXAMPLES

### Example 1: Enable threat protection for a PostgreSQL Flexible Server
```powershell
New-AzPostgreSqlFlexibleServerThreatProtectionSetting -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -ThreatProtectionName "Default" -State "Enabled"
```

```output
Name              : Default
ResourceGroupName : myResourceGroup
ServerName        : myPostgreSqlServer
State             : Enabled
CreationTime      : 2024-01-15T10:30:00Z
EmailAddresses    : {}
DisabledAlerts    : {}
EmailAccountAdmins: False
```

Enables Microsoft Defender for the PostgreSQL Flexible Server with default settings.

### Example 2: Enable threat protection with custom settings
```powershell
New-AzPostgreSqlFlexibleServerThreatProtectionSetting -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -ThreatProtectionName "Default" -State "Enabled" -EmailAddress @("admin@contoso.com", "security@contoso.com") -EmailAccountAdmin $true -DisabledAlert @("Sql_Injection_Vulnerability")
```

```output
Name              : Default
ResourceGroupName : production-rg
ServerName        : prod-postgresql-01
State             : Enabled
CreationTime      : 2024-01-20T14:15:00Z
EmailAddresses    : {"admin@contoso.com", "security@contoso.com"}
DisabledAlerts    : {"Sql_Injection_Vulnerability"}
EmailAccountAdmins: True
```

Enables Microsoft Defender with custom notification settings and disabled alerts.

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

### -ResourceGroupName
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

