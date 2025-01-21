---
external help file: Az.DataProtection-help.xml
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/backup-azdataprotectionbackupinstanceadhoc
schema: 2.0.0
---

# Backup-AzDataProtectionBackupInstanceAdhoc

## SYNOPSIS
Trigger adhoc backup

## SYNTAX

### BackupExpanded (Default)
```
Backup-AzDataProtectionBackupInstanceAdhoc -BackupInstanceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -VaultName <String> -BackupRuleOptionRuleName <String>
 [-TriggerOptionRetentionTagOverride <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### BackupViaIdentityExpanded
```
Backup-AzDataProtectionBackupInstanceAdhoc -InputObject <IDataProtectionIdentity>
 -BackupRuleOptionRuleName <String> [-TriggerOptionRetentionTagOverride <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Trigger adhoc backup

## EXAMPLES

### Example 1: Backup a protected backup instance
```powershell
$instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName "MyResourceGroup" -VaultName "MyVault"
Backup-AzDataProtectionBackupInstanceAdhoc -BackupInstanceName $instance.Name -ResourceGroupName "MyResourceGroup" -SubscriptionId "xxxx-xxx-xxxx" -VaultName "MyVault" -BackupRuleOptionRuleName "BackupWeekly" -TriggerOptionRetentionTagOverride "Default"
```

This Command Triggers Backup for a given backup instance.

### Example 2: Backup a protected backup instance
```powershell
$instance = Get-AzDataProtectionBackupInstance -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName "MyResourceGroup" -VaultName "MyVault"
$policy = Get-AzDataProtectionBackupPolicy -SubscriptionId $sub -VaultName "MyVault" -ResourceGroupName "MyResourceGroup" | Where-Object {$_.Name -eq "policyName"}
$backupJob = Backup-AzDataProtectionBackupInstanceAdhoc -BackupInstanceName $instance.Name -ResourceGroupName "MyResourceGroup" -SubscriptionId "xxxx-xxx-xxxx" -VaultName "MyVault" -BackupRuleOptionRuleName $policy.Property.PolicyRule[0].Name -TriggerOptionRetentionTagOverride $policy.Property.PolicyRule[0].Trigger.TaggingCriterion[0].TagInfoTagName
$jobid = $backupJob.JobId.Split("/")[-1]
$jobstatus = "InProgress"
while($jobstatus -ne "Completed")
{
    Start-Sleep -Seconds 10
    $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName
    $jobstatus = $currentjob.Status
}
```

This Command Triggers Backup for a given backup instance using protection policy used to protect the backup instance.
Then we track the backup job in a loop until it's completed.

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

### -BackupInstanceName
The name of the backup instance.

```yaml
Type: System.String
Parameter Sets: BackupExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackupRuleOptionRuleName
.

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity
Parameter Sets: BackupViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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
Parameter Sets: BackupExpanded
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
Parameter Sets: BackupExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TriggerOptionRetentionTagOverride
.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
The name of the backup vault.

```yaml
Type: System.String
Parameter Sets: BackupExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IOperationJobExtendedInfo

## NOTES

## RELATED LINKS
