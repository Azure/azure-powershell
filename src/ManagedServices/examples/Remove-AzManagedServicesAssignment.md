### Example 1: Removes Azure Lighthouse registration assignment at subscription scope
```powershell
<<<<<<< HEAD
Remove-AzManagedServicesAssignment -Name "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -Scope "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
=======
PS C:\> Remove-AzManagedServicesAssignment -Name xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -Scope "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Removes Azure Lighthouse registration assignment at subscription scope.

### Example 2: Removes Azure Lighthouse registration assignment at resource group scope
```powershell
<<<<<<< HEAD
Remove-AzManagedServicesAssignment -Name "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -Scope "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/testgroup"
=======
PS C:\> Remove-AzManagedServicesAssignment -Name xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -Scope "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/testgroup"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

Removes Azure Lighthouse registration assignment at resource group scope.