### Example 1: Update static route BFD administrative state for External Network
```powershell
$state = "Enable"
Update-AzNetworkFabricExternalNetworkStaticRouteBfdAdministrativeState -ExternalNetworkName $externalNetworkName -L3IsolationDomainName $l3IsolationDomainName -ResourceGroupName $resourceGroupName -State $state
```

This command enables or disables the static route BFD administrative state for the given External Network.
