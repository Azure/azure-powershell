---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.SiteRecovery.dll-Help.xml
Module Name: Az.RecoveryServices
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/start-azrecoveryservicesasrapplyclusterrecoverypoint
schema: 2.0.0
---

# Start-AzRecoveryServicesAsrApplyClusterRecoveryPoint

## SYNOPSIS
Changes a recovery point for a failed over replication protection cluster before committing the failover operation

## SYNTAX

```
Start-AzRecoveryServicesAsrApplyClusterRecoveryPoint [-ClusterRecoveryPoint <ASRClusterRecoveryPoint>]
 -ReplicationProtectionCluster <ASRReplicationProtectionCluster>
 [-ListNodeRecoveryPoint <System.Collections.Generic.List`1[System.String]>] [-LatestProcessedRecoveryPoint]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Start-AzRecoveryServicesAsrApplyClusterRecoveryPoint** changes the recovery point for a failed over protected item before it commits the failover operation.
You can check whether the job succeeded by using the Get-AzRecoveryServicesAsrJob cmdlet.

## EXAMPLES

### Example 1
```powershell
$currentJob = Start-AzRecoveryServicesAsrApplyClusterRecoveryPoint -ReplicationProtectionCluster $protectionCluster -LatestProcessedRecoveryPoint
```

Starts applying the recovery point on specified cluster. If LatestProcessedRecoveryPoint is passed and no specific recovery point is provided, it will pick the latest processed recovery points and returns the ASR job used to track the operation.

### Example 2
```powershell
$currentJob = Start-AzRecoveryServicesAsrApplyClusterRecoveryPoint -ReplicationProtectionCluster $protectionCluster -ClusterRecoveryPoint $clusterRecoveryPoint -ListNodeRecoveryPoint $nodeRecoveryPoints
```

Starts applying the recovery point on specified cluster and by passing ClusterRecoveryPoint and NodeRecoveryPoints, it will pick the specified recovery points and returns the ASR job used to track the operation.

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
