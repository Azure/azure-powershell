### Example 1: Get a specific StageProgression by name
```powershell
Get-AzChangeSafetyStageProgression -Name "canary-progression" `
    -ChangeRecordName "appDeploymentV2" `
    -ResourceGroupName "rg-changeops"
```

```output
Name               ChangeRecordName StageReference Status     Sequence ProvisioningState
----               ---------------- -------------- ------     -------- -----------------
canary-progression appDeploymentV2  canary         InProgress 1        Succeeded
```

Retrieves a specific StageProgression by its name.

### Example 2: List all StageProgressions for a ChangeRecord
```powershell
Get-AzChangeSafetyStageProgression -ChangeRecordName "appDeploymentV2" -ResourceGroupName "rg-changeops"
```

```output
Name               ChangeRecordName StageReference Status     Sequence ProvisioningState
----               ---------------- -------------- ------     -------- -----------------
canary-progression appDeploymentV2  canary         Completed  1        Succeeded
prod-progression   appDeploymentV2  production     InProgress 2        Succeeded
```

Lists all StageProgressions associated with a ChangeRecord, showing the progression through stages.

