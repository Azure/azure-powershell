---
external help file: Az.PolicyInsights-help.xml
Module Name: Az.PolicyInsights
online version: https://learn.microsoft.com/powershell/module/az.policyinsights/get-azpolicystatesummary
schema: 2.0.0
---

# Get-AzPolicyStateSummary

## SYNOPSIS
Gets latest policy compliance states summary for resources.

## SYNTAX

### SummarizeBySubscriptionId (Default)
```
Get-AzPolicyStateSummary [-SubscriptionId <String>] [-Filter <String>] [-From <DateTime>] [-To <DateTime>]
 [-Top <Int32>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SummarizeByResourceGroup
```
Get-AzPolicyStateSummary [-SubscriptionId <String>] -ResourceGroupName <String> [-Filter <String>]
 [-From <DateTime>] [-To <DateTime>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SummarizeByPolicySetDefinition
```
Get-AzPolicyStateSummary [-SubscriptionId <String>] -PolicySetDefinitionName <String> [-Filter <String>]
 [-From <DateTime>] [-To <DateTime>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SummarizeByPolicyDefinition
```
Get-AzPolicyStateSummary [-SubscriptionId <String>] -PolicyDefinitionName <String> [-Filter <String>]
 [-From <DateTime>] [-To <DateTime>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SummarizeByPolicyAssignment
```
Get-AzPolicyStateSummary [-SubscriptionId <String>] -PolicyAssignmentName <String> [-Filter <String>]
 [-From <DateTime>] [-To <DateTime>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SummarizeByPolicyAssignmentAndResourceGroup
```
Get-AzPolicyStateSummary [-SubscriptionId <String>] -ResourceGroupName <String> -PolicyAssignmentName <String>
 [-Filter <String>] [-From <DateTime>] [-To <DateTime>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SummarizeByManagementGroup
```
Get-AzPolicyStateSummary -ManagementGroupName <String> [-Filter <String>] [-From <DateTime>] [-To <DateTime>]
 [-Top <Int32>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SummarizeByResourceId
```
Get-AzPolicyStateSummary -ResourceId <String> [-Filter <String>] [-From <DateTime>] [-To <DateTime>]
 [-Top <Int32>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzPolicyStateSummary** cmdlet gets a summary view of latest policy compliance state numbers at various scopes, broken down into policy assignments and policy definitions.

It includes mostly information on non-compliant policy states.

## EXAMPLES

### Example 1: Get latest non-compliant policy states summary in current subscription scope
```powershell
Get-AzPolicyStateSummary
```

Gets the summary view of latest policy compliance states generated in the last day for all resources within the subscription in current session context.

### Example 2: Get latest non-compliant policy states summary in the specified subscription scope
```powershell
Get-AzPolicyStateSummary -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources within the specified subscription.

### Example 3: Get latest non-compliant policy states summary in management group scope
```powershell
Get-AzPolicyStateSummary -ManagementGroupName "myManagementGroup"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources within the specified management group.

### Example 4: Get latest non-compliant policy states summary in resource group scope in current subscription
```powershell
Get-AzPolicyStateSummary -ResourceGroupName "myResourceGroup"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources within the specified resource group (in the subscription in current session context).

### Example 5: Get latest non-compliant policy states summary in resource group scope in the specified subscription
```powershell
Get-AzPolicyStateSummary -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -ResourceGroupName "myResourceGroup"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources within the specified resource group (in the specified subscription).

### Example 6: Get latest non-compliant policy states summary for a resource
```powershell
Get-AzPolicyStateSummary -ResourceId "/subscriptions/fff10b27-fff3-fff5-fff8-fffbe01e86a5/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myns1/eventhubs/eh1/consumergroups/cg1"
```

Gets the summary view of latest policy compliance states generated in the last day for the specified resource.

### Example 7: Get latest non-compliant policy states summary for a policy set definition in current subscription
```powershell
Get-AzPolicyStateSummary -PolicySetDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources (within the tenant in current session context) effected by the specified policy set definition (that exists in the subscription in current session context).

### Example 8: Get latest non-compliant policy states summary for a policy set definition in the specified subscription
```powershell
Get-AzPolicyStateSummary -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -PolicySetDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources (within the tenant in current session context) effected by the specified policy set definition (that exists in the specified subscription).

### Example 9: Get latest non-compliant policy states summary for a policy definition in current subscription
```powershell
Get-AzPolicyStateSummary -PolicyDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources (within the tenant in current session context) effected by the specified policy definition (that exists in the subscription in current session context).

### Example 10: Get latest non-compliant policy states summary for a policy definition in the specified subscription
```powershell
Get-AzPolicyStateSummary -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -PolicyDefinitionName "fff58873-fff8-fff5-fffc-fffbe7c9d697"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources (within the tenant in current session context) effected by the specified policy definition (that exists in the specified subscription).

### Example 11: Get latest non-compliant policy states summary for a policy assignment in current subscription
```powershell
Get-AzPolicyStateSummary -PolicyAssignmentName "ddd8ef92e3714a5ea3d208c1"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources (within the tenant in current session context) effected by the specified policy assignment (that exists in the subscription in current session context).

### Example 12: Get latest non-compliant policy states summary for a policy assignment in the specified subscription
```powershell
Get-AzPolicyStateSummary -SubscriptionId "fff10b27-fff3-fff5-fff8-fffbe01e86a5" -PolicyAssignmentName "ddd8ef92e3714a5ea3d208c1"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources (within the tenant in current session context) effected by the specified policy assignment (that exists in the specified subscription).

### Example 13: Get latest non-compliant policy states summary for a policy assignment in the specified resource group in the current subscription
```powershell
Get-AzPolicyStateSummary -ResourceGroupName "myResourceGroup" -PolicyAssignmentName "ddd8ef92e3714a5ea3d208c1"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources (within the tenant in current session context) effected by the specified policy assignment (that exists in the resource group in the subscription in current session context).

### Example 14: Get latest non-compliant policy states summary in current subscription scope, with Top query option
```powershell
Get-AzPolicyStateSummary -Top 5
```

Gets the summary view of latest policy compliance states generated in the last day for all resources within the subscription in current session context.

The command orders the policy assignment summaries in the results by non-compliant resource counts in descending order, and takes only top 5 of those policy assignment summaries.

### Example 15: Get latest non-compliant policy states summary in current subscription scope, with From and To query options
```powershell
Get-AzPolicyStateSummary -From "2018-03-08 00:00:00Z" -To "2018-03-15 00:00:00Z"
```

Gets the summary view of latest policy compliance states generated within the date range specified for all resources within the subscription in current session context.

### Example 16: Get latest non-compliant policy states summary in current subscription scope, with Filter query option
```powershell
Get-AzPolicyStateSummary -Filter "(PolicyDefinitionAction eq 'deny' or PolicyDefinitionAction eq 'audit') and ResourceLocation ne 'eastus'"
```

Gets the summary view of latest policy compliance states generated in the last day for all resources within the subscription in current session context.
The command limits the results returned by filtering based on policy definition action (includes deny or audit actions), and resource location (excludes eastus location).

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

### -Filter
Filter expression using OData notation.

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

### -From
ISO 8601 formatted timestamp specifying the start time of the interval to query.
When not specified, the service uses ($to - 1-day).

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagementGroupName
Management group name.

```yaml
Type: System.String
Parameter Sets: SummarizeByManagementGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicyAssignmentName
Policy assignment name.

```yaml
Type: System.String
Parameter Sets: SummarizeByPolicyAssignment, SummarizeByPolicyAssignmentAndResourceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicyDefinitionName
Policy definition name.

```yaml
Type: System.String
Parameter Sets: SummarizeByPolicyDefinition
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicySetDefinitionName
Policy set definition name.

```yaml
Type: System.String
Parameter Sets: SummarizeByPolicySetDefinition
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource group name.

```yaml
Type: System.String
Parameter Sets: SummarizeByResourceGroup, SummarizeByPolicyAssignmentAndResourceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Resource ID.

```yaml
Type: System.String
Parameter Sets: SummarizeByResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
Uses current subscription if one isn't provided.

```yaml
Type: System.String
Parameter Sets: SummarizeBySubscriptionId, SummarizeByResourceGroup, SummarizeByPolicySetDefinition, SummarizeByPolicyDefinition, SummarizeByPolicyAssignment, SummarizeByPolicyAssignmentAndResourceGroup
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -To
ISO 8601 formatted timestamp specifying the end time of the interval to query.
When not specified, the service uses request time.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Maximum number of records to return.

```yaml
Type: System.Int32
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

### Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.ISummary

## NOTES

## RELATED LINKS
