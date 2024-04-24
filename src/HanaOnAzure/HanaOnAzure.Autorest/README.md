<!-- region Generated -->
# Az.HanaOnAzure
This directory contains the PowerShell module for the HanaOn service.

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
For information on how to develop for `Az.HanaOnAzure`, see [how-to.md](how-to.md).
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
commit: 5df8962f094d431b8f8e7cbe143e742d316e9141
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/hanaonazure/resource-manager/Microsoft.HanaOnAzure/preview/2020-02-07-preview/hanaonazure.json

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: HanaOnAzure
# Autorest will remove "Azure" in the generated module, resulting "Az.HanaOn"
# A work-around is to specify "service-name", which is of higher priority when calc the module name
service-name: HanaOnAzure
subject-prefix: SapMonitor

# If there are post APIs for some kinds of actions in the RP, you may need to
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Remove the set-* cmdlet, update-* is enough
  - where:
      verb: Set
      # But do not remove set-* from key vault, that is needed
      subject: ^SapMonitor$|^ProviderInstance$|^HanaInstance$
    remove: true
  # Remove commands of Hana instance, which need to be reconsidered
  - where:
      subject: HanaInstance
    remove: true
  # Rename some parameters to follow powershell convention
  - where:
      parameter-name: LogAnalyticsWorkspaceArmId
    set:
      parameter-name: LogAnalyticsWorkspaceResourceId
  - where:
      parameter-name: MonitorSubnet
    set:
      parameter-name: MonitorSubnetResourceId
  - where:
      parameter-name: PropertiesType
    set:
      parameter-name: ProviderType

  # Update some parameter description
  - where:
      parameter-name: MonitorSubnetResourceId
      subject: SapMonitor
    set:
      parameter-description: The subnet which the SAP monitor will be deployed in. It should be the same subnet of HANA database.

  # Make location required
  # Fixme: when service team makes the change, remove this line
  - from: swagger-document
    where: $.definitions.TrackedResource
    transform: $['required'] = ['location']
  # Hide New-*ProviderInstance for customization
  - where:
      verb: New
      subject: ProviderInstance
    hide: true

  # Table format
  - where:
      model-name: ProviderInstance
    set:
      format-table:
        properties:
          - Name
          - Type
        labels:
          Type: Provider Type
  - where:
      model-name: SapMonitor
    set:
      format-table:
        properties:
          - Name
          - Location
```

``` yaml
# HELPERS
# ManagedIdentity and KeyVault is required when creating provider instance
require:
  - $(this-folder)/../../helpers/ManagedIdentity/readme.noprofile.md
  - $(this-folder)/../../helpers/KeyVault/readme.noprofile.md

directive:
  #  remove unneeded cmdlets
  - where:
      subject: ^VaultDeleted$|^Vault$|^VaultNameAvailability$
    remove: true
  - where:
      subject: ^SystemAssignedIdentity$
    remove: true
```
