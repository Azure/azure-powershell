### Example 1: Update Administrative State of External Network
```powershell
$state = "Enable"
Invoke-AzNetworkFabricExternalNetworkAdministrativeState -ExternalNetworkName $externalNetworkName -L3IsolationDomainName $l3IsolationDomainName -ResourceGroupName $resourceGroupName -State $state
```

This command enables or disables the administrative state of the given External Network.
