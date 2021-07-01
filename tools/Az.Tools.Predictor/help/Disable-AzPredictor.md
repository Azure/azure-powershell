---
external help file: Microsoft.Azure.PowerShell.Tools.AzPredictor.dll-Help.xml
Module Name: Az.Tools.Predictor
online version:
schema: 2.0.0
---

# Disable-AzPredictor

## SYNOPSIS
Cmdlet to disable Az Predictor and stop receiving suggestions.

## SYNTAX

```
Disable-AzPredictor [-AllSession] [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Use this cmdlet to disable Az Predictor and stop receiving suggestions.

## EXAMPLES

### Example 1
```powershell
PS C:\> Disable-AzPredictor
```

Disable Az Predictor only for the current session.

## PARAMETERS

### -AllSession
Disable Az Predictor for the current and future PowerShell sessions.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Indicates whether the user would like to receive output.

```yaml
Type: SwitchParameter
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

### None

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
