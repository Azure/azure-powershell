### Example 1: Gets a list of egress endpoints (network endpoints of all outbound dependencies) in the specified dedicated hsm resource.
```powershell
Get-AzDedicatedHsmOutboundNetworkDependencyEndpoint -Name dedicatedHsmName01 -ResourceGroupName resourceGroup
```

This command gets a list of egress endpoints (network endpoints of all outbound dependencies) in the specified dedicated hsm resource.
The operation returns properties of each egress endpoint.
