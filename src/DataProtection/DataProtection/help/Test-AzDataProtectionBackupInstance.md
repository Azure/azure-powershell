---
external help file: Az.DataProtection-help.xml
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/test-azdataprotectionbackupinstance
schema: 2.0.0
---

# Test-AzDataProtectionBackupInstance

## SYNOPSIS
Validate whether validate for backup instance will be successful or not

## SYNTAX

### ValidateViaIdentityBackupVault (Default)
```
Test-AzDataProtectionBackupInstance -BackupVaultInputObject <IDataProtectionIdentity> -Name <String>
 -ValidateForModifyBackupRequest <IValidateForModifyBackupRequest> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ValidateViaIdentityBackupVaultExpanded1
```
Test-AzDataProtectionBackupInstance -BackupVaultInputObject <IDataProtectionIdentity> -Name <String>
 -RestoreRequestObject <IAzureBackupRestoreRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ValidateViaIdentityBackupVaultExpanded
```
Test-AzDataProtectionBackupInstance -BackupVaultInputObject <IDataProtectionIdentity> -Name <String>
 -BackupInstance <IBackupInstance> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ValidateViaJsonString2
```
Test-AzDataProtectionBackupInstance -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -VaultName <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ValidateViaJsonString1
```
Test-AzDataProtectionBackupInstance -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -VaultName <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ValidateViaJsonFilePath2
```
Test-AzDataProtectionBackupInstance -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -VaultName <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ValidateViaJsonFilePath1
```
Test-AzDataProtectionBackupInstance -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -VaultName <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ValidateViaIdentityBackupVault1
```
Test-AzDataProtectionBackupInstance -Name <String> -BackupVault1InputObject <IDataProtectionIdentity>
 -Parameter <IValidateRestoreRequestObject> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ValidateViaJsonString
```
Test-AzDataProtectionBackupInstance -ResourceGroupName <String> [-SubscriptionId <String>] -VaultName <String>
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ValidateViaJsonFilePath
```
Test-AzDataProtectionBackupInstance -ResourceGroupName <String> [-SubscriptionId <String>] -VaultName <String>
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Validate whether validate for backup instance will be successful or not

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

### -BackupInstance
Backup Instance

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IBackupInstance
Parameter Sets: ValidateViaIdentityBackupVaultExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackupVault1InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity
Parameter Sets: ValidateViaIdentityBackupVault1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -BackupVaultInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity
Parameter Sets: ValidateViaIdentityBackupVault, ValidateViaIdentityBackupVaultExpanded1, ValidateViaIdentityBackupVaultExpanded
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

### -JsonFilePath
Path of Json file supplied to the Validate operation

```yaml
Type: System.String
Parameter Sets: ValidateViaJsonFilePath2, ValidateViaJsonFilePath1, ValidateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Validate operation

```yaml
Type: System.String
Parameter Sets: ValidateViaJsonString2, ValidateViaJsonString1, ValidateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the backup instance.

```yaml
Type: System.String
Parameter Sets: ValidateViaIdentityBackupVault, ValidateViaIdentityBackupVaultExpanded1, ValidateViaIdentityBackupVaultExpanded, ValidateViaJsonString2, ValidateViaJsonString1, ValidateViaJsonFilePath2, ValidateViaJsonFilePath1, ValidateViaIdentityBackupVault1
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

### -Parameter
Validate restore request object

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IValidateRestoreRequestObject
Parameter Sets: ValidateViaIdentityBackupVault1
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
Parameter Sets: ValidateViaJsonString2, ValidateViaJsonString1, ValidateViaJsonFilePath2, ValidateViaJsonFilePath1, ValidateViaJsonString, ValidateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestoreRequestObject
Gets or sets the restore request object.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IAzureBackupRestoreRequest
Parameter Sets: ValidateViaIdentityBackupVaultExpanded1
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
Parameter Sets: ValidateViaJsonString2, ValidateViaJsonString1, ValidateViaJsonFilePath2, ValidateViaJsonFilePath1, ValidateViaJsonString, ValidateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValidateForModifyBackupRequest
Validate for modify backup request

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IValidateForModifyBackupRequest
Parameter Sets: ValidateViaIdentityBackupVault
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -VaultName
The name of the backup vault.

```yaml
Type: System.String
Parameter Sets: ValidateViaJsonString2, ValidateViaJsonString1, ValidateViaJsonFilePath2, ValidateViaJsonFilePath1, ValidateViaJsonString, ValidateViaJsonFilePath
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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IValidateForModifyBackupRequest

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IValidateRestoreRequestObject

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IOperationJobExtendedInfo

## NOTES

## RELATED LINKS
