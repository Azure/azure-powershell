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
     > PS D:\github\azure-powershell> Set-AzApiManagementPolicy -Context  -PolicyFilePath C:\wrongpolicy.xml -ApiId httpbin
     >   Set-AzApiManagementPolicy : 
     Error Code: ValidationError
     Error Message: One or more fields contain incorrect values:
     Error Details:
        [Code=ValidationError, Message=Error in element 'log-to-eventhub' on line 3, column 10: Logger not found, Target=log-to-eventhub]
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
        > New-AzApiManagementContext -ResourceId /subscriptions/subid/resourceGroups/rgName/providers/Microsoft.ApiManagement/service/contoso
    - 'Get-AzApiManagementApiRelease'
        > Get-AzApiManagementApiRelease -ResourceId /subscriptions/subid/resourceGroups/rgName/providers/Microsoft.ApiManagement/service/contoso/apis/echo-api/releases/releaseId
    - 'Get-AzApiManagementApiVersionSet'
        > Get-AzApiManagementApiVersionSet -ResourceId /subscriptions/subid/resourceGroups/rgName/providers/Microsoft.ApiManagement/service/constoso/apiversionsets/pathversionset
    - 'Get-AzApiManagementAuthorizationServer'
    - 'Get-AzApiManagementBackend'
        > Get-AzApiManagementBackend -ResourceId /subscriptions/subid/resourceGroups/rgName/providers/Microsoft.ApiManagement/service/contoso/backends/servicefabric
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
* Add new cmdlet Get-AzureRmDenyAssignment for retrieving deny assignments

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
* Fix issue where `Get-AzureRmRoleAssignment` doesn't respect -ErrorAction
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
* Az.Resources: Correct documentation for New-AzureRmPolicyDefinition -Mode default value
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
    - New-AzureRmEventGridSubscription: Add new optional parameters for specifying:
        - Event Time-To-Live,
        - Maximum number of delivery attempts for the events,
        - Dead letter endpoint.
    - Update-AzureRmEventGridSubscription: Add new optional parameters for specifying:
        - Event Time-To-Live,
        - Maximum number of delivery attempts for the events,
        - Dead letter endpoint.
* Add new enum values (namely, storageQueue and hybridConnection) for EndpointType option in New-AzureRmEventGridSubscription and Update-AzureRmEventGridSubscription cmdlets.
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
