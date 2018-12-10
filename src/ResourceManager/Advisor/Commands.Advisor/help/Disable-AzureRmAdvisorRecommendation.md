---
external help file: Microsoft.Azure.Commands.Advisor.dll-Help.xml
Module Name: Az.Advisor
online version:
schema: 2.0.0
---

# Disable-AzureRmAdvisorRecommendation

## SYNOPSIS
Disable an Azure Advisor recommendation.

## SYNTAX

### IdParameterSet (Default)
```
Disable-AzureRmAdvisorRecommendation [-ResourceId] <String> [[-Days] <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### NameParameterSet
```
Disable-AzureRmAdvisorRecommendation [[-Days] <String>] [-RecommendationName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### InputObjectParameterSet
```
Disable-AzureRmAdvisorRecommendation [[-Days] <String>]
 [-InputObject] <PsAzureAdvisorResourceRecommendationBase> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Create suppression for recomendation, this enables a particular recommendation to be postponed for a specific duration or infinitely.

## EXAMPLES

### Example 1
```powershell
PS C:\> Disable-AzureRMAdvisorRecommendation -Name "f380a3a8-9d18-cfad-78e0-55762c72a178"

SuppressionId : d1f70547-0e72-db29-443e-c1164d5d4377
Ttl           : -1
Id            : /subscriptions/{user_subscription}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cache/Redis/xyz/providers/Microsoft.Advisor/recommendations
                /{recommendation_id}/suppressions/HardCodedSupressionName
Name          : HardCodedSupressionName
Type          : Microsoft.Advisor/suppressions
```

Create a suppression for the given recomendation name with a default-SuppressionName and default days as -1.

### Example 3
```powershell
PS C:\> Disable-AzureRMAdvisorRecommendation -ResourceId "/subscriptions/{user_subscription}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cache/Redis/xyz/providers/Microsoft.Advisor/recommendations/{}" -Days 12

SuppressionId : 7d1f0547-0e72-db29-443e-c1164d5d4377
Ttl           : 12.00:00:00
Id            : /subscriptions/{user_subscription}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cache/Redis/xyz/providers/Microsoft.Advisor/recommendations
                /{recommendation_id}/suppressions/HardCodedSupressionName
Name          : HardCodedSupressionName
Type          : Microsoft.Advisor/suppressions
```

A suppression is created for the given recommendation-Id

### Example 4
```powershell
PS C:\>  Get-AzureRMAdvisorRecommendation -Id "/subscriptions/658c8950-e79d-4704-a903-1df66ba90258/resourceGroups/AzExpertStg/providers/Microsoft.Cache/Redis/azacache/providers/Microsoft.Advisor/recommendations/f380a3a8-9d18-cfad-78e0-55762c72a178" | Disable-A
zureRMAdvisorRecommendation

SuppressionId : daf24e78-af2d-e8d3-9c50-fa970edc2937
Ttl           : -1
Id            : /subscriptions/{user_subscription}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cache/Redis/xyz/providers/Microsoft.Advisor/recommendations
                /{recommendation_id}/suppressions/HardCodedSupressionName
Name          : HardCodedSupressionName
Type          : Microsoft.Advisor/suppressions
```

Creating a suppression by piping two cmdlet. First cmdlet will return one recommendation and second cmdlet will create a suppression for the same.

## PARAMETERS

### -Days
Days to disable.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
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

### -InputObject
The powershell object type PsAzureAdvisorResourceRecommendationBase returned by Get-AzureRmAdvisorRecommendation call.

```yaml
Type: PsAzureAdvisorResourceRecommendationBase
Parameter Sets: InputObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RecommendationName
ResourceName of the recommendation

```yaml
Type: String
Parameter Sets: NameParameterSet
Aliases: Name

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
ResourceID of the recommendation to be suppressed (space delimitited).

```yaml
Type: String
Parameter Sets: IdParameterSet
Aliases: Id

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorResourceRecommendationBase

## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorSuppressionContract, Microsoft.Azure.Commands.Advisor, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS
