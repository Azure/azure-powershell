### Example 1: List all connected machines in a subscription
```powershell
PS C:\> Get-AzConnectedMachine -SubscriptionId 67379433-5e19-4702-b39a-c0a03ca8d20c

Location Name           Type
-------- ----           ----
westus2  winwestus2_1   Microsoft.HybridCompute/machines
westus2  linwestus2_1   Microsoft.HybridCompute/machines

```

Lists all connected machines in a subscription.

### Example 2: List all connected machines in a resource group
```powershell
PS C:\> Get-AzConnectedMachine -ResourceGroupName contoso-connected-machines

Location Name           Type
-------- ----           ----
westus2  winwestus2_2   Microsoft.HybridCompute/machines
westus2  winwestus2_3   Microsoft.HybridCompute/machines
```

List all connected machines in a resource group.

### Example 3: Get a connected machine in a resource group by name
```powershell
PS C:\> Get-AzConnectedMachine -ResourceGroupName contoso-connected-machines -Name winwestus2_1

Location Name           Type
-------- ----           ----
westus2  winwestus2_1   Microsoft.HybridCompute/machines
```

Get a connected machine in a resource group by name.
