---
external help file:
Module Name: Az.DataProtection
online version: https://docs.microsoft.com/en-us/powershell/module/az.dataprotection/set-azdataprotectionbackupinstance
schema: 2.0.0
---

# Set-AzDataProtectionBackupInstance

## SYNOPSIS


## SYNTAX

### PutExpanded (Default)
```
Set-AzDataProtectionBackupInstance -Name <String> -ResourceGroupName <String> -VaultName <String>
 [-SubscriptionId <String>] [-Property <IBackupInstance>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### dppplatform
```
Set-AzDataProtectionBackupInstance -BackupInstance <IBackupInstanceResource> -VaultId <String> [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Put
```
Set-AzDataProtectionBackupInstance -Name <String> -ResourceGroupName <String> -VaultName <String>
 -Parameter <IBackupInstanceResource> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION


## EXAMPLES

### Example 1: Configure backup of an azure disk in a backup vault.
```powershell
PS C:\> $sub = "xxxx-xxx-xx"
PS C:\> $DiskId = "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.Compute/disks/{diskname}"
PS C:\> $policy = Get-AzDataProtectionBackupPolicy -SubscriptionId $sub -ResourceGroupName sarath-rg -VaultName sarath-vault -Name "MyPolicy"
PS C:\> $vault = Get-AzDataProtectionBackupVault -SubscriptionId $sub -ResourceGroupName sarath-rg -VaultName sarath-vault
PS C:\> $instance = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureDisk -DatasourceLocation $vault.Location -PolicyId $policy.Id -DatasourceId $DiskId 
PS C:\> $instance.Property.PolicyInfo.PolicyParameter.DataStoreParametersList[0].ResourceGroupId = "/subscriptions/{subscription}/resourceGroups/{resourceGroup}"
PS C:\> Set-AzDataProtectionBackupInstance -VaultId $vault.ID -BackupInstance $instance


Name                                                       Type                                                  BackupInstanceName
----                                                       ----                                                  ------------------
sarathdisk-sarathdisk-3df6ac08-9496-4839-8fb5-8b78e594f166 Microsoft.DataProtection/backupVaults/backupInstances sarathdisk-sarathdisk-3df6ac08-9496-4839-8fb5-8b78e594f166
```

The third command gets the policy with which disk will be backed up.
The fourth stores the backup vault object in $vault variable.
The fifth command initializes the backup instance request.
The last command configures backup of the given azure disk in the backup vault.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Put, PutExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupInstanceResource
Parameter Sets: dppplatform
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
Parameter Sets: Put, PutExpanded
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the backup instance

```yaml
Type: System.String
Parameter Sets: Put, PutExpanded
Aliases: BackupInstanceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Put, PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
BackupInstance Resource
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupInstanceResource
Parameter Sets: Put
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Property
BackupInstanceResource properties
To construct, see NOTES section for PROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupInstance
Parameter Sets: PutExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group where the backup vault is present.

```yaml
Type: System.String
Parameter Sets: Put, PutExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription Id.

```yaml
Type: System.String
Parameter Sets: Put, PutExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultId
Id of the backup vault

```yaml
Type: System.String
Parameter Sets: dppplatform
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
The name of the backup vault.

```yaml
Type: System.String
Parameter Sets: Put, PutExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupInstanceResource

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupInstanceResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


BACKUPINSTANCE <IBackupInstanceResource>: Backup instance request object which will be used to configure backup
  - `[Property <IBackupInstance>]`: BackupInstanceResource properties
    - `DataSourceInfo <IDatasource>`: Gets or sets the data source information.
      - `ResourceId <String>`: Full ARM ID of the resource. For azure resources, this is ARM ID. For non azure resources, this will be the ID created by backup service via Fabric/Vault.
      - `[ObjectType <String>]`: Type of Datasource object, used to initialize the right inherited type
      - `[ResourceLocation <String>]`: Location of datasource.
      - `[ResourceName <String>]`: Unique identifier of the resource in the context of parent.
      - `[ResourceType <String>]`: Resource Type of Datasource.
      - `[ResourceUri <String>]`: Uri of the resource.
      - `[Type <String>]`: DatasourceType of the resource.
    - `FriendlyName <String>`: Gets or sets the Backup Instance friendly name.
    - `ObjectType <String>`: 
    - `PolicyInfo <IPolicyInfo>`: Gets or sets the policy information.
      - `PolicyId <String>`: 
      - `[PolicyParameter <IPolicyParameters>]`: Policy parameters for the backup instance
        - `[DataStoreParametersList <IDataStoreParameters[]>]`: Gets or sets the DataStore Parameters
          - `DataStoreType <DataStoreTypes>`: type of datastore; Operational/Vault/Archive
          - `ObjectType <String>`: Type of the specific object - used for deserializing
          - `[ResourceGroupId <String>]`: Gets or sets the Resource Group Uri.
    - `[DataSourceSetInfo <IDatasourceSet>]`: Gets or sets the data source set information.
      - `ResourceId <String>`: Full ARM ID of the resource. For azure resources, this is ARM ID. For non azure resources, this will be the ID created by backup service via Fabric/Vault.
      - `[DatasourceType <String>]`: DatasourceType of the resource.
      - `[ObjectType <String>]`: Type of Datasource object, used to initialize the right inherited type
      - `[ResourceLocation <String>]`: Location of datasource.
      - `[ResourceName <String>]`: Unique identifier of the resource in the context of parent.
      - `[ResourceType <String>]`: Resource Type of Datasource.
      - `[ResourceUri <String>]`: Uri of the resource.

PARAMETER <IBackupInstanceResource>: BackupInstance Resource
  - `[Property <IBackupInstance>]`: BackupInstanceResource properties
    - `DataSourceInfo <IDatasource>`: Gets or sets the data source information.
      - `ResourceId <String>`: Full ARM ID of the resource. For azure resources, this is ARM ID. For non azure resources, this will be the ID created by backup service via Fabric/Vault.
      - `[ObjectType <String>]`: Type of Datasource object, used to initialize the right inherited type
      - `[ResourceLocation <String>]`: Location of datasource.
      - `[ResourceName <String>]`: Unique identifier of the resource in the context of parent.
      - `[ResourceType <String>]`: Resource Type of Datasource.
      - `[ResourceUri <String>]`: Uri of the resource.
      - `[Type <String>]`: DatasourceType of the resource.
    - `FriendlyName <String>`: Gets or sets the Backup Instance friendly name.
    - `ObjectType <String>`: 
    - `PolicyInfo <IPolicyInfo>`: Gets or sets the policy information.
      - `PolicyId <String>`: 
      - `[PolicyParameter <IPolicyParameters>]`: Policy parameters for the backup instance
        - `[DataStoreParametersList <IDataStoreParameters[]>]`: Gets or sets the DataStore Parameters
          - `DataStoreType <DataStoreTypes>`: type of datastore; Operational/Vault/Archive
          - `ObjectType <String>`: Type of the specific object - used for deserializing
          - `[ResourceGroupId <String>]`: Gets or sets the Resource Group Uri.
    - `[DataSourceSetInfo <IDatasourceSet>]`: Gets or sets the data source set information.
      - `ResourceId <String>`: Full ARM ID of the resource. For azure resources, this is ARM ID. For non azure resources, this will be the ID created by backup service via Fabric/Vault.
      - `[DatasourceType <String>]`: DatasourceType of the resource.
      - `[ObjectType <String>]`: Type of Datasource object, used to initialize the right inherited type
      - `[ResourceLocation <String>]`: Location of datasource.
      - `[ResourceName <String>]`: Unique identifier of the resource in the context of parent.
      - `[ResourceType <String>]`: Resource Type of Datasource.
      - `[ResourceUri <String>]`: Uri of the resource.

PROPERTY <IBackupInstance>: BackupInstanceResource properties
  - `DataSourceInfo <IDatasource>`: Gets or sets the data source information.
    - `ResourceId <String>`: Full ARM ID of the resource. For azure resources, this is ARM ID. For non azure resources, this will be the ID created by backup service via Fabric/Vault.
    - `[ObjectType <String>]`: Type of Datasource object, used to initialize the right inherited type
    - `[ResourceLocation <String>]`: Location of datasource.
    - `[ResourceName <String>]`: Unique identifier of the resource in the context of parent.
    - `[ResourceType <String>]`: Resource Type of Datasource.
    - `[ResourceUri <String>]`: Uri of the resource.
    - `[Type <String>]`: DatasourceType of the resource.
  - `FriendlyName <String>`: Gets or sets the Backup Instance friendly name.
  - `ObjectType <String>`: 
  - `PolicyInfo <IPolicyInfo>`: Gets or sets the policy information.
    - `PolicyId <String>`: 
    - `[PolicyParameter <IPolicyParameters>]`: Policy parameters for the backup instance
      - `[DataStoreParametersList <IDataStoreParameters[]>]`: Gets or sets the DataStore Parameters
        - `DataStoreType <DataStoreTypes>`: type of datastore; Operational/Vault/Archive
        - `ObjectType <String>`: Type of the specific object - used for deserializing
        - `[ResourceGroupId <String>]`: Gets or sets the Resource Group Uri.
  - `[DataSourceSetInfo <IDatasourceSet>]`: Gets or sets the data source set information.
    - `ResourceId <String>`: Full ARM ID of the resource. For azure resources, this is ARM ID. For non azure resources, this will be the ID created by backup service via Fabric/Vault.
    - `[DatasourceType <String>]`: DatasourceType of the resource.
    - `[ObjectType <String>]`: Type of Datasource object, used to initialize the right inherited type
    - `[ResourceLocation <String>]`: Location of datasource.
    - `[ResourceName <String>]`: Unique identifier of the resource in the context of parent.
    - `[ResourceType <String>]`: Resource Type of Datasource.
    - `[ResourceUri <String>]`: Uri of the resource.

## RELATED LINKS

