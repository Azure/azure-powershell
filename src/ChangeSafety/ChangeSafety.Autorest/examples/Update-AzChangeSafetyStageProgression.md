### Example 1: Complete a stage progression
```powershell
Update-AzChangeSafetyStageProgression -Name "canary-progression" `
    -ChangeRecordName "appDeploymentV2" `
    -ResourceGroupName "rg-changeops" `
    -Status "Completed" `
    -Comment "Canary deployment completed successfully, metrics look good"
```

```output
Name               ChangeRecordName StageReference Status    ProvisioningState
----               ---------------- -------------- ------    -----------------
canary-progression appDeploymentV2  canary         Completed Succeeded
```

Marks a stage progression as completed. This allows the next stage to be started.

### Example 2: Cancel a stage progression
```powershell
Update-AzChangeSafetyStageProgression -Name "prod-progression" `
    -ChangeRecordName "appDeploymentV2" `
    -ResourceGroupName "rg-changeops" `
    -Status "Cancelled" `
    -Comment "Cancelling due to critical bug found in canary"
```

```output
Name             ChangeRecordName StageReference Status    ProvisioningState
----             ---------------- -------------- ------    -----------------
prod-progression appDeploymentV2  production     Cancelled Succeeded
```

Cancels a stage progression. Use this when you need to abort a deployment.

