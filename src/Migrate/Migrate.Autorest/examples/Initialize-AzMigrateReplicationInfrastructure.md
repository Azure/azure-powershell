### Example 1: Initialises the infrastructure for the migrate project.
```powershell
Initialize-AzMigrateReplicationInfrastructure -ResourceGroupName TestRG -ProjectName TestProject -TargetRegion centralus
```

```output
True
```

Initialises the infrastructure for the migrate project.

### Example 2: Initialises the infrastructure for the migrate project for private endpoint scenario.
```powershell
Initialize-AzMigrateReplicationInfrastructure -ResourceGroupName "TestRG" -ProjectName "TestPEProject" -TargetRegion "centraluseuap" -Scenario "agentlessVMware" -CacheStorageAccountId "/subscriptions/b364ed8d-4279-4bf8-8fd1-56f8fa0ae05c/resourceGroups/singhabh-rg/providers/Microsoft.Storage/storageAccounts/singhabhstoragepe1"
```

```output
True
```

Initialises the infrastructure for the migrate project for private endpoint scenario.
