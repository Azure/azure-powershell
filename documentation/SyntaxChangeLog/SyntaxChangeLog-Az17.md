## 17.0.0 - November 2026
#### Az.Automation 1.13.0 
* Added cmdlet `Get-AzAutomationRuntimeEnvironment`, `Get-AzAutomationRuntimeEnvironmentPackage`, `New-AzAutomationRuntimeEnvironment`, `New-AzAutomationRuntimeEnvironmentPackage`, `Remove-AzAutomationRuntimeEnvironment`, `Remove-AzAutomationRuntimeEnvironmentPackage`, `Set-AzAutomationRuntimeEnvironment`, `Set-AzAutomationRuntimeEnvironmentPackage`
#### Az.Cdn 7.0.0 
* Removed cmdlet `Add-AzCdnEdgeActionAttachment`, `Deploy-AzCdnEdgeActionVersionCode`, `Get-AzCdnEdgeAction`, `Get-AzCdnEdgeActionExecutionFilter`, `Get-AzCdnEdgeActionVersion`, `Get-AzCdnEdgeActionVersionCode`, `New-AzCdnEdgeAction`, `New-AzCdnEdgeActionExecutionFilter`, `New-AzCdnEdgeActionVersion`, `New-AzFrontDoorCdnSecretUrlSigningKeyParametersObject`, `Remove-AzCdnEdgeAction`, `Remove-AzCdnEdgeActionAttachment`, `Remove-AzCdnEdgeActionExecutionFilter`, `Remove-AzCdnEdgeActionVersion`, `Update-AzCdnEdgeAction`, `Update-AzCdnEdgeActionExecutionFilter`, `Update-AzCdnEdgeActionVersion`
#### Az.Compute 11.12.0 
* Added cmdlet `Remove-AzSnapshotImmutabilityPolicy`, `Set-AzSnapshotImmutabilityPolicy`
#### Az.NetAppFiles 2.0.0 
* Removed cmdlet `Get-AzNetAppFilesSubvolume`, `Get-AzNetAppFilesSubvolumeMetadata`
* Modified cmdlet `New-AzNetAppFilesAccount`
   - Added parameter `-LdapConfiguration`
* Removed cmdlet `New-AzNetAppFilesSubvolume`
* Modified cmdlet `New-AzNetAppFilesVolume`
   - Removed parameter `-EnableSubvolume`
* Removed cmdlet `Remove-AzNetAppFilesSubvolume`
* Modified cmdlet `Set-AzNetAppFilesAccount`
   - Added parameter `-LdapConfiguration`
* Modified cmdlet `Update-AzNetAppFilesAccount`
   - Added parameter `-LdapConfiguration`
* Removed cmdlet `Update-AzNetAppFilesSubvolume`
* Added cmdlet `Update-AzNetAppFilesAccountLdapBindPassword`
#### Az.RedisEnterpriseCache 2.1.0 
* Modified cmdlet `New-AzRedisEnterpriseCache`
   - Added parameters `-NotifyKeyspaceEvents`, `-MaintenanceConfigurationMaintenanceWindow`
* Modified cmdlet `New-AzRedisEnterpriseCacheDatabase`
   - Added parameter `-NotifyKeyspaceEvents`
* Modified cmdlet `Update-AzRedisEnterpriseCache`
   - Added parameter `-MaintenanceConfigurationMaintenanceWindow`
* Modified cmdlet `Update-AzRedisEnterpriseCacheDatabase`
   - Added parameter `-NotifyKeyspaceEvents`
* Added cmdlet `Get-AzRedisEnterpriseCacheMigration`, `Invoke-AzRedisEnterpriseCacheClusterUnlinkMigratedEndpoint`, `Invoke-AzRedisEnterpriseCacheMigrationUnlinkMigratedEndpoint`, `Start-AzRedisEnterpriseCacheMigration`, `Test-AzRedisEnterpriseCacheMigration`, `Undo-AzRedisEnterpriseCacheMigration`
#### Az.Storage 9.8.0 
* Modified cmdlet `New-AzRmStorageContainer`
   - Added parameters `-BlobAccessPointConfigurationName`, `-BlobAccessPointConfigurationUniqueId`
* Modified cmdlet `New-AzStorageAccount`
   - Added parameters `-AllowSharedKeyAccessForBlob`, `-AllowSharedKeyAccessForFile`, `-AllowSharedKeyAccessForQueue`, `-AllowSharedKeyAccessForTable`, `-AllowCrossTenantDelegationSas`, `-PublishIpv6Endpoint`, `-RequireUserBoundUserDelegationSas`, `-RequireUserBoundUserDelegationSasAction`, `-AllowBlobAccessPoints`, `-TurboTierStatus`, `-TurboTierTargetPercent`
* Modified cmdlet `Set-AzStorageAccount`
   - Added parameters `-AllowSharedKeyAccessForBlob`, `-AllowSharedKeyAccessForFile`, `-AllowSharedKeyAccessForQueue`, `-AllowSharedKeyAccessForTable`, `-AllowCrossTenantDelegationSas`, `-PublishIpv6Endpoint`, `-RequireUserBoundUserDelegationSas`, `-RequireUserBoundUserDelegationSasAction`, `-AllowBlobAccessPoints`, `-TurboTierStatus`, `-TurboTierTargetPercent`
* Added cmdlet `Get-AzStorageAdvancedPlatformMetricsRule`, `Get-AzStorageBlobAccessPointConfiguration`, `Get-AzStorageContextCache`, `Get-AzStorageContextCacheContainer`, `New-AzStorageAdvancedPlatformMetricsRule`, `New-AzStorageBlobAccessPointConfiguration`, `New-AzStorageContextCache`, `New-AzStorageContextCacheContainer`, `Remove-AzStorageAdvancedPlatformMetricsRule`, `Remove-AzStorageBlobAccessPointConfiguration`, `Remove-AzStorageContextCache`, `Remove-AzStorageContextCacheContainer`, `Set-AzStorageAdvancedPlatformMetricsRule`, `Set-AzStorageContextCache`, `Set-AzStorageContextCacheContainer`, `Test-AzStorageBlobAccessPointConfigurationConnection`, `Test-AzStorageBlobAccessPointConnection`, `Test-AzStorageContextCacheNameAvailability`, `Update-AzStorageAdvancedPlatformMetricsRule`, `Update-AzStorageBlobAccessPointConfiguration`, `Update-AzStorageContextCache`, `Update-AzStorageContextCacheContainer`


