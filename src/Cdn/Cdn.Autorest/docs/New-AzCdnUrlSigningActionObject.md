---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/Az.Cdn/new-azcdnurlsigningactionobject
schema: 2.0.0
---

# New-AzCdnUrlSigningActionObject

## SYNOPSIS
Create an in-memory object for UrlSigningAction.

## SYNTAX

```
New-AzCdnUrlSigningActionObject -ParameterTypeName <String> [-ParameterAlgorithm <String>]
 [-ParameterNameOverride <IUrlSigningParamIdentifier[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for UrlSigningAction.

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

### -ParameterAlgorithm
Algorithm to use for URL signing.

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

### -ParameterNameOverride
Defines which query string parameters in the url to be considered for expires, key id etc.
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IUrlSigningParamIdentifier[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParameterTypeName


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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.UrlSigningAction

## NOTES

## RELATED LINKS

