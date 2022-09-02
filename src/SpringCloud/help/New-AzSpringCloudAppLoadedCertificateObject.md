---
external help file:
Module Name: Az.SpringCloud
online version: https://docs.microsoft.com/powershell/module/az.SpringCloud/new-AzSpringCloudAppLoadedCertificateObject
schema: 2.0.0
---

# New-AzSpringCloudAppLoadedCertificateObject

## SYNOPSIS
Create an in-memory object for LoadedCertificate.

## SYNTAX

```
New-AzSpringCloudAppLoadedCertificateObject -ResourceId <String> [-LoadTrustStore <Boolean>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for LoadedCertificate.

## EXAMPLES

### Example 1: Create an in-memory object for LoadedCertificate.
```powershell
New-AzSpringCloudAppLoadedCertificateObject -ResourceId myResourceId
```

```output
LoadTrustStore ResourceId
-------------- ----------
               myResourceId
```

Create an in-memory object for LoadedCertificate.

## PARAMETERS

### -LoadTrustStore
Indicate whether the certificate will be loaded into default trust store, only work for Java runtime.

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

### -ResourceId
Resource Id of loaded certificate.

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

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.LoadedCertificate

## NOTES

ALIASES

## RELATED LINKS

