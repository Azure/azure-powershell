---
external help file: Az.Cdn-help.xml
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
 [-ParameterNameOverride <IUrlSigningParamIdentifier[]>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for UrlSigningAction.

## EXAMPLES

### Example 1: Create an in-memory object for UrlSigningAction
```powershell
New-AzCdnUrlSigningActionObject -Name action01
```

```output
Name
----
action01
```

Create an in-memory object for UrlSigningAction

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
Aliases: Name

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
