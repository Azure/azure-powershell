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

## Az.Storage

### `New-AzStorageAccount`

- Cmdlet breaking-change will happen to all parameter sets
  - Default value of AllowBlobPublicAccess and AllowCrossTenantReplication settings on storage account will be changed to False in the future release. 
  When AllowBlobPublicAccess is False on a storage account, container ACLs cannot be configured to allow anonymous access to blobs within the storage account. 
  When AllowCrossTenantReplication is False on a storage account, cross AAD tenant object replication is not allowed when setting up Object Replication policies. Target version is for reference only, it might be changed by service plan.
  - This change is expected to take effect from Az.Storage version: 6.2.0 and Az version: 11.2.0

