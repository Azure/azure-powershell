### Example 1: List Network to Network Interconnects
```powershell
Get-AzNetworkFabricNni -NetworkFabricName $nfName -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState ConfigurationState EgressAclId ExportRoutePolicy Id
------------------- ------------------ ----------- ----------------- --
Enabled             Succeeded                                        /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.…
```

This command lists all the Network to Network Interconnects.

### Example 2: Get Network to Network Interconnect
```powershell
Get-AzNetworkFabricNni -Name $name -NetworkFabricName $nfName -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState ConfigurationState EgressAclId ExportRoutePolicy Id
------------------- ------------------ ----------- ----------------- --
Enabled             Succeeded                                        /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.…
```

This command gets details of the given Network to Network Interconnect.

