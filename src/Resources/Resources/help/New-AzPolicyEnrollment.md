---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/new-azpolicyenrollment
schema: 2.0.0
---

# New-AzPolicyEnrollment

## SYNOPSIS
Creates a policy enrollment.

## SYNTAX

```
New-AzPolicyEnrollment -Name <String> -Scope <String> [-AssignmentScopeValidation <String>]
 [-Description <String>] [-DisplayName <String>] [-Metadata <String>] [-PolicyAssignmentId <String>]
 [-PolicyDefinitionReferenceId <String[]>] [-ResourceSelector <IResourceSelector[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
This **New-AzPolicyEnrollment** cmdlet creates a policy enrollment with the given scope and name.
Policy enrollments apply to all resources contained within their scope.
For example, when you create a policy enrollment at resource group scope for a policy assignment at the same or above level, the enrollment applies to all applicable resources in the resource group.

## EXAMPLES

### Example 1: Policy enrollment at subscription scope
```powershell
$Subscription = Get-AzSubscription -SubscriptionName 'Subscription01'
$Assignment = Get-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment'
New-AzPolicyEnrollment -Name 'VirtualMachinePolicyEnrollment' -PolicyAssignmentId $Assignment.Id -Scope "/subscriptions/$($Subscription.Id)" -DisplayName 'VM Policy Enrollment'
```

The first command gets a subscription named Subscription01 by using the Get-AzSubscription cmdlet and stores it in the $Subscription variable.
The second command gets the policy assignment named VirtualMachinePolicyAssignment by using the Get-AzPolicyAssignment cmdlet and stores it in the $Assignment variable.
The assignment must have EnforcementMode set to Enroll.
The final command creates the policy enrollment for the assignment in $Assignment at the level of the subscription identified by the subscription scope string.

### Example 2: Policy enrollment at management group scope
```powershell
$ManagementGroup = Get-AzManagementGroup -GroupName 'AManagementGroup'
$Assignment = Get-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment'
New-AzPolicyEnrollment -Name 'VirtualMachinePolicyEnrollment' -PolicyAssignmentId $Assignment.Id -Scope $ManagementGroup.Id -Description 'Enrollment for VM policy at MG level'
```

The first command gets a management group named AManagementGroup by using the Get-AzManagementGroup cmdlet and stores it in the $ManagementGroup variable.
The second command gets the policy assignment named VirtualMachinePolicyAssignment by using the Get-AzPolicyAssignment cmdlet and stores it in the $Assignment variable.
The assignment must have EnforcementMode set to Enroll.
The final command creates the policy enrollment for the assignment in $Assignment at the management group scope identified by the **Id** property of $ManagementGroup.

### Example 3: Policy enrollment with resource selector
```powershell
$subscription = (Get-AzContext).Subscription
$Assignment = Get-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment'
$ResourceSelector = @{Name = "MyLocationSelector"; Selector = @(@{Kind = "resourceLocation"; In = @("eastus", "eastus2")})}
New-AzPolicyEnrollment -Name 'VirtualMachinePolicyEnrollment' -Scope "/subscriptions/$($subscription.Id)" -PolicyAssignmentId $Assignment.Id -ResourceSelector $ResourceSelector
```

The first command gets the subscription that the enrollment will be created at, the currently used one.
The second command gets the policy assignment named VirtualMachinePolicyAssignment by using the Get-AzPolicyAssignment cmdlet and stores it in the $Assignment variable.
The third command creates a resource selector object that limits the enrollment to resources located in East US or East US 2 and stores it in the $ResourceSelector variable.
The final command creates the policy enrollment for the assignment in $Assignment with the resource selector specified by $ResourceSelector.

## PARAMETERS

### -AssignmentScopeValidation
The option whether to validate the enrollment is at or under the assignment scope.

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

### -Description
The description of the policy enrollment.

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

### -DisplayName
The display name of the policy enrollment.

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

### -Metadata
The policy enrollment metadata.
Metadata is an open ended object and is typically a collection of key value pairs.

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

### -Name
The name of the policy enrollment.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: PolicyEnrollmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicyAssignmentId
The ID of the policy assignment that is being enrolled.

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

### -PolicyDefinitionReferenceId
When the associated policy assignment is for a policy set (initiative), this can be used to specify the policy definition reference IDs for policy definitions in the policy set that should be enrolled to.
These IDs correspond to a subset of `policyDefinitions[*].policyDefinitionReferenceId` in the policy set definition.
When specified and not empty, only the referenced policy definitions will be enrolled to.
Otherwise, the entire policy set is enrolled to.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceSelector
The resource selector list to filter policies by resource properties.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scope of the policy enrollment.
Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'), resource group (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}'), or resource (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/[{parentResourcePath}/]{resourceType}/{resourceName}')

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollment

## NOTES

## RELATED LINKS
