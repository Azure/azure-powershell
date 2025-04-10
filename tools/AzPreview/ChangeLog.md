## 13.5.0 - May 2025
#### Az.Communication 0.5.0
* First preview release for module Az.CommunicationServiceSmtpUsername

#### Az.Compute 9.3.0
* Added new parameters 'ZonePlacementPolicy', 'IncludeZone', 'ExcludeZone', and 'AlignRegionalDisksToVMZone' to cmdlets 'New-AzVM' and 'New-AzVmConfig'
* Added new parameter 'AlignRegionalDisksToVMZone' to cmdlet 'Update-AzVM'.
* VM/VMSS related cmdlets will now use 2024-11-01 ComputeRP API calls.

#### Az.DataFactory 1.19.2
* Added more support for M365 connection properties.
* Added more support for SnowfalkeV2 connection properties.

#### Az.DataProtection 2.7.0
* Added new cmdlet for validate for Modify backup - Test-AzDataProtectionBackupInstanceUpdate.
* Added new parameters for UAMI based restore in Initialize-AzDataProtectionRestoreRequest cmdlet.

#### Az.NetAppFiles 0.21.0
* Added new parameter 'CoolAccessTieringPolicy' to  'New-AzNetAppFilesVolume' and 'Update-AzNetAppFilesVolume',
* Added new cmdLet'Invoke-AzNetAppFilesAccountChangeKeyVault' to change Key Vault/Managed HSM that is used for encryption of volumes under NetApp account. 'Get-AzNetAppFilesAccountKeyVaultInformation' can be used to get information for this command.  
* Added new cmdLet 'Get-AzNetAppFilesAccountKeyVaultInformation', Gets information that can be used in 'Invoke-AzNetAppFilesAccountChangeKeyVault'
* Added new cmdLet 'Convert-AzNetAppFilesAccountToCmk'  Transition volumes encryption from PMK to CMK.

#### Az.Network 7.16.0
* Updated Add-AzNetworkInterfaceIpConfig and New-AzNetworkInterfaceIpConfig cmdlets to add new parameter PrivateIpAddressPrefixLength.
    - 'Add-AzNetworkInterfaceIpConfig'
    - 'New-AzNetworkInterfaceIpConfig'

#### Az.Orbital 0.2.0
* Introduced various new features by upgrading code generator. Please see detail [here](https://github.com/Azure/azure-powershell/blob/main/documentation/Autorest-powershell-v4-new-features.md).

#### Az.Peering 0.5.0
* Introduced various new features by upgrading code generator. Please see detail [here](https://github.com/Azure/azure-powershell/blob/main/documentation/Autorest-powershell-v4-new-features.md).

#### Az.Quantum 0.2.0
* Introduced various new features by upgrading code generator. Please see detail [here](https://github.com/Azure/azure-powershell/blob/main/documentation/Autorest-powershell-v4-new-features.md).

#### Az.RecoveryServices 7.7.0
* Fix for reprotect cmdlet in Azure Site Recovery for Azure to Azure provider.
* Deprecated the 'Token' parameter for cross-tenant authentication in MUA scenarios for handling breaking change in Get-AzAccessToken cmdlet, use parameter 'SecureToken' going forward.

#### Az.ResourceGraph 1.2.1
* Introduced various new features by upgrading code generator. Please see detail [here](https://github.com/Azure/azure-powershell/blob/main/documentation/Autorest-powershell-v4-new-features.md).

#### Az.Resources 7.11.0
* Added SuppressDiagnostics Parameter to Test-Deployment cmdlets.

#### Az.TrustedSigning 0.1.1
* Modified InvokeCiPolicySigning to include ShouldProcess command confirmation

#### Az.WindowsIotServices 0.2.0
* Introduced various new features by upgrading code generator. Please see details [here](https://github.com/Azure/azure-powershell/blob/main/documentation/Autorest-powershell-v4-new-features.md).
* Removed parameter Location from command Update-AzWindowsIotServicesDevice.

## 13.4.0 - April 2025
#### Az.Accounts 4.1.0
* Added AppConfiguration ResourceId and Suffix endpoints for Mooncake and USGov clouds to fix issue [#24219]

#### Az.Aks 6.1.1
* Preannounced breaking change: The default value of '-NodeVmSize' parameter of 'New-AzAksCluster' will be changing from 'Standard_DS2_V2 (Linux), Standard_DS2_V3 (Windows)' to being dynamically selected by the AKS resource provider based on quota and capacity in the next major release.
* The code base is going to be refactored, the following cmdlet adds a BreakingChange announcement:
  * 'Get-AzAksMaintenanceConfiguration'
  * 'Get-AzAksManagedClusterOSOption'
  * 'Get-AzAksManagedClusterOutboundNetworkDependencyEndpoint'
  * 'Get-AzAksNodePoolUpgradeProfile'
  * 'Get-AzAksUpgradeProfile'
  * 'Get-AzAksVersion'
  * 'New-AzAksMaintenanceConfiguration'

#### Az.AppConfiguration 1.4.1
* The code base is going to be refactored, the following cmdlet adds a BreakingChange announcement:
  * 'Get-AzAppConfigurationStore'
  * 'New-AzAppConfigurationStore'
  * 'Update-AzAppConfigurationStore'

#### Az.ArizeAI 0.1.0
* First preview release for module Az.ArizeAI

#### Az.Cdn 3.3.1
* This upgrade contains no changes in cdn powershell commandline tool, it only notifies user that we are going to upgrade the version of autorest, and will bring some breaking changes.

#### Az.CognitiveServices 1.16.0
* Updated SDK via autorest.powershell.
* Added Get, New, Remove cmdlets for AzCognitiveServicesAccountRaiPolicy, AzCognitiveServicesAccountRaiBlocklist, AzCognitiveServicesAccountRaiBlocklistItem.
* Added Get cmdlets for AzCognitiveServicesRaiContentFilters, AzCognitiveServicesAccountDeploymentSku, AzCognitiveServicesModelCapacity.
* Added Get, New cmdlets for AzCognitiveServicesAccountDefenderForAISetting.

#### Az.Compute 9.2.0
* Added new parameter '-ReplicationMode' to 'New-AzGalleryImageVersion' cmdlet.
* Added new parameter 'BlockDeletionBeforeEndOfLife' parameter to 'New-AzGalleryImageVersion' and 'Update-AzGalleryImageVersion' cmdlets.
* Updated 'New-AzVM', 'New-AzVmss', 'Update-AzVM', and 'Update-AzVmss' to pass 'Standard' as an input of '-SecurityType' parameter.
* Added breaking change message for 'Get-AzVMSize'.

#### Az.CosmosDB 1.18.0
* Added support for creating containers with Vector Embedding Policy.
* GAd Per Partition Automatic Failover GA
* GAd Per Region Per Partition Autoscale GA

#### Az.DynatraceObservability 0.2.0
* Updated the api version to '2023-04-27' (Stable Version)

#### Az.IoTOperationsService 0.1.0
* First preview release for module Az.IoTOperationsService

#### Az.ManagedServiceIdentity 1.3.1
* Added breaking change announcement for the following cmdlets due to migrating autorest from v3 to v4.
  * 'Get-AzFederatedIdentityCredential'
  * 'New-AzFederatedIdentityCredential'
  * 'Update-AzFederatedIdentityCredential'

#### Az.Monitor 6.0.2
* Pipeline Group upgraded API version to 2024-10-01-preview

#### Az.Network 7.15.1
* Updated VirtualNetworkGatewayConnection cmdlets to pass AuxilaryAuthHeader for referenced resourceIds i.e. LocalNetworkGateway2, VirtualNetworkGateway2. This is needed in case referenced resourceIds are in different AAD Tenant.
    - 'New-AzVirtualNetworkGatewayConnection'
    - 'Set-AzVirtualNetworkGatewayConnection'

#### Az.Pinecone 0.1.0
* First preview release for module Az.Pinecone

#### Az.RecoveryServices 7.6.0
* Azure Site Recovery support for shared disk scenario for Azure to Azure provider.
* Removed warning about ensuring Enhanced Policy for Trusted Launch VMs when configuring protection for Azure VMs.
* Added warning 'Starting in May 2025, Trusted Launch virtual machines can be protected with both standard and enhanced policies via PS and CLI' in Enable-AzRecoveryServicesBackupProtection.
* Added breaking change announcement for Get-AzRecoveryServicesBackupSchedulePolicyObject that this command will return a Enhanced policy object by default for IaaSVM workload.
* Added support for PremiumV2_LRS and UltraSSD_LRS target disk types for Azure to Azure replication.
* Added logs to enable better debugging for Modify protection with MSSQL workload.
* Added Cross region restore support for new regions - israelnorthwest, southwestus, southcentralus2, southeastus3, southeastus5.

#### Az.Resources 7.10.0
* Fixed the issue that Get-AzReource not working with '-ExpandProperties'. [#11248]
* Updated Resources SDK to 2024-11-01.
* Added breaking change announcement for the following cmdlets due to API version for resource type may change.
    - 'Get-AzResource'
    - 'New-AzResource'
    - 'Set-AzResource'
    - 'Remove-AzResource'
    - 'Invoke-AzResourceAction'
* Added ValidationLevel Parameter to WhatIf and Validate cmdlets for deployments.

#### Az.ScVmm 0.1.0
* First preview release for module Az.ScVmm

#### Az.Ssh 0.2.3
* Implemented code refactoring, no behavior changes expected.

#### Az.Storage 8.3.0
* Supported NFS File Share and NFS file and directory properties
    - 'Get-AzStorageFile'
    - 'Get-AzStorageFileContent'
    - 'New-AzStorageDirectory'
    - 'Remove-AzStorageFile'
    - 'Set-AzStorageFileContent'
    - 'Start-AzStorageFileCopy'
* Supported File share properties: Protocol, EnableSnapshotVirtualDirectoryAccess.
    - 'New-AzStorageShare'
    - 'Get-AzStorageShare'
* Supported create hard link in NFS File Share 
    - 'New-AzStorageFileHardLink'
* Added warning message for upcoming breaking change on upload Azure file
    - 'Set-AzStorageFileContent'
* Added warning messages for an upcoming breaking change when converting the account's redundancy configuration
    - 'Start-AzStorageAccountMigration'

#### Az.StorageSync 2.5.0
* Fixed the bug in server registration
* Improved the error message for Set-AzStorageSyncServiceIdentity cmdlet
* Added RoleAssignmentExists check
* Added AssignIdentity to Set-AzStorageSyncServer
* Added a default behavior of system assigned identity to StorageSyncService provisioning

#### Az.Synapse 3.2.0
* Supported copyComputeScale and pipelineExternalComputeScale in 'Set-AzSynapseIntegrationRuntime' Command

#### Az.TrustedSigning 0.1.0
* First preview release for module Az.TrustedSigning

#### Az.Websites 3.4.0
* Add support for pull based deployments from a URL with MSI authentication in 'Publish-AzWebApp'

#### Az.WeightsAndBiases 0.1.0
* First preview release for module Az.WeightsAndBiases

## 13.3.0 - March 2025
#### Az.CosmosDB 1.17.0
* Added support for Cosmos DB Table role definition and role assignment related cmdlets.

#### Az.DataBoxEdge 1.2.1
* Removed 'Microsoft.Azure.Management.DataBoxEdge' Version '1.0.0' PackageReference

#### Az.DataFactory 1.19.1
* Added more support for Oracle connection properties.
* Added more support for Teradata connection properties.
* Added more support for AzurePostgreSql connection properties.

#### Az.DataMigration 0.14.10
* Updated Sql schema migration and version package to new url. 

#### Az.DataShare 1.1.1
* Removed 'Microsoft.Azure.Management.DataShare' Version '1.0.1' PackageReference

#### Az.Maintenance 1.5.1
* Migrated SDK generation from autorest csharp to autorest powershell.

#### Az.Migrate 2.7.0
  * Updated Data.Replication to newer API version
    - Updated Data.Replication to point to stable API version 2024-09-01
  * Rebranded Data.Replication cmdlets
    - Rebranded Data.Replication cmdlets from Azure Stack HCI to Azure Local

#### Az.PolicyInsights 1.7.1
* Removed 'Microsoft.Azure.Management.PolicyInsights' Version '1.0.0' PackageReference

#### Az.RecoveryServices 7.5.1
* Updated Restore-AzRecoveryServicesBackupItem to support 0 as a TargetZoneNumber to restore to NoZone.
* Updated Restore-AzRecoveryServicesBackupItem to block cross zonal restore from snapshot RP.

#### Az.ResourceGraph 1.2.0
* Upgraded API version to 2024-04-01.

#### Az.Resources 7.9.0
* Added '-ApplicationId' as an alias of '-ServicePrincipalName'.
* Supported getting role assignments at the exact scope via '-AtScope' for 'Get-AzRoleAssignment'. 

#### Az.ServiceBus 4.1.1
* Fixed a bug when invoke 'Set-AzServiceBusNamespace' with parameter 'NoWait' [#26998]

#### Az.Sql 6.0.2
* Fixed GitHub issue #12417 'Get-AzSqlElasticPoolDatabase doesn't enumerate output.'
    - fixed the output to enumerate the results.

#### Az.Storage 8.2.0
* Supported new SkuName when create/update Storage account for Files Provisioned v2 account type:  'StandardV2_LRS', 'StandardV2_GRS', 'StandardV2_ZRS', 'StandardV2_GZRS', 'PremiumV2_LRS', 'PremiumV2_ZRS'
    - 'New-AzStorageAccount'
    - 'Set-AzStorageAccount'
* Supported Get File Service Usage on Files Provisioned v2 account type.
    - 'Get-AzStorageFileServiceUsage'
* Supported create/update file share on new parameters on Files Provisioned v2 account type with new parameter: '-ProvisionedBandwidthMibps', '-ProvisionedIops''
    - 'New-AzRmStorageShare'
    - 'Update-AzRmStorageShare'
* Supported create/update/Get file share on new parameters on Files Provisioned v1 account type with new parameter: '-PaidBurstingEnabled', '-PaidBurstingMaxBandwidthMibps', '-PaidBurstingMaxIops'
    - 'New-AzRmStorageShare'
    - 'Update-AzRmStorageShare'
    - 'Get-AzStorageFileServiceUsage'
* Supported get file share new properties for Files Provisioned v1/v2 account type
    - 'Get-AzStorageFileServiceUsage'

#### Az.Synapse 3.1.2
* Updated Azure.Analytics.Synapse.Artifacts to 1.0.0-preview.21.

#### Az.Websites 3.3.1
* Migrated Websites.Helper generation from autorest csharp to autorest powershell.

#### Az.Workloads 1.0.0
* General availability for module Az.Workloads
* Upgraded API version to 2024-09-01

## 13.2.0 - February 2025
#### Az.Accounts 4.0.2
* Fixed unsigned dll:
    - 'System.Buffers.dll'
    - 'System.Memory.dll'

#### Az.Automation 1.11.1
* Fixed Bug: Start-AzAutomationRunbook throws object reference error when the automation account is not available in the subscription 

#### Az.Blueprint 0.4.6
* Deprecation of Blueprint cmdlets.

#### Az.Compute 9.1.0
* Added new parameter 'EncryptionIdentity' to cmdlet 'Set-AzVmssDiskEncryptionExtension'
* Added new parameter 'EncryptionIdentity' to cmdlet 'New-VmssConfig'
* Added new parameter 'EncryptionIdentity' to cmdlet 'Set-AzVMDiskEncryptionExtension'
* Added new parameter 'EncryptionIdentity' to cmdlet 'New-AzVMConfig'

#### Az.DataProtection 2.6.1
* Updated Help Doc of Get-AzAccessToken Usage in DataProtection

#### Az.EventHub 5.2.0
*  Added parameter 'MinCompactionLagInMin', 'TimestampType' and 'UserMetadata' to cmdlets 'New-AzEventHub' and 'Set-AzEventHub'
*  Supported 'DelectorCompact' policy in parameter 'Cleanup-policy' of cmdlet 'new-AzEventhub'

#### Az.Network 7.14.0
* Updated 'New-AzRouteServer', 'Get-AzRouteServer', and 'Update-AzRouteServer' to include VirtualRouterAutoScaleConfiguration.

#### Az.Portal 0.3.0
* Updated Api Version to 2022-12-01-preview.

#### Az.RecoveryServices 7.5.0
* Added support for updating SoftDeleteRetentionPeriodInDays in Set-AzRecoveryServicesVaultProperty cmdlet.
* Added new cmdlet Undo-AzRecoveryServicesBackupContainerDeletion for undeleting soft deleted backup container.
* Resolved bug in Restore-AzRecoveryServicesBackupItem cmdlet.
* Updated cmdlet Set-AzRecoveryServicesBackupProperty to use vault PATCH API while setting CRR, Redundancy settings.
* Updated cmdlets Get-AzRecoveryServicesBackupItem and Get-AzRecoveryServicesVaultProperty to expose more properties in the output.
* Updated the configure backup per policy protection limit for VMs from 100 to 1000.

#### Az.Resources 7.8.1
* Updated to use bicep parameter --documentation-uri instead of the deprecated --documentationUri

#### Az.StorageSync 2.4.1
* Removed 'Microsoft.Azure.Management.Authorization' Version '2.13.0-preview' package reference

#### Az.Synapse 3.1.1
* Removed 'Microsoft.Azure.Management.Synapse' Version '2.6.0-preview' package reference 

## 13.1.0 - January 2025
#### Az.Accounts 4.0.1
* Upgraded nuget package to signed package.
* Fixed the Managed Identity parameter set description of 'AccountId' in 'Connect-AzAccount'.
* Made the breaking change warnings about 'Get-AzAccessToken' not appear when '-AsSecureString' is used.
* Fixed an issue that cmdlets may report warnings of 'KeyNotFoundException'. #26624
* Fixed an issue that the '-AppliesTo' parameter of 'Update-AzConfig' does not work as expected.
* Upgraded Azure.Core to 1.44.1 and Azure.Identity to 1.13.0.
* Updated Azure PowerShell intercept survey prompt.

#### Az.ADDomainServices 0.2.3
* Upgraded nuget package to signed package.

#### Az.Advisor 2.1.0
* Upgraded nuget package to signed package.

#### Az.Aks 6.1.0
* Upgraded nuget package to signed package.
* Fixed the issue that HTTP request body contains empty userAssignedIdentities object when identity type is 'SystemAssigned'.

#### Az.AksArc 0.1.3
* Upgraded nuget package to signed package.

#### Az.Alb 0.1.4
* Upgraded nuget package to signed package.

#### Az.AlertsManagement 0.6.3
* Upgraded nuget package to signed package.

#### Az.AnalysisServices 1.2.0
* Upgraded nuget package to signed package.

#### Az.ApiManagement 4.1.0
* Upgraded nuget package to signed package.
* Fixed model creation parameters of ApiCreateOrUpdateParameter, ProductContract, SubscriptionCreateParameters, GroupCreateParameters, OpenidConnectProviderContract, IdentityProviderCreateContract, BackendContract, CacheContract and DiagnosticContract with [#26672].

#### Az.App 2.0.1
* Upgraded nuget package to signed package.

#### Az.AppComplianceAutomation 0.1.3
* Upgraded nuget package to signed package.

#### Az.AppConfiguration 1.4.0
* Upgraded nuget package to signed package.

#### Az.ApplicationInsights 2.3.0
* Upgraded nuget package to signed package.

#### Az.ArcGateway 0.1.1
* Upgraded nuget package to signed package.

#### Az.ArcResourceBridge 1.1.0
* Upgraded nuget package to signed package.

#### Az.Astro 0.1.2
* Upgraded nuget package to signed package.

#### Az.Attestation 2.1.0
* Upgraded nuget package to signed package.

#### Az.Automanage 1.1.0
* Upgraded nuget package to signed package.

#### Az.Automation 1.11.0
* Upgraded nuget package to signed package.

#### Az.BareMetal 0.1.2
* Upgraded nuget package to signed package.

#### Az.Batch 3.7.0
* Upgraded nuget package to signed package.
* Fixed 'Object reference not set to an instance of an object' error when setting null values inside job 'CommonEnvironmentSettings' property. 

#### Az.Billing 2.2.0
* Upgraded nuget package to signed package.

#### Az.BillingBenefits 0.1.2
* Upgraded nuget package to signed package.

#### Az.Blueprint 0.4.5
* Upgraded nuget package to signed package.

#### Az.BotService 0.5.2
* Upgraded nuget package to signed package.

#### Az.Cdn 3.3.0
* Upgraded nuget package to signed package.

#### Az.ChangeAnalysis 0.1.2
* Upgraded nuget package to signed package.

#### Az.Chaos 0.1.1
* Upgraded nuget package to signed package.

#### Az.CloudService 2.1.0
* Upgraded nuget package to signed package.

#### Az.CodeSigning 0.2.1
* Upgraded nuget package to signed package.
* Upgraded Azure.Core to 1.44.1.
* Upgraded to rebranded package Azure.Developer.TrustedSigning.CryptoProvider.
* Upgraded to updated Azure.Codesigning.Sdk.

#### Az.CognitiveServices 1.15.0
* Upgraded nuget package to signed package.

#### Az.Communication 0.4.2
* Upgraded nuget package to signed package.

#### Az.Compute 9.0.1
* Upgraded nuget package to signed package.
* Upgraded Azure.Core to 1.44.1.
* Compute gallery related cmdlets will now use 2024-03-03 GalleryRP API calls. 

#### Az.ComputeFleet 0.1.0
* First preview release for module Az.ComputeFleet

#### Az.ComputeSchedule 0.1.0
* First preview release for module Az.ComputeSchedule

#### Az.ConfidentialLedger 1.1.0
* Upgraded nuget package to signed package.

#### Az.Confluent 0.2.2
* Upgraded nuget package to signed package.

#### Az.ConnectedKubernetes 0.14.0
* Upgraded nuget package to signed package.

#### Az.ConnectedMachine 1.1.1
* Upgraded nuget package to signed package.

#### Az.ConnectedNetwork 0.1.2
* Upgraded nuget package to signed package.

#### Az.ConnectedVMware 0.1.3
* Upgraded nuget package to signed package.

#### Az.ContainerInstance 4.1.1
* Upgraded nuget package to signed package.
* Added breaking change warning for removing default value for OsType 'New-AzContainerGroup'

#### Az.ContainerRegistry 4.3.0
* Upgraded nuget package to signed package.
* Upgraded Azure.Core to 1.44.1.

#### Az.CosmosDB 1.16.0
* Upgraded nuget package to signed package.
* Upgraded Azure.Core to 1.44.1.

#### Az.CostManagement 0.3.4
* Upgraded nuget package to signed package.
* Fixed bug tags in query filter cannot be properly serialized [#22326]

#### Az.CustomLocation 0.2.1
* Upgraded nuget package to signed package.

#### Az.CustomProviders 0.1.2
* Upgraded nuget package to signed package.

#### Az.Dashboard 0.1.3
* Upgraded nuget package to signed package.

#### Az.DataBox 0.3.3
* Upgraded nuget package to signed package.

#### Az.DataBoxEdge 1.2.0
* Upgraded nuget package to signed package.

#### Az.Databricks 1.10.0
* Upgraded nuget package to signed package.
* Updated Az.Databricks to use more intuitive parameter names for the ESC feature.

#### Az.Datadog 0.1.2
* Upgraded nuget package to signed package.

#### Az.DataFactory 1.19.0
* Upgraded nuget package to signed package.
* Added support for additional MySQL connection properties.
* Added support for Azure PostgreSQL v2, updated connection strings, and corrected Linked JSON configurations.

#### Az.DataLakeAnalytics 1.1.0
* Upgraded nuget package to signed package.

#### Az.DataLakeStore 1.4.0
* Upgraded nuget package to signed package.

#### Az.DataMigration 0.14.9
* Upgraded nuget package to signed package.
* Updated the URL to download the SQL Assessment Zip to 'https://aka.ms/sqlassessmentpackage'

#### Az.DataProtection 2.6.0
* Upgraded nuget package to signed package.
* Added support for UAMI in Backup Instance

#### Az.DataShare 1.1.0
* Upgraded nuget package to signed package.

#### Az.DedicatedHsm 0.3.2
* Upgraded nuget package to signed package.

#### Az.DesktopVirtualization 5.4.1
* Upgraded nuget package to signed package.

#### Az.DevCenter 2.0.1
* Upgraded nuget package to signed package.

#### Az.DeviceProvisioningServices 0.10.4
* Upgraded nuget package to signed package.

#### Az.DeviceRegistry 0.1.0
* First preview release for module Az.DeviceRegistry

#### Az.DeviceUpdate 0.1.2
* Upgraded nuget package to signed package.

#### Az.DevTestLabs 1.1.0
* Upgraded nuget package to signed package.
* Removed 'Microsoft.Azure.Management.DevTestLabs' Version '1.0.0' PackageReference

#### Az.DigitalTwins 0.2.2
* Upgraded nuget package to signed package.

#### Az.DiskPool 0.3.2
* Upgraded nuget package to signed package.

#### Az.Dns 1.3.1
* Upgraded nuget package to signed package.

#### Az.DnsResolver 1.1.1
* Upgraded nuget package to signed package.

#### Az.DynatraceObservability 0.1.2
* Upgraded nuget package to signed package.

#### Az.EdgeOrder 0.1.2
* Upgraded nuget package to signed package.

#### Az.EdgeZones 0.1.2
* Upgraded nuget package to signed package.

#### Az.Elastic 0.2.1
* Upgraded nuget package to signed package.

#### Az.ElasticSan 1.2.1
* Upgraded nuget package to signed package.

#### Az.EventGrid 2.2.0
* Upgraded nuget package to signed package.

#### Az.EventHub 5.1.0
* Upgraded nuget package to signed package.

#### Az.Fabric 0.1.1
* Upgraded nuget package to signed package.

#### Az.FirmwareAnalysis 0.1.4
* Upgraded nuget package to signed package.

#### Az.Fleet 0.2.2
* Upgraded nuget package to signed package.

#### Az.FluidRelay 0.1.2
* Upgraded nuget package to signed package.

#### Az.FrontDoor 1.12.0
* Upgraded nuget package to signed package.

#### Az.Functions 4.2.0
* Upgraded nuget package to signed package.

#### Az.GraphServices 0.1.2
* Upgraded nuget package to signed package.

#### Az.GuestConfiguration 0.11.2
* Upgraded nuget package to signed package.

#### Az.HanaOnAzure 0.3.3
* Upgraded nuget package to signed package.

#### Az.HDInsight 6.3.1
* Upgraded nuget package to signed package.

#### Az.HdInsightOnAks 0.2.1
* Upgraded nuget package to signed package.

#### Az.HealthBot 0.1.2
* Upgraded nuget package to signed package.

#### Az.HealthcareApis 2.1.0
* Upgraded nuget package to signed package.

#### Az.HealthDataAIServices 1.0.0
* General availability for module Az.HealthDataAIServices
* Upgraded nuget package to signed package.
* Upgraded API version to 2024-09-20

#### Az.HPCCache 0.1.3
* Upgraded nuget package to signed package.

#### Az.ImageBuilder 0.4.2
* Upgraded nuget package to signed package.

#### Az.ImportExport 0.2.2
* Upgraded nuget package to signed package.

#### Az.Informatica 0.1.1
* Upgraded nuget package to signed package.

#### Az.IotCentral 0.10.3
* Upgraded nuget package to signed package.

#### Az.IotHub 2.8.0
* Upgraded nuget package to signed package.
* Removed 'Microsoft.Azure.Management.IotHub' Version '4.2.0' PackageReference

#### Az.KeyVault 6.3.1
* Upgraded nuget package to signed package.
* Upgraded Azure.Core to 1.44.1.

#### Az.KubernetesConfiguration 0.7.3
* Upgraded nuget package to signed package.

#### Az.KubernetesRuntime 0.1.1
* Upgraded nuget package to signed package.

#### Az.Kusto 2.4.0
* Upgraded nuget package to signed package.
* Added new cmdlets
    - 'Add-AzKustoClusterCalloutPolicy'
    - 'Get-AzKustoClusterCalloutPolicy'
    - 'Remove-AzKustoClusterCalloutPolicy'
    - 'Get-AzKustoClusterFollowerDatabaseGet'

#### Az.LabServices 0.1.2
* Upgraded nuget package to signed package.

#### Az.LoadTesting 1.1.0
* Upgraded nuget package to signed package.

#### Az.LogicApp 1.6.0
* Upgraded nuget package to signed package.
* Removed 'Microsoft.Azure.Management.Logic' Version '4.1.0' PackageReference

#### Az.Logz 0.1.2
* Upgraded nuget package to signed package.

#### Az.MachineLearning 1.2.0
* Upgraded nuget package to signed package.

#### Az.MachineLearningServices 1.2.0
* Upgraded nuget package to signed package.

#### Az.Maintenance 1.5.0
* Upgraded nuget package to signed package.
* Added list of allowed classifications in description for Maintenance Configuration
* Fixed incorrect parameter mapping in Get-AzApplyUpdate

#### Az.ManagedNetworkFabric 0.1.3
* Upgraded nuget package to signed package.

#### Az.ManagedServiceIdentity 1.3.0
* Upgraded nuget package to signed package.

#### Az.ManagedServices 3.1.0
* Upgraded nuget package to signed package.

#### Az.ManagementPartner 0.7.5
* Upgraded nuget package to signed package.

#### Az.Maps 0.8.2
* Upgraded nuget package to signed package.

#### Az.MariaDb 0.2.3
* Upgraded nuget package to signed package.

#### Az.Marketplace 0.5.2
* Upgraded nuget package to signed package.

#### Az.MarketplaceOrdering 2.1.0
* Upgraded nuget package to signed package.

#### Az.Mdp 0.1.1
* Upgraded nuget package to signed package.

#### Az.Media 1.2.0
* Upgraded nuget package to signed package.

#### Az.Migrate 2.6.0
* Upgraded nuget package to signed package.
* Added support for PremiumV2 disk type.
* Added SBM support.

#### Az.MixedReality 0.2.2
* Upgraded nuget package to signed package.

#### Az.MobileNetwork 0.4.2
* Upgraded nuget package to signed package.

#### Az.Monitor 6.0.1
* Upgraded nuget package to signed package.

#### Az.MonitoringSolutions 0.1.2
* Upgraded nuget package to signed package.

#### Az.MySql 1.3.0
* Upgraded nuget package to signed package.

#### Az.NeonPostgres 0.1.1
* Upgraded nuget package to signed package.

#### Az.NetAppFiles 0.20.1
* Upgraded nuget package to signed package.

#### Az.Network 7.12.0
* Onboarded 'Microsoft.HeathDataAIServices/deidServices' to private link cmdlets
* Upgraded nuget package to signed package.
* Updated 'Remove-AzNetworkWatcherFlowLog' command to return boolean value
* Updated vnv and ipam cmdlets
* Allowed TA interval to be set as 0 incase TA is disabled
* Onboarded Azure Virtual Network Manager Cmdlets for IpamPool
    - 'Get-AzNetworkManagerAssociatedResourcesList'
    - 'Get-AzNetworkManagerIpamPool'
    - 'Get-AzNetworkManagerIpamPoolStaticCidr'
    - 'Get-AzNetworkManagerIpamPoolUsage'
    - 'New-AzNetworkManagerIpamPool'
    - 'New-AzNetworkManagerIpamPoolStaticCidr'
    - 'Remove-AzNetworkManagerIpamPool'
    - 'Remove-AzNetworkManagerIpamPoolStaticCidr'
    - 'Set-AzNetworkManagerIpamPool'
* Onboarded Azure Virtual Network Manager Cmdlets for VnetVerifier
    - 'New-AzNetworkManagerSecurityGroupItem'
    - 'New-AzNetworkManagerVerifierWorkspace'
    - 'Get-AzNetworkManagerVerifierWorkspace'
    - 'Set-AzNetworkManagerVerifierWorkspace'
    - 'Remove-AzNetworkManagerVerifierWorkspace'
    - 'New-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent'
    - 'Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent'
    - 'Remove-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisIntent'
    - 'New-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun'
    - 'Get-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun'
    - 'Remove-AzNetworkManagerVerifierWorkspaceReachabilityAnalysisRun'
* Updated cmdlet to add the property of 'NetworkGroupAddressSpaceAggregationOption', and updated corresponding cmdlets.
    - 'New-AzNetworkManagerSecurityAdminConfiguration'
    - 'New-AzNetworkManagerAddressPrefixItemCommand'
* Added 'DefaultOutboundConnectivityEnabled' property in PSNetworkInterface
* Added support for 'AutoscaleConfiguration' property in 'AzureFirewall' model for 'New-AzFirewall' and 'Set-AzFirewall' commands
* Added support for 'ResiliencyModel' property in 'New-AzVirtualNetworkGateway' and 'Set-AzVirtualNetworkGateway' command for ExpressRoute

#### Az.NetworkAnalytics 0.1.2
* Upgraded nuget package to signed package.

#### Az.NetworkCloud 1.1.0
* Upgraded nuget package to signed package.
* Upgraded API version to 2024-07-01

#### Az.NetworkFunction 0.1.5
* Upgraded nuget package to signed package.

#### Az.NewRelic 0.2.1
* Upgraded nuget package to signed package.

#### Az.Nginx 1.2.0
* Upgraded nuget package to signed package.

#### Az.NotificationHubs 1.2.0
* Upgraded nuget package to signed package.

#### Az.OperationalInsights 3.3.0
* Upgraded nuget package to signed package.

#### Az.Oracle 1.1.0
* Upgraded nuget package to signed package.

#### Az.Orbital 0.1.3
* Upgraded nuget package to signed package.

#### Az.PaloAltoNetworks 0.3.1
* Upgraded nuget package to signed package.

#### Az.Peering 0.4.2
* Upgraded nuget package to signed package.

#### Az.PolicyInsights 1.7.0
* Upgraded nuget package to signed package.
* Upgraded Azure.Core to 1.44.1.

#### Az.Portal 0.2.1
* Upgraded nuget package to signed package.

#### Az.PostgreSql 1.2.0
* Upgraded nuget package to signed package.

#### Az.PowerBIEmbedded 2.1.0
* Upgraded nuget package to signed package.
* Removed 'Microsoft.Azure.Management.PowerBIEmbedded' Version '1.1.1-preview' PackageReference
* Removed 'Microsoft.Azure.Management.PowerBIDedicated' Version '0.11.0-preview' PackageReference

#### Az.PrivateDns 1.2.0
* Upgraded nuget package to signed package.

#### Az.ProviderHub 0.3.1
* Upgraded nuget package to signed package.

#### Az.Purview 0.2.2
* Upgraded nuget package to signed package.

#### Az.Quantum 0.1.2
* Upgraded nuget package to signed package.

#### Az.Qumulo 0.1.3
* Upgraded nuget package to signed package.

#### Az.Quota 0.1.3
* Upgraded nuget package to signed package.

#### Az.RecoveryServices 7.4.0
* Upgraded nuget package to signed package.
* Updated the policy, protection commands to support AFS Vault Tier.

#### Az.RedisCache 1.11.0
* Upgraded nuget package to signed package.
* Added support for choosing Zonal Allocation Policy

#### Az.RedisEnterpriseCache 1.4.1
* Upgraded nuget package to signed package.

#### Az.Relay 2.1.0
* Upgraded nuget package to signed package.

#### Az.Reservations 0.13.1
* Upgraded nuget package to signed package.

#### Az.ResourceGraph 1.1.0
* Upgraded nuget package to signed package.

#### Az.ResourceMover 1.3.0
* Upgraded nuget package to signed package.

#### Az.Resources 7.8.0
* Upgraded nuget package to signed package.
* Added DefaultApiVersion to the returned properties of the 'Get-AzResourceProvider' cmdlet's Resource Type array
* Added Diagnostics/Warnings to WhatIf/Validate results for deployments.
* Fixed bug unexpected type issue: [#26752]
* Added parameter 'RequestedAccessTokenVersion' for 'New-AzADApplication' and 'Update-AzADApplication'

#### Az.Search 0.10.1
* Upgraded nuget package to signed package.

#### Az.Security 1.8.0
* Upgraded nuget package to signed package.

#### Az.SecurityInsights 3.2.0
* Upgraded nuget package to signed package.

#### Az.SelfHelp 0.2.1
* Upgraded nuget package to signed package.

#### Az.ServiceBus 4.1.0
* Upgraded nuget package to signed package.

#### Az.ServiceFabric 3.5.0
* Upgraded nuget package to signed package.

#### Az.ServiceLinker 0.2.3
* Upgraded nuget package to signed package.

#### Az.SignalR 2.1.0
* Upgraded nuget package to signed package.
* Removed 'Microsoft.Azure.Management.SignalR' Version '1.1.2-preview' PackageReference

#### Az.Sphere 0.1.3
* Upgraded nuget package to signed package.

#### Az.SpringCloud 0.3.2
* Upgraded nuget package to signed package.

#### Az.Sql 6.0.1
* Upgraded nuget package to signed package.
* Updated 'New-AzSqlDatabaseExport' with support for Managed Identity
 	- Added 'ManagedIdentity' to 'StorageKeyType' auth list
   	- Added 'ManagedIdentity' to 'AuthenticationType' auth list
* Updated 'New-AzSqlDatabaseImport' with support for Managed Identity
  	- Added 'ManagedIdentity' to 'StorageKeyType' auth list
	- Added 'ManagedIdentity' to 'AuthenticationType' auth list

#### Az.SqlVirtualMachine 2.4.0
* Upgraded nuget package to signed package.

#### Az.Ssh 0.2.2
* Upgraded nuget package to signed package.

#### Az.StackHCI 2.5.0
* Upgraded nuget package to signed package.

#### Az.StackHCIVM 1.1.0
* Upgraded nuget package to signed package.

#### Az.StandbyPool 0.2.1
* Upgraded nuget package to signed package.

#### Az.Storage 8.1.0
* Upgraded nuget package to signed package.
* Added warning message for account migration cmdlet.
    - 'Start-AzStorageAccountMigration'
* Fixed error message when creating OAuth based Storage context without first login with Connect-AzAccount.
    - 'New-AzStorageContext'
* Upgraded Azure.Storage.Blobs to 12.23.0
* Upgraded Azure.Storage.Files.Shares to 12.21.0
* Upgraded Azure.Storage.Files.DataLake to 12.21.0
* Upgraded Azure.Storage.Queues to 12.21.0
* Supported ClientName property when listing file handles 
    - 'Get-AzStorageFileHandle'
* Upgraded Azure.Core to 1.44.1.

#### Az.StorageAction 0.1.1
* Upgraded nuget package to signed package.

#### Az.StorageCache 0.1.2
* Upgraded nuget package to signed package.

#### Az.StorageMover 1.5.0
* Upgraded nuget package to signed package.

#### Az.StorageSync 2.4.0
* Upgraded nuget package to signed package.

#### Az.StreamAnalytics 2.1.0
* Upgraded nuget package to signed package.

#### Az.Subscription 0.11.2
* Upgraded nuget package to signed package.

#### Az.Support 2.1.0
* Upgraded nuget package to signed package.

#### Az.Synapse 3.1.0
* Upgraded nuget package to signed package.
* Upgraded Azure.Core to 1.44.1.

#### Az.Terraform 0.1.2
* Upgraded nuget package to signed package.

#### Az.TimeSeriesInsights 0.2.3
* Upgraded nuget package to signed package.

#### Az.TrafficManager 1.3.0
* Upgraded nuget package to signed package.

#### Az.VMware 0.7.2
* Upgraded nuget package to signed package.

#### Az.VoiceServices 0.1.3
* Upgraded nuget package to signed package.

#### Az.Websites 3.3.0
* Fixd the source app retrival from Microsoft.Web RP instead of ARM cache for 'RestoreAzureWebAppSnapshot'
* Upgraded nuget package to signed package.

#### Az.WindowsIotServices 0.1.2
* Upgraded nuget package to signed package.

#### Az.Workloads 0.4.0
* Upgraded nuget package to signed package.

## 13.0.0 - November 2024
#### Az.Accounts 4.0.0
* [Breaking Change] Removed alias 'Resolve-Error' for the cmdlet 'Resolve-AzError'.
* Updated the 'Get-AzAccessToken' breaking change warning message.
* Added Long Running Operation Support for Invoke-AzRest command.

#### Az.App 2.0.0
* The parameters of the 'New-AzContainerApp', 'New-AzContainerAppJob', 'Update-AzContainerApp', 'Update-AzContainerAppJob' commands have changed.
  * 'IdentityType' has been removed. 'EnableSystemAssignedIdentity' is used to enable/disable system-assigned identities.
  * The type of 'UserAssignedIdentity' is simplified to an array of strings that is used to specify the user's assigned identity.

#### Az.Astro 0.1.1
* Fixed the failure issue when deleting or replacing UserAssignedIdentity.

#### Az.Compute 9.0.0
* Made '-PublicIpSku' parameter Standard by default in 'New-AzVM'

#### Az.ConnectedKubernetes 0.12.0
* Corrected function that only worked on Windows.
* Prevented unexpected value changes where parameters that were never set are unchanged but replayed back as part of Set-AzConnectedKubernetes processing.

#### Az.ConnectedMachine 1.1.0
* Updated preview version api of HybridCompute to 2024-07-31

#### Az.ContainerInstance 4.1.0
* Added ContainerGroupProfileId ContainerGroupProfileRevision StandbyPoolProfileFailContainerGroupCreateOnReuseFailure StandbyPoolProfileId to Container Group properties.
* Added ConfigMapKeyValuePair to Container object properties.
* Added new cmdlet to define container without using the preset default properties New-AzContainerInstanceNoDefaultObject
* Added new cmdlets for Container Group Profile - Get-AzContainerInstanceContainerGroupProfile, New-AzContainerInstanceContainerGroupProfile, Remove-AzContainerInstanceContainerGroupProfile, Update-AzContainerInstanceContainerGroupProfile, Get-AzContainerInstanceContainerGroupProfileRevision

#### Az.DesktopVirtualization 5.4.0
* Added top level arm object for app attach packages

#### Az.DevCenter 2.0.0
* Updated data plane to 2024-05-01-preview and removed deprecation warnings.

#### Az.Dns 1.3.0
* Added 'NAPTR' record type support in cmdlets.

#### Az.DnsResolver 1.1.0
* Added 4 new DNS Resolver Policy (DNS Security Policy) resources into the cmdlets
    - DNS Resolver Policy (DNS Security Policy)
    - DNS Security Rule
    - DNS Resolver Policy Link (DNS Security Policy Link)
    - DNS Resolver Domain List

#### Az.ElasticSan 1.2.0
* Removed breaking change warnings for MI best practices 
    - 'New-AzElasticSanVolumeGroup'
    - 'Update-AzElasticSanVolumeGroup'

#### Az.HDInsight 6.3.0
* Changed the type of parameter '-IdentityId' in command 'Update-AzHDInsightCluster' from 'string'  to 'string[]'.

#### Az.KeyVault 6.3.0
* Added Secret URI Parameter to Key Vault Secret Cmdlets [#23053]

#### Az.Mdp 0.1.0
* First preview release for module Az.Mdp

#### Az.Monitor 6.0.0
* The parameters of the 'New-AzDataCollectionEndpoint', 'New-AzDataCollectionRule', 'Update-AzDataCollectionEndpoint', 'Update-AzDataCollectionRule' commands have changed.
  * 'IdentityType' has been removed. 'EnableSystemAssignedIdentity' is used to enable/disable system-assigned identities.
  * The type of 'UserAssignedIdentity' is simplified to an array of strings that is used to specify the user's assigned identity.

#### Az.NeonPostgres 0.1.0
* First preview release for module Az.NeonPostgres

#### Az.NetAppFiles 0.20.0
* Removed parameters 'Location', 'PoolName', 'VolumeName' from 'Get-AzNetAppFilesBackup', 'New-AzNetAppFilesBackup', 'Update-AzNetAppFilesBackup', 'Remove-AzNetAppFilesBackup' and 'Restore-AzNetAppFilesBackupFile'

#### Az.Network 7.11.0
* Updated Device Update Private Link provider configuration
    - Updated Microsoft.DeviceUpdate/accounts API version to 2023-07-01

#### Az.RecoveryServices 7.3.0
* Added CRR support for southeastus, westus3 regions.
* Added support for enabling Disk access settings for managed VM restores.

#### Az.Resources 7.7.0
* Updated Resources SDK to 2024-07-01.

#### Az.Sql 6.0.0
* Added 'Start-AzSqlInstanceLinkFailover' cmdlet for Managed Instance Link.
* Updated 'New-AzSqlInstanceLink' with new input parameters
	- Added 'DistributedAvailabilityGroupName', 'FailoverMode', 'InstanceLinkRole', 'SeedingMode'
	- Renamed 'SecondaryAvailabilityGroupName' -> 'InstanceAvailabilityGroupName'
			  'SourceEndpoint' -> 'PartnerEndpoint'
			  'PrimaryAvailabilityGroupName' -> 'PartnerAvailabilityGroupName'
	- 'TargetDatabase' -> 'Database', parameter type is changed from string to string[].
* Updated 'AzureSqlManagedInstanceLinkModel' that is a return type of 'New-AzSqlInstanceLink', 'Get-AzSqlInstanceLink', 'Update-AzSqlInstanceLink' ,'Remove-AzSqlInstanceLink'
* Added new optional parameter for 'New-AzSqlDatabaseSecondary' to support cross-subscription geo-replication.

#### Az.Storage 8.0.0
* When downloading blob with parameter AbsoluteUri (alias Uri, BlobUri), not allow input parameter Context together.
    - 'Get-AzStorageBlobContent'
* Migrated following Azure Storage File dataplane cmdlets from 'Microsoft.Azure.Storage.File' to 'Azure.Storage.Files.Shares'
    - 'Close-AzStorageFileHandle'
    - 'Get-AzStorageFile'
    - 'Get-AzStorageFileContent'
    - 'Get-AzStorageFileCopyState'
    - 'Get-AzStorageFileHandle'
    - 'Get-AzStorageShare'
    - 'Get-AzStorageShareStoredAccessPolicy'
    - 'New-AzStorageDirectory'
    - 'New-AzStorageShare'
    - 'New-AzStorageFileSASToken'
    - 'New-AzStorageShareSASToken'
    - 'New-AzStorageShareStoredAccessPolicy'
    - 'Remove-AzStorageDirectory'
    - 'Remove-AzStorageFile'
    - 'Remove-AzStorageShare'
    - 'Remove-AzStorageShareStoredAccessPolicy'
    - 'Rename-AzStorageDirectory'
    - 'Rename-AzStorageFile'
    - 'Set-AzStorageFileContent'
    - 'Set-AzStorageShareQuota'
    - 'Set-AzStorageShareStoredAccessPolicy'
    - 'Start-AzStorageFileCopy'
    - 'Stop-AzStorageFileCopy'

## 12.5.0 - October 2024
#### Az.Accounts 3.0.5
* Fixed the issue that 'Export-AzSshConfig' and 'Enter-AzVM' from Az.Ssh are not able to use when WAM is enabled.
* Added breaking change preannouncement for the removal of alias 'Resolve-Error'. #26189
* Integrated new detection library to expand the scope of secrets.

#### Az.AksArc 0.1.2
* Fixed bug where Remove-AzAksArcCluster would take a very long time to complete.
* Fixed issue where Update-AzAksArcCluster would error out when passing AdminGroupObjectID parameter.

#### Az.AnalysisServices 1.1.6
* Migrated AnalysisServices SDK to generated SDK
    - Removed 'Microsoft.Azure.Management.Analysis' Version '2.0.4' PackageReference
    - Added AnalysisServices.Management.Sdk ProjectReference

#### Az.ApiManagement 4.0.5
* Removed Microsoft.Azure.Management.ApiManagement 8.0.0.0-preview
* Added ApiManagement.Management.Sdk

#### Az.AppComplianceAutomation 0.1.2
* Used 'Get-AzAccessToken -AsSecureString' inside the 'AppComplianceAutomation' for the plain text version is going to be deprecate in the next release.

#### Az.ArcGateway 0.1.0
* First preview release for module Az.ArcGateway

#### Az.Attestation 2.0.3
* Migrated Attestation SDK to generated SDK
    - Removed 'Microsoft.Azure.Management.Attestation' Version '0.12.0-preview' PackageReference
    - Added Attestation.Management.Sdk ProjectReference

#### Az.Batch 3.6.4
* Migrate Batch SDK to generated SDK
  - Removed 'Microsoft.Azure.Management.Batch' Version='15.0.0' PackageReference
  - Added Batch.Management.Sdk ProjectReference

#### Az.Communication 0.4.1
* Added support for inline attachments in the send mail operation.
    - This update introduced a new property in the EmailAttachment object called contentId, which serves as a unique identifier in the HTML content.
    - The contentId property should be referenced in the HTML body of the email for inline rendering.

#### Az.Compute 8.5.0
* Added optional parameters '-SecurityPostureId' and '-SecurityPostureExcludeExtension' to cmdlets 'New-AzVmss' and 'New-AzVmssConfig'.
* Updated image aliases to be up-to-date in the azure-powershell\src\Compute\Strategies\ComputeRp\Images.json file.
* Added 'NvmeDisk' argument completer to 'DiffDiskPlacement' parameter for 'Set-AzVMOSDisk' and 'Set-AzVmssStorageProfile' cmdlets, allowing options for disk placement as 'CacheDisk', 'ResourceDisk', or 'NvmeDisk'.

#### Az.ConnectedKubernetes 0.11.1
* Fixed environment variable usage
* Got rid of deprecated module and improved logging

#### Az.ConnectedMachine 1.0.0
* General availability for module Az.ConnectedMachine

#### Az.DataFactory 1.18.9
* Added pageSize support to Salesforce V2 Source.
* Added pageSize support to ServiceNow V2 Source.
* Added host property to Snowflake linked service.
* Fixed missing authenticationType in PostgreSQL V2 linked service.

#### Az.DataProtection 2.5.0
* Added support for vault tier backup and restore for AzureKubernetesService
* Added support for resource modifier reference
* Added a fix for Update-AzDataProtectionBackupInstance

#### Az.DesktopVirtualization 4.3.2
* Preannounced the breaking changes for Az.DesktopVirtualization 6.0.0

#### Az.DeviceProvisioningServices 0.10.3
* Removed Microsoft.Azure.Management.DeviceProvisioningServices 0.10.0-preview dependencies
* Added Microsoft.Azure.PowerShell.DeviceProvisioningServices.Management.Sdk

#### Az.Elastic 0.2.0
* Updated the api version to '2024-03-01' (Stable Version)

#### Az.EventGrid 2.1.0
* Fixed an issue that caused some commands ending in 'Object' to not work properly.

#### Az.EventHub 5.0.1
* Migrated EventHub SDK to generated SDK
  - Removed 'Microsoft.Azure.Management.EventHub' Version '5.0.0' PackageReference
  - Added EventHub.Management.Sdk ProjectReference

#### Az.Functions 4.1.1
* Used 'Get-AzAccessToken -AsSecureString' inside the 'Functions' for the plain text version is going to be deprecate in the next release.

#### Az.HealthDataAIServices 0.1.0
* First preview release for module Az.HealthDataAIServices

#### Az.Migrate 2.5.0
* Validated user login with Microsoft Managed System Identity (MSI) in 'Initialize-AzMigrateHCIReplicationInfrastructure'
* Passed appropriate Hyper-V Generation value based on source VMware firmware type in 'New-AzMigrateHCIServerReplication'
* Added support for LinuxLicenseType in Az.Migrate module.

#### Az.Monitor 5.3.0
* Added new cmdlet for Azure Monitor Pipeline Groups
  * 'Get-AzPipelineGroup'
  * 'New-AzPipelineGroup'
  * 'Update-AzPipelineGroup'
  * 'Remove-AzPipelineGroup'

#### Az.NetAppFiles 0.19.0
* Added new cmdLets for on-prem volume migration 'Start-AnfPeerExternalCluster', 'Start-AnfFinalizeExternalReplication', 'Start-AnfPerformExternalReplication', 'Start-AnfAuthorizeExternalReplication'
* Added new cmdLets 'Get-AzNetAppFilesQuotaAvailability', 'Get-AzNetAppFilesNameAvailability' and 'Get-AzNetAppFilesFileNameAvailability'
* Added 'RemotePath' to 'PSNetAppFilesReplicationObject'
* Added 'EffectiveNetworkFeatures' to 'PSNetAppFilesVolume'

#### Az.Network 7.10.0
* Onboarded Azure Virtual Network Manager Cmdlets for UDR and NSG Management
    - 'New/Get/Remove/Set-AzNetworkManagerRoutingConfiguration'
    - 'New/Get/Remove/Set-AzNetworkManagerRoutingRuleCollection'
    - 'New/Get/Remove/Set-AzNetworkManagerRoutingRule'
    - 'New-AzNetworkManagerRoutingGroupItem'
    - 'New-AzNetworkManagerRoutingRuleDestination'
    - 'New-AzNetworkManagerRoutingRuleNextHop'
    - 'New/Get/Remove/Set-AzNetworkManagerSecurityUserConfiguration'
    - 'New/Get/Remove/Set-AzNetworkManagerSecurityUserRuleCollection'
    - 'New/Get/Remove/Set-AzNetworkManagerSecurityUserRule'
    - 'New-AzNetworkManagerSecurityUserGroupItem'
* Added support for 'MemberType' property in 'New-AzNetworkManagerSecurityUserGroupItem' command

#### Az.PrivateDns 1.1.0
* Updated new property ResolutionPolicy to Get, New and Set virtual network link cmdlets.
* Created autorest generated sdk in PrivateDns.Management.Sdk folder

#### Az.RecoveryServices 7.2.1
* Fixed bug in 'Set-ASRReplicationProtectedItem' cmdlet of H2A for replication to MD scenario.

#### Az.RedisEnterpriseCache 1.4.0
* Added support for using Microsoft Entra token-based authentication.
* Added the new properties of Cluster: highAvailability and redundancyMode.
* Added new product SKUs.
* Added the new properties of Database: accessKeysAuthentication.
* Added Invoke-AzRedisEnterpriseCacheForceDatabaseLinkToReplicationGroup to force link geo replicated caches.
* Added Update-AzRedisEnterpriseCacheDatabaseDbRedisVersion to upgrade the redis database version directly.

#### Az.ResourceGraph 1.0.1
* Migrated ResourceGraph SDK to generated SDK
  - Removed 'Microsoft.Azure.Management.ResourceGraph' Version '2.1.0' PackageReference
  - Added ResourceGraph.Management.Sdk ProjectReference

#### Az.Resources 7.6.0
* Fixed customer-reported 'Remove-AzPolicyAssignment' behavior.
* Added new cmdlets of DataBoundary

#### Az.ServiceBus 4.0.1
* Migrated ServiceBus SDK to generated SDK
    - Removed 'Microsoft.Azure.Management.ServiceBus' Version '5.0.0' PackageReference
    - Added ServiceBus.Management.Sdk ProjectReference 

#### Az.ServiceLinker 0.2.2
* Used 'Get-AzAccessToken -AsSecureString' inside the 'ServiceLinker' for the plain text version is going to be deprecate in the next release.

#### Az.StackHCI 2.4.1
* added support for new environment

#### Az.Storage 7.5.0
* Added a warning for an upcoming breaking change for download blob will block input parameter -AbsoluteUri and -Context together.
    - 'Get-AzStorageBlobContent'
* Revised AzureStorageBlob construct logic to make it more stable.

#### Az.Terraform 0.1.1
* Fixed descrption for this module

## 12.4.0 - October 2024
#### Az.App 1.1.0
* Added breaking change messages:
  * 'New-AzContainerApp'
  * 'New-AzContainerAppJob'
  * 'Update-AzContainerApp'
  * 'Update-AzContainerAppJob'
* Fixed an issue that caused Get/New-Az* cmdlets with returned objects to incorrectly expose the parameter [-PassThru].
  * 'Get-AzContainerApp'
  * 'Get-AzContainerAppAuthToken'
  * 'Get-AzContainerAppDiagnosticRoot'
  * 'New-AzContainerAppManagedCert'

#### Az.Billing 2.1.0
* Renamed 'Get-UsageAggregates' to 'Get-AzUsageAggregate' and added 'Get-UsageAggregates' as the alias to avoid breaking change.

#### Az.Blueprint 0.4.4
* Removed Microsoft.Azure.Management.Blueprint 0.20.7-preview dependencies
* Added Microsoft.Azure.PowerShell.Blueprint.Management.Sdk

#### Az.Compute 8.4.0
* Added 'SkuProfileVmSize' and 'SkuProfileAllocationStrategy' parameters to 'New-AzVmss', 'New-AzVmssConfig', and 'Update-AzVmss' cmdlets for VMSS Instance Mix operations.
* Added a new optional parameter '-GenerateSshKey-type' to the 'New-AzVM' cmdlet, allowing users to specify the type of SSH key to generate (Ed25519 or RSA).
* Added 'EnableResilientVMCreate' and 'EnableResilientVMDelete' parameters to 'Update-AzVmss' and 'New-AzVmssConfig' cmdlets for enhanced VM resilience options.
* Added 'IsVMInStandByPool' property to 'PSVirtualMachineInstanceView' object. [#25736]

#### Az.ConnectedKubernetes 0.11.0
* Added support for Workload Identity Federation and OIDC Issuer features to the ConnectedKubernetes cmdlets.
* Added support for arc gateway feature in cmdlet New-AzConnectedKubernetes.
* Added Set-AzConnectedKubernetes cmdlet to support updateing arc gateway features on existing resource.

#### Az.ConnectedMachine 0.9.0
* Updated the API version to 2024-05-20-preview.

#### Az.CosmosDB 1.15.0
* Added new parameter 'DisableTtl' to 'Restore-AzCosmosDBAccount'.

#### Az.CostManagement 0.3.3
* Fixed an error that values in row could be null when grouping by the value of TagKey in Invoke-AzCostManagementQuery cmdlet. Fix in 0.3.1 accidentally removed from 0.3.2, added it back. [#25948]

#### Az.DataFactory 1.18.8
* Added support for Iceberg format as a sink.
* Enabled sslMode and useSystemTrustStore options for MariaDB.

#### Az.DataMigration 0.14.8
* Removed Microsoft.Azure.Management.DataMigration 0.7.0-preview dependencies
* Added Microsoft.Azure.PowerShell.DataMigration.Management.Sdk

#### Az.ElasticSan 1.1.0
* Supported 'EnforceDataIntegrityCheckForIscsi' for creating and updating volume groups

#### Az.Fabric 0.1.0
* First preview release for module Az.Fabric

#### Az.HDInsight 6.2.1
* Fixed a bug: Error occurs when setting the same assigned identity for storage and esp configurations.

#### Az.IotCentral 0.10.2
* Removed Microsoft.Azure.Management.IotCentral 4.0.0 dependencies
* Added Microsoft.Azure.PowerShell.IotCentral.Management.Sdk

#### Az.KeyVault 6.2.0
* Fixed a parameter validation issue in Set-AzureKeyVaultCertificatePolicy. [#25649]

#### Az.KubernetesRuntime 0.1.0
* First preview release for module Az.KubernetesRuntime

#### Az.ManagementPartner 0.7.4
* Removed Microsoft.Azure.Management.ManagementPartner 1.1.1-preview dependency
* Added Microsoft.Azure.PowerShell.ManagementPartner.Management.Sdk

#### Az.Marketplace 0.5.1
* Removed Microsoft.Azure.Management.Marketplace 1.1.0 dependencies
* Added Microsoft.Azure.PowerShell.Marketplace.Management.Sdk

#### Az.Monitor 5.2.2
* Added breaking change messages:
  * 'New-AzDataCollectionEndpoint'
  * 'New-AzDataCollectionRule'
  * 'Update-AzDataCollectionEndpoint'
  * 'Update-AzDataCollectionRule'
* Updated documentation for 'New-AzActionGroupLogicAppReceiverObject'

#### Az.Network 7.9.0
* Onboarded 'Microsoft.VideoIndexer/accounts' to private link cmdlets
* Added support to create, get and delete Bastion shareable links
    - 'New-AzBastionShareableLink'
    - 'Get-AzBastionShareableLink'
    - 'Remove-AzBastionShareableLink'
* Fixed a bug in cmdlet 'Invoke-AzFirewallPacketCapture' which caused the packet capture request to be stuck in a waiting for activation state. 
* Updated cmdlet to add the property of 'Sensitivity', and updated corresponding cmdlets.
    - 'New-AzApplicationGatewayFirewallPolicyManagedRuleOverride'
* Added support for 'DefaultOutboundAccess' property in 'Set-AzVirtualNetworkSubnetConfig' command
* Added support for 'EnabledFilteringCriteria' property in 'New-AzNetworkWatcherFlowLog' and 'Set-AzNetworkWatcherFlowLog' commands
* Added support of 'UserAssignedIdentityId' Property in 'New-AzNetworkWatcherFlowLog' and 'Set-AzNetworkWatcherFlowLog' commands
* Added support of 'DestinationIPAddress' property in 'New-AzPrivateLinkService' command
    - 'LoadBalancerFrontendIpConfiguration' is not a mandatory parameter anymore.
    - The user can provide either 'LoadBalancerFrontendIpConfiguration' or 'DestinationIPAddress'.

#### Az.RecoveryServices 7.2.0
* Fixed bug for making RecoveryAzureStorageAccountId parameter optional in 'New-ASRReplicationProtectedItem' cmdlet of H2A.

#### Az.Resources 7.5.0
* Added 'ResourceSelector' and 'Override' parameters to 'New/Update-AzPolicyAssignment'.
* Added 'ResourceSelector' parameter to 'New/Update-AzPolicyExemption'.
* Removed 'Experimental' notice from '-WithSource' parameter to 'Publish-AzBicepModule'.

#### Az.StackHCIVM 1.0.5
* Fixed the update issue

#### Az.StandbyPool 0.2.0
* Added new Cmdlets:
  - Get-AzStandbyContainerGroupPoolStatus
  - Get-AzStandbyVMPoolStatus
* Updated existing Cmdlets
  - New-AzStandbyVMPool by add new parameter -MinReadyCapacity to support new added properties in put call.
* Deprecated Cmdlets
  - Get-StandbyVMPoolVM

#### Az.Storage 7.4.0
* Added a warning for an upcoming breaking change for removing references to 'Microsoft.Azure.Storage.File'
    - 'Start-AzStorageFileCopy'

#### Az.Terraform 0.1.0
* First preview release for module Az.Terraform

#### Az.Websites 3.2.2
* Fix bug where parameters could not be set to false for 'Publish-AzWebApp'

#### Az.Workloads 0.3.0
* Split Az.Workloads into two sub-modules

## 12.3.0 - September 2024
#### Az.Accounts 3.0.4
* Added customized UserAgent for ARM telemetry.
* Fixed secrets exposure in example documentation.
* Updated 'Connect-AzAccount' to fix a display issue in PowerShell ISE [#24556].
* Updated the reference of Azure PowerShell Common to 1.3.100-preview.
* Used Azure.Identity and Azure.Core directly for client assertion [#22628].

#### Az.ADDomainServices 0.2.2
* Fixed secrets exposure in example documentation.

#### Az.Aks 6.0.4
* Fixed secrets exposure in example documentation.

#### Az.ApiManagement 4.0.4
* Fixed secrets exposure in example documentation.

#### Az.App 1.0.1
* Fixed secrets exposure in example documentation.

#### Az.AppComplianceAutomation 0.1.1
* Fixed secrets exposure in example documentation.

#### Az.AppConfiguration 1.3.2
* Fixed secrets exposure in example documentation.

#### Az.Astro 0.1.0
* First preview release for module Az.Astro

#### Az.Automanage 1.0.2
* Fixed secrets exposure in example documentation.

#### Az.Batch 3.6.3
* Fixed secrets exposure in example documentation.

#### Az.Cdn 3.2.2
* Added support to enable ManagedIdentity when no BYOC in the classic front door during migration

#### Az.Compute 8.3.0
* Fixed secrets exposure in example documentation.
* References are updated to use 2024-07-01 ComputeRP and 2024-03-02 DiskRP REST API calls.
* Added information on how to find VM Images when using 'New-AzVM' with '-Image' parameter.
* Added 'TimeCreated' read-only field to 'PSVirtualMachineScaleSetVMProfile' object.
* Added parameter '-ResourceIdsOnly' to 'Get-AzCapacityReservationGroup' cmdlet.
* Changed the 'Set-AzVMOperatingSystem' cmdlet when the '-VM' parameter is used without an OSProfile. Now it will not throw a null reference exception when '-Credential' is not provided.
* Added parameter '-ForceDetach' to 'Remove-AzVMDataDisk' cmdlet.

#### Az.ConnectedKubernetes 0.10.3
* Fixed secrets exposure in example documentation.

#### Az.ContainerInstance 4.0.2
* Fixed secrets exposure in example documentation.

#### Az.CosmosDB 1.14.5
* Fixed secrets exposure in example documentation.

#### Az.DataBox 0.3.2
* Fixed secrets exposure in example documentation.

#### Az.Databricks 1.9.0
* Fixed an issue that 'Update-AzDatabricksWorkspace' doesn't work.[#25743]

#### Az.DataFactory 1.18.7
* Supported managed identity for Data Factory Azure File connector.
* Supported ServicePrincipalCert Auth for Data Factory Rest connector.
* Supported ServicePrincipalCert Auth for Data Factory SharePointOnlineList connector.

#### Az.DataMigration 0.14.7
* Fixed secrets exposure in example documentation.

#### Az.DevCenter 1.2.0
* Fixed secrets exposure in example documentation.
* Updated control plane to 2024-05-01-preview and added deprecation warnings

#### Az.DeviceProvisioningServices 0.10.2
* Fixed secrets exposure in example documentation.

#### Az.ElasticSan 1.0.3
* Added warnings for upcoming breaking changes to align the MI best practices.

#### Az.HanaOnAzure 0.3.2
* Fixed secrets exposure in example documentation.

#### Az.HDInsight 6.2.0
* Added new feature: Enable adding public IP tags to clusters. 
* Added commands for manage Azure Monitor Agent
    - Command 'Get-AzHDInsightAzureMonitorAgent' to get the Azure Monitor Agent status of HDInsight cluster.
    - Command 'Enable-AzHDInsightAzureMonitorAgent' to enable the Azure Monitor Agent in HDInsight cluster.
    - Command 'Disable-AzHDInsightAzureMonitorAgent' to disable the Azure Monitor Agent in HDInsight cluster.
    - Command 'Update-AzHDInsightCluster' to update tags or identity for HDInsight cluster.

#### Az.IotHub 2.7.7
* Fixed secrets exposure in example documentation.

#### Az.KeyVault 6.1.0
* Fixed secrets exposure in example documentation.
* Upgraded Get-AzKeyVaultKey for key vault key to track 2 SDK.

#### Az.Maintenance 1.4.3
* Fixed bug where AzMaintenanceConfiguration returned a List object. [#25781]

#### Az.MySql 1.2.1
* Fixed secrets exposure in example documentation.

#### Az.NetAppFiles 0.18.0
* Fixed some minor issues
* Added 'SnapshotName' to 'New-AzNetAppFilesBackup'
* Fixed 'New-AzNetAppFilesBackup', 'Label' is not a requred parameter

#### Az.Network 7.8.1
* Fixed secrets exposure in example documentation.
* Onboarded 'Microsoft.App/managedEnvironments' to private link cmdlets

#### Az.NetworkCloud 1.0.2
* Fixed secrets exposure in example documentation.

#### Az.NotificationHubs 1.1.3
* Fixed secrets exposure in example documentation.

#### Az.Oracle 1.0.0
* General availability for module Az.Oracle

#### Az.PostgreSql 1.1.2
* Fixed secrets exposure in example documentation.

#### Az.Qumulo 0.1.2
* Fixed secrets exposure in example documentation.

#### Az.RecoveryServices 7.1.0
* Added MUA support for CMK Encryption properties of Recovery Services Vault. Updated the  VaultProperty command to use underlying Vault APIs.
* Added additional properties to the output of Get-AzRecoveryServicesVault cmdlet - MoveDetails, MoveState, RedundancySettings, SecureScore, BcdrSecurityLevel, EncryptionProperty.

#### Az.Resources 7.4.0
* Fixed secrets exposure in example documentation.
* 'Remove-AzResourceGroup' - support parameter '[-ForceDeletionType]'.
* Removed specific characters from the codebase to unblock digital signature verification.

#### Az.Security 1.7.0
* Added new cmdlets for defender for storage

#### Az.ServiceFabric 3.3.4
* Fixed secrets exposure in example documentation.

#### Az.SignalR 2.0.2
* Fixed secrets exposure in example documentation.
* Improve the doc for 'Test-AzSignalRName'.

#### Az.Sphere 0.1.2
* Fixed secrets exposure in example documentation.

#### Az.Sql 5.3.0
* Fixed secrets exposure in example documentation.
* Fixed issues regarding Active Directory Administrator in 'Set-AzSqlInstanceActiveDirectoryAdministrator' and 'Set-AzSqlInstance' cmdlets.
* Added new parameter AuthenticationMetadata to 'New-AzSqlInstance' and 'Set-AzSqlInstance'

#### Az.SqlVirtualMachine 2.3.1
* Fixed secrets exposure in example documentation.

#### Az.Storage 7.3.0
* Supported account tier Cold
    - 'New-AzStorageAccount'
    - 'Set-AzStorageAccount'
* Updated Storage account cmdlet output properties Context to be based on OAuth token when the storage account has AllowSharedKeyAccess as false 
    - 'New-AzStorageAccount'
    - 'Set-AzStorageAccount'
    - 'Get-AzStorageAccount'
* Updated list share output display format 
    - 'Get-AzStorageShare'
* Added warnings for upcoming breaking changes in File cmdlets for removing references to 'Microsoft.Azure.Storage.File'
    - 'Close-AzStorageFileHandle'
    - 'Get-AzStorageFile'
    - 'Get-AzStorageFileContent'
    - 'Get-AzStorageFileCopyState'
    - 'Get-AzStorageFileHandle'
    - 'Get-AzStorageShare'
    - 'New-AzStorageDirectory'
    - 'New-AzStorageFileSASToken'
    - 'New-AzStorageShare'
    - 'New-AzStorageShareSASToken'
    - 'Remove-AzStorageDirectory'
    - 'Remove-AzStorageFile'
    - 'Remove-AzStorageShare'
    - 'Rename-AzStorageDirectory'
    - 'Rename-AzStorageFile'
    - 'Set-AzStorageFileContent'
    - 'Set-AzStorageShareQuota'
    - 'Start-AzStorageFileCopy'
    - 'Stop-AzStorageFileCopy'

#### Az.StorageSync 2.3.1
* Fixed the bug in server registration
* Improved the error message for Set-AzStorageSyncServiceIdentity cmdlet

#### Az.Synapse 3.0.10
* Fixed secrets exposure in example documentation.

#### Az.TimeSeriesInsights 0.2.2
* Fixed secrets exposure in example documentation.

#### Az.VMware 0.7.1
* Fixed secrets exposure in example documentation.

#### Az.Workloads 0.2.1
* Fixed secrets exposure in example documentation.

## 12.2.0 - August 2024
#### Az.Accounts 3.0.3
* Reduced the frequency of displaying sign-in announcement messages.
* Upgraded Azure.Core to 1.41.0 to include the fix for 'BearerTokenAuthenticationPolicy'
* Removed the informational table about selected context to avoid duplication with output table.

#### Az.AksArc 0.1.1
* Fixed bug where 'Invoke-AzAksArcClusterUpgrade' would throw false exception when kubernetes version is passed as a parameter. 
* Fixed bug where default nodepool labels and taints parameters would not work for 'New-AzAksArcCluster' command. 

#### Az.Cdn 3.2.1
* Bypassed object id validation for KeyVault access policy during 'Start-AzFrontDoorCdnProfilePrepareMigration'

#### Az.CodeSigning 0.2.0
* Added 'Get-AzCodeSigningCertChain' cmdlet to retrieve the certificate chain for a certificate profile.
* Added System.Formats.Asn1 dependency to the module to address a security vulnerability.

#### Az.Communication 0.4.0
* Added dataplane cmdlets:
    * 'Get-AzEmailServicedataEmailSendResult'
    * 'Send-AzEmailServicedataEmail'
* Upgraded API version to 2023-06-01-preview

#### Az.Compute 8.2.0
* Renamed parameter '-VmId' to '-SourceId' and added '-VmId' as an alias to 'New-AzRestorePointCollection' cmdlet.

#### Az.Databricks 1.8.1
* Fixed Access Connector Resource update for 'Update-AzDatabricksWorkspace'

#### Az.DataFactory 1.18.6
* Added security enhancement feature snowflake support storage integration.
* Supported 'domain' Property In Dynamics Family.
* Enabled UAMI auth for Data Factory Sql Server connector.
* Supported managed identity for Data Factory Azure Table connector.

#### Az.HdInsightOnAks 0.2.0
* Added commands
  - 'New-AzHdInsightOnAksManagedIdentityObject' for create an in-memory object for ManagedIdentitySpec.
  - 'New-AzHdInsightOnAksClusterMavenLibraryObject' for create an in-memory object for Maven library properties.
  - 'New-AzHdInsightOnAksClusterPyPiLibraryObject' for create an in-memory object for PyPi library properties.
  - 'Get-AzHdInsightOnAksClusterPoolUpgradeHistory' for get a list for cluster pool upgrade history.
  - 'Get-AzHdInsightOnAksClusterUpgradeHistory' for get a list for cluster upgrade history.
  - 'Invoke-AzHdInsightOnAksManageClusterLibrary' for manage libraries on cluster.
  - 'Invoke-AzHdInsightOnAksClusterManualRollback' for manual rollback upgrade for a cluster.
* Renamed command 'New-AzHdInsightOnAksClusterPoolAKSUpgradeObject' to 'New-AzHdInsightOnAksClusterPoolAksPatchVersionUpgradeObject'. 
* Separated the Upgrade function from command 'Update-AzHdInsightOnAksCluster', the new command is 'Invoke-AzHdInsightOnAksClusterUpgrade'. 
* Separated the Upgrade function from command 'Update-AzHdInsightOnAksClusterPool', the new command is 'Invoke-AzHdInsightOnAksClusterPoolUpgrade'.

#### Az.Informatica 0.1.0
* First preview release for module Az.Informatica

#### Az.MachineLearningServices 1.1.0
* Updated API version to 2024-04-01
* Added Kind and HubResourceId parameters for Workspace cmdlets
* Fixed batch deployment creation issue
* Fixed Connection creation issue
* Added Connection Properties object cmdlets for connection creation
    - 'New-AzMLWorkspaceAadAuthTypeWorkspaceConnectionPropertiesObject'
    - 'New-AzMLWorkspaceAccessKeyAuthTypeWorkspaceConnectionPropertiesObject'
    - 'New-AzMLWorkspaceAccountKeyAuthTypeWorkspaceConnectionPropertiesObject'
    - 'New-AzMLWorkspaceApiKeyAuthWorkspaceConnectionPropertiesObject'
    - 'New-AzMLWorkspaceCustomKeysWorkspaceConnectionPropertiesObject'
    - 'New-AzMLWorkspaceManagedIdentityAuthTypeWorkspaceConnectionPropertiesObject'
    - 'New-AzMLWorkspaceNoneAuthTypeWorkspaceConnectionPropertiesObject'
    - 'New-AzMLWorkspaceOAuth2AuthTypeWorkspaceConnectionPropertiesObject'
    - 'New-AzMLWorkspacePatAuthTypeWorkspaceConnectionPropertiesObject'
    - 'New-AzMLWorkspaceSasAuthTypeWorkspaceConnectionPropertiesObject'
    - 'New-AzMLWorkspaceServicePrincipalAuthTypeWorkspaceConnectionPropertiesObject'
    - 'New-AzMLWorkspaceUsernamePasswordAuthTypeWorkspaceConnectionPropertiesObject'
* Added Model reference object cmdlets for batch deployment creation
    - 'New-AzMLWorkspaceIdAssetReferenceObject'
    - 'New-AzMLWorkspaceDataPathAssetReferenceObject'
    - 'New-AzMLWorkspaceOutputPathAssetReferenceObject'

#### Az.NetAppFiles 0.17.0
* Updated to api-version 2024-03-01

#### Az.Nginx 1.1.0
* Added feature for auto scaling and upgradeprofile, and nginx configuration analysis

#### Az.Oracle 0.1.0
* First preview release for module Az.Oracle

#### Az.RedisCache 1.10.0
* Added support for Disabling Access Keys Authentication

#### Az.Resources 7.3.0
* Added null check and empty list check to the permissions object in the ToPSRoleDefinition method.
* Added argument completer for 'EnforcementMode', 'IdentityType'
    * 'New-AzPolicyAssignment'
    * 'New-AzPolicyExemption'
    * 'Update-AzPolicyAssignment'
    * 'Update-AzPolicyExemption'
* Fixed bug deserializing property: 'policyDefinitionReferenceId' [#25112] 
* Fixed overriding of Bicep parameters in Deployment cmdlets to support 'SecureString' parameters.
* Added Test cmdlets for Deployment Stacks.

#### Az.Sql 5.2.0
* Added breaking change announcement for cmdlets: 'New-AzSqlInstanceLink', 'Get-AzSqlInstanceLink', 'Remove-AzSqlInstanceLink', 'Update-AzSqlInstanceLink'.
* Added 'IsGeneralPurposeV2' and 'StorageIOps' parameters to 'New-AzSqlInstance', 'Set-AzSqlInstance' to enable the creation of GPv2 instances
* Added IsGeneralPurposeV2 and StorageIOps fields to the model of the managed instance so that it displays information about GPv2 instances that are returned by 'Get-AzSqlInstance'.
* Added new cmdlet 'Set-AzSqlDatabaseReplicationLink' for updating replication link type
* Updated 'Get-AzSqlDatabaseReplicationLink' to use the new sdk

#### Az.StackHCI 2.4.0
* Upgraded API version to 2024-04-01
* Allowed registration for 23H2 and above versions of the device

#### Az.Storage 7.2.0
* Upgraded Microsoft.Azure.Storage.DataMovement to 2.0.5

#### Az.StorageSync 2.3.0
* Fixed the Register-AzStorageSyncServer with Azure FileSync Agent v17
* Improved performance for Managed Identity migration cmdlet

## 12.1.0 - July 2024
#### Az.Accounts 3.0.1
* Disable WAM when the customers login with device code flow or username password (ROPC) flow to prevent a potential issue with token cache.
* Fixed [CVE-2024-35255](https://github.com/advisories/GHSA-m5vv-6r4h-3vj9)
* Updated 'Microsoft.Identity.Client.NativeInterop' to fix the WAM pop window issue in elevated mode [#24967]
* Updated the reference of Azure PowerShell Common to 1.3.98-preview.
* Limited promotional message to interactive scenarios only

#### Az.AksArc 0.1.0
* First preview release for module Az.AksArc

#### Az.AppComplianceAutomation 0.1.0
* First preview release for module Az.AppComplianceAutomation

#### Az.Batch 3.6.2
* Fixed a bug where 'New-AzBatchApplicationPackage' wouldn't work if the application 'AllowUpdates' parameter was set to 'False'.

#### Az.CodeSigning 0.1.2
* Updated signed 3rd party assembly Polly.dll to PSGallery

#### Az.Compute 8.1.0
* Added parameter '-SourceResourceId' to cmdlet 'Add-AzVMDataDisk'.
* Added parameter '-IdentityType' to cmdlet 'Update-AzDiskEncryptionSet'.
* Added 'Invoke-AzSpotPlacementScore' cmdlet, which calls the latest Spot Placement Score API. Set the original 'Invoke-AzSpotPlacementRecommender' as alias to avoid breaking changes.

#### Az.ConnectedMachine 0.8.0
* Updated the API version to 2024-03-31-preview.
* Added cmdlets 'Get-AzConnectedLicense', 'Get-AzConnectedNetworkSecurityPerimeterConfiguration', 'New-AzConnectedLicense', 'New-AzConnectedLicenseDetail', 'Remove-AzConnectedLicense' and 'Set-AzConnectedLicense'.

#### Az.CosmosDB 1.14.4
* Fixed the issue that Azure.Core.AccessToken is used before assigned.

#### Az.Databricks 1.8.0
* Updated the Az Databricks cmdlets to 2024-05-01 api version.

#### Az.DataFactory 1.18.5
* Added UAMI in DynamicsCrm LinkedService

#### Az.DataLakeStore 1.3.2
* Updated signed 3rd party assembly NLog.dll to PSGallery

#### Az.FrontDoor 1.11.1
* Fixed a not converting from string to base in CustomBlockResponseBody bug in updating waf policy

#### Az.Functions 4.1.0
* Upgraded to Microsoft.Web API version 2023-12-01 [#25347]
* Added support for creating function apps on container app [#22736]

#### Az.KeyVault 6.0.1
* Fixed an issue during merging certificate process. [#24323]

#### Az.Maintenance 1.4.2
* Fixed bug where rebootSettings property wasn't updating.

#### Az.Migrate 2.4.0
* Removed 'at lease one NIC needs to be user selected' constrain when creating/updating server replication (protected item)
* Added retries for calls to internal Get commands

#### Az.MySql 1.2.0
* Added cmdlets: 'Get-AzMySqlFlexibleServerAdvancedThreatProtectionSetting' and 'Update-AzMySqlFlexibleServerAdvancedThreatProtectionSetting'

#### Az.NetAppFiles 0.16.0
* Updated to api-version 2023-11-01
* Fixed some minor issues

#### Az.Network 7.8.0
* Added new cmdlets to support Save & Commit (AzureFirewallPolicy draft)
    - 'New-AzFirewallPolicyDraft'
    - 'New-AzFirewallPolicyRuleCollectionGroupDraft'
    - 'Get-AzFirewallPolicyDraft'
    - 'Get-AzFirewallPolicyRuleCollectionGroupDraft'
    - 'Set-AzFirewallPolicyDraft'
    - 'Set-AzFirewallPolicyRuleCollectionGroupDraft'
    - 'Remove-AzFirewallPolicyDraft'
    - 'Remove-AzFirewallPolicyRuleCollectionGroupDraft'
    - 'Deploy-AzFirewallPolicy'
* Added 'NoHealthyBackendsBehavior' to 'PSProbe', and updated corresponding cmdlets.
    - 'New-AzLoadBalancerProbeConfig'
    - 'Add-AzLoadBalancerProbeConfig'
    - 'Set-AzLoadBalancerProbeConfig'
* Upgraded API version to '2024-01-01'
* Updated cmdlet to add 'Premium' as a valid value for 'Sku' parameter and 'enableSessionRecording' feature for Bastion resources
    - 'New-AzBastion'
    - 'Set-AzBastion'
* Updated cmdlet 'Add-AzVirtualNetworkSubnetConfig', 'Set-AzVirtualNetworkSubnetConfig' and 'New-AzVirtualNetworkSubnetConfig' to support Network Identifier for Subnet Service Endpoint.
* Added cmdlet 'Restart-AzNetworkVirtualAppliance' for allowing a restart of Network Virtual Appliance instances from the customer subscription.
* Fixed a bug in 'Update-AzNetworkVirtualApplianceConnection'
* Updated the Azure Firewall and Azure Firewall Policy setter for their respective Private Range properties
  - Fixed a bug that prevented using /32 in private ranges on classic Azure Firewalls
  - Updated the error message to provide a suggested private range when the supplied range is not correctly masked by the host identifier
  - Added a new Allocate function for Azure Firewall that allows allocating customer public ip address to the firewall
  - Fixed a bug that caused firewalls and policies to lose their private range property value when using their 'Get' cmdlets

#### Az.NewRelic 0.2.0
* Updated API version from 2022-07-01 to 2024-01-01.
* Added cmdlets:
    - Get-AzNewRelicBillingInfo
    - Get-AzNewRelicConnectedPartnerResource
    - New-AzNewRelicFilteringTagObject
    - New-AzNewRelicMonitoredSubscription
    - Get-AzNewRelicMonitoredSubscription
    - Remove-AzNewRelicMonitoredSubscription
    - Update-AzNewRelicMonitoredSubscription
    - New-AzNewRelicMonitoredSubscriptionObject
    - Get-AzNewRelicMonitorLinkedResource
* Renamed cmdlet Get-AzNewRelicMonitorAppService to Get-AzNewRelicConnectedPartnerResource.
* Renamed cmdlet Get-AzNewRelicMonitorAppService to Get-AzNewRelicMonitoredAppService.
* Renamed cmdlet Get-AzNewRelicMonitorHost to Get-AzNewRelicMonitoredHost.
* Updated manage identity design.

#### Az.PaloAltoNetworks 0.3.0
* Upgraded managed identity parameters.
* Updated example for new managed identity.

#### Az.Resources 7.2.0
* Fixed 'Set-AzPolicyAssignment' loses description and Display Name [#25362]
* Fixed 'New-AzPolicyAssignment' string ID value handling for parameter '-PolicyDefinition'
* Fixed policy import issue with OP (requires serialization of null values)
* Fixed '-Scope' parameter handling at resource instance level
* Fixed error 'Get-AzPolicySetDefinition'cannot find matched parameter '-Name' [#25334]
* Fixed serialization issue with empty arrays in PolicyParameterObject
* Addressed a rare case where a service principal does not have AppId
* Introduced validation of MG scoped deployment stack during New/Set cmdlet execution.
* Updated Remove/New stack cmdlets with warnings for management groups ActionOnUnmanage and removed DeleteResourcesAndResourceGroups as valid ActionOnUnmanage value.
* Supported get and assign versioned policy definitions and sets
* Fixed syntax incompatible with windows powershell [#24971]
* Fixed bug with 'Get-AzPolicyExemption' requesting 'ParentResourcePath'
* Supported 'ServiceManagementReference' of Entra App
    * 'Get-AzADApplication'
    * 'New-AzADApplication'
    * 'Update-AzADApplication'
* Fixed deployment stack validation error surfacing.
* Fixed default formatting for output objects
* Removed '-InputObject' for
    * 'Get-AzPolicyAssignment'
    * 'Get-AzPolicyDefinition'
    * 'Get-AzPolicyExemption'
    * 'Get-AzPolicySetDefinition'
    * 'New-AzPolicyAssignment'
    * 'New-AzPolicyDefinition'
    * 'New-AzPolicySetDefinition'
* Implemented '-Version' and '-ListVersion' parameters on 'Get-AzPolicyDefinition' and 'Get-AzPolicySetDefinition'

#### Az.Sql 5.1.0
* Added cross-subscription support for 'Copy-AzSqlInstanceDatabase', 'Move-AzSqlInstanceDatabase'
* Added new parameter SecondaryType to 'Add-AzSqlDatabaseFromFailoverGroup'

#### Az.SqlVirtualMachine 2.3.0
* Enabled Microsoft entra id on SQL VM.

#### Az.Storage 7.1.0
* Fixed the issue that Azure.Core.AccessToken is used before assigned.
* Supported TLS1_3 when creating and updating a storage account 
    - 'New-AzStorageAccount'
    - 'Set-AzStorageAccount'
* Fixed sync copy blob issue with -AsJob is specified [#25105]
    - 'Copy-AzStorageBlob'
* Updated Storage.Management.Sdk to support API version 2023-05-01
* Updated 2 help examples of create storage account cmdlet, with MinimumTlsVersion as TLS1_2.
    - 'New-AzStorageAccount'

#### Az.StorageMover 1.4.0
* Added input parameter validation set for UploadLimitWeeklyRecurrenceObject
* Supported Uploaded Limit Schedule

#### Az.Synapse 3.0.9
* Updated Azure.Analytics.Synapse.Artifacts to 1.0.0-preview.20.
* Fixed the issue that Azure.Core.AccessToken is used before assigned.

#### Az.VMware 0.7.0
* Updated the AVS VMware cmdlets api version to '2023-09-01'. 

#### Az.Workloads 0.2.0
* Added trusted access parameter in Create and Register VIS.

## 12.0.0 - May 2024
#### Az.Accounts 3.0.0
* Web Account Manager (WAM) was set the default experience of interactive login. For more details please refer to https://go.microsoft.com/fwlink/?linkid=2272007
* Enabled secrets detection option by default.
* Fixed a null reference issue during the process of 'Get-AzContext -ListAvailable' [#24854].
* Supported interactive subscription selection for user login flow. See more details at [Announcing a new login experience with Azure PowerShell and Azure CLI
](https://techcommunity.microsoft.com/t5/azure-tools-blog/announcing-a-new-login-experience-with-azure-powershell-and/ba-p/4109357)
* Added config 'LoginExperienceV2' to allow customer to switch the default behavior of context selection back. Check the help document of 'Update-AzConfig' for more details.
* Supported auto-discovery of the endpoint of OperationalInsights (azure-powershell-common/pull/414)
* Updated the reference of Azure PowerShell Common to 1.3.94-preview.
* [Breaking Change] Removed config 'DisableErrorRecordsPersistence' to disable writing error records, error recording is now opt-in
* Added config 'EnableErrorRecordsPersistence' to enable writing error records to file system

#### Az.AnalysisServices 1.1.5
* Removed the outdated deps.json file.

#### Az.ApiManagement 4.0.3
* Removed the outdated deps.json file.

#### Az.Batch 3.6.1
* Removed the out-of-date breaking change message for 'Get-AzBatchCertificate' and 'New-AzBatchCertificate'.

#### Az.Billing 2.0.4
* Removed the outdated deps.json file.

#### Az.Blueprint 0.4.3
* Removed the outdated deps.json file.

#### Az.Chaos 0.1.0
* First preview release for module Az.Chaos

#### Az.Compute 8.0.0
* Added new optional parameter 'SecureVMGuestStateSAS' to cmdlet 'Grant-AzDiskAccess'.
* [Breaking Change] Added ValidateNotNullOrEmpty for '-ResourceGroupName' and '-VMScaleSetName' parameters to 'Get-AzVmss' cmdlet. [#20095]
* Added 'Etag' property to PSVirtualMachine and PSVirtualMachineScaleSet objects.   
* Added parameters '-IfMatch' and '-IfNoneMatch' to 'Update-AzVM', 'Update-AzVmss', 'New-AzVm', 'New-AzVmss', 'New-AzVmConfig', and 'New-AzVmssConfig' cmdlets.
* [Breaking Change] Cmdlet 'New-AzGalleryImageDefinition' will default parameter '-HyperVGeneration' to 'V2' if it is not set as 'V1' explicitly, and also default parameter '-Feature' by adding '@{Name='SecurityType';Value='TrustedLaunchSupported'}' if the 'SecurityType' feature is not set explicitly. 
* Resolved the bug with 'New-AzVMConfig' for '-CommunityGalleryImageId' and '-SharedGalleryImageId' parameters.
* [Breaking Change] Added ValidateNotNullOrEmpty for '-ResourceGroupName' and '-VMScaleSetName' parameters to 'Get-AzVmss' cmdlet. [#20095]
* [Breaking Change] Added new business logic to 'New-AzVmss' and 'New-AzVM' cmdlets. When the user explicitly sets the 'SecurityType' to 'Standard', the Image alias defaults to 'Win2022AzureEdition' to make future migrations to Trusted Launch easier.

#### Az.ConnectedVMware 0.1.2
* Fixed the placeholder in psd1 file.

#### Az.CosmosDB 1.14.3
* Removed the out-of-date breaking change message for 'Get-AzCosmosDBAccountKey'.

#### Az.CustomLocation 0.2.0
* Upgraded managed identity parameters.
* Updated example for new managed identity.

#### Az.DataBoxEdge 1.1.1
* Removed the outdated deps.json file.

#### Az.DataFactory 1.18.4
* Updated ADF encryption client SDK version to 5.29.8499.2

#### Az.DataLakeStore 1.3.1
* Removed the outdated deps.json file.

#### Az.DataShare 1.0.2
* Removed the outdated deps.json file.

#### Az.DeviceProvisioningServices 0.10.1
* Removed the outdated deps.json file.

#### Az.DevTestLabs 1.0.3
* Removed the outdated deps.json file.

#### Az.DnsResolver 1.0.0
* General availability for module Az.DnsResolver

#### Az.EdgeZones 0.1.1
* Fixed the placeholder in psd1 file.

#### Az.EventGrid 2.0.0
* Updated to use the 2023-06-01-preview API version.

#### Az.EventHub 5.0.0
* Moved cmdlets to V4

#### Az.FirmwareAnalysis 0.1.3
* Fixed the placeholder in psd1 file.

#### Az.Fleet 0.2.1
* Fixed the placeholder in psd1 file.

#### Az.FrontDoor 1.10.1
* Removed the outdated deps.json file.

#### Az.HPCCache 0.1.2
* Removed the outdated deps.json file.

#### Az.IotCentral 0.10.1
* Removed the outdated deps.json file.

#### Az.IotHub 2.7.6
* Removed the outdated deps.json file.

#### Az.KeyVault 6.0.0
* [Breaking change] Removed the offline fallback policy if specify parameter 'UseDefaultCVMPolicy' in 'Add-AzKeyVaultKey'. Key creation will fail if unable to get regional default CVM SKR policy from MAA Service Discovery API.
* [Breaking change] Removed parameter 'Value' from 'Invoke-AzKeyVaultKeyOperation'.
* [Breaking change] Removed property 'Result' from the output type 'PSKeyOperationResult' of 'Invoke-AzKeyVaultKeyOperation'.
* [Breaking Change] Replaced parameter 'EnableRbacAuthorization' by 'DisableRbacAuthorization' in 'New-AzKeyVault' and 'Update-AzKeyVault'.
    - RBAC will be enabled by default during the process of key vault creation. 

#### Az.KubernetesConfiguration 0.7.2
* Fixed issue that 'New-AzKubernetesExtension' installing Flux fails with error 'Failed to perform resource identity operation' [#22455]

#### Az.MachineLearning 1.1.4
* Removed the outdated deps.json file.

#### Az.MachineLearningServices 1.0.1
* Removed the outdated deps.json file.

#### Az.ManagedNetworkFabric 0.1.2
* Fixed the placeholder in psd1 file.

#### Az.Monitor 5.2.1
* Removed breaking change warning messages for Metric Management Plane
    * Get-AzMetric
    * Get-AzMetricDefinition
    * New-AzMetricFilter

#### Az.Network 7.6.0
* Added cmdlet 'New-AzVirtualApplianceNetworkProfile' to build network profile for network virtual appliance and pass as a parameter.
* Added cmdlet 'New-AzVirtualApplianceNetworkInterfaceConfiguration' and 'New-AzVirtualApplianceIpConfiguration' to build 'New-AzVirtualApplianceNetworkProfile'.
* Added support for ApplicationGatewaySkuFamily 
* Updated cmdlet to add the property of JSChallengeCookieExpirationInMins
    - 'New-AzApplicationGatewayFirewallPolicySetting'
* Added optional property 'HeaderValueMatcher' to 'New-AzApplicationGatewayRewriteRuleHeaderConfiguration'
* Added new cmdlet 'New-AzApplicationGatewayHeaderValueMatcher' to support for the new property 'HeaderValueMatcher'
* Added new cmdlet 'Update-AzVirtualApplianceInboundSecurityRule' to support Inbound Security Rule for Network Virtual Appliance
* Added new cmdlet 'New-AzVirtualApplianceInboundSecurityRulesProperty' to support for the property 'rules' of Inbound Security Rules
* Added AdminState parameter to Load Balancer Backend Address
    - 'New-AzLoadBalancerBackendAddressConfig'
* Updated PS SDK to older SDK removing identity field

#### Az.NetworkFunction 0.1.4
* Changed parsing logic in ATC custom cmdlet

#### Az.OperationalInsights 3.2.1
* Fixed an issue that 'Invoke-AzOperationalInsightsQuery' timed out after 100 seconds. The timeout is now bound to the '-Wait' parameter. (#16553)
* Removed the outdated deps.json file.

#### Az.PrivateDns 1.0.5
* Removed the outdated deps.json file.

#### Az.RecoveryServices 7.0.0
* [Breaking Change] Renamed the property 'ResouceType' of 'ASRVaultSettings' to 'ResourceType'. 

#### Az.RedisCache 1.9.1
* Fixed pattern for access policy resource names

#### Az.ResourceGraph 1.0.0
* General availability for module Az.ResourceGraph

#### Az.Resources 7.1.0
* Fixed deployment and deployment stack New/Set cmdlets to fail if template/parameter uri fails to downloads.
* Deployment Stack cmdlets GA release/updates.
* [Breaking Change] Redesigned CRUD cmdlets for 'PolicyAssignment', 'PolicyDefinition', 'PolicyExemption', 'PolicySetDefinition'. Please see Az 12 migration guide https://learn.microsoft.com/en-us/powershell/azure/migrate-az-12.0.0 for more detail.
* Added null check to the permissions object in the ToPSRoleDefinition method to return if the whole permissions object array is null.

#### Az.ServiceBus 4.0.0
* Moved cmdlets to V4.

#### Az.ServiceFabric 3.3.3
* Updated location of nodeType to use cluster location in stead of resource group location

#### Az.Sphere 0.1.1
* Fixed the placeholder in psd1 file.

#### Az.Sql 5.0.0
* Added multi-secondary support for 'Get-AzSqlDatabaseFailoverGroup', 'Remove-AzSqlDatabaseFromFailoverGroup' and 'Add-AzSqlDatabaseFromFailoverGroup'
* Changed default FailoverPolicy value for 'New-AzSqlDatabaseFailoverGroup', 'Set-AzSqlDatabaseFailoverGroup' from 'Automatic' to 'Manual'
* Added 'ManualCutover' and 'PerformCutover' parameters to 'Set-AzSqlInstance' for Azure Sql Sterling database to Azure Sql Hyperscale database
* Added 'OperationPhaseDetails' parameter to 'Get-AzSqlDatabaseActivity' and updated 'DatabaseOperations' Api to version '2022-11-01-preview' for .Net Sdk

#### Az.Ssh 0.2.1
* Removed the outdated deps.json file.

#### Az.StackHCIVM 1.0.4
* Fixed the placeholder in psd1 file.

#### Az.StandbyPool 0.1.1
* Fixed the placeholder in psd1 file.

#### Az.Storage 7.0.0
* Added a prompt that needs confirmation when upgrading a storage account from StorageV1 or BlobStorage to StorageV2. Can be suppressed with -Force.
    - 'Set-AzStorageAccount'
* Removed references to 'Microsoft.Azure.Storage.Queue' in Queue cmdlets 
    - 'Get-AzStorageQueue'
    - 'New-AzStorageQueue'
    - 'New-AzStorageQueueSASToken'
* When uploading an Azure File with write only SAS token, take the parameter -Path as destination file path, instead of destination directory path previously.
    - 'Set-AzStorageFileContent'

#### Az.StorageAction 0.1.0
* First preview release for module Az.StorageAction

#### Az.Support 2.0.0
* Converted Az.Support to autorest-based module.

#### Az.Synapse 3.0.8
* Upgraded 'Microsoft.DataTransfer.Gateway.Encryption' to '5.29.8499.2'

## 11.6.0 - April 2024
#### Az.Accounts 2.19.0
> [!IMPORTANT]
> Preannouncement: The default interactive login experience will change from browser based to 'Web Account Manager' (WAM) based on supported platforms, [learn more](https://learn.microsoft.com/en-us/entra/msal/dotnet/acquiring-tokens/desktop-mobile/wam). Only interactive login flow is influeced by WAM. This will take effect from the release of **May 21st**.
* Fixed secrets detection issues.

#### Az.ADDomainServices 0.2.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Advisor 2.0.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Aks 6.0.3
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Alb 0.1.3
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.AlertsManagement 0.6.2
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.AppConfiguration 1.3.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.ApplicationInsights 2.2.5
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.ArcResourceBridge 1.0.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Attestation 2.0.2
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Automanage 1.0.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.BareMetal 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Batch 3.6.0
* Added new properties 'ResourceTags'  and 'UpgradePolicy' to 'PSCloudPool' and 'PSPoolSpecification'.
* Added new property 'UpgradingOS' to 'PSNodeCounts'.
* Added new properties 'Caching', 'DiskSizeGB', 'ManagedDisk' and 'WriteAcceleratorEnabled' to 'PSOSDisk'.
* Added new properties 'SecurityProfile' and 'ServiceArtifactReference' to 'PSVirtualMachineConfigurations'.
* Added new property 'ScaleSetVmResourceId' to 'PSVirtualMachineInfo'.

#### Az.BillingBenefits 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.BotService 0.5.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Cdn 3.2.0
* Introduced secrets detection feature to safeguard sensitive data.
* Upgrade API version to 2024-02-01
* Added support to configure rules to scrub PII values from the AFDx logs when new or update a AFDx resource.

#### Az.ChangeAnalysis 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.CloudService 2.0.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Communication 0.3.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Compute 7.3.0
* Added cmdlet 'Invoke-AzSpotPlacementRecommender'.
* Fixed 'Update-AzCapacityReservationGroup' to remove Subscriptions from SharingProfile.

#### Az.ConfidentialLedger 1.0.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Confluent 0.2.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.ConnectedKubernetes 0.10.2
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.ConnectedMachine 0.7.2
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.ConnectedNetwork 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.ConnectedVMware 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.ContainerInstance 4.0.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.ContainerRegistry 4.2.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.CostManagement 0.3.2
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.CustomLocation 0.1.3
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.CustomProviders 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Dashboard 0.1.2
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.DataBox 0.3.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Databricks 1.7.2
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Datadog 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.DataMigration 0.14.6
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.DataProtection 2.4.0
* Added vault tier restore and update backup instance for blobs.
* Added CmkEnryption parameters to Get-AzDataProtectionBackupVault, New-AzDataProtectionBackupVault and Update-AzDataProtectionBackupVault cmdlets.
* Added MUA support for DisableVaultImmutability, Restore, Stop-Protection, Suspend-backup, Disable soft delete operations.

#### Az.DedicatedHsm 0.3.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.DesktopVirtualization 4.3.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.DevCenter 1.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.DeviceUpdate 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.DigitalTwins 0.2.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.DiskPool 0.3.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Dns 1.2.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.DnsResolver 0.2.2
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.DynatraceObservability 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.EdgeOrder 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.EdgeZones 0.1.0
* First preview release for module Az.EdgeZones

#### Az.Elastic 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.ElasticSan 1.0.2
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.EventHub 4.2.2
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.FirmwareAnalysis 0.1.2
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Fleet 0.2.0
* Introduced secrets detection feature to safeguard sensitive data.
* Upgraded managed identity parameters
* Updated example for new managed identity
* Updated command description

#### Az.FluidRelay 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Functions 4.0.8
* Updated logic to populate tab completers and cache in the New-AzFunctionApp cmdlet

#### Az.GraphServices 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.GuestConfiguration 0.11.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.HanaOnAzure 0.3.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.HdInsightOnAks 0.1.2
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.HealthBot 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.HealthcareApis 2.0.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.ImageBuilder 0.4.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.ImportExport 0.2.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.KeyVault 5.3.0
* Introduced secrets detection feature to safeguard sensitive data.
* [Upcoming Breaking Change] Added breaking change warning message for parameter 'UseDefaultCVMPolicy' of 'Add-AzKeyVaultKey'.
    - The offline fallback policy will be removed. Key creation will fail if unable to get regional default CVM SKR policy from MAA Service Discovery API.
* Added parameter 'PolicyPath' in 'Add-AzKeyVaultCertificate' to support custom policy in the process of certificate enrollment. 
* Upgraded the API version of merging certificate to 7.5. [#24323]

#### Az.KubernetesConfiguration 0.7.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Kusto 2.3.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.LabServices 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.LoadTesting 1.0.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Logz 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.ManagedNetworkFabric 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.ManagedServiceIdentity 1.2.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.ManagedServices 3.0.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Maps 0.8.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.MariaDb 0.2.2
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Marketplace 0.5.0
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.MarketplaceOrdering 2.0.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Migrate 2.3.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.MixedReality 0.2.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.MobileNetwork 0.4.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Monitor 5.2.0
* '-Location' parameter was removed from 'Update-AzActionGroup' and 'Update-AzDataCollectionRule' because they do not support updating the location.
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.MonitoringSolutions 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.MySql 1.1.2
* Fixed for various docs erroneously pointing to Postgres instead of MySQL

#### Az.Network 7.5.0
* Added cmdlet 'Convert-AzNetworkWatcherClassicConnectionMonitor' for converting a classic connection monitor to V2 connection monitor.

#### Az.NetworkAnalytics 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.NetworkCloud 1.0.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.NetworkFunction 0.1.3
* Introduced secrets detection feature to safeguard sensitive data.
* Added validation in New/Update collector policy cmdlets to throw exception if ExpressRoute Circuit bandwidth is less than 1G.

#### Az.NewRelic 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Nginx 1.0.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Orbital 0.1.2
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.PaloAltoNetworks 0.2.3
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Peering 0.4.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Portal 0.2.0
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.PostgreSql 1.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.ProviderHub 0.3.0
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Purview 0.2.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Quantum 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Qumulo 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Quota 0.1.2
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.RecoveryServices 6.9.0
* Added support for MUA for disabling vault Immutability, increasing RPO for policy schedule, restore, stop protection with retain data.
* Added support for Enabling/Disabling the azure monitor and email notification alerts for site recovery in recovery services vault.

#### Az.RedisEnterpriseCache 1.2.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Relay 2.0.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Reservations 0.13.0
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.ResourceGraph 0.13.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.ResourceMover 1.2.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Resources 6.16.2
* Introduced secrets detection feature to safeguard sensitive data.
* Migrated SDK generation from autorest csharp to autorest powershell.

#### Az.Security 1.6.2
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.SecurityInsights 3.1.2
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.SelfHelp 0.2.0
* Added support for Discovery NLP API at Subscription and Tenant levels.
* Added support for SelfHelp API and Discovery API at Tenant level.
* Added support for Simplified Solutions API.

#### Az.ServiceBus 3.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.ServiceLinker 0.2.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.SignalR 2.0.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Sphere 0.1.0
* First preview release for module Az.Sphere

#### Az.Sql 4.14.1
* Made 1.2 as default for MinimalTlsVersion when creating new Sql Server from Powershell
* Fixed an existing issue with 'Set-AzSqlInstanceActiveDirectoryAdministrator'

#### Az.SqlVirtualMachine 2.2.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.StackHCI 2.3.2
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.StackHCIVM 1.0.3
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.StandbyPool 0.1.0
* First preview release for module Az.StandbyPool

#### Az.Storage 6.2.0
* Introduced secrets detection feature to safeguard sensitive data.
* Fixed object replication policy time format parsing issue [#24434]
* Updated download offset and content length calculation logic for downloading files 
    - 'Get-AzStorageFileContent'

#### Az.StorageCache 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.StorageMover 1.3.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.StreamAnalytics 2.0.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Subscription 0.11.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Synapse 3.0.7
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.TimeSeriesInsights 0.2.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.VMware 0.6.2
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.VoiceServices 0.1.2
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Websites 3.2.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.WindowsIotServices 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Workloads 0.1.2
* Introduced secrets detection feature to safeguard sensitive data.

## 11.5.0 - April 2024
#### Az.Accounts 2.17.0
* Enabled globally disabling instance discovery before token acquisition [#22535].
* Implemented secrets detection feature for autorest modules.
* Added 'AsSecureString' to 'Get-AzAccessToken' to convert the returned token to SecureString [#24190].
* Upgraded Azure.Core to 1.37.0.

#### Az.Aks 6.0.2
* Fixed the 'Non-static method requires a target' error when updating the image version of the node pool. [#24337]

#### Az.Alb 0.1.2
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.ApplicationInsights 2.2.4
* Fixed the issue that Update-AzApplicationInsights would incorrectly remove existing tags.

#### Az.Attestation 2.0.1
* Fixed vulnerability https://github.com/advisories/GHSA-8g9c-28fc-mcx2

#### Az.CodeSigning 0.1.1
* Upgraded Azure.Core to 1.37.0.

#### Az.Communication 0.3.0
* First preview release for module Az.EmailService

#### Az.Compute 7.2.0
* Added parameters '-scriptUriManagedIdentity', '-outputBlobManagedIdentity', '-errorBlobMangedIdentity', and '-TreatFailureAsDeploymentFailure' to cmdlets 'Set-AzVmRunCommand' and 'Set-AzVmssRunCommand'. 
* Added new parameter '-EnableAutomaticOSUpgrade' to 'New-AzVmss' cmdlet.
* Renamed parameter '-AutoOSUpgrade' to '-EnableAutomaticOSUpgrade' in 'New-AzVmssConfig' cmdlet for consistency. Using '-AutoOSUpgrade' as parameter name will continue to work as it is added as an alias.
* Upgraded Azure.Core to 1.37.0.
* Az.Compute is updated to use the 2023-07-03 GalleryRP, 2024-03-01 ComputeRP and 2023-10-02 DiskRP API.
* Added new parameter '-TierOption' to 'New-AzSnapshotConfig'.
* Added breaking change warnings for the May 2024 release. The warnings are for:
  'New-AzGalleryImageVersion' defaulting to turn on TrustedLaunchSupported and HyperVGeneration to V2.
  'New-AzVM' and 'New-AzVmss' will default to the image 'Windows Server 2022 Azure Edition' instead of 'Windows 2016 Datacenter' by default.
  'Get-AzVmss' will no longer allow empty values to 'ResourceGroupName' and 'VMScaleSetName' to avoid a bug where it will just return nothing.
* Added a new parameter '-SharingProfile' to 'New-AzCapacityReservationGroup' and 'Update-AzCapacityReservationGroup'.
* Added the new parameter 'SourceImageVMId' to the 'New-AzGalleryImageVersion' cmdlet. Also added some error messages for this new parameter and the existing parameter 'SourceImageId'. 

#### Az.ConnectedMachine 0.7.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.ContainerRegistry 4.2.0
* Upgraded Azure.Core to 1.37.0.
* Fixed vulnerability https://github.com/advisories/GHSA-8g9c-28fc-mcx2
* Added exposeToken parameter for Connect-AzContainerRegistry to get token

#### Az.CosmosDB 1.14.2
* Upgraded Azure.Core to 1.37.0.

#### Az.CustomLocation 0.1.2
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.DataFactory 1.18.3
* Added ServiceNowV2, PostgreSqlV2, GoogleBigQuery in ADF
* Fixed headers property schema deserialize issue
* Fixed vulnerability https://github.com/advisories/GHSA-98g6-xh36-x2p7

#### Az.DataMigration 0.14.5
* Changed the Login Migration Console App source to NuGet.org and added versioning support for updating the console app.

#### Az.DataProtection 2.3.0
* Onboarded new workloads AzureDatabaseForPGFlexServer, AzureDatabaseForMySQL for data protection.

#### Az.ElasticSan 1.0.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.EventGrid 1.6.1
* Added breaking change messages due to structure update:
  - The cmdlet 'Set-AzEventGridTopic' will be removed.
  - In the 'Remove-AzEventGridSubscription' parameters will be deprecated.
  - In the 'Get-AzEventGrid*' the parameter 'ODataQuery', 'NextLink', 'ResourceId' will be removed.
  - In the 'New/Update-AzEventGrid*' parameters will be deprecated.

#### Az.EventHub 4.2.1
* Added Breaking Change Warning for parameter datatype change.

#### Az.FirmwareAnalysis 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Fleet 0.1.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.HdInsightOnAks 0.1.1
* Changes in the Cluster Pool
  - Enable create cluster pool with user network profile.
  - Enable get cluster pool available upgrade versions.
  - Enable upgrade cluster pool.
* Changes in the Cluster
  - Enable create Ranger cluster.
  - Enable get cluster available upgrade versions.
  - Enable set internal ingress.
  - Enable upgrade cluster.
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.KeyVault 5.2.2
* Introduced secrets detection feature to safeguard sensitive data.
* Formatted the output of Azure Key Vault certificate in removed state. [#24333]
* [Upcoming Breaking Change] Added breaking change warning message for parameter 'EnableRbacAuthorization' of 'New-AzKeyVault' and 'Update-AzKeyVault'.
    - RBAC will be enabled by default during the process of key vault creation. To disable RBAC authorization, please use parameter 'DisableRbacAuthorization'.
    - Parameter 'EnableRbacAuthorization' is expected to be removed in Az.KeyVault 6.0.0 and Az 12.0.0.
    - Parameter 'EnableRbacAuthorization' is expected to be replaced by  'DisableRbacAuthorization'.
* Upgraded Azure.Core to 1.37.0.

#### Az.MobileNetwork 0.4.0
* Three cmdlets were added: 'Remove-AzMobileNetworkBulkSimDelete', 'Update-AzMobileNetworkBulkSimUpload', 'Update-AzMobileNetworkBulkSimUploadEncrypted'.

#### Az.Monitor 5.1.1
* Added breaking change warning messages for Metric Management Plane
    * Get-AzMetric
    * Get-AzMetricDefinition
    * New-AzMetricFilter

#### Az.NetAppFiles 0.15.2
* Upgraded Azure.Core to 1.37.0.

#### Az.Network 7.4.1
* Fixed a bug caused by the introduction of the new property 'GlobalConfiguration' in 'PSApplicationGateway'

#### Az.PaloAltoNetworks 0.2.2
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.PolicyInsights 1.6.5
* Upgraded Azure.Core to 1.37.0.

#### Az.RecoveryServices 6.8.0
* Added option to set snapshot consistency type in policy cmdlets for creating or updating enhanced AzureVM policies.
* Fixed an issue while setting soft delete vault property. 

#### Az.Resources 6.16.1
* Added null check to the permissions object in the ToPSRoleDefinition method.
* Added dynamic parameters to stack New/Set cmdlets.
* Used correct JSON serializer settings for all templates-related deserialization.

#### Az.Security 1.6.1
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.ServiceBus 3.1.0
* Added Breaking Change Warning for parameter datatype change.

#### Az.StackHCIVM 1.0.2
* Updated API to 2024-01-01 version.
* Introduced secrets detection feature to safeguard sensitive data.

#### Az.Storage 6.1.3
* Introduced secrets detection feature to safeguard sensitive data.
* Upgraded Azure.Core to 1.37.0.
* Fixed upload file with OAuth authentication issue [#24289] 
    - 'Set-AzStorageFileContent'

#### Az.Support 1.0.1
* Added breaking change warning messages for cmdlet deprecation
    - New-AzSupportContactProfileObject
* Added breaking change warning messages for cmdlet rename
    - Get-AzSupportTicketCommunication
    - New-AzSupportTicketCommunication
* Added breaking change warning messages for parameter name and/or structure changes
    - Get-AzSupportService
    - Get-AzSupportProblemClassification
    - Get-AzSupportTicketCommunication
    - Get-AzSupportTicket
    - New-AzSupportTicket
    - Update-AzSupportTicket
* Added breaking change warning messages for output property name and/or structure changes
    - Get-AzSupportService
    - Get-AzSupportTicket
    - New-AzSupportTicket
    - Update-AzSupportTicket
* Added breaking change warning messages for new required parameters
    - New-AzSupportTicket
* Added breaking change warning messages for removed parameters
    - Get-AzSupportTicket
    - Get-AzSupportTicketCommunication
    - New-AzSupportTicket
* Added breaking change warning message for removal of pipe parameter set for list/new
    - New-AzSupportTicketCommunication
    - Get-AzSupportProblemClassification
    - Get-AzSupportTicketCommunication
* Added breaking change warning message for Get-AzSupportTicket retrieving tickets from the past week if no other parameters are specified
    - Get-AzSupportTicket

#### Az.Synapse 3.0.6
* Upgraded Azure.Core to 1.37.0.
* Fixed vulnerability https://github.com/advisories/GHSA-98g6-xh36-x2p7

#### Az.VMware 0.6.1
* Introduced secrets detection feature to safeguard sensitive data.

## 11.4.0 - March 2024
#### Az.Accounts 2.16.0
* Added a preview feature to detect secrets and sensitive information from the output of Azure PowerShell cmdlets to prevent leakage. Enable it by 'Set-AzConfig -DisplaySecretsWarning True'. Learn more at https://go.microsoft.com/fwlink/?linkid=2258844
* Fixed 'CacheDirectory' and 'CacheFile' out-of-sync issue in AzureRmContextSettings.json and the customers are not allowed to change these 2 properties.
* Redirected device code login messages from warning stream to information stream if use device authentication in 'Connect-AzAccount'.

#### Az.Cdn 3.1.2
* Fixed the case sensitive issue when do preparing migration steps for 'Start-AzFrontDoorCdnProfilePrepareMigration'

#### Az.CodeSigning 0.1.0
* First preview release for module Az.CodeSigning

#### Az.Compute 7.1.2
* Fixed 'New-AzVM' when a source image is specified to avoid an error on the 'Version' value.

#### Az.ConnectedMachine 0.7.0
* Added 'ScriptLocalPath' to 'New-AzConnectedMachineRunCommand' to let users add script files locally
* Added 'MachineName' parameter to the McahineExtension and MachineRunCommand models

#### Az.CosmosDB 1.14.1
* Fixed validation issues in same-account collection/container/graph and database/table/Gremlin restores, affecting the following cmdlets:
- Restore-AzCosmosDBSqlDatabase
- Restore-AzCosmosDBSqlContainer
- Restore-AzCosmosDBMongoDBDatabase
- Restore-AzCosmosDBMongoDBCollection
- Restore-AzCosmosDBGremlinDatabase
- Restore-AzCosmosDBGremlinGraph
- Restore-AzCosmosDBTable
* Upgraded SDK 'Azure.Security.KeyVault.Keys' TO 4.6.0-beta.1.
* Added breaking change message for ListConnectionStrings changes

#### Az.DataFactory 1.18.2
* Supported Snowflake V2 in ADF

#### Az.FirmwareAnalysis 0.1.0
* First preview release for module Az.FirmwareAnalysis

#### Az.KeyVault 5.2.1
* Supported 'HsmPlatform' in 'KeyAttributes'.

#### Az.LogicApp 1.5.1
* Removed the *.deps.json file that caused false positive security alerts. [#23603]

#### Az.Marketplace 0.4.0
* Added new features and capabilities to user and marketplace-admins:
    - Approve offer and plans with subscription granularity.
    - Enable\Disable Approve-All-Products on a collection.
    - Fetch all subscriptions in a tenant.
    - Get new plans notifications for the offers in the privatestore.
    - Get all approved offers and plans for a user.

#### Az.Monitor 5.1.0
* Added support for the Metric Data Plane

#### Az.RedisCache 1.9.0
* Upgraded API version to 2023-08-01
* Added support for flush operation
* Added support for update channels
* Added support for Microsoft Entra Authentication

#### Az.Resources 6.16.0
* Added breaking change warnings for Azure Policy cmdlets.
* Added 'AuxTenant' parameter in 'New-AzResourceGroupDeployment'to support cross-tenant deployment.
* Fixed bug with custom types and deployments whatif. [#13245]
* Fixed bug with nullable array parameters & outputs.
* Fixed bug with TemplateParameterUri not downloading parameters correctly.

#### Az.Security 1.6.0
* Added new cmdlets for Security Connectors
* Added new cmdlets for ApiCollections Security

#### Az.StackHCI 2.3.1
* Updated 'Set-AzStackHCI' to use HTTP PATCH for updating cluster resource instead of HTTP PUT and to only send updated properties.

#### Az.StackHCIVM 1.0.1
* Reported image download progress

#### Az.Storage 6.1.2
* Fixed parser logic when downloading blob from managed disk account with Sas Uri and bearer token on Linux and MacOS
    - 'Get-AzStorageBlobContent'
* Added warning messages for upcoming breaking changes in Queue cmdlets for removing references to 'Microsoft.Azure.Storage.Queue'
    - 'New-AzStorageQueue'
    - 'Get-AzStorageQueue'
    - 'New-AzStorageQueueSASToken'
* Added warning messages for an upcoming breaking change when uploading a file using SAS token without read permission 
    - 'Set-AzStorageFileContent'
* Added warning messages for an upcoming breaking change when upgrading a Storage account to StorageV2
    - 'Set-AzStorageAccount'

## 11.3.1 - February 2024
#### Az.Resources 6.15.1
* Fixed deadlock in Bicep CLI execution. [#24133]

## 11.3.0 - February 2024
#### Az.Accounts 2.15.1
* Upgraded the reference of Azure PowerShell Common to 1.3.90-preview.
* Upgraded Azure.Identity to 1.10.3 [#23018].
  - Renamed token cache from 'msal.cache' to 'msal.cache.cae' or 'masl.cache.nocae'.
* Enabled Continue Access Evaluation (CAE) for all Service Principals login methods.
* Supported signing in with Microsoft Account (MSA) via Web Account Manager (WAM). Enable it by 'Set-AzConfig -EnableLoginByWam True'.
* Adjusted output format to be more user-friendly for 'Get-AzContext/Tenant/Subscription' and 'Invoke-AzRestMethod'.
* Fixed the multiple 'x-ms-unique-id' values issue.

#### Az.Aks 6.0.1
* Fixed the resolve path issue in 'Install-AzAksCliTool'.

#### Az.ConnectedKubernetes 0.10.1
* Fixed custom location enable flag issue.

#### Az.DataFactory 1.18.1
* Added metadata Into StoreWriteSettings For Bug Fix
* Supported ADF Warehouse, Mysql V2 and Salesforce V2 in ADF

#### Az.DataMigration 0.14.4
* Added versioning to login migration console app.

#### Az.ElasticSan 1.0.0
* General availability for module Az.ElasticSan

#### Az.KeyVault 5.2.0
* Supported authentication via User Managed Identity by adding parameter 'UseUserManagedIdentity' and making 'SasToken' optional.

#### Az.ManagedNetworkFabric 0.1.0
* First preview release for module Az.ManagedNetworkFabric

#### Az.MariaDb 0.2.1
* Fixed an issue that updating password did not work.

#### Az.Migrate 2.3.0
* Added support for 'Data.Replication'

#### Az.Monitor 5.0.1
* Remove outdated breaking change warning [#24033]

#### Az.NetAppFiles 0.15.0
* Fixed some minor issues
* Updated to api-version 2023-07-01

#### Az.Network 7.4.0
* Fixed a few minor issues
* Updated 'New-AzApplicationGateway' to include 'EnableRequestBuffering' and 'EnableResponseBuffering' parameters
* Changed the Default Rule Set from CRS3.0 to DRS2.1 in 'NewAzureApplicationGatewayFirewallPolicy'
* Added optional property 'Profile' to 'New-AzFirewallPolicyIntrusionDetection' 
* Added new cmdlet to update Connection child resource of Network Virtual Appliance. - 'Update-AzNetworkVirtualApplianceConnection'
* Added support of 'InternetIngressIp' Property in New-AzNetworkVirtualAppliance
* Added the new cmdlet for supporting 'InternetIngressIp' Property with Network Virtual Appliances -'New-AzVirtualApplianceInternetIngressIpsProperty'
* Added a new AuxiliaryMode value 'AuxiliaryMode.Floating'
* Added support for AzureFirewallPacketCapture

#### Az.Nginx 1.0.0
* General availability of 'Az.Nginx' module

#### Az.RecoveryServices 6.7.1
* Added CRR support for taiwannorth, taiwannorthwest region.
* Added breaking change notification for cmdlets whose output type is 'ASRVaultSettings'.
* Added warning for Standard to Enhanced policy migration for AzureVMs.
* Updated Unregister-AzRecoveryServicesBackupContainer cmdlet to ouptput Job object if PassThru not given.
* Fixed issue with Get-AzRecoveryServicesVaultSettingsFile cmdlet to return private endpoint state for backup.

#### Az.Resources 6.15.0
* Supported '-SkipClientSideScopeValidation' in RoleAssignment and RoleDefinition related commands. [#22473]
* Updated Bicep build logic to use --stdout flag instead of creating a temporary file on disk.
* Fixed exception when '-ApiVersion' is specified for 'Get-AzResource', affected by some resource types.

#### Az.SpringCloud 0.3.1
* Added rename notification for Az.SpringCloud module.

#### Az.Sql 4.14.0
* Added 'DatabaseFormat' and 'PricingModel' parameters to 'New-AzSqlInstance', 'Set-AzSqlInstance'
* Added breaking change message for 'New-AzSqlDatabaseFailoverGroup' and 'Set-AzSqlDatabaseFailoverGroup'
    - The default value of 'FailoverPolicy' parameter will be changed from 'Automatic' to 'Manual'
* Added a new cmdlet for Azure SQL Managed Instance refresh external governance status
  - 'Invoke-AzSqlInstanceExternalGovernanceStatusRefresh'
* Updated 'Get-AzSqlInstance' to support returning the 'ExternalGovernanceStatus' property

#### Az.SqlVirtualMachine 2.2.0
* Fixed a bug of parameter 'VirtualMachineResourceId' of cmdlet 'New-AzSqlVM'.

#### Az.StackHCI 2.3.0
* Fixed issue for WAC.
* Restricted registration for 23H2 devices exclusively to cloud deployment.

#### Az.StackHCIVM 1.0.0
* General availability for module Az.StackHCIVM

#### Az.Storage 6.1.1
* Removed some code branches referencing Microsoft.Azure.Storage.Blob
    - 'Get-AzStorageBlob'
* Updated the prompt message when deleting a share snapshot and the output format when listing 
    - 'Remove-AzStorageShare'
    - 'Remove-AzRmStorageSahre'
    - 'Get-AzRmStorageShare'

#### Az.VMware 0.6.0
* Updated api version to '2023-03-01'

#### Az.Websites 3.2.0
* Fixed Ambiguous Positional Argument for 'New-AzWebAppSlot'

## 11.2.0 - January 2024
#### Az.Accounts 2.15.0
* Fixed the authentication issue when using 'FederatedToken' in Sovereign Clouds. [#23742]
* Added upcoming breaking change warning for deprecation of config parameter 'DisableErrorRecordsPersistence'.

#### Az.Alb 0.1.1
* Upgraded API version to 2023-11-01

#### Az.ApplicationInsights 2.2.3
* Enabled common parameter in get-azapplicationinsights 

#### Az.Automation 1.10.0
* Updated Module operation cmdlets to support Powershell 7.2

#### Az.Compute 7.1.1
* Fixed 'New-AzVmss' to correctly work when using '-EdgeZone' by creating the Load Balancer in the correct edge zone.
* Removed references to image aliases in 'New-AzVM' and 'New-AzVmss' to images that were removed.
* Az.Compute is updated to use the 2023-09-01 ComputeRP REST API calls. 

#### Az.ConnectedMachine 0.6.0
* This release, aimed at version 2023-10-03-preview of ConnectedMachine, introduces new commands alongside the existing ones
    - Get-AzConnectedMachineRunCommand: Retrieve run commands for an Azure Arc-Enabled Server
    - New-AzConnectedMachineRunCommand: Create a run command for an Azure Arc-Enabled Server
    - Remove-AzConnectedMachineRunCommand: Delete a run command for an Azure Arc-Enabled Server
    - Update-AzConnectedMachineRunCommand: Modify a run command for an Azure Arc-Enabled Server

#### Az.ContainerRegistry 4.1.3
* Fixed bug in 'Get-AzContainerRegistryManifest' returns only 100 results [#22922]

#### Az.CosmosDB 1.14.0
* Introduced Restore-AzCosmosDBSqlDatabase, Restore-AzCosmosDBSqlContainer to restore deleted database and containers in the same account for SQL.
* Introduced Restore-AzCosmosDBMongoDBDatabase, Restore-AzCosmosDBMongoDBCollection to restore deleted database and collections in the same account for MongoDB.
* Introduced Restore-AzCosmosDBGremlinDatabase, Restore-AzCosmosDBGremlinGraph to restore deleted database and graph in the same account for Gremlin.
* Introduced Restore-AzCosmosDBTable to restore deleted table in the same account.

#### Az.CustomLocation 0.1.1
* Upgraded api version to 2021-08-31-preview.

#### Az.DataProtection 2.2.0
* Added support for Cross region restore for Backup vaults

#### Az.DesktopVirtualization 4.3.0
* Removed AppAttach Cmdlets and ResetIcon parameter to Update-AzWvdApplication

#### Az.DevCenter 1.1.0
* Updated the default parameter set for Get-AzDevCenterUserSchedule to 'list'

#### Az.Fleet 0.1.0
* First preview release for module Az.Fleet

#### Az.HDInsight 6.1.0
* Added new feature: Enable secure channels while creating a new cluster.
* Fixed a bug: When creating a cluster without passing the version, the default version cannot be set to 'default'.

#### Az.KeyVault 5.1.0
* Added parameter 'ByteArrayValue' in 'Invoke-AzKeyVaultKeyOperation' to support operating byte array without conversion to secure string.
* Added Property 'RawResult' in the output type 'PSKeyOperationResult' of 'Invoke-AzKeyVaultKeyOperation'. 
* [Upcoming Breaking Change] Added breaking change warning message for parameter 'Value' in 'Invoke-AzKeyVaultKeyOperation'. 
    - Parameter 'Value' is expected to be removed in Az.KeyVault 6.0.0
    - 'ByteArrayValue' is the alternative of parameter 'Value' in byte array format
* [Upcoming Breaking Change] Added breaking change warning message for the output type 'PSKeyOperationResult' of 'Invoke-AzKeyVaultKeyOperation'. 
    - Property 'Result' is expected to be removed in Az.KeyVault 6.0.0
    - Property 'RawResult' is the alternative of parameter 'Result' in byte array format

#### Az.NetAppFiles 0.14.0
* Fixed some minor issues
* Updated to api-version 2023-05-01
* Added 'EncryptionKeySource', 'KeyVaultKeyName', 'KeyVaultResourceId', 'KeyVaultUri', 'IdentityType', 'UserAssignedIdentity' to 'New-AzNetAppFilesAccount' and 'Update-AzNetAppFilesAccount'
* Added new cmdlets 'Get-AzNetAppFilesNetworkSiblingSet' and 'Update-AzNetAppFilesNetworkSiblingSet' to query and update the network features of a network sibling set
* Added 'CoolAccessRetrievalPolicy' to 'New-AzNetAppFilesVolume' and 'Update-AzNetAppFilesVolume'
* Added 'SmbNonBrowsable' and 'SmbAccessBasedEnumeration' to 'Update-AzNetAppFilesVolume'

#### Az.Network 7.3.0
* Fixed a few minor issues
* Onboarded 'Microsoft.DBforPostgreSQL/flexibleServers' to private link cmdlets
* Fixed missing properties in PSBackendAddressPool

#### Az.PaloAltoNetworks 0.2.1
* Upgraded API version to 2023-09-01

#### Az.RecoveryServices 6.7.0
* Added support Edge zone VM restore
* Added cross zonal restore for snapshot recovery point

#### Az.Resources 6.13.0
* Added AppRoleAssigment related commands for service principal. [#18412]
* Added '-WithSource' parameter to 'Publish-AzBicepModule' for publishing source with a module (currently experimental)
* Supported nullable Bicep parameters in Deployment cmdlets
* Updated Get-AzRoleDefinition to api-version '2022-05-01-preview' and returns ABAC condition information
* Added a couple missing validators and completers to Deployment Stack cmdlets.

#### Az.ServiceFabric 3.3.2
* Fixed Az.ServiceFabric cannot be imported in arm64 platform.

#### Az.Sql 4.13.0
* Fixed 'Set-AzSqlDatabaseFailoverGroup' when going from multi-secondary to single secondary
* Added 'SecondaryComputeModel', 'AutoPauseDelayInMinutes' and 'MinimumCapacity' parameters within 'New-AzSqlDatabaseSecondary'

#### Az.Storage 6.1.0
* Defaults of AllowBlobPublicAccess and AllowCrossTenantReplication when creating a storage account were set to false by server changes. Please refer to https://techcommunity.microsoft.com/t5/azure-storage-blog/azure-storage-updating-some-default-security-settings-on-new/ba-p/3819554
    - 'New-AzStorageAccount'
* Supprted filter when listing file shares with management plane cmdlet 
    - 'Get-AzRmStorageShare'

#### Az.StorageMover 1.3.0
* Renamed SmbFileShare endpoint cmdlets

#### Az.StorageSync 2.1.1
* Updated dataset limit from 5 Tb to 100 Tib.

#### Az.Synapse 3.0.5
* Updated Azure.Analytics.Synapse.Artifacts to 1.0.0-preview.19
* Added ActionOnExistingTargetTable property for Synapse Link Connection

#### Az.Workloads 0.1.1
* Upgraded API version to 2023-10-01-preview

