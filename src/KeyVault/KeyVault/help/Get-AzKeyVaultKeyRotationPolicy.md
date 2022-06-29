---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version:
schema: 2.0.0
---

# Get-AzKeyVaultKeyRotationPolicy

## SYNOPSIS
Gets the key rotation policy for the specified key in Key Vault.

## SYNTAX

### ByVaultName (Default)
```
Get-AzKeyVaultKeyRotationPolicy [-VaultName] <String> [-Name] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByKeyInputObject
```
Get-AzKeyVaultKeyRotationPolicy [-InputObject] <PSKeyVaultKeyIdentityItem>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
This cmdlet requires the keys/get permission. It returns key rotation policy for the specified key.

## EXAMPLES

### Example 1
```powershell
Get-AzKeyVaultKeyRotationPolicy -VaultName test-kv -Name test-key
```

```output
Id              :
VaultName       : test-kv
KeyName         : test-key
LifetimeActions : {[Action: Notify, TimeAfterCreate: , TimeBeforeExpiry: P30D]}
ExpiresIn       :
CreatedOn       :
UpdatedOn       :
```

This cmdlet gets the key rotation policy for test-kv.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultKeyIdentityItem

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyRotationPolicy

## NOTES

## RELATED LINKS

[Set-AzKeyVaultKeyRotationPolicy.md](./Set-AzKeyVaultKeyRotationPolicy.md)

[Invoke-AzKeyVaultKeyRotation.md](./Invoke-AzKeyVaultKeyRotation.md)