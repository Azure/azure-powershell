---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/invoke-aznetworkcloudclustercontinueversionupdate
schema: 2.0.0
---

# Invoke-AzNetworkCloudClusterContinueVersionUpdate

## SYNOPSIS
Trigger the continuation of an update for a cluster with a matching update strategy that has paused after completing a segment of the update.

## SYNTAX

### ContinueExpanded (Default)
```
Invoke-AzNetworkCloudClusterContinueVersionUpdate -ClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>]
 [-MachineGroupTargetingMode <ClusterContinueUpdateVersionMachineGroupTargetingMode>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Continue
```
Invoke-AzNetworkCloudClusterContinueVersionUpdate -ClusterName <String> -ResourceGroupName <String>
 -ClusterContinueUpdateVersionParameter <IClusterContinueUpdateVersionParameters> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ContinueViaIdentity
```
Invoke-AzNetworkCloudClusterContinueVersionUpdate -InputObject <INetworkCloudIdentity>
 -ClusterContinueUpdateVersionParameter <IClusterContinueUpdateVersionParameters> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ContinueViaIdentityExpanded
```
Invoke-AzNetworkCloudClusterContinueVersionUpdate -InputObject <INetworkCloudIdentity>
 [-MachineGroupTargetingMode <ClusterContinueUpdateVersionMachineGroupTargetingMode>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Trigger the continuation of an update for a cluster with a matching update strategy that has paused after completing a segment of the update.

## EXAMPLES

### Example 1: Resume an update for a cluster with a matching update strategy that has paused after completing a segment.
```powershell
Invoke-AzNetworkCloudClusterContinueVersionUpdate -ResourceGroupName resourceGroupName -ClusterName clusterName -SubscriptionId subscriptionId -MachineGroupTargetingMode "AlphaByRack"  
```

This command resumes an update for a cluster with a matching update strategy that has paused after completing a segment.

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

### -ClusterContinueUpdateVersionParameter
ClusterContinueUpdateVersionParameters represents the body of the request to continue the update of a cluster version.
To construct, see NOTES section for CLUSTERCONTINUEUPDATEVERSIONPARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IClusterContinueUpdateVersionParameters
Parameter Sets: Continue, ContinueViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterName
The name of the cluster.

```yaml
Type: System.String
Parameter Sets: Continue, ContinueExpanded
Aliases:

Required: True
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity
Parameter Sets: ContinueViaIdentity, ContinueViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MachineGroupTargetingMode
The mode by which the cluster will target the next grouping of servers to continue the update.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.ClusterContinueUpdateVersionMachineGroupTargetingMode
Parameter Sets: ContinueExpanded, ContinueViaIdentityExpanded
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

### -PassThru
Returns true when the command succeeds

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
Parameter Sets: Continue, ContinueExpanded
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
Parameter Sets: Continue, ContinueExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IClusterContinueUpdateVersionParameters

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

