---
external help file: Microsoft.Azure.PowerShell.Tools.AzPredictor.dll-Help.xml
Module Name: Az.Tools.Predictor
online version:
schema: 2.0.0
---

# Send-AzPredictorRating

## SYNOPSIS
Cmdlet to send a rating between 1 and 5 about the suggestions provided by the Az.Tools.Predictor module

## SYNTAX

```
Send-AzPredictorRating [-PassThru] [-Rating] <Int32> [<CommonParameters>]
```

## DESCRIPTION
This cmdlet sends the given rating about Az.Tools.Predictor to the server. Accepted values for the rating range 1 (poor) - 5 (great). All data from this survey will be anonymized. See the Microsoft Privacy Policy (https://privacy.microsoft.com/) for more information.

## EXAMPLES

### Example 1
```powershell
PS C:\> Send-AzPredictorRating -Rating 5
```

Sends great satisfaction rate about Az.Tools.Predictor

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

### -Rating
The rating of Az Predictor: 1 (poor) - 5 (great).

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
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
