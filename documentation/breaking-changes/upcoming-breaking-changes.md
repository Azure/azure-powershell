# Upcoming breaking changes in Azure PowerShell

## Az.Storage

### `New-AzStorageAccount`

- Cmdlet breaking-change will happen to all parameter sets
  - Default value of AllowBlobPublicAccess and AllowCrossTenantReplication settings on storage account will be changed to False in the future release. 
  When AllowBlobPublicAccess is False on a storage account, container ACLs cannot be configured to allow anonymous access to blobs within the storage account. 
  When AllowCrossTenantReplication is False on a storage account, cross AAD tenant object replication is not allowed when setting up Object Replication policies. Target version is for reference only, it might be changed by service plan.
  - This change is expected to take effect from Az.Storage version: 6.2.0 and Az version: 11.2.0

