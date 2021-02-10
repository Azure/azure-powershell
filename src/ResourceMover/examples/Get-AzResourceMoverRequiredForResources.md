### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzResourceMoverRequiredForResources -MoveCollectionName PS-centralus-westcentralus-demoRMS -ResourceGroupName RG-MoveCollection-demoRMS -SourceId "/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups"

/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups/PSDemoRM/providers/Microsoft.Compute/virtualMachines/PSDemoVM
/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourcegroups/psdemorm/providers/microsoft.network/networkinterfaces/psdemovm111
/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourceGroups/psdemorm/providers/Microsoft.Network/virtualNetworks/psdemorm-vnet
/subscriptions/e80eb9fa-c996-4435-aa32-5af6f3d3077c/resourcegroups/psdemorm/providers/microsoft.network/networksecuritygroups/psdemovm-nsg
```

Get a list of required resources that needs to be added for the specified resource
