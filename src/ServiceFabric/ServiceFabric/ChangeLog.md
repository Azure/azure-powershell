<!--
    Please leave this section at the top of the change log.

    Changes for the upcoming release should go under the section titled "Upcoming Release", and should adhere to the following format:

    ## Upcoming Release
    * Overview of change #1
        - Additional information about change #1
    * Overview of change #2
        - Additional information about change #2
        - Additional information about change #2
    * Overview of change #3
    * Overview of change #4
        - Additional information about change #4

    ## YYYY.MM.DD - Version X.Y.Z (Previous Release)
    * Overview of change #1
        - Additional information about change #1
-->
## Upcoming Release

## Version 3.3.0
* Fixed minor issues

## Version 3.2.0
* Added new cmdlet `Add-AzServiceFabricManagedClusterNetworkSecurityRule` to update network security rules in managed cluster resource

## Version 3.1.1
* Added support for Windows 2022 server vm image. 
    - This enables cluster operations with Windows 2022 server vm image

## Version 3.1.0
* Fixed typo in verbose log message.
* Added Tag support for managed cluster create and update

## Version 3.0.2
* Added support for Ubuntu 20.04 vm image. 
    - This enables cluster operations with Ubuntu 20.04 vm image using AZ powershell. 

## Version 3.0.1
* Fixed Managed and Classic Application models (Application, Cluster, Service) by updating constructor to take all new properties
    - This solves piping related issues where piping the results directly from a Get cmdlet call into and Update or Set call remove some intentionally set properties
    - Updated appropriate test files to cover the above mentioned cases

## Version 3.0.0
* Removed deprecated cluster certificate commands:
    - `Add-AzServiceFabricClusterCertificate`
    - `Remove-AzServiceFabricClusterCertificate`
* Changed PSManagedService model to avoid using the properties parameter directly from sdk.
* Removed deprecated parameters for managed cmdlets:
    - `ReverseProxyEndpointPort`
    - `InstanceCloseDelayDuration`
    - `ServiceDnsName`
    - `InstanceCloseDelayDuration`
    - `DropSourceReplicaOnMove`
* Fixed `Update-AzServiceFabricReliability` to update correctly the vm instance count of the primary node type on the cluster resource.

## Version 2.4.0
* Upgraded Managed Cluster commands to use Service Fabric Managed Cluster SDK version 1.0.0 which uses service fabric resource provider api-version 2021-05-01.
* `New-AzServiceFabricManagedCluster` add parameters UpgradeCadence and ZonalResiliency.
* `New-AzServiceFabricManagedNodeType` add parameters DiskType, VmUserAssignedIdentity, IsStateless and MultiplePlacementGroup.
* `New-AzServiceFabricManagedClusterService` and `Set-AzServiceFabricManagedClusterService` mark parameters for deprecation: InstanceCloseDelayDuration, DropSourceReplicaOnMove and ServiceDnsName. They are not supported.

## Version 2.3.0
* Added parameters `VMImagePublisher`, `VMImageOffer`, `VMImageSku`, `VMImageVersion` to `Add-AzServiceFabricNodeType` to facilitate easy alternate OS image creation for new node type.
* Added parameter `IsPrimaryNodeType` to `Add-AzServiceFabricNodeType` to be able to create an additional primary node type, for the purpose of transitioning the primary node type to another one in the case of OS migration.
* `Add-AzServiceFabricNodeType` now correctly copies the LinuxDiagnostic extension. This was previously not working for Linux.
* `Add-AzServiceFabricNodeType` now correctly copies the RDP/SSH load balancer inbound NAT port mapping to the new node type.
* Added template for `UbuntuServer1804` for creating Ubuntu 18.04 clusters using `New-AzServiceFabricCluster`.
* `Remove-AzServiceFabricNodeType` was incorrectly blocking Bronze durability node types for removal, and this has been updated to only block when the Bronze durability level differs between the SF node type and VMSS setting.
* Added cmdlet `Update-AzServiceFabricVmImage` to update the delivered SF runtime package type. This must be changed when migrating from Ubuntu 16 to 18.
* Added cmdlet `Update-AzServiceFabricNodeType` to update the properties of a cluster node type. For now this is solely used to update whether the node type is primary via bool parameter `-IsPrimaryNodeType $false`.
* `Update-AzServiceFabricReliability` is now able to update reliability level when the cluster has more than one primary node type. To do this, the name of the node type is supplied via the new -NodeType parameter.

* Added new cmdlets for managed applications:
    - `New-AzServiceFabricManagedClusterApplication`
    - `Get-AzServiceFabricManagedClusterApplication`
    - `Set-AzServiceFabricManagedClusterApplication`
    - `Remove-AzServiceFabricManagedClusterApplication`
    - `New-AzServiceFabricManagedClusterApplicationType`
    - `Get-AzServiceFabricManagedClusterApplicationType`
    - `Set-AzServiceFabricManagedClusterApplicationType`
    - `Remove-AzServiceFabricManagedClusterApplicationType`
    - `New-AzServiceFabricManagedClusterApplicationTypeVersion`
    - `Get-AzServiceFabricManagedClusterApplicationTypeVersion`
    - `Set-AzServiceFabricManagedClusterApplicationTypeVersion`
    - `Remove-AzServiceFabricManagedClusterApplicationTypeVersion`
    - `New-AzServiceFabricManagedClusterService`
    - `Get-AzServiceFabricManagedClusterService`
    - `Set-AzServiceFabricManagedClusterService`
    - `Remove-AzServiceFabricManagedClusterService`
* Upgraded Managed Cluster commands to use Service Fabric Managed Cluster SDK version 1.0.0-beta.1 which uses service fabric resource provider api-version 2021-01-01-preview.

## Version 2.2.2
* Fixed `Add-AzServiceFabricNodeType`. Added node type to service fabric cluster before creating virtual machine scale set.

## Version 2.2.1
* Added example to `Set-AzServiceFabricSetting` with SettingsSectionDescription param
* Updated application related cmdlets to call out that support is only for ARM deployed resources
* Marked for deprecation cluster cert cmdlets `Add-AzureRmServiceFabricClusterCertificate` and `Remove-AzureRmServiceFabricClusterCertificate`

## Version 2.2.0
* Added new cmdlets for managed clusters and node types:
    - `New-AzServiceFabricManagedCluster`
    - `Get-AzServiceFabricManagedCluster`
    - `Set-AzServiceFabricManagedCluster`
    - `Remove-AzServiceFabricManagedCluster`
    - `Add-AzServiceFabricManagedClusterClientCertificate`
    - `Remove-AzServiceFabricManagedClusterClientCertificate`
    - `New-AzServiceFabricManagedNodeType`
    - `Get-AzServiceFabricManagedNodeType`
    - `Set-AzServiceFabricManagedNodeType`
    - `Remove-AzServiceFabricManagedNodeType`
    - `Add-AzServiceFabricManagedNodeTypeVMExtension`
    - `Add-AzServiceFabricManagedNodeTypeVMSecret`
    - `Remove-AzServiceFabricManagedNodeTypeVMExtension`
    - `Restart-AzServiceFabricManagedNodeType`
* Upgraded Service Fabric SDK to version 1.2.0 which uses service fabric resource provider api-version 2020-03-01 for the current model and 2020-01-01-preview for managed clusters.

## Version 2.1.0
* Fixed bug in add certificate using --SecretIdentifier that was getting the wrong certificate thumbprint

## Version 2.0.2
* Improved code formatting and usability of `New-AzServiceFabricCluster` examples

## Version 2.0.1
* Update references in .psd1 to use relative path

## Version 2.0.0
* Remove Add-AzServiceFabricApplicationCertificate cmdlet as this scenario is covered by Add-AzVmssSecret.

## Version 1.2.0
* Fixed typo in example for `Update-AzServiceFabricReliability` reference documentation
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

## Version 1.1.2
* Fix add node type cmdlet bugs:
    - NullReferenceException bug when resource group had other vmss not related to the service fabric cluster. Fixes issue: https://github.com/Azure/azure-powershell/issues/8681
    - Fix bug where cmdlet failed if virtualNetwork was in a different resource group that the cluster. fixes issue: https://github.com/Azure/azure-powershell/issues/8407
    - Deprecating Add-AzServiceFabricApplicationCertificate cmdlet

## Version 1.1.1
* Fix add certificate ByExistingKeyVault getting the wrong thumbprint in some cases

## Version 1.1.0
* Fix typo in error message for `Update-AzServiceFabricReliability`

* Fix missing character in Service Fabric cmdlines

## Version 1.0.1
* Rollback when a certificate is added to VMSS model but an exception is thrown this is to fix bug: https://github.com/Azure/service-fabric-issues/issues/932
* Fix some error messages.
* Fix create cluster with default ARM template for New-AzServiceFabriCluster which was not working with migration to Az.
* Fix add cluster/application certificate to only add to VM Scale Sets that correspond to the cluster by checking cluster id in the extension.

## Version 1.0.0
* General availability of `Az.ServiceFabric` module
* Upgraded Service Fabric SDK dependency to version 1.1.0.
    - This change allows the cmdlets to suport certifiates by common names.
* Added optinal parameters -CertCommonName and -CertIssuerThumbprint to `New-AzureRmServiceFabricCluster` to support creating cluster with certificate by common name.
* Added optional parameters -CertCommonName and -CertIssuerThumbprint to `Add-AzureRmServiceFabricClusterCertificate` to support adding certificate by common name.
