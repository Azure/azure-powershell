### Example 1: List properties of client group.
```powershell
Get-AzEventGridClientGroup -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid
```

```output
Name             ResourceGroupName
----             -----------------
$all             azps_test_group_eventgrid
azps-clientgroup azps_test_group_eventgrid
```

List properties of client group.

### Example 2: Get properties of a client group.
```powershell
Get-AzEventGridClientGroup -Name azps-clientgroup -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid
```

```output
Name             ResourceGroupName
----             -----------------
azps-clientgroup azps_test_group_eventgrid
```

Get properties of a client group.

### Example 3: Get properties of a client group.
```powershell
$namespace = Get-AzEventGridNamespace -ResourceGroupName azps_test_group_eventgrid -Name azps-eventgridnamespace
Get-AzEventGridClientGroup -Name azps-clientgroup -NamespaceInputObject $namespace
```

```output
Name             ResourceGroupName
----             -----------------
azps-clientgroup azps_test_group_eventgrid
```

Get properties of a client group.