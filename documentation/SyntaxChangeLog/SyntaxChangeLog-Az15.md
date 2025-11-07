## 15.0.0 - November 2025
#### Az.ArcResourceBridge 2.0.0 
* Modified cmdlet `Get-AzArcResourceBridgeTelemetryConfig`
   - Removed parameter `-InputObject`
   - Output type changed from ``String`` to ``IApplianceGetTelemetryConfigResult``
* Modified cmdlet `Get-AzArcResourceBridgeUpgradeGraph`
   - Added parameter `-ApplianceInputObject`
* Modified cmdlet `New-AzArcResourceBridge`
   - Removed parameter `-IdentityType`
   - Added parameters `-EnableSystemAssignedIdentity`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-Distro` from `Distro` to `String`
   - Changed the type of parameter `-InfrastructureConfigProvider` from `Provider` to `String`
* Modified cmdlet `Update-AzArcResourceBridge`
   - Added parameters `-JsonFilePath`, `-JsonString`
#### Az.Attestation 3.0.0 
* Modified cmdlet `New-AzAttestationProvider`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzAttestationProvider`
   - Added parameters `-JsonFilePath`, `-JsonString`
#### Az.Automanage 2.0.0 
* Modified cmdlet `Get-AzAutomanageConfigProfileAssignment`
   - Added parameter `-ConfigurationProfileAssignmentInputObject`
* Modified cmdlet `Get-AzAutomanageConfigProfileHciAssignment`
   - Added parameter `-ClusterInputObject`
* Modified cmdlet `Get-AzAutomanageConfigProfileHcrpAssignment`
   - Added parameter `-MachineInputObject`
* Modified cmdlet `Get-AzAutomanageHciReport`
   - Added parameters `-ClusterInputObject`, `-ConfigurationProfileAssignmentInputObject`
* Modified cmdlet `Get-AzAutomanageHcrpReport`
   - Added parameters `-ConfigurationProfileAssignmentInputObject`, `-MachineInputObject`
* Modified cmdlet `Get-AzAutomanageReport`
   - Added parameters `-ConfigurationProfileAssignmentInputObject`, `-ReportInputObject`
* Modified cmdlet `New-AzAutomanageConfigProfile`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzAutomanageConfigProfileAssignment`
   - Added parameters `-ConfigurationProfileAssignmentInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzAutomanageConfigProfileHciAssignment`
   - Added parameters `-ClusterInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzAutomanageConfigProfileHcrpAssignment`
   - Added parameters `-MachineInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Remove-AzAutomanageConfigProfileAssignment`
   - Added parameter `-ConfigurationProfileAssignmentInputObject`
* Modified cmdlet `Remove-AzAutomanageConfigProfileHciAssignment`
   - Added parameter `-ClusterInputObject`
* Modified cmdlet `Remove-AzAutomanageConfigProfileHcrpAssignment`
   - Added parameter `-MachineInputObject`
* Modified cmdlet `Update-AzAutomanageConfigProfile`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Added cmdlet `Update-AzAutomanageConfigProfileAssignment`, `Update-AzAutomanageConfigProfileHciAssignment`, `Update-AzAutomanageConfigProfileHcrpAssignment`
#### Az.Batch 4.0.0 
* Removed cmdlet `Get-AzBatchCertificate`, `Get-AzBatchRemoteDesktopProtocolFile`, `New-AzBatchCertificate`
* Modified cmdlet `New-AzBatchPool`
   - Removed parameters `-ResourceTag`, `-CertificateReferences`, `-ApplicationLicenses`, `-CloudServiceConfiguration`, `-CurrentNodeCommunicationMode`, `-TargetNodeCommunicationMode`
* Removed cmdlet `Remove-AzBatchCertificate`, `Stop-AzBatchCertificateDeletion`
#### Az.Cdn 5.1.0 
* Added cmdlet `Add-AzCdnEdgeActionAttachment`, `Deploy-AzCdnEdgeActionVersionCode`, `Get-AzCdnEdgeAction`, `Get-AzCdnEdgeActionExecutionFilter`, `Get-AzCdnEdgeActionVersion`, `Get-AzCdnEdgeActionVersionCode`, `New-AzCdnEdgeAction`, `New-AzCdnEdgeActionExecutionFilter`, `New-AzCdnEdgeActionVersion`, `Remove-AzCdnEdgeAction`, `Remove-AzCdnEdgeActionAttachment`, `Remove-AzCdnEdgeActionExecutionFilter`, `Remove-AzCdnEdgeActionVersion`, `Update-AzCdnEdgeAction`, `Update-AzCdnEdgeActionExecutionFilter`, `Update-AzCdnEdgeActionVersion`
#### Az.Compute 11.0.0 
* Modified cmdlet `Add-AzVmGalleryApplication`
   - Added parameter `-EnableAutomaticUpgrade`
* Modified cmdlet `Add-AzVmssGalleryApplication`
   - Added parameter `-EnableAutomaticUpgrade`
* Modified cmdlet `New-AzVmGalleryApplication`
   - Added parameters `-EnableAutomaticUpgrade`, `-TreatFailureAsDeploymentFailure`
* Modified cmdlet `New-AzVmssGalleryApplication`
   - Added parameters `-EnableAutomaticUpgrade`, `-TreatFailureAsDeploymentFailure`
* Modified cmdlet `Get-AzGalleryApplication`
   - Added parameter `-GalleryInputObject`
* Modified cmdlet `Get-AzGalleryApplicationVersion`
   - Added parameters `-ApplicationInputObject`, `-GalleryInputObject`
   - Changed the type of parameter `-Expand` from `ReplicationStatusTypes` to `String`
* Modified cmdlet `Invoke-AzSpotPlacementScore`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzGalleryApplication`
   - Added parameters `-GalleryInputObject`, `-JsonString`, `-JsonFilePath`
   - Changed the type of parameter `-SupportedOSType` from `OperatingSystemTypes` to `String`
* Modified cmdlet `New-AzGalleryApplicationVersion`
   - Added parameters `-GalleryInputObject`, `-ApplicationInputObject`, `-JsonString`, `-JsonFilePath`
* Modified cmdlet `Remove-AzGalleryApplication`
   - Added parameter `-GalleryInputObject`
* Modified cmdlet `Remove-AzGalleryApplicationVersion`
   - Added parameters `-ApplicationInputObject`, `-GalleryInputObject`
* Modified cmdlet `Remove-AzVMRunCommand`
   - Added parameter `-VirtualMachineInputObject`
* Modified cmdlet `Remove-AzVmssVMRunCommand`
   - Added parameters `-VirtualMachineInputObject`, `-VirtualMachineScaleSetInputObject`
* Modified cmdlet `Set-AzVMRunCommand`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Set-AzVmssVMRunCommand`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzGalleryApplication`
   - Added parameters `-GalleryInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzGalleryApplicationVersion`
   - Added parameters `-GalleryInputObject`, `-ApplicationInputObject`, `-JsonString`, `-JsonFilePath`
#### Az.ConfidentialLedger 2.0.0 
* Modified cmdlet `New-AzConfidentialLedger`
   - Changed the type of parameter `-LedgerType` from `LedgerType` to `String`
* Modified cmdlet `New-AzConfidentialLedgerAADBasedSecurityPrincipalObject`
   - Changed the type of parameter `-LedgerRoleName` from `LedgerRoleName` to `String`
* Modified cmdlet `New-AzConfidentialLedgerCertBasedSecurityPrincipalObject`
   - Changed the type of parameter `-LedgerRoleName` from `LedgerRoleName` to `String`
* Modified cmdlet `Update-AzConfidentialLedger`
   - Changed the type of parameter `-LedgerType` from `LedgerType` to `String`
#### Az.ContainerRegistry 5.0.0 
* Modified cmdlet `Get-AzContainerRegistryAgentPool`
   - Added parameter `-RegistryInputObject`
* Modified cmdlet `Get-AzContainerRegistryAgentPoolQueueStatus`
   - Added parameter `-RegistryInputObject`
   - Output type changed from ``Int32`` to ``IAgentPoolQueueStatus``
* Modified cmdlet `Get-AzContainerRegistryExportPipeline`
   - Added parameter `-RegistryInputObject`
* Modified cmdlet `Get-AzContainerRegistryImportPipeline`
   - Added parameter `-RegistryInputObject`
* Modified cmdlet `Get-AzContainerRegistryScopeMap`
   - Added parameter `-RegistryInputObject`
* Modified cmdlet `Get-AzContainerRegistryToken`
   - Added parameter `-RegistryInputObject`
* Modified cmdlet `Get-AzContainerRegistryWebhookCallbackConfig`
   - Added parameter `-RegistryInputObject`
* Modified cmdlet `Import-AzContainerRegistryImage`
   - Removed parameter `-Parameter`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-Mode` from `ImportMode` to `String`
* Modified cmdlet `New-AzContainerRegistry`
   - Removed parameters `-IdentityType`, `-IdentityUserAssignedIdentity`
   - Added parameters `-EnableSystemAssignedIdentity`, `-UserAssignedIdentity`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-Sku` from `SkuName` to `String`
   - Changed the type of parameter `-AzureAdAuthenticationAsArmPolicyStatus` from `AzureAdAuthenticationAsArmPolicyStatus` to `String`
   - Changed the type of parameter `-EncryptionStatus` from `EncryptionStatus` to `String`
   - Changed the type of parameter `-ExportPolicyStatus` from `ExportPolicyStatus` to `String`
   - Changed the type of parameter `-NetworkRuleBypassOption` from `NetworkRuleBypassOptions` to `String`
   - Changed the type of parameter `-NetworkRuleSetDefaultAction` from `DefaultAction` to `String`
   - Changed the type of parameter `-PublicNetworkAccess` from `PublicNetworkAccess` to `String`
   - Changed the type of parameter `-QuarantinePolicyStatus` from `PolicyStatus` to `String`
   - Changed the type of parameter `-RetentionPolicyStatus` from `PolicyStatus` to `String`
   - Changed the type of parameter `-SoftDeletePolicyStatus` from `PolicyStatus` to `String`
   - Changed the type of parameter `-TrustPolicyStatus` from `PolicyStatus` to `String`
   - Changed the type of parameter `-TrustPolicyType` from `TrustPolicyType` to `String`
   - Changed the type of parameter `-ZoneRedundancy` from `ZoneRedundancy` to `String`
* Modified cmdlet `New-AzContainerRegistryAgentPool`
   - Added parameters `-RegistryInputObject`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-OS` from `OS` to `String`
* Modified cmdlet `New-AzContainerRegistryCredentials`
   - Added parameters `-JsonString`, `-JsonFilePath`
   - Changed the type of parameter `-Name` from `TokenPasswordName` to `String`
   - Output type changed from ``PSContainerRegistryCredential`` to ``IGenerateCredentialsResult``
* Modified cmdlet `New-AzContainerRegistryExportPipeline`
   - Removed parameters `-IdentityType`, `-IdentityUserAssignedIdentity`
   - Added parameters `-RegistryInputObject`, `-EnableSystemAssignedIdentity`, `-UserAssignedIdentity`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-Option` from `PipelineOptions[]` to `String[]`
* Modified cmdlet `New-AzContainerRegistryImportPipeline`
   - Removed parameters `-IdentityType`, `-IdentityUserAssignedIdentity`
   - Added parameters `-RegistryInputObject`, `-EnableSystemAssignedIdentity`, `-UserAssignedIdentity`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-Option` from `PipelineOptions[]` to `String[]`
   - Changed the type of parameter `-SourceTriggerStatus` from `TriggerStatus` to `String`
   - Changed the type of parameter `-SourceType` from `PipelineSourceType` to `String`
* Modified cmdlet `New-AzContainerRegistryIPRuleObject`
   - Changed the type of parameter `-Action` from `Action` to `String`
* Modified cmdlet `New-AzContainerRegistryReplication`
   - Added parameters `-RegistryInputObject`, `-JsonString`, `-JsonFilePath`
   - Changed the type of parameter `-ZoneRedundancy` from `ZoneRedundancy` to `String`
* Modified cmdlet `New-AzContainerRegistryScopeMap`
   - Added parameters `-RegistryInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzContainerRegistryToken`
   - Added parameters `-RegistryInputObject`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-Status` from `TokenStatus` to `String`
* Modified cmdlet `New-AzContainerRegistryWebhook`
   - Added parameters `-RegistryInputObject`, `-JsonString`, `-JsonFilePath`
   - Changed the type of parameter `-Action` from `WebhookAction[]` to `String[]`
   - Changed the type of parameter `-Status` from `WebhookStatus` to `String`
* Modified cmdlet `Remove-AzContainerRegistryAgentPool`
   - Added parameter `-RegistryInputObject`
* Modified cmdlet `Remove-AzContainerRegistryExportPipeline`
   - Added parameter `-RegistryInputObject`
* Modified cmdlet `Remove-AzContainerRegistryImportPipeline`
   - Added parameter `-RegistryInputObject`
* Modified cmdlet `Remove-AzContainerRegistryReplication`
   - Added parameter `-RegistryInputObject`
* Modified cmdlet `Remove-AzContainerRegistryScopeMap`
   - Added parameter `-RegistryInputObject`
* Modified cmdlet `Remove-AzContainerRegistryToken`
   - Added parameter `-RegistryInputObject`
* Modified cmdlet `Remove-AzContainerRegistryWebhook`
   - Added parameter `-RegistryInputObject`
* Modified cmdlet `Test-AzContainerRegistryNameAvailability`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Test-AzContainerRegistryWebhook`
   - Output type changed from ``String`` to ``IEventInfo``
* Modified cmdlet `Update-AzContainerRegistry`
   - Removed parameters `-IdentityType`, `-IdentityUserAssignedIdentity`
   - Added parameters `-EnableSystemAssignedIdentity`, `-UserAssignedIdentity`, `-ZoneRedundancy`
   - Changed the type of parameter `-AzureAdAuthenticationAsArmPolicyStatus` from `AzureAdAuthenticationAsArmPolicyStatus` to `String`
   - Changed the type of parameter `-EncryptionStatus` from `EncryptionStatus` to `String`
   - Changed the type of parameter `-ExportPolicyStatus` from `ExportPolicyStatus` to `String`
   - Changed the type of parameter `-NetworkRuleBypassOption` from `NetworkRuleBypassOptions` to `String`
   - Changed the type of parameter `-NetworkRuleSetDefaultAction` from `DefaultAction` to `String`
   - Changed the type of parameter `-PublicNetworkAccess` from `PublicNetworkAccess` to `String`
   - Changed the type of parameter `-QuarantinePolicyStatus` from `PolicyStatus` to `String`
   - Changed the type of parameter `-RetentionPolicyStatus` from `PolicyStatus` to `String`
   - Changed the type of parameter `-Sku` from `SkuName` to `String`
   - Changed the type of parameter `-SoftDeletePolicyStatus` from `PolicyStatus` to `String`
   - Changed the type of parameter `-TrustPolicyStatus` from `PolicyStatus` to `String`
   - Changed the type of parameter `-TrustPolicyType` from `TrustPolicyType` to `String`
* Modified cmdlet `Update-AzContainerRegistryAgentPool`
   - Added parameters `-RegistryInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzContainerRegistryCredential`
   - Removed parameter `-RegenerateCredentialParameter`
   - Added parameters `-JsonString`, `-JsonFilePath`
   - Changed the type of parameter `-PasswordName` from `PasswordName` to `String`
   - Output type changed from ``PSContainerRegistryCredential`` to ``IRegistryListCredentialsResult``
* Modified cmdlet `Update-AzContainerRegistryScopeMap`
   - Added parameters `-RegistryInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzContainerRegistryToken`
   - Added parameters `-RegistryInputObject`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-Status` from `TokenStatus` to `String`
* Modified cmdlet `Update-AzContainerRegistryWebhook`
   - Added parameters `-RegistryInputObject`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-Action` from `WebhookAction[]` to `String[]`
   - Changed the type of parameter `-Status` from `WebhookStatus` to `String`
* Added cmdlet `Update-AzContainerRegistryExportPipeline`, `Update-AzContainerRegistryImportPipeline`
#### Az.DevCenter 3.0.0 
* Modified cmdlet `Get-AzDevCenterAdminImage`
   - Added parameter `-ProjectName`
* Modified cmdlet `Get-AzDevCenterAdminImageVersion`
   - Added parameter `-ProjectName`
* Removed cmdlet `Get-AzDevCenterAdminPlan`, `Get-AzDevCenterAdminPlanMember`
* Modified cmdlet `Get-AzDevCenterAdminSku`
   - `SupportsShouldProcess` changed from False to True
   - Added parameters `-ProjectName`, `-ResourceGroupName`
* Modified cmdlet `New-AzDevCenterAdminDevCenter`
   - Removed parameter `-PlanId`
* Removed cmdlet `New-AzDevCenterAdminPlan`, `New-AzDevCenterAdminPlanMember`
* Modified cmdlet `New-AzDevCenterAdminPool`
   - Added parameters `-ActiveHourConfigurationAutoStartEnableStatus`, `-ActiveHourConfigurationDefaultEndTimeHour`, `-ActiveHourConfigurationDefaultStartTimeHour`, `-ActiveHourConfigurationDefaultTimeZone`, `-ActiveHourConfigurationKeepAwakeEnableStatus`, `-DevBoxDefinitionType`, `-DevBoxTunnelEnableStatus`, `-ImageReferenceId`, `-SkuCapacity`, `-SkuFamily`, `-SkuName`, `-SkuSize`, `-SkuTier`, `-StopOnNoConnectGracePeriodMinute`, `-StopOnNoConnectStatus`
* Modified cmdlet `New-AzDevCenterAdminProject`
   - Added parameters `-AzureAiServiceSettingAzureAiServicesMode`, `-CustomizationSettingIdentity`, `-CustomizationSettingUserCustomizationsEnableStatus`, `-DevBoxAutoDeleteSettingDeleteMode`, `-DevBoxAutoDeleteSettingGracePeriod`, `-DevBoxAutoDeleteSettingInactiveThreshold`, `-ServerlessGpuSessionSettingMaxConcurrentSessionsPerProject`, `-ServerlessGpuSessionSettingServerlessGpuSessionsMode`, `-WorkspaceStorageSettingWorkspaceStorageMode`
* Modified cmdlet `New-AzDevCenterUserDevBox`
   - Removed parameter `-LocalAdministrator`
* Removed cmdlet `Remove-AzDevCenterAdminPlan`, `Remove-AzDevCenterAdminPlanMember`
* Modified cmdlet `Remove-AzDevCenterUserEnvironment`
   - Added parameter `-Force`
* Modified cmdlet `Update-AzDevCenterAdminDevCenter`
   - Removed parameter `-PlanId`
* Removed cmdlet `Update-AzDevCenterAdminPlan`, `Update-AzDevCenterAdminPlanMember`
* Modified cmdlet `Update-AzDevCenterAdminPool`
   - Added parameters `-ActiveHourConfigurationAutoStartEnableStatus`, `-ActiveHourConfigurationDefaultEndTimeHour`, `-ActiveHourConfigurationDefaultStartTimeHour`, `-ActiveHourConfigurationDefaultTimeZone`, `-ActiveHourConfigurationKeepAwakeEnableStatus`, `-DevBoxDefinitionType`, `-DevBoxTunnelEnableStatus`, `-ImageReferenceId`, `-SkuCapacity`, `-SkuFamily`, `-SkuName`, `-SkuSize`, `-SkuTier`, `-StopOnNoConnectGracePeriodMinute`, `-StopOnNoConnectStatus`
* Modified cmdlet `Update-AzDevCenterAdminProject`
   - Added parameters `-AzureAiServiceSettingAzureAiServicesMode`, `-CustomizationSettingIdentity`, `-CustomizationSettingUserCustomizationsEnableStatus`, `-DevBoxAutoDeleteSettingDeleteMode`, `-DevBoxAutoDeleteSettingGracePeriod`, `-DevBoxAutoDeleteSettingInactiveThreshold`, `-ServerlessGpuSessionSettingMaxConcurrentSessionsPerProject`, `-ServerlessGpuSessionSettingServerlessGpuSessionsMode`, `-WorkspaceStorageSettingWorkspaceStorageMode`
* Added cmdlet `Approve-AzDevCenterUserDevBox`, `Build-AzDevCenterAdminProjectCatalogImageDefinitionImage`, `Disable-AzDevCenterUserDevBoxAddOn`, `Enable-AzDevCenterUserDevBoxAddOn`, `Get-AzDevCenterAdminProjectCatalogImageDefinition`, `Get-AzDevCenterAdminProjectCatalogImageDefinitionBuild`, `Get-AzDevCenterAdminProjectCatalogImageDefinitionBuildDetail`, `Get-AzDevCenterAdminProjectCatalogImageDefinitionErrorDetail`, `Get-AzDevCenterAdminProjectPolicy`, `Get-AzDevCenterUserDevBoxAddon`, `Get-AzDevCenterUserDevBoxImagingTaskLog`, `Get-AzDevCenterUserDevBoxSnapshot`, `Get-AzDevCenterUserDevCenterApproval`, `Get-AzDevCenterUserEnvironmentTypeAbility`, `Get-AzDevCenterUserProjectAbility`, `Invoke-AzDevCenterUserAlignPool`, `New-AzDevCenterAdminProjectPolicy`, `New-AzDevCenterUserDevBoxAddOn`, `New-AzDevCenterUserDevBoxSnapshot`, `Remove-AzDevCenterAdminProjectPolicy`, `Remove-AzDevCenterUserDevBoxAddOn`, `Restore-AzDevCenterUserDevBoxSnapshot`, `Set-AzDevCenterUserDevBoxActiveHour`, `Stop-AzDevCenterAdminProjectCatalogImageDefinitionBuild`, `Update-AzDevCenterAdminProjectPolicy`
#### Az.ElasticSan 1.5.0 
* Modified cmdlet `New-AzElasticSan`
   - Added parameters `-AutoScalePolicyEnforcement`, `-CapacityUnitScaleUpLimitTiB`, `-IncreaseCapacityUnitByTiB`, `-UnusedSizeTiB`
* Modified cmdlet `Update-AzElasticSan`
   - Added parameters `-AutoScalePolicyEnforcement`, `-CapacityUnitScaleUpLimitTiB`, `-IncreaseCapacityUnitByTiB`, `-UnusedSizeTiB`
* Added cmdlet `Test-AzElasticSanVolumeBackup`, `Test-AzElasticSanVolumeRestore`
#### Az.FrontDoor 2.0.0 
* Modified cmdlet `Disable-AzFrontDoorCustomDomainHttps`
   - Removed parameter `-ResourceId`
   - Added parameters `-SubscriptionId`, `-FrontDoorInputObject`, `-AsJob`, `-NoWait`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-FrontDoorName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-FrontendEndpointName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-InputObject` from `PSFrontendEndpoint` to `IFrontDoorIdentity`
   - Parameter `-InputObject` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PSFrontendEndpoint`` to ``Boolean``
* Modified cmdlet `Enable-AzFrontDoorCustomDomainHttps`
   - Removed parameter `-ResourceId`
   - Added parameters `-SubscriptionId`, `-FrontDoorInputObject`, `-JsonString`, `-JsonFilePath`, `-AsJob`, `-NoWait`, `-PassThru`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-FrontDoorName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-FrontendEndpointName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-InputObject` from `PSFrontendEndpoint` to `IFrontDoorIdentity`
   - Parameter `-InputObject` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PSFrontendEndpoint`` to ``Boolean``
* Modified cmdlet `Get-AzFrontDoor`
   - Added parameters `-SubscriptionId`, `-InputObject`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Added parameter alias `FrontDoorName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PSFrontDoor`` to ``IFrontDoor``
* Modified cmdlet `Get-AzFrontDoorFrontendEndpoint`
   - Removed parameters `-FrontDoorObject`, `-ResourceId`
   - Added parameters `-SubscriptionId`, `-FrontDoorInputObject`, `-InputObject`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-FrontDoorName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Added parameter alias `FrontendEndpointName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PSFrontendEndpoint`` to ``IFrontendEndpoint``
* Modified cmdlet `Get-AzFrontDoorRulesEngine`
   - Added parameters `-SubscriptionId`, `-InputObject`, `-FrontDoorInputObject`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-FrontDoorName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Added parameter alias `RulesEngineName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PSRulesEngine`` to ``IRulesEngine``
* Modified cmdlet `Get-AzFrontDoorWafManagedRuleSetDefinition`
   - Added parameter `-SubscriptionId`
   - Output type changed from ``PSManagedRuleSetDefinition`` to ``IManagedRuleSetDefinition``
* Modified cmdlet `Get-AzFrontDoorWafPolicy`
   - Added parameters `-SubscriptionId`, `-InputObject`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Added parameter alias `PolicyName` to parameter `-Name`
   - Output type changed from ``PSPolicy`` to ``IWebApplicationFirewallPolicy``
* Modified cmdlet `New-AzFrontDoor`
   - Added parameters `-SubscriptionId`, `-FriendlyName`, `-JsonFilePath`, `-JsonString`, `-AsJob`, `-NoWait`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Added parameter alias `FrontDoorName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-RoutingRule` from `PSRoutingRule[]` to `IRoutingRule[]`
   - Changed the type of parameter `-BackendPool` from `PSBackendPool[]` to `IBackendPool[]`
   - Changed the type of parameter `-FrontendEndpoint` from `PSFrontendEndpoint[]` to `IFrontendEndpoint[]`
   - Changed the type of parameter `-LoadBalancingSetting` from `PSLoadBalancingSetting[]` to `ILoadBalancingSettingsModel[]`
   - Changed the type of parameter `-HealthProbeSetting` from `PSHealthProbeSetting[]` to `IHealthProbeSettingsModel[]`
   - Changed the type of parameter `-EnabledState` from `PSEnabledState` to `String`
   - Changed the type of parameter `-BackendPoolsSetting` from `PSBackendPoolsSetting` to `IBackendPoolsSettings`
   - Output type changed from ``PSFrontDoor`` to ``IFrontDoor``
* Modified cmdlet `New-AzFrontDoorBackendObject`
   - Changed the type of parameter `-EnabledState` from `PSEnabledState` to `String`
   - Output type changed from ``PSBackend`` to ``Backend``
* Modified cmdlet `New-AzFrontDoorBackendPoolObject`
   - Added parameter `-Id`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-FrontDoorName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-Backend` from `PSBackend[]` to `IBackend[]`
   - Parameter `-Backend` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-LoadBalancingSettingsName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-HealthProbeSettingsName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PSBackendPool`` to ``BackendPool``
* Modified cmdlet `New-AzFrontDoorBackendPoolsSettingObject`
   - Changed the type of parameter `-EnforceCertificateNameCheck` from `PSEnabledState` to `String`
   - Output type changed from ``PSBackendPoolsSetting`` to ``BackendPoolsSettings``
* Modified cmdlet `New-AzFrontDoorFrontendEndpointObject`
   - Removed parameter `-WebApplicationFirewallPolicyLink`
   - Added parameters `-WebApplicationFirewallPolicyLinkId`, `-Id`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-SessionAffinityEnabledState` from `PSEnabledState` to `String`
   - Output type changed from ``PSFrontendEndpoint`` to ``FrontendEndpoint``
* Modified cmdlet `New-AzFrontDoorHeaderActionObject`
   - Changed the type of parameter `-HeaderActionType` from `PSHeaderActionType` to `String`
   - Output type changed from ``PSHeaderAction`` to ``HeaderAction``
* Modified cmdlet `New-AzFrontDoorHealthProbeSettingObject`
   - Added parameter `-Id`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-Protocol` from `PSProtocol` to `String`
   - Changed the type of parameter `-EnabledState` from `PSEnabledState` to `String`
   - Output type changed from ``PSHealthProbeSetting`` to ``HealthProbeSettingsModel``
* Modified cmdlet `New-AzFrontDoorLoadBalancingSettingObject`
   - Added parameter `-Id`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Output type changed from ``PSLoadBalancingSetting`` to ``LoadBalancingSettingsModel``
* Modified cmdlet `New-AzFrontDoorRoutingRuleObject`
   - Removed parameters `-PatternToMatch`, `-RulesEngineName`
   - Added parameters `-PatternsToMatch`, `-RouteConfiguration`, `-RuleEngineName`, `-WebApplicationFirewallPolicyLinkId`, `-Id`, `-CacheDuration`, `-QueryParameter`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-FrontDoorName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-FrontendEndpointName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-BackendPoolName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-AcceptedProtocol` from `PSProtocol[]` to `String[]`
   - Changed the type of parameter `-DynamicCompression` from `PSEnabledState` to `String`
   - Changed the type of parameter `-EnabledState` from `PSEnabledState` to `String`
   - Output type changed from ``PSRoutingRule`` to ``RoutingRule``
* Modified cmdlet `New-AzFrontDoorRulesEngine`
   - Added parameters `-SubscriptionId`, `-JsonFilePath`, `-JsonString`, `-AsJob`, `-NoWait`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-FrontDoorName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Added parameter alias `RulesEngineName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-Rule` from `PSRulesEngineRule[]` to `IRulesEngineRule[]`
   - Output type changed from ``PSRulesEngine`` to ``IRulesEngine``
* Modified cmdlet `New-AzFrontDoorRulesEngineActionObject`
   - Added parameters `-RouteConfigurationOverride`, `-CacheDuration`, `-QueryParameter`
   - Changed the type of parameter `-RequestHeaderAction` from `List`1[Microsoft.Azure.Commands.FrontDoor.Models.PSHeaderAction]` to `IHeaderAction[]`
   - Changed the type of parameter `-ResponseHeaderAction` from `List`1[Microsoft.Azure.Commands.FrontDoor.Models.PSHeaderAction]` to `IHeaderAction[]`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-FrontDoorName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-BackendPoolName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-DynamicCompression` from `PSEnabledState` to `String`
   - Output type changed from ``PSRulesEngineAction`` to ``RulesEngineAction``
* Modified cmdlet `New-AzFrontDoorRulesEngineMatchConditionObject`
   - Changed the type of parameter `-MatchVariable` from `PSRulesEngineMatchVariable` to `String`
   - Changed the type of parameter `-Operator` from `PSRulesEngineOperator` to `String`
   - Changed the type of parameter `-Transform` from `PSTransform[]` to `String[]`
   - Output type changed from ``PSRulesEngineMatchCondition`` to ``RulesEngineMatchCondition``
* Modified cmdlet `New-AzFrontDoorRulesEngineRuleObject`
   - Changed the type of parameter `-Action` from `PSRulesEngineAction` to `IRulesEngineAction`
   - Changed the type of parameter `-MatchProcessingBehavior` from `PSMatchProcessingBehavior` to `String`
   - Changed the type of parameter `-MatchCondition` from `PSRulesEngineMatchCondition[]` to `IRulesEngineMatchCondition[]`
   - Output type changed from ``PSRulesEngineRule`` to ``RulesEngineRule``
* Modified cmdlet `New-AzFrontDoorWafCustomRuleGroupByVariableObject`
   - Output type changed from ``PSFrontDoorWafCustomRuleGroupByVariable`` to ``GroupByVariable``
* Modified cmdlet `New-AzFrontDoorWafCustomRuleObject`
   - Removed parameter `-CustomRule`
   - Added parameter `-GroupByCustomRule`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-MatchCondition` from `PSMatchCondition[]` to `IMatchCondition[]`
   - Parameter `-MatchCondition` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-RateLimitDurationInMinutes` from `Int32` to `Nullable`1[System.Int32]`
   - Changed the type of parameter `-RateLimitThreshold` from `Nullable`1[System.Int32]` to `Int32`
   - Output type changed from ``PSCustomRule`` to ``CustomRule``
* Modified cmdlet `New-AzFrontDoorWafLogScrubbingRuleObject`
   - Output type changed from ``PSFrontDoorWafLogScrubbingRule`` to ``WebApplicationFirewallScrubbingRules``
* Modified cmdlet `New-AzFrontDoorWafLogScrubbingSettingObject`
   - Changed the type of parameter `-ScrubbingRule` from `PSFrontDoorWafLogScrubbingRule[]` to `IWebApplicationFirewallScrubbingRules[]`
   - Output type changed from ``PSFrontDoorWafLogScrubbingSetting`` to ``PolicySettingsLogScrubbing``
* Modified cmdlet `New-AzFrontDoorWafManagedRuleExclusionObject`
   - Output type changed from ``PSManagedRuleExclusion`` to ``ManagedRuleExclusion``
* Modified cmdlet `New-AzFrontDoorWafManagedRuleObject`
   - Added parameter `-RuleSetAction`
   - Changed the type of parameter `-RuleGroupOverride` from `PSAzureRuleGroupOverride[]` to `IManagedRuleGroupOverride[]`
   - Changed the type of parameter `-Exclusion` from `PSManagedRuleExclusion[]` to `IManagedRuleExclusion[]`
   - Output type changed from ``PSAzureManagedRule`` to ``ManagedRuleSet``
* Modified cmdlet `New-AzFrontDoorWafManagedRuleOverrideObject`
   - Changed the type of parameter `-Exclusion` from `PSManagedRuleExclusion[]` to `IManagedRuleExclusion[]`
   - Output type changed from ``PSAzureManagedRuleOverride`` to ``ManagedRuleOverride``
* Modified cmdlet `New-AzFrontDoorWafMatchConditionObject`
   - Output type changed from ``PSMatchCondition`` to ``MatchCondition``
* Modified cmdlet `New-AzFrontDoorWafPolicy`
   - Removed parameters `-ManagedRule`, `-Sku`
   - Added parameters `-SubscriptionId`, `-Etag`, `-ManagedRuleSet`, `-SkuName`, `-JsonFilePath`, `-JsonString`, `-AsJob`, `-NoWait`
   - Added parameter alias `PolicyName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-EnabledState` from `PSEnabledState` to `String`
   - Changed the type of parameter `-Customrule` from `PSCustomRule[]` to `ICustomRule[]`
   - Parameter `-Customrule` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-LogScrubbingSetting` from `PSFrontDoorWafLogScrubbingSetting` to `IPolicySettingsLogScrubbing`
   - Output type changed from ``PSPolicy`` to ``IWebApplicationFirewallPolicy``
* Modified cmdlet `New-AzFrontDoorWafRuleGroupOverrideObject`
   - Changed the type of parameter `-ManagedRuleOverride` from `PSAzureManagedRuleOverride[]` to `IManagedRuleOverride[]`
   - Changed the type of parameter `-Exclusion` from `PSManagedRuleExclusion[]` to `IManagedRuleExclusion[]`
   - Output type changed from ``PSAzureRuleGroupOverride`` to ``ManagedRuleGroupOverride``
* Modified cmdlet `Remove-AzFrontDoor`
   - Removed parameter `-ResourceId`
   - Added parameters `-SubscriptionId`, `-AsJob`, `-NoWait`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Added parameter alias `FrontDoorName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-InputObject` from `PSFrontDoor` to `IFrontDoorIdentity`
   - Parameter `-InputObject` ValidateNotNullOrEmpty changed from `True` to `False`
* Modified cmdlet `Remove-AzFrontDoorContent`
   - Added parameters `-SubscriptionId`, `-InputObject`, `-ContentFilePath`, `-JsonFilePath`, `-JsonString`, `-AsJob`, `-NoWait`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
* Modified cmdlet `Remove-AzFrontDoorRulesEngine`
   - Removed parameter `-ResourceId`
   - Added parameters `-SubscriptionId`, `-FrontDoorInputObject`, `-AsJob`, `-NoWait`
   - Changed the type of parameter `-InputObject` from `PSRulesEngine` to `IFrontDoorIdentity`
   - Parameter `-InputObject` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-FrontDoorName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Added parameter alias `RulesEngineName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
* Modified cmdlet `Remove-AzFrontDoorWafPolicy`
   - Removed parameter `-ResourceId`
   - Added parameters `-SubscriptionId`, `-AsJob`, `-NoWait`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Added parameter alias `PolicyName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-InputObject` from `PSPolicy` to `IFrontDoorIdentity`
   - Parameter `-InputObject` ValidateNotNullOrEmpty changed from `True` to `False`
* Modified cmdlet `Set-AzFrontDoor`
   - Removed parameters `-InputObject`, `-ResourceId`
   - Added parameters `-SubscriptionId`, `-FriendlyName`, `-JsonFilePath`, `-JsonString`, `-AsJob`, `-NoWait`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Added parameter alias `FrontDoorName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-RoutingRule` from `PSRoutingRule[]` to `IRoutingRule[]`
   - Changed the type of parameter `-BackendPool` from `PSBackendPool[]` to `IBackendPool[]`
   - Changed the type of parameter `-FrontendEndpoint` from `PSFrontendEndpoint[]` to `IFrontendEndpoint[]`
   - Changed the type of parameter `-LoadBalancingSetting` from `PSLoadBalancingSetting[]` to `ILoadBalancingSettingsModel[]`
   - Changed the type of parameter `-HealthProbeSetting` from `PSHealthProbeSetting[]` to `IHealthProbeSettingsModel[]`
   - Changed the type of parameter `-EnabledState` from `PSEnabledState` to `String`
   - Changed the type of parameter `-BackendPoolsSetting` from `PSBackendPoolsSetting` to `IBackendPoolsSettings`
   - Output type changed from ``PSFrontDoor`` to ``IFrontDoor``
* Modified cmdlet `Set-AzFrontDoorRulesEngine`
   - Removed parameters `-InputObject`, `-ResourceId`
   - Added parameters `-SubscriptionId`, `-AsJob`, `-NoWait`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Parameter `-FrontDoorName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Added parameter alias `RulesEngineName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-Rule` from `PSRulesEngineRule[]` to `IRulesEngineRule[]`
   - Output type changed from ``PSRulesEngine`` to ``IRulesEngine``
* Modified cmdlet `Update-AzFrontDoorWafPolicy`
   - Removed parameters `-ResourceId`, `-ManagedRule`
   - Added parameters `-SubscriptionId`, `-Etag`, `-ManagedRuleSet`, `-SkuName`, `-Tag`, `-AsJob`, `-NoWait`
   - Parameter `-ResourceGroupName` ValidateNotNullOrEmpty changed from `True` to `False`
   - Added parameter alias `PolicyName` to parameter `-Name`
   - Parameter `-Name` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-InputObject` from `PSPolicy` to `IFrontDoorIdentity`
   - Parameter `-InputObject` ValidateNotNullOrEmpty changed from `True` to `False`
   - Changed the type of parameter `-EnabledState` from `PSEnabledState` to `String`
   - Changed the type of parameter `-Customrule` from `PSCustomRule[]` to `ICustomRule[]`
   - Changed the type of parameter `-LogScrubbingSetting` from `PSFrontDoorWafLogScrubbingSetting` to `IPolicySettingsLogScrubbing`
   - Output type changed from ``PSPolicy`` to ``IWebApplicationFirewallPolicy``
* Added cmdlet `New-AzFrontDoorCacheConfigurationObject`, `New-AzFrontDoorForwardingConfigurationObject`, `New-AzFrontDoorPolicySettingsObject`, `New-AzFrontDoorRedirectConfigurationObject`
#### Az.Nginx 2.0.0 
* Modified cmdlet `Get-AzNginxCertificate`
   - Added parameter `-NginxDeploymentInputObject`
* Modified cmdlet `Get-AzNginxConfiguration`
   - Added parameter `-NginxDeploymentInputObject`
* Modified cmdlet `Invoke-AzNginxAnalysisConfiguration`
   - Removed parameter `-Body`
   - Added parameters `-NginxDeploymentInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzNginxCertificate`
   - Added parameters `-NginxDeploymentInputObject`, `-CertificateErrorCode`, `-CertificateErrorMessage`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzNginxConfiguration`
   - Added parameters `-NginxDeploymentInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzNginxDeployment`
   - Removed parameters `-IdentityType`, `-IdentityUserAssignedIdentity`
   - Added parameters `-JsonFilePath`, `-JsonString`, `-AutoUpgradeProfileUpgradeChannel`, `-EnableSystemAssignedIdentity`, `-UserAssignedIdentity`
* Modified cmdlet `New-AzNginxPrivateIPAddressObject`
   - Changed the type of parameter `-PrivateIPAllocationMethod` from `NginxPrivateIPAllocationMethod` to `String`
* Modified cmdlet `Remove-AzNginxCertificate`
   - Added parameter `-NginxDeploymentInputObject`
* Modified cmdlet `Remove-AzNginxConfiguration`
   - Added parameter `-NginxDeploymentInputObject`
* Modified cmdlet `Update-AzNginxDeployment`
   - Removed parameters `-IdentityType`, `-IdentityUserAssignedIdentity`
   - Added parameters `-JsonFilePath`, `-JsonString`, `-EnableSystemAssignedIdentity`, `-UserAssignedIdentity`, `-NetworkProfile`
* Added cmdlet `Update-AzNginxCertificate`, `Update-AzNginxConfiguration`
#### Az.Oracle 2.0.0 
* Modified cmdlet `Get-AzOracleDbSystemShape`
   - Added parameter `-ShapeAttribute`
* Modified cmdlet `Get-AzOracleGiVersion`
   - Added parameter `-ShapeAttribute`
* Modified cmdlet `New-AzOracleAutonomousDatabase`
   - Removed parameters `-DayOfWeekName`, `-ScheduledStartTime`, `-ScheduledStopTime`
   - Added parameter `-ScheduledOperationsList`
* Modified cmdlet `New-AzOracleCloudVMCluster`
   - Added parameter `-ExascaleDbStorageVaultId`
* Modified cmdlet `New-AzOracleExadbVMCluster`
   - Added parameter `-ShapeAttribute`
* Modified cmdlet `New-AzOracleExascaleDbStorageVault`
   - Added parameter `-ExadataInfrastructureId`
* Modified cmdlet `Update-AzOracleAutonomousDatabase`
   - Removed parameters `-DayOfWeekName`, `-ScheduledStartTime`, `-ScheduledStopTime`
   - Added parameter `-ScheduledOperationsList`
* Added cmdlet `Get-AzOracleDbSystem`, `Get-AzOracleDbVersion`, `Get-AzOracleNetworkAnchor`, `Get-AzOracleResourceAnchor`, `Invoke-AzOracleActionAutonomousDatabase`, `New-AzOracleDbSystem`, `New-AzOracleNetworkAnchor`, `New-AzOracleResourceAnchor`, `Remove-AzOracleDbSystem`, `Remove-AzOracleNetworkAnchor`, `Remove-AzOracleResourceAnchor`, `Update-AzOracleDbSystem`, `Update-AzOracleNetworkAnchor`, `Update-AzOracleResourceAnchor`
#### Az.Relay 3.0.0 
* Modified cmdlet `Get-AzRelayHybridConnection`
   - Added parameter `-NamespaceInputObject`
* Modified cmdlet `Get-AzWcfRelay`
   - Added parameter `-NamespaceInputObject`
* Modified cmdlet `New-AzRelayAuthorizationRule`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-Rights` from `AccessRights[]` to `String[]`
* Modified cmdlet `New-AzRelayHybridConnection`
   - Added parameters `-NamespaceInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzRelayKey`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-RegenerateKey` from `KeyType` to `String`
* Modified cmdlet `New-AzRelayNamespace`
   - Added parameters `-InputObject`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-SkuTier` from `SkuTier` to `String`
* Modified cmdlet `New-AzRelayNetworkRuleSetIPRuleObject`
   - Changed the type of parameter `-Action` from `NetworkRuleIPAction` to `String`
* Modified cmdlet `New-AzWcfRelay`
   - Added parameters `-NamespaceInputObject`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-WcfRelayType` from `Relaytype` to `String`
* Modified cmdlet `Remove-AzRelayHybridConnection`
   - Added parameter `-NamespaceInputObject`
* Modified cmdlet `Remove-AzWcfRelay`
   - Added parameter `-NamespaceInputObject`
* Modified cmdlet `Set-AzRelayAuthorizationRule`
   - Changed the type of parameter `-Rights` from `AccessRights[]` to `String[]`
* Modified cmdlet `Set-AzRelayNamespaceNetworkRuleSet`
   - Changed the type of parameter `-DefaultAction` from `DefaultAction` to `String`
   - Changed the type of parameter `-PublicNetworkAccess` from `PublicNetworkAccess` to `String`
* Modified cmdlet `Set-AzWcfRelay`
   - Changed the type of parameter `-WcfRelayType` from `Relaytype` to `String`
* Modified cmdlet `Test-AzRelayName`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzRelayNamespace`
   - Added parameters `-JsonFilePath`, `-JsonString`
#### Az.ServiceFabric 5.0.0 
* Modified cmdlet `Set-AzServiceFabricManagedNodeType`
   - Removed parameters `-NodeName`, `-Reimage`, `-ForceReimage`, `-PassThru`
#### Az.Storage 9.4.0 
* Modified cmdlet `Invoke-AzStorageAccountFailover`
   - Added parameter `-FailoverType`
#### Az.StorageMover 2.0.0 
* Modified cmdlet `Get-AzStorageMoverAgent`
   - Added parameter `-StorageMoverInputObject`
* Modified cmdlet `Get-AzStorageMoverEndpoint`
   - Added parameter `-StorageMoverInputObject`
* Modified cmdlet `Get-AzStorageMoverJobDefinition`
   - Added parameters `-ProjectInputObject`, `-StorageMoverInputObject`
* Modified cmdlet `Get-AzStorageMoverJobRun`
   - Added parameters `-JobDefinitionInputObject`, `-ProjectInputObject`, `-StorageMoverInputObject`
* Modified cmdlet `Get-AzStorageMoverProject`
   - Added parameter `-StorageMoverInputObject`
* Modified cmdlet `New-AzStorageMover`
   - Removed parameter `-StorageMover`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzStorageMoverJobDefinition`
   - Removed parameter `-JobDefinition`
   - Added parameters `-ProjectInputObject`, `-StorageMoverInputObject`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-CopyMode` from `CopyMode` to `String`
   - Changed the type of parameter `-JobType` from `JobType` to `String`
* Modified cmdlet `New-AzStorageMoverNfsEndpoint`
   - Changed the type of parameter `-NfsVersion` from `NfsVersion` to `String`
* Modified cmdlet `New-AzStorageMoverProject`
   - Removed parameter `-Project`
   - Added parameters `-StorageMoverInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzStorageMoverUploadLimitWeeklyRecurrenceObject`
   - Changed the type of parameter `-Day` from `DayOfWeek[]` to `String[]`
* Modified cmdlet `Remove-AzStorageMoverEndpoint`
   - Added parameter `-StorageMoverInputObject`
* Modified cmdlet `Remove-AzStorageMoverJobDefinition`
   - Added parameters `-ProjectInputObject`, `-StorageMoverInputObject`
* Modified cmdlet `Remove-AzStorageMoverProject`
   - Added parameter `-StorageMoverInputObject`
* Modified cmdlet `Start-AzStorageMoverJobDefinition`
   - Added parameters `-ProjectInputObject`, `-StorageMoverInputObject`
   - Output type changed from ``String`` to ``IJobRunResourceId``
* Modified cmdlet `Stop-AzStorageMoverJobDefinition`
   - Added parameters `-ProjectInputObject`, `-StorageMoverInputObject`
   - Output type changed from ``String`` to ``IJobRunResourceId``
* Modified cmdlet `Update-AzStorageMover`
   - Removed parameter `-StorageMover`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzStorageMoverAgent`
   - Removed parameter `-Agent`
   - Added parameters `-StorageMoverInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzStorageMoverJobDefinition`
   - Removed parameter `-JobDefinition`
   - Added parameters `-ProjectInputObject`, `-StorageMoverInputObject`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-CopyMode` from `CopyMode` to `String`
* Modified cmdlet `Update-AzStorageMoverProject`
   - Removed parameter `-Project`
   - Added parameters `-StorageMoverInputObject`, `-JsonFilePath`, `-JsonString`
#### Az.StreamAnalytics 3.0.0 
* Modified cmdlet `Get-AzStreamAnalyticsFunction`
   - Added parameter `-StreamingjobInputObject`
* Modified cmdlet `Get-AzStreamAnalyticsInput`
   - Added parameter `-StreamingjobInputObject`
* Modified cmdlet `Get-AzStreamAnalyticsOutput`
   - Added parameter `-StreamingjobInputObject`
* Modified cmdlet `Get-AzStreamAnalyticsTransformation`
   - Added parameter `-StreamingjobInputObject`
* Modified cmdlet `New-AzStreamAnalyticsCluster`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-SkuName` from `ClusterSkuName` to `String`
* Modified cmdlet `New-AzStreamAnalyticsJob`
   - Changed the type of parameter `-SkuName` from `StreamingJobSkuName` to `String`
   - Changed the type of parameter `-CompatibilityLevel` from `CompatibilityLevel` to `String`
   - Changed the type of parameter `-EventsOutOfOrderPolicy` from `EventsOutOfOrderPolicy` to `String`
   - Changed the type of parameter `-OutputErrorPolicy` from `OutputErrorPolicy` to `String`
* Modified cmdlet `New-AzStreamAnalyticsTransformation`
   - Added parameters `-StreamingjobInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Remove-AzStreamAnalyticsFunction`
   - Added parameter `-StreamingjobInputObject`
* Modified cmdlet `Remove-AzStreamAnalyticsInput`
   - Added parameter `-StreamingjobInputObject`
* Modified cmdlet `Remove-AzStreamAnalyticsOutput`
   - Added parameter `-StreamingjobInputObject`
* Modified cmdlet `Start-AzStreamAnalyticsJob`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-OutputStartMode` from `OutputStartMode` to `String`
* Modified cmdlet `Update-AzStreamAnalyticsCluster`
   - Removed parameter `-Location`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-SkuName` from `ClusterSkuName` to `String`
* Modified cmdlet `Update-AzStreamAnalyticsJob`
   - Changed the type of parameter `-EventsOutOfOrderPolicy` from `EventsOutOfOrderPolicy` to `String`
   - Changed the type of parameter `-OutputErrorPolicy` from `OutputErrorPolicy` to `String`
* Modified cmdlet `Update-AzStreamAnalyticsTransformation`
   - Added parameters `-StreamingjobInputObject`, `-JsonFilePath`, `-JsonString`
#### Az.Workloads 2.0.0 
* Modified cmdlet `Get-AzWorkloadsProviderInstance`
   - Added parameter `-MonitorInputObject`
* Modified cmdlet `Get-AzWorkloadsSapApplicationInstance`
   - Added parameter `-SapVirtualInstanceInputObject`
* Modified cmdlet `Get-AzWorkloadsSapCentralInstance`
   - Added parameter `-SapVirtualInstanceInputObject`
* Modified cmdlet `Get-AzWorkloadsSapDatabaseInstance`
   - Added parameter `-SapVirtualInstanceInputObject`
* Modified cmdlet `Invoke-AzWorkloadsSapDiskConfiguration`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-DatabaseType` from `SapDatabaseType` to `String`
   - Changed the type of parameter `-DeploymentType` from `SapDeploymentType` to `String`
   - Changed the type of parameter `-Environment` from `SapEnvironmentType` to `String`
   - Changed the type of parameter `-SapProduct` from `SapProductType` to `String`
   - Output type changed from ``ISapDiskConfigurationsResultVolumeConfigurations`` to ``ISapDiskConfigurationsResult``
* Modified cmdlet `Invoke-AzWorkloadsSapSizingRecommendation`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-DatabaseType` from `SapDatabaseType` to `String`
   - Changed the type of parameter `-DeploymentType` from `SapDeploymentType` to `String`
   - Changed the type of parameter `-Environment` from `SapEnvironmentType` to `String`
   - Changed the type of parameter `-SapProduct` from `SapProductType` to `String`
   - Changed the type of parameter `-DbScaleMethod` from `SapDatabaseScaleMethod` to `String`
   - Changed the type of parameter `-HighAvailabilityType` from `SapHighAvailabilityType` to `String`
   - Output type changed from ``SapDeploymentType`` to ``ISapSizingRecommendationResult``
* Modified cmdlet `Invoke-AzWorkloadsSapSupportedSku`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-DatabaseType` from `SapDatabaseType` to `String`
   - Changed the type of parameter `-DeploymentType` from `SapDeploymentType` to `String`
   - Changed the type of parameter `-Environment` from `SapEnvironmentType` to `String`
   - Changed the type of parameter `-SapProduct` from `SapProductType` to `String`
   - Changed the type of parameter `-HighAvailabilityType` from `SapHighAvailabilityType` to `String`
   - Output type changed from ``ISapSupportedSku`` to ``ISapSupportedResourceSkusResult``
* Modified cmdlet `New-AzWorkloadsMonitor`
   - Removed parameter `-IdentityType`
   - Added parameters `-EnableSystemAssignedIdentity`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-RoutingPreference` from `RoutingPreference` to `String`
   - Changed the type of parameter `-UserAssignedIdentity` from `Hashtable` to `String[]`
* Modified cmdlet `New-AzWorkloadsProviderDB2InstanceObject`
   - Changed the type of parameter `-SslPreference` from `SslPreference` to `String`
* Modified cmdlet `New-AzWorkloadsProviderHanaDbInstanceObject`
   - Changed the type of parameter `-SslPreference` from `SslPreference` to `String`
* Modified cmdlet `New-AzWorkloadsProviderInstance`
   - Removed parameters `-IdentityType`, `-IdentityUserAssignedIdentity`
   - Added parameters `-MonitorInputObject`, `-EnableSystemAssignedIdentity`, `-UserAssignedIdentity`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzWorkloadsProviderPrometheusHaClusterInstanceObject`
   - Changed the type of parameter `-SslPreference` from `SslPreference` to `String`
* Modified cmdlet `New-AzWorkloadsProviderPrometheusOSInstanceObject`
   - Changed the type of parameter `-SslPreference` from `SslPreference` to `String`
* Modified cmdlet `New-AzWorkloadsProviderSapNetWeaverInstanceObject`
   - Changed the type of parameter `-SslPreference` from `SslPreference` to `String`
* Modified cmdlet `New-AzWorkloadsProviderSqlServerInstanceObject`
   - Changed the type of parameter `-SslPreference` from `SslPreference` to `String`
* Modified cmdlet `New-AzWorkloadsSapLandscapeMonitor`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzWorkloadsSapVirtualInstance`
   - Removed parameter `-IdentityType`
   - Added parameters `-JsonFilePath`, `-JsonString`, `-EnableSystemAssignedIdentity`
   - Changed the type of parameter `-Environment` from `SapEnvironmentType` to `String`
   - Changed the type of parameter `-SapProduct` from `SapProductType` to `String`
   - Changed the type of parameter `-UserAssignedIdentity` from `Hashtable` to `String[]`
* Modified cmdlet `Remove-AzWorkloadsProviderInstance`
   - Added parameter `-MonitorInputObject`
* Modified cmdlet `Start-AzWorkloadsSapApplicationInstance`
   - Added parameters `-SapVirtualInstanceInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Start-AzWorkloadsSapCentralInstance`
   - Added parameters `-SapVirtualInstanceInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Start-AzWorkloadsSapDatabaseInstance`
   - Added parameters `-SapVirtualInstanceInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Start-AzWorkloadsSapVirtualInstance`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Stop-AzWorkloadsSapApplicationInstance`
   - Added parameters `-SapVirtualInstanceInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Stop-AzWorkloadsSapCentralInstance`
   - Added parameters `-SapVirtualInstanceInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Stop-AzWorkloadsSapDatabaseInstance`
   - Added parameters `-SapVirtualInstanceInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Stop-AzWorkloadsSapVirtualInstance`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzWorkloadsMonitor`
   - Removed parameter `-IdentityType`
   - Added parameters `-AppLocation`, `-EnableSystemAssignedIdentity`, `-LogAnalyticsWorkspaceArmId`, `-ManagedResourceGroupName`, `-MonitorSubnet`, `-RoutingPreference`, `-ZoneRedundancyPreference`, `-AsJob`, `-NoWait`
   - Changed the type of parameter `-UserAssignedIdentity` from `Hashtable` to `String[]`
* Modified cmdlet `Update-AzWorkloadsSapApplicationInstance`
   - Added parameters `-SapVirtualInstanceInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzWorkloadsSapCentralInstance`
   - Added parameters `-SapVirtualInstanceInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzWorkloadsSapDatabaseInstance`
   - Added parameters `-SapVirtualInstanceInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzWorkloadsSapLandscapeMonitor`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzWorkloadsSapVirtualInstance`
   - Removed parameter `-IdentityType`
   - Added parameters `-EnableSystemAssignedIdentity`, `-JsonString`, `-JsonFilePath`
   - Changed the type of parameter `-ManagedResourcesNetworkAccessType` from `ManagedResourcesNetworkAccessType` to `String`
   - Changed the type of parameter `-UserAssignedIdentity` from `Hashtable` to `String[]`
* Added cmdlet `Update-AzWorkloadsProviderInstance`


