<!--
    Please leave this section at the top of the change log.

    Changes for the current release should go under the section titled "Current Release", and should adhere to the following format:

    ## Current Release
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
## Current Release
* Fixed server authentication usage with generated certificates (Issue #5998)

## Version 0.3.5
* Update default Linux image version sku
  - NewAzureServiceFabricCluster.cs default UbuntuServer1604 Sku update
* Set minimum dependency of module to PowerShell 5.0


## Version 0.3.4
* Updated to the latest version of the Azure ClientRuntime

## Version 0.3.3
* Fix issue with Default Resource Group in CloudShell

## Version 0.3.2
* Service Fabric cmdlet refresh
  - Updated ARM templates
  - Failed operations no longer rollback
  - Add-AzureRmServiceFabricNodeType
    - VMs default to managed disks
    - Existing VMSS subnet used
    - All operations are idempotent
  - Remove-AzureRmServiceFabricNodeType cleans up partially created VMSS and/or cluster node types
  - Fixed output of PSCluster object for complex property types

## Version 0.3.1
* Added Location Completer to -Location parameters allowing tab completion through valid Locations
* Added ResourceGroup Completer to -ResourceGroup parameters allowing tab completion through resource groups in current subscription

## Version 0.3.0
* Add support for online help
    - Run Get-Help with the -Online parameter to open the online help in your default Internet browser
    
## Version 0.2.7

## Version 0.2.6

## Version 0.2.4

## Version 0.2.3

## Version 0.2.2

## Version 0.2.1

## Version 0.2.0

## Version 0.1.1

## Version 0.1.0

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
