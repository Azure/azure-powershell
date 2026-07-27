### Example 1: Delete a StageMap by name
```powershell
Remove-AzChangeSafetyStageMap -Name "prod-deployment-stages" -ResourceGroupName "rg-changeops"
```

Deletes the specified StageMap. Note: StageMaps cannot be deleted if they are referenced by active ChangeRecords.

### Example 2: Delete a StageMap with confirmation prompt suppressed
```powershell
Remove-AzChangeSafetyStageMap -Name "prod-deployment-stages" -ResourceGroupName "rg-changeops" -Confirm:$false
```

Deletes the specified StageMap without prompting for confirmation.

