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
        subscriptionId = (Get-AzContext).Subscription.Id
        resourceGroups = @("rg-prod-eastus", "rg-prod-westus")
    }
```

```output
Name                  ResourceGroupName ChangeType  RolloutType Status      ProvisioningState
----                  ----------------- ----------  ----------- ------      -----------------
storageAccountCleanup rg-changeops      ManualTouch Hotfix      Initialized Succeeded
```

Updates the ChangeRecord with new target scope including specific resource groups.

