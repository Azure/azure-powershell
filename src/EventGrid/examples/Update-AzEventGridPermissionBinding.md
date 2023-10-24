### Example 1: Create a permission binding with the specified parameters.
```powershell
Update-AzEventGridPermissionBinding -ResourceGroupName azps_test_group_eventgrid -NamespaceName azps-eventgridnamespace -Name azps-pb -ClientGroupName "azps-clientgroup" -Permission Publisher -TopicSpaceName "azps-topicspace"
```

```output
Name    ResourceGroupName
----    -----------------
azps-pb azps_test_group_eventgrid
```

Create a permission binding with the specified parameters.

### Example 2: Create a permission binding with the specified parameters.
```powershell
$namespace = Get-AzEventGridNamespace -ResourceGroupName azps_test_group_eventgrid -Name azps-eventgridnamespace
Update-AzEventGridPermissionBinding -NamespaceInputObject $namespace -Name azps-pb -ClientGroupName "azps-clientgroup" -Permission Publisher -TopicSpaceName "azps-topicspace"
```

```output
Name    ResourceGroupName
----    -----------------
azps-pb azps_test_group_eventgrid
```

Create a permission binding with the specified parameters.

### Example 3: Create a permission binding with the specified parameters.
```powershell
$permissionbinding = Get-AzEventGridPermissionBinding -ResourceGroupName azps_test_group_eventgrid -NamespaceName azps-eventgridnamespace -Name azps-pb
Update-AzEventGridPermissionBinding -InputObject $permissionbinding -ClientGroupName "azps-clientgroup" -Permission Publisher -TopicSpaceName "azps-topicspace"
```

```output
Name    ResourceGroupName
----    -----------------
azps-pb azps_test_group_eventgrid
```

Create a permission binding with the specified parameters.