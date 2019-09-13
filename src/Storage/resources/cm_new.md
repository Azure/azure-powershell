## Incorrect Cmdlets

- Clear-AzRmStorageContainerLegalHold
    - StorageAccount
    - Container
- Get-AzRmStorageContainer
    - StorageAccount
- Get-AzRmStorageContainerImmutabilityPolicy
    - StorageAccount
    - Container
- Get-AzStorageAccountManagementPolicy
    - StorageAccountName
    - StorageAccountResourceId
    - StorageAccount
- Get-AzStorageBlobServiceProperty
    - StorageAccount
- Lock-AzRmStorageContainerImmutabilityPolicy
    - StorageAccount
    - Container
    - Force
- New-AzRmStorageContainer
    - StorageAccount
- New-AzStorageAccount
    - UseSubDomain
    - NetworkRuleSet
- Remove-AzRmStorageContainer
    - StorageAccount
    - Force
- Remove-AzRmStorageContainerImmutabilityPolicy
    - StorageAccount
    - Container
- Remove-AzStorageAccount
    - Force
    - AsJob
- Remove-AzStorageAccountManagementPolicy
    - StorageAccountName
    - StorageAccount
    - StorageAccountResourceId
- Set-AzRmStorageContainerImmutabilityPolicy
    - StorageAccount
    - Container
    - InputObject
- Set-AzRmStorageContainerLegalHold
    - StorageAccount
    - Container
- Set-AzStorageAccountManagementPolicy
    - StorageAccountName
    - StorageAccount
    - StorageAccountResourceId
    - Rule
    - Policy
- Update-AzRmStorageContainer
    - StorageAccount

## Correct Cmdlets

- Get-AzStorageAccount
- Get-AzStorageAccountKey
- Get-AzStorageUsage
- New-AzStorageAccountKey
- Test-AzStorageAccountNameAvailability

## New Cmdlets

- Get-AzFileService
- Get-AzFileServiceProperty
- Get-AzFileShare
- Get-AzSku
- Get-AzStorageAccountSas
- Get-AzStorageAccountServiceSas
- Get-AzStorageBlobService
- Invoke-AzLeaseBlobContainer
- Invoke-AzStorageAccountFailover
- New-AzFileShare
- New-AzRmStorageContainerImmutabilityPolicy
- New-AzStorageAccountManagementPolicy
- Remove-AzFileShare
- Revoke-AzStorageAccountUserDelegationKey
- Set-AzFileServiceProperty
- Set-AzStorageBlobServiceProperty
- Update-AzFileShare
- Update-AzStorageAccount

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
- Set-AzStorageAccount
- Update-AzStorageAccountNetworkRuleSet
- Update-AzStorageBlobServiceProperty
