---
external help file: Microsoft.Azure.PowerShell.Tools.AzPredictor.dll-Help.xml
Module Name: Az.Tools.Predictor
online version:
schema: 2.0.0
---

# Open-AzPredictorSurvey

## SYNOPSIS
Cmdlet to open a survey link in the default browser.

## SYNTAX

```
Open-AzPredictorSurvey [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
This cmdlet opens a survey link in the default browser and writes the link to the output stream. All data from this survey will be anonymized. See the Microsoft Privacy Policy (https://privacy.microsoft.com/) for more information

## EXAMPLES

### Example 1
```powershell
PS C:\> Open-AzPredictorSurvey
```

Open a survey link in the default browser.

## PARAMETERS

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
