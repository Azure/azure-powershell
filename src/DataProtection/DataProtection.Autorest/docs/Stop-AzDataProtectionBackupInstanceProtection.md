---
external help file:
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/stop-azdataprotectionbackupinstanceprotection
schema: 2.0.0
---

# Stop-AzDataProtectionBackupInstanceProtection

## SYNOPSIS
This operation will stop protection of a backup instance and data will be held forever

## SYNTAX

### Stop (Default)
```
Stop-AzDataProtectionBackupInstanceProtection -BackupInstanceName <String> -ResourceGroupName <String>
 -VaultName <String> [-SubscriptionId <String>] [-Token <String>] [-AsJob] [-DefaultProfile <PSObject>]
 [-NoWait] [-PassThru] [-ResourceGuardOperationRequest <String[]>] [-SecureToken <SecureString>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### StopViaIdentity
```
Stop-AzDataProtectionBackupInstanceProtection -InputObject <IDataProtectionIdentity> [-Token <String>]
 [-AsJob] [-DefaultProfile <PSObject>] [-NoWait] [-PassThru] [-ResourceGuardOperationRequest <String[]>]
 [-SecureToken <SecureString>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StopViaIdentityBackupVault
```
Stop-AzDataProtectionBackupInstanceProtection -BackupInstanceName <String>
 -BackupVaultInputObject <IDataProtectionIdentity> -Parameter <IStopProtectionRequest> [-Token <String>]
 [-AsJob] [-DefaultProfile <PSObject>] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StopViaIdentityBackupVaultExpanded
```
Stop-AzDataProtectionBackupInstanceProtection -BackupInstanceName <String>
 -BackupVaultInputObject <IDataProtectionIdentity> [-Token <String>] [-AsJob] [-DefaultProfile <PSObject>]
 [-NoWait] [-PassThru] [-ResourceGuardOperationRequest <String[]>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StopViaJsonFilePath
```
Stop-AzDataProtectionBackupInstanceProtection -BackupInstanceName <String> -ResourceGroupName <String>
 -VaultName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-Token <String>] [-AsJob]
 [-DefaultProfile <PSObject>] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### StopViaJsonString
```
Stop-AzDataProtectionBackupInstanceProtection -BackupInstanceName <String> -ResourceGroupName <String>
 -VaultName <String> -JsonString <String> [-SubscriptionId <String>] [-Token <String>] [-AsJob]
 [-DefaultProfile <PSObject>] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This operation will stop protection of a backup instance and data will be held forever

## EXAMPLES

### Example 1: Stop protection for a backup instance
```powershell
Stop-AzDataProtectionBackupInstanceProtection -ResourceGroupName "rgName" -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx" -VaultName "vaultName" -BackupInstanceName $backupInstance.BackupInstanceName
```

The above command can be used to stop protection of a backup instance

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
Parameter Sets: Stop, StopViaIdentityBackupVault, StopViaIdentityBackupVaultExpanded, StopViaJsonFilePath, StopViaJsonString
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
Parameter Sets: StopViaIdentityBackupVault, StopViaIdentityBackupVaultExpanded
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
Parameter Sets: StopViaIdentity
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

### -Parameter
Request body of Stop protection when MUA is Enabled

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IStopProtectionRequest
Parameter Sets: StopViaIdentityBackupVault
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
Parameter Sets: Stop, StopViaJsonFilePath, StopViaJsonString
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
Parameter Sets: Stop, StopViaIdentity, StopViaIdentityBackupVaultExpanded
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
Parameter Sets: Stop, StopViaIdentity
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
Parameter Sets: Stop, StopViaJsonFilePath, StopViaJsonString
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
Parameter Sets: Stop, StopViaJsonFilePath, StopViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IStopProtectionRequest

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

