### Example 1: Update static route BFD administrative state for Internal Network
```powershell
$state = "Enable"
Update-AzNetworkFabricInternalNetworkStaticRouteBfdAdministrativeState -InternalNetworkName $internalNetworkName -L3IsolationDomainName $l3IsolationDomainName -ResourceGroupName $resourceGroupName -State $state
```

This command enables or disables the static route BFD administrative state for the given Internal Network.
