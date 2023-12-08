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

First we set the SQL virtual machine ArmId for VM which needs to be registered. Next command is used to register the backup container.

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

The first command fetches the backup container for re-registeration. The next command triggers the re-registeration for the backup container. This command can be used for Datasourcetype MSSQL, SAPHANA.
