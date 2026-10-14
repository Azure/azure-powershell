### Example 1: Delete a policy remediation at resource group scope
```powershell
Remove-AzPolicyRemediation -ResourceGroupName "myRG" -Name "remediation1"
```

This command deletes the remediation named 'remediation1' in resource group 'myRG'.

### Example 2: Delete a management group remediation via piping
```powershell
$remediation = Get-AzPolicyRemediation -ManagementGroupId "mg1" -Name "remediation1"
$remediation | Remove-AzPolicyRemediation -Confirm
```

This command deletes the remediation named 'remediation1' from management group 'mg1'. A confirmation prompt will be presented before deleting the resource.

### Example 3: Cancel and delete a policy remediation
```powershell
Remove-AzPolicyRemediation -ResourceGroupName "myRG" -Name "remediation1" -AllowStop
```

This command deletes the remediation named 'remediation1' in resource group 'myRG'. If the remediation is in-progress it will be canceled before being deleted.

