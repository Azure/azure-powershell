---
external help file: Microsoft.Azure.Commands.KeyVault.dll-Help.xml
online version: https://msdn.microsoft.com/en-us/library/dn868052.aspx
schema: 2.0.0
---

# Get-AzureKeyVaultManagedStorageAccount

## SYNOPSIS
Gets Key Vault managed Azure Storage Accounts.

## SYNTAX

### ByVaultName (Default)
```
Get-AzureKeyVaultManagedStorageAccount [-VaultName] <String> [<CommonParameters>]
```

### ByAccountName
```
Get-AzureKeyVaultManagedStorageAccount [-VaultName] <String> [-AccountName] <String> [<CommonParameters>]
```

## DESCRIPTION
Gets a Key Vault managed Azure Storage Account if the name of the account is specified and the account keys are managed by the specified vault. If the account name is not specified, then all the accounts whose keys are managed by specified vault are listed.

## EXAMPLES

### Example 1: List all Key Vault managed Storage Accounts
```
PS C:\> Get-AzureKeyVaultManagedStorageAccount -VaultName 'myvault'
```

Lists all the accounts whose keys are managed by vault 'myvault'

### Example 2: Get a Key Vault managed Storage Account
```
PS C:\> Get-AzureKeyVaultManagedStorageAccount -VaultName 'myvault' -Name 'mystorageaccount'
```

Gets the details of Key Vault managed Storage Account of 'mystorageaccount' if its keys are managed by vault 'myvault'

## PARAMETERS

### -AccountName
Key Vault managed storage account name. Cmdlet constructs the FQDN of a managed storage account name from vault name, currently selected environment and manged storage account name.

```yaml
Type: String
Parameter Sets: ByAccountName
Aliases: StorageAccountName, Name

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VaultName
Vault name.
Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.KeyVault.Models.ManagedStorageAccount, Microsoft.Azure.Commands.KeyVault, Version=2.5.0.0, Culture=neutral, PublicKeyToken=null]]
Microsoft.Azure.Commands.KeyVault.Models.ManagedStorageAccount

## NOTES

## RELATED LINKS

[https://msdn.microsoft.com/en-us/library/dn868052.aspx](https://msdn.microsoft.com/en-us/library/dn868052.aspx)

