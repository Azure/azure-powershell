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
