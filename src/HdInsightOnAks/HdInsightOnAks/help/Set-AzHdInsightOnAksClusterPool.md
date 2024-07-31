---
external help file: Az.HdInsightOnAks-help.xml
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/set-azhdinsightonaksclusterpool
schema: 2.0.0
---

# Set-AzHdInsightOnAksClusterPool

## SYNOPSIS
Update a cluster pool.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzHdInsightOnAksClusterPool -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Location <String> [-ClusterPoolVersion <String>] [-ComputeProfileAvailabilityZone <String[]>]
 [-EnableLogAnalytics] [-LogAnalyticWorkspaceResourceId <String>] [-ManagedResourceGroupName <String>]
 [-NetworkProfileApiServerAuthorizedIPRange <String[]>] [-NetworkProfileEnablePrivateApiServer]
 [-NetworkProfileOutboundType <String>] [-SubnetId <String>] [-Tag <Hashtable>] [-VmSize <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Update
```
Set-AzHdInsightOnAksClusterPool -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -ClusterPool <IClusterPool> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Set-AzHdInsightOnAksClusterPool -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Set-AzHdInsightOnAksClusterPool -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a cluster pool.

## EXAMPLES

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
Parameter Sets: Update
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComputeProfileAvailabilityZone
The list of Availability zones to use for AKS VMSS nodes.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: (All)
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
Currently, this property is not supported and please don't use it.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: (All)
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: (All)
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterPool

## NOTES

## RELATED LINKS
