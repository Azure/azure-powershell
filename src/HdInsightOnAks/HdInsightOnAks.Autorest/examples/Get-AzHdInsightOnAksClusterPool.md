### Example 1: list all HDInsight cluster pools in current subscription
```powershell
Get-AzHdInsightOnAksClusterPool
```

```output
AkClusterAgentPoolIdentityProfileMsiClientId   : 00000000-0000-0000-0000-000000000000
AkClusterAgentPoolIdentityProfileMsiObjectId   : 00000000-0000-0000-0000-000000000000
AkClusterAgentPoolIdentityProfileMsiResourceId : /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/MC_hdi-00000000-0000-0000-0000-000000000000_clusterpool_westus2/providers/Microsoft.ManagedIdentity/userAssignedIdentities/agentpool
AkClusterProfileAksClusterResourceId           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/hdi-000000000000000000000000000000/providers/Microsoft.ContainerService/managedClusters/clusterpool
AkClusterProfileAksVersion                     : 1.26
AksManagedResourceGroupName                    : MC_hdi-00000000-0000-0000-0000-000000000000_clusterpool_westus2
ComputeProfileCount                            : 3
ComputeProfileVMSize                           : Standard_E4s_v3
DeploymentId                                   : 000000000000000000000000000000
Id                                             : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/Group/providers/Microsoft.HDInsight/clusterpools/clusterpoolname
Location                                       : West US 2
LogAnalyticProfileEnabled                      : True
LogAnalyticProfileWorkspaceId                  : /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/Group/providers/microsoft.operationalinsights/workspaces/testworkspace
ManagedResourceGroupName                       : hdi-000000000000000000000000000000
Name                                           : clusterpoolname
NetworkProfileSubnetId                         :
ProfileClusterPoolVersion                      : 1.0
ProvisioningState                              : Succeeded
Status                                         : Running
SystemData                                     : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api40.SystemData
SystemDataCreatedAt                            :
...
```

list all HDInsight cluster pools in current subscription.

### Example 2: list all HDInsight cluster pools in a resource group
```powershell
$clusterResourceGroupName = "your-resourceGroup"
Get-AzHdInsightOnAksClusterPool -ResourceGroupName $clusterResourceGroupName
```

```output
AkClusterAgentPoolIdentityProfileMsiClientId   : 00000000-0000-0000-0000-000000000000
AkClusterAgentPoolIdentityProfileMsiObjectId   : 00000000-0000-0000-0000-000000000000
AkClusterAgentPoolIdentityProfileMsiResourceId : /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/MC_hdi-00000000-0000-0000-0000-000000000000_clusterpool_westus2/providers/Microsoft.ManagedIdentity/userAssignedIdentities/agentpool
AkClusterProfileAksClusterResourceId           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/hdi-000000000000000000000000000000/providers/Microsoft.ContainerService/managedClusters/clusterpool
AkClusterProfileAksVersion                     : 1.26
AksManagedResourceGroupName                    : MC_hdi-00000000-0000-0000-0000-000000000000_clusterpool_westus2
ComputeProfileCount                            : 3
ComputeProfileVMSize                           : Standard_E4s_v3
DeploymentId                                   : 000000000000000000000000000000
Id                                             : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/Group/providers/Microsoft.HDInsight/clusterpools/clusterpoolname
Location                                       : West US 2
LogAnalyticProfileEnabled                      : True
LogAnalyticProfileWorkspaceId                  : /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/Group/providers/microsoft.operationalinsights/workspaces/testworkspace
ManagedResourceGroupName                       : hdi-000000000000000000000000000000
Name                                           : clusterpoolname
NetworkProfileSubnetId                         :
ProfileClusterPoolVersion                      : 1.0
ProvisioningState                              : Succeeded
Status                                         : Running
SystemData                                     : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api40.SystemData
SystemDataCreatedAt                            :
...
```

list all HDInsight cluster pools in a resource group.

### Example 3: Get a HDInsight cluster pool in a resource group
```powershell
$clusterResourceGroupName = "your-resourceGroup"
$clusterpoolName = "your-clusterpool"
Get-AzHdInsightOnAksClusterPool -ResourceGroupName $clusterResourceGroupName -Name $clusterpoolName
```

```output
AkClusterAgentPoolIdentityProfileMsiClientId   : 00000000-0000-0000-0000-000000000000
AkClusterAgentPoolIdentityProfileMsiObjectId   : 00000000-0000-0000-0000-000000000000
AkClusterAgentPoolIdentityProfileMsiResourceId : /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/MC_hdi-00000000-0000-0000-0000-000000000000_clusterpool_westus2/providers/Microsoft.ManagedIdentity/userAssignedIdentities/agentpool
AkClusterProfileAksClusterResourceId           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/hdi-000000000000000000000000000000/providers/Microsoft.ContainerService/managedClusters/clusterpool
AkClusterProfileAksVersion                     : 1.26
AksManagedResourceGroupName                    : MC_hdi-00000000-0000-0000-0000-000000000000_clusterpool_westus2
ComputeProfileCount                            : 3
ComputeProfileVMSize                           : Standard_E4s_v3
DeploymentId                                   : 000000000000000000000000000000
Id                                             : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/Group/providers/Microsoft.HDInsight/clusterpools/clusterpoolname
Location                                       : West US 2
LogAnalyticProfileEnabled                      : True
LogAnalyticProfileWorkspaceId                  : /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/Group/providers/microsoft.operationalinsights/workspaces/testworkspace
ManagedResourceGroupName                       : hdi-000000000000000000000000000000
Name                                           : clusterpoolname
NetworkProfileSubnetId                         :
ProfileClusterPoolVersion                      : 1.0
ProvisioningState                              : Succeeded
Status                                         : Running
SystemData                                     : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api40.SystemData
SystemDataCreatedAt                            :
...
```

Get a HDInsight cluster pool in a resource group.