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
* Supported specifying minimal supported TLS version when creating cluster.

## Version 3.0.3
* Fix document error of New-AzHDInsightCluster.

## Version 3.0.2
* Fix Invoke-AzHDInsightHiveJob.md error.

## Version 3.0.1
* Update references in .psd1 to use relative path

## Version 3.0.0
* Fixed the bug that customer will get "Not a valid Base-64 string" error when using Get-AzHDInsightCluster to get the cluster with ADLSGen1 storage.
* Add a parameter named "ApplicationId" to three cmdlets Add-AzHDInsightClusterIdentity, New-AzHDInsightClusterConfig and New-AzHDInsightCluster so that customer can provide the service principal application id for accessing Azure Data Lake.
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
* Removed parameter sets("Spark1", "Spark2") from Add-AzHDInsightConfigValue.
* Add examples to the help documents of cmdlet Add-AzHDInsightSecurityProfile.
* Changed output type of the following cmdlets:
*  - Changed the output type of Get-AzHDInsightProperties from  CapabilitiesResponse to AzureHDInsightCapabilities.
*  - Changed the output type of Remove-AzHDInsightCluster from ClusterGetResponse to bool.
*  - Changed the output type of Set-AzHDInsightGatewaySettings HttpConnectivitySettings to GatewaySettings.
* Added some scenario test cases.
* Remove some alias: 'Add-AzHDInsightConfigValues', 'Get-AzHDInsightProperties'.

## Version 2.0.2
* Call out breaking changes

## Version 2.0.1
* Fixed miscellaneous typos across module

## Version 2.0.0
* Removed two cmdlets:
    - Grant-AzHDInsightHttpServicesAccess
    - Revoke-AzHDInsightHttpServicesAccess
* Added a new cmdlet Set-AzHDInsightGatewayCredential to replace Grant-AzHDInsightHttpServicesAccess
* Update cmdlet Get-AzHDInsightJobOutput to distinguish reader role and hdinsight operator role:
    - Users with reader role need to specify `DefaultStorageAccountKey` parameter explicitly, otherwise error occurs.
	- Users with hdinsight operator role will not be affected.


## Version 1.1.0
* Updated cmdlets with plural nouns to singular, and deprecated plural names.

## Version 1.0.0
* General availability of `Az.HDInsight` module
