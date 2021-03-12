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

## Version 4.2.0
* Added new parameter `-EnableComputeIsolation` and `-ComputeIsolationHostSku` to the cmdlet `New-AzHDInsightCluster` to support compute isolation feature
* Added property `ComputeIsolationProperties` and `ConnectivityEndpoints` in the class AzureHDInsightCluster.


## Version 4.1.1
* Added properties: Fqdn and EffectiveDiskEncryptionKeyUrl in the class AzureHDInsightHostInfo.

## Version 4.1.0

* Add parameters `ResourceProviderConnection` and `PrivateLink` to cmdlet `New-AzHDInsightCluster` to support relay outbound and private link feature
* Add parameter `AmbariDatabase` to cmdlet `New-AzHDInsightCluster` to support custom Ambari database feature
* Add accept value "AmbariDatabase" to the parameter `MetastoreType` of the cmdlet `Add-AzHDInsightMetastore`

## Version 4.0.0
 * For New-AzHDInsightCluster cmdlet:
     - Replaced parameter `DefaultStorageAccountName` with `StorageAccountResourceId`
     - Replaced parameter `DefaultStorageAccountKey` with `StorageAccountKey`
     - Replaced parameter `DefaultStorageAccountType` with `StorageAccountType`
     - Removed parameter `PublicNetworkAccessType`
     - Removed parameter `OutboundPublicNetworkAccessType`
     - Added new parameters: `StorageFileSystem` and `StorageAccountManagedIdentity` to support ADLSGen2
     - Added new parameter `EnableIDBroker` to Support HDInsight ID Broker
     - Added new parameters: `KafkaClientGroupId`, `KafkaClientGroupName` and `KafkaManagementNodeSize` to support Kafka Rest Proxy
 * For New-AzHDInsightClusterConfig cmdlet:
     - Replaced parameter `DefaultStorageAccountName` with `StorageAccountResourceId`
     - Replaced parameter `DefaultStorageAccountKey` with `StorageAccountKey`
     - Replaced parameter `DefaultStorageAccountType` with `StorageAccountType`
     - Removed parameter `PublicNetworkAccessType`
     - Removed parameter `OutboundPublicNetworkAccessType`
* For Set-AzHDInsightDefaultStorage cmdlet:
    - Replaced parameter `StorageAccountName` with `StorageAccountResourceId`
* For Add-AzHDInsightSecurityProfile cmdlet:
    - Replaced parameter `Domain` with `DomainResourceId`
    - Removed the mandatory requirement for parameter `OrganizationalUnitDN`

## Version 3.6.1
* Added warning message for planning to deprecate the parameters `PublicNetworkAccessType` and `OutboundPublicNetworkAccessType`
* Added warning message for planning to replace the parameter `DefaultStorageAccountName` with `StorageAccountResourceId`
* Added warning message for planning to replace the parameter `DefaultStorageAccountKey` with `StorageAccountKey`
* Added warning message for planning to replace the parameter `DefaultStorageAccountType` with `StorageAccountType`
* Added warning message for planning to replace the parameter `DefaultStorageContainer` with `StorageContainer`
* Added warning message for planning to replace the parameter `DefaultStorageRootPath` with `StorageRootPath`

## Version 3.6.0
* Supported creating cluster with Autoscale configuration
    - Add new parameter `AutoscaleConfiguration` to the cmdlet `New-AzHDInsightCluster`
* Supported operating cluster's Autoscale configuration
    - Add new cmdlet `Get-AzHDInsihgtClusterAutoscaleConfiguration`
    - Add new cmdlet `New-AzHDInsihgtClusterAutoscaleConfiguration`
    - Add new cmdlet `Set-AzHDInsihgtClusterAutoscaleConfiguration`
    - Add new cmdlet `Remove-AzHDInsihgtClusterAutoscaleConfiguration`
    - Add new cmdlet `New-AzHDInsihgtClusterAutoscaleScheduleCondition`

## Version 3.5.0
* Supported creating cluster with encryption at host feature.

## Version 3.4.0
* Supported creating cluster with encryption in transit feature.
    - Add new parameter `EncryptionInTransit` to the cmdlet `New-AzHDInsightCluster`
	- Add new parameter `EncryptionInTransit` to the cmdlet `New-AzHDInsightClusterConfig`
* Supported creating cluster with private link feature:
    - Add new parameter `PublicNetworkAccessType` and `OutboundPublicNetworkAccessType` to the cmdlet `New-AzHDInsightCluster`
    - Add new parameter `PublicNetworkAccessType` and `OutboundPublicNetworkAccessType` to the cmdlet `New-AzHDInsightClusterConfig`
* Returned virtual network information when calling `New-AzHDInsightCluster` or `Get-AzHDInsightCluster`


## Version 3.3.1
* Supported creating cluster with ADLSGen1/2 storage in national clouds.

## Version 3.3.0
* Supported listing hosts and restart specific hosts of the HDInsight cluster.

## Version 3.2.0
* Supported Customer-managed key disk encryption.

## Version 3.1.0
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
