---
external help file: Az.DataProtection-help.xml
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/suspend-azdataprotectionbackupinstancebackup
schema: 2.0.0
---

# Suspend-AzDataProtectionBackupInstanceBackup

## SYNOPSIS
This operation will stop backup for a backup instance and retains the backup data as per the policy (except latest Recovery point, which will be retained forever)

## SYNTAX

### Suspend (Default)
```
Suspend-AzDataProtectionBackupInstanceBackup -BackupInstanceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -VaultName <String> [-Token <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-ResourceGuardOperationRequest <String[]>] [-SecureToken <SecureString>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SuspendViaJsonString
```
Suspend-AzDataProtectionBackupInstanceBackup -BackupInstanceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -VaultName <String> [-Token <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] -JsonString <String> [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SuspendViaJsonFilePath
```
Suspend-AzDataProtectionBackupInstanceBackup -BackupInstanceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -VaultName <String> [-Token <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] -JsonFilePath <String> [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SuspendViaIdentityBackupVaultExpanded
```
Suspend-AzDataProtectionBackupInstanceBackup -BackupInstanceName <String>
 -BackupVaultInputObject <IDataProtectionIdentity> [-Token <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-ResourceGuardOperationRequest <String[]>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SuspendViaIdentityBackupVault
```
Suspend-AzDataProtectionBackupInstanceBackup -BackupInstanceName <String>
 -BackupVaultInputObject <IDataProtectionIdentity> [-Token <String>] -Parameter <ISuspendBackupRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### SuspendViaIdentity
```
Suspend-AzDataProtectionBackupInstanceBackup [-Token <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-ResourceGuardOperationRequest <String[]>] [-SecureToken <SecureString>]
 -InputObject <IDataProtectionIdentity> [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
This operation will stop backup for a backup instance and retains the backup data as per the policy (except latest Recovery point, which will be retained forever)

## EXAMPLES

### Example 1: Suspend backups for a backup instance
```powershell
Suspend-AzDataProtectionBackupInstanceBackup -ResourceGroupName "rgName" -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx" -VaultName "vaultName" -BackupInstanceName $backupInstance.BackupInstanceName
```

The above command can be used to stop backups of a backup instance, this will move the backup instance to a suspended state.

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
Parameter Sets: Suspend, SuspendViaJsonString, SuspendViaJsonFilePath, SuspendViaIdentityBackupVaultExpanded, SuspendViaIdentityBackupVault
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackupVaultInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity
Parameter Sets: SuspendViaIdentityBackupVaultExpanded, SuspendViaIdentityBackupVault
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
Identity Parameter To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity
Parameter Sets: SuspendViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Suspend operation

```yaml
Type: System.String
Parameter Sets: SuspendViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Suspend operation

```yaml
Type: System.String
Parameter Sets: SuspendViaJsonString
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
Request body of Suspend backup when MUA is Enabled

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.ISuspendBackupRequest
Parameter Sets: SuspendViaIdentityBackupVault
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Suspend, SuspendViaJsonString, SuspendViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGuardOperationRequest
ResourceGuardOperationRequests on which LAC check will be performed

```yaml
Type: System.String[]
Parameter Sets: Suspend, SuspendViaIdentityBackupVaultExpanded, SuspendViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecureToken
Parameter to authorize operations protected by cross tenant resource guard.
Use command (Get-AzAccessToken -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -AsSecureString").Token to fetch authorization token for different tenant.

```yaml
Type: System.Security.SecureString
Parameter Sets: Suspend, SuspendViaIdentity
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
Parameter Sets: Suspend, SuspendViaJsonString, SuspendViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Token
Parameter deprecate.
Please use SecureToken instead.

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
Parameter Sets: Suspend, SuspendViaJsonString, SuspendViaJsonFilePath
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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.ISuspendBackupRequest

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
