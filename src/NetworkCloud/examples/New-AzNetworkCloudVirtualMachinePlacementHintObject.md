### Example 1: Create an in-memory object for VirtualMachinePlacementHint.
```powershell
New-AzNetworkCloudVirtualMachinePlacementHintObject -HintType "Affinity" -ResourceId "/subscriptions/subscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.NetworkCloud/racks/rackName" -SchedulingExecution "Hard" -Scope "Machine"
```

Creates an in-memory object for VirtualMachinePlacementHint.
