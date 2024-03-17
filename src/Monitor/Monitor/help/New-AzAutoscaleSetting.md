---
external help file: Az.Autoscale.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/new-azautoscalesetting
schema: 2.0.0
---

# New-AzAutoscaleSetting

## SYNOPSIS
Creates or updates an autoscale setting.

## SYNTAX

### CreateViaIdentity (Default)
```
New-AzAutoscaleSetting -InputObject <IAutoscaleIdentity> -Parameter <IAutoscaleSettingResource>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateExpanded
```
New-AzAutoscaleSetting -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -Location <String>
 -Profile <IAutoscaleProfile[]> [-Enabled] [-Notification <IAutoscaleNotification[]>]
 [-PredictiveAutoscalePolicyScaleLookAheadTime <TimeSpan>]
 [-PredictiveAutoscalePolicyScaleMode <PredictiveAutoscalePolicyScaleMode>] [-PropertiesName <String>]
 [-Tag <Hashtable>] [-TargetResourceLocation <String>] [-TargetResourceUri <String>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates an autoscale setting.

## EXAMPLES

### Example 1: Create autoscale setting for vmss
```powershell
$subscriptionId = (Get-AzContext).Subscription.Id
$rule1=New-AzAutoscaleScaleRuleObject -MetricTriggerMetricName "Percentage CPU" -MetricTriggerMetricResourceUri "/subscriptions/$subscriptionId/resourceGroups/test-group/providers/Microsoft.Compute/virtualMachineScaleSets/test-vmss" -MetricTriggerTimeGrain ([System.TimeSpan]::New(0,1,0)) -MetricTriggerStatistic "Average" -MetricTriggerTimeWindow ([System.TimeSpan]::New(0,5,0)) -MetricTriggerTimeAggregation "Average" -MetricTriggerOperator "GreaterThan" -MetricTriggerThreshold 10 -MetricTriggerDividePerInstance $false -ScaleActionDirection "Increase" -ScaleActionType "ChangeCount" -ScaleActionValue 1 -ScaleActionCooldown ([System.TimeSpan]::New(0,5,0))
$profile1=New-AzAutoscaleProfileObject -Name "adios" -CapacityDefault 1 -CapacityMaximum 10 -CapacityMinimum 1 -Rule $rule1 -FixedDateEnd ([System.DateTime]::Parse("2022-12-31T14:00:00Z")) -FixedDateStart ([System.DateTime]::Parse("2022-12-31T13:00:00Z")) -FixedDateTimeZone "UTC"
$webhook1=New-AzAutoscaleWebhookNotificationObject -Property @{} -ServiceUri "http://myservice.com"
$notification1=New-AzAutoscaleNotificationObject -EmailCustomEmail "gu@ms.com" -EmailSendToSubscriptionAdministrator $true -EmailSendToSubscriptionCoAdministrator $true -Webhook $webhook1
New-AzAutoscaleSetting -Name test-autoscalesetting -ResourceGroupName test-group -Location westeurope -Profile $profile1 -Enabled -Notification $notification1 -PredictiveAutoscalePolicyScaleLookAheadTime ([System.TimeSpan]::New(0,5,0)) -PredictiveAutoscalePolicyScaleMode 'Enabled' -PropertiesName "test-autoscalesetting" -TargetResourceUri "/subscriptions/$subscriptionId/resourceGroups/test-group/providers/Microsoft.Compute/virtualMachineScaleSets/test-vmss"
```

Create autoscale setting for vmss

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -Enabled
the enabled flag.
Specifies whether automatic scaling is enabled for the resource.
The default value is 'false'.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.IAutoscaleIdentity
Parameter Sets: CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Resource location

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The autoscale setting name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases: AutoscaleSettingName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Notification
the collection of notifications.
To construct, see NOTES section for NOTIFICATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.Api20221001.IAutoscaleNotification[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
The autoscale setting resource.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.Api20221001.IAutoscaleSettingResource
Parameter Sets: CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PredictiveAutoscalePolicyScaleLookAheadTime
the amount of time to specify by which instances are launched in advance.
It must be between 1 minute and 60 minutes in ISO 8601 format.

```yaml
Type: System.TimeSpan
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PredictiveAutoscalePolicyScaleMode
the predictive autoscale mode

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Support.PredictiveAutoscalePolicyScaleMode
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Profile
the collection of automatic scaling profiles that specify different scaling parameters for different time periods.
A maximum of 20 profiles can be specified.
To construct, see NOTES section for PROFILE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.Api20221001.IAutoscaleProfile[]
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PropertiesName
the name of the autoscale setting.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Gets or sets a list of key value pairs that describe the resource.
These tags can be used in viewing and grouping this resource (across resource groups).
A maximum of 15 tags can be provided for a resource.
Each tag must have a key no greater in length than 128 characters and a value no greater in length than 256 characters.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceLocation
the location of the resource that the autoscale setting should be added to.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceUri
the resource identifier of the resource that the autoscale setting should be added to.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.Api20221001.IAutoscaleSettingResource

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.IAutoscaleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Models.Api20221001.IAutoscaleSettingResource

## NOTES

## RELATED LINKS
