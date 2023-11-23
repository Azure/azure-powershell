## 11.0.0 - November 2023
#### Az.Accounts 2.13.2
* Enabled in-tool notification for version upgrade by default.
* Upgraded Azure.Core to 1.35.0.

#### Az.Aks 6.0.0
* Removed parameter 'DockerBridgeCidr' from 'New-AzAksCluster'

#### Az.App 1.0.0
* General availability for module Az.App.
* Upgraded api version to 2023-05-01.

#### Az.CloudService 2.0.0
* Downgraded the api version of referenced network to 2021-03-01.

#### Az.CognitiveServices 1.14.1
* Updated SDK via autorest.powershell.

#### Az.Compute 7.0.0
* Added update functionality in 'Update-AzVmss' for parameters 'SecurityType', 'EnableSecureBoot', and 'EnableVtpm' for the parameter set with the Put operation.
* Upgraded Azure.Core to 1.35.0.
* [Breaking change] Removed unversioned and outdated linux image aliases of 'CentOS', 'RHEL', 'UbuntuLTS' and 'Debian'.
* [Breaking change] 'New-AzVmss' will default to 'OrchestrationMode' set as  'Flexible' if it is not set as 'Uniform' explicitly.
* 'New-AzVmss' can now create VMSS with 'OrchestrationMode' set to 'Flexible' using '-SinglePlacementGroup' and '-UpgradePolicy'.
* Removed unversioned and outdated images from New-AzVmss '-ImageName' argument completers.
* [Breaking Change] Added defaulting logic for VM and VMSS creation to set SecurityType to TrustedLaunch and SecureBootEnabled and VTpmEnalbed to true when those are not set by the user.
* [Breaking Change] Added defaulting logic for Disk creation to default to TrustedLaunch when able. Allows the user to turn this off by setting the SecurityType to Standard.
* Added new parameter '-VirtualMachineScaleSetId' to 'Update-AzVm' cmdlet.
* Fixed 'New-AzVmss' and 'New-Azvm' to use 'SharedGalleryImageId' parameter.
* Reduced File Permissions from 0644 to 0600 for SSH Private Key File in 'New-AzVm'.
* Removed GuestAttestaion vm extension installation for Vmss and Vm creation cmdlets. 

#### Az.ContainerInstance 4.0.0
* [Breaking Change] Fixed the typo that output property starting with PreviousState was misspelled as PreviouState. [#22268]

#### Az.ContainerRegistry 4.1.2
* Upgraded Azure.Core to 1.35.0.

#### Az.CosmosDB 1.13.0
* Added new parameter 'EnableBurstCapacity' to 'Update-AzCosmosDBAccount' and 'New-AzCosmosDBAccount'.
* Added new paramater 'MinimalTlsVersion' to 'Update-AzCosmosDBAccount' and 'New-AzCosmosDBAccount'.
* Added new property 'CustomerManagedKeyStatus' to 'Get-AzCosmosDBAccount'.

#### Az.Databricks 1.7.1
* Fixed an issue regarding Custom Managed Key.[#22463] [#22898]

#### Az.DataFactory 1.17.1
* Added ParquetReadSettings in ADF
* Fixed minor issues

#### Az.DesktopVirtualization 4.2.0
* Added cmdlets:
    - 'Get-AzWvdAppAttachPackage'
    - 'Import-AzWvdAppAttachPackageInfo'
    - 'New-AzWvdAppAttachPackage'
    - 'Remove-AzWvdAppAttachPackage'
    - 'Update-AzWvdAppAttachPackage'
* Added Private Link Cmdlets
    - 'Get-AzWvdPrivateEndpointConnection'
    - 'Get-AzWvdPrivateLinkResource'
    - 'Remove-AzWvdPrivateEndpointConnection'
* Added Scaling Plan Personal Schedule cmdlets
    - 'Get-AzWvdScalingPlanPersonalSchedule'
    - 'New-AzWvdScalingPlanPersonalSchedule'
    - 'Remove-AzWvdScalingPlanPersonalSchedule'
    - 'Update-AzWvdScalingPlanPersonalSchedule'
* Added Scaling Plan Pooled Schedule cmdlets
    - 'Get-AzWvdScalingPlanPooledSchedule'
    - 'New-AzWvdScalingPlanPooledSchedule'
    - 'Remove-AzWvdScalingPlanPooledSchedule'
    - 'Update-AzWvdScalingPlanPooledSchedule'
* Updated rampDownCapacityThresholdPct minimum value from 0 to 1 on ScalingPlanPooledSchedule cmdlets
* Added showInFeed property to ApplicationGroups

#### Az.DevCenter 1.0.0
* General availability for module Az.DevCenter

#### Az.Dns 1.2.0
* Added cmdlets:
    - 'Get-AzDnsDnssecConfig'
    - 'New-AzDnsDnssecConfig'
    - 'Remove-AzDnsDnssecConfig'
* Added three new record types, 'DS', 'TLSA' and 'NAPTR'.

#### Az.EventHub 4.2.0
*  Added parameter 'PartitionCount' to 'Set-AzEventHub'

#### Az.Functions 4.0.7
* Used ARM API to get Stacks information for Functions [#14682]
* Removed support to create v3 function apps (Functions v3 has reached EOL) [#20838]
* Removeed Preview flag for Java 17 function apps [#20009]
* Added support to create dotnet-isolated apps [#16349]
* Added support for custom handler [#12542]
* Redacted appsettings output on Get-AzFunctionApp and Update-AzFunctionAppSetting [#23241]

#### Az.HDInsight 6.0.2
* Fixed a bug where the get cluster command does not display abfss storage information.

#### Az.KeyVault 5.0.0
* Removed non-core types creation in PowerShell scripts to be compatible in constrained language mode.
* Supported user assigned identity for Managed HSM in 'New/Update-AzKeyVaultManagedHsm' 
* [Breaking Change] Changed parameter 'SoftDeleteRetentionInDays' in 'New-AzKeyVaultManagedHsm' to mandatory.
* Upgraded Azure.Core to 1.35.0.

#### Az.Kusto 2.3.0
* Supported sandbox custom image
* Supported database CMK
* Supported cluster migration

#### Az.Maintenance 1.4.0
* Added support for maintenance configuration cancellation.

#### Az.Monitor 5.0.0
  * [Breaking Change] Action Group upgraded API version to stable 2023-01-01
  * [Breaking Change] Use new and update cmdlets instead 'Set-AzActionGroup' cmdlet
  * The receiver used subtype cmdlets to create a replacement for command 'New-AzActionGroupReceiver'
    * New-AzActionGroupArmRoleReceiverObject
    * New-AzActionGroupAutomationRunbookReceiverObject
    * New-AzActionGroupAzureAppPushReceiverObject
    * New-AzActionGroupAzureFunctionReceiverObject
    * New-AzActionGroupEmailReceiverObject
    * New-AzActionGroupEventHubReceiverObject
    * New-AzActionGroupItsmReceiverObject
    * New-AzActionGroupLogicAppReceiverObject
    * New-AzActionGroupSmsReceiverObject
    * New-AzActionGroupVoiceReceiverObject
    * New-AzActionGroupWebhookReceiverObject
* [Breaking Change] Data collection Rule upgraded API version to stable 2022-06-01
* [Breaking Change] AMCS removed 'Set-AzDataCollectionRule' cmdlet
* Added cmdlets for data collection endpoint:
    - 'Get-AzDataCollectionEndpoint'
    - 'New-AzDataCollectionEndpoint'
    - 'Remove-AzDataCollectionEndpoint'
    - 'Update-AzDataCollectionEndpoint'

#### Az.Network 7.0.0
* [Breaking Change] Removed 'Geo' as a valid input for parameter 'VariableName' in 'NewAzureApplicationGatewayFirewallCustomRuleGroupByVariable'.
* Added AllowBranchToBranchTraffic property to New-AzRouteServer
* Added AllowBranchToBranchTraffic property to Get-AzRouteServer
* Changed Update-AzRouteServer functionality to fix bugs
    - AllowBranchToBranchTraffic is now a bool
    - Updating HubRoutingPreference property will not effect AllowBranchToBranchTraffic

#### Az.NetworkCloud 1.0.0
* General availability of 'Az.NetworkCloud' module

#### Az.PolicyInsights 1.6.4
* Upgraded Azure.Core to 1.35.0.

#### Az.PowerBIEmbedded 2.0.0
* Removed deprecated workspace collection cmdlets

#### Az.RecoveryServices 6.6.1
* Fixed minor issues

#### Az.RedisCache 1.8.1
* Fixed minor issues

#### Az.Resources 6.12.0
* Supported  statements for user-defined types in Bicep files.
* Fixed reporting duplicate warnings when compiling Bicep files.
* Updated New and Set Management Group cmdlets to allow DeploymentSubscription to be optional.
* Fixed inexplicable error message when subscription and scope are neither provided in RoleAssignment/RoleDefinition related commands. [#22716]

#### Az.Security 1.5.0
* Fixed some minor issues
* Updated Pricing cmdlets to support extensions
    'Get-AzSecurityPricing'
    'Set-AzSecurityPricing'

#### Az.SecurityInsights 3.1.1
* Removed unnecessary breaking change messages.

#### Az.ServiceFabric 3.3.0
* Fixed minor issues

#### Az.Sql 4.11.0
* Added new parameters to 'New-AzSqlDatabaseFailoverGroup', 'Set-AzSqlDatabaseFailoverGroup'
    - PartnerServers
    - ReadOnlyEndpointTargetServer
* Added 'UseFreeLimit' and 'FreeLimitExhaustionBehavior' parameters to 'New-AzSqlDatabase', 'Get-AzSqlDatabase', 'Set-AzSqlDatabase'
* Added new cmdlets for Elastic Job Private Endpoints 'Get-AzSqlElasticJobPrivateEndpoint', 'New-AzSqlElasticJobPrivateEndpoint', 'Remove-AzSqlElasticJobPrivateEndpoint'
* Added new parameters 'WorkerCount', 'SkuName', 'Identity' to 'AzSqlElasticJobAgent' cmdlets
* Added support for optional SQL auth for Elastic Job Agent cmdlets
*   - The following parameters are now optional: 'CredentialName', 'OutputCredentialName', 'RefreshCredentialName'

#### Az.StackHCI 2.2.3
* Added support for ARC Onboarding using Cluster Managed Identity. 
* Removed previous IMDS Reg Key during Registration/Repair-Registration. 
* Removed creation of custom IMDS Reg Key during Arc Enablement.
* Improved logging experience.

#### Az.Storage 6.0.0
* Supported customer initiated migration
* Supported creationTime filter in Blob Inventory
    - 'New-AzStorageBlobInventoryPolicyRule'
* Supported traling dot in Azure file and directory name by default
    - 'Close-AzStorageFileHandle'
    - 'Get-AzStorageFile'
    - 'Get-AzStorageFileCopyState'
    - 'Get-AzStorageFileContent'
    - 'Get-AzStorageFileHandle'
    - 'New-AzStorageDirectory'
    - 'Remove-AzStorageDirectory'
    - 'Remove-AzStorageFile'
    - 'Rename-AzStorageDirectory'
    - 'Rename-AzStorageFile'
    - 'Set-AzStorageFileContent'
    - 'Start-AzStorageFileCopy'
    - 'Stop-AzStorageFileCopy'
* Upgraded Azure.Core to 1.35.0.
* [Breaking Change] Removed prefix '?' of the created SAS token
    - 'New-AzStorageBlobSasToken'
    - 'New-AzStorageContainerSasToken'
    - 'New-AzStorageAccountSasToken'
    - 'New-AzStorageFileSasToken'
    - 'New-AzStorageShareSasToken'
    - 'New-AzStorageQueueSasToken'
    - 'New-AzStorageTableSasToken'
* Migrated following Azure Queue dataplane cmdlets from 'Microsoft.Azure.Storage.Queue 11.2.2' to 'Azure.Storage.Queues 12.16.0'
    - 'New-AzStorageQueue'
    - 'Get-AzStorageQueue'
    - 'Remove-AzStorageQueue'
    - 'New-AzStorageQueueStoredAccessPolicy'
    - 'Get-AzStorageQueueStoredAccessPolicy'
    - 'Set-AzStorageQueueStoredAccessPolicy'
    - 'Remove-AzStorageQueueStoredAccessPolicy'

#### Az.StorageSync 2.1.0
* Fixed minor issues.

#### Az.Synapse 3.0.4
* Upgraded Azure.Core to 1.35.0.

#### Az.TrafficManager 1.2.2
* Fixed some minor issues

#### Az.Websites 3.1.2
* Adjusted 'Publish-AzWebApp' default behavior

### Thanks to our community contributors
* Shivam Bhatnagar (@Bitnagar), fix typos in `Get-AzWvdDesktop.md` (#23072)
* Hiroshi Yoshioka (@hyoshioka0128), Typo "a Azure"→"an Azure" (#23235)
* Varun Dhand (@varundhand), fix: typo in Enter-AzVM.md file (#23093)

## 10.4.1 - September 2023
#### Az.Resources 6.11.1
* Reverted commits that caused regression in 'Get-AzRoleAssignment'. [#22863]

## 10.4.0 - September 2023
#### Az.Accounts 2.13.1
* Added the module name in breaking change messages 
* Upgraded Microsoft.ApplicationInsights version from 2.13.1 to 2.18.0 

#### Az.Cdn 3.1.1
* Customized output property for 'Get-AzCdnEdgeNode' command

#### Az.ContainerInstance 3.2.2
* Added breaking change warning message for 'Get/New/Remove-ContainerGroup', 'New-ContainerInstanceInitDefinitionObject', 'New-ContainerInstanceObject' [#22268]
    - Output properties starting with 'PreviouState' will be corrected to 'PreviousState'

#### Az.DataProtection 2.1.0
* Added soft delete and MUA feature for Backup vaults

#### Az.KeyVault 4.12.0
* Supported splitting 'Import-AzKeyVaultSecurityDomain' process into three steps to allow keys to be hidden offline.
    - Added 'DownloadExchangeKey', 'RestoreBlob' and 'ImportRestoredBlob' in 'Import-AzKeyVaultSecurityDomain'.

#### Az.RecoveryServices 6.6.0
* Added support for custom RG with suffix while creating or modifying policy for workload type AzureVM.
* Added TLaD warning https://aka.ms/TLaD for Azure Site Recovery and Backup.
* Added support for setting AlwaysON soft delete state for recovery services vault.

#### Az.ResourceMover 1.2.0
* Upgraded API version to 2023-08-01.
* Improved error reporting to the customer using custom cmdlets to handle the error in a better manner.

#### Az.Resources 6.11.0
* Supported 'TemplateParameterFile' to accept a '.bicepparam' file.
* Fixed inexplicable error message when subscription and scope are neither provided in 'Get-AzRoleDefinition'. [#22716]

#### Az.SecurityInsights 3.1.0
* Fixed parameters' issues for 'New-AzSentinelAlertRule' and 'Update-AzSentinelAlertRule' [#21181][#21217][#22318]

#### Az.StackHCI 2.2.0
* Bug fixes for Attestation commands.
* Added support for installing mandatory extensions on HCI OS 22H2 and removed confirmation prompt for consent.
* Added ability to customize the location of logs generated during registration.
    - Custom log location can be specified by specifying an optional '-LogsDirectory' parameter in 'Register-AzStackHCI'.
    - 'Get-AzStackHCILogsDirectory' can be used to obtain the log location.
* Increased retry count for setting up ARC integration.

#### Az.Storage 5.10.1
* Added warning messages for an upcoming breaking change that the output Permissions will be changed to a string when creating and updating a Queue access policy
    - 'Get-AzStorageQueueStoredAccessPolicy'
    - 'Set-AzStorageQueueStoredAccessPolicy'

## 10.3.0 - September 2023
#### Az.Accounts 2.13.0
* Supported in-tool notification for version upgrade.
* Added an alias 'Set-AzConfig' to 'Update-AzConfig'
* Refilled credentials from 'AzKeyStore' when run 'Save-AzContext' [#22355]
* Added config 'DisableErrorRecordsPersistence' to disable writing error records to file system [#21732]
* Updated Azure.Core to 1.34.0.

#### Az.ArcResourceBridge 1.0.0
* General availability for module Az.ArcResourceBridge

#### Az.Compute 6.3.0
* Added '-Hibernate' switch parameter to 'Stop-AzVmss' default parameter set. 
* For 'Get-AzVmRunCommand', a bug is fixed to work when returning a list of RunCommands [#22403]
* Updated Azure.Core to 1.34.0.
* Added new cmdlets 'Get-AzHostSize' and 'Update-AzHost'.
* Added the 'Standard' value to the 'SecurityType' parameter to the cmdlets 'Set-AzDiskSecurityType', 'New-AzvmssConfig', 'Set-AzVmssSecurityProfile', 'Update-AzVmss', 'New-AzVmss', 'New-AzVMConfig', 'Set-AzVMsecurityProfile', and 'New-AzVM'.
* Fixed 'Update-AzVMSS' to update ImageReferenceSKU [#22195]
* Updated the above change to include 'New-AzVMConfig' as 1 scenario was initially missed when only using this cmdlet.

#### Az.ContainerInstance 3.2.1
* Fixed a bug in 'Invoke-AzContainerInstanceCommand' when no result was returned under some conditions [#22453]

#### Az.ContainerRegistry 4.1.1
* Updated Azure.Core to 1.34.0.

#### Az.CosmosDB 1.12.0
* Added PublicNetworkAccess parameter to 'Restore-AzCosmosDBAccount'.

#### Az.DataLakeAnalytics 1.0.3
* Refreshed module to ensure catalog file signed by Microsoft.

#### Az.EventHub 4.1.0
* Supported EventHub MSI capture feature in cmdlets 'New-AzEventHub' and 'Set-AzEventHub'

#### Az.HDInsight 6.0.1
* This change adds some warning messages to the incoming break changes for the next version, with detailed information as follows:
  * Added warning message for planning to replace the type of property 'DiskEncryption' of type 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster' from 'Microsoft.Azure.Management.HDInsight.Models.DiskEncryptionProperties' to 'Azure.ResourceManager.HDInsight.Models.HDInsightDiskEncryptionProperties'.
  * Added warning message for planning to replace the type of property 'WorkerNodeDataDisksGroups' of type 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster'  from 'List<Microsoft.Azure.Management.HDInsight.Models.DataDisksGroups>' to 'List<Azure.ResourceManager.HDInsight.Models.HDInsightClusterDataDiskGroup>'.
  * Added warning message for planning to replace the parameter 'NodeType' type from 'Microsoft.Azure.Management.HDInsight.Models.ClusterNodeType' to 'Microsoft.Azure.Commands.HDInsight.Models.Management.RuntimeScriptActionClusterNodeType'.

#### Az.KeyVault 4.11.0
* Fixed certificate policy bugs if DnsName is null. [#22642]
* Supported multi-regions for Managed Hsm: Added 'Add/Get/Remove-AzAzKeyVaultManagedHsmRegion'.
* Added 'Test-AzKeyVaultNameAvailability' and 'Test-AzKeyVaultManagedHsmNameAvailability'.
* Formatted the table view of '*-AzKeyVault', '*-AzKeyVaultKey' and '*-AzKeyVaultSecret'
* Added 'SecurityDomain' and 'Regions' properties into the output of 'New/Update/Get-AzKeyVaultManagedHsm' ('PSManagedHsm').
* Supported Setting for Managed HSM: Added 'Get-AzKeyVaultSetting' and 'Update-AzKeyVaultSetting'.
* Updated Azure.Core to 1.34.0.

#### Az.Maintenance 1.3.1
* Fixed breaking change information

#### Az.Media 1.1.2
* Refreshed module to ensure catalog file signed by Microsoft.

#### Az.Monitor 4.6.0
* Fixed 'Get-AzInsightsPrivateLinkScope' to support 'ResourceId' parameter [#22568]
* Fixed 'New-AzMetricAlertRuleV2DimensionSelection' to have 'exclude' or 'include' values only [#22256]
* Fixed 'Add-AzMetriAlertRuleV2' and 'Get-AzMetricAlertRuleV2' to support web tests criteria [#22350]
* Added parameter 'Dimension' for 'Get-AzMetric' to easily filter metrics by dimensions [#22320]
* Added breaking change for Data Collection Rule
* Added breaking change for Action Group

#### Az.Network 6.2.0
* Added support for new Application Gateway SKU type, Basic SKU
* Onboarded 'Microsoft.EventGrid/partnerNamespaces' to private link cmdlets
* Onboarded 'Microsoft.EventGrid/namespaces' to private link cmdlets
* Fixed bug in 'NewAzureApplicationGatewayFirewallCustomRuleGroupByVariable' to add 'GeoLocation' as a valid input for VariableName
* Added breaking change message for parameter 'VariableName' in 'NewAzureApplicationGatewayFirewallCustomRuleGroupByVariable' to remove 'Geo' as a valid input.

#### Az.NotificationHubs 1.1.2
* Refreshed module to ensure catalog file signed by Microsoft.

#### Az.PolicyInsights 1.6.3
* Updated Azure.Core to 1.34.0.

#### Az.RecoveryServices 6.5.1
* Added StorageAccountName property to AzureFileShare job.
* Added support for AFS restore to alternate storage account in different region and resource group than source storage account.

#### Az.Resources 6.10.0
* Added breaking change warnings for Azure Policy cmdlets.
* Implemented logic that allows Deployment Stack objects to be piped into Save and Remove Deployment Stack cmdlets.

#### Az.SecurityInsights 3.0.2
* Added breaking change message for 'Az.SecurityInsights'.

#### Az.Sql 4.10.0
* Fixed cmdlets to use 2018-06-01-preview api version
    - 'Set-AzSqlInstanceDatabaseSensitivityClassification',
    - 'Remove-AzSqlInstanceDatabaseSensitivityClassification',
    - 'Enable-AzSqlInstanceDatabaseSensitivityRecommendation',
    - 'Disable-AzSqlInstanceDatabaseSensitivityRecommendation',
* Added 'EncryptionProtectorAutoRotation' parameter to 'New-AzSqlDatabase', 'Get-AzSqlDatabase', 'Set-AzSqlDatabase', 'New-AzSqlDatabaseCopy', 'New-AzSqlDatabaseSecondary', 'Restore-AzSqlDatabase' cmdlets

#### Az.SqlVirtualMachine 2.1.0
* Added more parameters on cmdlet 'Update-AzSqlVM'.

#### Az.StackHCI 2.1.2
* Removed device type check and only check if service already exists.

#### Az.Storage 5.10.0
* Updated Azure.Core to 1.34.0.
* Added support for encryption context 
    - 'New-AzDataLakeGen2Item'
* Updated warning messages for an upcoming breaking change when creating a storage account 
    - 'New-AzStorageAccount'
* Updated help file of 'New-AzStorageQueueSASToken'

#### Az.Synapse 3.0.3
* Updated Azure.Core to 1.34.0.
* Updated Azure.Analytics.Synapse.Artifacts to 1.0.0-preview.18

#### Az.Websites 3.1.1
* Added support for XenonMV3 webapps

## 10.2.0 - August 2023
#### Az.Accounts 2.12.5
* Changed output stream from debug stream to warning stream for 'CmdletPreviewAttribute'
* Decreased the prompted frequency of preview warning message to once per cmdlet in one session  
* Reworded default preview message and added estimated GA date for 'CmdletPreviewAttribute'
* Updated Azure.Core to 1.33.0

#### Az.AppConfiguration 1.3.0
* Added cmdlets to support data plane operation:
  - 'Get-AzAppConfigurationKey'
  - 'Get-AzAppConfigurationKeyValue'
  - 'Get-AzAppConfigurationLabel'
  - 'Get-AzAppConfigurationRevision'
  - 'Remove-AzAppConfigurationKeyValue'
  - 'Remove-AzAppConfigurationLock'
  - 'Set-AzAppConfigurationKeyValue'
  - 'Set-AzAppConfigurationLock'
  - 'Test-AzAppConfigurationKeyValue'

#### Az.Batch 3.5.0
* Removed cmdlets: 'Get-AzBatchPoolStatistic' and 'Get-AzBatchJobStatistic'
* Deprecated cmdlets: 'Get-AzBatchCertificate' and 'New-AzBatchCertificate'
  - The Batch account certificates feature is deprecated. Please transition to using Azure Key Vault to securely access and install certificates on your Batch pools, [learn more](https://learn.microsoft.com/azure/batch/batch-certificate-migration-guide)

#### Az.Compute 6.2.0
* Fixed the 'Update-AzVmss' cmdlet so the 'AutomaticRepairGracePeriod', 'AutomaticRepairAction', and 'EnableAutomaticRepair' parameters function correctly.
* Updated help doc for 'New-AzVM', 'New-AzVMConfig', 'New-AzVmss', 'New-AzVmssConfig', 'Update-AzVM', and 'Update-AzVmss' to include parameters that were previously added for Trusted Launch features.
* Updated Azure.Core to 1.33.0.

#### Az.ContainerRegistry 4.1.0
* Updated Azure.Core to 1.33.0.
* Added new cmdlet 'New-AzContainerRegistryCredentials'

#### Az.CosmosDB 1.11.2
* Updated Azure.Core to 1.33.0.

#### Az.Databricks 1.7.0
* Added some parameters in 'Update-AzDatabricksWorkspace':
    - 'EnableNoPublicIP'
    - 'PublicNetworkAccess'

#### Az.DataFactory 1.17.0
* Added DisablePublish to Set_AzDataFactoryV2 Command

#### Az.Dns 1.1.3
* Removed length validation for DNS TXT record to make it consistent with Azure CLI and Azure portal.

#### Az.KeyVault 4.10.1
* Removed maximum number for 'IpAddressRange' and 'VirtualNetworkResourceId' in '*-AzKeyVaultNetworkRuleSet*' from client side. [#22137]
* Updated Azure.Core to 1.33.0.

#### Az.Maintenance 1.3.0
* Added support for Resource Group and Subscription configuration assignment.

#### Az.Network 6.1.1
* Onboarded 'Microsoft.ElasticSan/elasticSans' to private link cmdlets

#### Az.PolicyInsights 1.6.2
* Updated Azure.Core to 1.33.0.

#### Az.PrivateDns 1.0.4
* Removed length validation for DNS TXT record to make it consistent with Azure CLI and Azure portal.

#### Az.Resources 6.9.0
* Fixed the issue that 'New-AzRoleAssignment' didn't work without subscription.
* Added cmdlets for group owner
    - 'Get-AzADGroupOwner'
    - 'New-AzADGroupOwner'
    - 'Remove-AzADGroupOwner'
* Updated Tags functionality in deployment stacks New and Set cmdlets

#### Az.Sql 4.9.0
* Added new cmdlets for Azure SQL Managed Instance start/stop schedule
    - 'Start-AzSqlInstance',
    - 'Stop-AzSqlInstance',
    - 'Get-AzSqlInstanceStartStopSchedule',
    - 'New-AzSqlInstanceStartStopSchedule',
    - 'Remove-AzSqlInstanceStartStopSchedule',
    - 'New-AzSqlInstanceScheduleItem'

#### Az.StackHCI 2.1.0
* Updated to api-version 2023-03-01.
* Cmdlets added:
    - Invoke-AzStackHciExtendClusterSoftwareAssuranceBenefit : Enable Software Assurance for a cluster
    - Invoke-AzStackHciConsentAndInstallDefaultExtensions : Consent to installing default extensions on the cluster

#### Az.Storage 5.9.0
* Supported OAuth authentication on File service cmdlets
    - 'New-AzStorageContext'
    - 'Get-AzStorageFile'
    - 'Get-AzStorageFileContent'
    - 'Get-AzStorageFileCopyState'
    - 'New-AzStorageDirectory'
    - 'Remove-AzStorageDirectory'
    - 'Remove-AzStorageFile'
    - 'Set-AzStorageFileContent'
    - 'Start-AzStorageFileCopy'
    - 'Stop-AzStorageFileCopy'
    - 'Get-AzStorageFileHandle'
    - 'Close-AzStorageFileHandle'
* Supported get a file share object without get share properties. For pipeline to file/directory cmdlets with OAuth authentication.
    - 'Get-AzStorageShare'
* Updated Azure.Core to 1.33.0.

#### Az.Synapse 3.0.2
* Updated Azure.Core to 1.33.0.

#### Az.Websites 3.1.0
* Added AppServicePlan management support for P0V3 and P*mv3 tiers

### Thanks to our community contributors
* Dante Stancato (@dantecit0), Update Set-AzFirewall.md (#22224)
* Hiroshi Yoshioka (@hyoshioka0128), Typo "flexible server"→"Flexible Server" (#22215)
* @Jingshu918, [DataFactory]Added DisablePublish to Set_AzDataFactoryV2 Command (#22273)
* Miguel Vega (@miguel-vega), Updated Example 3 of the Connect-AzAccount.md page to use the correct PowerShell variable. (#22376)
* @Skatterbrainz, Update Remove-AzVM.md (#22378)
* @veppala, added examples for New-AzSqlVM cmdlet (#22185)
* @vladik-hbinov, Fixed Example 2 (#22193)

## 10.1.0 - July 2023
#### Az.Accounts 2.12.4
* Changed 'gallery' property to be optional in ARM metadata of 'Set-AzEnvironment' and 'Add-AzEnvironment'[#22037].

#### Az.Aks 5.5.1
* Fixed the issue of handling 'nextLink' in 'Set-AzAksCluster'. [#21846]
* Fixed the issue of parameter 'AcrNameToDetach' in 'Set-AzAksCluster' due to role assignment name is a guid.
* Added breaking change message for parameter 'DockerBridgeCidr' in 'New-AzAksCluster'.
* Supported the value 'AzureLinux' for parameter '-NodeOsSKU' in 'New-AzAksCluster' and parameter '-OsSKU' in 'New-AzAksNodePool'.
* Fixed the issue of '-DisableLocalAccount' for 'Set-AzAksCluster'. [#21835]

#### Az.Billing 2.0.3
* Fixed page continuation for Consumption PriceSheet cmdlet

#### Az.Cdn 3.1.0
* Upgraded API version to 2023-05-01
* Fixed known issue for 'Update-AzCdnProfile', 'Update-AzFrontDoorCdnProfile', 'Remove-AzCdnProfile', 'Remove-AzCdnProfile'

#### Az.CognitiveServices 1.14.0
* Updated CognitiveServices PowerShell to use 2023-05-01 version.

#### Az.Compute 6.1.0
* Added useful examples to the 'New-AzVMConfig' help doc.
* Added new 'ResourceId' parameter to the 'Get-AzVmss' cmdlet.
* Added '-SecurityType', '-EnableSecureBoot' and '-EnableVtpm' parameters to 'New-AzVm','New-AzVmConfig', 'New-AzVmss', 'New-AzVmssConfig', 'Update-AzVm' and 'Update-AzVmss' cmdlets.
* Configured parameter flags '-EnableSecureBoot' and '-EnableVtpm' to default to True for TrustedLaunch and ConfidentialVM values for the '-SecurityType' parameter in 'New-AzVm','New-AzVmConfig', 'New-AzVmss', 'New-AzVmssConfig', 'Update-AzVm' and 'Update-AzVmss' cmdlets.
* Added a message to the user when they provide an outdated image alias to 'New-AzVM' via the '-Image' parameter or to 'New-AzVmss' via the '-ImageName' parameter.
  The non-versioned image aliases were updated to versioned values in October 2023, and this message is to help urge customers to use the newer versioned image alias values.
* Changed the installation behavior for the 'GuestAttestation' extension in 'New-AzVM' and 'New-AzVmss' to set the property 'EnableAutomaticUpgrade' to true.
* Changed to 'Set-AzVMOperatingSystem' to correct unnecessary mandatory parameters.

#### Az.CosmosDB 1.11.1
* Locations showed in response included status, isSubscriptionRegionAccessAllowedForRegular and isSubscriptionRegionAccessAllowedForAz properties

#### Az.Databricks 1.6.0
* Added some parameters in the 'New-AzDatabricksWorkspace' and 'Update-AzDatabricksWorkspace'.
    - 'ManagedDiskKeyVaultPropertiesKeyName'
    - 'ManagedDiskKeyVaultPropertiesKeyVaultUri'
    - 'ManagedDiskKeyVaultPropertiesKeyVersion'
    - 'ManagedDiskRotationToLatestKeyVersionEnabled'
    - 'ManagedServicesKeyVaultPropertiesKeyName'
    - 'ManagedServicesKeyVaultPropertiesKeyVaultUri'
    - 'ManagedServicesKeyVaultPropertiesKeyVersion'
    - 'Authorization'
    - 'UiDefinitionUri'
* Added some parameters in the 'Update-AzDatabricksVNetPeering'.
    - 'DatabricksAddressSpacePrefix'
    - 'DatabricksVirtualNetworkId'
    - 'RemoteAddressSpacePrefix'
    - 'RemoteVirtualNetworkId'

#### Az.Migrate 2.2.0
* Fixed key vault SPN Id coming as null for some users
* Added support for Windows Server OS upgrade while migrating the server to Azure using Azure Migrate
* Updated OsUpgradeVersion parameter for Azure Migrate

#### Az.MySql 1.1.1
* Fixed iops and high availability parameters issue

#### Az.Network 6.1.0
* Added new cmdlets to get Connection child resource of Network Virtual Appliance.
    -'Get-AzNetworkVirtualApplianceConnection'
* Updated cmdlets to return connections in Network Virtual Appliance
    -'Network Virtual Appliance'
* Allowed not to provide 'Rules' in 'PSApplicationGatewayFirewallPolicyManagedRuleGroupOverride', which would return an empty 'RuleID' to be passed to NRP.
* Added optional parameter 'AdminState' to Express Route Virtual Network Gateway
* Fixed bug that caused 'Remove-AzApplicationGatewayAutoscaleConfiguration' to always fails
* Added read-only property 'DefaultPredefinedSslPolicy' in PSApplicationGateway
* Updated cmdlet to added optional parameter 'DomainNameLabelScope' to Public Ip Address
    - 'New-AzPublicIpAddress'
* Fixed bug where HubRoutingPreference didn't show up when running 'Get-AzRouteServer'
* Updated 'New-AzVirtualNetworkGateway' to remove validation for 'ExtendedLocation' parameter

#### Az.RecoveryServices 6.5.0
* Added CRR support for new regions malaysiasouth, chinanorth3, chinaeast3, jioindiacentral, jioindiawest.
* Regenerated CRR SDK. Fixed issues with SQL CRR.
* Fixed bug with rp expiry time, making 30 days expiry time for adhoc backup as default from client side.
* Added example to fetch pruned recovery points after modify policy.
* Fixed the documentation for suspend backups with immutability.

#### Az.RedisCache 1.8.0
* Upgraded API version to 2023-04-01

#### Az.Resources 6.8.0
* Fixed the incorrect behavior of pagination for 'Get-AzTag'
* Updated API version to 2022-09-01
* Added Deployment Stacks cmdlets
* Added support for dynamic parameters when deploying symbolic name templates.
* Fixed 'Set-AzPolicyExemption' parameter PolicyDefinitionReferenceId not accept empty array.
* Fixed 'Get-AzPolicyExemption' output not contain system data.

#### Az.Sql 4.8.0
* Added 'TryPlannedBeforeForcedFailover' parameter to 'Switch-AzSqlDatabaseFailoverGroup'
* Added new cmdlets for managed database move and copy operations
    - 'Copy-AzSqlInstanceDatabase'
    - 'Move-AzSqlInstanceDatabase'
    - 'Complete-AzSqlInstanceDatabaseCopy'
    - 'Stop-AzSqlInstanceDatabaseCopy'
    - 'Complete-AzSqlInstanceDatabaseMove'
    - 'Stop-AzSqlInstanceDatabaseMove'
    - 'Get-AzSqlInstanceDatabaseMoveOperation'
    - 'Get-AzSqlInstanceDatabaseCopyOperation'

#### Az.Storage 5.8.0
* Supported TierToCold and TierToHot in Storage account management policy
    - 'Add-AzStorageAccountManagementPolicyAction'
* Supported Blob Tier Cold
    - 'Copy-AzStorageBlob'
    - 'Set-AzStorageBlobContent'
    - 'Start-AzStorageBlobCopy'
* Migrated the following Azure Queue dataplane cmdlets from 'Microsoft.Azure.Storage.Queue' to 'Azure.Storage.Queue'
    - 'New-AzStorageQueueSASToken'
* Added warning messages for an upcoming breaking change when creating SAS token
    - 'New-AzStorageBlobSasToken'
    - 'New-AzStorageContainerSasToken'
    - 'New-AzStorageAccountSasToken'
    - 'New-AzStorageContext'
    - 'New-AzStorageFileSasToken'
    - 'New-AzStorageShareSasToken'
    - 'New-AzStorageQueueSasToken'
    - 'New-AzStorageTableSasToken'
    - 'New-AzDataLakeGen2SasToken'
* Added a warning message for an upcoming breaking change when creating a storage account
    - 'New-AzStorageAccount'

#### Az.StorageMover 1.0.1
* Fixed the issue of System.Management.Automation.Internal.Host.InternalHost conflicting with system parameter System.Management.Automation.Internal.Host.InternalHost

#### Az.Synapse 3.0.1
* Fixed the issue for 'Start-AzSynapseTrigger/Stop-AzSynapseTrigger' to not throw exception when Request Status is 202

#### Az.TrafficManager 1.2.1
Added a new API 'CheckTrafficManagerNameAvailabilityV2'.

#### Az.Websites 3.0.1
* Increased timeout for Publish-AzWebApp command
* Fixed Set-AzWebApp issue with 'Set-AzWebApp' when piping in Get-AzWebApp object [#21820]
* Added support for the PremiumMV3 tier to 'New-AzAppServicePlan' [#21933]

### Thanks to our community contributors
* Bas Wijdenes (@baswijdenes), Update Get-AzAutomationJob.md (#21984)
* Sebastiaan Koning (@OneAndOnlySeabass), Fix a few typos in Get-AzMarketplaceTerms.md (#21945)
* Hiroshi Yoshioka (@hyoshioka0128)
  * Typo "CosmosDB Account"→"Cosmos DB Account" (#22005)
  * Typo "azure key vault"→"Azure Key Vault" (#22103)

## 10.0.0 - June 2023
#### Az.Accounts 2.12.3
* Updated System.Security.Permissions to 4.7.0.

#### Az.Aks 5.5.0
* Fixed the issue of 'Enable-AzAksAddon' when there are no addons. [#21665]
* Added parameter '-EnableAHUB' for 'New-AzAksCluster' and 'Set-AzAksCluster'
* Added parameter '-WindowsProfileAdminUserPassword' for 'Set-AzAksCluster'

#### Az.Billing 2.0.2
* Fixed skip token for Consumption PriceSheet cmdlet

#### Az.Cdn 3.0.0
* Upgraded API version to 2022-11-01-preview
* Added support to migrate from Azure Front Door (classic) to Azure Front Door Standard and Premium.
* Added support for AFDX upgrade from Standard tier to Premium tier.

#### Az.Compute 6.0.0
* Added new switch parameter 'OSImageScheduledEventEnabled' and string parameter 'OSImageScheduledEventNotBeforeTimeoutInMinutes' to the cmdlets 'New-AzVmssConfig' and 'Update-AzVmss'.
* Fixed an issue that 'Add-AzVhd' throws 'FileNotFoundException' on Windows PowerShell. [#21321]
* Removed the 'NextLink' parameter and parameter set from the 'Get-AzVM' cmdlet.

#### Az.ContainerRegistry 4.0.0
* Updated module to autorest based

#### Az.CosmosDB 1.11.0
* Added support for Continuous 7 Days backup mode.
* Added new parameter 'EnablePartitionMerge' to 'Update-AzCosmosDBAccount' and 'New-AzCosmosDBAccount'.

#### Az.Databricks 1.5.1
* Fixed an issue that 'Update-AzDatabricksWorkspace' doesn't work as expected while enabling encryption. [#21324]

#### Az.DataProtection 2.0.0
* Added support for Blob Hardened recovery points (VaultStore).
* Added Cross Subscription Restore for 'AzureDisk', 'AzureDatabaseForPostgreSQL' and 'AzureBlob'.
* Added 'Get-AzDataProtectionOperationStatus' command for long running cmdlets async.

#### Az.DesktopVirtualization 4.0.0
* Upgraded API version to 2022-09-09
* Added cmdlet:
    - 'Get-AzWvdScalingPlanPooledSchedule'
    - 'New-AzWvdScalingPlanPooledSchedule'
    - 'Remove-AzWvdScalingPlanPooledSchedule'
    - 'Update-AzWvdScalingPlanPooledSchedule'
* Added parameters 'pageSize', 'isDescending' and 'initialSkip' to:
    - 'Get-AzWvdApplication'
    - 'Get-AzWvdApplicationGroup'
    - 'Get-AzWvdDesktop'
    - 'Get-AzWvdHostPool'
    - 'Get-AzWvdMsixPackage'
    - 'Get-AzWvdScalingPlan'
    - 'Get-AzWvdSessionHost'
    - 'Get-AzWvdStartMenuItem'
    - 'Get-AzWvdUserSession'
    - 'Get-AzWvdWorkspace'
* Added parameters 'AgentUpdateMaintenanceWindow', 'AgentUpdateMaintenanceWindowTimeZone', 'AgentUpdateType', 'AgentUpdateUseSessionHostLocalTime' to:
    - 'New-AzWvdHostPool'
    - 'Update-AzWvdHostPool'
* Added parameter 'FriendlyName' to:
    - 'New-AzWvdHostPool'
    - 'Update-AzWvdHostPool'
    - 'Update-AzWvdSessionHost'

#### Az.EventHub 4.0.0
* Aliased 'New-AzEventHubNamespace', 'Remove-AzEventHubNamespace', 'Set-AzEventHubNamespace', 'Get-AzEventHubNamespace' with 'New-AzEventHubNamespaceV2', 'Remove-AzEventHubNamespaceV2', 'Set-AzEventHubNamespaceV2', 'Get-AzEventHubNamespaceV2' respectively
* Replaced 'New-AzEventHubEncryptionConfig' by 'New-AzEventHubKeyVaultPropertiesObject'

#### Az.HDInsight 6.0.0
* Breaking Change:
  - Removed the parameter '-RdpAccessExpiry' which has been marked as deprecated for a long time from cmdlet 'New-AzHDInsightCluster'
  - Removed the parameter '-RdpCredential' which has been marked as deprecated for a long time from cmdlet 'New-AzHDInsightCluster'

#### Az.KeyVault 4.10.0
* Added breaking change announcement for parameter 'SoftDeleteRetentionInDays' in 'New-AzKeyVaultManagedHsm'. The parameter 'SoftDeleteRetentionInDays' is becoming mandatory
    - This change will take effect on version 6.0.0
* Changed the encoding way from a string into byte array in 'Invoke-AzKeyVaultKeyOperation' from ASCII to UTF8. UTF8 is backward-compatible with ASCII. [#21269]
* Bug fix: Changed the decoding way from byte array into a string from system default encoding to UTF8 to match encoding way. [#21269]
* Added parameter 'PolicyPath' and 'PolicyObject' in 'Import-AzKeyVaultCertificate' to support custom policy [#20780]

#### Az.MachineLearningServices 1.0.0
* General availability for module Az.MachineLearningServices

#### Az.Monitor 4.5.0
* Added cmdlets for monitor workspace:
    - 'Get-AzMonitorWorkspace'
    - 'New-AzMonitorWorkspace'
    - 'Update-AzMonitorWorkspace'
    - 'Remove-AzMonitorWorkspace'

#### Az.Network 6.0.0
* Added new cmdlets for RouteMap child resource of VirtualHub.
    -'Get-AzRouteMap'
    -'New-AzRouteMapRuleCriterion'
    -'New-AzRouteMapRuleActionParameter'
    -'New-AzRouteMapRuleAction'
    -'New-AzRouteMapRule'
    -'New-AzRouteMap'
    -'Set-AzRouteMap'
    -'Remove-AzRouteMap'
* Updated cmdlets to add inbound/outbound route maps in routingConfiguration
    -'New-AzRoutingConfiguration'
* Added the command 'New-AzFirewallPolicyApplicationRuleCustomHttpHeader'
* Added the method 'AddCustomHttpHeaderToInsert' to 'PSAzureFirewallPolicyApplicationRule'
* Added new cmdlets to support Rate Limiting Rule for Application Gateway WAF
    - 'New-AzApplicationGatewayFirewallCustomRuleGroupByUserSession',
    - 'New-AzApplicationGatewayFirewallCustomRuleGroupByVariable',
    - Also updated cmdlet to add the property of 'RateLimitDuration', 'RateLimitThreshold' and 'GroupByUserSession'
    - 'New-AzureApplicationGatewayFirewallCustomRule'
* Added support of 'AdditionalNic' Property in 'New-AzNetworkVirtualAppliance'
* Added the new cmdlet for supporting 'AdditionalNic' Property
    - 'New-AzVirtualApplianceAdditionalNicProperty'
* Added new cmdlets to support Log Scrubbing Feature for Application Gateway WAF Firewall Policy
    - 'New-AzApplicationGatewayFirewallPolicyLogScrubbingConfiguration',
    - 'New-AzApplicationGatewayFirewallPolicyLogScrubbingRule',
    - Also updated cmdlet to add the property of 'LogScrubbing'
    - 'New-AzApplicationGatewayFirewallPolicySetting'
* Onboarded 'Microsoft.HardwareSecurityModules/cloudHsmClusters' to private link cmdlets
* Updated cmdlet to add the property of 'DisableRequestBodyEnforcement', 'RequestBodyInspectLimitInKB' and 'DisableFileUploadEnforcement'
    - 'New-AzApplicationGatewayFirewallPolicySetting'
* Added optional property 'AuxiliarySku' to cmdlet 'New-AzNetworkInterface' to help choose performance on an 'AuxiliaryMode' enabled Network Interface.
* Added a new value 'AcceleratedConnections' for existing property 'AuxiliaryMode' for 'New-AzNetworkInterface'
* Added new cmdlets to get virtual hub effective routes and in/outbound routes
    - 'Get-AzVHubEffectiveRoute'
    - 'Get-AzVHubInboundRoute'
    - 'Get-AzVHubOutboundRoute'

#### Az.RedisEnterpriseCache 1.2.0
* Upgraded API version to 2023-03-01-preview

#### Az.Relay 2.0.0
* Updated API version to 2021-11-01

#### Az.Resources 6.7.0
* Added parameter '-CountVariable' for list operations, 'odataCount' can now be assigned to this variable [#20982]
    - 'Get-AzADApplication'
    - 'Get-AzADServicePrincipal'
    - 'Get-AzADUser'
    - 'Get-AzADGroup'
* Supported polymorphism for 'Get-AzADGroupMember', output of this cmdlet was now 'Application' 'ServicePrincipal', 'User' and 'Group' based on the 'odataType' [#19728]
* Added '-Force' parameter on 'Publish-AzBicepModule' for supporting overwriting existing modules.
* Fixed 'New-AzADApplication' when multiple redirect url types were provided. [#21108]
* Fixed 'Update-AzADServicePrincipal' when empty array passed for 'IdentifierUri' [#21345]
* Fixed an issue where location header was missing in the response from the service for 'New-AzManagedApplication'.
* Fixed 'Get-AzResourceGroup' ignored the subscription ID in '-Id' [#21725]

#### Az.ServiceBus 3.0.0
* Aliased 'New-AzServiceBusNamespace', 'Remove-AzServiceBusNamespace', 'Set-AzServiceBusNamespace', 'Get-AzServiceBusNamespace' with 'New-AzServiceBusNamespaceV2', 'Remove-AzServiceBusNamespaceV2', 'Set-AzServiceBusNamespaceV2', 'Get-AzServiceBusNamespaceV2' respectively.
* Replaced 'New-AzServiceBusEncryptionConfig' by 'New-AzServiceBusKeyVaultPropertiesObject'

#### Az.ServiceFabric 3.2.0
* Added new cmdlet 'Add-AzServiceFabricManagedClusterNetworkSecurityRule' to update network security rules in managed cluster resource

#### Az.SignalR 2.0.0
* Breaking change:
    - Removed 'HostNamePrefix' property of output type 'PSSignalRResource' of following cmdlets:
        - 'Get-AzSignalR'
        - 'New-AzSignalR'
        - 'Update-AzSignalR'

#### Az.Sql 4.7.0
* Added new cmdlets 'Get-AzSqlInstanceDatabaseLedgerDigestUpload', 'Disable-AzSqlInstanceDatabaseLedgerDigestUpload', and 'Enable-AzSqlInstanceDatabaseLedgerDigestUpload'
* Added 'EnableLedger' parameter to 'New-AzSqlInstanceDatabase'
* Added 'PreferredEnclaveType' parameter to 'NewAzureSqlElasticPool' and 'SetAzureSqlElasticPool' cmdlet

#### Az.SqlVirtualMachine 2.0.0
* Converted Az.SqlVirtualMachine to autorest-based module.

#### Az.StackHCI 2.0.0
* Made Region parameter mandatory in 'Register-AzStackHCI' cmdlet.
* Removed EnableAzureArcServer parameter from 'Register-AzStackHCI' cmdlet.
* Removed 'Test-AzStackHCIConnection' cmdlet. Customers can use 'Invoke-AzStackHciConnectivityValidation' from AzStackHCI.EnvironmentChecker module for enhanced connectivity verification tests.
* Added support for Managed Service identity (MSI) in Azure China Cloud.
* Added support for Mandatory extensions, for OS versions starting 23H2.
* Added parameter validations for 'Register-AzStackHCI' cmdlet.
* Improved Error logging in Registration and Unregistration.

#### Az.Storage 5.7.0
* Fixed issue of getting a single blob with leading slashes
    - 'Get-AzStorageBlob'
* Supported setting CORS rules in management plane cmdlets
    - 'Update-AzStorageBlobServiceProperty'
    - 'Update-AzStorageFileServiceProperty'
* Fixed an issue of 'StorageAccountName' field in context object when the context is invalid
    - 'New-AzStorageContext'
* Fixed an issue when a context does not have Credentials field
* Added '' to be a valid container name

#### Az.StorageSync 2.0.0
* Deprecated 'RegisteredServer' alias for InputObject parameter for Set-AzStorageSyncServerEndpoint

#### Az.Synapse 3.0.0
* Removed the unnecessary breaking change of parameter '-SparkConfigFilePath' for 'New-AzSynapseSparkPool' and 'Update-AzSynapseSparkPool' cmdlets

#### Az.Websites 3.0.0
* Removed 'New-AzWebAppContainerPSSession' and 'Enter-AzWebAppContainerPSSession' cmdlets

### Known Issues

* We have identified an issue when executing the following cmdlets from `Az.Cdn` module. We are working on a hotfix as soon as possible.
  * `Update-AzFrontDoorCdnProfile`
  * `Remove-AzCdnProfile`
  * `Remove-AzFrontDoorCdnProfile`
  * `Update-AzCdnProfile`
  * `Start-AzFrontDoorCdnProfilePrepareMigration`

### Thanks to our community contributors

* Gitanjali Verma (@gitanjali1993), Update Set-AzApplicationGatewayBackendAddressPool.md (#21458)
* Jeremiah Mathers (@jeremiahmathers), Update Set-AzApplicationGatewayConnectionDraining.md (#21601)
* Morris Janatzek (@morrisjdev), Added PackageAction `Set` for `Update-AzSynapseSparkPool` to support removing and adding packages in one action (#21579)
* Adam Myatt (@myatt83)
  * Update Set-AzNetworkManagerSubscriptionConnection.md (#21621)
  * Update Get-AzApiManagementAuthorizationServerClientSecret.md (#21619)
* Noah Koontz (@prototypicalpro)
  * Regenerate help for Az.Network (#21533)
  * feat: add autoscale support for virtual hub and update network formatting (#21518)
* Simon Wåhlin (@SimonWahlin), Add -Force parameter on Publish-AzBicepModule (#21713)
* Steve Matney (@stevematney), Fix typo in Update-AzWebAppTrafficRouting.md (#21667)

## 9.7.1 - May 2023
#### Az.Websites 2.15.1
* Used AAD Auth instead of Basic Auth for PublishAzureWebApps

## 9.7.0 - May 2023
#### Az.Accounts 2.12.2
* Fixed 'AzureSynapseAnalyticsEndpointResourceId' of 'USGovernment' environment.
* Updated Azure.Core to 1.31.0.
* Updated the reference of Azure PowerShell Common to 1.3.75-preview.

#### Az.Aks 5.4.0
* Added cmdlet 'New-AzAksMaintenanceConfiguration', 'Get-AzAksMaintenanceConfiguration', 'Remove-AzAksMaintenanceConfiguration', 'New-AzAksSnapshot', 'Get-AzAksSnapshot', 'Remove-AzAksSnapshot', 'Get-AzAksManagedClusterCommandResult', 'Get-AzAksManagedClusterOSOption', 'Get-AzAksManagedClusterOutboundNetworkDependencyEndpoint', 'Invoke-AzAksAbortAgentPoolLatestOperation', 'Invoke-AzAksAbortManagedClusterLatestOperation', 'Invoke-AzAksRotateManagedClusterServiceAccountSigningKey', 'Start-AzAksManagedClusterCommand', 'New-AzAksTimeInWeekObject', 'New-AzAksTimeSpanObject'.
* Added parameter '-OutboundType' for 'New-AzAksCluster'
* Added parameter '-EnableOidcIssuer' for 'New-AzAksCluster' and 'Set-AzAksCluster'
* Added parameter '-NodePodSubnetID' for 'New-AzAksCluster', '-PodSubnetID' for 'New-AzAksNodePool'

#### Az.Compute 5.7.1
* Added a breaking change warning to the 'Get-AzVM' cmdlet to show that the 'NextLink' parameter and parameter set will be removed in June 2023. The parameter has been non-functional for a long time.
* Updated the breaking change warning in 'New-AzVM' and 'New-AzVmss' regarding using the new versioned image aliases to indicate that certain aliases will be removed next breaking change release.
* Updated the 'Get-AzVMRunCommand' to include the 'ProvisioningState' value. Fix [#21473]
* Updated Azure.Core to 1.31.0.

#### Az.ContainerRegistry 3.0.4
* Updated Azure.Core to 1.31.0.

#### Az.CosmosDB 1.10.1
* Updated Azure.Core to 1.31.0.

#### Az.KeyVault 4.9.3
* Added breaking changes for 'Invoke-AzKeyVaultKeyOperation'. The encoded/decoded way between string and bytes in 'Invoke-AzKeyVaultKeyOperation' will change to UTF8.
    - This change will take effect on 5/23/2023
    - The change is expected to take effect from the version 5.0.0
* Updated Azure.Core to 1.31.0.

#### Az.LoadTesting 1.0.0
* General availability of 'Az.LoadTesting' module

#### Az.Network 5.7.0
* Onboarded 'Microsoft.HardwareSecurityModules/cloudHsmClusters' to private link cmdlets
* Fixed the issue for 'Update-AzCustomIpPrefix' that 'NoInternetAdvertise' will should be set to false if not provided

#### Az.PolicyInsights 1.6.1
* Updated Azure.Core to 1.31.0.

#### Az.PowerBIEmbedded 1.2.1
* Added deprecate warning message for workspace collection cmdlets

#### Az.RecoveryServices 6.4.0
* Added support for updating CrossSubscriptionRestoreState of the vault
* Added Cross subscription restore support for workload type MSSQL

#### Az.Resources 6.6.1
* Added support for Azure resources deployment with parameters file using Bicep parameters syntax

#### Az.Sql 4.6.0
* Added new cmdlets for managing server configuration options
    - 'Set-AzSqlServerConfigurationOption'
    - 'Get-AzSqlServerConfigurationOption'

#### Az.Storage 5.6.0
* Supported rename file and directory
    - 'Rename-AzStorageFile'
    - 'Rename-AzStorageDirectory'
* Added a warning message for an upcoming breaking change when getting a single blob
    - 'Get-AzStorageBlob'
* Fixed the issue of listing blobs with leading slashes
    - 'Get-AzStorageBlob'
* Added support for sticky bit
    - 'New-AzDataLakeGen2Item'
    - 'New-AzDataLakeGen2ACLObject'
    - 'Update-AzDataLakeGen2Item'
* Added warning messages for an upcoming cmdlet breaking change
    - 'New-AzStorageAccount'
    - 'Set-AzStorageAccount'
* Allowed to clear blob tags on a blob
    - 'Set-AzStorageBlobTag'
* Updated Azure.Core to 1.31.0

#### Az.Synapse 2.3.1
* Updated Azure.Core to 1.31.0.

#### Az.Websites 2.15.0
* Fixed Tag parameter issues with ASE for 'New-AzWebApp'

### Thanks to our community contributors
* @geologyrocks
  * Update IsCustom property on example role defintion (#21514)
  * Fix Assignment/Definition typo in Output (#21442)

## 9.6.0 - April 2023
#### Az.Aks 5.3.2
* Fixed the issue that system variable 'True' is undefined in 'Windows PowerShell'.
* Decoupled AutoMapper dependency, replaced with AdapterHelper.

#### Az.Batch 3.4.0
* Added new property 'Encryption' of type 'EncryptionProperties' to 'AccountCreateParameters'.
  - Configures how customer data is encrypted inside the Batch account.

#### Az.Billing 2.0.1
* Fixed pagination for 'Get-AzConsumptionPriceSheet' cmdlet

#### Az.CognitiveServices 1.13.1
* Removed notice and attestation from 'New-AzCognitiveServicesAccount'.

#### Az.Compute 5.7.0
* Addressed bug in 'Remove-AzVmss' to throw error when '-InstanceId' is null. [#21162]
* Added '-CustomData', '-AdminPassword', and '-ExactVersion' parameters to 'Invoke-AzVMReimage'.
* Removed the image alias 'CoreOS' as the publisher CoreOS no longer has any images for Azure.
  Updated the names of the 'openSUSE-Leap' and 'SLES' aliases to 'OpenSuseLeap154' and 'SuseSles15SP4' respectively. Updated these aliases to point to an image that actually exists.
* Added a breaking change warning to 'New-AzVM' and 'New-AzVmss' for future planned image alias removals due to the images reaching their End of Support date.
* Added new descriptive and versioned alias names for the Linux image aliases, including a new alias for  the 'Kinvolk' publisher.

#### Az.ContainerRegistry 3.0.3
* Added breaking change attributes for cmdlets

#### Az.CosmosDB 1.10.0
* Introduced restorable apis support for Gremlin and Table, which includes:
    - Added the apis for RestorableGremlinDatabases, RestorableGremlinGraphs, RestorableGremlinResources,RestorableTables, RestorableResources.
    - Added RetrieveContinuousBackupInfo apis for Gremlin and Table which help in determining the restore point of time and the resources to restore.
    - Added GremlinDatabasesToRestore and TablesToRestore field to provision and restore database account api.
    - Added StartTime and EndTime support for listing restorable containers event feed.

#### Az.DataProtection 1.2.0
* Added support for AKS workload with Backup Vaults
* Added support for 'Set-AzDataProtectionMSIPermission' during restore with AKS workload

#### Az.EventGrid 1.6.0
* Added fix for DeliveryAttributeMapping
* Added validation for StorageQueueTtl

#### Az.EventHub 3.2.3
* Added upcoming breaking change notifications for Az.EventHub module.

#### Az.Kusto 2.2.0
* Added cmdlet 'Get-AzKustoSku'
* Added parameter 'CallerRole' for cmdlet 'AzKustoDatabase' and 'Update-AzKustoDatabase'
* Added support for new data connection kind 'CosmosDb' for cmdlet 'New-AzKustoDataConnection' and 'Update-AzKustoDataConnection'
* Added parameters 'DatabaseNameOverride' 'DatabaseNamePrefix' 'TableLevelSharingPropertyFunctionsToInclude' 'TableLevelSharingPropertyFunctionsToExclude' for cmdlet 'New-AzKustoAttachedDatabaseConfiguration'

#### Az.Network 5.6.0
* Updated 'New-AzLoadBalancer' and 'Set-AzLoadBalancer' to validate surface level parameters for global tier load balancers
* Added property 'AuthorizationStatus' to ExpressRouteCircuit
* Added property 'BillingType' to ExpressRoutePort
* Added support for connection flushing in network security group which when enabled, re-evaluates flows when rules are updated
    - 'New-AzNetworkSecurityGroup'
* Added support for state in WAF Custom Rule
* Added 'New-AzGatewayCustomBgpIpConfigurationObject' command
* Updated 'New-AzVirtualNetworkGatewayConnection', 'Set-AzVirtualNetworkGatewayConnection' and 'New-AzVpnSiteLinkConnection' to support GatewayCustomBgpIpConfiguration.
* Updated 'Reset-AzVpnGateway' to support IpConfigurationId.
* Blocked some regions when creating/updating Basic Sku firewall
* Fixed bugs related to auto learn IP prefixes and Snat
* Updated multi-auth to be supported when both OpenVPN and IkeV2 protocols are used for VNG and VWAN VPN

#### Az.Resources 6.6.0
* Fixed an issue when running the 'New-AzManagementGroup' command where it tried to cast an async operation as a Management Group. [#21000]
* Fixed an issue when running 'Get-AzResourceGroup -Name 'some_name'', it ignores '-Location' if specified[#21225]

#### Az.ServiceBus 2.2.1
* Added upcoming breaking change notifications for Az.ServiceBus module.

#### Az.Sql 4.5.0
* Added a new cmdlet to refresh external governance status
    - 'Invoke-AzSqlServerExternalGovernanceStatusRefresh'

#### Az.SqlVirtualMachine 1.1.1
* Added breaking change notification for cmdlets to be removed and parameters to be changed.
    * Cmdlet 'New-AzSqlVMConfig' will be removed.
    * Cmdlet 'Set-AzSqlVMConfigGroup' will be removed.
    * Cmdlet 'Update-AzAvailabilityGroupListener' will be removed.
    * Parameter 'SqlVM' will be removed from cmdlet 'New-AzSqlVM'.
    * Parameter 'SqlVMGroupObject' will be removed from cmdlet 'Get-AzAvailabilityGroupListener' and 'Remove-AzAvailabilityGroupListener'.
    * Parameter alias 'SqlVM' will be removed from 'InputObject' of cmdlet 'Remove-AzSqlVM'.
    * Parameter alias 'SqlVMGroup' will be removed from 'InputObject' of cmdlet 'Update-AzSqlVMGroup' and 'Remove-AzSqlVMGroup'.
* Added breaking change notification for SqlManagementType

#### Az.Storage 5.5.0
* Supported create storage account with DnsEndpointType
    - 'New-AzStorageAccount'
* Fixed file cmdlets potential context issue when the current context doesn't match with the credential of input Azure File object
    - 'Close-AzStorageFileHandle'
    - 'Get-AzStorageFile'
    - 'Get-AzStorageFileContent'
    - 'Get-AzStorageFileHandle'
    - 'New-AzStorageDirectory'
    - 'New-AzStorageFileSASToken'
    - 'Remove-AzStorageDirectory'
    - 'Remove-AzStorageFile'
    - 'Remove-AzStorageShare'
    - 'Set-AzStorageFileContent'
    - 'Set-AzStorageShareQuota'
    - 'Start-AzStorageFileCopy'

#### Az.Websites 2.14.0
* Fixed 'Edit-AzWebAppBackupConfiguration' to pass backup configuration enabled or not
* Added a new parameter '-SoftRestart' for 'Restart-AzWebApp' and 'Restart-AzWebApp' to perform a soft restart
* Updated 'Get-AzWebApp' and 'Get-AzWebAppSlot' to expose 'VirtualNetwork Integration Info' [#10665]
* Set default value for '-RepositoryUrl' of 'New-AzStaticWebApp' [#21202]

### Thanks to our community contributors
* Allen TechWorld (@hachi1030-Allen), Bug - Invoke-AzCostManagementQuery cmdlet should handle null value in the response rows (#21180)
* Simon Angling (@sangling), Minor Spelling (#21165)
* Thomas Pike (@thwpike), Missing formatting for code block (#21130)

## 9.5.0 - March 2023
#### Az.Accounts 2.12.0
* Fixed the issue that errors related to WAM are thrown when it is not enabled. [#20871] [#20824]
* Updated Azure.Core library to 1.28.0.
* Fixed an issue that the helper message about missing modules shows up at the wrong time. [#19228]
* Added a hint message for some resource creation cmdlets when there is another region which may reduce the costs.
* Supported environment initialization and auto-discovery with ArmMetadata of API version 2022-09-01.

#### Az.Aks 5.3.1
* Fixed the issue that Invoke-AzAksRunCommand will fail when the directory for parameter CommandContextAttachment contains sub-directories. [#20734]

#### Az.Automanage 1.0.0
* General availability for module Az.Automanage

#### Az.Automation 1.9.1
* Fixed bug: Runbooks Name Pattern failures.

#### Az.CloudService 1.2.0
* Upgraded the api version to 2022-09-04.
* Upgraded the api version of referenced network to 2022-07-01.

#### Az.CognitiveServices 1.13.0
* Updated CognitiveServices PowerShell to use 2022-12-01 version.
* Added new CognitiveServices CommitmentPlan and Association cmdlets.
* Added MultiRegionSetting support for CognitiveServices Account cmdlets.

#### Az.Compute 5.5.0
* Added breaking change message for 'New-AzVmss'.
* Added '-PerformancePlus' parameter to 'New-AzDiskConfig'
* Added 'MaxSurge' to Set-AzVmssRollingUpgradePolicyCommand
* Added support for 'latest' in 'Get-AzvmImage' '-Version' parameter
* Added 'CompletionPercent' property to PSDisk object.

#### Az.ContainerInstance 3.2.0
* Added 'priority' property to Container Group properties
* Added 'Confidential' sku type to Container Group Skus

#### Az.ContainerRegistry 3.0.2
* Updated Azure.Core to 1.28.0.

#### Az.CosmosDB 1.9.1
* Updated Azure.Core to 1.28.0.

#### Az.Databricks 1.5.0
* Upgraded API version to 2023-02-01

#### Az.DataFactory 1.16.13
* Updated ADF .Net SDK version to 9.2.0
* Added AzureBlobFS sasUri and sasToken properties in ADF
* Added AzureBlobStorage containerUri and authenticationType properties in ADF
* Added support copyComputeScale And pipelineExternalComputeScale in IntegrationRuntime

#### Az.EventHub 3.2.2
* Added breaking change description for parameter 'MessageRetentionInDays', which would be deprecated and would be replaced by 'RetentionTimeInHours'

#### Az.FrontDoor 1.10.0
* Fixed New-AzFrontDoorWafPolicy cmdlet to support adding Tags for the Azure Frontdoor waf policy

#### Az.IotHub 2.7.5
* Updated IoT Hub Management SDK to version 4.2.0 (api-version 2021-07-02)
* Fixed 'Get-AzIoTHub' to work with DigiCert hubs

#### Az.KeyVault 4.9.2
* Updated Azure.Core to 1.28.0.

#### Az.ManagedServiceIdentity 1.1.1
* Upgraded to API version 2023-01-31.
* Federated identity credentials GA version is available now.

#### Az.Network 5.5.0
* Updated cmdlets to add new property of 'Snat' in Azure Firewall Policy.
    - 'New-AzFirewallPolicySnat'
    - 'New-AzFirewallPolicy'
    - 'Set-AzFirewallPolicy'
* Fixed a bug that reverts classic fw private ranges to default when doing get & set
* Onboarded 'Microsoft.Monitor/accounts' to private link cmdlets

#### Az.PolicyInsights 1.6.0
* Added support for policy attestations.

#### Az.RecoveryServices 6.3.0
* Supported using managed disks for replication for HyperV to Azure provider in Azure Site Recovery

#### Az.Relay 1.0.4
* Added breaking change message for cmdlets.
    * 'Set-AzRelayNamespace'
    * 'Get-AzRelayOperation'

#### Az.Resources 6.5.3
* Updated behavior of Get-AzPolicyDefinition which previously returned all definitions when -Id was provided with a nonexistent policy definition id. Fixed to correctly throw a 404 exception in this case.

#### Az.Security 1.4.0
* Updated Alerts cmdlets:
    'Get-AzSecurityAlert'
    'Set-AzSecurityAlert'
* Moving Security Contacts to be based on the latest API version '2020-01-01-preview' with backward compatibility support

#### Az.ServiceBus 2.2.0
* Upgraded API version to 2022-10-01-preview
* Fixed a bug for 'Set-AzServiceBusQueue'

#### Az.ServiceFabric 3.1.1
* Added support for Windows 2022 server vm image.
    - This enables cluster operations with Windows 2022 server vm image

#### Az.Sql 4.4.0
* Fixed identity assignment in 'Set-AzSqlDatabase' cmdlet
* Added new parameters to 'New-AzSqlDatabase', 'Get-AzSqlDatabase', 'Set-AzSqlDatabase', 'New-AzSqlDatabaseCopy', 'New-AzSqlDatabaseSecondary' cmdlets
   - AssignIdentity
   - EncryptionProtector
   - UserAssignedIdentityId
   - KeyList
   - KeysToRemove
   - FederatedClientId
* Added 'ExpandKeyList' and 'KeysFilter' parameters to 'Get-AzSqlDatabaseGeoBackup' and 'Get-SqlDeletedDatabaseBackup'
* Added new cmdlets for Per DB CMK
   - 'Revalidate-AzSqlDatabaseTransparentDataEncryptionProtector'
   - 'Revert-AzSqlDatabaseTransparentDataEncryptionProtector'
   - 'Revalidate-AzSqlServerTransparentDataEncryptionProtector'
   - 'Revalidate-AzSqlInstanceTransparentDataEncryptionProtector'
* Added an optional parameter 'SecondaryType' to:
    'Set-AzSqlDatabaseInstanceFailoverGroup'
    'New-AzSqlDatabaseInstanceFailoverGroup'

#### Az.StackHCI 1.4.3
* Removed manual installation for Az.Accounts from Az.StackHCI.
* Removed verbose while importing modules.

#### Az.Storage 5.4.1
* Updated Azure.Core to 1.28.0.

#### Az.StorageMover 1.0.0
* General availability for module Az.StorageMover
* Updated StorageMover API version to 2023-03-01

#### Az.Synapse 2.3.0
* Upgraded Azure.Analytics.Synapse.Artifacts to 1.0.0-preview.17
* Updated 'New-AzSynapseSparkPool' and 'Update-AzSynapseSparkPool' to support for setting spark pool isolated compute by '-EnableIsolatedCompute'
* Updated 'New-AzSynapseSparkPool' and 'Update-AzSynapseSparkPool' to support for setting spark pool node size to 'XLarge', 'XXLarge', 'XXXLarge'

#### Az.Websites 2.13.0
* Added a new parameter '-CopyIdentity' for 'New-AzWebAppSlot' to copy the identity from the parent app to the slot.
* Updated 'New-AzWebAppSSLBinding' to support -WhatIf parameter

### Thanks to our community contributors
* Brett Miller (@brettmillerb), Corrected syntax for ConfirmAction (#20902)
* Dave Neeley (@daveneeley), Clarify behavior of AcountEnabled and Password (#21006)
* Hiroshi Yoshioka (@hyoshioka0128), Typo "udpate"→"update" (#20810)
* @meenalsri
  * Update New-AzSynapseRoleAssignment.md (#20905)
  * Update Remove-AzSynapseRoleAssignment.md (#20906)
  * Added note for scenario when an SPN role assignment is listed (#20907)
* @sushil490023, Update Reference to latest swagger for Runbook Cmdlets (#20803)

## 9.4.0 - February 2023
#### Az.Accounts 2.11.2
* Supported Web Account Manager on ARM64-based Windows systems. Fixed an issue where 'Connect-AzAccount' failed with error 'Unable to load DLL 'msalruntime_arm64''. [#20700]
* Enabled credential to be found only by applicationId while tenant was not matched when acquire token. [#20484]
* When Az.Accounts ran in parallel, the waiters were allowed to wait infinitely to avoid throw exception in automation environment. [#20455]

#### Az.Aks 5.3.0
* Added parameter '-AadProfile' for 'New-AzAksCluster' and 'Set-AzAksCluster'
* Added parameter '-NodeHostGroupID' for 'New-AzAksCluster' and parameter '-HostGroupID' for 'New-AzAksNodePool'

#### Az.ApplicationInsights 2.2.2
* Added parameter validation for 'Get-AzApplicationInsights' [#20697]

#### Az.Compute 5.4.0
* Added '-SkipIdentity', '-PathUserIdentity', '-IsTest' parameter to 'Set-AzVMAEMExtension'
* Added 'ConsistencyMode' parameter to 'New-AzRestorePoint'.
* Updated the storage account type value in several locations from the outdated 'StandardLRS' to the current 'Standard_LRS'.
* Filled in missing parameter descriptions across multiple parameters and improved some existing parameter descriptions.
* Updated Compute PS to use the new .Net SDK version 59.0.0. This includes an approved breaking change for a non-functional feature.
  - The type of the property 'Source' of type 'Microsoft.Azure.Management.Compute.Models.GalleryDataDiskImage', 'Microsoft.Azure.Management.Compute.Models.GalleryOSDiskImage', and 'Microsoft.Azure.Management.Compute.Models.GalleryImageVersionStorageProfile' has changed from 'Microsoft.Azure.Management.Compute.Models.GalleryArtifactVersionSource' to 'Microsoft.Azure.Management.Compute.Models.GalleryDiskImageSource'.
* Updated the broken 'UbuntuLTS' image alias to use its original sku version of '16.04-LTS' instead of the nonexistent image '20.04-LTS'. This fixes an issue introduced in the version 5.3.0 release.
* Updated Set-AzVMRunCommand and Set-AzVmssRunCommand ScriptLocalPath parameter set to work with Linux and with files that have comments.
* Added '-TargetExtendedLocation' parameter to 'New-AzGalleryImageVersion' and 'Update-AzGalleryImageVersion'
* Added '-AllowDeletionOfReplicatedLocation' to 'Update-AzGalleryImageVersion'

#### Az.DataFactory 1.16.12
* Updated ADF .Net SDK version to 9.0.0

#### Az.DataProtection 1.1.0
* Added support for Immutable backup vaults
* Added Cross subscription restore flag for backup vaults
* Added Soft delete setting for backup vaults
* Fixed issue with Set-AzDataProtectionMSIPermission command
* Replaced Get-InstalledModule with Get-Module -ListAvailable
* Added New-AzDataProtectionSoftDeleteSettingObject command

#### Az.EventHub 3.2.1
* Fixed 'New-AzEventHubAuthorizationRuleSASToken' cmdlet which was returning wrong skn value

#### Az.Monitor 4.4.1
* Removed default value for time window for autoscale profile [#20660]
  * 'Get-AzAutoscaleSetting'
  * 'New-AzAutoscaleSetting'

#### Az.Network 5.4.0
* Fixed a bug that does not enable to set Perform SNAT to Always
* Fixed the incorrect type of '-TotalBytesPerSession' in 'New-AzNetworkWatcherPacketCapture'

#### Az.RecoveryServices 6.2.0
* Added support for enable/disable Public Network Access and PrivateEndpoints
* Added support for Immutable Vaults
* Added support for RetainRecoveryPointsAsPerPolicy in Disable-AzRecoveryServicesBackupProtection cmdlet. Now user can suspend backups and retain RPs as per policy
* Added List Recovery Point expiry time
* Added RecoveryServices, RecoveryServices.Backup, RecoveryServices.Backup.CrossRegionRestore management SDK
* Added support for non-UTC time zones with standard policy for workloadType IaasVM, MSSql, AzureFiles

#### Az.RedisCache 1.7.1
* Updated 'Get-AzRedisCacheLink' and 'New-AzRedisCacheLink' to print 'PrimaryHostName', 'GeoReplicatedPrimaryHostName', 'ServerRole', and 'LinkedRedisCacheLocation'.

#### Az.Resources 6.5.2
* Fixed query issue when objectId in assignment is empty for 'Get-DenyAssignment'
* Fixed an issue where running deployment cmdlets with '-WhatIf' throws exception when formatting results with nested array changes

#### Az.Sql 4.3.0
* Added an optional parameter 'HAReplicaCount' to 'Restore-AzSqlDatabase'
* Added new cmdlets for managed instance DTC
    'Get-AzSqlInstanceDtc'
    'Set-AzSqlInstanceDtc'
* Added 'TargetSubscriptionId' to 'Restore-AzSqlInstanceDatabase' in order to enable cross subscription restore
* Enabled support for UserAssignedManagedIdentity in Auditing
* Fixed WorkspaceResourceId parameter value in 'Set-AzSqlServerAudit'

#### Az.StackHCI 1.4.2
* Added Remote Support terms and conditions for HCI device types.
* Unified Resource Group support for both Azure Stack HCI and Arc for server resources.
* Enhanced error feedback and logging in the Register-AzStackHCI cmdlet.
* Bug fixes and improvements in Azure Arc for servers enablement in Register-AzStackHCI cmdlet.
* Improved parameter validations in the Register-AzStackHCI cmdlet.
* Enabled Managed System Identity (MSI) for Registration in Fairfax Cloud.
* Minor bug fixes and improvements.

#### Az.Storage 5.4.0
* Added a warning message for the upcoming breaking change when creating a Storage account
    - 'New-AzStorageAccount'
* Removed the ValidateSet of StandardBlobTier parameter
    - 'Copy-AzStorageBlob'
    - 'Set-AzStorageBlobContent'
    - 'Start-AzStorageBlobCopy'

#### Az.TrafficManager 1.2.0
* Added a new optional parameter 'AlwaysServe' for endpoints.

### Thanks to our community contributors
* Arun Sabale (@Ar-Sa), Fix example 1 in Set-AzVirtualNetworkPeering.md (#20588)
* Hiroshi Yoshioka (@hyoshioka0128)
  * Fixed typo "resouce group"→"resource group" (#20664)
  * Typo "resouce group"→"resource group" (#20713)

## 9.3.0 - January 2023
#### Az.Accounts
* Supported Web Account Manager (WAM) as an opt-in interactive login experience. Enable it by 'Update-AzConfig -EnableLoginByWam True'.
* Optimized the mechanism for assembly loading.
* Enabled AzKeyStore with keyring in Linux.
* Fixed a typo in GetAzureRmContextAutosaveSetting.cs changing the cmdlet class name to GetAzureRmContextAutosaveSetting
* Removed survey on error message in 'Resolve-AzError'. [#20398]

#### Az.Aks
* Added parameter '-EnableEncryptionAtHost' for 'New-AzAksCluster' and 'New-AzAksNodePool'
* Added parameter '-EnableUltraSSD' for 'New-AzAksCluster' and 'New-AzAksNodePool'
* Added parameter '-NodeKubeletConfig' for 'New-AzAksCluster', '-KubeletConfig' for 'New-AzAksNodePool'
* Added parameter '-NodeLinuxOSConfig' for 'New-AzAksCluster', '-LinuxOSConfig' and 'New-AzAksNodePool'
* Added parameter '-NodeMaxSurge' for 'New-AzAksCluster', '-MaxSurge' for 'New-AzAksNodePool' and 'Update-AzAksNodePool'
* Added parameter '-PPG' for 'New-AzAksCluster' and 'New-AzAksNodePool'
* Added parameter '-SpotMaxPrice' for 'New-AzAksNodePool'
* Added parameter '-EnableFIPS' for 'New-AzAksCluster' and 'New-AzAksNodePool'
* Added parameter '-AutoScalerProfile' for 'New-AzAksCluster' and 'Set-AzAksCluster'
* Added parameter '-GpuInstanceProfile' for 'New-AzAksCluster' and 'New-AzAksNodePool'
* Added parameter '-EnableUptimeSLA' for 'New-AzAksCluster' and 'Set-AzAksCluster'
* Added parameter '-EdgeZone' for 'New-AzAksCluster'

#### Az.ApiManagement
* Updated description of ResourceId param 'New-AzApiManagementBackend' and 'Set-AzApiManagementBackend' cmdlet [#16868]

#### Az.ApplicationInsights
* Enabled output object enumerating for 'Get-AzApplicationInsights' [#20225]

#### Az.Automation
* Updated Example: Start-AzAutomationRunbook should pass ordered dictionary for parameters [#20408]

#### Az.Batch
* Added new properties 'CurrentNodeCommunicationMode' (read only) and 'TargetCommunicationMode' of type 'NodeCommunicationMode' to 'PSCloudPool'.
  - Valid values for 'NodeCommunicationMode': Default, Classic, Simplified
  - When the 'PSCloudPool' is updated with a new 'TargetCommunicationMode' value, the Batch service will attempt to update the pool to the new value the next time the pool is resized down to zero compute nodes and back up.
* 'PSPrivateLinkServiceConnectionState''s 'ActionRequired' property required has been renamed to 'ActionsRequired'. The old property has been marked as obsolete, and now just returns the new property. This should not impact existing consumers.

#### Az.Compute
* Removed the image 'Win2008R2SP1' from the list of available images and documentation. This image is no longer available on the backend so the client tools need to sync to that change.
* Fixed a bug for creating Linux VM's from SIG/Community Gallery Images
* Added 'ImageReferenceId' string parameter to the 'New-AzVmssConfig' cmdlet. This allows gallery image references to be added for the Confidential VM feature.
* Added 'SecurityEncryptionType' and 'SecureVMDiskEncryptionSet' string parameters to the 'Set-AzVmssStorageProfile' cmdlet for the Confidential VM feature.

#### Az.ContainerRegistry
* Fixed bug in 'Get-AzContainerRegistryTag' to show correct tags [#20528]

#### Az.Monitor
* Fixed bug for 'Remove-AzDataCollectionRuleAssociation' [#20207]
* Added support for test notifications cmdlets
  * 'Test-AzActionGroup'
* Fixed start time parameter description of 'Get-AzActivityLog' [#20409]

#### Az.Network
* Added samples for retrieving Private Link IP Configuration using 'New-AzApplicationGatewayPrivateLinkIpConfiguration' with fix [#20440]
* Added 'DdosProtectionPlan' property in 'AzPublicIpAddress'
* Updated mapping in 'AzPublicIpAddress' to always show/create DdosSettings
* Fixed a bug that added Ddos related properties when viewing PublicIpAddress and DdosProtectionPlan objects
* Fixed a Bug for Set-AzIpGroup cmdlet to support the '-WhatIf' parameter
* Fixed a Bug for 'Add-AzLoadBalancerFrontendIpConfig', 'Add-AzLoadBalancerProbeConfig', 'Add-AzLoadBalancerBackendAddressPoolConfig', 'Set-AzLoadBalancer', 'New-AzLoadBalancerRuleConfig', 'Remove-AzLoadBalancerInboundNatRuleConfig' cmdlets to support the '-WhatIf' parameter. [#20416]
* Fixed a bug for DestinationPortBehavior in 'Get-AzNetworkWatcherConnectionMonitor', 'New-AzNetworkWatcherConnectionMonitor' powershell command by adding this properties to get and set the DestinationPortBehavior information. [#15996]

#### Az.RedisCache
* Added optional parameter 'PreferredDataArchiveAuthMethod' in 'Export-AzRedisCache'
* Added optional parameter 'PreferredDataArchiveAuthMethod' in 'Import-AzRedisCache'
* Added 4 additional properties for a geo replication link: 'PrimaryHostName', 'GeoReplicatedPrimaryHostName', 'ServerRole', and 'LinkedRedisCacheLocation'in 'Get-AzRedisCacheLink' and 'New-AzRedisCacheLink'

#### Az.Resources
* Fixed issue introduced in previous fix for 'Set-AzPolicySetDefinition' InternalServerError when the initiative is too large [#20238], which will remove space in value.
* Fixed 'Get-AzRoleAssignment' BadRequest when scope is '/' [#20323]

#### Az.SecurityInsights
* Fixed for 'Update-AzSentinelAlertRule' fails when using '-TriggerThreshold 0' [#20417]

#### Az.Sql
* Added a parameter named 'UseIdentity' for 'Set-AzSqlServerAudit', 'Set-AzSqlDatabaseAudit', 'Set-AzSqlServerMSSupportAudit'
* Added 'IsManagedIdentityInUse' property to the output of 'Get-AzSqlServerMSSupportAudit'
* Added 'PreferredEnclaveType' parameter to 'New-AzSqlDatabase', 'Get-AzSqlDatabase' and 'Set-AzSqlDatabase' cmdlet

#### Az.StackHCI
* Added support for arc extensions which depend on HCI cluster's IMDS endpoints.

#### Az.Storage
* Return ListBlobProperties in blob list result
    - 'Get-AzStorageBlob'
* Output AllowedCopyScope in get account result
    - 'Get-AzStorageAccount'

#### Az.Websites
* Fixed 'Import-AzWebAppKeyVaultCertificate' to use certificate naming convention same as portal [#19592]

### Thanks to our community contributors
* Pavel Lyalyakin (@bahrep), New-AzDiskConfig.md: fixed a copy-pasto (#20514)
* Eugene Ogongo (@eugeneogongo), Update Images.json (#18654)
* Hiroshi Yoshioka (@hyoshioka0128), Typo "resouce"→"resource" (#20441)
* Paul Gledhill (@pmgledhill102), Spelling mistake 'Accpeted' (#20380)
* Cameron Sowder (@sowderca), Fixed typo in Get-AzContextAutosaveSetting class name: GetzureRmContextAutosaveSetting -> GetAzureRmContextAutosaveSetting (#20420)


## 9.2.0 - December 2022
#### Az.Accounts
* Enabled caching tokens when logging in with a client assertion. This fixed the incorrectly short lifespan of tokens.
* Upgraded target framework of Microsoft.Identity.Client to net461 [#20189]
* Stored 'ServicePrincipalSecret' and 'CertificatePassword' into 'AzKeyStore'.
* Updated the reference of Azure PowerShell Common to 1.3.67-preview.

#### Az.Aks
* Bumped API version to 2022-09-01
* Added parameter '-NodeOsSKU' for 'New-AzAksCluster' and parameter '-OsSKU' for 'New-AzAksNodePool'
* Added parameter '-Mode' for 'New-AzAksNodePool' and 'Update-AzAksNodePool'
* Added property '-NodeImageVersion' for the output of 'Get-AzAksNodePool'[#19893]
* Added parameter '-NodePoolLabel' for 'Set-AzAksCluster', '-NodeLabel' for 'New-AzAksNodePool' and 'Update-AzAksNodePool'
* Added parameter '-NodePoolTag' for 'New-AzAksCluster' and 'Set-AzAksCluster', '-Tag' for 'New-AzAksNodePool' and 'Update-AzAksNodePool'

#### Az.ApplicationInsights
* Supported Workbook function. Below is the new cmdlet
    * 'Get-AzApplicationInsightsMyWorkbook'
    * 'Get-AzApplicationInsightsWorkbook'
    * 'Get-AzApplicationInsightsWorkbookRevision'
    * 'Get-AzApplicationInsightsWorkbookTemplate'
    * 'New-AzApplicationInsightsMyWorkbook'
    * 'New-AzApplicationInsightsWorkbook'
    * 'New-AzApplicationInsightsWorkbookTemplate'
    * 'New-AzApplicationInsightsWorkbookTemplateGalleryObject'
    * 'Remove-AzApplicationInsightsMyWorkbook'
    * 'Remove-AzApplicationInsightsWorkbook'
    * 'Remove-AzApplicationInsightsWorkbookTemplate'
    * 'Update-AzApplicationInsightsMyWorkbook'
    * 'Update-AzApplicationInsightsWorkbook'
    * 'Update-AzApplicationInsightsWorkbookTemplate'

#### Az.Compute
* Fixed issue found for 'Set-AzVmssVMRunCommand' [#19985]
* Fixed 'Get-AzVm' cmdlet when parameter '-Status' is provided, return property 'OsName', 'OsVersion' and 'HyperVGeneration'
* Fixed 'New-AzVM' cmdlet when creating VM with bootdiagnostic storage causes exception 'Kind' cannot be null.

#### Az.CosmosDB
* Added support for Cosmos DB Service related cmdlets.

#### Az.DataFactory
* Updated ADF .Net SDK version to 8.0.0

#### Az.DataProtection
* Fixed spacing issues in Set-AzDataProtectionMSIPermission.ps1

#### Az.EventHub
* Added NamespaceV2 cmdlets for EventHub

#### Az.KeyVault
* Fixed certificate export parameter issue in 'Add-AzKeyVaultKey' [#19623]
* Fixed CertificateString decoding issue in 'Import-AzKeyVaultCertificate'
* Shifted the location of key CVM release policy to GitHub [#19984]
* Added fallback logic (reading default CVM policy from a local copy) if fetching default CVM Policy from GitHub failed.

#### Az.Monitor
* Fixed bug for 'New-AzActivityLogAlert' and 'Update-AzActivityLogAlert' [#19927]

#### Az.Network
* Added optional parameters 'CustomBlockResponseStatusCode' and 'CustomBlockResponseBody' parameter to 'AzApplicationGatewayFirewallPolicySettings'
* Added a new cmdlet to get the application gateway waf manifest and rules
    - 'Get-AzApplicationGatewayWafDynamicManifest'

#### Az.RecoveryServices
* Added support for passing DiskEncryptionSetId for Cross region restore
* Fixed the pagination bug in 'Get-AzRecoveryServicesAsrProtectableItem' for the V2ARCM scenario.
* Fixed 'IncludeDiskId' property for 'New-ASRReplicationProtectedItem' cmdlet of H2A

#### Az.Resources
* Added cmdlet 'Get-AzADOrganization'
* Fixed 'Set-AzPolicySetDefinition' InternalServerError when the initiative is too large [#20238]

#### Az.ServiceBus
* Added NamespaceV2 cmdlets for ServiceBus.

#### Az.SignalR
* Updated to API version 2022-08-01-preview
  - Added support for custom domain. Added new cmdlets New-AzWebPubSubCustomCertificate, Get-AzWebPubSubCustomCertificate, Remove-AzWebPubSubCustomCertificate, New-AzWebPubSubCustomDomain, Get-AzWebPubSubCustomDomain, Remove-AzWebPubSubCustomDomain.
  - Added support for event listeners in hub settings. Added new cmdlets New-AzWebPubSubEventHubEndpointObject, New-AzWebPubSubEventNameFilterObject.

#### Az.StackHCI
* Enabled system-assigned identity on HCI cluster resource registration and repair registration flow.
* Added error message in the command Register-AzStackHCI if Arc is not enabled.
* Added default region confirmation prompt if the region is not mentioned in the command Register-AzStackHCI.
* Added general logging improvements.
* Added logic that skipping the Arc SPN permission check in Register-AzStackHCI if a customer doesn't have the required permissions to read Arc SPN credential.
* Added deprecation message for the command Test-AzStackHCIConnection. Customers can use Invoke-AzStackHciConnectivityValidation from the module AzStackHCI.EnvironmentChecker for connectivity verification tests.

#### Az.Storage
* Supported MaxPageSize, Include, and Filter parameters for listing encryption scopes
    - 'Get-AzStorageEncryptionScope'
* Supported excludePrefix, includeDeleted, and many new schema fields in Blob Inventory
    - 'New-AzStorageBlobInventoryPolicyRule'

#### Az.Synapse
* Added breaking change message for  '-SparkConfigFilePath'. It will be deprecated around the middle of December.
* Updated 'New-AzSynapseSparkPool' and 'Update-AzSynapseSparkPool' to support for setting spark pool configuration artifact by '-SparkCongifuration'. '-SparkCongifuration' is an alternative of parameter '-SparkConfigFilePath'.

#### Az.Websites
* Added Tag parameter for 'New-AzWebApp' and 'New-AzWebAppSlot'
* Fixed 'Set-AzWebApp' and 'Set-AZWebAppSlot' to rethrow exception when Service Principal/User doesn't have permission to list web app configuration. [#19942]

### Thanks to our community contributors
* @Ajay1250, The example was using the wrong command (#20237)
* Hiroshi Yoshioka (@hyoshioka0128), Typo "resouce"→"resource" (#20321)
* Mats Estensen (@matsest), [Az.Tools.Installer]: Updates for a new minor/patch version (#20022)
* Matthew Burleigh (@mburleigh), fix typos (#20020)
* Mo Zaatar (@mzaatar), Change letter case in example of New-AzStorageBlobSASToken (#20018)
* @patchin404, Updates Enable-AzCdnCustomDomainCustomHttps Doc (#20165)
* Robin Malik (@robinmalik), Update New-AzADAppCredential.md (#20317)
* @SherrySahni, container name not supported with upper case (#20012)
* @sushil490023, Adding PS Cmdlets for Azure Automation Python3 operation (#19598)
* Thomas Pike (@thwpike), Typo Fix (#20087)

## 9.1.1 - November 2022
#### Az.Aks
* Upgraded AutoMapper to Microsoft.Azure.PowerShell.AutoMapper 6.2.2 with fix [#18721]

#### Az.ApiManagement
* Upgraded AutoMapper to Microsoft.Azure.PowerShell.AutoMapper 6.2.2 with fix [#18721]

#### Az.Compute
* Upgraded AutoMapper to Microsoft.Azure.PowerShell.AutoMapper 6.2.2 with fix [#18721]

#### Az.Maintenance
* Upgraded AutoMapper to Microsoft.Azure.PowerShell.AutoMapper 6.2.2 with fix [#18721]

#### Az.Monitor
* Upgraded AutoMapper to Microsoft.Azure.PowerShell.AutoMapper 6.2.2 with fix [#18721]

#### Az.Network
* Upgraded AutoMapper to Microsoft.Azure.PowerShell.AutoMapper 6.2.2 with fix [#18721]

#### Az.RecoveryServices
* Upgraded AutoMapper to Microsoft.Azure.PowerShell.AutoMapper 6.2.2 with fix [#18721]

#### Az.Resources
* Upgraded AutoMapper to Microsoft.Azure.PowerShell.AutoMapper 6.2.2 with fix [#18721]

## 9.1.0 - November 2022
#### Az.Accounts
* Updated 'Get-AzSubscription' to retrieve subscription by Id rather than listed all the subscriptions from server if subscription Id is provided. [#19115]

#### Az.CognitiveServices
* Updated CognitiveServices PowerShell to use 2022-10-01 version.

#### Az.Compute
* Fixed EdgeZone does not pass to VM for 'New-AzVM' 'SimpleParameterSet' [#18978]
* Added 'ScriptFilePath' parameter set for 'Set-AzVMRunCommand' and 'Set-AzVmssVMRunCommand' to allow users to pass in the path of the file that has the run command script
* Added '-AsJob' optional parameter to 'Remove-AzVMExtension' cmdlet.
* Added '-EdgeZone' optional parameter for 'Get-AzComputeResourceSku' and 'New-AzSnapshotUpdateConfig' cmdlets.
* Added Disk Delete Optional parameters 'OsDisk Deletion Option' and 'Delete Option' to the 'Set-AzVmssStorageProfile' (OS Disk) and 'Add-AzVmssDataDisk' (Data Disk)
* Improved printed output for 'Get-AzComputeResourceSku'
* Updated 'Get-AzHost' cmdlet logic to return Host for '-ResourceId' parameterset.
* Added '-OSDiskSizeGB' optional parameter for 'Set-AzVmssStorageProfile'.
* Improved cmdlet description for 'Set-AzVM' and added examples.
* Updated property mapping for parameter 'Encryption' of 'New-AzGalleryImageVersion'
* Updated list format to display all VmssVmRunCommand properties for 'Get-AzVmssVmRunCommand'
* Updated 'Get-AzGallery', 'New-AzGallery', 'Update-AzGallery', 'Get-AzGalleryImageDefinition', 'Get-AzGalleryImageVersion', 'New-AzVm' and 'New-AzVmss' to support community galleries

#### Az.Databricks
* Added 'RequiredNsgRule' parameter in the 'Update-AzDatabricksWorkspace'.

#### Az.DataFactory
* Updated ADF .Net SDK version to 7.0.0

#### Az.DataProtection
* Fixed list parameter set for 'Get-AzDataProtectionBackupVault'

#### Az.EventGrid
* Updated to use the 2022-06-15 API version.
* Added new features:
    - Partner topics
    - Partner topic event subscriptions
    - Partner namespaces
    - Partner namespace keys
    - Partner configurations
    - Partner registrations
    - Verified partners
    - Channels

#### Az.EventHub
* Added readonly Status property in EventHub Namespace

#### Az.Functions
* Added warning logs to detect Az context switching in Get-AzFunctionApp

#### Az.KeyVault
* Bumped API version to 2022-07-01
* Added 'Undo-AzKeyVaultManagedHsm' to recover deleted managed HSM

#### Az.ManagedServiceIdentity
* Supported Create/Get/Update/Remove Federated Identity Credentials on a User Assigned Managed Identity
  * 'Get-AzFederatedIdentityCredentials'
  * 'New-AzFederatedIdentityCredentials'
  * 'Remove-AzFederatedIdentityCredentials'
  * 'Update-AzFederatedIdentityCredentials'
* Supported List Associated Resources on a User Assigned Managed Identity
  * 'Get-AzUserAssignedIdentityAssociatedResource'

#### Az.Migrate
* Added parameter 'CacheStorageAccountId' to 'Initialize-AzMigrateReplicationInfrastructure'
* Added support for OS Disk Swap and Test Migrate Subnet Selection

#### Az.Network
* Added possible value 'LocalGateway' for parameter 'GatewayType'
    - 'New-AzVirtualNetworkGateway'
* Exposed 'ExtendedLocation' and 'VNetExtendedLocationResourceId' for 'VirtualNetworkGateway'
    - 'Get-AzVirtualNetworkGateway'
* Added new cmdlet to get firewall learned ip prefixes
    * 'Get-AzFirewallLearnedIpPrefix'
* Fixed a bug that does not update firewall policy application, network and nat rules' descriptions even though description is provided via description parameter
* Updated 'New-AzIpConfigurationBgpPeeringAddressObject' to remove validate null or empty check for CustomAddress in Azure Virtual Network Gateway
* Updated 'New-AzVirtualNetworkGateway' to add validate null or empty check for CustomAddress in Azure Virtual Network Gateway
* Updated cmdlets to add new property of 'VirtualNetworkGatewayPolicyGroup' and 'VpnClientConnectionConfiguration' in Azure Virtual Network Gateway
    * 'New-AzVirtualNetworkGateway'
    * 'Set-AzVirtualNetworkGateway'
* Added new cmdlets to create
    * 'New-AzVirtualNetworkGatewayPolicyGroup'
    * 'New-AzVirtualNetworkGatewayPolicyGroupMember'
    * 'New-AzVpnClientConnectionConfiguration'
* Added message in breaking change attribute to notify that load balancer sku default behavior will be changed
    * 'New-AzLoadBalancer'
* Added cmdlet preview to notify customers to use default value or leave null for load balancer probe threshold property
    * 'New-AzLoadBalancerProbeConfig'
    * 'Set-AzLoadBalancerProbeConfig'
    * 'Add-AzLoadBalancerProbeConfig'

#### Az.RecoveryServices
* Added support for cross zonal restore for ZRS vaults for non-ZonePinned VM
* Fixed bug with Update-AzRecoveryServicesAsrProtectionContainerMapping
* Added new scenarios: EZ-to-AZ, EZ-to-AZ, EZ-to-EZ
* Removed 'VmName' from non A2A scenarios of 'New-AzRecoveryServicesAsrReplicationProtectedItem' as it is not applicable

#### Az.Resources
* Fixed parameter 'Count' for
    - Get-AzADApplication
    - Get-AzADServicePrincipal
    - Get-AzADUser
* Polished preview warning message for:
    - Add-AzADGroupMember
    - Get-AzADGroupMember
    - Remove-AzADGroupMember
* Fixed a 'NullReferenceException' when deploying a JSON template using Bicep extensibility
* Added '-AsJob' to support running 'Register-AzResourceProvider' as a Job

#### Az.Sql
* Added new cmdlets for CRUD operations on SQL server IPv6 Firewall rules
      'Get-AzSqlServerIpv6FirewallRule'
      'New-AzSqlServerIpv6FirewallRule'
      'Remove-AzSqlServerIpv6FirewallRule'
      'Set-AzSqlServerIpv6FirewallRule'
* StorageContainerSasToken parameter in the 'Start-AzSqlInstanceDatabaseLogReplay' cmdlet is now optional

#### Az.StackHCI
* Supported WDAC compliant APIs
* Fixed module versions of dependent PS modules
* Updated Remote Support cmdlets to check device type between HCIv2 and AzureEdge

#### Az.Storage
* Supported generate DataLakeGen2 Sas token with Encryption scope
    -  'New-AzDataLakeGen2SasToken'
* Supported blob type conversions in sync blob copy
    - 'Copy-AzStorageBlob'
* Supported create/upgrade storage account with Keyvault from another tenant and access Keyvault with FederatedClientId
  * 'New-AzStorageAccount'
  * 'Set-AzStorageAccount'
* Supported find blobs in a container with a blob tag filter sql expression
  * 'Get-AzStorageBlobByTag'
* Migrated following Azure File dataplane cmdlets from 'Microsoft.Azure.Storage.File' to 'Azure.Storage.Files.Shares'
  * 'Get-AzStorageFileHandle'
  * 'Close-AzStorageFileHandle'

#### Az.Websites
* Fixed 'Publish-AzWebApp' to use latest publish API when deploying war package [#19791]

### Thanks to our community contributors
* @alekiv, Fix typo in Example 1 (#19727)
* Johan Vanneuville (@JohanVanneuville), Update New-AzGalleryApplicationVersion.md (#19858)
* Simon Bass (@nimsarr), Fix typos (#19912)
* @wooch82, Update New-AzApplicationInsightsContinuousExport.md (#19802)

## 9.0.1 - October 2022
#### Az.Accounts
* Upgraded Azure.Core to 1.25.0 and Azure.Identity to 1.6.1
* Upgraded Microsoft.Identity.Client to 4.46.2 and Microsoft.Identity.Client.Extensions.Msal to 2.23.0
* Upgraded Microsoft.ApplicationInsights to 2.13.1
* [Breaking Change] Changed target framework of AuthenticationAssemblyLoadContext to netcoreapp3.1.
* [Breaking Change] Removed built-in environment of Azure Germany
* Supported tenant domain as input while using 'Connect-AzAccount' with parameter 'Tenant'. [#19471]
* Used the ArgumentCompleter attribute to replace the dynamic parameters of 'Get-AzContext'. [#18041]
* Fixed issue that module cannot be imported when required file is locked [#19624]

#### Az.Advisor
* Bumped API version to 2020-01-01

#### Az.Aks
* [Breaking Change] Removed the alias 'Install-AzAksKubectl' of 'Install-AzAksCliTool'.

#### Az.ApiManagement
* [Breaking Change] Changed the type of parameter 'Sku' from Enum to String in 'Add-AzApiManagementRegion', 'New-AzApiManagement' and 'Update-AzApiManagementRegion'.

#### Az.Attestation
* [Breaking Change] Replaced 'New/Remove/Get-AzAttestation' with 'New/Remove/Get-AzAttestationProvider'
* Added 'Get-AzAttestationDefaultProvider' and 'Update-AzAttestationProvider'
* Upgraded API version from 2018-09-01-preview to 2020-10-01

#### Az.Automation
* Added cmdlets 'Remove-AzAutomationHybridRunbookWorker', 'Remove-AzAutomationHybridRunbookWorkerGroup', 'Set-AzAutomationHybridRunbookWorkerGroup', 'Get-AzAutomationHybridRunbookWorker', 'Get-AzAutomationHybridRunbookWorkerGroup', 'Move-AzAutomationHybridRunbookWorker', 'New-AzAutomationHybridRunbookWorker', 'New-AzAutomationHybridRunbookWorkerGroup' for Hybrid Runbook Worker group management.

#### Az.Compute
* Added the 'TimeCreated' property to the Virtual Machine and Virtual Machine Scale Set models.
* Added Confidential VM functionality to multiple cmdlets.
  * Added new parameter 'SecureVMDiskEncryptionSet' to cmdlet 'Set-AzDiskSecurityProfile'.
  * Added new parameters 'SecureVMDiskEncryptionSet' and 'SecurityEncryptionType' to cmdlet 'Set-AzVMOSDisk'.
* Improved cmdlet descriptions and parameter descriptions for VM/VMSS creation.
* Added the 'BaseRegularPriorityCount' integer property to the following cmdlets: 'New-AzVmssConfig' and 'Update-AzVmssConfig'
* Added the 'RegularPriorityPercentage' integer property to the following cmdlets: 'New-AzVmssConfig' and 'Update-AzVmssConfig'
* Added Breaking Changes for Add-AzVMAdditionalUnattendContent and Get-AzGallery cmdlets
* Added '-DiskControllerType' property to the following cmdlets: 'New-AzVm', 'New-AzVmss', 'New-AzVmConfig', 'Set-AzVmssStorageProfile'

#### Az.Databricks
* Upgraded API version to 2022-04-01-preview
* Modified description of 'EnableNoPublicIP' parameter in the 'New-AzDatabricksWorkspace'. [#14381]

#### Az.DataFactory
* Updated ADF .Net SDK version to 6.4.0

#### Az.EventGrid
* Add remaining advanced filters
  * StringNotContains
  * StringNotBeginsWith
  * StringNotEndsWith
  * NumberInRange
  * NumberNotInRange
  * IsNullOrUndefined
  * IsNotNull

#### Az.EventHub
* Most cmdlets in Az.EventHub module have been migrated to a new format and would witness breaking changes. Please refer our migration guide https://go.microsoft.com/fwlink/?linkid=2204690 to know breaking changes in detail.

#### Az.Functions
* Enabled support to create Node 18 Preview and Java 17 Preview function apps (fixes issues #19184 and #18925)
* Removed the logic that checks for AzureGermanCloud in the cloud endpoints (fixes issue #19667)
* Hided generated unused cmdlets (fixes #16666)

#### Az.KeyVault
* Fixed the exception content swallowed issue when exception.Response is null [#19531]
* Added the existing parameters 'Exportable', 'Immutable', 'UseDefaultCVMPolicy', and 'ReleasePolicyPath'
  to the parameter sets 'InteractiveCreate', 'InputObjectCreate', and 'ResourceIdCreate'.

#### Az.MarketplaceOrdering
* Upgraded API version to 2021-01-01.

#### Az.Migrate
* Updated ApiVersion to 2022-05-01
* Added support for pause and resume
  * 'Suspend-AzMigrateServerReplication'
  * 'Resume-AzMigrateServerReplication'
* [Breaking Change] Removed unless cmdlets
  * 'Get-AzMigrateReplicationEligibilityResult'
  * 'Get-AzMigrateReplicationProtectionIntent'
  * 'Get-AzMigrateReplicationVaultSetting'
  * 'Get-AzMigrateSupportedOperatingSystem'
  * 'New-AzMigrateReplicationProtectionIntent'
  * 'New-AzMigrateReplicationVaultSetting'

#### Az.Monitor
* [Breaking Change] Upgraded API version for ActivityLogAlert from 2017-04-01 to 2020-10-01, affected cmdlets:
  * 'Get-AzActivityLogAlert'
  * 'Remove-AzActivityLogAlert'
  * 'Set-AzActivityLogAlert' replaced by 'New-AzActivityLogAlert'
  * 'Disable-AzActivityLogAlert' replaced by 'Update-AzActivityLogAlert'
  * 'Enable-AzActivityLogAlert' replaced by 'Update-AzActivityLogAlert'
  * 'New-AzActionGroup' replaced by 'New-AzActivityLogAlertActionGroupObject'
* [Breaking Change] Upgraded API version for DiagnosticSetting from 2017-05-01-preview to 2021-05-01-preview
  * 'Get-AzDiagnosticSettingCategory'
  * 'Get-AzDiagnosticSetting'
  * 'New-AzDiagnosticSetting'
  * 'Remove-AzDiagnosticSetting'
  * 'Set-AzDiagnosticSetting' replaced by 'New-AzDiagnosticSetting'
  * 'New-AzDiagnosticDetailSetting' replaced by 'New-AzDiagnosticSettingLogSettingsObject' and 'New-AzDiagnosticSettingMetricSettingsObject'
  * 'Get-AzSubscriptionDiagnosticSettingCategory' replaced by 'Get-AzEventCategory'
* [Breaking Change] Upgraded API version for Autoscale from 2015-04-01 to 2022-10-01
  * 'Get-AzAutoscaleSetting'
  * 'Remove-AzAutoscaleSetting'
  * 'Add-AzAutoscaleSetting' replaced by 'New-AzAutoscaleSetting'
  * 'New-AzAutoscaleNotification' replaced by 'New-AzAutoscaleNotificationObject'
  * 'New-AzAutoscaleProfile' replaced by 'New-AzAutoscaleProfileObject'
  * 'New-AzAutoscaleRule' replaced by 'New-AzAutoscaleScaleRuleObject'
  * 'New-AzAutoscaleWebhook' replaced by 'New-AzAutoscaleWebhookNotificationObject'
* [Breaking Change] Upgraded API version for ScheduledQueryRule from 2018-04-16 to 2021-08-01
  * 'Get-AzScheduledQueryRule'
  * 'New-AzScheduledQueryRuleAlertingAction'
  * 'New-AzScheduledQueryRuleAznActionGroup'
  * 'New-AzScheduledQueryRule'
  * 'New-AzScheduledQueryRuleLogMetricTrigger'
  * 'New-AzScheduledQueryRuleSchedule'
  * 'New-AzScheduledQueryRuleSource'
  * 'New-AzScheduledQueryRuleTriggerCondition'
  * 'Remove-AzScheduledQueryRule'
  * 'Set-AzScheduledQueryRule'
  * 'Update-AzScheduledQueryRule'

#### Az.MySql
* Added 'PublicNetworkAccess' to 'Update-AzMySqlServer' [#19189]

#### Az.Network
* Added a new endpoint switch 'AzureArcVM' in 'New-AzNetworkWatcherConnectionMonitor'
* Updated 'New-AzVirtualNetworkGatewayConnection' to support bypassing the ExpressRoute gateway when accessing private-links
* Updated 'Update-AzCustomIpPrefix' to support no-internet advertise CustomIpPrefix
* Updated 'New-AzNetworkInterface' to support create/update nic with DisableTcpStateTracking property
* Updated cmdlet to support specifying a VirtualRouterAsn on Virtual Hub
  * 'New-AzVirtualHub'
  * 'Update-AzVirtualHub'
* Updated cmdlet to support specifying an ASN on VPN Gateway
  * 'New-AzVpnGateway'
  * 'Update-AzVpnGateway'
* Updated 'New-AzRoutingConfiguration' to support bypassing NVA for spoke vNet traffic
* Updated 'Update-AzCustomIpPrefix' to support new parameters: Asn, Geo, ExpressRouteAdvertise
* Updated cmdlets to enable verification on client certificate revocation by using a new property VerifyClientRevocation in ApplicationGatewayClientAuthConfiguration
  * 'New-AzApplicationGatewayClientAuthConfiguration'
  * 'Set-AzApplicationGatewayClientAuthConfiguration'
* Updated 'New-AzCustomIpPrefix' to support IPv4 Parent/Child CustomIpPrefix creation.
* Added Uppercase Transform in New-AzApplicationGatewayFirewallCondition
* Added DdosProtectionMode parameter in New-AzPublicIpAddress
* Added ProbeThreshold parameter to Load Balancer Probe
  * 'Add-AzLoadBalancerProbeConfig'
  * 'New-AzLoadBalancerProbeConfig'
  * 'Set-AzLoadBalancerProbeConfig'
* Updated 'New-AzApplicationGatewayFirewallPolicyManagedRuleOverride' to support specifying an action for a managed rule override in Application Gateway WAF Policy
* Added breaking change enum values/notification for the following network manager cmdlets
  * 'Deploy-AzNetworkManagerCommit'
  * 'New-AzNetworkManagerConnectivityConfiguration'
  * 'New-AzNetworkManagerConnectivityGroupItem'
  * 'New-AzNetworkManagerSecurityAdminRule'
  * 'New-AzNetworkManagerSecurityAdminConfiguration'
  * 'New-AzNetworkManagerAddressPrefixItem'
  * 'New-AzNetworkManager'
* Added 'EnableUDPLogOptimization' parameter to 'New-AzFirewall'
* Fixed a bug that does not return HubIPAddresses and PrivateIPAddress during a Get-AzFirewall command
* Replaced 'IdentifyTopFatFlow' parameter with 'EnableFatFlowLogging' parameter to 'New-AzFirewall'
* Fixed a bug not able to add MSSQL application rules to an AZURE FIREWALL POLICY
* Onboard Project AzureML Registries to Private Link Common Cmdlets

#### Az.RecoveryServices
* [Breaking Change] Added fix for Enable-AzRecoveryServicesBackupProtection cmdlet. Resolved the null reference issue by making policy a mandatory parameter.
* [Breaking Change] Removed status filter from Get-AzRecoveryServicesBackupContainer command
* Added SubTasks Duration for IaasVM job

#### Az.Resources
* Fixed NullReferenceException issue in 'New-AzRoleAssignment' [#19793]

#### Az.SecurityInsights
* Changed 'Az.SecurityInsights' to autorest-based module

#### Az.ServiceBus
* Most cmdlets in Az.ServiceBus module have been migrated to a new format and would witness breaking changes. Please refer our migration guide https://go.microsoft.com/fwlink/?linkid=2204584 to know breaking changes in detail.

#### Az.Sql
* Added new fields to the 'Get-AzSqlInstanceDatabaseLogReplay' cmdlet
* Improved error handling in the 'Stop-AzSqlInstanceDatabaseLogReplay' cmdlet
* Added StorageContainerIdentity parameter in the 'Start-AzSqlInstanceDatabaseLogReplay' cmdlet
* Removed the following cmdlets: 'Clear-AzSqlServerAdvancedThreatProtectionSetting' and 'Clear-AzSqlDatabaseAdvancedThreatProtectionSetting'
* Added the following cmdlets: 'Get-AzSqlInstanceDatabaseAdvancedThreatProtectionSetting', 'Get-AzSqlInstanceAdvancedThreatProtectionSetting', 'Update-AzSqlInstanceDatabaseAdvancedThreatProtectionSetting' and 'Update-AzSqlInstanceAdvancedThreatProtectionSetting'
* Removed the following aliases: 'Enable-AzSqlServerAdvancedThreatProtection', 'Disable-AzSqlServerAdvancedThreatProtection', 'Get-AzSqlServerThreatDetectionSetting', 'Remove-AzSqlServerThreatDetectionSetting', 'Set-AzSqlServerThreatDetectionSetting', 'Get-AzSqlDatabaseThreatDetectionSetting', 'Set-AzSqlDatabaseThreatDetectionSetting' and 'Remove-AzSqlDatabaseThreatDetectionSetting'
* Changed the returned object for the following cmdlets: 'Get-AzSqlServerAdvancedThreatProtectionSetting' and 'Get-AzSqlDatabaseAdvancedThreatProtectionSetting'
* Changed the parameters for the following cmdlets: 'Update-AzSqlServerAdvancedThreatProtectionSetting' and 'Update-AzSqlDatabaseAdvancedThreatProtectionSetting'. Only 'Enable' parameter is now supported.
* Changed endpoint used in SQL Server and SQL Instance from AD Graph to MS Graph

#### Az.StackHCI
* Made GraphAccessToken parameter obsolete in Register-AzStackHCI, Unregister-AzStackHCI and Set-AzStackHCI cmdlets. This is because Az.StackHCI module does not depend on Azure AD anymore.
* Include API version for all Microsoft.AzStackHCI related AZ-Resource calls

#### Az.Storage
* Migrated following Azure File dataplane cmdlets from 'Microsoft.Azure.Storage.File 11.2.2' to 'Azure.Storage.Files.Shares 12.10.0'
  * 'Get-AzStorageFile'
  * 'Get-AzStorageFileCopyState'
  * 'Get-AzStorageShare'
  * 'Get-AzStorageShareStoredAccessPolicy'
  * 'New-AzStorageDirectory'
  * 'New-AzStorageFileSasToken'
  * 'New-AzStorageShare'
  * 'New-AzStorageShareSasToken'
  * 'New-AzStorageShareStoredAccessPolicy'
  * 'Remove-AzStorageDirectory'
  * 'Remove-AzStorageFile'
  * 'Remove-AzStorageShare'
  * 'Remove-AzStorageShareStoredAccessPolicy'
  * 'Set-AzStorageShareQuota'
  * 'Set-AzStorageShareStoredAccessPolicy'
  * 'Start-AzStorageFileCopy'
  * 'Stop-AzStorageFileCopy'
* Migrated Get/List blob to always use 'Azure.Storage.Blobs'
  * 'Get-AzStorageBlob'
* Fix create file sas failure with file object pipeline
  * 'New-AzStorageFileSasToken'

#### Az.Synapse
* [Breaking Change] Updated models of Synapse Link for Azure Sql Database
* Updated 'New-AzSynapseWorkspace' and 'Update-AzSynapseWorkspace' to support for user assigned managed identity (UAMI) by '-UserAssignedIdentityAction' and '-UserAssignedIdentityId'
* Added EnablePublicNetworkAccess parameter to 'New-AzureSynapseWorkspace' and 'Update-AzSynapseWorkspace'

### Thanks to our community contributors
* Aliaksei Venski (@AliakseiVenski), Update New-AzServiceBusAuthorizationRuleSASToken.md (#19521)
* Jason (@moo2u2), Fixed multiple hostnames param for app gateway http listener (#19451)
* Jan-Hendrik Peters [MSFT] (@nyanhp), [Connect-AzConnectedMachine] Fixes error with return value processing (#19542)
* @rahulbissa2727, PS changes for Uppercase Transform (#19546)

## 8.3.0 - September 2022
#### Az.Accounts
* Supported returning all subscriptions with specified name while using 'Get-AzSubscription' with parameter 'SubscriptionName'. [#19295]
* Fixed null reference exception when cmdlet uses AzureRestOperation [#18104]
* Updated survey message and settings

#### Az.Aks
* Added support of 'FQDN' in 'Import-AzAksCredential' [#17711]
* Added hint when 'Import-AzAksCredential' meets bad formatted kubernetes configuration file [#16741]
* Added parameter '-NodeResourceGroup' for 'New-AzAksCluster'. [#19014]
* Added support for 'Auto Upgrade' in 'New-AzAksCluster' and 'Set-AzAksCluster'.
* Added support for 'Http Proxy' in 'New-AzAksCluster' and 'Set-AzAksCluster'.
* Added parameter 'DisableLocalAccount' and 'DiskEncryptionSetID' in 'New-AzAksCluster' and 'Set-AzAksCluster'.
* Added logic for installing 'kubelogin' in 'Install-AzAksKubectl'.

#### Az.ApiManagement
* Added warning message for upcoming breaking change: changed the type of parameter Sku from Enum to String
* Supported GraphQL Specification Format

#### Az.AppConfiguration
* Added cmdlets 'Get-AzAppConfigurationDeletedStore' and 'Clear-AzAppConfigurationDeletedStore'
* Updated ApiVersion to 2022-05-01.

#### Az.Automation
* Fixed bug: Export-AzAutomationRunbook no longer adds extra '\' to file names [#11101]
* Fixed bug: Get-AzAutomationDscCompilationJobOutput returns complete summaries [#12322]
* Fixed bug: Get-AzAutomationDscNode [#10404]
* Fixed bug: Get-AzAutomationJob fails for some jobIds

#### Az.Batch
* Fixed a bug wherein creating a new JobSchedule does not properly submit Output Files.

#### Az.Compute
* Added Trusted Launch Generic Breaking Change warning for 'New-AzVM', 'New-AzDisk' and 'New-AzVMSS' cmdlets.
* 'Get-AzVMRunCommand' now shows all the properties of VMRunCommand in a list format.
* Added new Parameter '-PublicIpSku' to the 'NewAzVM' cmdlet with acceptable values : 'Basic' and 'Standard'.
* Added Generic Breaking Change PublicIpSku Warning and Overridden '-Zone' logic when '-PublicIpSku' is explicitly provided.
* Added Disk Delete Optional parameters 'OsDisk Deletion Option' and 'Delete Option' to the 'Set-AzVmssStorageProfile' (OS Disk) and 'Add-AzVmssDataDisk' (Data Disk)
* Improved printed output for 'Get-AzComputeResourceSku'
* Updated 'Update-AzVm' to give constructive error messages when empty variables are passed in parameters. [#15081]
* Added 'Zone' and 'IntentVMSizeList' optional parameters to the cmdlet 'New-AzProximityPlacementGroup'.
* Added parameters to Gallery cmdlets for Community Galleries
* For 'New-AzGalleryImageVersion', 'CVMEncryptionType' and 'CVMDiskEncryptionSetID' added as keys for parameter '-Target'.

#### Az.DesktopVirtualization
* Corrected parameter description of '-Force' in 'Remove-AzWvdUserSession'.

#### Az.EventGrid
* Updated to use the 2021-12-01 API version.
* Added new features:
    - System topic
    - System topic event subscription
    - System topic event subscription delivery attributes
* Updated cmdlets:
    - 'New-AzEventGridDomain':
        - Add new optional parameters to support auto creation of topic with first subscription.
        - Add new optional parameters to support auto deletion of topic with last subscription.
        - Add optional parameters to support azure managed identity
    - 'New-AzEventGridTopic'/'Update-AzEventGridTopic' :
        - Add optional parameters to support azure managed identity
    - 'New-AzEventGridSubscription '/'Update-AzEventGridSubscription ':
        - Add new optional parameters to support advanced filtering on arrays.
        - Add new optional parameters to support delivery attribute mapping.
        - Add new optional parameters to support storage queue message ttl.

#### Az.EventHub
* In the upcoming major breaking change release in October 2022, Az.EventHub would be migrating most cmdlets to a new format
for a better powershell experience and as a result would witness breaking changes. Please refer our migration guide to know more https://go.microsoft.com/fwlink/?linkid=2204690.

#### Az.Functions
* Made PowerShell 7.2 the default when creating a PowerShell function app

#### Az.KeyVault
* Fixed parameter validation logic of '-UseDefaultCVMPolicy'
* Added parameter 'ContentType' in 'Import-AzKeyVaultCertificate' to support importing pem via certificate string
* Allowed 'DnsName' in 'New-AzKeyVaultCertificatePolicy' to accept an empty list [#18954]

#### Az.MarketplaceOrdering
* Added a warning message for an upcoming breaking change to 'Get-AzMarketplaceTerms'.

#### Az.Monitor
* Added breaking change warning messages for
    - 'ActivityLogAlert'
    - 'DiagnosticSetting'
    - 'ScheduledQueryRule'
    - 'Autoscale'

#### Az.Network
* Added breaking change notification for 'Get-AzFirewall', 'New-AzFirewall', 'Set-AzFirewall' and 'New-AzFirewallHubIpAddress'

#### Az.OperationalInsights
* Added new cmdlets for Table resource: 'New-AzOperationalInsightsRestoreTable', 'New-AzOperationalInsightsSearchTable', 'New-AzOperationalInsightsTable','Remove-AzOperationalInsightsTable','Update-AzOperationalInsightsTable', 'Convert-AzOperationalInsightsMigrateTable'
* Added new property 'DefaultDataCollectionRuleResourceId' to 'Set-AzOperationalInsightsWorkspace' and to 'New-AzOperationalInsightsWorkspace' cmdlets

#### Az.PolicyInsights
* Updated parameter documentation for Get-AzPolicyState

#### Az.RecoveryServices
* Added support for Archive smart tiering for AzureVM and MSSQL workloads.

#### Az.Resources
* Fixed bug '-Password' overwrite '-PasswordProfile' in 'New-AzADUser' [#19265]
* Exposed 'EmployeeOrgData' 'Manager' for 'Get-AzADUSer' [#18205]
* Exposed parameter '-Count' for 'Get-AzADUser' [#16874]

#### Az.ServiceBus
* In the upcoming major breaking change release in October 2022, Az.ServiceBus would be migrating most cmdlets to a new format
for a better powershell experience and as a result would witness breaking changes. Please refer our migration guide to know more https://go.microsoft.com/fwlink/?linkid=2204584.
* Added -MinimumTlsVersion to New-AzServiceBusNamespace and Set-AzServiceBusNamespace

#### Az.Storage
* Supported to create or update Storage account with Azure Files Active Directory Domain Service Kerberos Authentication
    -  'New-AzStorageAccount'
    -  'Set-AzStorageAccount'
* Supported create/upgrade storage account by enable sftp and enable localuser
    -  'New-AzStorageAccount'
    -  'Set-AzStorageAccount'
* Supported manage local user of a storage account
    -  'Set-AzStorageLocalUser'
    -  'Get-AzStorageLocalUser'
    -  'Remove-AzStorageLocalUser'
    -  'New-AzStorageLocalUserSshPassword'
    -  'Get-AzStorageLocalUserKey'
    -  'New-AzStorageLocalUserSshPublicKey'
    -  'New-AzStorageLocalUserPermissionScope'
* Supported soft delete DataLake Gen2 item
    - 'Get-AzDataLakeGen2DeletedItem'
    - 'Restore-AzDataLakeGen2DeletedItem'

#### Az.Synapse
* Updated 'New-AzSynapseSparkPool' and 'Update-AzSynapseSparkPool' to support for setting spark pool dynamic executor allocation by '-EnableDynamicExecutorAllocation'

#### Az.Websites
* Fixed 'Import-AzWebAppKeyVaultCertificate' to use certificate naming convention same as Az-CLI

#### Thanks to our community contributors
* Harshit Aggarwal (@harshit283), Onboard EnergyServices to PrivatelinkCommonCmdlets (#19271)
* Jarrad O'Brien (@jarrad-obrien), typo (#19153)
* sravani saluru (@sravanisaluru), Update Set-AzSynapseSqlPoolAuditSetting.md (#18839)

## 8.2.0 - August 2022
#### Az.Accounts
* Implemented 'SupportsShouldProcess' for 'Invoke-AzRestMethod'
* Supported giving suggestions if an Azure PowerShell command cannot be found, for example when there is a typo in command name.

#### Az.Aks
* Removed the warning messages for MSGraph migration [#18856]

#### Az.Compute
* Added parameters 'PackageFileName', 'ConfigFileName' for 'New-AzGalleryApplicationVersion'

#### Az.ConfidentialLedger
* General availability of 'Az.ConfidentialLedger'

#### Az.EventHub
* Added -MinimumTlsVersion to New-AzEventHubNamespace and Set-AzEventHubNamespace
* Added -SupportsScaling to New-AzEventHubCluster and Set-AzEventHubCluster to support self serve clusters
* Deprecation warning on a few parameters in cluster cmdlets that will be deprecated in the November major release

#### Az.KeyVault
* Removed the warning messages for MSGraph migration [#18856]

#### Az.Migrate
* Fixed a cross-subscription issue

#### Az.Network
* Updated cmdlets to add new property of 'ExplicitProxy' in Azure Firewall Policy.
    - 'New-AzFirewallPolicyExplicitProxy'
    - 'New-AzFirewallPolicy'
    - 'Set-AzFirewallPolicy'
* Added new cmdlets to create packet captures for Network Watcher:
    - 'New-AzNetworkWatcherPacketCaptureV2'
    - 'New-AzPacketCaptureScopeConfig'
* Added support for CustomV2 ssl policies for Application Gateway.
    - Added 'CustomV2' to the validation set of 'PolicyType'
    - Added 'TLSv1_3' to the validation set of 'MinProtocolVersion'
    - Removed validation for null or empty cipher suites list since there can be empty cipher suites list for min protocol version of tls1.3
* Network Watcher Feature Change: Added new paramenter i.e. AzureVMSS as source endpoint in ConnectionMonitor.
    - 'New-AzNetworkWatcherConnectionMonitorEndpointObject'
* Added 'IdentifyTopFatFlow' parameter to 'AzureFirewall'
    - 'New-AzFirewall'
* Enabled Azure Firewall forced tunneling by default (AzureFirewallManagementSubnet and ManagementPublicIpAddress are required) whenever basic sku firewall is created.
    - 'New-AzFirewall'
* Fixed bug that causes an overflow due to incorrect SNAT private ranges IP validation.
* Added new cmdlets to create/manage L4(TCP/TLS) objects for ApplicationGateway:
	- 'Get-AzApplicationGatewayListener'
	- 'New-AzApplicationGatewayListener'
	- 'Add-AzApplicationGatewayListener'
	- 'Set-AzApplicationGatewayListener'
	- 'Remove-AzApplicationGatewayListener'
	- 'Get-AzApplicationGatewayBackendSetting'
	- 'New-AzApplicationGatewayBackendSetting'
	- 'Add-AzApplicationGatewayBackendSetting'
	- 'Set-AzApplicationGatewayBackendSetting'
	- 'Remove-AzApplicationGatewayBackendSetting'
	- 'Get-AzApplicationGatewayRoutingRule'
	- 'New-AzApplicationGatewayRoutingRule'
	- 'Add-AzApplicationGatewayRoutingRule'
	- 'Set-AzApplicationGatewayRoutingRule'
	- 'Remove-AzApplicationGatewayRoutingRule'
* Updated cmdlet to add TCP/TLS Listener , BackendSetting , RoutingRule support for  Application Gateway:
	- 'New-AzApplicationGateway'
* Updated cmdlets to add TCP/TLS protocol support for Application gateway Health Probe configuration:
	- 'Set-AzApplicationGatewayProbeConfig'
	- 'Add-AzApplicationGatewayProbeConfig'
	- 'New-AzApplicationGatewayProbeConfig'
* Updated cmdlets to add basic sku support on Azure Firewall and Azure Firewall Policy:
    - 'New-AzFirewall'
    - 'New-AzFirewallPolicy'
    - 'Set-AzFirewallPolicy'
* Added new cmdlets to create/manage authorization objects for ExpressRoutePort:
    - 'Add-AzExpressRoutePortAuthorization'
    - 'Get-AzExpressRoutePortAuthorization'
    - 'Remove-AzExpressRoutePortAuthorization'
* Added option parameter 'AuthorizationKey' to cmdlet 'New-AzExpressRouteCircuit' to allow creating ExpressRoute Circuit on a ExpressRoutePort with a different owner.
* Fixed bug that can't display CustomIpPrefix in PublicIpPrefix.
* Updated cmdlets to add new property of 'HubRoutingPreference' in VirtualHub and set property of 'PreferredRoutingGateway' deprecated .
    - 'New-AzVirtualHub'
    - 'Update-AzVirtualHub'
* Added optional parameter 'AuxiliaryMode' to cmdlet 'New-AzNetworkInterface' to enable this network interface as Sirius enabled. Allowed values are None(default) and MaxConnections.
* Multipool feature change: Updated cmdlets to add new optional property: 'ConfigurationPolicyGroups' object for associating policy groups.
    - 'Update-AzVpnServerConfiguration'
    - 'New-AzVpnServerConfiguration'
* Multipool feature change: Updated cmdlets to add new optional property: 'P2SConnectionConfiguration' object for specifying multiple Connection configurations.
    - 'Update-AzP2sVpnGateway'
    - 'New-AzP2sVpnGateway'
* Multipool feature change: Added new cmdlets to support CRUD of Configuration policy groups for VpnServerConfiguration.
    - 'Get-AzVpnServerConfigurationPolicyGroup'
    - 'New-AzVpnServerConfigurationPolicyGroup'
    - 'Update-AzVpnServerConfigurationPolicyGroup'
    - 'Remove-AzVpnServerConfigurationPolicyGroup'
* Added new cmdlets for RoutingIntent child resource of VirtualHub.
    -'Add-AzRoutingPolicy'
    -'Get-AzRoutingPolicy'
    -'New-AzRoutingPolicy'
    -'Remove-AzRoutingPolicy'
    -'Set-AzRoutingPolicy'
    -'Get-AzRoutingIntent'
    -'New-AzRoutingIntent'
    -'Remove-AzRoutingIntent'
    -'Set-AzRoutingIntent'
* Updated cmdlets to add new option of 'HubRoutingPreference' in RouteServer.
    - 'New-AzRouteServer'
    - 'Update-AzRouteServer'
* Fixed bug that can't parse CustomIpPrefixParent parameter from swagger to powershell.
* Added 'Any' operator in New-AzApplicationGatewayFirewallCondition
* Made properties 'ApplicationSecurityGroups' and 'IpConfigurations' for 'PrivateEndpoint' updatable in the cmdlet 'Set-AzPrivateEndpoint'
* Onboarded Device Update for IoT Hub to Private Link Common Cmdlets

#### Az.RedisEnterpriseCache
* Upgraded API version to 2022-01-01

#### Az.Resources
* Removed the warning messages for MSGraph migration [#18856]
* [Breaking Change] Renamed cmdlet from '{}-AzADAppFederatedIdentityCredential' to '{}-AzADAppFederatedCredential'
* [Breaking Change] Renamed '-Id' to '-FederatedCredentialId' for
    - 'Get-AzADAppFederatedCredential'
    - 'Remove-AzADAppFederatedCredential'
    - 'Update-AzADAppFederatedCredential'
* Upgraded API version from Beta to 1.0

#### Az.Sql
* Removed the warning messages for MSGraph migration [#18856]
* Moved SQL Server and SQL Instance from ActiveDirectoryClient to MicrosoftGraphClient
* Supported cross-subscription Failover Group creation using 'PartnerSubscriptionId' parameter in 'New-AzSqlDatabaseFailoverGroup' cmdlet

#### Az.Storage
* Added check for storage account sas token is secured with the storage account key.
    -  'New-AzStorageAccountSASToken'
* Supported Management Policy rule filter BlobIndexMatch
    -  Added a new cmdlet 'New-AzStorageAccountManagementPolicyBlobIndexMatchObject'
    -  Added a new parameter 'BlobIndexMatch' in 'New-AzStorageAccountManagementPolicyFilter'

#### Az.Synapse
* Set 'ResourceGroupName' as optional for 'Set-AzSynapseSqlAuditSetting' cmdlet
* Added LastCommitId parameter to 'New-AzureSynapseGitRepositoryConfig'
* Fixed the issue that update spark pool version fail by 'Update-AzSynapseSparkPool'

#### Az.Websites
* Fixed 'Publish-AzWebapp' to handle relative paths properly [#18028]

### Thanks to our community contributors
* Harish Karthic (@hkarthik7), Updated parameter name from `-Type` to `-SkuName` (#18882)
* Oscar de Groot (@odegroot), Fix "save as pfx" example (#19003)
* @shiftychris, Update New-AzApplicationGatewayFirewallPolicyManagedRuleSet.md (#18972)

## 8.1.0 - July 2022
#### Az.Accounts
* Supported exporting and importing configurations by 'Export-AzConfig' and 'Import-AzConfig'.
* Fixed an issue that Az.Accounts may fail to be imported in parallel PowerShell processes. [#18321]
* Fixed incorrect access token [#18105]
* Upgraded version of Microsoft.Identity.Client for .NET Framework. [#18495]
* Fixed an issue that Az.Accounts failed to be imported if multiple environment variables, which only differ by case, are set. [#18304]

#### Az.Aks
* Added parameter 'CommandContextAttachmentZip' for 'Invoke-AzAksRunCommand'. [#17454]
* Added ManagedIdentity support for Aks[#15656].
* Added property 'PowerState' for the output of 'Get-AzAksCluster'[#18271]
* Updated the logic of 'Set-AzAksCluster' for parameter 'NodeImageOnly'.
* Added parameter 'NodeImageOnly' for 'Update-AzAksNodePool'.
* Added parameter 'AvailabilityZone' for 'New-AzAksCluster'. [#18658]

#### Az.ApplicationInsights
* Fixed parameters for Set-AzApplicationInsightsDailyCap [#18315]
* Fixed parameter 'DocumentType' for 'New-AzApplicationInsightsContinuousExport' and 'Set-AzApplicationInsightsContinuousExport' [#18350]
* Fixed parameter 'ResourceId' for 'Get-AzApplicationInsights' [#18707]

#### Az.Compute
* Added image alias 'Win2022AzureEditionCore'
* Added the '-DisableIntegrityMonitoring' switch parameter to the 'New-AzVM' cmdlet.
  Changed the default behavior for 'New-AzVM' and 'New-AzVmss' when these conditions are met:
  1) '-DisableIntegrityMonitoring' is not true.
  2) 'SecurityType' on the SecurityProfile is 'TrustedLaunch'.
  3) 'VTpmEnabled' on the SecurityProfile is true.
  4) 'SecureBootEnabled' on the SecurityProfile is true.
  Now 'New-AzVM' will install the 'Guest Attestation' extension to the new VM when these conditions are met.
  Now 'New-AzVmss' will install the 'Guest Attestation' extension to the new Vmss when these conditions are met and installed to all VM instances in the Vmss.
* Added '-UserAssignedIdentity' and '-FederatedClientId' to the following cmdlets:
    - 'New-AzDiskEncryptionSetConfig'
    - 'Update-AzDiskEncryptionSet'
* Added '-TreatFailureAsDeploymentFailure' to cmdlets 'Add-AzVmGalleryApplication' and 'Add-AzVmssGalleryApplication'
* Removed Exceptions for when SinglePlacementGroup is set to true in 'OrchestrationMode'

#### Az.CosmosDB
* Added support for partition key and id paths to be part of client encryption policy.
* Fixed bug related to Update-AzCosmosDBSqlContainer command on containers with Client Encryption Policy.

#### Az.DataFactory
* Updated ADF .Net SDK version to 6.3.0

#### Az.EventHub
* Added cmdlets for CRUD operations on EventHub Application Groups. The added cmdlets include,
    -New-AzEventHubApplicationGroup
    -Set-AzEventHubApplicationGroup
    -Remove-AzEventHubApplicationGroup
    -Get-AzEventHubApplicationGroup
    -New-AzEventHubThrottlingPolicyConfig
* Get-AzEventHubNamespace returned a maximum of 100 namespaces for list by resource groups or list by subscriptions so far. From here onwards, for resource groups and subscriptions with over a 100 namespaces, the cmdlet will return all the namespaces. You will not see a change in the cmdlet behaviour if your resource groups or subscriptions have less than a 100 namespaces.
* Added cmdlets for manual approval of EventHubs Private Endpoint Connections. The added cmdlets include,
    -Approve-AzEventHubPrivateEndpointConnection
    -Deny-AzEventHubPrivateEndpointConnection
    -Get-AzEventHubPrivateEndpointConnection
    -Remove-AzEventHubPrivateEndpointConnection
    -Get-AzEventHubPrivateLink

#### Az.KeyVault
* Supported importing pem certificate by 'Import-AzKeyVaultCertificate' [#18494]
* Supported accepting rotation policy in a JSON file
* [Breaking Change] Changed parameter 'ExpiresIn' in 'Set-AzKeyVaultKeyRotationPolicy' from TimeSpan? to string. It must be an ISO 8601 duration like 'P30D' for 30 days.
* [Breaking Change] Changed output properties 'ExpiresIn', 'TimeAfterCreate' and 'TimeBeforeExpiry' of 'Set-AzKeyVaultKeyRotationPolicy' and 'Get-AzKeyVaultKeyRotationPolicy' from TimeSpan? to string.
* Supported creating/updating key with release policy in a Managed HSM
* Removed default value for 'EnabledForDeployment', 'EnabledForTemplateDeployment', 'EnabledForDiskEncryption' and 'EnableRbacAuthorization' during the process of key vault creation
* Changed default access policies for Key Vault secret, certificate and storage as 'All'

#### Az.Network
* Added support for CustomV2 ssl policies for Application Gateway.
    - Added 'CustomV2' to the validation set of 'PolicyType'
    - Added 'TLSv1_3' to the validation set of 'MinProtocolVersion'
    - Removed validation for null or empty cipher suites list since there can be empty cipher suites list for min protocol version of tls1.3
* [Breaking Change] Changed default value of '-PrivateEndpointNetworkPoliciesFlag' to 'Disabled' in 'Add-AzVirtualNetworkSubnetConfig' and 'New-AzVirtualNetworkSubnetConfig'
* Fixed bugs that cannot parse virtual network encryption paramemters when updating exsiting vnet.

#### Az.PowerBIEmbedded
* Updated SKU allowed values to support A7 and A8

#### Az.RecoveryServices
* Fixed delay in long running operations [#18567]

#### Az.Resources
* Added feedback when deleting role assignments even if passthru is not used
* Fixed relative path failure in -AsJob scenario [#18084]
* Fixed logic of 'createtime' and 'ChangedTime' in 'Get-AzResource --ExpandProperties'. [#18206]
* Fixed role assignment latency for 'New-AzADServicePrincipal' [#16777]

#### Az.ServiceBus
* Added cmdlets for manual approval of Service Bus Private Endpoint Connections. The added cmdlets include,
    -Approve-AzServiceBusPrivateEndpointConnection
    -Deny-AzServiceBusPrivateEndpointConnection
    -Get-AzServiceBusPrivateEndpointConnection
    -Remove-AzServiceBusPrivateEndpointConnection
    -Get-AzServiceBusPrivateLink

#### Az.ServiceFabric
* Fixed typo in verbose log message.
* Added Tag support for managed cluster create and update

#### Az.Sql
* Added 'GeoZone' option to 'BackupStorageRedundancy' parameter to 'New-AzSqlDatabase', 'Set-AzSqlDatabase', 'New-AzSqlDatabaseCopy', 'New-AzSqlDatabaseSecondary', and 'Restore-AzSqlDatabase' to enable create, update, copy, geo secondary and PITR support for GeoZone hyperscale databases
* Added additional input validation to 'Stop-AzSqlInstanceDatabaseLogReplay' cmdlet to ensure the target database was created by log replay service
* Bug fix for cmdlet 'Restore-AzSqlDatabase'. The optional property 'Tags' was not working as expected
* Added isManagedIdentityInUse get parameter for 'Get-AzSqlServerAudit' and 'Get-AzSqlDatabaseAudit'
* Added new cmdlet 'Set-AzSqlInstanceDatabase'

#### Az.StackHCI
* Added support to Stack HCI Cluster
* Added support to Stack HCI Extension
* Added support to Stack HCI Arc Settings

#### Az.Storage
* Supported BaseBlob DaysAfterCreationGreaterThan in Management Policy
    -  'Add-AzStorageAccountManagementPolicyAction'

### Thanks to our community contributors
* @ayeshurun, Update SKU allowed values for PowerBI Embedded capacities (#18670)
* @JulianePadrao, [SQL] fix for deprecated term (#18620)
* @kaushik-ms, powershell changes for new ssl policies in appgw (#18287)
* Adrian Leonhard (@NaridaL), fix typo beging -> begin in 3 files (#18391)

## 8.0.0 - May 2022
#### Az.Accounts
* Added a preview feature allowing user to control the following configurations by using 'Get-AzConfig', 'Update-AzConfig' and 'Clear-AzConfig':
    - 'DefaultSubscriptionForLogin': Subscription name or GUID. Sets the default context for Azure PowerShell when logging in without specifying a subscription.
    - 'DisplayBreakingChangeWarning': Controls if warning messages for breaking changes are displayed or suppressed.
    - 'EnableDataCollection': When enabled, Azure PowerShell cmdlets send telemetry data to Microsoft to improve the customer experience.
* Upgraded System.Reflection.DispatchProxy on Windows PowerShell [#17856]
* Upgraded Azure.Identity to 1.6.0 and Azure.Core to 1.24.0

#### Az.Aks
* Removed these aliases:
  * 'Get-AzAks'
  * 'New-AzAks'
  * 'Set-AzAks'
  * 'Remove-AzAks'

#### Az.ApiManagement
* [Breaking change] Replaced parameter 'Sample' by 'Examples' in 'New-AzApiManagementOperation' and 'Set-AzApiManagementOperation'
* Updated APIM .Net SDK version to 8.0.0 / Api Version 2021-08-01

#### Az.ApplicationInsights
* Upgraded API version for ApplicationInsights component to 2020-02-02
* Supported Log Analytics workspace-based component by 'New-AzApplicationInsights' and 'Update-AzApplicationInsights'

#### Az.Cdn
* Upgraded API version to 2021-06-01
* Removed deprecated cmdlets
  - Disable-AzCdnCustomDomain
  - Enable-AzCdnCustomDomain
  - Get-AzCdnEdgeNodes
  - Get-AzCdnProfileSsoUrl
  - New-AzCdnDeliveryPolicy
  - Set-AzFrontDoorCdnSecret
* Added new cmdlets
  - Clear-AzFrontDoorCdnEndpointContent
  - Get-AzFrontDoorCdnEndpointResourceUsage
  - Get-AzFrontDoorCdnOriginGroupResourceUsage
  - Get-AzFrontDoorCdnProfileResourceUsage
  - Get-AzFrontDoorCdnRuleSetResourceUsage
  - Test-AzFrontDoorCdnEndpointCustomDomain
  - Test-AzFrontDoorCdnEndpointNameAvailability
  - Test-AzFrontDoorCdnProfileHostNameAvailability
  - Update-AzFrontDoorCdnCustomDomainValidationToken
  - Update-AzFrontDoorCdnRule
* Renamed Set cmdlets to Update cmdlets
* Renamed 'Unpublish-AzCdnEndpointContent' cmdlets to 'Clear-AzCdnEndpointContent'
* Added 'Object' suffix to memory object creation cmdlets

#### Az.Compute
* Edited 'New-AzVm' cmdlet internal logic to use the 'PlatformFaultDomain' value in the 'PSVirtualMachine' object passed to it in the new virtual machine.
* Added a new cmdlet named 'Restart-AzHost' to restart dedicated hosts.
* Added '-DataAccessAuthMode' parameter to the following cmdlets:
    - 'New-AzDiskConfig'
    - 'New-AzDiskUpdateConfig'
    - 'New-AzSnapshotConfig'
    - 'New-AzSnapshotUpdateConfig'
* Added '-Architecture' parameter to the following cmdlets:
    - 'New-AzDiskConfig'
    - 'New-AzDiskUpdateConfig'
    - 'New-AzSnapshotConfig'
    - 'New-AzSnapshotUpdateConfig'
    - 'New-AzGalleryImageDefinition'
* Added '-InstanceView' parameter to 'Get-AzRestorePoint'
* Added parameter '-ScriptString' to 'Invoke-AzvmRunCommand' and 'Invoke-AzvmssRunCommand'
* Added parameter '-ScaleInPolicyForceDeletion' to 'Update-Azvmss'

#### Az.ContainerRegistry
* Updated parameter types from bool to bool? for 'Update-AzContainerRegistryRepository' [#17857]
    - 'ReadEnabled'
    - 'ListEnabled'
    - 'WriteEnabled'
    - 'DeleteEnabled'

#### Az.CosmosDB
* Introduced support for creating containers with Client Encryption Policy. The current supported version of Client Encryption Policy is 1.

#### Az.DataFactory
* Updated ADF .Net SDK version to 6.1.0
* Fixed Set-AzDataFactoryV2 -InputObject not correct with PublicNetworkAccess Parameter

#### Az.EventHub
* Made 'IPRule' and 'VirtualNetworkRule' optional in 'Set-AzEventHubNetworkRuleSet'.
* Deprecated older MSI properties in 'Set-AzEventHubNamespace' and 'New-AzEventHubNamespace'

#### Az.Functions
* Fixed an issue that New-AzFunctionApp cmdlet should write a warning message when setting default values for parameters that are not provided.

#### Az.HealthcareApis
* Migrated module to generated codebase.
* Added cmdlets:
    - New/Get/Update/Remove-AzHealthcareApisService
    - New/Get/Update/Remove-AzHealthcareApisWorkspace
    - New/Get/Update/Remove-AzHealthcareFhirService
    - New/Get/Update/Remove-AzHealthcareDicomService
    - New/Get/Update/Remove-AzHealthcareIoTConnector
    - New/Get/Remove-AzHealthcareIotConnectorFhirDestination
    - Get-AzHealthcareFhirDestination

#### Az.KeyVault
* Added 'Rotate' into the list of permissions to keys [#17970]

#### Az.ManagedServiceIdentity
* General availability of 'Az.ManagedServiceIdentity'

#### Az.Network
* Supported 'Microsoft.Network/privateLinkServices' in 'Get-AzPrivateEndpointConnection' [#16984].
* Provided friendly message if resource type is not supported for private endpoint connection features [#17091].
* Added 'DisableIPsecProtection' to 'Virtual Network Gateway'.
* Added new cmdlets to create/manage authorization objects for ExpressRoutePort:
    - 'Add-AzExpressRoutePortAuthorization'
    - 'Get-AzExpressRoutePortAuthorization'
    - 'Remove-AzExpressRoutePortAuthorization'
* Added option parameter 'AuthorizationKey' to cmdlet 'New-AzExpressRouteCircuit' to allow creating ExpressRoute Circuit on a ExpressRoutePort with a different owner.
* Fix bug that can't display CustomIpPrefix in PublicIpPrefix.
* Updated cmdlets to add new property of 'HubRoutingPreference' in VirtualHub and set property of 'PreferredRoutingGateway' deprecated .
    - 'New-AzVirtualHub'
    - 'Update-AzVirtualHub'
* Added optional parameter 'AuxiliaryMode' to cmdlet 'New-AzNetworkInterface' to enable this network interface as Sirius enabled. Allowed values are None(default) and MaxConnections.
* Multipool feature change: Updated cmdlets to add new optional property: 'ConfigurationPolicyGroups' object for associating policy groups.
    - 'Update-AzVpnServerConfiguration'
    - 'New-AzVpnServerConfiguration'
* Multipool feature change: Updated cmdlets to add new optional property: 'P2SConnectionConfiguration' object for specifying multiple Connection configurations.
    - 'Update-AzP2sVpnGateway'
    - 'New-AzP2sVpnGateway'
* Multipool feature change: Added new cmdlets to support CRUD of Configuration policy groups for VpnServerConfiguration.
    - 'Get-AzVpnServerConfigurationPolicyGroup'
    - 'New-AzVpnServerConfigurationPolicyGroup'
    - 'Update-AzVpnServerConfigurationPolicyGroup'
    - 'Remove-AzVpnServerConfigurationPolicyGroup'

#### Az.RecoveryServices
* Added support for Multi-user authorization using Resource Guard for recovery services vault.
* Added support for cross subscription restore for recovery services vault, modified storage account to be fetched from target subscription.

#### Az.Resources
* Added cmdlet for Application federated identity credential
    - 'Get-AzADAppFederatedIdentityCredential'
    - 'New-AzADAppFederatedIdentityCredential'
    - 'Remove-AzADAppFederatedIdentityCredential'
    - 'Update-AzADAppFederatedIdentityCredential'
* Upgraded and revised 'Get-AzLocation' cmdlet:
    - Upgraded 'subscriptionClient' for 'Get-AzLocation'. Changed its apiVersion from 2016-01-01 to 2021-01-01.[#18002]
    - Added all attributes of location info for 'Get-AzLocation', including 'pairedRegion' and so on. [#18045][#17536]
    - Support ExtendedLocations by 'Get-AzLocation' [#18046]
* Added the following cmdlets to remain in parity with 2021-04-01 API version:
    - 'New-AzHierarchySetting'
    - 'Get-AzHierarchySetting'
    - 'Update-AzHierarchySetting'
    - 'Remove-AzHierarchySetting'
    - 'Get-AzManagementGroupSubscription'
    - 'Get-AzSubscriptionUnderManagementGroup'
    - 'Start-AzTenantBackfill'
    - 'Get-AzTenantBackfillStatus'
    - 'Get-AzManagementGroupNameAvailability'
    - 'Get-AzEntity'
* [Breaking Change] Renamed property `isSyncedFromOnPremis` to `isSyncedFromOnPremise` to align with API spec

#### Az.Security
* Added new cmdlet: 'Get-AzSecuritySolution'
* Added Alerts Suppression Rules to cmdlets:
    'Get-AlertsSuppressionRule'
    'Remove-AlertsSuppressionRule'
    'Set-AlertsSuppressionRule'
    'New-AzAlertsSuppressionRuleScope'

#### Az.ServiceBus
* Fixed miscellaneous network rule set typos across module.
* Add 'TrustedServiceAccessEnabled' to 'Set-AzServiceBusNetworkRuleSet'

#### Az.Sql
* Added new cmdlet 'Get-AzSqlInstanceEndpointCertificate'
* Added parameter 'HighAvailabilityReplicaCount' to 'New-AzSqlElasticPool' and 'Set-AzSqlElasticPool'

#### Az.Storage
* Supported generate Sas token for DataLakeGen2
    -  'New-AzDataLakeGen2SasToken'
* Showed OAuth token in debug log in debug build only
    -  'New-AzStorageContext'
* Supported return more file properties when list Azure file
    -  'Get-AzStorageFile'

#### Az.Synapse
* Added support for Synapse Link for Azure Sql Database
    - Added 'Get-AzSynapseLinkConnection' cmdlet
    - Added 'Get-AzSynapseLinkConnectionDetailedStatus' cmdlet
    - Added 'Set-AzSynapseLinkConnection' cmdlet
    - Added 'Remove-AzSynapseLinkConnection' cmdlet
    - Added 'Start-AzSynapseLinkConnection' cmdlet
    - Added 'Stop-AzSynapseLinkConnection' cmdlet
    - Added 'Set-AzSynapseLinkConnectionLinkTable' cmdlet
    - Added 'Get-AzSynapseLinkConnectionLinkTable' cmdlet
    - Added 'Get-AzSynapseLinkConnectionLinkTableStatus' cmdlet
    - Added 'Update-AzSynapseLinkConnectionLandingZoneCredential' cmdlet
* Set 'UploadedTimestamp' when adding package to spark pool by 'Update-AzSynapseSparkPool'

#### Az.Websites
* Updated 'Get-AzWebApp' and 'Get-AzWebAppSlot' to expose 'VirtualNetworkSubnetId' property [#18042]

### Thanks to our community contributors
* @bb-froggy, Fixed dead link to the DCR Overview (#17998)
* Darryl van der Peijl (@DarrylvanderPeijl), Changing on-premise to on-premises (#17974)
* Hiroshi Yoshioka (@hyoshioka0128), Typo "Github Actions"→"GitHub Actions" (#18160)
* @misbamustaqim, Adding DisableIPsecProtection check(bool) to Virtual Network Gateway (#18029)
* Scott Tang (@scottwtang), Update documentation for Get-AzApiManagementSubscription cmdlet (#18027)
* @SnehaSudhirG, Update Get-AzAutomationScheduledRunbook.md (#18059)

## 7.5.0 - April 2022
#### Az.Accounts
* Upgraded Microsoft.Rest.ClientRuntime to 2.3.24

#### Az.Aks
* Updated the description of 'Force' in 'Invoke-AzAksRunCommand' [#17756]
* Fixed the issue that 'identity' cannot be piped into 'Set-AzAksCluster' [#17376]

#### Az.ApiManagement
Added warning message for upcoming breaking change.

#### Az.Batch
* Updated Az.Batch to use 'Microsoft.Azure.Batch' SDK version 15.3.0
  - Add ability to assign user-assigned managed identities to 'PSCloudPool'. These identities will be made available on each node in the pool, and can be used to access various resources.
  - Added 'IdentityReference' property to the following models to support accessing resources via managed identity:
    - 'PSAzureBlobFileSystemConfiguration'
    - 'PSOutputFileBlobContainerDestination'
    - 'PSContainerRegistry'
    - 'PSResourceFile'
    - 'PSUploadBatchServiceLogsConfiguration'
  - Added new 'extensions' property to 'PSVirtualMachineConfiguration' on 'PSCloudPool' to specify virtual machine extensions for nodes
  - Added the ability to specify availability zones using a new property 'NodePlacementConfiguration' on 'VirtualMachineConfiguration'
  - Added new 'OSDisk' property to 'VirtualMachineConfiguration', which contains settings for the operating system disk of the Virtual Machine.
    - The 'Placement' property on 'PSDiffDiskSettings' specifies the ephemeral disk placement for operating system disks for all VMs in the pool. Setting it to 'CacheDisk' will store the ephemeral OS disk on the VM cache.
  - Added 'MaxParallelTasks' property on 'PSCloudJob' to control the maximum allowed tasks per job (defaults to -1, meaning unlimited).
  - Added 'VirtualMachineInfo' property on 'PSComputeNode' which contains information about the current state of the virtual machine, including the exact version of the marketplace image the VM is using.
  - Added 'RecurrenceInterval' property to 'PSSchedule' to control the interval between the start times of two successive job under a job schedule.
  - Added a new 'Get-AzBatchComputeNodeExtension' command, which gets a specific extension by name, or a list of all extensions, for a given compute node.
* Updated Az.Batch'Microsoft.Azure.Management.Batch' SDK version 14.0.0.
  - Added a new 'Get-AzBatchSupportedVirtualMachineSku' command, which gets the list of Batch-supported Virtual Machine VM sizes available at a given location.
  - Added a new 'Get-AzBatchTaskSlotCount' command, which gets the number of task slots required by a given job.
  - 'MaxTasksPerComputeNode' has been renamed to 'TaskSlotsPerNode', to match a change in functionality.
    - 'MaxTasksPerComputeNode' will remain as an alias but will be removed in a coming update.

#### Az.Cdn
* Added breaking change messages for all cmdlets in Az.CDN module

#### Az.CognitiveServices
* Updated CognitiveServices PowerShell to use 2022-03-01 version.
* Added 'Get-AzCognitiveServicesAccountModel' cmdlet.

#### Az.Compute
* Added '-ImageReferenceId' parameter to following cmdlets: 'New-AzVm', 'New-AzVmConfig', 'New-AzVmss', 'Set-AzVmssStorageProfile'
* Added functionality for cross-tenant image reference for VM, VMSS, Managed Disk, and Gallery Image Version creation.
* 'New-AzGallery' can take in '-Permission' parameter to set its sharingProfile property.
* 'Update-AzGallery' can update sharingProfile.
* 'Get-AzGallery' can take in '-Expand' parameter for expanded resource view.
* New parameter set for the following cmdlets to support Shared Image Gallery Direct Sharing
    - Get-AzGallery
    - Get-AzGalleryImageDefinition
    - Get-AzGalleryImageVersion
* Updates and improvements to 'Add-AzVhd'
    - Added '-DiskHyperVGeneration' and '-DiskOsType' parameters to the DirectUploadToManagedDisk parameter set for upload to more robust managed disk settings.
    - Updated progress output functions so that it works with VHD files with '&' character in its name.
    - Updated so that uploading dynamically sized VHD files are converted to fixed size during upload.
    - Fixed a bug in uploading a differencing disk.
    - Automatically delete converted/resized VHD files after upload.
    - Fixed a bug that indicates '-ResourceGroupName' parameter as optional when it is actually mandatory.

#### Az.ContainerInstance
* Supported empty directory volume and secret volume for creating container group [#17410]

#### Az.DataFactory
* Updated ADF .Net SDK version to 6.0.0

#### Az.EventHub
* Deprecating older MSI related fields in New-AzEventHubNamespace and Set-AzEventHubNamespace

#### Az.KeyVault
* Supported getting random number from managed HSM by 'Get-AzKeyVaultRandomNumber'
* Skipped subscription connection status validation for Az.KeyVault.Extension [#17712]
* Enabled public network access setting

#### Az.Kusto
* Supported inline script resource (creation of script with content instead of sas token)
* Added managed identity support to EventGrid
* Added databaseRouting (Single/Multi) to all data connections
* Added PublicIPType to cluster

#### Az.Network
* Fixed 'ArgumentNullException' in 'Add-AzureRmRouteConfig' when 'RouteTable.Routes' is null.

#### Az.RecoveryServices
* Added support for multiple backups per day (hourly) Enhanced policy for workloadType AzureVM.

#### Az.Resources
* Fixed redundant quotes in list pagination [#17667]
* Added cmdlet 'Update-AzADGroup' [#17514]
* Updated API version to beta for group member related cmdlet to allow service principal to be add, get and delete from group [#16698]
* Added parameter '-OwnedApplication' for 'Get-AzADApplication' to get applications owned by current user
* Added parameter '-Web' for 'Update-AzADApplication' [#16750]

#### Az.Security
* Added new cmdlets for security Automations API

#### Az.StackHCI
* Updated firewall rules for Attestation network to block all other traffic
* Updated cluster to ignore Attestation network

#### Az.Storage
* Supported DaysAfterLastTierChangeGreaterThan in Management Policy
    -  'Add-AzStorageAccountManagementPolicyAction'
* Fixed the issue that upload blob might fail on Linux [#17743]
    -  'Set-AzStorageBlobContent'
* Supported AllowPermanentDelete when enable blob soft delete
    - 'Enable-AzStorageBlobDeleteRetentionPolicy'
* Added breaking change warning message for upcoming cmdlet breaking change
    - 'Get-AzStorageFile'

#### Az.Synapse
* Added support for Synapse Azure Active Directory (Azure AD) only authentication
    - Added 'Get-AzSynapseActiveDirectoryOnlyAuthentication' cmdlet
    - Added 'Enable-AzSynapseActiveDirectoryOnlyAuthentication' cmdlet
    - Added 'Disable-AzSynapseActiveDirectoryOnlyAuthentication' cmdlet

#### Az.Websites
* Updated 'New-AzWebAppContainerPSSession' with CmdletDeprecation Attribute [#16646]
* Updated 'Restore-AzDeletedWebApp' to fix issue that prevents the cmdlet from working on hosts with a locale is anything different from 'en-US'

### Thanks to our community contributors
* Aleksandar Nikolić (@alexandair), Fix the UniqueName property in the examples (#17826)
* @enevoj, Markup rendering issue? (#17732)
* @jeremytanyz, Update Set-AzStorageFileContent.md (#17805)
* Martin Bentancour (@mbentancour), Fix DateTime issue restoring deleted webapp  (#16308)
* Preben Huybrechts (@pregress), Perform null check before accessing it (#16552)
* Ryan Buckman (@ryan-buckman), update example 1 command description to match the ApiRevision arg in code sample (#17741)

## 7.4.0 - April 2022
#### Az.Accounts
* Added 'SshCredentialFactory' to support get ssh credential of vm from msal.
* Fixed the bug of cmdlet fails when -DefaultProfile is set to service principal login context. [#16617]
* Fixed the issue that authorization does not work in Dogfood environment

#### Az.AppConfiguration
* Added parameter 'PublicNetworkAccess' in 'New-AzAppConfigurationStore' and 'Update-AzAppConfigurationStore'

#### Az.ApplicationInsights
* Added breaking change warnings for upcoming Az.ApplicationInsights 2.0.0

#### Az.Cdn
* Added breaking change messages for upcoming breaking change release of version 2.0.0

#### Az.Compute
* Updated 'New-AzVM' to create a new storage account for boot diagnostics if one does not exist. This will prevent the cmdlet from using a random storage account in the current subscription to use for boot diagnostics.
* Added 'AutomaticRepairAction' string parameter to the 'New-AzVmssConfig' and 'Update-AzVmss' cmdlets.
* Updated 'Get-AzVm' to include 'GetVirtualMachineById' parameter set.
* Edited the documentation for the cmdlet 'Set-AzVMADDomainExtension' to ensure the example is accurate.
* Improved description and examples for disk creation.
* Added new parameters to 'New-AzRestorePoint' and 'New-AzRestorePointCollection' for copying Restore Points and Restore Point Collections.
* Added 'Zone' and 'PlacementGroupId' Parameters to 'Repair-AzVmssServiceFabricUpdateDomain'.
* Edited 'New-AzVmss' logic to better check for null properties when the parameter 'OrchestrationMode' is used.

#### Az.CosmosDB
* Introduced support for client encryption key resource management required for CosmosDB Client-Side Encryption by adding support for creating, updating and retrieving client encryption keys with following cmdlets: 'Get-AzCosmosDbClientEncryptionKey', 'New-AzCosmosDbClientEncryptionKey' and 'Update-AzCosmosDbClientEncryptionKey'

#### Az.DataFactory
* Updated ADF .Net SDK version to 5.4.0

#### Az.Functions
* Exposed PowerShell 7.2 stack definition for function app creation in Functions V4 only

#### Az.HDInsight
This release migrates Microsoft.Azure.Graph SDK to MicrosoftGraph SDK.

#### Az.KeyVault
* Fixed a bug to continue visiting 'NextPageLink' when listing key vaults from ARM API

#### Az.Network
* Added support for retrieving the state of packet capture even when the provisioning state of the packet capture was failure
    - 'Get-AzNetworkWatcherPacketCapture'
* Added support for accepting Vnet, Subnet and NIC resources as the TargetResourceId for the following cmdlets
    - 'Set-AzNetworkWatcherFlowLog'
    - 'New-AzNetworkWatcherFlowLog'

#### Az.OperationalInsights
* Removed capacity validation in new and update cluster cmdlets as validation exists on server side.
* Extended error message on base class for extended information.
* Bug fix - prevent exceptions while using StorageInsight cmdlets.
* Bug fix - when updating a cluster, it's SKU was set even if no value was passed.

#### Az.PostgreSql
* Added parameter PublicNetworkAccess for PostgreSQL single server related cmdlets [#17263]

#### Az.RecoveryServices
* Added support for Trusted VM backup and Enhanced policy for WorkloadType AzureVM.
* Added support for disabling hybrid backup security features in 'Set-AzRecoveryServicesVaultProperty' cmdlet. The feature can be re-enabled by setting 'DisableHybridBackupSecurityFeature' flag to False.

#### Az.Resources
* Removed '-ApplicationId' from 'New-AzADServicePrincipal' 'SimpleParameterSet' [#17256]
* Added 'New-AzResourceManagementPrivateLink', and 'New-AzPrivateLinkAssociation' cmdlets
* Added authorization related cmdlets:
    - 'Get-AzRoleAssignmentSchedule'
    - 'Get-AzRoleAssignmentScheduleInstance'
    - 'Get-AzRoleAssignmentScheduleRequest'
    - 'Get-AzRoleEligibilitySchedule'
    - 'Get-AzRoleEligibilityScheduleInstance'
    - 'Get-AzRoleEligibilityScheduleRequest'
    - 'Get-AzRoleEligibleChildResource'
    - 'Get-AzRoleManagementPolicy'
    - 'Get-AzRoleManagementPolicyAssignment'
    - 'New-AzRoleAssignmentScheduleRequest'
    - 'New-AzRoleEligibilityScheduleRequest'
    - 'New-AzRoleManagementPolicyAssignment'
    - 'Remove-AzRoleManagementPolicy'
    - 'Remove-AzRoleManagementPolicyAssignment'
    - 'Stop-AzRoleAssignmentScheduleRequest'
    - 'Stop-AzRoleEligibilityScheduleRequest'
    - 'Update-AzRoleManagementPolicy'
* Added 'Get-AzResourceManagementPrivateLink', 'Remove-AzResourceManagementPrivateLink', 'Get-AzResourceManagementPrivateLinkAssociation' and  'Remove-AzResourceManagementPrivateLinkAssociation' cmdlets

#### Az.ServiceBus
* Fixed that 'New-AzServiceBusAuthorizationRuleSASToken' returns invalid token. [#12975]

#### Az.ServiceFabric
* Added support for Ubuntu 20.04 vm image.
    - This enables cluster operations with Ubuntu 20.04 vm image using AZ powershell.

#### Az.Sql
* Added parameter 'ServicePrincipalType' to 'New-AzSqlInstance' and 'Set-AzSqlInstance'
* [Breaking change] Removed 'Get-AzSqlDatabaseTransparentDataEncryptionActivity'
* Added property 'CurrentBackupStorageRedundancy' and 'RequestedBackupStorageRedundancy' in  the outputs of Managed Instance CRUD commands
* Added optional property 'Tag' to 'Restore-AzSqlDatabase'
* Added new cmdlets for managing Server Trust Certificates
    - 'New-AzSqlInstanceServerTrustCertificate'
    - 'Get-AzSqlInstanceServerTrustCertificate'
    - 'Remove-AzSqlInstanceServerTrustCertificate'
* Added new cmdlets for managing Managed Instance Link
    - 'New-AzSqlInstanceLink'
    - 'Get-AzSqlInstanceLink'
    - 'Remove-AzSqlInstanceLink'
    - 'Set-AzSqlInstanceLink'
* Added support for DataWarehouse cross tenant and cross subscription restore operations to 'Restore-AzSqlDatabase' cmdlet

#### Az.Storage
* Updated examples in reference documentation for 'Close-AzStorageFileHandle'
* Supported create storage context with customized blob, queue, file, table service endpoint
    - 'New-AzStorageContext'
* Fixed copy blob failure on Premium Storage account, or account enabled hierarchical namespace
    -  'Copy-AzStorageBlob'
* Supported create account SAS token, container SAS token, blob  SAS token with EncryptionScope
    -  'New-AzStorageAccountSASToken'
    -  'New-AzStorageContainerSASToken'
    -  'New-AzStorageBlobSASToken'
* Supported asynchronous blob copy run on new API version
    -  'Start-AzStorageBlobCopy'
* Fixed IpRule examples in help
    -  'Add-AzStorageAccountNetworkRule'
    -  'Remove-AzStorageAccountNetworkRule'
    -  'Update-AzStorageAccountNetworkRuleSet'

#### Az.Synapse
* Upgraded Azure.Analytics.Synapse.Artifacts to 1.0.0-preview.14
* Fixed the issue that following cmdlets only shows 100 entries
    - 'Get-AzSynapseRoleAssignment' cmdlet
    - 'Get-AzSynapsePipelineRun' cmdlet
    - 'Get-AzSynapseTriggerRun' cmdlet
    - 'Get-AzSynapseActivityRun' cmdlet
* Fixed the issue that there should be an error message when removing a dependency pipeline

#### Az.Websites
* Fixed 'Set-AzWebAppSlot' to support MinTlsVersion version update [#17663]
* Fixed 'Set-AzAppServicePlan' to keep existing Tags when adding new Tags
* Fixed 'Set-AzWebApp','Set-AzWebAppSlot', 'Get-AzWebApp' and 'Get-AzWebAppSlot' to expose 'VnetRouteAllEnabled' property in 'SiteConfig' [#15663]
* Fixed 'Set-AzWebApp', 'Set-AzWebAppSlot', 'Get-AzWebApp' and 'Get-AzWebAppSlot' to expose 'HealthCheckPath' property in 'SiteConfig' [#16325]
* Fixed DateTime conversion issue caused by culture [#17253]
* Added support for the web job feature [#661]
    - Get-AzWebAppContinuousWebJob
    - Get-AzWebAppSlotContinuousWebJob
    - Get-AzWebAppSlotTriggeredWebJob
    - Get-AzWebAppSlotTriggeredWebJobHistory
    - Get-AzWebAppSlotWebJob
    - Get-AzWebAppTriggeredWebJob
    - Get-AzWebAppTriggeredWebJobHistory
    - Get-AzWebAppWebJob
    - Remove-AzWebAppContinuousWebJob
    - Remove-AzWebAppSlotContinuousWebJob
    - Remove-AzWebAppSlotTriggeredWebJob
    - Remove-AzWebAppTriggeredWebJob
    - Start-AzWebAppContinuousWebJob
    - Start-AzWebAppSlotContinuousWebJob
    - Start-AzWebAppSlotTriggeredWebJob
    - Start-AzWebAppTriggeredWebJob
    - Stop-AzWebAppContinuousWebJob
    - Stop-AzWebAppSlotContinuousWebJob

### Thanks to our community contributors
* Axel B. Andersen (@Agazoth)
  * Update Get-AzADUser.md (#17549)
  * Added a new example (#17535)
* @davidslamb, Fix invalid SAS token from New-AzServiceBusAuthorizationRuleSASToken (#17349)
* elle (@elle24), Update Get-AzApplicationGatewayRequestRoutingRule.md (#17405)
* @enevoj, Update Get-AzDataCollectionRule.md (#17586)
* Felipe Guth de Freitas Bergstrom (@guthbergstrom), Update New-AzDatabricksWorkspace.md (#17472)
* @k0rtina, Update Set-AzConsumptionBudget.md (#17355)
* Kanika Gupta (@kangupt), Added example for New-AzVM
* Evgeniy Chuvikov (@snofe), Update Update-AzCosmosDBSqlDatabaseThroughput.md

## 7.3.2 - March 2022
#### Az.Accounts
* Changed target framework of AuthenticationAssemblyLoadContext to netcoreapp2.1 [#17428]

#### Az.Compute
* Updated New-AzVM feature for 'vCPUsAvailable' and 'vCPUsPerCore' parameters. Cmdlets will not try to use the new 'VMCustomizationPreview' feature if the user does not have access to that feature. [#17370]

## 7.3.0 - March 2022
#### Az.Accounts
* Fixed the issue that authorization does not work in customized environment [#17157]
* Enabled Continue Access Evaluation for MSGraph
* Improved error message when login is blocked by AAD
* Improved error message when silent reauthentication failed
* Loaded System.Private.ServiceModel and System.ServiceModel.Primitives on Windows PowerShell [#17087]

#### Az.Aks
* Updated the breaking change warning messages [#16805]

#### Az.CloudService
* Fixed the issue of 'Get-AzCloudServiceNetworkInterface' and 'Get-AzCloudServicePublicIPAddress'.

#### Az.Compute
* Upgraded Compute .NET SDK package reference to version 52.0.0
* Updated 'New-AzSshKey' cmdlet to write file paths to generated keys to the Warning stream instead of the console.
* Added 'vCPUsAvailable' and 'vCPUsPerCore' integer parameters to the 'New-AzVm', 'New-AzVmConfig', and 'Update-AzVm' cmdlets.

#### Az.ContainerInstance
* Fixed Identity Bug in ImageRegistryCredential

#### Az.Databricks
* Upgraded API version to 2021-04-01-preview

#### Az.DataFactory
* Updated ADF .Net SDK version to 5.2.0

#### Az.DataShare
* Added breaking change warning message due to update API version.

#### Az.EventHub
* Added MSI properties to New-AzEventHubNamespace and Set-AzEventHubNamespace. Adding New-AzEventHubEncryptionConfig.

#### Az.KeyVault
* 'New-AzKeyVaultManagedHsm': supported specifying how long a deleted managed hsm is retained by 'SoftDeleteRetentionInDays' and enabling purge protection by 'EnablePurgeProtection'
* 'Update-AzKeyVaultManagedHsm': supported enabling purge protection by 'EnablePurgeProtection'
* 'Get-AzKeyVaultManagedHsm': Supported getting or listing deleted managed HSM(s)
* 'Remove-AzKeyVaultManagedHsm': Supported purging a specified deleted managed HSM

#### Az.Monitor
* Fixed an issue where users could not correctly ignore warning messages after setting environment variables [#17013]

#### Az.Network
* Added new property 'SqlSetting' for Azure Firewall Policy cmdlets
    - 'Get-AzFirewallPolicy'
    - 'New-AzFirewallPolicy'
    - 'Set-AzFirewallPolicy'
* Added new to create new 'SqlSetting' object for creating Azure Firewall Policy
    - 'New-AzFirewallPolicySqlSetting'
* Added new cmdlet to support query Load Balancer inbound nat rule port mapping lists for backend addresses
    - 'Get-AzLoadBalancerBackendAddressInboundNatRulePortMapping'
    - Also updated cmdlets to support inbound nat rule V2 configurations
        - 'New-AzLoadBalancerInboundNatRuleConfig'
        - 'Set-AzLoadBalancerInboundNatRuleConfig'
        - 'Add-AzLoadBalancerInboundNatRuleConfig'

#### Az.RecoveryServices
* Azure Backup added support for 'Create new virtual machine' and 'Replace existing virtual machine' experience for Managed VMs in Restore-AzRecoveryServicesBackupItem cmdlet. To perform a VM restore to AlternateLocation use TargetVMName, TargetVNetName, TargetVNetResourceGroup, TargetSubnetName parameters. To perform a restore to a VM in OriginalLocation, do not provide TargetResourceGroupName and RestoreAsUnmanagedDisks parameters, refer examples for more details.

#### Az.Resources
* Fixed keycredential key format, from base64url to byte [#17131]
* Fixed add key credential overwrite existing one [#17088]
* Deleted parameter sets cannot be reached for 'New-AzADSericePrincipal'
* Marked 'ObjectType' as 'Unknown' if object is not found or current account has insufficient privileges to get object type for role assignment [#16981]
* Fixed that 'Get-AzRoleAssignment' shows empty RoleDefinitionName for custom roles when not specifying scope [#16991]
* Unified the returned 'RoleDefinitionId' in PSRoleAssignment to GUID [#16991]

#### Az.ServiceBus
* Added identity and encryption properties to New-AzServiceBusNamespace and Set-AzServiceBusNamespace.
* Added New-AzServiceBusEncryptionConfig

#### Az.Storage
* Supported download blob from managed disk account with Sas Uri and bearer token
    -  'Get-AzStorageBlobContent'
* Supported create/upgrade storage account with ActiveDirectorySamAccountName and ActiveDirectoryAccountType
    -  'New-AzStorageAccount'
    -  'Set-AzStorageAccount'

#### Az.StorageSync
* Migrated Azure AD features in Az.StorageSync to MSGraph APIs. The cmdlets will call MSGraph API according to input parameters: New-AzStorageSyncCloudEndpoint
* Changed default parameter set of Invoke-AzStorageSyncChangeDetection to use full share detection

#### Az.Synapse
* Updated 'Update-AzSynapseSparkPool' to support new parameter [-ForceApplySetting]

### Thanks to our community contributors
* Aleksandar Nikolić (@alexandair)
  * Fix the StayProvisioned parameter (#17070)
  * Fix a typo (#17069)
* Joel Greijer (@greijer), Clarified special case on TemplateParameterUri (#17004)
* Aman Sharma (@HarvestingClouds), Added Workload Type to the bullets to match the accepted values (#17041)
* @hsrivast, Hsrivastava/breaking change msg (#16985)
* Chris (@isjwuk), Update New-AzAutomationUpdateManagementAzureQuery.md (#16365)
* @MSakssharm, Returning error if insufficient user permissions are there for GetAgentRegistrationInfo (#16965)
* Emanuel Palm (@PalmEmanuel), New-AzSshKey should log to Warning stream instead of console (#16988)
* Pavel Safonov (@PSafonov), Fixed a typo in ManagedResourceGroupName parameter description (#17039)
* Michael Arnwine (@vsmike), Update New-AzApplicationGatewayRewriteRuleSet.md Description Text is incorrect (#17102)

## 7.2.1 - February 2022
#### Az.Resources
* Fixed `New-AzADServicePrincipal` not working [#17054] [#17040]

## 7.2.0 - February 2022
#### Az.Accounts
* Removed legacy assembly System.Private.ServiceModel and System.ServiceModel.Primitives [#16063]

#### Az.Aks
* Fixed the typo in 'New-AzAksCluster' [#16733]

#### Az.Compute
* Remove ProvisioningDetails property from PSRestorePoint object.
* Updated 'Set-AzVmExtension' cmdlet to properly display '-Name' and '-Location' parameters as mandatory.
* Edited 'New-AzVmssConfig' second example so it runs successfully by changing the Tag input to the correct format.
* Added 'Hibernate' parameter to 'Stop-AzVm' cmdlet.
* Added 'HibernationEnabled' parameter to 'New-AzVm', 'New-AzVmConfig', and 'Update-AzVm' cmdlets.
* Added 'EnableHotpatching' parameter to the 'Set-AzVmssOSProfile' cmdlet.
* Added 'ForceDeletion' parameter to Remove-AzVM and Remove-AzVMSS.

#### Az.DataFactory
* Updated ADF .Net SDK version to 5.1.0

#### Az.EventHub
* Added public network access to the 'Set-AzEventHubNetworkRuleSet' set cmdlet
* Added 'New-AzEventHubSchemaGroup', 'Remove-AzEventHubSchemaGroup' and 'Get-AzEventHubSchemaGroup' in the eventhubs PS.

#### Az.HealthcareApis
* HealthcareApis cmdlets will bump up API version which may introduce breaking change. Please contact us for more information.

#### Az.KeyVault
* Improved the error message of Az.KeyVault.Extension [#16798]
* Added default access policies for Key Vault key as 'All but purge'
* Absorbed KeyOps from parameter when importing key from certificate on managed HSM [#16773]
* Fixed a bug when updating key operations on managed HSM [#16774]
* Fixed the issue when importing no-password certificate [#16742]

#### Az.OperationalInsights
* Added logic to prevent exceptions while using 'StorageInsight' cmdlets.

#### Az.PolicyInsights
* Added support for new remediation properties allowing the remediation of more resources with better control over the remediation rate and error handling
* Added support of fetching very large sets of results by internally using paginated API calls for policy states and policy events commands

#### Az.RecoveryServices
* Reverted the configure backup per policy limit for VMs from 1000 to 100. This limit was previously relaxed but as Azure portal has a limit of 100 VMs per policy, we are reverting this limit.
* Added support for multiple backups per day for FileShares.
* Segregated some of the CRR and non-CRR flows based on the SDK update.
* Add EdgeZone parameter to Azure Site recovery service cmdlet 'New-AzRecoveryServicesAsrRecoveryPlan'

#### Az.Resources
* Added proeprties 'onPremisesLastSyncDateTime', 'onPremisesSyncEnabled' to 'User' object [#16892]
* Added additional properties when creating request for 'New-AzADServicePrincipal' and 'Update-AzADServicePrincipal' [#16847] [#16841]
* Fixed 'DisplayName' and 'ApplicationId' for 'New-AzADAppCredential' [#16764]
* Enabled password reset for 'Update-AzADUser' [#16869]
* Updated parameter name 'EnableAccount' to 'AccountEnabled', and added alias 'EnableAccount' for 'Update-AzADUser' [#16753] [#16795]
* Fixed 'Set-AzPolicyAssignment' does not remove 'notScope' if empty [#15828]

#### Az.ServiceBus
* Added support to Enable or Disable  Public Network Access as optional parameter 'PublicNetworkAccess' to 'Set-AzServiceBusNetworkRuleSet'
* Fixed 'Set-AzServiceBusNamespace' with Tags

#### Az.Sql
* Deprecation of Get-AzSqlDatabaseTransparentDataEncryptionActivity cmdlet
* Fixed cmdlets for Azure Active Directory Admin 'AzureSqlServerActiveDirectoryAdministratorAdapter' and 'AzureSqlInstanceActiveDirectoryAdministratorAdapter' migrate from 'AzureEnvironment.Endpoint.AzureEnvironment.Endpoint.Graph' to 'AzureEnvironment.ExtendedEndpoint.MicrosoftGraphUrl'

#### Az.StackHCI
* Adding support cmdlet for Remote Support
    - New cmdlets - Install-AzStackHCIRemoteSupport, Remove-AzStackHCIRemoteSupport, Enable-AzStackHCIRemoteSupport, Disable-AzStackHCIRemoteSupport, Get-AzStackHCIRemoteSupportAccess,Get-AzStackHCIRemoteSupportSessionHistory

#### Az.Storage
* Fixed the issue that output number in console when update/copy blob sometimes [#16783]
    -  'Set-AzStorageBlobContent'
    -  'Copy-AzStorageBlob'
* Updated help file, added more description for the asynchronous blob copy.
    -  'Start-AzStorageBlobCopy'

#### Az.TrafficManager
* Added two new optional parameters 'MinChildEndpointsIPv4' and 'MinChildEndpointsIPv6' for nested endpoints

#### Az.Websites
* Updated 'New-AzAppServicePlan'  to create an app service plan with host environment id #16094

### Thanks to our community contributors
* @adriancuadrado, Update New-AzADServicePrincipal.md (#16896)
* Alan (@AlanFlorance), Update Get-AzDataLakeGen2ChildItem.md (#16292)
* @geologyrocks, Duplicated header (#16876)
* Hiroshi Yoshioka (@hyoshioka0128), Typo “Azure CosmosDB"→"Azure Cosmos DB” (#16561)
* Jean-Paul Smit (@jeanpaulsmit), The -Force option is not documented and not accepted as parameter (#16910)
* Kamil Konderak (@kamilkonderak), Fixed description for NodeOsDiskSize parameter (#16716)
* Muralidhar Ranganathan (@rmuralidhar), Mitigate Get-AzKeyVaultSecret: Invalid Parameter AsPlainText (#16730)
* Ørjan Landgraff (@theorjan), better PS example (#16748)
* @ahbleite, The switch option was not updated to reflect the new ParameterSetName values, therefore the $id is always null. (#16818)

## 7.1.0 - January 2022
#### Az.Accounts
* Copied 'ServicePrincipalSecret' and 'CertificatePassword' from Az.Accounts buildin profile to customer set profile. [#16617]
* Updated help message and help markdown for parameter 'Tenant' of the cmdlet 'Set-AzContext'. [#16515]
* Fixed the issue that Azure PowerShell could not work in a workflow. [#16408]
* Fixed the doubled Api Version in the URI of the underlying request issued by 'Invoke-AzRestMethod'. [#16615]

#### Az.Aks
* Added support of 'load balancer' and 'api server access' in 'New-AzAksCluster' and 'Set-AzAksCluster'. [#16575]

#### Az.Automation
* 'New-AzAutomationSchedule' allows defnining StartTime with offsets.
*  Fixed bug: updated 'Set-AzAutomationModule' to use PUT call while updating modules with specific versions   [#12552]

#### Az.CognitiveServices
* Updated PowerShell to use 2021-10-01 version.
* Added CommitmentTier and CommitmentPlan cmdlets.
* Added Deployment cmdlets.
* Added 'New-AzCognitiveServicesObject' cmdlet for generating CommitmentPlan/Deployment objects.

#### Az.Compute
* Updated 'UserData' parameter in VM and VMSS cmdlets to pipe by the Property Name to ensure piping scenarios occur correctly.
* Changed 'New-AzVM' cmdlet when using the SimpleParameterSet to not create a 'PublicIPAddress' when a 'PublicIPAddress' name is not provided.
* Added 'PlatformFaultDomain' parameter to cmdlets: 'New-AzVM' and 'New-AzVMConfig'
* Added '-Feature' parameter for 'New-AzGalleryImageDefinition'
* Added 'DiffDiskPlacement' string parameter to 'Set-AzVmOSDisk' and 'Set-AzVmssStorageProfile' cmdlets.

#### Az.CosmosDB
* Exposed BackupPolicyMigrationState as a part of Get-AzCosmosDBAccount response.
  - This shew the status of a backup policy migration state when an account was being converted from peroidic backup mode to continuous.

#### Az.DataFactory
* Updated ADF .Net SDK version to 5.0.0

#### Az.Functions
* Removed preview from the PowerShell 7.0 stack on Linux

#### Az.KeyVault
* Added cmdlets: 'Invoke-AzKeyVaultKeyRotation', 'Get-AzKeyVaultKeyRotationPolicy' and 'Set-AzKeyVaultKeyRotationPolicy'

#### Az.MySql
* General availability of Az.MySql

#### Az.Network
* Used case-insensitive comparison for ResourceId (Set/New-NetworkWatcherFlowLog)
* Added new properties 'ApplicationSecurityGroup', 'IpConfiguration' and 'CustomNetworkInterfaceName' for Private Endpoint cmdlets
    - 'Get-AzPrivateEndpoint'
    - 'New-AzPrivateEndpoint'
* Added new cmdlet to create new 'IpConfiguration' object for building Private Endpoint
    - 'New-AzPrivateEndpointIpConfiguration'
* Added OrdinalIgnoreCase for string comparison of 'ResourceIdentifier' type for FlowLog cmdlets
* Fixed typo in error message of 'InvalidWorkspaceResourceId'

#### Az.PostgreSql
* General availability of Az.PostgreSql

#### Az.RedisCache
* Added 'IdentityType' and 'UserAssignedIdentity' parameter in 'New-AzRedisCache' and 'Set-AzRedisCache' cmdlets.
    - It is used to assign and modify the Identity of Azure Cache for Redis.

#### Az.ResourceMover
* Added support for Tags in azure resource mover
* Added support for SystemData in azure resource mover
* Released 2021-08-01 api-version

#### Az.Resources
* Fixed incorrect alias for 'Get-AzADSpCredential' [#16592]
* Fixed 'ServicePrincipalName' and 'InputObject' parameters for 'Update-AzADServicePrincipal' [#16620]
* Fixed example for 'New-AzADAppCredential' [#16682]
* Added parameter 'Web' for 'New-AzADApplication' [#16659]
* Added secret text in response of 'New-AzADApplication' and 'New-AzADServicePrincipal' [#16659]
* Deserialized the 'Value' in 'DeploymentVariable' as object array if its type is Array [#16523]
* Fixed the usage of 'SignInName' in 'New-AzRoleAssignment' [#16627]
* Formatted the output format of 'DeploymentVariable'
* Remove 'isUser' operation filter from GetAzureProviderOperation Cmdlet

#### Az.SignalR
* Fixed the bug of 'Update-AzSignalR' cmdlet that resets the resource states by mistake.

#### Az.Sql
* Added 'ZoneRedundant' parameter to 'New-AzSqlDatabaseCopy', 'New-AzSqlDatabaseSecondary' and 'Restore-AzSqlDatabase' to enable zone redundant copy, geo secondary and PITR support for hyperscale databases

#### Az.Storage
* Fixed the failure of sync copy blob with long destination blob name [#16628]
    -  'Copy-AzStorageBlob'
* Supported AAD oauth storage context in storage table cmdlets.
    - `Get-AzStorageCORSRule`
    - `Get-AzStorageServiceLoggingProperty`
    - `Get-AzStorageServiceMetricsProperty`
    - `Get-AzStorageServiceProperty`
    - `Get-AzStorageTable`
    - `Get-AzStorageTableStoredAccessPolicy`
    - `New-AzStorageTable`
    - `New-AzStorageTableSASToken`
    - `New-AzStorageTableStoredAccessPolicy`
    - `Remove-AzStorageCORSRule`
    - `Remove-AzStorageTableStoredAccessPolicy`
    - `Set-AzStorageCORSRule`
    - `Set-AzStorageServiceLoggingProperty`
    - `Set-AzStorageServiceMetricsProperty`
    - `Set-AzStorageServiceProperty`
    - `Set-AzStorageTable`
    - `Set-AzStorageTableStoredAccessPolicy`

#### Az.Synapse
* General availability of Az.Synapse
* Migrated Azure AD features in Az.Synapse to MSGraph APIs. The cmdlets below called MSGraph API according to input parameters:
    - 'New-AzSynapseRoleAssignment' cmdlet
    - 'Get-AzSynapseRoleAssignment' cmdlet
    - 'Remove-AzSynapseRoleAssignment' cmdlet
    - 'Set-AzSynapseSqlActiveDirectoryAdministrator' cmdlet
* Added a default value for [-AutoPauseDelayInMinute] parameter of command 'New-AzSynapseSparkpool' and 'Update-AzSynapseSparkpool'

### Thanks to our community contributors
* @adishiritwick, Updated Set-AzAutomationModule  to use PUT call while updating modules with specific versions (#16505)
* @anuraj, Update the New-AzWebAppCertificate (#16634)
* @BrajaMS, Updated the example command with NodeType param (#16670)
* @geologyrocks, Principal typo (was princial) (#16699)
* Hen Itzhaki (@HenItzhaki), Added more example (#16424)
* Chris (@isjwuk), Formatting improvement (#15826)
* Jaromir Kaspar (@jaromirk), Added example for password credentials (#16600)
* Martin Falkus (@mfalkus), Fix a typo in Update Az-Tags doc where "Repalces" was specified instead of "Replaces" (#16541)
* Radoslav Gatev (@RadoslavGatev), [Az.Accounts] Fix the doubled Api Version in Uri of the request issued by Invoke-AzRestMethod (#16616)
* @Skuldo, Typo fix (#16585)
* Sujit Singh (@sujitks), Update Set-AzApplicationGatewayFirewallPolicy.md (#16583)
* @trudolf-msft, new example 4/workaround (#16437)

## 7.0.0 - December 2021
#### Az.Accounts
* Removed 'ServicePrincipalSecret' and 'CertificatePassword' in 'PSAzureRmAccount' [#15427]
* Added optional parameter 'MicrosoftGraphAccessToken' to 'Connect-AzAccount'
* Added optional parameters 'MicrosoftGraphEndpointResourceId', 'MicrosoftGraphUrl' to 'Add-AzEnvironment' and 'Set-AzEnvironment'
* Added '-AccountId' property to 'UserWithSubscriptionId' parameter set of 'Connect-AzAccount' which allows a user name to be pre-selected for interactive logins
* Added '-Uri' and '-ResourceId' to 'Invoke-AzRestMethod'
* Added Environment auto completer to the following cmdlets: Connect-AzAccount, Get-AzEnvironment, Set-AzEnvironment, and Remove-AzEnvironment [#15991]
* Added module name and version to User-Agent string [#16291]

#### Az.Advisor
* Fixed the issue that 'Az.Advisor.psd1' was not signed [#16226]

#### Az.Aks
* [Breaking Change] Updated parameter alias and output type of 'Get-AzAksVersion'
* Added 'Invoke-AzAksRunCommand' to support running a shell command (with kubectl, helm) on aks cluster. [#16104]
* Added support of 'EnableNodePublicIp' and 'NodePublicIPPrefixID' for 'New-AzAksCluster' and 'New-AzAksNodePool'. [#15656]
* Migrated the logic of creating service principal in 'New-AzAksCluster' from 'Azure Active Directory Graph' to 'Microsoft Graph'.
* Fixed the issue that 'Set-AzAksCluster' can't upgrade cluster when node pool version doesn't match cluster version. [#14583]
* Added 'ResourceGroupName' in 'PSKubernetesCluster'. [#15802]

#### Az.ApplicationInsights
* Added WebTest function. Below is the new cmdlet
    * 'Get-AzApplicationInsightsWebTest'
    * 'New-AzApplicationInsightsWebTest'
    * 'New-AzApplicationInsightsWebTestGeolocationObject'
    * 'New-AzApplicationInsightsWebTestHeaderFieldObject'
    * 'Remove-AzApplicationInsightsWebTest'
    * 'Update-AzApplicationInsightsWebTestTag'

#### Az.Automation
* Fixed example in reference doc for 'Remove-AzAutomationHybridWorkerGroup'
* Updated 'Set-AzAutomationModule' to use PUT call while updating modules with specific versions [#12552]

#### Az.CloudService
* General availability of 'Az.CloudService' module

#### Az.Compute
* Contains updates to the following powershell cmdlets
    - 'SetAzVmssDiskEncryptionExtension' : Added extension parameters for the cmdlet to work with test extensions and parameter 'EncryptFormatAll' for Virtual Machine Scale Sets
    - 'GetAzVmssVMDiskEncryptionStatus'	 : Modified the functionality of the cmdlet to properly display the encryption status of data disks of Virtual Machine Scale Sets
    - 'SetAzDiskEncryptionExtension'     : Fixed a bug in the cmdlet in the migrate scenario from 2pass to 1pass encryption
* Added 'Add-AzVhd' to convert VHD using Hyper-V
* Added 'UserData' parameter to VM and VMSS cmdlets
* Added string parameter 'PublicNetworkAccess' to DiskConfig and SnapshotConfig cmdlets
* Added boolean parameter 'AcceleratedNetwork' to DiskConfig and SnapshotConfig cmdlets
* Added 'CompletionPercent' property to the PSSnapshot model so it is visible to the user.

#### Az.ContainerInstance
* Upgraded API version to 2021-09-01
  - [Breaking Change] Changed the type of parameter 'LogAnalyticWorkspaceResourceId' in 'New-AzContainerGroup' from Hashtable to String
  - [Breaking Change] Removed parameter 'NetworkProfileId' in 'New-AzContainerGroup', added 'SubnetId' as its alternative
  - [Breaking Change] Removed parameter 'ReadinessProbeHttpGetHttpHeadersName' and 'ReadinessProbeHttpGetHttpHeadersValue' in 'New-AzContainerInstanceObject', added 'ReadinessProbeHttpGetHttpHeader' as their alternative
  - [Breaking Change] Removed parameter 'LivenessProbeHttpGetHttpHeadersName' and 'LivenessProbeHttpGetHttpHeadersValue' in 'New-AzContainerInstanceObject', added 'LivenessProbeHttpGetHttpHeader' as their alternative
  - Added 'Zone' in 'New-AzContainerGroup', 'AcrIdentity' in 'New-AzContainerGroupImageRegistryCredentialObject'
  - Changed 'Username' in 'New-AzContainerGroupImageRegistryCredentialObject' from mandatory to optional
* For 'Invoke-AzContainerInstanceCommand'
    - [Breaking Change] Displayed command execution result as the cmdlet output by connecting websocket in backend [#15754]
    - Added '-PassThru' to get last execution result when the command succeeds
    - Changed 'TerminalSizeCol' and 'TerminalSizeRow' from mandatory to optional, set their default values by current PowerShell window size
* Added 'Restart-AzContainerGroup', 'Get-AzContainerInstanceContainerGroupOutboundNetworkDependencyEndpoint' and 'New-AzContainerInstanceHttpHeaderObject'

#### Az.CosmosDB
* Fixed when a warning about the value of AnalyticalStorageSchemaType is displayed when no value was given.
* Added support for managed Cassandra.

#### Az.DataFactory
* Updated ADF .Net SDK version to 4.28.0

#### Az.EventHub
* Fixed the issue that 'New-AzEventHubKey' always generates a new primary key instead of a secondary key since version 1.9.0 [#16362]

#### Az.Functions
* [Breaking change] 'Update-AzFunctionAppPlan' prompts for confirmation [#16490]
* [Breaking change] 'Remove-AzFunctionApp' does not delete ASP if it is the last app in the plan [#16487]
* [Breaking change] Set the 'FunctionsVersion' to 4 for FunctionApp creation [#16426]
* [Breaking change] 'Update-AzFunctionApp' prompts for confirmation [#14442]
* Fixed an error creating function with 'New-AzFunctionApp' on PowerShell 5.1 [#15430]
* Supported storage account SKU 'Standard_GZRS' [#14633]

#### Az.HDInsight
* Added two parameters '-Zone' and '-PrivateLinkConfiguration' to cmdlet 'New-AzHDInsightCluster'
  - Added parameter '-Zone' to cmdlet 'New-AzHDInsightCluster' to support to create cluster with availability zones feature
  - Added parameter '-PrivateLinkConfiguration' to cmdlet 'New-AzHDInsightCluster' to support to add private link configuration when creating cluster with private link feature.
* Added cmdlet New-AzHDInsightIPConfiguration to create ip configuration object in memory.
* Added cmdlet New-AzHDInsightPrivateLinkConfiguration to create private link configuration object in memory.
* Fixed the output type in help doc of Set-AzHDInsightClusterDiskEncryptionKey cmdlet from 'Microsoft.Azure.Management.HDInsight.Models.Cluster' to  'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightCluster' to keep consistent with the real type of returned object.
* Breaking change:
  - Changed the type of parameter 'OSType' from 'Microsoft.Azure.Management.HDInsight.Models.OSType' to 'System.string' in cmdlet 'New-AzHDInsightCluster'.
  - Changed the type of parameter 'ClusterTier' from 'Microsoft.Azure.Management.HDInsight.Models.ClusterTier' to 'System.string' in cmdlets 'New-AzHDInsightCluster' and 'New-AzHDInsightClusterConfig'.
  - Changed the type of property 'VmSizes' in class 'AzureHDInsightCapabilities' from 'IDictionary<string, AzureHDInsightVmSizesCapability>' to 'IList<string>'.
  - Changed the type of property 'AssignedIdentity' in class 'AzureHDInsightCluster' from 'Microsoft.Azure.Management.HDInsight.Models.ClusterIdentity'  to 'Microsoft.Azure.Commands.HDInsight.Models.AzureHDInsightClusterIdentity'.

#### Az.KeyVault
* [Breaking Change] Renamed properties of 'PSKeyVaultPermission' type to follow the pattern of Azure RBAC.
* Migrated AAD Graph API to MSGraph API.
* Added a message to 'Set-AzKeyVaultAccessPolicy' stating that for the Permissions parameters, using the 'All' option will not include the 'Purge' permission.

#### Az.ManagedServices
* [Breaking Change] Updated API version to 2020-02-01-preview

#### Az.Monitor
* Added new properties EventName, Category, ResourceProviderName, OperationName, Status, SubStatus with type string as output for command Get-AzLog [#15833]
* Supported event hub receiver in action group [#16348]
* Added default parameter set 'GetByResourceGroup' for the command 'Get-AzAlertRule' [#16356]

#### Az.Network
* Bugfix in PSAzureFirewallPolicyThreatIntelWhitelist for FirewallPolicy
* Added optional parameter '-IsSecuritySite' to the following cmdlet:
    - 'New-AzVpnSite'
* Added support for new Match Variables in WAF Exclusions
* Onboard Virtual Network Encryption to Virtual Network Cmdlets
* Added support for NAT port range parameters in VPN NAT rule resources
    - 'New-AzVpnGatewayNatRule.md'
    - 'Update-AzVpnGatewayNatRule.md'
    - 'New-AzVirtualNetworkGatewayNatRule.md'
    - 'Update-AzVirtualNetworkGatewayNatRule.md'
* Added new cmdlets to support Per Rule Exclusions for Application Gateway WAF
    - 'New-AzApplicationGatewayFirewallPolicyExclusionManagedRuleSet'
    - 'New-AzApplicationGatewayFirewallPolicyExclusionManagedRuleGroup'
    - 'New-AzApplicationGatewayFirewallPolicyExclusionManagedRule'
    - Also updated cmdlet to add the property for configuring ExclusionManagedRuleSet within Exclusions
        - 'New-AzApplicationGatewayFirewallPolicyExclusion'
* Bug Fix in Application Gateway Trusted Client Certificate cmdlets to load the entire cert chain from file.

#### Az.OperationalInsights
* Expanded DataSourceType with values 'Query', 'Alerts' for LinkedStorageAccount cmdlets
* [Breaking Change] rename 'StorageAccountId' to 'StorageAccountIds'
  - 'New-AzOperationalInsightsLinkedStorageAccount'
* [Breaking Change] Returns 'PSSavedSearch' instead of 'HttpStatusCode' by 'New-AzOperationalInsightsComputerGroup'
* [Breaking Change] Returns 'PSCluster' instead of 'PSLinkedService' by 'Update-AzOperationalInsightsCluster'
* Expanded Sku with values 'capacityreservation', 'lacluster' for Workspace
* Added new properties:'SkuCapacity', 'ForceCmkForQuery', 'DisableLocalAuth' for Workspace
* Added new property: 'DailyQuotaGb'on'Set-AzOperationalInsightsWorkspace'
* Added new properties: 'ETag', 'Tag' for StorageInsight cmdlets
* Added new property 'StorageAccountResourceId' to cmdlet:
  - 'Set-AzOperationalInsightsStorageInsight'
* Added SupportsShouldProcess attribute to cmdlet:
  - 'Set-AzOperationalInsightsStorageInsight'
* Added new cmdlets to support Table, DataExport, WorkspaceShareKey, PurgeWorkspace, and AvailableServiceTier
* Added 'Error' property in the result of the 'Invoke-AzOperationalInsightsQuery' to retrieve partial error when running a query [#16378]

#### Az.RecoveryServices
* Azure Backup updated validate sets for supported BackupManagementType in 'Get-AzRecoveryServicesBackupItem', 'Get-AzRecoveryServicesBackupContainer', Get-AzRecoveryServicesBackupJob cmdlets.
* Azure Backup added support for SAPHanaDatabase for 'Disable-AzRecoveryServicesBackupProtection', 'Unregister-AzRecoveryServicesBackupContainer', 'Get-AzRecoveryServicesBackupItem', 'Get-AzRecoveryServicesBackupContainer' cmdlets.
* Breaking Change: 'Get-AzRecoveryServicesBackupJob', 'Get-AzRecoveryServicesBackupContainer' and 'Get-AzRecoveryServicesBackupItem' commands will only support 'BackupManagementType MAB' instead of 'MARS'.
* Azure Site Recovery support for capacity reservation for Azure to Azure provider.

#### Az.Resources
* Added 'Get-AzProviderPreviewFeature', 'Register-AzProviderPreviewFeature' and 'Unregister-AzProviderPreviewFeature' cmdlets.
* Fixed a bug when running Get-AzPolicyAlias with empty value of NamespaceMatch parameter [#16370]
* [Breaking change] Migrated from AAD Graph to Microsoft Graph
* [Breaking change] Changed the returned 'Id' in PSDenyAssignment from GUID string to fully qualified ID
* Allowed parameter 'Id' in 'Get-AzDenyAssignment' to accept fully qualified ID
* Added new cmdlet 'Publish-AzBicepModule' for publishing Bicep modules
* Added deprecation message for 'AssignIdentity' parameter in '*-AzPolicyAssignment' cmdlets.
* Added support for user assigned managed identities in policy assignments by adding 'IdentityType' and 'IdentityId' parameters to '*-AzPolicyAssignment' cmdlets.
* Updated policy cmdlets to use new api version 2021-06-01 that introduces support for user assigned managed identities in policy assignments.
* Narrowed API permission when get information about active directory object for *-AzRoleAssignment [#16054]

#### Az.Sql
* Fixed FirewallRuleName wildcard filtering in 'Get-AzSqlServerFirewallRule' [#16199]
* Moved SQL Server and SQL Instance AAD from ActiveDirectoryClient to MicrosoftGraphClient

#### Az.StackHCI
* Promoted Az.StackHCI to GA

#### Az.Storage
* Fixed the failure of 'Get-AzStorageContainerStoredAccessPolicy' when permission is null [#15644]
* Supported create blob service Sas token or account Sas token with permission i
    -  'New-AzStorageBlobSASToken'
    -  'New-AzStorageContainerSASToken'
    -  'New-AzStorageAccountSASToken'
* Fixed creating container SAS token failed from an access policy without expire time, and set SAS token expire time [#16266]
    -  'New-AzStorageContainerSASToken'
* Removed parameter -Name from Get-AzRmStorageShare ShareResourceIdParameterSet
    - 'Get-AzRmStorageShare'
* Supported create or migrate container to enable immutable Storage with versioning.
    -  'New-AzRmStorageContainer'
    -  'Invoke-AzRmStorageContainerImmutableStorageWithVersioningMigration'
* Supported set/remove immutability policy on a Storage blob.
    -  'Set-AzStorageBlobImmutabilityPolicy'
    -  'Remove-AzStorageBlobImmutabilityPolicy'
* Supported enable/disable legal hold on a Storage blob.
    -  'Set-AzStorageBlobLegalHold'
* Supported create storage account with enable account level immutability with versioning, and create/update storage account with account level immutability policy.
    - 'New-AzStorageAccount'
    - 'Set-AzStorageAccount'

#### Az.Websites
* Updated the Microsoft.Azure.Management.Websites SDK to 3.1.2

### Thanks to our community contributors
* Hiroshi Yoshioka (@hyoshioka0128), Fix typo "Azure CosmosDB"→"Azure Cosmos DB" (#16470)
* Chris (@isjwuk), Update New-AzAutomationSourceControl.md (#16366)
* Julian Hüppauff (@jhueppauff), [API Management] Fixed variable reference (#16525)
* @toswedlu, [CosmosDB] Changing the warning message for AnalyticalStorageSchemaType (#15723)

## 6.6.0 - November 2021
#### Az.Accounts
* Added new version of AAD service client using Microsoft Graph API

#### Az.Aks
* Added support for new parameters 'NetworkPolicy', 'PodCidr', 'ServiceCidr', 'DnsServiceIP', 'DockerBridgeCidr', 'NodePoolLabel', 'AksCustomHeader' in 'New-AzAksCluster'. [#13795]
* Added warnings of upcoming breaking change of migrating to Microsoft Graph.
* Added support for changing the number of nodes in a node pool. [#12379]

#### Az.ApiManagement
* Fixed a bug in 'Get-AzApiManagementTenantGitAccess' cmdlet.

#### Az.Batch
* Removed assembly 'System.Text.Encodings.Web.dll' [#16062]

#### Az.Compute
* Added cmdlets for adding VMGalleryApplication property to VM/VMSS
    - New-AzVmGalleryApplication
    - New-AzVmssGalleryApplication
    - Add-AzVmGalleryApplication
    - Add-AzVmssGalleryApplication
    - Remove-AzVmGalleryApplication
    - Remove-AzVmssGalleryApplication
* Added support for proxy and debug settings for VM Extension for SAP (AEM)
* Updated New-AzGalleryImageVersion to take in the 'Encryption' property correctly from '-TargetRegion' parameter.
* Updated Set-AzVmBootDiagnostic to default to managed storage account if not provided.
* Edited New-AzVmss defaulting behavior when 'OrchestrationMode' is set to Flexible.
    - Removed NAT Pool.
    - Removed UpgradePolicy. Throws an error if provided.
    - SinglePlacementGroup must be false. Throws an error if true.
    - Networking Profile's API version is 2020-11-01 or later.
    - Networking Profile IP Configurations Primary property is set to true.

#### Az.CosmosDB
* Introduced Get-AzCosmosDBMongoDBBackupInformation to retrieve latest backup information for MongoDB.
* Updated New-AzCosmosDBAccount, Update-AzCosmosDBAccount to accept BackupStorageRedundancy
* Introduced Get-AzCosmosDBLocation to list Azure CosmosDB Account and its locations properties.

#### Az.DataFactory
* Added PublicNetworkAccess to Update_AzDataFactoryV2 Command
* Updated ADF .Net SDK version to 4.26.0

#### Az.DesktopVirtualization
* Upgraded api version to 2021-07-12.

#### Az.EventHub
* Added support for Premium sku and namesapce and optional switch parameter 'DisableLocalAuth' to 'New-AzEventHubNamespace' and 'Set-AzEventHubNamespace'

#### Az.Functions
* Set site config netFrameworkVersion for Windows V4 apps only
* Enabled function app creation for Functions V4 stacks [#15919]

#### Az.IotHub
* Updated IoT Hub Management SDK to version 4.1.0 (api-version 2021-07-10)

#### Az.KeyVault
* Added warning message of upcoming breaking change to 'New-AzKeyVaultRoleDefinition' and 'Get-AzKeyVaultRoleDefinition'.
    - To comply with the syntax of 'New-AzRoleDefinition' and 'Get-AzRoleDefinition' we are going to rename some of the properties of 'PSKeyVaultPermission' model, which might affect these two cmdlets.
* Added warnings of upcoming breaking change of migrating to Microsoft Graph.

#### Az.Migrate
* Added check for invalid IP address

#### Az.OperationalInsights
* Fixed a bug in 'Set-AzOperationalInsightsLinkedService: when linked service does not exist, perform create(update) instead of failing'

#### Az.RecoveryServices
* Azure Backup fixed issues with StorageConfig
* Azure Backup added NodesList and AutoProtectionPolicy to Get-AzRecoveryServicesBackupProtectableItem Cmdlets.
* Azure Backup fixed GetItemsForContainerParamSet to support fetching the MAB backup item.
* Azure Backup fixed Get-AzRecoveryServicesBackupContainer to support BackupManagementType MAB instead of MARS.
* Added breaking change warning: 'Get-AzRecoveryServicesBackupJob', 'Get-AzRecoveryServicesBackupContainer' and 'Get-AzRecoveryServicesBackupProtectableItem' commands will only support 'BackupManagementType MAB' instead of 'MARS' alias, changes will take effect from upcoming breaking release.
* Added support for ZRS disk type for Azure to Azure replication.
* Added Availability zone information in replicated protected item response for Azure to Azure replication.

#### Az.RedisCache
* Created new examples in documentation of 'New-AzRedisCache' and 'Set-AzRedisCache'.

#### Az.Resources
* Fixed a bug about the exitcode of Bicep [#16055]
* Added breaking change warnings for AAD cmdlets
* Added property 'UIFormDefinition' to Template Spec Versions,  'Export-AzTemplateSpec' will now include a Template Spec Version's UIFormDefinition (if any) as part of the export.
* Added error catching for role assignment creation fail while creating a Service Principal
* Performance improvement for Get-AzPolicyAlias when -NamespaceMatch matches a single RP namespace

#### Az.Security
* Updated Security .NET SDK package reference to version 3.0.0

#### Az.ServiceBus
* Added support for ZoneRedundant and optional switch parameter 'DisableLocalAuth' to 'New-AzServiceBusNamespace' and 'Set-AzServiceBusNamespace'

#### Az.SignalR
* Added Web PubSub cmdlets
  - 'New-AzWebPubSub'
  - 'Get-AzWebPubSub'
  - 'Update-AzWebPubSub'
  - 'Restart-AzWebPubSub'
  - 'Remove-AzWebPubSub'
  - 'New-AzWebPubSubHub'
  - 'Get-AzWebPubSubHub'
  - 'Remove-AzWebPubSubHub'
  - 'New-AzWebPubSubKey'
  - 'Get-AzWebPubSubKey'
  - 'Get-AzWebPubSubSku'
  - 'Get-AzWebPubSubUsage'
  - 'Test-AzWebPubSubNameAvailability'

### Thanks to our community contributors
* bgomezangulo (@beagam), Update Resume-AzNetAppFilesReplication.md (#16040)
* Jim McCormick (@eimajtrebor), Fixed typo (#16091)
* Lampson Nguyen (@lampson), Update Get-AzDataShare.md (#16015)
* @MaxMeng1985, Update Get-AzSynapseSqlPoolRestorePoint.md (#16138)
* Reggie Gibson (@regedit32), New-AzBotService: Fix AppSecret conversion to plaintext on Windows PowerShell (#16160)
* Mötz Jensen (@Splaxi), BusinessIdentities details doesn't match the current implementation (#16141)


## 6.5.0 - October 2021
#### Az.Accounts
* Supported getting the access token for Microsoft Graph.
* Added AuthorizeRequestDelegate to allow service module to adjust token audience.
* Utilized [AssemblyLoadContext](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.loader.assemblyloadcontext) to resolve assembly conflict issues in PowerShell.
* Updated Azure.Core from 1.16.0 to 1.19.0.

#### Az.Attestation
* General availability of 'Az.Attestation' module

#### Az.Cdn
* Fixed null reference exception and typos in 'New-AzFrontDoorCdnRule' cmdlet

#### Az.Compute
* Updated Compute .NET SDK package reference to version 49.1.0
* Fixed a bug in 'Get-AzVM' that caused incorrect power status output.

#### Az.DataFactory
* Added a DataFlowEnableQuickReuse argument for the 'Set-AzDataFactoryV2IntegrationRuntime' cmdlet to enable quick reuse of clusters in next pipeline activities.
* Updated ADF .Net SDK version to 4.25.0
* Added a VNetInjectionMethod argument for the 'Set-AzDataFactoryV2IntegrationRuntime' cmdlet to support the express virtual network injection of Azure-SSIS Integration Runtime.

#### Az.FrontDoor
* Allowed rule engine action creation without RouteConfigurationOverride for 'New-AzFrontDoorRulesEngineActionObject'.
* Fixed DynamicCompression parameter being ignored issue of 'New-AzFrontDoorRulesEngineActionObject'.

#### Az.KeyVault
* Supported custom role definitions on managed HSM:
    - Create via 'New-AzKeyVaultRoleDefinition',
    - Delete via 'Remove-AzKeyVaultRoleDefinition',
    - Filter all custom roles via 'Get-AzKeyVaultRoleDefinition -Custom'.
* Supported Encrypt/Decrypt/Wrap/Unwrap using keys [#15679]
* Enabled managing resources in other subscriptions without switching the context by adding '-Subscription <String>'.

#### Az.Maintenance
* Added Guest patch maintenance support.

#### Az.Network
* Support for Sku, ScaleUnits parameters of BastionHost resource.
    - 'New-AzBastion'
    - 'Set-AzBastion'
* Onboard Azure Resource Manager to Private Link Common Cmdlets
* Updated cmdlets to add properties to enable/disable BgpRouteTranslationForNat for VpnGateway.
    - 'New-AzVpnGateway'
    - 'Update-AzVpnGateway'
* Updated cmdlet to add property to disable InternetSecurity for P2SVpnGateway.
    - 'New-AzP2sVpnGateway'
* Added new cmdlets for HubBgpConnection child resource of VirtualHub.
    - 'Get-AzVirtualHubBgpConnection'
    - 'New-AzVirtualHubBgpConnection'
    - 'Update-AzVirtualHubBgpConnection'
    - 'Remove-AzVirtualHubBgpConnection'
* Onboard Azure HDInsight to Private Link Common Cmdlets

#### Az.RecoveryServices
* Azure Site Recovery bug fixes for VMware to Azure Reprotect, Update policy and Disable scenarios.
* Azure Backup added the support for UserAssigned MSI in RecoveryServices Vault.

#### Az.Resources
* Added a clearer error message for a case in which TemplateUri do not accept bicep file.
* Fixed typos with ManagementGroups breaking change descriptions [#15819].
* Fixed resource tags casing issue - resource tags casing not being preserved.
* Updated to Microsoft.Azure.Management.Authorization 2.13.0-preview.

#### Az.Sql
* Fixed 'Get-AzSqlDatabaseImportExportStatus' to report the error encountered

#### Az.Storage
* Upgraded Azure.Storage.Blobs to 12.10.0
* Upgraded Azure.Storage.Files.Shares to 12.8.0
* Upgraded Azure.Storage.Files.DataLake to 12.8.0
* Upgraded Azure.Storage.Queues to 12.8.0
* Supported upgrade storage account to enable HierarchicalNamespace
    -  'Invoke-AzStorageAccountHierarchicalNamespaceUpgrade'
    -  'Stop-AzStorageAccountHierarchicalNamespaceUpgrade'
* Supported AccessTierInferred, Tags in blob inventory policy schema
    - 'New-AzStorageBlobInventoryPolicyRule'
* Supported create/update storage account with PublicNetworkAccess enabled/disabled
    - 'New-AzStorageAccount'
    - 'Set-AzStorageAccount'
* Supported create/update storage blob container with RootSquash
    - 'New-AzRmStorageContainer'
    - 'Update-AzRmStorageContainer'
* Supported AllowProtectedAppendWriteAll in set container Immutability Policy, and add container LegalHold
    - 'Set-AzRmStorageContainerImmutabilityPolicy'
    - 'Add-AzRmStorageContainerLegalHold'

#### Az.StorageSync
* Fixed a bug where not all properties of PSSyncSessionStatus and PSSyncActivityStatus objects were being populated properly.
* This affected the 'Get-AzStorageSyncServerEndpoint' cmdlet when trying to access the following properties of the output:
    - SyncStatus.UploadStatus
    - SyncStatus.DownloadStatus
    - SyncStatus.UploadActivity
    - SyncStatus.DownloadActivity

#### Az.Websites
* Updated 'Import-AzWebAppKeyVaultCertificate1' to set the default name with combination of keyvault name and cert name

### Thanks to our community contributors
* @DSakura207, Use last PowerState instance in Statuses for power status (#15941)
* Yannic Graber (@grabery), Recode Example2 (#15808)
* @joelmforsyth, Fix multi-regional examples (#15918)
* Adam Coffman (@SysAdminforCoffee), Update Set-AzNetworkInterfaceIpConfig.md (#15846)
* Michael Howard (@x509cert), Reworded sentence to make it clear that a specific key version must be provided (#15886)

## 6.4.0 - September 2021
#### Az.Accounts
* Corrected the URLs to Azure Portal in the results of 'Get-AzEnvironment' and 'Get-AzContext'. [#15429]
* Made infrastructural changes to support overriding default subscription via a '-SubscriptionId <String>' parameter.
    - [Az.Aks](https://docs.microsoft.com/powershell/module/az.aks/get-azakscluster) is the first module that supports it.

#### Az.Aks
* Made '-Subscription <String>' available in all Aks cmdlets. You can manage Aks resources in other subscriptions without switching the context.

#### Az.ApiManagement
* Added new 'Sync-AzApiManagementKeyVaultSecret' cmdlet.
* Added new 'New-AzApiManagementKeyVaultObject' cmdlet.
* Added new optional [-useFromLocation] parameter to the 'Get-ApiManagementCache' 'New-ApiManagementCache''Update-ApiManagementCache' cmdlet.
* Updated cmdlet **New-AzApiManagement** to manage ApiManagement service
    - Added support for the new 'Isolated' SKU
    - Added support for managing Availability Zones using 'Zone' property
    - Added support for Disabling Gateway in a Region using 'DisableGateway' property
    - Added support for managing the minimum Api Version to allow for Control Plane using 'MinimalControlPlaneApiVersion' property.
* Updated cmdlet **New-AzApiManagementRegion** to manage ApiManagement service
    - Added support for managing Availability Zones using 'Zone' property
    - Added support for Disabling Gateway in a Region using 'DisableGateway' property
* Updated cmdlet **Add-AzApiManagementRegion** to manage ApiManagement service
    - Added support for managing Availability Zones using 'Zone' property
    - Added support for Disabling Gateway in a Region using 'DisableGateway' property
* Updated cmdlet **Update-AzApiManagementRegion** to manage ApiManagement service
    - Added support for managing Availability Zones using 'Zone' property
    - Added support for Disabling Gateway in a Region using 'DisableGateway' property
* Updated cmdlet **New-AzApiManagementCustomHostnameConfiguration** to manage Custom Hostname Configuration
    - Added support for specifying 'IdentityClientId' to provide Managed Identity User Assigned ClientId to use with KeyVault

#### Az.Automation
* Fixed bug: Closing in input file handle in Import-AzAutomationRunbook

#### Az.Cdn
* Fixed mandatory parameters issue in 'Get-AzCdnEndpointResourceUsage' cmdlet

#### Az.Compute
* Added new parameters '-LinuxConfigurationPatchMode', '-WindowsConfigurationPatchMode', and '-LinuxConfigurationProvisionVMAgent' to 'Set-AzVmssOSProfile'
* Added new parameters '-SshKeyName' and '-GenerateSshKey' to 'New-AzVM' to create a VM with SSH
* Fixed a bug in 'Add-AzVHD' on Linux that caused uploads to fail for certain destination URI
* Added new cmdlets for Restore Points and Restore Point Collection:
    - 'New-AzRestorePoint'
    - 'New-AzRestorePointCollection'
    - 'Get-AzRestorePoint'
    - 'Get-AzRestorePointCollection'
    - 'Update-AzRestorePointCollection'
    - 'Remove-AzRestorePoint'
    - 'Remove-AzRestorePointCollection'
* Added new parameters '-EnableSpotRestore' and '-SpotRestoreTimeout' to 'New-AzVMSSConfig' to enable Spot Restore Policy
* Added new cmdlets: 'Update-AzCapacityReservationGroup' and 'Update-AzCapacityReservation'

#### Az.CosmosDB
* Fixed a bug where the restore of deleted database accounts fail.

#### Az.DataFactory
* Added a subnetId argument for the 'Set-AzDataFactoryV2IntegrationRuntime' cmdlet to support RBAC checking for VNet injection against the subnet resource ID instead of the VNet resource ID.
* Added the 'Get-AzDataFactoryV2IntegrationRuntimeOutboundNetworkDependenciesEndpoint' cmdlet to provide a list of outbound network dependencies for SSIS integration runtime in Azure Data Factory that joins a virtual network.
* Added PublicNetworkAccess to Data Factory.
* Updated ADF .Net SDK version to 4.23.0

#### Az.KeyVault
* Supported adding EC keys in key vault [#15699]

#### Az.Migrate
* Supported duplicate disk UUID in source disk.
* Supported subnets in same VNet for AVSet.
* Supported runAsAccount fetching for multiple Vcenters in same site.

#### Az.Network
* Updated cmdlet to add 'Subnet' property for IP based load balancer backend address pool.
    - 'New-AzLoadBalancerBackendAddressConfig'
* Updated cmdlet to add 'TunnelInterface' property for backend pool related operations.
    - 'New-AzLoadBalancerBackendAddressPool'
    - 'Set-AzLoadBalancerBackendAddressPool'

#### Az.RecoveryServices
* Azure Site Recovery multi appliance support for VMware to Azure disaster recovery scenarios using RCM as the control plane.
* Azure Backup fixed targetPhysicalPath issue with SQL CRR
* Azure Backup fixed disable protection for SQL workload
* Azure Backup resolved bug in setting CMK properties in latest release
* Azure Backup removed special characters from register-azrecoveryservicesbackupcontainer command help text

#### Az.Resources
* Use JsonExtensions to serialize deserialize JSON objects to ensure the use of custom serialization settings [#15552]
* Added support for 'Unsupported' and 'NoEffect' change types to deployment What-If cmdlets.

#### Az.SecurityInsights
* Updated to 'Get-AzSentinelIncident' parameters
    - Added '-Filter' to support OData filter
    - Added '-OrderBy' to support OData ordering
    - Added '-Max' to support retrieving more than the default of 1000 incidents.

#### Az.Sql
* Changed the underlying implementation of 'Get-AzSqlDatabase' to support a paginated response from the server
* Added 'ZoneRedundant' parameter to 'New-AzSqlInstance' and 'Set-AzSqlInstance' to enable the creation and the update of zone - redundant instances.
* Added ZoneRedundant field to the model of the managed instance so that it displays information about zone - redundancy for instance that are returned by 'Get-AzSqlInstance'.
* Extended AuditActionGroups enum in server & database audit. Added DBCC_GROUP, DATABASE_OWNERSHIP_CHANGE_GROUP and DATABASE_CHANGE_GROUP.
* Added 'AsJob' flag to 'Remove-AzSqlInstance'
* Added 'SubnetId' parameter to 'Set-AzSqlInstance' to support the cross-subnet update SLO
* Upgraded to newest SDK version

#### Az.Storage
* Supported get/set blob tags on a specific blob
    -  'Get-AzStorageBlobTag'
    -  'Set-AzStorageBlobTag'
* Supported create destination blob with specific blob tags while upload/copy Blob
    -  'Set-AzStorageBlobContent'
    -  'Start-AzStorageBlobCopy'
* Supported list blobs across containers with a blob tag filter sql expression
    -  'Get-AzStorageBlobByTag'
* Supported list blobs inside a container and include Blob Tags
    -  'Get-AzStorageBlob'
* Supported run blob operation with blob tag condition, and fail the cmdlet when blob tag condition not match
    -  'Get-AzStorageBlob'
    -  'Get-AzStorageBlobContent'
    -  'Get-AzStorageBlobTag'
    -  'Remove-AzStorageBlob'
    -  'Set-AzStorageBlobContent'
    -  'Set-AzStorageBlobTag'
    -  'Start-AzStorageBlobCopy'
    -  'Stop-AzStorageBlobCopy'
* Generate blob sas token with new API version
    -  'New-AzStorageBlobSASToken'
    -  'New-AzStorageContainerSASToken'
    -  'New-AzStorageAccountSASToken'
* Fixed blob copy failure with OAuth credential when client and server has time difference [#15644]
    -  'Copy-AzStorageBlob'
* Fixed remove Data Lake Gen2 item fail with readonly SAS token
    -  'Remove-AzDataLakeGen2Item'
* Revised destination existing check in move Data Lake Gen2 item
    -  'Move-AzDataLakeGen2Item'

#### Az.StorageSync
* Added parameter sets to 'Invoke-AzStorageSyncChangeDetection'
    - Can call the cmdlet without -DirectoryPath and -Path parameters to trigger change detection on an entire file share
* Added support for authoritative upload as part of New-AzStorageSyncServerEndpoint.
* Added cloud change enumeration status information in Cloud Endpoint object.
* Updated Server Endpoint object with various health properties
* Added 'ServerName' property in Server Endpoint and Registered Server objects to support showing the current FQDN of a server.

#### Az.Websites
* Fixed 'Set-AzWebApp' to return a valid warning message when fails to add -Hostname #9316
* Fixed 'Get-AzWebApp' to return CustomDomainVerificationId in the response. #9316

### Thanks to our community contributors
* Andrew Sears (@asears)
  * Fix spelling of accountname (#15779)
  * Fix Spelling, examples (#15780)
* @cawrites, Update New-AzDataMigrationService.md (#15646)
* @harpaul-gill, Adding support for pagination in Sql Get Databases (#15772)
* @jeepingben, Create mutex names that are safe for Linux (fixes #15653) (#15666)
* @LosManos, Docs: Parameter is ignored when listing secrets (#15788)
* Mats Estensen (@matsest), docs: add examples for Update-AzSubscription (#15748)
* Mauricio Arroyo (@mauricio-msft), Fix typo in cmdlet example (#15719)

## 6.3.0 - August 2021
#### Az.Accounts
* Disabled context auto saving when token cache persistence fails on Windows and macOS
* Added PowerShell version into telemetry record
* Upgraded Microsoft.ApplicationInsights from 2.4.0 to 2.12.0
* Updated Azure.Core to 1.16.0

#### Az.Aks
* Added 'Start-AzAksCluster', 'Stop-AzAksCluster', 'Get-AzAksUpgradeProfile' and 'Get-AzAksNodePoolUpgradeProfile'. [#14194]
* Added property 'IdentityProfile' in the output of 'Get-AzAksCluster'. [#12546]

#### Az.CognitiveServices
* [Breaking Change] Changed type of PSCognitiveServicesAccount.Identity.Type from IdentityType to ResourceIdentityType.
* [Breaking Change] Changed type of PSCognitiveServicesAccount.Sku.Tier from SkuTier to string.
* [Breaking Change] Removed ActionRequired from PrivateLinkServiceConnectionState.
* Updated PowerShell to use 2021-04-30 version.
* Added 'Undo-AzCognitiveServicesAccountRemoval' cmdlet.
* Added parameters '-RestrictOutboundNetworkAccess', '-AllowedFqdnList', '-DisableLocalAuth', '-KeyVaultIdentityClientId', '-IdentityType', '-UserAssignedIdentityId' to 'New-AzureCognitiveServicesAccount' and 'Set-AzureCognitiveServicesAccount'.
* Added parameters '-InRemovedState', '-Location' to 'Remove-AzureCognitiveServicesAccount' and 'Get-AzureCognitiveServicesAccount'.

#### Az.Compute
* Fixed the warning in 'New-AzVM' cmdlet stating the sku of the VM is being defaulted even if a sku size is provided by the user. Now it only occurs when the user does not provide a sku size.
* Edited 'Set-AzVmOperatingSystem' cmdlet to no longer overwrite any existing EnableAutomaticUpdates value on the passed in virtual machine if it exists.
* Updated Compute module to use the latest .Net SDK version 48.0.0.
* Added new cmdlets for the Capacity Reservation Feature:
    - 'New-AzCapacityReservationGroup'
    - 'Remove-AzCapacityReservationGroup'
    - 'Get-AzCapacityReservationGroup'
    - 'New-AzCapacityReservation'
    - 'Remove-AzCapacityReservation'
    - 'Get-AzCapacityReservation'
* Added a new parameter '-CapacityReservationGroupId' to the following cmdlets:
    - 'New-AzVm'
    - 'New-AzVmConfig'
    - 'New-AzVmss'
    - 'New-AzVmssConfig'
    - 'Update-AzVm'
    - 'Update-AzVmss'

#### Az.DataFactory
* Updated ADF .Net SDK version to 4.21.0

#### Az.Migrate
* Added SQL Server license type.
* Added CRN feature.
* Added resource tags feature.
* Updated to 2021-02-10 api version.

#### Az.Monitor
* Added parameter 'ResourceGroupName' back for 'Add-AzAutoscaleSetting' parameter set 'AddAzureRmAutoscaleSettingUpdateParamGroup' and made it optional [#15491]

#### Az.RecoveryServices
* Added Archive for V1 vaults.
* Added ProtectedItemsCount in Get-AzRecoveryServicesBackupProtectionPolicy.
* Azure site recovery bug fix for azure to azure in update vm properties.

#### Az.RedisCache
* Added 'RedisVersion' parameter in 'New-AzRedisCache' and 'Set-AzRedisCache'

#### Az.Resources
* Fixed bug with 'PSResource' where some constructors left 'SubscriptionId' property unassigned/null.  [#10783]
* Added support for creating and updating Template Spec in Bicep file [#15313]
* Added '-ProceedIfNoChange' parameter to deployment create cmdlets.

#### Az.ServiceFabric
* Fixed Managed and Classic Application models (Application, Cluster, Service) by updating constructor to take all new properties
    - This solves piping related issues where piping the results directly from a Get cmdlet call into and Update or Set call remove some intentionally set properties
    - Updated appropriate test files to cover the above mentioned cases

#### Az.Sql
* Fixed identity logic in 'Set-AzSqlServer' and 'Set-AzSqlInstance'

#### Az.Storage
* Supported Blob Last Access Time
    -  'Enable-AzStorageBlobLastAccessTimeTracking'
    -  'Disable-AzStorageBlobLastAccessTimeTracking'
    -  'Add-AzStorageAccountManagementPolicyAction'
* Made 'Get-AzDataLakeGen2ChildItem' list all datalake gen2 items by default, instead of needing user to list chunk by chunk.
* Fixed BlobProperties is empty issue when using sas without prefix '?' [#15460]
* Fixed synchronously copy small blob failure [#15548]
    - 'Copy-AzStorageBlob'

#### Az.Websites
* Fixed 'Add-AzWebAppAccessRestrictionRule' failing when users does not have permissions to get Service Tag list #15316 and #14862

### Thanks to our community contributors
* Borys Generalov (@bgener), Update Get-AzPolicyState.md (#15455)
* Dean Mock (@deanmock), Update New-AzAutomationSchedule.md (#15371)
* John Bevan (@JohnLBevan), #10783 - Fix for Get-AzResource returning PSResource with null SubscriptionId (#15106)
* Michael Mejias Sanchez (@mikemej), Update - Update deployment (external VNET) (#15391)
* @mjsharma, Adding note for alternate commands (#15360)
* Ked Mardemootoo (@nocticdr), Fixed some typos for added clarity (#15428)
* Pascal Berger (@pascalberger), Fix parameter name in Sync-AzVirtualNetworkPeering examples (#15493)
* @rcabr, Doc fix in Get-AzStorageContainer (#15476)
* AAron (@S-AA-RON), Update New-AzNetworkSecurityGroup.md (#15512)
* 坂本ポテコ (@sakamoto-poteko), Update New-AzVMConfig.md (#15376)
* @Shawn-Yuen, Update Remove-AzDataLakeGen2Item.md (#15388)

## 6.2.1 - July 2021
#### Az.Accounts
* Fixed access error when subscripiton has no 'Tags' property [#15425].

## 6.2.0 - July 2021
#### Az.Accounts
* Added Tags, AuthorizationSource to PSAzureSusbscripiton and added TenantType, DefaultDomain, TenantBrandingLogoUrl, CountryCode to PSAzureTenant [#15220]
* Upgraded subscription client to 2021-01-01 [#15220]
* Removed Interactive mode check in common lib
* Added endpoint of OperationalInsights to environment AzureChinaCloud [#15305]
* Printed auto generated modules' default logs to verbose stream

#### Az.Aks
* Added parameter 'AvailabilityZone' for 'New-AzAksNodePool'. [#14505]

#### Az.ApplicationInsights
* Added read only property 'ConnectionString' and 'ApplicationId' to applicationinsights component

#### Az.Compute
* Added optional parameter '-OrchestrationMode' to 'New-AzVmss' and 'New-AzVmssConfig'
* Updated the following cmdlets to work when the resource uses a remote image source using AKS or Shared Image Gallery.
    - 'Update-AzVm'
    - 'Update-AzVmss'
    - 'Update-AzGalleryImageVersion'
* Added parameters '-EnableCrossZoneUpgrade' and '-PrioritizeUnhealthyInstance' to the 'Set-AzVmssRollingUpgradePolicy'
* Added 'AssessmentMode' parameter to the 'Set-AzVMOperatingSystem' cmdlet.
* Fixed a bug in 'Add-AzVmssNetworkInterfaceConfiguration'
* Fixed IOPS and throughput check in 'Test-AzVMAEMExtension'
* Added new cmdlets for 2020-12-01 DiskRP API version
    - New-AzDiskPurchasePlanConfig
    - Set-AzDiskSecurityProfile
* Changed Cmdlets for 2020-12-01 DiskRP API version
    - New-AzDiskConfig
    - New-AzSnapshotConfig
    - New-AzSnapshotUpdateConfig
    - New-AzDiskUpdateConfig
    - New-AzDiskEncryptionSetConfig
    - Update-AzDiskEncryptionSet

#### Az.CosmosDB
* This release introduces the cmdlets for the features of Continuous Backup(Point in time restore):
  - Introduced support for creating accounts with continuous mode backup policy.
  - Introduced support for Point in time restore for accounts with continuous mode backup policy.
  - Introduced support to update the backup interval and backup retention for accounts with periodic mode backup policy.
  - Introduced support to list the restorable resources in a live database account.
  - Introduces support to specify analytical storage schema type on account creation/update.
  - The following cmdlets are added:
    - Restore-AzCosmosDBAccount, New-AzCosmosDBDatabaseToRestore, Get-AzCosmosDBRestorableDatabaseAccount,
    - Get-AzCosmosDBSqlRestorableDatabase, Get-AzCosmosDBSqlRestorableContainer, Get-AzCosmosDBSqlRestorableResource,
    - Get-AzCosmosDBMongoDBRestorableDatabase, Get-AzCosmosDBMongoDBRestorableCollection, Get-AzCosmosDBMongoDBRestorableResource.

#### Az.DataFactory
* Added Customer Managed Key Encryption to DataFactory

#### Az.Functions
* Added two additional app settings (WEBSITE_CONTENTSHARE and WEBSITE_CONTENTAZUREFILECONNECTIONSTRING) for Linux Consumption apps. [15124]
* Fixed bug with New-AzFunctionApp when created on Azure Gov. [13379]
* Added Az.Functions cmdlets need to support creating and copying app settings with empty values. [14511]

#### Az.Monitor
* Fixed null reference bug for 'Get-AzMetric' when 'ResultType' set to 'Metadata'
* Fixed bug for 'Add-AzAutoscaleSetting' not able to pipe result from 'Get-AzAutoscaleSetting' [#13861]

#### Az.Network
* Added public ip address as an optional parameter to create route server
    - 'New-AzRouteServer'
* Updated cmdlets to enable specification of edge zone
    - 'New-AzPublicIpPrefix'
    - 'New-AzLoadBalancer'
    - 'New-AzPrivateLinkService'
    - 'New-AzPrivateEndpoint'
* Added support for viewing extended location of virtual network in the console
    - 'New-AzVirtualNetwork'
    - 'Get-AzVirtualNetwork'
* Added support for viewing extended location of public IP address in the console
    - 'New-AzPublicIpAddress'
    - 'Get-AzPublicIpAddress'

#### Az.RecoveryServices
* Fixed Disable SQL AG AutoProtection.

#### Az.Security
* General availability of Az.Security module
* Changed the name of Get-AzRegulatoryComplainceAssessment to Get-AzRegulatoryComplianceAssessment to fix typo

#### Az.Sql
* Added 'RestrictOutboundNetworkAccess' parameter to following cmdlets
    - 'New-AzSqlServer'
    - 'Set-AzSqlServer'
* Added new cmdlets for CRUD operations on Allowed FQDNs of Outbound Firewall rules
      'Get-AzSqlServerOutboundFirewallRule'
      'New-AzSqlServerOutboundFirewallRule'
      'Remove-AzSqlServerOutboundFirewallRule'
* Fixed the identity logic for SystemAssigned,UserAssigned identities for New-AzSqlServer, New-AzSqlInstance
* Updated cmdlets for getting and updating SQL database's differential backup frequency
      'Get-AzSqlDatabaseBackupShortTermRetentionPolicy'
      'Set-AzSqlDatabaseBackupShortTermRetentionPolicy'
* Fixed Partial PUT issue for Azure Policy in 'Set-AzSqlServer' and 'Set-AzSqlInstance'

#### Az.Storage
* Supported enable/disable Blob container soft delete
    -  'Enable-AzStorageContainerDeleteRetentionPolicy'
    -  'Disable-AzStorageContainerDeleteRetentionPolicy'
* Supported list deleted Blob containers
    -  'Get-AzRmStorageContainer'
    -  'Get-AzStorageContainer'
* Supported restore deleted Blob container
    -  'Restore-AzStorageContainer'
* Supported secure SMB setting in File service properties
    - 'Update-AzStorageFileServiceProperty'
* Supported create account with EnableNfsV3
    - 'New-AzStorageAccount'
* Supported input more copy blob parameters from pipeline [#15301]
    -  'Start-AzStorageBlobCopy'

#### Az.Websites
* Fixed 'Import-AzWebAppKeyVaultCertificate' to support ServerFarmId [#15091]
* Fixed 'Added an optional parameter to delete or keep Appservice plan when the last WebApp is removing from plan'

### Thanks to our community contributors
* Mikey Bronowski (@MikeyBronowski)
  * Update Get-AzSynapseTriggerRun.md (#15231)
  * Update Get-AzSynapsePipelineRun.md by adding more examples covering more scenarios (#15232)
* @mjsharma, Adding note for alternate commands (#15359)
* @tomswedlund, Adding support for setting analytical storage schema type on account create/update for CosmosDB (#15362)
* @ylabade, Fix web app parameter name in examples (#15291)


## 6.1.0 - June 2021
#### Az.Accounts
* Added cmdlet 'Open-AzSurveyLink'
* Supported certificate file as input parameter of Connect-AzAccount

#### Az.Aks
* Fixed the issue that 'Set-AzAks' will fail in Automation Runbook. [#15006]

#### Az.ApplicationInsights
* Fixed issue that 'ResourcegroupName' is missed when executing below cmdlets with 'InputObject' parameter [#14848]
  * 'Get-AzApplicationInsightsLinkedStorageAccount'
  * 'New-AzApplicationInsightsLinkedStorageAccount'
  * 'Update-AzApplicationInsightsLinkedStorageAccount'
  * 'Remove-AzApplicationInsightsLinkedStorageAccount'

#### Az.Cdn
* Fixed profile missing issue in 'Remove-AzCdnProfile' cmdlet

#### Az.Compute
* Updated Compute module to use the latest .Net SDK version 47.0.0.

#### Az.ContainerInstance
* Removed the display of file share credential [#15224]

#### Az.DataFactory
* Updated ADF .Net SDK version to 4.19.0

#### Az.EventHub
* Added functionality to accept input from pipeline for 'Get-AzEventHub' from 'Get-AzEventHubNamespace'.

#### Az.HDInsight
* Support new azure monitor feature in HDInsight:
    - Add cmdlet 'Get-AzHDInsightAzureMonitor' to allow customer to get the Azure Monitor status of HDInsight cluster.
    - Add cmdlet 'Enable-AzHDInsightAzureMonitor' to allow customer to enable the Azure Monitor in HDInsight cluster.
    - Add cmdlet 'Disable-AzHDInsightAzureMonitor' to allow customer to disable the Azure Monitor in HDInsight cluster.

#### Az.KeyVault
* Removed duplicate list item in 'Get-AzKeyVault' [#15164]
* Added 'SecretManagement' tag to 'Az.KeyVault' module [#15173]

#### Az.Network
* Updated cmdlets for route server for a more stable way to add IP configuration.
* Added support for getting a single private link resource.
* Added more detailed description about GroupId in 'New-AzPrivateLinkServiceConnection'
* Updated cmdlets to enable setting of PrivateRange on AzureFirewallPolicy.
    - 'New-AzFirewallPolicy'
    - 'Set-AzFirewallPolicy'
* Updated cmdlets to add NatRules in VirtualNetworkGateway and BgpRouteTranslationForNat.
    - 'New-AzVirtualNetworkGateway'
    - 'Set-AzVirtualNetworkGateway'
* Updated cmdlets to add EngressNatRules and EgressNatRules in VirtualNetworkGateway Connection.
    - 'New-AzVirtualNetworkGatewayConnection'
    - 'Set-AzVirtualNetworkGatewayConnection'
* Updated cmdlet to enable setting of FlowTimeout in VirtualNetwork.
    - 'New-AzVirtualNetwork'
* Added cmdlets for Get/Create/Update/Delete VirtualNetworkGatewayNatRules.
    - 'New-AzVirtualNetworkGatewayNatRule'
    - 'Update-AzVirtualNetworkGatewayNatRule'
    - 'Get-AzVirtualNetworkGatewayNatRule'
    - 'Remove-AzVirtualNetworkGatewayNatRule'
* Added a new cmdlet for Sync on VirtualNetworkPeering
    - 'Sync-AzVirtualNetworkPeering'
* Updated cmdlets to add new properties and redefined an existing property in the VirtualNetworkPeering
    - 'Add-AzVirtualNetworkPeering'
    - 'Get-AzVirtualNetworkPeering'
* Updated cmdlets to enable setting of PreferredRoutingGateway on VirtualHub.
    - 'New-AzVirtualHub'
    - 'Update-AzVirtualHub'
* Updated cmdlets to expose two read-only properties of client certificate.
    - 'Get-AzApplicationGatewayTrustedClientCertificate'

#### Az.RecoveryServices
* Added cross tenant DS Move.
* Removed restriction to fetch recovery points only for a 30 days time range.
* Enabled CRR for new regions.

#### Az.Resources
* Allowed naming the deployment when testing deployments [#11497]

#### Az.SignalR
* Changed to 'Allow' and 'Deny' parameters of 'Update-AzSignalRNetworkAcl' cmdlet:
    - Accepted 'Trace' as a valid value.
    - Accepted '@()' as empty collection to clear the list.
* Supported 'ResourceGroupCompleter' and 'ResourceNameCompleter' in the applicable cmdlets.
* Deprecated the 'HostNamePrefix' property of output type 'PSSignalRResource' of following cmdlets:
    - 'Get-AzSignalR'
    - 'New-AzSignalR'
    - 'Update-AzSignalR'

#### Az.Sql
* Added option to support short version of maintenance configuration id for Managed Instance in 'New-AzSqlInstance' and 'Set-AzSqlInstance' cmdlets
* Added HighAvailabilityReplicaCount to 'New-AzSqlDatabaseSecondary'
* Added External Administrator and AAD Only Properties to AzSqlServer and AzSqlInstance
    - Added option to specify '-ExternalAdminName', '-ExternalAdminSid', '-EnableActiveDirectoryOnlyAuthentication' in 'New-AzSqlInstance' and 'Set-AzSqlInstance' cmdlets
    - Added option to expand external administrators information using '-ExpandActiveDirectoryAdministrator' in 'Get-AzSqlServer' and 'Get-AzSqlInstance' cmdlets
* Fixed 'Set-AzSqlDatabase' to no longer default ReadScale to Disabled when not specified
* Fixed 'Set-AzSqlServer' and 'Set-AzSqlInstance' for partial PUT with only identity and null properties
* Added parameters related to UMI in 'New-AzSqlServer', 'New-AzSqlInstance', 'Set-AzSqlServer' and 'Set-AzSqlInstance' cmdlets.
* Added -AutoRotationEnabled parameter to following cmdlets:
    - 'Set-AzSqlServerTransparentDataEncryptionProtector'
    - 'Get-AzSqlServerTransparentDataEncryptionProtector'
    - 'Set-AzSqlInstanceTransparentDataEncryptionProtector'
    - 'Get-AzSqlInstanceTransparentDataEncryptionProtector'

#### Az.Storage
* Supported create file share with NFS/SMB enabledEnabledProtocol and RootSquash, and update share with RootSquash
    - 'New-AzRmStorageShare'
    - 'Update-AzRmStorageShare'
* Supported enable Smb Multichannel on File service
    -  'Update-AzStorageFileServiceProperty'
* Fixed copy inside same account issue by access source with anonymous credential, when copy Blob inside same account with Oauth credential
* Removed StorageFileDataSmbShareOwner from value set of parameter DefaultSharePermission in create/update storage account
    - 'New-AzStorageAccount'
    - 'Set-AzStorageAccount'

#### Az.Websites
* Fixed issue that prevented removing rules by name and unique identifier in 'Remove-AzWebAppAccessRestrictionRule'
* Fixed issue that defaults AlwaysOn to false in 'Set-AzWebAppSlot'

### Thanks to our community contributors
* Andy Roberts (@andyr8939), Removing unused TimeGrain variable from example (#15062)
* Ashley Roll (@AshleyRoll), Remove Write-Host leaking file share credentials (#15225)
* Kailash Mandal (@KaishM), Update New-AzPublicIpAddress.md (#15040)
* Olivier Miossec (@omiossec), Update Get-AzExpressRouteCircuitRouteTable.md (#15054)
* Scott (@S-T-S), Update Set-AzNetworkInterface.md (#15112)
* @sohaibMSFT, Application Gateway AutoScale Example (#15071)
* @Srihsu, Update Split-AzReservation.md (#15049)
* @srozemuller, typo in examples resourcegroup parameter (#15146)


## 6.0.0 - May 2021
Az 6.0.0 (Az.Accounts 2.3.0) is only supported on Windows PowerShell 5.1, PowerShell 7.0 version 7.0.6 or greater and PowerShell 7.1 version 7.1.3 or greater, open https://aka.ms/install-powershell to learn how to upgrade. For further information, go to http://aka.ms/azpslifecyle.

#### Az.Accounts
* Upgraded Azure.Identity to 1.4 and MSAL to 4.30.1
* Removed obsolete parameters 'ManagedServiceHostName', 'ManagedServicePort' and 'ManagedServiceSecret' of cmdlet 'Connect-AzAccount', environment variables 'MSI_ENDPOINT' and 'MSI_SECRET' could be used instead
* Customize display format of PSAzureRmAccount to hide secret of service principal [#14208]
* Added optional parameter 'AuthScope' to 'Connect-AzAccount' to support enhanced authentication of data plane features
* Set retry times by environment variable [#14748]
* Supported subject name issuer authentication

#### Az.Compute
* Added 'Invoke-AzVmInstallPatch' to support patch installation in VMs using PowerShell.
* Updated Compute module to use the latest .Net SDK version 46.0.0.
* Added optional parameter '-EdgeZone' to the following cmdlets:
    - 'Get-AzVMImage
    - 'Get-AzVMImageOffer'
    - 'Get-AzVMImageSku'
    - 'New-AzDiskConfig'
    - 'New-AzImageConfig'
    - 'New-AzSnapshotConfig'
    - 'New-AzVM'
    - 'New-AzVmssConfig'
    - 'New-AzVMSS'

#### Az.ContainerInstance
* Added new cmdlets: 'Start-AzContainerGroup', 'Stop-AzContainerGroup' [#10773], 'Invoke-AzContainerInstanceCommand' [#7648], 'Update-AzContainerGroup', 'Add-AzContainerInstanceOutput', 'Get-AzContainerInstanceCachedImage', 'Get-AzContainerInstanceCapability', 'Get-AzContainerInstanceUsage', 'New-AzContainerGroupImageRegistryCredentialObject', 'New-AzContainerGroupPortObject', 'New-AzContainerGroupVolumeObject', 'New-AzContainerInstanceEnvironmentVariableObject', 'New-AzContainerInstanceInitDefinitionObject', 'New-AzContainerInstanceObject', 'New-AzContainerInstancePortObject' and 'New-AzContainerInstanceVolumeMountObject'
* Supported Log Analytics parameters in 'New-AzContainerGroup' [#11117]
* Added support to specify network profile and the name of Azure File Share in 'New-AzContainerGroup' [#9993] [#12218]
* Added support to specify environment variables as SecureValue [#10110] [#10640]

#### Az.ContainerRegistry
* Fixed username and password issue in 'Import-AzContainerRegistryImage' [#14971]
* Fixed data plane operations (repository, tag, manifest) failed cross registry in single Powershell session [#14849]

#### Az.CosmosDB
* Introduced support for Sql data plane RBAC, allowing the creation, updating, removal, and retrieval of Role Definitions and Role Assignments
  - The following cmdlets are added:
    - Get-AzCosmosDBSqlRoleDefinition, Get-AzCosmosDBSqlRoleAssignment,
    - New-AzCosmosDBSqlRoleDefinition, New-AzCosmosDBSqlRoleAssignment,
    - Remove-AzCosmosDBSqlRoleDefinition, Remove-AzCosmosDBSqlRoleAssignment,
    - Update-AzCosmosDBSqlRoleDefinition, Update-AzCosmosDBSqlRoleAssignment,
    - New-AzCosmosDBSqlPermission

#### Az.DesktopVirtualization
* Upgraded api version to 2021-02-01-preview.

#### Az.Functions
* Added support in function app creation for Python 3.9 and Node 14 function apps
* Removed support in function app creation for V2, Python 3.6, Node 8, and Node 10 function apps
* Updated IdentityID parameter from string to string array in Update-AzFunctionApp. This is to be consistent with New-AzFunctionApp which has the same parameter as a string array
* Updated FullyQualifiedErrorId for an invalid Functions version from FunctionsVersionIsInvalid to FunctionsVersionNotSupported
* When creating a Node.js function app, if no runtime version is specified, the default runtime version is set to 14 instead of 12

#### Az.KeyVault
* Provided key size for RSA key [#14819]

#### Az.Kusto
* Bumped API version to stable 2021-01-01

#### Az.Maintenance
* Bumped API version to stable 2021-05-01

#### Az.Migrate
* Fixed an issue in Initialize-AzMigrateReplicationInfrastructure.ps1

#### Az.Network
* Updated validation to allow passing zero value for saDataSizeKilobytes parameter
    - 'New-AzureRmIpsecPolicy'
* Added optional parameter '-EdgeZone' to the following cmdlets:
    - 'New-AzNetworkInterface'
    - 'New-AzPublicIpAddress'
    - 'New-AzVirtualNetwork'

#### Az.RecoveryServices
* Fixed security issue with SQL restore, this is a necessary breaking change. TargetContainer becomes mandatory for Alternate Location Restore.
* Removed Set-AzRecoveryServicesBackupProperties cmdlet alias, Set-AzRecoveryServicesBackupProperty is supported.
* Removed Get-AzRecoveryServicesBackupJobDetails cmdlet alias, Get-AzRecoveryServicesBackupJobDetail is supported.
* Added support for cross subscription DS Move.
* Azure Site Recovery support for VMware to Azure disaster recovery scenarios using RCM as the control plane.

#### Az.Resources
* Changed '-IdentifierUris' in 'New-AzADApplication' to optional parameter
* Removed generated 'DisplayName' of ADApplication created by 'New-AzADServicePrincipal'
* Updated SDK to 3.13.1-preview to use GA TemplateSpecs API version
* Added 'AdditionalProperties' to PSADUser and PSADGroup [#14568]
* Supported 'CustomKeyIdentifier' in 'New-AzADAppCredential' and 'Get-AzADAppCredential' [#11457], [#13723]
* Changed 'MainTemplate' to be shown by the default formatter for Template Spec Versions

#### Az.SecurityInsights
* GA release for `Az.SecurityInsights`

#### Az.ServiceFabric
* Removed deprecated cluster certificate commands:
    - 'Add-AzServiceFabricClusterCertificate'
    - 'Remove-AzServiceFabricClusterCertificate'
* Changed PSManagedService model to avoid using the properties parameter directly from sdk.
* Removed deprecated parameters for managed cmdlets:
    - 'ReverseProxyEndpointPort'
    - 'InstanceCloseDelayDuration'
    - 'ServiceDnsName'
    - 'InstanceCloseDelayDuration'
    - 'DropSourceReplicaOnMove'
* Fixed 'Update-AzServiceFabricReliability' to update correctly the vm instance count of the primary node type on the cluster resource.

#### Az.Sql
* Updated 'Set-AzSqlDatabaseVulnerabilityAssessmentRuleBaseline' documentation to include example of define array of array with one inner array.
* Added cmdlet 'Copy-AzSqlDatabaseLongTermRetentionBackup'
    - Copy LTR backups to different servers
* Added cmdlet 'Update-AzSqlDatabaseLongTermRetentionBackup'
    - Update Backup Storage Redundancy values for LTR backups
* Added CurrentBackupStorageRedundancy, RequestedBackupStorageRedundancy to 'Get-AzSqlDatabase', 'New-AzSqlDatabase', 'Set-AzSqlDatabase', 'New-AzSqlDatabaseSecondary', 'Set-AzSqlDatabaseSecondary', 'New-AzSqlDatabaseCopy'
    - Changed BackupStorageRedundancy value to CurrentBackupStorageRedundancy, RequestedBackupStorageRedundancy to reflect both the current value and what has been requested if a change was made

#### Az.Storage
* Supported file share snapshot
    - 'New-AzRmStorageShare'
    - 'Get-AzRmStorageShare'
    - 'Remove-AzRmStorageShare'
* Supported remove file share with it's snapshot (leased and not leased), by default remove file share will fail when share has snapshot
    - 'Remove-AzRmStorageShare'
* Supported Set/Get/Remove blob inventory policy
    - 'New-AzStorageBlobInventoryPolicyRule'
    - 'Set-AzStorageBlobInventoryPolicy'
    - 'Get-AzStorageBlobInventoryPolicy'
    - 'Remove-AzStorageBlobInventoryPolicy'
* Supported DefaultSharePermission in create/update storage account
    - 'New-AzStorageAccount'
    - 'Set-AzStorageAccount'
* Supported AllowCrossTenantReplication in create/update storage account
    - 'New-AzStorageAccount'
    - 'Set-AzStorageAccount'
* Supported Set Object Replication Policy with SourceAccount/DestinationAccount as Storage account resource Id
    - 'Set-AzStorageObjectReplicationPolicy'
* Supported set SasExpirationPeriod as TimeSpan.Zero
    - 'New-AzStorageAccount'
    - 'Set-AzStorageAccount
* Make sure the correct account name is used when create account credential
    - 'New-AzStorageContext'

#### Az.StorageSync
* Deprecated 'Invoke-AzStorageSyncFileRecall'
    - Customers should instead use 'Invoke-StorageSyncFileRecall', a cmdlet that is shipped with the Azure File Sync agent.
* Removed offline data transfer feature in 'New-AzStorageSyncServerEndpoint'.

#### Az.StreamAnalytics
* Bumped API version to 2017-04-01-preview
* Added StreamAnalytics Cluster support

#### Az.Websites
* updated 'Set-AzAppServicePlan' to keep existing Tags when adding new Tags
* Fixed 'Set-AzWebApp' to set the AppSettings
* updated 'Set-AzWebAppSlot' to set FtpsState
* Added support for StaticSites.

### Thanks to our community contributors
* @corichte, Update New-AzVirutalNetworkGatewayConnection Ex 1 (#14858)
* Hiroshi Yoshioka (@hyoshioka0128)
  * Typo "Azure SQL database"→"Azure SQL Database" (#14883)
  * Typo "Azure SQL managed instance"→"Azure SQL Managed Instance" (#14891)
  * Typo "Azure SQL managed instance"→"Azure SQL Managed Instance" (#14892)
  * Typo "Azure SQL managed instance"→"Azure SQL Managed Instance" (#14902)
  * Typo "Azure SQL managed instance"→"Azure SQL Managed Instance" (#14901)
  * Typo "Azure SQL managed instance"→"Azure SQL Managed Instance" (#14900)
  * Typo "Azure SQL managed instance"→"Azure SQL Managed Instance" (#14898)
  * Typo "Azure SQL managed instance"→"Azure SQL Managed Instance" (#14899)
* Jay Zelos (@jzelos), Updated example 3 to use correct parameter (#14852)
* @StevePantol, Update New-AzVMwarePrivateCloud.md (#14996)


## 5.9.0 - May 2021
#### Az.Aks
* Added support 'AcrNameToAttach' in 'Set-AzAksCluster'. [#14692]
* Added support 'AcrNameToDetach' in 'Set-AzAksCluster'. [#14693]
* Added 'Set-AzAksClusterCredential' to reset the ServicePrincipal of an existing AKS cluster.

#### Az.Automation
* Added support for User Assigned Identities and PublicNetworkAccess flag

#### Az.Cdn
* Added cmdlets to support new AFD Premium / Standard SKUs

#### Az.Compute
* Updated the 'Set-AzVMDiskEncryptionExtension' cmdlet to support ADE extension migration from two pass (version with AAD input parameters) to single pass (version without AAD input parameters).
    - Added a switch parameter '-Migrate' to trigger migration workflow.
    - Added a switch parameter '-MigrationRecovery' to trigger recovery workflow for VMs experiencing failures after migration from two pass ADE.

#### Az.DataFactory
* Added User Assigned Identities to Data Factory.
* Updated ADF .Net SDK version to 4.18.0

#### Az.FrontDoor
* Allowed Enable-AzFrontDoorCustomDomainHttps's SecretVersion parameter to be optional to support bring-your-own-certificate auto-rotation

#### Az.KeyVault
* Fixed a bug for 'Get-AzKeyVaultSecret -IncludeVersions' when current version is disabled [#14740]
* Displayed error code and message when updating purged secret [#14800]

#### Az.RecoveryServices
* Azure Site Recovery support for Multiple IP per NIC for Azure to Azure provider.
* Azure Site Recovery support for SqlServerLicenseType for VMware to Azure and HyperV to Azure providers.
* Azure Site Recovery support for Availability set for VMware to Azure and HyperV to Azure providers.
* Azure Site Recovery support for TargetVmSize for VMware to Azure and HyperV to Azure providers.
* Azure Site Recovery support for ResourceTagging for VMware to Azure and HyperV to Azure providers.
* Azure Site Recovery support for Virtual Machine Scale Set for Azure to Azure provider.
* Added support for restoring unmanaged disks vm as managed disks.

#### Az.Resources
* Added parameter 'ObjectType' for 'New-AzRoleAssignment'

#### Az.ServiceFabric
* Upgraded Managed Cluster commands to use Service Fabric Managed Cluster SDK version 1.0.0 which uses service fabric resource provider api-version 2021-05-01.
* 'New-AzServiceFabricManagedCluster' add parameters UpgradeCadence and ZonalResiliency.
* 'New-AzServiceFabricManagedNodeType' add parameters DiskType, VmUserAssignedIdentity, IsStateless and MultiplePlacementGroup.
* 'New-AzServiceFabricManagedClusterService' and 'Set-AzServiceFabricManagedClusterService' mark parameters for deprecation: InstanceCloseDelayDuration, DropSourceReplicaOnMove and ServiceDnsName. They are not supported.

#### Az.ResourceMover
* General availability of 'Az.ResourceMover' module

#### Az.Storage
* Supported create/update storage account with KeyExpirationPeriod and SasExpirationPeriod
    - 'New-AzStorageAccount'
    - 'Set-AzStorageAccount'
* Supported create/update storage account with keyvault encryption and access keyvault with user assigned identity
    - 'New-AzStorageAccount'
    - 'Set-AzStorageAccount'
* Supported EdgeZone in create storage account
    - 'New-AzStorageAccount'
* Fixed an issue that delete immutable blob will prompt incorrect message.
    - 'Remove-AzStorageAccount'
* Allowed update Storage Account KeyVault properties by cleanup Keyversion to enable key auto rotation [#14769]
    - 'Set-AzStorageAccount'
* Added breaking change warning message for upcoming cmdlet breaking change
    - 'Remove-AzRmStorageShare'

### Thanks to our community contributors
* Thomas Lee (@doctordns), Update Get-AzEnvironment.md (#14704)
* Fabian (@FullByte), Example with wrong parameter (typo) (#14743)
* @gradinDotCom, Update Get-AzNetworkWatcherNextHop.md (#14813)
* Dr Greg Low (@greglow-sdu), Update Get-AzSqlServerDnsAlias.md (#14737)
* Prateek Singh (@PrateekKumarSingh)
  * fixing a typo (#14779)
  * fixing typo (#14773)
* Remco Eissing (@remcoeissing)
  * Fixed typos in Restore-AzApiManagement (#14770)
  * Example 2 to use New-AzPolicyExemption (#14716)
* @sharma224
  * User identity changes (#14803)
  * Supporting Customer managed key  (#14680)
* Yannick Dils (@yannickdils), Update Location explanation (#14719)


## 5.8.0 - April 2021
#### Az.Accounts
* Fallback to first valid context if current default context key is 'Default' which is invalid

#### Az.Automation
* Added support for Customer Managed Key Encryption with System Assigned Identity
* Fixed issue that disables the schedule for update deployment if schedule was re-created with same name

#### Az.Compute
* Fixed a bug when 1 data disk attached to VMSS for Remove-AzVmssDataDisk [#13368]
* Added new cmdlets to support TrustedLaunch related cmdlets:
    - 'Set-AzVmSecurityProfile'
    - 'Set-AzVmUefi'
    - 'Set-AzVmssSecurityProfile'
    - 'Set-AzVmssUefi'
* Edited default value for Size parameter in New-AzVM cmdlet from Standard_DS1_v2 to Standard_D2s_v3.

#### Az.ContainerRegistry
* Fixed bug in 'Get-AzContainerRegistryManifest' showing incorrect image name

#### Az.HDInsight
* Supported getting default vmsize from backend if customer does not provide the related parameters: '-WorkerNodeSize', '-HeadNodeSize', '-ZookeeperNodeSize', '-EdgeNodeSize', '-KafkaManagementNodeSize'.

#### Az.HealthcareApis
* Added support for Acr LoginServers

#### Az.KeyVault
* Fixed a bug for 'Get-AzKeyVaultSecret -AsPlainText' if the secret is not found [#14645]

#### Az.Migrate
* Nullref Bug fixed in get discovered server and initialize replication infrastructure commandlets.

#### Az.Monitor
* Added cmdlet to get diagnostic setting categories for subscription
    - 'Get-AzSubscriptionDiagnosticSettingCategory'
* Supported subscription diagnostic setting operations with new parameter: SubscriptionId
    - 'Get-AzDiagnosticSetting'
    - 'New-AzDiagnosticSetting'
    - 'Remove-AzDiagnosticSetting'
* Supported 'AutoMitigate' parameter in metric alert rule properties. The flag indicates whether the alert should be auto resolved or not.

#### Az.Resources
* Added upcoming breaking change warnings on below cmdlets, because the value of 'IdentifierUris' parameter will need verified domain.
  - 'New-AzADApplication'
  - 'Update-AzADApplication'
  - 'New-AzADServicePrincipal'
  - 'Update-AzADServicePrincipal'
* Ignored Bicep warning message in error stream if exitcode equals zero.

#### Az.Sql
* Added cmdlet output breaking change warnings to the following:
    - 'New-AzSqlDatabase'
    - 'Get-AzSqlDatabase'
    - 'Set-AzSqlDatabase'
    - 'Remove-AzSqlDatabase'
    - 'New-AzSqlDatabaseSecondary'
    - 'Remove-AzSqlDatabaseSecondary'
    - 'Get-AzSqlDatabaseReplicationLink'
    - 'New-AzSqlDatabaseCopy'
    - 'Set-AzSqlDatabaseSecondary'

#### Az.Storage
* Fixed copy blob fail with source context as Oauth [#14662]
    -  'Start-AzStorageBlobCopy'

#### Az.StreamAnalytics
* Added upcoming breaking change warning message to all cmdlets because of upcoming changes on parameters.

### Thanks to our community contributors
* Andrei Zhukouski (@BurgerZ), Fix typo (#14575)
* Mark Allison (@markallisongit), Update Invoke-AzSqlInstanceFailover.md (#14603)


## 5.7.0 - March 2021
#### Az.Accounts
* Fixed incorrect warning message on Windows PowerShell [#14556]
* Set Azure Environment variable 'AzureKeyVaultServiceEndpointResourceId' according to the value of 'AzureKeyVaultDnsSuffix' when discovering environment

#### Az.Automation
* Fixed the issue for starting Python3 runbooks with parameters

#### Az.DataFactory
* Updated ADF .Net SDK version to 4.15.0

#### Az.EventHub
* Fixed that 'New-AzServiceBusAuthorizationRuleSASToken' returns invalid token. [#12975]

#### Az.IotHub
* Updated IoT Hub Management SDK and models to version 3.0.0 (api-version 2020-03-01)

#### Az.KeyVault
* Supported upcoming new API design for 'Export-AzKeyVaultSecurityDomain'
* Fixed several typos in cmdlet messages [#14341]

#### Az.Network
* Added new cmdlets to replace old product name 'virtual router' with new name 'route server' in the future.
    - 'Get-AzRouteServerPeerAdvertisedRoute'
    - 'Get-AzRouteServerPeerAdvertisedRoute'
    - Added deprecation attribute warning to the old cmdlets.
* Updated 'set-azExpressRouteGateway' to allow parameter -MinScaleUnits without specifying -MaxScaleUnits
* Updated cmdlets to enable setting of VpnLinkConnectionMode on VpnSiteLinkConnections.
    - 'New-AzVpnSiteLinkConnection'
    - 'Update-AzVpnConnection'
* Added new cmdlet to fetch IKE Security Associations for VPN Site Link Connections.
    - 'Get-VpnSiteLinkConnectionIkeSa'
* Added new cmdlet to reset a Virtual Network Gateway Connection.
    - 'Reset-AzVirtualNetworkGatewayConnection'
* Added new cmdlet to reset a Vpn Site Link Connection.
    - 'Reset-VpnSiteLinkConnection'
* Updated cmdlets to enable setting an optional parameter -TrafficSelectorPolicies
    - 'New-AzVpnConnection'
    - 'Update-AzVpnConnection'
* Bug fix for update vpnServerConfiguration.
* Add scenarioTest for p2s multi auth VWAN.
* Added multi auth feature support for VNG
	- 'Get-AzVpnClientConfiguration'
	- 'New-AzVirtualNetworkGateway'
	- 'Set-AzVirtualNetworkGateway'

#### Az.RecoveryServices
* Added Cross Zonal Restore for managed virtual machines.

#### Az.RedisEnterpriseCache
* GA version of Az.RedisEnterpriseCache

#### Az.Resources
* Redirected bicep message to verbose stream
* Removed the logic of copying Bicep template file to temp folder.
* Add support of policy exemption resource type
* Fixed what-if functionality when using '-QueryString' parameter.
* Normalized '-QueryString' starting with '?' for scenarios involving dynamic parameters.

#### Az.ServiceBus
* Fixed that 'New-AzServiceBusAuthorizationRuleSASToken' returns invalid token. [#12975]

#### Az.ServiceFabric
* Added parameters 'VMImagePublisher', 'VMImageOffer', 'VMImageSku', 'VMImageVersion' to 'Add-AzServiceFabricNodeType' to facilitate easy alternate OS image creation for new node type.
* Added parameter 'IsPrimaryNodeType' to 'Add-AzServiceFabricNodeType' to be able to create an additional primary node type, for the purpose of transitioning the primary node type to another one in the case of OS migration.
* 'Add-AzServiceFabricNodeType' now correctly copies the LinuxDiagnostic extension. This was previously not working for Linux.
* 'Add-AzServiceFabricNodeType' now correctly copies the RDP/SSH load balancer inbound NAT port mapping to the new node type.
* Added template for 'UbuntuServer1804' for creating Ubuntu 18.04 clusters using 'New-AzServiceFabricCluster'.
* 'Remove-AzServiceFabricNodeType' was incorrectly blocking Bronze durability node types for removal, and this has been updated to only block when the Bronze durability level differs between the SF node type and VMSS setting.
* Added cmdlet 'Update-AzServiceFabricVmImage' to update the delivered SF runtime package type. This must be changed when migrating from Ubuntu 16 to 18.
* Added cmdlet 'Update-AzServiceFabricNodeType' to update the properties of a cluster node type. For now this is solely used to update whether the node type is primary via bool parameter '-IsPrimaryNodeType False'.
* 'Update-AzServiceFabricReliability' is now able to update reliability level when the cluster has more than one primary node type. To do this, the name of the node type is supplied via the new -NodeType parameter.
* Added new cmdlets for managed applications:
    - 'New-AzServiceFabricManagedClusterApplication'
    - 'Get-AzServiceFabricManagedClusterApplication'
    - 'Set-AzServiceFabricManagedClusterApplication'
    - 'Remove-AzServiceFabricManagedClusterApplication'
    - 'New-AzServiceFabricManagedClusterApplicationType'
    - 'Get-AzServiceFabricManagedClusterApplicationType'
    - 'Set-AzServiceFabricManagedClusterApplicationType'
    - 'Remove-AzServiceFabricManagedClusterApplicationType'
    - 'New-AzServiceFabricManagedClusterApplicationTypeVersion'
    - 'Get-AzServiceFabricManagedClusterApplicationTypeVersion'
    - 'Set-AzServiceFabricManagedClusterApplicationTypeVersion'
    - 'Remove-AzServiceFabricManagedClusterApplicationTypeVersion'
    - 'New-AzServiceFabricManagedClusterService'
    - 'Get-AzServiceFabricManagedClusterService'
    - 'Set-AzServiceFabricManagedClusterService'
    - 'Remove-AzServiceFabricManagedClusterService'
* Upgraded Managed Cluster commands to use Service Fabric Managed Cluster SDK version 1.0.0-beta.1 which uses service fabric resource provider api-version 2021-01-01-preview.

#### Az.Sql
* Added cmdlet 'New-AzSqlServerTrustGroup'
* Added cmdlet 'Remove-AzSqlServerTrustGroup'
* Added cmdlet 'Get-AzSqlServerTrustGroup'

#### Az.Storage
* Fixed an issue that list account from resource group won't use nextlink
    - 'Get-AzStorageAccount'
* Supported ChangeFeedRetentionInDays when Enable ChangeFeed on Blob service
    - 'Update-AzStorageBlobServiceProperty'

#### Az.Websites
* Updated 'Add-AzWebAppAccessRestrictionRule' to allow all supported Service Tags and validate against Service Tag API.

### Thanks to our community contributors
* Freddie Sackur (@fsackur), Fix invalid SAS token from New-AzServiceBusAuthorizationRuleSASToken and New-AzEventHubAuthorizationRuleSASToken (#14535)
* Serafín Martín (@infoTrainingym), Unkown parameter (#14515)
* João Carlos Ferra de Almeida (@Jalmeida1994), Update Get-AzAksNodePool.md (#14503)
* Liam Barnett (@liambarnett), Fixed 3 typos in the document (#14335)
* @sbojjawar-Msft, Update Set-AzSqlDatabaseVulnerabilityAssessmentRuleBaseline.md (#14432)
* Yannick Dils (@yannickdils), Remove resource group from get-azloadbalancer this results in a region / zone update. (#14417)


## 5.6.0 - March 2021
#### Az.Accounts
* Upgrade Azure.Identity to fix the issue that Connect-AzAccount fails when ADFS credential is used [#13560]

#### Az.Automation
* Fixed the issue that string cannot be serialized correctly. [#14215]
* Added Support for Python3 Runbook Type

#### Az.Compute
* Added parameter '-EnableHotpatching' to the 'Set-AzVMOperatingSystem' cmdlet for Windows machines.
* Added parameter '-PatchMode' to the Linux parameter sets in the cmdlet 'Set-AzVMOperatingSystem'.
* [Breaking Change] Breaking changes for users in the public preview for the VM Guest Patching feature.
    - Removed property 'RebootStatus' from the 'Microsoft.Azure.Management.Compute.Models.LastPatchInstallationSummary' object.
    - Removed property 'StartedBy' from the 'Microsoft.Azure.Management.Compute.Models.LastPatchInstallationSummary' object.
    - Renamed property 'Kbid' to 'KbId' in the 'Microsoft.Azure.Management.Compute.Models.VirtualMachineSoftwarePatchProperties' object.
    - Renamed property 'patches' to 'availablePatches' in the 'Microsoft.Azure.Management.Compute.Models.VirtualMachineAssessPatchesResult' object.
    - Renamed object 'Microsoft.Azure.Management.Compute.Models.SoftwareUpdateRebootBehavior' to 'Microsoft.Azure.Management.Compute.Models.VMGuestPatchRebootBehavior'.
    - Renamed object 'Microsoft.Azure.Management.Compute.Models.InGuestPatchMode' to 'Microsoft.Azure.Management.Compute.Models.WindowsVMGuestPatchMode'.
* [Breaking Change] Removed all 'ContainerService' cmdlets. The Container Service API was deprecated in January 2020.
    - 'Add-AzContainerServiceAgentPoolProfile'
    - 'Get-AzContainerService'
    - 'New-AzContainerService'
    - 'New-AzContainerServiceConfig'
    - 'Remove-AzContainerService'
    - 'Remove-AzContainerServiceAgentPoolProfile'
    - 'Update-AzContainerService'

#### Az.ContainerRegistry
* Fixed authentication for `Connect-AzContainerRegistry`

#### Az.CosmosDB
* Introduced NetworkAclBypass and NetworkAclBypassResourceIds for Database Account cmdlets.
* Introduced ServerVersion parameter to Update-AzCosmosDBAccount.
* Introduced BackupInterval and BackupRetention for Database Account cmdlets

#### Az.DataFactory
* Updated ADF .Net SDK version to 4.14.0

#### Az.Migrate
* Az.Migrate GA
* Incorporated Initialize-AzMigrateReplicationInfrastructure as a cmdlet in the Az.Migrate module, from the external script that is run currently today.
* Made some parameters of New-AzMigrateServerReplication, New-AzMigrateDiskMapping case insensitive.
* Added support for scale appliance change, to handle new V3 keys.

#### Az.RecoveryServices
* Added null check for target storage account in FileShare restore.

#### Az.Resources
* Added support for Azure resources deployment in Bicep language
* Fixed issues with TemplateSpec deployments in 'New-AzTenantDeployment' and 'New-AzManagementGroupDeployment'
* Added support for '-QueryString' parameter in 'Test-Az*Deployments' cmdlets
* Fixed issue with dynamic parameters when 'New-Az*Deployments' is used with '-QueryString'
* Added support for '-TemplateParameterObject' parameter while using '-TemplateSpecId' parameter in 'New-Az*Deployments' cmdlets
* Fixed the inaccurate error message received on trying to deploy a non-existent template spec

#### Az.Storage
* Upgraded to Microsoft.Azure.Management.Storage 19.0.0, to support new API version 2021-01-01.
* Supported resource access rule in NetworkRuleSet
    - 'Update-AzStorageAccountNetworkRuleSet'
    - 'Add-AzStorageAccountNetworkRule'
    - 'Remove-AzStorageAccountNetworkRule'
* Supported Blob version and Append Blob type in Management Policy
    - 'Add-AzStorageAccountManagementPolicyAction'
    - 'New-AzStorageAccountManagementPolicyFilter'
    - 'Set-AzStorageAccountManagementPolicy'
* Supported create/update account with AllowSharedKeyAccess
    - 'New-AzStorageAccount'
    - 'Set-AzStorageAccount'
* Supported create Encryption Scope with RequireInfrastructureEncryption
    - 'New-AzStorageEncryptionScope'
* Supported copy block blob synchronously, with encryption scope
    - 'Copy-AzStorageBlob'
* Fixed issue that Get-AzStorageBlobContent use wrong directory separator char on Linux and MacOS [#14234]

#### Az.Websites
* Introduced an option to give custom timeout for 'Publish-AzWebApp'
* Added support for App Service Environment
    - 'New-AzAppServiceEnvironment'
    - 'Remove-AzAppServiceEnvironment'
    - 'Get-AzAppServiceEnvironment'
    - 'New-AzAppServiceEnvironmentInboundServices'

### Thanks to our community contributors
* @alunmj, Small spelling, formatting changes (#14155)
* @chakra146, Update Add-AzLoadBalancerInboundNatPoolConfig.md (#14231)
* Martin Ehrnst (@ehrnst), Fixed a typo in the cmdlet (#14112)
* Jan David Narkiewicz (@jdnark)
  * Examples used New-AzAks which is legacy cmdlet and the alias for New-AzAksCluster. Changed examples to use New-AzAksCluster which is the cmdlet this documentation page targets. (#14088)
  * Type fox: changed SshKeyVaule to SshKeyValue (#14087)
* Ivan Kulezic (@kukislav), Add sql mi maintenance configuration examples (#14216)
* @webguynj, Update Set-AzNetworkSecurityRuleConfig.md (#14176)
* Yannick Dils (@yannickdils), Added an additional cmdline to the example which applies the changes to the load balancer (#14185)


## 5.5.0 - February 2021
#### Az.Accounts
* Tracked CloudError code in exception
* Raised 'ContextCleared' event when 'Clear-AzContext' was executed

#### Az.Aks
* Refined error messages of cmdlet failure.
* Upgraded exception handling to use Azure PowerShell related exceptions.
* Fixed the issue that user could not use provided service principal to create Kubernetes cluster. [#13938]

#### Az.Automation
* Fixed the issue of processing 'PSCustomObject' and 'Array'.

#### Az.Compute
* Added parameter '-EnableAutomaticUpgrade' to 'Set-AzVmExtension' and 'Add-AzVmssExtension'.
* Removed FilterExpression parameter from 'Get-AzVMImage' cmdlet documentation.
* Added deprecation message to the ContainerService cmdlets:
    - 'Add-AzureRmContainerServiceAgentPoolProfileCommand'
    - 'Get-AzContainerService'
    - 'New-AzContainerService'
    - 'New-AzContainerServiceConfig'
    - 'Remove-AzContainerService'
    - 'Remove-AzContainerServiceAgentPoolProfile'
    - 'Update-AzContainerService'
* Added parameter '-BurstingEnabled' to 'New-AzDiskConfig' and 'New-AzDiskUpdateConfig'
* Added '-GroupByApplicationId' and '-GroupByUserAgent' parameters to the 'Export-AzLogAnalyticThrottledRequest' and 'Export-AzLogAnalyticRequestRateByInterval' cmdlets.
* Added 'VMParameterSet' parameter set to 'Get-AzVMExtension' cmdlet. Added new parameter '-VM' to this parameter set.

#### Az.ContainerRegistry
* Added cmdlets to supported repository, manifest, and tag operations:
    - 'Get-AzContainerRegistryRepository'
    - 'Update-AzContainerRegistryRepository'
    - 'Remove-AzContainerRegistryRepository'
    - 'Get-AzContainerRegistryManifest'
    - 'Update-AzContainerRegistryManifest'
    - 'Remove-AzContainerRegistryManifest'
    - 'Get-AzContainerRegistryTag'
    - 'Update-AzContainerRegistryTag'
    - 'Remove-AzContainerRegistryTag'

#### Az.Databricks
Supported -EnableNoPublicIP when creating a Databricks workspace

#### Az.FrontDoor
* Added FrontDoorId to properties
* Added JSON Exclusions and RequestBodyCheck support to managed rules

#### Az.HDInsight
* Added new parameter '-EnableComputeIsolation' and '-ComputeIsolationHostSku' to the cmdlet 'New-AzHDInsightCluster' to support compute isolation feature
* Added property 'ComputeIsolationProperties' and 'ConnectivityEndpoints' in the class AzureHDInsightCluster.

#### Az.KeyVault
* Supported specifying key type and curve name when importing keys via a BYOK file

#### Az.Network
* Added new cmdlets to replace old product name 'virtual router' with new name 'route server' in the future.
    - 'New-AzRouteServer'
    - 'Get-AzRouteServer'
    - 'Remove-AzRouteServer'
    - 'Update-AzRouteServer'
    - 'Get-AzRouteServerPeer'
    - 'Add-AzRouteServerPeer'
    - 'Update-AzRouteServerPeer'
    - 'Remove-AzRouteServerPeer'
    - Added deprecation attribute warning to the old cmdlets.
* Bug fix in ExpressRouteLink MacSecConfig. Added new property 'SciState' to 'PSExpressRouteLinkMacSecConfig'
* Updated format list and format table views for Get-AzVirtualNetworkGatewayConnectionIkeSa

#### Az.PolicyInsights
* Retracted changes made in powershell that increased request row limit. Removed incorrect statement of supporting paging

#### Az.RecoveryServices
* modified policy validation limits as per backup service.
* Added Zone Redundancy for Recovery Service Vaults.
* Azure Site Recovery support for Proximity placement group for VMware to Azure and HyperV to Azure providers.
* Azure Site Recovery support for Availability zone for VMware to Azure and HyperV to Azure providers.
* Azure Site Recovery support for UseManagedDisk for HyperV to Azure provider

#### Az.Resources
* Removed principal type on New-AzRoleAssignment and Set-AzRoleAssignment because current mapping was breaking certain scenarios

#### Az.Sql
* Added MaintenanceConfigurationId to 'New-AzSqlDatabase', 'Set-AzSqlDatabase', 'New-AzSqlElasticPool' and 'Set-AzSqlElasticPool'
* Fixed regression in 'Set-AzSqlServerAudit' when PredicateExpression argument is provided

#### Az.Storage
* Supported RoutingPreference settings in create/update Storage account
    - 'New-AzStorageAccount'
    - 'Set-AzStorageAccount'
* Upgraded Azure.Storage.Blobs to 12.8.0
* Upgraded Azure.Storage.Files.Shares to 12.6.0
* Upgraded Azure.Storage.Files.DataLake to 12.6.0

#### Az.Websites
* Added support for Importing a key vault certificate to WebApp.

### Thanks to our community contributors
* @atul-ram, Update Set-AzEventHub.md (#13921)
* Christoph Bergmeister [MVP] (@bergmeister), Set-AzDataLakeGen2AclRecursive.md - Fix typo (directiry -> directory) (#14082)
* Alexander Schmidt (@devdeer-alex), Fixed broken link to contribution guidelines (#14009)
* @JiangYuchun, Update Get-AzApplicationGatewayAuthenticationCertificate.md (#13972)
* Sebastian Olsen (@Spacebjorn), Corrected example command (#13901)


## 5.4.0 - January 2021
#### Az.Accounts
* Shown correct client request id on debug message [#13745]
* Added common Azure PowerShell exception type
* Supported storage API 2019-06-01

#### Az.Automation
* Fixed issue where description was not populated for update management schedules

#### Az.CosmosDB
* General availability of 'Az.CosmosDB' module
* Restricting New-AzCosmosDBAccount cmdlet to make update calls to existing Database Accounts.
* Introducing AnalyticalStorageTTL in SqlContainer.

#### Az.IotHub
* Fixed a regression regarding SAS token generation

#### Az.KeyVault
* Fixed an issue in Secret Management module

#### Az.LogicApp
* Fixed issue that 'Get-AzLogicAppTriggerHistory' and 'Get-AzLogicAppRunAction' only retrieving the first page of results [#9141]

#### Az.Monitor
* Added cmdlets for data collection rules:
    - 'Get-AzDataCollectionRule'
    - 'New-AzDataCollectionRule'
    - 'Set-AzDataCollectionRule'
    - 'Update-AzDataCollectionRule'
    - 'Remove-AzDataCollectionRule'
* Added cmdlets for data collection rules associations
    - 'Get-AzDataCollectionRuleAssociation'
    - 'New-AzDataCollectionRuleAssociation'
    - 'Remove-AzDataCollectionRuleAssociation'

#### Az.Network
* Added new cmdlets for CRUD of VpnGatewayNATRule.
    - 'New-AzAzVpnGatewayNatRule'
    - 'Update-AzAzVpnGatewayNatRule'
    - 'Get-AzAzVpnGatewayNatRule'
    - 'Remove-AzAzVpnGatewayNatRule'
* Updated cmdlets to set NATRule on VpnGateway resource and associate it with VpnSiteLinkConnection resource.
    - 'New-AzVpnGateway'
    - 'Update-AzVpnGateway'
    - 'New-AzVpnSiteLinkConnection'
* Updated cmdlets to enable setting of ConnectionMode on Virtual Network Gateway Connections.
    - 'New-AzVirtualNetworkGatewayConnection'
    - 'Set-AzVirtualNetworkGatewayConnection'
* Updated 'New-AzFirewallPolicyApplicationRule' cmdlet:
    - Added parameter TargetUrl
    - Added parameter TerminateTLS
* Added new cmdlets for Azure Firewall Premium Features
    - 'New-AzFirewallPolicyIntrusionDetection'
    - 'New-AzFirewallPolicyIntrusionDetectionBypassTraffic'
    - 'New-AzFirewallPolicyIntrusionDetectionSignatureOverride'
* Updated New-AzFirewallPolicy cmdlet:
    - Added parameter -SkuTier
    - Added parameter -Identity
    - Added parameter -UserAssignedIdentityId
    - Added parameter -IntrusionDetection
    - Added parameter -TransportSecurityName
    - Added parameter -TransportSecurityKeyVaultSecretId
* Added new cmdlet to fetch IKE Security Associations for Virtual Network Gateway Connections.
    - 'Get-AzVirtualNetworkGatewayConnectionIkeSa'
* Added multiple Authentication support for p2sVpnGateway
    - Updated New-AzVpnServerConfiguration and Update-AzVpnServerConfiguration to allow multiple authentication parameters to be set.
* Updated 'New-AzVpnGateway' and 'New-AzP2sVpnGateway' cmdlet:
    - Added parameter EnableRoutingPreferenceInternetFlag

#### Az.RecoveryServices
* Added Cross Region Restore feature.
* Blocked getting workload config when target item is an availability group.

#### Az.Resources
* Added support for -QueryString parameter in New-Az*Deployments cmdlets

#### Az.Sql
* Made 'Start-AzSqlInstanceDatabaseLogReplay' cmdlet synchronous, added -AsJob flag

#### Az.Storage
* Fix ContinuationToken never null when list blob with -IncludeVersion
    - 'Get-AzStorageBlob'

#### Az.Websites
* Added support for App Service Managed certificates
    - 'New-AzWebAppCertificate'
    - 'Remove-AzWebAppCertificate'
* Fixed issue that causes Docker Password to be removed from appsettings in 'Set-AzWebApp' and 'Set-AzWebAppSlot'

### Thanks to our community contributors
* Ivan Akcheurov (@ivanakcheurov), Update Set-AzSecurityWorkspaceSetting.md (#13877)
* @javiermarasco, Update example (#13837)
* @jhaprakash26, Update Set-AzVirtualNetwork.md (#13857)
* Michael Holmes (@MichaelHolmesWP), Update New-AzStorageTableStoredAccessPolicy.md (#13871)
* Michael James (@mikejwhat), Allow Get-AzLogicAppTriggerHistory and Get-AzLogicAppRunAction to return more than 30 results (#13846)
* @Willem-J-an, Fix bug causing Docker Password to be removed from appsettings in Set-AzWebApp(Slot) (#13866)


## 5.3.0 - December 2020
#### Az.Accounts
* Fixed the issue that Http proxy is not respected in Windows PowerShell [#13647]
* Improved debug log of long running operations in generated modules

#### Az.Automation
* Fixed issue that parameters of 'Start-AzAutomationRunbook' cannot convert PSObject wrapped string to JSON string [#13240]
* Fixed location completer for New-AzAutomationUpdateManagementAzureQuery cmdlet

#### Az.Compute
* New parameter 'VM' in new parameter set 'VMParameterSet' added to 'Get-AzVMDscExtensionStatus' and 'Get-AzVMDscExtension' cmdlets.
* Edited 'New-AzSnapshot' cmdlet to check for existing snapshot with the same name in the same resource group.
    - Throws an error if a duplicate snapshot exists.

#### Az.Databricks
* Fixed an issue that may cause 'New-AzDatabricksVNetPeering' to return before it is fully provisioned (https://github.com/Azure/autorest.powershell/issues/610)

#### Az.DataFactory
* Fixed the command 'Invoke-AzDataFactoryV2Pipeline' for SupportsShouldProcess issue

#### Az.DesktopVirtualization
* Added StartVMOnConnect property to hostpool.

#### Az.HDInsight
* Added properties: Fqdn and EffectiveDiskEncryptionKeyUrl in the class AzureHDInsightHostInfo.

#### Az.KeyVault
* Added a new parameter '-AsPlainText' to 'Get-AzKeyVaultSecret' to directly return the secret in plain text [#13630]
* Supported selective restore a key from a managed HSM full backup [#13526]
* Fixed some minor issues [#13583] [#13584]
* Added missing return objects of 'Get-Secret' in SecretManagement module
* Fixed an issue that may cause vault to be created without default access policy [#13687]

#### Az.Kusto
* Updated API version to 2020-09-18.

#### Az.Network
* Fixed issue in remove peering and connection cmdlet for ExpressRouteCircuit scenario
    - 'Remove-AzExpressRouteCircuitPeeringConfig' and 'Remove-AzExpressRouteCircuitConnectionConfig'

#### Az.PolicyInsights
* Added support for returning paginated results for Get-AzPolicyState

#### Az.RecoveryServices
* Enabled softdelete feature for SQL.
* Fixed SQL AG restore and removed the container name check.
* Changed container name format for Azure Files backup item.
* Added CMK feature support for Recovery services vault.

#### Az.Resources
* Fixed a NullRef exception issue in 'New-AzureManagedApplication' and 'Set-AzureManagedApplication'.
* Updated Azure Resource Manager SDK to use latest DeploymentScripts GA api-version: 2020-10-01.

#### Az.ServiceFabric
* Fixed 'Add-AzServiceFabricNodeType'. Added node type to service fabric cluster before creating virtual machine scale set.

#### Az.Sql
* Fixed parameter description for 'InstanceFailoverGroup' command.
* Updated the logic in which schemaName, tableName and columnName are being extracted from the id of SQL Data Classification commands.
* Fixed Status and StatusMessage fields in 'Get-AzSqlDatabaseImportExportStatus' to conform to documentation
* Added Microsoft support operations (DevOps) auditing cmdlets: Get-AzSqlServerMSSupportAudit, Set-AzSqlServerMSSupportAudit, Remove-AzSqlServerMSSupportAudit

#### Az.Storage
* Supported create/update/get/list EncryptionScope of a Storage account
    - 'New-AzStorageEncryptionScope'
    - 'Update-AzStorageEncryptionScope'
    - 'Get-AzStorageEncryptionScope'
* Supported create container and upload blob with Encryption Scope setting
    - 'New-AzRmStorageContainer'
    - 'New-AzStorageContainer'
    - 'Set-AzStorageBlobContent'

### Thanks to our community contributors
* Andreas Wolter (@AndreasWolter), removed marketing language, better example filter (#13671)
* Tidjani Belmansour (@BelRarr), Update Get-AzBillingInvoice.md (#13634)
* David Klempfner (@DavidKlempfner)
  * Fixed spelling mistake (#13677)
  * Update PSMetricNoDetails.cs (#13676)
* @kilobyte97, bugfix for remove cmdlet to delete config (#13655)
* @kongou-ae, Update Set-AzFirewall.md (#13727)
* @MasterKuat, Fix swap between title and code in documentation (#13666)
* NickT (@nukeulis), Update Set-AzContext.md (#13702)
* @PaulHCode, Update Start-AzJitNetworkAccessPolicy.md - Fix the Example to display the proper cmdlet being demonstrated (#13713)
* Ryan Borstelmann (@ryanborMSFT), Removed Subscription ID (#13715)
* Shashikant Shakya (@shshakya), Update Set-AzSqlDatabase.md (#13674)
* Sebastian Olsen (@Spacebjorn), Update Get-AzRecoveryServicesBackupItem.md (#13719)

## 5.2.0 - December 2020
#### Az.Accounts
* Managed to parse ExpiresOn time from raw token if could not get from underlying library
* Improved warning message if Interactive authentication is unavailable

#### Az.ApiManagement
* [Breaking change] 'New-AzApiManagementProduct' by default has no subscription limit.

#### Az.Compute
* Edited Get-AzVm to filter by '-Name' prior to checking for throttling due to too many resources.
* New cmdlet 'Start-AzVmssRollingExtensionUpgrade'.

#### Az.ContainerRegistry
* Supported parameter 'Name' for and value from pipeline input for 'Get-AzContainerRegistryUsage' [#13605]
* Polished exceptions for 'Connect-AzContainerRegistry'

#### Az.DataFactory
* Updated ADF .Net SDK version to 4.13.0

#### Az.HealthcareApis
* Added support for customer managed keys

#### Az.IotHub
* Fixed an issue of SAS token.

#### Az.KeyVault
* Supported 'all' as an option when setting key vault access policies
* Supported new version of SecretManagement module [#13366]
* Supported ByteArray, String, PSCredential and Hashtable for 'SecretValue' in SecretManagementModule [#12190]
* [Breaking change] redesigned the API surface of cmdlets related to managed HSM.

#### Az.Monitor
* Changed parameter 'Rule' of 'New-AzAutoscaleProfile' to accept empty list. [#12903]
* Added new cmdlets to support creating diagnostic settings more flexible:
    * 'Get-AzDiagnosticSettingCategory'
    * 'New-AzDiagnosticSetting'
    * 'New-AzDiagnosticDetailSetting'

#### Az.RecoveryServices
* Made help text and parameter set name changes to 'Restore-AzRecoveryServicesBackupItem' cmdlet.

#### Az.Resources
* Added '-Tag' parameter support to 'Set-AzTemplateSpec' and 'New-AzTemplateSpec'
* Added Tag display support to default formatter for Template Specs

#### Az.ServiceFabric
* Added example to 'Set-AzServiceFabricSetting' with SettingsSectionDescription param
* Updated application related cmdlets to call out that support is only for ARM deployed resources
* Marked for deprecation cluster cert cmdlets 'Add-AzureRmServiceFabricClusterCertificate' and 'Remove-AzureRmServiceFabricClusterCertificate'

#### Az.Sql
* Added SecondaryType to the following:
    - 'New-AzSqlDatabase'
    - 'Set-AzSqlDatabase'
    - 'New-AzSqlDatabaseSecondary'
* Added HighAvailabilityReplicaCount to the following:
    - 'New-AzSqlDatabase'
    - 'Set-AzSqlDatabase'
* Made ReadReplicaCount an alias of HighAvailabilityReplicaCount in the following:
    - 'New-AzSqlDatabase'
    - 'Set-AzSqlDatabase'

#### Az.Storage
* Supported upload Azure File size up to 4 TiB
    - 'Set-AzStorageFileContent'
* Upgraded Azure.Storage.Blobs to 12.7.0
* Upgraded Azure.Storage.Files.Shares to 12.5.0
* Upgraded Azure.Storage.Files.DataLake to 12.5.0

#### Az.StorageSync
* Added Sync tiering policy feature with download policy and local cache mode

#### Az.Websites
* Prevent duplicate access restriction rules

### Thanks to our community contributors
* Andrew Dawson (@dawsonar802), Update Get-AzKeyVaultCertificate.md - Get cert and save it as pfx section to work with PowerShell Core (#13557)
* @iviark, Healthcare APIs Powershell BYOK Updates (#13518)
* John Duckmanton (@johnduckmanton), Correct spelling of TagPatchOperation (#13508)
* Michael James (@mikejwhat)
  * Get-AzLogicAppRunHistory Help Tidy (#13513)
* Richard de Zwart (@mountain65)
  * Update Update-AzAppConfigurationStore.md (#13485)
  * Update New-AzCosmosDBAccount.md (#13490)
* @SteppingRazor, New-AzApiManagementProduct: Change SubscriptionsLimit parameter default value to None (#13457)
* Steve Burkett (@SteveBurkettNZ), Fix Typo for WorkspaceResourceId parameter in example (#13589)

## 5.1.0 - November 2020
#### Az.Accounts
* Fixed an issue that TenantId may be not respected if using 'Connect-AzAccount -DeviceCode'[#13477]
* Added new cmdlet 'Get-AzAccessToken'
* Fixed an issue that error happens if user profile path is inaccessible
* Fixed an issue causing Write-Object error during Connect-AzAccount [#13419]
* Added parameter 'ContainerRegistryEndpointSuffix' to: 'Add-AzEnvironment', 'Set-AzEnvironment'
* Supported interrupting login by hitting <kbd>CTRL</kbd>+<kbd>C</kbd>
* Fixed an issue causing 'Connect-AzAccount -KeyVaultAccessToken' not working [#13127]
* Fixed null reference and method case insensitive in 'Invoke-AzRestMethod'

#### Az.Aks
* Fixed the issue that user cannot use service principal to create a new Kubernetes cluster. [#13012]

#### Az.AppConfiguration
* General availability of 'Az.AppConfiguration' module

#### Az.DataFactory
* Improved error message of 'New-AzDataFactoryV2LinkedServiceEncryptedCredential' command

#### Az.DataLakeStore
* Updated ADLS dataplane SDK to 1.2.4-alpha. Changes:https://github.com/Azure/azure-data-lake-store-net/blob/preview-alpha/CHANGELOG.md#version-124-alpha

#### Az.DesktopVirtualization
* Added new MSIX Package cmdlets and updated Applications cmdlets.

#### Az.EventHub
* Fixed Cluster commands for EventHub cluster without tags
* Updated help text for PartnerNamespace of AzEventHubGeoDRConfiguration commands

#### Az.HDInsight
* Add parameters 'ResourceProviderConnection' and 'PrivateLink' to cmdlet 'New-AzHDInsightCluster' to support relay outbound and private link feature
* Add parameter 'AmbariDatabase' to cmdlet 'New-AzHDInsightCluster' to support custom Ambari database feature
* Add accept value 'AmbariDatabase' to the parameter 'MetastoreType' of the cmdlet 'Add-AzHDInsightMetastore'

#### Az.IotHub
* Allowed tags in IoT Hub create cmdlet.

#### Az.KeyVault
* Supported updating key vault tag

#### Az.LogicApp
* Fixed for Get-AzLogicAppRunHistory only retrieving the first page of results

#### Az.Network
* Updated below cmdlet
    - 'New-AzLoadBalancerFrontendIpConfigCommand', 'Set-AzLoadBalancerFrontendIpConfigCommand', 'Add-AzLoadBalancerFrontendIpConfigCommand':
        - Added PublicIpAddressPrefix property
        - Added PublicIpAddressPrefixId property
* Added new properties to the following cmdlets to allow for global load balancing
    - 'New-AzLoadBalancer':
        - Added Sku Tier property
    - 'New-AzPuplicIpAddress':
        - Added Sku Tier property
    - 'New-AzPublicIpPrefix':
        - Added Sku Tier property
    - 'New-AzLoadBalancerBackendAddressConfig':
        - Added LoadBalancerFrontendIPConfigurationId property
* Updated planning to deprecate warnings for the following cmdlets
    -'New-AzVirtualHubRoute'
    -'New-AzVirtualHubRouteTable'
    -'Add-AzVirtualHubRoute'
    -'Add-AzVirtualHubRouteTable'
    -'Get-AzVirtualHubRouteTable'
    -'Remove-AzVirtualHubRouteTable'
* Added planning to deprecate warnings on the argument 'RouteTable' for the following cmdlets
    -'New-AzVirtualHub'
    -'Set-AzVirtualHub'
    -'Update-AzVirtualHub'
* Made arguments '-MinScaleUnits' and '-MaxScaleUnits' optional in 'Set-AzExpressRouteGateway'
* Added new cmdlets to support Mutual Authentication and SSL Profiles on Application Gateway
    - 'Get-AzApplicationGatewayClientAuthConfiguration'
    - 'New-AzApplicationGatewayClientAuthConfiguration'
    - 'Remove-AzApplicationGatewayClientAuthConfiguration'
    - 'Set-AzApplicationGatewayClientAuthConfiguration'
    - 'Add-AzApplicationGatewayTrustedClientCertificate'
    - 'Get-AzApplicationGatewayTrustedClientCertificate'
    - 'New-AzApplicationGatewayTrustedClientCertificate'
    - 'Remove-AzApplicationGatewayTrustedClientCertificate'
    - 'Set-AzApplicationGatewayTrustedClientCertificate'
    - 'Add-AzApplicationGatewaySslProfile'
    - 'Get-AzApplicationGatewaySslProfile'
    - 'New-AzApplicationGatewaySslProfile'
    - 'Remove-AzApplicationGatewaySslProfile'
    - 'Set-AzApplicationGatewaySslProfile'
    - 'Get-AzApplicationGatewaySslProfilePolicy'
    - 'Remove-AzApplicationGatewaySslProfilePolicy'
    - 'Set-AzApplicationGatewaySslProfilePolicy'

#### Az.RecoveryServices
* Specifying policy BackupTime is in UTC.
* Modifying breaking change warning in Get-AzRecoveryServicesBackupJobDetails cmdlet.
* Updating sample script help text for Set-AzRecoveryServicesBackupProtectionPolicy cmdlet.

#### Az.Resources
* Fixed an issue where What-If shows two resource group scopes with different casing
* Updated 'Export-AzResourceGroup' to use the SDK.
* Added culture info to parse methods

#### Az.Sql
* Fixed issues where Set-AzSqlDatabaseAudit were not support Hyperscale database and database edition cannot be determined
* Added MaintenanceConfigurationId to 'New-AzSqlInstance' and 'Set-AzSqlInstance'
* Fixed a bug in GetAzureSqlDatabaseReplicationLink.cs where PartnerServerName parameter was being checked for by value instead of key

#### Az.Websites
* Added support for new access restriction features: ServiceTag, multi-ip and http-headers

### Thanks to our community contributors
* John Q. Martin (@johnmart82), Adding firewall prerequisite information (#13385)
* Manikandan Duraisamy (@madurais-msft), Corrected the PublicSubnetName argument (#13417)
* @mahortas, Update for -HostNames parameter values (#13349)
* @MariachiForHire, added supported TrafficAnalyticsInterval values (#13304)
* Michael James (@mikejwhat), Allow Get-AzLogicAppRunHistory to return more than 30 entries (#13393)
* Shashikant Shakya (@shshakya), Update Restore-AzSqlInstanceDatabase.md (#13404)

## 5.0.0 - October 2020
#### Az.Accounts
* [Breaking Change] Removed 'Get-AzProfile' and 'Select-AzProfile'
* Replaced Azure Directory Authentication Library with Microsoft Authentication Library(MSAL)

#### Az.Aks
* [Breaking Change] Removed parameter alias 'ClientIdAndSecret' in 'New-AzAksCluster' and 'Set-AzAksCluster'.
* [Breaking Change] Changed the default value of 'NodeVmSetType' in 'New-AzAksCluster' from 'AvailabilitySet' to 'VirtualMachineScaleSets'.
* [Breaking Change] Changed the default value of 'NetworkPlugin' in 'New-AzAksCluster' from 'None' to 'azure'.
* [Breaking Change] Removed parameter 'NodeOsType' in 'New-AzAksCluster' as it supports only one value Linux.

#### Az.Billing
* Added 'Get-AzBillingAccount' cmdlet
* Added 'Get-AzBillingProfile' cmdlet
* Added 'Get-AzInvoiceSection' cmdlet
* Added new parameters in 'Get-AzBillingInvoice' cmdlet
* Removed properties DownloadUrlExpiry, Type, BillingPeriodNames from the response of Get-AzBillingInvoice cmdlet

#### Az.Cdn
* Added cmdlets to support multi-origin and private link functionality

#### Az.CognitiveServices
* Updated SDK to 7.4.0-preview.

#### Az.Compute
* Added '-VmssId' parameter to 'New-AzVm'
* Added 'PlatformFaultDomainCount' parameter to the 'New-AzVmss' cmdlet.
* New cmdlet 'Get-AzDiskEncryptionSetAssociatedResource'
* Added 'Tier' and 'LogicalSectorSize' optional parameters to the New-AzDiskConfig cmdlet.
* Added 'Tier', 'MaxSharesCount', 'DiskIOPSReadOnly', and 'DiskMBpsReadOnly' optional parameters to the 'New-AzDiskUpdateConfig' cmdlet.

#### Az.ContainerRegistry
* [Breaking Change] Updates API version to 2019-05-01
* [Breaking Change] Removed SKU 'Classic' and parameter 'StorageAccountName' from 'New-AzContainerRegistry'
* Added New cmdlets: 'Connect-AzContainerRegistry', 'Import-AzContainerRegistry', 'Get-AzContainerRegistryUsage', 'New-AzContainerRegistryNetworkRule', 'Set-AzContainerRegistryNetworkRule'
* Added new parameter 'NetworkRuleSet' to 'Update-AzContainerRegistry'

#### Az.Databricks
* Fixed a bug that may cause updating databricks workspace without `-EncryptionKeyVersion` to fail.

#### Az.DataFactory
* Updated ADF .Net SDK version to 4.12.0
* Updated ADF encryption client SDK version to 4.14.7587.7
* Added 'Stop-AzDataFactoryV2TriggerRun' and 'Invoke-AzDataFactoryV2TriggerRun' commands

#### Az.DesktopVirtualization
* Require Location property for creating top level arm objects.
        * Made `ApplicationGroupType` required for `New-AzWvdApplicationGroup`.
        * Made `HostPoolArmPath` required for `New-AzWvdApplicationGroup`.
        * Added `PreferredAppGroupType` for `New-AzWvdHostPool`.

#### Az.Functions
* [Breaking Change] Removed 'IncludeSlot' switch parameter from all but one parameter set of 'Get-AzFunctionApp'. The cmdlet now supports retrieving deployment slots in the results when '-IncludeSlot' is specified.
* Updated 'New-AzFunctionApp':
  - Fixed -DisableApplicationInsights so that no application insights project is created when this option is specified. [#12728]
  - [Breaking Change] Removed support to create PowerShell 6.2 function apps.
  - [Breaking Change] Changed the default runtime version in Functions version 3 on Windows for PowerShell function apps from 6.2 to 7.0 when the RuntimeVersion parameter is not specified.
  - [Breaking Change] Changed the default runtime version in Functions version 3 on Windows and Linux for Node function apps from 10 to 12 when the RuntimeVersion parameter is not specified.
  - [Breaking Change] Changed the default runtime version in Functions version 3 on Linux for Python function apps from 3.7 to 3.8 when the RuntimeVersion parameter is not specified.

#### Az.HDInsight
 * For New-AzHDInsightCluster cmdlet:
     - Replaced parameter 'DefaultStorageAccountName' with 'StorageAccountResourceId'
     - Replaced parameter 'DefaultStorageAccountKey' with 'StorageAccountKey'
     - Replaced parameter 'DefaultStorageAccountType' with 'StorageAccountType'
     - Removed parameter 'PublicNetworkAccessType'
     - Removed parameter 'OutboundPublicNetworkAccessType'
     - Added new parameters: 'StorageFileSystem' and 'StorageAccountManagedIdentity' to support ADLSGen2
     - Added new parameter 'EnableIDBroker' to Support HDInsight ID Broker
     - Added new parameters: 'KafkaClientGroupId', 'KafkaClientGroupName' and 'KafkaManagementNodeSize' to support Kafka Rest Proxy
 * For New-AzHDInsightClusterConfig cmdlet:
     - Replaced parameter 'DefaultStorageAccountName' with 'StorageAccountResourceId'
     - Replaced parameter 'DefaultStorageAccountKey' with 'StorageAccountKey'
     - Replaced parameter 'DefaultStorageAccountType' with 'StorageAccountType'
     - Removed parameter 'PublicNetworkAccessType'
     - Removed parameter 'OutboundPublicNetworkAccessType'
* For Set-AzHDInsightDefaultStorage cmdlet:
    - Replaced parameter 'StorageAccountName' with 'StorageAccountResourceId'
* For Add-AzHDInsightSecurityProfile cmdlet:
    - Replaced parameter 'Domain' with 'DomainResourceId'
    - Removed the mandatory requirement for parameter 'OrganizationalUnitDN'

#### Az.KeyVault
* [Breaking Change] Deprecated parameter DisableSoftDelete in 'New-AzKeyVault' and EnableSoftDelete in 'Update-AzKeyVault'
* [Breaking Change] Removed attribute SecretValueText to avoid displaying SecretValue directly [#12266]
* Supported new resource type: managed HSM
    - CRUD of managed HSM and cmdlets to operate keys on managed HSM
    - Full HSM backup/restore, AES key creation, security domain backup/restore, RBAC

#### Az.ManagedServices
* [Breaking Change] Updated parameters naming conventions and associated examples

#### Az.Network
* [Breaking Change] Removed parameter 'HostedSubnet' and added 'Subnet' instead
* Added new cmdlets for Virtual Router Peer Routes
    - 'Get-AzVirtualRouterPeerLearnedRoute'
    - 'Get-AzVirtualRouterPeerAdvertisedRoute'
* Updated New-AzFirewall cmdlet:
    - Added parameter '-SkuTier'
    - Added parameter '-SkuName' and made Sku as Alias for this
    - Removed parameter '-Sku'
* [Breaking Change] Made 'Connectionlink' argument mandatory in 'Start-AzVpnConnectionPacketCapture' and 'Stop-AzVpnConnectionPacketCapture'
* [Breaking Change] Updated 'New-AzNetworkWatcherConnectionMonitorEndPointObject' to remove parameter '-Filter'
* [Breaking Change] Replaced 'New-AzNetworkWatcherConnectionMonitorEndpointFilterItemObject' cmdlet with 'New-AzNetworkWatcherConnectionMonitorEndpointScopeItemObject'
* Updated 'New-AzNetworkWatcherConnectionMonitorEndPointObject' cmdlet:
	- Added parameter '-Type'
	- Added parameter '-CoverageLevel'
	- Added parameter '-Scope'
* Updated 'New-AzNetworkWatcherConnectionMonitorProtocolConfigurationObject' cmdlet with new parameter '-DestinationPortBehavior'

#### Az.RecoveryServices
* Fixing Workload Restore for contributor permissions.
* Added new parameter sets and validations for Restore-AzRecoveryServicesBackupItem cmdlet.

#### Az.Resources
* Fixed parsing bug
* Updated ARM template What-If cmdlets to remove preview message from results
* Fixed an issue where template deployment cmdlets crash if '-WhatIf' is set at a higher scope [#13038]
* Fixed an issue where template deployment cmdlets does not preserve case for template parameters
* Added a default API version to be used in 'Export-AzResourceGroup' cmdlet
* Added cmdlets for Template Specs ('Get-AzTemplateSpec', 'Set-AzTemplateSpec', 'New-AzTemplateSpec', 'Remove-AzTemplateSpec', 'Export-AzTemplateSpec')
* Added support for deploying Template Specs using existing deployment cmdlets (via the new -TemplateSpecId parameter)
* Updated 'Get-AzResourceGroupDeploymentOperation' to use the SDK.
* Removed '-ApiVersion' parameter from '*-AzDeployment' cmdlets.

#### Az.Sql
* Added DiffBackupIntervalInHours to 'Set-AzSqlDatabaseBackupShortTermRetentionPolicy'
* Fixed issue where New-AzSqlDatabaseExport fails if networkIsolation not specified [#13097]
* Fixed issue where New-AzSqlDatabaseExport and New-AzSqlDatabaseImport were not returning OperationStatusLink in the result object [#13097]
* Update Azure Paired Regions URL in Backup Storage Redundancy Warnings

#### Az.Storage
* Removed obsolete property RestorePolicy.LastEnabledTime
    - 'Enable-AzStorageBlobRestorePolicy'
    - 'Disable-AzStorageBlobRestorePolicy'
    - 'Get-AzStorageBlobServiceProperty'
    - 'Update-AzStorageBlobServiceProperty'
* Change Type of DaysAfterModificationGreaterThan from int to int?
    - 'Set-AzStorageAccountManagementPolicy'
    - 'Get-AzStorageAccountManagementPolicy'
    - 'Add-AzStorageAccountManagementPolicyAction'
    - 'New-AzStorageAccountManagementPolicyRule'
* Supported create/update file share with access tier
    - 'New-AzRmStorageShare'
    - 'Update-AzRmStorageShare'
* Supported set/update/remove Acl recursively on Datalake Gen2 item
    -  'Set-AzDataLakeGen2AclRecursive'
    -  'Update-AzDataLakeGen2AclRecursive'
    -  'Remove-AzDataLakeGen2AclRecursive'
* Supported Container access policy with new permission x,t
    -  'New-AzStorageContainerStoredAccessPolicy'
    -  'Set-AzStorageContainerStoredAccessPolicy'
* Changed the output of get/set Container access policy cmdlet, by change the child property Permission type from enum to String
    -  'Get-AzStorageContainerStoredAccessPolicy'
    -  'Set-AzStorageContainerStoredAccessPolicy'
* Fixed a sample script issue of set management policy with json
    -  'Set-AzStorageAccountManagementPolicy'

#### Az.Websites
* Added support for Premium V3 pricing tier
* Updated the WebSites SDK to 3.1.0

### Thanks to our community contributors
* @atul-ram, Update Get-AzDelegation.md (#13176)
* @dineshreddy007, Get the App Roles assigned correctly in case of Stack HCI registration using WAC token. (#13249)
* @kongou-ae, Update New-AzOffice365PolicyProperty.md (#13217)
* Lohith Chowdary Chilukuri (@Lochiluk), Update Set-AzApplicationGateway.md (#13150)
* Matthew Burleigh (@mburleigh)
  * Add links to PowerShell cmdlets referenced in the document (#13203)
  * Add links to PowerShell cmdlets referenced in the document (#13190)
  * Add links to PowerShell cmdlets referenced in the document (#13189)
  * add links to referenced cmdlets (#13137)
  * Add links to PowerShell cmdlets referenced in the document (#13204)
  * Add links to PowerShell cmdlets referenced in the document (#13205)


## 4.8.0 - October 2020
#### Az.Accounts
* Fixed DateTime parse issue in common libraries [#13045]

#### Az.CognitiveServices
* Added 'New-AzCognitiveServicesAccountApiProperty' cmdlet.
* Supported 'ApiProperty' parameter for 'New-AzCognitiveServicesAccount' and 'Set-AzCognitiveServicesAccount'

#### Az.Compute
* Fixed issue in 'Update-ASRRecoveryPlan' by populating FailoverTypes
* Added the '-Top' and '-OrderBy' optional parameters to the 'Get-AzVmImage' cmdlet.

#### Az.Databricks
* General availability of 'Az.Databricks' module
* Added support for virtual network peering

#### Az.DataFactory
* Fixed typo in output messages

#### Az.EventHub
* Added optional switch parameter 'TrustedServiceAccessEnabled' to 'Set-AzEventHubNetworkRuleSet' cmdlet

#### Az.HDInsight
* Added warning message for planning to deprecate the parameters 'PublicNetworkAccessType' and 'OutboundPublicNetworkAccessType'
* Added warning message for planning to replace the parameter 'DefaultStorageAccountName' with 'StorageAccountResourceId'
* Added warning message for planning to replace the parameter 'DefaultStorageAccountKey' with 'StorageAccountKey'
* Added warning message for planning to replace the parameter 'DefaultStorageAccountType' with 'StorageAccountType'
* Added warning message for planning to replace the parameter 'DefaultStorageContainer' with 'StorageContainer'
* Added warning message for planning to replace the parameter 'DefaultStorageRootPath' with 'StorageRootPath'

#### Az.IotHub
* Updated devices sdk.

#### Az.KeyVault
* Provided the detailed date of removing property SecretValueText

#### Az.ManagedServices
* Updated breaking change warnings on cmdlets of managed services assignment and definition

#### Az.Monitor
* Fixed the bug that warning message cannot be suppressed. [#12889]
* Supported 'SkipMetricValidation' parameter in alert rule criteria. Allows creating an alert rule on a custom metric that isn't yet emitted, by causing the metric validation to be skipped.

#### Az.Network
* Added Office365 Policy to VPNSite Resource
    - 'New-AzO365PolicyProperty'

#### Az.RecoveryServices
* Added container name validation for workload backup.

#### Az.RedisCache
* Made 'New-AzRedisCache' and 'Set-AzRedisCache' cmdlets not fail because of permission issue related to registering Microsoft.Cache RP

#### Az.Sql
* Added BackupStorageRedundancy to the following:
    - 'Restore-AzureRmSqlDatabase'
    - 'New-AzSqlDatabaseCopy'
    - 'New-AzSqlDatabaseSecondary'
* Removed case sensitivity for BackupStorageRedundancy parameter for all SQL DB references
* Updated BackupStorageRedundancy warning message names

#### Az.Storage
* Supported enable/disable/get share soft delete properties on file Service of a Storage account
    - 'Update-AzStorageFileServiceProperty'
    - 'Get-AzStorageFileServiceProperty'
* Supported list file shares include the deleted ones of a Storage account, and Get single file share usage
    - 'Get-AzRmStorageShare'
* Supported restore a deleted file share
    - 'Restore-AzRmStorageShare'
* Changed the cmdlets for modify blob service properties, won't get the original properties from server, but only set the modified properties to server.
    - 'Enable-AzStorageBlobDeleteRetentionPolicy'
    - 'Disable-AzStorageBlobDeleteRetentionPolicy'
    - 'Enable-AzStorageBlobRestorePolicy'
    - 'Disable-AzStorageBlobRestorePolicy'
    - 'Update-AzStorageBlobServiceProperty'
* Fixed help issue for New-AzStorageAccount parameter -Kind default value [#12189]
* Fixed issue by add example to show how to set correct ContentType in blob upload [#12989]

### Thanks to our community contributors
* @felickz, Clarify escaping special characters in Subject (#13028)
* Martin Zurita (@Gorgoras), Corrected some typos in messages. (#12999)
* @kingsleyAzure
  * Add managed hsm uri in regex matching (#12912)
  * Add Managed HSM support for SQL (#13073)
* @MasterKuat, Fixed complaint on Managed instance's system database for vulnerability assessment (#12971)


## 4.7.0 - September 2020
#### Az.Accounts
* Formatted the upcoming breaking change messages
* Updated Azure.Core to 1.4.1

#### Az.Aks
* Added client side parameter validation logic for 'New-AzAksCluster', 'Set-AzAksCluster' and 'New-AzAksNodePool'. [#12372]
* Added support for add-ons in 'New-AzAksCluster'. [#11239]
* Added cmdlets 'Enable-AzAksAddOn' and 'Disable-AzAksAddOn' for add-ons. [#11239]
* Added parameter 'GenerateSshKey' for 'New-AzAksCluster'. [#12371]
* Updated api version to 2020-06-01.

#### Az.CognitiveServices
* Showed additional legal terms for certain APIs.

#### Az.Compute
* Added the '-EncryptionType' optional parameter to 'New-AzVmDiskEncryptionSetConfig'
* New cmdlets for new resource type: DiskAccess 'Get-AzDiskAccess', 'New-AzDiskAccess', 'Get-AzDiskAccess'
* Added optional parameters '-DiskAccessId' and '-NetworkAccessPolicy' to 'New-AzSnapshotConfig'
* Added optional parameters '-DiskAccessId' and '-NetworkAccessPolicy' to 'New-AzDiskConfig'
* Added 'PatchStatus' property to VirtualMachine Instance View
* Added 'VMHealth' property to the virtual machine's instance view, which is the returned object when 'Get-AzVm' is invoked with '-Status'
* Added 'AssignedHost' field to 'Get-AzVM' and 'Get-AzVmss' instance views. The field shows the resource id of the virtual machine instance
* Added optional parameter '-SupportAutomaticPlacement' to 'New-AzHostGroup'
* Added the '-HostGroupId' parameter to 'New-AzVm' and 'New-AzVmss'

#### Az.DataFactory
* Updated ADF .Net SDK version to 4.11.0

#### Az.EventHub
* Added new Cluster cmdlets - 'New-AzEventHubCluster', 'Set-AzEventHubCluster', 'Get-AzEventHubCluster', 'Remove-AzEventHubCluster', 'Get-AzEventHubClustersAvailableRegions'.
* Fixed for issue #10722 : Fix for assigning only 'Listen' to AuthorizationRule rights.

#### Az.Functions
* Removed the ability to create v2 Functions in regions that do not support it.
* Deprecated PowerShell 6.2. Added a warning for when a user creates a PowerShell 6.2 function app that advises them to create a PowerShell 7.0 function app instead.

#### Az.HDInsight
* Supported creating cluster with Autoscale configuration
    - Add new parameter 'AutoscaleConfiguration' to the cmdlet 'New-AzHDInsightCluster'
* Supported operating cluster's Autoscale configuration
    - Add new cmdlet 'Get-AzHDInsihgtClusterAutoscaleConfiguration'
    - Add new cmdlet 'New-AzHDInsihgtClusterAutoscaleConfiguration'
    - Add new cmdlet 'Set-AzHDInsihgtClusterAutoscaleConfiguration'
    - Add new cmdlet 'Remove-AzHDInsihgtClusterAutoscaleConfiguration'
    - Add new cmdlet 'New-AzHDInsihgtClusterAutoscaleScheduleCondition'

#### Az.KeyVault
* Added support for RBAC authorization [#10557]
* Enhanced error handling in 'Set-AzKeyVaultAccessPolicy' [#4007]

#### Az.Kusto
* General availability of 'Az.Kusto' module

#### Az.Network
* [Breaking Change] Updated below cmdlets to align resource virtual router and virtual hub
    - 'New-AzVirtualRouter':
        - Added -HostedSubnet parameter to support IP configuration child resource
        - deleted -HostedGateway and -HostedGatewayId
    - 'Get-AzVirtualRouter':
        - Added subscription level parameter set
    - 'Remove-AzVirtualRouter'
    - 'Add-AzVirtualRouterPeer'
    - 'Get-AzVirtualRouterPeer'
    - 'Remove-AzVirtualRouterPeer'
* Added new cmdlet for Azure Express Route Port
    - 'New-AzExpressRoutePortLOA'
* Added RemoteBgpCommunities property to the VirtualNetwork Peering Resource
* Modified the warning message for 'New-AzLoadBalancerFrontendIpConfig', 'New-AzPublicIpAddress' and 'New-AzPublicIpPrefix'.
* Added VpnGatewayIpConfigurations to 'Get-AzVpnGateway' output
* Fixed bug for 'Set-AzApplicationGatewaySslCertificate' [#9488]
* Added 'AllowActiveFTP' parameter to 'AzureFirewall'
* Updated below commands for feature: Enable internet security set/remove on VirtualWan P2SVpnGateway.
- Updated 'New-AzP2sVpnGateway': Added optional switch parameter 'EnableInternetSecurityFlag' for customers to set true to enable internet security on P2SVpnGateway, which will be applied for Point to site clients.
- Updated 'Update-AzP2sVpnGateway': Added optional switch parameters 'EnableInternetSecurityFlag' or 'DisableInternetSecurityFlag' for customers to set true/false to enable/disable internet security on P2SVpnGateway, which will be applied for Point to site clients.
* Added new cmdlet 'Reset-AzP2sVpnGateway' for customers to reset/reboot their VirtualWan P2SVpnGateway for troubleshooting.
* Added new cmdlet 'Reset-AzVpnGateway' for customers to reset/reboot their VirtualWan VpnGateway for troubleshooting.
* Updated 'Set-AzVirtualNetworkSubnetConfig'
    - Set NSG and Route Table properties of subnet to null if explicitly set in parameters [#1548][#9718]

#### Az.RecoveryServices
* Fixed the Delete State for workload Backup Items.

#### Az.Resources
* Added missing check for Set-AzRoleAssignment
* Added breaking change attribute to 'SubscriptionId' parameter of 'Get-AzResourceGroupDeploymentOperation'
* Updated ARM template What-If cmdlets to show 'Ignore' resource changes last
* Fixed secure and array parameter serialization issues for deployment cmdlets [#12773]

#### Az.ServiceFabric
* Added new cmdlets for managed clusters and node types:
    - 'New-AzServiceFabricManagedCluster'
    - 'Get-AzServiceFabricManagedCluster'
    - 'Set-AzServiceFabricManagedCluster'
    - 'Remove-AzServiceFabricManagedCluster'
    - 'Add-AzServiceFabricManagedClusterClientCertificate'
    - 'Remove-AzServiceFabricManagedClusterClientCertificate'
    - 'New-AzServiceFabricManagedNodeType'
    - 'Get-AzServiceFabricManagedNodeType'
    - 'Set-AzServiceFabricManagedNodeType'
    - 'Remove-AzServiceFabricManagedNodeType'
    - 'Add-AzServiceFabricManagedNodeTypeVMExtension'
    - 'Add-AzServiceFabricManagedNodeTypeVMSecret'
    - 'Remove-AzServiceFabricManagedNodeTypeVMExtension'
    - 'Restart-AzServiceFabricManagedNodeTyp'
* Upgraded Service Fabric SDK to version 1.2.0 which uses service fabric resource provider api-version 2020-03-01 for the current model and 2020-01-01-preview for managed clusters.

#### Az.Sql
* Added BackupStorageRedundancy to 'New-AzSqlInstance' and 'Get-AzSqlInstance'
* Added cmdlet 'Get-AzSqlServerActiveDirectoryOnlyAuthentication'
* Added cmdlet 'Enable-AzSqlServerActiveDirectoryOnlyAuthentication'
* Added Force parameter to 'New-AzSqlInstance'
* Added cmdlets for Managed Database Log Replay service
	- 'Start-AzSqlInstanceDatabaseLogReplay'
	- 'Get-AzSqlInstanceDatabaseLogReplay'
	- 'Complete-AzSqlInstanceDatabaseLogReplay'
	- 'Stop-AzSqlInstanceDatabaseLogReplay'
* Added cmdlet 'Get-AzSqlInstanceActiveDirectoryOnlyAuthentication'
* Added cmdlet 'Enable-AzSqlInstanceActiveDirectoryOnlyAuthentication'
* Added cmdlet 'Disable-AzSqlInstanceActiveDirectoryOnlyAuthentication'
* Updated cmdlets 'New-AzSqlDatabaseImport' and 'New-AzSqlDatabaseExport' to support network isolation functionality
* Added cmdlet 'New-AzSqlDatabaseImportExisting'
* Updated Databases cmdlets to support backup storage type specification
* Added Force parameter to 'New-AzSqlDatabase'
* Added warning for BackupStorageRedundancy configuration in select regions in 'New-AzSqlDatabase'
* Updated ActiveDirectoryOnlyAuthentication cmdlets for server and instance to include ResourceId and InputObject

#### Az.Storage
* Fixed upload blob fail by upgrade to Microsoft.Azure.Storage.DataMovement 2.0.0 [#12220]
* Supported Point In Time Restore
    - 'Enable-AzStorageBlobRestorePolicy'
    - 'Disable-AzStorageBlobRestorePolicy'
    - 'New-AzStorageBlobRangeToRestore'
    - 'Restore-AzStorageBlobRange'
* Supported get blob restore status of Storage account by run get-AzureRMStorageAccount with parameter -IncludeBlobRestoreStatus
    - 'Get-AzureRMStorageAccount'
* Added breaking change warning message for upcoming cmdlet output change
    - 'Get-AzStorageContainerStoredAccessPolicy'
    - 'Set-AzStorageContainerStoredAccessPolicy'
    - 'Set-AzStorageAccountManagementPolicy'
    - 'Get-AzStorageAccountManagementPolicy'
    - 'Add-AzStorageAccountManagementPolicyAction'
    - 'New-AzStorageAccountManagementPolicyRule'
* Upgraded Microsoft.Azure.Cosmos.Table SDK to 1.0.8

### Thanks to our community contributors
* Thomas Van Laere (@ThomVanL), Add Dockerfile-alpine-3.10 (#12911)
* Lohith Chowdary Chilukuri (@Lochiluk), Update Remove-AzNetworkInterfaceIpConfig.md (#12807)
* Roberth Strand (@roberthstrand), Get-AzResourceGroup - New example, and cleanup (#12828)
* Ravi Mishra (@inmishrar), update Azure Web App runtime stack to DOTNETCORE (#12833)
* @jack-education, Updated Set-AzVirtualNetworkSubnetConfig to allow NSG and Route Table to be removed from subnet (#12351)
* @hagop-globanet, Update Add-AzApplicationGatewayCustomError.md (#12784)
* Joshua Van Daalen (@greenSacrifice)
  * Update spelling of Property to Property (#12821)
  * Update New-AzResourceLock.md examples (#12806)
* Eragon Riddle (@eragonriddle), Corrected parameter field name in the example (#12825)
* @rossifumax, Fix typo in New-AzConfigurationAssignment.md (#12701)


## 4.6.1 - August 2020
#### Az.Compute
* Patched '-EncryptionAtHost' parameter in 'New-AzVm' to remove default value of false [#12776]

## 4.6.0 - August 2020
#### Az.Accounts
* Loaded all public cloud environments when discovery endpoint doesn't return default AzureCloud or other public environments [#12633]
* Exposed SubscriptionPolicies in 'Get-AzSubscription' [#12551]

#### Az.Automation
* Added '-RunOn' parameters to 'Set-AzAutomationWebhook' to specify a Hybrid Worker Group

#### Az.Compute
* Added '-EncryptionAtHost' parameter to 'New-AzVm', 'New-AzVmss', 'New-AzVMConfig', 'New-AzVmssConfig', 'Update-AzVM', and 'Update-AzVmss'
* Added 'SecurityProfile' to 'Get-AzVM' and 'Get-AzVmss' return object
* Added '-InstanceView' switch as optional parameter to 'Get-AzHostGroup'
* Added new cmdlet 'Invoke-AzVmPatchAssessment'

#### Az.DataFactory
* Added missing properties to PSPipelineRun class.

#### Az.HDInsight
* Supported creating cluster with encryption at host feature.

#### Az.KeyVault
* Added warning messages for planning to disable soft delete
* Added warning messages for planning to remove attribute SecretValueText

#### Az.Maintenance
* Added optional schedule related fields to 'New-AzMaintenanceConfiguration'
* Added new cmdlet for 'Get-AzMaintenancePublicConfiguration'

#### Az.ManagedServices
* Added breaking change warnings on cmdlets of managed services assignment and definition

#### Az.Monitor
* Extended the parameter set in 'Set-AzDiagnosticSetting' for separation of Logs and Metrics enablement [#12482]
* Fixed bug for 'Add-AzMetricAlertRuleV2' when getting metric alert from pipeline

#### Az.Resources
* Updated 'Get-AzPolicyAlias' response to include information indicating whether the alias is modifiable by Azure Policy.
* Created new cmdlet 'Set-AzRoleAssignment'
* Added 'Get-AzDeploymentManagementGroupWhatIfResult' for getting ARM template What-If results at management Group scope
* Added 'Get-AzTenantWhatIfResult' new cmdlet for getting ARM template What-If results at tenant scope
* Overrode '-WhatIf' and '-Confirm' for 'New-AzManagementGroupDeployment' and 'New-AzTenantDeployment' to use ARM template What-If results
* Fixed the behaviors of '-WhatIf' and '-Confirm' for new deployment cmdlets so they comply with False and
* Fixed serialization error for '-TemplateObject' and 'TemplateParameterObject' [#1528] [#6292]
* Added breaking change attribute to 'Get-AzResourceGroupDeploymentOperation' for the upcoming output type change

#### Az.SignalR
* Fixed 'Restart-AzSignalR' and 'Update-AzSignalR' help files errors
* Added cmdlets 'Update-AzSignalRNetworkAcl', 'Set-AzSignalRUpstream'

#### Az.Storage
* Supported blob query acceleration
    -  'Get-AzStorageBlobQueryResult'
    -  'New-AzStorageBlobQueryConfig'
* Updated help file, added more description, and fixed typo
    -  'Start-AzStorageBlobCopy'
    -  'Get-AzDataLakeGen2Item'
* Fixed download blob fail when related sub directory not exist [#12592]
    -  'Get-AzStorageBlobContent'
* Supported Set/Get/Remove Object Replication Policy on Storage accounts
    - 'New-AzStorageObjectReplicationPolicyRule'
    - 'Set-AzStorageObjectReplicationPolicy'
    - 'Get-AzStorageObjectReplicationPolicy'
    - 'Remove-AzStorageObjectReplicationPolicy'
* Supported enable/disable ChangeFeed on Blob Service of a Storage account
    - 'Update-AzStorageBlobServiceProperty'

## 4.5.0 - August 2020
#### Az.Accounts
* Updated 'Connect-AzAccount' to accept parameter 'MaxContextPopulation' [#9865]
* Updated SubscriptionClient version to 2019-06-01 and display tenant domains [#9838]
* Supported home tenant and managedBy tenant information of subscription
* Corrected module name, version info in telemetry data
* Adjusted SqlDatabaseDnsSuffix and ServiceManagementUrl if environment metadata endpoint returns incompatible value

#### Az.Aks
* Removed 'ClientIdAndSecret' to 'ServicePrincipalIdAndSecret' and set 'ClientIdAndSecret' as an alias [#12381].
* Removed 'Get-AzAks'/'New-AzAks'/'Remove-AzAks'/'Set-AzAks' to 'Get-AzAksCluster'/'New-AzAksCluster'/'Remove-AzAksCluster'/'Set-AzAksCluster' and set the original ones as alias [#12373].

#### Az.ApiManagement
* Added new 'Add-AzApiManagementApiToGateway' cmdlet.
* Added new 'Get-AzApiManagementGateway' cmdlet.
* Added new 'Get-AzApiManagementGatewayHostnameConfiguration' cmdlet.
* Added new 'Get-AzApiManagementGatewayKey' cmdlet.
* Added new 'New-AzApiManagementGateway' cmdlet.
* Added new 'New-AzApiManagementGatewayHostnameConfiguration' cmdlet.
* Added new 'New-AzApiManagementResourceLocationObject' cmdlet.
* Added new 'Remove-AzApiManagementApiFromGateway' cmdlet.
* Added new 'Remove-AzApiManagementGateway' cmdlet.
* Added new 'Remove-AzApiManagementGatewayHostnameConfiguration' cmdlet.
* Added new 'Update-AzApiManagementGateway' cmdlet.
* Added new optional [-GatewayId] parameter to the 'Get-AzApiManagementApi' cmdlet.

#### Az.CognitiveServices
* Used 'Deny' specifically as NetworkRules default action.

#### Az.FrontDoor
* Fixed an issue where an exception is being thrown when Enum.Parse tries to coerce a null value to an Enabled or Disabled enum values [#12344]

#### Az.HDInsight
* Supported creating cluster with encryption in transit feature.
    - Add new parameter 'EncryptionInTransit' to the cmdlet 'New-AzHDInsightCluster'
	- Add new parameter 'EncryptionInTransit' to the cmdlet 'New-AzHDInsightClusterConfig'
* Supported creating cluster with private link feature:
    - Add new parameter 'PublicNetworkAccessType' and 'OutboundPublicNetworkAccessType' to the cmdlet 'New-AzHDInsightCluster'
    - Add new parameter 'PublicNetworkAccessType' and 'OutboundPublicNetworkAccessType' to the cmdlet 'New-AzHDInsightClusterConfig'
* Returned virtual network information when calling 'New-AzHDInsightCluster' or 'Get-AzHDInsightCluster'

#### Az.Network
* Added support for AddressPrefixType parameter to 'Remove-AzExpressRouteCircuitConnectionConfig'
* Added non-breaking changes: PeerAddressType functionality for Private Peering in 'Remove-AzExpressRouteCircutPeeringConfig'.
* Code changed to ignore case for AddressPrefixType and PeerAddressType parameter.
* Modified the warning message for 'New-AzLoadBalancerFrontendIpConfig', 'New-AzPublicIpAddress' and 'New-AzPublicIpPrefix'.

#### Az.OperationalInsights
* Added '-ForceDelete' option for 'Remove-AzOperationalInsightsworkspace'
* Added new cmdlet 'Get-AzOperationalInsightsDeletedWorkspace'
* Added new cmdlet 'Restore-AzOperationalInsightsWorkspace'

#### Az.RecoveryServices
* Improved the Azure Backup container/item discovery experience.

#### Az.Resources
* Added properties 'Condition', 'ConditionVersion' and 'Description' to 'New-AzRoleAssignment'
    - This included all the relevant changes to the data models

#### Az.Sql
* Fixed potential server name case insensitive error in 'New-AzSqlServer' and 'Set-AzSqlServer'
* Fixed wrong database name returned on existing database error in 'New-AzSqlDatabaseSecondary'

#### Az.Storage
* Supported create container/blob Sas token with new permission x,t
    -  'New-AzStorageBlobSASToken'
    -  'New-AzStorageContainerSASToken'
* Supported create account Sas token with new permission x,t,f
    -  'New-AzStorageAccountSASToken'
* Supported get single file share usage
    - 'Get-AzRmStorageShare'

## 4.4.0 - July 2020
#### Az.Accounts
* Added new cmdlet 'Invoke-AzRestMethod'
* Fixed an issue that may cause authentication errors in multi-process scenarios such as running multiple Azure PowerShell cmdlets using 'Start-Job' [#9448]

#### Az.Aks
* Fixed bug 'Get-AzAks' doesn't get all clusters [#12296]

#### Az.AnalysisServices
* Removed project reference to Authentication

#### Az.Automation
* Fixed the issue that string with escape chars cannot be converted into json object.

#### Az.Compute
* Added warning when using 'New-AzVmss' without 'latest' image version

#### Az.DataFactory
* Added global parameters to Data Factory.

#### Az.EventGrid
* Updated to use the 2020-06-01 API version.
* Added new features:
    - Input mapping
    - Event Delivery Schema
    - Private Link
    - Cloud Event V10 Schema
    - Service Bus Topic As Destination
    - Azure Function As Destination
    - WebHook Batching
    - Secure webhook (AAD support)
    - IpFiltering
* Updated cmdlets:
    - 'New-AzEventGridSubscription'/'Update-AzEventGridSubscription':
        - Add new optional parameters to support webhook batching.
        - Add new optional parameters to support secured webhook using AAD.
        - Add new enum for EndpointType parameter to support azure function and service bus topic as new destinations.
        - Add new optional parameter for delivery schema.
    - 'New-AzEventGridTopic'/'Update-AzEventGridTopic' and 'New-AzEventGridDomain'/'Update-AzEventGridDomain':
        - Add new optional parameters to support IpFiltering.
    - 'New-AzEventGridTopic'/'New-AzEventGridDomain':
        - Add new optional parameters to support Input mapping.

#### Az.FrontDoor
* Updated module to use API 2020-05-01
* Added Private link support for Storage, Keyvault and Web App Service resources

#### Az.HDInsight
* Supported creating cluster with ADLSGen1/2 storage in national clouds.

#### Az.Monitor
* Fixed bug for 'Get-AzDiagnosticSetting' when metrics or logs are null [#12272]

#### Az.Network
* Fixed parameters swap in VWan HubVnet connection
* Added new cmdlets for Azure Network Virtual Appliance Sites
    - 'Get-AzVirtualApplianceSite'
    - 'New-AzVirtualApplianceSite'
    - 'Remove-AzVirtualApplianceSite'
    - 'Update-AzVirtualApplianceSite'
    - 'New-AzOffice365PolicyProperty'
* Added new cmdlets for Azure Network Virtual Appliance
    - 'Get-AzNetworkVirtualAppliance'
    - 'New-AzNetworkVirtualAppliance'
    - 'Remove-AzNetworkVirtualAppliance'
    - 'Update-AzNetworkVirtualAppliance'
    - 'Get-AzNetworkVirtualApplianceSku'
    - 'New-AzVirtualApplianceSkuProperty'
* Onboarded Application Gateway to Private Link Common Cmdlets
* Onboarded StorageSync to Private Link Common Cmdlets
* Onboarded SignalR to Private Link Common Cmdlets

#### Az.RecoveryServices
* Removed project reference to Authentication
* Azure Backup tuned cmdlets help text to be more accurate.
* Azure Backup added support for fetching MAB agent jobs using 'Get-AzRecoveryServicesBackupJob' cmdlet.

#### Az.Resources
* Updated 'Save-AzResourceGroupDeploymentTemplate' to use the SDK.
* Added 'Unregister-AzResourceProvider' cmdlet.

#### Az.Sql
* Added support for Service principal and guest users in Set-AzSqlInstanceActiveDirectoryAdministrator cmdlet'
* Fixed a bug in Data Classification cmdlets.'
* Added support for Azure SQL Managed Instance failover: 'Invoke-AzSqlInstanceFailover'

#### Az.Storage
* Fixed the issue that UserAgent is not added for some data plane cmdlets.
* Supported create/update Storage account with MinimumTlsVersion and AllowBlobPublicAccess
    -  'New-AzStorageAccount'
    -  'Set-AzStorageAccount'
* Support enable/disable versioning on Blob Service of a Storage account
    - 'Update-AzStorageBlobServiceProperty'
* Support list blobs with blob versions
    - 'Get-AzStorageBlob'
* Support get/remove single blob snapshot or blob version
    - 'Get-AzStorageBlob'
    - 'Remove-AzStorageBlob'
* Support pipeline from blob object generated from Azure.Storage.Blobs V12
    - 'Get-AzStorageBlobContent'
    - 'New-AzStorageBlobSASToken'
    - 'Remove-AzStorageBlob'
    - 'Set-AzStorageBlobContent'
    - 'Start-AzStorageBlobCopy'

#### Az.StorageSync
* Added a new version StorageSync SDK targeting ApiVersion 2020-03-01
* Added Update Storage Sync Service cmdlet
    - 'Set-AzStorageSyncService'
* Added IncomingTrafficPolicy and PrivateEndpointConnections to StorageSyncService cmdlets.

#### Az.Websites
* Added support to perform operations for Slots not in the same resource group as the App Service Plan

## 4.3.0 - June 2020
#### Az.Accounts
* Supported discovering environment setting by default and adding environment via 'Add-AzEnvironment'
* Update preloaded assemblies [#12024], [#11976]
* Updated Azure.Core assembly
* Fixed an issue that may cause 'Connect-AzAccount' to fail in multi-threaded execution [#11201]

#### Az.Aks
* Replaced usage of old [AccessProfile API](https://docs.microsoft.com/rest/api/aks/managedclusters/getaccessprofile) with calls to [ListClusterAdmin](https://docs.microsoft.com/rest/api/aks/managedclusters/listclusteradmincredentials) and [ListClusterUser](https://docs.microsoft.com/rest/api/aks/managedclusters/listclusterusercredentials) APIs

#### Az.Batch
* Updated Az.Batch to use 'Microsoft.Azure.Management.Batch' SDK version to 11.0.0
* Added the ability to set the BatchAccount Identity in the 'New-AzBatchAccount' cmdlet

#### Az.CognitiveServices
* Supported displaying account capabilities.
* Supported modifying PublicNetworkAccess.

#### Az.Compute
* Added SimulateEviction parameter to Set-AzVM and Set-AzVmssVM cmdlets.
* Added 'Premium_LRS' to the argument completer of StorageAccountType parameter for New-AzGalleryImageVersion cmdlet.
* Added Substatuses to VMCustomScriptExtension [#11297]
* Added 'Delete' to the argument completer of EvictionPolicy parameter for New-AzVM and New-AzVMConfig cmdlets.
* Fixed name of new VM Extension for SAP

#### Az.DataFactory
* Updated ADF .Net SDK version to 4.9.0

#### Az.EventHub
* Added Managed Identity parameters to 'New-AzEventHubNamespace' and 'Set-AzEventHubNamespace' cmdlets

#### Az.Functions
* Added support to create PowerShell 7.0 and Java 11 function apps

#### Az.HDInsight
* Supported listing hosts and restart specific hosts of the HDInsight cluster.

#### Az.HealthcareApis
* Updated the SDK version to 1.1.0
* Added support for Export settings and Managed Identity

#### Az.Monitor
* Fixed input object parameter for 'Set-AzActivityLogAlert'
* Fixed 'InputObject' parameter for 'Set-AzActionGroup' [#10868]

#### Az.Network
* Added support for AddressPrefixType parameter to 'Remove-AzExpressRouteCircuitConnectionConfig'
* Added new cmdlets for Azure FirewallPolicy
    - 'New-AzFirewallPolicyDnsSetting'
    - Support for Destination FQDN in Network Rules for Firewall Policy
* Added support for backend address pool operations
    - 'New-AzLoadBalancerBackendAddressConfig'
    - 'New-AzLoadBalancerBackendAddressPool'
    - 'Set-AzLoadBalancerBackendAddressPool'
    - 'Remove-AzLoadBalancerBackendAddressPool'
    - 'Get-AzLoadBalancerBackendAddressPool'
* Added name validation for 'New-AzIpGroup'
* Added new cmdlets for Azure FirewallPolicy
    - 'New-AzFirewallPolicyThreatIntelWhitelist'
* Updated below commands for feature: Custom dns servers set/remove on VirtualWan P2SVpnGateway.
    - Updated New-AzP2sVpnGateway: Added optional parameter '-CustomDnsServer' for customers to specify their dns servers to set on P2SVpnGateway, which can be used by Point to site clients.
    - Updated Update-AzP2sVpnGateway: Added optional parameter '-CustomDnsServer' for customers to specify their dns servers to set on P2SVpnGateway, which can be used by Point to site clients.
* Updated 'Update-AzVpnGateway'
    - Added optional parameter '-BgpPeeringAddress' for customers to specify their custom bgps to set on VpnGateway.
* Added new cmdlet to support resetting the routing state of a VirtualHub resource:
    - 'Reset-AzHubRouter'
* Updated below things based on recent swagger change for Firewall Policy
    - Changes names for RuleGroup, RuleCollectionGroup and RuleType
    - Added support for Firewall Policy NAT Rule Collections to support multiple NAT Rule Collection
* [Breaking Change] Added mandatory parameter 'SourceIpGroup' for 'New-AzFirewallPolicyApplicationRule' and 'New-AzFirewallPolicyNetworkRule'.
* [Breaking Change] Fixed 'New-AzFirewallPolicyApplicationRule', parameter 'SourceAddress' to be mandatory.
* [Breaking Change] Fixed 'New-AzFirewallPolicyApplicationRule', parameter 'SourceAddress' to be mandatory.
* [Breaking Change] Removed mandatory parameters: 'TranslatedAddress', 'TranslatedPort' for 'New-AzFirewallPolicyNatRuleCollection'.
* Added new cmdlets to support PrivateLink On Application Gateway
    - 'New-AzApplicationGatewayPrivateLinkConfiguration'
    - 'Get-AzApplicationGatewayPrivateLinkConfiguration'
    - 'New-AzApplicationGatewayPrivateLinkConfiguration'
    - 'Set-AzApplicationGatewayPrivateLinkConfiguration'
    - 'Remove-AzApplicationGatewayPrivateLinkConfiguration'
    - 'New-AzApplicationGatewayPrivateLinkIpConfiguration'
* Added new cmdlets for HubRouteTables child resource of VirtualHub.
    - 'New-AzVHubRoute'
    - 'New-AzVHubRouteTable'
    - 'Get-AzVHubRouteTable'
    - 'Update-AzVHubRouteTable'
    - 'Remove-AzVHubRouteTable'
* Updated existing cmdlets to support optional RoutingConfiguration input parameter for custom routing in VirtualWan.
    - 'New-AzExpressRouteConnection'
    - 'Set-AzExpressRouteConnection'
    - 'New-AzVirtualHubVnetConnection'
    - 'Update-AzVirtualHubVnetConnection'
    - 'New-AzVpnConnection'
    - 'Update-AzVpnConnection'
    - 'New-AzP2sVpnGateway'
    - 'Update-AzP2sVpnGateway'

#### Az.OperationalInsights
* Fixed bug PSWorkspace doesn't implement IOperationalInsightsWorkspace [#12135]
* Added 'pergb2018' to valid value set of parameter 'Sku' in 'Set-AzOperationalInsightsWorkspace'
* Added alias 'FunctionParameters' for parameter 'FunctionParameter' to
    - 'New-AzOperationalInsightsSavedSearch'
    - 'Set-AzOperationalInsightsSavedSearch'

#### Az.RecoveryServices
* Azure Backup added support for fetching MAB items.
* Azure Site Recovery supports disk type 'StandardSSD_LRS'

#### Az.Resources
* Added 'UsageLocation', 'GivenName', 'Surname', 'AccountEnabled', 'MailNickname', 'Mail' on 'PSADUser' [#10526] [#10497]
* Fixed issue that '-Mail' doesn't work on 'Get-AzADUser' [#11981]
* Added '-ExcludeChangeType' parameter to 'Get-AzDeploymentWhatIfResult' and 'Get-AzResourceGroupDeploymentWhatIfResult'
* Added '-WhatIfExcludeChangeType' parameter to 'New-AzDeployment' and 'New-AzResourceGroupDeployment'
* Updated 'Test-Az*Deployment' cmdlets to show better error messages
* Fixed help message for '-Name' parameter of deployment create and What-If cmdlets

#### Az.Sql
* Added support for service principal for Set SQL Server Azure Active Directory Admin cmdlet
* Fixed sync issue in Data Classification cmdlets.
* Supported searching user by mail on 'Set-AzSqlServerActiveDirectoryAdministrator' [#12192]

#### Az.Storage
* Supported create Storage account with RequireInfrastructureEncryption
    -  'New-AzStorageAccount'
* Moved the logic of loading Azure.Core to Az.Accounts

#### Az.Websites
* Added safeguard to delete created webapp if restore failed in 'Restore-AzDeletedWebApp'
* Added 'SourceWebApp.Location' for 'New-AzWebApp' and 'New-AzWebAppSlot'
* Fixed bug that prevented changing Container settings in 'Set-AzWebApp' and 'Set-AzWebAppSlot'
* Fixed bug to get SiteConfig when -Name is not given for Get-AzWebApp
* Added a support to create ASP for Linux Apps
* Added exceptions for clone across resource groups

## 4.2.0 - June 2020
#### Az.Accounts
* Fixed an issue that may cause Az to skip logs in Azure Automation or PowerShell jobs [#11492]

#### Az.AnalysisServices
* Updated assembly version of data plane cmdlets

#### Az.ApiManagement
* Updated assembly version of service management cmdlets

#### Az.Billing
* Updated assembly version of consumption cmdlets

#### Az.CognitiveServices
* Support PrivateEndpoint and PublicNetworkAccess control.

#### Az.DataFactory
* Updated assembly version of data factory V2 cmdlets

#### Az.DataShare
* General availability of ''Az.DataShare'' module

#### Az.DesktopVirtualization
* General availability of ''Az.DesktopVirtualization'' module

#### Az.OperationalInsights
* Upgraded SDK to 0.21.0
* Added optional parameters to
    - 'New-AzOperationalInsightsSavedSearch'
    - 'Set-AzOperationalInsightsSavedSearch'

#### Az.PolicyInsights
* Corrected example 3 for 'Start-AzPolicyComplianceScan'

#### Az.PowerBIEmbedded
* Updated assembly version of PowerBI cmdlets

#### Az.PrivateDns
* Corrected verbose output string formatting for Remove-AzPrivateDnsRecordSet

#### Az.RecoveryServices
* Azure Site Recovery support for creating recovery plan for zone to zone replication from xml input.
* Updated assembly version of SiteRecovery and Backup cmdlets

#### Az.Resources
* Added Tail parameter to Get-AzDeploymentScriptLog and Save-AzDeploymentScriptLog cmdlets
* Formatted Output property and show it on the Get-AzDeploymentScript cmdlet output
* Renamed -DeploymentScriptInputObject parameter to -DeploymentScriptObject
* Fixed missing file/target name in cmdlet messages.
* Updated assembly version of resource manager and tags cmdlets

#### Az.Sql
* Added UsePrivateLinkConnection to 'New-AzSqlSyncGroup', 'Update-AzSqlSyncGroup', 'New-AzSqlSyncMember' and 'Update-AzSqlSyncMember'
* Added SyncMemberAzureDatabaseResourceId to 'New-AzSqlSyncMember' and 'Update-AzSqlSyncMember'
* Added Guest user lookup support to Set SQL Server Azure Active Directory Admin cmdlet

#### Az.Storage
* Updated assembly version of data plane cmdlets

## 4.1.0 - May 2020
### Highlights since the last release
* Supported PowerShell versions: Windows PowerShell 5.1, PowerShell Core 6.2.4+, PowerShell 7
* General availability of Az.Functions
* Az.ApiManagement, Az.Batch, Az.Compute, Az.KeyVault, Az.Monitor, Az.Network, Az.OperationalInsights, Az.Resources, and Az.Storage have major release

#### Az.Accounts
* Updated 'Add-AzEnvironment' and 'Set-AzEnvironment' to accept parameters 'AzureSynapseAnalyticsEndpointResourceId' and 'AzureSynapseAnalyticsEndpointSuffix'
* Added Azure.Core related assemblies into Az.Accounts, supported PowerShell platforms include Windows PowerShell 5.1, PowerShell Core 6.2.4, PowerShell 7+

#### Az.Aks
* Upgraded API Version to 2019-10-01
* Supported to create AKS using Windows container
* Provided new cmdlets: 'New-AzAksNodePool', 'Update-AzAksNodePool', 'Remove-AzAksNodePool',
         'Get-AzAksNodePool', 'Install-AzAksKubectl', 'Get-AzAksVersion'

#### Az.ApiManagement
* 'New-AzApiManagement' and 'Set-AzApiManagement': [-AssignIdentity] parameter renamed as [-SystemAssignedIdentity]
* 'New-AzApiManagement' and 'Set-AzApiManagement': New parameter added: [-UserAssignedIdentity <String[]>]
* 'Get-AzApiManagementProperty': renamed as 'Get-AzApiManagementNamedValue'. PropertyId parameter renamed as NamedValueId.
* 'New-AzApiManagementProperty': renamed as 'New-AzApiManagementNamedValue'. PropertyId parameter renamed as NamedValueId.
* 'Set-AzApiManagementProperty': renamed as 'Set-AzApiManagementNamedValue'. PropertyId parameter renamed as NamedValueId.
* 'Remove-AzApiManagementProperty': renamed as 'Remove-AzApiManagementNamedValue'. PropertyId parameter renamed as NamedValueId.
* Added new 'Get-AzApiManagementAuthorizationServerClientSecret' cmdlet and 'Get-AzApiManagementAuthorizationServer' will not return client secret anymore.
* Added new 'Get-AzApiManagementNamedValueSecretValue' cmdlet and 'Get-AzApiManagementNamedValue' will not return secret value.
* Added new 'Get-AzApiManagementOpenIdConnectProviderClientSecret' cmdlet and 'Get-AzApiManagementOpenIdConnectProvider' will not return client secret anymore.
* Added new 'Get-AzApiManagementSubscriptionKey' cmdlet and 'Get-AzApiManagementSubscription' will not return subscription keys anymore.
* Added new 'Get-AzApiManagementTenantAccessSecret' cmdlet and 'Get-AzApiManagementTenantAccess' will not return keys anymore.
* Added new 'Get-AzApiManagementTenantGitAccessSecret' cmdlet and 'Get-AzApiManagementTenantGitAccess' will not return keys anymore.

#### Az.ApplicationInsights
* Added Parameters: 'RetentionInDays' 'PublicNetworkAccessForIngestion' 'PublicNetworkAccessForQuery' for 'New-AzApplicationInsights'
* Created cmdlet 'Update-AzApplicationInsights'
* Created cmdlets for Linked Storage Account

#### Az.Batch
* Updated Az.Batch to use 'Microsoft.Azure.Batch' SDK version 13.0.0 and 'Microsoft.Azure.Management.Batch' SDK version 9.0.0.
* Added the ability to select the kind of certificate being added using the new '-CertificateKind' parameter to 'New-AzBatchCertificate'.
* Removed 'ApplicationPackages' property from 'PSApplication' which was previously always ''.
  - The specific packages inside of an application now can be retrieved using 'Get-AzBatchApplicationPackage'. For example: 'Get-AzBatchApplication -AccountName myaccount -ResourceGroupName myresourcegroup -ApplicationId myapplication'.
* When creating a pool using 'New-AzBatchPool', the 'VirtualMachineImageId' property of 'PSImageReference' can now only refer to a Shared Image Gallery image.
* When creating a pool using 'New-AzBatchPool', the pool can be provisioned without a public IP using the new 'PublicIPAddressConfiguration' property of 'PSNetworkConfiguration'.
  - The 'PublicIPs' property of 'PSNetworkConfiguration' has moved in to 'PSPublicIPAddressConfiguration' as well. This property can only be specified if 'IPAddressProvisioningType' is 'UserManaged'.

#### Az.Compute
* Added HostId parameter to 'Update-AzVM' cmdlet
* Updated Help documents for 'New-AzVMConfig', 'New-AzVmssConfig', 'Update-AzVmss', 'Set-AzVMOperatingSystem' and 'Set-AzVmssOsProfile' cmdlets.
* Breaking changes
    - FilterExpression parameter is removed from 'Get-AzVMImage' cmdlet.
    - AssignIdentity parameter is removed from 'New-AzVmssConfig', 'New-AzVMConfig' and 'Update-AzVM' cmdlets.
    - AutomaticRepairMaxInstanceRepairsPercent is removed from 'New-AzVmssConfig' and 'Update-AzVmss' cmdlets.
    - AvailabilitySetsColocationStatus, VirtualMachinesColocationStatus and VirtualMachineScaleSetsColocationStatus properties are removed from ProximityPlacementGroup.
    - MaxInstanceRepairsPercent property is removed from AutomaticRepairsPolicy.
    - The types of AvailabilitySets, VirtualMachines and VirtualMachineScaleSets are changed from IList<SubResource> to IList<SubResourceWithColocationStatus>.
* Description for 'Get-AzVM' cmdlet has been updated to better describe it.

#### Az.DataFactory
* Supported CRUD of data flow runtime properties in Managed IR.

#### Az.FrontDoor
* Added new cmdlets for creation, update, retreival, and deletion of Front Door Rules Engine object
* Added helper cmdlets for construction of Front Door Rules Engine object
* Added Rules Engine reference to Front Door Routing Rule object.
* Added Private Link parameters to Front Door Backend object

#### Az.Functions
* General availability of ''Az.Functions'' module

#### Az.HDInsight
* Supported Customer-managed key disk encryption.

#### Az.HealthcareApis
* Access policies are no longer defaulted to the current principal

#### Az.IotHub
* Added cmdlet to invoke a query in an IoT hub to retrieve information using a SQL-like language.
* Fix issue that 'Add-AzIotHubDevice' fails to create Edge Enabled Device without child devices [#11597]
* Added cmdlet to generate SAS token for Iot Hub, device or module.
* Added cmdlet to invoke configuration metrics query.
* Manage IoT Edge automatic deployment at scale. New cmdlets are:
    - 'Add-AzIotHubDeployment'
    - 'Get-AzIotHubDeployment'
    - 'Remove-AzIotHubDeployment'
    - 'Set-AzIotHubDeployment'
* Added cmdlet to invoke an IoT Edge deployment metrics query.
* Added cmdlet to apply the configuration content to the specified edge device.

#### Az.KeyVault
* Removed two aliases: 'New-AzKeyVaultCertificateAdministratorDetails' and 'New-AzKeyVaultCertificateOrganizationDetails'
* Enabled soft delete by default when creating a key vault
* Network rules can be set to govern the accessibility from specific network locations when creating a key vault
* Added support to bring your own key (BYOK)
    - 'Add-AzKeyVaultKey' supports generating a key exchange key
    - 'Get-AzKeyVaultKey' supports downloading a public key in PEM format
* Updated the 'KeyOps' part of the help document of 'Add-AzKeyVaultKey'

#### Az.Monitor
* Fixed bug for 'Set-AzDiagnosticSettings', retention policy won't apply to all categories [#11589]
* Supported WebTest availability criteria for metric alert V2
	- 'New-AzMetricAlertRuleV2Criteria': an option to create webtest availability criteria was added
	- 'Add-AzMetricAlertRuleV2': supports the new webtest availability criteria
* Removed redundant definition for RetentionPolicy in PSLogProfile [#7608]
* Removed redundant properties difined in PSEventData [#11353]
* Renamed 'Get-AzLog' to 'Get-AzActivityLog'

#### Az.Network
* Added breaking change attribute to notify that Zone default behaviour will be changed
    - 'New-AzPublicIpAddress'
    - 'New-AzPublicIpPrefix'
    - 'New-AzLoadBalancerFrontendIpConfig'
* Added support for a new top level resource SecurityPartnerProvider
    - New cmdlets added:
        - New-AzSecurityPartnerProvider
        - Remove-AzSecurityPartnerProvider
        - Get-AzSecurityPartnerProvider
        - Set-AzSecurityPartnerProvider
* Added 'RequiredZoneNames' on 'PSPrivateLinkResource' and 'GroupId' on 'PSPrivateEndpointConnection'
* Fixed incorrect type of SuccessThresholdRoundTripTimeMs parameter for New-AzNetworkWatcherConnectionMonitorTestConfigurationObject
* Updated VirtualWan cmdlets to set default value of AllowVnetToVnetTraffic argument to True.
    - 'New-AzVirtualWan'
    - 'Update-AzVirtualWan'
* Added new cmdlets to support DNS zone group for private endpoint
    - 'New-AzPrivateDnsZoneConfig'
    - 'Get-AzPrivateDnsZoneGroup'
    - 'New-AzPrivateDnsZoneGroup'
    - 'Set-AzPrivateDnsZoneGroup'
    - 'Remove-AzPrivateDnsZoneGroup'
* Added 'DNSEnableProxy', 'DNSRequireProxyForNetworkRules' and 'DNSServers' parameters to 'AzureFirewall'
* Added 'EnableDnsProxy', 'DnsProxyNotRequiredForNetworkRule' and 'DnsServer' parameters to 'AzureFirewall'
    - Updated cmdlet:
        - New-AzFirewall

#### Az.OperationalInsights
* Updated legacy code to apply new generated SDK
* Deleted cmdlets due to deprecated APIs
    - 'Get-AzOperationalInsightsSavedSearchResult' (alias 'Get-AzOperationalInsightsSavedSearchResults')
    - 'Get-AzOperationalInsightsSearchResult' (alias 'Get-AzOperationalInsightsSearchResults')
    - 'Get-AzOperationalInsightsLinkTarget' (alias 'Get-AzOperationalInsightsLinkTargets')
* Added parameters for 'Set-AzOperationalInsightsWorkspace' and 'New-AzOperationalInsightsWorkspace'
* Created cmdlets for Linked Stoarge Account
* Created cmdlets for Clusters and Linked Service

#### Az.RecoveryServices
* Azure Site Recovery added support for protecting proximity placement group virtual machines for Azure to Azure provider.
* Azure Site Recovery added support for zone to zone replication.
* Azure Backup Added Long term retention support for Azure FileShare Recovery Points.
* Azure Backup Added disk exclusion properties to 'Get-AzRecoveryServicesBackupItem' cmdlet output.
* Added private endpoint for Vault credential file for site recovery service.

#### Az.Resources
* Added message warning about view delay when creating a new Role Definition
* Changed policy cmdlets to output strongly-typed objects
* Removed '-TenantLevel' parameter used for on the 'Get-AzResourceLock' cmdlet [#11335]
* Fixed 'Remove-AzResourceGroup -Id ResourceId'[#9882]
* Added new cmdlet for getting ARM template What-If results at resource group scope: 'Get-AzDeploymentResourceGroupWhatIfResult'
* Added new cmdlet for getting ARM template What-If results at subscription scope: 'Get-AzDeploymentWhatIfResult'
   - Alias: 'Get-AzSubscriptionDeploymentWhatIf'
* Overrode '-WhatIf' and '-Confirm' parameters for 'New-AzDeployment' and 'New-AzResourceGroupDeployment' to use ARM template What-If results
* Added deprecation message for 'ApiVersion' parameter in deployment cmdlets
* Added capability to show improved error messages for deployment failures
* Added correlationId logging for deployment failures
* Added 'error' property to the deployment script output
* Updated nuget Microsoft.Azure.Management.ResourceManager to '3.7.1-preview'
* Removed specific test cases as Error property in DeploymentValidateResult has changed to readonly from nuget 3.7.1-preview
* Brought GenericResourceExpanded from SDK ResourceManager 3.7.1-preview
* Added tag support for all Get cmdlets for deployment, as well as
    - 'New-AzDeployment'
    - 'New-AzManagementGroupDeployment'
    - 'New-AzResourceGroupDeployment'
    - 'New-AzTenantDeployment'

#### Az.ServiceFabric
* Fixed bug in add certificate using --SecretIdentifier that was getting the wrong certificate thumbprint

#### Az.Sql
* Enhance performance of:
    - 'Set-AzSqlDatabaseSensitivityClassification'
    - 'Set-AzSqlInstanceDatabaseSensitivityClassification'
    - 'Remove-AzSqlDatabaseSensitivityClassification'
    - 'Remove-AzSqlInstanceDatabaseSensitivityClassification'
    - 'Enable-AzSqlDatabaseSensitivityRecommendation'
    - 'Enable-AzSqlInstanceDatabaseSensitivityRecommendation'
    - 'Disable-AzSqlDatabaseSensitivityRecommendation'
    - 'Disable-AzSqlInstanceDatabaseSensitivityRecommendation'
* Removed client-side validation of 'RetentionDays' parameter from cmdlet 'Set-AzSqlDatabaseBackupShortTermRetentionPolicy'
* Auditing to a storage account in Vnet, fixing a bug when creating a Storage Blob Data Contributor role.

#### Az.Storage
* Added '-AsJob' to get/list account cmdlet 'Get-AzStorageAccount'
* Make KeyVersion to optional when update Storage account with KeyvaultEncryption, to support key auto-rotation
    - 'Set-AzStorageAccount'
* Fixed remove Azure File Directory fail with pipeline
    - 'Remove-AzStorageDirectory'
* Fixed [#9880]: Change NetWorkRule DefaultAction value defination to align with swagger.
	- 'Update-AzStorageAccountNetworkRuleSet'
	- 'Get-AzStorageAccountNetworkRuleSet'
* Fixed [#11624]: Skip duplicated rules when add NetworkRules, to avoid server failure
    - 'Add-AzStorageAccountNetworkRule'
* Upgraded Microsoft.Azure.Cosmos.Table SDK to 1.0.7
* Added a warning message to remind user to list again with ContinuationToken when only part items are returned in list DataLake Gen2 Items,
    - 'Get-AzDataLakeGen2ChildItem'
* Supported to create or update Storage account with Azure Files Active Directory Domain Service Authentication
    -  'New-AzStorageAccount'
    -  'Set-AzStorageAccount'
* Supported to new or list Kerberos keys of Storage account
    -  'New-AzStorageAccountKey'
    -  'Get-AzStorageAccountKey'
* Supported failover Storage account
    - 'Invoke-AzStorageAccountFailover'
* Updated help of 'Get-AzStorageBlobCopyState'
* Updated help of 'Get-AzStorageFileCopyState' and 'Start-AzStorageBlobCopy'
* Integrated Storage client library v12 to Queue and File cmdlets
* Changed output type from CloudFile to AzureStorageFile, the original output will become a child property of the new output
    - 'Get-AzStorageFile'
    - 'Remove-AzStorageFile'
    - 'Get-AzStorageFileContent'
    - 'Set-AzStorageFileContent'
    - 'Start-AzStorageFileCopy'
* Changed output type from CloudFileDirectory to AzureStorageFileDirectory, the original output will become a child property of the new output
    - 'New-AzStorageDirectory'
    - 'Remove-AzStorageDirectory'
* Changed output type from CloudFileShare to AzureStorageFileShare, the original output will become a child property of the new output
    - 'Get-AzStorageShare'
    - 'New-AzStorageShare'
    - 'Remove-AzStorageShare'
* Changed output type from FileShareProperties to AzureStorageFileShare, the original output will become a sub child property of the new output
    - 'Set-AzStorageShareQuota'

#### Az.TrafficManager
* Fixed incorrect profile name in 'DisableAzureTrafficManagerEndpoint' verbose output

#### Az.Websites
* Fixed typo on help of 'Update-AzWebAppAccessRestrictionConfig'.

## 3.8.0 - April 2020
#### Az.Accounts
* Updated Azure PowerShell survey URL in 'Resolve-AzError' [#11507]

#### Az.ApiManagement
* Added breaking change notice for Azure File cmdlets output change in a future release
* 'Set-AzApiManagementGroup' Updated documentation to specify the GroupId parameter

#### Az.Cdn
* Fixed ChinaCDN related pricing SKU display

#### Az.CognitiveServices
* Supported Identity, Encryption, UserOwnedStorage

#### Az.Compute
* Added 'Set-AzVmssOrchestrationServiceState' cmdlet.
* 'Get-AzVmss' with -InstanceView shows OrchestrationService states.

#### Az.IotHub
* Manage IoT device twin configuration, New cmdlets are:
    - 'Get-AzIotHubDeviceTwin'
    - 'Update-AzIotHubDeviceTwin'
* Added cmdlet to invoke direct method on a device in an Iot Hub.
* Manage IoT device module twin configuration, New cmdlets are:
    - 'Get-AzIotHubModuleTwin'
    - 'Update-AzIotHubModuleTwin'
* Manage IoT automatic device management configuration at scale. New cmdlets are:
    - 'Add-AzIotHubConfiguration'
    - 'Get-AzIotHubConfiguration'
    - 'Remove-AzIotHubConfiguration'
    - 'Set-AzIotHubConfiguration'
* Added cmdlet to invoke an edge module method in an Iot Hub.

#### Az.KeyVault
* Added a new cmdlet 'Update-AzKeyVault' that can enable soft delete and purge protection on a vault
* Added support to Microsoft.PowerShell.SecretManagement [#11178]
* Fixed error in the examples of 'Remove-AzKeyVaultManagedStorageSasDefinition' [#11479]
* Added support to private endpoint

#### Az.Maintenance
* Publishing release version of Maintenance cmdlets for GA

#### Az.Monitor
* Added cmdlets for private link scope
    - 'Get-AzInsightsPrivateLinkScope'
    - 'Remove-AzInsightsPrivateLinkScope'
    - 'New-AzInsightsPrivateLinkScope'
    - 'Update-AzInsightsPrivateLinkScope'
    - 'Get-AzInsightsPrivateLinkScopedResource'
    - 'New-AzInsightsPrivateLinkScopedResource'
    - 'Remove-AzInsightsPrivateLinkScopedResource'

#### Az.Network
* Updated cmdlets to enable connection on private IP for Virtual Network Gateway.
    - 'New-AzVirtualNetworkGateway'
    - 'Set-AzVirtualNetworkGateway'
    - 'New-AzVirtualNetworkGatewayConnection'
    - 'Set-AzVirtualNetworkGatewayConnection'
* Updated cmdlets to enable FQDN based LocalNetworkGateways and VpnSites
    - 'New-AzLocalNetworkGateway'
    - 'New-AzVpnSiteLink'
* Added support for IPv6 address family in ExpressRouteCircuitConnectionConfig (Global Reach)
    - Added 'Set-AzExpressRouteCircuitConnectionConfig'
        - allows setting of all the existing properties including the IPv6CircuitConnectionProperties
    - Updated 'Add-AzExpressRouteCircuitConnectionConfig'
        - Added another optional parameter AddressPrefixType to specify the address family of address prefix
* Updated cmdlets to enable setting of DPD Timeout on Virtual Network Gateway Connections.
    - New-AzVirtualNetworkGatewayConnection
    - Set-AzVirtualNetworkGatewayConnection

#### Az.PolicyInsights
* Added 'Start-AzPolicyComplianceScan' cmdlet for triggering policy compliance scans
* Added policy definition, set definition, and assignment versions to 'Get-AzPolicyState' output

#### Az.ServiceFabric
* Improved code formatting and usability of 'New-AzServiceFabricCluster' examples

#### Az.Sql
* Added cmdlets 'Get-AzSqlInstanceOperation' and 'Stop-AzSqlInstanceOperation'
* Supported auditing to a storage account in VNet.

#### Az.Storage
* Added breaking change notice for Azure File cmdlets output change in a future release
* Supported new SkuName StandardGZRS, StandardRAGZRS when create/update Storage account
    - 'New-AzStorageAccount'
    - 'Set-AzStorageAccount'
* Supported DataLake Gen2
    - 'New-AzDataLakeGen2Item'
    - 'Get-AzDataLakeGen2Item'
    - 'Get-AzDataLakeGen2ChildItem'
    - 'Move-AzDataLakeGen2Item'
    - 'Set-AzDataLakeGen2ItemAclObject'
    - 'Update-AzDataLakeGen2Item'
    - 'Get-AzDataLakeGen2ItemContent'
    - 'Remove-AzDataLakeGen2Item'

## 0.10.0-preview - April 2020
### General
* Az modules is now available in preview on Azure Stack Hub. This allows for cross-platform compatibility with Linux and macOs. Azure Stack Hub now supports PowerShell core with the Az modules, more information [here](https://aka.ms/az4AzureStack)
* Az modules support profile 2019-03-01-hybrid:
  - Az.Billing
  - Az.Compute
  - Az.DataBoxEdge
  - Az.EventHub
  - Az.IotHub
  - Az.KeyVault
  - Az.Monitor
  - Az.Network
  - Az.Resources
  - Az.Storage
  - Az.Websites
* Three new PowerShell modules for az have been introduced that work with Azure Stack Hub, which are Az.Databox, Az.IotHub, and Az.EventHub
* Commands remain relatively the same, with minor changes such as changing AzureRM to Az
* Updated link to PowerShell documentation for Azure Stack Hub can be found [here](aka.ms/InstallASHPowerShell)

#### Az.Accounts
* Upgrade from ADAL to MSAL

## 3.7.0 - March 2020
#### Az.Accounts
* Fixed 'Get-AzTenant'/'Get-AzDefault'/'Set-AzDefault' throw NullReferenceException when not login [#10292]

#### Az.Compute
* Added the following parameters to 'New-AzDiskConfig' cmdlet:
    - DiskIOPSReadOnly, DiskMBpsReadOnly, MaxSharesCount, GalleryImageReference
* Allowed Encryption property to Target parameter of 'New-AzGalleryImageVersion' cmdlet.
* Fixed tempDisk issue for 'Set-AzVmss' -Reimage and 'Invoke-AzVMReimage' cmdlets. [#11354]
* Added support to below cmdlets for new SAP Extension
    - 'Set-AzVMAEMExtension'
    - 'Get-AzVMAEMExtension'
    - 'Remove-AzVMAEMExtension'
    - 'Update-AzVMAEMExtension'
* Fixed errors in examples of help document
* Showed the exact string value for VM PowerState in the table format.
* 'New-AzVmssConfig': fixed serialization of AutomaticRepairs property when SinglePlacementGroup is disabled. [#11257]

#### Az.DataFactory
* Updated ADF .Net SDK version to 4.8.0
* Added optional parameters to 'Invoke-AzDataFactoryV2Pipeline' command to support rerun

#### Az.DataLakeStore
* Added breaking change description for 'Export-AzDataLakeStoreItem' and 'Import-AzDataLakeStoreItem'
* Added option of Byte encoding for 'New-AzDataLakeStoreItem', 'Add-AzDAtaLakeStoreItemContent', and 'Get-AzDAtaLakeStoreItemContent'

#### Az.HDInsight
* Supported specifying minimal supported TLS version when creating cluster.

#### Az.IotHub
* Added support to manage distributed settings per-device. New Cmdlets are:
    - 'Get-AzIotHubDistributedTracing'
    - 'Set-AzIotHubDistributedTracing'

#### Az.KeyVault
* Added breaking change attributes to 'New-AzKeyVault'

#### Az.Monitor
* Updated documentation for 'New-AzScheduledQueryRuleLogMetricTrigger'

#### Az.Network
* Updated cmdlets to allow cross-tenant VirtualHubVnetConnections
    - 'New-AzVirtualHubVnetConnection'
    - 'Update-AzVirtualHubVnetConnection'
    - 'New-AzVirtualHub'
    - 'Update-AzVirtualHub'
* Removed Sql Management SDK dependency
* Updated cmdlets to allow force firewallPolicy association
    - 'New-AzApplicationGateway'

#### Az.PolicyInsights
* Improved error messages

#### Az.RecoveryServices
* Azure Site Recovery added support for doing reprotect and updated vm properties for Azure disk encrypted Virtual Machines.
* Added Azure Site Recovery VmwareToAzure properties DR monitoring
* Azure Backup added support for retrying policy update for failed items.
* Azure Backup Added support for disk exclusion settings during backup and restore.
* Azure Backup Added Support for Restoring Multiple files/folders in AzureFileShare
* Azure Backup Added support for User-specified Resourcegroup support while updating IaasVM Policy

#### Az.Resources
* Fixed 'Get-AzResource -ResourceGroupName -Name -ExpandProperties -ResourceType' to use actual apiVersion of resources instead of default apiVersion [#11267]
* Added correlationId logging for error scenarios
* Small documentation change to 'Get-AzResourceLock'. Added example.
* Escaped single quote in parameter value of 'Get-AzADUser' [#11317]
* Added new cmdlets for Deployment Scripts ('Get-AzDeploymentScript', 'Get-AzDeploymentScriptLog', 'Save-AzDeploymentScriptLog', 'Remove-AzDeploymentScript')

#### Az.Sql
* Added readable secondary parameter to 'Invoke-AzSqlDatabaseFailover'
* Added cmdlet 'Disable-AzSqlServerActiveDirectoryOnlyAuthentication'
* Saved sensitivity rank when classifying columns in the database.

#### Az.Support
* General availability of 'Az.Support' module

#### Az.Websites
* Added support for working with webapp Traffic Routing Rules via below new cmdlets
  - 'Get-AzWebAppTrafficRouting'
  - 'Update-AzWebAppTrafficRouting'
  - 'Add-AzWebAppTrafficRouting'
  - 'Remove-AzWebAppTrafficRouting'

## 3.6.1 - March 2020
#### Az.Accounts
* Open Azure PowerShell survey page in 'Send-Feedback' [#11020]
* Display Azure PowerShell survey URL in 'Resolve-Error' [#11021]
* Added Az version in UserAgent

#### Az.ApiManagement
* Added support for retrieving and configuring Custom Domain on the DeveloperPortal Endpoint [#11007]
* 'Export-AzApiManagementApi' Added support for downloading Api Definition in Json format [#9987]
* 'Import-AzApiManagementApi' Added support for importing OpenApi 3.0 definition from Json document
* 'New-AzApiManagementIdentityProvider' and 'Set-AzApiManagementIdentityProvider' Added support for configuring 'Signin Tenant' for AAD B2C Provider [#9784]

#### Az.DataLakeStore
* Added reference to System.Buffers explicitly in csproj and psd1.

#### Az.IotHub
* Added support to manage devices in an Iot Hub. New Cmdlets are:
  - 'Add-AzIotHubDevice'
  - 'Get-AzIotHubDevice'
  - 'Remove-AzIotHubDevice'
  - 'Set-AzIotHubDevice'
* Added support to manage modules on a target Iot device in an Iot Hub. New Cmdlets are:
  - 'Add-AzIotHubModule'
  - 'Get-AzIotHubModule'
  - 'Remove-AzIotHubModule'
  - 'Set-AzIotHubModule'
* Added cmdlet to get the connection string of a target IoT device in an Iot Hub.
* Added cmdlet to get the connection string of a module on a target IoT device in an Iot Hub.
* Added support to get/set parent device of an IoT device. New Cmdlets are:
    - 'Get-AzIotHubDeviceParent'
    - 'Set-AzIotHubDeviceParent'
* Added support to manage device parent-child relationship.

#### Az.Monitor
* Fixed output value for 'Get-AzMetricDefinition' [#9714]

#### Az.Network
* Updated Sql Management SDK.
* Fixed a naming-difference issue in PrivateLinkServiceConnectionState class.
    - Mapping the field ActionsRequired to ActionRequired.
* Added PublicNetworkAccess to 'New-AzSqlServer' and 'Set-AzSqlServer'

#### Az.Resources
* Fixed for null reference bug in 'Get-AzRoleAssignment'
* Marked switch '-Force' and '-PassThru' optional in 'Remove-AzADGroup' [#10849]
* Fixed issue that 'MailNickname' doesn't return in 'Remove-AzADGroup' [#11167]
* Fixed issue that 'Remove-AzADGroup' pipe operation doesn't work [#11171]
* Fixed for null reference bug in GetAzureRoleAssignmentCommand
* Added breaking change attributes for upcoming changes to policy cmdlets
* Updated 'Get-AzResourceGroup' to perform resource group tag filtering on server-side
* Extended Tag cmdlets to accept -ResourceId
    - Get-AzTag -ResourceId
    - New-AzTag -ResourceId
    - Remove-AzTag -ResourceId
* Added new Tag cmdlet
    - Update-AzTag -ResourceId
* Brought ScopedDeployment from SDK 3.3.0

#### Az.Sql
* Added PublicNetworkAccess to 'New-AzSqlServer' and 'Set-AzSqlServer'
* Added support for Long Term Retention backup configuration for Managed Databases
    - Get/Set LTR policy on a managed database
    - Get LTR backup(s) by managed database, managed instance, or by location
    - Remove an LTR backup
    - Restore an LTR backup to create a new managed database
* Added MinimalTlsVersion to New-AzSqlServer and Set-AzSqlServer
* Added MinimalTlsVersion to New-AzSqlInstance and Set-AzSqlInstance
* Bumped SQL SDK version for Az.Network

#### Az.Storage
* Supported AllowProtectedAppendWrite in ImmutabilityPolicy
    - 'Set-AzRmStorageContainerImmutabilityPolicy'
* Added breaking change warning message for AzureStorageTable type change in a future release
    - 'New-AzStorageTable'
    - 'Get-AzStorageTable'

#### Az.Websites
* Added Tag parameter for 'New-AzAppServicePlan' and 'Set-AzAppServicePlan'
* Stop cmdlet execution if an exception is thrown when adding a custom domain to a website
* Added support to perform operations for App Services not in the same resource group as the App Service Plan
* Applied access restriction to WebApp/Function in different resource groups
* Fixed issue to set custom hostnames for WebAppSlots

## 3.5.0 - February 2020
### Highlights since the last major release
* Updated client side telemetry.
* Az.IotHub added cmdlets to support to manage devices.
* Az.SqlVirtualMachine added cmdlets for Availability Group Listener.

#### Az.Resource
* Fixed bug preventing correct tenant-level resource id generation.
* Fixed typo.

#### Az.Accounts
* Added SubscriptionId, TenantId, and execution time into data of client side telemetry

#### Az.Automation
* Fixed typo in Example 1 in reference documentation for 'New-AzAutomationSoftwareUpdateConfiguration'

#### Az.CognitiveServices
* Updated SDK to 7.0
* Improved error message when server responses empty body

#### Az.Compute
* Allowed empty value for ProximityPlacementGroupId during update

#### Az.FrontDoor
* Added cmdlet to get managed rule definitions that can be used in WAF

#### Az.IotHub
* Added support to manage devices in an Iot Hub. New Cmdlets are:
  - 'Add-AzIotHubDevice'
  - 'Get-AzIotHubDevice'
  - 'Remove-AzIotHubDevice'
  - 'Set-AzIotHubDevice'

#### Az.KeyVault
* Fixed duplicated text for Add-AzKeyVaultKey.md

#### Az.Monitor
* Fixed description of the Get-AzLog cmdlet.
* A new parameter called ActionGroupId was added to 'New-AzMetricAlertRuleV2' command.
  - The user can provide either ActionGroupId(string) or ActionGorup(ActivityLogAlertActionGroup).

#### Az.Network
* Added one extra parameter note for parameter '-EnableProxyProtocol' for 'New-AzPrivateLinkService' cmdlet.
* Fixed FilterData example in Start-AzVirtualNetworkGatewayConnectionPacketCapture.md and Start-AzVirtualnetworkGatewayPacketCapture.md.
* Added Packet Capture example for capture all inner and outer packets in Start-AzVirtualNetworkGatewayConnectionPacketCapture.md and Start-AzVirtualnetworkGatewayPacketCapture.md.
* Supported Azure Firewall Policy on VNet Firewalls
    - No new cmdlets are added. Relaxing the restriction for firewall policy on VNet firewalls

#### Az.RecoveryServices
* Added Support for Restore-as-files for SQL Databases.

#### Az.Resources
* Refactored template deployment cmdlets
    - Added new cmdlets for managing deployments at management group: *-AzManagementGroupDeployment
    - Added new cmdlets for managing deployments at tenant scope: *-AzTenantDeployment
    - Refactored *-AzDeployment cmdlets to work specifically at subscription scope
    - Created aliases *-AzSubscriptionDeployment for *-AzDeployment cmdlets
* Fixed 'Update-AzADApplication' when parameter 'AvailableToOtherTenants' is not set
* Removed ApplicationObjectWithoutCredentialParameterSet to avoid AmbiguousParameterSetException.
* Regenerated help files

#### Az.Sql
* Added support for cross subscription point in time restore on Managed Instances.
* Added support for changing existing Sql Managed Instance hardware generation
* Fixed 'Update-AzSqlServerVulnerabilityAssessmentSetting' help examples: parameter/property output - EmailAdmins

#### Az.SqlVirtualMachine
* Added cmdlets for Availability Group Listener

#### Az.StorageSync
* Updated supported character sets in 'Invoke-AzStorageSyncCompatibilityCheck'.

## 3.4.0 - February 2020

#### Az.CosmosDB
* Added cmdlets for Gremlin, MongoDB, Cassandra and Table APIs.
* Updated .NET SDK Version to 1.0.1
* Added parameters ConflictResolutionPolicyMode, ConflictResolutionPolicyPath and ConflictResolutionPolicyPath in Set-AzCosmosDBSqlContainer.
* Added new cmdlets for Sql API : New-CosmosDBSqlSpatialSpec, New-CosmosDBSqlCompositePath, New-CosmosDBSqlIncludedPathIndex, New-CosmosDBSqlIncludedPath

#### Az.Accounts
* Disable context auto saving when AzureRmContext.json not available
* Update the reference to Azure Powershell Common to 1.3.5-preview

#### Az.ApiManagement
* **Get-AzApiManagementApiSchema** Fixed getting Open-Api Schema associated with an API
    https://github.com/Azure/azure-powershell/issues/10626
* **New-AzApiManagementProduct*** and **Set-AzApiManagementProduct**
  - Fix documentation for https://github.com/Azure/azure-powershell/issues/10472
* **Set-AzApiManagementApi**
    Added example to show how to update the ServiceUrl using the cmdlet

#### Az.Compute
* Limit the number of VM status to 100 to avoid throttling when Get-AzVM -Status is performed without VM name.
* Add Update-AzDiskEncryptionSet cmdlet
* Add EncryptionType and DiskEncryptionSetId parameters to the following cmdlets:
    - New-AzDiskUpdateConfig, New-AzSnapshotUpdateConfig
* Add ColocationStatus parameter to Get-AzProximityPlacementGroup cmdlet.

#### Az.DataFactory
* Update ADF .Net SDK version to 4.7.0

#### Az.DeploymentManager
* Adds LIST operations for resources
* Adds capability for performing operations on Health Check steps

#### Az.HDInsight
* Fix document error of New-AzHDInsightCluster.

#### Az.KeyVault
* Add Name alias to VaultName attribute to make Remove-AzureKeyVault consistent with New-AzureKeyVault.

#### Az.Network
* New example added to Set-AzNetworkWatcherConfigFlowLog.md to demonstrate Traffic Analytics disable scenario.
* Add support for assigning management IP configuration to Azure Firewall - a dedicated subnet and Public IP that the firewall will use for its management traffic
    - Updated New-AzFirewall cmdlet:
        - Added parameter -ManagementPublicIpAddress (not mandatory) which accepts a Public IP Address object
        - Added method SetManagementIpConfiguration on firewall object - requires a subnet and a Public IP address as input - subnet name must be 'AzureFirewallManagementSubnet'
* Corrected Get-AzNetworkSecurityGroup examples to show examples for NSG's instead of network interfaces.
* Fixed typo in New-AzVpnSite command that was preventing resource id completer from completing a parameter.
* Added support for Url Confiugration in Rewrite Rules Action Set in the Application Gateway
    - New cmdlets added:
        - New-AzApplicationGatewayRewriteRuleUrlConfiguration
    - Cmdlets updated with optional parameter - UrlConfiguration
        - New-AzApplicationGatewayRewriteRuleActionSet
* Add suppport for NetworkWatcher ConnectionMonitor version 2 resources

#### Az.PolicyInsights
* Support evaluating compliance prior to determining what resource to remediate
    - Add '-ResourceDiscoverMode' parameter to Start-AzPolicyRemediation
* Add Get-AzPolicyMetadata cmdlet for getting policy metadata resources
* Updated Get-AzPolicyState and Get-AzPolicyStateSummary for API version 2019-10-01

#### Az.RecoveryServices
* Azure Site Recovery support for removing a replicated disk.
* Azure Backup added support for adding tags while creating a Recovery Services Vault.

#### Az.Resources
* Make -Scope optional in *-AzPolicyAssignment cmdlets with default to context subscription
* Add examples of creating ADServicePrincipal with password and key credential

#### Az.Sql
Fix New-AzSqlDatabaseSecondary cmdlet to check for PartnerDatabaseName existence instead of DatabaseName existence.

#### Az.Storage
* Support set Table/Queue Encryption Keytype in Create Storage Account
    - New-AzStorageAccount
* Show RequestId when StorageException don't have ExtendedErrorInformation
* Fix the Example 6 of cmdlet Start-AzStorageBlobCopy

#### Az.Websites
* Set-AzWebapp and Set-AzWebappSlot supports AlwaysOn, MinTls and FtpsState properties
* Fixing issue where setting HttpsOnly along with changing AppservicePlan at the same time using the single Set-AzWebApp Command, was resetting HttpsOnly to default value

## 3.3.0 - January 2020
#### Az.Accounts
* Updated Add-AzEnvironment and Set-AzEnvironment to accept parameters AzureAttestationServiceEndpointResourceId and AzureAttestationServiceEndpointSuffix

#### Az.Cdn
* Display error response detail in New-AzCdnEndpoint cmdlet

#### Az.Compute
* Fix Set-AzVMCustomScriptExtension cmdlet for a VM with managed OD disk which does not have OS profile.

#### Az.ContainerInstance
* Fixed parameter names used by example of New-AzContainerGroup

#### Az.DataBoxEdge
* Added cmdlet 'Get-AzDataBoxEdgeStorageContainer'
  - Get the Edge Storage Container
* Added cmdlet 'New-AzDataBoxEdgeStorageContainer'
  - Create new Edge Storage Container
* Added cmdlet 'Remove-AzDataBoxEdgeStorageContainer'
  - Remove the Edge Storage Container
* Added cmdlet 'Invoke-AzDataBoxEdgeStorageContainer'
  - Invoke action to refresh data on Edge Storage Container
* Added cmdlet 'Get-AzDataBoxEdgeStorageAccount'
  - Get the Edge Storage Account
* Added cmdlet 'New-AzDataBoxEdgeStorageAccount'
  - Create new Edge Storage Account
* Added cmdlet 'Remove-AzDataBoxEdgeStorageAccount'
  - Remove the Edge Storage Account
* Invoke cmdlet 'Invoke-AzDataBoxEdgeShare'
  - Invoke action to refresh data on share
* Added cmdlet 'Set-AzDataBoxEdgeStorageAccountCredential'
  - Set the az databoxedge storage account credential

#### Az.DataFactory
* Add AutoUpdateETA, LatestVersion, PushedVersion, TaskQueueId and VersionStatus properties for Get-AzDataFactoryV2IntegrationRuntime cmd
* Update ADF .Net SDK version to 4.6.0
* Add parameter 'PublicIPs' for 'Set-AzDataFactoryV2IntegrationRuntime' cmd
to enable create Azure-SSIS IR with static public IP addresses.

#### Az.DevTestLabs
* Remove the broken link in Get-AzDtlAllowedVMSizesPolicy.md

#### Az.EventHub
* Fix for issue 10634 : Fix the null Object reference for remove eventhubnamespace

#### Az.HDInsight
* Fix Invoke-AzHDInsightHiveJob.md error.

#### Az.MachineLearning
* Removed below cmdlets because MachineLearningCompute is not available any longer
  - Get-AzMlOpCluster
  - Get-AzMlOpClusterKey
  - New-AzMlOpCluster
  - Remove-AzMlOpCluster
  - Set-AzMlOpCluster
  - Test-AzMlOpClusterSystemServicesUpdateAvailability
  - Update-AzMlOpClusterSystemService

#### Az.Network
* Upgrade dependency of Microsoft.Azure.Management.Sql from 1.36-preview to 1.37-preview

#### Az.RecoveryServices
* Azure Site Recovery change support for managed disk vms encrypted at rest with customer managed leys for Azure to Azure provider.
* Azure Site Recovery support to input disk encryption Set Id as optional input at enabling protection for Vmware to Azure.
* Azure Site Recovery support to input disk encryption Set Id as optional input at disk level to enable protection for Vmware to Azure.
* Azure Site Recovery support to update replication protected item with disk encryption set Map for HyperV to Azure.

#### Az.Resources
* Fix an error in help document of 'Remove-AzTag'.

#### Az.Sql
* Fix vulnerability assessment set baseline cmdlets functionality to work on master db for azure database and limit it on managed instance system databases.
* Fix an error when creating SQL instance failover group

#### Az.SqlVirtualMachine
* Add DR as a new valid License type

#### Az.Storage
* Add breaking change warning message for DefaultAction Value change in a future release
    - Update-AzStorageAccountNetworkRuleSet
* Support Get last sync time of Storage account by run get-AzStorageAccount with parameter -IncludeGeoReplicationStats
    - Get-AzStorageAccount

## 3.2.0 - December 2019

### General
* Update references in .psd1 to use relative path for all modules

#### Az.Accounts
* Set correct UserAgent for client-side telemetry for Az 4.0 preview
* Display user friendly error message when context is null in Az 4.0 preview

#### Az.Batch
* Fix issue #10602, where **New-AzBatchPool** did not properly send 'VirtualMachineConfiguration.ContainerConfiguration' or 'VirtualMachineConfiguration.DataDisks' to the server.

#### Az.DataFactory
* Update ADF .Net SDK version to 4.5.0

#### Az.FrontDoor
* Added WAF managed rules exclusion support
* Add SocketAddr to auto-complete

#### Az.HealthcareApis
* Exception Handling

#### Az.KeyVault
* Fixed error accessing value that is potentially not set
* Elliptic Curve Cryptography Certificate Managment
    - Added support to specify the Curve for Certificate Policies

#### Az.Monitor
* Adding optional argument to the Add Diagnostic Settings command. A switch argument that if present indicates that the export to Log Analytics must be to a fixed schema (a.k.a. dedicated, data type)

#### Az.Network
* Support for IpGroups in AzureFirewall Application,Nat & Network Rules.

#### Az.RecoveryServices
* Added SoftDelete feature for VM and added tests for softdelete
* Azure Site Recovery support for Azure Disk Encryption One Pass for Azure to Azure.

#### Az.Resources
* Fix an issue where template deployment fails to read a template parameter if its name conflicts with some built-in parameter name.
* Updated policy cmdlets to use new api version 2019-09-01 that introduces grouping support within policy set definitions.

#### Az.Sql
* Upgraded storage creation in Vulnerability Assessment auto enablement to StorageV2

#### Az.Storage
* Support generate Blob/Constainer Idenity based SAS token with Storage Context based on Oauth authentication
    - New-AzStorageContainerSASToken
    - New-AzStorageBlobSASToken
* Support revoke Storage Account User Delegation Keys, so all Idenity SAS tokens are revoked
    - Revoke-AzStorageAccountUserDelegationKeys
* Upgrade to Microsoft.Azure.Management.Storage 14.2.0, to support new API version 2019-06-01.
* Support Share QuotaGiB more than 5120 in Management plane File Share cmdlets, and add parameter alias 'Quota' to parameter 'QuotaGiB'
  - New-AzRmStorageShare
  - Update-AzRmStorageShare
* Add parameter alias 'QuotaGiB' to parameter 'Quota'
  - Set-AzStorageShareQuota
* Fix the issue that Set-AzStorageContainerAcl can clean up the stored Access Policy
  - Set-AzStorageContainerAcl

## 3.1.0 - November 2019
### Highlights since the last major release
* Az.DataBoxEdge 1.0.0 released
* Az.SqlVirtualMachine 1.0.0 released

#### Az.Compute
* VM Reapply feature
    - Add Reapply parameter to Set-AzVM cmdlet
* VM Scale Set AutomaticRepairs feature:
    - Add EnableAutomaticRepair, AutomaticRepairGracePeriod, and AutomaticRepairMaxInstanceRepairsPercent parameters to the following cmdlets:
        New-AzVmssConfig
        Update-AzVmss
* Cross tenant gallery image support for New-AzVM
* Add 'Spot' to the argument completer of Priority parameter in New-AzVM, New-AzVMConfig and New-AzVmss cmdlets
* Add DiskIOPSReadWrite and DiskMBpsReadWrite parameters to Add-AzVmssDataDisk cmdlet
* Change SourceImageId parameter of New-AzGalleryImageVersion cmdlet to optional
* Add OSDiskImage and DataDiskImage parameters to New-AzGalleryImageVersion cmdlet
* Add HyperVGeneration parameter to New-AzGalleryImageDefinition cmdlet
* Add SkipExtensionsOnOverprovisionedVMs parameters to New-AzVmss, New-AzVmssConfig and Update-AzVmss cmdlets

#### Az.DataBoxEdge
* Added cmdlet `Get-AzDataBoxEdgeOrder`
    - Get the Order
* Added cmdlet `New-AzDataBoxEdgeOrder`
    - Create new Order
* Added cmdlet `Remove-AzDataBoxEdgeOrder`
    - Remove the Order
* Change in cmdlet `New-AzDataBoxEdgeShare`
    - Now creates Local Share
* Added cmdlet `Set-AzDataBoxEdgeRole`
    - Now IotRole can be mapped to Share
* Added cmdlet `Invoke-AzDataBoxEdgeDevice`
    - Invoke scan update, download update, install updates on the device
* Added cmdlet `Get-AzDataBoxEdgeTrigger`
    - Gets the information about Triggers
* Added cmdlet `New-AzDataBoxEdgeTrigger`
    - Create new Triggers
* Added cmdlet `Remove-AzDataBoxEdgeTrigger`
    - Remove the Triggers

#### Az.DataFactory
* Update ADF .Net SDK version to 4.4.0
* Add parameter 'ExpressCustomSetup' for 'Set-AzDataFactoryV2IntegrationRuntime' cmd to enable setup configurations and 3rd party components without custom setup script.

#### Az.DataLakeStore
* Update documentation of Get-AzDataLakeStoreDeletedItem and Restore-AzDataLakeStoreDeletedItem

#### Az.EventHub
* Fix for issue 10301 : Fix the SAS Token date format

#### Az.FrontDoor
* Add MinimumTlsVersion parameter to Enable-AzFrontDoorCustomDomainHttps and New-AzFrontDoorFrontendEndpointObject
* Add HealthProbeMethod and EnabledState parameters to New-AzFrontDoorHealthProbeSettingObject
* Add new cmdlet to create BackendPoolsSettings objec to pass into creation/update of Front Door
    - New-AzFrontDoorBackendPoolsSettingObject

#### Az.Network
* Change 'Start-AzVirtualNetworkGatewayConnectionPacketCapture.md' and 'Start-AzVirtualnetworkGatewayPacketCapture.md' FilterData option examples.

#### Az.PrivateDns
* Updated PrivateDns .net sdk to version 1.0.0

#### Az.RecoveryServices
* Azure Site Recovery support to select disk type at enabling protection.
* Azure Site Recovery bug fix for recovery plan action edit.
* Azure Backup SQL Restore support to accept filestream DBs.

#### Az.RedisCache
* Added 'MinimumTlsVersion' parameter in 'New-AzRedisCache' and 'Set-AzRedisCache' cmdlets. Also, added 'MinimumTlsVersion' in the output of 'Get-AzRedisCache' cmdlet.
* Added validation on '-Size' parameter for 'Set-AzRedisCache' and 'New-AzRedisCache' cmdlets

#### Az.Resources
- Updated policy cmdlets to use new api version 2019-06-01 that has new EnforcementMode property in policy assignment.
- Updated create policy definition help example
- Fix bug Remove-AZADServicePrincipal -ServicePrincipalName, throw null reference when service principal name not found.
- Fix bug New-AZADServicePrincipal, throw null reference when tenant doesn't have any subscription.
- Change New-AzAdServicePrincipal to add credentials only to associated application.

#### Az.Sql
* Added support for database ReadReplicaCount.
* Fixed Set-AzSqlDatabase when zone redundancy not set

## 3.0.0 - November 2019
### General
* Az.PrivateDns 1.0.0 released

#### Az.Accounts
* Add a deprecation message for 'Resolve-Error' alias.

#### Az.Advisor
* Added new category 'Operational Excellence' to Get-AzAdvisorRecommendation cmdlet.

#### Az.Batch
* Renamed `CoreQuota` on `BatchAccountContext` to `DedicatedCoreQuota`. There is also a new `LowPriorityCoreQuota`.
  - This impacts **Get-AzBatchAccount**.
* **New-AzBatchTask** `-ResourceFile` parameter now takes a collection of `PSResourceFile` objects, which can be constructed using the new **New-AzBatchResourceFile** cmdlet.
* New **New-AzBatchResourceFile** cmdlet to help create `PSResourceFile` objects. These can be supplied to **New-AzBatchTask** on the `-ResourceFile` parameter.
  - This supports two new kinds of resource file in addition to the existing `HttpUrl` way:
    - `AutoStorageContainerName` based resource files download an entire auto-storage container to the Batch node.
    - `StorageContainerUrl` based resource files download the container specified in the URL to the Batch node.
* Removed `ApplicationPackages` property of `PSApplication` returned by **Get-AzBatchApplication**.
  - The specific packages inside of an application now can be retrieved using **Get-AzBatchApplicationPackage**. For example: `Get-AzBatchApplication -AccountName myaccount -ResourceGroupName myresourcegroup -ApplicationId myapplication`.
* Renamed `ApplicationId` to `ApplicationName` on **Get-AzBatchApplicationPackage**, **New-AzBatchApplicationPackage**, **Remove-AzBatchApplicationPackage**, **Get-AzBatchApplication**, **New-AzBatchApplication**, **Remove-AzBatchApplication**, and **Set-AzBatchApplication**.
  - `ApplicationId` now is an alias of `ApplicationName`.
* Added new `PSWindowsUserConfiguration` property to `PSUserAccount`.
* Renamed `Version` to `Name` on `PSApplicationPackage`.
* Renamed `BlobSource` to `HttpUrl` on `PSResourceFile`.
* Removed `OSDisk` property from `PSVirtualMachineConfiguration`.
* Removed **Set-AzBatchPoolOSVersion**. This operation is no longer supported.
* Removed `TargetOSVersion` from `PSCloudServiceConfiguration`.
* Renamed `CurrentOSVersion` to `OSVersion` on `PSCloudServiceConfiguration`.
* Removed `DataEgressGiB` and `DataIngressGiB` from `PSPoolUsageMetrics`.
* Removed **Get-AzBatchNodeAgentSku** and replaced it with  **Get-AzBatchSupportedImage**.
  - **Get-AzBatchSupportedImage** returns the same data as **Get-AzBatchNodeAgentSku** but in a more friendly format.
  - New non-verified images are also now returned. Additional information about `Capabilities` and `BatchSupportEndOfLife` for each image is also included.
* Added ability to mount remote file-systems on each node of a pool via the new `MountConfiguration` parameter of **New-AzBatchPool**.
* Now support network security rules blocking network access to a pool based on the source port of the traffic. This is done via the `SourcePortRanges` property on `PSNetworkSecurityGroupRule`.
* When running a container, Batch now supports executing the task in the container working directory or in the Batch task working directory. This is controlled by the `WorkingDirectory` property on `PSTaskContainerSettings`.
* Added ability to specify a collection of public IPs on `PSNetworkConfiguration` via the new `PublicIPs` property. This guarantees nodes in the Pool will have an IP from the list user provided IPs.
* When not specified, the default value of `WaitForSuccess` on `PSSTartTask` is now `$True` (was `$False`).
* When not specified, the default value of `Scope` on `PSAutoUserSpecification` is now `Pool` (was `Task` on Windows and `Pool` on Linux).

#### Az.Cdn
* Introduced UrlRewriteAction and CacheKeyQueryStringAction to RulesEngine.
* Fixed several bugs like missing 'Selector' Input in New-AzDeliveryRuleCondition cmdlet.

#### Az.Compute
* Disk Encryption Set feature
    - New cmdlets:
        New-AzDiskEncryptionSetConfig
        New-AzDiskEncryptionSet
        Get-AzDiskEncryptionSet
        Remove-AzDiskEncryptionSet
    - DiskEncryptionSetId parameter is added to the following cmdlets:
        Set-AzImageOSDisk
        Set-AzVMOSDisk
        Set-AzVmssStorageProfile
        Add-AzImageDataDisk
        New-AzVMDataDisk
        Set-AzVMDataDisk
        Add-AzVMDataDisk
        Add-AzVmssDataDisk
        Add-AzVmssVMDataDisk
    - DiskEncryptionSetId and EncryptionType parameters are added to the following cmdlets:
        New-AzDiskConfig
        New-AzSnapshotConfig
* Add PublicIPAddressVersion parameter to New-AzVmssIPConfig
* Move FileUris of custom script extension from public setting to protected setting
* Add ScaleInPolicy to New-AzVmss, New-AzVmssConfig and Update-AzVmss cmdlets
* Breaking changes
    - UploadSizeInBytes parameter is used instead of DiskSizeGB for New-AzDiskConfig when CreateOption is Upload
    - PublishingProfile.Source.ManagedImage.Id is replaced with StorageProfile.Source.Id in GalleryImageVersion object

#### Az.DataFactory
* Update ADF .Net SDK version to 4.3.0

#### Az.DataLakeStore
* Update ADLS SDK version (https://github.com/Azure/azure-data-lake-store-net/blob/preview-alpha/CHANGELOG.md#version-123-alpha), brings following fixes
* Avoid throwing exception while unable to deserialize the creationtime of the trash or directory entry.
* Expose setting per request timeout in adlsclient
* Fix passing the original syncflag for badoffset recovery
* Fix EnumerateDirectory to retrieve continuation token once response is checked
* Fix Concat Bug

#### Az.FrontDoor
* Fixed miscellaneous typos across module

#### Az.HDInsight
* Fixed the bug that customer will get 'Not a valid Base-64 string' error when using Get-AzHDInsightCluster to get the cluster with ADLSGen1 storage.
* Add a parameter named 'ApplicationId' to three cmdlets Add-AzHDInsightClusterIdentity, New-AzHDInsightClusterConfig and New-AzHDInsightCluster so that customer can provide the service principal application id for accessing Azure Data Lake.
* Changed Microsoft.Azure.Management.HDInsight from 2.1.0 to 5.1.0
* Removed five cmdlets:
    - Get-AzHDInsightOMS
    - Enable-AzHDInsightOMS
    - Disable-AzHDInsightOMS
    - Grant-AzHDInsightRdpServicesAccess
    - Revoke-AzHDInsightRdpServicesAccess
* Added three cmdlets:
    - Get-AzHDInsightMonitoring to replace Get-AzHDInsightOMS.
    - Enable-AzHDInsightMonitoring to replace Enable-AzHDInsightOMS.
    - Disable-AzHDInsightMonitoring to replace Disable-AzHDInsightOMS.
* Fixed cmdlet Get-AzHDInsightProperties to support get capabilities information from a specific location.
* Removed parameter sets('Spark1', 'Spark2') from Add-AzHDInsightConfigValue.
* Add examples to the help documents of cmdlet Add-AzHDInsightSecurityProfile.
* Changed output type of the following cmdlets:
*  - Changed the output type of Get-AzHDInsightProperties from  CapabilitiesResponse to AzureHDInsightCapabilities.
*  - Changed the output type of Remove-AzHDInsightCluster from ClusterGetResponse to bool.
*  - Changed the output type of Set-AzHDInsightGatewaySettings HttpConnectivitySettings to GatewaySettings.
* Added some scenario test cases.
* Remove some alias: 'Add-AzHDInsightConfigValues', 'Get-AzHDInsightProperties'.

#### Az.IotHub
* Breaking changes:
    - The cmdlet 'Add-AzIotHubEventHubConsumerGroup' no longer supports the parameter 'EventHubEndpointName' and no alias was found for the original parameter name.
    - The parameter set '__AllParameterSets' for cmdlet 'Add-AzIotHubEventHubConsumerGroup' has been removed.
    - The cmdlet 'Get-AzIotHubEventHubConsumerGroup' no longer supports the parameter 'EventHubEndpointName' and no alias was found for the original parameter name.
    - The parameter set '__AllParameterSets' for cmdlet 'Get-AzIotHubEventHubConsumerGroup' has been removed.
    - The property 'OperationsMonitoringProperties' of type 'Microsoft.Azure.Commands.Management.IotHub.Models.PSIotHubProperties' has been removed.
    - The property 'OperationsMonitoringProperties' of type 'Microsoft.Azure.Commands.Management.IotHub.Models.PSIotHubInputProperties' has been removed.
    - The cmdlet 'New-AzIotHubExportDevice' no longer supports the alias 'New-AzIotHubExportDevices'.
    - The cmdlet 'New-AzIotHubImportDevice' no longer supports the alias 'New-AzIotHubImportDevices'.
    - The cmdlet 'Remove-AzIotHubEventHubConsumerGroup' no longer supports the parameter 'EventHubEndpointName' and no alias was found for the original parameter name.
    - The parameter set '__AllParameterSets' for cmdlet 'Remove-AzIotHubEventHubConsumerGroup' has been removed.
    - The cmdlet 'Set-AzIotHub' no longer supports the parameter 'OperationsMonitoringProperties' and no alias was found for the original parameter name.
    - The parameter set 'UpdateOperationsMonitoringProperties' for cmdlet 'Set-AzIotHub' has been removed.

#### Az.RecoveryServices
* Azure Site Recovery support to configure networking resources like NSG, public IP and internal load balancers for Azure to Azure.
* Azure Site Recovery Support to write to managed disk for vMWare to Azure.
* Azure Site Recovery Support to NIC reduction for vMWare to Azure.
* Azure Site Recovery Support to accelerated networking for Azure to Azure.
* Azure Site Recovery Support to agent auto update for Azure to Azure.
* Azure Site Recovery Support to Standard SSD for Azure to Azure.
* Azure Site Recovery Support to Azure Disk Encryption two pass for Azure to Azure.
* Azure Site Recovery Support to protect newly added disk for Azure to Azure.
* Added SoftDelete feature for VM and added tests for softdelete

#### Az.Resources
* Update dependency assembly Microsoft.Extensions.Caching.Memory from 1.1.1 to 2.2

#### Az.Network
* Change all cmdlets for PrivateEndpointConnection to support generic service provider.
    - Updated cmdlet:
        - Approve-AzPrivateEndpointConnection
        - Deny-AzPrivateEndpointConnection
        - Get-AzPrivateEndpointConnection
        - Remove-AzPrivateEndpointConnection
        - Set-AzPrivateEndpointConnection
* Add new cmdlet for PrivateLinkResource and it also support generic service provider.
    - New cmdlet:
        - Get-AzPrivateLinkResource
* Add new fields and parameter for the feature Proxy Protocol V2.
    - Add property EnableProxyProtocol in PrivateLinkService
    - Add property LinkIdentifier in PrivateEndpointConnection
    - Updated New-AzPrivateLinkService to add a new optional parameter EnableProxyProtocol.
* Fix incorrect parameter description in 'New-AzApplicationGatewaySku' reference documentation
* New cmdlets to support the azure firewall policy
* Add support for child resource RouteTables of VirtualHub
    - New cmdlets added:
        - Add-AzVirtualHubRoute
        - Add-AzVirtualHubRouteTable
        - Get-AzVirtualHubRouteTable
        - Remove-AzVirtualHubRouteTable
        - Set-AzVirtualHub
* Add support for new properties Sku of VirtualHub and VirtualWANType of VirtualWan
    - Cmdlets updated with optional parameters:
        - New-AzVirtualHub : added parameter Sku
        - Update-AzVirtualHub : added parameter Sku
        - New-AzVirtualWan : added parameter VirtualWANType
        - Update-AzVirtualWan : added parameter VirtualWANType
* Add support for EnableInternetSecurity property for HubVnetConnection, VpnConnection and ExpressRouteConnection
    - New cmdlets added:
        - Update-AzVirtualHubVnetConnection
    - Cmdlets updated with optional parameters:
        - New-AzVirtualHubVnetConnection : added parameter EnableInternetSecurity
        - New-AzVpnConnection : added parameter EnableInternetSecurity
        - Update-AzVpnConnection : added parameter EnableInternetSecurity
        - New-AzExpressRouteConnection : added parameter EnableInternetSecurity
        - Set-AzExpressRouteConnection : added parameter EnableInternetSecurity
* Add support for Configuring TopLevel WebApplicationFirewall Policy
    - New cmdlets added:
        - New-AzApplicationGatewayFirewallPolicySetting
        - New-AzApplicationGatewayFirewallPolicyExclusion
        - New-AzApplicationGatewayFirewallPolicyManagedRuleGroupOverride
        - New-AzApplicationGatewayFirewallPolicyManagedRuleOverride
        - New-AzApplicationGatewayFirewallPolicyManagedRule
        - New-AzApplicationGatewayFirewallPolicyManagedRuleSet
    - Cmdlets updated with optional parameters:
        - New-AzApplicationGatewayFirewallPolicy : added parameter PolicySetting, ManagedRule
* Added support for Geo-Match operator on CustomRule
    - Added GeoMatch to the operator on the FirewallCondition
* Added support for perListener and perSite Firewall policy
    - Cmdlets updated with optional parameters:
        - New-AzApplicationGatewayHttpListener : added parameter FirewallPolicy, FirewallPolicyId
        - New-AzApplicationGatewayPathRuleConfig : added parameter FirewallPolicy, FirewallPolicyId
* Fix required subnet with name AzureBastionSubnet in 'PSBastion' can be case insensitive
* Support for Destination FQDNs in Network Rules and Translated FQDN in NAT Rules for Azure Firewall
* Add support for top level resource RouteTables of IpGroup
    - New cmdlets added:
        - New-AzIpGroup
        - Remove-AzIpGroup
        - Get-AzIpGroup
        - Set-AzIpGroup

#### Az.ServiceFabric
* Remove Add-AzServiceFabricApplicationCertificate cmdlet as this scenario is covered by Add-AzVmssSecret.

#### Az.Sql
* Added support for restore of dropped databases on Managed Instances.
* Deprecated from code old auditing cmdlets.
* Removed deprecated aliases:
* Get-AzSqlDatabaseIndexRecommendations (use Get-AzSqlDatabaseIndexRecommendation instead)
* Get-AzSqlDatabaseRestorePoints (use Get-AzSqlDatabaseRestorePoint instead)
* Remove Get-AzSqlDatabaseSecureConnectionPolicy cmdlet
* Remove aliases for deprecated Vulnerability Assessment Settings cmdlets
* Deprecate Advanced Threat Detection Settings cmdlets
* Adding cmdlets to Disable and enable sensitivity recommendations on columns in a database.

#### Az.Storage
* Support enable Large File share when create or update Storage account
    -  New-AzStorageAccount
    -  Set-AzStorageAccount
* When close/get File handle, skip check the input path is File directory or File, to avoid failure with object in DeletePending status
    -  Get-AzStorageFileHandle
    -  Close-AzStorageFileHandle

## 2.8.0 - October 2019
### General
* Az.HealthcareApis 1.0.0 release

#### Az.Accounts
* Update telemetry and url rewriting for generated modules, fix windows unit tests.

#### Az.ApiManagement
* **Set-AzApiManagementApi** - Added support for Updating Api into ApiVersionSet
    - Fix for issue https://github.com/Azure/azure-powershell/issues/10068

#### Az.Automation
* Fixed New-AzureAutomationSoftwareUpdateConfiguration cmdlet for Linux reboot setting parameter.

#### Az.Batch
* **Get-AzBatchNodeAgentSku** is deprecated and will be replaced by **Get-AzBatchSupportImage** in version 2.0.0.

#### Az.Compute
* Add Priority, EvictionPolicy, and MaxPrice parameters to New-AzVM and New-AzVmss cmdlets
* Fix warning message and help document for Add-AzVMAdditionalUnattendContent and Add-AzVMSshPublicKey cmdlets
* Fix -skipVmBackup exception for Linux VMs with managed disks for Set-AzVMDiskEncryptionExtension.
* Fix bug in update encryption settings in Set-AzVMDiskEncryptionExtension, two pass scenario.

#### Az.DataFactory
* Adding CRUD commands for ADF V2 data flow: Set-AzDataFactoryV2DataFlow, Remove-AzDataFactoryV2DataFlow, and Get-AzDataFactoryV2DataFlow.
* Adding action commands for ADF V2 data flow debug Session: Start-AzDataFactoryV2DataFlowDebugSession, Get-AzDataFactoryV2DataFlowDebugSession, Add-AzDataFactoryV2DataFlowDebugSessionPackage, Invoke-AzDataFactoryV2DataFlowDebugSessionCommand and Stop-AzDataFactoryV2DataFlowDebugSession.
* Update ADF .Net SDK version to 4.2.0

#### Az.DataLakeStore
* Fix account validation so that accounts with '-' can be passed without domain

#### Az.HealthcareApis
* Updated the powershell version to 1.0.0
* Updated the SDK version to 1.0.2
* Update in tests to refer to new SDK version
* Updated the output structure from nested to flattened.

#### Az.IotHub
* Add new routing source: DigitalTwinChangeEvents
* Minor bug fix: Get-AzIothub not returning subscriptionId

#### Az.Monitor
* New action group receivers added for action group
  -ItsmReceiver
  -VoiceReceiver
  -ArmRoleReceiver
  -AzureFunctionReceiver
  -LogicAppReceiver
  -AutomationRunbookReceiver
  -AzureAppPushReceiver
* Use common alert schema enabled for the receivers. This is not applicable for SMS, Azure App push , ITSM and Voice recievers
* Webhooks now supports Azure active directory authentication .

#### Az.Network
* Add new cmdlet Get-AzAvailableServiceAlias which can be called to get the aliases that can be used for Service Endpoint Policies.
* Added support for the adding traffic selectors to Virtual Network Gateway Connections
    - New cmdlets added:
        - New-AzureRmTrafficSelectorPolicy
    - Cmdlets updated with optional parameter -TrafficSelectorPolicies
        -New-AzVirtualNetworkGatewayConnection
        -Set-AzVirtualNetworkGatewayConnection
* Add support for ESP and AH protocols in network security rule configurations
    - Updated cmdlets:
        - Add-AzNetworkSecurityRuleConfig
        - New-AzNetworkSecurityRuleConfig
        - Set-AzNetworkSecurityRuleConfig
* Improve handling of exceptions in Cortex cmdlets
* New Generations and SKUs for VirtualNetworkGateways
  - Introduce new Generations for VirtualNetworkGateways.
  - Introduce new high throughput SKUs for VirtualNetworkGateways.

#### Az.RedisCache
* Updated 'Set-AzRedisCache' reference documentation to include missing values for '-Size' parameter

#### Az.Sql
* Add support for setting Active Directory Administrator on Managed Instance

#### Az.Storage
* Upgrade Storage Client Library to 11.1.0
* List containers with Management plane API, will list with NextPageLink
    -  Get-AzRmStorageContainer
* List Storage accounts from subscription, will list with NextPageLink
    -  Get-AzStorageAccount

#### Az.StorageSync
* Fix Issue 9810 in Reset-AzStorageSyncServerCertificate.

#### Az.Websites
* Set-AzWebApp updating ASP of an app was failing

## 2.7.0 - September 2019
#### Az.ApiManagement
* Update '-Format' parameter description in 'Set-AzApiManagementPolicy' reference documentation
* Removed references of deprecated cmdlet 'Update-AzApiManagementDeployment' from reference documentation. Use 'Set-AzApiManagement' instead.

#### Az.Automation
* Fixed example typo in reference documentation for 'Register-AzAutomationDscNode'
* Added clarification on OS restriction to Register-AzAutomationDSCNode
* Fixed Start-AzAutomationRunbook cmdlet Null reference exception for -Wait option.

#### Az.Compute
* Add UploadSizeInBytes parameter tp New-AzDiskConfig
* Add Incremental parameter to New-AzSnapshotConfig
* Add a low priority virtual machine feature:
    - MaxPrice, EvictionPolicy and Priority parameters are added to New-AzVMConfig.
    - MaxPrice parameter is added to New-AzVmssConfig, Update-AzVM and Update-AzVmss cmdlets.
* Fix VM reference issue for Get-AzAvailabilitySet cmdlet when it lists all availability sets in the subscription.
* Fix the null exception for Get-AzRemoteDesktopFile.
* Fix VHD Seek method for end-relative position.
* Fix UltraSSD issue for New-AzVM and Update-AzVM.

#### Az.DataFactory
* Adding 3 new commands for ADF V2 - Add-AzDataFactoryV2TriggerSubscription, Remove-AzDataFactoryV2TriggerSubscription, and Get-AzDataFactoryV2TriggerSubscriptionStatus
* Updated ADF .Net SDK version to 4.1.3

#### Az.HDInsight
* Call out breaking changes

#### Az.IotHub
* Add support to invoke failover for an IotHub to the geo-paired disaster recovery region.
* Add support to manage message enrichment for an IotHub. New cmdlets are:
  - Add-AzIotHubMessageEnrichment
  - Get-AzIotHubMessageEnrichment
  - Remove-AzIotHubMessageEnrichment
  - Set-AzIotHubMessageEnrichment

#### Az.Monitor
* Pointing to the most recent Monitor SDK, i.e. 0.24.1-preview
   - Adds non-braking changes to the Metrics cmdlets, i.e. the Unit enumeration supports several new values. These are read-only cmdlets, so there would be no change in the input of the cmdlets.
   - The api-version of the **ActionGroups** requests is now **2019-06-01**, before it was **2018-03-01**. The scenario tests have been updated to accommodate for this change.
   - The constructors for the classes **EmailReceiver** and **WebhookReceiver** added one new mandatory argument, i.e. a Boolean value called **useCommonAlertSchema**. Currently, the value is fixed to **false** to hide this breaking change from the cmdlets. **NOTE**: this is a temporary change that must be validated by the Alerts team.
   - The order of the arguments for the constructor of the class **Source** (related to the **ScheduledQueryRuleSource** class) changed from the previous SDK. This change required two unit tests to the be fixed: they compiled, but failed to pass the tests.
   - The order of the arguments for the constructor of the class **AlertingAction** (related to the **ScheduledQueryRuleSource** class) changed from the previous SDK. This change required two unit tests to the be fixed: they compiled, but failed to pass the tests.
* Support Dynamic Threshold criteria for metric alert V2
  - New-AzMetricAlertRuleV2Criteria: now creats dynamic threshold criteria also
  - Add-AzMetricAlertRuleV2: now accept dynamic threshold criteria also
* Improvements in Scheduled Query Rule cmdlets (SQR)
 - Cmdlets will accept 'Location' paramater in both formats, either the location (e.g. eastus) or the location display name (e.g. East US)
 - Illustrated 'Enabled' parameter in help files properly
 - Added examples for 'ActionGroup' optional parameter
 - Overall improved help files
* Fix bug in determining scope type for 'Set-AzActionRule'

#### Az.Network
* Fix incorrect example in 'New-AzApplicationGateway' reference documentation
* Add note in 'Get-AzNetworkWatcherPacketCapture' reference documentation about retrieving all properties for a packet capture
* Fixed example in 'Test-AzNetworkWatcherIPFlow' reference documentation to correctly enumerate NICs
* Improved cloud exception parsing to display additional details if they are present
* Improved cloud exception parsing to handle additional type of SDK exception
* Fixed incorrect mapping of Security Rule models
* Added properties to network interface for private ip feature
    - Added property 'PrivateEndpoint' as type of PSResourceId to PSNetworkInterface
    - Added property 'PrivateLinkConnectionProperties' as type of PSIpConfigurationConnectivityInformation to PSNetworkInterfaceIPConfiguration
    - Added new model class PSIpConfigurationConnectivityInformation
* Added new ApplicationRuleProtocolType 'mssql' for Azure Firewall resource
* MultiLink support in Virtual WAN
    - New cmdlets
        - New-AzVpnSiteLink
        - New-AzVpnSiteLinkConnection
    - Updated cmdlet:
        - New-VpnSite
        - Update-VpnSite
        - New-VpnConnection
        - Update-VpnConnection
* Fixed documents for some PowerShell examples to use Az cmdlets instead of AzureRM cmdlets

#### Az.RecoveryServices
* Update AzureVMpolicy Object with ProtectedItemsCount Attribute
* Added Tests for VM policy and Original Storage Account Restore

#### Az.Resources
* Fix bug where New-AzRoleAssignment could not be called without parameter Scope.

#### Az.ServiceFabric
* Fixed typo in example for 'Update-AzServiceFabricReliability' reference documentation
* Adding new cmdlets to manage appliaction and services:
    - New-AzServiceFabricApplication
    - New-AzServiceFabricApplicationType
    - New-AzServiceFabricApplicationTypeVersion
    - New-AzServiceFabricService
    - Update-AzServiceFabricApplication
    - Get-AzServiceFabricApplication
    - Get-AzServiceFabricApplicationType
    - Get-AzServiceFabricApplicationTypeVersion
    - Get-AzServiceFabricService
    - Remove-AzServiceFabricApplication
    - Remove-AzServiceFabricApplicationType
    - Remove-AzServiceFabricApplicationTypeVersion
    - Remove-AzServiceFabricServic
* Upgraded Service Fabric SDK to version 1.2.0 which uses service fabric resource provider api-version 2019-03-01.

#### Az.SignalR
* Add Update, Restart, CheckNameAvailability, GetUsage Cmdlets

#### Az.Sql
* Update example in reference documentation for 'Get-AzSqlElasticPool'
* Added vCore example to creating an elastic pool (New-AzSqlElasticPool).
* Remove the validation of EmailAddresses and the check that EmailAdmins is not false in case EmailAddresses is empty in Set-AzSqlServerAdvancedThreatProtectionPolicy and Set-AzSqlDatabaseAdvancedThreatProtectionPolicy
* Enabled removal of server/database auditing settings when multiple diagnostic settings that enable audit category exist.
* Fix email addresses validation in multiple Sql Vulnerability Assessment cmdlets (Update-AzSqlDatabaseVulnerabilityAssessmentSetting, Update-AzSqlServerVulnerabilityAssessmentSetting, Update-AzSqlInstanceDatabaseVulnerabilityAssessmentSetting and Update-AzSqlInstanceVulnerabilityAssessmentSetting).

#### Az.Storage
* Updated example in reference documentation for 'Get-AzStorageAccountKey'
* In upload/Downalod Azure File,support perserve the source File SMB properties (File Attributtes, File Creation Time, File Last Write Time) in the destination file
    -  Set-AzStorageFileContent
    -  Get-AzStorageFileContent
* Fix Upload block blob with properties/metadate fail on container enabled ImmutabilityPolicy.
    -  Set-AzStorageBlobContent
* Support manage Azure File shares with Management plane API
    -  New-AzRmStorageShare
    -  Get-AzRmStorageShare
    -  Update-AzRmStorageShare
    -  Remove-AzRmStorageShare

#### Az.Websites
* Fixing issue where webapp Tags were getting deleted when migrating App to new ASPwhere webapp Tags were getting deleted when migrating App to new ASP
* Fixing the Publish-AzureWebapp to work across Linux and windows
* Update example in 'Get-AzWebAppPublishingProfile' reference documentation

## 2.6.0 - August 2019
#### General
* Fixed miscellaneous typos across numerous modules

#### Az.Accounts
* Added support for user-assigned MSI in Azure Functions authentication (#9479)

#### Az.Aks
* Fixed issue with output for 'Get-AzAks' ([#9847](https://github.com/Azure/azure-powershell/issues/9847))

#### Az.ApiManagement
* Fixed issue with whitespace in `productId`, `apiId`, `groupId`, `userId` ([#9351](https://github.com/Azure/azure-powershell/issues/9351))
* **Get-AzApiManagementProduct** - Added support for querying products using API ([#9482](https://github.com/Azure/azure-powershell/issues/9482))
* **New-AzApiManagementApiRevision** - Fixed issue where ApiRevisionDescription was not set when creating new API revision ([#9752](https://github.com/Azure/azure-powershell/issues/9752))
* Fixed typo in model `PsApiManagementOAuth2AuthrozationServer` to `PsApiManagementOAuth2AuthorizationServer`

#### Az.Batch
* Fixed typos in help message and documentation

#### Az.Cdn
* Fixed a typo in CDN module conversion helper

#### Az.Compute
* Added VmssId to **New-AzVMConfig** cmdlet
* Added `TerminateScheduledEvents` and `TerminateScheduledEventNotBeforeTimeoutInMinutes` parameters to **New-AzVmssConfig** and **Update-AzVmss**
* Added `HyperVGeneration` property to VM image object
* Added Host and HostGroup features
  - New cmdlets:
    - **New-AzHostGroup**
    - **New-AzHost**
    - **Get-AzHostGroup**
    - **Get-AzHost**
    - **Remove-AzHostGroup**
    - **Remove-AzHost**
  - Added `HostId` parameter to **New-AzVMConfig** and **New-AzVM**
* Updated example in **Invoke-AzVMRunCommand** documentation to use correct parameter name
* Updated `-VolumeType` description in **Set-AzVMDiskEncryptionExtension** and **Set-AzVmssDiskEncryptionExtension** reference documentation

#### Az.DataFactory
* Fixed typos in **New-AzDataFactoryEncryptValue** documentation
* Updated ADF .Net SDK version to 4.1.2
* Added parameters to **Set-AzureRmDataFactoryV2IntegrationRuntime** to enable Self-Hosted Integration Runtime as a proxy for SSIS Integration Runtime:
  - `DataProxyIntegrationRuntimeName`
  - `DataProxyStagingLinkedServiceName`
  - `DataProxyStagingPath`
* Updated **PSTriggerRun** to show the triggered pipelines, message and properties, and **PSActivityRun** to show the activity type

#### Az.DataLakeStore
* Fixed issue where **Get-DataLakeStoreDeletedItem** would hang on errors and remote exceptions

#### Az.EventHub
* Fixed typo `VirtualNteworkRule` in Set-AzEventHubNetworkRuleSet ([#9658](https://github.com/azure/azure-powershell/issues/9658))
* Fixed issue where Set-AzEventHubNamespace used PATCH instead of PUT ([#9558](https://github.com/azure/azure-powershell/issues/9558))
* Added `EnableKafka` parameter to **Set-AzEventHubNamespace** cmdlet
* Fixed issue with creating rules with `Listen` rights ([#9786](https://github.com/azure/azure-powershell/issues/9786))

#### Az.MarketplaceOrdering
* Fixed documentation typos

#### Az.Monitor
* Fixed incorrect parameter name in help documentation

#### Az.Network
* Updated **New-AzPrivateLinkServiceIpConfig**:
  - Deprecated the parameter `PublicIpAddress` since this is never used in the server side.
  - Added optional parameter `Primary` that indicates if the current IP configuration is the primary one
* Improved handling of request error exception from SDK
* Fixed validation logic for Ipv6 IP Prefix to check for correct IPv6 prefix length
* Added parameter set to get by subnet resource id to **Get-AzVirtualNetworkSubnetConfig**
* Updated description of **Location** parameter for **AzNetworkServiceTag**

#### Az.OperationalInsights
* Updated documentation for **New-AzOperationalInsightsLinuxSyslogDataSource**:
  - Added example
  - Updated description for `-Name` parameter
* Added an example for **New-AzOperationalInsightsWindowsEventDataSource**
* Changed the description of the `-Name` parameter for **New-AzOperationalInsightsWindowsEventDataSource**

#### Az.RecoveryServices
* Updated documentation for **Get-AzRecoveryServicesBackupJobDetail**

#### Az.Resources
* Added support for new API version 2019-05-10 for Microsoft.Resource
  - Add support for 'copy.count = 0' for variables, resources and properties
  - Resources with 'condition = false' or 'copy.count = 0' will be deleted in complete mode
* Added an example of assigning policy at the subscription level

#### Az.ServiceBus
* Fixed typo `VirtualNetworkRule` parameter in **Set-AzServiceBusNetworkRuleSet** Fix for issue #9658 : Typo
* Fixed issue with creating `Listen`-only rules ([#9786](https://github.com/azure/azure-powershell/issues/9786))
* Added new command **Test-AzServiceBusNameAvailability** to check the name availability for queue and topic

#### Az.ServiceFabric
* Fixed NullReferenceException when a resource group has a VMSS not related to the service fabric cluster ([#8681](https://github.com/Azure/azure-powershell/issues/8681))
* Fixed bug where cmdlets failed if virtualNetwork was in a different resource group than the cluster ([#8407](https://github.com/Azure/azure-powershell/issues/8407))
* Deprecated **Add-AzServiceFabricApplicationCertificate** cmdlet

#### Az.Sql
* Updated documentation for old Auditing cmdlets

#### Az.Storage
* Updated help for **Close-AzStorageFileHandle** and **Get-AzStorageFileHandle**,  added more scenarios to cmdlet examples and updated parameter descriptions
* Added support for `StandardBlobTier` in blob uploads and copies
* Added support for `Rehydrate` priority in blob copy

#### Az.Websites
* Added clarification around `-AppSettings` parameter for **Set-AzWebApp** and **Set-AzWebAppSlot**

## 2.5.0 - July 2019
#### Az.Accounts
* Update common code to use latest version of ClientRuntime

#### Az.ApplicationInsights
* Fix example typo in 'Remove-AzApplicationInsightsApiKey' documentation

#### Az.Automation
* Fix typo in resource string

#### Az.CognitiveServices
* Added NetworkRuleSet support.

#### Az.Compute
* Add missing properties (ComputerName, OsName, OsVersion and HyperVGeneration) of VM instance view object.

#### Az.ContainerRegistry
* Fix typo in Remove-AzContainerRegistryReplication for Replication parameter
    - More information here https://github.com/Azure/azure-powershell/issues/9633

#### Az.DataFactory
* Updated ADF .Net SDK version to 4.1.0
* Fix typo in documentation for 'Get-AzDataFactoryV2PipelineRun'

#### Az.EventHub
* Added new cmmdlet added for generating SAS token : New-AzEventHubAuthorizationRuleSASToken
* added verification and error message for authorizationrules rights if only 'Manage' is assigned

#### Az.KeyVault
* Added support to specify the KeySize for Certificate Policies

#### Az.LogicApp
* Fix for Get-AzIntegrationAccountMap to list all map types
  - Added new MapType parameter for filtering

#### Az.ManagedServices
* Added support for api version 2019-06-01 (GA)

#### Az.Network
* Add support for private endpoint and private link service
    - New cmdlets
        - Set-AzPrivateEndpoint
        - Set-AzPrivateLinkService
        - Approve-AzPrivateEndpointConnection
        - Deny-AzPrivateEndpointConnection
        - Get-AzPrivateEndpointConnection
        - Remove-AzPrivateEndpointConnection
        - Test-AzPrivateLinkServiceVisibility
        - Get-AzAutoApprovedPrivateLinkService
* Updated below commands for feature: PrivateEndpointNetworkPolicies/PrivateLinkServiceNetworkPolicies flag on Subnet in Virtualnetwork
    - Updated New-AzVirtualNetworkSubnetConfig/Set-AzVirtualNetworkSubnetConfig/Add-AzVirtualNetworkSubnetConfig
        - Added optional parameter -PrivateEndpointNetworkPoliciesFlag to indicate that enable or disable apply network policies on pivate endpoint in this subnet.
        - Added optional parameter -PrivateLinkServiceNetworkPoliciesFlag to indicate that enable or disable apply network policies on private link service in this subnet.
* AzPrivateLinkService's cmdlet parameter 'ServiceName' was renamed to 'Name' with an alias 'ServiceName' for backward compatibility
* Enable ICMP protocol for network security rule configurations
    - Updated cmdlets
        - Add-AzNetworkSecurityRuleConfig
        - New-AzNetworkSecurityRuleConfig
        - Set-AzNetworkSecurityRuleConfig
* Add ConnectionProtocolType (Ikev1/Ikev2) as a configurable parameter for New-AzVirtualNetworkGatewayConnection
* Add PrivateIpAddressVersion in LoadBalancerFrontendIpConfiguration
    - Updated cmdlet:
        - New-AzLoadBalancerFrontendIpConfig
        - Add-AzLoadBalancerFrontendIpConfig
        - Set-AzLoadBalancerFrontendIpConfig
* Application Gateway New-AzApplicationGatewayProbeConfig command update for supporting custom port in Probe
    - Updated New-AzApplicationGatewayProbeConfig: Added optional parameter Port which is used for probing backend server. This parameter is applicable for Standard_V2 and WAF_V2 SKU.

#### Az.OperationalInsights
* Updated default version for saved searches to be 1.
* Fixed custom log null regex handling

#### Az.RecoveryServices
* Update 'Get-AzRecoveryServicesBackupJob.md'
* Update 'Get-AzRecoveryServicesBackupContainer.md'
* Update 'Get-AzRecoveryServicesVault.md'
* Update 'Wait-AzRecoveryServicesBackupJob.md'
* Update 'Set-AzRecoveryServicesVaultContext.md'
* Update 'Get-AzRecoveryServicesBackupItem.md'
* Update 'Get-AzRecoveryServicesBackupRecoveryPoint.md'
* Update 'Restore-AzRecoveryServicesBackupItem.md'
* Updated service call for Unregistering container for Azure File Share
* Update 'Set-AzRecoveryServicesAsrAlertSetting.md'

#### Az.Resources
- Remove missing cmdlet referenced in 'New-AzResourceGroupDeployment' documentation
- Updated policy cmdlets to use new api version 2019-01-01

#### Az.ServiceBus
* Added new cmmdlet added for generating SAS token : New-AzServiceBusAuthorizationRuleSASToken
* added verification and error message for authorizationrules rights if only 'Manage' is assigned

#### Az.Sql
* Fix missing examples for Set-AzSqlDatabaseSecondary cmdlet
* Fix set Vulnerability Assessment recurring scans without providing any email addresses
* Fix a small typo in a warining message.

#### Az.Storage
* Update example in reference documentation for 'Get-AzStorageAccount' to use correct parameter name

#### Az.StorageSync
* Adding Invoke-AzStorageSyncChangeDetection cmdlet.
* Fix Issue 9551 for honoring TierFilesOlderThanDays

#### Az.Websites
* Fixing a bug where some SiteConfig properties were not returned by Get-AzWebApp and Set-AzWebApp
* Adds a new Location parameter to Get-AzDeletedWebApp and Restore-AzDeletedWebApp
* Fixes a bug with cloning web app slots using New-AzWebApp -IncludeSourceWebAppSlots

## 2.4.0 - July 2019
#### Az.Accounts
* Add support for profile cmdlets
* Add support for environments and data planes in generated cmdlets
* Fix bug where incorrect endpoint was being used in some cases for data plane cmdlets in Windows PowerShell

#### Az.Advisor
* GA release of `Az.Advisor`
* This module is now included as a part of the roll-up `Az` module

#### Az.ApiManagement
* Fix for issue https://github.com/Azure/azure-powershell/issues/8671
    - **Get-AzApiManagementSubscription**
        - Added support for querying subscriptions by User and Product
        - Added support for querying using Scope '/', '/apis', '/apis/echo-api'
* Fix for issue https://github.com/Azure/azure-powershell/issues/9307 and https://github.com/Azure/azure-powershell/issues/8432
    - **Import-AzApiManagementApi**
        - Added support for specifiying 'ApiVersion' and 'ApiVersionSetId' when importing Apis

#### Az.Automation
* Fixed Set-AzAutomationConnectionFieldValue cmdlet bug to handle string value.

#### Az.Compute
* Add HyperVGeneration parameter to New-AzImageConfig

#### Az.DataFactory
* Updating the output of get activity runs, get pipeline runs, and get trigger runs ADF cmdlets to support Select-Object pipe.

#### Az.EventGrid
* Fix typo in 'New-AzEventGridSubscription' documentation

#### Az.IotHub
* Add support to regenerate authorization policy keys.

#### Az.Network
* Added 'RoutingPreference' to public ip tags
* Improve examples for 'Get-AzNetworkServiceTag' reference documentation

#### Az.PolicyInsights
* Fix null reference issue in Get-AzPolicyState
    - More information here: https://github.com/Azure/azure-powershell/issues/9446

#### Az.OperationalInsights
* Fixed CustomLog datasource model returned in Get-AzOperationalInsightsDataSource

#### Az.RecoveryServices
* Fix for get-policy command for IaaSVMs

#### Az.Resources
    - Fix help text for Get-AzPolicyState -Top parameter
    - Add client-side paging support for Get-AzPolicyAlias
    - Add new parameters for Set-AzPolicyAssignment, -PolicyParameters and -PolicyParametersObject
    - Handful of doc and example updates for Policy cmdlets

#### Az.ServiceBus
* Fix for issue #4938 - New-AzServiceBusQueue returns BadRequest when setting MaxSizeInMegabytes

#### Az.Sql
* Add Instance Failover Group cmdlets from preview release to public release
* Support Azure SQL Server\Database Auditing with new cmdlets.
    - Set-AzSqlServerAudit
    - Get-AzSqlServerAudit
    - Remove-AzSqlServerAudit
    - Set-AzSqlDatabaseAudit
    - Get-AzSqlDatabaseAudit
    - Remove-AzSqlDatabaseAudit
* Remove email constraints from Vulnerability Assessment settings

#### Az.Storage
* Change 2 parameters '-IndexDocument' and '-ErrorDocument404Path' from required to optional  in cmdlet:
    -  Enable-AzStorageStaticWebsite
* Update help of Get-AzStorageBlobContent by add an example
* Show more error information when cmdlet failed with StorageException
* Support create or update Storage account with Azure Files AAD DS Authentication
    -  New-AzStorageAccount
    -  Set-AzStorageAccount
* Support list or close file handles of a file share, file directory or a file
    - Get-AzStorageFileHandle
    - Close-AzStorageFileHandle

#### Az.StorageSync
* This module is now included as a part of the roll-up `Az` module

## 2.3.2 - June 2019
#### Az.Accounts
* Fix bug with incorrect URL being used in some cases for Functions calls
    - More information here: https://github.com/Azure/azure-powershell/issues/8983
* Fix Issue with aliases from AzureRM to Az cmdlets
  - Set-AzureRmVMBootDiagnostics -> Set-AzVMBootDiagnostic
  - Export-AzureRMLogAnalyticThrottledRequests -> Export-AzLogAnalyticThrottledRequest

#### Az.Compute
* New-AzVm and New-AzVmss simple parameter sets now accept the 'ProximityPlacementGroup' parameter.
* Fix typo in 'New-AzVM' reference documentation

#### Az.Dns
* Fixed a typo in 'Set-AzDnsZone' help examples.

#### Az.EventGrid
* Updated to use the 2019-06-01 API version.
* New cmdlets:
    - New-AzEventGridDomain
        - Creates a new Azure Event Grid Domain.
    - Get-AzEventGridDomain
        - Gets the details of an Event Grid Domain, or gets a list of all Event Grid Domains in the current Azure subscription.
    - Remove-AzEventGridDomain
        - Removes an Azure Event Grid Domain.
    - New-AzEventGridDomainKey
        - Regenerates the shared access key for an Azure Event Grid Domain.
    - Get-AzEventGridDomainKey
        - Gets the shared access keys used to publish events to an Event Grid Domain.
    - New-AzEventGridDomainTopic:
        - Creates a new Azure Event Grid Domain Topic.
    - Get-AzEventGridDomainTopic
        - Gets the details of an Event Grid Domain Topic, or gets a list of all Event Grid Domain Topics under specific Event Grid Domain in the current Azure
    - Remove-AzEventGridDomainTopic:
        - Removes an existing Azure Event Grid Domain Topic.
* Updated cmdlets:
    - New-AzEventGridSubscription/Update-AzEventGridSubscription:
        - Add new mandatory parameters to support piping for the new Event Grid Domain and Event Grid Domain Topic to allow creating new event subscription under these resources.
        - Add new mandatory parameters for specifying the new Event Grid Domain name and/or Event Grid Domain Topic name to allow creating new event subscription under these resources.
        - Add new Parameter sets for domains and domain topics to allow reusing existing parameters (e.g., EndPointType, SubjectBeginsWith, etc).
        - Add new optional parameters for specifying:
            - Event subscription expiration date,
            - Advanced filtering parameters.
        - Add new enum for servicebusqueue as destination.
        - Disallow usage of 'All' in -IncludedEventType option and replace it with
    - Get-AzEventGridTopic, Get-AzEventGridDomain, Get-AzEventGridDomainTopic, Get-AzEventGridSubscription:
        - Add new optional parameters (Top, ODataQuery and NextLink) to support results pagination and filtering.
    - Remove-AzEventGridSubscription
        - Add new mandatory parameters to support piping for Event Grid Domain and Event Grid Domain Topic to allow removing existing event subscription under these resources.
        - Add new mandatory parameters for specifying the Event Grid Domain name and/or Event Grid Domain Topic name to allow removing existing event subscription under these resources.

#### Az.FrontDoor
* New-AzFrontDoorWafMatchConditionObject
    - Add transforms support and new operator auto-complete value (RegEx)
* New-AzFrontDoorWafManagedRuleObject
    - Add new auto-complete values

#### Az.Network
* Add support for Virtual Network Gateway Resource
    - New cmdlets
        - Get-AzVirtualNetworkGatewayVpnClientConnectionHealth
* Add AvailablePrivateEndpointType
    - New cmdlets
        - Get-AzAvailablePrivateEndpointType
* Add PrivatePrivateLinkService
    - New cmdlets
        - Get-AzPrivateLinkService
        - New-AzPrivateLinkService
        - Remove-AzPrivateLinkService
        - New-AzPrivateLinkServiceIpConfig
        - Set-AzPrivateEndpointConnection
* Add PrivateEndpoint
    - New cmdlets
        - Get-AzPrivateEndpoint
        - New-AzPrivateEndpoint
        - Remove-AzPrivateEndpoint
        - New-AzPrivateLinkServiceConnection
* Updated below commands for feature: UseLocalAzureIpAddress flag on VpnConnection
    - Updated New-AzVpnConnection: Added optional parameter -UseLocalAzureIpAddress to indicate that local azure ip address should be used as source address while initiating connection.
    - Updated Set-AzVpnConnection: Added optional parameter -UseLocalAzureIpAddress to indicate that local azure ip address should be used as source address while initiating connection.
* Added readonly field PeeredConnections in ExpressRoute peering.
* Added readonly field GlobalReachEnabled in ExpressRoute.
* Added breaking change attribute to call out deprecation of AllowGlobalReach field in ExpressRouteCircuit model
* Fixed Issue 8756 Error using TargetListenerID with AzApplicationGatewayRedirectConfiguration cmdlets
* Fixed bug in New-AzApplicationGatewayPathRuleConfig that prevented the rewrite ruleset from being set.
* Fixed displaying of VirtualNetworkTaps in NetworkInterfaceIpConfiguration
* Fixed Cortex Get cmdlets for list all part
* Fixed VirtualHub reference creation for ExpressRouteGateways, VpnGateway
* Added support for Availability Zones in AzureFirewall and NatGateway
* Added cmdlet Get-AzNetworkServiceTag
* Add support for multiple public IP addresses for Azure Firewall
    - Updated New-AzFirewall cmdlet:
        - Added parameter -PublicIpAddress which accepts one or more Public IP Address objects
        - Added parameter -VirtualNetwork which accepts a Virtual Network object
        - Added methods AddPublicIpAddress and RemovePublicIpAddress on firewall object - these accept a Public IP Address object as input
        - Deprecated parameters -PublicIpName and -VirtualNetworkName
* Updated below commands for feature: Set VpnClient AAD authentication options to Virtual network gateway resource.
    - Updated New-AzVirtualNetworkGateway: Added optional parameters AadTenantUri,AadAudienceId,AadIssuerUri to set VpnClient AAD authentication options on Gateway.
    - Updated Set-AzVirtualNetworkGateway: Added optional parameter AadTenantUri,AadAudienceId,AadIssuerUri to set VpnClient AAD authentication options on Gateway.
    - Updated Set-AzVirtualNetworkGateway: Added optional switch parameter RemoveAadAuthentication to remove VpnClient AAD authentication options from Gateway.

#### Az.OperationalInsights
* Enable **pergb2018** pricing tier in 'New-AzOperationalInsightsWorkspace' command

#### Az.Resources
* Support for additional Template Export options
    - Add '-SkipResourceNameParameterization' parameter to Export-AzResourceGroup
    - Add '-SkipAllParameterization' parameter to Export-AzResourceGroup
    - Add '-Resource' parameter to Export-AzResourceGroup for exported resource filtering

#### Az.ServiceFabric
* Fix add certificate ByExistingKeyVault getting the wrong thumbprint in some cases

#### Az.Sql
* Fix Advanced Threat Protection storage endpoint suffix
* Fix Advanced Data Security enable overrides Advanced Threat Protection policy
* New Cmdlets for Management.Sql to allow customers to add TDE keys and set TDE protector for managed instances
   - Add-AzSqlInstanceKeyVaultKey
   - Get-AzSqlInstanceKeyVaultKey
   - Remove-AzSqlInstanceKeyVaultKey
   - Get-AzSqlInstanceTransparentDataEncryptionProtector
   - Set-AzSqlInstanceTransparentDataEncryptionProtector

#### Az.Storage
* Support Kind FileStorage and SkuName Premium_ZRS when create Storage account
    - New-AzStorageAccount
* Clarified description of blob immutability cmdlet
    -  Remove-AzRmStorageContainerImmutabilityPolicy

#### Az.Websites
* Optimizes Get-AzWebAppCertificate to filter by resource group on the server instead of the client
* Adds -UseDisasterRecovery switch parameter to Get-AzWebAppSnapshot

## 2.2.0 - June 2019
#### Az.Cdn
* Updated cmdlets to support rulesEngine feature based on API version 2019-04-15.

#### Az.Compute
* Added `NoWait` parameter that starts the operation and returns immediately, before the operation is completed.
    - Updated cmdlets:
        Export-AzLogAnalyticRequestRateByInterval
        Export-AzLogAnalyticThrottledRequest
        Remove-AzVM
        Remove-AzVMAccessExtension
        Remove-AzVMAEMExtension
        Remove-AzVMChefExtension
        Remove-AzVMCustomScriptExtension
        Remove-AzVMDiagnosticsExtension
        Remove-AzVMDiskEncryptionExtension
        Remove-AzVMDscExtension
        Remove-AzVMSqlServerExtension
        Restart-AzVM
        Set-AzVM
        Set-AzVMAccessExtension
        Set-AzVMADDomainExtension
        Set-AzVMAEMExtension
        Set-AzVMBginfoExtension
        Set-AzVMChefExtension
        Set-AzVMCustomScriptExtension
        Set-AzVMDiagnosticsExtension
        Set-AzVMDscExtension
        Set-AzVMExtension
        Start-AzVM
        Stop-AzVM
        Update-AzVM

#### Az.EventHub
* Fix for #9231 - Get-AzEventHubNamespace does not return tags
* Fix for #9230 - Get-AzEventHubNamespace returns ResourceGroup instead of ResourceGroupName

#### Az.Network
* Update ResourceId and InputObject for Nat Gateway
    - Add alias for ResourceId and InputObject

#### Az.PolicyInsights
* Fix Null reference issue in Get-AzPolicyEvent

#### Az.RecoveryServices
* IaaSVM policy minimum retention in days changed to 7 from 1

#### Az.ServiceBus
* Fix for issue #9182 - Get-AzServiceBusNamespace returns ResourceGroup instead of ResourceGroupName

#### Az.ServiceFabric
* Fix typo in error message for 'Update-AzServiceFabricReliability'
* Fix missing character in Service Fabric cmdlines

#### Az.Sql
* Add DnsZonePartner Parameter for New-AzureSqlInstance cmdlet to support AutoDr for Managed Instance.
* Deprecating Get-AzSqlDatabaseSecureConnectionPolicy cmdlet
* Rename Threat Detection cmdlets to Advanced Threat Protection
* New-AzSqlInstance -StorageSizeInGB and -LicenseType parameters are now optional.

#### Az.Websites
* fixes the issue where using  Set-AzWebApp and Set-AzWebAppSlot with -WebApp property was removing the tags

## 2.1.0 - May 2019
#### Az.ApiManagement
* Created new Cmdlets for managing diagnostics at the global and API Scope
    - **Get-AzApiManagementDiagnostic** - Get the diagnostics configured a global or api Scope
    - **New-AzApiManagementDiagnostic** - Create new diagnostics at the global scope or api Scope
    - **New-AzApiManagementHttpMessageDiagnostic** - Create diagnostic setting for which Headers to log and the size of Body Bytes
    - **New-AzApiManagementPipelineDiagnosticSetting** - Create Diagnostic settings for incoming/outgoing HTTP messages to the Gateway.
    - **New-AzApiManagementSamplingSetting** - Create Sampling Setting  for the requests/response for a diagnostic
    - **Remove-AzApiManagementDiagnostic** - Remove a diagnostic entity at global or api scope
    - **Set-AzApiManagementDiagnostic** - Update a diagnostic Entity at global or api scope
* Created new Cmdlets for managing Cache in ApiManagement service
    - **Get-AzApiManagementCache** - Get the details of the Cache specified by identifier or all caches
    - **New-AzApiManagementCache** - Create a new 'default' Cache or Cache in a particular azure 'region'
    - **Remove-AzApiManagementCache** - Remove a cache
    - **Update-AzApiManagementCache** - Update a cache
* Created new Cmdlets for managing API Schema
    - **New-AzApiManagementSchema** - Create a new Schema for an API
    - **Get-AzApiManagementSchema** - Get the schemas configured in the API
    - **Remove-AzApiManagementSchema** - Remove the schema configured in the API
    - **Set-AzApiManagementSchema** - Update the schema configured in the API
* Created new Cmdlet for generating a User Token.
    - **New-AzApiManagementUserToken** - Generate a new User Token valid for 8 hours by default.Token for the 'GIT' user can be generated using this cmdlet./
* Created a new cmdlet to retrieving the Network Status
    - **Get-AzApiManagementNetworkStatus** - Get the Network status connectivity of resources on which API Management service depends on. This is useful when deploying ApiManagement service into a Virtual Network and validing whether any of the dependencies are broken.
* Updated cmdlet **New-AzApiManagement** to manage ApiManagement service
    - Added support for the new 'Consumption' SKU
    - Added support to turn the 'EnableClientCertificate' flag on for 'Consumption' SKU
    - The new cmdlet **New-AzApiManagementSslSetting** allows configuring 'TLS/SSL' setting on the 'Backend' and 'Frontend'. This can also be used to configure 'Ciphers' like '3DES' and 'ServerProtocols' like 'Http2' on the 'Frontend' of an ApiManagement service.
    - Added support for configuring the 'DeveloperPortal' hostname on ApiManagement service.
* Updated cmdlets **Get-AzApiManagementSsoToken** to take 'PsApiManagement' object as input
* Updated the cmdlet to display Error Messages inline
     - `PS D:\github\azure-powershell> Set-AzApiManagementPolicy -Context  -PolicyFilePath C:\wrongpolicy.xml -ApiId httpbin`
       - `Set-AzApiManagementPolicy :`
       - `Error Code: ValidationError`
       - `Error Message: One or more fields contain incorrect values:`
       - `Error Details: [Code=ValidationError, Message=Error in element 'log-to-eventhub' on line 3, column 10: Logger not found, Target=log-to-eventhub]`
* Updated cmdlet **Export-AzApiManagementApi** to export APIs in 'OpenApi 3.0' format
* Updated cmdlet **Import-AzApiManagementApi**
    - To import Api from 'OpenApi 3.0' document specification
    - To override the 'PsApiManagementSchema' property specified in any ('Swagger', 'Wadl', 'Wsdl', 'OpenApi') document.
    - To override the 'ServiceUrl' property specified in any document.
* Updated cmdlet **Get-AzApiManagementPolicy** to return policy in Non-Xml escaped 'format' using 'rawxml'
* Updated cmdlet **Set-AzApiManagementPolicy** to accept policy in Non-Xml escaped 'format' using 'rawxml' and Xml escaped using 'xml'
* Updated cmdlet **New-AzApiManagementApi**
    - To configure API with 'OpenId' authorization server.
    - To create an API in an 'ApiVersionSet'
    - To clone an API using 'SourceApiId' and 'SourceApiRevision'.
    - Ability to configure 'SubscriptionRequired' at the Api scope.
* Updated cmdlet **Set-AzApiManagementApi**
    - To configure API with 'OpenId' authorization server.
    - To updated an API into an 'ApiVersionSet'
    - Ability to configure 'SubscriptionRequired' at the Api scope.
* Updated cmdlet **New-AzApiManagementRevision**
    - To clone (copy tags, products, operations and policies) an existing revision using 'SourceApiRevision'. The new Revision assumes the 'ApiId' of the parent.
    - To provide an 'ApiRevisionDescription'
    - To override the 'ServiceUrl' when cloning an API.
* Updated cmdlet **New-AzApiManagementIdentityProvider**
    - To configure 'AAD' or 'AADB2C' with an 'Authority'
    - To setup 'SignupPolicy', 'SigninPolicy', 'ProfileEditingPolicy' and 'PasswordResetPolicy'
* Updated cmdlet **New-AzApiManagementSubscription**
    - To account for the new SubscriptonModel using 'Scope' and 'UserId'
    - To account for the old subscription model using 'ProductId' and 'UserId'
    - Add support to enable 'AllowTracing' at the subscription level.
* Updated cmdlet **Set-AzApiManagementSubscription**
    - To account for the new SubscriptonModel using 'Scope' and 'UserId'
    - To account for the old subscription model using 'ProductId' and 'UserId'
    - Add support to enable 'AllowTracing' at the subscription level.
* Updated following cmdlets to accept 'ResourceId' as input
    - 'New-AzApiManagementContext'
      - `New-AzApiManagementContext -ResourceId /subscriptions/subid/resourceGroups/rgName/providers/Microsoft.ApiManagement/service/contoso`
    - 'Get-AzApiManagementApiRelease'
      - `Get-AzApiManagementApiRelease -ResourceId /subscriptions/subid/resourceGroups/rgName/providers/Microsoft.ApiManagement/service/contoso/apis/echo-api/releases/releaseId`
    - 'Get-AzApiManagementApiVersionSet'
      - `Get-AzApiManagementApiVersionSet -ResourceId /subscriptions/subid/resourceGroups/rgName/providers/Microsoft.ApiManagement/service/constoso/apiversionsets/pathversionset`
    - 'Get-AzApiManagementAuthorizationServer'
    - 'Get-AzApiManagementBackend'
      - `Get-AzApiManagementBackend -ResourceId /subscriptions/subid/resourceGroups/rgName/providers/Microsoft.ApiManagement/service/contoso/backends/servicefabric`
    - 'Get-AzApiManagementCertificate'
    - 'Remove-AzApiManagementApiVersionSet'
    - 'Remove-AzApiManagementSubscription'

#### Az.Automation
* Updated Get-AzAutomationJobOutputRecord to handle JSON and Text record values.
    - Fix for issue https://github.com/Azure/azure-powershell/issues/7977
    - Fix for issue https://github.com/Azure/azure-powershell/issues/8600
* Changed behavior for Start-AzAutomationDscCompilationJob to just start the job instead of waiting for its completion.
    * Fix for issue https://github.com/Azure/azure-powershell/issues/8347
* Fix for Get-AzAutomationDscNode when using -Name returns all node. Now it returns matching node only.

#### Az.Compute
* Add ProtectFromScaleIn and ProtectFromScaleSetAction parameters to Update-AzVmssVM cmdlet.
* New-AzVM wimple parameter set now uses by default an available location if 'East US' is not supported

#### Az.DataLakeStore
* Update the ADLS sdk to use httpclient, integrate dataplane testing with azure framework

#### Az.Monitor
* Fixed incorrect parameter names in help examples

#### Az.Network
* Add DisableBgpRoutePropagation flag to Effective Route Table output
    - Updated cmdlet:
        - Get-AzEffectiveRouteTable
* Fix double dash in New-AzApplicationGatewayTrustedRootCertificate documentation

#### Az.Resources
* Add new cmdlet Get-AzDenyAssignment for retrieving deny assignments

#### Az.Sql
* Rename Advanced Threat Protection cmdlets to Advanced Data Security and enable Vulnerability Assessment by default

## 2.0.0 - May 2019
#### Az.Accounts
* Update Authentication Library to fix ADFS issues with username/password auth

#### Az.CognitiveServices
* Only display Bing disclaimer for Bing Search Services.
* Improve error when create account failed.

#### Az.Compute
* Proximity placement group feature.
    - The following new cmdlets are added:
      New-AzProximityPlacementGroup
    Get-AzProximityPlacementGroup
    Remove-AzProximityPlacementGroup
  - The new parameter, ProximityPlacementGroupId, is added to the following cmdlets:
      New-AzAvailabilitySet
    New-AzVMConfig
    New-AzVmssConfig
* StorageAccountType parameter is added to New-AzGalleryImageVersion.
* TargetRegion of New-AzGalleryImageVersion can contain StorageAccountType.
* SkipShutdown switch parameter is added to Stop-AzVM and Stop-AzVmss
* Breaking changes
    - Set-AzVMBootDiagnostics is changed to Set-AzVMBootDiagnostic.
    - Export-AzLogAnalyticThrottledRequests is changed to Export-AzLogAnalyticThrottledRequests.

#### Az.DeploymentManager
* First Generally Available release of Azure Deployment Manager cmdlets

#### Az.Dns
* Automatic DNS NameServer Delegation
    - Create DNS zone cmdlet accepts parent zone name as additional optional parameter.
    - Adds NS records in the parent zone for newly created child zone.

#### Az.FrontDoor
* First Generally Available Release of Azure FrontDoor cmdlets
* Rename WAF cmdlets to include 'Waf'
    - `Get-AzFrontDoorFireWallPolicy --> Get-AzFrontDoorWafPolicy`
    - `New-AzFrontDoorCustomRuleObject --> New-AzFrontDoorWafCustomRuleObject`
    - `New-AzFrontDoorFireWallPolicy --> New-AzFrontDoorWafPolicy`
    - `New-AzFrontDoorManagedRuleObject --> New-AzFrontDoorWafManagedRuleObject`
    - `New-AzFrontDoorManagedRuleOverrideObject --> New-AzFrontDoorWafManagedRuleOverrideObject`
    - `New-AzFrontDoorMatchConditionObject --> New-AzFrontDoorWafMatchConditionObject`
    - `New-AzFrontDoorRuleGroupOverrideObject --> New-AzFrontDoorWafRuleGroupOverrideObject`
    - `Remove-AzFrontDoorFireWallPolicy --> Remove-AzFrontDoorWafPolicy`
    - `Update-AzFrontDoorFireWallPolicy --> Update-AzFrontDoorWafPolicy`
#### Az.HDInsight
* Removed two cmdlets:
    - Grant-AzHDInsightHttpServicesAccess
    - Revoke-AzHDInsightHttpServicesAccess
* Added a new cmdlet Set-AzHDInsightGatewayCredential to replace Grant-AzHDInsightHttpServicesAccess
* Update cmdlet Get-AzHDInsightJobOutput to distinguish reader role and hdinsight operator role:
    - Users with reader role need to specify 'DefaultStorageAccountKey' parameter explicitly, otherwise error occurs.
  - Users with hdinsight operator role will not be affected.

#### Az.Monitor
* New cmdlets for SQR API (Scheduled Query Rule)
    - New-AzScheduledQueryRuleAlertingAction
  - New-AzScheduledQueryRuleAznsActionGroup
  - New-AzScheduledQueryRuleLogMetricTrigger
  - New-AzScheduledQueryRuleSchedule
  - New-AzScheduledQueryRuleSource
  - New-AzScheduledQueryRuleTriggerCondition
  - New-AzScheduledQueryRule
  - Get-AzScheduledQueryRule
  - Set-AzScheduledQueryRule
  - Update-AzScheduledQueryRule
  - Remove-AzScheduledQueryRule
  - [More](https://docs.microsoft.com/en-us/rest/api/monitor/scheduledqueryrules) information about SQR API
  - Updated Az.Monitor.md to include cmdlets for GenV2(non classic) metric-based alert rule

#### Az.Network
* Add support for Nat Gateway Resource
    - New cmdlets
        - New-AzNatGateway
        - Get-AzNatGateway
        - Set-AzNatGateway
        - Remove-AzNatGateway
   - Updated cmdlets
        - New-AzureVirtualNetworkSubnetConfigCommand
        - Add-AzureVirtualNetworkSubnetConfigCommand
* Updated below commands for feature: Custom routes set/remove on Brooklyn Gateway.
    - Updated New-AzVirtualNetworkGateway: Added optional parameter -CustomRoute to set the address prefixes as custom routes to set on Gateway.
    - Updated Set-AzVirtualNetworkGateway: Added optional parameter -CustomRoute to set the address prefixes as custom routes to set on Gateway.

#### Az.PolicyInsights
* Support for querying policy evaluation details.
    - Add '-Expand' parameter to Get-AzPolicyState. Support '-Expand PolicyEvaluationDetails'.

#### Az.RecoveryServices
* Support for Cross subscription Azure to Azure site recovery.
* Marking upcoming breaking changes for Azure Site Recovery.
* Fix for Azure Site Recovery recovery plan end action plan.
* Fix for Azure Site Recovery Update network mapping for Azure to Azure.
* Fix for Azure Site Recovery update protection direction for Azure to Azure for managed disk.
* Other minor fixes.

#### Az.Relay
* Fix typos in customer-facing messages

#### Az.ServiceBus
* Added new cmdlets for NetworkRuleSet of Namespace

#### Az.Storage
* Upgrade to Storage Client Library 10.0.1 (the namespace of all objects from this SDK change from 'Microsoft.WindowsAzure.Storage.*' to 'Microsoft.Azure.Storage.*')
* Upgrade to Microsoft.Azure.Management.Storage 11.0.0, to support new API version 2019-04-01.
* The default Storage account Kind in Create Storage account change from 'Storage' to 'StorageV2'
    - New-AzStorageAccount
* Change the Storage account cmdlet output Sku.Name to be aligned with input SkuName by add '-', like 'StandardLRS' change to 'Standard_LRS'
    - New-AzStorageAccount
    - Get-AzStorageAccount
    - Set-AzStorageAccount

#### Az.Websites
* 'Kind' property will now be set for PSSite objects returned by Get-AzWebApp
* Get-AzWebApp*Metrics and Get-AzAppServicePlanMetrics marked deprecated

## 1.8.0 - April 2019
### Highlights since the last major release
* General availability of `Az` module
* For more information about the `Az` module, please visit the following: https://aka.ms/azps-announce
* Added Location, ResourceGroup, and ResourceName completers: https://azure.microsoft.com/en-us/blog/completers-in-azure-powershell/
* Added wildcard support to Get cmdlets for Az.Compute and Az.Network
* Added interactive and username/password authentication for Windows PowerShell 5.1 only
* Added support for Python 2 runbooks in Az.Automation
* Az.LogicApp: New cmdlets for Integration Account Assemblies and Batch Configuration

#### Az.Accounts
* Update Uninstall-AzureRm to correctly delete modules in Mac

#### Az.Batch
* Updated cmdlets with plural nouns to singular, and deprecated plural names.

#### Az.Cdn
* Updated cmdlets with plural nouns to singular, and deprecated plural names.

#### Az.CognitiveServices
* Updated cmdlets with plural nouns to singular, and deprecated plural names.

#### Az.Compute
* Fix issue with AEM installation if resource ids of disks had lowercase resourcegroups in resource id
* Updated cmdlets with plural nouns to singular, and deprecated plural names.
* Fix documentation for wildcards

#### Az.DataFactory
* Add SsisProperties if NodeCount not null for managed integration runtime.

#### Az.DataLakeStore
* Updated cmdlets with plural nouns to singular, and deprecated plural names.

#### Az.EventGrid
* Updated the help text for endpoint to indicate that resources should be created before using the create/update event subscription cmdlets.

#### Az.EventHub
* Added new cmdlets for NetworkRuleSet of Namespace

#### Az.HDInsight
* Updated cmdlets with plural nouns to singular, and deprecated plural names.

#### Az.IotHub
* Updated cmdlets with plural nouns to singular, and deprecated plural names.

#### Az.KeyVault
* Updated cmdlets with plural nouns to singular, and deprecated plural names.
* Fix documentation for wildcards

#### Az.MachineLearning
* Updated cmdlets with plural nouns to singular, and deprecated plural names.

#### Az.Media
* Updated cmdlets with plural nouns to singular, and deprecated plural names.

#### Az.Monitor
  * New cmdlets for GenV2(non classic) metric-based alert rule
      - New-AzMetricAlertRuleV2DimensionSelection
      - New-AzMetricAlertRuleV2Criteria
      - Remove-AzMetricAlertRuleV2
      - Get-AzMetricAlertRuleV2
      - Add-AzMetricAlertRuleV2
  * Updated Monitor SDK to version 0.22.0-preview

#### Az.Network
* Updated cmdlets with plural nouns to singular, and deprecated plural names.
* Fix documentation for wildcards

#### Az.NotificationHubs
* Updated cmdlets with plural nouns to singular, and deprecated plural names.

#### Az.OperationalInsights
* Updated cmdlets with plural nouns to singular, and deprecated plural names.

#### Az.PowerBIEmbedded
* Updated cmdlets with plural nouns to singular, and deprecated plural names.

#### Az.RecoveryServices
* Updated cmdlets with plural nouns to singular, and deprecated plural names.
* Updated table format for SQL in azure VM
* Added alternate method to fetch location in AzureFileShare
* Updated ScheduleRunDays in SchedulePolicy object according to timezone

#### Az.RedisCache
* Updated cmdlets with plural nouns to singular, and deprecated plural names.

#### Az.Resources
* Fix documentation for wildcards

#### Az.Sql
* Replace dependency on Monitor SDK with common code
* Updated cmdlets with plural nouns to singular, and deprecated plural names.
* Enhanced process of multiple columns classification.
* Include sku properties (sku name, family, capacity) in response from Get-AzSqlServerServiceObjective and format as table by default.
* Ability to Get-AzSqlServerServiceObjective by location without needing a preexisting server in the region.
* Support for time zone parameter in Managed Instance create.
* Fix documentation for wildcards

#### Az.Websites
* fixes the Set-AzWebApp and Set-AzWebAppSlot to not remove the tags on execution
* Updated cmdlets with plural nouns to singular, and deprecated plural names.
* Updated the WebSites SDK.
* Removed the AdminSiteName property from PSAppServicePlan.

## 1.7.0 - April 2019
### Highlights since the last major release
* General availability of `Az` module
* For more information about the `Az` module, please visit the following: https://aka.ms/azps-announce
* Added Location, ResourceGroup, and ResourceName completers: https://azure.microsoft.com/en-us/blog/completers-in-azure-powershell/
* Added wildcard support to Get cmdlets for Az.Compute and Az.Network
* Added interactive and username/password authentication for Windows PowerShell 5.1 only
* Added support for Python 2 runbooks in Az.Automation
* Az.LogicApp: New cmdlets for Integration Account Assemblies and Batch Configuration

#### Az.Accounts
* Updated Add-AzEnvironment and Set-AzEnvironment to accept parameter AzureAnalysisServicesEndpointResourceId

#### Az.AnalysisServices
* Using ServiceClient in dataplane cmdlets and removing the original authentication logic
* Making Add-AzureASAccount a wrapper of Connect-AzAccount to avoid a breaking change

#### Az.Automation
* Fixed New-AzAutomationSoftwareUpdateConfiguration cmdlet bug for Inclusions. Now parameter IncludedKbNumber and IncludedPackageNameMask should work.
* Bug fix for azure automation update management dynamic group

#### Az.Compute
* Add HyperVGeneration parameter to New-AzDiskConfig and New-AzSnapshotConfig
* Allow VM creation with galley image from other tenants.

#### Az.ContainerInstance
* Fixed issue in the -Command parameter of New-AzContainerGroup which added a trailing empty argument

#### Az.DataFactory
* Updated ADF .Net SDK version to 3.0.2
* Updated Set-AzDataFactoryV2 cmdlet with extra parameters for RepoConfiguration related settings.

#### Az.Resources
* Improve handling of providers for 'Get-AzResource' when providing '-ResourceId' or '-ResourceGroupName', '-Name' and '-ResourceType' parameters
* Improve error handling for for 'Test-AzDeployment' and 'Test-AzResourceGroupDeployment'
    - Handle errors thrown outside of deployment validation and include them in output of command instead
    - More information here: https://github.com/Azure/azure-powershell/issues/6856
* Add '-IgnoreDynamicParameters' switch parameter to set of deployment cmdlets to skip prompt in script and job scenarios
    - More information here: https://github.com/Azure/azure-powershell/issues/6856

#### Az.Sql
* Support Database Data Classification.

#### Az.Storage
* Report detail error when create Storage context with parameter -UseConnectedAccount, but without login Azure account
    - New-AzStorageContext
* Support Manage Blob Service Properties of a specified Storage account with Management plane API
    - Update-AzStorageBlobServiceProperty
    - Get-AzStorageBlobServiceProperty
    - Enable-AzStorageBlobDeleteRetentionPolicy
    - Disable-AzStorageBlobDeleteRetentionPolicy
* -AsJob support for Blob and file upload and download cmdlets
    - Get-AzStorageBlobContent
    - Set-AzStorageBlobContent
    - Get-AzStorageFileContent
    - Set-AzStorageFileContent

## 1.6.0 - March 2019
### Highlights since the last major release
* General availability of `Az` module
* For more information about the `Az` module, please visit the following: https://aka.ms/azps-announce
* Added Location, ResourceGroup, and ResourceName completers: https://azure.microsoft.com/en-us/blog/completers-in-azure-powershell/
* Added wildcard support to Get cmdlets for Az.Compute and Az.Network
* Added interactive and username/password authentication for Windows PowerShell 5.1 only
* Added support for Python 2 runbooks in Az.Automation
* Az.LogicApp: New cmdlets for Integration Account Assemblies and Batch Configuration

#### Az.Automation
* Azure automation update management change to support the following new features :
    * Dynamic grouping
    * Pre-Post script
    * Reboot Setting

#### Az.Compute
* Fix issue with path resolution in Get-AzVmBootDiagnosticsData
* Update Compute client library to 25.0.0.

#### Az.KeyVault
* Added wildcard support to KeyVault cmdlets

#### Az.Network
* Add Threat Intelligence support for Azure Firewall
* Add Application Gateway Firewall Policy top level resource and Custom Rules
* Add Alert action type for Azure Firewall Network and Application Rule Collections
* Added support for conditions in RewriteRules in the Application Gateway
    - New cmdlets added:
        - New-AzApplicationGatewayRewriteRuleCondition
    - Cmdlets updated with optional parameter - RuleSequence and Condition
        - New-AzApplicationGatewayRewriteRule

#### Az.RecoveryServices
* Added SnapshotRetentionInDays in Azure VM policy to support Instant RP
* Added pipe support for unregister container

#### Az.Resources
* Update wildcard support for Get-AzResource and Get-AzResourceGroup
* Update credentials used when making generic calls to ARM

#### Az.Sql
* changed Threat Detection's cmdlets param (ExcludeDetectionType) from DetectionType to string[] to make it future proof when new DetectionTypes are added and to support autocomplete as well.
* Add Vulnerability Assessment cmdlets on Server and Managed Instance

#### Az.Storage
* Support Get/Set/Remove Management Policy on a Storage account
    - Set-AzStorageAccountManagementPolicy
    - Get-AzStorageAccountManagementPolicy
    - Remove-AzStorageAccountManagementPolicy
    - Add-AzStorageAccountManagementPolicyAction
    - New-AzStorageAccountManagementPolicyFilter
    - New-AzStorageAccountManagementPolicyRule

#### Az.Websites
* Fix ARM template bug that breaks cloning all slots using 'New-AzWebApp -IncludeSourceWebAppSlots'

## 1.5.0 - March 2019
### Highlights since the last major release
* General availability of `Az` module
* For more information about the `Az` module, please visit the following: https://aka.ms/azps-announce
* Added Location, ResourceGroup, and ResourceName completers: https://azure.microsoft.com/en-us/blog/completers-in-azure-powershell/
* Added wildcard support to Get cmdlets for Az.Compute and Az.Network
* Added interactive and username/password authentication for Windows PowerShell 5.1 only
* Added support for Python 2 runbooks in Az.Automation
* Az.LogicApp: New cmdlets for Integration Account Assemblies and Batch Configuration

#### Az.Accounts
* Add 'Register-AzModule' command to support AutoRest generated cmdlets
* Update examples for Connect-AzAccount

#### Az.Automation
* Fixed issue when retreiving certain monthly schedules in several Azure Automation cmdlets
* Fix Get-AzAutomationDscNode returning just top 20 nodes. Now it returns all nodes

#### Az.Cdn
* Added new Powershell cmdlets for Enable/Disable Custom Domain Https and deprecated the old ones

#### Az.Compute
* Add wildcard support to Get cmdlets

#### Az.DataFactory
* Updated ADF .Net SDK version to 3.0.1

#### Az.LogicApp
* Fix for ListWorkflows only retrieving the first page of results

#### Az.Network
* Add wildcard support to Network cmdlets

#### Az.RecoveryServices
* Added Sql server in Azure VM support
* SDK Update
* Removed VMappContainer check in Get-ProtectableItem
* Added Name and ServerName as parameters for Get-ProtectableItem

#### Az.Resources
* Add `-TemplateObject` parameter to deployment cmdlets
    - More information here: https://github.com/Azure/azure-powershell/issues/2933
* Fix issue when piping the result of `Get-AzResource` to `Set-AzResource`
    - More information here: https://github.com/Azure/azure-powershell/issues/8240
* Fix issue with JSON data type change when running `Set-AzResource`
    - More information here: https://github.com/Azure/azure-powershell/issues/7930

#### Az.Sql
* Updating AuditingEndpointsCommunicator.
    - Fixing the behavior of an edge case while creating new diagnostic settings.

#### Az.Storage
* Support Kind BlockBlobStorage when create Storage account
       - New-AzStorageAccount

## 1.4.0 - February 2019
### Highlights since the last major release
* General availability of `Az` module
* For more information about the `Az` module, please visit the following: https://aka.ms/azps-announce
* Added Location, ResourceGroup, and ResourceName completers: https://azure.microsoft.com/en-us/blog/completers-in-azure-powershell/
* Added interactive and username/password authentication for Windows PowerShell 5.1 only
* Added support for Python 2 runbooks in Az.Automation
* Az.LogicApp: New cmdlets for Integration Account Assemblies and Batch Configuration

#### Az.AnalysisServices
* Deprecated AddAzureASAccount cmdlet

#### Az.Automation
* Update help for Import-AzAutomationDscNodeConfiguration
* Added configuration name validation to Import-AzAutomationDscConfiguration cmdlet
* Improved error handling for Import-AzAutomationDscConfiguration cmdlet

#### Az.CognitiveServices
* Added CustomSubdomainName as a new optional parameter for New-AzCognitiveServicesAccount which is used to specify subdomain for the resource.

#### Az.Compute
* Fix issue with ID parameter sets
* Update Get-AzVMExtension to list all installed extension if Name parameter is not provided
* Add Tag and ResourceId parameters to Update-AzImage cmdlet
* Get-AzVmssVM without instance ID and with InstanceView can list VMSS VMs with instance view.

#### Az.DataLakeStore
* Add cmdlets for ADL deleted item enumerate and restore

#### Az.EventHub
* Added new boolean property SkipEmptyArchives to Skip Empty Archives in CaptureDescription class of Eventhub

#### Az.KeyVault
* Fix tagging on Set-AzKeyVaultSecret

#### Az.LogicApp
* Add in Basic sku for Integration Accounts
* Add in XSLT 2.0, XSLT 3.0 and Liquid Map Types
* New cmdlets for Integration Account Assemblies
  - Get-AzIntegrationAccountAssembly
  - New-AzIntegrationAccountAssembly
  - Remove-AzIntegrationAccountAssembly
  - Set-AzIntegrationAccountAssembly
* New cmdlets for Integration Account Batch Configuration
  - Get-AzIntegrationAccountBatchConfiguration
  - New-AzIntegrationAccountBatchConfiguration
  - Remove-AzIntegrationAccountBatchConfiguration
  - Set-AzIntegrationAccountBatchConfiguration
* Update Logic App SDK to version 4.1.0

#### Az.Monitor
* Update help for Get-AzMetric

#### Az.Network
* Update help example for Add-AzApplicationGatewayCustomError

#### Az.OperationalInsights
* Additional support for New and Get ApplicationInsights data source.
    - Added new 'ApplicationInsights' kind to support Get specific and Get all ApplicationInsights data sources for given workspace.
    - Added New-AzOperationalInsightsApplicationInsightsDataSource cmdlet for creating data source by given Application-Insights resource parameters: subscription Id, resourceGroupName and name.

#### Az.Resources
* Fix for issue https://github.com/Azure/azure-powershell/issues/8166
* Fix for issue https://github.com/Azure/azure-powershell/issues/8235
* Fix for issue https://github.com/Azure/azure-powershell/issues/6219
* Fix bug preventing repeat creation of KeyCredentials

#### Az.Sql
* Add support for SQL DB Hyperscale tier
* Fixed bug where restore could fail due to setting unnecessary properties in restore request

#### Az.Websites
* Correct example in Get-AzWebAppSlotMetrics

## 1.3.0 - February 2019
### Highlights since the last major release
* General availability of `Az` module
* For more information about the `Az` module, please visit the following: https://aka.ms/azps-announce
* Added Location, ResourceGroup, and ResourceName completers: https://azure.microsoft.com/en-us/blog/completers-in-azure-powershell/
* Added interactive and username/password authentication for Windows PowerShell 5.1 only
* Added support for Python 2 runbooks in Az.Automation

#### Az.Accounts
* Update to latest version of ClientRuntime

#### Az.AnalysisServices
General availability for Az.AnalysisServices module.

#### Az.Compute
* AEM extension: Add support for UltraSSD and P60,P70 and P80 disks
* Update help description for Set-AzVMBootDiagnostics
* Update help description and example for Update-AzImage

#### Az.RecoveryServices
General availability for Az.RecoveryServices module.

#### Az.Resources
* Fix tagging for resource groups
    - More information here: https://github.com/Azure/azure-powershell/issues/8166
* Fix issue where `Get-AzRoleAssignment` doesn't respect -ErrorAction
    - More information here: https://github.com/Azure/azure-powershell/issues/8235

#### Az.Sql
* Add Get/Set AzSqlDatabaseBackupShortTermRetentionPolicy
* Fix issue where not being logged into Azure account would result in nullref exception when executing SQL cmdlets
* Fixed null ref exception in Get-AzSqlCapability

## 1.2.1 - January 2019
### Highlights since the last major release
* General availability of `Az` module
* For more information about the `Az` module, please visit the following: https://aka.ms/azps-announce
* Added Location, ResourceGroup, and ResourceName completers: https://azure.microsoft.com/en-us/blog/completers-in-azure-powershell/
* Added interactive and username/password authentication for Windows PowerShell 5.1 only
* Added support for Python 2 runbooks in Az.Automation

#### Az.Accounts
* Release with correct version of Authentication

#### Az.AnalysisServices
* Release with updated Authentication dependency

#### Az.RecoveryServices
* Release with updated Authentication dependency


## 1.2.0 - January 2019
### Highlights since the last major release
* General availability of `Az` module
* For more information about the `Az` module, please visit the following: https://aka.ms/azps-announce
* Added Location, ResourceGroup, and ResourceName completers: https://azure.microsoft.com/en-us/blog/completers-in-azure-powershell/
* Added interactive and username/password authentication for Windows PowerShell 5.1 only
* Added support for Python 2 runbooks in Az.Automation

#### Az.Accounts
* Add interactive and username/password authentication for Windows PowerShell 5.1 only
* Update incorrect online help URLs
* Add warning message in PS Core for Uninstall-AzureRm

#### Az.Aks
* Update incorrect online help URLs

#### Az.Automation
* Added support for Python 2 runbooks
* Update incorrect online help URLs

#### Az.Cdn
* Update incorrect online help URLs

#### Az.Compute
* Add Invoke-AzVMReimage cmdlet
* Add TempDisk parameter to Set-AzVmss
* Fix the warning message of New-AzVM

#### Az.ContainerRegistry
* Update incorrect online help URLs

#### Az.DataFactory
* Updated ADF .Net SDK version to 3.0.0

#### Az.DataLakeStore
* Fix issue with ADLS endpoint when using MSI
    - More information here: https://github.com/Azure/azure-powershell/issues/7462
* Update incorrect online help URLs

#### Az.IotHub
* Add Encoding format to Add-IotHubRoutingEndpoint cmdlet.

#### Az.KeyVault
* Update incorrect online help URLs

#### Az.Network
* Update incorrect online help URLs

#### Az.Resources
* Fix incorrect examples in 'New-AzADAppCredential' and 'New-AzADSpCredential' reference documentation
* Fix issue where path for '-TemplateFile' parameter was not being resolved before executing resource group deployment cmdlets
* Az.Resources: Correct documentation for New-AzPolicyDefinition -Mode default value
* Az.Resources: Fix for issue https://github.com/Azure/azure-powershell/issues/7522
* Az.Resources: Fix for issue https://github.com/Azure/azure-powershell/issues/5747
* Fix formatting issue with 'PSResourceGroupDeployment' object
    - More information here: https://github.com/Azure/azure-powershell/issues/2123

#### Az.ServiceFabric
* Rollback when a certificate is added to VMSS model but an exception is thrown this is to fix bug: https://github.com/Azure/service-fabric-issues/issues/932
* Fix some error messages.
* Fix create cluster with default ARM template for New-AzServiceFabriCluster which was not working with migration to Az.
* Fix add cluster/application certificate to only add to VM Scale Sets that correspond to the cluster by checking cluster id in the extension.

#### Az.SignalR
* Update incorrect online help URLs

#### Az.Sql
* Update incorrect online help URLs
* Updated parameter description for LicenseType parameter with possible values
* Fix for updating managed instance identity not working when it is the only updated property
* Support for custom collation on managed instance

#### Az.Storage
* Update incorrect online help URLs
* Give detail error message when get/set classic Logging/Metric on Premium Storage Account, since Premium Storage Account not supoort classic Logging/Metric.
    - Get/Set-AzStorageServiceLoggingProperty
    - Get/Set-AzStorageServiceMetricsProperty

#### Az.TrafficManager
* Update incorrect online help URLs

#### Az.Websites
* Update incorrect online help URLs
* Fixes 'New-AzWebAppSSLBinding' to upload the certificate to the correct resourcegroup+location if the app is hosted on an ASE.
* Fixes 'New-AzWebAppSSLBinding' to not overwrite the tags on binding an SSL certificate to an app

## 1.1.0 - January 2019
### Highlights since the last major release
* General availability of `Az` module
* For more information about the `Az` module, please visit the following: https://aka.ms/azps-announce
* Added Location, ResourceGroup, and ResourceName completers: https://azure.microsoft.com/en-us/blog/completers-in-azure-powershell/

#### Az.Accounts
* Add 'Local' Scope to Enable-AzureRmAlias

#### Az.Compute
* Name is now optional in ID parameter set for Restart/Start/Stop/Remove/Set-AzVM and Save-AzVMImage
* Updated the description of ID in help files
* Fix backward compatibility issue with Az.Accounts module

#### Az.DataLakeStore
* Update the sdk version of dataplane to 1.1.14 for SDK fixes.
    - Fix handling of negative acesstime and modificationtime for getfilestatus and liststatus, Fix async cancellation token

#### Az.EventGrid
* Updated to use the 2019-01-01 API version.
* Update the following cmdlets to support new scenario in 2019-01-01 API version
    - New-AzEventGridSubscription: Add new optional parameters for specifying:
        - Event Time-To-Live,
        - Maximum number of delivery attempts for the events,
        - Dead letter endpoint.
    - Update-AzEventGridSubscription: Add new optional parameters for specifying:
        - Event Time-To-Live,
        - Maximum number of delivery attempts for the events,
        - Dead letter endpoint.
* Add new enum values (namely, storageQueue and hybridConnection) for EndpointType option in New-AzEventGridSubscription and Update-AzEventGridSubscription cmdlets.
* Show warning message if creating or updating the event subscription is expected to entail manual action from user.

#### Az.IotHub
* Updated to the latest version of the IotHub SDK

#### Az.LogicApp
* Get-AzLogicApp lists all without specified Name

#### Az.Resources
* Fix parameter set issue when providing '-ODataQuery' and '-ResourceId' parameters for 'Get-AzResource'
    - More information here: https://github.com/Azure/azure-powershell/issues/7875
* Fix handling of the -Custom parameter in New/Set-AzPolicyDefinition
* Fix typo in New-AzDeployment documentation
* Made '-MailNickname' parameter mandatory for 'New-AzADUser'
    - More information here: https://github.com/Azure/azure-powershell/issues/8220

#### Az.SignalR
* Fix backward compatibility issue with Az.Accounts module

#### Az.Sql
* Converted the Storage management client dependency to the common SDK implementation.

#### Az.Storage
* Set the StorageAccountName of Storage context as the real Storage Account Name, when it's created with Sas Token, OAuth or Anonymous
    - New-AzStorageContext
* Create Sas Token of Blob Snapshot Object with '-FullUri' parameter, fix the returned Uri to be the sanpshot Uri
    - New-AzStorageBlobSASToken

#### Az.Websites
* Fixed a date parsing bug in 'Get-AzDeletedWebApp'
* Fix backward compatibility issue with Az.Accounts module

## Version 1.0.0 - December 2018
### Highlights since the last major release
* General availability of `Az` module
* For more information about the `Az` module, please visit the following: https://aka.ms/azps-announce
* Added Location, ResourceGroup, and ResourceName completers: https://azure.microsoft.com/en-us/blog/completers-in-azure-powershell/
