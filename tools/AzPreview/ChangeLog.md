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

