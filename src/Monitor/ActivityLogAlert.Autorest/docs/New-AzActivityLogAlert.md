---
external help file:
Module Name: Az.Monitor
online version: https://docs.microsoft.com/powershell/module/az.monitor/new-azactivitylogalert
schema: 2.0.0
---

# New-AzActivityLogAlert

## SYNOPSIS
Create a new Activity Log Alert rule or update an existing one.

## SYNTAX

```
New-AzActivityLogAlert -Name <String> -ResourceGroupName <String> -Action <IActionGroup[]>
 -Condition <IAlertRuleAnyOfOrLeafCondition[]> -Location <String> -Scope <String[]> [-SubscriptionId <String>]
 [-Description <String>] [-Enabled <Boolean>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a new Activity Log Alert rule or update an existing one.

## EXAMPLES

### Example 1: Create activity log alert
```powershell
$scope = "subscriptions/"+(Get-AzContext).Subscription.ID
$actiongroup=New-AzActivityLogAlertActionGroupObject -Id $ActionGroupResourceId -WebhookProperty @{"sampleWebhookProperty"="SamplePropertyValue"}
$condition1=New-AzActivityLogAlertAlertRuleAnyOfOrLeafConditionObject -Equal Administrative -Field category
$condition2=New-AzActivityLogAlertAlertRuleAnyOfOrLeafConditionObject -Equal Error -Field level
$any1=New-AzActivityLogAlertAlertRuleLeafConditionObject -Field properties.incidentType -Equal Maintenance
$any2=New-AzActivityLogAlertAlertRuleLeafConditionObject -Field properties.incidentType -Equal Incident
$condition3=New-AzActivityLogAlertAlertRuleAnyOfOrLeafConditionObject -AnyOf $any1,$any2
New-AzActivityLogAlert -Name $AlertName -ResourceGroupName $ResourceGroupName -Action $actiongroup -Condition @($condition1,$condition2,$condition3) -Location global -Scope $scope
```

Create activity log alert for subscription, when `$condition1` and `$condition2` and (`$any1` or `$any2`) fulfilled

## PARAMETERS

### -Action
The list of the Action Groups.
To construct, see NOTES section for ACTIONGROUP properties and create a hash table.
To construct, see NOTES section for ACTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActivityLogAlert.Models.Api20201001.IActionGroup[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Condition
The list of Activity Log Alert rule conditions.
To construct, see NOTES section for CONDITIONALLOF properties and create a hash table.
To construct, see NOTES section for CONDITION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActivityLogAlert.Models.Api20201001.IAlertRuleAnyOfOrLeafCondition[]
Parameter Sets: (All)
Aliases:

Required: True
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

### -Description
A description of this Activity Log Alert rule.

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

### -Enabled
Indicates whether this Activity Log Alert rule is enabled.
If an Activity Log Alert rule is not enabled, then none of its actions will be activated.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The location of the resource.
Since Azure Activity Log Alerts is a global service, the location of the rules should always be 'global'.

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

### -Name
The name of the Activity Log Alert rule.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ActivityLogAlertName

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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
A list of resource IDs that will be used as prefixes.
The alert will only apply to Activity Log events with resource IDs that fall under one of these prefixes.
This list must include at least one item.

```yaml
Type: System.String[]
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

### -Tag
The tags of the resource.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActivityLogAlert.Models.Api20201001.IActivityLogAlertResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`ACTION <IActionGroup[]>`: The list of the Action Groups. To construct, see NOTES section for ACTIONGROUP properties and create a hash table.
  - `Id <String>`: The resource ID of the Action Group. This cannot be null or empty.
  - `[WebhookProperty <IActionGroupWebhookProperties>]`: the dictionary of custom properties to include with the post operation. These data are appended to the webhook payload.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

`CONDITION <IAlertRuleAnyOfOrLeafCondition[]>`: The list of Activity Log Alert rule conditions. To construct, see NOTES section for CONDITIONALLOF properties and create a hash table.
  - `[ContainsAny <String[]>]`: The value of the event's field will be compared to the values in this array (case-insensitive) to determine if the condition is met.
  - `[Equal <String>]`: The value of the event's field will be compared to this value (case-insensitive) to determine if the condition is met.
  - `[Field <String>]`: The name of the Activity Log event's field that this condition will examine.         The possible values for this field are (case-insensitive): 'resourceId', 'category', 'caller', 'level', 'operationName', 'resourceGroup', 'resourceProvider', 'status', 'subStatus', 'resourceType', or anything beginning with 'properties'.
  - `[AnyOf <IAlertRuleLeafCondition[]>]`: An Activity Log Alert rule condition that is met when at least one of its member leaf conditions are met.
    - `[ContainsAny <String[]>]`: The value of the event's field will be compared to the values in this array (case-insensitive) to determine if the condition is met.
    - `[Equal <String>]`: The value of the event's field will be compared to this value (case-insensitive) to determine if the condition is met.
    - `[Field <String>]`: The name of the Activity Log event's field that this condition will examine.         The possible values for this field are (case-insensitive): 'resourceId', 'category', 'caller', 'level', 'operationName', 'resourceGroup', 'resourceProvider', 'status', 'subStatus', 'resourceType', or anything beginning with 'properties'.

## RELATED LINKS

