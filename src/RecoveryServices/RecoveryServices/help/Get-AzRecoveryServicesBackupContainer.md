---
external help file: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Backup.dll-Help.xml
Module Name: Az.RecoveryServices
ms.assetid: 1097FF29-1C23-4960-930C-5C1227419359
<<<<<<< HEAD
online version: https://docs.microsoft.com/en-us/powershell/module/az.recoveryservices/get-azrecoveryservicesbackupcontainer
=======
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/get-azrecoveryservicesbackupcontainer
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
schema: 2.0.0
---

# Get-AzRecoveryServicesBackupContainer

## SYNOPSIS

Gets Backup containers.

## SYNTAX

```
Get-AzRecoveryServicesBackupContainer [-ContainerType] <ContainerType> [[-BackupManagementType] <String>]
 [[-FriendlyName] <String>] [[-ResourceGroupName] <String>] [[-Status] <ContainerRegistrationStatus>]
 [-VaultId <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION

<<<<<<< HEAD
The **Get-AzRecoveryServicesBackupContainer** cmdlet gets a backup container.
A Backup container encapsulates data sources that are modelled as backup items.
=======
The **Get-AzRecoveryServicesBackupContainer** cmdlet gets a backup container. A Backup container encapsulates data sources that are modelled as backup items.
For Container type "Azure VM" , the output lists all the containers whose name exactly matches to the one passed  as the value for Friendly Name parameter. 
For other container types,  output gives a list of containers with name similar to the value passed for Friendly name parameter.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Set the vault context by using the -VaultId parameter.

## EXAMPLES

### Example 1: Get a specific container

```powershell
PS C:\> $vault = Get-AzRecoveryServicesVault -ResourceGroupName "resourceGroup" -Name "vaultName"
PS C:\> Get-AzRecoveryServicesBackupContainer -ContainerType "AzureVM" -Status "Registered" -FriendlyName "V2VM" -VaultId $vault.ID
```

This command gets the container named V2VM of type AzureVM.

### Example 2: Get all containers of a specific type

```powershell
PS C:\> $vault = Get-AzRecoveryServicesVault -ResourceGroupName "resourceGroup" -Name "vaultName"
PS C:\> Get-AzRecoveryServicesBackupContainer -ContainerType Windows -BackupManagementType MARS -VaultId $vault.ID
```

This command gets all Windows containers that are protected by Azure Backup agent.
The **BackupManagementType** parameter is only required for Windows containers.

## PARAMETERS

### -BackupManagementType

<<<<<<< HEAD
Specifies the backup management type.
The acceptable values for this parameter are:

- AzureVM
- MARS
- AzureSQL
=======
The class of resources being protected. The acceptable values for this parameter are:

- AzureVM
- MARS
- AzureWorkload
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
- AzureStorage

This parameter is used to differentiate Windows machines that are backed up using MARS agent or other backup engines.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
<<<<<<< HEAD
Accepted values: AzureVM, MARS, AzureSQL, AzureStorage
=======
Accepted values: AzureVM, MARS, AzureWorkload, AzureStorage
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerType

Specifies the backup container type.
The acceptable values for this parameter are:

- AzureVM
- Windows
<<<<<<< HEAD
- AzureSQL
=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
- AzureStorage
- AzureVMAppContainer

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.ContainerType
Parameter Sets: (All)
Aliases:
<<<<<<< HEAD
Accepted values: AzureVM, Windows, AzureSQL, AzureStorage, AzureVMAppContainer
=======
Accepted values: AzureVM, Windows, AzureStorage, AzureVMAppContainer
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile

The credentials, account, tenant, and subscription used for communication with azure.

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

### -FriendlyName

Specifies the friendly name of the container to get.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName

Specifies the name of the resource group.
This parameter is for Azure virtual machines only.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status

Specifies the container registration status.
The acceptable values for this parameter are:

- Registered

```yaml
Type: Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.ContainerRegistrationStatus
Parameter Sets: (All)
Aliases:
Accepted values: Registered

Required: False
Position: 5
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

<<<<<<< HEAD
### -CommonParameters

=======
### CommonParameters
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models.ContainerBase

## NOTES

## RELATED LINKS

[Get-AzRecoveryServicesBackupItem](./Get-AzRecoveryServicesBackupItem.md)

[Get-AzRecoveryServicesBackupManagementServer](./Get-AzRecoveryServicesBackupManagementServer.md)

[Unregister-AzRecoveryServicesBackupContainer](./Unregister-AzRecoveryServicesBackupContainer.md)
