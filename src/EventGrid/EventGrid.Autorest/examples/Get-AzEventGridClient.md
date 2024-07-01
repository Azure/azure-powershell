### Example 1: List properties of client.
```powershell
Get-AzEventGridClient -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid
```

```output
Name        ResourceGroupName
----        -----------------
azps-client azps_test_group_eventgrid
```

List properties of client.

### Example 2: Get properties of a client.
```powershell
Get-AzEventGridClient -Name azps-client -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid
```

```output
Name        ResourceGroupName
----        -----------------
azps-client azps_test_group_eventgrid
```

Get properties of a client.

### Example 3: Get properties of a client.
```powershell
$namespace = Get-AzEventGridNamespace -ResourceGroupName azps_test_group_eventgrid -Name azps-eventgridnamespace
Get-AzEventGridClient -Name azps-client -NamespaceInputObject $namespace
```

```output
Name        ResourceGroupName
----        -----------------
azps-client azps_test_group_eventgrid
```

Get properties of a client.