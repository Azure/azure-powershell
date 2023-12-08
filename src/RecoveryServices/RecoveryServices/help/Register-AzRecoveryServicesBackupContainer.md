---
external help file: Az.RecoveryServices-help.xml
Module Name: Az.RecoveryServices
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/register-azrecoveryservicesbackupcontainer
schema: 2.0.0
---

# Register-AzRecoveryServicesBackupContainer

## SYNOPSIS
The Register-AzRecoveryServicesBackupContainer cmdlet registers an Azure VM for AzureWorkloads with specific DatasourceType.

## SYNTAX

### Register (Default)
```
Register-AzRecoveryServicesBackupContainer -ResourceGroupName <String> -VaultName <String>
 [-DatasourceType] <DatasourceTypes> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-ResourceId] <String> [<CommonParameters>]
```

### ReRegister
```
Register-AzRecoveryServicesBackupContainer -ResourceGroupName <String> -VaultName <String>
 [-DatasourceType] <DatasourceTypes> [-Container] <IProtectionContainerResource> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
The Register-AzRecoveryServicesBackupContainer cmdlet registers an Azure VM for AzureWorkloads with specific DatasourceType.

## EXAMPLES

### Example 1: Register a backup container for DatasourceType MSSQL
```powershell
$resourceId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/hiagarg/providers/Microsoft.Compute/virtualMachines/sql-vm2"
$registeredContainer = Register-AzRecoveryServicesBackupContainer -ResourceGroupName $resourceGroupName -VaultName $vaultName -DatasourceType MSSQL -ResourceId $resourceId
$registeredContainer
```

```output
ETag Location Name
---- -------- ----
              VMAppContainer;Compute;hiagarg;sql-vm2
```

First we set the SQL virtual machine ArmId for VM which needs to be registered.
Next command is used to register the backup container.

### Example 2: Re-registering a backup container
```powershell
$container = Get-AzRecoveryServicesBackupContainer -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -ContainerType AzureVMAppContainer -DatasourceType MSSQL | Where-Object { $_.Name -match $containerFriendlyName }
$reRegisteredContainer = Register-AzRecoveryServicesBackupContainer -ResourceGroupName $resourceGroupName -VaultName $vaultName -DatasourceType MSSQL -Container $container
$reRegisteredContainer | fl
```

```output
BackupManagementType  : AzureWorkload
ContainerType         : VMAppContainer
ETag                  :
FriendlyName          : sql-vm2
HealthStatus          : Healthy
Id                    : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/hiagarg/providers/Microsoft.RecoveryServices/vaults/hiagaVault/backupFabrics/Azure/protectionContainers/VMAppContainer;Compute;hiagarg;sql-vm2
Location              :
Name                  : VMAppContainer;Compute;hiagarg;sql-vm2
Property              : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.AzureVMAppContainerProtectionContainer
ProtectableObjectType : VMAppContainer
RegistrationStatus    : Registered
Tag                   : Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.ResourceTags
Type                  : Microsoft.RecoveryServices/vaults/backupFabrics/protectionContainers
```

The first command fetches the backup container for re-registeration.
The next command triggers the re-registeration for the backup container.
This command can be used for Datasourcetype MSSQL, SAPHANA.

## PARAMETERS

### -Container
Specifies a container object for which this cmdlet triggers the re-registration.
To obtain an ProtectionContainerResource, use the Get-AzRecoveryServicesBackupContainer cmdlet
To construct, see NOTES section for CONTAINER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainerResource
Parameter Sets: ReRegister
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DatasourceType
Specifies the DatasourceType

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DatasourceTypes
Parameter Sets: (All)
Aliases:
Accepted values: AzureVM, MSSQL, SAPHANA, AzureFiles

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group where the recovery services vault is present

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

### -ResourceId
Specifies the ARM ID of an Instance or Availability Group

```yaml
Type: System.String
Parameter Sets: Register
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription Id

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

### -VaultName
The name of the recovery services vault

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainerResource

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainerResource

## NOTES

## RELATED LINKS
