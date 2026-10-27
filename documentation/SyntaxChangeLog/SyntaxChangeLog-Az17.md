## 17.0.0 - November 2026
#### Az.Automation 1.12.1 
* Added cmdlet `Get-AzAutomationRuntimeEnvironment`, `Get-AzAutomationRuntimeEnvironmentPackage`, `New-AzAutomationRuntimeEnvironment`, `New-AzAutomationRuntimeEnvironmentPackage`, `Remove-AzAutomationRuntimeEnvironment`, `Remove-AzAutomationRuntimeEnvironmentPackage`, `Set-AzAutomationRuntimeEnvironment`, `Set-AzAutomationRuntimeEnvironmentPackage`
#### Az.Cdn 6.3.0 
* Modified cmdlet `New-AzFrontDoorCdnCustomDomainTlsSettingParametersObject`
   - Added parameters `-ServerTlsGroup`, `-ServerTlsGroupPolicy`
* Modified cmdlet `New-AzFrontDoorCdnOrigin`
   - Added parameters `-CertificateNameCheckValidationMode`, `-CustomCertificateSubject`
* Modified cmdlet `Update-AzFrontDoorCdnOrigin`
   - Added parameters `-CertificateNameCheckValidationMode`, `-CustomCertificateSubject`
#### Az.Compute 11.11.0 
* Modified cmdlet `New-AzGallery`
   - Added parameters `-EnableSoftDelete`, `-SoftDeleteRetentionPeriodInDays`, `-SoftDeleteGracePeriodInDays`
* Modified cmdlet `Remove-AzGalleryImageVersion`
   - Added parameter `-BypassSoftDelete`
* Modified cmdlet `Update-AzGallery`
   - Added parameters `-EnableSoftDelete`, `-DisableSoftDelete`, `-SoftDeleteRetentionPeriodInDays`, `-SoftDeleteGracePeriodInDays`
* Added cmdlet `Get-AzGallerySoftDeletedImageVersion`, `Restore-AzGalleryImageVersion`
#### Az.ConnectedMachine 1.2.0 
* Modified cmdlet `Install-AzConnectedMachinePatch`
   - Added parameters `-WindowParameterPatchNameMasksToExclude`, `-WindowParameterPatchNameMasksToInclude`
* Modified cmdlet `New-AzConnectedMachineRunCommand`
   - Changed the type of parameter `-RunAsPassword` from `String` to `SecureString`
* Modified cmdlet `New-AzConnectedPrivateLinkScope`
   - Added parameter `-ServiceExtension`
* Modified cmdlet `Remove-AzConnectedMachine`
   - Added parameters `-AsJob`, `-NoWait`
* Modified cmdlet `Set-AzConnectedPrivateLinkScope`
   - Added parameter `-ServiceExtension`
* Modified cmdlet `Update-AzConnectedMachineRunCommand`
   - Changed the type of parameter `-RunAsPassword` from `String` to `SecureString`
* Added cmdlet `Get-AzConnectedExtensionMetadataV2`, `Get-AzConnectedExtensionPublisher`, `Get-AzConnectedExtensionType`#### Az.EventHub 5.8.0 
, `Approve-AzEventHubFabricShortcut`, `Get-AzEventHubFabricShortcut`, `Get-AzEventHubUpgradePreferencesOperation`, `Invoke-AzEventHubRejectFabricShortcut`, `New-AzEventHubFabricShortcut`, `New-AzEventHubUpgradePreferencesOperation`, `Remove-AzEventHubFabricShortcut`
#### Az.Migrate 0.1.0 
* Modified cmdlet `New-AzMigrateLocalServerReplication`
   - Added parameters `-TargetVMSecurityOption`, `-EnableSecureBoot`
* Modified cmdlet `Set-AzMigrateLocalServerReplication`
   - Added parameters `-TargetVMSecurityOption`, `-EnableSecureBoot`
#### Az.Network 8.4.0 
* Modified cmdlet `New-AzDdosCustomPolicy`
   - Added parameter `-MitigationRule`
* Modified cmdlet `New-AzNetworkVirtualAppliance`
   - Added parameter `-AddressFamily`
* Modified cmdlet `New-AzVirtualNetworkAppliance`
   - Added parameter `-CapacityProviderId`
* Modified cmdlet `Update-AzNetworkVirtualAppliance`
   - Added parameter `-AddressFamily`
* Modified cmdlet `Update-AzVirtualNetworkAppliance`
   - Added parameter `-CapacityProviderId`
* Added cmdlet `Add-AzDdosCustomPolicyMitigationRule`, `Add-AzExpressRouteLagAuthorization`, `Get-AzDdosCustomPolicyDetectionRule`, `Get-AzDdosCustomPolicyMitigationRule`, `Get-AzExpressRouteLagAuthorization`, `Get-AzExpressRouteLagAuthorizationKey`, `Get-AzVirtualNetworkApplianceCapability`, `New-AzDdosCustomPolicyMitigationRule`, `New-AzVirtualNetworkApplianceCapability`, `Remove-AzDdosCustomPolicyMitigationRule`, `Remove-AzExpressRouteLagAuthorization`, `Remove-AzVirtualNetworkApplianceCapability`, `Set-AzDdosCustomPolicyDetectionRule`, `Set-AzDdosCustomPolicyMitigationRule`
#### Az.Relay 3.1.0 
* Modified cmdlet `New-AzRelayNamespace`
   - Added parameters `-ClusterArmId`, `-MinimumTlsVersion`
* Modified cmdlet `Update-AzRelayNamespace`
   - Added parameters `-ClusterArmId`, `-MinimumTlsVersion`, `-AsJob`, `-NoWait`
* Added cmdlet `Get-AzRelayCluster`, `Get-AzRelayClusterAvailableClusterRegion`, `Get-AzRelayClusterNamespace`, `Get-AzRelayClusterSku`, `New-AzRelayCluster`, `Remove-AzRelayCluster`, `Set-AzRelayCluster`
#### Az.Sql 7.3.0 
* Modified cmdlet `Set-AzSqlDatabaseBackupShortTermRetentionPolicy`
   - Added parameters `-LockImmutability`, `-Force`
* Modified cmdlet `Set-AzSqlInstanceDatabaseBackupLongTermRetentionPolicy`
   - Added parameters `-TimeBasedImmutability`, `-TimeBasedImmutabilityMode`
* Modified cmdlet `Set-AzSqlInstanceDatabaseBackupShortTermRetentionPolicy`
   - Added parameters `-LockImmutability`, `-Force`
* Added cmdlet `Lock-AzSqlInstanceDatabaseLongTermRetentionBackupImmutability`, `Remove-AzSqlInstanceDatabaseLongTermRetentionBackupImmutability`, `Remove-AzSqlInstanceDatabaseLongTermRetentionBackupLegalHold`, `Set-AzSqlInstanceDatabaseLongTermRetentionBackupLegalHold`
#### Az.StorageMover 2.2.0 
* Modified cmdlet `New-AzStorageMoverAzNfsFileShareEndpoint`
   - Added parameter `-EndpointKind`
* Modified cmdlet `New-AzStorageMoverAzSmbFileShareEndpoint`
   - Added parameters `-EndpointKind`, `-EnableCrossTenantTransfer`, `-AllowedStorageAccount`
* Modified cmdlet `New-AzStorageMoverAzStorageContainerEndpoint`
   - Added parameters `-EndpointKind`, `-EnableCrossTenantTransfer`, `-AllowedStorageAccount`
* Modified cmdlet `New-AzStorageMoverJobDefinition`
   - Added parameters `-CrossTenantEndpointResourceId`, `-CrossTenantEndpointTenantId`, `-IsCrossTenantJob`, `-MoverSyncedUntil`, `-ScheduleRepeatInterval`, `-SyncMode`
* Modified cmdlet `New-AzStorageMoverMultiCloudConnectorEndpoint`
   - Added parameter `-EndpointKind`
* Modified cmdlet `New-AzStorageMoverNfsEndpoint`
   - Added parameters `-EndpointKind`, `-SourceType`
* Modified cmdlet `New-AzStorageMoverS3WithHmacEndpoint`
   - Added parameter `-EndpointKind`
* Modified cmdlet `New-AzStorageMoverSmbEndpoint`
   - Added parameters `-EndpointKind`, `-SourceType`
* Modified cmdlet `Update-AzStorageMoverAzSmbFileShareEndpoint`
   - Added parameters `-EnableCrossTenantTransfer`, `-AllowedStorageAccount`
* Modified cmdlet `Update-AzStorageMoverAzStorageContainerEndpoint`
   - Added parameters `-EnableCrossTenantTransfer`, `-AllowedStorageAccount`
* Modified cmdlet `Update-AzStorageMoverJobDefinition`
   - Added parameters `-MoverSyncedUntil`, `-ScheduleRepeatInterval`, `-SyncMode`
* Added cmdlet `Invoke-AzStorageMoverReconcileJobDefinition`
#### Az.TrafficManager 1.6.0 
* Modified cmdlet `New-AzTrafficManagerProfile`
   - Added parameter `-RecordType`
#### Az.Websites 4.3.0 
* Modified cmdlet `New-AzAppServicePlan`
   - Added parameters `-ManagedInstance`, `-AssignIdentity`, `-UserAssignedIdentityId`, `-DefaultIdentity`, `-RdpEnabled`, `-VirtualNetworkSubnetId`, `-InstallScript`, `-StorageMount`, `-RegistryAdapter`
* Modified cmdlet `Set-AzAppServicePlan`
   - Added parameters `-AssignIdentity`, `-UserAssignedIdentityId`, `-DefaultIdentity`, `-RdpEnabled`, `-VirtualNetworkSubnetId`, `-InstallScript`, `-StorageMount`, `-RegistryAdapter`
* Modified cmdlet `New-AzStaticWebApp`
   - Removed parameters `-InputObject`, `-JsonString`, `-JsonFilePath`
* Added cmdlet `Get-AzAppServicePlanManagedInstance`, `Get-AzAppServicePlanRdpCredential`, `Restart-AzAppServicePlanManagedInstance`


