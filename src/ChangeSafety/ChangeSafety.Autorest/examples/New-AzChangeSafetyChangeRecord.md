### Example 1: Create a stageless ChangeRecord with Targets (simple flow)
```powershell
New-AzChangeSafetyChangeRecord -Name "storageAccountCleanup" `
    -ResourceGroupName "rg-changeops" `
    -ChangeType "ManualTouch" `
    -RolloutType "Hotfix" `
    -Description "Delete unused storage account for cleanup" `
    -Targets @{
        subscriptionId = (Get-AzContext).Subscription.Id
    }
```

```output
Name                  ResourceGroupName ChangeType  RolloutType Status      ProvisioningState
----                  ----------------- ----------  ----------- ------      -----------------
storageAccountCleanup rg-changeops      ManualTouch Hotfix      Initialized Succeeded
```

Creates a simple stageless ChangeRecord targeting the current subscription. This is used for guarded operations where you want policy protection without staged rollouts.

### Example 2: Create a ChangeRecord with StageMap for staged rollouts
```powershell
New-AzChangeSafetyChangeRecord -Name "appDeploymentV2" `
    -ResourceGroupName "rg-changeops" `
    -ChangeType "AppDeployment" `
    -RolloutType "Normal" `
    -Description "Deploy microservices application v2.1.0 to production" `
    -StageMapResourceId "/subscriptions/$((Get-AzContext).Subscription.Id)/resourceGroups/rg-changeops/providers/Microsoft.ChangeSafety/stageMaps/prod-deployment-stages" `
    -AnticipatedStartTime (Get-Date).AddHours(1) `
    -AnticipatedEndTime (Get-Date).AddHours(4) `
    -ReleaseLabel "v2.1.0-prod"
```

```output
Name             ResourceGroupName ChangeType    RolloutType Status      ProvisioningState
----             ----------------- ----------    ----------- ------      -----------------
appDeploymentV2  rg-changeops      AppDeployment Normal      Initialized Succeeded
```

Creates a ChangeRecord with a StageMap reference for staged rollouts. Use this when you need to progress through multiple stages (e.g., canary, production).

### Example 3: Create a ChangeRecord with ApiOperations change definition
```powershell
$changeDefinitionDetail = @{
    operations = @(
        @{
            httpMethod = "DELETE"
            uri = "https://management.azure.com/subscriptions/$((Get-AzContext).Subscription.Id)/resourceGroups/rg-test/providers/Microsoft.Storage/storageAccounts/teststorageaccount?api-version=2023-01-01"
        }
    )
}

New-AzChangeSafetyChangeRecord -Name "storageDelete" `
    -ResourceGroupName "rg-changeops" `
    -ChangeType "ManualTouch" `
    -RolloutType "Normal" `
    -ChangeDefinitionKind "ApiOperations" `
    -ChangeDefinitionName "Delete storage account" `
    -ChangeDefinitionDetail $changeDefinitionDetail
```

```output
Name          ResourceGroupName ChangeType  RolloutType Status      ProvisioningState
----          ----------------- ----------  ----------- ------      -----------------
storageDelete rg-changeops      ManualTouch Normal      Initialized Succeeded
```

Creates a ChangeRecord with explicit API operations defined. The policy will validate that the actual operation matches the declared operations.

