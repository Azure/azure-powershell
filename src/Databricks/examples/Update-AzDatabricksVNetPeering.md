### Example 1: Update AllowForwardedTraffic of vnet peering
```powershell
Update-AzDatabricksVNetPeering -WorkspaceName databricks-test01 -ResourceGroupName lucas-manual-test -Name vnetpeering-t01 -AllowForwardedTraffic $True
```

```output
Name            Type
----            ----
vnetpeering-t01
```

This command updates AllowForwardedTraffic of vnet peering.

### Example 2: Update AllowForwardedTraffic of vnet peering by object
```powershell
Get-AzDatabricksVNetPeering -WorkspaceName databricks-test01 -ResourceGroupName lucas-manual-test -Name vnetpeering-t01 | Update-AzDatabricksVNetPeering -AllowGatewayTransit $true
```

```output
Name            Type
----            ----
vnetpeering-t01
```

This command updates AllowForwardedTraffic of vnet peering by object.