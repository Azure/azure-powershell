### Example 1: Start a remediation at subscription scope
```powershell
$policyAssignmentId = "/subscriptions/f0710c27-9663-4c05-19f8-1b4be01e86a5/providers/Microsoft.Authorization/policyAssignments/2deae24764b447c29af7c309"
Start-AzPolicyRemediation -PolicyAssignmentId $policyAssignmentId -Name "remediation1" -NoWait
```

This command creates a new policy remediation in the current context's subscription for the provided policy assignment. The cmdlet will return immediately after the remediation is created without waiting for the remediation to complete.

### Example 2: Start a remediation at management group scope with optional filters
```powershell
$policyAssignmentId = "/providers/Microsoft.Management/managementGroups/mg1/providers/Microsoft.Authorization/policyAssignments/pa1"
Start-AzPolicyRemediation -ManagementGroupId "mg1" -PolicyAssignmentId $policyAssignmentId -Name "remediation1" -FilterLocation "westus","eastus"
```

This command creates a new policy remediation in management group 'mg1' for the given policy assignment. Only resources in the 'westus' or 'eastus' locations will be remediated.

### Example 3: Start a remediation at resource group scope for a policy set definition assignment
```powershell
$policyAssignmentId = "/subscriptions/f0710c27-9663-4c05-19f8-1b4be01e86a5/resourceGroups/myRG/providers/Microsoft.Authorization/policyAssignments/2deae24764b447c29af7c309"
Start-AzPolicyRemediation -ResourceGroupName "myRG" -PolicyAssignmentId $policyAssignmentId -PolicyDefinitionReferenceId "0349234412441" -Name "remediation1"
```

This command creates a new policy remediation in resource group 'myRG' for the given policy assignment. The policy assignment assigns a policy set definition (also known as an initiative). The policy definition reference ID indicates which policy within the initiative should be remediated.

### Example 4: Start a remediation and wait for it to complete in the background
```powershell
$policyAssignmentId = "/subscriptions/f0710c27-9663-4c05-19f8-1b4be01e86a5/providers/Microsoft.Authorization/policyAssignments/2deae24764b447c29af7c309"
$job = Start-AzPolicyRemediation -PolicyAssignmentId $policyAssignmentId -Name "remediation1" -AsJob
$job | Wait-Job
$remediation = $job | Receive-Job
```

This command starts a new policy remediation in the current context's subscription with the provided policy assignment. It will wait for the remediation to complete before returning the final remediation status.

### Example 5: Start a remediation that will discover non-compliant resources before remediating
```powershell
$policyAssignmentId = "/subscriptions/f0710c27-9663-4c05-19f8-1b4be01e86a5/providers/Microsoft.Authorization/policyAssignments/2deae24764b447c29af7c309"
Start-AzPolicyRemediation -PolicyAssignmentId $policyAssignmentId -Name "remediation1" -ResourceDiscoveryMode ReEvaluateCompliance
```

This command creates a new policy remediation in  the current context's subscription with the provided policy assignment. The compliance state of resources in the subscription will be re-evaluated against the policy assignment and non-compliant resources will be remediated.

### Example 6: Start a remediation that will remediate up to 10,000 non-compliant resources
```powershell
$policyAssignmentId = "/subscriptions/f0710c27-9663-4c05-19f8-1b4be01e86a5/providers/Microsoft.Authorization/policyAssignments/2deae24764b447c29af7c309"
Start-AzPolicyRemediation -PolicyAssignmentId $policyAssignmentId -Name "remediation1" -ResourceCount 10000
```

### Example 7: Start a remediation that will remediate 30 resources in parallel
```powershell
$policyAssignmentId = "/subscriptions/f0710c27-9663-4c05-19f8-1b4be01e86a5/providers/Microsoft.Authorization/policyAssignments/2deae24764b447c29af7c309"
Start-AzPolicyRemediation -PolicyAssignmentId $policyAssignmentId -Name "remediation1" -ParallelDeploymentCount 30
```

### Example 8: Start a remediation that will terminate if more than half of the remediation deployments fail
```powershell
$policyAssignmentId = "/subscriptions/f0710c27-9663-4c05-19f8-1b4be01e86a5/providers/Microsoft.Authorization/policyAssignments/2deae24764b447c29af7c309"
Start-AzPolicyRemediation -PolicyAssignmentId $policyAssignmentId -Name "remediation1" -FailureThreshold 0.5
```

