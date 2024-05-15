---
external help file: Az.CustomLocation-help.xml
Module Name: Az.CustomLocation
online version: https://learn.microsoft.com/powershell/module/Az.CustomLocation/new-azcustomlocationmatchexpressionsobject
schema: 2.0.0
---

# New-AzCustomLocationMatchExpressionsObject

## SYNOPSIS
Create an in-memory object for MatchExpressionsProperties.

## SYNTAX

```
New-AzCustomLocationMatchExpressionsObject [-Key <String>] [-Operator <String>] [-Value <String[]>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for MatchExpressionsProperties.

## EXAMPLES

### Example 1: Create an in-memory object for MatchExpressionsProperties.
```powershell
New-AzCustomLocationMatchExpressionsObject -Key "key4" -Operator "In" -Value "value4"
```

```output
Key  Operator
---  --------
key4 In
```

Create an in-memory object for MatchExpressionsProperties.

## PARAMETERS

### -Key
Key is the label key that the selector applies to.

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

### -Operator
The Operator field represents a key's relationship to a set of values.
Valid operators are In, NotIn, Exists and DoesNotExist.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
The label value.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CustomLocation.Models.MatchExpressionsProperties

## NOTES

## RELATED LINKS
