---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/update-azpolicyenrollment
schema: 2.0.0
---

# Update-AzPolicyEnrollment

## SYNOPSIS
This operation updates a policy enrollment with the newly provided properties.

## SYNTAX

### UpdateByNameAndScope (Default)
```
Update-AzPolicyEnrollment -Name <String> -Scope <String> [-Description <String>] [-DisplayName <String>]
 [-AssignmentScopeValidation <String>] [-ResourceSelector <IResourceSelector[]>]
 [-PolicyDefinitionReferenceId <String[]>] [-Metadata <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### UpdateByInputObject
```
Update-AzPolicyEnrollment -InputObject <IPolicyEnrollment> [-Description <String>] [-DisplayName <String>]
 [-AssignmentScopeValidation <String>] [-ResourceSelector <IResourceSelector[]>]
 [-PolicyDefinitionReferenceId <String[]>] [-Metadata <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### UpdateById
```
Update-AzPolicyEnrollment -Id <String> [-Description <String>] [-DisplayName <String>]
 [-AssignmentScopeValidation <String>] [-ResourceSelector <IResourceSelector[]>]
 [-PolicyDefinitionReferenceId <String[]>] [-Metadata <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzPolicyEnrollment** cmdlet updates a policy enrollment with the newly provided properties.

Any properties not provided will be preserved from the existing enrollment.

## EXAMPLES

### Example 1: Update the display name
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$PolicyEnrollment = Get-AzPolicyEnrollment -Name 'PolicyEnrollment07' -Scope $ResourceGroup.ResourceId
Update-AzPolicyEnrollment -Id $PolicyEnrollment.Id -DisplayName 'Enrollment for VM location policy'
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet.
The command stores that object in the $ResourceGroup variable.
The second command gets the policy enrollment named PolicyEnrollment07 by using the Get-AzPolicyEnrollment cmdlet.
The command stores that object in the $PolicyEnrollment variable.
The final command updates the display name on the policy enrollment identified by the **Id** property of $PolicyEnrollment.

### Example 2: Update via pipeline
```powershell
$PolicyEnrollment = Get-AzPolicyEnrollment -Name 'PolicyEnrollment07' -Scope "/subscriptions/$((Get-AzContext).Subscription.Id)"
$PolicyEnrollment.DisplayName = 'Updated VM Enrollment'
$PolicyEnrollment | Update-AzPolicyEnrollment
```

The first command gets the policy enrollment named PolicyEnrollment07 by using the Get-AzPolicyEnrollment cmdlet and stores it in the $PolicyEnrollment variable.
The second command sets a new display name on the $PolicyEnrollment object.
The final command pipes the modified object to Update-AzPolicyEnrollment to persist the change.

### Example 3: Update the resource selector
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$ResourceSelector = @{Name = "MyLocationSelector"; Selector = @(@{Kind = "resourceLocation"; NotIn = @("eastus", "eastus2")})}
Update-AzPolicyEnrollment -Name 'VirtualMachinePolicyEnrollment' -Scope $ResourceGroup.ResourceId -ResourceSelector $ResourceSelector
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet.
The second command creates a resource selector object that limits the enrollment to resources in locations other than East US or East US 2 and stores it in the $ResourceSelector variable.
The final command updates the policy enrollment named VirtualMachinePolicyEnrollment with the resource selector specified by $ResourceSelector.

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
Accept pipeline input: True (ByPropertyName)
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
Accept pipeline input: True (ByPropertyName)
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
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Id
The ID of the policy enrollment to update.
Use the format '{scope}/providers/Microsoft.Authorization/policyEnrollments/{policyEnrollmentName}'.

```yaml
Type: System.String
Parameter Sets: UpdateById
Aliases: ResourceId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InputObject
The Policy Enrollment object to update.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollment
Parameter Sets: UpdateByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name of the policy enrollment.

```yaml
Type: System.String
Parameter Sets: UpdateByNameAndScope
Aliases: PolicyEnrollmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Accept pipeline input: True (ByPropertyName)
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
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Scope
The scope of the policy enrollment.
Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'), resource group (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}'), or resource (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/[{parentResourcePath}/]{resourceType}/{resourceName}')

```yaml
Type: System.String
Parameter Sets: UpdateByNameAndScope
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollment

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceSelector[]

### System.String

### System.String[]

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyEnrollment

## NOTES

## RELATED LINKS
