---
external help file: Az.PostgreSqlFlexibleServer-help.xml
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/test-azpostgresqlflexibleserverbackupslongtermretentionprerequisite
schema: 2.0.0
---

# Test-AzPostgreSqlFlexibleServerBackupsLongTermRetentionPrerequisite

## SYNOPSIS
Performs all checks required for a long term retention backup operation to succeed.

## SYNTAX

### CheckExpanded (Default)
```
Test-AzPostgreSqlFlexibleServerBackupsLongTermRetentionPrerequisite -ResourceGroupName <String>
 -ServerName <String> [-SubscriptionId <String>] -BackupSettingBackupName <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CheckViaJsonString
```
Test-AzPostgreSqlFlexibleServerBackupsLongTermRetentionPrerequisite -ResourceGroupName <String>
 -ServerName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CheckViaJsonFilePath
```
Test-AzPostgreSqlFlexibleServerBackupsLongTermRetentionPrerequisite -ResourceGroupName <String>
 -ServerName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Check
```
Test-AzPostgreSqlFlexibleServerBackupsLongTermRetentionPrerequisite -ResourceGroupName <String>
 -ServerName <String> [-SubscriptionId <String>] -Parameter <ILtrPreBackupRequest> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CheckViaIdentityExpanded
```
Test-AzPostgreSqlFlexibleServerBackupsLongTermRetentionPrerequisite
 -InputObject <IPostgreSqlFlexibleServerIdentity> -BackupSettingBackupName <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CheckViaIdentity
```
Test-AzPostgreSqlFlexibleServerBackupsLongTermRetentionPrerequisite
 -InputObject <IPostgreSqlFlexibleServerIdentity> -Parameter <ILtrPreBackupRequest>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Performs all checks required for a long term retention backup operation to succeed.

## EXAMPLES

### Example 1: Test prerequisites for long-term retention backup
```powershell
Test-AzPostgreSqlFlexibleServerBackupsLongTermRetentionPrerequisite -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
```

```output
PrerequisitesMet      : True
StorageAccountRequired: True
PermissionsValid      : True
BackupEnabled         : True
Message               : All prerequisites are met for long-term retention backup.
```

Checks if all prerequisites are met for enabling long-term retention backups on the PostgreSQL Flexible Server.

### Example 2: Test prerequisites and identify missing requirements
```powershell
Test-AzPostgreSqlFlexibleServerBackupsLongTermRetentionPrerequisite -ResourceGroupName "development-rg" -ServerName "dev-postgresql-01"
```

```output
PrerequisitesMet      : False
StorageAccountRequired: True
PermissionsValid      : False
BackupEnabled         : True
Message               : Missing permissions to access the storage account. Please ensure the server has Contributor role on the target storage account.
Recommendations       : {Grant storage permissions, Verify storage account exists}
```

Identifies that the server lacks necessary permissions for long-term retention backups and provides remediation guidance.

## PARAMETERS

### -BackupSettingBackupName
Backup Name for the current backup

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
Parameter Sets: CheckViaIdentityExpanded, CheckViaIdentity
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

### -Parameter
A request that is made for pre-backup.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrPreBackupRequest
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
Parameter Sets: CheckExpanded, CheckViaJsonString, CheckViaJsonFilePath, Check
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
Parameter Sets: CheckExpanded, CheckViaJsonString, CheckViaJsonFilePath, Check
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
Parameter Sets: CheckExpanded, CheckViaJsonString, CheckViaJsonFilePath, Check
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

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrPreBackupRequest

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrPreBackupResponse

## NOTES

## RELATED LINKS
