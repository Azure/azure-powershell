### Example 1: Regenerate a shared access key for a topic.
```powershell
New-AzEventGridTopicKey -ResourceGroupName azps_test_group_eventgrid -TopicName azps-topic -KeyName key1
```

```output
Key1        Key2
----        ----
JF0co*****= BG*****=
```

Regenerate a shared access key for a topic.