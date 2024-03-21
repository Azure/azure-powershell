### Example 1: Upgrade a cluster pool.
```powershell
$clusterResourceGroupName = "Group"
$clusterpoolName = "your-clusterpool"
Update-AzHdInsightOnAksClusterPool -ResourceGroupName $clusterResourceGroupName -ClusterPoolName $clusterpoolName -Debug -UpgradeType NodeOsUpgrade 
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
