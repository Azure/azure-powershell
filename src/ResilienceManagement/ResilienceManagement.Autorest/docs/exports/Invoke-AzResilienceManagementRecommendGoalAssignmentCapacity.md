---
external help file:
Module Name: Az.ResilienceManagement
online version: https://learn.microsoft.com/powershell/module/az.resiliencemanagement/invoke-azresiliencemanagementrecommendgoalassignmentcapacity
schema: 2.0.0
---

# Invoke-AzResilienceManagementRecommendGoalAssignmentCapacity

## SYNOPSIS
Recommends capacity improvements for resources under the goal assignments scope.
Returns AI-powered capacity assessments and recommendations.

## SYNTAX

### RecommendExpanded (Default)
```
Invoke-AzResilienceManagementRecommendGoalAssignmentCapacity -GoalAssignmentName <String>
 -ServiceGroupName <String> -ResourceId <String[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Recommend
```
Invoke-AzResilienceManagementRecommendGoalAssignmentCapacity -GoalAssignmentName <String>
 -ServiceGroupName <String> -Body <IRecommendCapacityRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RecommendViaIdentity
```
Invoke-AzResilienceManagementRecommendGoalAssignmentCapacity -InputObject <IResilienceManagementIdentity>
 -Body <IRecommendCapacityRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RecommendViaIdentityExpanded
```
Invoke-AzResilienceManagementRecommendGoalAssignmentCapacity -InputObject <IResilienceManagementIdentity>
 -ResourceId <String[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RecommendViaIdentityServiceGroup
```
Invoke-AzResilienceManagementRecommendGoalAssignmentCapacity -GoalAssignmentName <String>
 -ServiceGroupInputObject <IResilienceManagementIdentity> -Body <IRecommendCapacityRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RecommendViaIdentityServiceGroupExpanded
```
Invoke-AzResilienceManagementRecommendGoalAssignmentCapacity -GoalAssignmentName <String>
 -ServiceGroupInputObject <IResilienceManagementIdentity> -ResourceId <String[]> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RecommendViaJsonFilePath
```
Invoke-AzResilienceManagementRecommendGoalAssignmentCapacity -GoalAssignmentName <String>
 -ServiceGroupName <String> -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### RecommendViaJsonString
```
Invoke-AzResilienceManagementRecommendGoalAssignmentCapacity -GoalAssignmentName <String>
 -ServiceGroupName <String> -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Recommends capacity improvements for resources under the goal assignments scope.
Returns AI-powered capacity assessments and recommendations.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```powershell
{{ Add code here }}
```



### -------------------------- EXAMPLE 2 --------------------------
```powershell
{{ Add code here }}
```



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
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IRecommendCapacityRequest
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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IResilienceManagementIdentity
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
To construct, see NOTES section for SERVICEGROUPINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IResilienceManagementIdentity
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

### Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IRecommendCapacityRequest

### Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IResilienceManagementIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IRecommendCapacityResult

## NOTES

## RELATED LINKS

