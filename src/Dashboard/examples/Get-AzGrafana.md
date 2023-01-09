### Example 1: List the specific workspace.
```powershell
Get-AzGrafana
```

```output
Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azpstest-grafana      azpstest-gp
```

List the specific workspace.

### Example 2: Get the properties of a specific workspace for Resource Group.
```powershell
Get-AzGrafana -ResourceGroupName azpstest-gp
```

```output
Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azpstest-grafana      azpstest-gp
```

Get the properties of a specific workspace for Resource Group.

### Example 3: Get the properties of a specific workspace for Grafana resource.
```powershell
Get-AzGrafana -ResourceGroupName azpstest-gp -GrafanaName azpstest-grafana
```

```output
Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azpstest-grafana      azpstest-gp
```

Get the properties of a specific workspace for Grafana resource.