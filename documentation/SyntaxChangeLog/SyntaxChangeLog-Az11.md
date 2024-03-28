## 11.5.0 - April 2024
#### Az.Accounts 2.17.0 
* Modified cmdlet `Clear-AzConfig`
   - Added parameter `-DisableInstanceDiscovery`
* Modified cmdlet `Get-AzAccessToken`
   - Added parameter `-AsSecureString`
* Modified cmdlet `Get-AzConfig`
   - Added parameter `-DisableInstanceDiscovery`
* Modified cmdlet `Update-AzConfig`
   - Added parameter `-DisableInstanceDiscovery`
#### Az.Compute 7.2.0 
* Modified cmdlet `New-AzCapacityReservationGroup`
   - Added parameter `-SharingProfile`
* Modified cmdlet `New-AzGalleryImageVersion`
   - Added parameter `-SourceImageVMId`
* Modified cmdlet `New-AzSnapshotConfig`
   - Added parameter `-TierOption`
* Modified cmdlet `New-AzVmss`
   - Added parameter `-EnableAutomaticOSUpgrade`
* Modified cmdlet `New-AzVmssConfig`
   - Removed parameter `-AutoOSUpgrade`
   - Added parameter `-EnableAutomaticOSUpgrade`
* Modified cmdlet `Update-AzCapacityReservationGroup`
   - Added parameter `-SharingProfile`
* Modified cmdlet `Set-AzVMRunCommand`
   - Added parameters `-ErrorBlobManagedIdentityClientId`, `-ErrorBlobManagedIdentityObjectId`, `-OutputBlobManagedIdentityClientId`, `-OutputBlobManagedIdentityObjectId`, `-ScriptUriManagedIdentityClientId`, `-ScriptUriManagedIdentityObjectId`, `-TreatFailureAsDeploymentFailure`
* Modified cmdlet `Set-AzVmssVMRunCommand`
   - Added parameters `-ErrorBlobManagedIdentityClientId`, `-ErrorBlobManagedIdentityObjectId`, `-OutputBlobManagedIdentityClientId`, `-OutputBlobManagedIdentityObjectId`, `-ScriptUriManagedIdentityClientId`, `-ScriptUriManagedIdentityObjectId`, `-TreatFailureAsDeploymentFailure`
#### Az.ContainerRegistry 4.2.0 
* Modified cmdlet `Connect-AzContainerRegistry`
   - Added parameter `-ExposeToken`
#### Az.DataProtection 2.3.0 
* Modified cmdlet `Search-AzDataProtectionBackupVaultInAzGraph`
   - Added parameter alias `SubscriptionId` to parameter `-Subscription`
   - Added parameter alias `ResourceGroupName` to parameter `-ResourceGroup`
   - Added parameter alias `VaultName` to parameter `-Vault`
* Modified cmdlet `Set-AzDataProtectionMSIPermission`
   - Added parameters `-SubscriptionId`, `-DatasourceType`, `-StorageAccountARMId`
   - Added parameter alias `ResourceGroupName` to parameter `-VaultResourceGroup`
#### Az.RecoveryServices 6.8.0 
* Modified cmdlet `New-AzRecoveryServicesBackupProtectionPolicy`
   - Added parameter `-SnapshotConsistencyType`
* Modified cmdlet `Set-AzRecoveryServicesBackupProtectionPolicy`
   - Added parameter `-SnapshotConsistencyType`
#### Az.ServiceBus 3.1.0 
* Modified cmdlet `New-AzServiceBusGeoDRConfiguration`
   - Added parameter `-PassThru`

## 11.4.0 - March 2024
#### Az.Accounts 2.16.0 
* Modified cmdlet `Clear-AzConfig`
   - Added parameter `-DisplaySecretsWarning`
* Modified cmdlet `Get-AzConfig`
   - Added parameter `-DisplaySecretsWarning`
* Modified cmdlet `Update-AzConfig`
   - Added parameter `-DisplaySecretsWarning`
#### Az.Monitor 5.1.0 
* Added cmdlet `Get-AzMetricsBatch`
#### Az.RedisCache 1.9.0 
* Modified cmdlet `New-AzRedisCache`
   - Added parameter `-UpdateChannel`
* Modified cmdlet `Set-AzRedisCache`
   - Added parameter `-UpdateChannel`
* Added cmdlet `Clear-AzRedisCache`, `Get-AzRedisCacheAccessPolicy`, `Get-AzRedisCacheAccessPolicyAssignment`, `New-AzRedisCacheAccessPolicy`, `New-AzRedisCacheAccessPolicyAssignment`, `Remove-AzRedisCacheAccessPolicy`, `Remove-AzRedisCacheAccessPolicyAssignment`
#### Az.Resources 6.16.0 
* Modified cmdlet `New-AzResourceGroupDeployment`
   - Added parameter `-AuxTenant`
#### Az.Security 1.6.0 
* Added cmdlet `Get-AzSecurityApiCollection`, `Get-AzSecurityConnector`, `Get-AzSecurityConnectorAzureDevOpsOrg`, `Get-AzSecurityConnectorAzureDevOpsOrgAvailable`, `Get-AzSecurityConnectorAzureDevOpsProject`, `Get-AzSecurityConnectorAzureDevOpsRepo`, `Get-AzSecurityConnectorDevOpsConfiguration`, `Get-AzSecurityConnectorGitHubOwner`, `Get-AzSecurityConnectorGitHubOwnerAvailable`, `Get-AzSecurityConnectorGitHubRepo`, `Get-AzSecurityConnectorGitLabGroup`, `Get-AzSecurityConnectorGitLabGroupAvailable`, `Get-AzSecurityConnectorGitLabProject`, `Get-AzSecurityConnectorGitLabSubgroup`, `Invoke-AzSecurityApiCollectionApimOffboard`, `Invoke-AzSecurityApiCollectionApimOnboard`, `New-AzSecurityAwsEnvironmentObject`, `New-AzSecurityAwsOrganizationalDataMasterObject`, `New-AzSecurityAwsOrganizationalDataMemberObject`, `New-AzSecurityAzureDevOpsScopeEnvironmentObject`, `New-AzSecurityConnector`, `New-AzSecurityConnectorActionableRemediationObject`, `New-AzSecurityConnectorDevOpsConfiguration`, `New-AzSecurityCspmMonitorAwsOfferingObject`, `New-AzSecurityCspmMonitorAzureDevOpsOfferingObject`, `New-AzSecurityCspmMonitorGcpOfferingObject`, `New-AzSecurityCspmMonitorGithubOfferingObject`, `New-AzSecurityCspmMonitorGitLabOfferingObject`, `New-AzSecurityDefenderCspmAwsOfferingObject`, `New-AzSecurityDefenderCspmGcpOfferingObject`, `New-AzSecurityDefenderForContainersAwsOfferingObject`, `New-AzSecurityDefenderForContainersGcpOfferingObject`, `New-AzSecurityDefenderForDatabasesAwsOfferingObject`, `New-AzSecurityDefenderForDatabasesGcpOfferingObject`, `New-AzSecurityDefenderForServersAwsOfferingObject`, `New-AzSecurityDefenderForServersGcpOfferingObject`, `New-AzSecurityGcpOrganizationalDataMemberObject`, `New-AzSecurityGcpOrganizationalDataOrganizationObject`, `New-AzSecurityGcpProjectEnvironmentObject`, `New-AzSecurityGitHubScopeEnvironmentObject`, `New-AzSecurityGitLabScopeEnvironmentObject`, `New-AzSecurityInformationProtectionAwsOfferingObject`, `Remove-AzSecurityConnector`, `Remove-AzSecurityConnectorDevOpsConfiguration`, `Update-AzSecurityConnector`, `Update-AzSecurityConnectorAzureDevOpsOrg`, `Update-AzSecurityConnectorAzureDevOpsProject`, `Update-AzSecurityConnectorAzureDevOpsRepo`, `Update-AzSecurityConnectorDevOpsConfiguration`

## 11.3.1 - February 2024

## 11.3.0 - February 2024
#### Az.KeyVault 5.2.0 
* Modified cmdlet `Backup-AzKeyVault`
   - Added parameter `-UseUserManagedIdentity`
* Modified cmdlet `Restore-AzKeyVault`
   - Added parameter `-UseUserManagedIdentity`
#### Az.Migrate 2.3.0 
* Modified cmdlet `Get-AzMigrateDiscoveredServer`
   - Added parameter `-SourceMachineType`
* Added cmdlet `Get-AzMigrateHCIJob`, `Get-AzMigrateHCIReplicationFabric`, `Get-AzMigrateHCIServerReplication`, `Initialize-AzMigrateHCIReplicationInfrastructure`, `New-AzMigrateHCIDiskMappingObject`, `New-AzMigrateHCINicMappingObject`, `New-AzMigrateHCIServerReplication`, `Remove-AzMigrateHCIServerReplication`, `Set-AzMigrateHCIServerReplication`, `Start-AzMigrateHCIServerMigration`
#### Az.Network 7.4.0 
* Modified cmdlet `New-AzApplicationGateway`
   - Added parameters `-EnableRequestBuffering`, `-EnableResponseBuffering`
* Modified cmdlet `New-AzFirewallPolicyIntrusionDetection`
   - Added parameter `-Profile`
* Modified cmdlet `New-AzNetworkVirtualAppliance`
   - Added parameter `-InternetIngressIp`
* Added cmdlet `Invoke-AzFirewallPacketCapture`, `New-AzFirewallPacketCaptureParameter`, `New-AzFirewallPacketCaptureRule`, `New-AzVirtualApplianceInternetIngressIpsProperty`, `Update-AzNetworkVirtualApplianceConnection`
#### Az.Resources 6.15.0 
* Modified cmdlet `Get-AzRoleAssignment`
   - Added parameter `-SkipClientSideScopeValidation`
* Modified cmdlet `Get-AzRoleDefinition`
   - Added parameter `-SkipClientSideScopeValidation`
* Modified cmdlet `New-AzRoleAssignment`
   - Added parameter `-SkipClientSideScopeValidation`
* Modified cmdlet `New-AzRoleDefinition`
   - Added parameter `-SkipClientSideScopeValidation`
* Modified cmdlet `Remove-AzRoleAssignment`
   - Added parameter `-SkipClientSideScopeValidation`
* Modified cmdlet `Remove-AzRoleDefinition`
   - Added parameter `-SkipClientSideScopeValidation`
* Modified cmdlet `Set-AzRoleAssignment`
   - Added parameter `-SkipClientSideScopeValidation`
* Modified cmdlet `Set-AzRoleDefinition`
   - Added parameter `-SkipClientSideScopeValidation`
#### Az.Sql 4.14.0 
* Modified cmdlet `New-AzSqlInstance`
   - Added parameters `-DatabaseFormat`, `-PricingModel`
* Modified cmdlet `Set-AzSqlInstance`
   - Added parameters `-DatabaseFormat`, `-PricingModel`
* Added cmdlet `Invoke-AzSqlInstanceExternalGovernanceStatusRefresh`
#### Az.SqlVirtualMachine 2.2.0 
* Modified cmdlet `New-AzSqlVM`
   - Removed parameter `-VirtualMachineResourceId`
#### Az.StackHCI 2.3.0 
* Modified cmdlet `Unregister-AzStackHCI`
   - Added parameter `-IsWAC`





