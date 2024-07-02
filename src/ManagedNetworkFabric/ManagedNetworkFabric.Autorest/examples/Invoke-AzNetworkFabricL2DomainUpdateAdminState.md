### Example 1: Enables isolation domain across the fabric or on specified racks.
```powershell
$state="Enable"
Invoke-AzNetworkFabricL2DomainUpdateAdminState -L2IsolationDomainName $name -ResourceGroupName $resourceGroupName -State $state
```

This command enables isolation domain across the fabric or on specified racks.


