# Upcoming breaking changes in Azure PowerShell

## Az.Accounts

### `Clear-AzConfig`

- Cmdlet breaking-change will happen to all parameter sets
  - Parameter `DisableErrorRecordsPersistence` will be deprecated, a new parameter `EnableErrorRecordsPersistence` will be added instead. Writing error records to file system will become opt-in instead of opt-out. This change will happen around May 2024
  - This change is expected to take effect from Az.Accounts version: 2.X and Az version: 12.0.0

### `Get-AzConfig`

- Cmdlet breaking-change will happen to all parameter sets
  - Parameter `DisableErrorRecordsPersistence` will be deprecated, a new parameter `EnableErrorRecordsPersistence` will be added instead. Writing error records to file system will become opt-in instead of opt-out. This change will happen around May 2024
  - This change is expected to take effect from Az.Accounts version: 2.X and Az version: 12.0.0

### `Update-AzConfig`

- Cmdlet breaking-change will happen to all parameter sets
  - Parameter `DisableErrorRecordsPersistence` will be deprecated, a new parameter `EnableErrorRecordsPersistence` will be added instead. Writing error records to file system will become opt-in instead of opt-out. This change will happen around May 2024
  - This change is expected to take effect from Az.Accounts version: 2.X and Az version: 12.0.0

## Az.CosmosDB

### `Get-AzCosmosDBAccountKey`

- Cmdlet breaking-change will happen to all parameter sets
  - Output type for -Type ConnectionStrings will be changed to List<DatabaseAccountConnectionString> in next major version.
  - This change is expected to take effect from Az.CosmosDB version: 2.0.0 and Az version: 12.0.0

## Az.KeyVault

### `Invoke-AzKeyVaultKeyOperation`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.KeyVault.Models.PSKeyOperationResult' is changing
  - The following properties in the output type are being deprecated : 'Result'
  - The following properties are being added to the output type : 'RawResult'
  - This change is expected to take effect from Az.KeyVault version: 6.0.0 and Az version: 12.0.0

- Parameter breaking-change will happen to all parameter sets
  - `-Value`
    - The parameter : 'Value' is being replaced by parameter : 'ByteArrayValue'.
    - This change is expected to take effect from Az.KeyVault version: 6.0.0 and Az version: 12.0.0

## Az.RecoveryServices

### `Get-AzRecoveryServicesAsrVaultContext`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRVaultSettings' is changing
  - The following properties in the output type are being deprecated : 'ResouceType'
  - The following properties are being added to the output type : 'ResourceType'
  - This change is expected to take effect from Az.RecoveryServices version: 7.0.0 and Az version: 12.0.0

### `Import-AzRecoveryServicesAsrVaultSettingsFile`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRVaultSettings' is changing
  - The following properties in the output type are being deprecated : 'ResouceType'
  - The following properties are being added to the output type : 'ResourceType'
  - This change is expected to take effect from Az.RecoveryServices version: 7.0.0 and Az version: 12.0.0

### `Set-AzRecoveryServicesAsrVaultContext`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.ASRVaultSettings' is changing
  - The following properties in the output type are being deprecated : 'ResouceType'
  - The following properties are being added to the output type : 'ResourceType'
  - This change is expected to take effect from Az.RecoveryServices version: 7.0.0 and Az version: 12.0.0

## Az.Resources

### `Get-AzPolicyAssignment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyAssignment' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'EnforcementMode' 'Metadata' 'NonComplianceMessages' 'NotScopes' 'Parameters' 'PolicyDefinitionId' 'Scope'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

### `Get-AzPolicyDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyDefinition' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'Metadata' 'Mode' 'Parameters' 'PolicyRule' 'PolicyType'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

### `Get-AzPolicyExemption`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyExemption' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'ExemptionCategory' 'ExpiresOn' 'Metadata' 'PolicyAssignmentId' 'PolicyDefinitionReferenceIds'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

### `Get-AzPolicySetDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicySetDefinition' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'Metadata' 'Parameters' 'PolicyDefinitionGroups' 'PolicyDefinitions' 'PolicyType'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

### `New-AzPolicyAssignment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyAssignment' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'EnforcementMode' 'Metadata' 'NonComplianceMessages' 'NotScopes' 'Parameters' 'PolicyDefinitionId' 'Scope'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

### `New-AzPolicyDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyDefinition' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'Metadata' 'Mode' 'Parameters' 'PolicyRule' 'PolicyType'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

### `New-AzPolicyExemption`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyExemption' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'ExemptionCategory' 'ExpiresOn' 'Metadata' 'PolicyAssignmentId' 'PolicyDefinitionReferenceIds'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

### `New-AzPolicySetDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicySetDefinition' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'Metadata' 'Parameters' 'PolicyDefinitionGroups' 'PolicyDefinitions' 'PolicyType'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

### `Set-AzPolicyAssignment`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyAssignment' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'EnforcementMode' 'Metadata' 'NonComplianceMessages' 'NotScopes' 'Parameters' 'PolicyDefinitionId' 'Scope'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

### `Set-AzPolicyDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyDefinition' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'Metadata' 'Mode' 'Parameters' 'PolicyRule' 'PolicyType'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

### `Set-AzPolicyExemption`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicyExemption' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'ExemptionCategory' 'ExpiresOn' 'Metadata' 'PolicyAssignmentId' 'PolicyDefinitionReferenceIds'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

### `Set-AzPolicySetDefinition`

- Cmdlet breaking-change will happen to all parameter sets
  - The output type 'Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy.PsPolicySetDefinition' is changing
  - The following properties in the output type are being deprecated : 'Properties'
  - The following properties are being added to the output type : 'Description' 'DisplayName' 'Metadata' 'Parameters' 'PolicyDefinitionGroups' 'PolicyDefinitions' 'PolicyType'
  - This change is expected to take effect from Az.Resources version: 7.1.0 and Az version: 12.0.0

## Az.Sql

### `New-AzSqlDatabaseFailoverGroup`

- Cmdlet breaking-change will happen to all parameter sets
  - The default value of FailoverPolicy will change from Automatic to Manual
  - This change is expected to take effect from Az.Sql version: 5.0.0 and Az version: 12.0.0

### `Set-AzSqlDatabaseFailoverGroup`

- Cmdlet breaking-change will happen to all parameter sets
  - The default value of FailoverPolicy will change from Automatic to Manual
  - This change is expected to take effect from Az.Sql version: 5.0.0 and Az version: 12.0.0

## Az.Storage

### `Get-AzStorageQueue`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudQueue and EncodeMessage from deprecated v11 SDK will be removed. Use child property QueueClient instead of CloudQueue.
  - This change is expected to take effect from Az.Storage version: 6.0.0 and Az version: 11.0.0

### `New-AzStorageQueue`

- Cmdlet breaking-change will happen to all parameter sets
  - The child property CloudQueue and EncodeMessage from deprecated v11 SDK will be removed. Use child property QueueClient instead of CloudQueue.
  - This change is expected to take effect from Az.Storage version: 6.0.0 and Az version: 11.0.0

### `New-AzStorageQueueSASToken`

- Parameter breaking-change will happen to all parameter sets
  - `-Protocol`
    - The type of parameter Protocol will be changed from SharedAccessProtocol to string.
    - This change is expected to take effect from Az.Storage version: 7.0.0 and Az version: 12.0.0

### `Set-AzStorageAccount`

- Parameter breaking-change will happen to all parameter sets
  - `-UpgradeToStorageV2`
    - A prompt that needs users' confirmation will be added when upgrading a storage account from StorageV1 or BlobStorage to StorageV2. Suppress it with -Force.
    - This change is expected to take effect from Az.Storage version: 7.0.0 and Az version: 12.0.0

### `Set-AzStorageFileContent`

- Parameter breaking-change will happen to all parameter sets
  - `-Path`
    - When uploading using SAS token without Read permission, the destination path will be taken as a file path, instead of a directory path previously.
    - This change is expected to take effect from Az.Storage version: 7.0.0 and Az version: 12.0.0

