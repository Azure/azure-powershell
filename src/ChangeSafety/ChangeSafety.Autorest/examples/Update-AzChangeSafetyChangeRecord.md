### Example 1: Update a ChangeRecord description
```powershell
Update-AzChangeSafetyChangeRecord -Name "storageAccountCleanup" `
    -ResourceGroupName "rg-changeops" `
    -Description "Updated: Delete unused storage account for Q4 cleanup" `
    -Comment "Updated description for clarity"
```

```output
Name                  ResourceGroupName ChangeType  RolloutType Status      ProvisioningState
----                  ----------------- ----------  ----------- ------      -----------------
storageAccountCleanup rg-changeops      ManualTouch Hotfix      Initialized Succeeded
```

Updates the description and adds a comment to an existing ChangeRecord.

### Example 2: Update a ChangeRecord with new Targets
```powershell
Update-AzChangeSafetyChangeRecord -Name "storageAccountCleanup" `
    -ResourceGroupName "rg-changeops" `
    -Targets @{
        resourceId = "/subscriptions/$((Get-AzContext).Subscription.Id)/resourceGroups/rg-prod/providers/Microsoft.Storage/storageAccounts/storageAccountCleanup"
        httpMethod = "DELETE"
    }
```

```output
Name                  ResourceGroupName ChangeType  RolloutType Status      ProvisioningState
----                  ----------------- ----------  ----------- ------      -----------------
storageAccountCleanup rg-changeops      ManualTouch Hotfix      Initialized Succeeded
```

Updates the ChangeRecord with a resource-scoped target and guarded operation.
