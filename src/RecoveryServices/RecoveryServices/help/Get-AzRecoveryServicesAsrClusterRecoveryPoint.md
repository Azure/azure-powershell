---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.SiteRecovery.dll-Help.xml
Module Name: Az.RecoveryServices
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/get-azrecoveryservicesasrclusterrecoverypoint
schema: 2.0.0
---

# Get-AzRecoveryServicesAsrClusterRecoveryPoint

## SYNOPSIS
Gets the available cluster recovery points for a replication protection cluster.

## SYNTAX

### ByObject (Default)
```
Get-AzRecoveryServicesAsrClusterRecoveryPoint -ReplicationProtectionCluster <ASRReplicationProtectionCluster>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByObjectWithName
```
Get-AzRecoveryServicesAsrClusterRecoveryPoint -Name <String>
 -ReplicationProtectionCluster <ASRReplicationProtectionCluster> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzRecoveryServicesAsrClusterRecoveryPoint** cmdlet gets the list of available cluster recovery points for a replication protection cluster. The list is in order from latest to oldest Recovery Points, the first one being the Latest Processed (lowest RTO).

## EXAMPLES

### Example 1
```powershell
$ClusterRecoveryPoints = Get-AzRecoveryServicesAsrClusterRecoveryPoint -ReplicationProtectionCluster $ReplicationProtectionCluster
```

Gets cluster recovery points for the specified ASR replication protection cluster

## PARAMETERS

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

### -Name
Specifies the name of the cluster recovery point to get.

```yaml
Type: System.String
Parameter Sets: ByObjectWithName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplicationProtectionCluster
Specifies the Azure Site Recovery Replication Protection Cluster object for which to get the list of available cluster recovery points.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRReplicationProtectionCluster

## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRClusterRecoveryPoint

## NOTES

## RELATED LINKS
