---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-azfrontdoorcdnsecretfirstpartymanagedcertificateparametersobject
schema: 2.0.0
---

# New-AzFrontDoorCdnSecretFirstPartyManagedCertificateParametersObject

## SYNOPSIS
Create an in-memory object for AzureFirstPartyManagedCertificateParameters.

## SYNTAX

```
New-AzFrontDoorCdnSecretFirstPartyManagedCertificateParametersObject [-SubjectAlternativeName <String[]>]
 [-Type <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AzureFirstPartyManagedCertificateParameters.

## EXAMPLES

### Example 1: Create an in-memory object for AzureFirstPartyManagedCertificateParameters
```powershell
New-AzFrontDoorCdnSecretFirstPartyManagedCertificateParametersObject -Type BYOC
```

```output
Type
----
BYOC
```

Create an in-memory object for AzureFirstPartyManagedCertificateParameters

## PARAMETERS

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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.AzureFirstPartyManagedCertificateParameters

## NOTES

## RELATED LINKS

