### Example 1: List properties of namespace.
```powershell
Get-AzEventGridNamespace
```

```output
Location Name                    ResourceGroupName
-------- ----                    -----------------
eastus   azps-eventgridnamespace azps_test_group_eventgrid
```

List properties of namespace.

### Example 2: List properties of namespace.
```powershell
Get-AzEventGridNamespace -ResourceGroupName azps_test_group_eventgrid
```

```output
Location Name                    ResourceGroupName
-------- ----                    -----------------
eastus   azps-eventgridnamespace azps_test_group_eventgrid
```

List properties of namespace.

### Example 3: Get properties of a namespace.
```powershell
Get-AzEventGridNamespace -ResourceGroupName azps_test_group_eventgrid -Name azps-eventgridnamespace
```

```output
Location Name                    ResourceGroupName
-------- ----                    -----------------
eastus   azps-eventgridnamespace azps_test_group_eventgrid
```

Get properties of a namespace.