### Example 1: Delete a workspace for Grafana resource.
```powershell
Remove-AzGrafana -GrafanaName azpstest-grafana -ResourceGroupName azpstest-gp
```

Delete a workspace for Grafana resource.

### Example 2: Delete a workspace for Grafana resource.
```powershell
Get-AzGrafana -ResourceGroupName azpstest-gp -GrafanaName azpstest-grafana | Remove-AzGrafana
```

Delete a workspace for Grafana resource.