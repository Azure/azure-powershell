---
external help file: Az.DataProtection-help.xml
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
Set-AzDataProtectionMSIPermission -VaultResourceGroup <String> -VaultName <String> -PermissionsScope <String>
 -BackupInstance <IBackupInstanceResource> [-KeyVaultId <String>] [-UserAssignedIdentityARMId <String>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetPermissionsForRestore
```
Set-AzDataProtectionMSIPermission -VaultResourceGroup <String> -VaultName <String> -PermissionsScope <String>
 [-UserAssignedIdentityARMId <String>] -RestoreRequest <IAzureBackupRestoreRequest> [-SubscriptionId <String>]
 [-DatasourceType <DatasourceTypes>] [-SnapshotResourceGroupId <String>] [-StorageAccountARMId <String>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
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

### Example 5: Grant Permissions using Vault UAMI for Configure Backup
```powershell
$backupinstance = Get-AzDataProtectionBackupInstance -ResourceGroupName "ResourceGroupName" -VaultName "VaultName" -SubscriptionId "SubscriptionId"

Set-AzDataProtectionMSIPermission -VaultResourceGroup "ResourceGroupName" -VaultName "VaultName" -PermissionsScope "ResourceGroup" -BackupInstance $backupinstance[0] -UserAssignedIdentityARMId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RGName/providers/Microsoft.ManagedIdentity/userAssignedIdentities/UserAssignedIdentityName"
```

```output
Using Vault UAMI with ARMId: /subscriptions/SubscriptionId/resourceGroups/ResourceGroupName/providers/Microsoft.ManagedIdentity/userAssignedIdentities/UserAssignedIdentityName with Principal ID: PrincipalId 
Assigned Disk Snapshot Contributor permission to the backup vault over snapshot resource group with Id /subscriptions/SubscriptionId/resourceGroups/ResourceGroupName 
Assigned Disk Backup Reader permission to the backup vault over DataSource with Id /subscriptions/SubscriptionId/resourceGroups/ResourceGroupName/providers/Microsoft.Compute/disks/DiskName
Waiting for 60 seconds for roles to propagate
```

The above command is used to assign permissions to the backup vault "VaultName" under resource group "ResourceGroupName" at the "ResourceGroup" scope using a User Assigned Managed Identity (UAMI).

## PARAMETERS

### -BackupInstance
Backup instance request object which will be used to configure backup
To construct, see NOTES section for BACKUPINSTANCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IBackupInstanceResource
Parameter Sets: SetPermissionsForBackup
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
Parameter Sets: SetPermissionsForRestore
Aliases:
Accepted values: AzureDisk, AzureBlob, AzureDatabaseForPostgreSQL, AzureKubernetesService, AzureDatabaseForPGFlexServer, AzureDatabaseForMySQL

Required: False
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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestoreRequest
Restore request object which will be used for restore
To construct, see NOTES section for RESTOREREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IAzureBackupRestoreRequest
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

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountARMId
Target storage account ARM Id.
Use this parameter for DatasourceType AzureDatabaseForMySQL, AzureDatabaseForPGFlexServer.

```yaml
Type: System.String
Parameter Sets: SetPermissionsForRestore
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription Id of the backup vault

```yaml
Type: System.String
Parameter Sets: SetPermissionsForRestore
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentityARMId
User Assigned Identity ARM ID of the backup vault to be used for assigning permissions

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
Aliases: ResourceGroupName

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

## RELATED LINKS
