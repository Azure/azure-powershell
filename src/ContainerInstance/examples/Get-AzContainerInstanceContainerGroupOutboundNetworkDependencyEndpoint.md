### Example 1: Get a list of the outbound network dependencies
```powershell
Get-AzContainerInstanceContainerGroupOutboundNetworkDependencyEndpoint -ResourceGroupName test-rg -ContainerGroupName test-cg
```

```output
[]
```

This command returns a list of the outbound network dependencies for Container Instances. Container Instances does not have any outbound network dependencies, so this list will be empty.
