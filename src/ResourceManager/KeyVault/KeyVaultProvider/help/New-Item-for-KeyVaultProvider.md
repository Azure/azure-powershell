---
external help file: Microsoft.Azure.Commands.KeyVault.Provider.dll-Help.xml
Module Name: AzureRM.KeyVault
ms.assetid: 89299823-3382-402D-9458-519466748051
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.keyvault/new-item-for-keyvaultprovider
schema: 2.0.0
---

# New-Item for KeyVault Provider

## SYNOPSIS
Creates KeyVault Vaults, Secrets, Certificates, and Keys.

## SYNTAX

### Path (Default)
```
New-Item [-Path] <String[]> [-ItemType <String>] [-Value <Object>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Name
```
New-Item [[-Path] <String[]>] -Name <String> [-ItemType <String>] [-Value <Object>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
For the KeyVault Provider, the **New-Item** cmdlet creates KeyVault types specified by the path.  These types are: Vaults, Secrets, Certificates, Keys, and AccessPolicies.

Note: This custom cmdlet help file explains how the New-Item cmdlet works in a KeyVault drive. For information about the New-Item cmdlet in all drives, type "Get-Help New-Item -Path $null" or see New-Item at http://go.microsoft.com/fwlink/?LinkID=113373.

## EXAMPLES

### Example 1: Create KeyVault Vault using dynamic parameters
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> New-Item kv:/vault1 -ResourceGroupName myRG -Location westus -EnabledForDeployment -EnabledForTemplateDeployment -EnabledForDiskEncryption -EnableSoftDelete -Sku Standard -Tag @{"a"="b"}

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
Enabled For Disk Encryption?     : True
Soft Delete Enabled?             : True
Access Policies                  :
                                   Tenant ID                                  : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
                                   Object ID                                  : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
                                   Application ID                             :
                                   Display Name                               :
                                   Permissions to Keys                        : get, create, delete, list, update,
                                   import, backup, restore, recover
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
                                   Name  Value
                                   ====  =====
                                   a     b
```

### Example 2: Create KeyVault Vault by passing a HashTable of parameters
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> New-Item kv:/vault1 -Value @{"ResourceGroupName"="myRG";"Location"="westus";"EnabledForDeployment"="true"}

Vault Name                       : vault1
Resource Group Name              : myRG
Location                         : westus
Resource ID                      : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx/resourceGroups/myRG/providers
                                   /Microsoft.KeyVault/vaults/vault1
Vault URI                        : https://vault1.vault.azure.net/
Tenant ID                        : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
SKU                              : Standard
Enabled For Deployment?          : True
Enabled For Template Deployment? : False
Enabled For Disk Encryption?     : False
Soft Delete Enabled?             : False
Access Policies                  :
                                   Tenant ID                                  : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
                                   Object ID                                  : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
                                   Application ID                             :
                                   Display Name                               :
                                   Permissions to Keys                        : get, create, delete, list, update,
                                   import, backup, restore, recover
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

### Example 3: Create KeyVault Vault by passing a PSObject (PSKeyVault)
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> $vault = Get-Item kv:/vault
PS C:\> $vault.EnabledForDeployment = $true
PS C:\> $vault.EnableSoftDelete = $true
PS C:\> New-Item kv:/vault1 -Value $vault

Vault Name                       : vault1
Resource Group Name              : myRG
Location                         : westus
Resource ID                      : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx/resourceGroups/myRG/providers
                                   /Microsoft.KeyVault/vaults/vault1
Vault URI                        : https://vault1.vault.azure.net/
Tenant ID                        : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
SKU                              : Standard
Enabled For Deployment?          : True
Enabled For Template Deployment? : False
Enabled For Disk Encryption?     : False
Soft Delete Enabled?             : True
Access Policies                  :
                                   Tenant ID                                  : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
                                   Object ID                                  : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
                                   Application ID                             :
                                   Display Name                               :
                                   Permissions to Keys                        : get, create, delete, list, update,
                                   import, backup, restore, recover
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

### Example 4: Create KeyVault Secret
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> $SecretValue = ConvertTo-SecureSecret -String p@ssw0rd -AsPlainText -Force
PS C:\> $Expires = (Get-Date).AddYears(2).ToUniversalTime()
PS C:\> $Nbf = (Get-Date).ToUniversalTime()
PS C:\> New-Item kv:/vault1/Secrets/secret1 -SecretValue $SecretValue -Disable -Expires $Expires -NotBefore $Nbf -ContentType "xml" -Tag @{"a"="b"}

Vault Name   : vault1
Name         : secret1
Version      : xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Id           : https://vault1.vault.azure.net:443/secrets/secret1/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Enabled      : False
Expires      : 5/9/2020 12:55:41 AM
Not Before   : 5/9/2018 12:55:41 AM
Created      : 5/9/2018 12:55:46 AM
Updated      : 5/9/2018 12:55:46 AM
Content Type : xml
Tags         : Name  Value
               a     b
```

### Example 5: Create KeyVault Certificate
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> $Policy = New-AzureKeyVaultCertificatePolicy -SecretContentType "application/x-pkcs12" -SubjectName "CN=contoso.com" -IssuerName "Self" -ValidityInMonths 6 -ReuseKeyOnRenewal
PS C:\> New-Item kv:/vault1/Certificates/cert1 -CertificatePolicy $Policy -Tag @{"a"="b"}

Id                        : https://vault1.vault.azure.net/certificates/cert1/pending
Status                    : inProgress
StatusDetails             : Pending certificate created. Certificate request is in progress. This may take some time
                            based on the issuer provider. Please check again later.
RequestId                 : xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Target                    :
Issuer                    : Self
CancellationRequested     : False
CertificateSigningRequest : xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
ErrorCode                 :
ErrorMessage              :
Name                      :
VaultName                 :
```

### Example 6: Import KeyVault Certificate from FilePath
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> $Password = ConvertTo-SecureString -String "123" -AsPlainText -Force
PS C:\> New-Item kv:/vault1/Certificates/cert1 -FilePath "C:\Users\contosoUser\Desktop\import.pfx" -Password $Password

Id                        : https://vault1.vault.azure.net/certificates/cert1/pending
Status                    : inProgress
StatusDetails             : Pending certificate created. Certificate request is in progress. This may take some time
                            based on the issuer provider. Please check again later.
RequestId                 : xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Target                    :
Issuer                    : Self
CancellationRequested     : False
CertificateSigningRequest : xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
ErrorCode                 :
ErrorMessage              :
Name                      :
VaultName                 :
```

You can create the certificate to import by using one of the following methods:

Use the New-AzureKeyVaultCertificateSigningRequest cmdlet to create a certificate signing request and submit it to a certificate authority.
Use an existing certificate package file, such as a .pfx or .p12 file, which contains both the certificate and private key.

### Example 7: Import KeyVault Certificate from CertificateString
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> $Password = ConvertTo-SecureString -String "123" -AsPlainText -Force
PS C:\> New-Item kv:/vault1/Certificates/cert1 -CertificateString $CertificateString -Password $Password

Id                        : https://vault1.vault.azure.net/certificates/cert1/pending
Status                    : inProgress
StatusDetails             : Pending certificate created. Certificate request is in progress. This may take some time
                            based on the issuer provider. Please check again later.
RequestId                 : xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Target                    :
Issuer                    : Self
CancellationRequested     : False
CertificateSigningRequest : xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
ErrorCode                 :
ErrorMessage              :
Name                      :
VaultName                 :
```

You can create the certificate to import by using one of the following methods:

Use the New-AzureKeyVaultCertificateSigningRequest cmdlet to create a certificate signing request and submit it to a certificate authority.
Use an existing certificate package file, such as a .pfx or .p12 file, which contains both the certificate and private key.

### Example 8: Import KeyVault Certificate from CertificateCollection
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> New-Item kv:/vault1/Certificates/cert1 -CertificateCollection $CertificateCollection

Id                        : https://vault1.vault.azure.net/certificates/cert1/pending
Status                    : inProgress
StatusDetails             : Pending certificate created. Certificate request is in progress. This may take some time
                            based on the issuer provider. Please check again later.
RequestId                 : xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Target                    :
Issuer                    : Self
CancellationRequested     : False
CertificateSigningRequest : xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
ErrorCode                 :
ErrorMessage              :
Name                      :
VaultName                 :
```

You can create the certificate to import by using one of the following methods:

Use the New-AzureKeyVaultCertificateSigningRequest cmdlet to create a certificate signing request and submit it to a certificate authority.
Use an existing certificate package file, such as a .pfx or .p12 file, which contains both the certificate and private key.

### Example 9: Create KeyVault Key
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> $Expires = (Get-Date).AddYears(2).ToUniversalTime()
PS C:\> $Nbf = (Get-Date).ToUniversalTime()
PS C:\> New-Item kv:/vault1/Keys/key1 -Destination Software -Disable -KeyOps decrypt -Expires $Expires -NotBefore $Nbf -Size 2048 -Tag @{"a"="b"}

Vault Name     : vault1
Name           : key1
Version        : xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Id             : https://vault1.vault.azure.net:443/keys/key1/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Enabled        : False
Expires        : 5/9/2020 1:16:31 AM
Not Before     : 5/9/2018 1:16:31 AM
Created        : 5/9/2018 1:16:33 AM
Updated        : 5/9/2018 1:16:33 AM
Purge Disabled : False
Tags           : Name  Value
                 a     b
```

### Example 10: Import an HSM-protected key
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> $Password = ConvertTo-SecureString -String 'Password' -AsPlainText -Force
PS C:\> New-Item kv:/vault1/Keys/key1 -KeyFilePath 'C:\Contoso\ITPfx.pfx' -KeyFilePassword $Password

Vault Name     : vault1
Name           : key1
Version        : xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Id             : https://vault1.vault.azure.net:443/keys/key1/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
Enabled        : True
Expires        : 
Not Before     : 
Created        : 5/9/2018 1:16:33 AM
Updated        : 5/9/2018 1:16:33 AM
Purge Disabled : False
Tags           : 
```

### Example 11: Set AccessPolicy for vault (using UserPrincipalName)
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> New-Item kv:/vault1/AccessPolicies/policy1 -UserPrincipalName 'UserName@contoso.com' -PermissionsToKeys create, get -PermissionsToSecrets get, list -PermissionsToKeys get, list -PermissionsToStorage get, list

Tenant ID                                  : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
Object ID                                  : 11111111-1111-1111-1111-111111111111
Application ID                             :
Display Name                               : User Name (UserName@contoso.com)
Permissions to Keys                        : {create, get}
Permissions to Secrets                     : {get, list}
Permissions to Certificates                : {get, list}
Permissions to (Key Vault Managed) Storage : {get, list}
```

Note: The name of the AccessPolicy will be the ObjectId, to ensure that it can be accessed across sessions.  To get this AccessPolicy, run Get-Item kv:/vault1/AccessPolicies/11111111-1111-1111-1111-111111111111.

### Example 12: Set AccessPolicy for vault (using ServicePrincipalName)
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> New-Item kv:/vault1/AccessPolicies/policy1 -ServicePrincipalName 'http://payroll.contoso.com' -PermissionsToSecrets Get,Set

Tenant ID                                  : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
Object ID                                  : 11111111-1111-1111-1111-111111111111
Application ID                             :
Display Name                               : User Name (http://payroll.contoso.com)
Permissions to Keys                        : {}
Permissions to Secrets                     : {get, set}
Permissions to Certificates                : {}
Permissions to (Key Vault Managed) Storage : {}
```

Note: The name of the AccessPolicy will be the ObjectId, to ensure that it can be accessed across sessions.  To get this AccessPolicy, run Get-Item kv:/vault1/AccessPolicies/11111111-1111-1111-1111-111111111111.

### Example 12: Set AccessPolicy for vault (using EmailAddress)
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> New-Item kv:/vault1/AccessPolicies/policy1 -EmailAddress 'username@microsoft.com' -PermissionsToSecrets Get,Set

Tenant ID                                  : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
Object ID                                  : 11111111-1111-1111-1111-111111111111
Application ID                             :
Display Name                               : User Name (username@microsoft.com)
Permissions to Keys                        : {}
Permissions to Secrets                     : {get, set}
Permissions to Certificates                : {}
Permissions to (Key Vault Managed) Storage : {}
```

Note: The name of the AccessPolicy will be the ObjectId, to ensure that it can be accessed across sessions.  To get this AccessPolicy, run Get-Item kv:/vault1/AccessPolicies/11111111-1111-1111-1111-111111111111.

### Example 12: Set AccessPolicy for vault (using Object)
```
PS C:\> Import-Module AzureRM.KeyVault
PS C:\> New-PSDrive -Name kv -PSProvider KeyVault -Root C:\Users\Default\
PS C:\> New-Item kv:/vault1/AccessPolicies/policy1 -ObjectId 11111111-1111-1111-1111-111111111111 -ApplicationId 22222222-2222-2222-2222-222222222222 -BypassObjectIdValidation -PermissionsToSecrets Get,Set

Tenant ID                                  : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxx
Object ID                                  : 11111111-1111-1111-1111-111111111111
Application ID                             : 22222222-2222-2222-2222-222222222222
Display Name                               : User Name (username@microsoft.com)
Permissions to Keys                        : {}
Permissions to Secrets                     : {get, set}
Permissions to Certificates                : {}
Permissions to (Key Vault Managed) Storage : {}
```

Note: The name of the AccessPolicy will be the ObjectId, to ensure that it can be accessed across sessions.  To get this AccessPolicy, run Get-Item kv:/vault1/AccessPolicies/11111111-1111-1111-1111-111111111111.


## PARAMETERS

### -ItemType
Specifies the provider-specified type of the new item. Valid values are: Vault, Key, Certificate, Secret, and AccessPolicy.

```yaml
Type: String
Parameter Sets: (All)
Aliases: Type

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the name of the new item.

You can specify the name of the new item in the *Name* or *Path* parameter value, and you can specify the path of the new item in *Name* or *Path* value.

```yaml
Type: String
Parameter Sets: nameSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### None

## NOTES

## RELATED LINKS
