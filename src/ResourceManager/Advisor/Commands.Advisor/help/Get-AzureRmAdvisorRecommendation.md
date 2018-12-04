---
external help file: Microsoft.Azure.Commands.Advisor.dll-Help.xml
Module Name: AzureRM.Advisor
online version:
schema: 2.0.0
---

# Get-AzureRmAdvisorRecommendation

## SYNOPSIS
Gets a list of Azure Advisor recommendations.

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
This dispays the list of recommendations.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzureRMAdvisorRecommendation -ResourceId "id1 id2"

Id                   : id1
Category             : Performance
ExtendedProperties   : {}
Impact               : Medium
ImpactedField        : Microsoft.Cache/Redis
ImpactedValue        : azacache
LastUpdated          : 12/3/2018 11:04:50 PM
Metadata             : {}
RecommendationTypeId : 905a0026-8010-45b2-ab46-a92c3e4a5131
Risk                 : None
ShortDescription     : problem : Improve the performance and reliability of your Redis Cache instance
                       solution :Follow Redis cache Advisor recommendations

SuppressionIds       : {}
Name                 : rec-name
Type                 : Microsoft.Advisor/recommendations

Id                   : id2
Category             : Performance
ExtendedProperties   : {}
Impact               : Medium
ImpactedField        : Microsoft.Cache/Redis
ImpactedValue        : azacache
LastUpdated          : 12/2/2018 11:04:50 PM
Metadata             : {}
RecommendationTypeId : 905a0026-8010-45b2-ab46-a92c3e4a5131
Risk                 : None
ShortDescription     : problem : Improve the performance and reliability of your Redis Cache instance
                       solution :Follow Redis cache Advisor recommendations

SuppressionIds       : {}
Name                 : rec-name
Type                 : Microsoft.Advisor/recommendations
```

Get list of recommendation using the given -ResourceId's specified.


### Example 2
```powershell
PS C:\> Get-AzureRMAdvisorRecommendation -ResourceGroupName "resourceGroupName" -Category Performance

Id                   : id1
Category             : Performance
ExtendedProperties   : {}
Impact               : Medium
ImpactedField        : Microsoft.Cache/Redis
ImpactedValue        : azacache
LastUpdated          : 12/3/2018 11:04:50 PM
Metadata             : {}
RecommendationTypeId : 905a0026-8010-45b2-ab46-a92c3e4a5131
Risk                 : None
ShortDescription     : problem : Improve the performance and reliability of your Redis Cache instance
                       solution :Follow Redis cache Advisor recommendations

SuppressionIds       : {}
Name                 : rec-name
Type                 : Microsoft.Advisor/recommendations

Id                   : id2
Category             : Performance
ExtendedProperties   : {}
Impact               : Medium
ImpactedField        : Microsoft.Cache/Redis
ImpactedValue        : azacache
LastUpdated          : 12/2/2018 11:04:50 PM
Metadata             : {}
RecommendationTypeId : 905a0026-8010-45b2-ab46-a92c3e4a5131
Risk                 : None
ShortDescription     : problem : Improve the performance and reliability of your Redis Cache instance
                       solution :Follow Redis cache Advisor recommendations

SuppressionIds       : {}
Name                 : rec-name
Type                 : Microsoft.Advisor/recommendations
```

Get list of recommendation using the given -ResourceGroupName, -Category specified.

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
ResourceGroup name of the recommendation.

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

### System.String

## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorResourceRecommendationBase, Microsoft.Azure.Commands.Advisor, Version=0.1.1.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS
