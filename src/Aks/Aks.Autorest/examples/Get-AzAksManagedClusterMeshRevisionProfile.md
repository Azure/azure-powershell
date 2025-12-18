### Example 1: Get AKS Mesh Revision Profile
```powershell
Get-AzAksManagedClusterMeshRevisionProfile -Location eastus
```

```output
Id                           : /subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/providers/Microsoft.ContainerService/locations/eastus/meshRevisionProfiles/istio
MeshRevision                 : {{
                                 "revision": "asm-1-25",
                                 "upgrades": [ "asm-1-26", "asm-1-27" ],
                                 "compatibleWith": [
                                   {
                                     "name": "KubernetesOfficial",
                                     "versions": [ "1.29", "1.30", "1.31", "1.32", "1.33" ]
                                   },
                                   {
                                     "name": "AKSLongTermSupport",
                                     "versions": [ "1.28", "1.29", "1.30", "1.31", "1.32", "1.33" ]
                                   }
                                 ]
                               }, {
                                 "revision": "asm-1-26",
                                 "upgrades": [ "asm-1-27" ],
                                 "compatibleWith": [
                                   {
                                     "name": "KubernetesOfficial",
                                     "versions": [ "1.29", "1.30", "1.31", "1.32", "1.33", "1.34" ]
                                   },
                                   {
                                     "name": "AKSLongTermSupport",
                                     "versions": [ "1.28", "1.29", "1.30", "1.31", "1.32", "1.33", "1.34" ]
                                   }
                                 ]
                               }, {
                                 "revision": "asm-1-27",
                                 "compatibleWith": [
                                   {
                                     "name": "KubernetesOfficial",
                                     "versions": [ "1.29", "1.30", "1.31", "1.32", "1.33", "1.34" ]
                                   },
                                   {
                                     "name": "AKSLongTermSupport",
                                     "versions": [ "1.29", "1.30", "1.31", "1.32", "1.33", "1.34" ]
                                   }
                                 ]
                               }}
Name                         : istio
ResourceGroupName            :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.ContainerService/locations/meshRevisionProfiles
```

Get extra metadata on the revision, including supported revisions, cluster compatibility and available upgrades.

