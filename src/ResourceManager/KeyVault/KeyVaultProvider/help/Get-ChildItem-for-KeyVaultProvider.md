---
external help file: Microsoft.Azure.Commands.KeyVault.Provider.dll-Help.xml
Module Name: AzureRM.KeyVault
ms.assetid: 89299823-3382-402D-9458-519466748051
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.keyvault/get-childitem-for-keyvaultprovider
schema: 2.0.0
---

# Get-ChildItem for KeyVault Provider

## SYNOPSIS
Gets KeyVault types contained in a directory.

## SYNTAX

### Items (Default)

```
Get-ChildItem [[-Path] <String[]>] [-Recurse] [-Name] [<CommonParameters>]
```

### Literal Items

```
Get-ChildItem -LiteralPath <String[]> [-Recurse] [-Force] [-Name] [<CommonParameters>]
```

## DESCRIPTION
For the KeyVault Provider, the **Get-ChildItem** cmdlet returns the KeyVault types contained in the directory specified by the path.  These types are: Vaults, Secrets, Certificates, Keys, and AccessPolicies.

Note: This custom cmdlet help file explains how the Get-ChildItem cmdlet works in a KeyVault drive. For information about the Get-ChildItem cmdlet in all drives, type "Get-Help Get-ChildItem -Path $null" or see Get-ChildItem at http://go.microsoft.com/fwlink/?LinkID=113308.

## EXAMPLES

### Example 1: Get all vaults in current subscription
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Get-ChildItem kv:/

Vault Name          : vault1
Resource Group Name : myRG
Location            : westus
Resource ID         : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx/resourceGroups/myRG/providers/Microsoft.Ke
                      yVault/vaults/vault1
Tags                :

Vault Name          : vault2
Resource Group Name : myRG
Location            : westus
Resource ID         : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx/resourceGroups/myRG/providers/Microsoft.Ke
                      yVault/vaults/vault2
Tags                :
```

### Example 2: Get all vaults in current subscription with a certain tag
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Get-ChildItem kv:/ -Tag @{"a"="b"}

Vault Name          : vault1
Resource Group Name : maddie1
Location            : myRG
Resource ID         : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx/resourceGroups/myRG/providers/Microsoft.Ke
                      yVault/vaults/vault1
Tags                :
                      Name  Value
                      ====  =====
                      a     b
```

### Example 3: Get all Secrets in a KeyVault
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Get-ChildItem kv:/vault1/Secrets/

Vault Name   : vault1
Name         : secret1
Version      :
Id           : https://vault1.vault.azure.net:443/secrets/secret1
Enabled      : True
Expires      : 
Not Before   :
Created      : 5/7/2018 8:41:52 PM
Updated      : 5/7/2018 8:41:52 PM
Content Type : 
Tags         : 


Vault Name   : vault1
Name         : secret12
Version      :
Id           : https://vault1.vault.azure.net:443/secrets/secret12
Enabled      : True
Expires      :
Not Before   :
Created      : 5/7/2018 9:35:58 PM
Updated      : 5/7/2018 9:35:58 PM
Content Type :
Tags         :
```

### Example 4: Get all Certificates in a KeyVault
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Get-ChildItem kv:/vault1/Certificate/

Enabled       : True
Expires       : 11/7/2018 8:45:14 PM
NotBefore     : 5/7/2018 8:35:14 PM
Created       : 5/7/2018 8:45:15 PM
Updated       : 5/7/2018 8:45:15 PM
Tags          :
VaultName     : vault1
Name          : cert1
Version       :
Id            : https://vault1.vault.azure.net:443/certificates/cert1

Enabled       : True
Expires       : 11/7/2018 8:49:32 PM
NotBefore     : 5/7/2018 8:39:32 PM
Created       : 5/7/2018 8:49:32 PM
Updated       : 5/7/2018 8:49:32 PM
Tags          : {a}
VaultName     : vault1
Name          : cert21
Version       :
Id            : https://vault1.vault.azure.net:443/certificates/cert21
```

### Example 5: Get all Keys in a KeyVault
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Get-ChildItem kv:/vault1/Keys/

Vault Name     : vault1
Name           : key1
Version        :
Id             : https://vault1.vault.azure.net:443/keys/key1
Enabled        : True
Expires        :
Not Before     :
Created        : 5/7/2018 8:51:40 PM
Updated        : 5/7/2018 8:51:40 PM
Purge Disabled : False
Tags           :

Vault Name     : vault1
Name           : key2
Version        :
Id             : https://vault1.vault.azure.net:443/keys/key2
Enabled        : True
Expires        :
Not Before     :
Created        : 5/7/2018 8:53:05 PM
Updated        : 5/7/2018 8:53:05 PM
Purge Disabled : False
Tags           :
```

### Example 6: Get all AccessPolicies in a KeyVault
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Get-ChildItem kv:/vault1/AccessPolicies/

Tenant ID                                  : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
Object ID                                  : 11111111-1111-1111-1111-111111111111
Application ID                             :
Display Name                               : User1 (user1@microsoft.com)
Permissions to Keys                        : {get, create, delete, list...}
Permissions to Secrets                     : {get, list, set, delete...}
Permissions to Certificates                : {get, delete, list, create...}
Permissions to (Key Vault Managed) Storage : {delete, deletesas, get, getsas...}

Tenant ID                                  : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
Object ID                                  : 22222222-2222-2222-2222-222222222222
Application ID                             :
Display Name                               : User2 (user2@microsoft.com)
Permissions to Keys                        : {create, get}
Permissions to Secrets                     : {}
Permissions to Certificates                : {}
Permissions to (Key Vault Managed) Storage : {}
```


## PARAMETERS

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

### -Recurse
Gets the items in the specified locations and in all child items of the locations.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: s

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Filters the output by tags. Available only for filtering Vaults.

```yaml
Type: Hashtable
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
