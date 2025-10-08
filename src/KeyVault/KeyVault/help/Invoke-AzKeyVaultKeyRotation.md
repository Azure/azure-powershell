---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://learn.microsoft.com/powershell/module/az.keyvault/invoke-azkeyvaultkeyrotation
schema: 2.0.0
---

# Invoke-AzKeyVaultKeyRotation

## SYNOPSIS
Creates a new key version in Key Vault, stores it, then returns the new key.

## SYNTAX

### ByVaultName (Default)
```
Invoke-AzKeyVaultKeyRotation [-VaultName] <String> [-Name] <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByKeyInputObject
```
Invoke-AzKeyVaultKeyRotation [-InputObject] <PSKeyVaultKeyIdentityItem>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The cmdlet will rotate the key based on the key policy. It requires the keys/rotate permission. It will returns a new version of the rotate key.

## EXAMPLES

### Example 1
```powershell
Invoke-AzKeyVaultKeyRotation -VaultName test-kv -Name test-key
```

```output
Vault/HSM Name : test-kv
Name           : test-key
Key Type       : RSA
Key Size       : 2048
Curve Name     :
Version        : xxxxxxxxxxxxxx4939xxxxxxxxxxxxxxxx
Id             : https://test-kv.vault.azure.net:443/keys/test-key/xxxxxxxxxxxxxx4939xxxxxxxxxxxxxxxx
Enabled        : True
Expires        :
Not Before     :
Created        : 12/10/2021 2:57:58 AM
Updated        : 12/10/2021 2:57:58 AM
Recovery Level : Recoverable+Purgeable
Tags           :
```

This cmdlet creates a new key version for test-key.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -InputObject
Key object

```yaml
Type: Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultKeyIdentityItem
Parameter Sets: ByKeyInputObject
Aliases: Key

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Key name.

```yaml
Type: System.String
Parameter Sets: ByVaultName
Aliases: KeyName

Required: True
Position: 1
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

### -VaultName
Vault name.

```yaml
Type: System.String
Parameter Sets: ByVaultName
Aliases:

Required: True
Position: 0
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

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultKeyIdentityItem

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultKey

## NOTES

## RELATED LINKS

[Get-AzKeyVaultKeyRotationPolicy.md](./Get-AzKeyVaultKeyRotationPolicy.md)

[Set-AzKeyVaultKeyRotationPolicy.md](./Set-AzKeyVaultKeyRotationPolicy.md)
