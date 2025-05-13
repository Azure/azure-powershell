---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.SiteRecovery.dll-Help.xml
Module Name: Az.RecoveryServices
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/update-azrecoveryservicesasrclusterprotectiondirection
schema: 2.0.0
---

# Update-AzRecoveryServicesAsrClusterProtectionDirection

## SYNOPSIS
Updates the replication direction for the specified replication protection cluster.
Used to re-protect/reverse replicate a failed over replication protection cluster.

## SYNTAX

### AzureToAzureWithoutProtectedItemDetails (Default)
```
Update-AzRecoveryServicesAsrClusterProtectionDirection [-AzureToAzure]
 -ProtectionContainerMapping <ASRProtectionContainerMapping>
 -ReplicationProtectionCluster <ASRReplicationProtectionCluster> -RecoveryResourceGroupId <String>
 [-RecoveryAvailabilitySetId <String>] [-RecoveryProximityPlacementGroupId <String>]
 [-RecoveryVirtualMachineScaleSetId <String>] [-RecoveryCapacityReservationGroupId <String>]
 [-RecoveryBootDiagStorageAccountId <String>] [-RecoveryAvailabilityZone <String>]
 -LogStorageAccountId <String> [-DiskEncryptionVaultId <String>] [-DiskEncryptionSecretUrl <String>]
 [-KeyEncryptionKeyUrl <String>] [-KeyEncryptionVaultId <String>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AzureToAzure
```
Update-AzRecoveryServicesAsrClusterProtectionDirection [-AzureToAzure]
 -ProtectionContainerMapping <ASRProtectionContainerMapping>
 -AzureToAzureReplicationProtectedItemConfig <ASRAzureToAzureReplicationProtectedItemConfig[]>
 -ReplicationProtectionCluster <ASRReplicationProtectionCluster> -RecoveryResourceGroupId <String>
 -LogStorageAccountId <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzRecoveryServicesAsrClusterProtectionDirection** cmdlet updates the replication direction for the specified Azure Site Recovery protection cluster object after the completion of a commit failover operation.

## EXAMPLES

### Example 1
```powershell
Update-AzRecoveryServicesAsrClusterProtectionDirection -AzureToAzure -ReplicationProtectionCluster $cluster -RecoveryProximityPlacementGroupId $ppg -RecoveryAvailabilitySetId $avset -RecoveryResourceGroupId $rgId -LogStorageAccountId $storage -ProtectionContainerMapping $recoverypcm
```


Start the update direction operation for the specified replication protection cluster in target azure region defined by protection container mapping without protected item replication configuration.

### Example 2
```powershell
Update-AzRecoveryServicesAsrClusterProtectionDirection -AzureToAzure -ReplicationProtectionCluster $cluster -AzureToAzureReplicationProtectedItemConfig $rpis -LogStorageAccountId $storage -ProtectionContainerMapping $recoverypcm -RecoveryResourceGroupId $rgId
```


Start the update direction operation for the specified replication protection cluster in target azure region defined by protection container mapping with protected item replication configuration.

## PARAMETERS

### -AzureToAzure
Specifies the Azure to Azure disaster recovery.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureToAzureReplicationProtectedItemConfig
Specifies the list of all replication protected items available in protection cluster.

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRAzureToAzureReplicationProtectedItemConfig[]
Parameter Sets: AzureToAzure
Aliases:

Required: True
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

### -DiskEncryptionSecretUrl
Specifies the disk encryption secret URL(Azure disk encryption) to be used be recovery VM after failover.

```yaml
Type: System.String
Parameter Sets: AzureToAzureWithoutProtectedItemDetails
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiskEncryptionVaultId
Specifies the disk encryption secret key vault ID(Azure disk encryption) to be used be recovery VM after failover.

```yaml
Type: System.String
Parameter Sets: AzureToAzureWithoutProtectedItemDetails
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyEncryptionKeyUrl
Specifies the disk encryption secret key URL(Azure disk encryption) to be used be recovery VM after failover.

```yaml
Type: System.String
Parameter Sets: AzureToAzureWithoutProtectedItemDetails
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyEncryptionVaultId
Specifies the disk encryption secret key vault ID(Azure disk encryption) to be used be recovery VM after failover.

```yaml
Type: System.String
Parameter Sets: AzureToAzureWithoutProtectedItemDetails
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogStorageAccountId
Specifies the storage account ID to store the replication log of VMs.

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

### -ProtectionContainerMapping
Protection container Mapping to be used for replication.

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRProtectionContainerMapping
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryAvailabilitySetId
The availability set that the virtual machine should be created in upon failover

```yaml
Type: System.String
Parameter Sets: AzureToAzureWithoutProtectedItemDetails
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryAvailabilityZone
The availability zone that the virtual machine should be created in upon failover

```yaml
Type: System.String
Parameter Sets: AzureToAzureWithoutProtectedItemDetails
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryBootDiagStorageAccountId
Specifies the storage account for boot diagnostics for recovery azure VM.

```yaml
Type: System.String
Parameter Sets: AzureToAzureWithoutProtectedItemDetails
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryCapacityReservationGroupId
Specify the capacity reservation group Id to be used by the failover VM in target recovery region.

```yaml
Type: System.String
Parameter Sets: AzureToAzureWithoutProtectedItemDetails
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryProximityPlacementGroupId
The resource ID of the recovery proximity placement group to failover this virtual machine to.

```yaml
Type: System.String
Parameter Sets: AzureToAzureWithoutProtectedItemDetails
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryResourceGroupId
Recovery resourceGroup id for protected Vm.

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

### -RecoveryVirtualMachineScaleSetId
Specifies the reccovery virtual machine scale set id.

```yaml
Type: System.String
Parameter Sets: AzureToAzureWithoutProtectedItemDetails
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplicationProtectionCluster
Specifies the replication protection cluster object.

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
