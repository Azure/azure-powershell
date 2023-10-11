### Example 1: Asynchronously creates a new namespace topic with the specified parameters.
```powershell
New-AzEventGridNamespaceTopic -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -TopicName azps-topic -PublisherType Custom -EventRetentionInDay 1 -InputSchema CloudEventSchemaV1_0
```

```output
Name       ResourceGroupName
----       -----------------
azps-topic azps_test_group_eventgrid
```

Asynchronously creates a new namespace topic with the specified parameters.