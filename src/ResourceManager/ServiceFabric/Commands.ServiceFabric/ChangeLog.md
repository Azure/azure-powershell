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
* Upgraded Service Fabric SDK dependency to version 1.1.0.
    - This change allows the cmdlets to suport certifiates by common names.
* Added optinal parameters -CertCommonName and -CertIssuerThumbprint to `New-AzureRmServiceFabricCluster` to support creating cluster with certificate by common name.
* Added optional parameters -CertCommonName and -CertIssuerThumbprint to `Add-AzureRmServiceFabricClusterCertificate` to support adding certificate by common name.
