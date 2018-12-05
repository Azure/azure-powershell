---
external help file: Microsoft.Azure.Commands.Advisor.dll-Help.xml
Module Name: AzureRM.Advisor
online version:
schema: 2.0.0
---

# Enable-AzureRmAdvisorRecommendation

## SYNOPSIS
Enable an Azure Advisor recommendation.

## SYNTAX

### NameParameterSet (Default)
```
Enable-AzureRmAdvisorRecommendation -RecommendationName <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### IdParameterSet
```
Enable-AzureRmAdvisorRecommendation -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### InputObjectParameterSet
```
Enable-AzureRmAdvisorRecommendation
 -InputObject <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorResourceRecommendationBase]>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Enables a suppresed recomendation, the suppression for a recommendation are removed using this cmdlet. One can remove all the suppression associated with a recommendation.

## EXAMPLES

### Example 1
```powershell
PS C:\> Enable-AzureRMAdvisorRecommendation -Id "{recommendation_id}" 

Id                   : subscriptions/{user_subscription}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cache/Redis/xyz/providers/Microsoft.Advisor/recommendations/{recommendation_id}
Category             : Performance
ExtendedProperties   : {}
Impact               : Medium
ImpactedField        : Microsoft.Cache/Redis
ImpactedValue        : xyz
LastUpdated          : 12/4/2018 12:06:47 AM
Metadata             : {}
RecommendationTypeId : 905a0026-8010-45b2-ab46-a92c3e4a5131
Risk                 : None
ShortDescription     : problem : Improve the performance and reliability of your Redis Cache instance
                       solution :Follow Redis cache Advisor recommendations

SuppressionIds       : {} 
Name                 : {recommendation_id}
Type                 : Microsoft.Advisor/recommendations
```

Removes all the suppression for the given recommendation with name "recommendation_id".

### Example 2
```powershell
PS C:\> Get-AzureRMAdvisorRecommendation -Id "/subscriptions/{user_subscription}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cache/Redis/xyz/providers/Microsoft.Advisor/recommendations/{recommendation_id}" 
| Enable-AzureRMAdvisorRecommendation

Id                   : subscriptions/{user_subscription}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cache/Redis/xyz/providers/Microsoft.Advisor/recommendations/{recommendation_id}
Category             : Performance
ExtendedProperties   : {}
Impact               : Medium
ImpactedField        : Microsoft.Cache/Redis
ImpactedValue        : xyz
LastUpdated          : 12/4/2018 12:06:47 AM
Metadata             : {}
RecommendationTypeId : 905a0026-8010-45b2-ab46-a92c3e4a5131
Risk                 : None
ShortDescription     : problem : Improve the performance and reliability of your Redis Cache instance
                       solution :Follow Redis cache Advisor recommendations

SuppressionIds       : {} 
Name                 : {recommendation_id}
Type                 : Microsoft.Advisor/recommendations
```

## PARAMETERS

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
The pipeline object returned by Get-AzureRmAdvisorRecommendation call.


```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorResourceRecommendationBase]
Parameter Sets: InputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RecommendationName
ResourceName of the recommendation.

```yaml
Type: String
Parameter Sets: NameParameterSet
Aliases: Name

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Resource Id of the recommenation to be suppressed.

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

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorResourceRecommendationBase, Microsoft.Azure.Commands.Advisor, Version=0.1.1.0, Culture=neutral, PublicKeyToken=null]]

## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorResourceRecommendationBase, Microsoft.Azure.Commands.Advisor, Version=0.1.1.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS
