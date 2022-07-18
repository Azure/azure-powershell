### Example 1: Get all Storage movers in a subcription
```powershell
 Get-AzStorageMover
```

```output
Location    Name
--------    ----
eastus      myStorageMover1
eastus      myStorageMover2
```

This command gets all the Storage movers in a subscription.

### Example 2: Get all Storage movers in a resource group
```powershell
Get-AzStorageMover -ResourceGroupName myResourceGroup
```

```output
Location    Name
--------    ----
eastus		myStorageMover1
eastus      myStorageMover2
```

This command gets all the Storage movers in a resource group. 

### Example 2: Get a specific Storage mover
```powershell
Get-AzStorageMover -ResourceGroupName myResourceGroup -Name myStorageMover
```

```output
Location    Name
--------    ----
eastus		myStorageMover
```

This command gets a specific Storage mover.

