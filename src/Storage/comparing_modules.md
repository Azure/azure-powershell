## Incorrect Cmdlets

- [x] Get-AzStorageAccount
    - Name
- [x] New-AzStorageAccount
    - UseSubDomain
    - AssignIdentity
    - NetworkRuleSet
    - EnableHierarchicalNamespace
- [x] Remove-AzStorageAccount
    - Force
    - AsJob
- [x] Set-AzStorageAccount
    - Force
    - SkuName
    - AccessTier
    - CustomDomainName
    - UseSubDomain
    - Tag
    - EnableHttpsTrafficOnly
    - StorageEncryption
    - KeyvaultEncryption
    - KeyName
    - KeyVersion
    - KeyVaultUri
    - AssignIdentity
    - NetworkRuleSet
    - UpgradeToStorageV2

## Correct Cmdlets

- [x] Get-AzStorageAccountKey
- [x] New-AzStorageAccountKey

## New Cmdlets

- [ ] Clear-AzBlobContainerLegalHold
- [ ] Get-AzBlobContainer
- [ ] Get-AzBlobContainerImmutabilityPolicy
- [ ] Get-AzBlobServiceProperty
- [x] Get-AzManagementPolicy
- [x] Get-AzSku
- [x] Get-AzStorageAccountProperty
- [x] Get-AzStorageAccountSas
- [x] Get-AzStorageAccountServiceSas
- [x] Get-AzUsage
- [ ] Invoke-AzExtendBlobContainerImmutabilityPolicy
- [ ] Invoke-AzLeaseBlobContainer
- [ ] Lock-AzBlobContainerImmutabilityPolicy
- [ ] New-AzBlobContainer
- [ ] New-AzBlobContainerImmutabilityPolicy
- [x] New-AzManagementPolicy
- [ ] Remove-AzBlobContainer
- [ ] Remove-AzBlobContainerImmutabilityPolicy
- [x] Remove-AzManagementPolicy
- [x] Revoke-AzStorageAccountUserDelegationKey
- [ ] Set-AzBlobContainerImmutabilityPolicy
- [ ] Set-AzBlobContainerLegalHold
- [ ] Set-AzBlobServiceProperty
- [x] Set-AzManagementPolicy
- [x] Test-AzStorageAccountNameAvailability
- [ ] Update-AzBlobContainer
- [x] Update-AzStorageAccount

## Missing Cmdlets

- [ ] Add-AzRmStorageContainerLegalHold
- [x] Add-AzStorageAccountManagementPolicyAction
- [x] Add-AzStorageAccountNetworkRule
- [ ] Disable-AzStorageBlobDeleteRetentionPolicy
- [ ] Enable-AzStorageBlobDeleteRetentionPolicy
- [ ] Get-AzRmStorageContainer
- [ ] Get-AzRmStorageContainerImmutabilityPolicy
- [x] Get-AzStorageAccountManagementPolicy
- [x] Get-AzStorageAccountNameAvailability
- [x] Get-AzStorageAccountNetworkRuleSet
- [ ] Get-AzStorageBlobServiceProperty
- [ ] Get-AzStorageUsage
- [ ] Lock-AzRmStorageContainerImmutabilityPolicy
- [ ] New-AzRmStorageContainer
- [x] New-AzStorageAccountManagementPolicyFilter
- [x] New-AzStorageAccountManagementPolicyRule
- [ ] Remove-AzRmStorageContainer
- [ ] Remove-AzRmStorageContainerImmutabilityPolicy
- [ ] Remove-AzRmStorageContainerLegalHold
- [x] Remove-AzStorageAccountManagementPolicy
- [x] Remove-AzStorageAccountNetworkRule
- [x] Set-AzCurrentStorageAccount
- [ ] Set-AzRmStorageContainerImmutabilityPolicy
- [x] Set-AzStorageAccountManagementPolicy
- [ ] Update-AzRmStorageContainer
- [x] Update-AzStorageAccountNetworkRuleSet
- [ ] Update-AzStorageBlobServiceProperty
