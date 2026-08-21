### Example 1: Create Confluent topic
```powershell
New-AzConfluentTopic `
    -OrganizationName "sharedrp-scus-org" `
    -ResourceGroupName "sharedrp-confluent" `
    -EnvironmentId "env-exampleenv001" `
    -ClusterId "lkc-examplekafka1" `
    -Name "my-topic" `
    -PartitionsCount "6" `
    -ReplicationFactor "3"
```

```output
ConfigRelated                :
Id                           : /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/sharedrp-confluent/providers/Microsoft.Confluent/organizations/sharedrp-scus-org/environments/env-exampleenv001/clusters/lkc-examplekafka1/topics/my-topic
InputConfig                  :
Kind                         :
MetadataResourceName         :
MetadataSelf                 :
Name                         : my-topic
PartitionReassignmentRelated :
PartitionRelated             :
PartitionsCount              : 6
ReplicationFactor            : 3
ResourceGroupName            : sharedrp-confluent
SystemDataCreatedAt          : 3/7/2026 2:17:49 PM
SystemDataCreatedBy          : user4@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/7/2026 2:17:49 PM
SystemDataLastModifiedBy     : user4@example.com
SystemDataLastModifiedByType : User
TopicId                      :
Type                         : microsoft.confluent/organizations/environments/clusters/topics
```

This command creates confluent topics