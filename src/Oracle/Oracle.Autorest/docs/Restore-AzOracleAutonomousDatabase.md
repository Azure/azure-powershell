---
external help file:
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/az.oracle/restore-azoracleautonomousdatabase
schema: 2.0.0
---

# Restore-AzOracleAutonomousDatabase

## SYNOPSIS
Restores an Autonomous Database based on the provided request parameters.

## SYNTAX

### RestoreExpanded (Default)
```
Restore-AzOracleAutonomousDatabase -Name <String> -ResourceGroupName <String> -Timestamp <DateTime>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Restore
```
Restore-AzOracleAutonomousDatabase -Name <String> -ResourceGroupName <String>
 -Body <IRestoreAutonomousDatabaseDetails> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RestoreViaIdentity
```
Restore-AzOracleAutonomousDatabase -InputObject <IOracleIdentity> -Body <IRestoreAutonomousDatabaseDetails>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RestoreViaIdentityExpanded
```
Restore-AzOracleAutonomousDatabase -InputObject <IOracleIdentity> -Timestamp <DateTime>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RestoreViaJsonFilePath
```
Restore-AzOracleAutonomousDatabase -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RestoreViaJsonString
```
Restore-AzOracleAutonomousDatabase -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Restores an Autonomous Database based on the provided request parameters.

## EXAMPLES

### Example 1: Restore a Backup for an Autonomous Database resource
```powershell
$timeStamp = Get-Date
Restore-AzOracleAutonomousDatabase -Name "OFakePowerShellTestAdbs" -ResourceGroupName "PowerShellTestRg" -Timestamp $timeStamp
```

Restore a Backup for an Autonomous Database resource.
For more information, execute `Get-Help Restore-AzOracleAutonomousDatabase`.

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

### -Body
Details to restore an Oracle Autonomous Database.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IRestoreAutonomousDatabaseDetails
Parameter Sets: Restore, RestoreViaIdentity
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity
Parameter Sets: RestoreViaIdentity, RestoreViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Restore operation

```yaml
Type: System.String
Parameter Sets: RestoreViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Restore operation

```yaml
Type: System.String
Parameter Sets: RestoreViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The database name.

```yaml
Type: System.String
Parameter Sets: Restore, RestoreExpanded, RestoreViaJsonFilePath, RestoreViaJsonString
Aliases: Autonomousdatabasename

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
Parameter Sets: Restore, RestoreExpanded, RestoreViaJsonFilePath, RestoreViaJsonString
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
Parameter Sets: Restore, RestoreExpanded, RestoreViaJsonFilePath, RestoreViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Timestamp
The time to restore the database to.

```yaml
Type: System.DateTime
Parameter Sets: RestoreExpanded, RestoreViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IRestoreAutonomousDatabaseDetails

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IAutonomousDatabase

## NOTES

## RELATED LINKS

