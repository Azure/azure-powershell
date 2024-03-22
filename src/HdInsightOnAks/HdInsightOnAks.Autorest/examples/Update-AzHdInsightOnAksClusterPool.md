### Example 1: Upgrade a cluster pool(NodeOsUpgrade).
```powershell
$clusterResourceGroupName = "Group"
$clusterpoolName = "your-clusterpool"
Update-AzHdInsightOnAksClusterPool -ResourceGroupName $clusterResourceGroupName -ClusterPoolName $clusterpoolName -UpgradeType NodeOsUpgrade 
```

```output
AkClusterProfileAkClusterAgentPoolIdentityProfileMsiClientId   : 
AkClusterProfileAkClusterAgentPoolIdentityProfileMsiObjectId   : 
AkClusterProfileAkClusterAgentPoolIdentityProfileMsiResourceId : 
AkClusterProfileAksClusterResourceId                           : 
AkClusterProfileAksVersion                                     : 
AksManagedResourceGroupName                                    : 
ComputeProfileCount                                            : 
ComputeProfileVMSize                                           : 
DeploymentId                                                   : 
Id                                                             : /providers/Microsoft.HDInsight/locations/WESTUS3/operationStatuses/29a21725-8fec-428a-911f-dccc6ec9a6d8*F7AC27D6EE8809127228CC9761587D363E49354C7A941A3D1D0AF885952AC245
Location                                                       : 
LogAnalyticProfileEnabled                                      : False
LogAnalyticProfileWorkspaceId                                  : 
ManagedResourceGroupName                                       : 
Name                                                           : 29a21725-8fec-428a-911f-dccc6ec9a6d8*F7AC27D6EE8809127228CC9761587D363E49354C7A941A3D1D0AF885952AC245
NetworkProfileApiServerAuthorizedIPRange                       : 
NetworkProfileEnablePrivateApiServer                           : 
NetworkProfileOutboundType                                     : 
NetworkProfileSubnetId                                         : 
ProfileClusterPoolVersion                                      : 
ProvisioningState                                              : 
ResourceGroupName                                              : 
Status                                                         : 
SystemDataCreatedAt                                            : 
SystemDataCreatedBy                                            : 
SystemDataCreatedByType                                        : 
SystemDataLastModifiedAt                                       : 
SystemDataLastModifiedBy                                       : 
SystemDataLastModifiedByType                                   : 
Tag                                                            : {}
Type                                                           : 
```

Upgrade a cluster pool and upgrade type is NodeOsUpgrade.


### Example 2: Upgrade a cluster pool(AKSPatchUpgrade).
```powershell
$clusterResourceGroupName = "Group"
$clusterpoolName = "your-clusterpool"
$upgradeObj = New-AzHdInsightOnAksClusterPoolAKSUpgradeObject -TargetAksVersion "1.27.9" -UpgradeClusterPool $true
Update-AzHdInsightOnAksClusterPool -ResourceGroupName $clusterResourceGroupName -ClusterPoolName $clusterpoolName -ClusterPoolUpgradeRequest $upgradeObj
```

```output
AkClusterProfileAkClusterAgentPoolIdentityProfileMsiClientId   : 
AkClusterProfileAkClusterAgentPoolIdentityProfileMsiObjectId   : 
AkClusterProfileAkClusterAgentPoolIdentityProfileMsiResourceId : 
AkClusterProfileAksClusterResourceId                           : 
AkClusterProfileAksVersion                                     : 
AksManagedResourceGroupName                                    : 
ComputeProfileCount                                            : 
ComputeProfileVMSize                                           : 
DeploymentId                                                   : 
Id                                                             : /providers/Microsoft.HDInsight/locations/WESTUS3/operationStatuses/0aea8755-7a43-4c4a-96ea-a2879b9cb820*F7AC27D6EE8809127228CC9761587D363E49354C7A941A3D1D0AF885952AC245
Location                                                       : 
LogAnalyticProfileEnabled                                      : False
LogAnalyticProfileWorkspaceId                                  : 
ManagedResourceGroupName                                       : 
Name                                                           : 0aea8755-7a43-4c4a-96ea-a2879b9cb820*F7AC27D6EE8809127228CC9761587D363E49354C7A941A3D1D0AF885952AC245
NetworkProfileApiServerAuthorizedIPRange                       : 
NetworkProfileEnablePrivateApiServer                           : 
NetworkProfileOutboundType                                     : 
NetworkProfileSubnetId                                         : 
ProfileClusterPoolVersion                                      : 
ProvisioningState                                              : 
ResourceGroupName                                              : 
Status                                                         : 
...
```

Upgrade a cluster pool and upgrade type is NodeOsUpgrade.