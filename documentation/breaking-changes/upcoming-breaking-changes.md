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

## Az.Aks

### `New-AzAkscluster`

- Cmdlet breaking-change will happen to all parameter sets
  - The default created service principal will only have contributor role for this resource group.
  - This change is expected to take effect from Az.Aks version: 6.X and Az version: 12.0.0


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

