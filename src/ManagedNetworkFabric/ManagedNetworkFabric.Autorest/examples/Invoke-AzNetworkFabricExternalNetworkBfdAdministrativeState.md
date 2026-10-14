### Example 1: Update BFD Administrative State of External Network
```powershell
$administrativeState = "Enable"
Invoke-AzNetworkFabricExternalNetworkBfdAdministrativeState -ExternalNetworkName $externalNetworkName -L3IsolationDomainName $l3IsolationDomainName -ResourceGroupName $resourceGroupName -AdministrativeState $administrativeState
```

This command enables or disables the BFD administrative state of the given External Network.
