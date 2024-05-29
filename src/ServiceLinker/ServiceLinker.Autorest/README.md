<!-- region Generated -->
# Az.ServiceLinker
This directory contains the PowerShell module for the ServiceLinker service.

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
For information on how to develop for `Az.ServiceLinker`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: e7bf3adfa2d5e5cdbb804eec35279501794f461c
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/servicelinker/resource-manager/Microsoft.ServiceLinker/preview/2022-11-01-preview/servicelinker.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
  # - $(this-folder)/../APISpecs/servicelinker/resource-manager/Microsoft.ServiceLinker/stable/2022-05-01/servicelinker.json

# For new RP, the version is 0.1.0
module-version: 0.1.1
# Normally, title is the service name
title: ServiceLinker
# subject-prefix: "ServiceLinker"

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
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  - where:
      subject: ConnectorDryrun|Connector|ConnectorConfiguration
    remove: true
  - where:
      verb: New|Update
      parameter-name: (.*)DeleteOrUpdateBehavior$
    hide: true
  - from: swagger-document
    where: 
      - $.paths["/{resourceUri}/providers/Microsoft.ServiceLinker/linkers/{linkerName}"].put.parameters
      - $.paths["/{resourceUri}/providers/Microsoft.ServiceLinker/linkers/{linkerName}"].patch.parameters
    transform: >-
      $[4] = {
            "name": "x-ms-serviceconnector-user-token",
            "type": "string",
            "in": "header"
          }
  - no-inline:
    - TargetServiceBase
    - AuthInfoBase
    - SecretInfoBase
    - AzureResourcePropertiesBase
  # - model-cmdlet:
  #   - AzureResource
  #   - AzureKeyVaultProperties
  #   - ConfluentBootstrapServer
  #   - ConfluentSchemaRegistry
  #   - SecretAuthInfo
  #   - UserAssignedIdentityAuthInfo
  #   - SystemAssignedIdentityAuthInfo
  #   - ServicePrincipalSecretAuthInfo
  #   - ValueSecretInfo
  #   - KeyVaultSecretReferenceSecretInfo
  #   - KeyVaultSecretUriSecretInfo
  - where:
      verb: New
      parameter-name: Name
    set:
      default:
        script: '"connect_"+(-join ((65..90) + (97..122) | Get-Random -Count 5 | % {[char]$_}))'
  - select: command
    where:
      subject: Linker|LinkerConfiguration
    hide: true
  - where:
      verb: New
      parameter-name: ClientType
    set:
      default: 
        script: '"none"'
```
