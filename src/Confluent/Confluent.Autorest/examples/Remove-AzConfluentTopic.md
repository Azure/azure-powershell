### Example 1: Delete topic
```powershell
Remove-AzConfluentTopic `
    -OrganizationName "sharedrp-scus-org" `
    -ResourceGroupName "sharedrp-confluent" `
    -EnvironmentId "env-exampleenv001" `
    -ClusterId "lkc-examplekafka1" `
    -Name "topic_1"
```

```output
""
```

This Command deletes the topic