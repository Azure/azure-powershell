---
external help file:
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/test-azdataprotectionbackupinstanceupdate
schema: 2.0.0
---

# Test-AzDataProtectionBackupInstanceUpdate

## SYNOPSIS
Validate whether update for backup instance will be successful or not

## SYNTAX

```
Test-AzDataProtectionBackupInstanceUpdate -Name <String> -ResourceGroupName <String> -VaultName <String>
 -BackupInstance <IBackupInstance> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Validate whether update for backup instance will be successful or not

## EXAMPLES

### Example 1: Validate for modify backup instance operation
```powershell
$backupInstanceResource = Get-AzDataProtectionBackupInstance -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId | Where-Object { $_.Name -match $backupInstanceName }
$backupInstanceResource.Property.PolicyInfo.PolicyId = $newPolicyARMId

Test-AzDataProtectionBackupInstanceUpdate -Name $backupInstanceResource.Name -ResourceGroupName $ResourceGroupName -VaultName $VaultName -SubscriptionId $SubscriptionId -BackupInstance $backupInstanceResource.Property
```

```output
ObjectType               JobId
----------               -----
OperationJobExtendedInfo
```

First command gets the backup instance resource and updates the policy id.
Second command validates whether the update operation will be successful or not.
If the output is coming as OperationJobExtendedInfo, then the update operation will be successful and can be continued with Update-AzDataProtectionBackupInstance cmdlet.

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

### -BackupInstance
Backup Instance
To construct, see NOTES section for BACKUPINSTANCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250201.IBackupInstance
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

### -Name
The name of the backup instance.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: BackupInstanceName

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

### -VaultName
The name of the backup vault.

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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250201.IOperationJobExtendedInfo

## NOTES

## RELATED LINKS

