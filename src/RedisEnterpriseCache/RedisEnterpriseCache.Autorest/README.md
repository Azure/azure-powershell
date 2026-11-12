<!-- region Generated -->
# Az.RedisEnterpriseCache
This directory contains the PowerShell module for the RedisEnterpriseCache service.

---
## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.7.5 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.RedisEnterpriseCache`, see [how-to.md](how-to.md).
<!-- endregion -->

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# Pin the preview 2026-10-01 specification commit for reproducible generation.
commit: d041be265dd43bd327700a880c4632952b03aab7
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/redisenterprise/resource-manager/Microsoft.Cache/RedisEnterprise/preview/2026-10-01-preview/redisenterprise.json

module-version: 2.2.0
title: RedisEnterpriseCache
subject-prefix: 'RedisEnterpriseCache'

directive:
  # Require the access policy assignment properties envelope expected by the service.
  - from: swagger-document
    where: $.definitions.AccessPolicyAssignment
    transform: $['required'] = ['properties']
  # Require the user object ID nested in the assignment request model.
  - from: swagger-document
    where: $.definitions.AccessPolicyAssignmentPropertiesUser
    transform: $['required'] = ['objectId']
  # Require both geo-replication inputs used by the force-link operation.
  - from: swagger-document
    where: $.definitions.ForceLinkParametersGeoReplication
    transform: $['required'] = ['linkedDatabases','groupNickname']
  # Force these parameters as mandatory since swagger required on $ref definitions
  # doesn't always propagate to cmdlet parameters in autorest.powershell
  - where:
      verb: New
      subject: AccessPolicyAssignment
      parameter-name: UserObjectId
    required: true
  - where:
      verb: Invoke
      subject: ForceDatabaseLinkToReplicationGroup
      parameter-name: GroupNickname
    required: true
  - where:
      verb: Invoke
      subject: ForceDatabaseLinkToReplicationGroup
      parameter-name: LinkedDatabase
    required: true

  # Normalize the assignment operation name to generate New-* instead of Set-*.
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cache/redisEnterprise/{clusterName}/databases/{databaseName}/accessPolicyAssignments/{accessPolicyAssignmentName}"].put
    transform: $['operationId'] = 'AccessPolicyAssignment_CreateOrUpdate'
  # Use user-facing create-or-update wording in generated help.
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cache/redisEnterprise/{clusterName}/databases/{databaseName}/accessPolicyAssignments/{accessPolicyAssignmentName}"].put
    transform: $['description'] = 'Creates or updates a particular access policy assignment for a database'
  # Correct the cluster PUT description used by generated service APIs.
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cache/redisEnterprise/{clusterName}"].put
    transform: $['description'] = 'Creates or updates an existing Redis Enterprise cluster.'
  # This will remove the 'RedisEnterprise' prefix from the subject of every cmdlet
  # beginning with 'RedisEnterprise', because we have already set the subject-prefix above
  - where:
      subject: (^RedisEnterprise)(.*)
    set:
      subject: $2

  # Other cmdlet renames and aliases
  - where:
      subject: OperationsStatus
    set:
      subject: OperationStatus
  - where:
      subject: DatabaseKey
    set:
      subject: Key
  - where:
      verb: Invoke
      subject: UnlinkClusterMigratedEndpoint
    set:
      subject: ClusterUnlinkMigratedEndpoint
  - where:
      verb: Invoke
      subject: UnlinkMigrationMigratedEndpoint
    set:
      subject: MigrationUnlinkMigratedEndpoint
  # Clarify that Migration cmdlets apply only to Azure Cache for Redis
  # Basic, Standard, and Premium sources.
  - where:
      verb: Get
      subject: Migration
    set:
      command-description: Gets information about a migration from an Azure Cache for Redis Basic, Standard, or Premium cache to Azure Managed Redis.
  - where:
      verb: Test
      subject: Migration
    set:
      command-description: Validates whether an Azure Cache for Redis Basic, Standard, or Premium cache can be migrated to Azure Managed Redis.
  - where:
      verb: Undo
      subject: Migration
    set:
      command-description: Cancels or rolls back a migration from an Azure Cache for Redis Basic, Standard, or Premium cache to Azure Managed Redis.
  # Preserve the established user-facing description instead of the raw service operation wording.
  - where:
      verb: Update
      subject: ^$
    set:
      command-description: Updates an existing Redis Enterprise cluster.
  - where:
      verb: Invoke
      subject: MigrationUnlinkMigratedEndpoint
    set:
      command-description: Unlinks the migrated endpoint from an Azure Managed Redis cluster that was migrated from an Azure Cache for Redis Basic, Standard, or Premium cache.
  - where:
      verb: Test
      subject: Migration
      parameter-name: SourceResourceId
    set:
      parameter-description: The resource ID of the source Azure Cache for Redis Basic, Standard, or Premium cache to validate.
  - where:
      verb: New
      subject: Key
    set:
      alias:
        - New-AzRedisEnterpriseCacheDatabaseKey
        - New-AzRedisEnterpriseCacheAccessKey
  - where:
      verb: Get
      subject: Key
    set:
      alias:
        - Get-AzRedisEnterpriseCacheDatabaseKey
        - Get-AzRedisEnterpriseCacheAccessKey
  - where:
      verb: Import|Export
      subject: (^Database)(.*)
    set:
      subject: $2
  - where:
      verb: Import
      subject: ^$
    set:
      alias: Import-AzRedisEnterpriseCacheDatabase
  - where:
      verb: Clear
      subject: Database
    set:
      verb: Invoke
      subject: DatabaseFlush
  - where:
      verb: Export
      subject: ^$
    set:
      alias: Export-AzRedisEnterpriseCacheDatabase
  # Parameter renames and aliases
  - where:
      verb: Get|Update|Remove
      subject: ^$
      parameter-name: ClusterName
    set:
      alias: Name
  - where:
      verb: New
      subject: Database
      parameter-name: GeoReplicationLinkedDatabase
    set:
      parameter-name: LinkedDatabase
  - where:
      verb: New
      subject: Database
    set:
      hide: true
  - where:
      verb: Invoke
      subject: ForceDatabaseLinkToReplicationGroup
      parameter-name: GeoReplicationLinkedDatabase
    set:
      parameter-name: LinkedDatabase
  - where:
      verb: Invoke
      subject: ForceDatabaseLinkToReplicationGroup
      parameter-name: GeoReplicationGroupNickname
    set:
      parameter-name: GroupNickname
  - where:
      verb: New
      subject: Database
      parameter-name: GeoReplicationGroupNickname
    set:
      parameter-name: GroupNickname
  - where:
      model-name: ForceLinkParameters
      property-name: GeoReplicationLinkedDatabase
    set:
      property-name: LinkedDatabase
  - where:
      model-name: ForceLinkParameters
      property-name: GeoReplicationGroupNickname
    set:
      property-name: GroupNickname
  - where:
      parameter-name: SkuCapacity
    set:
      parameter-name: Capacity
      alias: SkuCapacity
  - where:
      parameter-name: SkuName
    set:
      parameter-name: Sku
      alias: SkuName
  - where:
      parameter-name: PersistenceAofEnabled
    set:
      parameter-name: AofPersistenceEnabled
  - where:
      parameter-name: PersistenceAofFrequency
    set:
      parameter-name: AofPersistenceFrequency
  - where:
      parameter-name: PersistenceRdbEnabled
    set:
      parameter-name: RdbPersistenceEnabled
  - where:
      parameter-name: PersistenceRdbFrequency
    set:
      parameter-name: RdbPersistenceFrequency
  # Use the plural form exposed by Redis for the keyspace notification setting.
  - where:
      parameter-name: NotifyKeyspaceEvent
    set:
      parameter-name: NotifyKeyspaceEvents
  # Keep the output/model property name consistent with the input parameter (plural)
  - where:
      property-name: NotifyKeyspaceEvent
    set:
      property-name: NotifyKeyspaceEvents
  # Keep the generated firewall parameter help concise while retaining the replacement semantics.
  - where:
      verb: Update
      subject: ^$
      parameter-name: FirewallRule
    set:
      parameter-description: The complete set of firewall rules for the cluster. Omitting this parameter preserves existing rules. An empty array clears all rules, and a non-empty array replaces all rules. At most 250 rules are supported, and non-empty rules require public network access to be enabled. Disabling public network access also clears existing rules. With public network access enabled, an empty rule set allows all public traffic; it does not deny all traffic. Firewall rules cannot be changed together with scaling or encryption settings.

  # Remove unused variants
  - where:
      verb: Get
      variant: ^GetViaIdentity$
    remove: true
  - where:
      verb: Export
      variant: ^Export$|^ExportViaIdentity
    remove: true
  - where:
      verb: Import
      variant: ^Import$|^ImportViaIdentity
    remove: true
  - where:
      verb: Update
      subject: ^(Database)?$
      variant: ^Update$|ViaIdentity$
    remove: true
  # Remove only the new UpgradeViaIdentity variant for DatabaseDbRedisVersion (didn't exist in v2.0.0)
  - where:
      verb: Update
      subject: DatabaseDbRedisVersion
      variant: UpgradeViaIdentity
    remove: true
  - where:
      verb: Get
      subject: OperationStatus
      variant: ViaIdentity$
    remove: true
  - where:
      verb: New
      subject: Key
      variant: ^Regenerate$|ViaIdentity
    remove: true

  # Remove unexpanded variant
  - where:
      verb: Invoke
      variant: ^(Flush|Force)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      subject: ^(Database)?$
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      subject: AccessPolicyAssignment
      variant: ^(Create)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  # Test-Migration (validate) ships as generated. Keep only the standard
  # Expanded/JsonFilePath/JsonString variants (module convention).
  - where:
      verb: Test
      subject: Migration
      variant: ^Validate$|^ValidateViaIdentity$|^ValidateViaIdentityExpanded$
    remove: true
  # Remove generated variants for Start-Migration except ViaJsonString (which the custom wrapper calls internally).
  # The generated Expanded variant doesn't nest the discriminated union body under "properties" envelope.
  - where:
      verb: Start
      subject: Migration
      variant: ^Start$|^StartExpanded$|^StartViaIdentity$|^StartViaIdentityExpanded$|^StartViaJsonFilePath$
    remove: true
  - where:
      verb: Start
      subject: Migration
      variant: ^StartViaJsonString$
    hide: true
  # Remove because cannot update
  - where:
      verb: Set|Update
      subject: AccessPolicyAssignment
    remove: true
  # Remove Update-Migration as there is no update to take place for an ongoing migration
  - where:
      verb: Update
      subject: Migration
    remove: true

  # Hide cmdlets
  - where:
      verb: New|Get
      subject: ^$|^Database$|^Key$
    hide: true
  - where:
      verb: Remove|Update
      subject: Database
    hide: true
  - where:
      verb: Import|Export
      subject: ^$
    hide: true
  - where:
      subject: PrivateEndpointConnection|PrivateLinkResource
    hide: true

  # DatabaseName parameter to have value 'default'
  - where:
      subject: ForceDatabaseUnlink
      parameter-name: DatabaseName
    hide: true
    set:
      default:
        script: '"default"'
  # DatabaseName parameter to have value 'default'
  - where:
      verb: Invoke
      subject: DatabaseFlush
      parameter-name: Name
    hide: true
    set:
      default:
        script: '"default"'

  # add breaking change warning message
  - where:
      verb: New|Update
      subject: RedisEnterpriseCache
    set:
      preview-announcement:
        preview-message: This cmdlet will undergo a breaking change in a future release. A new required property publicNetworkAccess will be added and AccessKeysAuthentication default value will be updated to Disabled
        estimated-ga-date:  2025/11/19

  # Fix bugs in generated code from namespace conflict
  # - from: source-file-csharp
  #   where: $
  #   transform: $ = $.replace(/Origin\(System.Convert.ToString\(/g, 'Origin(global::System.Convert.ToString(');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/Module.Instance.SetProxyConfiguration\(/g, 'Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Module.Instance.SetProxyConfiguration(');
  - from: source-file-csharp
    where: $
    transform: $ = $.replace(/Forcibly reforce an existing database/g, 'Forcibly recreates an existing database');

  # Breaking change
  - where:
      verb: Get
      subject: OperationStatus
    set:
      preview-announcement:
        preview-message: "*****************************************************************************************\\r\\n* This cmdlet will undergo a breaking change in Az v16.0.0, to be released in May 2026. *\\r\\n* At least one change applies to this cmdlet.                                                     *\\r\\n* See all possible breaking changes at https://go.microsoft.com/fwlink/?linkid=2333486            *\\r\\n**************************************************************************************************"
  - where:
      verb: Update
      subject: ^$
    set:
      preview-announcement:
        preview-message: "*****************************************************************************************\\r\\n* This cmdlet will undergo a breaking change in Az v16.0.0, to be released in May 2026. *\\r\\n* At least one change applies to this cmdlet.                                                     *\\r\\n* See all possible breaking changes at https://go.microsoft.com/fwlink/?linkid=2333486            *\\r\\n**************************************************************************************************"
```
