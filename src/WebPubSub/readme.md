<!-- region Generated -->
# Az.WebPubSub
This directory contains the PowerShell module for the WebPubSub service.

---
## Status
[![Az.WebPubSub](https://img.shields.io/powershellgallery/v/Az.WebPubSub.svg?style=flat-square&label=Az.WebPubSub "Az.WebPubSub")](https://www.powershellgallery.com/packages/Az.WebPubSub/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.2.3 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.WebPubSub`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../readme.azure.noprofile.md
sanitize-names: true
input-file:
# You need to specify your swagger files here.
  # - $(repo)/specification/webpubsub/resource-manager/Microsoft.SignalRService/preview/2021-06-01-preview/webpubsub.json
  - $(this-folder)/../webpubsub-stable.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: WebPubSub
subject-prefix: ''

# If there are post APIs for some kinds of actions in the RP, you may need to
# uncomment following line to support viaIdentity for these post APIs
identity-correction-for-post: true

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
  - select: command
    where:
      verb: Get
      subject: Usage
    set:
      subject-prefix: WebPubSub
  - where:
      verb: New
      subject: WebPubSub
    hide: true
  # location cannot be updated
  - where:
      verb: Update
      subject: WebPubSub
      parameter-name: Location
    hide: true
  # format output
  - where:
      model-name: WebPubSubResource
    set:
      format-table:
        properties:
          - Name
          - Location
          - SkuName
  # rename parameters
  - where:
      parameter-name: IdentityUserAssignedIdentity
    set:
      parameter-name: UserAssignedIdentity
  - where:
      parameter-name: TlClientCertEnabled
    set:
      parameter-name: EnableTlsClientCert
  - where:
      parameter-name: NetworkAcLPrivateEndpoint
    set:
      parameter-name: PrivateEndpoint
  - where:
      parameter-name: LiveTraceConfigurationEnabled
    set:
      parameter-name: LiveTraceEnabled
  - where:
      parameter-name: LiveTraceConfigurationCategory
    set:
      parameter-name: LiveTraceCategory
  - where:
      parameter-name: ResourceLogConfigurationCategory
    set:
      parameter-name: ResourceLogCategory
  # rename model properties, usually is a mapping of the previous section
  - where:
      model-name: WebPubSubResource
      property-name: IdentityUserAssignedIdentity
    set:
      property-name: UserAssignedIdentity
  - where:
      model-name: WebPubSubResource
      property-name: TlClientCertEnabled
    set:
      property-name: EnableTlsClientCert
  - where:
      model-name: WebPubSubResource
      property-name: NetworkAcLPrivateEndpoint
    set:
      property-name: PrivateEndpoint
  - where:
      model-name: WebPubSubResource
      property-name: LiveTraceConfigurationEnabled
    set:
      property-name: LiveTraceEnabled
  - where:
      model-name: WebPubSubResource
      property-name: LiveTraceConfigurationCategory
    set:
      property-name: LiveTraceCategory
  - where:
      model-name: WebPubSubResource
      property-name: ResourceLogConfigurationCategory
    set:
      property-name: ResourceLogCategory
  # remove the subject before the 'Name' when multiple *Name parameter exist
  - where:
      subject: WebPubSubEventHandler
      parameter-name: EventHandlerName
    set:
      parameter-name: Name
  - where:
      subject: WebPubSubHub
      parameter-name: HubName
    set:
      parameter-name: Name
  - where:
      subject: WebPubSubPrivateEndpointConnection
      parameter-name: PrivateEndpointConnectionName
    set:
      parameter-name: Name
  - where:
      subject: WebPubSubSharedPrivateLinkResource
      parameter-name: SharedPrivateLinkResourceName
    set:
      parameter-name: Name
```
