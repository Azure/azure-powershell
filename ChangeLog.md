﻿## 6.10.0 - October 2018
#### Azure.Storage
* Fix Copy Blob/File won't copy metadata when destination has metadata issue
    - Start-AzureStorageBlobCopy
    - Start-AzureStorageFileCopy

#### AzureRM.CognitiveServices
* Support Get-AzureRmCognitiveServicesAccountSkus without an existing account.

#### AzureRM.Compute
* Fix Get-AzureRmVM -ResourceGroupName <rg> to return more than 50 results if needed
* Added an example of the 'SimpleParameterSet' to New-AzureRmVmss cmdlet help.
* Fixed a typo in the Azure Disk Encryption progress message

#### AzureRM.DataFactoryV2
* Updated the ADF .Net SDK version to 2.3.0.

#### AzureRM.Network
* Added NetworkProfile functionality. new cmdlets added
    - Get-AzureRMNetworkProfile
    - New-AzureRMNetworkProfile
    - Remove-AzureRMNetworkProfile
    - Set-AzureRMNetworkProfile
    - New-AzureRMContainerNicConfig
    - New-AzureRmContainerNicConfigIpConfig
* Added service association link on Subnet Model
* Added cmdlet New-AzureRmVirtualNetworkTap, Get-AzureRmVirtualNetworkTap, Set-AzureRmVirtualNetworkTap, Remove-AzureRmVirtualNetworkTap
* Added cmdlet Set-AzureRmNEtworkInterfaceTapConfig, Get-AzureRmNEtworkInterfaceTapConfig, Remove-AzureRmNEtworkInterfaceTapConfig

#### AzureRM.RedisCache
* Allow any string as Size parameter going forward. Add P5 in PSArgumentCompleter popup

#### AzureRM.Resources
* Add missing -Mode parameter to Set-AzureRmPolicyDefinition
* Fix Get-AzureRmProviderOperation commandlet bug for operations with Origin containing User

#### AzureRM.Sql
* Fixed issue where some backup cmdlets would not recognize the current azure subscription

#### AzureRM.Storage
* Support get the Storage resource usage of a specific location, and add warning message for get global Storage resource usage is obsolete.
    - Get-AzureRmStorageUsage

#### AzureRM.Websites
* New Cmdlet Get-AzureRMWebAppContainerContinuousDeploymentUrl - Gets the Container Continuous Deployment Webhook URL
* New Cmdlets New-AzureRMWebAppContainerPSSession and Enter-WebAppContainerPSSession  - Initiates a PowerShell remote session into a windows container app

## 6.9.0 - September 2018
#### General
* AzureRM.SignalR was added to the AzureRM rollup module

#### AzureRM.Profile
* Minor changes to the storage common code
* Updated help files to include full parameter types.
- Changed -ServicePrincipal to non-mandatory in the ServicePrincipalCertificateWithSubscriptionId parameter set

#### Azure.Storage
* Support create Storage Context with OAuth.
	- New-AzureStorageContext

#### AzureRM.Cdn
* Added Standard_Microsoft in Cdn pricing sku.

#### AzureRM.Compute
* Move dependencies on Keyvault and Storage to the common dependencies
* Add support for more virutal machine sizes to AEM cmdlets
* Add PublicIPPrefix parameter to New-AzureRmVmssIpConfig
* Add ResourceId parameter to Invoke-AzureRmVMRunCommand cmdelt
* Add Invoke-AzureRmVmssVMRunCommand cmdlet

#### AzureRM.Dns
* Added support for alias record during dns record creation

#### AzureRM.Insights
* Fixed issues #6833 and #7102 (Diagnostic Settings area)
    - Issues with the default name, i.e. 'service', during creation and listing/getting of diagnostic settings
    - Issues creating diagnostic settings with categories
* Added deprecation message for metrics time grains parameters
    - Timegrains parameters are still being accepted (this is a non-breaking change,) but they are ignored in the backend since only PT1M is valid

#### AzureRM.Network
* Changes to LoadBalancer cmdlets
  - LoadBalancerInboundNatPoolConfig: added parameters IdleTimeoutInMinutes, EnableFloatingIp and EnableTcpReset
  - LoadBalancerInboundNatRuleConfig: added parameter EnableTcpReset
  - LoadBalancerRuleConfig: added parameter EnableTcpReset
  - LoadBalancerProbeConfig: added support for value "Https" for parameter Protocol
* Added new commands for new LoadBalancer's subresource OutboundRule
  - Add-AzureRmLoadBalancerOutboundRuleConfig
  - Get-AzureRmLoadBalancerOutboundRuleConfig
  - New-AzureRmLoadBalancerOutboundRuleConfig
  - Set-AzureRmLoadBalancerOutboundRuleConfig
  - Remove-AzureRmLoadBalancerOutboundRuleConfig
* Added new HostedWorkloads property for PSNetworkInterface
* Added new cmdlets for feature: Azure Firewall via ARM
  - Added Get-AzureRmFirewall
  - Added Set-AzureRmFirewall
  - Added New-AzureRmFirewall
  - Added Remove-AzureRmFirewall
  - Added New-AzureRmFirewallApplicationRuleCollection
  - Added New-AzureRmFirewallApplicationRule
  - Added New-AzureRmFirewallNatRuleCollection
  - Added New-AzureRmFirewallNatRule
  - Added New-AzureRmFirewallNetworkRuleCollection
  - Added New-AzureRmFirewallNetworkRule
* Added support for Trusted Root certificate and Autoscale configuration in Application Gateway
  - New Cmdlets added:
      - Add-AzureRmApplicationGatewayTrustedRootCertificate
      - Get-AzureRmApplicationGatewayTrustedRootCertificate
      - New-AzureRmApplicationGatewayTrustedRootCertificate
      - Remove-AzureRmApplicationGatewayTrustedRootCertificate
      - Set-AzureRmApplicationGatewayTrustedRootCertificate
      - Get-AzureRmApplicationGatewayAutoscaleConfiguration
      - New-AzureRmApplicationGatewayAutoscaleConfiguration
      - Remove-AzureRmApplicationGatewayAutoscaleConfiguration
      - Set-AzureRmApplicationGatewayAutoscaleConfiguration
  - Cmdlets updated with optonal parameter -TrustedRootCertificate
      - New-AzureRmApplicationGateway
      - Set-AzureRmApplicationGateway
      - New-AzureRmApplicationGatewayBackendHttpSetting
      - Set-AzureRmApplicationGatewayBackendHttpSetting
  - Cmdlets updated with optonal parameter -AutoscaleConfiguration
      - New-AzureRmApplicationGateway
      - Set-AzureRmApplicationGateway
* Add cmdlet for Interface Endpoint Get-AzureInterfaceEndpoint
* Added support for multiple address prefixes in a subnet. Updated cmdlets:
  - New-AzureRmVirtualNetworkSubnetConfig
  - Set-AzureRmVirtualNetworkSubnetConfig
  - Add-AzureRmVirtualNetworkSubnetConfig
  - Get-AzureRmVirtualNetworkSubnetConfig
  - Add-AzureRmApplicationGatewayAuthenticationCertificate
  - Add-AzureRmApplicationGatewayFrontendIPConfig
  - New-AzureRmApplicationGatewayFrontendIPConfig
  - Set-AzureRmApplicationGatewayFrontendIPConfig
  - Add-AzureRmApplicationGatewayIPConfiguration
  - New-AzureRmApplicationGatewayIPConfiguration
  - Set-AzureRmApplicationGatewayIPConfiguration
  - Add-AzureRmNetworkInterfaceIpConfig
  - New-AzureRmNetworkInterfaceIpConfig  - Set-AzureRmNetworkInterfaceIpConfig
  - New-AzureRmVirtualNetworkGatewayIpConfig
  - Add-AzureRmVirtualNetworkGatewayIpConfig
  - Set-AzureRmLoadBalancerFrontendIpConfig
  - Add-AzureRmLoadBalancerFrontendIpConfig
  - New-AzureRmLoadBalancerFrontendIpConfig
  - New-AzureRmNetworkInterface
* Adding cmdlets for subnet delegation.
  - New-AzureRmDelegation: Creates a new delegation, which can be added to a subnet
  - Remove-AzureRmDelegation: Takes in a subnet and removes the provided delegation name from that subnet
  - Add-AzureRmDelegation: Takes in a subnet and adds the provided service name as a delegation to that subnet
  - Get-AzureRmDelegation
  - Get-AzureRmAvailableServiceDelegations

#### AzureRM.RecoveryServices.SiteRecovery
* Support for managed Managed disk

#### AzureRM.RedisCache
* Updated Insights dependency.

#### AzureRM.Resources
* Update New-AzureRmResourceGroupDeployment with new parameter RollbackAction
    - Add support for OnErrorDeployment with the new parameter.
* Support managed identity on policy assignments.
* Parameters with default values are no longer requred when assigning a policy with 'New-AzureRmPolicyAssignment'
* Add new cmdlet Get-AzureRmPolicyAlias for retrieving policy aliases

#### AzureRM.ServiceBus
* Fixed issue #7161

#### AzureRM.SignalR
* Update SKU names to Free_F1 and Standard_S1
* Add version field to the PSSignalRResource object and connection string to the PSSignalRKeys object.

#### AzureRM.Storage
* Support Immutability Policy in AzureRm.Storage
    - Remove-AzureRmStorageAccountNetworkRule
    - Get-AzureRmStorageContainer
    - Update-AzureRmStorageContainer
    - New-AzureRmStorageContainer
    - Remove-AzureRmStorageContainer
    - Add-AzureRmStorageContainerLegalHold
    - Remove-AzureRmStorageContainerLegalHold
    - Set-AzureRmStorageContainerImmutabilityPolicy
    - Get-AzureRmStorageContainerImmutabilityPolicy
    - Remove-AzureRmStorageContainerImmutabilityPolicy
    - Lock-AzureRmStorageContainerImmutabilityPolicy

#### AzureRM.Websites
* Added two new cmdlets: Get-AzureRmDeletedWebApp and Restore-AzureRmDeletedWebApp
* New-AzureRmAppServicePlan -HyperV switch is added for create app service plan with windows container
* New-AzureRmWebApp/ New-AzureRmWebAppSlot/ Set-AzureRmWebApp/ Set-AzureRmWebAppSlot - New parameters (–ContainerRegistryUser string -ContainerRegistryPassword secureString -EnableContainerContinuousDeployment) added for creating and managing windows container app

## 6.8.1 - August 2018
#### General
* Fixed issue with default resource groups not being set.
* Updated common runtime assemblies

#### AzureRM.ApiManagement
* Fixed issue with default resource groups not being set.
* Fixed issue https://github.com/Azure/azure-powershell/issues/6603
    - Import-AzureRmApiManagementApi and *-AzureRmApiManagementCertificate cmdlets now handle relative Paths
* Fixed issue https://github.com/Azure/azure-powershell/issues/6879
    - The CertificateInformation is a settable property allowing for Set-AzureRmApiManagement cmdlet to work property. Fixed by upgrading to
	4.0.4-preview nuget
* Fixed issue https://github.com/Azure/azure-powershell/issues/6853
    - Fixed the Odata filter for Search by Name on Product
* Fixed issue https://github.com/Azure/azure-powershell/issues/6814
    - Fixed the Odata filter for Search by Name on Api
* Added support for AzureMonitor logger


#### AzureRM.Compute
* Fixed the issue that target is missing in error output.
* Fixed issue with storage account type for VM with managed disk
* Fixed issue with default resource groups not being set.
* Fix AEM Extension cmdlets for other environments, for example Azure China

#### AzureRM.Network
* Changed default cmdlet output presentation to table view

#### AzureRM.PowerBIEmbedded
* Fix failure in Update-AzureRmPowerBIEmbeddedCapacity when trying to scale paused capacity


#### AzureRM.Resources
* Fixed issue with creating managed applications from the MarketPlace.

#### AzureRM.ServiceBus
* Fixed issues
	- https://github.com/Azure/azure-powershell/issues/5058
	- https://github.com/Azure/azure-powershell/issues/5055
	- https://github.com/Azure/azure-powershell/issues/6891

#### AzureRM.TrafficManager
* Added Support for the MultiValue routing method
    - New parameter 'MaxReturn' for MultiValue routing
* Added Support for the Subnet routing method
    - Support for IP address ranges (subnets) in endpoints
* Added Support for Custom Headers in profiles
* Added Support for Expected status code ranges in profiles
* Added Support for Custom Headers in endpoints

## 6.8.0 - August 2018
#### General
* Fixed issue with default resource groups not being set.

#### AzureRM.Profile
* Added expiration property to tokens returned during Connect-AzureRmAccount

#### AzureRM.Compute
* Fixed the issue that target is missing in error output.
* Fixed issue with storage account type for VM with managed disk
* Fix AEM Extension cmdlets for other environments, for example Azure China

#### AzureRM.IotHub
* Fix examples for New-AzureRmIotHubExportDevices and New-AzureRmIotHubImportDevices

#### AzureRM.Network
* Changed default models representation to table-view

#### AzureRM.PowerBIEmbedded
* Fix failure in Update-AzureRmPowerBIEmbeddedCapacity when trying to scale paused capacity

#### AzureRM.Resources
* Fixed issue with creating managed application from the MarketPlace.

#### AzureRM.ServiceBus
* Fix for issues
	- https://github.com/Azure/azure-powershell/issues/5058
	- https://github.com/Azure/azure-powershell/issues/5055
	- https://github.com/Azure/azure-powershell/issues/6891

#### AzureRM.TrafficManager
* Support for the MultiValue routing method
    - New parameter 'MaxReturn' for MultiValue routing
* Support for the Subnet routing method
    - Support for IP address ranges (subnets) in endpoints
* Support for Custom Headers in profiles
* Support for Expected status code ranges in profiles
* Support for Custom Headers in endpoints

#### AzureRM.Websites
* Fixed issue with default resource group being set incorrectly.

## 6.7.0 - August 2018
#### General
* Updated to the latest version of the Azure ClientRuntime.

#### AzureRM.Profile
* Add user id to default context name to avoid context clashing
    - https://github.com/Azure/azure-powershell/issues/6489
* Fix issues with Clear-AzureRmContext that caused issues with selecting a context #6398
* Enable tenant domain to be passed to '-TenantId' parameter for 'Connect-AzureRmAccount'
    - https://github.com/Azure/azure-powershell/issues/3974
    - https://github.com/Azure/azure-powershell/issues/6709

#### Azure.Storage
* Remove the 5TB limitation for Azure File Share quota
- Set-AzureStorageShareQuota

#### AzureRM.Compute
* Add EvictionPolicy parameter to New-AzureRmVmssConfig
* Use default location in the DiskFileParameterSet of New-AzureRmVm if no Location is specified.
* Fix parameter description in Save-AzureRmVMImage
* Fix Get-AzureRmVMDiskEncryptionStatus cmdlet for certain singlepass related scenarios

#### AzureRM.DataLakeStore
* Fix debugging when DebugPreference is set from powershell command line
* Update example for Set-AzureRmDataLakeStoreItemAcl
* Update example for Set-AzureRmDataLakeStoreItemAclEntry

#### AzureRM.Network
* Added example for Set-AzureRmLocalNetworkGateway
* Added examples and descriptions for Add-AzureRmVirtualNetworkGatewayIpConfig, Get-AzureRmVirtualNetworkGatewayConnectionSharedKey and New-AzureRmVirtualNetworkGatewayConnection
* Added examples for Remove-AzureRmVirtualNetworkGatewayIpConfig and Reset-AzureRmVirtualNetworkGateway
* Added example for Reset-AzureRmVirtualNetworkGatewayConnectionSharedKey
* Added example for Set-AzureRmVirtualNetworkGatewayConnectionSharedKey
* Added example for Set-AzureRmVirtualNetworkGatewayConnection
* Re-generated cmdlets for ApplicationSecurityGroup, RouteTable and Usage using latest code generator
* Clarified error message for Get-AzureRmVirtualNetworkSubnetConfig when attempting to get a subnet that does not exitc

#### AzureRM.RecoveryServices.Backup
* Added policy filter to Get-AzureRmRecoveryServicesBackItem cmdlet. The command returns the list of backup items protected by the given policy id.
* Updated Microsoft.Azure.Management.RecoveryServices.Backup to version 3.0.0-preview.
* Added TargetResourceGroupName parameter to Restore-AzureRmRecoveryServicesBackupItem. The resource group to which the managed disks are restored. Applicable to backup of VM with managed disks.

#### AzureRM.Resources
* Support template deployment at subscription scope. Add new Cmdlets:
    - New-AzureRmDeployment
    - Get-AzureRmDeployment
    - Test-AzureRmDeployment
    - Remove-AzureRmDeployment
    - Stop-AzureRmDeployment
    - Save-AzureRmDeploymentTemplate
    - Get-AzureRmDeploymentOperation
* Fix issue where error is thrown when passing a context to Set-AzureRmResource
    - https://github.com/Azure/azure-powershell/issues/5705
* Fix example in New-AzureRmResourceGroupDeployment

## 6.6.0 - July 2018
#### General
* Updated all help files to include full parameter types and correct input/output types.

#### AzureRM.Profile
* Updated Common.Strategy library to be able to validate that the current config for a resource is compatible with the target resource. Default is always true, individual resources and overridet the default.
* Added ps1xml types to Common.Storage

#### Azure.Storage
* Support get Storage Context from DefaulfProfile
* Add Ps1XmlAttribute to cmdlets output types properties.

#### AzureRM.ApiManagement
* Fixed issue https://github.com/Azure/azure-powershell/issues/6370
    - Fixed bug in Automapper to translate PsApiManagementApi to ApiContract
* Fixed issue https://github.com/Azure/azure-powershell/issues/6515
    - Fixed bug in File.Save to not overload with Encoding Type
* Fixed issue https://github.com/Azure/azure-powershell/issues/6560
    - Upgraded to 4.0.3 Nuget version which fixes the pattern exception on apiId

#### AzureRM.Compute
* Fix issue with creating a vm using DiskFileParameterSet in New-AzureRmVm failing because of PremiumLRS storage account type renaming.
* Fix Invoke-AzureRmVMRunCommand cmdlet
* Update Get-AzureRmAvailabilitySet to enable list all availability sets in a subscription.  (ResouceGroupName parameter is now optional.)
* Update SimpleParameterSet of 'New-AzureRmVm' to enable Accelerated Network on qualifying vms.
* Update New-AzureRmVmss simple parameter set to fail creating the vmss when a user specified LB already exists.
* Update example for New-AzureRmDisk
* Add example for 'New-AzureRmVM'
* Update description for Set-AzureRmVMOSDisk
* Update Example 1 for Set-AzureRmVMBginfoExtension to correct spelling and prefix.

#### AzureRM.DataFactoryV2
* Updated the ADF .Net SDK version to 1.1.0.
* Support self-hosted integration runtime sharing across data factories.
     - Add new parameter -SharedIntegrationRuntimeResourceId to Set-AzureRmDataFactoryV2IntegrationRuntime cmdlet.
     - Add new optional parameter -LinkedDataFactoryName to Remove-AzureRmDataFactoryV2IntegrationRuntime cmdlet.

#### AzureRM.DataLakeStore
* Updated the DataPlane SDK (Microsoft.Azure.DataLake.Store) version to 1.1.9

#### AzureRM.EventHub
* Updated piping for InputObject and ResourceId in remove cmdlets

#### AzureRM.Insights
* Fixed formatting of OutputType in help files
* Using Microsoft.Azure.Management.Monitor SDK 0.19.1-preview

#### AzureRM.KeyVault
* Fix piping issue in Set-AzureRmKeyVaultAccessPolicy

#### AzureRM.Network
* Added examples for LoadBalancerInboundNatPoolConfig cmdlets.

#### AzureRM.Resources
* Fix issue when providing both tag name and value for 'Get-AzureRmResource'
    - https://github.com/Azure/azure-powershell/issues/6765
* Fix piping scenario with 'Set-AzureRmResource'

#### AzureRM.ServiceBus
* Updated piping for InputObject and ResourceId in remove cmdlets
* fixed few issues
	- https://github.com/Azure/azure-powershell/issues/3780
	- https://github.com/Azure/azure-powershell/issues/4340

#### AzureRM.Sql
* Adding Server Advanced Threat Protection support with the following cmdlets:
	- Enable-AzureRmSqlServerAdvancedThreatProtection; Disable-AzureRmSqlServerAdvancedThreatProtection; Get-AzureRmSqlServerAdvancedThreatProtectionPolicy
* Adding Vulnerability Assessment support with the following cmdlets:
	- Update-AzureRmSqlDatabaseVulnerabilityAssessmentSettings; Get-AzureRmSqlDatabaseVulnerabilityAssessmentSettings; Clear-AzureRmSqlDatabaseVulnerabilityAssessmentSettings
	- Set-AzureRmSqlDatabaseVulnerabilityAssessmentRuleBaseline; Get-AzureRmSqlDatabaseVulnerabilityAssessmentRuleBaseline; Clear-AzureRmSqlDatabaseVulnerabilityAssessmentRuleBaseline
	- Convert-AzureRmSqlDatabaseVulnerabilityAssessmentScan; Get-AzureRmSqlDatabaseVulnerabilityAssessmentScanRecord; Start-AzureRmSqlDatabaseVulnerabilityAssessmentScan
* Fixed example in Remove-AzureRmSqlServerFirewallRule
* Fix datetime handling incorrectly for non-us base culture in Get-AzureSqlSyncGroupLog

#### AzureRM.Storage
* Add Ps1XmlAttribute to cmdlets output types properties
* Show StorageAccount cmdlet output in table view
    - Get-AzureRmStorageAccount
    - New-AzureRmStorageAccount
    - Set-AzureRmStorageAccount

#### AzureRM.Tags
* Remove incorrect statement from Tag cmdlet help
    - https://github.com/Azure/azure-powershell/issues/3878

## 6.5.0 - July 2018
#### AzureRM.Profile
* Updated help for 'Get-AzureRmContextAutosaveSetting'

#### Azure.Storage
* Support Upload Blob or File with write only Sas token
- Set-AzureStorageBlobContent
- Set-AzureStorageFileContent

#### AzureRM.AnalysisServices
* Add required property ResourceGroupName to AS.

#### AzureRM.Automation
* Update help and add example for 'New-AzureRMAutomationSchedule'

#### AzureRM.Compute
* Add -Tag parameter to Update/New-AzureRmAvailabilitySet
* Add example for 'Add-AzureRmVmssExtension'
* Add examples for 'Remove-AzureRmVmssExtension'
* Update help for 'Set-AzureRmVMAccessExtension'
* Update SimpleParameterSet for New-AzureRmVmss to set SinglePlacementGroup to false by default and add switch parameter 'SinglePlacementGroup' that enables the user to create the VMSS in a single placement group.

#### AzureRM.EventHub
* Added a readonly property 'PendingReplicationOperationsCount' to PSEventHubDRConfigurationAttributes class, which gives the pending replication operations count while replication is in progress

#### AzureRM.KeyVault
* Update error message for Set-AzureRmKeyVaultAccessPolicy

#### AzureRM.LogicApp
* Fixed "parameter set could not be resolved" error in New-AzureRmLogicApp

#### AzureRM.Network
* Enable peering across Virtual Networks in multiple Tenants for Set/Add-AzureRmVirtualNetworkPeering
* Updated below cmdlets for Application Gateway
    - New-AzureRmApplicationGateway : Added EnableFIPS flag and Zones support
    - New-AzureRmApplicationGatewaySku : Added new skus Standard_v2 and WAF_v2
    - Set-AzureRmApplicationGatewaySku : Added new skus Standard_v2 and WAF_v2
* Regenerated RouteTable cmdlets with the latest generator version

#### AzureRM.Relay
* Updated markdown files, fix for the parameter name issue in example

#### AzureRM.Resources
* Update Roleassignment and roledefinition cmdlets:
    - Remove extra roledefinition calls done as part of paging.
* Fix Get-AzureRmRoleAssignment cmdlet
    - Fix -ExpandPrincipalGroups command parameter functionality
* Fix issue with 'Get-AzureRmResource' where '-ResourceType' parameter was case sensitive

#### AzureRM.ServiceBus
* Added top and skip parameter to list cmdlets
* Added Standard to Premium NameSpace migration cmdlets :
	- Start-AzureRmServiceBusMigration
	- Get-AzureRmServiceBusMigration
	- Complete-AzureRmServiceBusMigration
	- Stop-AzureRmServiceBusMigration
	- Remove-AzureRmServiceBusMigration
* Added a readonly property 'PendingReplicationOperationsCount' to PSServiceBusDRConfigurationAttributes class, which gives the pending replication operations count while replication is in progress

#### AzureRM.ServiceFabric
* Update example for 'New-AzureRmServiceFabricCluster'

#### AzureRM.Sql
* Adding new Cmdlets for Management.Sql to allow customers to add TDE Certificate to Sql Server instance or a Managed Instance
	- Add-AzureRmSqlServerTransparentDataEncryptionCertificate
	- Add-AzureRmSqlManagedInstanceTransparentDataEncryptionCertificate

#### AzureRM.Websites
* `Set-AzureRmWebApp -AssignIdentity` and  `Set-AzureRmWebAppSlot -AssignIdentity` when set to false will now remove the Identity property from the site object.Removing preview tag as well.
* `Get-AzureRmWebAppMetrics`,`Get-AzureRmAppServicePlanMetrics` example updated
* `Set-AzureRmWebApp -PhpVersion` supports off as a valid php version

## 6.4.0 - July 2018
#### General
* Fixed formatting of OutputType in help files for most modules

#### AzureRM.Profile
* Ps1Xml attribute added to the basic output types

#### AzureRM.Compute
* IP Tag feature for VMSS
    - 'New-AzureRmVmssIpTagConfig' cmdlet is added
    - IpTag parameter is added to New-AzureRmVmssIpConfig
* Auto OS Rollback feature for VMSS
    - DisableAutoRollback parameters are added to New-AzureRmVmssConfig and Update-AzureRmVmss
* OS Upgrade History feature for Vmss
    - OSUpgradeHistory switch parameter is added to Get-AzureRmVmss

#### AzureRM.DataLakeAnalytics
* Add support for Catalog ACLs through the following commands:
    - Get-AzureRmDataLakeAnalyticsCatalogItemAclEntry
    - Set-AzureRmDataLakeAnalyticsCatalogItemAclEntry
    - Remove-AzureRmDataLakeAnalyticsCatalogItemAclEntry

#### AzureRM.DataLakeStore
* Add cancellation support and progress tracking for Set-AzureRmDataLakeStoreItemAclEntry, Remove-AzureRmDataLakeStoreItemAclEntry, Set-AzureRmDataLakeStoreItemAcl
* Add cancellation support for Export-AzureRmDataLakeStoreChildItemProperties
* Fix flushing of debug messages for cmdlets that does recursive operations
* Fix location of test of DataLake cmdlets

#### AzureRM.EventHub
* Added Optional MaxCount parameter to List Operations cmdlet Get-AzureRmEventHub and Get-AzureRmEventHubConsumerGroup
* Fixed issue in New-AzureRmEventHub cmdlet where at least one parameter needed while creating New EventHub. Provided Default Parameter set.
* Added optional Parameter -KeyValue to New-AzureRmEventHubKey cmdlet, which enables user to provide KeyValue.

#### AzureRM.KeyVault
* Fix issue where all resources were being returned by Get-AzureRmKeyVault -Tag

#### AzureRM.Network
* Expose new Skus for Zone-Redundant VirtualNetworkGateways
* Added new commands for feature: ExpressRoute Partner APIs via ARM
    - Added Get-AzureRmExpressRouteCrossConnection
    - Added Set-AzureRmExpressRouteCrossConnection
    - Added Add-AzureRmExpressRouteCrossConnectionPeering
    - Added Get-AzureRmExpressRouteCrossConnectionPeering
    - Added Remove-AzureRmExpressRouteCrossConnectionPeering
    - Added Get-AzureRMExpressRouteCrossConnectionArpTable
    - Added Get-AzureRMExpressRouteCrossConnectionRouteTable
    - Added Get-AzureRMExpressRouteCrossConnectionRouteTableSummary

#### AzureRM.RecoveryServices.Backup
* Added Get-AzureRmRecoveryServicesBackupStatus cmdlet. This cmdlet takes a VM ID and checks if the VM is protected by some vault in the subscription. If there exists such a vault, the cmdlet outputs the vault details.

#### AzureRM.Resources
* Update Get-AzureRmPolicyAssignment cmdlets:
    - Add support for listing -Scope values at management group level
    - Add support for retrieving individual assignments with -Scope values at management group level
    - Add -Effective and -All switches to control  parameter
* Update Get/New/Remove/Set-AzureRmPolicyDefinition cmdlets
    - Add -ManagementGroupName parameter to apply operations to a given management group
    - Add -SubscriptionId parameter to apply operations to a given subscription
* Update Get/New/Remove/Set-AzureRmPolicySetDefinition cmdlets
    - Add -ManagementGroupName parameter to apply operations to a given management group
    - Add -SubscriptionId parameter to apply operations to a given subscription
* Add KeyVault secret reference support in parameters when using 'TemplateParameterObject' in 'New-AzureRmResourceGroupDeployment'
* Fix issue where '-EndDate' parameter was ignored for 'New-AzureRmADAppCredential'
    - https://github.com/Azure/azure-powershell/issues/6505
* Fix issue where 'Add-AzureRmADGroupMember' used incorrect URL to make request
    - https://github.com/Azure/azure-powershell/issues/6485

#### AzureRM.ServiceBus
* Added optional Parameter -KeyValue to New-AzureRmServiceBusKey cmdlet, which enables user to provide KeyValue.

#### AzureRM.Sql
* Clarified User-Defined Restore Points for SQLDW in New-AzureRmSqlDatabaseRestorePoint help
* Updated documentation of -ComputeGeneration parameter in several cmdlets

## 6.3.0 - June 2018
#### AzureRM.Profile
* Updated error messages for Enable-AzureRmContextAutoSave
* Create a context for each subscription when running 'Connect-AzureRmAccount' with no previous context

#### Azure.Storage
* Added additional information about -Permissions parameter in help files.

#### AzureRM.Compute
* 'Get-AzureRmVmDiskEncryptionStatus' fixes an issue observed for VMs with no data disks
* Update Compute client library version to fix following cmdlets
    - Grant-AzureRmDiskAccess
    - Grant-AzureRmSnapshotAccess
    - Save-AzureRmVMImage
* Fixed following cmdlets to show 'operation ID' and 'operation status' correctly:
    - Start-AzureRmVM
    - Stop-AzureRmVM
    - Restart-AzureRmVM
    - Set-AzureRmVM
    - Remove-AzuerRmVM
    - Set-AzureRmVmss
    - Start-AzureRmVmssRollingOSUpgrade
    - Stop-AzureRmVmssRollingUpgrade
    - Start-AzureRmVmss
    - Restart-AzureRmVmss
    - Stop-AzureRmVmss
    - Remove-AzureRmVmss
    - ConvertTo-AzureRmVMManagedDisk
    - Revoke-AzureRmSnapshotAccess
    - Remove-AzureRmSnapshot
    - Revoke-AzureRmDiskAccess
    - Remove-AzureRmDisk
    - Remove-AzureRmContainerService
    - Remove-AzureRmAvailabilitySet

#### AzureRM.EventGrid
* Remove ValidateNotNullOrEmpty validation conditions for SubjectBeginsWith/SubjectEndsWith in Update-AzureRmEventGridSubscription cmdlet to allow changing these parameters to empty string if needed.

#### AzureRM.KeyVault
* Fix issue where no Tags are being returned when Get-AzureRmKeyVault -Tag is run

#### AzureRM.PolicyInsights
* Public release of Policy Insights cmdlets
    - Use API version 2018-04-04
    - Add PolicyDefinitionReferenceId to the results of Get-AzureRmPolicyStateSummary

#### AzureRM.RecoveryServices.Backup
* Added -Vault parameter to RecoveryServices.Backup cmdlets. When passed, this will override the Set-AzureRmRecoveryServicesContext cmdlet.

#### AzureRM.Sql
* Updated example in the help file for Get-AzureRmSqlDatabaseExpanded

#### AzureRM.TrafficManager
* Updated the help file for Add-AzureRmTrafficManagerEndpointConfig

#### AzureRM.Websites
* 'Set-AzureRmWebApp' is updated to not overwrite the AppSettings when using -AssignIdentity
* 'New-AzureRmWebAppSlot' is updated to honor AppServicePlan as an optional parameter

## 6.2.1 - June 2018
### AzureRM.OperationalInsights
* Updated PSWorkspace model to allow Network to use type as a parameter

## 6.2.0 - June 2018
#### AzureRM.Profile
* Fix issue where version 10.0.3 of Newtonsoft.Json wasn't being loaded on module import

#### AzureRM.Compute
* VMSS VM Update feature
    - Added 'Update-AzureRmVmssVM' and 'New-AzureRmVMDataDisk' cmdlets
    - Add VirtualMachineScaleSetVM parameter to 'Add-AzureRmVMDataDisk' cmdlet to support adding a data disk to Vmss VM.

#### AzureRM.DataFactoryV2
* Updated the ADF .Net SDK version to 0.8.0-preview containing following changes:
    - Added Configure factory repository operation
    - Updated QuickBooks LinkedService to expose consumerKey and consumerSecret properties
    - Updated Several model types from SecretBase to Object
    - Added Blob Events trigger

### AzureRM.KeyVault
* Update documentation with example output

### AzureRM.Network
* Enable Traffic Analytics parameters on Network Watcher cmdlets

#### AzureRM.Resources
* Fix issue with 'Properties' property of 'PSResource' object(s) returned from 'Get-AzureRmResource'

#### AzureRM.Scheduler
* Fix issue with update ServiceBusQueueJob not setting new Auth values

### AzureRM.Sql
* Updated the following cmdlets with optional LicenseType parameter
	- New-AzureRmSqlDatabase; Set-AzureRmSqlDatabase
	- New-AzureRmSqlElasticPool; Set-AzureRmSqlElasticPool
	- New-AzureRmSqlDatabaseCopy
	- New-AzureRmSqlDatabaseSecondary
	- Restore-AzureRmSqlDatabase

#### AzureRM.Websites
* 'New-AzureRMWebApp' is updated to use common algorithms from the Strategy library.

## 6.1.1 - May 2018
#### AzureRM.Resources
* Revert change to `New-AzureRmADServicePrincipal` that gave service principals `Contributor` permissions over the current subscription if no values were provided for the `Role` or `Scope` parameters
    - If no values are provided for `Role` or `Scope`, the service principal is created with no permissions
    - If a `Role` is provided, but no `Scope`, the service principal is created with the specified `Role` permissions over the current subscription
    - If a `Scope` is provided, but no `Role`, the service principal is created with `Contributor` permissions over the specified `Scope`
    - If both `Role` and `Scope` are provided, the service principal is created with the specified `Role` permissions over the specified `Scope`

## 6.1.0 - May 2018
#### AzureRM.Profile
* Fix issue where running 'Clear-AzureRmContext' would keep an empty context with the name of the previous default context, which prevented the user from creating a new context with the old name

#### AzureRM.AnalysisServices
* Enable Gateway assocaite/disassociate operations on AS.

#### AzureRM.ApiManagement
* Added support for ApiVersions, ApiReleases and ApiRevisions
* Added suppport for ServiceFabric Backend
* Added support for Application Insights Logger
* Added support for recognizing 'Basic' sku as a valid sku of Api Management service
* Added support for installing Certificates issued by private CA as Root or CA
* Added support for accepting Custom SSL certificates via KeyVault and Multiple proxy hostnames
* Added support for MSI identity
* Added support for accepting Policies via Url
NOTE: The following cmdlets will be deprecated in future release
   - Import-AzureRmApiManagementHostnameCertificate
   - New-AzureRmApiManagementHostnameConfiguration
   - Set-AzureRmApiManagementHostnames
   - Update-AzureRmApiManagementDeployment

#### AzureRM.Batch
* Release new cmdlet Get-AzureBatchPoolNodeCounts
* Release new cmdlet Start-AzureBatchComputeNodeServiceLogUpload

#### AzureRM.Consumption
* Add new parameters Expand, ResourceGroup, InstanceName, InstanceId, Tags, and Top on Cmdlet Get-AzureRmConsumptionUsageDetail

#### AzureRM.DataLakeStore
* Fix example for Export-AzureRmDataLakeStoreChildItemProperties
* Fix null parameter exception for Recurse case in Set-AzureRmDataLakeStoreItemAclEntry
* Fix the help files for Set-AzureRmDataLakeStoreItemAclEntry, Set-AzureRmDataLakeStoreItemAcl, Remove-AzureRmDataLakeStoreItemAclEntry

#### AzureRM.Network
* Bump up Network SDK version from 18.0.0-preview to 19.0.0-preview
* Added cmdlet to create protocol configuration
    - New-AzureRmNetworkWatcherProtocolConfiguration
* Added cmdlet to add a new circuit connection to an existing express route circuit.
    - Add-AzureRmExpressRouteCircuitConnectionConfig
* Added cmdlet to remove a circuit connection from an existing express route circuit.
    - Remove-AzureRmExpressRouteCircuitConnectionConfig
* Added cmdlet to retrieve a circuit connection
    - Get-AzureRmExpressRouteCircuitConnectionConfig

#### AzureRM.ServiceFabric
* Fixed server authentication usage with generated certificates (Issue #5998)

#### AzureRM.Sql
* Updated Auditing cmdlets to allow removing AuditActions or AuditActionGroups
* Fixed issue with Set-AzureRmSqlDatabaseBackupLongTermRetentionPolicy when setting a new flexible retention policy where the command would fail with 'Configure long term retention policy with azure recovery service vault and policy is no longer supported. Please submit request with the new flexible retention policy'.
* Update all Azure Sql Database/ElasticPool Creation/Update related cmdlets to use the new Database API, which support Sku property for scale and tier-related properties.
* The updated cmdlets including:
	- New-AzureRmSqlDatabase; Set-AzureRmSqlDatabase
	- New-AzureRmSqlElasticPool; Set-AzureRmSqlElasticPool
	- New-AzureRmSqlDatabaseCopy
	- New-AzureRmSqlDatabaseSecondary
	- Restore-AzureRmSqlDatabase

#### AzureRM.TrafficManager
* Update the parameters for 'Get-AzureRmTrafficManagerProfile' so that -ResourceGroupName parameter is required when using -Name parameter.

## 6.0.0 - May 2018
#### General
* Set minimum dependency of modules to PowerShell 5.0

#### Azure.Storage
* Support  as Storage blob container name
	- New-AzureStorageBlobContainer
	- Remove-AzureStorageBlobContainer
	- Set-AzureStorageBlobContent
	- Get-AzureStorageBlobContent
* Fix the issue that some Storage cmdlets failure output not contain detail failure information

#### AzureRM.ApiManagement
* Introduce multiple breaking changes
    - Please refer to the migration guide for more information

#### AzureRM.Automation
* Remove deprecated 'Tags' alias from cmdlets
    - 'Set-AzureRmAutomationRunbook'

#### AzureRM.Batch
* Updated New-AzureBatchPool documentation to remove deprecated example

#### AzureRM.Cdn
* Introduce multiple breaking changes
    - Please refer to the migration guide for more information

#### AzureRM.Compute
* 'New-AzureRmVm' and 'New-AzureRmVmss' support verbose output of parameters
* 'New-AzureRmVm' and 'New-AzureRmVmss' (simple parameter set) support assigning user defined and(or) system defined identities to the VM(s).
* VMSS Redeploy and PerformMaintenance feature
    -  Add new switch parameter -Redeploy and -PerformMaintenance to 'Set-AzureRmVmss' and 'Set-AzureRmVmssVM'
* Add DisableVMAgent switch parameter to 'Set-AzureRmVMOperatingSystem' cmdlet
* 'New-AzureRmVm' and 'New-AzureRmVmss' (simple parameter set) support a 'Win10' image.
* 'Repair-AzureRmVmssServiceFabricUpdateDomain' cmdlet is added.
* Introduce multiple breaking changes
    - Please refer to the migration guide for more details
* 'Set-AzureRmVmDiskEncryptionExtension' makes AAD parameters optional

#### AzureRM.DataFactories
* Remove deprecated 'Tags' alias from cmdlets
    - New-AzureRmDataFactory

#### AzureRM.DataFactoryV2
* Updated the ADF .Net SDK version to 0.7.0-preview containing following changes:
    - Added execution parameters and connection managers property on ExecuteSSISPackage Activity
    - Updated PostgreSql, MySql llinked service to use full connection string instead of server, database, schema, username and password
    - Removed the schema from DB2 linked service
    - Removed schema property from Teradata linked service
    - Added LinkedService, Dataset, CopySource for Responsys

#### AzureRM.DataLakeAnalytics
* Remove deprecated 'Tags' alias from cmdlets
    - 'New-AzureRmDataLakeAnalyticsAccount'
    - 'Set-AzureRmDataLakeAnalyticsAccount'

#### AzureRM.DataLakeStore
* Add new feature of recursive Acl Change to Remove-AzureRmDataLakeStoreItemAclEntry, Set-AzureRmDataLakeStoreItemAclEntry, Set-AzureRmDataLakeStoreItemAcl
* Add new cmdlet for retrieving the content summary under a directory
* Add new cmdlet for retrieving the disk usage and Acl dump
* Correct return type of Set-AzureRmDataLakeStoreItemAcl bool to IEnumerable<DataLakeStoreItemAce>
* Correct return type of Set-AzureRmDataLakeStoreItemAclEntry bool to IEnumerable<DataLakeStoreItemAce>
* Breaking changes in Export-AzureRmDataLakeStoreItem, Import-AzureRmDataLakeStoreItem, Remove-AzureRmDataLakeStoreItem

#### AzureRM.Dns
* Introduce multiple breaking changes
    - Please refer to the migration guide for more information

#### AzureRM.EventHub
* Updated Help for cmdlets with missing examples

#### AzureRM.Insights
* Introduced multiple breaking changes
    - Please refer to the migration guide for more information

#### AzureRM.IotHub
* Enable tags and Basic Sku to the IotHub

#### AzureRM.KeyVault
* Breaking changes to support piping scenarios
* Added new cmdlets: Backup/Restore-AzureKeyVaultManagedStorageAccount, Backup/Restore-AzureKeyVaultCertificate, Undo-AzureKeyVaultManagedStorageSasDefinitionRemoval, and Undo-AzureKeyVaultManagedStorageAccountRemoval

#### AzureRM.MachineLearning
* Remove deprecated 'Tags' alias from cmdlets
    - Update-AzureRmMlCommitmentPlan

#### AzureRM.Media
* Remove deprecated 'Tags' alias from cmdlets
    - 'Set-AzureRmMediaService'

#### AzureRM.Network
* Add support for DDoS protection plan resource
* Introduced multiple breaking changes
    - Please refer to the migration guide for more information

#### AzureRM.NotificationHubs
* Introduce multiple breaking changes
    - Please refer to the migration guide for more information

#### AzureRM.OperationalInsights
* Introduce multiple breaking changes
    - Please refer to the migration guide for more information

#### AzureRM.Profile
* Enable context autosave by default
* Add USGovernmentOperationalInsightsEndpoint and USGovernmentOperationalInsightsEndpointResourceId properties to Azure environment for US Gov.

#### AzureRM.RecoveryServices.SiteRecovery
* Fixed Authentication Header in SiteRecovery scenarios

#### AzureRM.RedisCache
* Introduced multiple breaking changes
    - Please refer to the migration guide for more information

#### AzureRM.Resources
* Remove obsolete parameter -AtScopeAndBelow from Get-AzureRmRoledefinition call
* Include assignments to deleted USers/Groups/ServicePrincipals in Get-AzureRmRoleAssignment result
* Add Tab completers for Scope and ResourceType
* Add convenience cmdlet for creating ServicePrincipals
* Merge Get- and Find- functionality in Get-AzureRmResource
* Add AD Cmdlets:
  - Remove-AzureRmADGroupMember
  - Get-AzureRmADGroup
  - New-AzureRmADGroup
  - Remove-AzureRmADGroup
  - Remove-AzureRmADUser
  - Update-AzureRmADApplication
  - Update-AzureRmADServicePrincipal
  - Update-AzureRmADUser

#### AzureRM.ServiceFabric
* Update default Linux image version sku
  - NewAzureServiceFabricCluster.cs default UbuntuServer1604 Sku update

#### AzureRM.Storage
* Introduced multiple breaking changes
    - Please refer to the migration guide for more information

#### AzureRM.Websites
* Upgrade to latest version of the Websites SDK
* Added -AssignIdentity & -Httpsonly properties for Set-AzureRmWebApp and Set-AzureRmWebAppSlot
- Added two new cmdlets: Get-AzureRmWebAppSnapshots and Restore-AzureRmWebAppSnapshot

## 5.7.0 - April 2018

#### General
* Updated to the latest version of the Azure ClientRuntime

#### Azure.Storage
* Fix the issue that upload Blob and upload File cmdlets fail on FIPS policy enabled machines
	- Set-AzureStorageBlobContent
	- Set-AzureStorageFileContent

#### AzureRM.Billing
* New Cmdlet Get-AzureRmEnrollmentAccount
  - cmdlet to retrieve enrollment accounts

#### AzureRM.CognitiveServices
* Integrate with Cognitive Services Management SDK version 4.0.0.
* Add Get-AzureRmCognitiveServicesAccountUsage operation.

#### AzureRM.Compute
* `Get-AzureRmVmssDiskEncryptionStatus` supports encryption status at data disk level
* `Get-AzureRmVmssVmDiskEncryptionStatus` supports encryption status at data disk level
* Update for Zone Resilient
* 'New-AzureRmVm' and 'New-AzureRmVmss' (simple parameter set) support availability zones.

#### AzureRM.ContainerRegistry
* Decouple reliance on Commands.Resources.Rest and ARM/Storage SDKs.

#### AzureRM.DataLakeStore
* Add debug functionality
* Update the version of the ADLS dataplane SDK to 1.1.2
* Export-AzureRmDataLakeStoreItem - Deprecated parameters PerFileThreadCount, ConcurrentFileCount and introduced parameter Concurrency
* Import-AzureRMDataLakeStoreItem - Deprecated parametersPerFileThreadCount, ConcurrentFileCount and introduced parameter Concurrency
* Get-AzureRMDataLakeStoreItemContent - Fixed the tail behavior for contents greater than 4MB
* Set-AzureRMDataLakeStoreItemExpiry - Introduced new parameter set SetRelativeExpiry for setting relative expiration time
* Remove-AzureRmDataLakeStoreItem - Deprecated parameter Clean.

#### AzureRM.EventHub
* Fixed AlternameName in New-AzureRmEventHubGeoDRConfiguration

#### AzureRM.KeyVault
* Updated cmdlets to include piping scenarios
* Add deprecation messages for upcoming breaking change release

#### AzureRM.Network
* Fix error message with Network cmdlets

#### AzureRM.ServiceBus
* Added 'properties' in CorrelationFilter of Rules to support customproperties
* updated New-AzureRmServiceBusGeoDRConfiguration help and fixed Rules cmdlet output
* Fixed auto-forward properties in New-AzureRmServiceBusQueue and New-AzureRmServiceBusSubscription cmdlet

#### AzureRM.Sql
* Add new cmdlet 'Stop-AzureRmSqlElasticPoolActivity' to support canceling the asynchronous operations on elastic pool
* Update the response for cmdlets Get-AzureRmSqlDatabaseActivity and Get-AzureRmSqlElasticPoolActivity to reflect more information in the response

## 5.6.0 - March 2018

#### General
* Fix issue with Default Resource Group in CloudShell
* Fix issue where incorrect startup scripts were being executed during module import

#### AzureRM.Profile
* Enable MSI authentication in unsupported scenarios
* Add support for user-defined Managed Service Identity

#### AzureRM.AnalysisServices
* Fixed issue with cleaning up scripts in build

#### AzureRM.Cdn
* Fixed issue with cleaning up scripts in build

#### AzureRM.Compute
* 'New-AzureRmVM' and 'New-AzureRmVMSS' support data disks.
* 'New-AzureRmVM' and 'New-AzureRmVMSS' support custom image by name or by id.
* Log analytic feature
    - Added 'Export-AzureRmLogAnalyticRequestRateByInterval' cmdlet
    - Added 'Export-AzureRmLogAnalyticThrottledRequests' cmdlet

#### AzureRM.ContainerInstance
* Fix parameter sets issue for container registry and azure file volume mount

#### AzureRM.DataFactoryV2
* Updated the ADF .Net SDK to version 0.6.0-preview containing the following changes:
    - Added new AzureDatabricks LinkedService and DatabricksNotebook Activity
    - Added headNodeSize and dataNodeSize properties in HDInsightOnDemand LinkedService
    - Added LinkedService, Dataset, CopySource for SalesforceMarketingCloud
    - Added support for SecureOutput on all activities
    - Added new BatchCount property on ForEach activity which control how many concurrent activities to run
    - Added new Filter Activity
    - Added Linked Service Parameters support

#### AzureRM.Dns
* Support for Private DNS Zones (Public Preview)
    - Adds ability to create DNS zones that are visible only to the associated virtual networks

#### AzureRM.Network
* Updating model types for compatibility with DNS cmdlets.

#### AzureRM.RecoveryServices.SiteRecovery
* Changes for ASR Azure to Azure Site Recovery (cmdlets are currently supporting operations for Enterprise to Enterprise, Enterprise to Azure, HyperV to Azure,VMware to Azure)
    - New-AzureRmRecoveryServicesAsrProtectionContainer
    - New-AzureRmRecoveryServicesAsrAzureToAzureDiskReplicationConfig
    - Remove-AzureRmRecoveryServicesAsrProtectionContainer
    - Update-AzureRmRecoveryServicesAsrProtectionDirection

#### AzureRM.Storage
* Obsolete following parameters in new and set Storage Account cmdlets: EnableEncryptionService and DisableEncryptionService, since Encryption at Rest is enabled by default and can't be disabled.
    - New-AzureRmStorageAccount
    - Set-AzureRmStorageAccount

#### AzureRM.Websites
* Fixed the help for Remove-AzureRmWebAppSlot

## 5.5.0 - March 2018
#### AzureRM.Profile
* Fixed issue with importing aliases
* Load version 10.0.3 of Newtonsoft.Json side-by-side with version 6.0.8

#### Azure.Storage
* Support Soft-Delete feature
	- Enable-AzureStorageDeleteRetentionPolicy
	- Disable-AzureStorageDeleteRetentionPolicy
	- Get-AzureStorageBlob

#### AzureRM.AnalysisServices
* Fixed issue with importing aliases
* Add support of firewall and query scaleout feature, as well as support of 2017-08-01 api version.

#### AzureRM.Automation
* Fixed issue with importing aliases

#### AzureRM.Cdn
* Fixed issue with importing aliases

#### AzureRM.CognitiveServices
* Update notice.txt and notice message.

#### AzureRM.Compute
* 'New-AzureRmVMSS' prints connection strings in verbose mode.
* 'New-AzureRmVmss' supports public IP address, load balancing rules, inbound NAT rules.
* WriteAccelerator feature
    - Added WriteAccelerator switch parameter to the following cmdlets:
	  Set-AzureRmVMOSDisk
	  Set-AzureRmVMDataDisk
	  Add-AzureRmVMDataDisk
	  Add-AzureRmVmssDataDisk
    - Added OsDiskWriteAccelerator switch parameter to the following cmdlet:
          Set-AzureRmVmssStorageProfile.
    - Added OsDiskWriteAccelerator Boolean parameter to the following cmdlets:
          Update-AzureRmVM
          Update-AzureRmVmss

#### AzureRM.DataFactories
* Fix credential encryption issue that caused no meaningful error for some encryption operations
* Enable integration runtime to be shared across data factory

#### AzureRM.DataFactoryV2
* Add parameter "SetupScriptContainerSasUri" and "Edition" for "Set-AzureRmDataFactoryV2IntegrationRuntime" cmd to enable custom setup and edition selection functionality
* Fix credential encryption issue that caused no meaningful error for some encryption operations.
* Enable integration runtime to be shared across data factory

#### AzureRM.HDInsight
* Fixed issue with importing aliases

#### AzureRM.KeyVault
* Fixed example for Set-AzureRmKeyVaultAccessPolicy

#### AzureRM.Network
* Fixed issue with importing aliases

#### AzureRM.OperationalInsights
* Fixed issue with importing aliases

#### AzureRM.RecoveryServices
* Fixed issue with importing aliases

#### AzureRM.RecoveryServices.SiteRecovery
* Fixed issue with importing aliases

#### AzureRM.Resources
* Fixed issue with importing aliases

#### AzureRM.ServiceBus
* Added EnableBatchedOperations property to Queue
* Added DeadLetteringOnFilterEvaluationExceptions property to Subscriptions

#### AzureRM.ServiceFabric
* Service Fabric cmdlet refresh
  - Updated ARM templates
  - Failed operations no longer rollback
  - Add-AzureRmServiceFabricNodeType
    - VMs default to managed disks
    - Existing VMSS subnet used
    - All operations are idempotent
  - Remove-AzureRmServiceFabricNodeType cleans up partially created VMSS and/or cluster node types
  - Fixed output of PSCluster object for complex property types

#### AzureRM.Sql
* Fixed issue with importing aliases
* Get-AzureRmSqlServer, New-AzureRmSqlServer, and Remove-AzureRmSqlServer response now includes FullyQualifiedDomainName property.

#### AzureRM.Websites
* Fixed issue with importing aliases
* New-AzureRMWebApp - added parameter set for simplified WebApp creation, with local git repository support.

## 5.4.1 - February 2018
#### AzureRM.Profile
* Fix concurrent module import issue in PowerShell Workflow and Azure Automation

## 5.4.0 - February 2018
#### AzureRM.Automation
* Added alias from New-AzureRmAutomationModule to Import-AzureRmAutomationModule

#### AzureRM.Compute
* Fix ErrorAction issue for some of Get cmdlets.

#### AzureRM.ContainerInstance
* Apply Azure Container Instance SDK 2018-02-01
    - Support DNS name label

#### AzureRM.DevTestLabs
* Fixed all of the GET cmdlets which previously weren't working.

#### AzureRM.EventHub
* Fix bug in Get-AzureRmEventHubGeoDRConfiguration help

#### AzureRM.Network
* Added cmdlet to create a new connection monitor
    - New-AzureRmNetworkWatcherConnectionMonitor
* Added cmdlet to update a connection monitor
    - Set-AzureRmNetworkWatcherConnectionMonitor
* Added cmdlet to get connection monitor or connection monitor list
    - Get-AzureRmNetworkWatcherConnectionMonitor
* Added cmdlet to query connection monitor
    - Get-AzureRmNetworkWatcherConnectionMonitorReport
* Added cmdlet to start connection monitor
    - Start-AzureRmNetworkWatcherConnectionMonitor
* Added cmdlet to stop connection monitor
    - Stop-AzureRmNetworkWatcherConnectionMonitor
* Added cmdlet to remove connection monitor
    - Remove-AzureRmNetworkWatcherConnectionMonitor
* Updated Set-AzureRmApplicationGatewayBackendAddressPool documentation to remove deprecated example
* Added EnableHttp2 flag to Application Gateway
    - Updated New-AzureRmApplicationGateway: Added optional parameter -EnableHttp2
* Add IpTags to PublicIpAddress
    - Updated New-AzureRmPublicIpAddress: Added IpTags
    - New-AzureRmPublicIpTag to add Iptag
* Add DisableBgpRoutePropagation property in RouteTable and effectiveRoute.

#### AzureRM.Resources
* Register-AzureRmProviderFeature: Added missing example in the docs
* Register-AzureRmResourceProvider: Added missing example in the docs

#### AzureRM.Storage
* Obsolete following parameters in new and set Storage Account cmdlets: EnableEncryptionService and DisableEncryptionService, since Encryption at Rest is enabled by default and can't be disabled.
    - New-AzureRmStorageAccount
    - Set-AzureRmStorageAccount

## 5.3.0 - February 2018
#### AzureRM.Profile
* Added deprecation warning for PowerShell 3 and 4
* 'Add-AzureRmAccount' has been renamed as 'Connect-AzureRmAccount'; an alias has been added for the old cmdlet name, and other aliases ('Login-AzAccount' and 'Login-AzureRmAccount') have been redirected to the new cmdlet name.
* 'Remove-AzureRmAccount' has been renamed as 'Disconnect-AzureRmAccount'; an alias has been added for the old cmdlet name, and other aliases ('Logout-AzAccount' and 'Logout-AzureRmAccount') have been redirected to the new cmdlet name.
* Corrected Resource Strings to use Connect-AzureRmAccount instead of Login-AzureRmAccount
* Add-AzureRmEnvironment and Set-AzureRmEnvironment
  - Added -AzureOperationalInsightsEndpoint and -AzureOperationalInsightsEndpointResourceId as parameters for use with OperationalInsights data plane RP.

#### AzureRM.AnalysisServices
* Corrected usage of 'Login-AzureRmAccount' to use 'Connect-AzureRmAccount'

#### AzureRM.Compute
* Added 'AvailabilitySetName' parameter to the simplified parameterset of 'New-AzureRmVm'.
* Corrected usage of 'Login-AzureRmAccount' to use 'Connect-AzureRmAccount'
* User assigned identity support for VM and VM scale set
- IdentityType and IdentityId parameters are added to New-AzureRmVMConfig, New-AzureRmVmssConfig, Update-AzureRmVM and Update-AzureRmVmss
* Added EnableIPForwarding parameter to Add-AzureRmVmssNetworkInterfaceConfig
* Added Priority parameter to New-AzureRmVmssConfig

#### AzureRM.DataLakeAnalytics
* Corrected usage of 'Login-AzureRmAccount' to use 'Connect-AzureRmAccount'

#### AzureRM.DataLakeStore
* Corrected usage of 'Login-AzureRmAccount' to use 'Connect-AzureRmAccount'
* Corrected the error message of 'Test-AzureRmDataLakeStoreAccount' when running this cmdlet without having logged in with 'Login-AzureRmAccount'

#### AzureRM.EventGrid
* Updated to use the 2018-01-01 API version.

#### AzureRM.EventHub
* Added below new commands for Geo Disaster Recovery operations.
	-Creating a new Alias(Disaster Recovery configuration):
		- New-AzureRmEventHubGeoDRConfiguration [-ResourceGroupName] <String> [-Namespace] <String> [-Name] <String> [-PartnerNamespace] <String> [-WhatIf] [-Confirm]
	-Retrieve Alias(Disaster Recovery configuration) :
		- Get-AzureRmEventHubGeoDRConfiguration [-ResourceGroupName] <String> [-Namespace] <String> [[-Name] <String>]
	-Disabling the Disaster Recovery and stops replicating changes from primary to secondary namespaces
		- Set-AzureRmEventHubGeoDRConfigurationBreakPair [-ResourceGroupName] <String> [-Namespace] <String> [-Name] <String>
	-Invoking Disaster Recovery failover and reconfigure the alias to point to the secondary namespace
		- Set-AzureRmEventHubGeoDRConfigurationFailOver [-ResourceGroupName] <String> [-Namespace] <String> [-Name] <String>
	-Deleting an Alias(Disaster Recovery configuration)
		- Remove-AzureRmEventHubGeoDRConfiguration [-ResourceGroupName] <String> [-Namespace] <String> [-Name] <String> [-WhatIf] [-Confirm]
* Added below new commands for checking the Namespace Name and GeoDr Configuration Name - Alias availability.
	-Check the Availability of Namespace name or Alias(Disaster Recovery configuration) name:
		- Test-AzureRmEventHubName [-ResourceGroupName] <String> [-Namespace] <String> [-AliasName] <String>

#### AzureRM.Insights
* Corrected usage of 'Login-AzureRmAccount' to use 'Connect-AzureRmAccount'

#### AzureRM.KeyVault
* Corrected usage of 'Login-AzureRmAccount' to use 'Connect-AzureRmAccount'

#### AzureRM.Network
* Fix overwrite message 'Are you sure you want to overwriteresource'

#### AzureRM.OperationalInsights
* Added support for V2 API querying via Invoke-AzureRmOperationalInsightsQuery. See [https://dev.loganalytics.io/](https://dev.loganalytics.io/) for more info on the new API.

#### AzureRM.Resources
* Get-AzureRmADServicePrincipal: Removed -ServicePrincipalName from the default Empty parameter set as it was redundant with the SPN parameter set

#### AzureRM.ServiceBus
* Added functionality fix for Remove-AzureRmServiceBusRule and Get-AzureRmServiceBusKey
* Added below new commandlets for Geo Disaster Recovery operations.
	-Creating a new Alias(Disaster Recovery configuration):
		- New-AzureRmServiceBusDRConfigurations [-ResourceGroupName] <String> [-Namespace] <String> [-Name] <String> [-PartnerNamespace] <String> [-WhatIf] [-Confirm]
	-Retrieve Alias(Disaster Recovery configuration) :
		- Get-AzureRmServiceBusDRConfigurations [-ResourceGroupName] <String> [-Namespace] <String> [[-Name] <String>]
	-Disabling the Disaster Recovery and stops replicating changes from primary to secondary namespaces
		- Set-AzureRmServiceBusDRConfigurationsBreakPairing [-ResourceGroupName] <String> [-Namespace] <String> [-Name] <String>
	-Invoking Disaster Recovery failover and reconfigure the alias to point to the secondary namespace
		- Set-AzureRmServiceBusDRConfigurationsFailOver [-ResourceGroupName] <String> [-Namespace] <String> [-Name] <String>
	-Deleting an Alias(Disaster Recovery configuration)
		- Remove-AzureRmServiceBusDRConfigurations [-ResourceGroupName] <String> [-Namespace] <String> [-Name] <String> [-WhatIf] [-Confirm]
* Updated Test-AzureRmServiceBusName commandlets to support Geo Disaster Recovery - Alias name check availability operations.
	-Check the Availability of Namespace name or Alias(Disaster Recovery configuration) name:
		- Test-AzureRmServiceBusName [-ResourceGroupName] <String> [-Namespace] <String> [-AliasName] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]

#### AzureRM.UsageAggregates
* Corrected usage of 'Login-AzureRmAccount' to use 'Connect-AzureRmAccount'

## 5.2.0 - January 2018
#### AzureRM.Profile
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Add-AzureRmAccount
  * Added -MSI login for authenticationg using the credentials of the Managed Service Identity of the current VM / Service
  * Fixed KeyVault Authentication when logging in with user-provided access tokens

#### Azure.Storage
* Add cmdlets to get and set Storage service properties
	- Get-AzureStorageServiceProperty
	- Update-AzureStorageServiceProperty

#### AzureRM.AnalysisServices
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

#### AzureRM.ApiManagement
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Obsoleted -Tags in favor of -Tag for New-AzureRmApiManagementProperty, Set-AzureRmApiManagementProperty, and New-AzureRmApiManagement

#### AzureRM.ApplicationInsights
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

#### AzureRM.Automation
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Obsoleted -Tags in favor of -Tag for Set-AzureRmAutomationRunbook

#### AzureRM.Backup
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

#### AzureRM.Batch
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

#### AzureRM.Cdn
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Obsoleted -Tags in favor of -Tag for New-AzureRmCdnEndpoint and New-AzureRmCdnProfile

#### AzureRM.CognitiveServices
* Integrate with Cognitive Services Management SDK version 3.0.0.

#### AzureRM.Compute
* Added simplified parameter set to New-AzureRmVmss, which creates a Virtual Machine Scale Set and all required resources using smart defaults
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Obsoleted -Tags in favor of -Tag for New-AzureRmVm and Update-AzureRmVm
* Fixed Get-AzureRmComputeResourceSku cmdlet when Zone is included in restriction.
* Updated Diagnostics Agent configuration schema for Azure Monitor sink support.

#### AzureRM.ContainerInstance
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

#### AzureRM.ContainerRegistry
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

#### AzureRM.DataFactories
* Enabled Azure Key Vault support for all data store linked services
* Added license type property for Azure SSIS integration runtime
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Obsoleted -Tags in favor of -Tag for New-AzureRmDataFactory

#### AzureRM.DataFactoryV2
* Enabled Azure Key Vault support for all data store linked services
* Added license type property for Azure SSIS integration runtime
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Add parameter "LicenseType" for "Set-AzureRmDataFactoryV2IntegrationRuntime" cmd to enable AHUB functionality

#### AzureRM.DataLakeAnalytics
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Obsoleted -Tags in favor of -Tag for New-AzureRmDataLakeAnalyticsAccount and Set-AzureRmDataLakeAnalyticsAccount

#### AzureRM.DataLakeStore
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Obsoleted -Tags in favor of -Tag for New-AzureRmDataLakeStoreAccount and Set-AzureRmDataLakeStoreAccount

#### AzureRM.DevTestLabs
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

#### AzureRM.Dns
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

#### AzureRM.EventGrid
* Added the following new cmdlet:
    - Update-AzureRmEventGridSubscription
        - Update the properties of an Event Grid event subscription.
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

#### AzureRM.EventHub
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

#### AzureRM.HDInsight
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

#### AzureRM.Insights
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

#### AzureRM.IotHub
* Add Certificate support for IoTHub cmdlets
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

#### AzureRM.KeyVault
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Added -AsJob support for long-running KeyVault cmdlets. Allows selected cmdlets to run in the background and return a job to track and control progress.
    * Affected cmdlet is: Remove-AzureRmKeyVault
* Fixed bug in Set-AzureRmKeyVaultAccessPolicy where the AAD filter was setting SPN to the provided UPN, rather than setting the UPN
   - See the following issue for more information: https://github.com/Azure/azure-powershell/issues/5201

#### AzureRM.LogicApp
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

#### AzureRM.MachineLearning
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Obsoleted -Tags in favor of -Tag for Update-AzureRmMlCommitmentPlan

#### AzureRM.MachineLearningCompute
* Add IncludeAllResources parameter to Remove-AzureRmMlOpCluster cmdlet
    - Using this switch parameter will remove all resources that were created with the cluster originally
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

#### AzureRM.Media
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Obsoleted -Tags in favor of -Tag for Set-AzureRmMediaService and New-AzureRmMediaService

#### AzureRM.Network
* Added -AsJob support for long-running Network cmdlets. Allows selected cmdlets to run in the background and return a job to track and control progress.
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

#### AzureRM.NotificationHubs
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Obsoleted -Tags in favor of -Tag for New-AzureRmNotificationHubsNamespace and Set-AzureRmNotificationHubsNamespace

#### AzureRM.OperationalInsights
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Obsoleted -Tags in favor of -Tag for New-AzureRmOperationalInsightsSavedSearch, Set-AzureRmOperationalInsightsSavedSearch, New-AzureRmOperationalInsightsWorkspace, and Set-AzureRmOperationalInsightsWorkspace

#### AzureRM.PowerBIEmbedded
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

#### AzureRM.RecoveryServices
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

#### AzureRM.RecoveryServices.Backup
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Added -UseOriginalStorageAccount option to the Restore-AzureRmRecoveryServicesBackupItem cmdlet.
	- Enabling this flag results in restoring disks to their original storage accounts which allows users to maintain the configuration of restored VM as close to the original VMs as possible.
	- It also helps in improving the performance of the restore operation.

#### AzureRM.RedisCache
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Added  3 new cmdlets for firewall rules
* Added  3 new cmdlets for geo replication
* Added support for zones and tags
* Make ResourceGroup as optional whenever possible.

#### AzureRM.Relay
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

#### AzureRM.Resources
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Added -AsJob support for long-running Resources cmdlets. Allows selected cmdlets to run in the background and return a job to track and control progress.
* Added alias from Get-AzureRmProviderOperation to Get-AzureRmResourceProviderAction to conform with naming conventions

#### AzureRM.Scheduler
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

#### AzureRM.ServerManagement
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Obsoleted -Tags in favor of -Tag for New-AzureRmServerManagementNode and New-AzureRmServerManagementGateway

#### AzureRM.ServiceBus
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

#### AzureRM.ServiceFabric
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

#### AzureRM.SiteRecovery
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

#### AzureRM.Sql
* Update the Auditing commands parameters description
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Added -AsJob parameter to long running cmdlets
* Obsoleted -DatabaseName parameter from Get-AzureRmSqlServiceObjective

#### AzureRM.Storage
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Fix a null reference issue of run cmdlet New-AzureRMStorageAccount with parameter -EnableEncryptionService None
* Added -AsJob support for long-running Storage cmdlets. Allows selected cmdlets to run in the background and return a job to track and control progress.
    - Affected cmdlets are New-, Remove-, Add-, and Update- for Storage Account and Storage Account Network Rule.

#### AzureRM.StreamAnalytics
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

#### AzureRM.TrafficManager
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

#### AzureRM.Websites
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription
* Added -AsJob support for long-running Websites cmdlets. Allows selected cmdlets to run in the background and return a job to track and control progress.
     - Affected cmdlets are New-, Remove-, Add-, and Set- for WebApps, AppServicePlan and Slots

## 2017.12.8 Version 5.1.1
* AnalysisServices
    - Change validate set of location to dynamic lookup so that all clouds are supported.
* Automation
    - Update to Import-AzureRMAutomationRunbook
        - Support is now being provided for Python2 runbooks
* Batch
    - Fixed a bug where account operations without a resource group failed to auto-detect the resource group
* Compute
    - Get-AzureRmComputeResourceSku shows zone information.
    - Update Disable-AzureRmVmssDiskEncryption to fix issue https://github.com/Azure/azure-powershell/issues/5038
    - Added -AsJob support for long-running Compute cmdlets. Allows selected cmdlets to run in the background and return a job to track and control progress.
        - Affected cmdlets include: New-, Update-, Set-, Remove-, Start-, Restart-, Stop- cmdlets for Virtual Machines and Virtual Machine Scale Sets
    - Added simplified parameter set to New-AzureRmVM, which creates a Virtual Machine and all required resources using smart defaults
* ContainerInstance
    - Apply Azure Container Instance SDK 2017-10-01
        - Support container run-to-completion
        - Support Azure File volume mount
        - Support opening multiple ports for public IP
* ContainerRegistry
    - New cmdlets for geo-replication and webhooks
        - Get/New/Remove-AzureRmContainerRegistryReplication
        - Get/New/Remove/Test/Update-AzureRmContainerRegistryWebhook
* DataFactories
    - Credential encryption functionality now works with both "Remote Access" enabled (Over Network) and "Remote Access" disabled (Local Machine).
* DataFactoryV2
    - Added two new cmdlets: Update-AzureRmDataFactoryV2 and Stop-AzureRmDataFactoryV2PipelineRun
* DataLakeAnalytics
    - Added a parameter called ScriptParameter to Submit-AzureRmDataLakeAnalyticsJob
        - Detailed information about ScriptParameter can be found using Get-Help on Submit-AzureRmDataLakeAnalyticsJob
    - For New-AzureRmDataLakeAnalyticsAccount, changed the parameter MaxDegreeOfParallelism to MaxAnalyticsUnits
        - Added an alias for the parameter MaxAnalyticsUnits: MaxDegreeOfParallelism
    - For New-AzureRmDataLakeAnalyticsComputePolicy, changed the parameter MaxDegreeOfParallelismPerJob to MaxAnalyticsUnitsPerJob
        - Added an alias for the parameter MaxAnalyticsUnitsPerJob: MaxDegreeOfParallelismPerJob
    - For Set-AzureRmDataLakeAnalyticsAccount, changed the parameter MaxDegreeOfParallelism to MaxAnalyticsUnits
        - Added an alias for the parameter MaxAnalyticsUnits: MaxDegreeOfParallelism
    - For Submit-AzureRmDataLakeAnalyticsJob, changed the parameter DegreeOfParallelism to AnalyticsUnits
        - Added an alias for the parameter AnalyticsUnits: DegreeOfParallelism
    - For Update-AzureRmDataLakeAnalyticsComputePolicy, changed the parameter MaxDegreeOfParallelismPerJob to MaxAnalyticsUnitsPerJob
        - Added an alias for the parameter MaxAnalyticsUnitsPerJob: MaxDegreeOfParallelismPerJob
* MachineLearningCompute
    - Add Set-AzureRmMlOpCluster
        - Update a cluster's agent count or SSL configuration
    - Orchestrator properties are optional
        - The service will create a service principal if not provided, so the orchestrator
        properties are now optional
* PowerBIEmbedded
    - Add support for Power BI Embedded Capacity cmdlets
    - New Cmdlet Get-AzureRmPowerBIEmbeddedCapacity - Gets the details of a PowerBI Embedded Capacity.
    - New Cmdlet New-AzureRmPowerBIEmbeddedCapacity - Creates a new PowerBI Embedded Capacity
    - New Cmdlet Remove-AzureRmPowerBIEmbeddedCapacity - Deletes an instance of PowerBI Embedded Capacity
    - New Cmdlet Resume-AzureRmPowerBIEmbeddedCapacity - Resumes an instance of PowerBI Embedded Capacity
    - New Cmdlet Suspend-AzureRmPowerBIEmbeddedCapacity - Suspends an instance of PowerBI Embedded Capacity
    - New Cmdlet Test-AzureRmPowerBIEmbeddedCapacity - Tests the existence of an instance of PowerBI Embedded Capacity
    - New Cmdlet Update-AzureRmPowerBIEmbeddedCapacity - Modifies an instance of PowerBI Embedded Capacity
* Profile
    - Updated USGovernmentActiveDirectoryEndpoint to https://login.microsoftonline.us/
        - For more information about the Azure Government endpoint mappings, please see the following: https://docs.microsoft.com/en-us/azure/azure-government/documentation-government-developer-guide#endpoint-mapping
    - Added -AsJob support for cmdlets, enabling selected cmdlets to execute in the background and return a job to track and control progress
    - Added -AsJob parameter to Get-AzureRmSubscription cmdlet
* RecoveryServices.Backup
    - Fixed bug - Get-AzureRmRecoveryServicesBackupItem should do case insensitive comparison for container name filter.
    - Fixed bug - AzureVmItem now has a property that shows the last time a backup operation has happened - LastBackupTime.
* Resources
    - Fixed issue where Get-AzureRMRoleAssignment would result in a assignments without roledefiniton name for custom roles
        - Users can now use Get-AzureRMRoleAssignment with assignments having roledefinition names irrespective of the type of role
    - Fixed issue where Set-AzureRMRoleRoleDefinition used to throw RD not found error when there was a new scope in assignablescopes
        - Users can now use Set-AzureRMRoleRoleDefinition with assignable scopes including new scopes irrespective of the position of the scope
    - Allow scopes to end with "/"
        - Users can now use RoleDefinition and RoleAssignment commandlets with scopes ending with "/" ,consistent with API and CLI
    - Allow users to create RoleAssignment using delegation flag
        - Users can now use New-AzureRMRoleAssignment with an option of adding the delegation flag
    - Fix RoleAssignment get to respect the scope parameter
    - Add an alias for ServicePrincipalName in the New-AzureRmRoleAssignment Commandlet
        - Users can now use the ApplicationId instead of the ServicePrincipalName when using the New-AzureRmRoleAssignment commandlet
* SiteRecovery
    - Add deprecation warnings for all cmdlets in this module in preparation for the next breaking change release.
        - Please see the upcoming breaking changes guide for more information on how to migrate your cmdlets from AzureRM.
* Sql
    - Added ability to rename database using Set-AzureRmSqlDatabase
    - Fixed issue https://github.com/Azure/azure-powershell/issues/4974
        - Providing invalid AUDIT_CHANGED_GROUP value for auditing cmdlets no longer throws an error and will be removed in an upcoming release.
    - Fixed issue https://github.com/Azure/azure-powershell/issues/5046
        - AuditAction parameter in auditing cmdlets is no longer being ignored
    - Fixed an issue in Auditing cmdlets when 'Secondary' StorageKeyType is provided
        - When setting blob auditing, the primary storage account key was used instead of the secondary key when providing 'Secondary' value for StorageKeyType parameter.
    - Changing the wording for confirmation message from Set-AzureRmSqlServerTransparentDataEncryptionProtector
* Azure (RDFE)
    - Removed all RemoteApp Cmdles
* Azure.Storage
    - Upgrade to Azure Storage Client Library 8.6.0 and Azure Storage DataMovement Library 0.6.5

## 2017.11.10 Version 5.0.1
* Fixed assembly loading issue that caused some cmdlets to fail when executing in the following modules:
    - AzureRM.ApiManagement
    - AzureRM.Backup
    - AzureRM.Batch
    - AzureRM.Compute
    - AzureRM.DataFactories
    - AzureRM.HDInsight
    - AzureRM.KeyVault
    - AzureRM.RecoveryServices
    - AzureRM.RecoveryServices.Backup
    - AzureRM.RecoveryServices.SiteRecovery
    - AzureRM.RedisCache
    - AzureRM.SiteRecovery
    - AzureRM.Sql
    - AzureRM.Storage
    - AzureRM.StreamAnalytics

## 2017.11.8 - Version 5.0.0
* NOTE: This is a breaking change release. Please see the migration guide (https://aka.ms/azps-migration-guide) for a full list of introduced breaking changes.
* All cmdlets in AzureRM now support online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser
* AnalysisServices
    * Fixed Synchronize-AzureAsInstance command to work with new AsAzure REST API for sync
* ApiManagement
    * Please see the migration guide for breaking changes made to ApiManagement this release
    * Updated Cmdlet Get-AzureRmApiManagementUser to fix issue https://github.com/Azure/azure-powershell/issues/4510
    * Updated Cmdlet New-AzureRmApiManagementApi to create Api with Empty Path https://github.com/Azure/azure-powershell/issues/4069
* ApplicationInsights
    * Add commands to get/create/remove applicaiton insights resource
        - Get-AzureRmApplicationInsights
        - New-AzureRmApplicationInsights
        - Remove-AzureRmApplicationInsights
    * Add commands to get/update pricing/daily cap of applicaiton insights resource
        - Get-AzureRmApplicationInsights -IncludeDailyCap
        - Set-AzureRmApplicationInsightsPricingPlan
        - Set-AzureRmApplicationInsightsDailyCap
    * Add commands to get/create/update/remove continuous export of applicaiton insights resource
    	- Get-AzureRmApplicationInsightsContinuousExport
    	- Set-AzureRmApplicationInsightsContinuousExport
    	- New-AzureRmApplicationInsightsContinuousExport
    	- Remove-AzureRmApplicationInsightsContinuousExport
    * Add commands to get/create/remove api keys of applicaiton insights resoruce
    	- Get-AzureRmApplicationInsightsApiKey
    	- New-AzureRmApplicationInsightsApiKey
    	- Remove-AzureRmApplicationInsightsApiKey
* AzureBatch
    * Added new parameters to `New-AzureRmBatchAccount`.
        - `PoolAllocationMode`: The allocation mode to use for creating pools in the Batch account. To create a Batch account which allocates pool nodes in the user's subscription, set this to `UserSubscription`.
        - `KeyVaultId`: The resource ID of the Azure key vault associated with the Batch account.
        - `KeyVaultUrl`: The URL of the Azure key vault associated with the Batch account.
    * Updated parameters to `New-AzureBatchTask`.
        - Removed the `RunElevated` switch. The `UserIdentity` parameter has been added to replace `RunElevated`, and the equivalent behavior can be achieved by constructing a `PSUserIdentity` as shown below:
            - $autoUser = New-Object Microsoft.Azure.Commands.Batch.Models.PSAutoUserSpecification -ArgumentList @("Task", "Admin")
            - $userIdentity = New-Object Microsoft.Azure.Commands.Batch.Models.PSUserIdentity $autoUser
        - Added the `AuthenticationTokenSettings` parameter. This parameter allows you to request the Batch service provide an authentication token to the task when it runs, avoiding the need to pass Batch account keys to the task in order to issue requests to the Batch service.
        - Added the `ContainerSettings` parameter.
            - This parameter allows you to request the Batch service run the task inside a container.
        - Added the `OutputFiles` parameter.
            - This parameter allows you to configure the task to upload files to Azure Storage after it has finished.
    * Updated parameters to `New-AzureBatchPool`.
        - Added the `UserAccounts` parameter.
            - This parameter defines user accounts created on each node in the pool.
        - Added `TargetLowPriorityComputeNodes` and renamed `TargetDedicated` to `TargetDedicatedComputeNodes`.
            - A `TargetDedicated` alias was created for the `TargetDedicatedComputeNodes` parameter.
        - Added the `NetworkConfiguration` parameter.
            - This parameter allows you to configure the pools network settings.
    * Updated parameters to `New-AzureBatchCertificate`.
        - The `Password` parameter is now a `SecureString`.
    * Updated parameters to `New-AzureBatchComputeNodeUser`.
        - The `Password` parameter is now a `SecureString`.
    * Updated parameters to `Set-AzureBatchComputeNodeUser`.
        - The `Password` parameter is now a `SecureString`.
    * Renamed the `Name` parameter to `Path` on `Get-AzureBatchNodeFile`, `Get-AzureBatchNodeFileContent`, and `Remove-AzureBatchNodeFile`.
        - A `Name` alias was created for the `Path` parameter.
    * Changes to objects
        - Please see the Batch change log for the full list
    * Added support for Azure Active Directory based authentication.
        - To use Azure Active Directory authentication, retrieve a `BatchAccountContext` object using the `Get-AzureRmBatchAccount` cmdlet, and supply this `BatchAccountContext` to the `-BatchContext` parameter of a Batch service cmdlet. Azure Active Directory authentication is mandatory for accounts with `PoolAllocationMode = UserSubscription`.
        - For existing accounts or for new accounts created with `PoolAllocationMode = BatchService`, you may continue to use shared key authentication by retrieving a `BatchAccountContext` object using the `Get-AzureRmBatchAccoutKeys` cmdlet.
* Compute
    * Azure Disk Encryption Extension Commands
        - New Parameter for 'Set-AzureRmVmDiskEncryptionExtension': '-EncryptFormatAll' encrypt formats data disks
        - New Parameters for 'Set-AzureRmVmDiskEncryptionExtension': '-ExtensionPublisherName' and '-ExtensionType' allow switching to other versions of the extension
        - New Parameters for 'Disable-AzureRmVmDiskEncryption': '-ExtensionPublisherName' and '-ExtensionType' allow switching to other versions of the extension
        - New Parameters for 'Get-AzureRmVmDiskEncryptionStatus': '-ExtensionPublisherName' and '-ExtensionType' allow switching to other versions of the extension
* DataLakeAnalytics
    * Please see the migration guide for breaking changes made to DataLakeAnalytics this release
    * Changed one of the two OutputTypes of Get-AzureRmDataLakeAnalyticsAccount
        - List\<DataLakeAnalyticsAccount> to List\<PSDataLakeAnalyticsAccountBasic>
        - The properties of PSDataLakeAnalyticsAccountBasic is a strict subset of the properties of DataLakeAnalyticsAccount
        - The additional properties that are in DataLakeAnalyticsAccount are not returned by the service.  Therefore, this change is to reflect this accurately. These additional properties are still in PSDataLakeAnalyticsAccountBasic, but they are tagged as Obsolete.
    * Changed one of the two OutputTypes of Get-AzureRmDataLakeAnalyticsJob
        - List\<JobInformation> to List\<PSJobInformationBasic>
        - The properties of PSJobInformationBasic is a strict subset of the properties of JobInformation
        - The additional properties that are in JobInformation are not returned by the service.  Therefore, this change is to reflect this accurately. These additional properties are still in PSJobInformationBasic, but they are tagged as Obsolete.
* DataLakeStore
    * Please see the migration guide for breaking changes made to DataLakeStore this release
    * Changed one of the two OutputTypes of Get-AzureRmDataLakeStoreAccount
        - List\<PSDataLakeStoreAccount> to List\<PSDataLakeStoreAccountBasic>
        - The properties of PSDataLakeStoreAccountBasic is a strict subset of the properties of PSDataLakeStoreAccount
        - The additional properties that are in PSDataLakeStoreAccount are not returned by the service.  Therefore, this change is to reflect this accurately. These additional properties are still in PSDataLakeStoreAccountBasic, but they are tagged as Obsolete.
* Dns
    * Support for CAA record types in Azure DNS
       - Supports all operations on CAA record type
* EventHub
    * Please see the migration guide for breaking changes made to EventHub this release
* Insights
    * Please see the migration guide for breaking changes made to Insights this release
* Network
    * Please see the migration guide for breaking changes made to Network this release
    * Added cmdlet to list available internet service providers for a specified Azure region
        - Get-AzureRmNetworkWatcherReachabilityProvidersList
    * Added cmdlet to get the relative latency score for internet service providers from a specified location to Azure regions
        - Get-AzureRmNetworkWatcherReachabilityReport
* Profile
    - Set-AzureRmDefault
        - Use this cmdlet to set a default resource group.  This will make the -ResourceGroup parameter optional for some cmdlets, and will use the default when a resource group is not specified
        - ```Set-AzureRmDefault -ResourceGroupName "ExampleResourceGroup"```
        - If resource group specified exists in the subscription, this resource group will be set to default.  Otherwise, the resource group will be created and then set to default.
    - Get-AzureRmDefault
        - Use this cmdlet to get the current default resource group (and other defaults in the future).
        - ```Get-AzureRmDefault -ResourceGroup```
    - Clear-AzureRmDefault
        - Use this cmdlet to remove the current default resource group
        - ```Clear-AzureRmDefault -ResourceGroup```
    - Add-AzureRmEnvironment and Set-AzureRmEnvironment
        - Add the BatchAudience parameter, which allows you to specify the Azure Batch Active Directory audience to use when acquiring authentication tokens for the Batch service.
* RecoveryServices.Backup
    * Added cmdlets to perform instant file recovery.
        - Get-AzureRmRecoveryServicesBackupRPMountScript
        - Disable-AzureRmRecoveryServicesBackupRPMountScript
    * Updated RecoveryServices.Backup SDK version to the latest
    * Updated tests for the Azure VM workload so that, all setups needed for test runs are done by the tests themselves.
    * Fixes https://github.com/Azure/azure-powershell/issues/3164
* RecoveryServices.SiteRecovery
    * Changes for ASR VMware to Azure Site Recovery (cmdlets are currently supporting operations for Enterprise to Enterprise, Enterprise to Azure, HyperV to Azure)
        - New-AzureRmRecoveryServicesAsrPolicy
        - New-AzureRmRecoveryServicesAsrProtectedItem
        - Update-AzureRmRecoveryServicesAsrPolicy
        - Update-AzureRmRecoveryServicesAsrProtectionDirection
    * Added support to AAD-based vault
    * Added cmdlets to manage VCenter resources
        - Get-AzureRmRecoveryServicesAsrVCenter
        - New-AzureRmRecoveryServicesAsrVCenter
        - Remove-AzureRmRecoveryServicesAsrVCenter
        - Update-AzureRmRecoveryServicesAsrVCenter
    * Added other cmdlets
        - Get-AzureRmRecoveryServicesAsrAlertSetting
        - Get-AzureRmRecoveryServicesAsrEvent
        - New-AzureRmRecoveryServicesAsrProtectableItem
        - Set-AzureRmRecoveryServicesAsrAlertSetting
        - Start-AzureRmRecoveryServicesAsrResynchronizeReplicationJob
        - Start-AzureRmRecoveryServicesAsrSwitchProcessServerJob
        - Start-AzureRmRecoveryServicesAsrTestFailoverCleanupJob
        - Update-AzureRmRecoveryServicesAsrMobilityService
* ServiceBus
    - Please see the migration guide for breaking changes made to ServiceBus this release
* Sql
    * Adding support for list and cancel the asynchronous updateslo operation on the database
    	- update existing cmdlet Get-AzureRmSqlDatabaseActivity to return DB updateslo operation status.
    	- add new cmdlet Stop-AzureRmSqlDatabaseActivity for cancel the asynchronous updateslo operation on the database.
    * Adding support for Zone Redundancy for databases and elastic pools
    	- Adding ZoneRedundant switch parameter to New-AzureRmSqlDatabase
    	- Adding ZoneRedundant switch parameter to Set-AzureRmSqlDatabase
    	- Adding ZoneRedundant switch parameter to New-AzureRmSqlElasticPool
    	- Adding ZoneRedundant switch parameter to Set-AzureRmSqlElasticPool
    * Adding support for Server DNS Aliases
    	- Adding Get-AzureRmSqlServerDnsAlias cmdlet which gets server dns aliases by server and alias name or a list of server dns aliases for an azure Sql Server.
    	- Adding New-AzureRmSqlServerDnsAlias cmdlet which creates new server dns alias for a given Azure Sql server
    	- Adding Set-AzurermSqlServerDnsAlias cmlet which allows updating a Azure Sql Server to which server dns alias is pointing
    	- Adding Remove-AzureRmSqlServerDnsAlias cmdlet which removes a server dns alias for a Azure Sql Server
* Azure.Storage
    * Upgrade to Azure Storage Client Library 8.5.0 and Azure Storage DataMovement Library 0.6.3
    * Add File Share Snapshot Support Feature
        - Add 'SnapshotTime' parameter to Get-AzureStorageShare
        - Add 'IncludeAllSnapshot' parameter to Remove-AzureStorageShare

## 2017.10.12 - Version 4.4.1
* AzureBatch
     - Marked cmdlet parameters and type properties obsolete in
       preparation for upcoming breaking change release (Version 4.0.0)
* HDInsight
    * Added support for Data Disks property in cluster creation
        - Added parameter 'WorkerNodeDataDisksGroups' to the New-AzureHDInsightCluster cmdlet
* Insights
        * Add-AzureRmLogAlertRule
            - Adding details to deprecation warning introduced in April 2017: the cmdlet will stop having effect: its functionality is moved to the "ActivityLogAlerts" cmdlets.
            - Help file modified to include the deprecation warning and the details.
        * Disable-AzureRmActivityLogAlert, Disable-AzureRmActivityLogAlert, Remove-AzureRmActivityLogAlert, Set-AzureRmActivityLogAlert
            - Help file modified: removed text stating that the Force arguments was accepted since that argument is not accepted.
* KeyVault
    * Deprecating the PurgeDisabled flag from Key, Secret and Certificate attributes, respectively.
      * The flag is being superseded by the RecoveryLevel attribute.
* MachineLearningCompute
    * Added initial set of cmdlets for MachineLearningCompute
        - Get-AzureRmMlOpCluster
        - Get-AzureRmMlOpClusterKey
        - New-AzureRmMlOpCluster
        - Remove-AzureRmMlOpCluster
        - Test-AzureRmMlOpClusterSystemServicesUpdateAvailability
        - Update-AzureRmMlOpClusterSystemService
* MarketplaceOrdering
    * New Cmdlet Get-AzureRmMarketplaceTerms
        - Get the agreement terms of a given publisher id, offer id and plan id.
    * New Cmdlet Set-AzureRmMarketplaceTerms
    	- Accept or reject agreement terms of a give publisher id, offer id and plan id. Please use Get-AzureRmMarketplaceTerms to get the agreement terms.
* Profile
    * LocationCompleterAttribute added and available for cmdlets which use the -Location parameter
        - Use this feature by adding LocationCompleter(string[] validResourceTypes) onto the Location parameter

## 2017.09.25 - Version 4.4.0
* AnalysisServices
    * Added a new dataplane commandlet to allow synchronization of databases from read-write instance to read-only instances
        - Included help file for the commandlet
        - Added in-memory tests and a scenario test (only live)
    * Fixed bugs in Add-AzureAsAccount commandlet
* Automation
    * Fixed help documents for cmdlets fixed in the earlier release.
    * Added 4 new cmdlets to support staged rollout of DSC node configurations.
        - Start-AzureRmAutomationDscNodeConfigurationDeployment
        - Stop-AzureRmAutomationDscNodeConfigurationDeployment
        - Get-AzureRmAutomationDscNodeConfigurationDeployment
        - Get-AzureRmAutomationDscNodeConfigurationDeploymentSchedule
* CognitiveServices
    * Integrate with Cognitive Services Management SDK version 2.0.0.
    * Get-AzureRmCognitiveServicesAccount now can correctly support paging.
* Compute
    * Run Command feature:
        - New cmdlet: 'Invoke-AzureRmVMRunCommand' invokes a run command on a VM
        - New cmdlet: 'Get-AzureRmVMRunCommandDocument' shows available run command documents
    * Add 'StorageAccountType' parameter to Set-AzureRmDataDisk
    * Availability Zone support for virtual machine, VM scale set, and disk
        - New paramter: 'Zone' is added to New-AzureRmVM, New-AzureRmVMConfig, New-AzureRmVmssConfig, New-AzureRmDiskConfig
    * VM scale set rolling upgrade feature:
        - New cmdlet: 'Start-AzureRmVmssRollingOSUpgrade' invokes OS rolling upgrade of VM scale set
        - New cmdlet: 'Set-AzureRmVmssRollingUpgradePolicy' sets upgrade policy for VM scale set rolling upgrade.
        - New cmdlet: 'Stop-AzureRmVmssRollingUpgrade' cancels rolling upgrade of VM scale set
        - New cmdlet: 'Get-AzureRmVmssRollingUpgrade' shows the status of VM scale set rolling upgrade.
    * AssignIdentity switch parameter is introduced for system assigned identity.
        - New parameter: 'AssignIdentity' is added to New-AzureRmVMConfig, New-AzureRmVmssConfig and Update-AzureRmVM
    * Vmss disk encryption feature:
        - New cmdlet: 'Set-AzureRmVmssDiskEncryptionExtension' enables disk encryption on VM scale set
        - New cmdlet: 'Disable-AzureRmVmssDiskEncryption' disables disk encryption on VM scale set
        - New cmdlet: 'Get-AzureRmVmssDiskEncryptionStatus' shows the disk encryption status of a VM scale set
        - New cmdelt: 'Get-AzureRmVmssVMDiskEncryptionStatus' shows the disk encryption status of VMs in a VM scale set
* ContainerInstance
    * Add PowerShell cmdlets for Azure Container Instance
        - New-AzureRmContainerGroup
        - Get-AzureRmContainerGroup
        - Remove-AzureRmContainerGroup
        - Get-AzureRmContainerInstanceLog
* Insights
        * New cmdlet Disable-AzureRmActivityLogAlert
            - A new cmdlet to disable an existing activity log alert.
            - Optionally the Tags are settable with this cmdlet too.
        * New cmdlet Enable-AzureRmActivityLogAlert
            - A new cmdlet to enable an existing activity log alert.
            - Optionally the Tags are settable with this cmdlet too.
        * New cmdlet Get-AzureRmActivityLogAlert
            - A new cmdlet to retrieve one or more activity log alerts.
            - The alerts can be retrieved by name, resource group, or subscription.
        * New cmdlet New-AzureRmActionGroup
            - A new cmdlet to create an ActionGroup object in memory (no request involved.)
        * New cmdlet New-AzureRmActivityLogAlertCondition
            - A new cmdlet to create an activity log alert leaf condition object in memory (no request involved.)
        * New cmdlet Set-AzureRmActivityLogAlert
            - A new cmdlet to create or update an activity log alert.
        * New cmdlet Remove-AzureRmActivityLogAlert
            - A new cmdlet to remove one activity log alert.
        * New cmdlet Set-AzureRmActionGroup
            - A new cmdlet to create a new or update an existing action group.
        * New cmdlet Get-AzureRmActionGroup
            - A new cmdlet to retrieve one or more action groups.
            - The action groups can be retrieved by name, resource group, or subscription.
        * New cmdlet Remove-AzureRmActionGroup
            - A new cmdlet to remove one action group.
        * New cmdlet New-AzureRmActionGroupReceiver
            - A new cmdlet to create an new action group receiver in memory.
* KeyVault
    * New/updated Cmdlets to support soft-delete for KeyVault certificates
      * Get-AzureKeyVaultCertificate
      * Remove-AzureKeyVaultCertificate
      * Undo-AzureKeyVaultCertificateRemoval
* Network
    * Added support for endpoint services to Virtual Network Subnets
        - Updated Add-AzureRmVirtualSubnetConfig: Added optional parameter -ServiceEndpoint
        - Updated New-AzureRmVirtualSubnetConfig: Added optional parameter -ServiceEndpoint
        - Updated Set-AzureRmVirtualSubnetConfig: Added optional parameter -ServiceEndpoint
    * Added cmdlet to list endpoint services available in the location
        - Get-AzureRmVirtualNetworkAvailableEndpointService
    * Added the ability to configure external radius based P2S authentication to the following commandlets
        - New-AzureVirtualNetworkGateway
        - Set-AzureVirtualNetworkGateway
        - Set-AzureRmVirtualNetworkGatewayVpnClientConfig
    * Added cmdlet to allow generation of VpnProfiles for external radius based P2S
        - New-AzureRmVpnClientConfiguration
    	  - Get-AzureRmVpnClientConfiguration
    * Added support for SKU parameter to Public IP Addresses and Load Balancers
        - Updated New-AzureRMLoadBalancer: Added optional parameter -Sku
        - Updated New-AzureRMPublicIpAddress: Added optional parameter -Sku
    * Added support for DisableOutboundSNAT to Load Balancer Rules
        - Updated New-AzureRMLoadBalancerRuleConfig: Added optional parameter DisableOutboundSNAT
        - Updated Add-AzureRMLoadBalancerRuleConfig: Added optional parameter DisableOutboundSNAT
        - Updated Set-AzureRMLoadBalancerRuleConfig: Added optional parameter DisableOutboundSNAT
    * Added support for IkeV2 P2S
        - Updated New-AzureRmVirtualNetworkGateway: Added optional parameter -VpnClientProtocol, defaults to [ "SSTP", "IkeV2" ]
        - Updated Set-AzureRmVirtualNetworkGateway: Added optional parameter -VpnClientProtocol
    * Added support for MultiValued rules in Network Security Rules and Effective Network Security Rules
        - Updated Add-AzureRmNetworkSecurityRuleConfig: Updated SourcePortRange, DestinationPortRange, SourceAddressPrefix parameters to accept a list of strings
        - Updated New-AzureRmNetworkSecurityRuleConfig: Updated SourcePortRange, DestinationPortRange, SourceAddressPrefix  parameter to accept a list of strings
        - Updated Set-AzureRmNetworkSecurityRuleConfig: Updated SourcePortRange, DestinationPortRange, SourceAddressPrefix parameter to accept a list of strings
        - Updated Add-AzureRmNetworkSecurityRuleConfig: Updated SourcePortRange, DestinationPortRange, SourceAddressPrefix parameter to accept a list of strings
        - Updated New-AzureRmNetworkSecurityGroupÂ : Updated SecurityRules parameter to accept SourcePortRange, DestinationPortRange, SourceAddressPrefix parameters which are list of strings in PSSecurityRule object
        - Updated Get-AzureRmEffectiveNetworkSecurityGroup: Added parameter TagMap
        - Updated Get-AzureRmEffectiveNetworkSecurityGroup: Updated returned PSEffectiveSecurityRule object with SourcePortRange, DestinationPortRange, SourceAddressPrefix parameters which are list of strings.
    * Added support for DDoS protection for virtual networks
        - Updated New-AzureRmVirtualNetwork: Added switch parameters EnableDDoSProtection and EnableVmProtection
        - Added properties EnableDDoSProtection and EnableVmProtection in PSVirtualNetwork object
    * Added support for Highly Available Internal Load Balancer
        - Updated Add-AzureRmLoadBalancerRuleConfig: Added All as an acceptable value for Protocol parameter
        - Updated New-AzureRmLoadBalancerRuleConfig: Added All as an acceptable value for Protocol parameter
        - Updated Set-AzureRmLoadBalancerRuleConfig: Added All as an acceptable value for Protocol parameter
    * Added support for Application Security Groups
        - Added New-AzureRmApplicationSecurityGroup
        - Added Get-AzureRmApplicationSecurityGroup
        - Added Remove-AzureRmApplicationSecurityGroup
        - Updated New-AzureRmNetworkInterface: Added optional parameters ApplicationSecurityGroup and ApplicationSecurityGroupId
        - Updated New-AzureRmNetworkInterfaceIpConfig: Added optional parameters ApplicationSecurityGroup and ApplicationSecurityGroupId
        - Updated Add-AzureRmNetworkInterfaceIpConfig: Added optional parameters ApplicationSecurityGroup and ApplicationSecurityGroupId
        - Updated Set-AzureRmNetworkInterfaceIpConfig: Added optional parameters ApplicationSecurityGroup and ApplicationSecurityGroupId
        - Updated New-AzureRmNetworkSecurityRuleConfig: Added optional parameters SourceApplicationSecurityGroup, SourceApplicationSecurityGroupId, DestinationApplicationSecurityGroup, and DestinationApplicationSecurityGroupId
        - Updated Add-AzureRmNetworkSecurityRuleConfig: Added optional parameters SourceApplicationSecurityGroup, SourceApplicationSecurityGroupId, DestinationApplicationSecurityGroup, and DestinationApplicationSecurityGroupId
        - Updated Set-AzureRmNetworkSecurityRuleConfig: Added optional parameters SourceApplicationSecurityGroup, SourceApplicationSecurityGroupId, DestinationApplicationSecurityGroup, and DestinationApplicationSecurityGroupId
    * Added new commands for VpnDeviceConfiguration Scripts
        - Get-AzureRmVirtualNetworkGatewaySupportedVpnDevices
        - Get-AzureRmVirtualNetworkGatewayConnectionVpnDeviceConfigScript
* Profile
  * Start-Job Support for AzureRm cmdlets.
    * All AzureRmCmdlets add -AzureRmContext parameter, which can accept a context (output of a Context cmdlet).
      - Common pattern for jobs with context persistence DISABLED: ```Start-Job {param ($context) New-AzureRmVM -AzureRmContext $context [... other parameters]} -ArgumentList (Get-AzureRmContext)```
      - Common pattern for jobs with context persistence ENABLED:```Start-Job {New-AzureRmVM [... other parameters]}```
  * Persist login information across sessions, new cmdlets:
    - Enable-AzureRmContextAutosave - Enable login persistence across sessions.
    - Disable-AzureRmContextAutosave - Disable login persistence across sessions.
  * Manage context information, new cmdets
    - Select-AzureRmContext - Select the active named context.
    - Rename-AzureRmContext - Rename an exsiting context for easy reference.
    - Remove-AzureRmContext - Remove an existing context.
    - Remove-AzureRmAccount - Remove all credentials, subscriptions, and tenants associated with an account.
  * Manage context information, cmdlet changes:
    - Added Scope = (Process | CurrentUser) to all cmdlets that change credentials
    - Get-AzureRmContext - Added ListAvailable parameter to list all saved contexts
* Resources
    * Add PolicySetDefinition cmdlets
        - New-AzureRmPolicySetDefinition cmdlet to create a policy set definition
        - Get-AzureRmPolicySetDefinition cmdlet to list all policy set definitions or to get a specific policy set definition
        - Remove-AzureRmPolicySetDefinition cmdlet to delete a policy set definition
        - Set-AzureRmPolicySetDefinition cmdlet to update an existing policy set definition
    * Add -PolicySetDefinition, -Sku and -NotScope parameters to New-AzureRmPolicyAssignment and Set-AzureRmPolicyAssignment cmdlets
    * Add support to pass in policy url to New-AzureRmPolicyDefinition and Set-AzureRmPolicyDefinition cmdlets
    * Add -Mode parameter to New-AzureRmPolicyDefinition cmdlet
    * Add Support for removal of roleassignment using PSRoleAssignment object
        - Users can now use PSRoleassignmnet inputobject with Remove-AzureRMRoleAssignment commandlet to remove the roleassignment.
    * Add ManagedApplication cmdlets
        - New-AzureRmManagedApplication cmdlet to create a managed application
        - Get-AzureRmManagedApplication cmdlet to list all managed applications under a subscription or to get a specific managed application
        - Remove-AzureRmManagedApplication cmdlet to delete a managed application
        - Set-AzureRmManagedApplication cmdlet to update an existing managed application
    * Add ManagedApplicationDefinition cmdlets
        - New-AzureRmManagedApplicationDefinition cmdlet to create a managed application definition using a zip file uri or using mainTemplate and createUiDefinition json files
        - Get-AzureRmManagedApplicationDefinition cmdlet to list all managed application definitions under a resource group or to get a specific managed application definition
        - Remove-AzureRmManagedApplicationDefinition cmdlet to delete a managed application definition
        - Set-AzureRmManagedApplicationDefinition cmdlet to update an existing managed application definition
* Sql
    * Adding support for Virtual Network Rules
    	- Adding Get-AzureRmSqlServerVirtualNetworkRule cmdlet which gets the virtual network rules by a specific rule name or a list of virtual network rules in an Azure Sql server.
    	- Adding Set-AzureRmSqlServerVirtualNetworkRule cmdlet which changes the virtual network that the rule points to.
    	- Adding Remove-AzureRmSqlServerVirtualNetworkRule cmdlet which removes a virtual network rule for an Azure Sql server.
    	- Adding New-AzureRmSqlServerVirtualNetworkRule cmdlet which creates a new virtual network rule for an Azure Sql server.
* Websites
    * Add PremiumV2 Tier for App Service Plans
* Azure.Storage
    * Upgrade to Azure Storage Client Library 8.4.0 and Azure Storage DataMovement Library 0.6.1
    * Add PremiumPageBlobTier Support in Upload and Copy Blob API
        - Set-AzureStorageBlobContent
    	- Start-AzureStorageBlobCopy
    * Refine the Console Output Format of AzureStorageContainer, AzureStorageBlob, AzureStorageQueue, AzureStorageTable
        - Get-AzureStorageContainer
        - Get-AzureStorageBlob
        - Get-AzureStorageQueue
        - Get-AzureStorageTable

## 2017.08.10 - Version 4.3.1
  * Update to fix assembly signing issue

## 2017.08.07 - Version 4.3.0
* AnalysisServices
    * Fixed bug in Set-AzureRmAnalysisServciesServer
        - When admin was not provided, the admin will be removed.
    * Added BackupBlobContainerUri in New-AzureRmAnalysisServicesServer and Set-AzureRmAnalysisServicesServer
        - Enable to set/disable backup blob container for backup/restore Azure Analysis Services Server
    * Updated Sku lookup in New-AzureRmAnalysisServicesServer and Set-AzureRmAnalysisServicesServer
        - Changed hard coded Sku into dynamic lookup.
    * Add-AzureAnalysisServicesAccount to support login with Service Principal
* Automation
    * Made changes to AutomationDSC* cmdlets to pull more than 100 records
    * Resolved the issue where the Verbose streams stop working after calling some Automation cmdlets (for example Get-AzureRmAutomationVariable, Get-AzureRmAutomationJob).
    * Support for NodeConfiguration Build versioning added in StartAzureAutomationDscCompilationJob and ImportAzureAutomationDscNodeConfiguration.
    * Bug fixes for existing issues - Fixes the alias issue is #3775 and the runOn alias and support for HybridWorkers.
* Compute
    * Set-AzureRmVMAEMExtension: Add support for new Premium Disk sizes
    * Set-AzureRmVMAEMExtension: Add support for M series
    * Add ForceUpdateTag parameter to Add-AzureRmVmssExtension
    * Add Primary parameter to New-AzureRmVmssIpConfig
    * Add EnableAcceleratedNetworking parameter to Add-AzureRmVmssNetworkInterfaceConfig
    * Add InstanceId to Set-AzureRmVmss
    * Expose MaintenanceRedeployStatus to Get-AzureRmVM -Status output
    * Expose Restriction and Capability to the table format of Get-AzureRmComputeResourceSku
* DataLakeStore
    * Fix for issue: https://github.com/Azure/azure-powershell/issues/4323
* EventHub
    * added ResourceGroup property to NamespaceAttributes
        - 'ResourceGroup' Gets the name of the resource group the Namespace is in
    * updated commandlets with new parameter and parameter alias
        - below cmdlets updated with Parametersets for Namespace and EventHub for operation of AuthorizationRule
        - New-AzureRmEventHubAuthorizationRule
            + Adds a new AuthorizationRule to the existing NameSpace or EventHub.
        - Get-AzureRmEventHubAuthorizationRule
            + Gets AuthorizationRule / List of AuthorizationRules for the existing NameSpace or EventHub.
        - Set-AzureRmEventHubAuthorizationRule
            + Updates properties of existing AuthorizationRule of EventHub NameSpace.
        - Remove-AzureRmEventHubAuthorizationRule
            + Deletes the existing AuthorizationRule of existing NameSpace or EventHub.
        - New-AzureRmEventHubKey
            + Generates a new Primary/Secondary Key for AuthorizationRule of existing NameSpace or EventHub.
        - Get-AzureRmEventHubKey
            + Gets Primary/Secondary Key for AuthorizationRule of existing NameSpace or EventHub.
* Network
    * New-AzureRmExpressRouteCircuitPeeringConfig: Added IPv6 support. New optional parameter added
    	- PeerAddressType
    * Set-AzureRmExpressRouteCircuitPeeringConfig: Added IPv6 support. New optional parameter added
    	- PeerAddressType
    * Remove-AzureRmExpressRouteCircuitPeeringConfig: Added IPv6 support. New optional parameter added
    	- PeerAddressType
    * Marked parameter -ProbeEnabled as obsolete
        - Add-AzureRmApplicationGatewayBackendHttpSettings
        - New-AzureRmApplicationGatewayBackendHttpSettings
        - Set-AzureRmApplicationGatewayBackendHttpSettings
* Profile
    * Data collection has been enabled by default. Usage data is collected by Microsoft in order to improve the user experience. The data is anonymous and does not include command-line argument values.
        - Use the Disable-AzureRmDataCollection cmdlet to turn the feature off
        - Use the Enable-AzureRmDataCollection cmdlet to turn this feature on
* Resources
    * Add Support for validation of scopes for the following roledefinition and roleassignment commandlets before sending the request to ARM
        - Get-AzureRMRoleAssignment
        - New-AzureRMRoleAssignment
        - Remove-AzureRMRoleAssignment
        - Get-AzureRMRoleDefinition
        - New-AzureRMRoleDefinition
        - Remove-AzureRMRoleDefinition
        - Set-AzureRMRoleDefinition
* ServiceBus
    * Added below new commandlets for AuthorizationRules for NameSpace, Queue and Topic. according to parameter set the authorization rule orperations are perfomed.
     - New-AzureRmServiceBusAuthorizationRule
       - Adds a new AuthorizationRule to the existing ServiceBus NameSpace/Queue/Topic.
     - Get-AzureRmServiceBusAuthorizationRule
       - Gets AuthorizationRule / List of AuthorizationRules for the existing ServiceBus NameSpace/Queue/Topic.
     - Set-AzureRmServiceBusAuthorizationRule
       - Updates properties of existing AuthorizationRule of Servicebus NameSpace/Queue/Topic.
     - New-AzureRmServiceBusKey
       - Generates a new Primary/Secondary Key for AuthorizationRule of existing ServiceBus NameSpace/Queue/Topic.
     - Get-AzureRmServiceBusKey
       - Gets Primary/Secondary Key for AuthorizationRule of existing ServiceBus NameSpace/Queue/Topic.
     - Remove-AzureRmServiceBusNamespaceAuthorizationRule
       - Deletes the existing AuthorizationRule of ServiceBus NameSpace/Queue/Topic.
    * Added Resource Group property to NamespceAttributes
* Sql
    * Updating Set-AzureRmSqlServerTransparentDataEncryptionProtector to display a warning and require confirmation if the Encryption Protector Type is being set to AzureKeyVault
    * Adding new updated cmdlets for Auditing settings
    	- Adding Get-AzureRmSqlDatabaseAuditing cmdlet which gets the auditing settings of an Azure SQL database.
    	- Adding Get-AzureRmSqlServerAuditing cmdlet which gets the auditing settings of an Azure SQL server.
    	- Adding Set-AzureRmSqlDatabaseAuditing cmdlet which changes the auditing settings for an Azure SQL database.
    	- Adding Set-AzureRmSqlServerAuditing cmdlet which changes the auditing settings of an Azure SQL server.
    * Deprecating the existing Auditing policy cmdlets
    	- Deprecating Get-AzureRmSqlDatabaseAuditingPolicy
    	- Deprecating Get-AzureRmSqlServerAuditingPolicy
    	- Deprecating Set-AzureRmSqlDatabaseAuditingPolicy
    	- Deprecating Set-AzureRmSqlServerAuditingPolicy
    	- Deprecating Use-AzureRmSqlServerAuditingPolicy
    	- Deprecating Remove-AzureRmSqlDatabaseAuditing
    	- Deprecating Remove-AzureRmSqlServerAuditing
    * Schema file parsing for Update-AzureRmSqlSyncGroup is now case insensitive.
* Storage
    * Add NeworkRule support to resource mode storage account cmdlets
        - New-AzureRmStorageAccount
        - Set-AzureRmStorageAccount
        - Get-AzureRmStorageAccountNetworkRuleSet
        - Update-AzureRmStorageAccountNetworkRuleSet
        - Add-AzureRmStorageAccountNetworkRule
        - Remove-AzureRmStorageAccountNetworkRule

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
     Â  Â - SALifeTimeSeconds defaults to 27000 seconds
     Â  Â - SADataSizeKilobytes defaults to 102400000 KB
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
    * Remove the validation against â€œTypeâ€ and â€œSkuNameâ€ of Cognitive Services Account, this will allow the script to support new APIs/SKUs without changes.
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
	Â Â Â Â - Added new param :- TunnelConnectionStatus in output Connection object to show per tunnel connection health status.
	* Reset-AzureRmVirtualNetworkGateway
	Â Â Â Â - Added optional input param:- gatewayVip to pass gateway vip for ResetGateway API in case of Active-Active feature enabled gateways.
	Â Â Â Â - Gateway Vip can be retrieved from PublicIPs refered in VirtualNetworkGateway object.

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
* **Behavioral change for -Force, â€“Confirm and $ConfirmPreference parameters for all cmdlets. We are changing this implementation to be in line with PowerShell guidelines. For most cmdlets, this means removing the Force parameter and to skip the ShouldProcess prompt, users will need to include the parameter: â€˜-Confirm:$falseâ€™ in their PowerShell scripts.** This changes are addressing following issues:
  * Correct implementation of â€“WhatIf functionality, allowing a user to determine the effects of a cmdlet or script without making any actual changes
  * Control over prompting using a session-wide $ConfirmPreference, so that the user is prompted based on the impact of a prospective change (as reported in the ConfirmImpact setting in the cmdlet)
  * Cmdlet-specific control over confirmation prompts using the â€“Confirm parameter
  * Consistent use of ShouldContinue and the â€“Force parameter across cmdlets, for only those actions that would require prompting from the user due to the special nature of the changes (for example, deleting hidden files)
  * Consistency with other PowerShell cmdlets, so that PowerShell scripting knowledge from other cmdlets is immediately applicable to the Azure PowerShell cmdlets.

**Notice that now to *automatically skip all Prompts in all Circumstances* Azure PowerShell cmdlets require the user to supply two parameters:**
```
My-CmdletWithConfirmation â€“Confirm:$false -Force
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
    * Warning message for deprecation Name parameter in New-AzureVM. The guidance is to use â€“Name parameter in New-AzureVMConfig cmdlet.
    * Save-AzureVMImgage has new paramter -Path to save the JSON template returned from the server.
    * Add-AzureVMNetworkInterface has new paramter -NetworkInterface which accepts a list of NIC object returned by Get-AzureNetworkInterface cmdlet.
    * Deprecated â€œ-Nameâ€ parameter in Set-AzureVMSourceImage. The guidance is to use the Pub, Offer, SKU, Version method to specify the VM Images for the VM.
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
    * Set-AzureSiteRecoveryProtectionEntity â€“ protection profile is introduced
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
  * Allow users to define which storage account key (Primary or Secondary) to use when defining audit policy, using the â€œStorageKeyTypeâ€ parameter.

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
        * SlotStickyConnectionStringNames â€“ connection string names not to be moved during swap operation
        * SlotStickyAppSettingNames â€“ application settings names not to be moved during swap operation
        * AutoSwapSlotName â€“ slot name to swap automatically with after successful deployment
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
* BREAKING CHANGE: New-AzureVM and New-AzureQuickVM now require an â€“AdminUserName parameter when creating Windows based VMs.
* Added support for virtual machine high memory SKUs (A6 and A7).
* Remote PowerShell is now enabled by default on Windows based VMs using https. To disable: specify the â€“DisableWinRMHttps parameter on New-AzureQuickVM or Add-AzureProvisioningConfig. To enable using http: specify â€“EnableWinRMHttp parameter (Note: http is intended for VM to VM communication and a public endpoint is not created by default).
* Added Get-AzureWinRMUri new cmdlet to get the connection string URI for Windows Remote Management.
* Added Set-AzureAvailabilitySet new cmdlet to group similar virtual machines into an availability set after deployment.
* New-AzureVM and New-AzureQuickVM now support a parameter named â€“X509Certificates. When a certificate is added to this array it is automatically uploaded and deployed to the virtual machine.
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
