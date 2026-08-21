
### Example 1: Get all policy remediations in the current subscription
```powershell
Get-AzPolicyRemediation
```

This command gets all the remediations created at or underneath the subscription in the current context.

### Example 2: Get a specific policy remediation and the deployment details
```powershell
Get-AzPolicyRemediation -ResourceGroupName "myResourceGroup" -Name "remediation1" -IncludeDetail
```

This command gets the remediation named 'remediation1' from resource group 'myResourceGroup'. The details of the deployments created by the remediation will be included.

### Example 3: Get 10 policy remediations in a management group with optional filters
```powershell
Get-AzPolicyRemediation -ManagementGroupId "mg1" -Top 10 -Filter "PolicyAssignmentId eq '/providers/Microsoft.Management/managementGroups/mg1/providers/Microsoft.Authorization/policyAssignments/pa1'"
```

This command gets a max of 10 policy remediations from a management group named 'mg1'. Only policy remediations for the given policy assignment will be retrieved.

