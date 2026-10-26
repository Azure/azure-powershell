---
external help file:
Module Name: Az.Commvault
online version: https://learn.microsoft.com/powershell/module/az.commvault/stop-azcommvaultprotectiongroupbackup
schema: 2.0.0
---

# Stop-AzCommvaultProtectionGroupBackup

## SYNOPSIS
Stop Backup for a Protection Group

## SYNTAX

### StopExpanded (Default)
```
Stop-AzCommvaultProtectionGroupBackup -CloudAccountName <String> -ProtectionGroupName <String>
 -ResourceGroupName <String> -Reason <String> [-SubscriptionId <String>] [-Comment <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Stop
```
Stop-AzCommvaultProtectionGroupBackup -CloudAccountName <String> -ProtectionGroupName <String>
 -ResourceGroupName <String> -Request <IStopBackupProtectionGroupRequest> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StopViaIdentity
```
Stop-AzCommvaultProtectionGroupBackup -InputObject <ICommvaultIdentity>
 -Request <IStopBackupProtectionGroupRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StopViaIdentityCloudAccount
```
Stop-AzCommvaultProtectionGroupBackup -CloudAccountInputObject <ICommvaultIdentity>
 -ProtectionGroupName <String> -Request <IStopBackupProtectionGroupRequest> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StopViaIdentityCloudAccountExpanded
```
Stop-AzCommvaultProtectionGroupBackup -CloudAccountInputObject <ICommvaultIdentity>
 -ProtectionGroupName <String> -Reason <String> [-Comment <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StopViaIdentityExpanded
```
Stop-AzCommvaultProtectionGroupBackup -InputObject <ICommvaultIdentity> -Reason <String> [-Comment <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StopViaJsonFilePath
```
Stop-AzCommvaultProtectionGroupBackup -CloudAccountName <String> -ProtectionGroupName <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StopViaJsonString
```
Stop-AzCommvaultProtectionGroupBackup -CloudAccountName <String> -ProtectionGroupName <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Stop Backup for a Protection Group

## EXAMPLES

### Example 1: Stop the backups of a protection group
```powershell
Stop-AzCommvaultProtectionGroupBackup -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -ProtectionGroupName pg-prod-vms -Reason 'Maintenance' -Comment 'Planned maintenance window'
```

Stops the scheduled backups of the protection group and records the reason and a comment.

### Example 2: Stop the backups of a protection group by using a JSON request
```powershell
Stop-AzCommvaultProtectionGroupBackup -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -ProtectionGroupName pg-prod-vms -JsonString '{"reason":"Maintenance","comment":"Planned maintenance window"}'
```

Stops the scheduled backups by passing the request body as a JSON string.

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

### -CloudAccountInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity
Parameter Sets: StopViaIdentityCloudAccount, StopViaIdentityCloudAccountExpanded
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
Parameter Sets: Stop, StopExpanded, StopViaJsonFilePath, StopViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Comment
Any further comments

```yaml
Type: System.String
Parameter Sets: StopExpanded, StopViaIdentityCloudAccountExpanded, StopViaIdentityExpanded
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity
Parameter Sets: StopViaIdentity, StopViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Stop operation

```yaml
Type: System.String
Parameter Sets: StopViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Stop operation

```yaml
Type: System.String
Parameter Sets: StopViaJsonString
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

### -PassThru
Returns true when the command succeeds

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

### -ProtectionGroupName
Name of the ProtectionGroup resource

```yaml
Type: System.String
Parameter Sets: Stop, StopExpanded, StopViaIdentityCloudAccount, StopViaIdentityCloudAccountExpanded, StopViaJsonFilePath, StopViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Reason
The reason for stopping the backup

```yaml
Type: System.String
Parameter Sets: StopExpanded, StopViaIdentityCloudAccountExpanded, StopViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Request
The properties of StopBackupProtectionGroupRequest

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.IStopBackupProtectionGroupRequest
Parameter Sets: Stop, StopViaIdentity, StopViaIdentityCloudAccount
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
Parameter Sets: Stop, StopExpanded, StopViaJsonFilePath, StopViaJsonString
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
Parameter Sets: Stop, StopExpanded, StopViaJsonFilePath, StopViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.IStopBackupProtectionGroupRequest

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

