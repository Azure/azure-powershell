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