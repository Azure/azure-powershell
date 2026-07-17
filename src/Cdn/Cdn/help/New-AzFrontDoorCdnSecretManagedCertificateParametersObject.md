---
external help file: Az.Cdn-help.xml
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-azfrontdoorcdnsecretmanagedcertificateparametersobject
schema: 2.0.0
---

# New-AzFrontDoorCdnSecretManagedCertificateParametersObject

## SYNOPSIS
Create an in-memory object for ManagedCertificateParameters.

## SYNTAX

```
New-AzFrontDoorCdnSecretManagedCertificateParametersObject [-Type <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ManagedCertificateParameters.

## EXAMPLES

### Example 1: Create an in-memory object for ManagedCertificateParameters
```powershell
New-AzFrontDoorCdnSecretManagedCertificateParametersObject -Type ManagedCert
```

```output
ExpirationDate Subject
-------------- -------
```

Create an in-memory object for ManagedCertificateParameters.

## PARAMETERS

### -Type
Type.

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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ManagedCertificateParameters

## NOTES

## RELATED LINKS
