---
external help file: Microsoft.Azure.Commands.KeyVault.dll-Help.xml
ms.assetid: 363FA51E-D075-4800-A4BE-BFF63FD25C90
online version: 
schema: 2.0.0
---

# Get-AzureKeyVaultCertificate

## SYNOPSIS
Gets a certificate from a key vault.

## SYNTAX

### ByVaultName (Default)
```
Get-AzureKeyVaultCertificate [-VaultName] <String> [<CommonParameters>]
```

### ByDeletedCertificates
```
Get-AzureKeyVaultCertificate [-VaultName] <String> [-Name] <String> [-InRemovedState] [<CommonParameters>]
```

### ByCertificateName
```
Get-AzureKeyVaultCertificate [-VaultName] <String> [-Name] <String> [[-Version] <String>] [<CommonParameters>]
```

### ByCertificateVersions
```
Get-AzureKeyVaultCertificate [-VaultName] <String> [-Name] <String> [-IncludeVersions] [<CommonParameters>]
```

### ByDeletedCertificates
```
Get-AzureKeyVaultCertificate [-VaultName] <String> [[-Name] <String>] [-InRemovedState] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureKeyVaultCertificate** cmdlet gets the specified certificate or the versions of a certificate from a key vault in Azure Key Vault.

## EXAMPLES

### Example 1: Get a certificate
```
PS C:\>Get-AzureKeyVaultCertificate -VaultName "ContosoKV01" -Name "TestCert01"
Name        : testCert01
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
Created     : 2/8/2016 11:21:45 PM
Updated     : 2/8/2016 11:21:45 PM
```

This command gets the certificate named TestCert01 from the key vault named ContosoKV01.

### Example 2: Get all the certificates that have been deleted but not purged for this key vault.
```
PS C:\>Get-AzureKeyVaultCertificate -VaultName 'Contoso' -InRemovedState
```

This command gets all the certificates that have been previously deleted, but not purged, in the key vault named Contoso.

### Example 3: Gets the certificate MyCert that has been deleted but not purged for this key vault.
```
PS C:\>Get-AzureKeyVaultCertificate -VaultName 'Contoso' -Name 'MyCert' -InRemovedState
```

This command gets the certificate named 'MyCert' that has been previously deleted, but not purged, in the key vault named Contoso.
This command will return metadata such as the deletion date, and the scheduled purging date of this deleted certificate.

## PARAMETERS

### -IncludeVersions
Indicates that this operation gets all versions of the certificate.

```yaml
Type: SwitchParameter
Parameter Sets: ByCertificateVersions
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InRemovedState
Specifies whether to include previously deleted certificates in the output.```yaml
Type: SwitchParameter
Parameter Sets: ByDeletedCertificates
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the name of the certificate to get.

```yaml
Type: String
Parameter Sets: ByDeletedCertificates, ByCertificateName, ByCertificateVersions
Aliases: CertificateName

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: ByDeletedCertificates
Aliases: CertificateName

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VaultName
Specifies the name of a key vault.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Version
Specifies the version of a certificate.

```yaml
Type: String
Parameter Sets: ByCertificateName
Aliases: CertificateVersion

Required: False
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Add-AzureKeyVaultCertificate](./Add-AzureKeyVaultCertificate.md)

[Import-AzureKeyVaultCertificate](./Import-AzureKeyVaultCertificate.md)

[Remove-AzureKeyVaultCertificate](./Remove-AzureKeyVaultCertificate.md)

[Undo-AzureKeyVaultSecretCertificate](./Undo-AzureKeyVaultSecretCertificate.md)
