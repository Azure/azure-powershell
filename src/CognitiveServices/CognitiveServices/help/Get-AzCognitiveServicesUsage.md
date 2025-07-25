---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CognitiveServices.dll-Help.xml
Module Name: Az.CognitiveServices
online version: https://learn.microsoft.com/powershell/module/az.cognitiveservices/get-azcognitiveservicesusage
schema: 2.0.0
---

# Get-AzCognitiveServicesUsage

## SYNOPSIS
Get Usage of Cognitive Services

## SYNTAX

```
Get-AzCognitiveServicesUsage [-Location] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Get Usage of Cognitive Services

## EXAMPLES

### Example 1
```powershell
Get-AzCognitiveServicesUsage -Location 'WestUS'
```

```output
CurrentValue  : 0
Name          : CustomVision.Prediction.Transactions
Limit         : 10000
Status        : Included
Unit          : Count
QuotaPeriod   : 30.00:00:00
NextResetTime : 0001-01-01T00:00:00Z
```

Get Usage of Cognitive Services

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Cognitive Services Account Location.

```yaml
Type: System.String
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

### Microsoft.Azure.Management.CognitiveServices.Models.PSCognitiveServicesUsage

## NOTES

## RELATED LINKS
