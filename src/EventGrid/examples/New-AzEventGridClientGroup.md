### Example 1: Create a client group with the specified parameters.
```powershell
New-AzEventGridClientGroup -Name azps-clientgroup -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -Query "attributes.b IN ['a', 'b', 'c']"
```

```output
Name             ResourceGroupName
----             -----------------
azps-clientgroup azps_test_group_eventgrid
```

Create a client group with the specified parameters.