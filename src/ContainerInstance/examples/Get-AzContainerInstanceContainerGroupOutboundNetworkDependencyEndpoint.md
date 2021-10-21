### Example 1: Get a list of the outbound network dependencies
```powershell
PS C:\> Get-AzContainerInstanceContainerGroupOutboundNetworkDependencyEndpoint -ResourceGroupName test-rg -ContainerGroupName test-cg

[]
```

This command returns a list of the outbound network dependencies for Container Instances. Container Instances does not have any outbound network dependencies, so this list will be empty.

### Example 2: Get a list of the outbound network dependencies (alias)
```powershell
PS C:\> Get-AzContainerGroupOutboundNetworkDependencyEndpoint -ResourceGroupName test-rg -ContainerGroupName test-cg

[]
```

This command returns a list of the outbound network dependencies for Container Instances. Container Instances does not have any outbound network dependencies, so this list will be empty.