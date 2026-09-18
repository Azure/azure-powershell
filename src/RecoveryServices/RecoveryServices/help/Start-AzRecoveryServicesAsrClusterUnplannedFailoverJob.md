---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.SiteRecovery.dll-Help.xml
Module Name: Az.RecoveryServices
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/start-azrecoveryservicesasrclusterunplannedfailoverjob
schema: 2.0.0
---

# Start-AzRecoveryServicesAsrClusterUnplannedFailoverJob

## SYNOPSIS
Starts an unplanned failover operation for a cluster.

## SYNTAX

```
Start-AzRecoveryServicesAsrClusterUnplannedFailoverJob
 -ReplicationProtectionCluster <ASRReplicationProtectionCluster> -Direction <String> [-PerformSourceSideAction]
 [-LatestProcessedRecoveryPoint] [-ClusterRecoveryPoint <ASRClusterRecoveryPoint>]
 [-ListNodeRecoveryPoint <System.Collections.Generic.List`1[System.String]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Start-AzRecoveryServicesAsrClusterUnplannedFailoverJob** cmdlet starts unplanned failover of an Azure Site Recovery replication protection cluster.
You can check whether the job succeeded by using the Get-AzRecoveryServicesAsrJob cmdlet.

## EXAMPLES

### Example 1
```powershell
$currentJob = Start-AzRecoveryServicesAsrClusterUnplannedFailoverJob -ReplicationProtectionCluster $protectionCluster -Direction PrimaryToRecovery -LatestProcessedRecoveryPoint
```

Starts a unplanned failover operation for the specified cluster. If LatestProcessedRecoveryPoint is passed and no specific recovery point is provided, it will pick the latest processed recovery points and the ASR job used to track the operation.

### Example 2
```powershell
$currentJob = Start-AzRecoveryServicesAsrClusterUnplannedFailoverJob -ReplicationProtectionCluster $protectionCluster -Direction PrimaryToRecovery -ClusterRecoveryPoint $clusterRecoveryPoint -ListNodeRecoveryPoint $nodeRecoveryPoints
```

Starts a unplanned failover operation for the specified cluster and by passing ClusterRecoveryPoint and NodeRecoveryPoints, it will pick the specified recovery points and returns the ASR job used to track the operation.

## PARAMETERS

### -ClusterRecoveryPoint
Specifies the recovery point for the cluster.

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRClusterRecoveryPoint
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Direction
Specifies the failover direction.
The acceptable values for this parameter are:

- PrimaryToRecovery
- RecoveryToPrimary

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: PrimaryToRecovery, RecoveryToPrimary

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LatestProcessedRecoveryPoint
Fetch the latest processed recovery points if not passed for cluster or any individual node.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: LatestProcessedRecoveryPoint

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ListNodeRecoveryPoint
Specifies the recovery points for the nodes which are not part of cluster recovery point.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PerformSourceSideAction
Perform operation in source side before starting unplanned failover.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: PerformSourceSideActions

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplicationProtectionCluster
Specifies the replication protection cluster.

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRReplicationProtectionCluster
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRReplicationProtectionCluster

## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRJob

## NOTES

## RELATED LINKS
