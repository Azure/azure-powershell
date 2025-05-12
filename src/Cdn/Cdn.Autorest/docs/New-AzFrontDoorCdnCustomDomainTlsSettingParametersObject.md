---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-azfrontdoorcdncustomdomaintlssettingparametersobject
schema: 2.0.0
---

# New-AzFrontDoorCdnCustomDomainTlsSettingParametersObject

## SYNOPSIS
Create an in-memory object for AfdDomainHttpsParameters.

## SYNTAX

```
New-AzFrontDoorCdnCustomDomainTlsSettingParametersObject -CertificateType <String>
 [-CipherSuiteSetType <String>] [-CustomizedCipherSuiteSet <IAfdDomainHttpsCustomizedCipherSuiteSet>]
 [-MinimumTlsVersion <String>] [-Secret <IResourceReference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AfdDomainHttpsParameters.

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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CipherSuiteSetType
cipher suite set type that will be used for Https.

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

### -CustomizedCipherSuiteSet
Customized cipher suites object that will be used for Https when cipherSuiteSetType is Customized.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IAfdDomainHttpsCustomizedCipherSuiteSet
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MinimumTlsVersion
TLS protocol version that will be used for Https when cipherSuiteSetType is Customized.

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

### -Secret
Resource reference to the secret.
ie.
subs/rg/profile/secret.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IResourceReference
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.AfdDomainHttpsParameters

## NOTES

## RELATED LINKS

