### Example 1: Create a permission binding with the specified parameters.
```powershell
New-AzEventGridPermissionBinding -Name azps-pb -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -ClientGroupName "azps-clientgroup" -Permission Publisher -TopicSpaceName "azps-topicspace"
```

```output
Name    ResourceGroupName
----    -----------------
azps-pb azps_test_group_eventgrid
```

Create a permission binding with the specified parameters.