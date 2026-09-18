### Example 1: Update Topic
```powershell
Update-AzConfluentTopic `
    -OrganizationName "sharedrp-scus-org" `
    -ResourceGroupName "sharedrp-confluent" `
    -EnvironmentId "env-exampleenv001" `
    -ClusterId "lkc-examplekafka1" `
    -Name "topic_2" `
    -PartitionsCount "6" `
    -ReplicationFactor "3"
```

```output
ConfigRelated                :
Id                           : /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/sharedrp-confluent/providers/Microsoft.Confluent/organizations/sharedrp-scus-org/environments/env-exampleenv001/clusters/lkc-examplekafka1/topics/topic_2
InputConfig                  : {}
Kind                         :
MetadataResourceName         :
MetadataSelf                 : Self
Name                         : topic_2
PartitionReassignmentRelated :
PartitionRelated             :
PartitionsCount              : 6
ReplicationFactor            : 3
ResourceGroupName            : sharedrp-confluent
SystemDataCreatedAt          : 1/7/2026 4:23:20 AM
SystemDataCreatedBy          : user4@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/7/2026 3:36:11 PM
SystemDataLastModifiedBy     : user4@example.com
SystemDataLastModifiedByType : User
TopicId                      :
Type                         : microsoft.confluent/organizations/environments/clusters/topics
```

This command updates confluent topics