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
 [-MinimumTlsVersion <String>] [-Secret <IResourceReference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AfdDomainHttpsParameters.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

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

