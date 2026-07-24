### Example 1: Update BFD Administrative State of Network to Network Interconnect
```powershell
$administrativeState = "Enable"
Invoke-AzNetworkFabricNniBfdAdministrativeState -NetworkFabricName $networkFabricName -NetworkToNetworkInterconnectName $nniName -ResourceGroupName $resourceGroupName -AdministrativeState $administrativeState
```

This command enables or disables the BFD administrative state of the given Network to Network Interconnect.
