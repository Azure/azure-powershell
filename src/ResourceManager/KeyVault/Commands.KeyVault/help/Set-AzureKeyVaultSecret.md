---
external help file: Microsoft.Azure.Commands.KeyVault.dll-Help.xml
Module Name: AzureRM.KeyVault
ms.assetid: 9FC72DE9-46BB-4CB5-9880-F53756DBE012
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.keyvault/set-azurekeyvaultsecret
schema: 2.0.0
---

# Set-AzureKeyVaultSecret

## SYNOPSIS
Creates or updates a secret in a key vault.

## SYNTAX

### DefaultAttribute (Default)
```
Set-AzureKeyVaultSecret [-VaultName] <String> [-Name] <String> [[-Version] <String>] [-Enable <Boolean>]
 [-Expires <DateTime>] [-NotBefore <DateTime>] [-ContentType <String>] [-Tag <Hashtable>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Default
```
Set-AzureKeyVaultSecret [-VaultName] <String> [-Name] <String> [-SecretValue] <SecureString> [-Disable]
 [-Expires <DateTime>] [-NotBefore <DateTime>] [-ContentType <String>] [-Tag <Hashtable>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputObject
```
Set-AzureKeyVaultSecret [-InputObject] <PSKeyVaultSecretIdentityItem> [-SecretValue] <SecureString> [-Disable]
 [-Expires <DateTime>] [-NotBefore <DateTime>] [-ContentType <String>] [-Tag <Hashtable>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputObjectAttribute
```
Set-AzureKeyVaultSecret [-InputObject] <PSKeyVaultSecretIdentityItem> [[-Version] <String>] [-Enable <Boolean>]
 [-Expires <DateTime>] [-NotBefore <DateTime>] [-ContentType <String>] [-Tag <Hashtable>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
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

### Example 3: Modify the attributes of a secret
```
PS C:\> $Expires = (Get-Date).AddYears(2).ToUniversalTime()
PS C:\> $Nbf = (Get-Date).ToUniversalTime()
PS C:\> $Tags = @{ 'Severity' = 'medium'; 'HR' = null}
PS C:\> $ContentType= 'xml'
PS C:\> Set-AzureKeyVaultSecret -VaultName 'ContosoVault' -Name 'HR' -Expires $Expires -NotBefore $Nbf -ContentType $ContentType -Enable $True -Tag $Tags -PassThru
```

The first four commands define attributes for the expiry date, the NotBefore date, tags, and
context type, and store the attributes in variables.

The final command modifies the attributes for the secret named HR in the key vault named
ContosoVault, using the stored variables.

### Example 4: Delete the tags and content type for a secret
```
PS C:\>Set-AzureKeyVaultSecret -VaultName 'ContosoVault' -Name 'HR' -Version '9EEA45C6EE50490B9C3176A80AC1A0DF' -ContentType '' -Tag -@{}
```

This command deletes the tags and the content type for the specified version of the secret named HR
in the key vault named Contoso.

### Example 5: Disable the current version of secrets whose name begins with IT
```
PS C:\> $Vault = 'ContosoVault'
PS C:\> $Prefix = 'IT'
PS C:\> Get-AzureKeyVaultSecret $Vault | Where-Object {$_.Name -like $Prefix + '*'} | Set-AzureKeyVaultSecret -Enable $False
```

The first command stores the string value Contoso in the $Vault variable.

The second command stores the string value IT in the $Prefix variable.

The third command uses the Get-AzureKeyVaultSecret cmdlet to get the secrets in the specified key
vault, and then passes those secrets to the **Where-Object** cmdlet. The **Where-Object** cmdlet
filters the secrets for names that begin with the characters IT. The command pipes the secrets that
match the filter to the Set-AzureKeyVaultSecret cmdlet, which disables them.

### Example 6: Set the ContentType for all versions of a secret
```
PS C:\>$VaultName = 'ContosoVault'
PS C:\> $Name = 'HR'
PS C:\> $ContentType = 'xml'
PS C:\> Get-AzureKeyVaultKey -VaultName $VaultName -Name $Name -IncludeVersions | Set-AzureKeyVaultSecret -ContentType $ContentType
```

The first three commands define string variables to use for the *VaultName*, *Name*, and
*ContentType* parameters. The fourth command uses the Get-AzureKeyVaultKey cmdlet to get the
specified keys, and pipes the keys to the Set-AzureKeyVaultSecret cmdlet to set their
content type to XML.

## PARAMETERS

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
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Disable
Indicates that this cmdlet disables a secret.

```yaml
Type: SwitchParameter
Parameter Sets: Default, InputObject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Enable
If present, enable a secret if value is true. Disable a secret if value is false. If not specified, the existing value of the secret's enabled/disabled state remains unchanged.

```yaml
Type: Boolean
Parameter Sets: DefaultAttribute, InputObjectAttribute
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
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Secret object

```yaml
Type: PSKeyVaultSecretIdentityItem
Parameter Sets: InputObject, InputObjectAttribute
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Specifies the name of a secret to modify. This cmdlet constructs the fully qualified domain name
(FQDN) of a secret based on the name that this parameter specifies, the name of the key vault, and
your current environment.

```yaml
Type: String
Parameter Sets: DefaultAttribute, Default
Aliases: SecretName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
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
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecretValue
Specifies the value for the secret as a **SecureString** object. To obtain a **SecureString**
object, use the **ConvertTo-SecureString** cmdlet. For more information, type `Get-Help
ConvertTo-SecureString`.

```yaml
Type: SecureString
Parameter Sets: Default, InputObject
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
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
Specifies the name of the key vault to which this secret belongs. This cmdlet constructs the FQDN
of a key vault based on the name that this parameter specifies and your current environment.

```yaml
Type: String
Parameter Sets: DefaultAttribute, Default
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
Secret version. Cmdlet constructs the FQDN of a secret from vault name, currently selected environment, secret name and secret version.

```yaml
Type: String
Parameter Sets: DefaultAttribute, InputObjectAttribute
Aliases: SecretVersion

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### None
This cmdlet does not accept any input.

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultSecret

## NOTES

## RELATED LINKS

[Get-AzureKeyVaultSecret](./Get-AzureKeyVaultSecret.md)

[Remove-AzureKeyVaultSecret](./Remove-AzureKeyVaultSecret.md)
