---
external help file: Microsoft.Azure.Commands.KeyVault.Provider.dll-Help.xml
Module Name: AzureRM.KeyVault
ms.assetid: 89299823-3382-402D-9458-519466748051
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.keyvault/get-item-for-keyvaultprovider
schema: 2.0.0
---

# Get-Item for KeyVault Provider

## SYNOPSIS
Gets KeyVault types: Vaults, Secrets, Certificates, Keys, and AccessPolicies.

## SYNTAX

### Path (Default)
```
Get-Item [-Path] <String[]> [<CommonParameters>]
```

### LiteralPath
```
Get-Item -LiteralPath <String[]> [<CommonParameters>]
```

## DESCRIPTION
For the KeyVault Provider, the **Get-Item** cmdlet returns the KeyVault type specified by the path.  These types are: Vaults, Secrets, Certificates, Keys, and AccessPolicies.

Note: This custom cmdlet help file explains how the Get-Item cmdlet works in a KeyVault drive. For information about the Get-Item cmdlet in all drives, type "Get-Help Get-Item -Path $null" or see Get-Item at http://go.microsoft.com/fwlink/?LinkID=113319.

## EXAMPLES

### Example 1: Get all vaults in current subscription
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Get-Item kv:/*

Vault Name                       : vault1
Resource Group Name              : myRG
Location                         : westus
Resource ID                      : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx/resourceGroups/myRG/providers
                                   /Microsoft.KeyVault/vaults/vault1
Vault URI                        : https://vault1.vault.azure.net/
Tenant ID                        : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
SKU                              : Standard
Enabled For Deployment?          : False
Enabled For Template Deployment? : False
Enabled For Disk Encryption?     : False
Soft Delete Enabled?             : True
Access Policies                  :
                                   Tenant ID                                  : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
                                   Object ID                                  : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
                                   Application ID                             :
                                   Display Name                               : User Name (user@microsoft.com)
                                   Permissions to Keys                        : backup, create, decrypt, delete,
                                   encrypt, get, import, list, purge, recover, restore, sign, unwrapKey, update,
                                   verify, wrapKey
                                   Permissions to Secrets                     : get, list, set, delete, backup,
                                   restore, recover
                                   Permissions to Certificates                : get, delete, list, create, import,
                                   update, deleteissuers, getissuers, listissuers, managecontacts, manageissuers,
                                   setissuers, recover
                                   Permissions to (Key Vault Managed) Storage : delete, deletesas, get, getsas, list,
                                   listsas, regeneratekey, set, setsas, update


Network Rule Set                 :
                                   Default Action                             : Allow
                                   Bypass                                     : AzureServices
                                   IP Rules                                   :
                                   Virtual Network Rules                      :

Tags                             :
```

### Example 2: Get specific KeyVault vault
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Get-Item kv:/vault1

Vault Name                       : vault1
Resource Group Name              : myRG
Location                         : westus
Resource ID                      : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx/resourceGroups/myRG/providers
                                   /Microsoft.KeyVault/vaults/vault1
Vault URI                        : https://vault1.vault.azure.net/
Tenant ID                        : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
SKU                              : Standard
Enabled For Deployment?          : False
Enabled For Template Deployment? : False
Enabled For Disk Encryption?     : False
Soft Delete Enabled?             : True
Access Policies                  :
                                   Tenant ID                                  : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
                                   Object ID                                  : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
                                   Application ID                             :
                                   Display Name                               : User Name (user@microsoft.com)
                                   Permissions to Keys                        : backup, create, decrypt, delete,
                                   encrypt, get, import, list, purge, recover, restore, sign, unwrapKey, update,
                                   verify, wrapKey
                                   Permissions to Secrets                     : get, list, set, delete, backup,
                                   restore, recover
                                   Permissions to Certificates                : get, delete, list, create, import,
                                   update, deleteissuers, getissuers, listissuers, managecontacts, manageissuers,
                                   setissuers, recover
                                   Permissions to (Key Vault Managed) Storage : delete, deletesas, get, getsas, list,
                                   listsas, regeneratekey, set, setsas, update


Network Rule Set                 :
                                   Default Action                             : Allow
                                   Bypass                                     : AzureServices
                                   IP Rules                                   :
                                   Virtual Network Rules                      :

Tags                             :
```

### Example 3: Get KeyVault Secret
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Get-Item kv:/vault1/Secrets/secret1

Vault Name   : vault1
Name         : secret1
Version      : xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Id           : https://mvault.vault.azure.net:443/secrets/secret1/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Enabled      : True
Expires      : 
Not Before   :
Created      : 5/7/2018 8:41:52 PM
Updated      : 5/7/2018 8:41:52 PM
Content Type : 
Tags         : 
```

To get the SecretValue, run Get-Content kv:/vault1/Secrets/secret1.

### Example 4: Get KeyVault Certificate
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Get-Item kv:/vault1/Certificate/cert1

Certificate   :
KeyId         : https://vault1.vault.azure.net:443/keys/cert1/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
SecretId      : https://vault1.vault.azure.net:443/secrets/cert1/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Thumbprint    : xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
RecoveryLevel : Recoverable+Purgeable
Policy        : Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultCertificatePolicy
Enabled       : True
Expires       : 
NotBefore     : 
Created       : 5/7/2018 8:45:15 PM
Updated       : 5/7/2018 8:45:15 PM
Tags          :
VaultName     : vault1
Name          : cert1
Version       : xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Id            : https://vault1.vault.azure.net:443/certificates/cert1/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
```

To get the X509Certificate2, run Get-Content kv:/vault1/Certificate/cert1

### Example 5: Get KeyVault Key
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Get-Item kv:/vault1/Keys/key1

Vault Name     : vault1
Name           : key1
Version        : xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Id             : https://vault1.vault.azure.net:443/keys/key1/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Enabled        : True
Expires        :
Not Before     :
Created        : 5/7/2018 8:51:40 PM
Updated        : 5/7/2018 8:51:40 PM
Purge Disabled : False
Tags           :
```

To get the JsonWebKey, run Get-Content kv:/vault1/Keys/key1

### Example 6: Get a specific version of a KeyVault Key
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Get-Item kv:/vault1/Keys/key1 -Version 12345678123456781234567812345678

Vault Name     : vault1
Name           : key1
Version        : 12345678123456781234567812345678
Id             : https://vault1.vault.azure.net:443/keys/key1/12345678123456781234567812345678
Enabled        : True
Expires        :
Not Before     :
Created        : 5/7/2018 8:51:40 PM
Updated        : 5/7/2018 8:51:40 PM
Purge Disabled : False
Tags           :
```

The -Version parameter can also be applied to Certificates and Secrets.

### Example 7: Get all versions of a KeyVault Key
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Get-Item kv:/vault1/Keys/key1 -IncludeVersions

Vault Name     : vault1
Name           : key1
Version        : 87654321876543218765432187654321
Id             : https://vault1.vault.azure.net:443/keys/key1/87654321876543218765432187654321
Enabled        : True
Expires        :
Not Before     :
Created        : 5/7/2018 8:51:40 PM
Updated        : 5/7/2018 8:51:40 PM
Purge Disabled : False
Tags           :

Vault Name     : vault1
Name           : key1
Version        : 12345678123456781234567812345678
Id             : https://vault1.vault.azure.net:443/keys/key1/12345678123456781234567812345678
Enabled        : True
Expires        :
Not Before     :
Created        : 5/7/2018 8:51:40 PM
Updated        : 5/7/2018 8:51:40 PM
Purge Disabled : False
Tags           :
```

The -IncludeVersions parameter can also be applied to Certificates and Secrets.

### Example 8: Get an AccessPolicy for a KeyVault
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Get-Item kv:/vault1/AccessPolicies/11111111-1111-1111-1111-111111111111

Tenant ID                                  : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
Object ID                                  : 11111111-1111-1111-1111-111111111111
Application ID                             :
Display Name                               : User1 (user1@microsoft.com)
Permissions to Keys                        : {get, create, delete, list...}
Permissions to Secrets                     : {get, list, set, delete...}
Permissions to Certificates                : {get, delete, list, create...}
Permissions to (Key Vault Managed) Storage : {delete, deletesas, get, getsas...}
```

## PARAMETERS

### -IncludeVersions
Indicates that this operation gets all versions of the KeyVault type. Available for Certificates, Keys, and Secrets.

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

### -LiteralPath
Specifies a path to the item.
Unlike the *Path* parameter, the value of *LiteralPath* is used exactly as it is typed.
No characters are interpreted as wildcards.
If the path includes escape characters, enclose it in single quotation marks.
Single quotation marks tell Windows PowerShell not to interpret any characters as escape sequences.

```yaml
Type: String[]
Parameter Sets: LiteralPath
Aliases: PSPath

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Path
Specifies the path to an item.
This cmdlet gets the item at the specified location.
Wildcards are permitted.
This parameter is required, but the parameter name ("Path") is optional.

Use a dot (.) to specify the current location.
Use the wildcard character (*) to specify all the items in the current location.

```yaml
Type: String[]
Parameter Sets: Path
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: True
```

### -Version
Specifies the version of a KeyVault type.  Available for Certificates, Keys, and Secrets.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVault
### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultCertificate
### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultKey
### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultSecret
### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultAccessPolicy

## NOTES

## RELATED LINKS
