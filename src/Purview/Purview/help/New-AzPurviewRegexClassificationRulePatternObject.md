---
external help file: Az.Purview-help.xml
Module Name: Az.Purview
online version: https://docs.microsoft.com/powershell/module/az.Purview/new-AzPurviewRegexClassificationRulePatternObject
schema: 2.0.0
---

# New-AzPurviewRegexClassificationRulePatternObject

## SYNOPSIS
Create an in-memory object for RegexClassificationRulePattern.

## SYNTAX

```
New-AzPurviewRegexClassificationRulePatternObject [-Pattern <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for RegexClassificationRulePattern.

## EXAMPLES

### Example 1: Create Regex Classification Rule Pattern Object
```powershell
PS C:\> New-AzPurviewRegexClassificationRulePatternObject -Pattern '^col1$'

Kind  Pattern
----  -------
Regex ^col1$
```

Create Regex Classification Rule Pattern Object

## PARAMETERS

### -Pattern

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

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.RegexClassificationRulePattern

## NOTES

ALIASES

## RELATED LINKS
