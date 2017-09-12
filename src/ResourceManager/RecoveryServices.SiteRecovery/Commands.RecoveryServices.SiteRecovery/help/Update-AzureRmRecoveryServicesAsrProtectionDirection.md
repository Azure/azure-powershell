---
external help file: Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.dll-Help.xml
Module Name: AzureRM.RecoveryServices.SiteRecovery
online version: 
schema: 2.0.0
---

# Update-AzureRmRecoveryServicesAsrProtectionDirection

## SYNOPSIS
Updates the replication direction for the specified replication protected item or recovery plan. Used to re-protect/reverse replicate a failed over replicated item or recovery plan.

## SYNTAX

### ByRPIObject (Default)
```
Update-AzureRmRecoveryServicesAsrProtectionDirection -ReplicationProtectedItem <ASRReplicationProtectedItem>
 -Direction <String> [-WhatIf] [-Confirm] [<CommonParameters>]
```

### VMwareToAzureRPI
```
Update-AzureRmRecoveryServicesAsrProtectionDirection [-Account <ASRRunAsAccount>] -DataStore <ASRDataStore>
 [-MasterTarget <ASRMasterTargetServer>] -ProcessServer <ASRProcessServer>
 -ProtectionContainerMapping <ASRProtectionContainerMapping>
 -ReplicationProtectedItem <ASRReplicationProtectedItem> -Direction <String>
 -RetentionVolume <ASRRetentionVolume> [-WhatIf] [-Confirm] [<CommonParameters>]
```

### VMwareToVMwareRPI
```
Update-AzureRmRecoveryServicesAsrProtectionDirection -Account <ASRRunAsAccount>
 -ProcessServer <ASRProcessServer> -ProtectionContainerMapping <ASRProtectionContainerMapping>
 [-LogStorageAccountId <String>] [-RecoveryAzureStorageAccountId <String>]
 -ReplicationProtectedItem <ASRReplicationProtectedItem> -Direction <String> [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByRPObject
```
Update-AzureRmRecoveryServicesAsrProtectionDirection -RecoveryPlan <ASRRecoveryPlan> -Direction <String>
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzureRmRecoveryServicesAsrProtectionDirection** cmdlet updates the replication direction for the specified Azure Site Recovery object after the completion of a commit failover operation.

## EXAMPLES

### Example 1
```
PS C:\> $currentJob = Update-AzureRmRecoveryServicesAsrProtectionDirection -RecoveryPlan $RP -Direction PrimaryToRecovery
```

Start the update direction operation for the specified recoveyr plan and returns the ASR job object used to track the operation.

## PARAMETERS

### -Account
The run as account to be used to push install the Mobility service if needed. Must be one from the list of run as accounts in the ASR fabric.

```yaml
Type: ASRRunAsAccount
Parameter Sets: VMwareToAzureRPI
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: ASRRunAsAccount
Parameter Sets: VMwareToVMwareRPI
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataStore
The VMware datastore to be used for the vmdk's

```yaml
Type: ASRDataStore
Parameter Sets: VMwareToAzureRPI
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Direction
Specifies the direction to be used for the update operation post a failover.  
The acceptable values for this parameter are:

- PrimaryToRecovery
- RecoveryToPrimary

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: PrimaryToRecovery, RecoveryToPrimary

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogStorageAccountId
Vm log azure storage account Id.

```yaml
Type: String
Parameter Sets: VMwareToVMwareRPI
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MasterTarget
Master Target Server Details.

```yaml
Type: ASRMasterTargetServer
Parameter Sets: VMwareToAzureRPI
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProcessServer
Process Sever to be used for replication.

```yaml
Type: ASRProcessServer
Parameter Sets: VMwareToAzureRPI, VMwareToVMwareRPI
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProtectionContainerMapping
Protection containerMapping to be used for replication.

```yaml
Type: ASRProtectionContainerMapping
Parameter Sets: VMwareToAzureRPI, VMwareToVMwareRPI
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryAzureStorageAccountId
Recovery Azure Storage AccountId.

```yaml
Type: String
Parameter Sets: VMwareToVMwareRPI
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryPlan
Specifies an ASR recovery plan object.

```yaml
Type: ASRRecoveryPlan
Parameter Sets: ByRPObject
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ReplicationProtectedItem
Specifies an ASR replication protected item

```yaml
Type: ASRReplicationProtectedItem
Parameter Sets: ByRPIObject, VMwareToAzureRPI, VMwareToVMwareRPI
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RetentionVolume
Retention Volume on the master target server to be used.

```yaml
Type: ASRRetentionVolume
Parameter Sets: VMwareToAzureRPI
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRRecoveryPlan
Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRReplicationProtectedItem

## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRJob

## NOTES

## RELATED LINKS

