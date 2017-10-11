---
external help file: Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.dll-Help.xml
online version: 
schema: 2.0.0
---

# New-AzureRmRecoveryServicesAsrReplicationProtectedItem

## SYNOPSIS
Enables replication for an ASR protectable item by creating a replication protected item

## SYNTAX

### DisableDR (Default)
```
New-AzureRmRecoveryServicesAsrReplicationProtectedItem [-WaitForCompletion] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### EnterpriseToEnterprise
```
New-AzureRmRecoveryServicesAsrReplicationProtectedItem -ProtectableItem <ASRProtectableItem> -Name <String>
 -ProtectionContainerMapping <ASRProtectionContainerMapping> [-WaitForCompletion] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### EnterpriseToAzure
```
New-AzureRmRecoveryServicesAsrReplicationProtectedItem -ProtectableItem <ASRProtectableItem> -Name <String>
 -ProtectionContainerMapping <ASRProtectionContainerMapping> -RecoveryAzureStorageAccountId <String>
 -RecoveryResourceGroupId <String> [-WaitForCompletion] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### HyperVSiteToAzure
```
New-AzureRmRecoveryServicesAsrReplicationProtectedItem -ProtectableItem <ASRProtectableItem> -Name <String>
 -ProtectionContainerMapping <ASRProtectionContainerMapping> -RecoveryAzureStorageAccountId <String>
 -OSDiskName <String> -OS <String> -RecoveryResourceGroupId <String> [-WaitForCompletion] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmRecoveryServicesAsrReplicationProtectedItem** cmdlet creates a new replication protected item.
Use this cmdlet to enable replication for an ASR protectable item.

## EXAMPLES

### Example 1
```
PS C:\> $currentJob = New-AzureRmRecoveryServicesAsrReplicationProtectedItem -ProtectableItem $VM -Name $VM.Name -ProtectionContainerMapping $ProtectionContainerMapping
```

Starts the replication protected item creation operation for the specified ASR protectable item and returns the ASR job used to track the operation.

## PARAMETERS

### -Name
Specifies a name for the ASR replication protected item.

```yaml
Type: String
Parameter Sets: EnterpriseToEnterprise, EnterpriseToAzure, HyperVSiteToAzure
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OS
Specifies the operating system family.
The acceptable values for this parameter are: Windows or Linux.

```yaml
Type: String
Parameter Sets: HyperVSiteToAzure
Aliases: 
Accepted values: Windows, Linux

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSDiskName
Specifies the name of the operating system disk.

```yaml
Type: String
Parameter Sets: HyperVSiteToAzure
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProtectableItem
Specifies the ASR protectable item object for which replication is being enabled.

```yaml
Type: ASRProtectableItem
Parameter Sets: EnterpriseToEnterprise, EnterpriseToAzure, HyperVSiteToAzure
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProtectionContainerMapping
Specifies the ASR protection container mapping object corresponding to the replication policy to be used for replication.

```yaml
Type: ASRProtectionContainerMapping
Parameter Sets: EnterpriseToEnterprise, EnterpriseToAzure, HyperVSiteToAzure
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryAzureStorageAccountId
Specifies the ID of the Azure storage account to replicate to.

```yaml
Type: String
Parameter Sets: EnterpriseToAzure, HyperVSiteToAzure
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryResourceGroupId
Specifies the ARM identifier of the resource group in which the virtual machine will be created in the event of a failover.

```yaml
Type: String
Parameter Sets: EnterpriseToAzure, HyperVSiteToAzure
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WaitForCompletion
Specifies that the cmdlet should wait for completion of the operation before returning.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts  for confirmation before starting the operation.

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

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRProtectableItem

## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRJob

## NOTES

## RELATED LINKS

[Get-AzureRmRecoveryServicesAsrReplicationProtectedItem](./Get-AzureRmRecoveryServicesAsrReplicationProtectedItem.md)

[Remove-AzureRmRecoveryServicesAsrReplicationProtectedItem](./Remove-AzureRmRecoveryServicesAsrReplicationProtectedItem.md)

[Set-AzureRmRecoveryServicesAsrReplicationProtectedItem](./Set-AzureRmRecoveryServicesAsrReplicationProtectedItem.md)
