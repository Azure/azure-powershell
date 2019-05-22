## Generated

### Existing Cmdlets

#### App Service Plan

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzAppServicePlan` | No | - See if we want to add `-Location` (used only for filtering) |
| `Get-AzAppServicePlanMetric` | No - `Get-AzAppServicePlanMetrics` | - Change `-Detail` to a `SwitchParameter` called `-IncludeInstanceDetails`<br>- Add variant that introduces `-AppServicePlan` parameter<br>- Add variants that add `-Metric`, `-StartTime`, `-EndTime` and `-Granularity` parameters and use the `-Filter` parameter |
| `New-AzAppServicePlan` | No | - `-Tier` can be replaced by `-SkuTier`<br>- `-Tier` and `-WorkerSize` were used to get value for `-SkuName` parameter<br>- `-NumberOfWorkers` can be replaced by `-SkuSize`<br>- `-AseName` and `-AseResourceGroupName` can be replaced by `-HostingEnvironmentProfileId` |
| `Remove-AzAppServicePlan` | No | - Do we need missing `-Force` and `-AsJob` parameters? |
| `Set-AzAppServicePlan` | No | - Ignore existing `-AdminSiteName` parameter since it's not even used in cmdlet<br>- `-Tier` can be replaced by `-SkuTier`<br>- `-Tier` and `-WorkerSize` were used to get value for `-SkuName` parameter<br>- `-NumberOfWorkers` can be replaced by `-SkuSize` |

#### Certificate

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppCertificate` | No | - See if we want to add `-Thumbprint` (used only for filtering) |

#### Web App

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Backup-AzWebApp` | No - `New-AzWebAppBackup` | - Look at using `Backup-AzWebAppSlot` as a variant to support `-Slot` parameter |
| `Get-AzDeletedWebApp` | No | - See if we want to add `-ResourceGroupName`, `-Name` and `-Slot` (used only for filtering) |
| `Get-AzWebApp` | No | - See if we want to add `-Location` (used only for filtering)<br>- Add variant that uses `-AppServicePlan` to make call to `Get-AzAppServicePlanWebApp` |
| `Get-AzWebAppMetric` | No - `Get-AzWebAppMetrics` | - Change `-Detail` to a `SwitchParameter` called `-IncludeInstanceDetails`<br>- Add variant that introduces `-WebApp`<br>- Add variants that add `-Metric`, `-StartTime`, `-EndTime` and `-Granularity` parameters and use the `-Filter` parameter |
| `Get-AzWebAppPublishingCredential` | No - `Get-AzWebAppContainerContinuousDeploymentUrl` |  |
| `Get-AzWebAppPublishingCredentialSlot` | No - `Get-AzWebAppContainerContinuousDeploymentUrl` |  |
| `Get-AzWebAppPublishingProfile` | No - `Get-AzWebAppPublishingProfile` and `Get-AzWebAppSlotPublishingProfile` | - Change `-IncludeDisasterRecoveryEndpoint` to a `SwitchParameter`<br>- Add variant that introduces `-WebApp` |
| `New-AzWebApp` | No | - Needs investigation |
| `New-AzWebAppPublishingProfile` | No - `Reset-AzWebAppPublishingProfile` |  |
| `Remove-AzWebApp` | No | - Do we need missing `-Force` and `-AsJob` parameters? |
| `Restart-AzWebApp` | No |  |
| `Restore-AzDeletedWebApp` | No | - Look at using `Restore-AzDeletedWebAppSlot` as a variant to support `-Slot` parameter<br>- See if we need all of the `-Target*` parameters or if we can just use the parameters without "Target"<br>- Use `-RecoveryConfiguration` instead of existing `-RestoreContentOnly` |
| `Restore-AzWebApp` | No - `Restore-AzWebAppBackup` |  |
| `Set-AzWebApp` | No | - Needs investigation |
| `Start-AzWebApp` | No |  |
| `Stop-AzWebApp` | No |  |

#### Web App Backup

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppBackup` | No - `Get-AzWebAppBackupList` |  |
| `Get-AzWebAppBackupConfiguration` | No | - Look at using `Get-AzWebAppBackupConfigurationSlot` as a variant to support `-Slot` parameter |
| `Get-AzWebAppBackupConfigurationSlot` | Yes | - Should we hide this cmdlet and use it as a variant for `Get-AzWebAppBackupConfiguration`? |
| `Get-AzWebAppBackupSlot` | No - `Get-AzWebAppBackupList` |  |
| `Get-AzWebAppBackupStatus` | No - `Get-AzWebAppBackup` |  |
| `Get-AzWebAppBackupStatusSlot` | No - `Get-AzWebAppBackup` |  |
| `Remove-AzWebAppBackup` | No | - Look at using `Remove-AzWebAppBackupSlot` as a variant to support `-Slot` parameter |
| `Remove-AzWebAppBackupSlot` | Yes | - Should we hide this cmdlet and use it as a variant for `Remove-AzWebAppBackup`? |
| `Set-AzWebAppBackupConfiguration` | No - `Edit-AzWebAppBackupConfiguration` |  |
| `Set-AzWebAppBackupConfigurationSlot` | No - `Edit-AzWebAppBackupConfiguration` |  |

#### Web App Slot

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Backup-AzWebAppSlot` | No - `New-AzWebAppBackup` | - Should we hide this cmdlet and use it as a variant for `Backup-AzWebApp`? |
| `Get-AzWebAppSlot` | No |  |
| `Get-AzWebAppSlotConfigurationName` | No - `Get-AzWebAppSlotConfigName` | - Add variant that introduces `-WebApp` |
| `Get-AzWebAppSlotMetric` | No - `Get-AzWebAppSlotMetrics` | - Change `-Detail` to a `SwitchParameter` called `-IncludeInstanceDetails`<br>- Add variant that introduces `-WebApp`<br>- Add variants that add `-Metric`, `-StartTime`, `-EndTime` and `-Granularity` parameters and use the `-Filter` parameter |
| `New-AzWebAppSlot` | No | - Needs investigation |
| `New-AzWebAppSlotPublishingPassword` | No - `Reset-AzWebAppSlotPublishingProfile` |  |
| `Remove-AzWebAppSlot` | No | - Do we need missing `-Force` and `-AsJob` parameters? |
| `Restart-AzWebAppSlot` | No |  |
| `Restore-AzDeletedWebAppSlot` | No - `Restore-AzDeletedWebApp` | - Should we hide this cmdlet and use it as a variant for `Restore-AzDeletedWebApp`? |
| `Restore-AzWebAppSlot` | No - `Restore-AzWebAppBackup` |  |
| `Set-AzWebAppSlot` | No | - Needs investigation  |
| `Set-AzWebAppSlotConfigurationName` | No - `Set-AzWebAppSlotConfigName` |  |
| `Start-AzWebAppSlot` | No |  |
| `Stop-AzWebAppSlot` | No |  |
| `Switch-AzWebAppSlot` | No | - Investigate what to do with `-SwapWithPreviewAction` parameter |

#### Web App Snapshot

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppSnapshot` | No | - Look at using `Get-AzWebAppSnapshotSlot` as a variant to support `-Slot` parameter<br>- Add variant that introduces `-WebApp` |
| `Get-AzWebAppSnapshotSlot` | Yes | - Should we hide this cmdlet and use it as a variant for `Get-AzWebAppSnapshot`? |
| `Restore-AzWebAppSnapshot` | No | - Look at using `Restore-AzWebAppSnapshotSlot` as a variant to support `-Slot` parameter<br>- Do we need missing `-Force` parameter? |
| `Restore-AzWebAppSnapshotSlot` | Yes | - Should we hide this cmdlet and use it as a variant for `Restore-AzWebAppSnapshot`? |

### New Cmdlets

#### App Service Certificate

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzAppServiceCertificateOrder` | Yes |  |
| `Get-AzAppServiceCertificateOrderCertificate` | Yes |  |
| `Get-AzAppServiceCertificateOrderCertificateAction` | Yes |  |
| `Get-AzAppServiceCertificateOrderCertificateEmailHistory` | Yes |  |
| `Get-AzAppServiceCertificateOrderSiteSeal` | Yes |  |
| `Invoke-AzReissueAppServiceCertificateOrder` | Yes |  |
| `Invoke-AzRenewAppServiceCertificateOrder` | Yes |  |
| `Invoke-AzResendAppServiceCertificateOrderEmail` | Yes |  |
| `New-AzAppServiceCertificateOrder` | Yes |  |
| `New-AzAppServiceCertificateOrderCertificate` | Yes |  |
| `Remove-AzAppServiceCertificateOrder` | Yes |  |
| `Remove-AzAppServiceCertificateOrderCertificate` | Yes |  |
| `Request-AzAppServiceCertificateOrder` | Yes |  |
| `Set-AzAppServiceCertificateOrder` | Yes |  |
| `Set-AzAppServiceCertificateOrderCertificate` | Yes |  |
| `Test-AzAppServiceCertificateOrderDomainOwnership` | Yes |  |
| `Test-AzAppServiceCertificateOrderPurchaseInformation` | Yes |  |
| `Update-AzAppServiceCertificateOrder` | Yes |  |
| `Update-AzAppServiceCertificateOrderCertificate` | Yes |  |

#### App Service Environment

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzAppServiceEnvironment` | Yes |  |
| `Get-AzAppServiceEnvironmentAppServicePlan` | Yes |  |
| `Get-AzAppServiceEnvironmentCapacity` | Yes |  |
| `Get-AzAppServiceEnvironmentDiagnostic` | Yes |  |
| `Get-AzAppServiceEnvironmentDiagnosticItem` | Yes |  |
| `Get-AzAppServiceEnvironmentInboundNetworkDependencyEndpoint` | Yes |  |
| `Get-AzAppServiceEnvironmentMetric` | Yes |  |
| `Get-AzAppServiceEnvironmentMetricDefinition` | Yes |  |
| `Get-AzAppServiceEnvironmentMultiRoleMetric` | Yes |  |
| `Get-AzAppServiceEnvironmentMultiRoleMetricDefinition` | Yes |  |
| `Get-AzAppServiceEnvironmentMultiRolePool` | Yes |  |
| `Get-AzAppServiceEnvironmentMultiRolePoolInstanceMetric` | Yes |  |
| `Get-AzAppServiceEnvironmentMultiRolePoolInstanceMetricDefinition` | Yes |  |
| `Get-AzAppServiceEnvironmentMultiRolePoolSku` | Yes |  |
| `Get-AzAppServiceEnvironmentMultiRoleUsage` | Yes |  |
| `Get-AzAppServiceEnvironmentOperation` | Yes |  |
| `Get-AzAppServiceEnvironmentOutboundNetworkDependencyEndpoint` | Yes |  |
| `Get-AzAppServiceEnvironmentUsage` | Yes |  |
| `Get-AzAppServiceEnvironmentVip` | Yes |  |
| `Get-AzAppServiceEnvironmentWebApp` | Yes |  |
| `Get-AzAppServiceEnvironmentWebWorkerMetric` | Yes |  |
| `Get-AzAppServiceEnvironmentWebWorkerMetricDefinition` | Yes |  |
| `Get-AzAppServiceEnvironmentWebWorkerUsage` | Yes |  |
| `Get-AzAppServiceEnvironmentWorkerPool` | Yes |  |
| `Get-AzAppServiceEnvironmentWorkerPoolInstanceMetric` | Yes |  |
| `Get-AzAppServiceEnvironmentWorkerPoolInstanceMetricDefinition` | Yes |  |
| `Get-AzAppServiceEnvironmentWorkerPoolSku` | Yes |  |
| `New-AzAppServiceEnvironment` | Yes |  |
| `New-AzAppServiceEnvironmentMultiRolePool` | Yes |  |
| `New-AzAppServiceEnvironmentWorkerPool` | Yes |  |
| `Remove-AzAppServiceEnvironment` | Yes |  |
| `Rename-AzAppServiceEnvironmentVnet` | Yes |  |
| `Restart-AzAppServiceEnvironment` | Yes |  |
| `Resume-AzAppServiceEnvironment` | Yes |  |
| `Set-AzAppServiceEnvironment` | Yes |  |
| `Set-AzAppServiceEnvironmentMultiRolePool` | Yes |  |
| `Set-AzAppServiceEnvironmentWorkerPool` | Yes |  |
| `Suspend-AzAppServiceEnvironment` | Yes |  |
| `Update-AzAppServiceEnvironment` | Yes |  |
| `Update-AzAppServiceEnvironmentMultiRolePool` | Yes |  |
| `Update-AzAppServiceEnvironmentWorkerPool` | Yes |  |

#### App Service Plan

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzAppServicePlanCapability` | Yes |  |
| `Get-AzAppServicePlanHybridConnection` | Yes |  |
| `Get-AzAppServicePlanHybridConnectionKey` | Yes |  |
| `Get-AzAppServicePlanHybridConnectionPlanLimit` | Yes |  |
| `Get-AzAppServicePlanMetricDefintion` | Yes |  |
| `Get-AzAppServicePlanRoute` | Yes |  |
| `Get-AzAppServicePlanServerFarmSku` | Yes |  |
| `Get-AzAppServicePlanUsage` | Yes |  |
| `Get-AzAppServicePlanVnet` | Yes |  |
| `Get-AzAppServicePlanVnetFromServerFarm` | Yes |  |
| `Get-AzAppServicePlanVnetGateway` | Yes |  |
| `Get-AzAppServicePlanWebApp` | Yes |  |
| `New-AzAppServicePlanVnetRoute` | Yes |  |
| `Remove-AzAppServicePlanHybridConnection` | Yes |  |
| `Remove-AzAppServicePlanVnetRoute` | Yes |  |
| `Restart-AzAppServicePlanWebApp` | Yes |  |
| `Restart-AzAppServicePlanWorker` | Yes |  |

#### Connection

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Confirm-AzWebSiteConnectionConsentCode` | Yes |  |
| `Get-AzWebSiteConnection` | Yes |  |
| `Get-AzWebSiteConnectionConsentLink` | Yes |  |
| `Get-AzWebSiteConnectionKey` | Yes |  |
| `New-AzWebSiteConnection` | Yes |  |
| `Remove-AzWebSiteConnection` | Yes |  |
| `Set-AzWebSiteConnection` | Yes |  |

#### Diagnostic

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebSiteDiagnosticHostingEnvironmentDetectorResponse` | Yes |  |
| `Get-AzDiagnosticSiteDiagnosticCategory` | Yes |  |
| `Get-AzDiagnosticSiteDiagnosticCategorySlot` | Yes |  |
| `Get-AzWebSiteDiagnosticSiteAnalysis` | Yes |  |
| `Get-AzWebSiteDiagnosticSiteAnalysisSlot` | Yes |  |
| `Get-AzWebSiteDiagnosticSiteDetector` | Yes |  |
| `Get-AzWebSiteDiagnosticSiteDetectorResponse` | Yes |  |
| `Get-AzWebSiteDiagnosticSiteDetectorResponseSlot` | Yes |  |
| `Get-AzWebSiteDiagnosticSiteDetectorSlot` | Yes |  |
| `Invoke-AzWebSiteExecuteDiagnosticSiteAnalysis` | Yes |  |
| `Invoke-AzWebSiteExecuteDiagnosticSiteAnalysisSlot` | Yes |  |
| `Invoke-AzWebSiteExecuteDiagnosticSiteDetector` | Yes |  |
| `Invoke-AzWebSiteExecuteDiagnosticSiteDetectorSlot` | Yes |  |

#### Domain

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebSiteDomain` | Yes |  |
| `Get-AzWebSiteDomainControlCenterSsoRequest` | Yes |  |
| `Get-AzWebSiteDomainOperation` | Yes |  |
| `Get-AzWebSiteDomainRecommendation` | Yes |  |
| `Get-AzWebSiteDomainRegistrationProviderOperation` | Yes |  |
| `New-AzWebSiteDomain` | Yes |  |
| `Remove-AzWebSiteDomain` | Yes |  |
| `Set-AzWebSiteDomain` | Yes |  |
| `Test-AzWebSiteDomainAvailability` | Yes |  |
| `Update-AzWebSiteDomain` | Yes |  |

#### Domain Ownership

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppDomainOwnershipIdentifier` | Yes |  |
| `Get-AzWebAppDomainOwnershipIdentifierSlot` | Yes |  |
| `Get-AzWebSiteDomainOwnershipIdentifier` | Yes |  |
| `New-AzWebAppDomainOwnershipIdentifier` | Yes |  |
| `New-AzWebAppDomainOwnershipIdentifierSlot` | Yes |  |
| `New-AzWebSiteDomainOwnershipIdentifier` | Yes |  |
| `Remove-AzWebAppDomainOwnershipIdentifier` | Yes |  |
| `Remove-AzWebAppDomainOwnershipIdentifierSlot` | Yes |  |
| `Remove-AzWebSiteDomainOwnershipIdentifier` | Yes |  |
| `Set-AzWebAppDomainOwnershipIdentifier` | Yes |  |
| `Set-AzWebAppDomainOwnershipIdentifierSlot` | Yes |  |
| `Set-AzWebSiteDomainOwnershipIdentifier` | Yes |  |
| `Update-AzWebAppDomainOwnershipIdentifier` | Yes |  |
| `Update-AzWebAppDomainOwnershipIdentifierSlot` | Yes |  |
| `Update-AzWebSiteDomainOwnershipIdentifier` | Yes |  |

#### Recommendations

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Disable-AzWebSiteRecommendation` | Yes |  |
| `Get-AzWebSiteDomainRecommendation` | Yes |  |
| `Get-AzWebSiteRecommendation` | Yes |  |
| `Get-AzWebSiteRecommendationHistory` | Yes |  |
| `Get-AzWebSiteRecommendationRecommendedRule` | Yes |  |
| `Get-AzWebSiteRecommendationRuleDetail ` | Yes |  |
| `Reset-AzWebSiteRecommendationFilter` | Yes |  |
| `Set-AzAppServicePlanVnetGateway` | Yes |  |
| `Set-AzAppServicePlanVnetRoute` | Yes |  |
| `Update-AzAppServicePlan` | Yes |  |
| `Update-AzAppServicePlanVnetRoute` | Yes |  |

#### Web App Application Setting

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppApplicationSetting` | Yes |  |
| `Get-AzWebAppApplicationSettingSlot` | Yes |  |
| `Set-AzWebAppApplicationSetting` | Yes |  |
| `Set-AzWebAppApplicationSettingSlot` | Yes |  |

#### Web App Auth Setting

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppAuthSetting` | Yes |  |
| `Get-AzWebAppAuthSettingSlot` | Yes |  |
| `Set-AzWebAppAuthSetting` | Yes |  |
| `Set-AzWebAppAuthSettingSlot` | Yes |  |

#### Web App Azure Storage Account

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppAzureStorageAccount` | Yes |  |
| `Get-AzWebAppAzureStorageAccountSlot` | Yes |  |
| `Set-AzWebAppAzureStorageAccount` | Yes |  |
| `Set-AzWebAppAzureStorageAccountSlot` | Yes |  |

#### Web App Backup

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Find-AzWebAppBackup` | Yes |  |
| `Find-AzWebAppBackupSlot` | Yes |  |
| `Get-AzWebAppBackupConfigurationSlot` | Yes |  |
| `Get-AzWebAppBackupSlot` | Yes |  |
| `Get-AzWebAppBackupStatus` | Yes |  |
| `Get-AzWebAppBackupStatusSecret` | Yes |  |
| `Get-AzWebAppBackupStatusSecretSlot` | Yes |  |
| `Get-AzWebAppBackupStatusSlot` | Yes |  |
| `Remove-AzWebAppBackupConfiguration` | Yes |  |
| `Remove-AzWebAppBackupConfigurationSlot` | Yes |  |
| `Remove-AzWebAppBackupSlot` | Yes |  |
| `Restore-AzWebAppFromBackupBlob` | Yes |  |
| `Restore-AzWebAppFromBackupBlobSlot` | Yes |  |
| `Set-AzWebAppBackupConfiguration` | Yes |  |
| `Set-AzWebAppBackupConfigurationSlot` | Yes |  |

#### Web App Certificate

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppCertificateCsr` | Yes |  |
| `Get-AzWebAppCertificateRegistrationProviderOperation` | Yes |  |
| `New-AzWebAppCertificate` | Yes |  |
| `New-AzWebAppCertificateCsr` | Yes |  |
| `Remove-AzWebAppCertificate` | Yes |  |
| `Remove-AzWebAppCertificateCsr` | Yes |  |
| `Set-AzWebAppCertificate` | Yes |  |
| `Set-AzWebAppCertificateCsr` | Yes |  |
| `Update-AzWebAppCertificate` | Yes |  |
| `Update-AzWebAppCertificateCsr` | Yes |  |

#### Web App Configuration

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Add-AzWebAppSlotConfigurationSlot` | Yes |  |
| `Get-AzWebAppConfiguration` | Yes |  |
| `Get-AzWebAppConfigurationSlot` | Yes |  |
| `Get-AzWebAppConfigurationSnapshot` | Yes |  |
| `Get-AzWebAppConfigurationSnapshotInfo` | Yes |  |
| `Get-AzWebAppConfigurationSnapshotInfoSlot` | Yes |  |
| `Get-AzWebAppConfigurationSnapshotSlot` | Yes |  |
| `New-AzWebAppConfiguration` | Yes |  |
| `New-AzWebAppConfigurationSlot` | Yes |  |
| `Reset-AzWebAppSlotConfigurationSlot` | Yes |  |
| `Restore-AzWebAppSiteConfigurationSnapshot` | Yes |  |
| `Restore-AzWebAppSiteConfigurationSnapshotSlot` | Yes |  |
| `Set-AzWebAppConfiguration` | Yes |  |
| `Set-AzWebAppConfigurationSlot` | Yes |  |
| `Update-AzWebAppConfiguration` | Yes |  |
| `Update-AzWebAppConfigurationSlot` | Yes |  |

#### Web App Connection String

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppConnectionString` | Yes |  |
| `Get-AzWebAppConnectionStringSlot` | Yes |  |
| `Set-AzWebAppConnectionString` | Yes |  |
| `Set-AzWebAppConnectionStringSlot` | Yes |  |

#### Web App Container Log

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppContainerLogZip` | Yes |  |
| `Get-AzWebAppContainerLogZipSlot` | Yes |  |
| `Get-AzWebAppWebSiteContainerLog` | Yes |  |
| `Get-AzWebAppWebSiteContainerLogSlot` | Yes |  |

#### Web App Continuous Web Job

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppContinuouWebJob` | Yes |  |
| `Get-AzWebAppContinuouWebJobSlot` | Yes |  |
| `Remove-AzWebAppContinuouWebJob` | Yes |  |
| `Remove-AzWebAppContinuouWebJobSlot` | Yes |  |
| `Start-AzWebAppContinuouWebJob` | Yes |  |
| `Start-AzWebAppContinuouWebJobSlot` | Yes |  |
| `Stop-AzWebAppContinuouWebJob` | Yes |  |
| `Stop-AzWebAppContinuouWebJobSlot` | Yes |  |

#### Web App Deployment

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppDeployment` | Yes |  |
| `Get-AzWebAppDeploymentLog` | Yes |  |
| `Get-AzWebAppDeploymentLogSlot` | Yes |  |
| `Get-AzWebAppDeploymentSlot` | Yes |  |
| `New-AzWebAppDeployment` | Yes |  |
| `New-AzWebAppDeploymentSlot` | Yes |  |
| `Remove-AzWebAppDeployment` | Yes |  |
| `Remove-AzWebAppDeploymentSlot` | Yes |  |

#### Web App Diagnostic Log

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppDiagnosticLogConfiguration` | Yes |  |
| `Get-AzWebAppDiagnosticLogConfigurationSlot` | Yes |  |
| `Set-AzWebAppDiagnosticLogConfig` | Yes |  |
| `Set-AzWebAppDiagnosticLogConfigSlot` | Yes |  |

#### Web App Function

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppFunction` | Yes |  |
| `Get-AzWebAppFunctionAdminToken` | Yes |  |
| `Get-AzWebAppFunctionAdminTokenSlot` | Yes |  |
| `Get-AzWebAppFunctionSecret` | Yes |  |
| `Get-AzWebAppFunctionSecretSlot` | Yes |  |
| `New-AzWebAppFunction` | Yes |  |
| `Remove-AzWebAppFunction` | Yes |  |
| `Sync-AzWebAppFunctionTrigger` | Yes |  |
| `Sync-AzWebAppFunctionTriggerSlot` | Yes |  |

#### Web App Host Name Binding

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppHostNameBinding` | Yes |  |
| `Get-AzWebAppHostNameBindingSlot` | Yes |  |
| `New-AzWebAppHostNameBinding` | Yes |  |
| `New-AzWebAppHostNameBindingSlot` | Yes |  |
| `Remove-AzWebAppHostNameBinding` | Yes |  |
| `Remove-AzWebAppHostNameBindingSlot` | Yes |  |
| `Set-AzWebAppHostNameBinding` | Yes |  |
| `Set-AzWebAppHostNameBindingSlot` | Yes |  |

#### Web App Hybrid Connection

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppHybridConnection` | Yes |  |
| `Get-AzWebAppHybridConnectionKey` | Yes |  |
| `Get-AzWebAppHybridConnectionKeySlot` | Yes |  |
| `Get-AzWebAppHybridConnectionSlot` | Yes |  |
| `New-AzWebAppHybridConnection` | Yes |  |
| `New-AzWebAppHybridConnectionSlot` | Yes |  |
| `Remove-AzWebAppHybridConnection` | Yes |  |
| `Remove-AzWebAppHybridConnectionSlot` | Yes |  |
| `Set-AzWebAppHybridConnection` | Yes |  |
| `Set-AzWebAppHybridConnectionSlot` | Yes |  |
| `Update-AzWebAppHybridConnection` | Yes |  |
| `Update-AzWebAppHybridConnectionSlot` | Yes |  |

#### Web App Instance

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppInstanceFunctionSlot` | Yes |  |
| `Get-AzWebAppInstanceIdentifier` | Yes |  |
| `Get-AzWebAppInstanceIdentifierSlot` | Yes |  |
| `Get-AzWebAppInstanceMSDeployLog` | Yes |  |
| `Get-AzWebAppInstanceMSDeployLogSlot` | Yes |  |
| `Get-AzWebAppInstanceMSDeployStatus` | Yes |  |
| `Get-AzWebAppInstanceMSDeployStatusSlot` | Yes |  |
| `Get-AzWebAppInstanceProcess` | Yes |  |
| `Get-AzWebAppInstanceProcessDump` | Yes |  |
| `Get-AzWebAppInstanceProcessDumpSlot` | Yes |  |
| `Get-AzWebAppInstanceProcessModule` | Yes |  |
| `Get-AzWebAppInstanceProcessModuleSlot` | Yes |  |
| `Get-AzWebAppInstanceProcessSlot` | Yes |  |
| `Get-AzWebAppInstanceProcessThread` | Yes |  |
| `Get-AzWebAppInstanceProcessThreadSlot` | Yes |  |
| `New-AzWebAppInstanceFunctionSlot` | Yes |  |
| `New-AzWebAppInstanceMSDeployOperation` | Yes |  |
| `New-AzWebAppInstanceMSDeployOperationSlot` | Yes |  |
| `Remove-AzWebAppInstanceFunctionSlot` | Yes |  |
| `Remove-AzWebAppInstanceProcess` | Yes |  |
| `Remove-AzWebAppInstanceProcessSlot` | Yes |  |

#### Web App Metadata

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppMetadata` | Yes |  |
| `Get-AzWebAppMetadataSlot` | Yes |  |
| `Set-AzWebAppMetadata` | Yes |  |
| `Set-AzWebAppMetadataSlot` | Yes |  |

#### Web App Metric Definition

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppMetricDefinition` | Yes |  |
| `Get-AzWebAppMetricDefinitionSlot` | Yes |  |

#### Web App MySql

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppMigrateMySqlStatus` | Yes |  |
| `Get-AzWebAppMigrateMySqlStatusSlot` | Yes |  |
| `Move-AzWebAppMySql` | Yes |  |

#### Web App MSDeploy

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppMSDeployLog` | Yes |  |
| `Get-AzWebAppMSDeployLogSlot` | Yes |  |
| `Get-AzWebAppMSDeployStatus` | Yes |  |
| `Get-AzWebAppMSDeployStatusSlot` | Yes |  |
| `New-AzWebAppMSDeployOperation` | Yes |  |
| `New-AzWebAppMSDeployOperationSlot` | Yes |  |

#### Web App Network

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppNetworkFeature` | Yes |  |
| `Get-AzWebAppNetworkFeatureSlot` | Yes |  |
| `Get-AzWebAppNetworkTrace` | Yes |  |
| `Get-AzWebAppNetworkTraceOperation` | Yes |  |
| `Get-AzWebAppNetworkTraceOperationSlot` | Yes |  |
| `Get-AzWebAppNetworkTraceOperationSlotV2` | Yes |  |
| `Get-AzWebAppNetworkTraceOperationV2` | Yes |  |
| `Get-AzWebAppNetworkTraceSlot` | Yes |  |
| `Get-AzWebAppNetworkTraceSlotV2` | Yes |  |
| `Get-AzWebAppNetworkTraceV2` | Yes |  |
| `Start-AzWebAppNetworkTrace` | Yes |  |
| `Start-AzWebAppNetworkTraceSlot` | Yes |  |
| `Start-AzWebAppWebSiteNetworkTrace` | Yes |  |
| `Start-AzWebAppWebSiteNetworkTraceOperation` | Yes |  |
| `Start-AzWebAppWebSiteNetworkTraceOperationSlot` | Yes |  |
| `Start-AzWebAppWebSiteNetworkTraceSlot` | Yes |  |
| `Stop-AzWebAppNetworkTrace` | Yes |  |
| `Stop-AzWebAppNetworkTraceSlot` | Yes |  |
| `Stop-AzWebAppWebSiteNetworkTrace` | Yes |  |
| `Stop-AzWebAppWebSiteNetworkTraceSlot` | Yes |  |

#### Web App Performance Monitor

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppPerfMonCounter` | Yes |  |
| `Get-AzWebAppPerfMonCounterSlot` | Yes |  |

#### Web App Premier Add-On

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Add-AzWebAppPremierAddOn` | Yes |  |
| `Add-AzWebAppPremierAddOnSlot` | Yes |  |
| `Get-AzWebAppPremierAddOn` | Yes |  |
| `Get-AzWebAppPremierAddOnSlot` | Yes |  |
| `Get-AzWebSitePremierAddOnOffer` | Yes |  |
| `Remove-AzWebAppPremierAddOn` | Yes |  |
| `Remove-AzWebAppPremierAddOnSlot` | Yes |  |
| `Update-AzWebAppPremierAddOn` | Yes |  |
| `Update-AzWebAppPremierAddOnSlot` | Yes |  |

#### Web App Private Access

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppPrivateAccess` | Yes |  |
| `Get-AzWebAppPrivateAccessSlot` | Yes |  |
| `Set-AzWebAppPrivateAccessVnet` | Yes |  |
| `Set-AzWebAppPrivateAccessVnetSlot` | Yes |  |

#### Web App Process

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppProcess` | Yes |  |
| `Get-AzWebAppProcessDump` | Yes |  |
| `Get-AzWebAppProcessDumpSlot` | Yes |  |
| `Get-AzWebAppProcessModule` | Yes |  |
| `Get-AzWebAppProcessModuleSlot` | Yes |  |
| `Get-AzWebAppProcessSlot` | Yes |  |
| `Get-AzWebAppProcessThread` | Yes |  |
| `Get-AzWebAppProcessThreadSlot` | Yes |  |
| `Remove-AzWebAppProcess` | Yes |  |
| `Remove-AzWebAppProcessSlot` | Yes |  |

#### Web App Public Certificate

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppPublicCertificate` | Yes |  |
| `Get-AzWebAppPublicCertificateSlot` | Yes |  |
| `New-AzWebAppPublicCertificate` | Yes |  |
| `New-AzWebAppPublicCertificateSlot` | Yes |  |
| `Remove-AzWebAppPublicCertificate` | Yes |  |
| `Remove-AzWebAppPublicCertificateSlot` | Yes |  |
| `Set-AzWebAppPublicCertificate` | Yes |  |
| `Set-AzWebAppPublicCertificateSlot` | Yes |  |

#### Web App Publishing Credential

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppPublishingCredential` | Yes |  |
| `Get-AzWebAppPublishingCredentialSlot` | Yes |  |

#### Web App Relay Service Connection

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppRelayServiceConnection` | Yes |  |
| `Get-AzWebAppRelayServiceConnectionSlot` | Yes |  |
| `New-AzWebAppRelayServiceConnection` | Yes |  |
| `New-AzWebAppRelayServiceConnectionSlot` | Yes |  |
| `Remove-AzWebAppRelayServiceConnection` | Yes |  |
| `Remove-AzWebAppRelayServiceConnectionSlot` | Yes |  |
| `Set-AzWebAppRelayServiceConnection` | Yes |  |
| `Set-AzWebAppRelayServiceConnectionSlot` | Yes |  |
| `Update-AzWebAppRelayServiceConnection` | Yes |  |
| `Update-AzWebAppRelayServiceConnectionSlot` | Yes |  |

#### Web App Repository

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Sync-AzWebAppRepository` | Yes |  |
| `Sync-AzWebAppRepositorySlot` | Yes |  |

#### Web App Site

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppSiteExtension` | Yes |  |
| `Get-AzWebAppSiteExtensionSlot` | Yes |  |
| `Get-AzWebAppSitePhpErrorLogFlag` | Yes |  |
| `Get-AzWebAppSitePhpErrorLogFlagSlot` | Yes |  |
| `Get-AzWebAppSitePushSetting` | Yes |  |
| `Get-AzWebAppSitePushSettingSlot` | Yes |  |
| `Install-AzWebAppSiteExtension` | Yes |  |
| `Install-AzWebAppSiteExtensionSlot` | Yes |  |
| `Remove-AzWebAppSiteExtension` | Yes |  |
| `Remove-AzWebAppSiteExtensionSlot` | Yes |  |
| `Set-AzWebAppSitePushSetting` | Yes |  |
| `Set-AzWebAppSitePushSettingSlot` | Yes |  |

#### Web App Snapshot

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppSnapshotFromDrSecondary` | Yes |  |
| `Get-AzWebAppSnapshotFromDrSecondarySlot` | Yes |  |
| `Get-AzWebAppSnapshotSlot` | Yes |  |
| `Restore-AzWebAppSiteConfigurationSnapshot` | Yes |  |
| `Restore-AzWebAppSiteConfigurationSnapshotSlot` | Yes |  |
| `Restore-AzWebAppSnapshotSlot` | Yes |  |

#### Web App Source Control

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppSourceControl` | Yes |  |
| `Get-AzWebAppSourceControlSlot` | Yes |  |
| `Get-AzWebSiteSourceControl` | Yes |  |
| `New-AzWebAppSourceControl` | Yes |  |
| `New-AzWebAppSourceControlSlot` | Yes |  |
| `Remove-AzWebAppSourceControl` | Yes |  |
| `Remove-AzWebAppSourceControlSlot` | Yes |  |
| `Set-AzWebAppSourceControl` | Yes |  |
| `Set-AzWebAppSourceControlSlot` | Yes |  |
| `Set-AzWebSiteSourceControl` | Yes |  |
| `Update-AzWebAppSourceControl` | Yes |  |
| `Update-AzWebAppSourceControlSlot` | Yes |  |

#### Web App Swift Virtual Network

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppSwiftVirtualNetworkConnection` | Yes |  |
| `Get-AzWebAppSwiftVirtualNetworkConnectionSlot` | Yes |  |
| `New-AzWebAppSwiftVirtualNetworkConnection` | Yes |  |
| `New-AzWebAppSwiftVirtualNetworkConnectionSlot` | Yes |  |
| `Remove-AzWebAppSwiftVirtualNetwork` | Yes |  |
| `Remove-AzWebAppSwiftVirtualNetworkSlot` | Yes |  |
| `Set-AzWebAppSwiftVirtualNetworkConnection` | Yes |  |
| `Set-AzWebAppSwiftVirtualNetworkConnectionSlot` | Yes |  |
| `Update-AzWebAppSwiftVirtualNetworkConnection` | Yes |  |
| `Update-AzWebAppSwiftVirtualNetworkConnectionSlot` | Yes |  |

#### Web App Sync Function

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppSyncFunctionTrigger` | Yes |  |
| `Get-AzWebAppSyncFunctionTriggerSlot` | Yes |  |

#### Web App Triggered Web Job

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppTriggeredWebJob` | Yes |  |
| `Get-AzWebAppTriggeredWebJobHistory` | Yes |  |
| `Get-AzWebAppTriggeredWebJobHistorySlot` | Yes |  |
| `Get-AzWebAppTriggeredWebJobSlot` | Yes |  |
| `Remove-AzWebAppTriggeredWebJob` | Yes |  |
| `Remove-AzWebAppTriggeredWebJobSlot` | Yes |  |
| `Start-AzWebAppTriggeredWebJob` | Yes |  |
| `Start-AzWebAppTriggeredWebJobSlot` | Yes |  |

#### Web App Usage

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppUsage` | Yes |  |
| `Get-AzWebAppUsageSlot` | Yes |  |

#### Web App VNet Connection

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppVnetConnection` | Yes |  |
| `Get-AzWebAppVnetConnectionGateway` | Yes |  |
| `Get-AzWebAppVnetConnectionGatewaySlot` | Yes |  |
| `Get-AzWebAppVnetConnectionSlot` | Yes |  |
| `New-AzWebAppVnetConnection` | Yes |  |
| `New-AzWebAppVnetConnectionGateway` | Yes |  |
| `New-AzWebAppVnetConnectionGatewaySlot` | Yes |  |
| `New-AzWebAppVnetConnectionSlot` | Yes |  |
| `Remove-AzWebAppVnetConnection` | Yes |  |
| `Remove-AzWebAppVnetConnectionSlot` | Yes |  |
| `Set-AzWebAppVnetConnection` | Yes |  |
| `Set-AzWebAppVnetConnectionGateway` | Yes |  |
| `Set-AzWebAppVnetConnectionGatewaySlot` | Yes |  |
| `Set-AzWebAppVnetConnectionSlot` | Yes |  |
| `Update-AzWebAppVnetConnection` | Yes |  |
| `Update-AzWebAppVnetConnectionGateway` | Yes |  |
| `Update-AzWebAppVnetConnectionGatewaySlot` | Yes |  |
| `Update-AzWebAppVnetConnectionSlot` | Yes |  |

#### Web App Web Job

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebAppWebJob` | Yes |  |
| `Get-AzWebAppWebJobSlot` | Yes |  |

#### Website Global

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebSiteGlobalClassicMobileService` | Yes |  |
| `Get-AzWebSiteGlobalManagedHostingEnvironment` | Yes |  |
| `Get-AzWebSiteGlobalSubscriptionPublishingCredential` | Yes |  |
| `Set-AzWebSiteGlobalSubscriptionPublishingCredential` | Yes |  |
| `Test-AzWebSiteGlobalDomainRegistrationDomainPurchaseInformation` | Yes |  |
| `Test-AzWebSiteGlobalHostingEnvironment` | Yes |  |
| `Test-AzWebSiteGlobalHostingEnvironmentNameAvailable` | Yes |  |

#### Website Instance Deployment

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebSiteInstanceDeployment` | Yes |  |
| `Get-AzWebSiteInstanceDeploymentSlot` | Yes |  |
| `New-AzWebSiteInstanceDeployment` | Yes |  |
| `New-AzWebSiteInstanceDeploymentSlot` | Yes |  |
| `Remove-AzWebSiteInstanceDeployment` | Yes |  |
| `Remove-AzWebSiteInstanceDeploymentSlot` | Yes |  |

#### Website Managed Hosting Environment

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironment` | Yes |  |
| `Get-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironmentOperation` | Yes |  |
| `Get-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironmentServerFarm` | Yes |  |
| `Get-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironmentSite` | Yes |  |
| `Get-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironmentVip` | Yes |  |
| `Get-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironmentWebHostingPlan` | Yes |  |
| `New-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironment` | Yes |  |
| `Remove-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironment` | Yes |  |
| `Set-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironment` | Yes |  |

#### Website Operation

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebSiteOperation` | Yes |  |
| `Get-AzWebSiteOperationSlot` | Yes |  |
| `Get-AzWebSiteProviderOperation` | Yes |  |
| `Get-AzWebSiteServerFarmOperation` | Yes |  |

#### Website Top Level Domain

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Get-AzWebSiteTopLevelDomain` | Yes |  |
| `Get-AzWebSiteTopLevelDomainAgreement` | Yes |  |

#### Other

| Cmdlet | New? | Notes |
| ------ | ---- | ----- |
| `Add-AzWebAppSlotConfigToProduction` | Yes |  |
| `Get-AzWebAppSlotDifferenceFromProduction` | Yes |  |
| `Get-AzWebAppSlotDifferenceSlot` | Yes |  |
| `Get-AzWebSiteBillingMeter` | Yes |  |
| `Get-AzWebSiteClassicMobileServiceClassicMobileService` | Yes |  |
| `Get-AzWebSiteGeoRegion` | Yes |  |
| `Get-AzWebSiteHostingEnvironmentWebHostingPlan` | Yes |  |
| `Get-AzWebSiteIdentifierAssignedToHostName` | Yes |  |
| `Get-AzWebSiteManagedApi` | Yes |  |
| `Get-AzWebSiteProviderAvailableStack` | Yes |  |
| `Get-AzWebSiteProviderAvailableStackOnPrem` | Yes |  |
| `Get-AzWebSitePublishingUser` | Yes |  |
| `Get-AzWebSiteResourceHealthMetadata` | Yes |  |
| `Get-AzWebSiteSku` | Yes |  |
| `Get-AzWebSiteSubscriptionDeploymentLocation` | Yes |  |
| `Invoke-AzWebSiteRenewDomain` | Yes |  |
| `Move-AzWebAppStorage` | Yes |  |
| `Reset-AzWebAppProductionSlotConfig` | Yes |  |
| `Test-AzWebAppCloneable` | Yes |  |
| `Test-AzWebAppCloneableSlot` | Yes |  |
| `Test-AzWebAppCustomHostname` | Yes |  |
| `Test-AzWebAppCustomHostnameSlot` | Yes |  |
| `Test-AzWebSiteDomainAvailability` | Yes |  |
| `Test-AzWebSiteMove` | Yes |  |
| `Test-AzWebSiteNameAvailability` | Yes |  |

## Not Generated

### Web App

- `Enter-AzWebAppContainerPSSession` (needs investigation)
- `Get-AzWebAppSSLBinding` (gets a property on a web app)
- `New-AzWebAppAzureStoragePath` (creates an in-memory object)
- `New-AzWebAppContainerPSSession` (needs investigation)
- `New-AzWebAppDatabaseBackupSetting` (creates an in-memory object)
- `New-AzWebAppSSLBinding` (needs investigation)
- `Publish-AzWebApp` (needs investigation -- uses generic HttpClient to publish the web app, no calls from the Websites client)
- `Remove-AzWebAppSSLBinding` (needs investigation)