### Example 1: Remove a Kafka topic
```powershell
Remove-AzConfluentTopic -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -EnvironmentId env-abc123 -ClusterId lkc-abc123 -TopicName old-topic
```

This command removes a Kafka topic from the cluster.

### Example 2: Remove topic without confirmation
```powershell
Remove-AzConfluentTopic -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -EnvironmentId env-abc123 -ClusterId lkc-abc123 -TopicName temp-topic -Force
```

This command removes a Kafka topic without prompting for confirmation.

