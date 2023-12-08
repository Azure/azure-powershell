---
external help file: Az.RecoveryServices-help.xml
Module Name: Az.RecoveryServices
online version: https://learn.microsoft.com/powershell/module/az.recoveryservices/get-azrecoveryservicesbackupcontainer
schema: 2.0.0
---

# Get-AzRecoveryServicesBackupContainer

## SYNOPSIS
Gets list of backup containers registered with a recovery services vault

## SYNTAX

```
Get-AzRecoveryServicesBackupContainer -ResourceGroupName <String> -VaultName <String>
 -ContainerType <BackupContainerType> [-SubscriptionId <String>] [-FriendlyName <String>]
 [-DatasourceType <DatasourceTypes>] [-ContainerResourceGroupName <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets list of backup containers registered with a recovery services vault

## EXAMPLES

### Example 1: Get backup containers for DatasourceType MSSQL
```powershell
$container = Get-AzRecoveryServicesBackupContainer -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -ContainerType AzureVMAppContainer -DatasourceType MSSQL | Where-Object { $_.Name -match $containerFriendlyName }
$container | fl
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

This command is used to fetch backup containers for DatasourceType MSSQL which are registered with recovery services vault.

## PARAMETERS

### -ContainerResourceGroupName
The ResourceGroup of the resource being managed by the Azure Backup service for example: ResourceGroup name of the VM

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

### -ContainerType
Specifies the backup container type.
The acceptable values for this parameter are: AzureVM, Windows, AzureStorage, AzureVMAppContainer

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.BackupContainerType
Parameter Sets: (All)
Aliases:
Accepted values: AzureVM, Windows, AzureStorage, AzureVMAppContainer

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatasourceType
Specifies the DatasourceType

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.DatasourceTypes
Parameter Sets: (All)
Aliases:
Accepted values: AzureVM, MSSQL, SAPHANA, AzureFiles

Required: False
Position: Named
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

### -FriendlyName
Specifies the friendly name of the container to get

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

### -ResourceGroupName
The name of the resource group where the recovery services vault is present.

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
The name of the recovery services vault.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IProtectionContainerResource

## NOTES

## RELATED LINKS
