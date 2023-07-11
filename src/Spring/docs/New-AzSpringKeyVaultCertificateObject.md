---
external help file:
Module Name: Az.Spring
online version: https://learn.microsoft.com/powershell/module/az.Spring/new-AzSpringKeyVaultCertificateObject
schema: 2.0.0
---

# New-AzSpringKeyVaultCertificateObject

## SYNOPSIS
Create an in-memory object for KeyVaultCertificateProperties.

## SYNTAX

```
New-AzSpringKeyVaultCertificateObject -Name <String> -VaultUri <String> [-ExcludePrivateKey <Boolean>]
 [-Version <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for KeyVaultCertificateProperties.

## EXAMPLES

### Example 1: Create an in-memory object for KeyVaultCertificateProperties
```powershell
New-AzSpringKeyVaultCertificateObject -VaultUri "keyvaluturi" -Name 'keycert'
```

```output
ActivateDate DnsName ExpirationDate IssuedDate Issuer SubjectName Thumbprint CertVersion ExcludePrivateKey KeyVaultCertName VaultUri
------------ ------- -------------- ---------- ------ ----------- ---------- ----------- ----------------- ---------------- --------
                                                                                                           keycert          keyvaluturi
```

Create an in-memory object for KeyVaultCertificateProperties

## PARAMETERS

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

### -Name
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

### -Version
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Spring.Models.Api20220401.KeyVaultCertificateProperties

## NOTES

ALIASES

## RELATED LINKS

