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

### -ApplicationId
Dynamic Parameter available when creating KeyVault AccessPolicies. Specifies the ID of application that a user must use to grant permissions.

```yaml
Type: Guid?
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BypassObjectIdValidation
Dynamic Parameter available when creating KeyVault AccessPolicies. Enables you to specify an object ID without validating that the object exists in Azure Active Directory.

Use this parameter only if you want to grant access to your key vault to an object ID that refers to a delegated security group from another Azure tenant.

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


### -CertificateCollection
Dynamic Parameter available when creating KeyVault Certificates. Specifies the certificate collection to add to a key vault.

```yaml
Type: X509Certificate2Collection
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertificateString
Dynamic Parameter available when creating KeyVault Certificates. Specifies a certificate string.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertificatePolicy
Dynamic Parameter available when creating KeyVault Certificates. Specifies a KeyVaultCertificatePolicy object.

```yaml
Type: PSKeyVaultCertificatePolicy
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContentType
Dynamic Parameter available when creating KeyVault Secrets. Specifies the content type of a secret. To delete the existing content type, specify an empty string.

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

### -Destination
Dynamic Parameter available when creating KeyVault Keys. Specifies whether to add the key as a software-protected key or an HSM-protected key in the Key Vault service. Valid values are: HSM and Software.

Note: To use HSM as your destination, you must have a key vault that supports HSMs. For more information about the service tiers and capabilities for Azure Key Vault, see the Azure Key Vault Pricing website.

This parameter is required when you create a new key. If you import a key by using the KeyFilePath parameter, this parameter is optional:

If you do not specify this parameter, and this cmdlet imports a key that has .byok file name extension, it imports that key as an HSM-protected key. The cmdlet cannot import that key as software-protected key.

If you do not specify this parameter, and this cmdlet imports a key that has a .pfx file name extension, it imports the key as a software-protected key.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Disable
Dynamic Parameter available when creating KeyVault Secrets or Keys. Indicates that this cmdlet disables a secret or key.

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

### -EmailAddress
Dynamic Parameter available when creating KeyVault AccessPolicies.  Specifies the user email address of the user to whom to grant permissions.

This email address must exist in the directory associated with the current subscription and be unique.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnabledForDeployment
Dynamic Parameter available when creating KeyVault Vaults. Enables the Microsoft.Compute resource provider to retrieve secrets from this key vault when this key vault is referenced in resource creation, for example when creating a virtual machine.

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

### -EnabledForDiskEncryption
Dynamic Parameter available when creating KeyVault Vaults. Enables the Azure disk encryption service to get secrets and unwrap keys from this key vault.

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

### -EnabledForTemplateDeployment
Dynamic Parameter available when creating KeyVault Vaults. Enables Azure Resource Manager to get secrets from this key vault when this key vault is referenced in a template deployment.

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

### -EnableSoftDelete
Dynamic Parameter available when creating KeyVault Vaults. Specifies that the soft-delete functionality is enabled for this key vault. When soft-delete is enabled, for a grace period, you can recover this key vault and its contents after it is deleted.

For more information about this functionality, see [Azure Key Vault soft-delete overview](https://docs.microsoft.com/azure/key-vault/key-vault-ovw-soft-delete). For how-to instructions, see [How to use Key Vault soft-delete with PowerShell](https://docs.microsoft.com/azure/key-vault/key-vault-soft-delete-powershell).

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
Dynamic Parameter available when creating KeyVault Secrets or Keys. Specifies the expiration time, as a DateTime object, for the secret that this cmdlet updates. This parameter uses Coordinated Universal Time (UTC). To obtain a DateTime object, use the Get-Date cmdlet. For more information, type Get-Help Get-Date.

```yaml
Type: DateTime?
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilePath
Dynamic Parameter available when creating KeyVault Certificates. Specifies the path of the certificate file that this cmdlet imports.

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

### -KeyFilePassword
Dynamic Parameter available when creating KeyVault Keys. Specifies a password for the imported file as a SecureString object. To obtain a SecureString object, use the ConvertTo-SecureString cmdlet. For more information, type Get-Help ConvertTo-SecureString. You must specify this password to import a file with a .pfx file name extension.

```yaml
Type: SecureString
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyFilePath
Dynamic Parameter available when creating KeyVault Keys. Specifies the path of a local file that contains key material that this cmdlet imports. The valid file name extensions are .byok and .pfx.

If the file is a .byok file, the key is automatically protected by HSMs after the import and you cannot override this default.

If the file is a .pfx file, the key is automatically protected by software after the import. To override this default, set the Destination parameter to HSM so that the key is HSM-protected.

When you specify this parameter, the Destination parameter is optional.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyOps
Dynamic Parameter available when creating KeyVault Keys. Specifies an array of operations that can be performed by using the key that this cmdlet adds.
If you do not specify this parameter, all operations can be performed.

The acceptable values for this parameter are a comma-separated list of key operations as defined by
the [JSON Web Key (JWK) specification](http://go.microsoft.com/fwlink/?LinkID=613300):

- Encrypt
- Decrypt
- Wrap
- Unwrap
- Sign
- Verify

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -NotBefore
Dynamic Parameter available when creating KeyVault Secrets or Keys. Specifies the time, as a DateTime object, before which the secret cannot be used. This parameter uses UTC. To obtain a DateTime object, use the Get-Date cmdlet.

```yaml
Type: DateTime?
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Dynamic Parameter available when creating KeyVault Vaults. Specifies the Azure region in which to create the key vault. Use the command Get-AzureLocation to see your choices.

```yaml
Type: string
Parameter Sets: (All)
Aliases:

Required: True
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

### -ObjectId
Dynamic Parameter available when creating KeyVault AccessPolicies.  Specifies the object ID of the user or service principal in Azure Active Directory for which to grant permissions.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Password
Dynamic Parameter available when creating KeyVault Certificates. Specifies the password for a certificate file.

```yaml
Type: SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### -PermissionsToCertificates
Dynamic Parameter available when creating KeyVault AccessPolicies.  Specifies an array of certificate permissions to grant to a user or service principal.

The acceptable values for this parameter:

- Get
- List
- Delete
- Create
- Import
- Update
- Managecontacts
- Getissuers
- Listissuers
- Setissuers
- Deleteissuers
- Manageissuers

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:
Accepted values: get, list, delete, create, import, update, managecontacts, getissuers, listissuers, setissuers, deleteissuers, manageissuers, recover, purge, backup, restore

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PermissionsToKeys
Dynamic Parameter available when creating KeyVault AccessPolicies.  Specifies an array of key operation permissions to grant to a user or service principal.

The acceptable values for this parameter:

- Decrypt
- Encrypt
- UnwrapKey
- WrapKey
- Verify
- Sign
- Get
- List
- Update
- Create
- Import
- Delete
- Backup
- Restore
- Recover
- Purge

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:
Accepted values: decrypt, encrypt, unwrapKey, wrapKey, verify, sign, get, list, update, create, import, delete, backup, restore, recover, purge

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PermissionsToSecrets
Dynamic Parameter available when creating KeyVault AccessPolicies.  Specifies an array of secret operation permissions to grant to a user or service principal.

The acceptable values for this parameter:

- Get
- List
- Set
- Delete
- Backup
- Restore
- Recover
- Purge

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:
Accepted values: get, list, set, delete, backup, restore, recover, purge

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PermissionsToStorage
Dynamic Parameter available when creating KeyVault AccessPolicies.  Specifies managed storage account and SaS-definition operation permissions to grant to a user or service principal.

The acceptable values for this parameter:

- Get
- List
- Set
- Delete
- Update
- RegenerateKey
- GetSAS
- ListSAS
- DeleteSAS
- SetSAS
- Backup
- Restore
- Recover
- Purge

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:
Accepted values: get, list, delete, set, update, regeneratekey, getsas, listsas, deletesas, setsas, recover, backup, restore, purge

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Dynamic Parameter available when creating KeyVault Vaults. Specifies the name of an existing resource group in which to create the key vault.

```yaml
Type: string
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecretValue
Dynamic Parameter available when creating KeyVault Secrets. Specifies the value for the secret as a SecureString object. To obtain a SecureString object, use the ConvertTo-SecureString cmdlet. For more information, type Get-Help ConvertTo-SecureString.

```yaml
Type: SecureString
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServicePrincipalName
Dynamic Parameter available when creating KeyVault AccessPolicies.  Specifies the service principal name of the application to which to grant permissions.

Specify the application ID, also known as client ID, registered for the application in AzureActive Directory. The application with the service principal name that this parameter specifies must be registered in the Azure directory that contains your current subscription.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sku
Dynamic Parameter available when creating KeyVault Vaults. Specifies the SKU of the key vault instance. For information about which features are available for each SKU, see the Azure Key Vault Pricing website (https://go.microsoft.com/fwlink/?linkid=512521).

```yaml
Type: SkuName
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Size
Dynamic Parameter available when creating KeyVault Keys. RSA key size, in bits. If not specified, the service will provide a safe default.

```yaml
Type: int?
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Dynamic Parameter available when creating KeyVault Vaults, Secrets, Certificates, or Keys.  Key-value pairs in the form of a hash table. For example:

@{key0="value0";key1=$null;key2="value2"}

```yaml
Type: HashTable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserPrincipalName
Dynamic Parameter available when creating KeyVault AccessPolicies.  Specifies the user principal name of the user to whom to grant permissions.

This user principal name must exist in the directory associated with the current subscription.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Collections.Hashtable
### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVault
### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultCertificate
### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultKey
### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultSecret
### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultAccessPolicy

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVault
### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultCertificate
### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultKey
### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultSecret
### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultAccessPolicy

## NOTES

## RELATED LINKS
