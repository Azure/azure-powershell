---
external help file:
Module Name: Az.Resilience
online version: https://learn.microsoft.com/powershell/module/az.resilience/get-azresiliencegoalassignmentcapacity
schema: 2.0.0
---

# Get-AzResilienceGoalAssignmentCapacity

## SYNOPSIS
Recommends capacity improvements for resources under the goal assignments scope.
Returns AI-powered capacity assessments and recommendations.

## SYNTAX

### GetExpanded (Default)
```
Get-AzResilienceGoalAssignmentCapacity -GoalAssignmentName <String> -ServiceGroupName <String>
 -ResourceId <String[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Get
```
Get-AzResilienceGoalAssignmentCapacity -GoalAssignmentName <String> -ServiceGroupName <String>
 -Body <IRecommendCapacityRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzResilienceGoalAssignmentCapacity -InputObject <IResilienceIdentity> -Body <IRecommendCapacityRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaIdentityExpanded
```
Get-AzResilienceGoalAssignmentCapacity -InputObject <IResilienceIdentity> -ResourceId <String[]>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaIdentityServiceGroup
```
Get-AzResilienceGoalAssignmentCapacity -GoalAssignmentName <String>
 -ServiceGroupInputObject <IResilienceIdentity> -Body <IRecommendCapacityRequest> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaIdentityServiceGroupExpanded
```
Get-AzResilienceGoalAssignmentCapacity -GoalAssignmentName <String>
 -ServiceGroupInputObject <IResilienceIdentity> -ResourceId <String[]> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaJsonFilePath
```
Get-AzResilienceGoalAssignmentCapacity -GoalAssignmentName <String> -ServiceGroupName <String>
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### GetViaJsonString
```
Get-AzResilienceGoalAssignmentCapacity -GoalAssignmentName <String> -ServiceGroupName <String>
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Recommends capacity improvements for resources under the goal assignments scope.
Returns AI-powered capacity assessments and recommendations.

## EXAMPLES

### Example 1: Get capacity recommendations for a goal assignment
```powershell
Get-AzResilienceGoalAssignmentCapacity `
  -GoalAssignmentName 'ga-payments-tier1' `
  -ServiceGroupName 'azcmdlet-testing' `
  -ResourceId @('/subscriptions/30233210-6bf4-4c4f-9e00-7cdcc1a176ec/resourceGroups/rg-resiliency-prod/providers/Microsoft.Compute/virtualMachines/vm-payments-01')
```

Evaluates the supplied resources and returns capacity assessments and resiliency recommendations.
Pass an empty array to let the service discover non-resilient resources in the scope automatically.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IRecommendCapacityRequest
Parameter Sets: Get, GetViaIdentity, GetViaIdentityServiceGroup
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
Parameter Sets: Get, GetExpanded, GetViaIdentityServiceGroup, GetViaIdentityServiceGroupExpanded, GetViaJsonFilePath, GetViaJsonString
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: GetViaIdentity, GetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Get operation

```yaml
Type: System.String
Parameter Sets: GetViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Get operation

```yaml
Type: System.String
Parameter Sets: GetViaJsonString
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
Parameter Sets: GetExpanded, GetViaIdentityExpanded, GetViaIdentityServiceGroupExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: GetViaIdentityServiceGroup, GetViaIdentityServiceGroupExpanded
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
Parameter Sets: Get, GetExpanded, GetViaJsonFilePath, GetViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IRecommendCapacityRequest

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IRecommendCapacityResult

## NOTES

## RELATED LINKS

