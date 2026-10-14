### Example 1: Cancel a policy remediation at resource group scope
```powershell
Stop-AzPolicyRemediation -ResourceGroupName "myRG" -Name "remediation1"
```

This command cancels the remediation named 'remediation1' in resource group 'myRG'.

### Example 2: Cancel a management group remediation via piping
```powershell
$remediation = Get-AzPolicyRemediation -ManagementGroupName "mg1" -Name "remediation1"
$remediation | Stop-AzPolicyRemediation
```

This command cancels the remediation named 'remediation1' in management group 'mg1'.
