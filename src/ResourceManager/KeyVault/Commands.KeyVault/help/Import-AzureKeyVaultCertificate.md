---
external help file: Microsoft.Azure.Commands.KeyVault.dll-Help.xml
ms.assetid: D4188DC6-A8AB-4B45-9781-94B74C338C63
online version:
schema: 2.0.0
---

# Import-AzureKeyVaultCertificate

## SYNOPSIS
Imports a certificate to a key vault.

## SYNTAX

### ImportCertificateFromFile (Default)
```
Import-AzureKeyVaultCertificate [-VaultName] <String> [-Name] <String> -FilePath <String> [-Tag <Hashtable>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ImportWithPrivateKeyFromFile
```
Import-AzureKeyVaultCertificate [-VaultName] <String> [-Name] <String> -FilePath <String>
 [-Password <SecureString>] [-Tag <Hashtable>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ImportWithPrivateKeyFromString
```
Import-AzureKeyVaultCertificate [-VaultName] <String> [-Name] <String> -CertificateString <String>
 [-Password <SecureString>] [-Tag <Hashtable>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ImportWithPrivateKeyFromCollection
```
Import-AzureKeyVaultCertificate [-VaultName] <String> [-Name] <String>
 -CertificateCollection <X509Certificate2Collection> [-Tag <Hashtable>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Import-AzureKeyVaultCertificate** cmdlet imports a certificate into a key vault.

You can create the certificate to import by using one of the following methods:

- Use the New-AzureKeyVaultCertificateSigningRequest cmdlet to create a certificate signing request and submit it to a certificate authority.
- Use an existing certificate package file, such as a .pfx or .p12 file, which contains both the certificate and private key.

## EXAMPLES

### Example 1: Import a key vault certificate
```
PS C:\>$Password = ConvertTo-SecureString -String "123" -AsPlainText -Force
PS C:\> Import-AzureKeyVaultCertificate -VaultName "ContosoKV01" -Name "ImportCert01" -FilePath "C:\Users\contosoUser\Desktop\import.pfx" -Password $Password
Name        : importCert01
Certificate : [Subject]
                CN=contoso.com

              [Issuer]
                CN=contoso.com

              [Serial Number]
                05979C5A2F0741D5A3B6F97673E8A118

              [Not Before]
                2/8/2016 3:11:45 PM

              [Not After]
                8/8/2016 4:21:45 PM

              [Thumbprint]
                3E9B6848AD1834284157D68B060F748037F663C8

Thumbprint  : 3E9B6848AD1834284157D68B060F748037F663C8
Tags        :
Enabled     : True
Created     : 2/8/2016 11:50:43 PM
Updated     : 2/8/2016 11:50:43 PM
```

The first command uses the ConvertTo-SecureString cmdlet to create a secure password, and then
stores it in the $Password variable.

The second command imports the certificate named ImportCert01 into the CosotosoKV01 key vault.

## PARAMETERS

### -CertificateCollection
Specifies the certificate collection to add to a key vault.

```yaml
Type: X509Certificate2Collection
Parameter Sets: ImportWithPrivateKeyFromCollection
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertificateString
Specifies a certificate string.

```yaml
Type: String
Parameter Sets: ImportWithPrivateKeyFromString
Aliases:

Required: True
Position: Named
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

### -FilePath
Specifies the path of the certificate file that this cmdlet imports.

```yaml
Type: String
Parameter Sets: ImportCertificateFromFile, ImportWithPrivateKeyFromFile
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
Type: String
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
Type: SecureString
Parameter Sets: ImportWithPrivateKeyFromFile, ImportWithPrivateKeyFromString
Aliases:

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
Type: Hashtable
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

Microsoft.Azure.Commands.KeyVault.Models.CertificateBundle

## NOTES

## RELATED LINKS

[Remove-AzureKeyVaultCertificate](./Remove-AzureKeyVaultCertificate.md)