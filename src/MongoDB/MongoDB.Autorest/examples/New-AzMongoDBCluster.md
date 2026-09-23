### Example 1: Create a new FREE-tier Cluster
```powershell
New-AzMongoDBCluster -ResourceGroupName sharmaanuTest -OrganizationName KanedaTest -ProjectName test-project-1 -Name test-cluster-free -ClusterTier FREE -RegionName eastus2 | Format-List
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

Creates a FREE-tier MongoDB Atlas cluster in `eastus2` under the given project. Valid tiers are FREE, FLEX, M10, M30. Use `Get-AzMongoDBProjectClusterTierRegion` first to confirm the chosen tier is available in the target region.

### Example 2: Create a paid (M10) Cluster
```powershell
New-AzMongoDBCluster -ResourceGroupName sharmaanuTest -OrganizationName KanedaTest -ProjectName test-project-1 -Name test-cluster-m10 -ClusterTier M10 -RegionName westus2
```

Creates a dedicated M10 cluster. M10/M30 tiers incur metered billing through the MongoDB Atlas marketplace offer linked to the organization.
