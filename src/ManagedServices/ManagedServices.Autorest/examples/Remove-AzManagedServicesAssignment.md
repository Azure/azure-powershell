### Example 1: Removes Azure Lighthouse registration assignment at subscription scope
```powershell
Remove-AzManagedServicesAssignment -Name "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -Scope "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
```

Removes Azure Lighthouse registration assignment at subscription scope.

### Example 2: Removes Azure Lighthouse registration assignment at resource group scope
```powershell
Remove-AzManagedServicesAssignment -Name "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -Scope "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/testgroup"
```

Removes Azure Lighthouse registration assignment at resource group scope.