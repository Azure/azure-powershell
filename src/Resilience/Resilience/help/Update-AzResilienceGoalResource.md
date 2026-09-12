---
external help file: Az.Resilience-help.xml
Module Name: Az.Resilience
online version: https://learn.microsoft.com/powershell/module/az.resilience/update-azresiliencegoalresource
schema: 2.0.0
---

# Update-AzResilienceGoalResource

## SYNOPSIS
Action to exclude a resource from goal assignment.

## SYNTAX

### UpdateViaIdentity (Default)
```
Update-AzResilienceGoalResource -InputObject <IResilienceIdentity> -Body <IUpdateGoalResourceRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzResilienceGoalResource -GoalAssignmentName <String> -ServiceGroupName <String> -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzResilienceGoalResource -GoalAssignmentName <String> -ServiceGroupName <String> -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityServiceGroupExpanded
```
Update-AzResilienceGoalResource -GoalAssignmentName <String> -ServiceGroupInputObject <IResilienceIdentity>
 -Resource <IGoalResource[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityServiceGroup
```
Update-AzResilienceGoalResource -GoalAssignmentName <String> -ServiceGroupInputObject <IResilienceIdentity>
 -Body <IUpdateGoalResourceRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateExpanded
```
Update-AzResilienceGoalResource -GoalAssignmentName <String> -ServiceGroupName <String>
 -Resource <IGoalResource[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Update
```
Update-AzResilienceGoalResource -GoalAssignmentName <String> -ServiceGroupName <String>
 -Body <IUpdateGoalResourceRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzResilienceGoalResource -InputObject <IResilienceIdentity> -Resource <IGoalResource[]>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Action to exclude a resource from goal assignment.

## EXAMPLES

### Example 1: Exclude a resource from a goal assignment
```powershell
$resource = Get-AzResilienceGoalResource `
  -Name 'gr-payments-web' `
  -GoalAssignmentName 'ga-payments-tier1' `
  -ServiceGroupName 'azcmdlet-testing'

$resource.HighAvailabilityGoalParticipation = 'Excluded'

Update-AzResilienceGoalResource `
  -GoalAssignmentName 'ga-payments-tier1' `
  -ServiceGroupName 'azcmdlet-testing' `
  -Resource $resource
```

Retrieves a goal resource, excludes it from high availability evaluation, and submits the change.
`-Resource` accepts an array, so several resources can be updated in a single call.

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
Request model for update goal resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IUpdateGoalResourceRequest
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityServiceGroup, Update
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
Parameter Sets: UpdateViaJsonString, UpdateViaJsonFilePath, UpdateViaIdentityServiceGroupExpanded, UpdateViaIdentityServiceGroup, UpdateExpanded, Update
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
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
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

### -Resource
List of update goal resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IGoalResource[]
Parameter Sets: UpdateViaIdentityServiceGroupExpanded, UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateViaIdentityServiceGroupExpanded, UpdateViaIdentityServiceGroup
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
Parameter Sets: UpdateViaJsonString, UpdateViaJsonFilePath, UpdateExpanded, Update
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

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IUpdateGoalResourceRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IUpdateGoalResourceResponse

## NOTES

## RELATED LINKS
