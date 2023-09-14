---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/resize-azhdinsightonakscluster
schema: 2.0.0
---

# Resize-AzHdInsightOnAksCluster

## SYNOPSIS
Resize an existing Cluster.

## SYNTAX

### ResizeExpanded (Default)
```
Resize-AzHdInsightOnAksCluster -Name <String> -PoolName <String> -ResourceGroupName <String>
 -Location <String> [-SubscriptionId <String>] [-Tag <Hashtable>] [-TargetWorkerNodeCount <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Resize
```
Resize-AzHdInsightOnAksCluster -Name <String> -PoolName <String> -ResourceGroupName <String>
 -ClusterResizeRequest <IClusterResizeData> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ResizeViaIdentity
```
Resize-AzHdInsightOnAksCluster -InputObject <IHdInsightOnAksIdentity>
 -ClusterResizeRequest <IClusterResizeData> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ResizeViaIdentityExpanded
```
Resize-AzHdInsightOnAksCluster -InputObject <IHdInsightOnAksIdentity> -Location <String> [-Tag <Hashtable>]
 [-TargetWorkerNodeCount <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Resize an existing Cluster.

## EXAMPLES

### Example 1: Resize the number of working nodes in the cluster.
```powershell
$clusterResourceGroupName = "your-resourceGroup"
$clusterpoolName = "your-clusterpool"
$clusterName = "your-clustername"
$targetWorkerNodeCount 6
Resize-AzHdInsightOnAksCluster `
    -ResourceGroupName $clusterResourceGroupName `
    -Location $location `
    -PoolName $clusterpoolName `
    -Name $clusterName `
    -TargetWorkerNodeCount $targetWorkerNodeCount
```

```output
ApplicationLogStdErrorEnabled               :
ApplicationLogStdOutEnabled                 :
AuthorizationProfileGroupId                 :
AuthorizationProfileUserId                  :
AutoscaleProfileAutoscaleType               :
AutoscaleProfileEnabled                     : False
AutoscaleProfileGracefulDecommissionTimeout :
ClusterType                                 :
ComputeProfileNode                          :
ConnectivityProfileSsh                      :
CoordinatorDebugEnable                      :
CoordinatorDebugPort                        :
CoordinatorDebugSuspend                     :
CoordinatorHighAvailabilityEnabled          :
DeploymentId                                :
FlinkProfileNumReplica                      :
HistoryServerCpu                            : 0
HistoryServerMemory                         : 0
...
```

Resize the number to 6 of working nodes in the cluster.

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

### -ClusterResizeRequest
The parameters for resizing a cluster.
To construct, see NOTES section for CLUSTERRESIZEREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.IClusterResizeData
Parameter Sets: Resize, ResizeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHdInsightOnAksIdentity
Parameter Sets: ResizeViaIdentity, ResizeViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: ResizeExpanded, ResizeViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the HDInsight cluster.

```yaml
Type: System.String
Parameter Sets: Resize, ResizeExpanded
Aliases: ClusterName

Required: True
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

### -PoolName
The name of the cluster pool.

```yaml
Type: System.String
Parameter Sets: Resize, ResizeExpanded
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
Parameter Sets: Resize, ResizeExpanded
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
Type: System.String
Parameter Sets: Resize, ResizeExpanded
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
Parameter Sets: ResizeExpanded, ResizeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetWorkerNodeCount
Target node count of worker node.

```yaml
Type: System.Int32
Parameter Sets: ResizeExpanded, ResizeViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.IClusterResizeData

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHdInsightOnAksIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.Api20230601Preview.ICluster

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`CLUSTERRESIZEREQUEST <IClusterResizeData>`: The parameters for resizing a cluster.
  - `Location <String>`: The geo-location where the resource lives
  - `[Tag <ITrackedResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.
  - `[TargetWorkerNodeCount <Int32?>]`: Target node count of worker node.

`INPUTOBJECT <IHdInsightOnAksIdentity>`: Identity Parameter
  - `[ClusterName <String>]`: The name of the HDInsight cluster.
  - `[ClusterPoolName <String>]`: The name of the cluster pool.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The name of the Azure region.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription. The value must be an UUID.

## RELATED LINKS

