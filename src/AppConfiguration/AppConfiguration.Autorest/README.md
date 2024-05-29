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
Use of the beta version of `autorest.powershell` generator requires the following:
- [NodeJS LTS](https://nodejs.org) (10.15.x LTS preferred)
  - **Note**: It *will not work* with Node < 10.x. Using 11.x builds may cause issues as they may introduce instability or breaking changes.
> If you want an easy way to install and update Node, [NVS - Node Version Switcher](../nodejs/installing-via-nvs.md) or [NVM - Node Version Manager](../nodejs/installing-via-nvm.md) is recommended.
- [AutoRest](https://aka.ms/autorest) v3 beta <br>`npm install -g autorest@beta`<br>&nbsp;
- PowerShell 6.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g pwsh`<br>&nbsp;
- .NET Core SDK 2.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g dotnet-sdk-2.2`<br>&nbsp;

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 7d6b4765562b238310ea80d652ac08597fec0476
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/appconfiguration/resource-manager/Microsoft.AppConfiguration/stable/2022-05-01/appconfiguration.json

module-version: 1.0.0
title: AppConfiguration
subject-prefix: $(service-name)

# If there are post APIs for some kinds of actions in the RP, you may need to
# uncomment following line to support viaIdentity for these post APIs
identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  # Remove the unexpanded parameter set
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^CheckViaIdentityExpanded$
    remove: true

  - where:
      parameter-name: ConfigStoreCreationParameter|RegenerateKeyParameter|CheckNameAvailabilityParameter
    select: command
    hide: true

  # Hide New & Update for customization
  - where:
      verb: Update|New
      subject: ConfigurationStore
    hide: true

  # Rename parameters to follow design guideline
  - where:
      subject: OperationNameAvailability
    set:
      subject: StoreNameAvailability
  - where:
      parameter-name: IdentityUserAssignedIdentity
    set:
      parameter-name: UserAssignedIdentity
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

  # rename enum
  - where:
      parameter-name: IdentityType
    set:
      completer:
        name: Managed Identity Type Completer
        description: Gets the list of type of managed identities available for creating/updating app configuration store.
        script: "'None', 'SystemAssigned', 'UserAssigned', 'SystemAssignedAndUserAssigned'"

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
```
