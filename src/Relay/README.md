<!-- region Generated -->
# Az.Relay
This directory contains the PowerShell module for the Relay service.

---
## Status
[![Az.Relay](https://img.shields.io/powershellgallery/v/Az.Relay.svg?style=flat-square&label=Az.Relay "Az.Relay")](https://www.powershellgallery.com/packages/Az.Relay/)

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
For information on how to develop for `Az.Relay`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 591b17c5a50e7fc0ef09211197279e6d9f7ebc22
require:
  - $(this-folder)/../readme.azure.noprofile.md
  - $(repo)/specification/relay/resource-manager/readme.md

title: Relay

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true
inlining-threshold: 50

directive:
  # Remove cmdlet, Private link related resource should be ignored. 
  - where:
     subject: PrivateEndpointConnection|PrivateLinkResource
    remove: true
  - where:
      verb: Test
      subject: NamespaceNameAvailability
    set:
      subject: Name
  - where:
      subject: ^WcfRelay$
    set:
      subject-prefix: Wcf
      subject: Relay

  - where:
      subject: ^WcfRelayKey$
    set:
      subject-prefix: Wcf
      subject: RelayKey

  - where:
      subject: ^Namespace$
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true

  - where:
      subject: ^Namespace$
      variant: ^Update$|^UpdateViaIdentity$
    remove: true
  
  - where:
      subject: ^Namespace$
      parameter-name: PrivateEndpointConnection
    hide: true

  - where:
      model-name: RelayNamespace
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - Location
          - Status
          - SkuName
          - ServiceBusEndpoint
  
```
