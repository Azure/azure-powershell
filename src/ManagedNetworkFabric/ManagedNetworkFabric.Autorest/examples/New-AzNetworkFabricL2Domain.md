### Example 1: Create the L2 Isolation Domain Resource
```powershell
$nfId="/subscriptions/1234ABCD-0A1B-1234-5678-123456ABCDEF/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/networkFabrics/fabricName"

New-AzNetworkFabricL2Domain -Name $name -ResourceGroupName $resourceGroupName -Location $location -NetworkFabricId $nfId -VlanId 501 -Mtu 1500
```

```output
AdministrativeState Annotation ConfigurationState Id
------------------- ---------- ------------------ --
Disabled                                          /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg0921…
```

This command creates the L2 Isolation Domain resource.
