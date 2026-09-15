---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Backup.dll-Help.xml
Module Name: Az.RecoveryServices
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/register-azrecoveryservicesbackupcontainer
schema: 2.0.0
---

# Register-AzRecoveryServicesBackupContainer

## SYNOPSIS
The **Register-AzRecoveryServicesBackupContainer** cmdlet registers Azure workload and Azure Storage backup containers with a Recovery Services vault.

## SYNTAX

### Register (Default)
```
Register-AzRecoveryServicesBackupContainer [-ResourceId] <String>
 [-BackupManagementType] <BackupManagementType> [-WorkloadType] <WorkloadType> [-Force] [-VaultId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ReRegister
```
Register-AzRecoveryServicesBackupContainer [-Container] <ContainerBase>
 [-BackupManagementType] <BackupManagementType> [-WorkloadType] <WorkloadType> [-Force] [-VaultId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AzureFileRegister
```
Register-AzRecoveryServicesBackupContainer [-StorageAccountName] <String>
 [-BackupManagementType] <BackupManagementType> [-WorkloadType] <WorkloadType> [-AccessType <String>]
 [-IsSystemAssignedIdentity] [-UserAssignedIdentityArmUrl <String>] [-Force] [-VaultId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This command allows Azure Backup to convert the resource to a Backup Container that is registered to the specified Recovery Services vault. It supports Azure workload containers and Azure Storage containers used for Azure File Share backup. An Azure Storage container can use shared-key or managed identity access.

## EXAMPLES

### Example 1 Register a backup container
```powershell
Register-AzRecoveryServicesBackupContainer -ResourceId <AzureVMID> -VaultId <vaultID> -WorkloadType MSSQL -BackupManagementType AzureWorkload
```

The cmdlet registers an azure VM as a container for the workload MSSQL.

### Example 2 Re-register a backup container
```powershell
$vault = Get-AzRecoveryServicesVault -ResourceGroupName "rgName"  -Name "vaultName"
$container = Get-AzRecoveryServicesBackupContainer -ContainerType AzureVMAppContainer -VaultId $vault.ID 
Register-AzRecoveryServicesBackupContainer -Container $container[-1] -BackupManagementType AzureWorkload -WorkloadType MSSQL -VaultId $vault.ID
```

The first command fetches the recovery services vault. The second command fetches all the backup containers registered with the recovery services vault. The third command triggers a re-register operation for the container $container[-1], to re-register an already registered container we pass -Container parameter.

### Example 3: Register an Azure Storage account by using a user-assigned managed identity
```powershell
$vault = Get-AzRecoveryServicesVault -ResourceGroupName "vaultResourceGroup" -Name "vaultName"
$identityId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/identityResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/backupIdentity"
Register-AzRecoveryServicesBackupContainer -StorageAccountName "storageAccountName" -BackupManagementType AzureStorage -WorkloadType AzureFiles -AccessType IdentityBased -UserAssignedIdentityArmUrl $identityId -VaultId $vault.ID
```

This example registers an Azure Storage account for Azure File Share backup using a user-assigned managed identity. If the account is already registered with a different access type or identity, the cmdlet requests confirmation. Specify **-Force** to skip that confirmation.

## PARAMETERS

### -AccessType
Specifies how Azure Backup accesses an Azure Storage account. Use `KeyBased` for shared-key access or `IdentityBased` for managed identity access.

```yaml
Type: System.String
Parameter Sets: AzureFileRegister
Aliases:
Accepted values: KeyBased, IdentityBased

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackupManagementType
The class of resources being protected. Supported values are AzureWorkload and AzureStorage.

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.BackupManagementType
Parameter Sets: (All)
Aliases:
Accepted values: AzureWorkload, AzureStorage

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
Parameter Sets: ReRegister
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
Skips the confirmation dialog when registering or re-registering a container.

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

### -IsSystemAssignedIdentity
Indicates that Azure Backup uses the Recovery Services vault's system-assigned managed identity to access the storage account.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AzureFileRegister
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
ID of the Azure Resource whose representative item needs to be checked if it is already protected by some RecoveryServices Vault in the subscription.

```yaml
Type: System.String
Parameter Sets: Register
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountName
Specifies the name of the Azure Storage account to register for Azure File Share backup.

```yaml
Type: System.String
Parameter Sets: AzureFileRegister
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentityArmUrl
Specifies the ARM resource ID of the user-assigned managed identity that Azure Backup uses to access the storage account.

```yaml
Type: System.String
Parameter Sets: AzureFileRegister
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
Workload type of the resource. The current supported value is AzureVM, WindowsServer, AzureFiles, MSSQL

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.WorkloadType
Parameter Sets: (All)
Aliases:
Accepted values: AzureVM, AzureSQLDatabase, AzureFiles, MSSQL

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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.ContainerBase

## NOTES

## RELATED LINKS
