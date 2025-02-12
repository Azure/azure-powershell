### Example 1: Update an Azure HDInsight cluster pool.
```powershell
# Cluster configuration info
$location = "East US 2"
$clusterResourceGroupName = "Group"
$clusterpoolName = "your-clusterpool"
$vmSize = "Standard_E4s_v3"

# log analytics workspace info
$LogAnalyticProfileWorkspaceId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/group/providers/microsoft.operationalinsights/workspaces/loganalyticsworkspacename"

Set-AzHdInsightOnAksClusterPool `
    -Name $clusterpoolName `
    -ResourceGroupName $clusterResourceGroupName `
    -VmSize $vmSize `
    -Location $location `
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
SystemDataLastModifiedAt                       : 2023/9/7 6:50:07
SystemDataLastModifiedBy                       : xxxxx@microsoft.com
SystemDataLastModifiedByType                   : User
Tag                                            : Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api40.TrackedResourceTags
Type                                           : microsoft.hdinsight/clusterpools
```

Update an Azure HDInsight cluster pool enableLogAnalytics.
