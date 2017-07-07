---
external help file: Microsoft.Azure.Commands.KeyVault.dll-Help.xml
ms.assetid: 9FC72DE9-46BB-4CB5-9880-F53756DBE012
online version: http://go.microsoft.com/fwlink/?LinkId=690303
schema: 2.0.0
---

# Set-AzureKeyVaultSecret

## SYNOPSIS
Creates or updates a secret in a key vault.

## SYNTAX

```
Set-AzureKeyVaultSecret [-VaultName] <String> [-Name] <String> [-SecretValue] <SecureString> [-Disable]
 [-Expires <DateTime>] [-NotBefore <DateTime>] [-ContentType <String>] [-Tag <Hashtable>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureKeyVaultSecret** cmdlet creates or updates a secret in a key vault in Azure Key
Vault. If the secret does not exist, this cmdlet creates it. If the secret already exists, this
cmdlet creates a new version of that secret.

## EXAMPLES

### Example 1: Modify the value of a secret using default attributes
```
PS C:\> $Secret = ConvertTo-SecureString -String 'Password' -AsPlainText -Force
PS C:\> Set-AzureKeyVaultSecret -VaultName 'Contoso' -Name 'ITSecret' -SecretValue $Secret
```

The first command converts a string into a secure string by using the **ConvertTo-SecureString**
cmdlet, and then stores that string in the $Secret variable. For more information, type `Get-Help
ConvertTo-SecureString`.

The second command modifies value of the secret named ITSecret in the key vault named Contoso. The
secret value becomes the value stored in $Secret.

### Example 2: Modify the value of a secret using custom attributes
```
PS C:\> $Secret = ConvertTo-SecureString -String 'Password' -AsPlainText -Force
PS C:\> $Expires = (Get-Date).AddYears(2).ToUniversalTime()
PS C:\> $NBF =(Get-Date).ToUniversalTime()
PS C:\> $Tags = @{ 'Severity' = 'medium'; 'IT' = null }
PS C:\> $ContentType = 'txt'
PS C:\> Set-AzureKeyVaultSecret -VaultName 'Contoso' -Name 'ITSecret' -SecretValue $Secret -Expires $Expires -NotBefore $NBF -ContentType $ContentType -Disable $False -Tags $Tags
```

The first command converts a string into a secure string by using the **ConvertTo-SecureString**
cmdlet, and then stores that string in the $Secret variable. For more information, type `Get-Help
ConvertTo-SecureString`.

The next commands define custom attributes for the expiry date, tags, and context type, and store
the attributes in variables.

The final command modifies values of the secret named ITSecret in the key vault named Contoso, by
using the values specified previously as variables.

## PARAMETERS

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContentType
Specifies the content type of a secret.
To delete the existing content type, specify an empty string.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Disable
Indicates that this cmdlet disables a secret.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Expires
Specifies the expiration time, as a **DateTime** object, for the secret that this cmdlet updates.
This parameter uses Coordinated Universal Time (UTC). To obtain a **DateTime** object, use the
**Get-Date** cmdlet. For more information, type `Get-Help Get-Date`.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the name of a secret to modify. This cmdlet constructs the fully qualified domain name
(FQDN) of a secret based on the name that this parameter specifies, the name of the key vault, and
your current environment.

```yaml
Type: String
Parameter Sets: (All)
Aliases: SecretName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NotBefore
Specifies the time, as a **DateTime** object, before which the secret cannot be used. This
parameter uses UTC. To obtain a **DateTime** object, use the **Get-Date** cmdlet.

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SecretValue
Specifies the value for the secret as a **SecureString** object. To obtain a **SecureString**
object, use the **ConvertTo-SecureString** cmdlet. For more information, type `Get-Help
ConvertTo-SecureString`.

```yaml
Type: SecureString
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Key-value pairs in the form of a hash table. For example:

@{key0="value0";key1=$null;key2="value2"}

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases: Tags

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VaultName
Specifies the name of the key vault to which this secret belongs. This cmdlet constructs the FQDN
of a key vault based on the name that this parameter specifies and your current environment.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

Microsoft.Azure.Commands.KeyVault.Models.Secret

## NOTES

## RELATED LINKS

[Get-AzureKeyVaultSecret](./Get-AzureKeyVaultSecret.md)

[Remove-AzureKeyVaultSecret](./Remove-AzureKeyVaultSecret.md)
