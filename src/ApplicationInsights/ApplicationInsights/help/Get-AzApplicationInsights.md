---
external help file: Az.ApplicationInsights-help.xml
Module Name: Az.ApplicationInsights
online version: https://learn.microsoft.com/powershell/module/az.applicationinsights/get-azapplicationinsights
schema: 2.0.0
---

# Get-AzApplicationInsights

## SYNOPSIS
Returns an Application Insights component.

## SYNTAX

### ListBySubscription (Default)
```
Get-AzApplicationInsights [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzApplicationInsights [-SubscriptionId <String[]>] -ResourceGroupName <String> -Name <String> [-Full]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListByResourceGroupName
```
Get-AzApplicationInsights [-SubscriptionId <String[]>] -ResourceGroupName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetByResourceId
```
Get-AzApplicationInsights -ResourceId <String> [-Full] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetByInputObject
```
Get-AzApplicationInsights -InputObject <IApplicationInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Returns an Application Insights component.

## EXAMPLES

### Example 1: Get application insights resource
```powershell
Get-AzApplicationInsights -ResourceGroupName "testgroup" -Name "test"
```

Get application insights resource

### Example 2: Get application insights resource with pricing plan information
```powershell
Get-AzApplicationInsights -ResourceGroupName "testgroup" -Name "test" -IncludePricingPlan
```

Get application insights resource with pricing plan information

## PARAMETERS

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

### -Full

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Get, GetByResourceId
Aliases: IncludeDailyCap, IncludeDailyCapStatus, IncludePricingPlan

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IApplicationInsightsIdentity
Parameter Sets: GetByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Application Insights component resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ApplicationInsightsComponentName, ComponentName

Required: True
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
Parameter Sets: Get, ListByResourceGroupName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource ID of applicationinsights component.

```yaml
Type: System.String
Parameter Sets: GetByResourceId
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
Type: System.String[]
Parameter Sets: ListBySubscription, Get, ListByResourceGroupName
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IApplicationInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api202002.IApplicationInsightsComponent

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.PSApplicationInsightsComponentWithPricingPlan

## NOTES

## RELATED LINKS
