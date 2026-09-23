---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Backup.dll-Help.xml
Module Name: Az.RecoveryServices
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/undo-azrecoveryservicesbackupcontainerdeletion
schema: 2.0.0
---

# Undo-AzRecoveryServicesBackupContainerDeletion

## SYNOPSIS
Undeletes a previously soft-deleted backup container in a recovery services vault.

## SYNTAX

```
Undo-AzRecoveryServicesBackupContainerDeletion [-Container] <ContainerBase>
 [-BackupManagementType] <BackupManagementType> [-WorkloadType] <WorkloadType> [-Force] [-VaultId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The Undo-AzRecoveryServicesBackupContainerDeletion cmdlet restores a soft-deleted container to a state where it is no longer marked for deferred deletion and is ready for re-registration.

## EXAMPLES

### Example 1
```powershell
$container = Get-AzRecoveryServicesBackupContainer -ResourceGroupName $resourceGroupName -VaultId $vault.ID -BackupManagementType AzureWorkload -ContainerType AzureVMAppContainer | Where-Object { $_.Name -match $containerName}
Undo-AzRecoveryServicesBackupContainerDeletion -Container $container[0] -BackupManagementType AzureWorkload -WorkloadType MSSQL -VaultId $vault.ID -Force -Confirm:$false
```

```output
Name											ResourceGroupName        Status               ContainerType        WorkloadsPresent     HealthStatus
----											-----------------        ------               -------------        ----------------     ------------
VMAppContainer;Compute;rgname;contianerName		rgname                   SoftDeleted          AzureVMAppContainer  SQL                  Healthy
```

This example retrieves a backup container named `$containerName` from a specified resource group and vault, and then undeletes the soft-deleted container for an MSSQL workload. The `-Force` parameter is used to bypass the confirmation prompt, and `-Confirm:$false` ensures the cmdlet runs without additional confirmation.

## PARAMETERS

### -BackupManagementType
The class of resources being protected.
Currently the values supported for this cmdlet are

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.BackupManagementType
Parameter Sets: (All)
Aliases:
Accepted values: AzureVM, AzureWorkload, AzureStorage

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Container
Container where the item resides

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.ContainerBase
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -Force
Force registers container (prevents confirmation dialog).
This parameter is optional.

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

### -VaultId
ARM ID of the Recovery Services Vault.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WorkloadType
Workload type of the resource.
The current supported values are

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType
Parameter Sets: (All)
Aliases:
Accepted values: AzureVM, AzureFiles, MSSQL, SAPHanaDatabase

Required: True
Position: 2
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

### Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.ContainerBase

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.ContainerBase

## NOTES

## RELATED LINKS
