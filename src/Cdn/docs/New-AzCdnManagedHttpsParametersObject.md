---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-azcdnmanagedhttpsparametersobject
schema: 2.0.0
---

# New-AzCdnManagedHttpsParametersObject

## SYNOPSIS
Create an in-memory object for CdnManagedHttpsParameters.

## SYNTAX

```
New-AzCdnManagedHttpsParametersObject -CertificateSourceParameterCertificateType <String>
 -ProtocolType <String> [-MinimumTlsVersion <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for CdnManagedHttpsParameters.

## EXAMPLES

### Example 1: Create an in-memory object for AzureCDN CdnManagedHttpsParameters
```powershell
New-AzCdnManagedHttpsParametersObject -CertificateSourceParameterCertificateType Dedicated -CertificateSource Cdn -ProtocolType ServerNameIndication
```

```output
CertificateSource MinimumTlsVersion ProtocolType
----------------- ----------------- ------------
Cdn                                 TLS12
```

Create an in-memory object for AzureCDN CdnManagedHttpsParameters

## PARAMETERS

### -CertificateSourceParameterCertificateType
Type of certificate used.

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

### -MinimumTlsVersion
TLS protocol version that will be used for Https.

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

### -ProtocolType
Defines the TLS extension protocol that is used for secure delivery.

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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.CdnManagedHttpsParameters

## NOTES

ALIASES

## RELATED LINKS

