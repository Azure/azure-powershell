### Example 1: List properties of permission binding.
```powershell
Get-AzEventGridPermissionBinding -ResourceGroupName azps_test_group_eventgrid -NamespaceName azps-eventgridnamespace
```

```output
Name    ResourceGroupName
----    -----------------
azps-pb azps_test_group_eventgrid
```

List properties of permission binding.

### Example 2: Get properties of a permission binding.
```powershell
Get-AzEventGridPermissionBinding -ResourceGroupName azps_test_group_eventgrid -NamespaceName azps-eventgridnamespace -Name azps-pb
```

```output
Name    ResourceGroupName
----    -----------------
azps-pb azps_test_group_eventgrid
```

Get properties of a permission binding.

### Example 3: Get properties of a permission binding.
```powershell
$namespace = Get-AzEventGridNamespace -ResourceGroupName azps_test_group_eventgrid -Name azps-eventgridnamespace
Get-AzEventGridPermissionBinding -NamespaceInputObject $namespace -Name azps-pb
```

```output
Name    ResourceGroupName
----    -----------------
azps-pb azps_test_group_eventgrid
```

Get properties of a permission binding.