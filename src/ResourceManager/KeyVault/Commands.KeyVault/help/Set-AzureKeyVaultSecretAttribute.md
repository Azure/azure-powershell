---
external help file: Microsoft.Azure.Commands.KeyVault.dll-Help.xml
ms.assetid: E2A45461-6B41-42FF-A874-A4CEFC867A33
online version: http://go.microsoft.com/fwlink/?LinkId=690305
schema: 2.0.0
---

# Set-AzureKeyVaultSecretAttribute

## SYNOPSIS
Updates attributes of a secret in a key vault.

## SYNTAX

```
Set-AzureKeyVaultSecretAttribute [-VaultName] <String> [-Name] <String> [[-Version] <String>]
 [-Enable <Boolean>] [-Expires <DateTime>] [-NotBefore <DateTime>] [-ContentType <String>] [-Tag <Hashtable>]
 [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureKeyVaultSecretAttribute** cmdlet updates editable attributes of a secret in a key vault.

## EXAMPLES

### Example 1: Modify the attributes of a secret
```
PS C:\> $Expires = (Get-Date).AddYears(2).ToUniversalTime()
PS C:\> $Nbf = (Get-Date).ToUniversalTime()
PS C:\> $Tags = @{ 'Severity' = 'medium'; 'HR' = null}
PS C:\> $ContentType= 'xml'
PS C:\> Set-AzureKeyVaultSecretAttribute -VaultName 'ContosoVault' -Name 'HR' -Expires $Expires -NotBefore $Nbf -ContentType $ContentType -Enable $True -Tag $Tags -PassThru
```

The first four commands define attributes for the expiry date, the NotBefore date, tags, and
context type, and store the attributes in variables.

The final command modifies the attributes for the secret named HR in the key vault named
ContosoVault, using the stored variables.

### Example 2: Delete the tags and content type for a secret
```
PS C:\>Set-AzureKeyVaultSecretAttribute -VaultName 'ContosoVault' -Name 'HR' -Version '9EEA45C6EE50490B9C3176A80AC1A0DF' -ContentType '' -Tag -@{}
```

This command deletes the tags and the content type for the specified version of the secret named HR
in the key vault named Contoso.

### Example 3: Disable the current version of secrets whose name begins with IT
```
PS C:\> $Vault = 'ContosoVault'
PS C:\> $Prefix = 'IT'
PS C:\> Get-AzureKeyVaultSecret $Vault | Where-Object {$_.Name -like $Prefix + '*'} | Set-AzureKeyVaultSecretAttribute -Enable $False
```

The first command stores the string value Contoso in the $Vault variable.

The second command stores the string value IT in the $Prefix variable.

The third command uses the Get-AzureKeyVaultSecret cmdlet to get the secrets in the specified key
vault, and then passes those secrets to the **Where-Object** cmdlet. The **Where-Object** cmdlet
filters the secrets for names that begin with the characters IT. The command pipes the secrets that
match the filter to the Set-AzureKeyVaultSecretAttribute cmdlet, which disables them.

### Example 4: Set the ContentType for all versions of a secret
```
PS C:\>$VaultName = 'ContosoVault'
PS C:\> $Name = 'HR'
PS C:\> $ContentType = 'xml'
PS C:\> Get-AzureKeyVaultKey -VaultName $VaultName -Name $Name -IncludeVersions | Set-AzureKeyVaultSecretAttribute -ContentType $ContentType
```

The first three commands define string variables to use for the *VaultName*, *Name*, and
*ContentType* parameters. The fourth command uses the Get-AzureKeyVaultKey cmdlet to get the
specified keys, and pipes the keys to the Set-AzureKeyVaultSecretAttribute cmdlet to set their
content type to XML.

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
Specifies the content type of a secret. If you do not specify this parameter, there is no change to
the current secret's content type. To remove the existing content type, specify an empty string.

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

### -Enable
Indicates whether to enable a secret. Specify $False to disable a secret, or $True to enable a
secret. If you do not specify this parameter, there is no change to the current secret's enabled or
disabled state.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Expires
Specifies the date and time that a secret expires.

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
Specifies the name of a secret. This cmdlet constructs the fully qualified domain name (FQDN) of a
secret based on the name that this parameter specifies, the name of the key vault, and your current
environment.

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
Specifies the Coordinated Universal Time (UTC) before which the secret can't be used.
If you do not specify this parameter, there is no change to the current secret's NotBefore attribute.

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

### -PassThru
Returns an object representing the item with which you are working.
By default, this cmdlet does not generate any output.

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
Specifies the name of the key vault to modify.
This cmdlet constructs the FQDN of a key vault based on the name that this parameter specifies, and your currently selected environment.

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

### -Version
Specifies the version of a secret.
This cmdlet constructs the FQDN of a secret based on the key vault name, your currently selected environment, the secret name, and the secret version.

```yaml
Type: String
Parameter Sets: (All)
Aliases: SecretVersion

Required: False
Position: 2
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

Returns Microsoft.Azure.Commands.KeyVault.Models.Secret object if PassThru is specified. Otherwise, returns nothing.

## NOTES

## RELATED LINKS

[Get-AzureKeyVaultKey](./Get-AzureKeyVaultKey.md)

[Get-AzureKeyVaultSecret](./Get-AzureKeyVaultSecret.md)

[Remove-AzureKeyVaultSecret](./Remove-AzureKeyVaultSecret.md)