---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.SiteRecovery.dll-Help.xml
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/new-azrecoveryservicesasrinmagercmdiskinput
schema: 2.0.0
---

# New-AzRecoveryServicesAsrInMageRcmDiskInput

## SYNOPSIS
Creates Azure Site Recovery Disk replication configuration for VMware To Azure replication.

## SYNTAX

```
New-AzRecoveryServicesAsrInMageRcmDiskInput -DiskId <String> -LogStorageAccountId <String> -DiskType <String>
 [-DiskEncryptionSetId <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a disk mapping object that maps an VMware virtual machine disk to the cache storage account and target managed disk type (recovery region) to be used to replicate the disk.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzRecoveryServicesAsrInMageRcmDiskInput -DiskId $diskId -LogStorageAccountId $logStorageAccountId -DiskType $diskType -DiskEncryptionSetId $diskEncryptionSetId

DiskId				: 6000C296-91a1-f649-6714-a02903020cbc
LogStorageAccountId	: /subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourceGroups/xxxxxxxxxxxx/providers/Microsoft.Storage/storageAccounts/xxxxxxxxxxxx
DiskType			: Standard_LRS
DiskEncryptionSetId	: 8010C296-91a1-a639-6714-a02903020cbc
```

Create a disk mapping object for VMware virtual machine disks to be replicated. Used during enable protection for VMware machine.

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

### -DiskEncryptionSetId
Specifies the disk encryption set ARM Id.

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

### -DiskId
Specify the DiskId of the disk that this mapping corresponds to.

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

### -DiskType
Specifies the Recovery disk type.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Standard_LRS, Premium_LRS, StandardSSD_LRS

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogStorageAccountId
Specifies the log or cache storage account Id to be used to store replication logs.

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

### Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRInMageRcmDiskInput

## NOTES

## RELATED LINKS
