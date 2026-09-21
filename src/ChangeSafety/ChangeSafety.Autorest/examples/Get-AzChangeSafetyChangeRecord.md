### Example 1: Get a specific ChangeRecord by name
```powershell
Get-AzChangeSafetyChangeRecord -Name "storageAccountCleanup" -ResourceGroupName "rg-changeops"
```

```output
Name                  ResourceGroupName ChangeType  RolloutType Status      ProvisioningState
----                  ----------------- ----------  ----------- ------      -----------------
storageAccountCleanup rg-changeops      ManualTouch Hotfix      Initialized Succeeded
```

Retrieves a specific ChangeRecord by its name from the specified resource group.

### Example 2: List all ChangeRecords in a resource group
```powershell
Get-AzChangeSafetyChangeRecord -ResourceGroupName "rg-changeops"
```

```output
Name                  ResourceGroupName ChangeType    RolloutType Status      ProvisioningState
----                  ----------------- ----------    ----------- ------      -----------------
storageAccountCleanup rg-changeops      ManualTouch   Hotfix      Initialized Succeeded
appDeploymentV2       rg-changeops      AppDeployment Normal      InProgress  Succeeded
```

Lists all ChangeRecords in the specified resource group.

### Example 3: List all ChangeRecords in the current subscription
```powershell
Get-AzChangeSafetyChangeRecord
```

Lists all ChangeRecords across all resource groups in the current subscription.

