### Example 1: Create a new Kafka topic
```powershell
New-AzConfluentTopic -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -EnvironmentId env-abc123 -ClusterId lkc-abc123 -Name orders -Partitions 6 -ReplicationFactor 3
```

```output
Name       Partitions  ReplicationFactor  IsInternal
----       ----------  -----------------  ----------
orders     6           3                  False
```

This command creates a new Kafka topic with specified partitions and replication factor.

### Example 2: Create topic with custom retention
```powershell
New-AzConfluentTopic -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -EnvironmentId env-abc123 -ClusterId lkc-abc123 -Name logs -Partitions 12 -ReplicationFactor 3 -RetentionMs 604800000
```

This command creates a Kafka topic with 7-day retention period.

