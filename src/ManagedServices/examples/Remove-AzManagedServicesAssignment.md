### Example 1: Removes Azure Lighthouse registration assignment at subscription scope.
```powershell
PS C:\> Remove-AzManagedServicesAssignment -Name 13e437f5-393d-4041-840f-25b26b7a1efc -Scope "/subscriptions/24ab6047-da91-48c0-88e5-20a8c6daafc8"

PS C:\>
```

Removes Azure Lighthouse registration assignment at subscription scope.

### Example 2: Removes Azure Lighthouse registration assignment at resource group scope.
```powershell
PS C:\> Remove-AzManagedServicesAssignment -Name ca63aca5-31a4-4120-88a1-526088173628 -Scope "/subscriptions/24ab6047-da91-48c0-88e5-20a8c6daafc8/resourceGroups/testgroup"

PS C:\>
```

Removes Azure Lighthouse registration assignment at resource group scope.