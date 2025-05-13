---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.SiteRecovery.dll-Help.xml
Module Name: Az.RecoveryServices
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/get-azrecoveryservicesasrreplicationprotectioncluster
schema: 2.0.0
---

# Get-AzRecoveryServicesAsrReplicationProtectionCluster

## SYNOPSIS
Gets a replication protection cluster or all the replication protection clusters in a protection container or all the replication protection clusters in the Recovery Services vault

## SYNTAX

### Default (Default)
```
Get-AzRecoveryServicesAsrReplicationProtectionCluster [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByObjectWithName
```
Get-AzRecoveryServicesAsrReplicationProtectionCluster -Name <String>
 -ProtectionContainer <ASRProtectionContainer> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByObject
```
Get-AzRecoveryServicesAsrReplicationProtectionCluster -ProtectionContainer <ASRProtectionContainer>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzRecoveryServicesAsrReplicationProtectionCluster** cmdlet gets the details of the specified replication protection cluster or all the replication protection clusters in a protection container or all the replication protection clusters in the Recovery Services vault.

## EXAMPLES

### Example 1
```powershell
Get-AzRecoveryServicesAsrReplicationProtectionCluster -Name $ClusterName -ProtectionContainer $ProtectionContainer
```

Gets the replication protection cluster with the specified name.

### Example 2
```powershell
Get-AzRecoveryServicesAsrReplicationProtectionCluster -ProtectionContainer $ProtectionContainer
```

Gets the replication protection cluster in a protection container.

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
Specifies the name of the replication protection cluster to get.

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

### -ProtectionContainer
Specifies the Azure Site Recovery protection container object.

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRProtectionContainer
Parameter Sets: ByObjectWithName, ByObject
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

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRProtectionContainer

## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRReplicationProtectionCluster

## NOTES

## RELATED LINKS
