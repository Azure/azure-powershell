### Example 1: List all topics in a Kafka cluster
```powershell
Get-AzConfluentTopic -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -EnvironmentId env-abc123 -ClusterId lkc-abc123
```

```output
Name              Partitions  ReplicationFactor  IsInternal
----              ----------  -----------------  ----------
orders            6           3                  False
payments          3           3                  False
__consumer_offsets 50         3                  True
```

This command lists all Kafka topics in the specified cluster.

### Example 2: Get specific topic details
```powershell
Get-AzConfluentTopic -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -EnvironmentId env-abc123 -ClusterId lkc-abc123 -TopicName orders
```

This command retrieves details of a specific Kafka topic.

