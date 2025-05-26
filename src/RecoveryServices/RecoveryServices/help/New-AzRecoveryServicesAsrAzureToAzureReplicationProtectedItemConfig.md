---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.SiteRecovery.dll-Help.xml
Module Name: Az.RecoveryServices
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/new-azrecoveryservicesasrazuretoazurereplicationprotecteditemconfig
schema: 2.0.0
---

# New-AzRecoveryServicesAsrAzureToAzureReplicationProtectedItemConfig

## SYNOPSIS
Creates a replication protected item mapping object for Azure virtual machine to be replicated.

## SYNTAX

### AzureToAzureWithoutDiskDetails (Default)
```
New-AzRecoveryServicesAsrAzureToAzureReplicationProtectedItemConfig -ReplicationProtectedItemName <String>
 -RecoveryResourceGroupId <String> [-RecoveryAvailabilitySetId <String>]
 [-RecoveryBootDiagStorageAccountId <String>] [-RecoveryAvailabilityZone <String>]
 [-RecoveryProximityPlacementGroupId <String>] [-RecoveryVirtualMachineScaleSetId <String>]
 [-RecoveryCapacityReservationGroupId <String>] [-DiskEncryptionVaultId <String>]
 [-DiskEncryptionSecretUrl <String>] [-KeyEncryptionKeyUrl <String>] [-KeyEncryptionVaultId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AzureToAzure
```
New-AzRecoveryServicesAsrAzureToAzureReplicationProtectedItemConfig [-ManagedDisk]
 -ReplicationProtectedItemName <String> -RecoveryResourceGroupId <String>
 -AzureToAzureDiskReplicationConfiguration <ASRAzuretoAzureDiskReplicationConfig[]>
 [-RecoveryAvailabilitySetId <String>] [-RecoveryBootDiagStorageAccountId <String>]
 [-RecoveryAvailabilityZone <String>] [-RecoveryProximityPlacementGroupId <String>]
 [-RecoveryVirtualMachineScaleSetId <String>] [-RecoveryCapacityReservationGroupId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a protected item mapping object to get target properties (recovery region) to be used to replicate the protected item.

## EXAMPLES

### Example 1
```powershell
New-AzRecoveryServicesAsrAzureToAzureReplicationProtectedItemConfig -ReplicationProtectedItemName $rpiName1 -RecoveryResourceGroupId $rgId -RecoveryAvailabilitySetId $avset -RecoveryProximityPlacementGroupId $ppg
```

Create a replication protected item mapping object for Azure virtual machine to be replicated without disk details.
Used during Azure to Azure re-protect operation for Replication protection cluster.

### Example 2
```powershell
New-AzRecoveryServicesAsrAzureToAzureReplicationProtectedItemConfig -ManagedDisk -ReplicationProtectedItemName $rpiName2 -RecoveryResourceGroupId $rgId -AzureToAzureDiskReplicationConfiguration $disks -RecoveryAvailabilitySetId $avset -RecoveryProximityPlacementGroupId $ppg
```

Create a replication protected item mapping object for Azure virtual machine to be replicated with disk details.
Used during Azure to Azure re-protect operation for Replication protection cluster.

## PARAMETERS

### -AzureToAzureDiskReplicationConfiguration
Specifies disk config for the replication protected item.

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRAzuretoAzureDiskReplicationConfig[]
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
Parameter Sets: AzureToAzureWithoutDiskDetails
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
Parameter Sets: AzureToAzureWithoutDiskDetails
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
Parameter Sets: AzureToAzureWithoutDiskDetails
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
Parameter Sets: AzureToAzureWithoutDiskDetails
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedDisk
Specifies for input with disk details

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AzureToAzure
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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryBootDiagStorageAccountId
{{ Fill RecoveryBootDiagStorageAccountId Description }}

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

### -RecoveryCapacityReservationGroupId
Specifies the storage account for boot diagnostics for recovery azure VM.

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

### -RecoveryProximityPlacementGroupId
Specify the capacity reservation group Id to be used by the failover VM in target recovery region.

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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplicationProtectedItemName
Specifies the replication protected item name.

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

### None

## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRAzureToAzureReplicationProtectedItemConfig

## NOTES

## RELATED LINKS
