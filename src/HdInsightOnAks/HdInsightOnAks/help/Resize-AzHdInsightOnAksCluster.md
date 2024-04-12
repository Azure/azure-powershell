---
external help file: Az.HdInsightOnAks-help.xml
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
 [-SubscriptionId <String>] -Location <String> [-Tag <Hashtable>] [-TargetWorkerNodeCount <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ResizeViaJsonString
```
Resize-AzHdInsightOnAksCluster -Name <String> -PoolName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResizeViaJsonFilePath
```
Resize-AzHdInsightOnAksCluster -Name <String> -PoolName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResizeViaIdentityClusterpoolExpanded
```
Resize-AzHdInsightOnAksCluster -Name <String> -ClusterpoolInputObject <IHdInsightOnAksIdentity>
 -Location <String> [-Tag <Hashtable>] [-TargetWorkerNodeCount <Int32>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResizeViaIdentityClusterpool
```
Resize-AzHdInsightOnAksCluster -Name <String> -ClusterpoolInputObject <IHdInsightOnAksIdentity>
 -ClusterResizeRequest <IClusterResizeData> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Resize
```
Resize-AzHdInsightOnAksCluster -Name <String> -PoolName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -ClusterResizeRequest <IClusterResizeData> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResizeViaIdentityExpanded
```
Resize-AzHdInsightOnAksCluster -InputObject <IHdInsightOnAksIdentity> -Location <String> [-Tag <Hashtable>]
 [-TargetWorkerNodeCount <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResizeViaIdentity
```
Resize-AzHdInsightOnAksCluster -InputObject <IHdInsightOnAksIdentity>
 -ClusterResizeRequest <IClusterResizeData> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Resize an existing Cluster.

## EXAMPLES

### Example 1: Resize the number of working nodes in the cluster.
```powershell
$clusterResourceGroupName = "your-resourceGroup"
$clusterpoolName = "your-clusterpool"
$clusterName = "your-clustername"
$targetWorkerNodeCount = 6
$location = "west us 2"

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

### -ClusterpoolInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHdInsightOnAksIdentity
Parameter Sets: ResizeViaIdentityClusterpoolExpanded, ResizeViaIdentityClusterpool
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterResizeRequest
The parameters for resizing a cluster.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterResizeData
Parameter Sets: ResizeViaIdentityClusterpool, Resize, ResizeViaIdentity
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHdInsightOnAksIdentity
Parameter Sets: ResizeViaIdentityExpanded, ResizeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Resize operation

```yaml
Type: System.String
Parameter Sets: ResizeViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Resize operation

```yaml
Type: System.String
Parameter Sets: ResizeViaJsonString
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
Parameter Sets: ResizeExpanded, ResizeViaIdentityClusterpoolExpanded, ResizeViaIdentityExpanded
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
Parameter Sets: ResizeExpanded, ResizeViaJsonString, ResizeViaJsonFilePath, ResizeViaIdentityClusterpoolExpanded, ResizeViaIdentityClusterpool, Resize
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
Parameter Sets: ResizeExpanded, ResizeViaJsonString, ResizeViaJsonFilePath, Resize
Aliases: ClusterPoolName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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
Parameter Sets: ResizeExpanded, ResizeViaJsonString, ResizeViaJsonFilePath, Resize
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
Parameter Sets: ResizeExpanded, ResizeViaJsonString, ResizeViaJsonFilePath, Resize
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
Parameter Sets: ResizeExpanded, ResizeViaIdentityClusterpoolExpanded, ResizeViaIdentityExpanded
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
Parameter Sets: ResizeExpanded, ResizeViaIdentityClusterpoolExpanded, ResizeViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterResizeData

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHdInsightOnAksIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ICluster

## NOTES

## RELATED LINKS
