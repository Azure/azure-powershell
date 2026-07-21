### Example 1: Delete a StageProgression by name
```powershell
Remove-AzChangeSafetyStageProgression -Name "canary-progression" `
    -ChangeRecordName "appDeploymentV2" `
    -ResourceGroupName "rg-changeops"
```

Deletes the specified StageProgression from a ChangeRecord.

### Example 2: Delete a StageProgression with confirmation prompt suppressed
```powershell
Remove-AzChangeSafetyStageProgression -Name "canary-progression" `
    -ChangeRecordName "appDeploymentV2" `
    -ResourceGroupName "rg-changeops" `
    -Confirm:$false
```

Deletes the specified StageProgression without prompting for confirmation.

