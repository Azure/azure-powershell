### Example 1: Create an Azure HDInsight cluster pool
```powershell
# Cluster pool configuration info
$location = "West US 3"
$clusterResourceGroupName = "Group"
$clusterpoolName = "your-clusterpool"
$vmSize = "Standard_E4s_v3"

# Create the cluster pool
New-AzHdInsightOnAksClusterPool `
    -Name $clusterpoolName `
    -ResourceGroupName $clusterResourceGroupName `
    -Location $location `
    -VmSize $vmSize
```

```output
AkClusterAgentPoolIdentityProfileMsiClientId   : 00000000-0000-0000-0000-000000000000
AkClusterAgentPoolIdentityProfileMsiObjectId   : 00000000-0000-0000-0000-000000000000
AkClusterAgentPoolIdentityProfileMsiResourceId : /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/MC_hdi-00000000000000000000000000000_testpoolname_westus3/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testpoolname-agentpool
AkClusterProfileAksClusterResourceId           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/hdi-00000000000000000000000000000/providers/Microsoft.ContainerService/managedClusters/testpoolname
AkClusterProfileAksVersion                     : 1.26
AksManagedResourceGroupName                    : MC_hdi-00000000000000000000000000000_testpoolname_westus3
ComputeProfileCount                            : 3
ComputeProfileVMSize                           : Standard_E4s_v3
DeploymentId                                   : 00000000000000000000000000000
Id                                             : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/Group/providers/Microsoft.HDInsight/clusterpools/testpoolname
Location                                       : West US 3
LogAnalyticProfileEnabled                      : False
LogAnalyticProfileWorkspaceId                  :
ManagedResourceGroupName                       : hdi-00000000000000000000000000000
Name                                           : testpoolname
NetworkProfileSubnetId                         :
ProfileClusterPoolVersion                      :
ProvisioningState                              : Succeeded
Status                                         : Running
SystemData                                     : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api40.SystemData
SystemDataCreatedAt                            :
...
```

This command creates a cluster pool in the current subscription.

### Example 2: Create an Azure HDInsight cluster pool enabled log analytics workspace
```powershell
# Cluster configuration info
$location = "East US 2"
$clusterResourceGroupName = "Group"
$clusterpoolName = "your-clusterpool"
$vmSize = "Standard_E4s_v3"

# log analytics workspace info
$LogAnalyticProfileWorkspaceId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/group/providers/microsoft.operationalinsights/workspaces/loganalyticsworkspacename"

# Create the cluster pool
New-AzHdInsightOnAksClusterPool `
    -Name $clusterpoolName `
    -ResourceGroupName $clusterResourceGroupName `
    -Location $location `
    -VmSize $vmSize `
    -EnableLogAnalytics `
    -LogAnalyticWorkspaceResourceId $LogAnalyticProfileWorkspaceId
```

```output
AkClusterAgentPoolIdentityProfileMsiClientId   : 00000000-0000-0000-0000-000000000000
AkClusterAgentPoolIdentityProfileMsiObjectId   : 00000000-0000-0000-0000-000000000000
AkClusterAgentPoolIdentityProfileMsiResourceId : /subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/MC_hdi-00000000000000000000000000000_testpoolname_westus3/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testpoolname-agentpool
AkClusterProfileAksClusterResourceId           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/hdi-00000000000000000000000000000/providers/Microsoft.ContainerService/managedClusters/testpoolname
AkClusterProfileAksVersion                     : 1.26
AksManagedResourceGroupName                    : MC_hdi-00000000000000000000000000000_testpoolname_westus3
ComputeProfileCount                            : 3
ComputeProfileVMSize                           : Standard_E4s_v3
DeploymentId                                   : 00000000000000000000000000000
Id                                             : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/Group/providers/Microsoft.HDInsight/clusterpools/testpoolname
Location                                       : West US 3
LogAnalyticProfileEnabled                      : True
LogAnalyticProfileWorkspaceId                  :/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/group/providers/microsoft.operationalinsights/workspaces/loganalyticsworkspacename"
ManagedResourceGroupName                       : hdi-00000000000000000000000000000
Name                                           : testpoolname
NetworkProfileSubnetId                         :
ProfileClusterPoolVersion                      :
ProvisioningState                              : Succeeded
Status                                         : Running
SystemData                                     : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api40.SystemData
SystemDataCreatedAt                            :
...
```

Create an Azure HDInsight cluster pool enabled azure monitor with log analytics workspace.
