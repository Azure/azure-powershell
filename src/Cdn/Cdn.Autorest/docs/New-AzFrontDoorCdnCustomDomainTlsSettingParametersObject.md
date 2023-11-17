---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.Cdn/new-AzFrontDoorCdnCustomDomainTlsSettingParametersObject
schema: 2.0.0
---

# New-AzFrontDoorCdnCustomDomainTlsSettingParametersObject

## SYNOPSIS
Create an in-memory object for AFDDomainHttpsParameters.

## SYNTAX

```
New-AzFrontDoorCdnCustomDomainTlsSettingParametersObject -CertificateType <AfdCertificateType>
 [-MinimumTlsVersion <AfdMinimumTlsVersion>] [-Secret <IResourceReference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AFDDomainHttpsParameters.

## EXAMPLES

### Example 1: Create an in-memory object for AFDDomainHttpsParameters
```powershell
$secret =  Get-AzFrontDoorCdnSecret -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -Name secret001
$secretResoure = New-AzFrontDoorCdnResourceReferenceObject -Id $secret.Id
New-AzFrontDoorCdnCustomDomainTlsSettingParametersObject -CertificateType "CustomerCertificate" -MinimumTlsVersion "TLS12" -Secret $secretResoure
```

```output
CertificateType     MinimumTlsVersion
---------------     -----------------
CustomerCertificate TLS12
```

Create an in-memory object for AFDDomainHttpsParameters

## PARAMETERS

### -CertificateType
Defines the source of the SSL certificate.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.AfdCertificateType
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.AfdMinimumTlsVersion
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Secret
Resource reference to the secret.
ie.
subs/rg/profile/secret.
To construct, see NOTES section for SECRET properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceReference
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.AfdDomainHttpsParameters

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`SECRET <IResourceReference>`: Resource reference to the secret. ie. subs/rg/profile/secret.
  - `[Id <String>]`: Resource ID.

## RELATED LINKS

