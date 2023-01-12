### Example 1: Update peering tags
```powershell
$tags=@{hello='world'}
Update-AzPeering -Name DemoPeering -ResourceGroupName DemoRG -Tag $tags
```

```output
Name        SkuName             Kind   PeeringLocation ProvisioningState Location
----        -------             ----   --------------- ----------------- --------
DemoPeering Premium_Direct_Free Direct Dallas          Succeeded         South Central US
```

Updates the specified peering's tags

