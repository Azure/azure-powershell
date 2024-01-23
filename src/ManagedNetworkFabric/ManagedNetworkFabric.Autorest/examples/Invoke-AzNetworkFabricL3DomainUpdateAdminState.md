### Example 1: Enables racks for this Isolation Domain
```powershell
$state="Enable"
Invoke-AzNetworkFabricL3DomainUpdateAdminState -L3IsolationDomainName $name -ResourceGroupName $resourceGroupName -State $state
```

This command enables racks for this Isolation Domain.

