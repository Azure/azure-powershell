## 2017.07.17 - Version 4.2.1
* Compute
    - Fix issue with VM DIsk and VM Disk snapshot create and update cmdlets, (link)[https://github.com/azure/azure-powershell/issues/4309]
      - New-AzureRmDisk
      - New-AzureRmSnapshot
      - Update-AzureRmDisk
      - Update-AzureRmSnapshot
* Profile
    - Fix issue with non-interactive user authentication in RDFE (link)[https://github.com/Azure/azure-powershell/issues/4299]
* ServiceManagement
    - Fix issue with non-interactive user authentication (link)[https://github.com/Azure/azure-powershell/issues/4299]

## 2017.7.11 - Version 4.2.0
* AnalysisServices
    * Add new dataplane API
        - Introduced API to fetch AS server log, Export-AzureAnalysisServicesInstanceLog
* Automation
    * Properly setting TimeZone value for Weekly and Monthly schedules for New-AzureRmAutomationSchedule
        - More information can be found in this issue: https://github.com/Azure/azure-powershell/issues/3043
* AzureBatch
    - Added new Get-AzureBatchJobPreparationAndReleaseTaskStatus cmdlet.
    - Added byte range start and end to Get-AzureBatchNodeFileContent parameters.
* CognitiveServices
    * Integrate with Cognitive Services Management SDK version 1.0.0.
    * Fix an account name length checking bug.
* Compute
    * Storage account type support for Image disk:
        - 'StorageAccountType' parameter is added to Set-AzureRmImageOsDisk and Add-AzureRmImageDataDisk
    * PrivateIP and PublicIP feature in Vmss Ip Configuration:
        - 'PrivateIPAddressVersion', 'PublicIPAddressConfigurationName', 'PublicIPAddressConfigurationIdleTimeoutInMinutes', 'DnsSetting' names are added to New-AzureRmVmssIpConfig
        - 'PrivateIPAddressVersion' parameter for specifying IPv4 or IPv6 is added to New-AzureRmVmssIpConfig
    * Performance Maintenance feature:
        - 'PerformMaintenance' switch parameter is added to Restart-AzureRmVM.
        - Get-AzureRmVM -Status shows the information of performance maintenance of the given VM
    * Virtual Machine Identity feature:
        - 'IdentityType' parameter is added to New-AzureRmVMConfig and UpdateAzureRmVM
        - Get-AzureRmVM shows the information of the identity of the given VM
    * Vmss Identity feature:
        - 'IdentityType' parameter is added to to New-AzureRmVmssConfig
        - Get-AzureRmVmss shows the information of the identity of the given Vmss
    * Vmss Boot Diagnostics feature:
        - New cmdlet for setting boot diagnostics of Vmss object: Set-AzureRmVmssBootDiagnostics
        - 'BootDiagnostic' parameter is added to New-AzureRmVmssConfig
    * Vmss LicenseType feature:
        - 'LicenseType' parameter is added to New-AzureRmVmssConfig
    * RecoveryPolicyMode support:
        - 'RecoveryPolicyMode' paramter is added to New-AzureRmVmssConfig
    * Compute Resource Sku feature:
        - New cmdlet 'Get-AzureRmComputeResourceSku' list all compute resource skus
* DataFactories
    * Deprecate New-AzureRmDataFactoryGatewayKey
    * Introduce gateway auth key feature by adding New-AzureRmDataFactoryGatewayAuthKey and Get-AzureRmDataFactoryGatewayAuthKey
* DataLakeAnalytics
    * Add support for Compute Policy CRUD through the following commands:
        - New-AzureRMDataLakeAnalyticsComputePolicy
        - Get-AzureRMDataLakeAnalyticsComputePolicy
        - Remove-AzureRMDataLakeAnalyticsComputePolicy
        - Update-AzureRMDataLakeAnalyticsComputePolicy
    * Add support for job relationship metadata for help with recurring jobs and job pipelines. The following commands were updated or added:
        - Submit-AzureRMDataLakeAnalyticsJob
        - Get-AzureRMDataLakeAnalyticsJob
        - Get-AzureRMDataLakeAnalyticsJobRecurrence
        - Get-AzureRMDataLakeAnalyticsJobPipeline
    * Updated the token audience for job and catalog APIs to use the correct Data Lake specific audience instead of the Azure Resource audience.
* DataLakeStore
    * Added support for user managed KeyVault key rotations in the Set-AzureRMDataLakeStoreAccount cmdlet
    * Added a quality of life update to automatically trigger an `enableKeyVault` call when a user managed KeyVault is added or a key is rotated.
    * Updated the token audience for job and catalog APIs to use the correct Data Lake specific audience instead of the Azure Resource audience.
    * Fixed a bug limiting the size of files created/appended using the following cmdlets:
        - New-AzureRmDataLakeStoreItem
        - Add-AzureRmDataLakeStoreItemContent
* Dns
    * Fix bug in the piping scenario for Get-AzureRmDnsZone
        - More information can be found here: https://github.com/Azure/azure-powershell/issues/4203
* HDInsight
    * Added support to enable / disable Operations Management Suite(OMS)
    * New cmdlets
        - Enable-AzureRmHDInsightOperationsManagementSuite
        - Disable-AzureRmHDInsightOperationsManagementSuite
        - Get-AzureRmHDInsightOperationsManagementSuite
    * Add new parameters to set Spark custom configurations to Add-AzureRmHDInsightConfigValues
        - Parameters SparkDefaults and SparkThriftConf for Spark 1.6
        - Parameters Spark2Defaults and Spark2ThriftConf for Spark 2.0
* Insights
    * Issue #4215 (change request) remove the 15 days limit in the time window for the Get-AzureRmLog cmdlet. Also minor changes to the unit test names.
    * Issue #3957 fixed for Get-AzureRmLog
        - Issue #1: The backend returns the records in pages of 200 records each, linked by the continuation token to the next page. The customers were seeing the cmdlet returning only 200 records when they knew there were more. This was happening regardless of the value they set for MaxEvents, unless that value was less than 200.
        - Issue #2: The documentation contained incorrect data about this cmdlet, e.g.: the default timewindow was 1 hour.
        - Fix #1: The cmdlet now follows the continuation token returned by the backend until it reaches MaxEvents or the end of the set.<br>The default value for MaxEvents is 1000 and its maximum is 100000. Any value for MaxEvents that is less than 1 is ignored and the default is used instead. These values and behavior did not change, now they are correctly documented.<br>An alias for MaxEvents has been added -MaxRecords- since the name of the cmdlet does not speak about events anymore, but only about Logs.
        - Fix #2: The documentation contains correct and more detailed information: new alias, correct time window, correct default, minimum, and maximum values.
* KeyVault
    * Remove email address from the directory query when -UserPrincipalName is specified to the Set-AzureRMKeyVaultAccessPolicy and Remove-AzureRMKeyVaultAccessPolicy cmdlets.
      - Both Cmdlets now have an -EmailAddress parameter that can be used instead of the -UserPrincipalName parameter when querying for email address is appropriate.  If there are more than one matching email addresses in the directory then the Cmdlet will fail.
* Network
    * New-AzureRmIpsecPolicy: SALifeTimeSeconds and SADataSizeKilobytes are no longer mandatory parameters
        - SALifeTimeSeconds defaults to 27000 seconds
        - SADataSizeKilobytes defaults to 102400000 KB
    * Added support for custom cipher suite configuration using ssl policy and listing all ssl options api in Application Gateway
        - Added optional parameter -PolicyType, -PolicyName, -MinProtocolVersion, -Ciphersuite
            - Add-AzureRmApplicationGatewaySslPolicy
            - New-AzureRmApplicationGatewaySslPolicy
            - Set-AzureRmApplicationGatewaySslPolicy
        - Added Get-AzureRmApplicationGatewayAvailableSslOptions (Alias: List-AzureRmApplicationGatewayAvailableSslOptions)
        - Added Get-AzureRmApplicationGatewaySslPredefinedPolicy (Alias: List-AzureRmApplicationGatewaySslPredefinedPolicy)
    * Added redirect support in Application Gateway
        - Added Add-AzureRmApplicationGatewayRedirectConfiguration
        - Added Get-AzureRmApplicationGatewayRedirectConfiguration
        - Added New-AzureRmApplicationGatewayRedirectConfiguration
        - Added Remove-AzureRmApplicationGatewayRedirectConfiguration
        - Added Set-AzureRmApplicationGatewayRedirectConfiguration
        - Added optional parameter -RedirectConfiguration
            - Add-AzureRmApplicationGatewayRequestRoutingRule
            - New-AzureRmApplicationGatewayRequestRoutingRule
            - Set-AzureRmApplicationGatewayRequestRoutingRule
        - Added optional parameter -DefaultRedirectConfiguration
            - Add-AzureRmApplicationGatewayUrlPathMapConfig
            - New-AzureRmApplicationGatewayUrlPathMapConfig
            - Set-AzureRmApplicationGatewayUrlPathMapConfig
        - Added optional parameter -RedirectConfiguration
            - Add-AzureRmApplicationGatewayPathRuleConfig
            - New-AzureRmApplicationGatewayPathRuleConfig
            - Set-AzureRmApplicationGatewayPathRuleConfig
        - Added optional parameter -RedirectConfigurations
            - New-AzureRmApplicationGateway 
            - Set-AzureRmApplicationGateway
    * Added support for azure websites in Application Gateway
        - Added New-AzureRmApplicationGatewayProbeHealthResponseMatch
        - Added optional parameters -PickHostNameFromBackendHttpSettings, -MinServers, -Match
            - Add-AzureRmApplicationGatewayProbeConfig 
            - New-AzureRmApplicationGatewayProbeConfig
            - Set-AzureRmApplicationGatewayProbeConfig
        - Added optional parameters -PickHostNameFromBackendAddress, -AffinityCookieName, -ProbeEnabled, -Path
            - Add-AzureRmApplicationGatewayBackendHttpSettings
            - New-AzureRmApplicationGatewayBackendHttpSettings
            - Set-AzureRmApplicationGatewayBackendHttpSettings
    * Update Get-AzureRmPublicIPaddress to retrieve publicipaddress resources created via VM Scale Set
    * Added cmdlet to get virtual network current usage
        - Get-AzureRmVirtualNetworkUsageList
* Profile
    * Fixed error when using Import-AzureRmContext or Save-AzureRmContext
        - More information can be found in this issue: https://github.com/Azure/azure-powershell/issues/3954
* RecoveryServices.SiteRecovery
    * Introducing a new module for Azure Site Recovery operations.
    	- All cmdlets begin with AzureRmRecoveryServicesAsr*
* Sql
    * Add Data Sync PowerShell Cmdlets to AzureRM.Sql
    * Updated AzureRmSqlServer cmdlets to use new REST API version that avoids timeouts when creating server.
    * Deprecated server upgrade cmdlets because the old server version (2.0) no longer exists.
    * Add new optional switch paramter "AssignIdentity" to New-AzureRmSqlServer and Set-AzureRmSqlServer cmdlets to support provisioning of a resource identity for the SQL server resource
    * The parameter ResourceGroupName is now optional for Get-AzureRmSqlServer
    	- More information can be found in the following issue: https://github.com/Azure/azure-powershell/issues/635
* ServiceManagement
    For ExpressRoute:
    * Updated New-AzureBgpPeering cmdlet to add following new options :
        - PeerAddressType : Values of "IPv4" or "IPv6" can be specified to create a BGP Peering of the corresponding address family type	
    * Updated Set-AzureBgpPeering cmdlet to add following new options :
        - PeerAddressType : Values of "IPv4" or "IPv6" can be specified to update BGP Peering of the corresponding address family type
    * Updated Remove-AzureBgpPeering cmdlet to add following new options :
        - PeerAddressType : Values of "IPv4", "IPv6" or All can be specified to remove BGP Peering of the corresponding address family type or all of them

## 2017.06.07 - Version 4.1.0
* AnalysisServices
    * New SKUs added: B1, B2, S0
    * Scale up/down support added
* CognitiveServices
    * Update detailed display of license agreements when creating Cognitive Services resources
* Compute
    * Fix Test-AzureRmVMAEMExtension for virtual machines with multiple managed disks
    * Updated Set-AzureRmVMAEMExtension: Add caching information for Premium managed disks
    * Add-AzureRmVhd: The size limit on vhd is increased to 4TB.
    * Stop-AzureRmVM: Clarify documentation for STayProvisioned parameter
    * New-AzureRmDiskUpdateConfig
      * Deprecated parameters CreateOption, StorageAccountId, ImageReference, SourceUri, SourceResourceId
    * Set-AzureRmDiskUpdateImageReference: Deprecated cmdlet
    * New-AzureRmSnapshotUpdateConfig
      * Deprecated parameters CreateOption, StorageAccountId, ImageReference, SourceUri, SourceResourceId
    * Set-AzureRmSnapshotUpdateImageReference: Deprecated Cmdlet
* DataLakeStore
    * Enable-AzureRmDataLakeStoreKeyVault (Enable-AdlStoreKeyVault)
      * Enable KeyVault managed encryption for a DataLake Store
* DevTestLabs
    * Update cmdlets to work with current and updated DevTest Labs API version.
* IotHub
    * Add Routing support for IoTHub cmdlets
* KeyVault
  * New Cmdlets to support KeyVault Managed Storage Account Keys
    * Get-AzureKeyVaultManagedStorageAccount
    * Add-AzureKeyVaultManagedStorageAccount
    * Remove-AzureKeyVaultManagedStorageAccount
    * Update-AzureKeyVaultManagedStorageAccount
    * Update-AzureKeyVaultManagedStorageAccountKey
    * Get-AzureKeyVaultManagedStorageSasDefinition
    * Set-AzureKeyVaultManagedStorageSasDefinition
    * Remove-AzureKeyVaultManagedStorageSasDefinition
* Network
    * Get-AzureRmNetworkUsage: New cmdlet to show network usage and capacity details
    * Added new GatewaySku options for VirtualNetworkGateways
        * VpnGw1, VpnGw2, VpnGw3 are the new Skus added for Vpn gateways
    * Set-AzureRmNetworkWatcherConfigFlowLog
      * Fixed  help examples
* NotificationHubs
    * Transparent Update to NotificationHubs cmdlets for new API
* Profile
    * Resolve-AzureRmError
      * New cmdlet to show details of errors and exceptions thrown by cmdlets, including server request/response data
    * Send-Feedback
      * Enabled sending feedback without logging in
    * Get-AzureRmSubscription
      * Fix bug in retreiving CSP subscriptions
* Resources
    * Fixed issue where Get-AzureRMRoleAssignment would result in a Bad Request if the number of roleassignments where greater than 1000
        * Users can now use Get-AzureRMRoleAssignment even if the roleassignments to be returned is greater than 1000
* Sql
    * Restore-AzureRmSqlDatabase: Update documentation example
* Storage
    * Add AssignIdentity setting support to resource mode storage account cmdlets
        * New-AzureRmStorageAccount
        * Set-AzureRmStorageAccount
    * Add Customer Key Support to resource mode storage account cmdlets
        * Set-AzureRmStorageAccount
        * New-AzureRmStorageAccountEncryptionKeySource
* TrafficManager
    
    * New Monitor settings 'MonitorIntervalInSeconds', 'MonitorTimeoutInSeconds', 'MonitorToleratedNumberOfFailures'
    * New Monitor protocol 'TCP'
* ServiceManagement
    * Add-AzureVhd: The size limit on vhd is increased to 4TB.
    * New-AzureBGPPeering: Support LegacyMode
* Azure.Storage
    * Update help for parameters that accept wildcard characters and update StorageContext type

## 2017.05.23 - Version 4.0.2
* Profile
    * Add-AzureRmAccount
      * Added `-EnvironmentName` parameter alis for backward compatibility with 2.x versions of AzureRM.profile

## 2017.05.12 - Version 4.0.1
 * Fix issue with New-AzureStorageContext in offline scenarios: https://github.com/Azure/azure-powershell/issues/3939
 
 ## 2017.05.10 - Version 4.0.0
* This release contains breaking changes. Please see [the migration guide](https://aka.ms/azps-migration-guide) for change details and the impact on existing scripts.
* ApiManagement
    * Added support for configuring external groups in New-AzureRmApiManagementGroup.
* Billing
    * New Cmdlet Get-AzureRmBillingPeriod
        - cmdlet to retrieve azure billing periods of the subscription.
    * Update Cmdlet Get-AzureRmBillingInvoice
    	- new property BillingPeriodNames
    	- output in list view
* Compute
    * Updated Set-AzureRmVMAEMExtension and Test-AzureRmVMAEMExtension cmdlets to support Premium managed disks
    * Backup encryption settings for IaaS VMs and restore on failure
    * ChefServiceInterval option is renamed to ChefDaemonInterval now. Old one will continue to work however.
    * Remove duplicated DataDiskNames and NetworkInterfaceIDs properties from PS VM object.
      - Make DataDiskNames and NetworkInterfaceIDs parameters optional in Remove-AzureRmVMDataDisk and Remove-AzureRmVMNetworkInterface, respectively.
    * Fix the piping issue of Get cmdlets when the Get cmdlets return a list object.
    * Cmdlets that conflicted with RDFE cmdlets have been renamed. See issue https://github.com/Azure/azure-powershell/issues/2917 for more details
        - `New-AzureVMSqlServerAutoBackupConfig` has been renamed to `New-AzureRmVMSqlServerAutoBackupConfig`
        - `New-AzureVMSqlServerAutoPatchingConfig` has been renamed to `New-AzureRmVMSqlServerAutoPatchingConfig`
        - `New-AzureVMSqlServerKeyVaultCredentialConfig` has been renamed to `New-AzureRmVMSqlServerKeyVaultCredentialConfig`
* Consumption
    * New Cmdlet Get-AzureRmConsumptionUsageDetail
        - cmdlet to retrieve usage details of the subscription.
* ContainerRegistry
    * Add PowerShell cmdlets for Azure Container Registry
        - New-AzureRmContainerRegistry
        - Get-AzureRmContainerRegistry
        - Update-AzureRmContainerRegistry
        - Remove-AzureRmContainerRegistry
        - Get-AzureRmContainerRegistryCredential
        - Update-AzureRmContainerRegistryCredential
        - Test-AzureRmContainerRegistryNameAvailability
* DataLakeAnalytics
    * Add support for catalog package get and list
    * Add support for listing the following catalog items from deeper ancestors:
      * Table
      * TVF
      * View
      * Statistics
* DataLakeStore
    * For `Import-AzureRMDataLakeStoreItem` and `Export-AzureRMDataLakeStoreItem` trace logging has been disabled by default to improve performance. If trace logging is desired please use the `-DiagnosticLogLevel` and `-DiagnosticLogPath` parameters
    * Fixed a bug that would sometimes cause PowerShell to crash when uploading lots of small file to ADLS.
* EventHub
    * Bug fix : 
    	- Fix for Set-AzureRmEventHubNamespace cmdlet error  - 'Tier' cannot be null, where it should be 'SkuName' 
        - Set-AzureRmEventHub - Fix 'Object reference not set to an instance of an object' error while updating EventHub  
* Insights
    * Add-AzureRm*AlertRule
        - Returns a single object: newResource, statusCode, requestId
    * Get-AzureRmAlertRule
        - The output is now enumerated instead of considered a single object. Its type did not change, it is still a list.
    * Remove-AzureRmAlertRule
        - The statusCode follows the status code returned by the request, before it was Ok always.
    * Add-AzureRmAutoscaleSetting
        - Returns now a single object (not a list as before) containing statusCode, requestId, and the newly created/updated resource.
        - The status code follows the status returned by the request, before it was always Ok.
    * New-AzureRmAutoscaleRule
        - The parameter ScaleActionType has been extended, it receives the following values now: ChangeCount, PercentChangeCount, ExactCount.
    * Remove-AzureRmAutoscaleSetting
        - The statusCode in the output follows the statusCode returned by the request. Before it was always Ok. 
    * Get-AzureRMLogProfile
        - The output is now enumerated. Before it was considered a single object. The type of the output remains a list as before.
    * Remove-AzureRmLogProfile
        - The PassThru parameter has been implemented.
    * Metrics API
        - The SDK now retrieves metrics from MDM.
    * Get-AzureRmMetricDefinition
        - The output is still a list, but the structure of the list changed.
    * Get-AzureRmMetric
        - The call has changed. This is the new syntax: Get-AzureRmMetric ResourceId [MetricNames [TimeGrain] [AggregationType] [StartTime] [EndTime]] [DetailedOutput]
        - The output is a list, and the structure of its elements has changed.
* KeyVault
    * Adding backup/restore support for KeyVault secrets
        - Secrets can be backed up and restored, matching the functionality currently supported for Keys
    
    * Backup cmdlets for Keys and Secrets now accept a corresponding object as an input parameter
        - The caller may chain retrieval and backup operations: Get-AzureKeyVaultKey -VaultName myVault -Name myKey | Backup-AzureKeyVaultKey
        
    * Backup cmdlets now support a -Force switch to overwrite an existing file
        - Note that attempting to overwrite an existing file will no longer throw, and will instead prompt the user for a choice on how to proceed.
* LogicApp
    * New parameters for Interchange Control Number disaster recovery cmdlets:
        - Optional -AgreementType parameter ("X12", or "Edifact") to specify the relevant control numbers
* MachineLearning
    * Consume new version of Azure Machine Learning .Net SDK and add a new cmdlet
        - Add-AzureRmMlWebServiceRegionalProperty 
    * Minor wording fixes in help text.
* Network
    * Added Test-AzureRmNetworkWatcherConnectivity cmdlet
        - Returns connectivity information for a specified source VM and a destination
        - If connectivity between the source and destination cannot be established, the cmdlet returns details about the issue
* Profile
    * Added `Send-Feedback' cmdlet: allows a user to initiate a set of prompts which sends feedback to the Azure PowerShell team.
    * The following aliases have been removed as they conflicted with existing cmdlet names in the Azure module:
        - `Enable-AzureDataCollection` (supported by `Enable-AzureRmDataCollection`)
        - `Disable-AzureDataCollection` (supported by `Disable-AzureRmDataCollection`)
* Relay
    * Adds cmdlets for the Azure Relay which allows users to create and manage all Azure Relay resources.
        - `New-AzureRmRelayNamespace`
        - `Get-AzureRmRelayNamespace`
        - `Set-AzureRmRelayNamespace`
        - `Remove-AzureRmRelayNamespace`
        - `New-AzureRmWcfRelay`
        - `Get-AzureRmWcfRelay`
        - `Set-AzureRmWcfRelay`
        - `Remove-AzureRmWcfRelay`
        - `New-AzureRmRelayHybridConnection`
        - `Get-AzureRmRelayHybridConnection`
        - `Set-AzureRmRelayHybridConnection`
        - `Remove-AzureRmRelayHybridConnection`
        - `Test-AzureRmRelayName`
        - `Get-AzureRmRelayOperation`
        - `New-AzureRmRelayKey`
        - `Get-AzureRmRelayKey`
        - `New-AzureRmRelayAuthorizationRule`
        - `Get-AzureRmRelayAuthorizationRule`
        - `Set-AzureRmRelayAuthorizationRule`
        - `Remove-AzureRmRelayAuthorizationRule`
* Resources
    * Support cross-resource-group deployments for New-AzureRmResourceGroupDeployment
        - Users can now use nested deployments to deploy to different resource groups.
* ServiceBus
    
    * Bug Fix: ServiceBus Queue object property values were set to null, the object is used as input parameter in Set-AzureRmServiceBusQueue cmdlet to update Queue. 
      - Properties affected are LockDuration, EntityAvailabilityStatus, DuplicateDetectionHistoryTimeWindow, MaxDeliveryCount and MessageCount 
* ServiceFabric
    
    * Added cmdlets for service fabric
        - Add-AzureRmServiceFabricApplicationCertificate
            Add a certificate which will be used as application certificate
        - Add-AzureRmServiceFabricClientCertificate
            Add a common name or thumbprint to the cluster settings for client authentication
        - Add-AzureRmServiceFabricClusterCertificate
            Add a secondary cluster certificate to the cluster for rolling over the existing certificate
        - Add-AzureRmServiceFabricNodes
            Add nodes/VMs of a specific node type to a cluster
        - Add-AzureRmServiceFabricNodeType
            Add a node type/VMs to an existing cluster
        - Get-AzureRmServiceFabricCluster
            Get the details of the cluster resource
        - New-AzureRmServiceFabricCluster
            Create a new ServiceFabric cluster. This command has many overloads to cover various scenarios
        - Remove-AzureRmServiceFabricClientCertificate
            Remove a client certificate from being used to access a cluster
        - Remove-AzureRmServiceFabricClusterCertificate
            Remove a cluster certificate from being used for cluster security
        - Remove-AzureRmServiceFabricNodes
            Remove nodes from a specific node type from a cluster
        - Remove-AzureRmServiceFabricNodeType
            Remove a node type from a cluster
        - Remove-AzureRmServiceFabricSettings
            Remove one or more ServiceFabric settings from a cluster
        - Set-AzureRmServiceFabricSettings
            Add or update one or more ServiceFabric settings of a cluster
        - Set-AzureRmServiceFabricUpgradeType
            Change the ServiceFabric upgrade type of a cluster
        - Update-AzureRmServiceFabricDurability
            Change the durability tier of a cluster
        - Update-AzureRmServiceFabricReliability
            Change the reliability tier of a cluster
* Sql
    * Added -SampleName parameter to New-AzureRmSqlDatabase
    * Updates to Failover Group cmdlets
    	- Remove 'Tag' parameters
    	- Remove 'PartnerResourceGroupName' and 'PartnerServerName' parameters from Remove-AzureRmSqlDatabaseFailoverGroup cmdlet
    	- Add 'GracePeriodWithDataLossHours' parameter to New- and Set- cmdlets, which shall eventually replace 'GracePeriodWithDataLossHour'
    	- Documentation has been fleshed out and updated
    	- Change formatting of returned objects and fix some bugs where fields were not always populated
    	- Add 'DatabaseNames' and 'PartnerLocation' properties to Failover Group object
    	- Fix bug causing Switch- cmdlet to return immediately rather than waiting for operation to complete
    	- Fix integer overflow bug when high grace period values are used
    	- Adjust grace period to a minimum of 1 hour if a lower one is provided
    * Remove "Usage_Anomaly" from the accepted values for "ExcludedDetectionType" parameter of Set-AzureRmSqlDatabaseThreatDetectionPolicy cmdlet and Set-AzureRmSqlServerThreatDetectionPolicy cmdlet. 
* Storage
    * Upgrade SRP SDK to 6.3.0
    * New/Set-AzureRmStorageAccount:Add a new parameter to support EnableHttpsTrafficOnly
    * New/Set/Get-AzureRmStorageAccount: Returned Storage Account contains a new attribute EnableHttpsTrafficOnly
* Azure.Storage
    * Upgrade to Azure Storage Client Library 8.1.1 and Azure Storage DataMovement Library 0.5.1
    * Add a new cmdlet to support blob Incremental Copy feature

## 2017.04.05 - Version 3.8.0
* Compute
    * Fix bug in Get-* cmdlets, to allow retrieving multiple pages of data (more than 120 items)
* DataLakeAnalytics
    * Fix help for some commands to have the proper verbage and examples.
* DataLakeStore
    * Add support for head and tail to the `Get-AzureRMDataLakeStoreItemContent` cmdlet. This enables returning the top N or last N new line delimited rows to be displayed.
* HDInsight
    * Added support for RServer cluster type
        - Edgenode VM size can be specified for RServer cluster in New-AzureRmHDInsightCluster or New-AzureRmHDInsightClusterConfig
        - RServer is now a configuration option in Add-AzureRmHDInsightConfigValues. It allows for RStudio flag to be set to indicate that R Studio installation should be done.
* LogicApp
    * Set-AzureRmIntegrationAccountSchema and Set-AzureRmIntegrationAccountMap cmdlets are fixed for the contentlink issue(Both content and contentlink were set resulting in update failure). 
* Network
    * Added support for new web application firewall features to Application Gateways
        - Added New-AzureRmApplicationGatewayFirewallDisabledRuleGroupConfig
        - Added Get-AzureRmApplicationGatewayAvailableWafRuleSets (Alias: List-AzureRmApplicationGatewayAvailableWafRuleSets)
        - Updated New-AzureRmApplicationGatewayWebApplicationFirewallConfiguration: Added parameter -RuleSetType -RuleSetVersion and -DisabledRuleGroups
        - Updated Set-AzureRmApplicationGatewayWebApplicationFirewallConfiguration: Added parameter -RuleSetType -RuleSetVersion and -DisabledRuleGroups
    * Added support for IPSec policies to Virtual Network Gateway Connections
    	- Added New-AzureRmIpsecPolicy
    	- Updated New-AzureRmVirtualNetworkGatewayConnection: Added parameter -IpsecPolicies and -UsePolicyBasedTrafficSelectors
* Profile
    * *Obsolete*: Save-AzureRmProfile is renamed to Save-AzureRmContext, there is an alias to the old cmdlet name, the alias will be removed in the next release.
    * *Obsolete*: Select-AzureRmProfile is renamed to Import-AzureRmContext, there is an alias to the old cmdlet name, the alias will be removed in the next release.
    * The PSAzureContext and PSAzureProfile output types of profile cmdlets will be changed in the next release.
    * The Save-AzureRmContext cmdlet will have no OutputType in the next release.
    * Fix bug in cmdlet common code to use FIPS-compliant algorithm for data hashes: https://github.com/Azure/azure-powershell/issues/3651 
* Sql
    * Bug fixes on Azure Failover Group Cmdlets
    	- Fix for operation polling
    	- Fix GracePeriodWithDataLossHour value when setting FailoverPolicy to Manual
* TrafficManager
    * Support for the Geographic traffic routing method
        - New value 'Geographic' for the TrafficRoutingMethod parameter of New-AzureRmTrafficManagerProfile
        - New parameter 'GeoMapping' for the New-AzureRmTrafficManagerEndpoint and Add-AzureRmTrafficManagerEndpointConfig
        - Fix piping for Get-AzureRmTrafficManagerProfile when it returns a collection of profiles
* ServiceManagement
    * Add initiate maintenance PowerShell cmdlet.
    * Add Maintenance Status field to Get-AzureVM response.
    * Added new cmdlets to support Recovery Services vault upgrade
        - Test-AzureRecoveryServicesVaultUpgrade
        - Invoke-AzureRecoveryServicesVaultUpgrade

## 2017.03.09 - Version 3.7.0
* ApiManagement
    * Added new cmdlets to manage Backend entity
        - New-AzureRmApiManagementBackend
        - Get-AzureRmApiManagementBackend
        - Set-AzureRmApiManagementBackend
        - Remove-AzureRmApiManagementBackend
    * Created supporting cmdlets to create in-memory objects required while Creating or Updating Backend entity
        - New-AzureRmApiManagementBackendCredential
        - New-AzureRmApiManagementBackendProxy
* Billing
    * New Cmdlet Get-AzureRmBillingInvoice
        - cmdlet to retrieve azure billing invoices of the subscription.
* Compute
    * Updated Set-AzureRmVMAEMExtension and Test-AzureRmVMAEMExtension cmdlets to support managed disks
* LogicApp
    * New cmdlets for X12 Interchange Control Number disaster recovery:
        - Get-AzureRmIntegrationAccountGeneratedIcn
        - Get-AzureRmIntegrationAccountReceivedIcn
        - Remove-AzureRmIntegrationAccountReceivedIcn
        - Set-AzureRmIntegrationAccountGeneratedIcn
        - Set-AzureRmIntegrationAccountReceivedIcn
* Network
    * Added support for connection draining to Application Gateways
        - Added Get-AzureRmApplicationGatewayConnectionDraining 
        - Added New-AzureRmApplicationGatewayConnectionDraining
        - Added Remove-AzureRmApplicationGatewayConnectionDraining 
        - Added Set-AzureRmApplicationGatewayConnectionDraining
        - Updated Add-AzureRmApplicationGatewayBackendHttpSettings: Added optional parameter -ConnectionDraining
        - Updated New-AzureRmApplicationGatewayBackendHttpSettings: Added optional parameter -ConnectionDraining
        - Updated Set-AzureRmApplicationGatewayBackendHttpSettings: Added optional parameter -ConnectionDraining
    
    * Remapped unused 'Name' parameter in ExpressRoute cmdlets to 'ExpressRouteCircuitName'
        - Get-AzureRmExpressRouteCircuitARPTable
        - Get-AzureRmExpressRouteCircuitRouteTable
        - Get-AzureRmExpressRouteCircuitRouteTableSummary
        - Get-AzureRmExpressRouteCircuitStats
* Sql
    * Bug fix - Auditing and Threat Detection cmdlets now return a meangfull error instead of null refernce error. 
    * Updating Transparent Data Encryption (TDE) with Bring Your Own Key (BYOK) support cmdlets for updated API.
* Websites
    * Update help documentation for AppServicePlan cmdlets
* ServiceManagement
    * Update the output object of migration cmdlets (Move-AzureService, Move-AzureStorageAccount, Move-AzureVirtualNetwork, Move-AzureNetworkSecurityGroup, Move-AzureReservedIP, Move-AzureRouteTable):
        - ValidationMessages contain "Information" and "Warning" messages in addition to "Error" messages.
        - Result output is changed according to ValidationMessages.
    
    * Removed ManagedCache cmdlets.  These cmdlets were non-functional and have been deeprecated for more than a year
        - Get-AzureManagedCacheLocation
        - Get-AzureManagedCache
        - Get-AzureManagedCacheAccessKey
        - Get-AzureManagedCacheNamedCache
        - New-AzureManagedCache
        - New-AzureManagedCacheAccessKey
        - New-AzureManagedCacheNamedCache
        - Remove-AzureManagedCache
        - Remove-AzureManagedCacheNamedCache
        - Set-AzureManagedCache
        - Set-AzureManagedCacheNamedCache

## 2017.02.22 - Version 3.6.0
* AnalysisServices
    * Added State property in additional to ProvisioningState
        - All the cmdlet returning AnalysisService would have a new property 'State' used outside of provisioing.
        - The 'State' is intended to check status outside of provisioning, while 'ProvisioningState' is intended to check status related to Provisioning.
        - ProvisioningState and State are same in service side at this moment, the service side would differenciate ProvisioningState and State in future
* CognitiveServices
    * Integrate with Cognitive Services Management SDK 0.2.1 to support more Cognitive Services API Types and SKUs.
    * Remove the validation against “Type” and “SkuName” of Cognitive Services Account, this will allow the script to support new APIs/SKUs without changes.
* Compute
    * Updated Set-AzureRmVMDscExtension cmdlet WmfVersion parameter to support "5.1"
    * Updated Set-AzureRmVMChefExtension cmdlet to add following new options :
      - Daemon: Configures the chef-client service for unattended execution. e.g. -Daemon 'none' or e.g. -Daemon 'service'."
      - Secret: The encryption key used to encrypt and decrypt the data bag item values.
      - SecretFile: The path to the file that contains the encryption key used to encrypt and decrypt the data bag item values.
    * Fix for Get-AzureRmVM: Get-AzureRmVM did not display anything when the output includes availability set property.
    * New cmdlets:
        - Update-AzureRmAvailabilitySet: can update an unmanaged availability set to a managed availability set.
        - Add-AzureRmVmssDataDisk, Remove-AzureRmVmssDataDisk
    * New parameter, SkipVmBackup, for cmdlet Set-AzureRmVMDiskEncryptionExtension to allow user to skip backup creation for Linux VMs
* DataFactories
    * Fixed Get-AzureRmDataFactoryActivityWindow so it works for named pipeline and activity
* DataLakeAnalytics
    * Add Firewall Rule support to Data Lake Analytics:
        - Add-AzureRMDataLakeAnalyticsFirewallRule
        - Get-AzureRMDataLakeAnalyticsFirewallRule
        - Set-AzureRMDataLakeAnalyticsFirewallRule
        - Remove-AzureRMDataLakeAnalyticsFirewallRule
        - Set-AzureRMDataLakeAnalyticsAccount supports enabling/disabling the firewall and allowing/blocking Azure originating IPs through the firewall
        - Warnings will be raised if updating firewall rules when the firewall is disabled
    * Fix Get-AzureRMDataLakeAnalyticsJob functionality:
        - Top now correctly returns the number of jobs specified. The default number of jobs to return is 500. The more jobs requested the longer the command will take.
    * Remove explicit restrictions on resource locations. If Data Lake Analytics is not supported in a region, we will surface an error from the service.
* DataLakeStore
    * Update Upload and Download commands to use the new and improved Upload/Download helpers in the new DataLake.Store clients. This also gives better diagnostic logging, if enabled.
    * Default thread counts for Upload and download are now computed on a best effort basis based on the data being uploaded or downloaded. This should allow for good performance without specifying a thread count.
    * Update to Set-AzureRMDataLakeStoreAccount to allow for enabling and disabling Azure originating IPs through the firewall
    * Add warnings to Add and Set-AzureRMDataLakeStoreFirewallRule and AzureRMDataLakeStoreTrustedIdProvider if they are disabled
    * Remove explicit restrictions on resource locations. If Data Lake Store is not supported in a region, we will surface an error from the service.
* EventHub
    * Future Breaking Change Notification: We've added a warning about removing property 'ResourceGroupName' from the returned NamespceAttributes from cmdlets New-AzureRmEventHubNamespace, Get-AzureRmEvnetHubNamespace and Set-AzureRmEvnetHubNamespace
* Insights
    * Allow users to unselect data sinks for Set-AzureRmDiagnosticSettings
* Network
    * Added support for network Watcher APIs
        - New-AzureRmNetworkWatcher
        - Get-AzureRmNetworkWatcher
        - Remove-AzureRmNetworkWatcher
        - New-AzureRmPacketCaptureFilterConfig
        - New-AzureRmNetworkWatcherPacketCapture
        - Get-AzureRmNetworkWatcherPacketCapture
        - Stop-AzureRmNetworkWatcherPacketCapture
        - Remove-AzureRmNetworkWatcherPacketCapture
        - Get-AzureRmNetworkWatcherFlowLogSatus
        - Get-AzureRmNetworkWatcherNextHop
        - Get-AzureRmNetworkWatcherSecurityGroupView
        - Get-AzureRmNetworkWatcherTopology
        - Get-AzureRmNetworkWatcherTroubleshootingResult
        - Set-AzureRmNetworkWatcherConfigFlowLog
        - Start-AzureRmNetworkWatcherResourceTroubleshooting
        - Test-AzureRmNetworkWatcherIPFlow
    * Add-AzureRmExpressRouteCircuitPeeringConfig
        - Added new param :-RouteFilter to associate the BGP with route filter to filter out BGP communities via Microsoft peering. This parameter is set by resource
        - Added new param :-RouteFilterId to associate the BGP with route filter to filter out BGP communities via Microsoft peering. This parameter is set by resource id
    * New-AzureRmExpressRouteCircuitPeeringConfig
        - Added new param :-RouteFilter to associate the BGP with route filter to filter out BGP communities via Microsoft peering. This parameter is set by resource
        - Added new param :-RouteFilterId to associate the BGP with route filter to filter out BGP communities via Microsoft peering. This parameter is set by resource id
    * Set-AzureRmExpressRouteCircuitPeeringConfig
        - Added new param :-RouteFilter to associate the BGP with route filter to filter out BGP communities via Microsoft peering. This parameter is set by resource
        - Added new param :-RouteFilterId to associate the BGP with route filter to filter out BGP communities via Microsoft peering. This parameter is set by resource id
    * New cmdlets for selective service feature 
        - Get-AzureRmRouteFilter
        - New-AzureRmRouteFilter
        - Set-AzureRmRouteFilter
        - Remove-AzureRmRouteFilter
        - Add-AzureRmRouteFilterRuleConfig
        - Get-AzureRmRouteFilterRuleConfigobject
        - New-AzureRmRouteFilterRuleConfig
        - Set-AzureRmRouteFilterRuleConfig
        - Remove-AzureRmRouteFilterRuleConfig
* Resources
    * Support policy parameters for New-AzureRmPolicyDefinition and New-AzureRmPolicyAssignment
        - Users can now use Parameter parameter with New-AzureRmPolicyDefinition. This accepts both JSON string and file path.
        - Users can now provide policy parameter values in New-AzureRmPolicyAssignment in a couple of ways, including JSON string, file path, PS object, and through PowerShell parameters. 
* Scheduler
    * Fixed issue to properly encode HTTP jobs' callback Uri in Scheduler PowerShell cmdlet
* Sql
    * Adding new cmdlets for support for Azure SQL feature Transparent Data Encryption (TDE) with Bring Your Own Key (BYOK) Support
    	- TDE with BYOK support is a new feature in Azure SQL, which allows users to encrypt their database with a key from Azure Key Vault. This feature is currently in private preview.
    	- Get-AzureRmSqlServerKeyVaultKey : This cmdlet returns a list of Azure Key Vault keys added to a Sql Server.
    	- Add-AzureRmSqlServerKeyVaultKey : This cmdlet adds an Azure Key Vault key to a Sql Server.
    	- Remove-AzureRmSqlServerKeyVaultKey : This cmdlet removes an Azure Key Vault key from a Sql Server.
    	- Get-AzureRmSqlServerTransparentDataEncryptionProtector : This cmdlet returns the current encryption protector for a Sql Server.
    	- Set-AzureRmSqlServerTransparentDataEncryptionProtector : This cmdlet sets the encryption protector for a Sql Server. The encryption protector can be set to a key from Azure Key Vault or a key that is managed by Azure Sql.
    * New feature: Set--AzureRmSqlDatabaseAuditing  and Set-AzureRmSqlDatabaseServerAuditingPolicy supports setting secondary storage key for AuditType Blob 
    * Bug fix: Remove-AzureRmSqlDatabaseAuditing should set the UseServerDefault value to disabled 
    * Bug fix: Fixing an issue of selecting classic storage account when creating / updating Auditing or Threat Detection policies
    * Bug fix: Set-AzureRmSqlDatabaseAuditing and Set-AzureRmSqlDatabaseServerAuditingPolicy commands use the AuditType value that was previously defined in case it has not been configured by the user.
    * Bug fix: In case Blob Auditing is defined, Remove-AzureRmSqlDatabaseAuditing and Remove-AzureRmSqlDatabaseServerAuditingPolicy commands disable the Auditing settings.
    * Adding new cmdlets for support for Azure SQL feature AutoDR:
        -This is a new feature in Azure SQL that supports failover of multiple Azure Sql Databases to the partner server at the same time during disaster and allows automatic failover
        - Add-AzureRmSqlDatabaseToFailoverGroup add Azure Sql Databases into a Failover Group
        - Get-AzureRmSqlDatabaseFailoverGroup get the Failover Group entity
        - New-AzureRmSqlDatabaseFailoverGroup creates a new Failover Group
        - Remove-AzureRmSqlDatabaseFromFailoverGroup removes Azure Sql Databases from a Failover Group
        - Remove-AzureRmSqlDatabaseFailoverGroup Failover Group deletes the Failover Group
        - Set-AzureRmSqlDatabaseFailoverGroup set Azure Sql Database Failover Policy and Grace Period entities of the Failover Group
        - Switch-AzureRmSqlDatabaseFailoverGroup issues the failover operation with data loss or without data loss  
* Storage
    * Upgrade Microsoft.Azure.Management.Storage to version 6.1.0-preview
    * Add File Encryption features support to resource mode storage account cmdlets
        - New-AzureRmStorageAccount
        - Set-AzureRmStorageAccount
    
* ServiceManagement
    * Updated Set-AzureVMDscExtension cmdlet WmfVersion parameter to support "5.1"
    
    * Updated Set-AzureVMChefExtension cmdlet to add following new options :
        - Daemon: Configures the chef-client service for unattended execution. e.g. -Daemon 'none' or e.g. -Daemon 'service'."
        - Secret: The encryption key used to encrypt and decrypt the data bag item values.
        - SecretFile: The path to the file that contains the encryption key used to encrypt and decrypt the data bag item values.

## 2017.01.18 - Version 3.4.0
* AnalysisServices
    * Added two new dataplane APIs in a separate module Azure.AnalysisServices.psd1
        - This introduces two new APIs that enable customers to login to Azure Analysis Services servers and issue a restart command.
* Compute
    * Fix Get-AzureRmVM with -Status issue: Get-AzureRmVM throws an exception when Get-AzureRmVM lists multiple VMs and some of the VMs are deleted during Get-AzureRmVM is performed.
    * New parameters in New-AzureRmVMSqlServerAutoBackupConfig cmdlet to support Auto Backup for SQL Server 2016 VMs.
    	- BackupSystemDbs : Specifies if system databases should be added to Sql Server Managed Backup.
    	- BackupScheduleType : Specifies the type of managed backup schedule, manual or automated. If it's manual, schedule settings need to be specified.
    	- FullBackupFrequency : Specifies the frequency of Full Backup, daily or weekly.
    	- FullBackupStartHour : Specifies the hour of the day when the Sql Server Full Backup should start.
    	- FullBackupWindowInHours : Specifies the window (in hours) when Sql Server Full Backup should occur.
    	- LogBackupFrequencyInMinutes : Specifies the frequency of Sql Server Log Backup.
    * New-AzureVMSqlServer* cmdlets are renamed to New-AzureRmVMSqlServer* now. Old ones will continue to work however.
* DataLakeAnalytics
    * Update Get-AdlJob to support Top parameter
    * Update Get-AdlJob to return the list of jobs in order by most recently submitted
    * Updated help for all cmdlets to include output as well as more descriptions of parameters and the inclusion of aliases.
    * Update New-AdlAnalyticsAccount and Set-AdlAnalyticsAccount to support commitment tier options for the service.
    * Added OutputType mismatch warnings to all cmdlets with incorrect OutputType attributes. These will be fixed in a future breaking change release.
* DataLakeStore
    * Updated help for all cmdlets to include output as well as more descriptions of parameters and the inclusion of aliases.
    * Update New-AdlStore and Set-AdlStore to support commitment tier options for the service.
    * Added OutputType mismatch warnings to all cmdlets with incorrect OutputType attributes. These will be fixed in a future breaking change release.
    * Add Diagnostic logging support to Import-AdlStoreItem and Export-AdlStoreItem. This can be enabled through the following parameters:
        * -Debug, enables full diagnostic logging as well as debug logging to the PowerShell console. Most verbose options
        * -DiagnosticLogLevel, allows finer control of the output than debug. If used with debug, this is ignored and debug logging is used.
        * -DiagnosticLogPath, optionally specify the file to write diagnostic logs to. By default it is written to a file under %LOCALAPPDATA%\AdlDataTransfer
    * Added support to New-AdlStore to explicitly opt-out of account encryption. To do so, create the account with the -DisableEncryption flag.
* OperationalInsights
    * Get-AzureRmOperationalInsightsSearchResults no longer requires the Top parameter to retrieve results
* Resources
    * Support Tag as parameters for Find-AzureRmResource
        - Users can now use Tag parameter with Find-AzureRmResource
        - Fixed the issue where illegal combinations of TagName, TagValue with other search parameters was allowed in Find-AzureRmResource and would result in users getting exception from the service by disallowing such combinations. 
* ServiceBus
    * Add SkuCapacity parameter to Set-AzureRmServiceBusNamespace
        - User will be able to update the SkuCapacity(Messaging units in case of a premium namespace) of the SeriveBus NameSpace
    
    * Future Breaking Change Notification: We've added a warning about removing property 'ResourceGroupName' from the returned NamespceAttributes from cmdlets New-AzureRmServiceBusNamespace, Get-AzureRmServiceBusNamespace and Set-AzureRmServiceBusNamespace
        -The call remains the same, but the returned values NameSpace object will not have the ResourceGroupName property  
* Sql
    * Added new return parameter "AuditType" to Get-AzureRmSqlDatabaseAuditingPolicy and Get-AzureRmSqlServerAuditingPolicy returned object
        - This parameter value indicates the returned auditing policy type - Table or Blob.
* ServiceManagement
    * New parameters in New-AzureVMSqlServerAutoBackupConfig cmdlet to support Auto Backup for SQL Server 2016 VMs.
    	- BackupSystemDbs : Specifies if system databases should be added to Sql Server Managed Backup.
    	- BackupScheduleType : Specifies the type of managed backup schedule, manual or automated. If it's manual, schedule settings need to be specified.
    	- FullBackupFrequency : Specifies the frequency of Full Backup, daily or weekly.
    	- FullBackupStartHour : Specifies the hour of the day when the Sql Server Full Backup should start.
    	- FullBackupWindowInHours : Specifies the window (in hours) when Sql Server Full Backup should occur.
    	- LogBackupFrequencyInMinutes : Specifies the frequency of Sql Server Log Backup.
* Storage
    * Fix Start-AzureStorageBlobCopy output might has wrong BlobType issue
        - Start-AzureStorageBlobCopy
    * Fix hang issue when running cmdlets from WPF/Winform context  
        - Get-AzureStorageBlob
        - Get-AzureStorageBlobContent
        - Get-AzureStorageBlobCopyState
        - Get-AzureStorageContainer
        - Get-AzureStorageContainerStoredAccessPolicy
        - New-AzureStorageContainer
        - Remove-AzureStorageBlob
        - Remove-AzureStorageContainer
        - Set-AzureStorageBlobContent
        - Set-AzureStorageContainerAcl
        - Start-AzureStorageBlobCopy
        - Stop-AzureStorageBlobCopy
        - Get-AzureStorageFile
        - Get-AzureStorageFileContent
        - Get-AzureStorageFileCopyState
        - Get-AzureStorageShare
        - Get-AzureStorageShareStoredAccessPolicy
        - New-AzureStorageDirectory
        - New-AzureStorageShare
        - Remove-AzureStorageDirectory
        - Remove-AzureStorageFile
        - Remove-AzureStorageShare
        - Set-AzureStorageFileContent
        - Start-AzureStorageFileCopy
        - Stop-AzureStorageFileCopy
        - Get-AzureStorageQueueStoredAccessPolicy
        - Get-AzureStorageTableStoredAccessPolicy 

## 2016.12.14 - Version 3.3.0
* ApiManagement
    * Added new cmdlets to manage external Identity Provider Configurations
        - New-AzureRmApiManagementIdentityProvider
        - Set-AzureRmApiManagementIdentityProvider
        - Get-AzureRmApiManagementIdentityProvider
        - Remove-AzureRmApiManagementIdentityProvider
    * Updated the client to use .net client 3.2.0 AzureRm.ApiManagement which has RBAC support
    * Updated cmdlet Import-AzureRmApiManagementApi to allow importing an Wsdl type API as either Soap Pass Through (ApiType = Http) or Soap To Rest (ApiType = Soap). Default is Soap Pass Through.
    * Fixed Issue https://github.com/Azure/azure-powershell/issues/3217
* Compute
    * Add Remove-AzureRmVMSecret cmdlet.
    * Based on user feedback (https://github.com/Azure/azure-powershell/issues/1384), we've added a DisplayHint property to VM object to enable Compact and Expand display modes. This is similar to `Get -Date - DisplayHint Date` cmdlet. By default, the return of `Get-AzureRmVm -ResourceGroupName <rg-name> -Name <vm-name>` will be compact. You can expand the output using `-DisplayHint Expand` parameter.
    * UPCOMING BREAKING CHANGE Notification: We've added a warning about removing ` DataDiskNames` and ` NetworkInterfaceIDs` properties from the returned VM object from `Get-AzureRmVm -ResourceGroupName <rg-name> -Name <vm-name` cmdlet. Please update your scripts to access these properties in the following way:
        - `$vm.StorageProfile.DataDisks`
        - `$vm.NetworkProfile.NetworkInterfaces`
    * Updated Set-AzureRmVMChefExtension cmdlet to add following new options :
        - JsonAttribute : A JSON string to be added to the first run of chef-client. e.g. -JsonAttribute '{"container_service": {"chef-init-test": {"command": "C:\\opscode\\chef\\bin"}}}'
        - ChefServiceInterval : Specifies the frequency (in minutes) at which the chef-service runs. If in case you don't want the chef-service to be installed on the Azure VM then set value as 0 in this field. e.g. -ChefServiceInterval 45
* DataLakeAnalytics
    * Removal of unsupported parameters in Add and Set-AzureRMDataLakeAnalyticsDataSource (default for data lake store)
    * Removed unsupported parameter in Set-AzureRMDataLakeAnalyticsAccount (default data lake store)
    * Introduction of deprecation warning for nested properties for all ARM resources. Nested properties will be removed in a future release and all properties will be moved one level up.
    * Added the ability to set MaxDegreeOfParallelism, MaxJobCount and QueryStoreRetention in New and Set-AzureRMDataLakeAnalyticsAccount
    * Removed invalid return value from New-AzureRMDataLakeAnalyticsCatalogSecret
* DataLakeStore
    * Introduction of deprecation warning for nested properties for all ARM resources. Nested properties will be removed in a future release and all properties will be moved one level up.
    * Removed the ability to set encryption in Set-AzureRMDataLakeStoreAccount (never was supported)
    * Added ability to enable/disable firewall rules and the trusted id providers during Set-AzureRMDataLakeStoreAccount
    * Added a new cmdlet: Set-AzureRMDataLakeStoreItemExpiry, which allows the user to set or remove the expiration for files (not folders) in their ADLS account.
    * Small fix for friendly date properties to pivot off UTC time instead of local time, ensuring standard time reporting.
* EventHub
    * Adds commandlets for the Azure EventHub
        - New-AzureRmEventHubNamespace
            - Adds a New EventHub NameSpace in the existing Resource Group.
        - Get-AzureRmEventHubNamespace
            - Gets Eventhub NameSpace/list of NameSpaces of existing Resource Group.
        - Set-AzureRmEventHubNamespace
            - Updates properties of existing EventHub NameSpace.
        - Remove-AzureRmEventHubNamespace
            - Deletes the existing EventHub NameSpace.
        - New-AzureRmEventHubNamespaceAuthorizationRule
            - Adds a new AuthorizationRule to the existing EventHub NameSpace.
        - Get-AzureRmEventHubNamespaceAuthorizationRule
            - Gets AuthorizationRule / List of AuthorizationRules for the existing EventHub NameSpace.
        - Set-AzureRmEventHubNamespaceAuthorizationRule
            - Updates properties of existing AuthorizationRule of EventHub NameSpace.
        - New-AzureRmEventHubNamespaceKey
            - Generates a new Primary/Secondary Key for AuthorizationRule of existing EventHub NameSpace.
        - Get-AzureRmEventHubNamespaceKey
            - Gets Primary/Secondary Key for AuthorizationRule of existing EventHub NameSpace.
        - Remove-AzureRmEventHubNamespaceAuthorizationRule
            - Deletes the existing AuthorizationRule of EventHub NameSpace.
        - New-AzureRmEventHub
            - Adds a new EventHub to the existing NameSpace.
        - Get-AzureRmEventHub
            - Gets existing Queue/ List of EventHub of the existing NameSpace.
        - Set-AzureRmEventHub
            - Updates properties of existing EventHub of NameSpace.
        - Remove-AzureRmEventHub
            - Deletes existing EventHub of NameSpace.
        - New-AzureRmEventHubAuthorizationRule
            - Adds a new AuthorizationRule to the existing EventHub of NameSpace.
        - Get-AzureRmEventHubAuthorizationRule
            - Gets the AuthorizationRule / List of AuthorizationRules of the EventHub. 
        - Set-AzureRmEventHubAuthorizationRule
            - Updates the AuthorizationRule of the EventHub.
        - New-AzureRmEventHubKey
            - Generates a new Primary/Secondary Key for AuthorizationRule of existing EventHub.
        - Get-AzureRmEventHubKey
            - Gets Primary/Secondary Key for AuthorizationRule of existing EventHub.
        - Remove-AzureRmEventHubAuthorizationRule
            - Deletes the existing AuthorizationRule of EventHub.
        - New-AzureRmEventHubConsumerGroup
            - Adds a new ConsumerGroup to the existing EventHub
        - Get-AzureRmEventHubConsumerGroup
            - Gets existing ConsumerGroup/ List of ConsumerGroups of the existing EventHub.
        - Set-AzureRmEventHubConsumerGroup
            - Updates properties of existing ConsumerGroup of EventHub.
        - Remove-AzureRmEventHubConsumerGroup
            - Deletes existing ConsumerGroup of EventHub.
* Insights
    * Parameter now accepts two more values in New-AzureRmAutoscaleRule
        - Parameter ScaleType now accepts the previous ChangeCount (default) plus two more values PercentChangeCount, and ExactCount
        - Add a warning message about this parameter accepting two more values
    * Add parameter became optional in Add-AzureRmLogProfile
        - Parameter StorageAccountId is now optional
    * Minor changes to the output classes to expose more properties
        - Before the user could see the properties because they were printed, but not access them programatically because they were protected for instance.
* IotHub
    * Adds commandlets for the Azure IoT Hub 
        - Add-AzureRmIotHubEventHubConsumerGroup
            - Adds an Event Hub consumer group for an existing Azure IoT hub.
        - Add-AzureRmIotHubKey
            - Adds a new key to an existing Azure IoT hub.
        - Get-AzureRmIotHub
            - Gets the properties of an exisiting Azure IoT hub.
        - Get-AzureRmIotHubConnectionString
            - Gets the connection strings of an existing Azure IoT hub.
        - Get-AzureRmIotHubEventHubConsumerGroup
            - Gets the list of event hub consumer groups for the specified eventhub endpoint.
        - Get-AzureRmIotHubJob
            - Gets the properties of a set of Azure IoT hubs in a subscription or resource group.
        - Get-AzureRmIotHubKey
            - Gets the information related to a list of keys of an Azure IoT hub.
        - Get-AzureRmIotHubQuotaMetric
            - Gets the quota metrics for an Azure IoT hub.
        - Get-AzureRmIotHubRegistryStatistic
            - Gets the registry statistics for an Azure IoT hub.
        - Get-AzureRmIotHubValidSku
            - Gets the list of valid Skus to which an existing Azure IoT hub can transition to.
        - New-AzureRmIotHub
            - Creates a new Azure IoT hub.
        - New-AzureRmIotHubExportDevices
            - Starts a new job for exporting the devices of an Azure IoT hub.
        - New-AzureRmIotHubImportDevices
            - Starts a new job for importing the devices of an Azure IoT hub.
        - Remove-AzureRmIotHub
            - Removes an Azure IoT hub.
        - Remove-AzureRmIotHubEventHubConsumerGroup
            - Removes a consumer group for the specified event hub endpoint of a give Azure IoT hub.
        - Remove-AzureRmIotHubKey
            - Removes a key from an Azure IoT hub.
        - Set-AzureRmIotHub
            - Updates the properties of an Azure IoT hub.
* MachineLearning
    * Serialization and deserialization improvements for all cmdlets
* NotificationHubs
    * Added the skuTier parameter to set the sky for namespace
        - New-AzureRmNotificationHubsNamespace
        - Set-AzureRmNotificationHubsNamespace
* RecoveryServices.Backup
    * Migrated from Hyak based Azure SDK to Swagger based Azure SDK
* Resources
    * Support ResourceNameEquals and ResourceGroupNameEquals as parameters for Find-AzureRmResource
        - Users can now use ResourceNameEquals and ResourceGroupNameEquals with Find-AzureRmResource
* ServiceBus
    * Adds commandlets for the Azure ServiceBus
        - New-AzureRmServiceBusNamespace
            - Adds a New ServiceBus NameSpace in the existing Resource Group.
        - Get-AzureRmServiceBusNamespace
            - Gets NameSpace/list of NameSpaces of existing Resource Group.
        - Set-AzureRmServiceBusNamespace
            - Updates properties of existing Servicebus NameSpace.
        - Remove-AzureRmServiceBusNamespace
            - Deletes the existing ServiceBus NameSpace.
        - New-AzureRmServiceBusNamespaceAuthorizationRule
            - Adds a new AuthorizationRule to the existing ServiceBus NameSpace.
        - Get-AzureRmServiceBusNamespaceAuthorizationRule
            - Gets AuthorizationRule / List of AuthorizationRules for the existing ServiceBus NameSpace.
        - Set-AzureRmServiceBusNamespaceAuthorizationRule
            - Updates properties of existing AuthorizationRule of Servicebus NameSpace.
        - New-AzureRmServiceBusNamespaceKey
            - Generates a new Primary/Secondary Key for AuthorizationRule of existing ServiceBus NameSpace.
        - Get-AzureRmServiceBusNamespaceKey
            - Gets Primary/Secondary Key for AuthorizationRule of existing ServiceBus NameSpace.
        - Remove-AzureRmServiceBusNamespaceAuthorizationRule
            - Deletes the existing AuthorizationRule of ServiceBus NameSpace.
        - New-AzureRmServiceBusQueue
            - Adds a new Queue to the existing ServiceBus NameSpace.
        - Get-AzureRmServiceBusQueue
            - Gets existing Queue/ List of Queues of the existing ServiceBus NameSpace.
        - Set-AzureRmServiceBusQueue
            - Updates properties of existing Queue of ServiceBus NameSpace.
        - Remove-AzureRmServiceBusQueue
            - Deletes existing Queue of ServiceBus NameSpace.
        - New-AzureRmServiceBusQueueAuthorizationRule
            - Adds a new AuthorizationRule to the existing Queue of ServiceBus NameSpace.
        - Get-AzureRmServiceBusQueueAuthorizationRule
            - Gets the AuthorizationRule / List of AuthorizationRules of the Queue 
        - Set-AzureRmServiceBusQueueAuthorizationRule
            - Updates the AuthorizationRule of the Queue.
        - New-AzureRmServiceBusQueueKey
            - Generates a new Primary/Secondary Key for AuthorizationRule of existing ServiceBus Queue.
        - Get-AzureRmServiceBusQueueKey
            - Gets Primary/Secondary Key for AuthorizationRule of existing ServiceBus Queue.
        - Remove-AzureRmServiceBusQueueAuthorizationRule
            - Deletes the existing AuthorizationRule of ServiceBus Queue.
        - New-AzureRmServiceBusTopic
           - Adds a new Topic to the existing ServiceBus NameSpace.
        - Get-AzureRmServiceBusTopic
           - Gets existing Topic/ List of Topics of the existing ServiceBus NameSpace.
        - Set-AzureRmServiceBusTopic
           - Updates properties of existing Topic of ServiceBus NameSpace.
        - Remove-AzureRmServiceBusTopic
           - Deletes existing Topic of ServiceBus NameSpace.
        - New-AzureRmServiceBusTopicAuthorizationRule
           - Adds a new AuthorizationRule to the existing Topic of ServiceBus NameSpace.
        - Get-AzureRmServiceBusTopicAuthorizationRule
           - Gets the AuthorizationRule / List of AuthorizationRules of the Topic.
        - Set-AzureRmServiceBusTopicAuthorizationRule
           - Updates the AuthorizationRule of the Topic.
        - New-AzureRmServiceBusTopicKey
           - Generates a new Primary/Secondary Key for AuthorizationRule of existing ServiceBus Topic.
        - Get-AzureRmServiceBusTopicKey
           - Gets Primary/Secondary Key for AuthorizationRule of existing ServiceBus Topic.
        - Remove-AzureRmServiceBusTopicAuthorizationRule
           - Deletes the existing AuthorizationRule of ServiceBus Topic.
        - New-AzureRmServiceBusSubscription
           - Adds a new Subscription to the existing ServiceBus Topic.
        - Get-AzureRmServiceBusSubscription
            - Gets existing Subscription/ List of Subscriptions of the existing ServiceBus Topic.
        - Set-AzureRmServiceBusSubscription
            - Updates properties of existing Subscription of ServiceBus Topic.
        - Remove-AzureRmServiceBusSubscription
            - Deletes existing Subscription of ServiceBus Topic.
* Sql
    * Added storage properties to cmdlets for Azure SQL threat detection policy management at database and server level 
        - StorageAccountName
        - RetentionInDays
    * Removed the unsupported param "AuditAction" from Set-AzureSqlDatabaseServerAuditingPolicy
    * Added new param "AuditAction" to Set-AzureSqlDatabaseAuditingPolicy
    * Fix for showing on GET and persisting Tags on SET (if not given) for Database, Server and Elastic Pool 
        - If Tags is used in command it will save tags, if not it will not wipe out tags on resource.
    * Fix for showing on GET and persisting Tags on SET (if not given) for Database, Server and Elastic Pool 
        - If Tags is used in command it will save tags, if not it will not wipe out tags on resource.
    * Changes for "New-AzureRmSqlDatabase", "Set-AzureRmSqlDatabase" and "Get-AzureRmSqlDatabase" cmdlets
        - Adding a new parameter called "ReadScale" for the 3 cmdlets above.
        - The "ReadScale" parameter has 2 possibl values: "Enabled" or "Disabled" to indicate whether the ReadScale option is turned on for the database.
    * Functionality of ReadScale Feature.
        - ReadScale is a new feature in SQL Database, which allows the user to enabled/disable routing read-only requests to Geo-secondary Premium databases.
        - This feature allows the customer to scale up/down their read-only workload flexibly, and unlocked more DTUs for the premium database.
        - To configure ReadScale, user simply specify "ReadScale" paramter with "Enabled/Disabled" at database creation with New-AzureRmSqlDatabase cmdlet, 
* Websites
    * Add: PerSiteScaling option on cmdlets New-AzureRmAppservicePlan and Set-AzureRmAppServicePlan
    * Add: NumberOfWorkers option on cmdlets Set-AzureRmWebApp and Set-AzureRmWebAppSlot
    * Add: Help documentation using platyPS
* ServiceManagement
    * Updated Set-AzureVMChefExtension cmdlet to add following new options :
        - JsonAttribute : A JSON string to be added to the first run of chef-client. e.g. -JsonAttribute '{"container_service": {"chef-init-test": {"command": "C:\\opscode\\chef\\bin"}}}'
        - ChefServiceInterval : Specifies the frequency (in minutes) at which the chef-service runs. If in case you don't want the chef-service to be installed on the Azure VM then set value as 0 in this field. e.g. -ChefServiceInterval 45
    * Updated New-AzureVirtualNetworkGatewayConnection cmdlet to add validation on acceptable input parameter:GatewayConnectionType values sets and it can be case insensitive:
        - GatewayConnectionType : Added validation to accept only set of values:- 'ExpressRoute'/'IPsec'/'Vnet2Vnet'/'VPNClient' and acceptable set of values can be passed in any casing.
    * Updating Managed Cache warning message which notifies customer about service deprecation on the following cmdlets :
        - Get-AzureManagedCache
        - Get-AzureManagedCacheAccessKey
        - Get-AzureManagedCacheLocation
        - Get-AzureManagedCacheNamedCache
        - New-AzureManagedCache
        - New-AzureManagedCacheAccessKey
        - New-AzureManagedCacheNamedCache
        - Remove-AzureManagedCache
        - Remove-AzureManagedCacheNamedCache
        - Set-AzureManagedCache
        - Set-AzureManagedCacheNamedCache
    * For more information about Managed Cache service deprecation, see http://go.microsoft.com/fwlink/?LinkID=717458

## 2016.11.14 - Version 3.2.0
* Network
	* Get-AzureRmVirtualNetworkGatewayConnection
	    - Added new param :- TunnelConnectionStatus in output Connection object to show per tunnel connection health status.
	* Reset-AzureRmVirtualNetworkGateway
	    - Added optional input param:- gatewayVip to pass gateway vip for ResetGateway API in case of Active-Active feature enabled gateways.
	    - Gateway Vip can be retrieved from PublicIPs refered in VirtualNetworkGateway object.

## 2016.11.02 - Version 3.1.0
* ApiManagement
    * Fixed cmdlet Import-AzureRmApiManagementApi when importing Api by SpecificationByUrl parameter
    * New-AzureRmApiManagement supports creating an ApiManagement service in a VirtualNetwork and with additional regions
* AzureBatch
    * Rename cmdlet Get-AzureRmBatchSubscriptionQuotas to Get-AzureRmBatchLocationsQuotas (an alias for the old command was created)
        - Rename return type PSBatchSubscriptionQuotas to PSBatchLocationQuotas (no property changes)
* Compute
    * Update formats for list of VMs, VMScaleSets and ContainerService
        - The default format of Get-AzureRmVM, Get-AzureRmVmss and Get-AzureRmContainerService is not table format when these cmdlets call List Operation
    * Fix overprovision issue for VMScaleSet
        - Because of the bug in Compute client library (and Swagger spec) regarding overprovision property of VMScaleSet, this property did not show up correctly.
    * Better piping scenario for VMScaleSets and ContainerService cmdlets
        - VMScaleSet and ContainerService now have "ResourceGroupName" property, so when piping Get command to Delete/Update command, -ResourceGroupName is not required.
    * Separate paremater sets for Set-AzureRmVM with Generalized and Redeploy parameter
    * Reduce time taken by Get-AzureRmVMDiskEncryptionStatus cmdlet from two minutes to under five seconds
    * Allow Set-AzureRmVMDiskEncryptionStatus to be used with VHDs residing in multiple resource groups
* DataLakeAnalytics
    * Addition of Catalog CRUD cmdlets:
        - The following cmdlets are replacing Secret CRUD cmdlets. In the next release Secret CRUD cmdlets will be removed.
        - New-AzureRMDataLakeAnalyticsCatalogCredential
        - Set-AzureRMDataLakeAnalyticsCatalogCredential
        - Remove-AzureRMDataLakeAnalyticsCatalogCredential
    * Fixes for Get-AzureRMDataLakeAnalyticsCatalogItem
        - Better error messaging and support for invalid input
    * General help improvements
        - Clearer help for job operations
        - Fixed typos and incorrect examples
* DataLakeStore
    * Improvements to import and export data cmdlets
        - Drastically increased performance for distributed download scenarios, where multiple sessions are running across many clients targeting the same ADLS account.
        - Better error handling and messaging for both upload and download scenarios.
    * Full Firewall rules management CRUD
        - The below cmdlets can be used to manage firewall rules for an ADLS account:
        - Add-AzureRMDataLakeStoreFirewallRule
        - Set-AzureRMDataLakeStoreFirewallRule
        - Get-AzureRMDataLakeStoreFirewallRule
        - Remove-AzureRMDataLakeStoreFirewallRule
    * Full Trusted ID provider management CRUD
        - The below cmdlets can be used to manage trusted identity providers for an ADLS account:
        - Add-AzureRMDataLakeStoreTrustedIdProvider
        - Set-AzureRMDataLakeStoreTrustedIdProvider
        - Get-AzureRMDataLakeStoreTrustedIdProvider
        - Remove-AzureRMDataLakeStoreTrustedIdProvider
    * Account Encryption Support
        - You can now encrypt newly created ADLS accounts as well as enable encryption on existing ADLS accounts using the New-AzureRMDataLakeStoreAccount and Set-AzureRMDataLakeStoreAccount cmdlets, respectively.
* HDInsight
    * Add support to create HDInsight Spark 2.0 cluster using new cmdlet Add-AzureRmHDInsightComponentVersion to specify the component version of Spark
    * Get-AzureRmHDInsightCluster now returns the component version in a Spark 2.0 cluster
    * New cmdlet
        - Add-AzureRmHDInsightSecurityProfile
* Insights
    * Add several warning/deprecation messages about future changes to cmdlets
        - Add-AzureRmAutoscaleSetting
        - Get-AzureRmMetric
        - Get-AzureRmMetricDefinition
        - New-AzureRmAutoscaleRule
        - Remove-AzureRmAlertRule
        - Remove-AzureRmAutoscaleSetting
        - Remove-AzureRmLogProfile
    * Add new parameter to Set-AzureRmDiagnosticSetting
        - Parameter WorkspaceId is the OMS workspace Id
* MachineLearning
    * Add support for Azure Machine Learning Committment Plans
        - Get-AzureRmMLCommitmentAssociation
        - Get-AzureRmMLCommitmentPlan
        - Get-AzureRmMLCommitmentPlanUsageHistory
        - Move-AzureRmMLCommitmentAssociation
        - New-AzureRmMLCommitmentPlan
        - Remove-AzureRmMLCommitmentPlan
        - Update-AzureRmMLCommitmentPlan
* Network
    * Add-AzureRmVirtualNetworkPeering
        - Parameter AlloowGatewayTransit renamed to AllowGatewayTransit (an alias for the old parameter was created)
        - Fixed issue where UseRemoteGateway property was not being populated in the request to the server
    * Get-AzureRmEffectiveNetworkSecurityGroup
        - Add warning if there is no response from GetEffectiveNSG
    * Add Source property to EffectiveRoute
* NotificationHubs
    * New cmdlets
        - New-AzureRmNotificationHubKey
        - New-AzureRmNotificationHubsNamespaceKey
* OperationalInsights
    * Add new parameter to cmdlet New-AzureRmOperationalInsightsWindowsPerformanceCounterDataSource
        - UseLegacyCollector (switch parameter) will enable collection of 32-bit legacy performance counters on 64-bit machines
    * Rename New-AzureRmOperationalInsightsAzureAuditDataSource to New-AzureRmOperationalInsightsAzureActivityLogDataSource (an alias for the old command was created)
    * Get-AzureRmOperationalInsightsDataSource returns null instead of throwing an exception if not found
    * New-AzureRmOperationalInsightsComputerGroup now supports defining a group simply by separating computer names with commas
* Profile
    * Add-AzureRmAccount
        - Add position for Credential parameter so the following command is allowed: Add-AzureRmAccount (Get-Credential)
        - Updated parameter sets so the SubscriptionId and SubscriptionName are mutually exclusive
* Resources
    * Lookup of AAD group by Id now uses GetObjectsByObjectId AAD Graph call instead of Groups/<id>
        - This will enable Groups lookup in CSP scenario
    * Remove unnecessary AAD graph call in Get role assignments logic
        - Only make call when needed instead of always
    * Fixed issue where Remove-AzureRmResource would throw an exception if one of the resources passed through the pipeline failed to be removed
        - If cmdlet fails to remove one of the resources, the result will not have an effect on the removal of other resources

## 2016.09.28 version 3.0.0
* This release contains breaking changes. Please see [the migration guide](documentation/release-notes/migration-guide.3.0.0.md) for change details and the impact on existing scripts.
* ApiManagement
    * Enable support of Importing and Exporting SOAP based APIs (Wsdl Format)
        - Import-AzureRmApiManagementApi
        - Export-AzureRmApiManagementApi
    * Deprecated cmdlet Set-AzureRmApiManagementVirtualNetworks. In place, place used cmdlet Update-AzureRmApiManagementDeployment
    * Enabled support for ARM based VNETs for configuration Vpn via cmdlet Update-AzureRmApiManagementDeployment
    * Introduced support for VpnType (None, External, Internal) to differentiate ApiManagement workloads for Internet and Intranet
    * Fixed PowerShell issues
        - https://github.com/Azure/azure-powershell/issues/2622
        - https://github.com/Azure/azure-powershell/issues/2606
* Batch
    * Added new cmdlet for reactivating tasks
        - Enable-AzureBatchTask
    * Added new parameter for application packages on job manager tasks and cloud tasks
        - New-AzureBatchTask -ApplicationPackageReferences
    * Added new parameters for job auto termination
        - New-AzureBatchJob -OnAllTasksComplete -OnTaskFailure
        - New-AzureBatchJob -ExitConditions
* ExpressRoute
    * Added new parameter service key in return object when provider list all cross connection
        - Get-AzureCrossConnectionCommand
* MachineLearning
    * Get-AzureRmMlWebService supports paginated response
    * Remind user Get-AzureRmMlWebService "Name" parameter needs to work with "ResourceGroupName" parameter
* Network
    * Added new cmdlet to get application gateway backend health
        - Get-AzureRmApplicationGatewayBackendHealth
    * Added support for creating UltraPerformance sku
        - New-AzureRmVirtualNetworkGateway -GatewaySku
        - New-AzureVirtualNetworkGateway -GatewaySku   
* RemoteApp
    * Added cmdlets to enable User Disk and Gold Image Migration feature
        - Export-AzureRemoteAppUserDisk
        - Export-AzureRemoteAppTemplateImage
* SiteRecovery
    * New cmdlets have been added to support one to one mapping with service objects.
        - Get-AzureRmSiteRecoveryFabric
        - Get-AzureRmSiteRecoveryProtectableItem
        - Get-AzureRmSiteRecoveryProtectionContainerMapping
        - Get-AzureRmSiteRecoveryRecoveryPoin
        - Get-AzureRmSiteRecoveryReplicationProtectedItem
        - Get-AzureRmSiteRecoveryServicesProvider
        - New-AzureRmSiteRecoveryFabri
        - New-AzureRmSiteRecoveryProtectionContainerMapping
        - New-AzureRmSiteRecoveryReplicationProtectedItem
        - Remove-AzureRmSiteRecoveryFabric
        - Remove-AzureRmSiteRecoveryProtectionContainerMapping
        - Remove-AzureRmSiteRecoveryReplicationProtectedItem
        - Remove-AzureRmSiteRecoveryServicesProvider
        - Set-AzureRmSiteRecoveryReplicationProtectedItem
        - Start-AzureRmSiteRecoveryApplyRecoveryPoint
        - Update-AzureRmSiteRecoveryServicesProvider
    * Following cmdlets have been modified for to support one to one mapping with service objects.
        - Edit-AzureRmSiteRecoveryRecoveryPlan
        - Get-AzureRmSiteRecoveryNetwork
        - Get-AzureRmSiteRecoveryNetworkMapping
        - Get-AzureRmSiteRecoveryProtectionContainer
        - Get-AzureRmSiteRecoveryStorageClassification
        - Get-AzureRmSiteRecoveryStorageClassificationMapping
        - Start-AzureRmSiteRecoveryCommitFailoverJob
        - Start-AzureRmSiteRecoveryPlannedFailoverJob
        - Start-AzureRmSiteRecoveryTestFailoverJob
        - Start-AzureRmSiteRecoveryUnplannedFailoverJob
        - Update-AzureRmSiteRecoveryProtectionDirection
        - Update-AzureRmSiteRecoveryRecoveryPlan  
    * HUB support added to Set-AzureRmSiteRecoveryReplicationProtectedItem.
    * Deprecation warning introduced for cmlets/parameter-sets which does not comply to SiteRecovery service object model.

## 2016.09.16 version 2.2.0
* Network
  - New switch parameter added for network interface to enable/Disable accelerated networking -New-AzureRmNetworkInterface -EnableAcceleratedNetworking

## 2016.09.08 version 2.1.0
* Compute
  * Add support for querying encryption status from the AzureDiskEncryptionForLinux extension
* DataFactory
  * Added new cmdlet for listing activity windows
    - Get-AzureRmDataFactoryActivityWindow
* DataLake
  * Changed parameter `Host` to `DatabaseHost` and added alias to `Host`
    - New-AzureRmDataLakeAnalyticsCatalogSecret
    - Set-AzureRmDataLakeAnalyticsCatalogSecret
  * Add support for ACL and Default ACL removal
  * Add support for getting and setting unnamed permissions on files and folders
* KeyVault
  * Add support for certificates
    - Add-AzureKeyVaultCertificate
    - Add-AzureKeyVaultCertificateContact
    - Get-AzureKeyVaultCertificate
    - Get-AzureKeyVaultCertificateContact
    - Get-AzureKeyVaultCertificateIssuer
    - Get-AzureKeyVaultCertificateOperation
    - Get-AzureKeyVaultCertificatePolicy
    - Import-AzureKeyVaultCertificate
    - New-AzureKeyVaultCertificateAdministratorDetails
    - New-AzureKeyVaultCertificateOrganizationDetails
    - New-AzureKeyVaultCertificatePolicy
    - Remove-AzureKeyVaultCertificate
    - Remove-AzureKeyVaultCertificateContact
    - Remove-AzureKeyVaultCertificateIssuer
    - Remove-AzureKeyVaultCertificateOperation
    - Set-AzureKeyVaultCertificateAttribute
    - Set-AzureKeyVaultCertificateIssuer
    - Set-AzureKeyVaultCertificatePolicy
    - Stop-AzureKeyVaultCertificateOperation
* Network
  * Enable Active-Active gateway feature PowerShell cmdlets
    - Add-AzureRmVirtualNetworkGatewayIpConfig
    - Remove-AzureRmVirtualNetworkGatewayIpConfig
  * Added new cmdlet
    - Test-AzureRmPrivateIpAddressAvailability
* Resources
  * Support zones in provider and resource cmdlets
    - Get-AzureRmProvider
    - New-AzureRmResource
    - Set-AzureRmResource
* Sql
  * Added new cmdlets for Azure SQL threat detection policy management at server level
    - Get-AzureRmSqlServerThreatDetectionPolicy
    - Remove-AzureRmSqlServerThreatDetectionPolicy
    - Set-AzureRmSqlServerThreatDetectionPolicy
  * Added new cmdlets to support enabling/disabling GeoBackupPolicy for Sql Azure DataWarehouses
    - Get-AzureRmSqlDatabaseGeoBackupPolicy
    - Set-AzureRmSqlDatabaseGeoBackupPolicy
  * Added new cmdlets for Azure Sql Advisors and Recommended Actions APIs
    - Get-AzureRmSqlDatabaseAdvisor
    - Get-AzureRmSqlElasticPoolAdvisor
    - Get-AzureRmSqlServerAdvisor
    - Get-AzureRmSqlDatabaseRecommendedActions
    - Get-AzureRmSqlElasticPoolRecommendedActions
    - Get-AzureRmSqlServerRecommendedActions
    - Set-AzureRmSqlDatabaseAdvisorAutoExecuteStatus
    - Set-AzureRmSqlElasticPoolAdvisorAutoExecuteStatus
    - Set-AzureRmSqlServerAdvisorAutoExecuteStatus
    - Set-AzureRmSqlDatabaseRecommendedActionState
    - Set-AzureRmSqlElasticPoolRecommendedActionState
    - Set-AzureRmSqlServerRecommendedActionState

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