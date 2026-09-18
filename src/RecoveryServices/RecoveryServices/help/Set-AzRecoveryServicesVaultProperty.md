---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Backup.dll-Help.xml
Module Name: Az.RecoveryServices
ms.assetid: C2A7F37B-5713-4430-B83F-C6745692396D
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/set-azrecoveryservicesvaultproperty
schema: 2.0.0
---

# Set-AzRecoveryServicesVaultProperty

## SYNOPSIS
Updates properties of a Vault.

## SYNTAX

### AzureRSVaultSoftDeleteParameterSet (Default)
```
Set-AzRecoveryServicesVaultProperty [-SoftDeleteFeatureState <String>]
 [-SoftDeleteRetentionPeriodInDays <Int32>] [-DisableHybridBackupSecurityFeature <Boolean>] [-VaultId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-Token <String>] [-SecureToken <SecureString>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AzureRSVaultCMKParameterSet
```
Set-AzRecoveryServicesVaultProperty [-VaultId <String>] [-DefaultProfile <IAzureContextContainer>]
 [-Token <String>] [-SecureToken <SecureString>] -EncryptionKeyId <String> [-KeyVaultSubscriptionId <String>]
 [-InfrastructureEncryption] [-UseSystemAssignedIdentity <Boolean>] [-UserAssignedIdentity <String>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzRecoveryServicesVaultProperty** cmdlet updates properties of a Recovery services vault. This cmdlet can be used to Enable/Disable/AlwaysON soft delete or set CMK encryption for a vault with two different parameter sets. 
**SoftDeleteFeatureState** property of a vault can be disabled only if there are no registered containers in the vault. InfrastructureEncryption can only be set the first time a user updates the CMK vault.

## EXAMPLES

### Example 1: Update SoftDeleteFeatureState of a vault
```powershell
$vault = Get-AzRecoveryServicesVault -ResourceGroupName "rgName" -Name "vaultName"
$props = Set-AzRecoveryServicesVaultProperty -VaultId $vault.Id -SoftDeleteFeatureState Enable
```

The first command gets a Vault object and then stores it in the $vault variable.
The second command Updates the SoftDeleteFeatureState property of the vault to "Enabled" state. Allowed values for SoftDeleteFeatureState are Disable, Enable, AlwaysON.

### Example 2: Update CMK encryption of a vault to use SystemAssigned MSIdentity

```powershell
$vault = Get-AzRecoveryServicesVault -ResourceGroupName "rgName" -Name "vaultName"
$keyVault = Get-AzKeyVault -VaultName "keyVaultName" -ResourceGroupName "RGName" 
$key = Get-AzKeyVaultKey -VaultName "keyVaultName" -Name "keyName" 
Set-AzRecoveryServicesVaultProperty -EncryptionKeyId $key.ID -InfrastructureEncryption -VaultId $vault.ID -UseSystemAssignedIdentity $true
```

First cmdlet gets the RSVault to update encryption properties. Second cmdlet gets the azure key vault. Third cmdlet gets the key from the key vault.
Fourth cmdlet updates the customer managed encryption key within the RSVault to be accessed via SystemAssigned identity. Use -InfrastructureEncryption param to enable infrastructure encryption for the first time update. 

### Example 3: Update CMK encryption of a vault to use userAssigned MSIdentity

```powershell
$vault = Get-AzRecoveryServicesVault -ResourceGroupName "rgName" -Name "vaultName"
$keyVault = Get-AzKeyVault -VaultName "keyVaultName" -ResourceGroupName "RGName" 
$key = Get-AzKeyVaultKey -VaultName "keyVaultName" -Name "keyName" 
Set-AzRecoveryServicesVaultProperty -EncryptionKeyId $key.ID -VaultId $vault.ID -UseSystemAssignedIdentity $false -UserAssignedIdentity $vault.Identity.UserAssignedIdentities.Keys[0]
```

First cmdlet gets the RSVault to update encryption properties. Second cmdlet gets the azure key vault. Third cmdlet gets the key from the key vault.
Fourth cmdlet updates the customer managed encryption key within the RSVault to be accessed via UserAssigned identity.

### Example 4: Update HybridBackupSecurityFeature of a vault

```powershell
$vault = Get-AzRecoveryServicesVault -ResourceGroupName "rgName" -Name "vaultName"
$prop = Set-AzRecoveryServicesVaultProperty -VaultId $vault.Id -DisableHybridBackupSecurityFeature $false
```

The first command gets a Vault object and then stores it in the $vault variable.
The second command disables the HybridBackupSecurityFeature of the vault, set $true to enable it again.

### Example 5: Update SoftDeleteFeatureState and HybridBackupSecurityFeature to AlwaysON

```powershell
$vault = Get-AzRecoveryServicesVault -ResourceGroupName "rgName" -Name "vaultName" 
$prop = Set-AzRecoveryServicesVaultProperty -VaultId $vault.Id -SoftDeleteFeatureState AlwaysON
```

The first command gets a Vault object and then stores it in the $vault variable.
The second command sets the SoftDeleteFeatureState of the vault to "AlwaysON", which will also set the HybridBackupSecurityFeature to AlwaysON. Additionally, the SoftDeleteRetentionPeriodInDays parameter is used to set the soft delete retention period to 16 days. 

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableHybridBackupSecurityFeature
Optional flag ($true/$false) to disable/enable security setting for hybrid backups against accidental deletes and add additional layer of authentication for critical operations. Provide $false to enable the security.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: AzureRSVaultSoftDeleteParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionKeyId
KeyId of the encryption key to be used for CMK.

```yaml
Type: System.String
Parameter Sets: AzureRSVaultCMKParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InfrastructureEncryption
Enables infrastructure encryption on this vault. Infrastructure encryption must be enabled when configuring encryption.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AzureRSVaultCMKParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultSubscriptionId
Subscription Id of the Key Vault.

```yaml
Type: System.String
Parameter Sets: AzureRSVaultCMKParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecureToken
Parameter to authorize operations protected by cross tenant resource guard. Use command (Get-AzAccessToken -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx").Token to fetch authorization token for different tenant

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SoftDeleteFeatureState
SoftDeleteFeatureState of the Recovery Services Vault. Allowed values are Disable, Enable, AlwaysON.

```yaml
Type: System.String
Parameter Sets: AzureRSVaultSoftDeleteParameterSet
Aliases:
Accepted values: Enable, Disable, AlwaysON

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SoftDeleteRetentionPeriodInDays
Specifies the retention period for soft deleted items in days.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: AzureRSVaultSoftDeleteParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Token
Auxiliary access token for authenticating critical operation to resource guard subscription

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

### -UserAssignedIdentity
ARM Id of UserAssigned Identity to be used for CMK encryption. Provide this parameter if UseSystemAssignedIdentity is $false.

```yaml
Type: System.String
Parameter Sets: AzureRSVaultCMKParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseSystemAssignedIdentity
Boolean flag to indicate if SystemAssigned Identity will be used for CMK encryption. Accepted Values: $true, $false

```yaml
Type: System.Boolean
Parameter Sets: AzureRSVaultCMKParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultId
ARM ID of the Recovery Services Vault.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### System.String

### Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.VaultSoftDeleteFeatureState

## OUTPUTS

### Microsoft.Azure.Management.RecoveryServices.Backup.Models.BackupResourceVaultConfigResource

## NOTES

## RELATED LINKS

[Get-AzRecoveryServicesVault](./Get-AzRecoveryServicesVault.md)

[Get-AzRecoveryServicesVaultProperty](./Get-AzRecoveryServicesVaultProperty.md)
