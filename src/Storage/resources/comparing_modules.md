## Incorrect Cmdlets

- Clear-AzRmStorageContainerLegalHold
    - StorageAccount
    - Container
- Get-AzRmStorageContainer
    - StorageAccount
- Get-AzRmStorageContainerImmutabilityPolicy
    - StorageAccount
    - Container
    - Etag
- Get-AzStorageAccount
    - Name
- Get-AzStorageAccountManagementPolicy
    - StorageAccountResourceId
    - StorageAccount
- Get-AzStorageBlobServiceProperty
    - StorageAccount
- Lock-AzRmStorageContainerImmutabilityPolicy
    - StorageAccount
    - Container
    - Etag
    - Force
- New-AzRmStorageContainer
    - StorageAccount
- New-AzStorageAccount
    - AssignIdentity
    - NetworkRuleSet
    - EnableHierarchicalNamespace
- Remove-AzRmStorageContainer
    - StorageAccount
    - Force
- Remove-AzRmStorageContainerImmutabilityPolicy
    - StorageAccount
    - Container
    - Etag
- Remove-AzStorageAccount
    - Force
    - AsJob
- Remove-AzStorageAccountManagementPolicy
    - StorageAccount
    - StorageAccountResourceId
- Set-AzRmStorageContainerImmutabilityPolicy
    - StorageAccount
    - Container
    - ImmutabilityPeriod
    - Etag
    - ExtendPolicy
- Set-AzRmStorageContainerLegalHold
    - StorageAccount
    - Container
- Set-AzStorageAccount
    - Force
    - StorageEncryption
    - KeyvaultEncryption
    - AssignIdentity
    - NetworkRuleSet
    - UpgradeToStorageV2
    - AsJob
- Set-AzStorageAccountManagementPolicy
    - StorageAccount
    - StorageAccountResourceId
    - Rule
    - Policy
- Update-AzRmStorageContainer
    - StorageAccount

## Correct Cmdlets

- Get-AzStorageAccountKey
- Get-AzStorageUsage
- New-AzStorageAccountKey
- Test-AzStorageAccountNameAvailability

## New Cmdlets

- Get-AzSku
- Get-AzStorageAccountProperty
- Get-AzStorageAccountSas
- Get-AzStorageAccountServiceSas
- Invoke-AzExtendBlobContainerImmutabilityPolicy
- Invoke-AzLeaseBlobContainer
- Invoke-AzStorageAccountFailover
- New-AzRmStorageContainerImmutabilityPolicy
- New-AzStorageAccountManagementPolicy
- Revoke-AzStorageAccountUserDelegationKey
- Set-AzStorageBlobServiceProperty

## Missing Cmdlets

- Add-AzStorageAccountManagementPolicyAction
- Add-AzStorageAccountNetworkRule
- Disable-AzStorageBlobDeleteRetentionPolicy
- Enable-AzStorageBlobDeleteRetentionPolicy
- Get-AzStorageAccountNetworkRuleSet
- New-AzStorageAccountManagementPolicyFilter
- New-AzStorageAccountManagementPolicyRule
- Remove-AzStorageAccountNetworkRule
- Set-AzCurrentStorageAccount
- Update-AzStorageAccountNetworkRuleSet
- Update-AzStorageBlobServiceProperty
