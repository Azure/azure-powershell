---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
ms.assetid: D4188DC6-A8AB-4B45-9781-94B74C338C63
online version: https://learn.microsoft.com/powershell/module/az.keyvault/import-azkeyvaultcertificate
schema: 2.0.0
---

# Import-AzKeyVaultCertificate

## SYNOPSIS
Imports a certificate to a key vault.

## SYNTAX

### ImportCertificateFromFile (Default)
```
Import-AzKeyVaultCertificate [-VaultName] <String> [-Name] <String> -FilePath <String>
 [-Password <SecureString>] [-PolicyPath <String>] [-PolicyObject <PSKeyVaultCertificatePolicy>]
 [-Tag <Hashtable>] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ImportWithPrivateKeyFromString
```
Import-AzKeyVaultCertificate [-VaultName] <String> [-Name] <String> -CertificateString <String>
 [-ContentType <String>] [-Password <SecureString>] [-PolicyPath <String>]
 [-PolicyObject <PSKeyVaultCertificatePolicy>] [-Tag <Hashtable>] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ImportWithPrivateKeyFromCollection
```
Import-AzKeyVaultCertificate [-VaultName] <String> [-Name] <String> [-PolicyPath <String>]
 [-PolicyObject <PSKeyVaultCertificatePolicy>] [-CertificateCollection] <X509Certificate2Collection>
 [-Tag <Hashtable>] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Import-AzKeyVaultCertificate** cmdlet imports a certificate into a key vault.
You can create the certificate to import by using one of the following methods:
- Use `Add-AzKeyVaultCertificate` to create a certificate signing request and submit it to a certificate authority. See https://learn.microsoft.com/azure/key-vault/certificates/create-certificate-signing-request
- Use an existing certificate package file, such as a .pfx or .p12 file, which contains both the certificate and private key.

## EXAMPLES

### Example 1: Import a key vault certificate
```powershell
$Password = ConvertTo-SecureString -String "123" -AsPlainText -Force
Import-AzKeyVaultCertificate -VaultName "ContosoKV01" -Name "ImportCert01" -FilePath "C:\Users\contosoUser\Desktop\import.pfx" -Password $Password
```

```output
Name        : importCert01
Certificate : [Subject]
                CN=contoso.com

              [Issuer]
                CN=contoso.com

              [Serial Number]
                XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

              [Not Before]
                2/8/2016 3:11:45 PM

              [Not After]
                8/8/2016 4:21:45 PM

              [Thumbprint]
                XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

Thumbprint  : XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Tags        :
Enabled     : True
Created     : 2/8/2016 11:50:43 PM
Updated     : 2/8/2016 11:50:43 PM
```

The first command uses the ConvertTo-SecureString cmdlet to create a secure password, and then
stores it in the $Password variable.
The second command imports the certificate named ImportCert01 into the CosotosoKV01 key vault.

### Example 2: Import a key vault certificate by CertificateString
```powershell
$Password = ConvertTo-SecureString -String "123" -AsPlainText -Force
$Base64String = [System.Convert]::ToBase64String([System.IO.File]::ReadAllBytes("import.pfx"))
Import-AzKeyVaultCertificate -VaultName "ContosoKV01" -Name "ImportCert01" -CertificateString $Base64String -Password $Password
```

```output
Name        : importCert01
Certificate : [Subject]
                CN=contoso.com

              [Issuer]
                CN=contoso.com

              [Serial Number]
                XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

              [Not Before]
                2/8/2016 3:11:45 PM

              [Not After]
                8/8/2016 4:21:45 PM

              [Thumbprint]
                XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

Thumbprint  : XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Tags        :
Enabled     : True
Created     : 2/8/2016 11:50:43 PM
Updated     : 2/8/2016 11:50:43 PM
```

The first command uses the ConvertTo-SecureString cmdlet to create a secure password, and then
stores it in the $Password variable.
The second command reads a certificate as a Base64 encoded representation.
The third command imports the certificate named ImportCert01 into the CosotosoKV01 key vault.

### Example 3: Import a key vault certificate with PolicyFile
```powershell
$Password = ConvertTo-SecureString -String "123" -AsPlainText -Force
Import-AzKeyVaultCertificate -VaultName "ContosoKV01" -Name "ImportCert01" -FilePath "C:\Users\contosoUser\Desktop\import.pfx" -Password $Password -PolicyPath "C:\Users\contosoUser\Desktop\policy.json"
```

```output
Name        : importCert01
Certificate : [Subject]
                CN=contoso.com

              [Issuer]
                CN=contoso.com

              [Serial Number]
                XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

              [Not Before]
                2/8/2016 3:11:45 PM

              [Not After]
                8/8/2016 4:21:45 PM

              [Thumbprint]
                XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

KeyId         : https://ContosoKV01.vault.azure.net/keys/ImportCert01/XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
SecretId      : https://ContosoKV01.vault.azure.net/secrets/ImportCert01/XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Thumbprint    : XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Policy        :
                Secret Content Type: application/x-pkcs12
                Issuer Name    : Unknown
                Created On     : 3/22/2023 6:00:52 AM
                Updated On     : 4/27/2023 9:52:53 AM
                ...
RecoveryLevel : Recoverable+Purgeable
Enabled       : True
Expires       : 6/9/2023 6:20:26 AM
NotBefore     : 3/11/2023 6:20:26 AM
Created       : 4/24/2023 9:05:51 AM
Updated       : 4/24/2023 9:05:51 AM
Tags          : {}
VaultName     : ContosoKV01
Name          : ImportCert01
Version       : XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Id            : https://ContosoKV01.vault.azure.net/certificates/ImportCert01/XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
```

The first command uses the ConvertTo-SecureString cmdlet to create a secure password, and then
stores it in the $Password variable.
The second command imports the certificate named ImportCert01 into the CosotosoKV01 key vault with
a policy defined by file.

## PARAMETERS

### -CertificateCollection
Specifies the certificate collection to add to a key vault.

```yaml
Type: System.Security.Cryptography.X509Certificates.X509Certificate2Collection
Parameter Sets: ImportWithPrivateKeyFromCollection
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CertificateString
Base64 encoded representation of the certificate object to import. This certificate needs to contain the private key.

```yaml
Type: System.String
Parameter Sets: ImportWithPrivateKeyFromString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContentType
Specifies the type of the certificate to be imported. Regards certificate string as PFX format by default.

```yaml
Type: System.String
Parameter Sets: ImportWithPrivateKeyFromString
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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilePath
Specifies the path of the certificate file that this cmdlet imports.

```yaml
Type: System.String
Parameter Sets: ImportCertificateFromFile
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the certificate name. This cmdlet constructs the fully qualified domain name (FQDN) of a
certificate from key vault name, currently selected environment, and certificate name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: CertificateName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Password
Specifies the password for a certificate file.

```yaml
Type: System.Security.SecureString
Parameter Sets: ImportCertificateFromFile, ImportWithPrivateKeyFromString
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicyObject
An in-memory object to specify management policy for the certificate. Mutual-exclusive to PolicyPath.

```yaml
Type: Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultCertificatePolicy
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PolicyPath
A file path to specify management policy for the certificate that contains JSON encoded policy definition. Mutual-exclusive to PolicyObject.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VaultName
Specifies the key vault name into which this cmdlet imports certificates.
This cmdlet constructs the fully qualified domain name (FQDN) of a key vault based on the name and currently selected environment.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.Security.Cryptography.X509Certificates.X509Certificate2Collection

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultCertificate

## NOTES

## RELATED LINKS

[Remove-AzKeyVaultCertificate](./Remove-AzKeyVaultCertificate.md)

[Creating and merging CSR in Key Vault](https://learn.microsoft.com/azure/key-vault/certificates/create-certificate-signing-request)
