---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/invoke-azhdinsightonaksclustermanualrollback
schema: 2.0.0
---

# Invoke-AzHdInsightOnAksClusterManualRollback

## SYNOPSIS
Manual rollback upgrade for a cluster.

## SYNTAX

### UpgradeExpanded (Default)
```
Invoke-AzHdInsightOnAksClusterManualRollback -ClusterName <String> -ClusterPoolName <String>
 -ResourceGroupName <String> -UpgradeHistory <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Upgrade
```
Invoke-AzHdInsightOnAksClusterManualRollback -ClusterName <String> -ClusterPoolName <String>
 -ResourceGroupName <String> -ClusterRollbackUpgradeRequest <IClusterUpgradeRollback>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpgradeViaIdentity
```
Invoke-AzHdInsightOnAksClusterManualRollback -InputObject <IHdInsightOnAksIdentity>
 -ClusterRollbackUpgradeRequest <IClusterUpgradeRollback> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpgradeViaIdentityClusterpool
```
Invoke-AzHdInsightOnAksClusterManualRollback -ClusterName <String>
 -ClusterpoolInputObject <IHdInsightOnAksIdentity> -ClusterRollbackUpgradeRequest <IClusterUpgradeRollback>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpgradeViaIdentityClusterpoolExpanded
```
Invoke-AzHdInsightOnAksClusterManualRollback -ClusterName <String>
 -ClusterpoolInputObject <IHdInsightOnAksIdentity> -UpgradeHistory <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpgradeViaIdentityExpanded
```
Invoke-AzHdInsightOnAksClusterManualRollback -InputObject <IHdInsightOnAksIdentity> -UpgradeHistory <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpgradeViaJsonFilePath
```
Invoke-AzHdInsightOnAksClusterManualRollback -ClusterName <String> -ClusterPoolName <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpgradeViaJsonString
```
Invoke-AzHdInsightOnAksClusterManualRollback -ClusterName <String> -ClusterPoolName <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Manual rollback upgrade for a cluster.

## EXAMPLES

### Example 1: Roll back the upgrade of a cluster
```powershell
$clusterResourceGroupName = "Group"
$clusterpoolName = "ps-test-pool"
$clusterName = "cluster"
Invoke-AzHdInsightOnAksClusterManualRollback -ResourceGroupName $clusterResourceGroupName -ClusterName $clusterName -ClusterPoolName $clusterpoolName -UpgradeHistory /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/devrp/providers/Microsoft.HDInsight/clusterpools/pool/clusters/cluster202458152055/upgradeHistories/05_11_2024_06_41_26_AM-AKSPatchUpgrade
```

Roll back the upgrade of a cluster

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

### -ClusterName
The name of the HDInsight cluster.

```yaml
Type: System.String
Parameter Sets: Upgrade, UpgradeExpanded, UpgradeViaIdentityClusterpool, UpgradeViaIdentityClusterpoolExpanded, UpgradeViaJsonFilePath, UpgradeViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterpoolInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHdInsightOnAksIdentity
Parameter Sets: UpgradeViaIdentityClusterpool, UpgradeViaIdentityClusterpoolExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterPoolName
The name of the cluster pool.

```yaml
Type: System.String
Parameter Sets: Upgrade, UpgradeExpanded, UpgradeViaJsonFilePath, UpgradeViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterRollbackUpgradeRequest
Cluster Upgrade.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterUpgradeRollback
Parameter Sets: Upgrade, UpgradeViaIdentity, UpgradeViaIdentityClusterpool
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
Parameter Sets: UpgradeViaIdentity, UpgradeViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Upgrade operation

```yaml
Type: System.String
Parameter Sets: UpgradeViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Upgrade operation

```yaml
Type: System.String
Parameter Sets: UpgradeViaJsonString
Aliases:

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Upgrade, UpgradeExpanded, UpgradeViaJsonFilePath, UpgradeViaJsonString
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
Parameter Sets: Upgrade, UpgradeExpanded, UpgradeViaJsonFilePath, UpgradeViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpgradeHistory
A specific upgrade history to rollback

```yaml
Type: System.String
Parameter Sets: UpgradeExpanded, UpgradeViaIdentityClusterpoolExpanded, UpgradeViaIdentityExpanded
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterUpgradeRollback

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHdInsightOnAksIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ICluster

## NOTES

## RELATED LINKS

