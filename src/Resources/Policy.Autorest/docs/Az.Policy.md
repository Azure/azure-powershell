---
Module Name: Az.Policy
Module Guid: 54d436a4-6f2e-4977-b339-2b40665fd8c4
Download Help Link: https://learn.microsoft.com/powershell/module/az.policy
Help Version: 1.0.0.0
Locale: en-US
---

# Az.Policy Module
## Description
Microsoft Azure PowerShell: Policy cmdlets

## Az.Policy Cmdlets
### [Get-AzPolicyAssignment](Get-AzPolicyAssignment.md)
This operation retrieves a single policy assignment, given its name and the scope it was created at.

### [Get-AzPolicyDefinition](Get-AzPolicyDefinition.md)
This operation retrieves the policy definition in the given subscription with the given name.

### [Get-AzPolicyExemption](Get-AzPolicyExemption.md)
This operation retrieves a single policy exemption, given its name and the scope it was created at.

### [Get-AzPolicySetDefinition](Get-AzPolicySetDefinition.md)
This operation retrieves the policy set definition in the given subscription with the given name.

### [New-AzPolicyAssignment](New-AzPolicyAssignment.md)
This operation creates or updates a policy assignment with the given scope and name.
Policy assignments apply to all resources contained within their scope.
For example, when you assign a policy at resource group scope, that policy applies to all resources in the group.

### [New-AzPolicyDefinition](New-AzPolicyDefinition.md)
This operation creates or updates a policy definition in the given subscription with the given name.

### [New-AzPolicyExemption](New-AzPolicyExemption.md)
This operation creates or updates a policy exemption with the given scope and name.
Policy exemptions apply to all resources contained within their scope.
For example, when you create a policy exemption at resource group scope for a policy assignment at the same or above level, the exemption exempts to all applicable resources in the resource group.

### [New-AzPolicySetDefinition](New-AzPolicySetDefinition.md)
This operation creates or updates a policy set definition in the given subscription with the given name.

### [Remove-AzPolicyAssignment](Remove-AzPolicyAssignment.md)
This operation deletes a policy assignment, given its name and the scope it was created in.
The scope of a policy assignment is the part of its ID preceding '/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}'.

### [Remove-AzPolicyDefinition](Remove-AzPolicyDefinition.md)
This operation deletes the policy definition in the given subscription with the given name.

### [Remove-AzPolicyExemption](Remove-AzPolicyExemption.md)
This operation deletes a policy exemption, given its name and the scope it was created in.
The scope of a policy exemption is the part of its ID preceding '/providers/Microsoft.Authorization/policyExemptions/{policyExemptionName}'.

### [Remove-AzPolicySetDefinition](Remove-AzPolicySetDefinition.md)
This operation deletes the policy set definition in the given subscription with the given name.

### [Update-AzPolicyAssignment](Update-AzPolicyAssignment.md)
This operation updates a policy assignment with the given scope and name.
Policy assignments apply to all resources contained within their scope.
For example, when you assign a policy at resource group scope, that policy applies to all resources in the group.

### [Update-AzPolicyDefinition](Update-AzPolicyDefinition.md)
This operation updates an existing policy definition in the given subscription or management group with the given name.

### [Update-AzPolicyExemption](Update-AzPolicyExemption.md)
This operation updates a policy exemption with the given scope and name.

