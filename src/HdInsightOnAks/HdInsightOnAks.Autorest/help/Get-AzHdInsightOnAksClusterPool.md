---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/get-azhdinsightonaksclusterpool
schema: 2.0.0
---

# Get-AzHdInsightOnAksClusterPool

## SYNOPSIS
Gets a cluster pool.

## SYNTAX

### List (Default)
```
Get-AzHdInsightOnAksClusterPool [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzHdInsightOnAksClusterPool -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzHdInsightOnAksClusterPool -InputObject <IHdInsightOnAksIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzHdInsightOnAksClusterPool -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a cluster pool.

## EXAMPLES

### Example 1: list all HDInsight gen2 cluster pools in current subscription
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

list all HDInsight gen2 cluster pools in current subscription.

### Example 2: list all HDInsight gen2 cluster pools in a resource group
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

list all HDInsight gen2 cluster pools in a resource group.

### Example 3: Get a HDInsight gen2 cluster pool in a resource group
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

Get a HDInsight gen2 cluster pool in a resource group.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHdInsightOnAksIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the cluster pool.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ClusterPoolName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHdInsightOnAksIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterPool

## NOTES

## RELATED LINKS

