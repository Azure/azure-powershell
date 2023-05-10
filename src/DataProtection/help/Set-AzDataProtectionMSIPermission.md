---
external help file:
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/set-azdataprotectionmsipermission
schema: 2.0.0
---

# Set-AzDataProtectionMSIPermission

## SYNOPSIS
Grants required permissions to the backup vault and other resources for configure backup and restore scenarios

## SYNTAX

### SetPermissionsForBackup (Default)
```
Set-AzDataProtectionMSIPermission -BackupInstance <IBackupInstanceResource> -PermissionsScope <String>
 -VaultName <String> -VaultResourceGroup <String> [-KeyVaultId <String>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### SetPermissionsForRestore
```
Set-AzDataProtectionMSIPermission -PermissionsScope <String> -RestoreRequest <IAzureBackupRestoreRequest>
 -SnapshotResourceGroupId <String> -VaultName <String> -VaultResourceGroup <String> [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Grants required permissions to the backup vault and other resources for configure backup and restore scenarios

## EXAMPLES

### Example 1: Grant Permissions for Azure Disks
```powershell
Set-AzDataProtectionMSIPermission -BackupInstance $instance -VaultResourceGroup "VaultRG" -VaultName "Vaultname" -PermissionsScope "ResourceGroup"

```

```output
Assigning Disk Backup Reader permission to the backup vault
Assigned Disk Backup Reader permission to the backup vault
Assigning Disk Snapshot Contributor permission to the backup vault
Assigned Disk Snapshot Contributor permission to the backup vault
Waiting for 60 seconds for roles to propagate
```

The above command is used to assign permissions to the backup vault "Vaultname" under resource group "VaultRG" at the "Resource Group" scope of the disk.

### Example 2: Grant Permissions for Azure Blobs
```powershell
Set-AzDataProtectionMSIPermission -BackupInstance $instance -VaultResourceGroup "VaultRG" -VaultName "Vaultname" -PermissionsScope "Subscription"
```

```output
Assigning Storage Account Backup Contributor permission to the backup vault
Assigned Storage Account Backup Contributor permission to the backup vault
Waiting for 60 seconds for roles to propagate
```

The above command is used to assign permissions to the backup vault "Vaultname" under resource group "VaultRG" at the "Subscription" scope of the blob.

### Example 3: Grant Permissions for Azure Database For PostgreSQL
```powershell
Set-AzDataProtectionMSIPermission -KeyVaultId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/Sqlrg/providers/Microsoft.KeyVault/vaults/testkeyvault"  -BackupInstance $instance -VaultResourceGroup "VaultRG" -VaultName "Vaultname" -PermissionsScope "Resource"

```

```output
Confirm
Are you sure you want to perform this action?
Performing the operation "
                            1.'Allow All Azure services' under network connectivity in the Postgres Server
                            2.'Allow Trusted Azure services' under network connectivity in the Key vault" on target "KeyVault: oss-pstest-keyvault and PostgreSQLServer: oss-pstest-server".
[Y] Yes  [A] Yes to All  [N] No  [L] No to All  [S] Suspend  [?] Help (default is "Y"): A
Assigning Reader permission to the backup vault
Assigned Reader permission to the backup vault
Waiting for 60 seconds for roles to propagate
```

The above command is used to assign permissions to the backup vault "Vaultname" under resource group "VaultRG" at the "Resource" scope of the Azure Database For PostgreSQL.
It takes an additional KeyVaultId parameter to assign the necessary permissions to the backup vault on the keyvault.

### Example 4: Grant missing permissions to configure backup for AzureKubernetesService
```powershell
Set-AzDataProtectionMSIPermission -BackupInstance $backupInstance -VaultResourceGroup "resourceGroupName" -VaultName "vaultName" -PermissionsScope "ResourceGroup"
```

```output
Confirm
Are you sure you want to perform this action?
Performing the operation "Allow Contributor permission over snapshot resource group" on target
"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourceGroupName/providers/Microsoft.ContainerService/managedClusters/aks-cluster".
[Y] Yes  [A] Yes to All  [N] No  [L] No to All  [S] Suspend  [?] Help (default is "Y"): Y
Assigned Contributor permission to DataSource with Id /subscriptions/xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourceGroupName/providers/Microsoft.ContainerService/managedClusters/aks-cluster over snapshot resource group with Id /subscriptions/xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/snapshotResourceGroup
Assigned Reader permission to the backup vault over snapshot resource group with Id /subscriptions/xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/snapshotResourceGroup
Required permission Reader is already assigned to backup vault over DataSource with Id /subscriptions/xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourceGroupName/providers/Microsoft.ContainerService/managedClusters/aks-cluster
Waiting for 60 seconds for roles to propagate
```

The above command is used to assign permissions to the backup vault "VaultName" under resource group "resourceGroupName" at the "ResourceGroup" scope.

## PARAMETERS

### -BackupInstance
Backup instance request object which will be used to configure backup
To construct, see NOTES section for BACKUPINSTANCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IBackupInstanceResource
Parameter Sets: SetPermissionsForBackup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultId
ID of the keyvault

```yaml
Type: System.String
Parameter Sets: SetPermissionsForBackup
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PermissionsScope
Scope at which the permissions need to be granted

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

### -RestoreRequest
Restore request object which will be used for restore
To construct, see NOTES section for RESTOREREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IAzureBackupRestoreRequest
Parameter Sets: SetPermissionsForRestore
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SnapshotResourceGroupId
Sanpshot Resource Group

```yaml
Type: System.String
Parameter Sets: SetPermissionsForRestore
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
Name of the backup vault

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

### -VaultResourceGroup
Resource group of the backup vault

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

## OUTPUTS

### System.Object

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`BACKUPINSTANCE <IBackupInstanceResource>`: Backup instance request object which will be used to configure backup
  - `[Tag <IDppProxyResourceTags>]`: Proxy Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[Property <IBackupInstance>]`: BackupInstanceResource properties
    - `DataSourceInfo <IDatasource>`: Gets or sets the data source information.
      - `ResourceId <String>`: Full ARM ID of the resource. For azure resources, this is ARM ID. For non azure resources, this will be the ID created by backup service via Fabric/Vault.
      - `[ObjectType <String>]`: Type of Datasource object, used to initialize the right inherited type
      - `[ResourceLocation <String>]`: Location of datasource.
      - `[ResourceName <String>]`: Unique identifier of the resource in the context of parent.
      - `[ResourceType <String>]`: Resource Type of Datasource.
      - `[ResourceUri <String>]`: Uri of the resource.
      - `[Type <String>]`: DatasourceType of the resource.
    - `ObjectType <String>`: 
    - `PolicyInfo <IPolicyInfo>`: Gets or sets the policy information.
      - `PolicyId <String>`: 
      - `[PolicyParameter <IPolicyParameters>]`: Policy parameters for the backup instance
        - `[BackupDatasourceParametersList <IBackupDatasourceParameters[]>]`: Gets or sets the Backup Data Source Parameters
          - `ObjectType <String>`: Type of the specific object - used for deserializing
        - `[DataStoreParametersList <IDataStoreParameters[]>]`: Gets or sets the DataStore Parameters
          - `DataStoreType <DataStoreTypes>`: type of datastore; Operational/Vault/Archive
          - `ObjectType <String>`: Type of the specific object - used for deserializing
    - `[DataSourceSetInfo <IDatasourceSet>]`: Gets or sets the data source set information.
      - `ResourceId <String>`: Full ARM ID of the resource. For azure resources, this is ARM ID. For non azure resources, this will be the ID created by backup service via Fabric/Vault.
      - `[DatasourceType <String>]`: DatasourceType of the resource.
      - `[ObjectType <String>]`: Type of Datasource object, used to initialize the right inherited type
      - `[ResourceLocation <String>]`: Location of datasource.
      - `[ResourceName <String>]`: Unique identifier of the resource in the context of parent.
      - `[ResourceType <String>]`: Resource Type of Datasource.
      - `[ResourceUri <String>]`: Uri of the resource.
    - `[DatasourceAuthCredentials <IAuthCredentials>]`: Credentials to use to authenticate with data source provider.
      - `ObjectType <String>`: Type of the specific object - used for deserializing
    - `[FriendlyName <String>]`: Gets or sets the Backup Instance friendly name.
    - `[ValidationType <ValidationType?>]`: Specifies the type of validation. In case of DeepValidation, all validations from /validateForBackup API will run again.

`RESTOREREQUEST <IAzureBackupRestoreRequest>`: Restore request object which will be used for restore
  - `ObjectType <String>`: 
  - `RestoreTargetInfo <IRestoreTargetInfoBase>`: Gets or sets the restore target information.
    - `ObjectType <String>`: Type of Datasource object, used to initialize the right inherited type
    - `[RestoreLocation <String>]`: Target Restore region
  - `SourceDataStoreType <SourceDataStoreType>`: Gets or sets the type of the source data store.
  - `[SourceResourceId <String>]`: Fully qualified Azure Resource Manager ID of the datasource which is being recovered.

## RELATED LINKS

