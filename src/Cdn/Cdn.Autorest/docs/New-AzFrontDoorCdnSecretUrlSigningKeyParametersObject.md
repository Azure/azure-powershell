---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.Cdn/new-AzFrontDoorCdnSecretUrlSigningKeyParametersObject
schema: 2.0.0
---

# New-AzFrontDoorCdnSecretUrlSigningKeyParametersObject

## SYNOPSIS
Create an in-memory object for UrlSigningKeyParameters.

## SYNTAX

```
New-AzFrontDoorCdnSecretUrlSigningKeyParametersObject -KeyId <String> -Type <SecretType>
 [-SecretSourceId <String>] [-SecretVersion <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for UrlSigningKeyParameters.

## EXAMPLES

### Example 1: Create an in-memory object for UrlSigningKeyParameters
```powershell
New-AzFrontDoorCdnSecretUrlSigningKeyParametersObject -KeyId keyId01 -Type Byoc -SecretVersion v1.0
```

```output
KeyId   SecretVersion
-----   -------------
keyId01 v1.0
```

Create an in-memory object for UrlSigningKeyParameters.

## PARAMETERS

### -KeyId
Defines the customer defined key Id.
This id will exist in the incoming request to indicate the key used to form the hash.

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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.UrlSigningKeyParameters

## NOTES

ALIASES

## RELATED LINKS

