---
external help file: Microsoft.Azure.Commands.KeyVault.dll-Help.xml
Module Name: AzureRM.KeyVault
ms.assetid: 2BE34AE1-06FA-4F66-8FDB-CED22C2E0978
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.keyvault/get-azurekeyvaultkey
schema: 2.0.0
---

# Get-AzureKeyVaultKey

## SYNOPSIS
Gets Key Vault keys.

## SYNTAX

### ByVaultName (Default)
```
Get-AzureKeyVaultKey [-VaultName] <String> [[-Name] <String>] [-InRemovedState]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByKeyName
```
Get-AzureKeyVaultKey [-VaultName] <String> [-Name] <String> [-Version] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByKeyVersions
```
Get-AzureKeyVaultKey [-VaultName] <String> [-Name] <String> [-IncludeVersions]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByInputObjectVaultName
```
Get-AzureKeyVaultKey [-InputObject] <PSKeyVault> [[-Name] <String>] [-InRemovedState]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByInputObjectKeyName
```
Get-AzureKeyVaultKey [-InputObject] <PSKeyVault> [-Name] <String> [-Version] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByKInputObjecteyVersions
```
Get-AzureKeyVaultKey [-InputObject] <PSKeyVault> [-Name] <String> [-IncludeVersions]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureKeyVaultKey** cmdlet gets Azure Key Vault keys.
This cmdlet gets a specific **Microsoft.Azure.Commands.KeyVault.Models.KeyBundle** or a list of all **KeyBundle** objects in a key vault or by version.

## EXAMPLES

### Example 1: Get all the keys in a key vault
```
PS C:\>Get-AzureKeyVaultKey -VaultName 'Contoso'
```

This command gets all the keys in the key vault named Contoso.

### Example 2: Get the current version of a key
```
PS C:\>Get-AzureKeyVaultKey -VaultName 'Contoso' -KeyName 'ITPfx'
```

This command gets the current version of the key named ITPfx in the key vault named Contoso.

### Example 3: Get all versions of a key
```
PS C:\>Get-AzureKeyVaultKey -VaultName 'Contoso' -KeyName 'ITPfx' -IncludeVersions
```

This command gets all versions the key named ITPfx in the key vaultnamed Contoso.

### Example 4: Get a specific version of a key
```
PS C:\>$Key = Get-AzureKeyVaultKey -VaultName 'Contoso' -KeyName 'ITPfx' -Version '5A12A276385949DB8B5F82AFEE85CAED'
```

This command gets a specific version of the key named ITPfx in the key vault named Contoso.
After running this command, you can inspect various properties of the key by navigating the $Key object.

### Example 5: Get all the keys that have been deleted but not purged for this key vault.
```
PS C:\>Get-AzureKeyVaultKey -VaultName 'Contoso' -InRemovedState
```

This command gets all the keys that have been previously deleted, but not purged, in the key vault named Contoso.

### Example 6: Gets the key ITPfx that has been deleted but not purged for this key vault.
```
PS C:\>Get-AzureKeyVaultKey -VaultName 'Contoso' -KeyName 'ITPfx' -InRemovedState
```

This command gets the key ITPfx that has been previously deleted, but not purged, in the key vault named Contoso.
This command will return metadata such as the deletion date, and the scheduled purging date of this deleted key.

## PARAMETERS

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

### -IncludeVersions
Indicates that this cmdlet gets all versions of a key.
The current version of a key is the first one on the list.
If you specify this parameter you must also specify the *Name* and *VaultName* parameters.

If you do not specify the *IncludeVersions* parameter, this cmdlet gets the current version of the key with the specified *Name*.

```yaml
Type: SwitchParameter
Parameter Sets: ByKeyVersions, ByKInputObjecteyVersions
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
KeyVault object.

```yaml
Type: PSKeyVault
Parameter Sets: ByInputObjectVaultName, ByInputObjectKeyName, ByKInputObjecteyVersions
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InRemovedState
Specifies whether to show the previously deleted keys in the output

```yaml
Type: SwitchParameter
Parameter Sets: ByVaultName, ByInputObjectVaultName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the name of the key bundle to get.

```yaml
Type: String
Parameter Sets: ByVaultName, ByInputObjectVaultName
Aliases: KeyName

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: ByKeyName, ByKeyVersions, ByInputObjectKeyName, ByKInputObjecteyVersions
Aliases: KeyName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VaultName
Specifies the name of the key vault from which this cmdlet gets keys.
This cmdlet constructs the fully qualified domain name (FQDN) of a key vault based on the name that this parameter specifies and your selected environment.

```yaml
Type: String
Parameter Sets: ByVaultName, ByKeyName, ByKeyVersions
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Version
Specifies the key version.
This cmdlet constructs the FQDN of a key based on the key vault name, your currently selected environment, the key name, and the key version.

```yaml
Type: String
Parameter Sets: ByKeyName, ByInputObjectKeyName
Aliases: KeyVersion

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### String

## OUTPUTS

### List<Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultKeyIdentityItem>, Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultKey, List<Microsoft.Azure.Commands.KeyVault.Models.PSDeletedKeyVaultKeyIdentityItem>, Microsoft.Azure.Commands.KeyVault.Models.PSDeletedKeyVaultKey

## NOTES

## RELATED LINKS

[Add-AzureKeyVaultKey](./Add-AzureKeyVaultKey.md)

[Remove-AzureKeyVaultKey](./Remove-AzureKeyVaultKey.md)

[Undo-AzureKeyVaultKeyRemoval](./Undo-AzureKeyVaultKeyRemoval.md)

[Set-AzureKeyVaultKeyAttribute](./Set-AzureKeyVaultKeyAttribute.md)

