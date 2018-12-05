---
external help file: Microsoft.Azure.Commands.Advisor.dll-Help.xml
Module Name: AzureRM.Advisor
online version:
schema: 2.0.0
---

# Get-AzureRmAdvisorRecommendation

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### IdParameterSet
```
Get-AzureRmAdvisorRecommendation -ResourceId <String> [-Category <String>] [-Refresh <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### NameParameterSet
```
Get-AzureRmAdvisorRecommendation [-Category <String>] [-ResourceGroupName <String>] [-Refresh <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
{{Fill in the Description}}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Category
Category of the recommendation

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Refresh
Regenerates the recommendations.
Accepted values are true or false.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
ResourceGroup name of the recommendation

```yaml
Type: String
Parameter Sets: NameParameterSet
Aliases: Name

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
One or more recommendation-Id (space delimited)

```yaml
Type: String
Parameter Sets: IdParameterSet
Aliases: Id

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorResourceRecommendationBase, Microsoft.Azure.Commands.Advisor, Version=0.1.1.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS
