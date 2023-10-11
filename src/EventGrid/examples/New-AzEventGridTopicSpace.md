### Example 1: Create a topic space with the specified parameters.
```powershell
New-AzEventGridTopicSpace -Name azps-topicspace -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -TopicTemplate "filter1"
```

```output
Name            ResourceGroupName
----            -----------------
azps-topicspace azps_test_group_eventgrid
```

Create a topic space with the specified parameters.