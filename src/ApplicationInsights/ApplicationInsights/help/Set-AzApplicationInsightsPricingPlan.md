---
external help file: Az.ApplicationInsights-help.xml
Module Name: Az.ApplicationInsights
online version: https://learn.microsoft.com/powershell/module/az.applicationinsights/set-azapplicationinsightspricingplan
schema: 2.0.0
---

# Set-AzApplicationInsightsPricingPlan

## SYNOPSIS
Update current billing features for an Application Insights component.

## SYNTAX

```
Set-AzApplicationInsightsPricingPlan -ResourceGroupName <String> -Name <String> [-SubscriptionId <String>]
 [-PricingPlan <String>] [-DailyCapGB <Double>] [-DisableNotificationWhenHitCap] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update current billing features for an Application Insights component.

## EXAMPLES

### Example 1: Set pricing plan and daily data volume information for an application insights resource
```powershell
Set-AzApplicationInsightsPricingPlan -ResourceGroupName "testgroup" -Name "test" -PricingPlan "Basic" -DailyCapGB 400
```

Set the pricing plan to "Basic", set the daily data volume cap to 400GB per day and stop send notification when hit cap for resource "test" in resource group "testgroup"

## PARAMETERS

### -DailyCapGB
Daily data volume cap in GB.

```yaml
Type: System.Double
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
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableNotificationWhenHitCap
Stop send notification when hit cap.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Application Insights component resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ApplicationInsightsComponentName, ComponentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PricingPlan
Current enabled pricing plan.
When the component is in the Enterprise plan, this will list both 'Basic' and 'Application Insights Enterprise'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20150501.IApplicationInsightsComponentBillingFeatures

## NOTES

## RELATED LINKS
