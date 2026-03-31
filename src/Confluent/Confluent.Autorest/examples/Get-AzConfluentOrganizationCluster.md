### Example 1: Get Cluster by Cluster ID
```powershell
Get-AzConfluentOrganizationCluster -ClusterId cluster_1 -EnvironmentId env-exampleenv001 -OrganizationName sharedrp-scus-org -ResourceGroupName sharedrp-confluent
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/sharedrp-confluent/providers/Microsoft.Confluent/organizations/sharedrp-scus-org/environments/env-exampleenv001/clusters/cluster_1
Kind                         : Cluster
MetadataCreatedTimestamp     : 12/19/2025 09:35:30 +00:00
MetadataDeletedTimestamp     :
MetadataResourceName         : crn://confluent.cloud/organization=00000000-0000-0000-0000-000000000000/environment=env-exampleenv001/cloud-cluster=lkc-examplekafka1/kafka=lkc-examplekafka1
MetadataSelf                 : https://api.example.confluent.io/cmk/v2/clusters/lkc-examplekafka1
MetadataUpdatedTimestamp     : 12/19/2025 09:35:30 +00:00
Name                         : cluster_1
ResourceGroupName            : sharedrp-confluent
Spec                         : {
                                 "config": {
                                   "kind": "Basic"
                                 },
                                 "environment": {
                                   "id": "env-exampleenv001"
                                 },
                                 "name": "cluster_1",
                                 "availability": "SINGLE_ZONE",
                                 "cloud": "AZURE",
                                 "region": "centralus",
                                 "httpEndpoint": "https://pkc-exampleabc001.centralus.azure.example.confluent.io:443",
                                 "apiEndpoint": ""
                               }
StatusCku                    : 0
StatusPhase                  : PROVISIONING
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : microsoft.confluent/organizations/environments/clusters
```

This command fetches the cluster details by cluster ID