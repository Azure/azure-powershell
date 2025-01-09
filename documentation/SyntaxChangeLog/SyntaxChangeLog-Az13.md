## 13.1.0 - January 2025
#### Az.Databricks 1.10.0 
* Modified cmdlet `New-AzDatabricksWorkspace`
   - Removed parameters `-EnhancedSecurityMonitoringValue`, `-AutomaticClusterUpdateValue`, `-ComplianceSecurityProfileComplianceStandard`, `-ComplianceSecurityProfileValue`
   - Added parameters `-EnhancedSecurityMonitoring`, `-AutomaticClusterUpdate`, `-ComplianceStandard`, `-EnhancedSecurityCompliance`
* Modified cmdlet `Update-AzDatabricksWorkspace`
   - Removed parameters `-EnhancedSecurityMonitoringValue`, `-AutomaticClusterUpdateValue`, `-ComplianceSecurityProfileComplianceStandard`, `-ComplianceSecurityProfileValue`
   - Added parameters `-EnhancedSecurityMonitoring`, `-AutomaticClusterUpdate`, `-ComplianceStandard`, `-EnhancedSecurityCompliance`
#### Az.DataProtection 2.6.0 
* Modified cmdlet `Initialize-AzDataProtectionBackupInstance`
   - Added parameters `-UseSystemAssignedIdentity`, `-UserAssignedIdentityArmId`
* Modified cmdlet `New-AzDataProtectionBackupVault`
   - Added parameter alias `AssignUserIdentity` to parameter `-IdentityUserAssignedIdentity`
* Modified cmdlet `Set-AzDataProtectionMSIPermission`
   - Added parameter `-UserAssignedIdentityARMId`
* Modified cmdlet `Update-AzDataProtectionBackupInstance`
   - Added parameters `-UseSystemAssignedIdentity`, `-UserAssignedIdentityArmId`
* Modified cmdlet `Update-AzDataProtectionBackupVault`
   - Added parameter alias `AssignUserIdentity` to parameter `-IdentityUserAssignedIdentity`
#### Az.Kusto 2.4.0 
* Modified cmdlet `New-AzKustoCluster`
   - Added parameter `-CalloutPolicy`
* Modified cmdlet `New-AzKustoSandboxCustomImage`
   - Added parameter `-BaseImageName`
* Modified cmdlet `New-AzKustoScript`
   - Added parameters `-PrincipalPermissionsAction`, `-ScriptLevel`
* Modified cmdlet `Update-AzKustoCluster`
   - Added parameter `-CalloutPolicy`
* Modified cmdlet `Update-AzKustoSandboxCustomImage`
   - Added parameter `-BaseImageName`
* Modified cmdlet `Update-AzKustoScript`
   - Added parameters `-PrincipalPermissionsAction`, `-ScriptLevel`
* Added cmdlet `Add-AzKustoClusterCalloutPolicy`, `Get-AzKustoClusterCalloutPolicy`, `Get-AzKustoClusterFollowerDatabaseGet`, `Remove-AzKustoClusterCalloutPolicy`
#### Az.Network 7.12.0 
* Modified cmdlet `Add-AzVirtualNetworkSubnetConfig`
   - Added parameter `-IpamPoolPrefixAllocation`
   - Parameter `-AddressPrefix` ValidateNotNullOrEmpty changed from `True` to `False`
* Modified cmdlet `New-AzFirewall`
   - Added parameters `-MinCapacity`, `-MaxCapacity`
* Modified cmdlet `New-AzNetworkManagerSecurityAdminConfiguration`
   - Added parameter `-NetworkGroupAddressSpaceAggregationOption`
* Modified cmdlet `New-AzVirtualNetwork`
   - Added parameter `-IpamPoolPrefixAllocation`
   - Parameter `-AddressPrefix` ValidateNotNullOrEmpty changed from `True` to `False`
* Modified cmdlet `New-AzVirtualNetworkGateway`
   - Added parameter `-ResiliencyModel`
* Modified cmdlet `New-AzVirtualNetworkSubnetConfig`
   - Added parameter `-IpamPoolPrefixAllocation`
   - Parameter `-AddressPrefix` ValidateNotNullOrEmpty changed from `True` to `False`
* Modified cmdlet `Set-AzVirtualNetworkGateway`
   - Added parameter `-ResiliencyModel`
* Modified cmdlet `Set-AzVirtualNetworkSubnetConfig`
   - Added parameter `-IpamPoolPrefixAllocation`
   - Parameter `-AddressPrefix` ValidateNotNullOrEmpty changed from `True` to `False`
* Added cmdlet `Get-AzNetworkManagerAssociatedResourcesList`, `Get-AzNetworkManagerIpamPool`, `Get-AzNetworkManagerIpamPoolStaticCidr`, `Get-AzNetworkManagerIpamPoolUsage`, `Get-AzNetworkManagerVerifierWorkspace`, `Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent`, `Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun`, `New-AzNetworkManagerIpamPool`, `New-AzNetworkManagerIpamPoolStaticCidr`, `New-AzNetworkManagerIPTraffic`, `New-AzNetworkManagerVerifierWorkspace`, `New-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent`, `New-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun`, `Remove-AzNetworkManagerIpamPool`, `Remove-AzNetworkManagerIpamPoolStaticCidr`, `Remove-AzNetworkManagerVerifierWorkspace`, `Remove-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent`, `Remove-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun`, `Set-AzNetworkManagerIpamPool`, `Set-AzNetworkManagerVerifierWorkspace`
#### Az.NetworkCloud 1.1.0 
* Modified cmdlet `New-AzNetworkCloudAgentPool`
   - Added parameters `-UpgradeSettingDrainTimeout`, `-UpgradeSettingMaxUnavailable`
* Modified cmdlet `New-AzNetworkCloudCluster`
   - Added parameters `-AssociatedIdentityType`, `-AssociatedIdentityUserAssignedIdentityResourceId`, `-CommandOutputSettingContainerUrl`, `-IdentityType`, `-IdentityUserAssignedIdentity`, `-RuntimeProtectionConfigurationEnforcementLevel`, `-SecretArchiveKeyVaultId`, `-SecretArchiveUseKeyVault`, `-UpdateStrategyMaxUnavailable`, `-UpdateStrategyThresholdType`, `-UpdateStrategyThresholdValue`, `-UpdateStrategyType`, `-UpdateStrategyWaitTimeMinute`
* Modified cmdlet `New-AzNetworkCloudClusterManager`
   - Added parameters `-IdentityType`, `-IdentityUserAssignedIdentity`
* Modified cmdlet `New-AzNetworkCloudInitialAgentPoolConfigurationObject`
   - Added parameters `-UpgradeSettingDrainTimeout`, `-UpgradeSettingMaxUnavailable`
* Modified cmdlet `New-AzNetworkCloudKeySetUserObject`
   - Added parameter `-UserPrincipalName`
* Modified cmdlet `New-AzNetworkCloudKubernetesCluster`
   - Added parameter `-L2ServiceLoadBalancerConfigurationIPAddressPool`
* Modified cmdlet `Update-AzNetworkCloudAgentPool`
   - Added parameters `-AdministratorConfigurationSshPublicKey`, `-UpgradeSettingDrainTimeout`, `-UpgradeSettingMaxUnavailable`
* Modified cmdlet `Update-AzNetworkCloudCluster`
   - Added parameters `-AssociatedIdentityType`, `-AssociatedIdentityUserAssignedIdentityResourceId`, `-CommandOutputSettingContainerUrl`, `-IdentityType`, `-IdentityUserAssignedIdentity`, `-RuntimeProtectionConfigurationEnforcementLevel`, `-SecretArchiveKeyVaultId`, `-SecretArchiveUseKeyVault`, `-UpdateStrategyMaxUnavailable`, `-UpdateStrategyThresholdType`, `-UpdateStrategyThresholdValue`, `-UpdateStrategyType`, `-UpdateStrategyWaitTimeMinute`
* Modified cmdlet `Update-AzNetworkCloudClusterManager`
   - Added parameters `-IdentityType`, `-IdentityUserAssignedIdentity`
* Modified cmdlet `Update-AzNetworkCloudKubernetesCluster`
   - Added parameters `-ControlPlaneNodeConfigurationAdminPublicKey`, `-SshPublicKey`
* Added cmdlet `Get-AzNetworkCloudKubernetesClusterFeature`, `Invoke-AzNetworkCloudClusterContinueVersionUpdate`, `Invoke-AzNetworkCloudScanClusterRuntime`, `New-AzNetworkCloudKubernetesClusterFeature`, `Remove-AzNetworkCloudKubernetesClusterFeature`, `Update-AzNetworkCloudKubernetesClusterFeature`
#### Az.RecoveryServices 7.4.0 
* Modified cmdlet `Get-AzRecoveryServicesBackupRetentionPolicyObject`
   - Added parameter `-BackupTier`
#### Az.RedisCache 1.11.0 
* Modified cmdlet `New-AzRedisCache`
   - Added parameter `-ZonalAllocationPolicy`
* Modified cmdlet `Set-AzRedisCache`
   - Added parameter `-ZonalAllocationPolicy`
#### Az.Resources 7.8.0 
* Modified cmdlet `New-AzADApplication`
   - Added parameter `-RequestedAccessTokenVersion`
* Modified cmdlet `Update-AzADApplication`
   - Added parameter `-RequestedAccessTokenVersion`

## 13.0.0 - November 2024
#### Az.Accounts 4.0.0 
* Modified cmdlet `Invoke-AzRestMethod`
   - Added parameters `-WaitForCompletion`, `-PollFrom`, `-FinalResultFrom`
#### Az.App 2.0.0 
* Modified cmdlet `New-AzContainerApp`
   - Removed parameters `-IdentityType`, `-IdentityUserAssignedIdentity`
   - Added parameters `-EnableSystemAssignedIdentity`, `-UserAssignedIdentity`
* Modified cmdlet `New-AzContainerAppJob`
   - Removed parameters `-IdentityType`, `-IdentityUserAssignedIdentity`
   - Added parameters `-EnableSystemAssignedIdentity`, `-UserAssignedIdentity`
* Modified cmdlet `Update-AzContainerApp`
   - Removed parameters `-IdentityType`, `-IdentityUserAssignedIdentity`
   - Added parameters `-EnableSystemAssignedIdentity`, `-UserAssignedIdentity`
* Modified cmdlet `Update-AzContainerAppJob`
   - Removed parameters `-IdentityType`, `-IdentityUserAssignedIdentity`
   - Added parameters `-EnableSystemAssignedIdentity`, `-UserAssignedIdentity`
#### Az.ConnectedMachine 1.1.0 
* Added cmdlet `Get-AzConnectedLicenseProfile`, `Get-AzConnectedMachineRunCommand`, `New-AzConnectedLicenseProfile`, `New-AzConnectedLicenseProfileFeature`, `New-AzConnectedMachineRunCommand`, `Remove-AzConnectedLicenseProfile`, `Remove-AzConnectedMachineRunCommand`, `Update-AzConnectedLicenseProfile`, `Update-AzConnectedLicenseProfileFeature`, `Update-AzConnectedMachineRunCommand`
#### Az.ContainerInstance 4.1.0 
* Modified cmdlet `New-AzContainerGroup`
   - Added parameters `-ContainerGroupProfileId`, `-ContainerGroupProfileRevision`, `-StandbyPoolProfileFailContainerGroupCreateOnReuseFailure`, `-StandbyPoolProfileId`
* Modified cmdlet `New-AzContainerInstanceObject`
   - Added parameter `-ConfigMapKeyValuePair`
* Added cmdlet `Get-AzContainerInstanceContainerGroupProfile`, `Get-AzContainerInstanceContainerGroupProfileRevision`, `New-AzContainerInstanceContainerGroupProfile`, `New-AzContainerInstanceNoDefaultObject`, `Remove-AzContainerInstanceContainerGroupProfile`, `Update-AzContainerInstanceContainerGroupProfile`
#### Az.DesktopVirtualization 5.4.0 
* Modified cmdlet `Disconnect-AzWvdUserSession`
   - Added parameters `-HostPoolInputObject`, `-SessionHostInputObject`
* Modified cmdlet `Expand-AzWvdMsixImage`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Get-AzWvdApplication`
   - Added parameter `-ApplicationGroupInputObject`
* Modified cmdlet `Get-AzWvdDesktop`
   - Added parameter `-ApplicationGroupInputObject`
* Modified cmdlet `Get-AzWvdMsixPackage`
   - Added parameter `-HostPoolInputObject`
* Modified cmdlet `Get-AzWvdPrivateEndpointConnection`
   - Added parameters `-HostPoolInputObject`, `-WorkspaceInputObject`
* Modified cmdlet `Get-AzWvdScalingPlanPersonalSchedule`
   - Added parameter `-ScalingPlanInputObject`
* Modified cmdlet `Get-AzWvdScalingPlanPooledSchedule`
   - Added parameter `-ScalingPlanInputObject`
* Modified cmdlet `Get-AzWvdSessionHost`
   - Added parameter `-HostPoolInputObject`
* Modified cmdlet `Get-AzWvdUserSession`
   - Added parameters `-HostPoolInputObject`, `-SessionHostInputObject`
* Modified cmdlet `New-AzWvdApplication`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-CommandLineSetting` from `CommandLineSetting` to `String`
   - Changed the type of parameter `-ApplicationType` from `RemoteApplicationType` to `String`
* Modified cmdlet `New-AzWvdApplicationGroup`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-ApplicationGroupType` from `ApplicationGroupType` to `String`
   - Changed the type of parameter `-IdentityType` from `ResourceIdentityType` to `String`
   - Changed the type of parameter `-SkuTier` from `SkuTier` to `String`
* Modified cmdlet `New-AzWvdHostPool`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-HostPoolType` from `HostPoolType` to `String`
   - Changed the type of parameter `-LoadBalancerType` from `LoadBalancerType` to `String`
   - Changed the type of parameter `-PreferredAppGroupType` from `PreferredAppGroupType` to `String`
   - Changed the type of parameter `-AgentUpdateType` from `SessionHostComponentUpdateType` to `String`
   - Changed the type of parameter `-IdentityType` from `ResourceIdentityType` to `String`
   - Changed the type of parameter `-PersonalDesktopAssignmentType` from `PersonalDesktopAssignmentType` to `String`
   - Changed the type of parameter `-PublicNetworkAccess` from `HostpoolPublicNetworkAccess` to `String`
   - Changed the type of parameter `-RegistrationTokenOperation` from `RegistrationTokenOperation` to `String`
   - Changed the type of parameter `-SkuTier` from `SkuTier` to `String`
   - Changed the type of parameter `-SsoSecretType` from `SsoSecretType` to `String`
* Modified cmdlet `New-AzWvdMsixPackage`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzWvdScalingPlan`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-HostPoolType` from `ScalingHostPoolType` to `String`
   - Changed the type of parameter `-IdentityType` from `ResourceIdentityType` to `String`
   - Changed the type of parameter `-SkuTier` from `SkuTier` to `String`
* Modified cmdlet `New-AzWvdScalingPlanPersonalSchedule`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-DaysOfWeek` from `DayOfWeek[]` to `String[]`
   - Changed the type of parameter `-OffPeakActionOnDisconnect` from `SessionHandlingOperation` to `String`
   - Changed the type of parameter `-OffPeakActionOnLogoff` from `SessionHandlingOperation` to `String`
   - Changed the type of parameter `-OffPeakStartVMOnConnect` from `SetStartVMOnConnect` to `String`
   - Changed the type of parameter `-PeakActionOnDisconnect` from `SessionHandlingOperation` to `String`
   - Changed the type of parameter `-PeakActionOnLogoff` from `SessionHandlingOperation` to `String`
   - Changed the type of parameter `-PeakStartVMOnConnect` from `SetStartVMOnConnect` to `String`
   - Changed the type of parameter `-RampDownActionOnDisconnect` from `SessionHandlingOperation` to `String`
   - Changed the type of parameter `-RampDownActionOnLogoff` from `SessionHandlingOperation` to `String`
   - Changed the type of parameter `-RampDownStartVMOnConnect` from `SetStartVMOnConnect` to `String`
   - Changed the type of parameter `-RampUpActionOnDisconnect` from `SessionHandlingOperation` to `String`
   - Changed the type of parameter `-RampUpActionOnLogoff` from `SessionHandlingOperation` to `String`
   - Changed the type of parameter `-RampUpAutoStartHost` from `StartupBehavior` to `String`
   - Changed the type of parameter `-RampUpStartVMOnConnect` from `SetStartVMOnConnect` to `String`
* Modified cmdlet `New-AzWvdScalingPlanPooledSchedule`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-DaysOfWeek` from `DayOfWeek[]` to `String[]`
   - Changed the type of parameter `-OffPeakLoadBalancingAlgorithm` from `SessionHostLoadBalancingAlgorithm` to `String`
   - Changed the type of parameter `-PeakLoadBalancingAlgorithm` from `SessionHostLoadBalancingAlgorithm` to `String`
   - Changed the type of parameter `-RampDownLoadBalancingAlgorithm` from `SessionHostLoadBalancingAlgorithm` to `String`
   - Changed the type of parameter `-RampDownStopHostsWhen` from `StopHostsWhen` to `String`
   - Changed the type of parameter `-RampUpLoadBalancingAlgorithm` from `SessionHostLoadBalancingAlgorithm` to `String`
* Modified cmdlet `New-AzWvdWorkspace`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-IdentityType` from `ResourceIdentityType` to `String`
   - Changed the type of parameter `-PublicNetworkAccess` from `PublicNetworkAccess` to `String`
   - Changed the type of parameter `-SkuTier` from `SkuTier` to `String`
* Modified cmdlet `Remove-AzWvdApplication`
   - Added parameter `-ApplicationGroupInputObject`
* Modified cmdlet `Remove-AzWvdMsixPackage`
   - Added parameter `-HostPoolInputObject`
* Modified cmdlet `Remove-AzWvdPrivateEndpointConnection`
   - Added parameters `-HostPoolInputObject`, `-WorkspaceInputObject`
* Modified cmdlet `Remove-AzWvdScalingPlanPersonalSchedule`
   - Added parameter `-ScalingPlanInputObject`
* Modified cmdlet `Remove-AzWvdScalingPlanPooledSchedule`
   - Added parameter `-ScalingPlanInputObject`
* Modified cmdlet `Remove-AzWvdSessionHost`
   - Added parameter `-HostPoolInputObject`
* Modified cmdlet `Remove-AzWvdUserSession`
   - Added parameters `-HostPoolInputObject`, `-SessionHostInputObject`
* Modified cmdlet `Send-AzWvdUserSessionMessage`
   - Added parameters `-HostPoolInputObject`, `-SessionHostInputObject`, `-SendMessage`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzWvdApplication`
   - Added parameters `-ApplicationGroupInputObject`, `-Application`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-ApplicationType` from `RemoteApplicationType` to `String`
   - Changed the type of parameter `-CommandLineSetting` from `CommandLineSetting` to `String`
* Modified cmdlet `Update-AzWvdApplicationGroup`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzWvdDesktop`
   - Added parameters `-ApplicationGroupInputObject`, `-Desktop`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzWvdHostPool`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-AgentUpdateType` from `SessionHostComponentUpdateType` to `String`
   - Changed the type of parameter `-LoadBalancerType` from `LoadBalancerType` to `String`
   - Changed the type of parameter `-PersonalDesktopAssignmentType` from `PersonalDesktopAssignmentType` to `String`
   - Changed the type of parameter `-PreferredAppGroupType` from `PreferredAppGroupType` to `String`
   - Changed the type of parameter `-PublicNetworkAccess` from `HostpoolPublicNetworkAccess` to `String`
   - Changed the type of parameter `-RegistrationInfoRegistrationTokenOperation` from `RegistrationTokenOperation` to `String`
   - Changed the type of parameter `-SsoSecretType` from `SsoSecretType` to `String`
* Modified cmdlet `Update-AzWvdMsixPackage`
   - Added parameters `-HostPoolInputObject`, `-MsixPackage`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzWvdScalingPlan`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzWvdScalingPlanPersonalSchedule`
   - Added parameters `-ScalingPlanInputObject`, `-ScalingPlanSchedule`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-DaysOfWeek` from `DayOfWeek[]` to `String[]`
   - Changed the type of parameter `-OffPeakActionOnDisconnect` from `SessionHandlingOperation` to `String`
   - Changed the type of parameter `-OffPeakActionOnLogoff` from `SessionHandlingOperation` to `String`
   - Changed the type of parameter `-OffPeakStartVMOnConnect` from `SetStartVMOnConnect` to `String`
   - Changed the type of parameter `-PeakActionOnDisconnect` from `SessionHandlingOperation` to `String`
   - Changed the type of parameter `-PeakActionOnLogoff` from `SessionHandlingOperation` to `String`
   - Changed the type of parameter `-PeakStartVMOnConnect` from `SetStartVMOnConnect` to `String`
   - Changed the type of parameter `-RampDownActionOnDisconnect` from `SessionHandlingOperation` to `String`
   - Changed the type of parameter `-RampDownActionOnLogoff` from `SessionHandlingOperation` to `String`
   - Changed the type of parameter `-RampDownStartVMOnConnect` from `SetStartVMOnConnect` to `String`
   - Changed the type of parameter `-RampUpActionOnDisconnect` from `SessionHandlingOperation` to `String`
   - Changed the type of parameter `-RampUpActionOnLogoff` from `SessionHandlingOperation` to `String`
   - Changed the type of parameter `-RampUpAutoStartHost` from `StartupBehavior` to `String`
   - Changed the type of parameter `-RampUpStartVMOnConnect` from `SetStartVMOnConnect` to `String`
* Modified cmdlet `Update-AzWvdScalingPlanPooledSchedule`
   - Added parameters `-ScalingPlanInputObject`, `-ScalingPlanSchedule`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-DaysOfWeek` from `DayOfWeek[]` to `String[]`
   - Changed the type of parameter `-OffPeakLoadBalancingAlgorithm` from `SessionHostLoadBalancingAlgorithm` to `String`
   - Changed the type of parameter `-PeakLoadBalancingAlgorithm` from `SessionHostLoadBalancingAlgorithm` to `String`
   - Changed the type of parameter `-RampDownLoadBalancingAlgorithm` from `SessionHostLoadBalancingAlgorithm` to `String`
   - Changed the type of parameter `-RampDownStopHostsWhen` from `StopHostsWhen` to `String`
   - Changed the type of parameter `-RampUpLoadBalancingAlgorithm` from `SessionHostLoadBalancingAlgorithm` to `String`
* Modified cmdlet `Update-AzWvdSessionHost`
   - Added parameters `-HostPoolInputObject`, `-SessionHost`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzWvdWorkspace`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-PublicNetworkAccess` from `PublicNetworkAccess` to `String`
* Added cmdlet `Get-AzWvdAppAttachPackage`, `Import-AzWvdAppAttachPackageInfo`, `New-AzWvdAppAttachPackage`, `Remove-AzWvdAppAttachPackage`, `Update-AzWvdAppAttachPackage`
#### Az.DevCenter 2.0.0 
* Modified cmdlet `Deploy-AzDevCenterUserEnvironment`
   - Output type changed from ``Boolean`` to ``IEnvironment``
* Modified cmdlet `Get-AzDevCenterUserCatalog`
   - Output type changed from ``String``, ``ICatalog`` to ``ICatalog``
* Modified cmdlet `Get-AzDevCenterUserEnvironmentLog`
   - Removed parameters `-OutFile`, `-PassThru`
   - Output type changed from ``Boolean`` to ``String``
* Modified cmdlet `Get-AzDevCenterUserEnvironmentType`
   - Added parameters `-InputObject`, `-Name`
* Modified cmdlet `New-AzDevCenterUserEnvironment`
   - Output type changed from ``Boolean`` to ``IEnvironment``
* Modified cmdlet `Remove-AzDevCenterUserDevBox`
   - Output type changed from ``Boolean`` to ``IOperationStatus``
* Modified cmdlet `Remove-AzDevCenterUserEnvironment`
   - Output type changed from ``Boolean`` to ``IOperationStatus``
* Modified cmdlet `Repair-AzDevCenterUserDevBox`
   - Output type changed from ``Boolean`` to ``IOperationStatus``
* Modified cmdlet `Restart-AzDevCenterUserDevBox`
   - Output type changed from ``Boolean`` to ``IOperationStatus``
* Modified cmdlet `Start-AzDevCenterUserDevBox`
   - Output type changed from ``Boolean`` to ``IOperationStatus``
* Modified cmdlet `Stop-AzDevCenterUserDevBox`
   - Output type changed from ``Boolean`` to ``IOperationStatus``
* Added cmdlet `Get-AzDevCenterUserDevBoxCustomizationGroup`, `Get-AzDevCenterUserDevBoxCustomizationTaskDefinition`, `Get-AzDevCenterUserDevBoxCustomizationTaskLog`, `New-AzDevCenterUserDevBoxCustomizationGroup`, `Test-AzDevCenterUserDevBoxCustomizationTaskAction`
#### Az.Dns 1.3.0 
* Modified cmdlet `Add-AzDnsRecordConfig`
   - Added parameters `-Order`, `-Flags`, `-Services`, `-Regexp`, `-Replacement`
* Modified cmdlet `New-AzDnsRecordConfig`
   - Added parameters `-Order`, `-Flags`, `-Services`, `-Regexp`, `-Replacement`
* Modified cmdlet `Remove-AzDnsRecordConfig`
   - Added parameters `-Order`, `-Flags`, `-Services`, `-Regexp`, `-Replacement`
#### Az.DnsResolver 1.1.0 
* Added cmdlet `Get-AzDnsResolverDomainList`, `Get-AzDnsResolverPolicy`, `Get-AzDnsResolverPolicyDnsSecurityRule`, `Get-AzDnsResolverPolicyVirtualNetworkLink`, `New-AzDnsResolverDomainList`, `New-AzDnsResolverPolicy`, `New-AzDnsResolverPolicyDnsSecurityRule`, `New-AzDnsResolverPolicyVirtualNetworkLink`, `Remove-AzDnsResolverDomainList`, `Remove-AzDnsResolverPolicy`, `Remove-AzDnsResolverPolicyDnsSecurityRule`, `Remove-AzDnsResolverPolicyVirtualNetworkLink`, `Update-AzDnsResolverDomainList`, `Update-AzDnsResolverPolicy`, `Update-AzDnsResolverPolicyDnsSecurityRule`, `Update-AzDnsResolverPolicyVirtualNetworkLink`
#### Az.HDInsight 6.3.0 
* Modified cmdlet `Update-AzHDInsightCluster`
   - Changed the type of parameter `-IdentityId` from `String` to `String[]`
#### Az.KeyVault 6.3.0 
* Modified cmdlet `Backup-AzKeyVaultSecret`
   - Added parameter `-Id`
* Modified cmdlet `Get-AzKeyVaultSecret`
   - Removed parameter `-ResourceId`
   - Added parameters `-Id`, `-ParentResourceId`
* Modified cmdlet `Remove-AzKeyVaultSecret`
   - Added parameter `-Id`
* Modified cmdlet `Restore-AzKeyVaultSecret`
   - Removed parameter `-ResourceId`
   - Added parameters `-Id`, `-ParentResourceId`
* Modified cmdlet `Set-AzKeyVaultSecret`
   - Added parameter `-Id`
* Modified cmdlet `Undo-AzKeyVaultSecretRemoval`
   - Added parameter `-Id`
* Modified cmdlet `Update-AzKeyVaultSecret`
   - Added parameter `-Id`
#### Az.Monitor 6.0.0 
* Modified cmdlet `New-AzDataCollectionEndpoint`
   - Removed parameter `-IdentityType`
   - Added parameter `-EnableSystemAssignedIdentity`
   - Changed the type of parameter `-UserAssignedIdentity` from `Hashtable` to `String[]`
* Modified cmdlet `New-AzDataCollectionRule`
   - Removed parameter `-IdentityType`
   - Added parameter `-EnableSystemAssignedIdentity`
   - Changed the type of parameter `-UserAssignedIdentity` from `Hashtable` to `String[]`
* Modified cmdlet `Update-AzDataCollectionEndpoint`
   - Removed parameter `-IdentityType`
   - Added parameters `-Description`, `-EnableSystemAssignedIdentity`, `-ImmutableId`, `-Kind`, `-NetworkAclsPublicNetworkAccess`
   - Changed the type of parameter `-UserAssignedIdentity` from `Hashtable` to `String[]`
* Modified cmdlet `Update-AzDataCollectionRule`
   - Removed parameter `-IdentityType`
   - Added parameter `-EnableSystemAssignedIdentity`
   - Changed the type of parameter `-UserAssignedIdentity` from `Hashtable` to `String[]`
#### Az.RecoveryServices 7.3.0 
* Modified cmdlet `Restore-AzRecoveryServicesBackupItem`
   - Added parameters `-DiskAccessOption`, `-TargetDiskAccessId`
#### Az.Sql 6.0.0 
* Modified cmdlet `New-AzSqlDatabaseSecondary`
   - Added parameter `-PartnerSubscriptionId`
* Modified cmdlet `New-AzSqlInstanceLink`
   - Removed parameters `-PrimaryAvailabilityGroupName`, `-SecondaryAvailabilityGroupName`, `-TargetDatabase`, `-SourceEndpoint`
   - Added parameters `-PartnerAvailabilityGroupName`, `-InstanceAvailabilityGroupName`, `-Database`, `-PartnerEndpoint`, `-FailoverMode`, `-InstanceLinkRole`, `-SeedingMode`
* Added cmdlet `Start-AzSqlInstanceLinkFailover`
#### Az.Storage 8.0.0 
* Modified cmdlet `Close-AzStorageFileHandle`
   - Removed parameters `-Share`, `-Directory`, `-File`
* Modified cmdlet `Get-AzStorageFile`
   - Removed parameters `-Share`, `-Directory`
* Modified cmdlet `Get-AzStorageFileContent`
   - Removed parameters `-Share`, `-Directory`, `-File`
* Modified cmdlet `Get-AzStorageFileCopyState`
   - Removed parameter `-File`
* Modified cmdlet `Get-AzStorageFileHandle`
   - Removed parameters `-Share`, `-Directory`, `-File`
* Modified cmdlet `New-AzStorageDirectory`
   - Removed parameters `-Share`, `-Directory`
* Modified cmdlet `New-AzStorageFileSASToken`
   - Removed parameter `-File`
   - Added parameter `-ShareFileClient`
   - Changed the type of parameter `-Protocol` from `Nullable`1[Microsoft.Azure.Storage.SharedAccessProtocol]` to `String`
* Modified cmdlet `New-AzStorageShareSASToken`
   - Changed the type of parameter `-Protocol` from `Nullable`1[Microsoft.Azure.Storage.SharedAccessProtocol]` to `String`
* Modified cmdlet `Remove-AzStorageDirectory`
   - Removed parameters `-Share`, `-Directory`
* Modified cmdlet `Remove-AzStorageFile`
   - Removed parameters `-Share`, `-Directory`, `-File`
* Modified cmdlet `Remove-AzStorageShare`
   - Removed parameter `-Share`
* Modified cmdlet `Set-AzStorageFileContent`
   - Removed parameters `-Share`, `-Directory`
* Modified cmdlet `Set-AzStorageShareQuota`
   - Removed parameter `-Share`
   - Added parameter `-ShareClient`
* Modified cmdlet `Start-AzStorageFileCopy`
   - Removed parameter `-DestFile`
   - Added parameter alias `ShareClient` to parameter `-SrcShare`
   - Removed parameter alias `CloudFileShare` from parameter `-SrcShare`
   - Changed the type of parameter `-SrcShare` from `CloudFileShare` to `ShareClient`
   - Added parameter alias `ShareFileClient` to parameter `-SrcFile`
   - Removed parameter alias `CloudFile` from parameter `-SrcFile`
   - Changed the type of parameter `-SrcFile` from `CloudFile` to `ShareFileClient`
   - Added parameter alias `DestFile` to parameter `-DestShareFileClient`
* Modified cmdlet `Stop-AzStorageFileCopy`
   - Removed parameter `-File`



