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
