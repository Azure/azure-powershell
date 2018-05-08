---
external help file: Microsoft.Azure.Commands.KeyVault.Provider.dll-Help.xml
Module Name: AzureRM.KeyVault
ms.assetid: 89299823-3382-402D-9458-519466748051
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.keyvault/set-item-for-keyvaultprovider
schema: 2.0.0
---

# Set-Item for KeyVault Provider

## SYNOPSIS
Sets the properties of a KeyVault type: Vaults, Secrets, Certificates, Keys, and AccessPolicies.

## SYNTAX

### Path (Default)
```
Set-Item [-Path] <String[]> [[-Value] <Object>] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### LiteralPath
```
Set-Item -LiteralPath <String[]> [[-Value] <Object>] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
For the KeyVault Provider, the **Set-Item** cmdlet allows the user to set properties of KeyVault types.  These types are: Vaults, Secrets, Certificates, Keys, and AccessPolicies.  Parameters can be passed in using either dynamic parameters, passing a HashTable of the parameter values to -Value, or passing an object of the correct type to -Value.

Note: This custom cmdlet help file explains how the Set-Item cmdlet works in a file system drive. For information about the Set-Item cmdlet in all drives, type "Get-Help Set-Item -Path $null" or see Set-Item at http://go.microsoft.com/fwlink/?LinkId=821630.

## EXAMPLES

### Example 1: Set properties of a KeyVault vault using dynamic parameters
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Set-Item kv:/vault1 -EnabledForDeployment $true -EnabledForTemplateDeployment $true -EnabledForDiskEncryption $false -PassThru

Vault Name                       : vault1
Resource Group Name              : myRG
Location                         : westus
Resource ID                      : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx/resourceGroups/myRG/providers
                                   /Microsoft.KeyVault/vaults/vault1
Vault URI                        : https://vault1.vault.azure.net/
Tenant ID                        : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
SKU                              : Standard
Enabled For Deployment?          : True
Enabled For Template Deployment? : True
Enabled For Disk Encryption?     : False
Soft Delete Enabled?             : True
Access Policies                  :
Network Rule Set                 :
                                   Default Action                             : Allow
                                   Bypass                                     : AzureServices
                                   IP Rules                                   :
                                   Virtual Network Rules                      :
Tags                             :
```

### Example 2: Set properties of a KeyVault vault by passing HashTable of parameter values
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Set-Item kv:/vault1 -Value @{"EnabledForDeployment"=$true;"EnabledForTemplateDeployment"=$true;"EnabledForDiskEncryption"=$false} -PassThru

Vault Name                       : vault1
Resource Group Name              : myRG
Location                         : westus
Resource ID                      : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx/resourceGroups/myRG/providers
                                   /Microsoft.KeyVault/vaults/vault1
Vault URI                        : https://vault1.vault.azure.net/
Tenant ID                        : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
SKU                              : Standard
Enabled For Deployment?          : True
Enabled For Template Deployment? : True
Enabled For Disk Encryption?     : False
Soft Delete Enabled?             : True
Access Policies                  :
Network Rule Set                 :
                                   Default Action                             : Allow
                                   Bypass                                     : AzureServices
                                   IP Rules                                   :
                                   Virtual Network Rules                      :
Tags                             :
```

### Example 3: Set properties of a KeyVault vault by passing object of type PSVault
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> $vault = Get-Item kv:/vault1
PS C:\> $vault.EnabledForDeployment = $true
PS C:\> $vault.EnabledForTemplateDeployment = $true
PS C:\> $vault.EnabledForDiskEncription = $false
PS C:\> Set-Item kv:/vault1 -Value $vault -PassThru

Vault Name                       : vault1
Resource Group Name              : myRG
Location                         : westus
Resource ID                      : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx/resourceGroups/myRG/providers
                                   /Microsoft.KeyVault/vaults/vault1
Vault URI                        : https://vault1.vault.azure.net/
Tenant ID                        : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
SKU                              : Standard
Enabled For Deployment?          : True
Enabled For Template Deployment? : True
Enabled For Disk Encryption?     : False
Soft Delete Enabled?             : True
Access Policies                  :
Network Rule Set                 :
                                   Default Action                             : Allow
                                   Bypass                                     : AzureServices
                                   IP Rules                                   :
                                   Virtual Network Rules                      :
Tags                             :
```

### Example 4: Set properties of a KeyVault Secret using dynamic parameters
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> $Expires = (Get-Date).AddYears(2).ToUniversalTime()
PS C:\> $Nbf = (Get-Date).ToUniversalTime()
PS C:\> Set-Item kv:/vault1/Secrets/secret1 -Enable $true -Expires $Expires -NotBefore $Nbf -ContentType "xml" -Tag @{"a"="b"} -PassThru

Vault Name   : vault1
Name         : secret1
Version      : xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Id           : https://vault1.vault.azure.net:443/secrets/secret1/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Enabled      : True
Expires      : 5/8/2020 9:28:51 PM
Not Before   : 5/8/2018 9:28:51 PM
Created      : 5/7/2018 8:41:52 PM
Updated      : 5/8/2018 9:28:54 PM
Content Type : xml
Tags         : Name  Value
               a     b
```

### Example 5: Set properties of a specific version of a KeyVault Secret using dynamic parameters
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> $Expires = (Get-Date).AddYears(2).ToUniversalTime()
PS C:\> $Nbf = (Get-Date).ToUniversalTime()
PS C:\> Set-Item kv:/vault1/Secrets/secret1 -Enable $true -Expires $Expires -NotBefore $Nbf -ContentType "xml" -Tag @{"a"="b"} -Version 12345678123456781234567812345678 -PassThru

Vault Name   : vault1
Name         : secret1
Version      : 12345678123456781234567812345678
Id           : https://vault1.vault.azure.net:443/secrets/secret1/12345678123456781234567812345678
Enabled      : True
Expires      : 5/8/2020 9:28:51 PM
Not Before   : 5/8/2018 9:28:51 PM
Created      : 5/7/2018 8:41:52 PM
Updated      : 5/8/2018 9:28:54 PM
Content Type : xml
Tags         : Name  Value
               a     b
```

The version parameter is also available for Certificates and Keys.

### Example 6: Set properties of a KeyVault Certificate using dynamic parameters
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Set-Item kv:/vault1/Certificates/cert1 -Enable $true -Tag @{"a"="b"} -PassThru

Certificate   : 
KeyId         : https://vault1.vault.azure.net:443/keys/cert1/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
SecretId      : https://vault1.vault.azure.net:443/secrets/cert1/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Thumbprint    : xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
RecoveryLevel : Recoverable+Purgeable
Policy        : Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultCertificatePolicy
Enabled       : True
Expires       : 11/7/2018 8:45:14 PM
NotBefore     : 5/7/2018 8:35:14 PM
Created       : 5/7/2018 8:45:15 PM
Updated       : 5/8/2018 10:27:11 PM
Tags          : {a}
VaultName     : vault1
Name          : cert1
Version       : xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Id            : https://vault1.vault.azure.net:443/certificates/cert1/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
```

### Example 7: Set properties of a KeyVault Key using dynamic parameters
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> $Expires = (Get-Date).AddYears(2).ToUniversalTime()
PS C:\> $Nbf = (Get-Date).ToUniversalTime()
PS C:\> Set-Item kv:/vault1/Keys/key1 -Enable $true -Expires $Expires -NotBefore $Nbf -KeyOps decrypt -Tag @{"a"="b"} -PassThru

Vault Name     : vault1
Name           : key1
Version        : xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Id             : https://vault1.vault.azure.net:443/keys/key1/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Enabled        : True
Expires        : 5/8/2020 10:31:54 PM
Not Before     : 5/8/2018 10:32:00 PM
Created        : 5/7/2018 8:51:40 PM
Updated        : 5/8/2018 10:32:04 PM
Purge Disabled : False
Tags           : Name  Value
                 a     b
```

### Example 8: Set properties of a KeyVault AccessPolicy using dynamic parameters
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> Set-Item kv:/vault1/AccessPolicies/11111111-1111-1111-1111-111111111111 -PermissionsToKeys get, create -PermissionsToSecrets get, list -PermissionsToCertificates get -PermissionsToStorage get -PassThru

Tenant ID                                  : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
Object ID                                  : 11111111-1111-1111-1111-111111111111
Application ID                             :
Display Name                               : User1 (user1@microsoft.com)
Permissions to Keys                        : {get, create}
Permissions to Secrets                     : {get, list}
Permissions to Certificates                : {get}
Permissions to (Key Vault Managed) Storage : {get}
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

### -Value
Specifies a new value for the item. Value accepts either a HashTable or a PSObject with the correct type required by the path. Ex: For "Set-Item kv:/vault1/Secrets/secret1", Value accepts a PSKeyVaultSecret.

```yaml
Type: Object
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
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
