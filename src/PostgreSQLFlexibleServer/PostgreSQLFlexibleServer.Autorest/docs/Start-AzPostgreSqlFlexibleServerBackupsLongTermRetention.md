---
external help file:
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/start-azpostgresqlflexibleserverbackupslongtermretention
schema: 2.0.0
---

# Start-AzPostgreSqlFlexibleServerBackupsLongTermRetention

## SYNOPSIS
Initiates a long term retention backup.

## SYNTAX

### StartViaIdentity (Default)
```
Start-AzPostgreSqlFlexibleServerBackupsLongTermRetention -InputObject <IPostgreSqlFlexibleServerIdentity>
 -Parameter <IBackupsLongTermRetentionRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Start
```
Start-AzPostgreSqlFlexibleServerBackupsLongTermRetention -ResourceGroupName <String> -ServerName <String>
 -Parameter <IBackupsLongTermRetentionRequest> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StartExpanded
```
Start-AzPostgreSqlFlexibleServerBackupsLongTermRetention -ResourceGroupName <String> -ServerName <String>
 -BackupSettingBackupName <String> -TargetDetailSasUriList <SecureString[]> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StartViaIdentityExpanded
```
Start-AzPostgreSqlFlexibleServerBackupsLongTermRetention -InputObject <IPostgreSqlFlexibleServerIdentity>
 -BackupSettingBackupName <String> -TargetDetailSasUriList <SecureString[]> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StartViaJsonFilePath
```
Start-AzPostgreSqlFlexibleServerBackupsLongTermRetention -ResourceGroupName <String> -ServerName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### StartViaJsonString
```
Start-AzPostgreSqlFlexibleServerBackupsLongTermRetention -ResourceGroupName <String> -ServerName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Initiates a long term retention backup.

## EXAMPLES

### Example 1: Start a long-term retention backup
```powershell
Start-AzPostgreSqlFlexibleServerBackupsLongTermRetention -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer" -BackupInstanceName "ltr-backup-annual-2024" -BackupSetting @{retentionPeriod="P7Y"}
```

```output
Name              : ltr-backup-annual-2024
ServerName        : myPostgreSqlServer
ResourceGroupName : myResourceGroup
OperationType     : LtrBackup
Status            : InProgress
StartTime         : 2024-01-15T10:30:00Z
RetentionPeriod   : P7Y
```

Starts a long-term retention backup for the PostgreSQL Flexible Server with a 7-year retention period.

### Example 2: Start an LTR backup for compliance
```powershell
Start-AzPostgreSqlFlexibleServerBackupsLongTermRetention -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -BackupInstanceName "compliance-backup-2024" -BackupSetting @{retentionPeriod="P10Y"; backupType="Full"}
```

```output
Name              : compliance-backup-2024
ServerName        : prod-postgresql-01
ResourceGroupName : production-rg
OperationType     : LtrBackup
Status            : InProgress
StartTime         : 2024-01-20T02:00:00Z
RetentionPeriod   : P10Y
BackupType        : Full
```

Starts a long-term retention backup for compliance purposes with a 10-year retention period.

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

### -BackupSettingBackupName
Backup Name for the current backup

```yaml
Type: System.String
Parameter Sets: StartExpanded, StartViaIdentityExpanded
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
Parameter Sets: StartViaIdentity, StartViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Start operation

```yaml
Type: System.String
Parameter Sets: StartViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Start operation

```yaml
Type: System.String
Parameter Sets: StartViaJsonString
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

### -Parameter
The request that is made for a long term retention backup.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupsLongTermRetentionRequest
Parameter Sets: Start, StartViaIdentity
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
Parameter Sets: Start, StartExpanded, StartViaJsonFilePath, StartViaJsonString
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
Parameter Sets: Start, StartExpanded, StartViaJsonFilePath, StartViaJsonString
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
Parameter Sets: Start, StartExpanded, StartViaJsonFilePath, StartViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetDetailSasUriList
List of SAS uri of storage containers where backup data is to be streamed/copied.

```yaml
Type: System.Security.SecureString[]
Parameter Sets: StartExpanded, StartViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupsLongTermRetentionRequest

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupsLongTermRetentionResponse

## NOTES

## RELATED LINKS

