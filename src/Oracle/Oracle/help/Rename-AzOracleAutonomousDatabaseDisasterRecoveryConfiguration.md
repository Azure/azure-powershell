---
external help file: Az.Oracle-help.xml
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/az.oracle/rename-azoracleautonomousdatabasedisasterrecoveryconfiguration
schema: 2.0.0
---

# Rename-AzOracleAutonomousDatabaseDisasterRecoveryConfiguration

## SYNOPSIS
Perform ChangeDisasterRecoveryConfiguration action on Autonomous Database

## SYNTAX

### ChangeExpanded (Default)
```
Rename-AzOracleAutonomousDatabaseDisasterRecoveryConfiguration -Autonomousdatabasename <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-DisasterRecoveryType <String>]
 [-IsReplicateAutomaticBackup] [-IsSnapshotStandby] [-TimeSnapshotStandbyEnabledTill <DateTime>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ChangeViaJsonString
```
Rename-AzOracleAutonomousDatabaseDisasterRecoveryConfiguration -Autonomousdatabasename <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ChangeViaJsonFilePath
```
Rename-AzOracleAutonomousDatabaseDisasterRecoveryConfiguration -Autonomousdatabasename <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Change
```
Rename-AzOracleAutonomousDatabaseDisasterRecoveryConfiguration -Autonomousdatabasename <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -Body <IDisasterRecoveryConfigurationDetails>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ChangeViaIdentityExpanded
```
Rename-AzOracleAutonomousDatabaseDisasterRecoveryConfiguration -InputObject <IOracleIdentity>
 [-DisasterRecoveryType <String>] [-IsReplicateAutomaticBackup] [-IsSnapshotStandby]
 [-TimeSnapshotStandbyEnabledTill <DateTime>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ChangeViaIdentity
```
Rename-AzOracleAutonomousDatabaseDisasterRecoveryConfiguration -InputObject <IOracleIdentity>
 -Body <IDisasterRecoveryConfigurationDetails> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Perform ChangeDisasterRecoveryConfiguration action on Autonomous Database

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

### -Autonomousdatabasename
The database name.

```yaml
Type: System.String
Parameter Sets: ChangeExpanded, ChangeViaJsonString, ChangeViaJsonFilePath, Change
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
Configurations of a Disaster Recovery Details

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IDisasterRecoveryConfigurationDetails
Parameter Sets: Change, ChangeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -DisasterRecoveryType
Indicates the disaster recovery (DR) type of the Autonomous Database Serverless instance.
Autonomous Data Guard (ADG) DR type provides business critical DR with a faster recovery time objective (RTO) during failover or switchover.
Backup-based DR type provides lower cost DR with a slower RTO during failover or switchover.

```yaml
Type: System.String
Parameter Sets: ChangeExpanded, ChangeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity
Parameter Sets: ChangeViaIdentityExpanded, ChangeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsReplicateAutomaticBackup
If true, 7 days worth of backups are replicated across regions for Cross-Region ADB or Backup-Based DR between Primary and Standby.
If false, the backups taken on the Primary are not replicated to the Standby database.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ChangeExpanded, ChangeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsSnapshotStandby
Indicates if user wants to convert to a snapshot standby.
For example, true would set a standby database to snapshot standby database.
False would set a snapshot standby database back to regular standby database.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ChangeExpanded, ChangeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Change operation

```yaml
Type: System.String
Parameter Sets: ChangeViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Change operation

```yaml
Type: System.String
Parameter Sets: ChangeViaJsonString
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
Parameter Sets: ChangeExpanded, ChangeViaJsonString, ChangeViaJsonFilePath, Change
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
Parameter Sets: ChangeExpanded, ChangeViaJsonString, ChangeViaJsonFilePath, Change
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeSnapshotStandbyEnabledTill
Time and date stored as an RFC 3339 formatted timestamp string.
For example, 2022-01-01T12:00:00.000Z would set a limit for the snapshot standby to be converted back to a cross-region standby database.

```yaml
Type: System.DateTime
Parameter Sets: ChangeExpanded, ChangeViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IDisasterRecoveryConfigurationDetails

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IAutonomousDatabase

## NOTES

## RELATED LINKS
