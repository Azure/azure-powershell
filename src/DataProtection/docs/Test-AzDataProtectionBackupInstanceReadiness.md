---
external help file:
Module Name: Az.DataProtection
online version: https://docs.microsoft.com/powershell/module/az.dataprotection/test-azdataprotectionbackupinstancereadiness
schema: 2.0.0
---

# Test-AzDataProtectionBackupInstanceReadiness

## SYNOPSIS
Validate whether adhoc backup will be successful or not

## SYNTAX

### ValidateViaIdentity (Default)
```
Test-AzDataProtectionBackupInstanceReadiness -InputObject <IDataProtectionIdentity>
 -Parameter <IValidateForBackupRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Validate
```
Test-AzDataProtectionBackupInstanceReadiness -ResourceGroupName <String> -VaultName <String>
 -Parameter <IValidateForBackupRequest> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateExpanded
```
Test-AzDataProtectionBackupInstanceReadiness -ResourceGroupName <String> -VaultName <String>
 -BackupInstance <IBackupInstance> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentityExpanded
```
Test-AzDataProtectionBackupInstanceReadiness -InputObject <IDataProtectionIdentity>
 -BackupInstance <IBackupInstance> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Validate whether adhoc backup will be successful or not

## EXAMPLES

### Example 1: Test the backup instance 
```powershell
Initialize-AzDataProtectionBackupInstance -DatasourceType AzureDatabaseForPostgreSQL -DatasourceLocation "westus" -PolicyId $polOss[0].Id -DatasourceId "subscriptions/xxxxxx-xxxxxx-xxxx/resourcegroups/Ossrg/providers/Microsoft.DBforPostgreSQL/servers/rishitserver3/databases/postgres" -SecretStoreURI "https://rishitkeyvault3.vault.azure.net/secrets/rishitnewsecre" -SecretStoreType AzureKeyVault

```

The command validates whether the backup instance is ready for configuring backup

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
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IBackupInstance
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity
Parameter Sets: ValidateViaIdentity, ValidateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Parameter
Validate for backup request
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IValidateForBackupRequest
Parameter Sets: Validate, ValidateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group where the backup vault is present.

```yaml
Type: System.String
Parameter Sets: Validate, ValidateExpanded
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
Parameter Sets: Validate, ValidateExpanded
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
Parameter Sets: Validate, ValidateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IValidateForBackupRequest

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IOperationJobExtendedInfo

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


BACKUPINSTANCE <IBackupInstance>: Backup Instance
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

INPUTOBJECT <IDataProtectionIdentity>: Identity Parameter
  - `[BackupInstanceName <String>]`: The name of the backup instance
  - `[BackupPolicyName <String>]`: 
  - `[Id <String>]`: Resource identity path
  - `[JobId <String>]`: The Job ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
  - `[Location <String>]`: The location in which uniqueness will be verified.
  - `[OperationId <String>]`: 
  - `[RecoveryPointId <String>]`: 
  - `[RequestName <String>]`: 
  - `[ResourceGroupName <String>]`: The name of the resource group where the backup vault is present.
  - `[ResourceGuardsName <String>]`: The name of ResourceGuard
  - `[SubscriptionId <String>]`: The subscription Id.
  - `[VaultName <String>]`: The name of the backup vault.

PARAMETER <IValidateForBackupRequest>: Validate for backup request
  - `BackupInstance <IBackupInstance>`: Backup Instance
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

