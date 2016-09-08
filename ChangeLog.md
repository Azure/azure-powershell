## 2016.09.08 version 2.1.0
* Data Factory
  - New cmdlet added to retrieve activity windows: Get-AzureRmDataFactoryActivityWindow

## 2016.08.09 version 2.0.1
* Fixed assembly signing issue causing load problems in some PowerShell versions.  (Issue #2747)

##2016.08.08 version 2.0.0
* This release contains breaking changes. Please see [the migration guide](documentation/release-notes/migration-guide.2.0.0.md) for change details and the impact on existing scripts.
* Removal of Force parameters that were marked as obsolete in the previous release
  * ApiManagement
    - Remove-AzureRmApiManagement
    - Remove-AzureRmApiManagementApi
    - Remove-AzureRmApiManagementGroup
    - Remove-AzureRmApiManagementLogger
    - Remove-AzureRmApiManagementOpenIdConnectProvider
    - Remove-AzureRmApiManagementOperation
    - Remove-AzureRmApiManagementPolicy
    - Remove-AzureRmApiManagementProduct
    - Remove-AzureRmApiManagementProperty
    - Remove-AzureRmApiManagementSubscription
    - Remove-AzureRmApiManagementUser
  * Automation
    - Remove-AzureRmAutomationCertificate
    - Remove-AzureRmAutomationCredential
    - Remove-AzureRmAutomationVariable
    - Remove-AzureRmAutomationWebhook
  * Batch
    - Remove-AzureBatchCertificate
    - Remove-AzureBatchComputeNode
    - Remove-AzureBatchComputeNodeUser
  * DataFactories
    - Resume-AzureRmDataFactoryPipeline
    - Set-AzureRmDataFactoryPipelineActivePeriod
    - Suspend-AzureRmDataFactoryPipeline
  * DataLakeStore
    - Remove-AzureRmDataLakeStoreItemAclEntry
    - Set-AzureRmDataLakeStoreItemAcl
    - Set-AzureRmDataLakeStoreItemAclEntry
    - Set-AzureRmDataLakeStoreItemOwner
  * OperationalInsights
    - Remove-AzureRmOperationalInsightsSavedSearch
  * Profile
    - Remove-AzureRmEnvironment
  * RedisCache
    - Remove-AzureRmRedisCacheDiagnostics
  * Resources
    - Register-AzureRmProviderFeature
    - Register-AzureRmResourceProvider
    - Remove-AzureRmADServicePrincipal
    - Remove-AzureRmPolicyAssignment
    - Remove-AzureRmResourceGroupDeployment
    - Remove-AzureRmRoleAssignment
    - Stop-AzureRmResourceGroupDeployment
    - Unregister-AzureRmResourceProvider
  * Storage
    - Remove-AzureStorageContainerStoredAccessPolicy
    - Remove-AzureStorageQueueStoredAccessPolicy
    - Remove-AzureStorageShareStoredAccessPolicy
    - Remove-AzureStorageTableStoredAccessPolicy
  * StreamAnalytics
    - Remove-AzureRmStreamAnalyticsFunction
    - Remove-AzureRmStreamAnalyticsInput
    - Remove-AzureRmStreamAnalyticsJob
    - Remove-AzureRmStreamAnalyticsOutput
  * Tag
    - Remove-AzureRmTag
* Changed `Tags` parameter name to `Tag`, and changed the parameter type from `HashTable[]` to `HashTable` for the following cmdlets
  * Batch
    - Get-AzureRmBatchAccount
    - New-AzureRmBatchAccount
    - Set-AzureRmBatchAccount
  * Compute
    - New-AzureRmVM
    - Update-AzureRmVM
  * DataLakeAnalytics
    - New-AzureRmDataLakeAnalyticsAccount
    - Set-AzureRmDataLakeAnalyticsAccount
  * DataLakeStore
    - New-AzureRmDataLakeStoreAccount
    - Set-AzureRmDataLakeStoreAccount
  * Dns
    - New-AzureRmDnsZone
    - Set-AzureRmDnsZone
  * KeyVault
    - Get-AzureRmKeyVault
    - New-AzureRmKeyVault
  * Network
    - New-AzureRmApplicationGateway
    - New-AzureRmExpressRouteCircuit
    - New-AzureRmLoadBalancer
    - New-AzureRmLocalNetworkGateway
    - New-AzureRmNetworkInterface
    - New-AzureRmNetworkSecurityGroup
    - New-AzureRmPublicIpAddress
    - New-AzureRmRouteTable
    - New-AzureRmVirtualNetwork
    - New-AzureRmVirtualNetworkGateway
    - New-AzureRmVirtualNetworkGatewayConnection
    - New-AzureRmVirtualNetworkPeering
  * Resources
    - Find-AzureRmResource
    - Find-AzureRmResourceGroup
    - New-AzureRmResource
    - New-AzureRmResourceGroup
    - Set-AzureRmResource
    - Set-AzureRmResourceGroup
  * SQL
    - New-AzureRmSqlDatabase
    - New-AzureRmSqlDatabaseCopy
    - New-AzureRmSqlDatabaseSecondary
    - New-AzureRmSqlElasticPool
    - New-AzureRmSqlServer
    - Set-AzureRmSqlDatabase
    - Set-AzureRmSqlElasticPool
    - Set-AzureRmSqlServer
  * Storage
    - New-AzureRmStorageAccount
    - Set-AzureRmStorageAccount
  * TrafficManager
    - New-AzureRmTrafficManagerProfile
* Azure Redis Cache
  * New cmdlet added for New-AzureRmRedisCacheScheduleEntry 
  * New cmdlet added for New-AzureRmRedisCachePatchSchedule 
  * New cmdlet added for Get-AzureRmRedisCachePatchSchedule
  * New cmdlet added for Remove-AzureRmRedisCachePatchSchedule
* Azure Resource Manager
  * Tag parameter type has been changed for all cmdlets which used it. The type has been changed from HashTable[] to HashTable. To create a new tag object, do as follows: `@{tagName1='tagValue1'}` instead of `@{Name='tagName1';Value='tagValue1'}`
  * Fixed an issue with Get-AzureRmResourceProvider cmdlet to support querying based on global locations through the Location parameter
  * Removed all deprecation warning messages
* Azure Storage
  * Get-AzureRmStorageAccountKey
    - Cmdlet now returns a list of keys, rather than an object with properties for each key
  * New-AzureRmStorageAccountKey
    - `StorageAccountRegenerateKeyResponse` field in output of this cmdlet is renamed to `StorageAccountListKeysResults`, which is now a list of keys rather than an object with properties for each key
  * New/Get/Set-AzureRmStorageAccount
    - `AccountType` field in output of cmdlet is renamed to `Sku.Name`
    - Output type for PrimaryEndpoints/Secondary endpoints blob/table/queue/file changed from `Uri` to `String`
  * Change -Tag parameter type from HashTable[] to HashTable
    - New-AzureRmStorageAccount
    - Set-AzureRmStorageAccount
  * Added ShouldProcess support
    - Set-AzureStorageContainerStoredAccessPolicy
    - Set-AzureStorageShareStoredAccessPolicy
    - Set-AzureStorageQueueStoredAccessPolicy
    - Set-AzureStorageTableStoredAccessPolicy
  * Downgraded ConfirmImpact to Medium
    - Remove-AzureStorageBlob
    - Remove-AzureStorageContainer
    - Remove-AzureStorageContainerStoredAccessPolicy
    - Remove-AzureStorageFile
    - Remove-AzureStorageShare
    - Remove-AzureStorageShareStoredAccessPolicy
    - Remove-AzureStorageQueue
    - Remove-AzureStorageQueueStoredAccessPolicy
    - Remove-AzureStorageTable
    - Remove-AzureStorageTableStoredAccessPolicy
  * Add support for ShouldProcess and -Force parameter to supress confirmation
    - Remove-AzureRmStorageAccount
    - Set-AzureRmStorageAccount 
  * Confirmation needed only when there's data in the Container/Table to delete (suppress with -Force)
    - Remove-AzureStorageContainer
    - Remove-AzureStorageTable
* Azure Batch
  * Add virtual network support
    - New-AzureBatchPool
  * Change -Tag parameter type from HashTable[] to HashTable
    - Set-AzureRmBatchAccount
    - New-AzureRmBatchAccount
    - Get-AzureRmBatchAccount
* Azure Sql
  * Extended the auditing cmdlets to support management of blob auditing, both at the database and at the server level	
	
	

##2016.07.11 version 1.6.0
* **Behavioral change for -Force, –Confirm and $ConfirmPreference parameters for all cmdlets. We are changing this implementation to be in line with PowerShell guidelines. For most cmdlets, this means removing the Force parameter and to skip the ShouldProcess prompt, users will need to include the parameter: ‘-Confirm:$false’ in their PowerShell scripts.** This changes are addressing following issues:
  * Correct implementation of –WhatIf functionality, allowing a user to determine the effects of a cmdlet or script without making any actual changes
  * Control over prompting using a session-wide $ConfirmPreference, so that the user is prompted based on the impact of a prospective change (as reported in the ConfirmImpact setting in the cmdlet)
  * Cmdlet-specific control over confirmation prompts using the –Confirm parameter
  * Consistent use of ShouldContinue and the –Force parameter across cmdlets, for only those actions that would require prompting from the user due to the special nature of the changes (for example, deleting hidden files)
  * Consistency with other PowerShell cmdlets, so that PowerShell scripting knowledge from other cmdlets is immediately applicable to the Azure PowerShell cmdlets.

**Notice that now to *automatically skip all Prompts in all Circumstances* Azure PowerShell cmdlets require the user to supply two parameters:**
```
My-CmdletWithConfirmation –Confirm:$false -Force
```
* Azure Compute
  * Set-AzureRmVMADDomainExtension
  * Get-AzureRmVMADDomainExtension
  * -Redeploy parameter for Restart-AzureVM
  * -Validate parameter for Move-AzureService, Move-AzureStorageAccount, and Move-AzureVirtualNetwork
  * Name and version parameters for extension cmdlets are optional as before.
  * New-AzureVM can get a license type from VM object.
* Azure Storage
  * Change Tags Parameter to Tag, and add parameter alias Tags
    - New-AzureRmStorageAccount
    - Set-AzureRmStorageAccount
* Azure Network
  * New cmdlet added for Virtual Network Peering
* Azure Redis Cache
  * New cmdlet added for Reset-AzureRmRedisCache 
  * New cmdlet added for Export-AzureRmRedisCache 
  * New cmdlet added for Import-AzureRmRedisCache 
  * Modified cmdlet New-AzureRmRedisCache to include parameter change for vNet 
* Azure SQL DB Backup/Restore
  * Cmdlets for LTR (Long Term Retention) backup feature
    * Get-AzureRmSqlServerBackupLongTermRetentionVault
    * Get-AzureRmSqlDatabaseBackupLongTermRetentionPolicy
    * Set-AzureRmSqlServerBackupLongTermRetentionVault
    * Set-AzureRmSqlDatabaseBackupLongTermRetentionPolicy
  * Restore-AzureRmSqlDatabase now supports point-in-time restore of a deleted database
  * Restore-AzureRmSqlDatabase now supports restoring from a Long Term Retention backup
* Azure LogicApp
  * Added LogicApp Integration accounts cmdlets.
    * Get-AzureRmIntegrationAccountAgreement
    * Get-AzureRmIntegrationAccountCallbackUrl
    * Get-AzureRmIntegrationAccountCertificate
    * Get-AzureRmIntegrationAccount
    * Get-AzureRmIntegrationAccountMap
    * Get-AzureRmIntegrationAccountPartner
    * Get-AzureRmIntegrationAccountSchema
    * New-AzureRmIntegrationAccountAgreement
    * New-AzureRmIntegrationAccountCertificate
    * New-AzureRmIntegrationAccount
    * New-AzureRmIntegrationAccountMap
    * New-AzureRmIntegrationAccountPartner
    * New-AzureRmIntegrationAccountSchema
    * Remove-AzureRmIntegrationAccountAgreement
    * Remove-AzureRmIntegrationAccountCertificate
    * Remove-AzureRmIntegrationAccount
    * Remove-AzureRmIntegrationAccountMap
    * Remove-AzureRmIntegrationAccountPartner
    * Remove-AzureRmIntegrationAccountSchema
    * Set-AzureRmIntegrationAccountAgreement
    * Set-AzureRmIntegrationAccountCertificate
    * Set-AzureRmIntegrationAccount
    * Set-AzureRmIntegrationAccountMap
    * Set-AzureRmIntegrationAccountPartner
    * Set-AzureRmIntegrationAccountSchema
* Azure Data Lake Store
  * Drastically improve performance of file and folder upload and download.
    * This includes a slight change to the parameter names for download and inclusion of two new parameters for upload:
      * NumThreads -> PerFileThreadCount, used to indicate the number of threads to use in a single file
      * ConcurrentFileCount, used to indicate the number of files to upload/download in parallel for folder upload/download.
    * Default threading values are now designed to give a better all around throughput for most file sizes. If performance is not as desired, the values above can be modified to meet requirements.
* Azure Data Lake Analytics
  * Get-AzureRMDataLakeAnalyticsDataSource now returns all data sources when called with no arguments.
    * This change also removes the data source type parameter from the cmdlet.
    * This change results in a new object being returned for the list operation with the following properties:
      * Type, the type of data source
      * Name, the name of the data source
      * IsDefault, set to true if this is the default data source for the account
  * Get-AzureRMDataLakeAnalyticsJob fixed for list for certain date time offset values when filtering on submittedBefore and submittedAfter.
* Web Apps
  * Add Swap-AzureRmWebAppSlot cmdlet for regular swap and swap with preview
  * Extend Set-AzureRmWebAppSlot cmdlet to support auto swap
* Azure API Management
  * Fixed Azure Api Management Deployment cmdlets for AzureChinaCloud.
  * Removed cmdlet Set-AzureRmApiManagementTenantGitAccess as Git Access is enabled by Default.
* Azure Recovery Services Backup
  * Added support for the Azure SQL workload
  * Added support for backing up and restoring encrypted Azure VMs
  * Backup-AzureRmRecoveryServicesBackupItem - Added optional retention time feature for recovery points
  * Minor filter-related bug fixes in Get-AzureRmRecoveryServicesBackupContainer and Get-AzureRmRecoveryServicesBackupItem cmdlets
* Azure Automation
  * Added Get-AzureRmAutomationHybridWorkerGroup

##2016.06.23 version 1.5.1
* Azure Resource Manager
  - Fix a bug in New-AzureRmResourceGroupDeployment. In some deployments the cmdlet throws an exception with "Deployment 'deploymentName' could not be found." and causes the cmdlet to fail. The fix makes sure the deployment is created before getting operations.
* AzureRM.Profile
  - Fix issues #2387, #2388 with SubscriptionId and TenantId ValidationSet in Set-AzureRMContext cmdlet

##2016.06.01 version 1.5.0
* Azure Resource Manager
  - (Get/Set/New/Remove)-AzureRmResourceGroup cmdlets will now use the new autorest generated ARM assembly
  - (Get/New/Remove)-AzureRmResourceGroupDeployment cmdlets will now use the new autorest generated ARM assembly
  - (Get/Register)-AzureRmProviderFeature cmdlets will now use the new autorest generated ARM assembly
  - (Get/Register/Unregister)-AzureRmResourceProvider cmdlets will now use the new autorest generated ARM assembly
  - Use a constant backoff interval when polling for deployment progress in New-AzureRmResourceGroupDeployment cmdlet
  - Add support to specify file share paths for cmdlets that take input file as parameter
  - Improve error message when Move-AzureRmResource cmdlet fails
  - Improve error message when New-AzureRmResourceGroupDeployment cmdlet fails
  - Enable object and array type parameters for template deployment
  - Preserve casing for resource properties in New/Set-AzureRmResource cmdlet
  - PropertyObject parameter is now optional in New-AzureRmResource cmdlet
* Azure Compute (CRP)
  - Add additional validation for fixed vhd in Add-AzureRmVhd cmdlet
  - Add -ForceRerun parameter to Set-AzureRmVMCustomExtension, Set-AzureRmVMBginfoExtension, and Set-AzureRmAccessExtension
  - Update -VhdUri parameter from optional to mandatory (bug fix)
  - Remove GeoReplicationEnabled deprecation warning message for Get-AzureStorageAccount cmdlet
  - Fix piping issue for Remove-AzureRmExtension
  - Create one storage account for Boot diagnostics (one for each location, instead of one for each resource group)
  - Add -DiskSizeInGB paramter to Set-AzureRmVMOSDisk cmdlet
  - Show operation id and status for POST Async cmdlets.
  - Fix Remove-AzureRmNetworkInterface issue for not throwing error when all NICs are removed.
  - Fix 'Type' output for List cmdlet
  - Remove xmlCfg contents from output format.
  - Show warning message for upcoming breaking update of Tag fix.
  - Change Set-AzureBootDiagnostics cmdlets name to Set-AzureVMBootDiagnostics (and set alias)
* Azure Compute (ASM)
  - Storage Migration cmdlet (Move-AzureStorageAccount)
  - Fix Add-AzureCertificate issue
* Azure Storage
  * Fix get Storage Account throttling failures when run it on subscription with many accounts 
    - Get-AzureRmStorageAccount
    - Get-AzureStorageAccount
* Azure Batch
  * Added Batch account usage cmdlets
    - Get-BatchPoolUsageMetrics
    - Get-BatchPoolStatistics
    - Get-BatchJobStatistics
  * Added application packages and task dependencies cmdlets
    - Get-AzureRmBatchApplication
    - Get-AzureRmBatchApplicationPackage
    - New-AzureRmBatchApplication
    - New-AzureRmBatchApplicationPackage
    - Set-AzureRmBatchApplication
    - Remove-AzureRmBatchApplicationPackage
    - Remove-AzureRmBatchApplication
  * Added bulk task option to New-AzureBatchTask cmdlet
* Azure API Management
  * Added Tenant Access cmdlets to get keys for Tenant Access via REST API
    - Get-AzureRmApiManagementTenantAccess
    - Set-AzureRmApiManagementTenantAccess
   * Added OpenId Connect Provider cmdlets to Manage OpenID Connect Providers
    - Get-AzureRmApiManagementOpenIdConnectProvider
    - New-AzureRmApiManagementOpenIdConnectProvider
    - Remove-AzureRmApiManagementOpenIdConnectProvider
    - Set-AzureRmApiManagementOpenIdConnectProvider
* Azure Automation
  * (New/Import)-AzureRmAutomationRunbook now supports the new values of 'GraphicalPowerShell' and 'GraphicalPowerShellWorkflow' with the Type parameter.  The use of 'Graph' value is discouraged.
  * Start-AzureRmAutomationRunbook now supports the Wait and MaxWaitSeconds parameters.
  * (New/Get)-AzureRmAutomationSchedule now supports weekly and monthly schedules.
  * New-AzureRmAutomationSchedule now takes a TimeZone parameter to adjust for daylight savings.
* Azure Machine Learning (Preview)
  * New cmdlets to manage Azure Machine Learning Web Services
    - New-AzureRmMlWebService
    - Get-AzureRmMlWebService
    - Remove-AzureRmMlWebService
    - Update-AzureRmMlWebService
    - Get-AzureRmMlWebServiceKeys
    - Import-AzureRmMlWebService
    - Export-AzureRmMlWebService
* Azure Data Lake (Preview)
  * Convenience cmdlet aliases added for all cmdlets
    - Analytics account management
      - Get-AdlAnalyticsAccount
      - New-AdlAnalyticsAccount
      - Remove-AdlAnalyticsAccount
      - Set-AdlAnalyticsAccount
      - Test-AdlAnalyticsAccount
    - Data source management
      - Add-AdlAnalyticsDataSource
      - Get-AdlAnalyticsDataSource
      - Remove-AdlAnalyticsDataSource
      - Set-AdlAnalyticsDataSource
    - Job management
      - Get-AdlJob
      - Stop-AdlJob
      - Submit-AdlJob
      - Wait-AdlJob
    - Catalog management
      - Get-AdlCatalogItem
      - New-AdlCatalogSecret
      - Remove-AdlCatalogSecret
      - Set-AdlCatalogSecret
      - Test-AdlCatalogItem
    - Store account management
      - Get-AdlStore
      - New-AdlStore
      - Remove-AdlStore
      - Set-AdlStore
      - Test-AdlStore
    - File management
      - Add-AdlStoreItemContent
      - Export-AdlStoreItem
      - Get-AdlStoreChildItem
      - Get-AdlStoreItem
      - Get-AdlStoreItemContent
      - Import-AdlStoreItem
      - Join-AdlStoreItem
      - Move-AdlStoreItem
      - New-AdlStoreItem
      - Remove-AdlStoreItem
      - Test-AdlStoreItem
    - File access management
      - Get-AdlStoreItemAcl
      - Get-AdlStoreItemOwner
      - Get-AdlStoreItemPermissions
      - Remove-AdlStoreItemAcl
      - Remove-AdlStoreItemAclEntry
      - Set-AdlStoreItemAcl
      - Set-AdlStoreItemAclEntry
      - Set-AdlStoreItemOwner
      - Set-AdlStoreItemPermissions
   * Granular progress tracking for folder upload done through Import-AzureRMDataLakeStoreItem
   * Scalable performance improvements for flat and recursive folder upload through Import-AzureRMDataLakeStoreItem. Full network saturation should now be possible.
   * Errors more accurately indicate that failed Import-AzureRMDataLakeStoreItem commands can be resumed/retried.
   * More targetted error handling for all Data Lake Store filesystem cmdlets.
   * Support for getting/listing table partitions through Get-AzureRMDataLakeAnalyticsCatalogItem
   
##2016.05.04 version 1.4.0
* Azure Resource Manager
  - Get-AzureRmLocation cmdlet: New cmdlet Lists all public Azure locatiosn with available provider namespaces
  - Get-AzureRMResourceGroupDeploymentOperations: Improved output format
  - Get-AzureRMDeployment: Responses contain all error details
  - Added cmdlet help anbd examples
  - Normalized cmdlet parameter defaults and position
* Azure Storage
  * Add Encryption and Hot/Cool features support to resource mode storage account cmdlets
    - New-AzureRmStorageAccount
    - Set-AzureRmStorageAccount
  * Add "Add" and "Create" permission to Blob SAS cmdlets
    - New-AzureStorageBlobSASToken
    - New-AzureStorageContainerSASToken
    - New-AzureStorageContainerStoredAccessPolicy
    - Set-AzureStorageContainerStoredAccessPolicy
  * Add "Create" permission to File SAS cmdlets
    - New-AzureStorageFileSASToken
    - New-AzureStorageShareSASToken
    - New-AzureStorageShareStoredAccessPolicy
    - Set-AzureStorageShareStoredAccessPolicy
* Azure Compute
  * Added cmdlets for Contaner Service support
  * Bug and help fixes
* Azure Profile
  * Added support for German national cloud (AzureGermanCloud)
* Azure APIManagement
  *  Added Tenant Git Configuration cmdlets
    - Get-AzureRmApiManagementTenantGitAccess
    - Set-AzureRmApiManagementTenantGitAccess
    - Get-AzureRmApiManagementTenantSyncState
    - Publish-AzureRmApiManagementTenantGitConfiguration
    - Save-AzureRmApiManagementTenantGitConfiguration
  * Added ApiManagement Properties cmdlets
    - Get-AzureRmApiManagementProperty
    - New-AzureRmApiManagementProperty
    - Remove-AzureRmApiManagementProperty
    - Set-AzureRmApiManagementProperty
  * Added Logger cmdlets
    - Get-AzureRmApiManagementLogger
    - Remove-AzureRmApiManagementLogger
    - Set-AzureRmApiManagementLogger
    - New-AzureRmApiManagementLogger
  * Fixed cmdlet bugs
    - NewAzureRMApiManagementAPI: changed Path to optional
    - NewAzureRMApiManagementProduct: fixed issue with creating products without Subscriptions
* Azure Recovery Services Backup
  * Added Recovery Services Backup cmdlets
    - Set-AzureRmRecoveryServicesVaultContext
    - Set-AzureRmRecoveryServicesBackupProperties
    - Get-AzureRmRecoveryServicesBackupProperties
    - Get-AzureRmRecoveryServicesVaultSettingsFile
    - Backup-AzureRmRecoveryServicesBackupItem
    - Get-AzureRmRecoveryServicesBackupContainer
    - Get-AzureRmRecoveryServicesBackupManagementServer
    - Unregister-AzureRmRecoveryServicesBackupContainer
    - Unregister-AzureRmRecoveryServicesBackupManagementServer
    - Disable-AzureRmRecoveryServicesBackupProtection
    - Enable-AzureRmRecoveryServicesBackupProtection
    - Get-AzureRmRecoveryServicesBackupItem
    - Get-AzureRmRecoveryServicesBackupJob
    - Get-AzureRmRecoveryServicesBackupJobDetails
    - Stop-AzureRmRecoveryServicesBackupJob
    - Wait-AzureRmRecoveryServicesBackupJob
    - Get-AzureRmRecoveryServicesBackupRetentionPolicyObject
    - Get-AzureRmRecoveryServicesBackupProtectionPolicy
    - Get-AzureRmRecoveryServicesBackupSchedulePolicyObject
    - New-AzureRmRecoveryServicesBackupProtectionPolicy
    - Remove-AzureRmRecoveryServicesBackupProtectionPolicy
    - Set-AzureRmRecoveryServicesBackupProtectionPolicy
    - Get-AzureRmRecoveryServicesBackupRecoveryPoint
    - Restore-AzureRmRecoveryServicesBackupItem

##2016.04.19 version 1.3.2
* Add support for specifying NIC/VMSS as application gateway backend address
* Fix HDI ADL cluster creation and live test
* Fix WAPack cmdlet Proxy issue for WAP
* Fix Dynamic Memory Issue while setting VM
* Update Azure Gov STS and Traffic Manager
* Compute
  - Upgrade to Microsoft.Azure.Management.Compute nuget package v13.0 
* HDInsignt
  - Upgrade to Microsoft.Azure.Management.HDInsight nuget package v1.0.14
* Resource Manager 
  - Change api-version for Policy and Locks operations
  - Change api version for Deployments operations
* Web Apps
  - Add backup and restore cmdlets
    - Restore-AzureWebApp
    - Edit-AzureRmWebAppBackupConfiguration
    - Get-AzureRmWebAppBackupConfiguration
    - Get-AzureRmWebAppBackup
    - New-AzureRmWebAppBackup
    - Remove-AzureRmWebAppBackup
    - Restore-AzureRmWebAppBackup
    - Get-AzureRmWebAppBackupList
    - New-AzureRmWebAppDatabaseBackupSetting
  - Upgrade to Microsoft.WindowsAzure.Management.WebSite nuget package v5.0

##2016.03.30 version 1.3.0
* AzureRM module
  - Installation performance fix
* New Azure CDN cmdlets
* Azure Storage
  * Made Protocol parameter in following cmdlets to be nullable and optional
    - New-AzureStorageBlobSASToken
    - New-AzureStorageContainerSASToken
    - New-AzureStorageFileSASToken
    - New-AzureStorageShareSASToken
    - New-AzureStorageQueueSASToken
    - New-AzureStorageTableSASToken
    - New-AzureStorageAccountSASToken
* Add Export-AzureRmResourceGroupTemplate cmdlet
* Add VirtualMachineScaleSet cmdlet
* Add "EA" value for permission parameter of Set-AzurePlatformVMImage
* Documentation improvements in cmdlets 

##2016.03.03 version 1.2.2
* Azure Compute (ARM):
  * Add -LicenseType parameter to New-AzureRmVM for bring your own license (BYOL)
  * Add -SecureExecution parameter to Set-AzureRmVMCustomScriptExtension
  * Add -DisableAutoUpgradeMinorVersion and -ForceRerun parameters to Set-AzureRmVMExtension
  * Add Set-AzureRmVMPlan cmdlet
  * Add -Redeploy parameter to Set-AzureRmVM
  * Add AutoUpgradeMinorVersion and ForceUpdateTag parameters for Get-AzureRmVMExtension
  * Update positions of parameters for New-AzureRmVM
* Azure Compute (Service Management):
  * Add Set-AzureBootDiagnostics cmdlets
  * Enable boot diagnostics by default for New-AzureVM and New-AzureQuickVM
* Azure LogicApp: New cmdlets for managing LogicApps  
  * Get-AzureLogicAppAccessKey
  * Get-AzureLogicApp
  * Get-AzureLogicAppRunAction
  * Get-AzureLogicAppRunHistory
  * Get-AzureLogicAppTrigger
  * Get-AzureLogicAppTriggerHistory
  * New-AzureLogicApp
  * Remove-AzureLogicApp
  * Start-AzureLogicApp
  * Set-AzureLogicAppAccessKey
  * Set-AzureLogicApp
  * Stop-AzureLogicAppRun
 * Azure Storage
  * Added cmdlet to generate SAS token against storage account
    - New-AzureStorageAccountSASToken
  * Added IPAddressOrRange/Protocol support in cmdlets to generate SAS token against blob, container, file, share, table, queue
    - New-AzureStorageBlobSASToken
    - New-AzureStorageContainerSASToken
    - New-AzureStorageFileSASToken
    - New-AzureStorageShareSASToken
    - New-AzureStorageQueueSASToken
    - New-AzureStorageTableSASToken
* Azure SQL DB Backup/Restore
  * Get-AzureRmSqlDatabaseGeoBackup
  * Get-AzureRmSqlDeletedDatabaseBackup
  * Restore-AzureRmSqlDatabase
    * This cmdlet accepts as pipelined input the result of one of the first two cmdlets (or Get-AzureRmSqlDatabase if restoring a live DB to a point-in-time)

## 2016.02.04 version 1.2.1
* Fix installer issue - remove PSGallery modules on install

## 2016.02.03 version 1.2.0
* Azure RemoteApp: 
  * Organizational Unit in Azure RemoteApp RDFE cmdlets now accepts Unicode characters.
* Azure Stack Admin: 
  * New module for the management of azure stack administrative resources such as plan, offer, subscription, resource provider and
    gallery items.
* Azure Stack Storage Admin: 
  * New module for the management of azure stack storage administrative resources such as configuration, infrastructure and health.
* Azure Operational Insights new cmdlets:
  *  Get-AzureRmOperationalInsightsSavedSearch
  *  Get-AzureRmOperationalInsightsSavedSeearchResults
  *  Get-AzureRmOperationalInsightsSavedSearches
  *  Get-AzureRmOperationalInsightsSchema
  *  Get-AzureRmOperationalInsightsSearchResult
  *  Get-AzureRmOperationalInsightsSearchResultUpdate
  *  Remove-AzureRmOperationalInsightsSavedSearch
  *  Remove-AzureRmOperationalInsightsSavedSearch
  *  Set-AzureRmOperationalInsightsSavedSearch
* Add-AzureRmAccount fixed issue with wrong credential message
* Get-AzureRmSubscription cmdlet now returns paginated results
* Update-AzureRM now only updates when need unless -Force is used
* Added telemetry to ARM and ASM cmdlets

## 2016.01.12 version 1.1.0
* Azure SQL Database: Threat Detection policies:
  * Using new Threat Detection Types
* Azure Redis Cache: new cmdlets for enabling and disabling diagnostics
  * Set-AzureRmRedisCacheDiagnostics
  * Remove-AzureRmRedisCacheDiagnostics
* Azure Websites: New cmdlets for managing SSL binding
  * Get-AzureRmWebAppCertificate
  * New-AzureRmWebAppSSLBinding
  * Get-AzureRmWebAppSSLBinding
  * Remove-AzureRmWebAppSSLBinding
  * Added AseName and AseResourceGroupName parameters in New-AzureRmWebApp and New-AzureRmAppServicePlan cmdlet
  * Added support for cloning all deployment slots associated with source website
* Azure Stream Analytics: Added new cmdlet support for Functions.
  * New-AzureRmStreamAnalyticsFunction
  * Get-AzureRmStreamAnalyticsFunction
  * Test-AzureRmStreamAnalyticsFunction
  * Get-AzureRmStreamAnalyticsDefaultFunctionDefinition
  * Remove-AzureRmStreamAnalyticsFunction
* Azure Batch
  * New-AzureBatchTask now accepts a MultiInstanceSettings parameter
  * Get-AzureBatchSubtask cmdlet added
  * Enable-AzureBatchComputeNodeScheduling / Disable-AzureBatchComputeNodeScheduling cmdlets added
  * Enable-AzureBatchAutoScale and New-AzureBatchPool now accept an AutoScaleEvaluationInterval parameter.
  
## 2015.12.14 version 1.0.2
* Azure Compute (ARM):
  * Enable BGInfo extension by default
  * Fix the issue when an OS disk is in a different resource group: Now New-AzureRmVM does not create a new storage account for boot diagnostics.
  * Add Set-AzureRmBginfoExtension cmdlet
  * Make WinRMCertificateUrl parameter mandatory when Set-AzureRmVMOperatingSystem cmdlet is performed with WinRMHttps switch
* Azure Compute (Service Management):
  * Fix the issue when adding a new VM without a data disk
  * Add ExtensionId parameter for all extension cmdlets
  * Expose RemoteAccessCertificateThumbprint property for Get-AzureVM cmdlet
* Azure SQL Database: new cmdlets for managing database threat detection policies:
  * Get-AzureRmSqlDatabaseThreatDetectionPolicy
  * Set-AzureRmSqlDatabaseThreatDetectionPolicy
  * Remove-AzureRmSqlDatabaseThreatDetectionPolicy
* Azure RemoteApp: New cmdlets for managing stale machine accounts in AD:
  * Get-AzureRemoteAppVmStaleAdObject
  * Clear-AzureRemoteAppVmStaleAdObject
* ARM Storage:
  * Fix alias missing issue


## 2015.11.09 version 1.0.1
* Azure Compute
  * Added cmdlets for managing VM DiskEncryption extension
* Azure KeyVault
  * Added EnabledForDiskEncryption and EnabledForTemplateDeployment flags to Azure Key Vault access policy
* Azure Websites 
  * Fixed issues with website management client creation

## 2015.11.05 version 1.0
* Azure Compute
  * AzureRmVM cmdlet bug fixes
  * Fixes for DSC Extension cmdlets
* Azure DataLake
  * First release of Azure DataLake Store and Azure DataLake Analytics cmdlets
* Azure Network
  * Fixes to ExpressRoute cmdlets in Azure Resource Manager
  * Changes to BGP cmdlets
* Azure Notification Hubs
  * First release of Azure Notification Hubs cmdlets
* Azure Profile
  * Enable Certificate login for AD Applications
  * Get-AzureRmSubscription, Set-AzureRmContext search all tenants by default when no tenant is specified
* Azure Redis Cache
  * Set-AzureRedisCache - Premium and vNet support for redis cache
  * New-AzureRedisCache - Premium and vNet support for redis cache
* Azure Resource Manager
  * Automatic RP Registration
  * Updates for Find-Resource, Authorization cmdlets, and AzureAD cmdlets
* Azure Sql
  * Changes to Data Masking cmdlets
* Azure Storage
  * Added support for storage file and usage metrics in Azure Resource Manager cmdlets
* Azure Websites
  * New and rewritten cmdlets for Azure Web Application management
  
## 2015.10.09 version 1.0 preview
* Azure Resource Manager Management Cmdlets
  * New-AzureRmResourceGroup - Removed the template deployment parameters from this cmdlet. Template deployment will now be 
  handled only through the New-AzureRmResourceGroupDeployment
  * Get-AzureRmResource - Will query directly against the Resource Provider. Removed parameters for tags from here. New cmdlets added for querying against the cache as listed below.
  * Get-AzureRmResourceGroup - Removed parameters for finding resources through tags. New cmdlet added for handling this   
  functionality as mentioned below.
  * Find-AzureRmResource - Query against the cache. 
  * Find-AzureRmResourceGroup - Tag parameter added for querying resource group containing specific tags.
  * Test-AzureResource - Cmdlet removed. Will be adding a better and reliable way to achieve this scenario which will be guaranteed to work against all Resource providers.
  * Test-AzureResourceGroup - Cmdlet removed. Will be adding a better and reliable way to achieve this scenario.
  * Get-AzureRmResourceProvider - This cmdlet has been renamed. Earlier it was called Get-AzureProvider. We have changed the output to include locations. Now you can use this to find out which providers and types are available for certain location.
  * Cmdlets added for policy
    * New-AzureRmPolicyDefinition, Get-AzureRmPolicyDefinition, Set-AzureRMPolicyDefinition, Remove-AzureRmPolicyDefinition
    * New-AzureRmPolicyAssignment, Get-AzureRmPolicyAssignment, Set-AzureRmPolicyAssignment, Remove-AzureRmPolicyAssignment
  * Consolidated Log cmdlets
    * Removed Get-AzureResourceLog, Get-AzureResourceGroupLog, Get-AzureProviderLog
    * Added new cmdlet Get-AzureLog which you can use to obtain logs at different scopes like resource group, resource, provider.
  * Removed Get-AzureLocation - the functionality is now provided through the Get-AzureRmResourceProvider
  
## 2015.09.03 version 0.9.8
* Azure Redis Cache cmdlets 
  * New-AzureRMRedisCache - 'RedisVersion' parameter is deprecated.
* Azure Compute (ARM) Cmdlets
  * Added -Launch parameter for Get-AzureRemoteDesktopFile cmdlet
  * Added Id parameter for VM cmdlets to support piping scenario without ResourceGroupName parameter
  * Added Set-AzureVMDataDisk cmdlet
  * Added Add-AzureVhd cmdlet
  * Changed the output format of Get image cmdlets as a table
  * Fixed Set-AzureVMAccessExtension cmdlet
* Azure Compute (Service Management) cmdlets
  * Exposed ComputeImageConfig in Get-AzurePlatformVMImage cmdlet
  * Fixed Publish-AzurePlatformExtension and Set-AzurePlatformExtension cmdlets
* Azure Backup - added the following cmdlets
  * Backup-AzureRMBackupItem
  * Register-AzureRMBackupContainer
  * Disable-AzureRMBackupProtection
  * Enable-AzureRMBackupProtection
  * Get-AzureRMBackupItem
  * Get-AzureRMBackupJob
  * Get-AzureRMBackupJobDetails
  * Stop-AzureRMBackupJob
  * Wait-AzureRMBackupJob
  * Get-AzureRMBackupProtectionPolicy
  * New-AzureRMBackupProtectionPolicy
  * New-AzureRMBackupRetentionPolicyObject
  * Remove-AzureRMBackupProtectionPolicy
  * Set-AzureRMBackupProtectionPolicy
  * Get-AzureRMBackupRecoveryPoint
  * Restore-AzureRMBackupItem
* Azure Batch - added the following cmdlets
  * Enable-AzureBatchJob
  * Disable-AzureBatchJob
  * Enable-AzureBatchJobSchedule
  * Disable-AzureBatchJobSchedule
  * Stop-AzureBatchJob
  * Stop-AzureBatchJobSchedule
  * Stop-AzureBatchTask
* Azure Data Factory
  * Update SDK reference to 3.0.0 to use API version 2015-09-01
    * Imposes message size limits for all authoring types. Pipelines must be 200 KB or less in size and all others must be 30 KB or less. 
    * TeradataLinkedService no longer accepts the obsolete properties "database" and "schema". 
    * Obsolete copy-related properties are no longer returned from the service. 
* Azure Sql (ARM) Cmdlets - added the following cmdlets
  * Get-AzureSqlServerActiveDirectoryAdministrator
  * Set-AzureSqlServerActiveDirectoryAdministrator
  * Remove-AzureSqlServerActiveDirectoryAdministrator
* SQL Server VM cmdlets (ARM)
  * New-AzureVMSqlServerAutoPatchingConfig
  * New-AzureVMSqlServerAutoBackupConfig
  * Set-AzureVMSqlServerExtension
  * Get-AzureVMSqlServerExtension
  * Remove-AzureVMSqlServerExtension
* Azure SQL Database Index Recommendation Cmdlets
  * Get-AzureSqlDatabaseIndexRecommendations
  * Start-AzureSqlDatabaseExecuteIndexRecommendation
  * Stop-AzureSqlDatabaseExecuteIndexRecommendation
* Azure SQL Database and Server Upgrade Hints Cmdlets
  * Get-AzureSqlDatabaseUpgradeHint
  * Get-AzureSqlServerUpgradeHint
	
## 2015.08.17 version 0.9.7
* Azure Profile cmdlets
  * New-AzureProfile
    * Added parameter set for empty profile
    * Fixed issues with AAD aithentication when constructing profile
    * Enabled passing results of Add-AzureEnvironment to New-AzureProfile -Environment parameter
* Azure ResourceManager cmdlets
  * New-AzureResourceGroupDeployment: Added Mode (deployment mode) and Force parameters 
  * Get-AzureProviderOperation: API changes to improve performance
* Azure Compute (ARM) Cmdlets
  * Fixes for Set-AzureDeployment with -ExtensionConfiguration
  * Fixes for Set-AzureVMCustomExtension cmdlets
  * Deprecated cmdlets Get-AzureVMImageDetail and Get-AzureVMExtentionImageDetail
* Azure Compute (Service Management) cmdlets
  * Publish-AzureVMDSCConfiguration: Added additional configuration parameters
* Azure Network (ARM) cmdlets
  * Added help for Route Table cmdlets
* Azure Storage cmdlets
  * Added support for downloading, uploading, and copying append blob
  * Added support for asynchronous copying to and from cloud file
  * Added azure service CORS management
* Azure Sql (ARM) Cmdlets
  * Fixed issues with ElascitPool cmdlets
* AzureBatch cmdlets
  * Added Batch autoscale cmdlets Enable-AzureBatchAutoScale, Disable-AzureBatchAutoScale
* RemoteApp cmdlets
  * Added Restart-AzureRemoteAppVm cmdlet
* Azure HDInsight cmdlets
  * Added cmdlet help

## 2015.08.07 version 0.9.6
* Azure Batch cmdlets
    * Cmdlets updated to use the general availability API. See http://blogs.technet.com/b/windowshpc/archive/2015/07/10/what-39-s-new-in-azure-batch-july-release-general-availability.aspx
    * Breaking changes to cmdlets resulting from API update:
        * Workitems have been removed. 
            * If you were adding all tasks to a single job, use the New-AzureBatchJob cmdlet to directly create your job.
            * If you were managing workitems with a recurring schedule defined, use the AzureBatchJobSchedule cmdlets instead.
        * If you were using the AzureBatchVM cmdlets, use the AzureBatchComputeNode cmdlets instead.
        * The AzureBatchTaskFile and AzureBatchVMFile cmdlets have been consolidated into the AzureBatchNodeFile cmdlets.
        * The Name property on most entities has been replaced by an Id property.
* Azure Network
    * Cert and SET cmdlet bugfix
* Azure Compute
    * Update VMAcces extension to use Json configs.
    * Fix Publish Extension cmdlets.
    * Update CustomScript cmdlet for SAS Uri.
    * Update help file.
* Azure Data Factory
    * Rename Table to Dataset.
* Azure SQL
    * changed the structure of the security namespace to align to the rest of the namespaces in the Azure SQL namespace.
    * Added Schema to data masking rule.
    * Updated underlying sql nuget version.
    * Add the parameter for elastic pool in Start-AzureSqlServerUpgrade.
    * Return the schedule time of the upgrade (in case of forced upgrade) to customer in Get-AzureSqlServerUpgrade.
* Azure Hdinsight Resoruce Management cmdlets
* Azure Site Recovery
    * Add Valult, Server, Protection Container, protection Entity, Protection Profile, Job cmdlets.
* Azure Stream Analytics 
    * Use Stream Analytics SDK reference to 1.6.0 version.
* Azure Backup
    * Get-AzureBackupContainer cmdlet
    * Enable-AzureBackupContainerReregistration cmdlet
    * Unregister-AzureBackupContainer cmdlet
* Azure UsageAggregates cmdlet

## 2015.07.17 version 0.9.5
* Azure SQL cmdlets
  * Allowing to use of Storage V2 accounts in Auditing policies
* Azure RedisCache cmdlets 
  * Set-AzureRedisCache - Bug fix done in management API that fixes bug here as well, Make return type public
  * New-AzureRedisCache - Make return type public
  * Get-AzureRedisCache - Make return type public
  * Azure Network Resource Provider cmdlets
  * Added Application Gateway cmdlets
    * New-AzureApplicationGateway
    * Start-AzureApplicationGateway
    * Stop-AzureApplicationGateway
    * SetAzureApplicationGateway
    * GetAzureApplicationGateway
    * RemoveAzureApplicationGateway
  * Added Application Gateway Backend Address Pool cmdlets
    * New-AzureApplicationGatewayBackendAddressPool
    * Add-AzureApplicationGatewayBackendAddressPool
    * Set-AzureApplicationGatewayBackendAddressPool
    * Get-AzureApplicationGatewayBackendAddressPool
    * Remove-AzureApplicationGatewayBackendAddressPool
  * Added Application Gateway Backend HTTP Settings cmdlets
    * New-AzureApplicationGatewayBackendHttpSettings
    * Add-AzureApplicationGatewayBackendHttpSettings
    * Set-AzureApplicationGatewayBackendHttpSettings
    * Get-AzureApplicationGatewayBackendHttpSettings
    * Remove-AzureApplicationGatewayBackendHttpSettings
  * Added Application Gateway Frontend IP Configuration cmdlets
    * New-AzureApplicationGatewayFrontendIPConfiguration
    * Add-AzureApplicationGatewayFrontendIPConfiguration
    * Set-AzureApplicationGatewayFrontendIPConfiguration
    * Get-AzureApplicationGatewayFrontendIPConfiguration
    * Remove-AzureApplicationGatewayFrontendIPConfiguration
  * Added Application Gateway Frontend Port cmdlets
    * New-AzureApplicationGatewayFrontendPort
    * Add-AzureApplicationGatewayFrontendPort
    * Set-AzureApplicationGatewayFrontendPort
    * Get-AzureApplicationGatewayFrontendPort
    * Remove-AzureApplicationGatewayFrontendPort
  * Added Application Gateway IP Configuration cmdlets
    * New-AzureApplicationGatewayGatewayIPConfiguration
    * Add-AzureApplicationGatewayGatewayIPConfiguration
    * Set-AzureApplicationGatewayGatewayIPConfiguration
    * Get-AzureApplicationGatewayGatewayIPConfiguration
    * Remove-AzureApplicationGatewayGatewayIPConfiguration
  * Added Application Gateway HTTP Listener cmdlets
    * New-AzureApplicationGatewayHttpListener
    * Add-AzureApplicationGatewayHttpListener
    * Set-AzureApplicationGatewayHttpListener
    * Get-AzureApplicationGatewayHttpListener
    * Remove-AzureApplicationGatewayHttpListener
  * Added Application Gateway Request Routing Rule cmdlets
    * New-AzureApplicationGatewayRequestRoutingRule
    * Add-AzureApplicationGatewayRequestRoutingRule
    * Set-AzureApplicationGatewayRequestRoutingRule
    * Get-AzureApplicationGatewayRequestRoutingRule
    * Remove-AzureApplicationGatewayRequestRoutingRule
  * Added Application Gateway SKU cmdlets
    * New-AzureApplicationGatewaySku
    * Set-AzureApplicationGatewaySku
    * Get-AzureApplicationGatewaySku
  * Added Application Gateway SSL Certificate cmdlets
    * New-AzureApplicationGatewaySslCertificate
    * Add-AzureApplicationGatewaySslCertificate
    * Set-AzureApplicationGatewaySslCertificate
    * Get-AzureApplicationGatewaySslCertificate
    * Remove-AzureApplicationGatewaySslCertificate
  * Fixed minor bugs AzureLoadbalancer 
  * Renamed Get-AzureCheckDnsAvailablity to Test-AzureDnsAvailability
  * Added cmdlets to RouteTables and Routes
    * New-AzureRouteTable
    * Get-AzureRouteTable
    * Set-AzureRouteTable
    * Remove-AzureRouteTable
    * New-AzureRouteConfig
    * Add-AzureRouteConfig
    * Set-AzureRouteConfig
    * Get-AzureRouteConfig
    * Remove-AzureRouteConfig
* Azure Network cmdlets
  * Reserved IP cmdlets (New-AzureReservedIP, Get-AzureReservedIP, Set-AzureReservedIPAssociation, Remove-AzureReservedIPAssociation) fixed to support -VirtualIPName parameter
  * Multivip Cmdlets (Add-AzureVirtualIP, Remove-AzureVirtualIP) fixed to support -VirtualIPName parameter
* Azure Backup cmdlets
  *Added New-AzureBackupVault cmdlets
  *Added Get-AzureBackupVault cmdlets
  *Added Set-AzureBackupVault cmdlets
  *Added Remove-AzureBackupVault cmdlets
  *Added Get-AzureBackupVaultCredential cmdlets
* Azure Resource Manager cmdlets
  * Fixed formatting of output for Get-UsageAggregates
  * Fixed executing Get-UsageAggregates when first cmdlet being called.
* Added TrafficManager cmdlets
  * Enable-AzureTrafficManagerProfile
  * Disable-AzureTrafficManagerProfile
  * New-AzureTrafficManagerEndpoint
  * Get-AzureTrafficManagerEndpoint
  * Set-AzureTrafficManagerEndpoint
  * Remove-AzureTrafficManagerEndpoint
  * Enable-AzureTrafficManagerEndpoint
  * Disable-AzureTrafficManagerEndpoint
* Upgraded TrafficManager cmdlets
  * Get-AzureTrafficManagerProfile
    * Name is now optional (it will list all profiles in resource group)
    * Resource group is now optional (it will list all profiles in subscription)
* Azure Data Factory cmdlets
    * Upgraded management library to 1.0.0 with breaking JSON format change.
    * Updated list operation paging support in cmdlets.

## 2015.06.26 version 0.9.4
* Azure Compute cmdlets
    * Warning message for deprecation Name parameter in New-AzureVM. The guidance is to use –Name parameter in New-AzureVMConfig cmdlet.
    * Save-AzureVMImgage has new paramter -Path to save the JSON template returned from the server.
    * Add-AzureVMNetworkInterface has new paramter -NetworkInterface which accepts a list of NIC object returned by Get-AzureNetworkInterface cmdlet. 
    * Deprecated “-Name” parameter in Set-AzureVMSourceImage. The guidance is to use the Pub, Offer, SKU, Version method to specify the VM Images for the VM.
    * Fixed the formatting of the output of VM Image cmdlets.
    * Fixed issues in New/Set-AzureDeployment & other service extension related cmdlets.
* Azure Batch cmdlets
    * Added Start-AzureBatchPoolResize
    * Added Stop-AzureBatchPoolResize
* Azure Key Vault cmdlets
    * Updated Key Vault package versions
    * Fixed bugs related to secrets
* Azure Network Resource Provider cmdlets
    * New-AzureLocalNetworkGateway parameter name change
    * Reset-AzureLocalNetworkGateway renamed to Set-AzureLocalNetworkGateway, added new parameter
    * VirtualNetworkGateway parameter changes
        * New-AzureVirtualNetworkGateway parameter changes
        * Removed command Resize-AzureVirtualNetworkGateway
        * Reset-AzureVirtualNetworkGatewayConnection renamed to Set-AzureVirtualNetworkGatewayConnection8
* Azure Storage changes
    * Fix the bug on aliases Get-AzureStorageContainerAcl, Start-CopyAzureStorageBlob and Stop-CopyAzureStorageBlob
* Azure RedisCache cmdlets 
    * Set-AzureRedisCache - Added support for scaling, using RedisConfiguration instead of MaxMemoryPolicy #513
    * New-AzureRedisCache - Using RedisConfiguration instead of MaxMemoryPolicy #513
* Azure Resource Manager cmdlets
    * Added Get-UsageAggregates
    * Added Get-AzureProviderOperation cmdlet
    * Added Test-AzureResourceGroup and Test-AzureResource cmdlets
    * Refactored Resource Lock cmdlets
    * Removed unnecessary code when getting a resource
* Azure SQL Database
    * Added cmdlets for pause/resume functionality and retrieving restore points for restoring backups:
        * Suspend-AzureSqlDatabase
        * Resume-AzureSqlDatabase
        * Get-AzureSqlDatabaseRestorePoints
    * Changed cmdlets:
        * New-AzureSqlDatabase - Can now create Azure Sql Data Warehouse databases

## 2015.06.05 version 0.9.3
* Fixed bug in Websites cmdlets related to slots #454
* Fix bug in Set-AzureResource cmdlet #456
* Fix for new azure resource of Microsoft.Storage #457

## 2015.05.29 version 0.9.2
* Deprecated Switch-AzureMode
* Profile
    * Fixed bug in Get-AzureSubscription and Select-AzureSubscription cmdlets 
* Added Automation cmdlets
    * Get-AzureAutomationWebhook
    * New-AzureAutomationWebhook
    * Remove-AzureAutomationWebhook
    * Set-AzureAutomationWebhook    
* Azure Compute
    * Get-AzureVMImage and Get-AzureVMImageDetail are combined (Get-AzureVMImageDetail gives a warning message for future deprecation)
    * Get-AzureVMExtensionImage and Get-AzureVMExtensionImageDetail are combined (Get-AzureVMExtensionImageDetail gives a warning message for future deprecation)
    * Tags are added in VM resources
    * Get-AzureVM now gets resource group name from piping
    * -All switch is removed from Get-AzureVM
    * Get-AzureVM -Status output is updated
    * -Force parameter is added for Remove-AzureAvailabilitySet
    * Outputs of New-AzureAvailabilitySet, Get-AzureAvailabilitySet, and Remove-AzureAvailabilitySet are updated
* Azure Key Vault 
    * Update Set-AzureKeyVaultAccessPolicy and Remove-AzureKeyVaultAccessPolicy cmdlets
    * Fixed bugs  
* Azure Data Factories
    * Base cmdlet type switch to use Profile
    * New-AzureDataFactoryEncryptedValue cmdlet supporting M data sources
* Azure Resource Manager 
    * Fixed bug in Move-AzureResource cmdlet
    * Fixed bug in Set-AzureResource cmdlet

## 2015.05.04 version 0.9.1
* Azure SQL Database: new support for configuring audit retention.
* Azure Automation
    * Added Automation cmdlets support in AzureResourceManager mode
      * Export-AzureAutomationDscConfiguration
      * Export-AzureAutomationDscNodeReportContent
      * Get-AzureAutomationAccount
      * Get-AzureAutomationDscCompilationJob
      * Get-AzureAutomationDscCompilationJobOutput
      * Get-AzureAutomationDscConfiguration
      * Get-AzureAutomationDscNode
      * Get-AzureAutomationDscNodeConfiguration
      * Get-AzureAutomationDscNodeReport
      * Get-AzureAutomationDscOnboardingMetaconfig
      * Get-AzureAutomationModule
      * Get-AzureAutomationRegistrationInfo
      * Import-AzureAutomationDscConfiguration
      * New-AzureAutomationAccount
      * New-AzureAutomationKey
      * New-AzureAutomationModule
      * Register-AzureAutomationDscNode
      * Remove-AzureAutomationAccount
      * Remove-AzureAutomationModule
      * Set-AzureAutomationAccount
      * Set-AzureAutomationDscNode
      * Set-AzureAutomationModule
      * Start-AzureAutomationDscCompilationJob
      * Unregister-AzureAutomationDscNode
* Azure Key Vault 
    * Added new cmdlets for key vault management in AzureResourceManager mode
      * New-AzureKeyVault
      * Get-AzureKeyVault
      * Remove-AzureKeyVault
      * Set-AzureKeyVaultAccessPolicy
      * Remove-AzureKeyVaultAccessPolicy
    * Added new cmdlet for secret management in AzureResourceManager mode
      * Set-AzureKeyVaultSecretAttribute

## 2015.04.29 version 0.9.0
* Azure Compute
    * Added Compute cmdlets support in AzureResourceManager mode
      * Add-AzureVMSshPublicKey
      * Add-AzureVMSecret
      * Add-AzureVMNetworkInterface
      * Add-AzureVMDataDisk
      * Add-AzureVMAdditionalUnattendContent
      * Get-AzureVM
      * Get-AzureVMUsage
      * Get-AzureVMSize
      * Get-AzureVMImageSku
      * Get-AzureVMImagePublisher
      * Get-AzureVMImageOffer
      * Get-AzureVMImageDetail
      * Get-AzureVMImage
      * Get-AzureVMExtensionImageType
      * Get-AzureVMExtensionImageDetail
      * Get-AzureVMExtensionImage
      * Get-AzureVMExtension
      * Get-AzureVMCustomScriptExtension
      * Get-AzureVMAccessExtension
      * Get-AzureVMImagePublisher
      * Get-AzureVMImageOffer
      * Get-AzureVMImageDetail
      * Get-AzureVMImage
      * Get-AzureVMExtensionImageType
      * Get-AzureVMExtensionImageDetail
      * Get-AzureVMExtensionImage
      * Get-AzureVMExtension
      * Get-AzureVMCustomScriptExtension
      * Get-AzureVMAccessExtension
      * New-AzureVM
      * New-AzureVMConfig
      * Update-AzureVM
      * Stop-AzureVM
      * Start-AzureVM
      * Set-AzureVMSourceImage
      * Set-AzureVMOSDisk
      * Set-AzureVMOperatingSystem
      * Set-AzureVMExtension
      * Set-AzureVMCustomScriptExtension
      * Set-AzureVMAccessExtension
      * Set-AzureVM
      * Save-AzureVMImage
      * Restart-AzureVM
      * Remove-AzureVMNetworkInterface
      * Remove-AzureVMExtension
      * Remove-AzureVMDataDisk
      * Remove-AzureVMCustomScriptExtension
      * Remove-AzureVMAccessExtension
      * Remove-AzureVM
* Azure Network
  * Added Network Cmdlets support in AzureResourceManager mode
    * Get-AzureVirtualNetwork
    * New-AzureVirtualNetwork
    * Remove-AzureVirtualNetwork
    * Set-AzureVirtualNetwork
    * Get-AzureVirtualNetworkSubnetConfig
    * New-AzureVirtualNetworkSubnetConfig
    * Add-AzureVirtualNetworkSubnetConfig
    * Set-AzureVirtualNetworkSubnetConfig
    * Remove-AzureVirtualNetworkSubnetConfig
    * Get-AzureNetworkInterface
    * New-AzureNetworkInterface
    * Remove-AzureNetworkInterface
    * Set-AzureNetworkInterface
    * Get-AzurePublicIpAddress
    * New-AzurePublicIpAddress
    * Remove-AzurePublicIpAddress
    * Set-AzurePublicIpAddress
    * Add-AzureLoadBalancerBackendAddressPoolConfig
    * Add-AzureLoadBalancerFrontendIpConfig
    * Add-AzureLoadBalancerInboundNatRuleConfig
    * Add-AzureLoadBalancerProbeConfig
    * Add-AzureLoadBalancerRuleConfig
    * Get-AzureLoadBalancer
    * Get-AzureLoadBalancerBackendAddressPoolConfig
    * Get-AzureLoadBalancerFrontendIpConfig
    * Get-AzureLoadBalancerInboundNatRuleConfig
    * Get-AzureLoadBalancerProbeConfig
    * Get-AzureLoadBalancerRuleConfig
    * New-AzureLoadBalancer
    * New-AzureLoadBalancerBackendAddressPoolConfig
    * New-AzureLoadBalancerFrontendIpConfig
    * New-AzureLoadBalancerInboundNatRuleConfig
    * New-AzureLoadBalancerProbeConfig
    * New-AzureLoadBalancerRuleConfig
    * Remove-AzureLoadBalancer
    * Remove-AzureLoadBalancerBackendAddressPoolConfig
    * Remove-AzureLoadBalancerFrontendIpConfig
    * Remove-AzureLoadBalancerInboundNatRuleConfig
    * Remove-AzureLoadBalancerProbeConfig
    * Remove-AzureLoadBalancerRuleConfig
    * Set-AzureLoadBalancer
    * Set-AzureLoadBalancerFrontendIpConfig
    * Set-AzureLoadBalancerInboundNatRuleConfig
    * Set-AzureLoadBalancerProbeConfig
    * Set-AzureLoadBalancerRuleConfig
    * Get-AzureNetworkSecurityGroup
    * New-AzureNetworkSecurityGroup
    * Remove-AzureNetworkSecurityGroup
    * Set-AzureNetworkSecurityGroup
    * Get-AzureNetworkSecurityRuleConfig
    * New-AzureNetworkSecurityRuleConfig
    * Remove-AzureNetworkSecurityRuleConfig
    * Add-AzureNetworkSecurityRuleConfig
    * Set-AzureNetworkSecurityRuleConfig
    * Get-AzureRemoteDesktopFile
* Azure Storage
  * Added cmdlets in AzureResourceManager Mode
    * New-AzureStorageAccount
    * Get-AzureStorageAccount
    * Set-AzureStorageAccount
    * Remove-AzureStorageAccount
    * New-AzureStorageAccountKey
    * Get-AzureStorageAccountKey
  * Made Azure Storage data cmdlets work in AzureResourceManager Mode
* Azure HDInsight:
  * Added support for creating WindowsPaas cluster with RDP Access Enabled by default
  * Added cmdlets
	* Grant-AzureHdinsightRdpAccess
	* Revoke-AzureHdinsightRdpAccess
* Azure Batch
  * Added cmdlets
    * New-AzureBatchVMUser
    * Remove-AzureBatchVMUser
    * Get-AzureBatchRDPFile
    * Get-AzureBatchVMFileContents
* StorSimple: New StorSimple commands in AzureServiceManagement mode
  * Added cmdlets
    * Confirm-AzureStorSimpleLegacyVolumeContainerStatus
    * Get-AzureStorSimpleLegacyVolumeContainerConfirmStatus
    * Get-AzureStorSimpleLegacyVolumeContainerMigrationPlan
    * Get-AzureStorSimpleLegacyVolumeContainerStatus
    * Import-AzureStorSimpleLegacyApplianceConfig
    * Import-AzureStorSimpleLegacyVolumeContainer
    * Start-AzureStorSimpleLegacyVolumeContainerMigrationPlan
    * New-AzureStorSimpleVirtualDeviceCommand
    * Get-AzureStorSimpleJob
    * Stop-AzureStorSimpleJob
    * Start-AzureStorSimpleBackupCloneJob
    * Get-AzureStorSimpleFailoverVolumeContainers
    * Start-AzureStorSimpleDeviceFailoverJob
    * New-AzureStorSimpleNetworkConfig
    * Set-AzureStorSimpleDevice
    * Set-AzureStorSimpleVirtualDevice

## 2015.03.31 version 0.8.16
* Azure Data Factory:
  * Fixes for clean install and subscription registration issues
* Azure HDInsight:
  * Support for creating, deleting, listing, and submitting jobs to HDInsight clusters with Linux Operating System.
* Azure Compute
  * Fix pipeline issues with Get-AzureVM (#3047)
  * Fixed DateTime Overflow issue
* Azure Batch
  * Added cmdlets
    * Add/Remove Batch Pools
    * Get-BatchTaskFileContent
    * Get-BatchTaskFile
* Azure Insights
  * Added cmdlets
   * Add-AutoscaleSetting
   * Get-AutoscaleHistory
   * Get-AutoscaleSetting
   * New-AutoscaleProfile
   * New-AutoscaleRule
   * Remove-AutoscaleSetting
   * Get-Metrics
   * Get-MetricDefinitions
   * Format-MetricsAsTable
* Azure Websites
  * Added cmdlet Get-AzureWebhostingPlanMetrics
  * Added Premium support
  * Renamed WebSites to WebApp
* AzureProfile
  * Made AzureProfile serializable to support workflow scenarios

## 2015.03.11 version 0.8.15.1
* Fixes for clean install and subscription registration issues

## 2015.03.09 version 0.8.15
* Azure RemoteApp: New RemoteApp cmdlets:
  * Add-AzureRemoteAppUser
  * Disconnect-AzureRemoteAppSession
  * Get-AzureRemoteAppCollection
  * Get-AzureRemoteAppCollectionUsageDetails
  * Get-AzureRemoteAppCollectionUsageSummary
  * Get-AzureRemoteAppLocation
  * Get-AzureRemoteAppOperationResult
  * Get-AzureRemoteAppPlan
  * Get-AzureRemoteAppProgram
  * Get-AzureRemoteAppSession
  * Get-AzureRemoteAppStartMenuProgram
  * Get-AzureRemoteAppTemplateImage
  * Get-AzureRemoteAppUser
  * Get-AzureRemoteAppVNet
  * Get-AzureRemoteAppVpnDevice
  * Get-AzureRemoteAppVpnDeviceConfigScript
  * Get-AzureRemoteAppWorkspace
  * Invoke-AzureRemoteAppSessionLogoff
  * New-AzureRemoteAppCollection
  * New-AzureRemoteAppTemplateImage
  * New-AzureRemoteAppVNet
  * Publish-AzureRemoteAppProgram
  * Remove-AzureRemoteAppCollection
  * Remove-AzureRemoteAppTemplateImage
  * Remove-AzureRemoteAppUser
  * Remove-AzureRemoteAppVNet
  * Rename-AzureRemoteAppTemplateImage
  * Reset-AzureRemoteAppVpnSharedKey
  * Send-AzureRemoteAppSessionMessage
  * Set-AzureRemoteAppCollection
  * Set-AzureRemoteAppVNet
  * Set-AzureRemoteAppWorkspace
  * Unpublish-AzureRemoteAppProgram
  * Update-AzureRemoteAppCollection

* Storage: new cmdlets
  * Get-AzureStorageContainerStoredAccessPolicy
  * Get-AzureStorageQueueStoredAccessPolicy
  * Get-AzureStorageTableStoredAccessPolicy
  * New-AzureStorageContainerStoredAccessPolicy
  * New-AzureStorageQueueStoredAccessPolicy
  * New-AzureStorageTableStoredAccessPolicy
  * Remove-AzureStorageContainerStoredAccessPolicy
  * Remove-AzureStorageQueueStoredAccessPolicy
  * Remove-AzureStorageTableStoredAccessPolicy
  * Set-AzureStorageContainerStoredAccessPolicy
  * Set-AzureStorageQueueStoredAccessPolicy
  * Set-AzureStorageTableStoredAccessPolicy

* Azure Recovery Services
  * New cmdlets:
    * Create and enumerate Vaults & Sites, download Vault Settings file
      * New- AzureSiteRecoveryVault
      * Get-AzureSiteRecoveryVault
      * New- AzureSiteRecoverySite
      * Get- AzureSiteRecoverySite
      * Get-AzureSiteRecoveryVaultSettingsFile
    * Enumerate Networks and manage Network Mappings
      * Get- AzureSiteRecoveryNetwork
      * New- AzureSiteRecoveryNetworkMapping
      * Get- AzureSiteRecoveryNetworkMapping
      * Remove- AzureSiteRecoveryNetworkMapping
    * Enumerate Storages and manage Storage Mappings
      * Get-AzureSiteRecoveryStorage
      * New- AzureSiteRecoveryStorageMapping
      * Get-AzureSiteRecoveryStorageMapping
      * Remove- AzureSiteRecoveryStorageMapping
    * Create, associated, and dissociate protection profile object
      * New- AzureSiteRecoveryProtectionProfileObject
      * Start-AzureSiteRecoveryProtectionProfileAssociationJob
      * Start-AzureSiteRecoveryProtectionProfileDissociationJob
    * Update VM properties and sync owner information
      * Set-AzureSiteRecoveryVM
      * Update-AzureSiteRecoveryProtectionEntity
  * Changed cmdlets:
    * Get-AzureSiteRecoveryJob
    * Set-AzureSiteRecoveryProtectionEntity – protection profile is introduced
    * Start-AzureSiteRecoveryCommitFailoverJob
    * Start-AzureSiteRecoveryPlannedFailoverJob
    * Start-AzureSiteRecoveryTestFailoverJob

* Azure ExpressRoute cmdlet updates
  * Fixed bugs in:
    * New-AzureDedicatedCircuit
    * New-AzureDedicatedCircuitLink
    * New-AzureBGPPeering
    * Remove-AzureDedicatedCircuit
    * Remove-AzureDedicatedCircuitLink
    * Remove-AzureBGPPeering
  * Added new cmdlet:
    * Update-AzureDedicatedCircuitBandwidth

* Azure SQL Database: new cmdlets for managing database dynamic data masking policies:
  * Get-AzureSqlDatabaseDataMaskingPolicy
  * Set-AzureSqlDatabaseDataMaskingPolicy
  * New-AzureSqlDatabaseDataMaskingRule
  * Get-AzureSqlDatabaseDataMaskingRule
  * Set-AzureSqlDatabaseDataMaskingRule
  * Remove-AzureSqlDatabaseDataMaskingRule

* Azure Batch: new cmdlets:
  * Get-AzureBatchPool
  * Get-AzureBatchWorkItem
  * Get-AzureBatchJob
  * Get-AzureBatchTask

* Azure Compute: new features
  * Added ForceUpdate parameter for the following cmdlets:
    * Set-AzureVMExtension
    * Set-AzureVMCustomScriptExtension
    * Set-AzureVMAccessExtension
  * Show 'Regions' property for Get-AzureVMAvailableExtensions cmdlet
  * Add 'ResizedSizeInGB' parameter for the following cmdlets
    * Update-AzureDisk
    * Set-AzureOSDisk
    * Set-AzureDataDisk (DiskName parameter is also added along with ResizedSizeInGB)

* AzureProfile:
  * New cmdlets to manage in-memory profiles
    * New-AzureProfile: Create a new in-memory Profile
    * Select-AzureProfile: Select the profile to be used in the current session
  * Added -Profile parameter to every cmdlet - the cmdlet will use the passed-in profile to authenticate with Azure

## 2015.02.12 version 0.8.14
* StorSimple: New StorSimple commands in AzureServiceManagement mode:
  * GetAzureStorSimpleAccessControlRecord
  * GetAzureStorSimpleStorageAccountCredential
  * RemoveAzureStorSimpleAccessControlRecord
  * RemoveAzureStorSimpleStorageAccountCredential
  * SetAzureStorSimpleAccessControlRecord
  * GetAzureStorSimpleDeviceVolume
  * RemoveAzureStorSimpleDeviceVolume
  * GetAzureStorSimpleDeviceVolumeContainer
  * RemoveAzureStorSimpleDeviceVolumeContainer
  * GetAzureStorSimpleDevice
  * GetAzureStorSimpleDeviceConnectedInitiator
  * GetAzureStorSimpleResource
  * GetAzureStorSimpleResourceContext
  * SetAzureStorSimpleDeviceBackupPolicy
  * NewAzureStorSimpleDeviceBackupPolicy
  * GetAzureStorSimpleDeviceBackup
  * RemoveAzureStorSimpleDeviceBackup
  * StartAzureStorSimpleDeviceBackupJob
  * StartAzureStorSimpleDeviceBackupRestoreJob
  * RemoveAzureStorSimpleDeviceBackupPolicy
  * NewAzureStorSimpleDeviceVolume
  * SetAzureStorSimpleDeviceVolume
  * NewAzureStorSimpleDeviceVolumeContainer
  * SelectAzureStorSimpleResource
  * GetAzureStorSimpleDeviceBackupPolicy
  * NewAzureStorSimpleStorageAccountCredential
  * GetAzureStorSimpleTask
  * SetAzureStorSimpleStorageAccountCredential
  * NewAzureStorSimpleInlineStorageAccountCredential
  * NewAzureStorSimpleAccessControlRecord

* HDInsight:
  * HeadNodeVMSize (update): the parameter is now a string that can now accept various sizes (specifications here: https://msdn.microsoft.com/en-us/library/azure/dn197896.aspx -> Sizes for Web and Worker Role Instances)
  * DataNodeVMSize (new)  :  use to specify size of data nodes (where applicable)
  * ZookeeperNodeVMSize (new): use to specify Zookeeper node sizes (where applicable)
  * ClusterType (update): New value (Spark) can be specified as cluster type
  * Add-AzureHDInsightConfigValues cmdlet:
    * Spark (new): collection of configuration properties can be passed in to customize the Spark service

 * Azure Insights cmdlets in AzureResourceManager Mode:
   * Get-AzureCrrelationLogId
   * Get-AzureResourceGroupLog
   * Get-AzureResourceLog
   * Get-AzureResourceProviderLog
   * Get-AzureSubscriptionIdLog

* Azure VM cmdlets
  * Get-AzureVMDscExtentionStatus: Get the DSC Extension status for a cloud service or VM

 * Updates and bug fixes for AzureAutomation and AzureDataFactory cmdlets

2015.01.08 version 0.8.13
* Key Vault Service - new cmdlets in AzureResourceManager mode:
  * Keys:
    * Add-AzureKeyVaultKey
    * Get-AzureKeyVaultKey
    * Set-AzureKeyVaultKey
    * Backup-AzureKeyVaultKey
    * Restore-AzureKeyVaultKey
    * Remove-AzureKeyVaultKey
  * Secrets:
    * Get-AzureKeyVaultSecret
    * Set-AzureKeyVaultSecret
    * Remove-AzureKeyVaultSecret

## 2014.12.12 version 0.8.12
* StreamAnalytics
  * New cmdlets in AzureResourceManager mode
    * New-AzureStreamAnalyticsJob
    * New-AzureStreamAnalyticsInput
    * New-AzureStreamAnalyticsOutput
    * New-AzureStreamAnalyticsTransformation
    * Get-AzureStreamAnalyticsJob
    * Get-AzureStreamAnalyticsInput
    * Get-AzureStreamAnalyticsOutput
    * Get-AzureStreamAnalyticsTransformation
    * Get-AzureStreamAnalyticsQuota
    * Remove-AzureStreamAnalyticsJob
    * Remove-AzureStreamAnalyticsInput
    * Remove-AzureStreamAnalyticsOutput
    * Test-AzureStreamAnalyticsInput
    * Test-AzureStreamAnalyticsOutput
    * Start-AzureStreamAnalyticsJob
    * Stop-AzureStreamAnalyticsJob
* Batch
  * Fixed issue with Delete-AzureBatchAccount
* Profile
  * Fixed issues with Select-AzureSubscription to allow selecting subscriptions by Id
  * Deprecated SubscriptionDataFile parameter
* Compute
  * Set-AzureVMImage cmdlets - added IconUri, SmallIconUri, and ShowInGui parameters
* Sql
  *  Added Sql Server v12 support to SQL authentication context for SqlAzure cmdlets

## 2014.11.14 Version 0.8.11
* Profile
  * Clear-AzureProfile: remove all subscription and credential data from the user store
  * Select-AzureSubscription: fixed output types in default and PassThru mode
* Compute
  * Get-AzureVMSqlServerExtension
  * Set-AzureVMSqlServerExtension
  * Remove-AzureVMSqlServerExtension
* HDInsight
  * New cmdlets
    * Add-AzureHDInisghtScriptAction
    * Set-AzureHDInsightClusterSize
  * Changed cmdlets
  	*Added ConfigActions parameter
* Managed Cache
  * Get-AzureManagedCacheNamedCache
  * New-AzureManagedCacheNamedCache
  * Set-AzureManagedCacheNamedCache
  * Remove-AzureManagedCacheNamedCache
* Websites
  * Fixes for webjobs and site creation
  * Additional settings for Publish-AzureWebsiteProject cmdlet
  * Enable use of SAS URLs in ApplicationDiagnostics storage
* Sql Database (AzureResourceManager)
  * New cmdlets to manage direct access to Sql databases:
    * Enable-AzureSqlDatabaseDirectAccess
    * Disable-AzureSqlDatabaseDirectAccess
    * Enable-AzureSqlDatabaseServerDirectAccess
    * Enable-AzureSqlDatabaseServerDirectAccess
  * Rename previous cmdlets to use the term audit policy instead of audit setting
    * Get-AzureSqlDatabaseAuditingPolicy
    * Set-AzureSqlDatabaseAuditingPolicy
    * Get-AzureSqlDatabaseServerAuditingPolicy
    * Set-AzureSqlDatabaseServerAuditingPolicy
    * Remove-AzureSqlDatabaseAuditing
    * Remove-AzureSqlDatabaseServerAuditing
    * Use-AzureSqlDatabaseServerAuditingPolicy
  * Allow users to define which storage account key (Primary or Secondary) to use when defining audit policy, using the “StorageKeyType” parameter.

## 2014.10.27 Version 0.8.10
* Azure Data Factory cmdlets in AzureResourceManager mode
    * New-AzureDataFactory
    * New-AzureDataFactoryGateway
    * New-AzureDataFactoryGatewayKey
    * New-AzureDataFactoryHub
    * New-AzureDataFactoryLinkedService
    * New-AzureDataFactoryPipeline
    * New-AzureDataFactoryTable
    * New-AzureDataFactoryEncryptValue
    * Get-AzureDataFactory
    * Get-AzureDataFactoryGateway
    * Get-AzureDataFactoryHub
    * Get-AzureDataFactoryLinkedService
    * Get-AzureDataFactoryPipeline
    * Get-AzureDataFactoryRun
    * Get-AzureDataFactorySlice
    * Get-AzureDataFactoryTable
    * Remove-AzureDataFactory
    * Remove-AzureDataFactoryGateway
    * Remove-AzureDataFactoryHub
    * Remove-AzureDataFactoryLinkedService
    * Remove-AzureDataFactoryPipeline
    * Remove-AzureDataFactoryTable
    * Resume-AzureDataFactoryPipeline
    * Save-AzureDataFactoryLog
    * Set-AzureDataFactoryGateway
    * Set-AzureDataFactoryPipelineActivePeriod
    * Set-AzureDataFactorySliceStatus
    * Suspend-AzureDataFactoryPipeline
* Azure Batch cmdlets in AzureResourceManager mode
    * Set-AzureBatchAccount
    * Remove-AzureBatchAccount
    * New-AzureBatchAccountKey
    * New-AzureBatchAccount
    * Get-AzureBatchAccountKeys
    * Get-AzureBatchAccount
* Azure Network
    * Multi NIC support
        * Add-AzureNetworkInterfaceConfig
        * Get-AzureNetworkInterfaceConfig
        * Remove-AzureNetworkInterfaceConfig
        * Set-AzureNetworkInterfaceConfig
    * Security group support
        * Set-AzureNetworkSecurityGroupToSubnet
        * Set-AzureNetworkSecurityGroupConfig
        * Remove-AzureNetworkSecurityGroupFromSubnet
        * Remove-AzureNetworkSecurityGroupConfig
        * Remove-AzureNetworkSecurityGroup
        * New-AzureNetworkSecurityGroup
        * Get-AzureNetworkSecurityGroupForSubnet
        * Get-AzureNetworkSecurityGroupConfig
        * Get-AzureNetworkSecurityGroup
	* VipMobility Support
		*Set-AzureReservedIPAssociation
		*Remove-AzureReservedIPAssociation
	* MultiVip Support
		* Add-AzureVirtualIP
		* Remove-AzureVirtualIP
* Azure Virtual Machine
    * Added Add PublicConfigKey and PrivateConfigKey parameters to SetAzureVMExtension
* Azure Website
    * Set-AzureWebsite exposes new parameters and Get-AzureWebsite returns them
        * SlotStickyConnectionStringNames – connection string names not to be moved during swap operation
        * SlotStickyAppSettingNames – application settings names not to be moved during swap operation
        * AutoSwapSlotName – slot name to swap automatically with after successful deployment
* Recovery Services
    * Import & view vault settings
        * Import-AzureSiteRecoveryVaultSettingsFile
        * Get-AzureSiteRecoveryVaultSettings
    * Enumerate Servers, Protection Containers, Protection Entities
        * Get-AzureSiteRecoveryServer
        * Get-AzureSiteRecoveryProtectionContainer
        * Get-AzureSiteRecoveryProtectionEntity
        * Get-AzureSiteRecoveryVM
    * Manage Azure Site Recovery Operations
        * Get-AzureSiteRecoveryJob
        * Restart-AzureSiteRecoveryJob
        * Resume-AzureSiteRecoveryJob
        * Stop-AzureSiteRecoveryJob
    * Manage Recovery Plan
        * New-AzureSiteRecoveryRecoveryPlan
        * Get-AzureSiteRecoveryRecoveryPlanFile
        * Get-AzureSiteRecoveryRecoveryPlan
        * Remove-AzureSiteRecoveryRecoveryPlan
        * Update-AzureSiteRecoveryRecoveryPlan
    * Protection and Failover Operations
        * Set-AzureSiteRecoveryProtectionEntity
        * Start-AzureSiteRecoveryCommitFailoverJob
        * Start-AzureSiteRecoveryPlannedFailoverJob
        * Start-AzureSiteRecoveryTestFailoverJob
        * Start-AzureSiteRecoveryUnplannedFailoverJob
        * Update-AzureSiteRecoveryProtectionDirection

2014.10.03 Version 0.8.9
* Redis Cache cmdlets in AzureResourceManager mode
    * New-AzureRedisCache
    * Get-AzureRedisCache
    * Set-AzureRedisCache
    * Remove-AzureRedisCache
    * New-AzureRedisCacheKey
    * Get-AzureRedisCacheKey
* Fixed Remove-AzureDataDisk regression
* Fixed cloud service cmdlets to work with the latest Azure authoring tools
* Fixed Get-AzureSubscription -ExtendedDetails regression
* Added -CreateACSNamespace parameter to New-AzureSBNamespace cmdlet

## 2014.09.10 Version 0.8.8
* Role-based access control support
    * Query role definition
        * Get-AzureRoleDefinition
        * Manage role assignment
        * New-AzureRoleAssignment
        * Get-AzureRoleAssignment
        * Remove-AzureRoleAssignment
    * Query Active Directory object
        * Get-AzureADUser
        * Get-AzureADGroup
        * Get-AzureADGroupMember
        * Get-AzureADServicePrincipal
    * Show user's permissions on
        * Get-AzureResourceGroup
        * Get-AzureResource
* Active Directory service principal login support in Azure Resource Manager mode
    * Add-AzureAccount -Credential -ServicePrincipal -Tenant
* SQL Database auditing support in Azure Resource Manager mode
    * Use-AzureSqlServerAuditingSetting
    * Set-AzureSqlServerAuditingSetting
    * Set-AzureSqlDatabaseAuditingSetting
    * Get-AzureSqlServerAuditingSetting
    * Get-AzureSqlDatabaseAuditingSetting
    * Disable-AzureSqlServerAuditing
    * Disable-AzureSqlDatabaseAuditing
* Other improvements
    * Virtual Machine DSC extension supports PSCredential as configuration argument
    * Virtual Machine Antimalware extension supports native JSON configuration
    * Storage supports creating storage account with different geo-redundant options
    * Traffic Manager supports nesting of profiles
    * Website supports configuring x32/x64 worker process
    * -Detail parameter on Get-AzureResourceGroup to improve performance
    * Major refactoring around account and subscription management

## 2014.08.22 Version 0.8.7.1
* AzureResourceManager
    * Update Gallery and Monitoring management clients to fix Gallery commands
*HDInsight
    * Update Microsoft.Net API for Hadoop

## 2014.08.18 Version 0.8.7
* Update Newtonsoft.Json dependency to 6.0.4
* Compute
    * Windows Azure Diagnostics (WAD) Version 1.2: extension cmdlets for Iaas And PaaS
        * Set-AzureVMDiagnosticsExtension
        * Get-AzureVMDiagnosticsExtension
        * Set-AzureServiceDiagnosticsExtension
        * Get-AzureServiceDiagnosticsExtension
    * Get-AzureDeployment: added CreatedTime and LastModifiedTime to output
    * Get-AzureVM: added Hostname property
    * Implemented CustomData support for Azure VMs
* Websites
    * Added RoutingRules parameter to Set-AzureWebsite to expose Testing in Production (TiP) and returned from Get-AzureWebsite
    * Get-AzureWebsiteMetric to return web site metrics
    * Get-AzureWebHostingPlan
    * Get-AzureWebHostingPlanMetric to return metrics for the servers in the web hosting plan
* SQL Database
    * Get-AzureSqlRecoverableDatabase parameter simplification and return type changes
    * Set-AzureSqlDatabaseRecovery parameter and return type changes
* HDInsight
    * Added support for provisioning of HBase clusters into Virtual Networks.

2014.08.04 Version 0.8.6
* Non-interactive login support for Microsoft Organizational account with ``Add-AzureAccount -Credential``
* Upgrade cloud service cmdlets dependencies to Azure SDK 2.4
* Compute
    * PowerShell DSC VM extension
        * Get-AzureVMDscExtension
        * Remove-AzureVMDscExtension
        * Set-AzureVMDscExtension
        * Publish-AzureVMDscConfiguration
    * Added CompanyName and SupportedOS parameters to Publish-AzurePlatformExtension
    * New-AzureVM will display a warning instead of an error when the service already exists in the same subscription
    * Added Version parameter to generic service extension cmdlets
    * Changed the ShowInGUI parameter to DoNotShowInGUI in Update-AzureVMImage
* SQL Database
    * Added OfflineSecondary parameter to Start-AzureSqlDatabaseCopy
    * Database copy cmdlets will return 2 more properties: IsOfflineSecondary and IsTerminationAllowed
* Windows Azure Pack
    * New-WAPackCloudService
    * Get-WAPackCloudService
    * Remove-WAPackCloudService
    * New-WAPackVMRole
    * Get-WAPackVMRole
    * Set-WAPackVMRole
    * Remove-WAPackVMRole
    * New-WAPackVNet
    * Remove-WAPackVNet
    * New-WAPackVMSubnet
    * Get-WAPackVMSubnet
    * Remove-WAPackVMSubnet
    * New-WAPackStaticIPAddressPool
    * Get-WAPackStaticIPAddressPool
    * Remove-WAPackStaticIPAddressPool
    * Get-WAPackLogicalNetwork

2014.07.16 Version 0.8.5
* Upgrade .NET dependency to .NET 4.5
* Azure File Service
    * Get-AzureStorageFile
    * Remove-AzureStorageFile
    * Get-AzureStorageFileContent
    * Set-AzureStorageFileContent
* Azure Resource Manager tags in AzureResourceManager mode
    * New-AzureTag
    * Get-AzureTag
    * Remove-AzureTag
    * Tag parameter in New-AzureResourceGroup, Set-AzureResourceGroup, New-AzureResource and Set-AzureResource
    * Tag parameter in Get-AzureResourceGroup and Get-AzureResource
* Compute
    * ReverseDnsFqdn parameter in New-AzureService, Set-AzureService, New-AzureVM and New-AzureQuickVM
	* Added VirtualIPName parameter to Set-AzureEndpoint, Add-AzureEndpoint, Set-AzureLoadBalancedEndpoint for Multivip support
* Network
    * Set-AzureInternalLoadBalancer
    * Add-AzureDns
    * Set-AzureDns
    * Remove-AzureDns
    * Added IdealTimeoutInMinutes parameter to Set-AzurePublicIP, Add-AzureEndpoint and Set-AzureLoadBalancedEndpoint
	
## 2014.06.30 Version 0.8.4
* Compute
    * New-AzurePlatformExtensionCertificateConfig
    * New-AzurePlatformExtensionEndpointConfigSet
    * New-AzurePlatformExtensionLocalResourceConfigSet
    * Publish-AzurePlatformExtension
    * Remove-AzurePlatformExtensionEndpoint
    * Remove-AzurePlatformExtensionLocalResource
    * Set-AzurePlatformExtension
    * Set-AzurePlatformExtensionEndpoint
    * Set-AzurePlatformExtensionLocalResource
    * Unpublish-AzurePlatformExtension
* Antimalware
    * Get-AzureVMMicrosoftAntimalwareExtension
    * Set-AzureVMMicrosoftAntimalwareExtension
    * Improve the cmdlets to use AzureStorageContext instead of flat storage parameters
* Networking
    * Enabling New-AzureVnetGateway to create dynamic gateways
    * Added alias New-AzureDns to New-AzureDnsConfig
* Scheduler
    * New-AzureSchedulerJobCollection
    * Set-AzureSchedulerJobCollection

## 2014.05.29 Version 0.8.3
* Restructured source code and installation folder
* Web Site
    * Return instances info from Get-AzureWebsite
    * Added "Slot1" and "Slot2" parameters to enable swap between any 2 slots
* Traffic Manager
    * Support for Weighted Round Robin policies
    * Support for Performance policies with external endpoints
* Update Get-AzureRoleSize, Get-AzureAffinityGroup, Get-AzureService, Get-AzureLocation cmdlets with role sizes info
* New "ClusterType" parameter for HDInsight

## 2014.05.12 Version 0.8.2
* Compute and Network improvements
    * Public IP support
        * Set-AzurePublicIP
        * Get-AzurePublicIP
        * Remove-AzurePublicIP
    * Reserved IP support
        * New-AzureReservedIP
        * Get-AzureReservedIP
        * Remove-AzureReservedIP
    * Internal load balancer support
        * New-AzureInternalLoadBalancerConfig
        * Add-AzureInternalLoadBalancer
        * Get-AzureInternalLoadBalancer
        * Remove-AzureInternalLoadBalancer
    * VM image disk improvements
        * New-AzureVMImageDiskConfigSet
        * Set-AzureVMImageOSDiskConfig
        * Remove-AzureVMImageOSDiskConfig
        * Set-AzureVMImageDataDiskConfig
        * Remove-AzureVMImageDataDiskConfig
    * Virtual network improvements
        * Set-AzureVnetGatewayKey
* Azure Automation cmdlets
    * Get-AzureAutomationAccount
    * Get-AzureAutomationJob
    * Get-AzureAutomationJobOutput
    * Get-AzureAutomationRunbook
    * Get-AzureAutomationRunbookDefinition
    * Get-AzureAutomationSchedule
    * New-AzureAutomationRunbook
    * New-AzureAutomationSchedule
    * Publish-AzureAutomationRunbook
    * Register-AzureAutomationScheduledRunbook
    * Remove-AzureAutomationRunbook
    * Remove-AzureAutomationSchedule
    * Resume-AzureAutomationJob
    * Set-AzureAutomationRunbook
    * Set-AzureAutomationRunbookDefinition
    * Set-AzureAutomationSchedule
    * Start-AzureAutomationRunbook
    * Stop-AzureAutomationJob
    * Suspend-AzureAutomationJob
    * Unregister-AzureAutomationScheduledRunbook
* Traffic Manager cmdlets
    * Add-AzureTrafficManagerEndpoint
    * Disable-AzureTrafficManagerProfile
    * Enable-AzureTrafficManagerProfile
    * Get-AzureTrafficManagerProfile
    * New-AzureTrafficManagerProfile
    * Remove-AzureTrafficManagerEndpoint
    * Remove-AzureTrafficManagerProfile
    * Set-AzureTrafficManagerEndpoint
    * Set-AzureTrafficManagerProfile
    * Test-AzureTrafficManagerDomainName
* Anti-Malware Cloud Service extension cmdlets
    * Get-AzureServiceAntimalwareConfig
    * Remove-AzureServiceAntimalwareExtension
    * Set-AzureServiceAntimalwareExtension

## 2014.05.07 Version 0.8.1
* Managed cache cmdlets
    * New-AzureManagedCache
    * Set-AzureManagedCache
    * Get-AzureManagedCache
    * Remove-AzureManagedCache
    * New-AzureManagedCacheAccessKey
    * Get-AzureManagedCacheAccessKey
* Fixed installer to support Windows PowerShell 5.0 Preview
* Fixed a bunch of module loading issues
* Documentation improvements
* Engineering and infrastructure improvements

## 2014.04.03 Version 0.8.0
* Azure Resource Manager cmdlets (preview)
  * Switch-AzureMode to switch the PowerShell module between service management and resource manager.
  * Resource groups
    * New-AzureResourceGroup
    * Get-AzureResourceGroup
    * Remove-AzureResourceGroup
    * Get-AzureResourceGroupLog
  * Templates
    * Get-AzureResourceGroupGalleryTemplate
    * Save-AzureResourceGroupGalleryTemplate
    * Test-AzureResourceGroupTemplate
  * Deployments
    * New-AzureResourceGroupDeployment
    * Get-AzureResourceGroupDeployment
  * Resources
    * New-AzureResource
    * Get-AzureResource
    * Set-AzureResource
    * Remove-AzureResource
* Azure Scheduler cmdlets
  * Get-AzureSchedulerLocation
  * Job collection
    * Get-AzureSchedulerJobCollection
    * Remove-AzureSchedulerJobCollection
  * HTTP job and storage queue job
    * New-AzureSchedulerHttpJob
    * Set-AzureSchedulerHttpJob
    * New-AzureSchedulerStorageQueueJob
    * Set-AzureSchedulerStorageQueueJob
    * Get-AzureSchedulerJob
    * Remove-AzureSchedulerJob
    * Get-AzureSchedulerJobHistory
* Virtual Machine improvements
  * Puppet extension
    * Get-AzureVMPuppetExtension
    * Set-AzureVMPuppetExtension
    * Remove-AzureVMPuppetExtension
  * Custom script extension
    * Get-AzureVMCustomScriptExtension
    * Set-AzureVMCustomScriptExtension
    * Remove-AzureVMCustomScriptExtension
  * VM Image support in the following cmdlets
    * Get-AzureVMImage
    * Save-AzureVMImage
    * Remove-AzureVMImage
    * New-AzureVM
    * New-AzureQuickVM
* Upgrade cloud service cmdlets dependencies to Azure SDK 2.3

## 2014.03.11 Version 0.7.4
* VM extension cmdlets
  * Set-AzureVMExtension
  * Get-AzureVMExtension
  * Remove-AzureVMExtension
  * Set-AzureVMAccessExtension
  * Get-AzureVMAccessExtension
  * Remove-AzureVMAccessExtension
* Multi-thread support in storage cmdlets
* Add YARN support via -Yarn parameter on Add-AzureHDInsightConfigValues

## 2014.02.25 Version 0.7.3.1
* Hotfix for https://github.com/WindowsAzure/azure-sdk-tools/issues/2350

## 2014.02.12 Version 0.7.3
* Web Site cmdlets
  * Slot
    * All Web Site cmdlets takes a new -Slot parameter
    * Switch-AzureWebsiteSlot to swap slots
  * WebJob
    * Get-AzureWebsiteJob
    * New-AzureWebsiteJob
    * Remove-AzureWebsiteJob
    * Start-AzureWebsiteJob
    * Stop-AzureWebsiteJob
    * Get-AzureWebsiteJobHistory
  * Publish project to Web Site via WebDeploy
    * Publish-AzureWebsiteProject
  * Test Web Site name availability
    * Test-AzureName -Website
* Virtual Machine cmdlets
  * Generic extension
    * Get-AzureVMAvailableExtension
    * Get-AzureServiceAvailableExtension
  * BGInfo extension
    * Get-AzureVMBGInfoExtension
    * Set-AzureVMBGInfoExtension
    * Remove-AzureBMBGInfoExtension
  * VM role size
    * Get-AzureRoleSize
    * New-AzureQuickVM -InstanceSize takes a string instead of enum
  * Other improvements
    * Add-AzureProvisioningConfig will enable guest agent by default. Use -DisableGuestAgent to disable it
* Cloud Service cmdlets
  * Generic extension
    * Get-AzureServiceExtension
    * Set-AzureServiceExtension
    * Remove-AzureServiceExtension
  * Active directory domain extension
    * Get-AzureServiceADDomainExtension
    * Set-AzureServiceADDomainExtension
    * Remove-AzureServiceADDomainExtension
    * New-AzureServiceADDomainExtensionConfig
Virtual Network cmdlets
  * Get-AzureStaticVNetIP
  * Set-AzureStaticVNetIP
  * Remove-AzureStaticVNetIP
  * Test-AzureStaticVNetIP
* Storage cmdlets
  * Metrics and logging
    * Get-AzureStorageServiceLoggingProperty
    * Set-AzureStorageServiceLoggingProperty
    * Get-AzureStorageServiceMetricsProperty
    * Set-AzureStorageServiceMetricsProperty
  * Timeout configuration via -ServerTimeoutRequest and -ClientTimeoutRequest parameters
  * Paging support via -MaxCount and -ContinuationToken parameters
    * Get-AzureStorageBlob
    * Get-AzureStorageContainer
* ExpressRoute cmdlets (in ExpressRoute module)
  * Get-AzureDedicatedCircuit
  * Get-AzureDedicatedCircuitLink
  * Get-AzureDedicatedCircuitServiceProvider
  * New-AzureDedicatedCircuit
  * New-AzureDedicatedCircuitLink
  * Remove-AzureDedicatedCircuit
  * Remove-AzureDedicatedCircuitLink
  * Get-AzureBGPPeering
  * New-AzureBGPPeering
  * Remove-AzureBGPPeering
  * Set-AzureBGPPeering


## 2013.12.19 Version 0.7.2.1
* Hotfix for some encoding issue with Hive query which contain "%".

## 2013.12.10 Version 0.7.2
* HDInsight cmdlets
  * Add-AzureHDInsightConfigValues
  * Add-AzureHDInsightMetastore
  * Add-AzureHDInsightStorage
  * Get-AzureHDInsightCluster
  * Get-AzureHDInsightJob
  * Get-AzureHDInsightJobOutput
  * Get-AzureHDInsightProperties
  * New-AzureHDInsightCluster
  * New-AzureHDInsightClusterConfig
  * New-AzureHDInsightHiveJobDefinition
  * New-AzureHDInsightMapReduceJobDefinition
  * New-AzureHDInsightPigJobDefinition
  * New-AzureHDInsightSqoopJobDefinition
  * New-AzureHDInsightStreamingMapReduceJobDefinition
  * Remove-AzureHDInsightCluster
  * Revoke-AzureHDInsightHttpServicesAccess
  * Set-AzureHDInsightDefaultStorage
  * Start-AzureHDInsightJob
  * Stop-AzureHDInsightJob
  * Use-AzureHDInsightCluster
  * Wait-AzureHDInsightJob
  * Grant-AzureHDInsightHttpServicesAccess
  * Invoke-AzureHDInsightHiveJob
* Configure Web Site WebSocket and managed pipe mode
  * Set-AzureWebsite -WebSocketEnabled -ManagedPipelineMode
* Configure Web Site remote debugging
  * Enable-AzureWebsiteDebug -Version
  * Disable-AzureWebsiteDebug
* Options for cleaning up VHD when deleting VMs
  * Remove-AzureVM -DeleteVHD
  * Remove-AzureService -DeleteAll
  * Remove-AzureDeployment -DeleteVHD
* Virtual IP reservation preview feature (in AzurePreview module)
  * Get-AzureDeployment
  * Get-AzureReservedIP
  * New-AzureReservedIP
  * New-AzureVM
  * Remove-AzureReservedIP
* Support these cmdlets for Visual Studio Cloud Service projects:
  * Start-AzureEmulator
  * Publish-AzureServiceProject
  * Save-AzureServiceProjectPackage


## 2013.11.07 Version 0.7.1
* Regression fixes
    * Get-AzureWinRMUri cannot return the correct port number (https://github.com/WindowsAzure/azure-sdk-tools/issues/2056)
    * New-AzureVM fails when creating a VM with a domain join provisioning (https://github.com/WindowsAzure/azure-sdk-tools/issues/2055)
    * ACL for endpoints broken (https://github.com/WindowsAzure/azure-sdk-tools/issues/2054)
    * Restarting web site will clean the host names (https://github.com/WindowsAzure/azure-sdk-tools/issues/2101)
    * Creating a new Linux VM with an SSH certificate fails (https://github.com/WindowsAzure/azure-sdk-tools/issues/2057)
    * Debug stream only prints out at the end of processing (https://github.com/WindowsAzure/azure-sdk-tools/issues/2033)
* Cmdlets for creating Storage SAS token
    * New-AzureStorageBlobSASToken
    * New-AzureStorageContainerSASToken
    * New-AzureStorageQueueSASToken
    * New-AzureStorageTableSASToken
* VM cmdlets for Windows Azure Pack
    * Get-WAPackVM
    * Get-WAPackVMOSDisk
    * Get-WAPackVMSizeProfile
    * Get-WAPackVMTemplate
    * New-WAPackVM
    * Remove-WAPackVM
    * Restart-WAPackVM
    * Resume-WAPackVM
    * Set-WAPackVM
    * Start-WAPackVM
    * Stop-WAPackVM
    * Suspend-WAPackVM

## 2013.10.21 Version 0.7.0
* Windows Azure Active Directory authentication support!
    * Now you can use your Microsoft account or Organizational account to login from PowerShell without the need of any management certificate or publish settings file!
    * Use Add-AzureAccount to get started
    * Checkout Add-AzureAccount, Get-AzureAcccount and Remove-AzureAccount for details
* Changed the file format which is used to store the subscription information. Information in the original file will be added to the new file automatically. If you downgrade from 0.7.0 to a lower version, you can still see the subscriptions you imported before the 0.7.0 upgrade. But anything added after the 0.7.0 upgrade won't show up in the downgrade.
* BREAKING CHANGE
    * Changed the assembly name and namespace from Microsoft.WindowsAzure.Management.* to Microsoft.WindowsAzure.Commands.*
    * Select-AzureSubscription
        * Now you can use it to select or clear either the current subscription or the default subscription
        * Replaced the -Clear parameter with -NoCurrent parameter
    * Set-AzureSubscription
        * Removed -DefaultSubscription and -NoDefaultSubscription parameters. Go to Select-AzureSubscription with -Default and -NoDefault parameters.
    * New-AzureSqlDatabaseServerContext
        * Replaced the -SubscriptionData parameter with -SubscriptionName parameter
* Upgraded Windows Azure SDK dependency from 1.8 to 2.2
* Added support for a new virtual machine high memory SKU (A5)

2013.08.22 Version 0.6.19
* Media Services cmdlets
  * Get-AzureMediaServicesAccount
  * New-AzureMediaServicesAccount
  * Remove-AzureMediaServicesAccount
  * New-AzureMediaServicesKey
* SQL Database Import/Export cmdlets
  * Start-AzureSqlDatabaseImport
  * Start-AzureSqlDatabaseExport
  * Get-AzureSqlDatabaseImportExportStatus
* Platform VM Image cmdlets (need to import the PIR module manually)
  * Get-AzurePlatformVMImage
  * Set-AzurePlatformVMImage
  * Remove-AzurePlatformVMImage

## 2013.07.31 Version 0.6.18
* Service Bus authorization rule cmdlets
  * New-AzureSBAuthorizationRule
  * Get-AzureSBAuthorizationRule
  * Set-AzureSBAuthorizationRule
  * Remove-AzureSBAuthorizationRule
* Some Windows Azure Pack fixes.

## 2013.07.18 Version 0.6.17
* Upgraded Windows Azure SDK dependency from 1.8 to 2.0.
* SQL Azure database CRUD cmdlets don't require SQL auth anymore if the user owns the belonging subscription.
* Get-AzureSqlDatabaseServerQuota cmdlet to get the quota information for a specified Windows Azure SQL Database Server.
* SQL Azure service objective support
  * Get-AzureSqlDatabaseServiceObjective cmdlet to a service objective for the specified Windows Azure SQL Database Server.
  * Added -ServiceObjective parameter to Set-AzureSqlDatabase to set the service objective of the specified Windows Azure SQL database.
* Fixed a Get-AzureWebsite local caching issue. Now Get-AzureWebsite will always return the up-to-date web site information.

## 2013.06.24 Version 0.6.16
* Add-AzureEnvironment to add customized environment like Windows Azure Pack
* Set-AzureEnvironment to set customized environment like Windows Azure Pack
* Remove-AzureEnvironment to remove customized environment like Windows Azure Pack
* Web Site cmdlets now support Windows Azure Pack
* Service Bus cmdlets now support Windows Azure Pack
* Added "WAPack" prefix to all the cmdlets which support Windows Azure Pack. Use "help WAPack" to see all the supported cmdlets
* Added -NoWinRMEndpoint parameter to New-AzureQuickVM and Add-AzureProvisioningConfig
* Added -AllowAllAzureSerivces parameter to New-AzureSqlDatabaseServerFirewallRule
* Many bug fixes around VM, Cloud Services and Web Site diagnostics

## 2013.06.03 Version 0.6.15
* Introduced the environment concept to support different Windows Azure environments
  * Get-AzureEnvironment cmdlet to return all the out-of-box Windows Azure environments
  * -Environment parameter in the following cmdlets to specify which environment to target
    * Get-AzurePublishSettingsFile
    * Show-AzurePortal
* Windows Azure Web Site application diagnostics cmdlets
  * Enable-AzureWebsiteApplicationDiagnostic
  * Disable-AzureWebsiteApplicationDiagnostic
* Stop-AzureVM
  * Changed the behavior to deprovision the VM after stopping it
  * -StayProvisioned parameter to keep the VM provisioned after stopping it
* Windows Azure Cloud Services remote desktop extension cmdlets
  * New-AzureServiceRemoteDesktopExtensionConfig
  * Get-AzureServiceRemoteDesktopExtension
  * Set-AzureServiceRemoteDesktopExtension
  * Remove-AzureServiceRemoteDesktopExtension
* Windows Azure Cloud Services diagnostics extension cmdlets
  * New-AzureServiceDiagnosticsExtensionConfig
  * Get-AzureServiceDiagnosticsExtension
  * Set-AzureServiceDiagnosticsExtension
  * Remove-AzureServiceDiagnosticsExtension
* Windows Azure Virtual Machine endpoint enhancements
  * Cmdlets to create ACL configuration objects
    * New-AzureVMAclConfig
    * Get-AzureVMAclConfig
    * Set-AzureVMAclConfig
    * Remove-AzureVMAclConfig
  * -ACL parameter to support ACL in
    * Add-AzureEndpoint
    * Set-AzureEndpoint
  * -DirectServerReturn parameter in
    * Add-AzureEndpoint
    * Set-AzureEndpoint
  * Set-AzureLoadBalancedEndpoint cmdlet to modify load balanced endpoints
* Bug fixes
  * Fixed New-AzureSqlDatabaseServerContext model mismatch warning

## 2013.05.08 Version 0.6.14
* Windows Azure Storage Table cmdlets
  * Get-AzureStorageTable
  * New-AzureStorageTable
  * Remove-AzureStorageTable
* Windows Azure Storage Queue cmdlets
  * Get-AzureStorageQueue
  * New-AzureStorageQueue
  * Remove-AzureStorageQueue
* Fix an issue in Publish-AzureServiceProject when swapping between staging and production slot

## 2013.04.23 Version 0.6.13.1
* Hotfix to make Set-AzureStorageAccount behave correctly with the -GeoReplicationEnabled parameter

## 2013.04.16 Version 0.6.13
* Completely fixed issues with first website creation on a new account. Now you can use PowerShell with a new account directly without the need to go to the Azure portal.
* BREAKING CHANGE: New-AzureVM and New-AzureQuickVM now require an –AdminUserName parameter when creating Windows based VMs.
* Added support for virtual machine high memory SKUs (A6 and A7).
* Remote PowerShell is now enabled by default on Windows based VMs using https. To disable: specify the –DisableWinRMHttps parameter on New-AzureQuickVM or Add-AzureProvisioningConfig. To enable using http: specify –EnableWinRMHttp parameter (Note: http is intended for VM to VM communication and a public endpoint is not created by default).
* Added Get-AzureWinRMUri new cmdlet to get the connection string URI for Windows Remote Management.
* Added Set-AzureAvailabilitySet new cmdlet to group similar virtual machines into an availability set after deployment.
* New-AzureVM and New-AzureQuickVM now support a parameter named –X509Certificates. When a certificate is added to this array it is automatically uploaded and deployed to the virtual machine.
* Improved *-AzureEndpoint cmdlets:
  * Allows a simple endpoint to be created.
  * Allows a load balanced endpoint to be created.
  * Allows a load balanced endpoint to be created with a health probe and you can now specify the Probe Interval and Timeout periods.
* Removed subscription check requirement when using Add-AzureVHD with a shared access signature.
* Added Simultaneous Upgrade option to New-AzureDeployment for Cloud Services deployment. This option can save a significant amount of time during deployments to staging. This option can cause downtime and should only be used in non-production deployments.
* Upgraded to the latest service management library.
* Made New-AzureDeployment to use SSL during the deployment.
* Added Get-AzureWebsiteLog -ListPath to get all the available log paths of the website.
* Fixed the issue of removing custom DNS names in Start/Stop/Restart-AzureWebsite.
* Fixed several GB18030 encoding issues.
* Renamed Start/Stop-CopyAzureStorageBlob to Start/Stop-AzureStorageBlobCopy. Kept old names as aliases for backward compatibility.

## 2013.03.26 Version 0.6.12.1
 * Hotfix to fix issues with first website creation on a new account.

## 2013.03.20 Version 0.6.12
 * Windows Azure Storage entity level cmdlets
   * New-AzureStorageContext
   * New-AzureStorageContainer
   * Get-AzureStorageContainer
   * Remove-AzureStorageContainer
   * Get-AzureStorageContainerAcl
   * Set-AzureStorageContainerAcl
   * Get-AzureStorageBlob
   * Get-AzureStorageBlobContent
   * Set-AzureStorageBlobContent
   * Remove-AzureStorageBlob
   * Start-CopyAzureStorageBlob
   * Stop-CopyAzureStorageBlob
   * Get-AzureStorageBlobCopyState
 * Windows Azure Web Sites diagnostics log streaming cmdlet
   * Get-AzureWebsitLog -Tail

## 2013.03.06 Version 0.6.11
 * Windows Azure Store cmdlets
 * Upgraded to the latest service management library and update service management version header to 2012-12-01
 * Added Save-AzureVhd cmdlet
 * Updated Add-AzureVMImage, Get-AzureVMImage and Set-AzureVMImage cmdlets to support new attributes in service management version header 2012-12-01

## 2013.02.11 Version 0.6.10
 * Upgrade to use PowerShell 3.0
 * Released source code for VM and Cloud Services cmdlets
 * Added a few new cmdlets for Cloud Services (Add-AzureWebRole, Add-AzureWorkerRole, NewAzureRoleTemplate, Save-AzureServiceProjectPackage, Set-AzureServiceProjectRole -VMSize), See Web Camps TV (http://channel9.msdn.com/Shows/Web+Camps+TV/Whats-Coming-in-the-Command-Line-Tools-for-Windows-Azure-with-Glenn-Block) for more on these new cmdlets.
 * Added Support for SAS in destination Uri for Add-AzureVhd
 * Added -Confirm and -WhatIf support for Remove-Azure* cmdlets
 * Added configurable startup task for Node.js and generic roles
 * Enabled emulator support when running roles with memcache
 * Role based cmdlets don't require role name if run in a role folder
 * Added scenario test framework and started adding automated scenario tests
 * Multiple bug fixes

## 2012.12.12 Version 0.6.9
 * Added Service Bus namespace management cmdlets 'help azuresb'
 * Added -ServiceBusNamespace parameter to 'Test-AzureName' to verify namespace availability
 * Added VHD uploader cmdlet 'Add-AzureVHD' for uploading VM images to blob storage.
 * Improved message reporting and piping for couple scaffolding cmdlets
 * Fixed PHP customization functionality for modifying php.ini and installing custom extensions
 * Verbose option is enabled by default when using Windows Azure PowerShell shortcut

## 2012.11.21 Version 0.6.8
 * Multiple bug fixes
 * Added dedicated cache role support
 * Added GitHub support

## 2012.10.08 Version 0.6.5
 * Adding websites cmdlets

## 2012.06.06 Version 0.6.0
 * Adding PowerShell management cmdlets
 * Adding PHP Cmdlets
 * Renaming existing cmdlets to remove duplication
 * Node.exe is no longer embedded

## 2012.05.11 Version 0.5.4
 * node 0.6.17
 * iisnode 0.1.19

## 2012.02.17 Version 0.5.3
 * Bug fixes

## 2012.02.10 Version 0.5.2
 * Bug fixes

## 2011.12.23 Version 0.5.1
 * Added Remote Desktop support
 * Added SSL support
 * node 0.6.6
 * iisnode 0.1.13

2011.12.09 Version 0.5.0
 * Initial Release
