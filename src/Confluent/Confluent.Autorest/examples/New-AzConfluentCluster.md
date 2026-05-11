### Example 1: Create Confluent Cluster
```powershell
$spec = @{
    Name         = "cluster_4"
    Availability = "SINGLE_ZONE"
    Cloud        = "Azure"
    Region       = "centralus"
    ConfigKind   = "Basic"          # maps to spec.config.kind
    EnvironmentId = "env-exampleenv001" # maps to spec.environment.id
}

New-AzConfluentCluster `
    -OrganizationName "sharedrp-scus-org" `
    -ResourceGroupName "sharedrp-confluent" `
    -EnvironmentId "env-exampleenv001" `
    -Id "lkc-xxxxx" `
    -Kind "Cluster" `
    -Spec $spec
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/sharedrp-confluent/providers/Microsoft.Confluent/organizations/sharedrp-scus-org/environments/env-exampleenv001/clusters/lkc-xxxxx
Kind                         : Cluster
MetadataCreatedTimestamp     :
MetadataDeletedTimestamp     :
MetadataResourceName         :
MetadataSelf                 :
MetadataUpdatedTimestamp     :
Name                         : lkc-xxxxx
ResourceGroupName            : sharedrp-confluent
Spec                         : {
                                 "config": {
                                   "kind": "Basic"
                                 },
                                 "environment": {
                                   "id": "env-exampleenv001"
                                 },
                                 "name": "cluster_4",
                                 "availability": "SINGLE_ZONE",
                                 "cloud": "Azure",
                                 "region": "centralus"
                               }
StatusCku                    :
StatusPhase                  :
SystemDataCreatedAt          : 3/7/2026 2:07:47 PM
SystemDataCreatedBy          : user4@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/7/2026 2:07:47 PM
SystemDataLastModifiedBy     : user4@example.com
SystemDataLastModifiedByType : User
Type                         : microsoft.confluent/organizations/environments/clusters
```

This command create confluent clusters