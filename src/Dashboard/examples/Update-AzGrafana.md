### Example 1: Update a workspace for Grafana resource.
```powershell
Update-AzGrafana -GrafanaName azpstest-grafana -ResourceGroupName azpstest-gp -ApiKey Enabled -DeterministicOutboundIP 'Enabled' -IdentityType 'SystemAssigned' -PublicNetworkAccess 'Enabled' -ZoneRedundancy 'Enabled' -Tag @{"Environment"="Dev"}
```

```output
Location Name             ResourceGroupName
-------- ----             -----------------
eastus   azpstest-grafana azpstest-gp
```

Update a workspace for Grafana resource.

### Example 2: Update a workspace for Grafana resource.
```powershell
Get-AzGrafana -ResourceGroupName azpstest-gp -GrafanaName azpstest-grafana | Update-AzGrafana -ApiKey Enabled -DeterministicOutboundIP 'Enabled' -IdentityType 'SystemAssigned' -PublicNetworkAccess 'Enabled' -ZoneRedundancy 'Enabled' -Tag @{"Environment"="Dev"}
```

```output
Location Name             ResourceGroupName
-------- ----             -----------------
eastus   azpstest-grafana azpstest-gp
```

Update a workspace for Grafana resource.