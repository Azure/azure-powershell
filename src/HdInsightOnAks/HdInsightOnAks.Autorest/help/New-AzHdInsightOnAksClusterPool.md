---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/new-azhdinsightonaksclusterpool
schema: 2.0.0
---

# New-AzHdInsightOnAksClusterPool

## SYNOPSIS
Create a cluster pool.

## SYNTAX

### CreateExpanded (Default)
```
New-AzHdInsightOnAksClusterPool -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-ClusterPoolVersion <String>] [-EnableLogAnalytics]
 [-LogAnalyticWorkspaceResourceId <String>] [-ManagedResourceGroupName <String>]
 [-NetworkProfileApiServerAuthorizedIPRange <String[]>] [-NetworkProfileEnablePrivateApiServer]
 [-NetworkProfileOutboundType <String>] [-SubnetId <String>] [-Tag <Hashtable>] [-VmSize <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzHdInsightOnAksClusterPool -Name <String> -ResourceGroupName <String> -ClusterPool <IClusterPool>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzHdInsightOnAksClusterPool -InputObject <IHdInsightOnAksIdentity> -ClusterPool <IClusterPool>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzHdInsightOnAksClusterPool -InputObject <IHdInsightOnAksIdentity> -Location <String>
 [-ClusterPoolVersion <String>] [-EnableLogAnalytics] [-LogAnalyticWorkspaceResourceId <String>]
 [-ManagedResourceGroupName <String>] [-NetworkProfileApiServerAuthorizedIPRange <String[]>]
 [-NetworkProfileEnablePrivateApiServer] [-NetworkProfileOutboundType <String>] [-SubnetId <String>]
 [-Tag <Hashtable>] [-VmSize <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzHdInsightOnAksClusterPool -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzHdInsightOnAksClusterPool -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a cluster pool.

## EXAMPLES

### Example 1: Create an Azure HDInsight gen2 cluster pool
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

### Example 2: Create an Azure HDInsight gen2 cluster pool enabled log analytics workspace
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

Create an Azure HDInsight gen2 cluster pool enabled azure monitor with log analytics workspace.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterPool
Cluster pool.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterPool
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterPoolVersion
Cluster pool version is a 2-part version.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -EnableLogAnalytics
True if log analytics is enabled for cluster pool, otherwise false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

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
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogAnalyticWorkspaceResourceId
Log analytics workspace to associate with the OMS agent.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedResourceGroupName
A resource group created by RP, to hold the resources created by RP on-behalf of customers.
It will also be used to generate aksManagedResourceGroupName by pattern: MC_{managedResourceGroupName}_{clusterPoolName}_{region}.
Please make sure it meets resource group name restriction.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the cluster pool.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases: ClusterPoolName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkProfileApiServerAuthorizedIPRange
IP ranges are specified in CIDR format, e.g.
137.117.106.88/29.
This feature is not compatible with private AKS clusters.
So you cannot set enablePrivateApiServer to true and apiServerAuthorizedIpRanges at the same time.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkProfileEnablePrivateApiServer
ClusterPool is based on AKS cluster.
AKS cluster exposes the API server to public internet by default.
If you set this property to true, a private AKS cluster will be created, and it will use private apiserver, which is not exposed to public internet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkProfileOutboundType
This can only be set at cluster pool creation time and cannot be changed later.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubnetId
Cluster pool subnet resource id.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VmSize
The virtual machine SKU.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterPool

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHdInsightOnAksIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterPool

## NOTES

## RELATED LINKS

