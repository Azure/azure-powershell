## 15.1.0 - December 2025
#### Az.Compute 11.1.0 
* Modified cmdlet `Get-AzVmssVM`
   - Added parameter `-ResiliencyView`
#### Az.CosmosDB 1.19.0 
* Modified cmdlet `New-AzCosmosDBAccount`
   - Added parameters `-EnablePriorityBasedExecution`, `-DefaultPriorityLevel`
* Modified cmdlet `New-AzCosmosDBSqlVectorIndex`
   - Added parameters `-QuantizationByteSize`, `-IndexingSearchListSize`, `-VectorIndexShardKey`
* Modified cmdlet `Restore-AzCosmosDBAccount`
   - Added parameter `-SourceBackupLocation`
* Modified cmdlet `Update-AzCosmosDBAccount`
   - Added parameters `-EnablePriorityBasedExecution`, `-DefaultPriorityLevel`
* Added cmdlet `Add-AzCosmosDBFleetspaceAccount`, `Get-AzCosmosDBFleet`, `Get-AzCosmosDBFleetspace`, `Get-AzCosmosDBFleetspaceAccount`, `New-AzCosmosDBFleet`, `New-AzCosmosDBFleetspace`, `Remove-AzCosmosDBFleet`, `Remove-AzCosmosDBFleetspace`, `Remove-AzCosmosDBFleetspaceAccount`, `Update-AzCosmosDBFleet`, `Update-AzCosmosDBFleetspace`
#### Az.Migrate 2.10.1 
* Modified cmdlet `New-AzMigrateServerReplication`
   - Added parameter `-TargetCapacityReservationGroupId`
* Modified cmdlet `Set-AzMigrateServerReplication`
   - Added parameter `-TargetCapacityReservationGroupId`
* Modified cmdlet `Start-AzMigrateServerMigration`
   - Added parameter `-TargetCapacityReservationGroupId`
#### Az.Network 7.24.0 
* Modified cmdlet `New-AzNetworkVirtualAppliance`
   - Added parameter `-NvaInterfaceConfiguration`
* Modified cmdlet `New-AzNetworkWatcherFlowLog`
   - Added parameter `-RecordType`
* Modified cmdlet `Set-AzNetworkWatcherFlowLog`
   - Added parameter `-RecordType`
* Added cmdlet `New-AzNvaInterfaceConfiguration`

## 15.0.0 - November 2025
#### Az.Advisor 3.0.0 
* Modified cmdlet `Set-AzAdvisorConfiguration`
   - Changed the type of parameter `-LowCpuThreshold` from `CpuThreshold` to `String`
#### Az.ApplicationInsights 3.0.0 
* Modified cmdlet `Get-AzApplicationInsightsApiKey`
   - Added parameter `-ComponentInputObject`
* Modified cmdlet `Get-AzApplicationInsightsContinuousExport`
   - Added parameter `-ComponentInputObject`
* Modified cmdlet `Get-AzApplicationInsightsMyWorkbook`
   - Changed the type of parameter `-Category` from `CategoryType` to `String`
   - Changed the type of parameter `-Tag` from `String[]` to `List`1[System.String]`
* Modified cmdlet `Get-AzApplicationInsightsWorkbook`
   - Changed the type of parameter `-Category` from `CategoryType` to `String`
   - Changed the type of parameter `-Tag` from `String[]` to `List`1[System.String]`
* Modified cmdlet `Get-AzApplicationInsightsWorkbookRevision`
   - Added parameter `-WorkbookInputObject`
* Modified cmdlet `New-AzApplicationInsights`
   - Changed the type of parameter `-ApplicationType` from `ApplicationType` to `String`
   - Changed the type of parameter `-FlowType` from `FlowType` to `String`
   - Changed the type of parameter `-IngestionMode` from `IngestionMode` to `String`
   - Changed the type of parameter `-PublicNetworkAccessForIngestion` from `PublicNetworkAccessType` to `String`
   - Changed the type of parameter `-PublicNetworkAccessForQuery` from `PublicNetworkAccessType` to `String`
   - Changed the type of parameter `-RequestSource` from `RequestSource` to `String`
* Modified cmdlet `New-AzApplicationInsightsLinkedStorageAccount`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzApplicationInsightsMyWorkbook`
   - Removed parameter `-IdentityType`
   - Added parameters `-EnableSystemAssignedIdentity`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzApplicationInsightsWebTest`
   - Changed the type of parameter `-Kind` from `WebTestKindEnum` to `String`
* Modified cmdlet `New-AzApplicationInsightsWorkbook`
   - Removed parameters `-IdentityType`, `-IdentityUserAssignedIdentity`
   - Added parameters `-EnableSystemAssignedIdentity`, `-UserAssignedIdentity`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzApplicationInsightsWorkbookTemplate`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Remove-AzApplicationInsightsApiKey`
   - Added parameter `-ComponentInputObject`
* Modified cmdlet `Remove-AzApplicationInsightsContinuousExport`
   - Added parameter `-ComponentInputObject`
* Modified cmdlet `Update-AzApplicationInsights`
   - Changed the type of parameter `-ApplicationType` from `ApplicationType` to `String`
   - Changed the type of parameter `-FlowType` from `FlowType` to `String`
   - Changed the type of parameter `-IngestionMode` from `IngestionMode` to `String`
   - Changed the type of parameter `-PublicNetworkAccessForIngestion` from `PublicNetworkAccessType` to `String`
   - Changed the type of parameter `-PublicNetworkAccessForQuery` from `PublicNetworkAccessType` to `String`
   - Changed the type of parameter `-RequestSource` from `RequestSource` to `String`
* Modified cmdlet `Update-AzApplicationInsightsLinkedStorageAccount`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzApplicationInsightsWebTestTag`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzApplicationInsightsWorkbook`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzApplicationInsightsWorkbookTemplate`
   - Added parameters `-JsonFilePath`, `-JsonString`
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
#### Az.Cdn 6.0.0 
* Modified cmdlet `New-AzFrontDoorCdnOriginGroup`
   - Added parameters `-AuthenticationScope`, `-AuthenticationType`, `-UserAssignedIdentityId`
* Modified cmdlet `Update-AzFrontDoorCdnOriginGroup`
   - Added parameters `-AuthenticationScope`, `-AuthenticationType`, `-UserAssignedIdentityId`
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
#### Az.HealthcareApis 3.0.0 
* Modified cmdlet `Get-AzHealthcareDicomService`
   - Added parameter `-WorkspaceInputObject`
* Modified cmdlet `Get-AzHealthcareFhirService`
   - Added parameter `-WorkspaceInputObject`
* Modified cmdlet `Get-AzHealthcareIotConnector`
   - Added parameter `-WorkspaceInputObject`
* Modified cmdlet `Get-AzHealthcareIotConnectorFhirDestination`
   - Added parameters `-IotconnectorInputObject`, `-WorkspaceInputObject`
* Modified cmdlet `New-AzHealthcareApisService`
   - Removed parameter `-IdentityType`
   - Added parameters `-EnableSystemAssignedIdentity`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-Kind` from `Kind` to `String`
   - Changed the type of parameter `-PublicNetworkAccess` from `PublicNetworkAccess` to `String`
* Modified cmdlet `New-AzHealthcareApisWorkspace`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-PublicNetworkAccess` from `PublicNetworkAccess` to `String`
* Modified cmdlet `New-AzHealthcareDicomService`
   - Removed parameters `-IdentityType`, `-IdentityUserAssignedIdentity`
   - Added parameters `-WorkspaceInputObject`, `-EnableSystemAssignedIdentity`, `-UserAssignedIdentity`, `-JsonString`, `-JsonFilePath`
   - Changed the type of parameter `-PublicNetworkAccess` from `PublicNetworkAccess` to `String`
* Modified cmdlet `New-AzHealthcareFhirService`
   - Removed parameters `-IdentityType`, `-IdentityUserAssignedIdentity`
   - Added parameters `-WorkspaceInputObject`, `-EnableSystemAssignedIdentity`, `-UserAssignedIdentity`, `-JsonString`, `-JsonFilePath`
   - Changed the type of parameter `-Kind` from `FhirServiceKind` to `String`
   - Changed the type of parameter `-PublicNetworkAccess` from `PublicNetworkAccess` to `String`
   - Changed the type of parameter `-ResourceVersionPolicyConfigurationDefault` from `FhirResourceVersionPolicy` to `String`
* Modified cmdlet `New-AzHealthcareIotConnector`
   - Removed parameters `-IdentityType`, `-IdentityUserAssignedIdentity`
   - Added parameters `-WorkspaceInputObject`, `-EnableSystemAssignedIdentity`, `-UserAssignedIdentity`, `-JsonString`, `-JsonFilePath`
* Modified cmdlet `New-AzHealthcareIotConnectorFhirDestination`
   - Added parameters `-WorkspaceInputObject`, `-IotconnectorInputObject`, `-JsonString`, `-JsonFilePath`
   - Changed the type of parameter `-ResourceIdentityResolutionType` from `IotIdentityResolutionType` to `String`
* Modified cmdlet `Remove-AzHealthcareDicomService`
   - Added parameter `-DicomserviceInputObject`
* Modified cmdlet `Remove-AzHealthcareFhirService`
   - Added parameter `-FhirserviceInputObject`
* Modified cmdlet `Remove-AzHealthcareIotConnector`
   - Added parameter `-IotconnectorInputObject`
* Modified cmdlet `Remove-AzHealthcareIotConnectorFhirDestination`
   - Added parameters `-IotconnectorInputObject`, `-WorkspaceInputObject`
* Modified cmdlet `Test-AzHealthcareServiceNameAvailability`
   - Removed parameter `-InputObject`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzHealthcareApisService`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-PublicNetworkAccess` from `PublicNetworkAccess` to `String`
* Modified cmdlet `Update-AzHealthcareApisWorkspace`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzHealthcareDicomService`
   - Removed parameters `-IdentityType`, `-IdentityUserAssignedIdentity`
   - Added parameters `-WorkspaceInputObject`, `-EnableSystemAssignedIdentity`, `-Etag`, `-PublicNetworkAccess`, `-UserAssignedIdentity`
* Modified cmdlet `Update-AzHealthcareFhirService`
   - Removed parameters `-IdentityType`, `-IdentityUserAssignedIdentity`
   - Added parameters `-WorkspaceInputObject`, `-AccessPolicyObjectId`, `-AcrConfigurationLoginServer`, `-AcrConfigurationOciArtifact`, `-AllowCorsCredential`, `-Audience`, `-Authority`, `-CorsHeader`, `-CorsMaxAge`, `-CorsMethod`, `-CorsOrigin`, `-EnableSmartProxy`, `-EnableSystemAssignedIdentity`, `-Etag`, `-ExportStorageAccountName`, `-Kind`, `-PublicNetworkAccess`, `-ResourceVersionPolicyConfigurationDefault`, `-ResourceVersionPolicyConfigurationResourceTypeOverride`, `-UserAssignedIdentity`
* Modified cmdlet `Update-AzHealthcareIotConnector`
   - Removed parameters `-IdentityType`, `-IdentityUserAssignedIdentity`
   - Added parameters `-WorkspaceInputObject`, `-DeviceMappingContent`, `-EnableSystemAssignedIdentity`, `-Etag`, `-IngestionEndpointConfigurationConsumerGroup`, `-IngestionEndpointConfigurationEventHubName`, `-IngestionEndpointConfigurationFullyQualifiedEventHubNamespace`, `-UserAssignedIdentity`
* Added cmdlet `Update-AzHealthcareIotConnectorFhirDestination`
#### Az.Monitor 7.0.0 
* Modified cmdlet `New-AzActivityLogAlert`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzAutoscaleProfileObject`
   - Changed the type of parameter `-RecurrenceFrequency` from `RecurrenceFrequency` to `String`
* Modified cmdlet `New-AzAutoscaleScaleRuleMetricDimensionObject`
   - Changed the type of parameter `-Operator` from `ScaleRuleMetricDimensionOperationType` to `String`
* Modified cmdlet `New-AzAutoscaleScaleRuleObject`
   - Changed the type of parameter `-MetricTriggerOperator` from `ComparisonOperationType` to `String`
   - Changed the type of parameter `-MetricTriggerStatistic` from `MetricStatisticType` to `String`
   - Changed the type of parameter `-MetricTriggerTimeAggregation` from `TimeAggregationType` to `String`
   - Changed the type of parameter `-ScaleActionDirection` from `ScaleDirection` to `String`
   - Changed the type of parameter `-ScaleActionType` from `ScaleType` to `String`
* Modified cmdlet `New-AzAutoscaleSetting`
   - Removed parameters `-InputObject`, `-Parameter`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-PredictiveAutoscalePolicyScaleMode` from `PredictiveAutoscalePolicyScaleMode` to `String`
* Modified cmdlet `New-AzDiagnosticSetting`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzScheduledQueryRule`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-Kind` from `Kind` to `String`
* Modified cmdlet `New-AzScheduledQueryRuleConditionObject`
   - Changed the type of parameter `-Operator` from `ConditionOperator` to `String`
   - Changed the type of parameter `-TimeAggregation` from `TimeAggregation` to `String`
* Modified cmdlet `New-AzScheduledQueryRuleDimensionObject`
   - Changed the type of parameter `-Operator` from `DimensionOperator` to `String`
* Modified cmdlet `New-AzSubscriptionDiagnosticSetting`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzActivityLogAlert`
   - Added parameters `-JsonString`, `-JsonFilePath`
* Modified cmdlet `Update-AzAutoscaleSetting`
   - Changed the type of parameter `-PredictiveAutoscalePolicyScaleMode` from `PredictiveAutoscalePolicyScaleMode` to `String`
* Modified cmdlet `Update-AzScheduledQueryRule`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Added cmdlet `Update-AzDiagnosticSetting`, `Update-AzSubscriptionDiagnosticSetting`
#### Az.NetworkCloud 2.0.0 
* Modified cmdlet `Deploy-AzNetworkCloudCluster`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Enable-AzNetworkCloudStorageApplianceRemoteVendorManagement`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Get-AzNetworkCloudAgentPool`
   - Added parameter `-KubernetesClusterInputObject`
* Modified cmdlet `Get-AzNetworkCloudBareMetalMachineKeySet`
   - Added parameter `-ClusterInputObject`
* Modified cmdlet `Get-AzNetworkCloudBmcKeySet`
   - Added parameter `-ClusterInputObject`
* Modified cmdlet `Get-AzNetworkCloudConsole`
   - Added parameter `-VirtualMachineInputObject`
* Modified cmdlet `Get-AzNetworkCloudKubernetesClusterFeature`
   - Added parameter `-KubernetesClusterInputObject`
* Modified cmdlet `Get-AzNetworkCloudMetricsConfiguration`
   - Added parameter `-ClusterInputObject`
* Modified cmdlet `Invoke-AzNetworkCloudBareMetalMachineCordon`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-Evacuate` from `BareMetalMachineEvacuate` to `String`
* Modified cmdlet `Invoke-AzNetworkCloudBareMetalMachineDataExtract`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Invoke-AzNetworkCloudBareMetalMachineReplace`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Invoke-AzNetworkCloudBareMetalMachineRunCommand`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Invoke-AzNetworkCloudBareMetalMachineRunReadCommand`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Invoke-AzNetworkCloudClusterContinueVersionUpdate`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-MachineGroupTargetingMode` from `ClusterContinueUpdateVersionMachineGroupTargetingMode` to `String`
* Modified cmdlet `Invoke-AzNetworkCloudClusterVersionUpdate`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Invoke-AzNetworkCloudScanClusterRuntime`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-ScanActivity` from `ClusterScanRuntimeParametersScanActivity` to `String`
* Modified cmdlet `New-AzNetworkCloudAgentPool`
   - Added parameters `-KubernetesClusterInputObject`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-Mode` from `AgentPoolMode` to `String`
   - Changed the type of parameter `-AgentOptionHugepagesSize` from `HugepagesSize` to `String`
* Modified cmdlet `New-AzNetworkCloudBareMetalMachineKeySet`
   - Added parameters `-ClusterInputObject`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-PrivilegeLevel` from `BareMetalMachineKeySetPrivilegeLevel` to `String`
* Modified cmdlet `New-AzNetworkCloudBgpAdvertisementObject`
   - Changed the type of parameter `-AdvertiseToFabric` from `AdvertiseToFabric` to `String`
* Modified cmdlet `New-AzNetworkCloudBgpServiceLoadBalancerConfigurationObject`
   - Changed the type of parameter `-FabricPeeringEnabled` from `FabricPeeringEnabled` to `String`
* Modified cmdlet `New-AzNetworkCloudBmcKeySet`
   - Added parameters `-ClusterInputObject`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-PrivilegeLevel` from `BmcKeySetPrivilegeLevel` to `String`
* Modified cmdlet `New-AzNetworkCloudCluster`
   - Removed parameters `-IdentityType`, `-IdentityUserAssignedIdentity`
   - Added parameters `-EnableSystemAssignedIdentity`, `-UserAssignedIdentity`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-ClusterType` from `ClusterType` to `String`
   - Changed the type of parameter `-AnalyticsOutputSettingsAssociatedIdentityType` from `ManagedServiceIdentitySelectorType` to `String`
   - Changed the type of parameter `-AssociatedIdentityType` from `ManagedServiceIdentitySelectorType` to `String`
   - Changed the type of parameter `-ComputeDeploymentThresholdGrouping` from `ValidationThresholdGrouping` to `String`
   - Changed the type of parameter `-ComputeDeploymentThresholdType` from `ValidationThresholdType` to `String`
   - Changed the type of parameter `-RuntimeProtectionConfigurationEnforcementLevel` from `RuntimeProtectionEnforcementLevel` to `String`
   - Changed the type of parameter `-SecretArchiveSettingsAssociatedIdentityType` from `ManagedServiceIdentitySelectorType` to `String`
   - Changed the type of parameter `-SecretArchiveUseKeyVault` from `ClusterSecretArchiveEnabled` to `String`
   - Changed the type of parameter `-UpdateStrategyThresholdType` from `ValidationThresholdType` to `String`
   - Changed the type of parameter `-UpdateStrategyType` from `ClusterUpdateStrategyType` to `String`
   - Changed the type of parameter `-VulnerabilityScanningSettingContainerScan` from `VulnerabilityScanningSettingsContainerScan` to `String`
* Modified cmdlet `New-AzNetworkCloudClusterManager`
   - Removed parameters `-IdentityType`, `-IdentityUserAssignedIdentity`
   - Added parameters `-EnableSystemAssignedIdentity`, `-UserAssignedIdentity`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzNetworkCloudConsole`
   - Added parameters `-VirtualMachineInputObject`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-Enabled` from `ConsoleEnabled` to `String`
* Modified cmdlet `New-AzNetworkCloudInitialAgentPoolConfigurationObject`
   - Changed the type of parameter `-Mode` from `AgentPoolMode` to `String`
   - Changed the type of parameter `-AgentOptionHugepagesSize` from `HugepagesSize` to `String`
* Modified cmdlet `New-AzNetworkCloudIpAddressPoolObject`
   - Changed the type of parameter `-AutoAssign` from `BfdEnabled` to `String`
   - Changed the type of parameter `-OnlyUseHostIP` from `BfdEnabled` to `String`
* Modified cmdlet `New-AzNetworkCloudKubernetesCluster`
   - Removed parameter `-KubernetesClusterName`
   - Added parameters `-Name`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-BgpServiceLoadBalancerConfigurationFabricPeeringEnabled` from `FabricPeeringEnabled` to `String`
* Modified cmdlet `New-AzNetworkCloudKubernetesClusterFeature`
   - Added parameters `-KubernetesClusterInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzNetworkCloudL2Network`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-HybridAksPluginType` from `HybridAksPluginType` to `String`
* Modified cmdlet `New-AzNetworkCloudL3Network`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-HybridAksIpamEnabled` from `HybridAksIpamEnabled` to `String`
   - Changed the type of parameter `-HybridAksPluginType` from `HybridAksPluginType` to `String`
   - Changed the type of parameter `-IPAllocationType` from `IPAllocationType` to `String`
* Modified cmdlet `New-AzNetworkCloudL3NetworkAttachmentConfigurationObject`
   - Changed the type of parameter `-IpamEnabled` from `L3NetworkConfigurationIpamEnabled` to `String`
   - Changed the type of parameter `-PluginType` from `KubernetesPluginType` to `String`
* Modified cmdlet `New-AzNetworkCloudMetricsConfiguration`
   - Removed parameter `-MetricsConfigurationName`
   - Added parameters `-Name`, `-ClusterInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `New-AzNetworkCloudNetworkAttachmentObject`
   - Changed the type of parameter `-IPAllocationMethod` from `VirtualMachineIPAllocationMethod` to `String`
   - Changed the type of parameter `-DefaultGateway` from `DefaultGateway` to `String`
* Modified cmdlet `New-AzNetworkCloudServiceLoadBalancerBgpPeerObject`
   - Changed the type of parameter `-BfdEnabled` from `BfdEnabled` to `String`
   - Changed the type of parameter `-BgpMultiHop` from `BgpMultiHop` to `String`
* Modified cmdlet `New-AzNetworkCloudServicesNetwork`
   - Removed parameter `-CloudServicesNetworkName`
   - Added parameters `-Name`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-EnableDefaultEgressEndpoint` from `CloudServicesNetworkEnableDefaultEgressEndpoints` to `String`
* Modified cmdlet `New-AzNetworkCloudTrunkedNetwork`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-HybridAksPluginType` from `HybridAksPluginType` to `String`
* Modified cmdlet `New-AzNetworkCloudVirtualMachine`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-CloudServiceNetworkAttachmentIPAllocationMethod` from `VirtualMachineIPAllocationMethod` to `String`
   - Changed the type of parameter `-BootMethod` from `VirtualMachineBootMethod` to `String`
   - Changed the type of parameter `-CloudServiceNetworkAttachmentDefaultGateway` from `DefaultGateway` to `String`
   - Changed the type of parameter `-IsolateEmulatorThread` from `VirtualMachineIsolateEmulatorThread` to `String`
   - Changed the type of parameter `-OSDiskCreateOption` from `OSDiskCreateOption` to `String`
   - Changed the type of parameter `-OSDiskDeleteOption` from `OSDiskDeleteOption` to `String`
   - Changed the type of parameter `-VMDeviceModel` from `VirtualMachineDeviceModelType` to `String`
   - Changed the type of parameter `-VirtioInterface` from `VirtualMachineVirtioInterfaceType` to `String`
* Modified cmdlet `New-AzNetworkCloudVirtualMachinePlacementHintObject`
   - Changed the type of parameter `-HintType` from `VirtualMachinePlacementHintType` to `String`
   - Changed the type of parameter `-SchedulingExecution` from `VirtualMachineSchedulingExecution` to `String`
   - Changed the type of parameter `-Scope` from `VirtualMachinePlacementHintPodAffinityScope` to `String`
* Modified cmdlet `New-AzNetworkCloudVolume`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Remove-AzNetworkCloudAgentPool`
   - Added parameter `-KubernetesClusterInputObject`
* Modified cmdlet `Remove-AzNetworkCloudBareMetalMachineKeySet`
   - Added parameter `-ClusterInputObject`
* Modified cmdlet `Remove-AzNetworkCloudBmcKeySet`
   - Added parameter `-ClusterInputObject`
* Modified cmdlet `Remove-AzNetworkCloudConsole`
   - Added parameter `-VirtualMachineInputObject`
* Modified cmdlet `Remove-AzNetworkCloudKubernetesClusterFeature`
   - Added parameter `-KubernetesClusterInputObject`
* Modified cmdlet `Remove-AzNetworkCloudMetricsConfiguration`
   - Added parameter `-ClusterInputObject`
* Modified cmdlet `Restart-AzNetworkCloudKubernetesClusterNode`
   - Added parameters `-KubernetesClusterRestartNodeParameter`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Stop-AzNetworkCloudBareMetalMachine`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-SkipShutdown` from `BareMetalMachineSkipShutdown` to `String`
* Modified cmdlet `Stop-AzNetworkCloudVirtualMachine`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-SkipShutdown` from `SkipShutdown` to `String`
* Modified cmdlet `Update-AzNetworkCloudAgentPool`
   - Added parameters `-KubernetesClusterInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzNetworkCloudBareMetalMachine`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzNetworkCloudBareMetalMachineKeySet`
   - Added parameters `-ClusterInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzNetworkCloudBmcKeySet`
   - Added parameters `-ClusterInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzNetworkCloudCluster`
   - Removed parameters `-IdentityType`, `-IdentityUserAssignedIdentity`
   - Added parameters `-EnableSystemAssignedIdentity`, `-UserAssignedIdentity`
   - Changed the type of parameter `-AnalyticsOutputSettingsAssociatedIdentityType` from `ManagedServiceIdentitySelectorType` to `String`
   - Changed the type of parameter `-AssociatedIdentityType` from `ManagedServiceIdentitySelectorType` to `String`
   - Changed the type of parameter `-ComputeDeploymentThresholdGrouping` from `ValidationThresholdGrouping` to `String`
   - Changed the type of parameter `-ComputeDeploymentThresholdType` from `ValidationThresholdType` to `String`
   - Changed the type of parameter `-RuntimeProtectionConfigurationEnforcementLevel` from `RuntimeProtectionEnforcementLevel` to `String`
   - Changed the type of parameter `-SecretArchiveSettingsAssociatedIdentityType` from `ManagedServiceIdentitySelectorType` to `String`
   - Changed the type of parameter `-SecretArchiveUseKeyVault` from `ClusterSecretArchiveEnabled` to `String`
   - Changed the type of parameter `-UpdateStrategyThresholdType` from `ValidationThresholdType` to `String`
   - Changed the type of parameter `-UpdateStrategyType` from `ClusterUpdateStrategyType` to `String`
   - Changed the type of parameter `-VulnerabilityScanningSettingContainerScan` from `VulnerabilityScanningSettingsContainerScan` to `String`
* Modified cmdlet `Update-AzNetworkCloudClusterManager`
   - Removed parameters `-IdentityType`, `-IdentityUserAssignedIdentity`
   - Added parameters `-EnableSystemAssignedIdentity`, `-UserAssignedIdentity`, `-AsJob`, `-NoWait`
* Modified cmdlet `Update-AzNetworkCloudConsole`
   - Added parameters `-VirtualMachineInputObject`, `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-Enabled` from `ConsoleEnabled` to `String`
* Modified cmdlet `Update-AzNetworkCloudKubernetesCluster`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzNetworkCloudKubernetesClusterFeature`
   - Added parameters `-KubernetesClusterInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzNetworkCloudL2Network`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzNetworkCloudL3Network`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzNetworkCloudMetricsConfiguration`
   - Added parameters `-ClusterInputObject`, `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzNetworkCloudRack`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzNetworkCloudServicesNetwork`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-EnableDefaultEgressEndpoint` from `CloudServicesNetworkEnableDefaultEgressEndpoints` to `String`
* Modified cmdlet `Update-AzNetworkCloudStorageAppliance`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzNetworkCloudTrunkedNetwork`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzNetworkCloudVirtualMachine`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzNetworkCloudVolume`
   - Added parameters `-JsonFilePath`, `-JsonString`
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
#### Az.Resources 9.0.0 
* Modified cmdlet `Get-AzRoleEligibleChildResource`
   - Removed parameter `-InputObject`
* Modified cmdlet `New-AzRoleAssignmentScheduleRequest`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-ExpirationType` from `Type` to `String`
   - Changed the type of parameter `-RequestType` from `RequestType` to `String`
* Modified cmdlet `New-AzRoleEligibilityScheduleRequest`
   - Added parameters `-JsonFilePath`, `-JsonString`
   - Changed the type of parameter `-ExpirationType` from `Type` to `String`
   - Changed the type of parameter `-RequestType` from `RequestType` to `String`
* Modified cmdlet `New-AzRoleManagementPolicyAssignment`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Modified cmdlet `Update-AzRoleManagementPolicy`
   - Added parameters `-JsonFilePath`, `-JsonString`
* Added cmdlet `Update-AzRoleAssignmentScheduleRequest`, `Update-AzRoleEligibilityScheduleRequest`, `Update-AzRoleManagementPolicyAssignment`
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



