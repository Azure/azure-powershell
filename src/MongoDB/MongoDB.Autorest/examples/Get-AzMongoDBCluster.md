### Example 1: List all Clusters under a Project
```powershell
Get-AzMongoDBCluster -ResourceGroupName sharmaanuTest -OrganizationName KanedaTest -ProjectName test-project-1
```

```output
Backup                       : False
ClusterName                  : test-cluster-free
Id                           : /subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/sharmaanuTest/providers/MongoDB.Atlas/organizations/KanedaTest/projects/test-project-1/clusters/test-cluster-free
MongoDbVersion               : 8.0.24-patch-6a3992052eafe5000797a34e
Name                         : test-cluster-free
ProvisioningState            : Succeeded
RegionName                   : eastus2
ResourceGroupName            : sharmaanuTest
State                        : IDLE
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tier                         : FREE
Type                         : MongoDB.Atlas/organizations/projects/clusters
```

Lists all clusters that belong to the given project.

### Example 2: Get a specific Cluster
```powershell
Get-AzMongoDBCluster -ResourceGroupName sharmaanuTest -OrganizationName KanedaTest -ProjectName test-project-1 -Name test-cluster-free | Format-List
```

```output
Backup                       : False
ClusterName                  : test-cluster-free
Id                           : /subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/sharmaanuTest/providers/MongoDB.Atlas/organizations/KanedaTest/projects/test-project-1/clusters/test-cluster-free
MongoDbVersion               : 8.0.24-patch-6a3992052eafe5000797a34e
Name                         : test-cluster-free
ProvisioningState            : Succeeded
RegionName                   : eastus2
ResourceGroupName            : sharmaanuTest
State                        : IDLE
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tier                         : FREE
Type                         : MongoDB.Atlas/organizations/projects/clusters
```

Gets the details of a single cluster by name.
