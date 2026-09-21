### Example 1: Get a specific StageMap by name
```powershell
Get-AzChangeSafetyStageMap -Name "prod-deployment-stages" -ResourceGroupName "rg-changeops"
```

```output
Name                   ResourceGroupName ProvisioningState
----                   ----------------- -----------------
prod-deployment-stages rg-changeops      Succeeded
```

Retrieves a specific StageMap by its name from the specified resource group.

### Example 2: List all StageMaps in a resource group
```powershell
Get-AzChangeSafetyStageMap -ResourceGroupName "rg-changeops"
```

```output
Name                   ResourceGroupName ProvisioningState
----                   ----------------- -----------------
prod-deployment-stages rg-changeops      Succeeded
regional-rollout       rg-changeops      Succeeded
```

Lists all StageMaps in the specified resource group.

### Example 3: List all StageMaps in the current subscription
```powershell
Get-AzChangeSafetyStageMap
```

Lists all StageMaps across all resource groups in the current subscription.

