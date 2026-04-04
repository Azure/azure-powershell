<!-- region Generated -->
# Az.AppConfiguration
This directory contains the PowerShell module for the AppConfiguration service.

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
For information on how to develop for `Az.AppConfiguration`, see [how-to.md](how-to.md).
<!-- endregion -->

---
## Generation Requirements
Use of the `autorest.powershell` generator requires the following:
- [NodeJS LTS](https://nodejs.org) (18.x LTS or greater)
- [AutoRest](https://aka.ms/autorest) v3 <br>`npm install -g autorest@latest`<br>&nbsp;
- PowerShell 7.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g pwsh`<br>&nbsp;
- .NET SDK 8.0 or greater
  - If you don't have it installed, download from [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)<br>&nbsp;

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 45cbb1a2b5a68c01b7182dbcaa57c3052f992647
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/appconfiguration/resource-manager/Microsoft.AppConfiguration/stable/2024-06-01/appconfiguration.json

module-version: 1.0.0
title: AppConfiguration
subject-prefix: $(service-name)

directive:
  # Strip x-ms-identifiers extension to avoid schema validation errors
  - from: swagger-document
    where: $.definitions.OperationDefinitionListResult.properties.value
    transform: delete $['x-ms-identifiers']
  - from: swagger-document
    where: $.definitions.ServiceSpecification.properties.logSpecifications
    transform: delete $['x-ms-identifiers']
  - from: swagger-document
    where: $.definitions.ServiceSpecification.properties.metricSpecifications
    transform: delete $['x-ms-identifiers']
  - from: swagger-document
    where: $.definitions.MetricSpecification.properties.dimensions
    transform: delete $['x-ms-identifiers']
  - from: swagger-document
    where: $.definitions.ErrorDetails.properties.additionalInfo
    transform: delete $['x-ms-identifiers']
  - from: swagger-document
    where: $.definitions.SnapshotProperties.properties.filters
    transform: delete $['x-ms-identifiers']

  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$|^CheckViaIdentityExpanded$|^PurgeViaIdentityLocation$|^GetViaIdentityLocation$
    remove: true

  - where:
      parameter-name: ConfigStoreCreationParameter|RegenerateKeyParameter|CheckNameAvailabilityParameter
    select: command
    hide: true

  # Rename parameters to follow design guideline
  - where:
      subject: OperationNameAvailability
    set:
      subject: StoreNameAvailability
  - where:
      parameter-name: KeyVaultPropertyIdentityClientId
    set:
      parameter-name: KeyVaultIdentityClientId
  - where:
      parameter-name: KeyVaultPropertyKeyIdentifier
    set:
      parameter-name: EncryptionKeyIdentifier
  - where:
      parameter-name: SkuName
    set:
      parameter-name: Sku

  - where:
      subject: ConfigurationStoreKeyValue
      verb: Get
    remove: true

  # Sanitize doesn't work because parameter name doesn't start with subject
  - where:
      subject: ConfigurationStore|ConfigurationStoreKey
      parameter-name: ConfigStoreName
    set:
      parameter-name: Name

  # Private link features are implemented in Az.Network so we don't need them
  - where:
      subject: PrivateEndpointConnection|PrivateLinkResource
    remove: true

  # Remove `[-SkipToken <String>]` because we hide pageable implementation.
  - from: swagger-document
    where: $.paths.*.*
    transform: $.parameters = $.parameters.filter(p => p.name !== '$skipToken')

  # Swagger bug. Remove when https://github.com/Azure/azure-rest-api-specs/issues/10188 is fixed.
  - from: swagger-document
    where: $.definitions.RegenerateKeyParameters
    transform: $.required = ['id']

  # Update cmdlet descriptions
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}"].get.description
    transform: return "Get or list app configuration stores."

  - where:
      subject: ^KeyValue$
    remove: true

  - where:
      subject: ^ConfigurationStoreDeleted$
    set:
      subject: ConfigurationDeletedStore

  # Snapshot operations are ARM proxies for data plane; exclude from this module
  - where:
      subject: ^Snapshot$
    remove: true

  # CreateMode is create-only (x-ms-mutability: create), not applicable to Update
  - where:
      verb: Update
      subject: ConfigurationStore
      parameter-name: CreateMode
    hide: true

  # Location is create-only on stores, not updatable
  - where:
      verb: Update
      subject: ConfigurationStore
      parameter-name: Location
    hide: true

  # Location is required when creating a replica
  - from: swagger-document
    where: $.definitions.Replica
    transform: >
      if (!$.required) { $.required = []; }
      if (!$.required.includes('location')) { $.required.push('location'); }

  # Hide Update-AzAppConfigurationReplica; replicas have no updatable properties
  - where:
      verb: Update
      subject: Replica
    hide: true

  # Format output
  - where:
      model-name: Replica
    set:
      format-table:
        properties:
          - Name
          - Location
          - ProvisioningState
          - ResourceGroupName
```
