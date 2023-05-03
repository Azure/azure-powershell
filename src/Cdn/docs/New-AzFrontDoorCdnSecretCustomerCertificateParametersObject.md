---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.Cdn/new-AzFrontDoorCdnSecretCustomerCertificateParametersObject
schema: 2.0.0
---

# New-AzFrontDoorCdnSecretCustomerCertificateParametersObject

## SYNOPSIS
Create an in-memory object for CustomerCertificateParameters.

## SYNTAX

```
New-AzFrontDoorCdnSecretCustomerCertificateParametersObject -Type <SecretType> [-SecretSourceId <String>]
 [-SecretVersion <String>] [-SubjectAlternativeName <String[]>] [-UseLatestVersion <Boolean>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for CustomerCertificateParameters.

## EXAMPLES

### Example 1: Create an in-memory object for AzureFrontDoor CustomerCertificateParameters
```powershell
$secretSourceId = "xxxxxxxx"
New-AzFrontDoorCdnSecretCustomerCertificateParametersObject -UseLatestVersion $true -SubjectAlternativeName @() -Type "CustomerCertificate" -SecretSourceId $secretSourceId               
```

```output
CertificateAuthority ExpirationDate SecretVersion Subject SubjectAlternativeName Thumbprint UseLatestVersion
-------------------- -------------- ------------- ------- ---------------------- ---------- ----------------
                                                          {}                                True
```

Create an in-memory object for AzureFrontDoor CustomerCertificateParameters

## PARAMETERS

### -SecretSourceId
Resource ID.

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

### -SecretVersion
Version of the secret to be used.

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

### -SubjectAlternativeName
The list of SANs.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
The type of the secret resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.SecretType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseLatestVersion
Whether to use the latest version for the certificate.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.CustomerCertificateParameters

## NOTES

ALIASES

## RELATED LINKS

