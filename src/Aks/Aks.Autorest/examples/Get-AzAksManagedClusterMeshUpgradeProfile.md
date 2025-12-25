### Example 1: Gets available upgrades for a service mesh in a cluster.
```powershell
Get-AzAksManagedClusterMeshUpgradeProfile -ResourceGroupName AKS_TEST_RG -ResourceName AKS_Test_Cluster
```

```output
CompatibleWith               : {{
                                 "name": "KubernetesOfficial",
                                 "versions": [ "1.29", "1.30", "1.31", "1.32", "1.33" ]
                               }}
Id                           : /subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/resourceGroups/AKS_TEST_RG/providers/Microsoft.ContainerService/managedClusters/AKS_Test_Cluster/meshUpgradeProfiles/istio
Name                         : istio
ResourceGroupName            : AKS_TEST_RG
Revision                     : asm-1-25
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.ContainerService/managedClusters/meshUpgradeProfiles
Upgrade                      : {asm-1-26, asm-1-27}
```

Gets available upgrades for a service mesh in a cluster.
