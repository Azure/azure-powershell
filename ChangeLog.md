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
