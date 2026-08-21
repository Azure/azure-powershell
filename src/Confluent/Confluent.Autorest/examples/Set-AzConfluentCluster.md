### Example 1: Update confluent clusters
```powershell
$spec = @{
    Name          = "cluster_4"
    Availability  = "SINGLE_ZONE"
    Cloud         = "Azure"
    Region        = "centralus"
    ConfigKind    = "Basic"
    EnvironmentId = "env-exampleenv001"
}

Set-AzConfluentCluster `
    -OrganizationName "sharedrp-scus-org" `
    -ResourceGroupName "sharedrp-confluent" `
    -EnvironmentId "env-exampleenv001" `
    -Id "lkc-ccccc" `
    -Kind "Cluster" `
    -Spec $spec
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/sharedrp-confluent/providers/Microsoft.Confluent/organizations/sharedrp-scus-org/environments/env-exampleenv001/clusters/lkc-ccccc
Kind                         : Cluster
MetadataCreatedTimestamp     :
MetadataDeletedTimestamp     :
MetadataResourceName         :
MetadataSelf                 :
MetadataUpdatedTimestamp     :
Name                         : lkc-ccccc
ResourceGroupName            : sharedrp-confluent
Spec                         : {
                                 "config": {
                                   "kind": "Basic"
                                 },
                                 "environment": {
                                   "id": "env-exampleenv001"
                                 },
                                 "name": "cluster_7",
                                 "availability": "SINGLE_ZONE",
                                 "cloud": "Azure",
                                 "region": "centralus"
                               }
StatusCku                    :
StatusPhase                  :
SystemDataCreatedAt          : 3/7/2026 3:24:52 PM
SystemDataCreatedBy          : user4@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 3/7/2026 3:24:52 PM
SystemDataLastModifiedBy     : user4@example.com
SystemDataLastModifiedByType : User
Type                         : microsoft.confluent/organizations/environments/clusters
```

This command updates confluent clusters