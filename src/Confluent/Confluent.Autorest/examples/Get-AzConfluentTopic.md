### Example 1: List Topics in a cluster
```powershell
Get-AzConfluentTopic -ClusterId lkc-examplekafka1 -EnvironmentId env-exampleenv001 -OrganizationName sharedrp-scus-org -ResourceGroupName sharedrp-confluent
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                                 ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
cosmos.metadata.topic.lcc-stgc1vpmx5                                                                                                                                                sharedrp-confluent
cosmos.metadata.topic.lcc-stgcm9kon1                                                                                                                                                sharedrp-confluent
cosmos.metadata.topic.lcc-stgcq309wp                                                                                                                                                sharedrp-confluent
dlq-lcc-stgc3xwgpm                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgc5jmo38                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgc62rn93                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgc80v17q                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgcdn1njo                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgcdnvydz                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgcgokr23                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgcgow69m                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgcm92vnw                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgcm9g1zq                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgcn8j9gk                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgcp2kpgk                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgcydg857                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgcydyj1o                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgcyv2666                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgcyvd3ok                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgcyvg91k                                                                                                                                                                  sharedrp-confluent
dlq-lcc-stgczxdz73                                                                                                                                                                  sharedrp-confluent
testtopic1                                                                                                                                                                          sharedrp-confluent
topic_1                                                                                                                                                                             sharedrp-confluent
topic_2                                                                                                                                                                             sharedrp-confluent
topic_3                                                                                                                                                                             sharedrp-confluent
```

This command lists all topics in cluster

### Example 2: Get Topic by topic name
```powershell
Get-AzConfluentTopic -ClusterId lkc-examplekafka1 -EnvironmentId env-exampleenv001 -Name <String> -OrganizationName sharedrp-scus-org -ResourceGroupName sharedrp-confluent
```

```output
ConfigRelated                :
Id                           : /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/sharedrp-confluent/providers/Microsoft.Confluent/organizations/sharedrp-scus-org/environments/env-exampleenv001/clusters/lkc-examplekafka1/topics/topic_1
InputConfig                  : {}
Kind                         :
MetadataResourceName         :
MetadataSelf                 : Self
Name                         : topic_1
PartitionReassignmentRelated :
PartitionRelated             :
PartitionsCount              : 6
ReplicationFactor            : 3
ResourceGroupName            : sharedrp-confluent
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TopicId                      :
Type                         : microsoft.confluent/organizations/environments/clusters/topics
```

This command fetches topic details by topic name