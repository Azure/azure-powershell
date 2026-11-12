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
* Upgraded code generator. See [here](https://go.microsoft.com/fwlink/?linkid=2340249).
* Added support for preview API version 2026-10-01-preview
* Added `FirewallRule` to `New-AzRedisEnterpriseCache` and `Update-AzRedisEnterpriseCache` for configuring Azure Managed Redis firewall rules
* Added `AccessString` to `New-AzRedisEnterpriseCacheAccessPolicyAssignment` for configuring custom Redis access control list permissions
* Added access policy assignment provisioning error details to command output
* Added `Get-AzRedisEnterpriseCacheMigration` cmdlet to get information about a migration from an Azure Cache for Redis Basic, Standard, or Premium cache to Azure Managed Redis
* Added `Start-AzRedisEnterpriseCacheMigration` cmdlet to start a migration from an Azure Cache for Redis Basic, Standard, or Premium cache to Azure Managed Redis
* Added `Undo-AzRedisEnterpriseCacheMigration` cmdlet to cancel or rollback a migration from an Azure Cache for Redis Basic, Standard, or Premium cache to Azure Managed Redis
* Added `Test-AzRedisEnterpriseCacheMigration` cmdlet to validate whether an Azure Cache for Redis Basic, Standard, or Premium cache can be migrated to Azure Managed Redis
* Added `Invoke-AzRedisEnterpriseCacheClusterUnlinkMigratedEndpoint` and `Invoke-AzRedisEnterpriseCacheMigrationUnlinkMigratedEndpoint` cmdlets to unlink endpoints after migrations from Azure Cache for Redis Enterprise and Azure Cache for Redis Basic, Standard, or Premium, respectively
* Added `MaintenanceConfigurationMaintenanceWindow` parameter to `New-AzRedisEnterpriseCache` and `Update-AzRedisEnterpriseCache` for configuring maintenance windows
* Added `NotifyKeyspaceEvents` parameter to `New-AzRedisEnterpriseCache`, `New-AzRedisEnterpriseCacheDatabase`, and `Update-AzRedisEnterpriseCacheDatabase` for configuring keyspace notifications

## Version 2.0.0
* [Upgraded code generator](https://go.microsoft.com/fwlink/?linkid=2340249)

## Version 1.6.1
* Preannounced breaking changes. Please refer to https://go.microsoft.com/fwlink/?linkid=2333229

## Version 1.6.0
* Added a new required property: PublicNetworkAccess for Cluster.
* Updated the default value of AccessKeysAuthentication property for Database to 'Disabled'.

## Version 1.5.0
* Added support for listing all SKUs a cluster can scale to.
* Added a new enum: NoCluster for Clustering policy.

## Version 1.4.1
* Upgraded nuget package to signed package.

## Version 1.4.0
* Added support for using Microsoft Entra token-based authentication.
* Added the new properties of Cluster: highAvailability and redundancyMode.
* Added new product SKUs.
* Added the new properties of Database: accessKeysAuthentication.
* Added Invoke-AzRedisEnterpriseCacheForceDatabaseLinkToReplicationGroup to force link geo replicated caches.
* Added Update-AzRedisEnterpriseCacheDatabaseDbRedisVersion to upgrade the redis database version directly.

## Version 1.2.1
* Introduced secrets detection feature to safeguard sensitive data.

## Version 1.2.0
* Upgraded API version to 2023-03-01-preview

## Version 1.1.0
* Upgraded API version to 2022-01-01

## Version 1.0.0
* GA version of Az.RedisEnterpriseCache

## Version 0.1.0
* First preview release for module Az.RedisEnterpriseCache
