---
external help file: Microsoft.Azure.Commands.ApplicationInsights.dll-Help.xml
Module Name: AzureRM.ApplicationInsights
online version: 
schema: 2.0.0
---

# Get-AzureRmApplicationInsightsPricingPlan

## SYNOPSIS
Get pricing plan information for an applicaiton insights resource

## SYNTAX

```
Get-AzureRmApplicationInsightsPricingPlan [-ResourceGroupName] <String> [-Name] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Get pricing plan information for an applicaiton insights resource

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmApplicationInsightsDailyCapStatus -ResourceGroupName "testgroup" -Name "test"
```

Get pricing plan information for resource named "test" in resource group "testgroup"

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Application Insights Component Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ApplicationInsightsComponentName, ComponentName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.ApplicationInsights.Models.PSPricingTier

## NOTES

## RELATED LINKS

