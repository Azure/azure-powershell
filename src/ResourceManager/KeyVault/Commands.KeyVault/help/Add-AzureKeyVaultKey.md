---
external help file: Microsoft.Azure.Commands.KeyVault.dll-Help.xml
ms.assetid: 846F781C-73A3-4BBE-ABD9-897371109FBE
online version: http://go.microsoft.com/fwlink/?LinkId=690295
schema: 2.0.0
---

# Add-AzureKeyVaultKey

## SYNOPSIS
Creates a key in a key vault or imports a key into a key vault.

## SYNTAX

### Create (Default)
```
Add-AzureKeyVaultKey [-VaultName] <String> [-Name] <String> -Destination <String> [-Disable]
 [-KeyOps <String[]>] [-Expires <DateTime>] [-NotBefore <DateTime>] [-Tag <Hashtable>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Import
```
Add-AzureKeyVaultKey [-VaultName] <String> [-Name] <String> -KeyFilePath <String>
 [-KeyFilePassword <SecureString>] [-Destination <String>] [-Disable] [-KeyOps <String[]>]
 [-Expires <DateTime>] [-NotBefore <DateTime>] [-Tag <Hashtable>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzureKeyVaultKey** cmdlet creates a key in a key vault in Azure Key Vault, or imports a key into a key vault.
Use this cmdlet to add keys by using any of the following methods:

- Create a key in a hardware security module (HSM) in the Key Vault service.
- Create a key in software in the Key Vault service.
- Import a key from your own hardware security module (HSM) to HSMs in the Key Vault service.
- Import a key from a .pfx file on your computer.
- Import a key from a .pfx file on your computer to hardware security modules (HSMs) in the Key Vault service.

For any of these operations, you can provide key attributes or accept default settings.

If you create or import a key that has the same name as an existing key in your key vault, the
original key is updated with the values that you specify for the new key. You can access the
previous values by using the version-specific URI for that version of the key. To learn about key
versions and the URI structure, see [About Keys andSecrets](http://go.microsoft.com/fwlink/?linkid=518560)
in the Key Vault REST API documentation.

Note: To import a key from your own hardware security module, you must first generate a BYOK
package (a file with a .byok file name extension) by using the Azure Key Vault BYOK toolset. For
more information, see
[How to Generate and Transfer HSM-Protected Keys for Azure Key Vault](http://go.microsoft.com/fwlink/?LinkId=522252).

As a best practice, back up your key after it is created or updated, by using the
Backup-AzureKeyVaultKey cmdlet. There is no undelete functionality, so if you accidentally delete
your key or delete it and then change your mind, the key is not recoverable unless you have a
backup of it that you can restore.

## EXAMPLES

### Example 1: Create a key
```
PS C:\>Add-AzureKeyVaultKey -VaultName 'Contoso' -Name 'ITSoftware' -Destination 'Software'
```

This command creates a software-protected key named ITSoftware in the key vault named Contoso.

### Example 2: Create an HSM-protected key
```
PS C:\>Add-AzureKeyVaultKey -VaultName 'Contoso' -Name 'ITHsm' -Destination 'HSM'
```

This command creates an HSM-protected key in the key vault named Contoso.

### Example 3: Create a key with non-default values
```
PS C:\>$KeyOperations = 'decrypt', 'verify'
PS C:\> $Expires = (Get-Date).AddYears(2).ToUniversalTime()
PS C:\> $NotBefore = (Get-Date).ToUniversalTime()
PS C:\> $Tags = @{'Severity' = 'high'; 'Accounting' = null}
PS C:\> Add-AzureKeyVaultKey -VaultName 'Contoso' -Name 'ITHsmNonDefault' -Destination 'HSM' -Expires $Expires -NotBefore $NotBefore -KeyOps $KeyOperations -Disable -Tag $Tags
```

The first command stores the values decrypt and verify in the $KeyOperations variable.

The second command creates a **DateTime** object, defined in UTC, by using the **Get-Date** cmdlet.
That object specifies a time two years in the future. The command stores that date in the $Expires
variable. For more information, type `Get-Help Get-Date`.

The third command creates a **DateTime** object by using the **Get-Date** cmdlet. That object
specifies current UTC time. The command stores that date in the $NotBefore variable.

The final command creates a key named ITHsmNonDefault that is an HSM-protected key. The command
specifies values for allowed key operations stored $KeyOperations. The command specifies times for
the *Expires* and *NotBefore* parameters created in the previous commands, and tags for high
severity and IT. The new key is disabled. You can enable it by using the **Set-AzureKeyVaultKey**
cmdlet.

### Example 4: Import an HSM-protected key
```
PS C:\>Add-AzureKeyVaultKey -VaultName 'Contoso' -Name 'ITByok' -KeyFilePath 'C:\Contoso\ITByok.byok' -Destination 'HSM'
```

This command imports the key named ITByok from the location that the *KeyFilePath* parameter
specifies. The imported key is an HSM-protected key.

To import a key from your own hardware security module, you must first generate a BYOK package (a file with a .byok file name extension) by using the Azure Key Vault BYOK toolset.
For more information, see
[How to Generate and Transfer HSM-Protected Keys for Azure Key Vault](http://go.microsoft.com/fwlink/?LinkId=522252).

### Example 5: Import a software-protected key
```
PS C:\>$Password = ConvertTo-SecureString -String 'Password' -AsPlainText -Force
PS C:\> Add-AzureKeyVaultKey -VaultName 'Contoso' -Name 'ITPfx' -KeyFilePath 'C:\Contoso\ITPfx.pfx' -KeyFilePassword $Password
```

The first command converts a string into a secure string by using the **ConvertTo-SecureString**
cmdlet, and then stores that string in the $Password variable. For more information, type `Get-Help
ConvertTo-SecureString`.

The second command creates a software password in the Contoso key vault. The command specifies the
location for the key and the password stored in $Password.

### Example 6: Import a key and assign attributes
```
PS C:\>$Password = ConvertTo-SecureString -String 'password' -AsPlainText -Force
PS C:\> $Expires = (Get-Date).AddYears(2).ToUniversalTime()
PS C:\> $Tags = @{ 'Severity' = 'high'; 'Accounting' = null }
PS C:\> Add-AzureKeyVaultKey -VaultName 'Contoso' -Name 'ITPfxToHSM' -Destination 'HSM' -KeyFilePath 'C:\Contoso\ITPfx.pfx' -KeyFilePassword $Password -Expires $Expires -Tag $Tags
```

The first command converts a string into a secure string by using the **ConvertTo-SecureString**
cmdlet, and then stores that string in the $Password variable.

The second command creates a **DateTime** object by using the **Get-Date** cmdlet, and then stores
that object in the $Expires variable.

The third command creates the $tags variable to set tags for high severity and IT.

The final command imports a key as an HSM key from the specified location. The command specifies
the expiration time stored in $Expires and password stored in $Password, and applies the tags
stored in $tags.

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

### -Destination
Specifies whether to add the key as a software-protected key or an HSM-protected key in the Key Vault service.
Valid values are: HSM and Software.

Note: To use HSM as your destination, you must have a key vault that supports HSMs. For more
information about the service tiers and capabilities for Azure Key Vault, see the
[Azure Key Vault Pricing website](http://go.microsoft.com/fwlink/?linkid=512521).

This parameter is required when you create a new key. If you import a key by using the
*KeyFilePath* parameter, this parameter is optional:

- If you do not specify this parameter, and this cmdlet imports a key that has .byok file name
extension, it imports that key as an HSM-protected key. The cmdlet cannot import that key as
software-protected key.

- If you do not specify this parameter, and this cmdlet imports a key that has a .pfx file name
extension, it imports the key as a software-protected key.

```yaml
Type: String
Parameter Sets: Create
Aliases:
Accepted values: HSM, Software

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: Import
Aliases:
Accepted values: HSM, Software

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Disable
Indicates that the key you are adding is set to an initial state of disabled. Any attempt to use
the key will fail. Use this parameter if you are preloading keys that you intend to enable later.

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
Specifies the expiration time, as a **DateTime** object, for the key that this cmdlet adds. This
parameter uses Coordinated Universal Time (UTC). To obtain a **DateTime** object, use the
**Get-Date** cmdlet. For more information, type `Get-Help Get-Date`. If you do not specify this
parameter, the key does not expire.

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

### -KeyFilePassword
Specifies a password for the imported file as a **SecureString** object. To obtain a
**SecureString** object, use the **ConvertTo-SecureString** cmdlet. For more information, type
`Get-Help ConvertTo-SecureString`. You must specify this password to import a file with a .pfx file
name extension.

```yaml
Type: SecureString
Parameter Sets: Import
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyFilePath
Specifies the path of a local file that contains key material that this cmdlet imports.
The valid file name extensions are .byok and .pfx.

- If the file is a .byok file, the key is automatically protected by HSMs after the import and you
cannot override this default.

- If the file is a .pfx file, the key is automatically protected by software after the import. To
override this default, set the *Destination* parameter to HSM so that the key is HSM-protected.

When you specify this parameter, the *Destination* parameter is optional.

```yaml
Type: String
Parameter Sets: Import
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyOps
Specifies an array of operations that can be performed by using the key that this cmdlet adds.
If you do not specify this parameter, all operations can be performed.

The acceptable values for this parameter are a comma-separated list of key operations as defined by
the [JSON Web Key (JWK) specification](http://go.microsoft.com/fwlink/?LinkID=613300):

- Encrypt
- Decrypt
- Wrap
- Unwrap
- Sign
- Verify
- Backup
- Restore

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the name of the key to add to the key vault. This cmdlet constructs the fully qualified
domain name (FQDN) of a key based on the name that this parameter specifies, the name of the key
vault, and your current environment. The name must be a string of 1 through 63 characters in length
that contains only 0-9, a-z, A-Z, and - (the dash symbol).

```yaml
Type: String
Parameter Sets: (All)
Aliases: KeyName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NotBefore
Specifies the time, as a **DateTime** object, before which the key cannot be used. This parameter
uses UTC. To obtain a **DateTime** object, use the **Get-Date** cmdlet. If you do not specify this
parameter, the key can be used immediately.

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
Specifies the name of the key vault to which this cmdlet adds the key. This cmdlet constructs the
FQDN of a key vault based on the name that this parameter specifies and your current environment.

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

Microsoft.Azure.Commands.KeyVault.Models.KeyBundle

## NOTES

## RELATED LINKS

[Backup-AzureKeyVaultKey](./Backup-AzureKeyVaultKey.md)

[Get-AzureKeyVaultKey](./Get-AzureKeyVaultKey.md)

[Remove-AzureKeyVaultKey](./Remove-AzureKeyVaultKey.md)

[Set-AzureKeyVaultKeyAttribute](./Set-AzureKeyVaultKeyAttribute.md)