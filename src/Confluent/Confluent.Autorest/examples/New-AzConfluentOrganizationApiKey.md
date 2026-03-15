### Example 1: Create an API key for a Kafka cluster
```powershell
New-AzConfluentOrganizationApiKey `
    -OrganizationName "sharedrp-scus-org" `
    -ResourceGroupName "sharedrp-confluent" `
    -EnvironmentId "env-exampleenv001" `
    -ClusterId "cluster_1" `
    -Name "my-kafka-api-key" `
    -Description "API key for kafka cluster access"
```

```output
Id                       : EXAMPLEApiKeyId01
Kind                     : ApiKey
MetadataCreatedTimestamp : 2026-03-07T14:19:59.278517+00:00
MetadataDeletedTimestamp :
MetadataResourceName     : crn://api.example.confluent.io/organization=00000000-0000-0000-0000-000000000000/user=u-exampleuser03/api-key=EXAMPLEApiKeyId01
MetadataSelf             : https://api.example.confluent.io/iam/v2/api-keys/EXAMPLEApiKeyId01
MetadataUpdatedTimestamp : 2026-03-07T14:19:59.278517+00:00
OwnerId                  : u-exampleuser03
OwnerKind                : User
OwnerRelated             : https://api.example.confluent.io/iam/v2/users/u-exampleuser03
OwnerResourceName        : crn://api.example.confluent.io/organization=00000000-0000-0000-0000-000000000000/user=u-exampleuser03
ResourceEnvironment      : env-exampleenv001
ResourceGroupName        :
ResourceId               : lkc-examplekafka1
ResourceKind             : Cluster
ResourceName             : crn://api.example.confluent.io/organization=00000000-0000-0000-0000-000000000000/kafka=lkc-examplekafka1
ResourceRelated          : https://api.example.confluent.io/cmk/v2/clusters/lkc-examplekafka1
SpecDescription          : API key for kafka cluster access
SpecName                 : my-kafka-api-key
SpecSecret               :
```

This command Create API Key for a schema registry cluster ID under a environment