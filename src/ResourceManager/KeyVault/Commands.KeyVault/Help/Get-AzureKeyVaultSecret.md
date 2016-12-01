---
external help file: Microsoft.Azure.Commands.KeyVault.dll-Help.xml
ms.assetid: 8C9B33EE-10DE-4803-B76D-FE9FC2AC3372
online version: 
schema: 2.0.0
---

# Get-AzureKeyVaultSecret

## SYNOPSIS
Gets the secrets in a key vault.

## SYNTAX

### ByVaultName (Default)
```
Get-AzureKeyVaultSecret [-VaultName] <String> [<CommonParameters>]
```

### BySecretVersions
```
Get-AzureKeyVaultSecret [-VaultName] <String> [-Name] <String> [-IncludeVersions] [<CommonParameters>]
```

### BySecretName
```
Get-AzureKeyVaultSecret [-VaultName] <String> [-Name] <String> [[-Version] <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureKeyVaultSecret** cmdlet gets secrets in a key vault.
This cmdlet gets a specific secret or all the secrets in a key vault.

## EXAMPLES

### Example 1: Get all current versions of all secrets in a key vault
```
PS C:\>Get-AzureKeyVaultSecret -VaultName 'Contoso'
```

This command gets the current versions of all secrets in the key vault named Contoso.

### Example 2: Get all versions of a specific secret
```
PS C:\>Get-AzureKeyVaultSecret -VaultName 'Contoso' -Name 'ITSecret' -IncludeVersions
```

This command gets all versions of the secret named ITSecret in the key vault named Contoso.

### Example 3: Get the current version of a specific secret
```
PS C:\>Get-AzureKeyVaultSecret -VaultName 'Contoso' -Name 'ITSecret'
```

This command gets the current version of the secret named ITSecret in the key vault named Contoso.

### Example 4: Get a specific version of a specific secret
```
PS C:\>Get-AzureKeyVaultSecret -VaultName 'Contoso' -Name 'ITSecret' -Version '6A12A286385949DB8B5F82AFEF85CAE9'
```

This command gets a specific version of the secret named ITSecret in the key vault named Contoso.

### Example 5: Get the plain text value of the current version of a specific secret
```
PS C:\>$secret = Get-AzureKeyVaultSecret -VaultName 'Contoso' -Name 'ITSecret'
PS C:\> Write-Host "Secret Value is: " $secret.SecretValueText
```

These commands get the current version of a secret named ITSecret, and then displays the plain text value of that secret.

## PARAMETERS

### -IncludeVersions
Indicates that this cmdlet gets all versions of a secret.
The current version of a secret is the first one on the list.
If you specify this parameter you must also specify the *Name* and *VaultName* parameters.

If you do not specify the *IncludeVersions* parameter, this cmdlet gets the current version of the secret with the specified *Name*.

```yaml
Type: SwitchParameter
Parameter Sets: BySecretVersions
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the name of the secret to get.

```yaml
Type: String
Parameter Sets: BySecretVersions, BySecretName
Aliases: SecretName

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VaultName
Specifies the name of the key vault to which the secret belongs.
This cmdlet constructs the fully qualified domain name (FQDN) of a key vault based on the name that this parameter specifies and your current environment.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Version
Specifies the secret version.
This cmdlet constructs the FQDN of a secret based on the key vault name, your currently selected environment, the secret name, and the secret version.

```yaml
Type: String
Parameter Sets: BySecretName
Aliases: SecretVersion

Required: False
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### String

## OUTPUTS

### List<Microsoft.Azure.Commands.KeyVault.Models.Secret>, Microsoft.Azure.Commands.KeyVault.Models.Secret

## NOTES

## RELATED LINKS

[Remove-AzureKeyVaultSecret](./Remove-AzureKeyVaultSecret.md)

[Set-AzureKeyVaultSecret](./Set-AzureKeyVaultSecret.md)


