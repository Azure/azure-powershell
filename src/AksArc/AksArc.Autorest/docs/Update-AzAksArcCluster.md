---
external help file:
Module Name: Az.AksArc
online version: https://learn.microsoft.com/powershell/module/az.aksarc/update-azaksarccluster
schema: 2.0.0
---

# Update-AzAksArcCluster

## SYNOPSIS
Update the provisioned cluster instance

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzAksArcCluster -ClusterName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AdminGroupObjectID <String[]>] [-AutoScalerProfileBalanceSimilarNodeGroup <String>]
 [-AutoScalerProfileExpander <String>] [-AutoScalerProfileMaxEmptyBulkDelete <String>]
 [-AutoScalerProfileMaxGracefulTerminationSec <String>] [-AutoScalerProfileMaxNodeProvisionTime <String>]
 [-AutoScalerProfileMaxTotalUnreadyPercentage <String>] [-AutoScalerProfileNewPodScaleUpDelay <String>]
 [-AutoScalerProfileOkTotalUnreadyCount <String>] [-AutoScalerProfileScaleDownDelayAfterAdd <String>]
 [-AutoScalerProfileScaleDownDelayAfterDelete <String>]
 [-AutoScalerProfileScaleDownDelayAfterFailure <String>] [-AutoScalerProfileScaleDownUnneededTime <String>]
 [-AutoScalerProfileScaleDownUnreadyTime <String>] [-AutoScalerProfileScaleDownUtilizationThreshold <String>]
 [-AutoScalerProfileScanInterval <String>] [-AutoScalerProfileSkipNodesWithLocalStorage <String>]
 [-AutoScalerProfileSkipNodesWithSystemPod <String>] [-ControlPlaneCount <Int32>] [-EnableAzureHybridBenefit]
 [-NfCsiDriverEnabled] [-SmbCsiDriverEnabled] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AutoScaling
```
Update-AzAksArcCluster -ClusterName <String> -MaxCount <Int32> -MinCount <Int32> -ResourceGroupName <String>
 -EnableAutoScaling [-SubscriptionId <String>] [-AdminGroupObjectID <String[]>]
 [-AutoScalerProfileBalanceSimilarNodeGroup <String>] [-AutoScalerProfileExpander <String>]
 [-AutoScalerProfileMaxEmptyBulkDelete <String>] [-AutoScalerProfileMaxGracefulTerminationSec <String>]
 [-AutoScalerProfileMaxNodeProvisionTime <String>] [-AutoScalerProfileMaxTotalUnreadyPercentage <String>]
 [-AutoScalerProfileNewPodScaleUpDelay <String>] [-AutoScalerProfileOkTotalUnreadyCount <String>]
 [-AutoScalerProfileScaleDownDelayAfterAdd <String>] [-AutoScalerProfileScaleDownDelayAfterDelete <String>]
 [-AutoScalerProfileScaleDownDelayAfterFailure <String>] [-AutoScalerProfileScaleDownUnneededTime <String>]
 [-AutoScalerProfileScaleDownUnreadyTime <String>] [-AutoScalerProfileScaleDownUtilizationThreshold <String>]
 [-AutoScalerProfileScanInterval <String>] [-AutoScalerProfileSkipNodesWithLocalStorage <String>]
 [-AutoScalerProfileSkipNodesWithSystemPod <String>] [-ControlPlaneCount <Int32>] [-EnableAzureHybridBenefit]
 [-NfCsiDriverEnabled] [-SmbCsiDriverEnabled] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update the provisioned cluster instance

## EXAMPLES

### Example 1: Scale up control plane count
```powershell
Update-AzAksArcCluster -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -ControlPlaneCount 3
```

Increase control plane count to 3 nodes.

### Example 2: Enable autoscaling
```powershell
Update-AzAksArcCluster -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -EnableAutoScaling -MinCount 1 -MaxCount 5
```

Enable autoscaling in provisioned cluster.

### Example 3: Enable NfCsiDriver
```powershell
Update-AzAksArcCluster -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -NfCsiDriverEnabled
```

Enable NfCsi driver in provisioned cluster.

### Example 4: Enable SmbCsiDriver
```powershell
Update-AzAksArcCluster -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -SmbCsiDriverEnabled
```

Enable SmbCsi driver in provisioned cluster.

### Example 5: Enable azure hybrid benefit
```powershell
Update-AzAksArcCluster -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -EnableAzureHybridBenefit
```

Enable Azure Hybrid User Benefits feature for a provisioned cluster.

### Example 6: Disable azure hybrid benefit
```powershell
Update-AzAksArcCluster -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -EnableAzureHybridBenefit:$false
```

Disable Azure Hybrid User Benefits feature for a provisioned cluster.

### Example 7: Disable autoscaling
```powershell
Update-AzAksArcCluster -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -EnableAutoScaling:$false
```

Disable autoscaling in provisioned cluster.

### Example 8: Disable NfCsiDriver
```powershell
Update-AzAksArcCluster -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -NfCsiDriverEnabled:$false
```

Disable NfCsi driver in provisioned cluster.

### Example 9: Disable SmbCsiDriver
```powershell
Update-AzAksArcCluster -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -SmbCsiDriverEnabled:$false
```

Disable SmbCsi driver in provisioned cluster.

### Example 10: Update aad admin GUIDS
```powershell
Update-AzAksArcCluster -ClusterName azps_test_cluster -ResourceGroupName azps_test_group -AdminGroupObjectID @("2e00cb64-66d8-4c9c-92d8-6462caf99e33", "1b28ff4f-f7c5-4aaa-aa79-ba8b775ab443")
```

Update aad admin GUIDS.

## PARAMETERS

### -AdminGroupObjectID


```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -AutoScalerProfileBalanceSimilarNodeGroup
Valid values are 'true' and 'false'

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoScalerProfileExpander
If not specified, the default is 'random'.
See [expanders](https://github.com/kubernetes/autoscaler/blob/master/cluster-autoscaler/FAQ.md#what-are-expanders) for more information.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoScalerProfileMaxEmptyBulkDelete
The default is 10.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoScalerProfileMaxGracefulTerminationSec
The default is 600.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoScalerProfileMaxNodeProvisionTime
The default is '15m'.
Values must be an integer followed by an 'm'.
No unit of time other than minutes (m) is supported.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoScalerProfileMaxTotalUnreadyPercentage
The default is 45.
The maximum is 100 and the minimum is 0.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoScalerProfileNewPodScaleUpDelay
For scenarios like burst/batch scale where you don't want CA to act before the kubernetes scheduler could schedule all the pods, you can tell CA to ignore unscheduled pods before they're a certain age.
The default is '0s'.
Values must be an integer followed by a unit ('s' for seconds, 'm' for minutes, 'h' for hours, etc).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoScalerProfileOkTotalUnreadyCount
This must be an integer.
The default is 3.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoScalerProfileScaleDownDelayAfterAdd
The default is '10m'.
Values must be an integer followed by an 'm'.
No unit of time other than minutes (m) is supported.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoScalerProfileScaleDownDelayAfterDelete
The default is the scan-interval.
Values must be an integer followed by an 'm'.
No unit of time other than minutes (m) is supported.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoScalerProfileScaleDownDelayAfterFailure
The default is '3m'.
Values must be an integer followed by an 'm'.
No unit of time other than minutes (m) is supported.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoScalerProfileScaleDownUnneededTime
The default is '10m'.
Values must be an integer followed by an 'm'.
No unit of time other than minutes (m) is supported.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoScalerProfileScaleDownUnreadyTime
The default is '20m'.
Values must be an integer followed by an 'm'.
No unit of time other than minutes (m) is supported.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoScalerProfileScaleDownUtilizationThreshold
The default is '0.5'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoScalerProfileScanInterval
The default is '10'.
Values must be an integer number of seconds.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoScalerProfileSkipNodesWithLocalStorage
The default is true.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoScalerProfileSkipNodesWithSystemPod
The default is true.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterName
The name of the Kubernetes cluster on which get is called.

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

### -ControlPlaneCount
Number of control plane nodes.
The default value is 1, and the count should be an odd number

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableAutoScaling
Indicates whether to enable autoscalar.
The default value is true.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AutoScaling
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableAzureHybridBenefit
Indicates whether Azure Hybrid Benefit is opted in.
Default value is false

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

### -MaxCount
Max nodes in autoscalar

```yaml
Type: System.Int32
Parameter Sets: AutoScaling
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MinCount
Min nodes in autoscalar

```yaml
Type: System.Int32
Parameter Sets: AutoScaling
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NfCsiDriverEnabled
Indicates whether to enable NFS CSI Driver.
The default value is true.

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

### -SmbCsiDriverEnabled
Indicates whether to enable SMB CSI Driver.
The default value is true.

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

### -SubscriptionId
The ID of the target subscription.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AksArc.Models.IProvisionedCluster

## NOTES

## RELATED LINKS

