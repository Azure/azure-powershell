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

* Add example to Set-AzServiceFabricSetting with SettingsSectionDescription param
* Update application related cmdlets to call out that support is only for ARM deployed resources
* Mark for deprecation cluster cert cmdlets Add-AzureRmServiceFabricClusterCertificate and Remove-AzureRmServiceFabricClusterCertificate

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
    - `Restart-AzServiceFabricManagedNodeTyp`
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
