---
external help file: Microsoft.Azure.Commands.RecoveryServices.Backup.dll-Help.xml
ms.assetid: 1097FF29-1C23-4960-930C-5C1227419359
online version: 
schema: 2.0.0
---

# Get-AzureRmRecoveryServicesBackupContainer

## SYNOPSIS
Gets Backup containers.

## SYNTAX

```
Get-AzureRmRecoveryServicesBackupContainer [-ContainerType] <ContainerType> [[-BackupManagementType] <String>]
 [[-Name] <String>] [-FriendlyName <String>] [[-ResourceGroupName] <String>]
 [[-Status] <ContainerRegistrationStatus>] [-InformationAction <ActionPreference>]
 [-InformationVariable <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmRecoveryServicesBackupContainer** cmdlet gets a backup container.
A Backup container encapsulates data sources that are modelled as backup items.

Set the vault context by using the Set-AzureRmRecoveryServicesVaultContext cmdlet before you use the current cmdlet.

## EXAMPLES

### Example 1: Get a specific container
```
PS C:\>Get-AzureRmRecoveryServicesContainer -ContainerType "AzureVM" -Status "Registered" -Name "V2VM";
```

This command gets the container named V2VM of type AzureVM.

### Example 2: Get all containers of a specific type
```
PS C:\>Get-AzureRmRecoveryServicesBackupContainer -ContainerType Windows -BackupManagementType MARS
```

This command gets all Windows containers that are protected by Azure Backup agent.
The *BackupManagementType* parameter is only required for Windows containers.

## PARAMETERS

### -ContainerType
Specifies the backup container type.
The acceptable values for this parameter are:

- AzureVM 
- Windows
- AzureSQL

```yaml
Type: ContainerType
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackupManagementType
Specifies the backup management type.
The acceptable values for this parameter are:

- AzureVM
- MARS
- AzureSQL

This parameter is used to differentiate Windows machines that are backed up using MARS agent or other backup engines.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the name of the container to get.

```yaml
Type: String
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
Type: String
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
Type: ContainerRegistrationStatus
Parameter Sets: (All)
Aliases: 

Required: False
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationAction
Specifies how this cmdlet responds to an information event.

The acceptable values for this parameter are:

- Continue
- Ignore
- Inquire
- SilentlyContinue
- Stop
- Suspend

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: infa

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationVariable
Specifies an information variable.

```yaml
Type: String
Parameter Sets: (All)
Aliases: iv

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FriendlyName
Specifies the friendly name of the container to get.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRmRecoveryServicesBackupItem](./Get-AzureRmRecoveryServicesBackupItem.md)

[Get-AzureRmRecoveryServicesBackupManagementServer](./Get-AzureRmRecoveryServicesBackupManagementServer.md)

[Unregister-AzureRmRecoveryServicesBackupContainer](./Unregister-AzureRmRecoveryServicesBackupContainer.md)


