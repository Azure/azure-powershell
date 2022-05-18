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

This Command Triggers Backup for a given backup instance using protection policy used to protect the backup instance. Then we track the backup job in a loop until it's completed.
