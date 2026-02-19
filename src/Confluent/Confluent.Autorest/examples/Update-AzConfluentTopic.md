### Example 1: Update Kafka topic partition count
```powershell
Update-AzConfluentTopic -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -EnvironmentId env-abc123 -ClusterId lkc-abc123 -TopicName orders -Partitions 12
```

```output
Name       Partitions  ReplicationFactor  IsInternal
----       ----------  -----------------  ----------
orders     12          3                  False
```

This command updates the partition count for a Kafka topic.

### Example 2: Update topic configuration settings
```powershell
Update-AzConfluentTopic -ResourceGroupName confluent-rg -OrganizationName confluentorg-01 -EnvironmentId env-abc123 -ClusterId lkc-abc123 -TopicName logs -Config @{"retention.ms"="1209600000"; "compression.type"="gzip"}
```

This command updates configuration settings for a Kafka topic (14-day retention with gzip compression).

