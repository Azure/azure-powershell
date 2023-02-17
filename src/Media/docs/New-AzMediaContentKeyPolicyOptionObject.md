---
external help file:
Module Name: Az.Media
online version: https://learn.microsoft.com/powershell/module/az.Media/new-AzMediaContentKeyPolicyOptionObject
schema: 2.0.0
---

# New-AzMediaContentKeyPolicyOptionObject

## SYNOPSIS
Create an in-memory object for ContentKeyPolicyOption.

## SYNTAX

```
New-AzMediaContentKeyPolicyOptionObject -ConfigurationOdataType <String> -RestrictionOdataType <String>
 [-Name <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ContentKeyPolicyOption.

## EXAMPLES

### Example 1: Create an in-memory object for ContentKeyPolicyOption.
```powershell
New-AzMediaContentKeyPolicyOptionObject -ConfigurationOdataType "#Microsoft.Media.ContentKeyPolicyWidevineConfiguration" -RestrictionOdataType "#Microsoft.Media.ContentKeyPolicyOpenRestriction" -Name "widevineoption"
```

```output
Name           PolicyOptionId
----           --------------
widevineoption
```

Create an in-memory object for ContentKeyPolicyOption.

## PARAMETERS

### -ConfigurationOdataType
The discriminator for derived types.

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

### -Name
The Policy Option description.

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

### -RestrictionOdataType
The discriminator for derived types.

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

### Microsoft.Azure.PowerShell.Cmdlets.Media.Models.Api20220801.ContentKeyPolicyOption

## NOTES

ALIASES

## RELATED LINKS

