### Example 1: Get Usage of an azure container registry.
```powershell
Get-AzContainerRegistryUsage -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample"
```

```output
CurrentValue Limit        Name                       Unit
------------ -----        ----                       ----
0            536870912000 Size                       Bytes
0            500          Webhooks                   Count
2            -1           Geo-replications           Count
0            100          IPRules                    Count
0            100          VNetRules                  Count
0            200          PrivateEndpointConnections Count
0            50000        ScopeMaps                  Count
0            50000        Tokens                     Count
```

Get Usage of an azure container registry.

