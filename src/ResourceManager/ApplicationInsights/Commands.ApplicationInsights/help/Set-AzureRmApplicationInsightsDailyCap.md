---
external help file: Microsoft.Azure.Commands.ApplicationInsights.dll-Help.xml
Module Name: AzureRM.ApplicationInsights
online version: 
schema: 2.0.0
---

# Set-AzureRmApplicationInsightsDailyCap

## SYNOPSIS
Set daily data volume cap for an application insights resource

## SYNTAX

```
Set-AzureRmApplicationInsightsDailyCap [-ResourceGroupName] <String> [-Name] <String> [[-DailyCapGB] <Double>]
 [[-StopSendNotificationWhenHitCap] <Boolean>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Set daily data volume cap for an application insights resource

## EXAMPLES

### Example 1
```
PS C:\> Set-AzureRmApplicationInsightsDailyCap -ResourceGroupName "testgroup" -Name "test" -DailyCapGB 400
 -StopSendNotificationWhenHitCap true
```

Set the daily data volumen cap to 400GB per day and stop send notification when hit cap for resource "test" in resource group "testgroup"

## PARAMETERS

### -DailyCapGB
Daily Cap.

```yaml
Type: Double
Parameter Sets: (All)
Aliases: 

Required: False
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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

### -StopSendNotificationWhenHitCap
Stop send notification when hit cap.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases: 

Required: False
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
System.Double
System.Boolean

## OUTPUTS

### Microsoft.Azure.Commands.ApplicationInsights.Models.PSPricingTier

## NOTES

## RELATED LINKS

