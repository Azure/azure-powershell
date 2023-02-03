---
external help file:
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/test-azdataprotectionbackupinstancereadiness
schema: 2.0.0
---

# Test-AzDataProtectionBackupInstanceReadiness

## SYNOPSIS
Validate whether adhoc backup will be successful or not

## SYNTAX

```
Test-AzDataProtectionBackupInstanceReadiness -ResourceGroupName <String> -VaultName <String>
 -BackupInstance <IBackupInstance> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Validate whether adhoc backup will be successful or not

## EXAMPLES

### Example 1: Test the backup instance 
```powershell
$vault = Get-AzDataProtectionBackupVault -ResourceGroupName "resourceGroupName" -VaultName "vaultName"
$diskBackupPolicy = Get-AzDataProtectionBackupPolicy -ResourceGroupName "resourceGroupName" -VaultName $vault.Name -Name "diskBackupPolicy"
$diskId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/rgName/providers/Microsoft.Compute/disks/test-disk" 
$snapshotRG = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/rgName"
$instance = Initialize-AzDataProtectionBackupInstance -SnapshotResourceGroupId $Snapshotrg -DatasourceType AzureDisk -DatasourceLocation $vault.Location -PolicyId $diskBackupPolicy[0].Id -DatasourceId $diskId 
Test-AzDataProtectionBackupInstanceReadiness -ResourceGroupName "resourceGroupName" -VaultName $vault.Name -BackupInstance  $instance[0].Property
```

The first command gets the backup vault.
The second command gets the disk policy.
Next we initialize $diskId and $snapshotRG variables with disk and snapshot ARM Ids.
The fifth line runs the Initialize command to create a client side backup instance object.
Finally we trigger the Test-AzDataProtectionBackupInstanceReadiness command to validate whether the backup instance is ready for configuring backup or not, the command will fail or pass accordingly.
This command can be use to check whether the backup vault has all the necessary permissions to configure backup.

## PARAMETERS

### -AsJob
Run the command as a job

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

### -BackupInstance
Backup Instance
To construct, see NOTES section for BACKUPINSTANCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IBackupInstance
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -NoWait
Run the command asynchronously

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
The name of the backup vault.

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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IOperationJobExtendedInfo

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`BACKUPINSTANCE <IBackupInstance>`: Backup Instance
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

## RELATED LINKS

