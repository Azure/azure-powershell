### Example 1: Get all agents in a Storage mover
```powershell
Get-AzStorageMoverAgent -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover
```

```output
Name
----
myAgent
```

This command gets all the agents under a Storage mover

### Example 2: Get a specific agent
```powershell
Get-AzStorageMoverAgent -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -Name myAgent
```	

```output
Name
----
myAgent
```

This command gets a specific agent.

