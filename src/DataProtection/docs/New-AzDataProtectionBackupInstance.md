---
external help file:
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/new-azdataprotectionbackupinstance
schema: 2.0.0
---

# New-AzDataProtectionBackupInstance

## SYNOPSIS
Configures Backup for supported azure resources

## SYNTAX

```
New-AzDataProtectionBackupInstance -BackupInstance <IBackupInstanceResource> -ResourceGroupName <String>
 -VaultName <String> [-AsJob] [-DefaultProfile <PSObject>] [-NoWait] [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Configures Backup for supported azure resources

## EXAMPLES

### Example 1: Configure backup of an azure disk in a backup vault.
```powershell
$sub = "xxxx-xxx-xx"
$DiskId = "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.Compute/disks/{diskname}"
$policy = Get-AzDataProtectionBackupPolicy -SubscriptionId $sub -ResourceGroupName sarath-rg -VaultName sarath-vault -Name "MyPolicy"
$instance = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureDisk -DatasourceLocation $vault.Location -PolicyId $policy.Id -DatasourceId $DiskId 
$instance.Property.PolicyInfo.PolicyParameter.DataStoreParametersList[0].ResourceGroupId = "/subscriptions/{subscription}/resourceGroups/{resourceGroup}"
New-AzDataProtectionBackupInstance -SubscriptionId $sub -ResourceGroupName sarath-rg -VaultName sarath-vault -BackupInstance $instance
```

```output
Name                                                       Type                                                  BackupInstanceName
----                                                       ----                                                  ------------------
sarathdisk-sarathdisk-3df6ac08-9496-4839-8fb5-8b78e594f166 Microsoft.DataProtection/backupVaults/backupInstances sarathdisk-sarathdisk-3df6ac08-9496-4839-8fb5-8b78e594f166
```

The third command gets the policy with which disk will be backed up.
The fourth command initializes the backup instance request.
The last command configures backup of the given azure disk in the backup vault.

### Example 2: Configure protection for AzureDatabaseForPostgreSQL database in a backup vault (using secret store authentication).
```powershell
$sub = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
$dataSourceId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroupName/providers/Microsoft.DBforPostgreSQL/servers/OssServerName/databases/DBName"
$secretURI = "https://oss-keyvault.vault.azure.net/secrets/oss-secret"
$vault = Get-AzDataProtectionBackupVault -SubscriptionId $sub -ResourceGroupName "ResourceGroupName"  -VaultName  $vaultName
$policy = Get-AzDataProtectionBackupPolicy -SubscriptionId $sub -ResourceGroupName "ResourceGroupName" -VaultName "vaultName" -Name "MyPolicy"
$instance = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureDatabaseForPostgreSQL -DatasourceLocation $vault.Location -PolicyId $policy.Id -DatasourceId $dataSourceId -SecretStoreURI $secretURI -SecretStoreType AzureKeyVault
New-AzDataProtectionBackupInstance -SubscriptionId $sub -ResourceGroupName "ResourceGroupName" -VaultName "vaultName" -BackupInstance $instance
```

```output
Name                                                                Type                                                  BackupInstanceName
----                                                                ----                                                  ------------------
xyz-postgresql-wus-empdb10-xxxxxxxx-xxxx-xxxx-a3ba-be75108d8b21 Microsoft.DataProtection/backupVaults/backupInstances xyz-postgresql-wus-empdb10-xxxxxxxx-xxxx-xxxx-a3ba-be75108d8b21
```

The third command initializes the secretURI for secret store authentication.

The fifth command gets the policy with which database will be protected.
The sixth command initializes the backup instance request object.
The last command configures backup of the given $dataSourceId in the backup vault.

### Example 3: Configure protection for AzureKubernetesService cluster in a backup vault
```powershell
$policy = Get-AzDataProtectionBackupPolicy -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -VaultName "vaultName" -ResourceGroupName "resourceGroupName" | where {$_.Name -eq "policyName"}
$sourceClusterId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourceGroupName/providers/Microsoft.ContainerService/managedClusters/aks-cluster"
$snapshotResourceGroupId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourceGroupName"
$backupConfig = New-AzDataProtectionBackupConfigurationClientObject -SnapshotVolume $true -IncludeClusterScopeResource $true -DatasourceType AzureKubernetesService -LabelSelector "x=y","foo=bar" 
$backupInstance = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureKubernetesService  -DatasourceLocation "eastus" -PolicyId $policy.Id -DatasourceId $sourceClusterId -SnapshotResourceGroupId $snapshotResourceGroupId -FriendlyName "aks-cluster-friendlyName" -BackupConfiguration $backupConfig
Set-AzDataProtectionMSIPermission -BackupInstance $backupInstance -VaultResourceGroup "resourceGroupName" -VaultName "vaultName" -PermissionsScope "ResourceGroup"
$tag= @{"Owner"="BIOwnerName";"Foo"="Bar";"A"="B"}
$biCreate = New-AzDataProtectionBackupInstance -ResourceGroupName "ResourceGroupName" -VaultName "vaultName" -BackupInstance $backupInstance -SubscriptionId $sub -Tag $tag
$biCreate
```

```output
Name                                                                       BackupInstanceName
----                                                                       ------------------
aks-cluster-aks-cluster-117bd668-4t5h-4f3a-947c-ea71304cb4d7 aks-cluster-aks-cluster-117bd668-4t5h-4f3a-947c-ea71304cb4d7
```

The First command gets the AzureKubernetesService policy in a given vault.
The second, third command initializes the AKS cluster and snapshot resource group Id.
The fourth command backup configuration object needed for AzureKubernetesService.
The fifth command initializes the client object for backup instance.
The sixth command assigns the necessary permissions for configure backup.

The sevnth and eight command initializes custom tags and configure backup finally by creating a backup instance.

## PARAMETERS

### -AsJob


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
Backup instance request object which will be used to configure backup
To construct, see NOTES section for BACKUPINSTANCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IBackupInstanceResource
Parameter Sets: (All)
Aliases:

Required: True
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

### -NoWait


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
Resource Group of the backup vault

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
Subscription Id of the vault

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

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

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

## RELATED LINKS

