### Example 1: Update NPB static route BFD administrative state for NNI
```powershell
$state = "Enable"
Update-AzNetworkFabricNetworkToNetworkInterconnectNpbStaticRouteBfdAdministrativeState -NetworkFabricName $networkFabricName -NetworkToNetworkInterconnectName $nniName -ResourceGroupName $resourceGroupName -State $state
```

This command enables or disables the NPB static route BFD administrative state for the given Network to Network Interconnect.
