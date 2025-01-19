---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/Az.SpringApps/new-azspringkeyvaultcertificateobject
schema: 2.0.0
---

# New-AzSpringKeyVaultCertificateObject

## SYNOPSIS
Create an in-memory object for KeyVaultCertificateProperties.

## SYNTAX

```
New-AzSpringKeyVaultCertificateObject -KeyVaultCertName <String> -VaultUri <String> [-AutoSync <String>]
 [-CertVersion <String>] [-ExcludePrivateKey <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for KeyVaultCertificateProperties.

## EXAMPLES

### Example 1: Create an in-memory object for KeyVaultCertificateProperties.
```powershell
New-AzSpringKeyVaultCertificateObject -KeyVaultCertName  "mycert" -VaultUri "https://myvault.vault.azure.net" -CertVersion "xxxxxxxxxxxxxxxxxxx"
```

```output
ActivateDate      :
AutoSync          :
CertVersion       : xxxxxxxxxxxxxxxxxxx
DnsName           :
ExcludePrivateKey :
ExpirationDate    :
IssuedDate        :
Issuer            :
KeyVaultCertName  : mycert
ProvisioningState :
SubjectName       :
Thumbprint        :
Type              : KeyVaultCertificate
VaultUri          : https://myvault.vault.azure.net
```

Create an in-memory object for KeyVaultCertificateProperties.

## PARAMETERS

### -AutoSync
Indicates whether to automatically synchronize certificate from key vault or not.

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

### -CertVersion
The certificate version of key vault.

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

### -ExcludePrivateKey
Optional.
If set to true, it will not import private key from key vault.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultCertName
The certificate name of key vault.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultUri
The vault uri of user key vault.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.KeyVaultCertificateProperties

## NOTES

## RELATED LINKS

