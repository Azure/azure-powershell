---
external help file:
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/new-azpolicyexemption
schema: 2.0.0
---

# New-AzPolicyExemption

## SYNOPSIS
Creates or updates a policy exemption.

## SYNTAX

```
New-AzPolicyExemption [-Name] <String> [-ExemptionCategory] <ExemptionCategory> [-PolicyAssignment] <PSObject>
 [[-Scope] <String>] [[-AssignmentScopeValidation] <AssignmentScopeValidation>] [[-DisplayName] <String>]
 [[-Description] <String>] [[-PolicyDefinitionReferenceId] <String[]>] [[-ExpiresOn] <DateTime?>]
 [[-Metadata] <String>] [[-DefaultProfile] <PSObject>] [-BackwardCompatible] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzPolicyExemption** cmdlet creates a policy exemption with the given scope and name.

## EXAMPLES

### Example 1: Policy exemption at subscription level
```powershell
$Subscription = Get-AzSubscription -SubscriptionName 'Subscription01'
$Assignment = Get-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment'
New-AzPolicyExemption -Name 'VirtualMachinePolicyExemption' -PolicyAssignment $Assignment -Scope "/subscriptions/$($Subscription.Id)" -ExemptionCategory Waiver
```

The first command gets a subscription named Subscription01 by using the Get-AzSubscription cmdlet and stores it in the $Subscription variable.
The second command gets the policy assignment named VirtualMachinePolicyAssignment by using the Get-AzPolicyAssignment cmdlet and stores it in the $Assignment variable.
The final command exempts the policy assignment in $Assignment at the level of the subscription identified by the subscription scope string.

### Example 2: Policy exemption at resource group level
```powershell
$ResourceGroup = Get-AzResourceGroup -Name 'ResourceGroup11'
$Assignment = Get-AzPolicyAssignment -Name 'VirtualMachinePolicyAssignment'
New-AzPolicyExemption -Name 'VirtualMachinePolicyAssignment' -PolicyAssignment $Assignment -Scope $ResourceGroup.ResourceId -ExemptionCategory Mitigated
```

The first command gets a resource group named ResourceGroup11 by using the Get-AzResourceGroup cmdlet and stores it in the $ResourceGroup variable.
The second command gets the policy assignment named VirtualMachinePolicyAssignment by using the Get-AzPolicyAssignment cmdlet and stores it in the $Assignment variable.
The final command exempts the policy assignment in $Assignment at the level of the resource group identified by the **ResourceId** property of $ResourceGroup.

## PARAMETERS

### -AssignmentScopeValidation
Whether to validate the exemption is at or under the assignment scope.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Support.AssignmentScopeValidation
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -BackwardCompatible
Causes cmdlet to return artifacts using legacy format placing policy-specific properties in a property bag object.

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

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: 10
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
This message will be part of response in case of policy violation.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DisplayName
The display name of the policy assignment.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ExemptionCategory
The policy exemption category

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Policy.Support.ExemptionCategory
Parameter Sets: (All)
Aliases:

Required: True
Position: 5
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ExpiresOn
The expiration date and time (in UTC ISO 8601 format yyyy-MM-ddTHH:mm:ssZ) of the policy exemption.

```yaml
Type: System.Nullable`1[[System.DateTime, System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: 8
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Metadata
The policy assignment metadata.
Metadata is an open ended object and is typically a collection of key value pairs.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 9
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name of the policy exemption.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: PolicyExemptionName

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PolicyAssignment
The policy assignment id filter.
To construct, see NOTES section for POLICYASSIGNMENT properties and create a hash table.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases:

Required: True
Position: 6
Default value: None
Accept pipeline input: True (ByValue, ByPropertyName)
Accept wildcard characters: False
```

### -PolicyDefinitionReferenceId
The policy definition reference ID list when the associated policy assignment is for a policy set (initiative).

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: 7
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Scope
The scope of the policy exemption.
Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'), resource group (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}', or resource (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/[{parentResourcePath}/]{resourceType}/{resourceName}'

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Support.AssignmentScopeValidation

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Support.ExemptionCategory

### System.Management.Automation.PSObject

### System.Nullable`1[[System.DateTime, System.Private.CoreLib, Version=7.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

### System.String

### System.String[]

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.Api20220701Preview.IPolicyExemption

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`POLICYASSIGNMENT <PSObject>`: The policy assignment id filter.
  - `[Description <String>]`: This message will be part of response in case of policy violation.
  - `[DisplayName <String>]`: The display name of the policy assignment.
  - `[EnforcementMode <EnforcementMode?>]`: The policy assignment enforcement mode. Possible values are Default and DoNotEnforce.
  - `[IdentityType <ResourceIdentityType?>]`: The identity type. This is the only required field when adding a system or user assigned identity to a resource.
  - `[IdentityUserAssignedIdentity <IIdentityUserAssignedIdentities>]`: The user identity associated with the policy. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
    - `[(Any) <IUserAssignedIdentitiesValue>]`: This indicates any property can be added to this object.
  - `[Location <String>]`: The location of the policy assignment. Only required when utilizing managed identity.
  - `[Metadata <IPolicyAssignmentPropertiesMetadata>]`: The policy assignment metadata. Metadata is an open ended object and is typically a collection of key value pairs.
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[NonComplianceMessage <INonComplianceMessage[]>]`: The messages that describe why a resource is non-compliant with the policy.
    - `Message <String>`: A message that describes why a resource is non-compliant with the policy. This is shown in 'deny' error messages and on resource's non-compliant compliance results.
    - `[PolicyDefinitionReferenceId <String>]`: The policy definition reference ID within a policy set definition the message is intended for. This is only applicable if the policy assignment assigns a policy set definition. If this is not provided the message applies to all policies assigned by this policy assignment.
  - `[NotScope <String[]>]`: The policy's excluded scopes.
  - `[Parameter <IParameterValues>]`: The parameter values for the assigned policy rule. The keys are the parameter names.
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[PolicyDefinitionId <String>]`: The ID of the policy definition or policy set definition being assigned.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.

## RELATED LINKS

