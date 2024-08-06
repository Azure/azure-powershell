---
external help file: Az.HdInsightOnAks-help.xml
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/az.hdinsightonaks/invoke-azhdinsightonaksclusterupgrade
schema: 2.0.0
---

# Invoke-AzHdInsightOnAksClusterUpgrade

## SYNOPSIS
Upgrade a cluster.

## SYNTAX

### UpgradeExpanded (Default)
```
Invoke-AzHdInsightOnAksClusterUpgrade -Name <String> -PoolName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -UpgradeType <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpgradeViaJsonString
```
Invoke-AzHdInsightOnAksClusterUpgrade -Name <String> -PoolName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpgradeViaJsonFilePath
```
Invoke-AzHdInsightOnAksClusterUpgrade -Name <String> -PoolName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpgradeViaIdentityClusterpoolExpanded
```
Invoke-AzHdInsightOnAksClusterUpgrade -Name <String> -ClusterpoolInputObject <IHdInsightOnAksIdentity>
 -UpgradeType <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpgradeViaIdentityClusterpool
```
Invoke-AzHdInsightOnAksClusterUpgrade -Name <String> -ClusterpoolInputObject <IHdInsightOnAksIdentity>
 -ClusterUpgradeRequest <IClusterUpgrade> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Upgrade
```
Invoke-AzHdInsightOnAksClusterUpgrade -Name <String> -PoolName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -ClusterUpgradeRequest <IClusterUpgrade> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpgradeViaIdentityExpanded
```
Invoke-AzHdInsightOnAksClusterUpgrade -InputObject <IHdInsightOnAksIdentity> -UpgradeType <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpgradeViaIdentity
```
Invoke-AzHdInsightOnAksClusterUpgrade -InputObject <IHdInsightOnAksIdentity>
 -ClusterUpgradeRequest <IClusterUpgrade> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Upgrade a cluster.

## EXAMPLES

### Example 1: Upgrade a cluster.
```powershell
$clusterResourceGroupName = "Group"
$clusterpoolName = "ps-test-pool"
$clusterName = "flinkcluster"
$hotfixObj = New-AzHdInsightOnAksClusterHotfixUpgradeObject -ComponentName Webssh -TargetBuildNumber 7 -TargetClusterVersion "1.1.1" -TargetOssVersion "0.4.2"
Invoke-AzHdInsightOnAksClusterUpgrade -ResourceGroupName $clusterResourceGroupName -ClusterName $clusterName -ClusterPoolName $clusterpoolName -ClusterUpgradeRequest $hotfixObj
```

```output
AccessProfileEnableInternalIngress          : False
AccessProfilePrivateLinkServiceId           : 
ApplicationLogStdErrorEnabled               : 
ApplicationLogStdOutEnabled                 : 
AuthorizationProfileGroupId                 : 
AuthorizationProfileUserId                  : 
AutoscaleProfileAutoscaleType               : 
AutoscaleProfileEnabled                     : False
AutoscaleProfileGracefulDecommissionTimeout : 
ClusterType                                 : 
ComputeProfileNode                          : 
ConnectivityEndpointBootstrapServerEndpoint : 
ConnectivityEndpointBrokerEndpoint          : 
ConnectivityProfileSsh                      : 
CoordinatorDebugEnable                      : 
CoordinatorDebugPort                        : 
CoordinatorDebugSuspend                     : 
CoordinatorHighAvailabilityEnabled          : 
DatabaseHost                                : 
DatabaseName                                : 
DatabasePasswordSecretRef                   : 
DatabaseUsername                            : 
DeploymentId                                : 
DiskStorageDataDiskSize                     : 0
...
```

Upgrade a cluster with type HotFix.

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
Parameter Sets: UpgradeViaIdentityClusterpoolExpanded, UpgradeViaIdentityClusterpool
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterUpgradeRequest
Cluster Upgrade.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterUpgrade
Parameter Sets: UpgradeViaIdentityClusterpool, Upgrade, UpgradeViaIdentity
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
Parameter Sets: UpgradeViaIdentityExpanded, UpgradeViaIdentity
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

### -Name
The name of the HDInsight cluster.

```yaml
Type: System.String
Parameter Sets: UpgradeExpanded, UpgradeViaJsonString, UpgradeViaJsonFilePath, UpgradeViaIdentityClusterpoolExpanded, UpgradeViaIdentityClusterpool, Upgrade
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
Parameter Sets: UpgradeExpanded, UpgradeViaJsonString, UpgradeViaJsonFilePath, Upgrade
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
Parameter Sets: UpgradeExpanded, UpgradeViaJsonString, UpgradeViaJsonFilePath, Upgrade
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
Parameter Sets: UpgradeExpanded, UpgradeViaJsonString, UpgradeViaJsonFilePath, Upgrade
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpgradeType
Type of upgrade.

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

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterUpgrade

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IHdInsightOnAksIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.ICluster

## NOTES

## RELATED LINKS
