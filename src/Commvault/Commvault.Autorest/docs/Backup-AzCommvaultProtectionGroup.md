---
external help file:
Module Name: Az.Commvault
online version: https://learn.microsoft.com/powershell/module/az.commvault/backup-azcommvaultprotectiongroup
schema: 2.0.0
---

# Backup-AzCommvaultProtectionGroup

## SYNOPSIS
Ad-hoc backup of protected items resource in given protection group.

## SYNTAX

### BackupViaIdentity (Default)
```
Backup-AzCommvaultProtectionGroup -InputObject <ICommvaultIdentity> -Request <IBackupProtectionGroupRequest>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Backup
```
Backup-AzCommvaultProtectionGroup -CloudAccountName <String> -Name <String> -ResourceGroupName <String>
 -Request <IBackupProtectionGroupRequest> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### BackupExpanded
```
Backup-AzCommvaultProtectionGroup -CloudAccountName <String> -Name <String> -ResourceGroupName <String>
 -BackupOptionBackupCopyImmediately -BackupOptionJobDescription <String>
 -BackupOptionNotifyUserOnJobCompletion -BackupOptionRunSnapShotBackup -VMList <IVMListItem[]>
 [-SubscriptionId <String>] [-BackupOptionBackupLevel <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### BackupViaIdentityCloudAccount
```
Backup-AzCommvaultProtectionGroup -CloudAccountInputObject <ICommvaultIdentity> -Name <String>
 -Request <IBackupProtectionGroupRequest> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### BackupViaIdentityCloudAccountExpanded
```
Backup-AzCommvaultProtectionGroup -CloudAccountInputObject <ICommvaultIdentity> -Name <String>
 -BackupOptionBackupCopyImmediately -BackupOptionJobDescription <String>
 -BackupOptionNotifyUserOnJobCompletion -BackupOptionRunSnapShotBackup -VMList <IVMListItem[]>
 [-BackupOptionBackupLevel <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### BackupViaIdentityExpanded
```
Backup-AzCommvaultProtectionGroup -InputObject <ICommvaultIdentity> -BackupOptionBackupCopyImmediately
 -BackupOptionJobDescription <String> -BackupOptionNotifyUserOnJobCompletion -BackupOptionRunSnapShotBackup
 -VMList <IVMListItem[]> [-BackupOptionBackupLevel <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### BackupViaJsonFilePath
```
Backup-AzCommvaultProtectionGroup -CloudAccountName <String> -Name <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### BackupViaJsonString
```
Backup-AzCommvaultProtectionGroup -CloudAccountName <String> -Name <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Ad-hoc backup of protected items resource in given protection group.

## EXAMPLES

### Example 1: Run an ad-hoc backup of a virtual machine
```powershell
Backup-AzCommvaultProtectionGroup -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -Name pg-prod-vms -BackupOptionBackupCopyImmediately -BackupOptionJobDescription 'Ad-hoc backup job' -BackupOptionNotifyUserOnJobCompletion -BackupOptionRunSnapShotBackup -VMList @{ VMGuid = '40000000-aaaa-4bbb-8ccc-000000000000' }
```

Starts an ad-hoc backup job for the specified virtual machine in the protection group.

### Example 2: Run an ad-hoc backup by using a JSON request
```powershell
Backup-AzCommvaultProtectionGroup -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -Name pg-prod-vms -JsonString '{"vmList":[{"vmGuid":"40000000-aaaa-4bbb-8ccc-000000000000"}],"backupOptions":{"backupLevel":"FULL","jobDescription":"Ad-hoc backup job","backupCopyImmediately":true,"runSnapShotBackup":true,"notifyUserOnJobCompletion":true}}'
```

Starts a full ad-hoc backup job by passing the request body as a JSON string.

## PARAMETERS

### -BackupOptionBackupCopyImmediately
Indicates whether to run backup immediately or not for the VM

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: BackupExpanded, BackupViaIdentityCloudAccountExpanded, BackupViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackupOptionBackupLevel
Indicates whether to stop backup or not for the VM

```yaml
Type: System.String
Parameter Sets: BackupExpanded, BackupViaIdentityCloudAccountExpanded, BackupViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackupOptionJobDescription
The name of the backup job to be shown in Commvault

```yaml
Type: System.String
Parameter Sets: BackupExpanded, BackupViaIdentityCloudAccountExpanded, BackupViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackupOptionNotifyUserOnJobCompletion
Indicates whether to notify the user on job completion

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: BackupExpanded, BackupViaIdentityCloudAccountExpanded, BackupViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackupOptionRunSnapShotBackup
Indicates whether to run snapshot backup or not for the VM, if false, it will run regular backup

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: BackupExpanded, BackupViaIdentityCloudAccountExpanded, BackupViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CloudAccountInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity
Parameter Sets: BackupViaIdentityCloudAccount, BackupViaIdentityCloudAccountExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CloudAccountName
Name of the Cloud Account resource

```yaml
Type: System.String
Parameter Sets: Backup, BackupExpanded, BackupViaJsonFilePath, BackupViaJsonString
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity
Parameter Sets: BackupViaIdentity, BackupViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Backup operation

```yaml
Type: System.String
Parameter Sets: BackupViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Backup operation

```yaml
Type: System.String
Parameter Sets: BackupViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the ProtectionGroup resource

```yaml
Type: System.String
Parameter Sets: Backup, BackupExpanded, BackupViaIdentityCloudAccount, BackupViaIdentityCloudAccountExpanded, BackupViaJsonFilePath, BackupViaJsonString
Aliases: ProtectionGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Request
The properties of BackupProtectionGroupRequest

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.IBackupProtectionGroupRequest
Parameter Sets: Backup, BackupViaIdentity, BackupViaIdentityCloudAccount
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
Parameter Sets: Backup, BackupExpanded, BackupViaJsonFilePath, BackupViaJsonString
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
Parameter Sets: Backup, BackupExpanded, BackupViaJsonFilePath, BackupViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMList
The vm list details.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.IVMListItem[]
Parameter Sets: BackupExpanded, BackupViaIdentityCloudAccountExpanded, BackupViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.IBackupProtectionGroupRequest

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.IBackupProtectionGroupResponse

## NOTES

## RELATED LINKS

