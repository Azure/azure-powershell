---
external help file:
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/initialize-azdataprotectionbackupinstance
schema: 2.0.0
---

# Initialize-AzDataProtectionBackupInstance

## SYNOPSIS
Initializes Backup instance Request object for configuring backup

## SYNTAX

```
Initialize-AzDataProtectionBackupInstance -DatasourceLocation <String> -DatasourceType <DatasourceTypes>
 [-BackupConfiguration <IBackupDatasourceParameters>] [-DatasourceId <String>] [-FriendlyName <String>]
 [-PolicyId <String>] [-SecretStoreType <SecretStoreTypes>] [-SecretStoreURI <String>]
 [-SnapshotResourceGroupId <String>] [-UserAssignedIdentityArmId <String>]
 [-UseSystemAssignedIdentity <Boolean?>] [<CommonParameters>]
```

## DESCRIPTION
Initializes Backup instance Request object for configuring backup

## EXAMPLES

### Example 1: Initialize Backup instance object for Azure Disk
```powershell
$policy = Get-AzDataProtectionBackupPolicy -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName sarath-rg -VaultName sarath-vault
$AzureDiskId = "/subscriptions/{subscription}/resourceGroups/{resourceGroup}/providers/Microsoft.Compute/disks/{diskname}"
$instance = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureDisk -DatasourceLocation westus -DatasourceId $AzureDiskId -PolicyId $policy[0].Id
$instance.Property.PolicyInfo.PolicyParameter.DataStoreParametersList[0].ResourceGroupId = "/subscriptions/{subscription}/resourceGroups/{snapshotResourceGroup}"
$instance
```

```output
Name Type BackupInstanceName
---- ---- ------------------
          sarath-disk3-sarath-disk3-af697a80-e2bc-49f1-af6c-22f6c4d68405
```

The First command gets all the policies in a given vault.
The second command stores azure disk's resource id in $AzureDiskId
variable.
The third command returns a backup instance resource for Azure Disk.
The fourth command sets the snapshot resource group field.
This object can now be used to configure backup for the given disk.

### Example 2: Initialize Backup instance object for AzureKubernetesService
```powershell
$policy = Get-AzDataProtectionBackupPolicy -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -VaultName "vaultName" -ResourceGroupName "resourceGroupName" | Where-Object {$_.Name -eq "policyName"}
$sourceClusterId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourceGroupName/providers/Microsoft.ContainerService/managedClusters/aks-cluster"
$snapshotResourceGroupId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourceGroupName"
$backupConfig = New-AzDataProtectionBackupConfigurationClientObject -SnapshotVolume $true -IncludeClusterScopeResource $true -DatasourceType AzureKubernetesService -LabelSelector "x=y","foo=bar" 
$backupInstance = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureKubernetesService  -DatasourceLocation "eastus" -PolicyId $policy.Id -DatasourceId $sourceClusterId -SnapshotResourceGroupId $snapshotResourceGroupId -FriendlyName "aks-cluster-friendlyName" -BackupConfiguration $backupConfig
$instance
```

```output
Name BackupInstanceName
---- ------------------
     aks-cluster-aks-cluster-ed68435e-069t-4b4a-9d84-d0c194800fc2
```

The First command gets the AzureKubernetesService policy in a given vault.
The second, third command initializes the AKS cluster and snapshot resource group Id.
The fourth command backup configuration object needed for AzureKubernetesService.
The fifth command initializes the client object for backup instance.
This object can now be used to configure backup using New-AzDataProtectionBackupInstance after all necessary permissions are assigned with Set-AzDataProtectionMSIPermission command.

### Example 3: Configure protection for AzureDatabaseForPGFlexServer
```powershell
$vault = Get-AzDataProtectionBackupVault -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName"
$pol = Get-AzDataProtectionBackupPolicy -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -VaultName "vaultName" -ResourceGroupName "resourceGroupName" -Name "policyName"
$datasourceId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/rgName/providers/Microsoft.DBforPostgreSQL/flexibleServers/test-pgflex"
$backupInstanceClientObject = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureDatabaseForPGFlexServer -DatasourceLocation $vault.Location -PolicyId $pol[0].Id -DatasourceId $datasourceId
```

```output
Name BackupInstanceName
---- ------------------
     test-pgflex-test-pgflex-ed68435e-069t-4b4a-9d84-d0c194800fc2
```

The first command gets the backup vault.
The second command get the AzureDatabaseForPGFlexServer policy.
The third command datasource ARM Id.
The fourth command initializes the backup instance.
Similarly use datasourcetype AzureDatabaseForMySQL to initialize backup instance for AzureDatabaseForMySQL.

## PARAMETERS

### -BackupConfiguration
Backup configuration for backup.
Use this parameter to configure protection for AzureKubernetesService,AzureBlob.
To construct, see NOTES section for BACKUPCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IBackupDatasourceParameters
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatasourceId
ID of the datasource to be protected

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

### -DatasourceLocation
Location of the Datasource to be protected.

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

### -DatasourceType
Datasource Type

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DatasourceTypes
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FriendlyName
Friendly name for backup instance

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

### -PolicyId
Policy Id to be assiciated to Datasource

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

### -SecretStoreType
Secret store type for secret store authentication of data source.
This parameter is only supported for AzureDatabaseForPostgreSQL currently.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.SecretStoreTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecretStoreURI
Secret uri for secret store authentication of data source.
This parameter is only supported for AzureDatabaseForPostgreSQL currently.

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

### -SnapshotResourceGroupId
Sanpshot Resource Group

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

### -UserAssignedIdentityArmId
User assigned identity ARM Id

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AssignUserIdentity

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UseSystemAssignedIdentity
Use system assigned identity

```yaml
Type: System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IBackupInstanceResource

## NOTES

## RELATED LINKS

