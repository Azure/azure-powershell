### Example 1: Start a compliance scan at subscription scope
```powershell
Start-AzPolicyComplianceScan
```

This command starts a policy compliance evaluation for the active subscription.

### Example 2: Start a compliance scan at resource group scope
```powershell
Start-AzPolicyComplianceScan -ResourceGroupName "myRG"
```

This command starts a policy compliance evaluation for the "myRG" resource group in the active subscription.

### Example 3: Start a compliance scan and wait for it to complete in the background
```powershell
$job = Start-AzPolicyComplianceScan -AsJob
$job | Wait-Job
```

This command starts a policy compliance evaluation for the active subscription as a job, then it waits for the scan to complete.