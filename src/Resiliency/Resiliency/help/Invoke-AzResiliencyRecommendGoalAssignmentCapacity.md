---
external help file:
Module Name: Az.Resiliency
online version: https://learn.microsoft.com/powershell/module/az.resiliency/invoke-azresiliencyrecommendgoalassignmentcapacity
schema: 2.0.0
---

# Invoke-AzResiliencyRecommendGoalAssignmentCapacity

## SYNOPSIS
Recommends capacity improvements for resources under the goal assignments scope.
Returns AI-powered capacity assessments and recommendations.

## SYNTAX

### RecommendExpanded (Default)
```
Invoke-AzResiliencyRecommendGoalAssignmentCapacity -GoalAssignmentName <String> -ServiceGroupName <String>
 -ResourceId <String[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Recommend
```
Invoke-AzResiliencyRecommendGoalAssignmentCapacity -GoalAssignmentName <String> -ServiceGroupName <String>
 -Body <IRecommendCapacityRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RecommendViaIdentity
```
Invoke-AzResiliencyRecommendGoalAssignmentCapacity -InputObject <IResiliencyIdentity>
 -Body <IRecommendCapacityRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RecommendViaIdentityExpanded
```
Invoke-AzResiliencyRecommendGoalAssignmentCapacity -InputObject <IResiliencyIdentity> -ResourceId <String[]>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RecommendViaIdentityServiceGroup
```
Invoke-AzResiliencyRecommendGoalAssignmentCapacity -GoalAssignmentName <String>
 -ServiceGroupInputObject <IResiliencyIdentity> -Body <IRecommendCapacityRequest> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RecommendViaIdentityServiceGroupExpanded
```
Invoke-AzResiliencyRecommendGoalAssignmentCapacity -GoalAssignmentName <String>
 -ServiceGroupInputObject <IResiliencyIdentity> -ResourceId <String[]> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RecommendViaJsonFilePath
```
Invoke-AzResiliencyRecommendGoalAssignmentCapacity -GoalAssignmentName <String> -ServiceGroupName <String>
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RecommendViaJsonString
```
Invoke-AzResiliencyRecommendGoalAssignmentCapacity -GoalAssignmentName <String> -ServiceGroupName <String>
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Recommends capacity improvements for resources under the goal assignments scope.
Returns AI-powered capacity assessments and recommendations.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

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

### -Body
Request body for the recommend capacity action.
Provide specific resource IDs to evaluate, or pass an empty array to let the service automatically select non-resilient resources from the goal assignment.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IRecommendCapacityRequest
Parameter Sets: Recommend, RecommendViaIdentity, RecommendViaIdentityServiceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

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

### -GoalAssignmentName
The name of the GoalAssignment

```yaml
Type: System.String
Parameter Sets: Recommend, RecommendExpanded, RecommendViaIdentityServiceGroup, RecommendViaIdentityServiceGroupExpanded, RecommendViaJsonFilePath, RecommendViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IResiliencyIdentity
Parameter Sets: RecommendViaIdentity, RecommendViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Recommend operation

```yaml
Type: System.String
Parameter Sets: RecommendViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Recommend operation

```yaml
Type: System.String
Parameter Sets: RecommendViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -ResourceId
Azure resource IDs to evaluate for resiliency.
Pass an empty array to automatically discover and evaluate non-resilient resources in the service group.
Maximum 50 resources per request.

```yaml
Type: System.String[]
Parameter Sets: RecommendExpanded, RecommendViaIdentityExpanded, RecommendViaIdentityServiceGroupExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IResiliencyIdentity
Parameter Sets: RecommendViaIdentityServiceGroup, RecommendViaIdentityServiceGroupExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ServiceGroupName
The name of the service group.

```yaml
Type: System.String
Parameter Sets: Recommend, RecommendExpanded, RecommendViaJsonFilePath, RecommendViaJsonString
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IRecommendCapacityRequest

### Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IResiliencyIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resiliency.Models.IRecommendCapacityResult

## NOTES

## RELATED LINKS

