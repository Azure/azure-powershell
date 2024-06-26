---
external help file:
Module Name: Az.OracleDatabaseResourceManager
online version: https://learn.microsoft.com/powershell/module/az.oracledatabaseresourcemanager/update-azoracledatabaseresourcemanagerautonomousdatabasebackup
schema: 2.0.0
---

# Update-AzOracleDatabaseResourceManagerAutonomousDatabaseBackup

## SYNOPSIS
Update a AutonomousDatabaseBackup

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzOracleDatabaseResourceManagerAutonomousDatabaseBackup -Adbbackupid <String>
 -Autonomousdatabasename <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-RetentionPeriodInDay <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Update
```
Update-AzOracleDatabaseResourceManagerAutonomousDatabaseBackup -Adbbackupid <String>
 -Autonomousdatabasename <String> -ResourceGroupName <String> -Property <IAutonomousDatabaseBackupUpdate>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzOracleDatabaseResourceManagerAutonomousDatabaseBackup
 -InputObject <IOracleDatabaseResourceManagerIdentity> -Property <IAutonomousDatabaseBackupUpdate>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityAutonomousDatabase
```
Update-AzOracleDatabaseResourceManagerAutonomousDatabaseBackup -Adbbackupid <String>
 -AutonomousDatabaseInputObject <IOracleDatabaseResourceManagerIdentity>
 -Property <IAutonomousDatabaseBackupUpdate> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityAutonomousDatabaseExpanded
```
Update-AzOracleDatabaseResourceManagerAutonomousDatabaseBackup -Adbbackupid <String>
 -AutonomousDatabaseInputObject <IOracleDatabaseResourceManagerIdentity> [-RetentionPeriodInDay <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzOracleDatabaseResourceManagerAutonomousDatabaseBackup
 -InputObject <IOracleDatabaseResourceManagerIdentity> [-RetentionPeriodInDay <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzOracleDatabaseResourceManagerAutonomousDatabaseBackup -Adbbackupid <String>
 -Autonomousdatabasename <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzOracleDatabaseResourceManagerAutonomousDatabaseBackup -Adbbackupid <String>
 -Autonomousdatabasename <String> -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a AutonomousDatabaseBackup

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

### -Adbbackupid
AutonomousDatabaseBackup id

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded, UpdateViaIdentityAutonomousDatabase, UpdateViaIdentityAutonomousDatabaseExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -AutonomousDatabaseInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabaseResourceManager.Models.IOracleDatabaseResourceManagerIdentity
Parameter Sets: UpdateViaIdentityAutonomousDatabase, UpdateViaIdentityAutonomousDatabaseExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Autonomousdatabasename
The database name.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabaseResourceManager.Models.IOracleDatabaseResourceManagerIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
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

### -Property
The type used for update operations of the AutonomousDatabaseBackup.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabaseResourceManager.Models.IAutonomousDatabaseBackupUpdate
Parameter Sets: Update, UpdateViaIdentity, UpdateViaIdentityAutonomousDatabase
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
Parameter Sets: Update, UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetentionPeriodInDay
Retention period, in days, for long-term backups.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityAutonomousDatabaseExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: Update, UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabaseResourceManager.Models.IAutonomousDatabaseBackupUpdate

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabaseResourceManager.Models.IOracleDatabaseResourceManagerIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabaseResourceManager.Models.IAutonomousDatabaseBackup

## NOTES

## RELATED LINKS

