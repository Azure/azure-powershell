# Release notes for module Az.Storage

## Version x.x.x.-preview

## What's new

All in-memory create cmdlets were removed in favor of `flattened` cmdlet parameters. This allows you to specify the properties of many objects inline, and for others, provide a simple inline hashtable like ```@{Property1="Value1"}```.

### Notes

* `Get-AzStorageAccount` providing `-Name` retrieves several properties about an existing storage account.
The returned object has some properties such as the network rule set that were before retrieved using `Get-AzStorageAccountNetworkRuleSet`.

## Future enhancements

## Supported cmdlets

- Clear-AzRmStorageContainerLegalHold
- Close-AzStorageFileHandle
- Disable-AzStorageDeleteRetentionPolicy
- Disable-AzStorageStaticWebsite
- Enable-AzStorageDeleteRetentionPolicy
- Enable-AzStorageStaticWebsite
- Get-AzFileService
- Get-AzFileServiceProperty
- Get-AzFileShare
- Get-AzRmStorageContainer
- Get-AzRmStorageContainerImmutabilityPolicy
- Get-AzSku
- Get-AzStorageAccount
- Get-AzStorageAccountKey
- Get-AzStorageAccountManagementPolicy
- Get-AzStorageAccountSas
- Get-AzStorageAccountServiceSas
- Get-AzStorageBlob
- Get-AzStorageBlobContent
- Get-AzStorageBlobCopyState
- Get-AzStorageBlobService
- Get-AzStorageBlobServiceProperty
- Get-AzStorageContainer
- Get-AzStorageContainerStoredAccessPolicy
- Get-AzStorageCORSRule
- Get-AzStorageFile
- Get-AzStorageFileContent
- Get-AzStorageFileCopyState
- Get-AzStorageFileHandle
- Get-AzStorageQueue
- Get-AzStorageQueueStoredAccessPolicy
- Get-AzStorageServiceLoggingProperty
- Get-AzStorageServiceMetricsProperty
- Get-AzStorageServiceProperty
- Get-AzStorageShare
- Get-AzStorageShareStoredAccessPolicy
- Get-AzStorageTable
- Get-AzStorageTableStoredAccessPolicy
- Get-AzStorageUsage
- Invoke-AzLeaseBlobContainer
- Invoke-AzStorageAccountFailover
- Lock-AzRmStorageContainerImmutabilityPolicy
- New-AzFileShare
- New-AzRmStorageContainer
- New-AzRmStorageContainerImmutabilityPolicy
- New-AzStorageAccount
- New-AzStorageAccountKey
- New-AzStorageAccountManagementPolicy
- New-AzStorageAccountSASToken
- New-AzStorageBlobSASToken
- New-AzStorageContainer
- New-AzStorageContainerSASToken
- New-AzStorageContainerStoredAccessPolicy
- New-AzStorageContext
- New-AzStorageDirectory
- New-AzStorageFileSASToken
- New-AzStorageQueue
- New-AzStorageQueueSASToken
- New-AzStorageQueueStoredAccessPolicy
- New-AzStorageShare
- New-AzStorageShareSASToken
- New-AzStorageShareStoredAccessPolicy
- New-AzStorageTable
- New-AzStorageTableSASToken
- New-AzStorageTableStoredAccessPolicy
- Remove-AzFileShare
- Remove-AzRmStorageContainer
- Remove-AzRmStorageContainerImmutabilityPolicy
- Remove-AzStorageAccount
- Remove-AzStorageAccountManagementPolicy
- Remove-AzStorageBlob
- Remove-AzStorageContainer
- Remove-AzStorageContainerStoredAccessPolicy
- Remove-AzStorageCORSRule
- Remove-AzStorageDirectory
- Remove-AzStorageFile
- Remove-AzStorageQueue
- Remove-AzStorageQueueStoredAccessPolicy
- Remove-AzStorageShare
- Remove-AzStorageShareStoredAccessPolicy
- Remove-AzStorageTable
- Remove-AzStorageTableStoredAccessPolicy
- Revoke-AzStorageAccountUserDelegationKey
- Set-AzFileServiceProperty
- Set-AzRmStorageContainerImmutabilityPolicy
- Set-AzRmStorageContainerLegalHold
- Set-AzStorageAccountManagementPolicy
- Set-AzStorageBlobContent
- Set-AzStorageBlobServiceProperty
- Set-AzStorageContainerAcl
- Set-AzStorageContainerStoredAccessPolicy
- Set-AzStorageCORSRule
- Set-AzStorageFileContent
- Set-AzStorageQueueStoredAccessPolicy
- Set-AzStorageServiceLoggingProperty
- Set-AzStorageServiceMetricsProperty
- Set-AzStorageShareQuota
- Set-AzStorageShareStoredAccessPolicy
- Set-AzStorageTableStoredAccessPolicy
- Start-AzStorageBlobCopy
- Start-AzStorageBlobIncrementalCopy
- Start-AzStorageFileCopy
- Stop-AzStorageBlobCopy
- Stop-AzStorageFileCopy
- Test-AzStorageAccountNameAvailability
- Update-AzFileShare
- Update-AzRmStorageContainer
- Update-AzStorageAccount
- Update-AzStorageServiceProperty

## Removed cmdlets

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
