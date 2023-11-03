---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.Cdn/new-AzFrontDoorCdnSecretManagedCertificateParametersObject
schema: 2.0.0
---

# New-AzFrontDoorCdnSecretManagedCertificateParametersObject

## SYNOPSIS
Create an in-memory object for ManagedCertificateParameters.

## SYNTAX

```
New-AzFrontDoorCdnSecretManagedCertificateParametersObject -Type <SecretType> [<CommonParameters>]
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.ManagedCertificateParameters

## NOTES

ALIASES

## RELATED LINKS

