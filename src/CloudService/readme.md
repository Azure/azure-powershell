<!-- region Generated -->
# Az.CloudService
This directory contains the PowerShell module for the CloudService service.

---
## Status
[![Az.CloudService](https://img.shields.io/powershellgallery/v/Az.CloudService.svg?style=flat-square&label=Az.CloudService "Az.CloudService")](https://www.powershellgallery.com/packages/Az.CloudService/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.8.1 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.CloudService`, see [how-to.md](how-to.md).
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
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(this-folder)/resources/CloudService.json
  - $(this-folder)/resources/LoadBalancer.json

title: CloudService
module-version: 0.1.0

identity-correction-for-post: true

directive:
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^Reimage$|^Reimage1$
    remove: true
  - where:
      subject: ^CloudService$
      verb: Set
    set:
      verb: Update
  - where:
      subject: ^CloudServiceUpdateDomain$
      verb: Get
    remove: true
  # - where:
  #     subject: ^CloudServiceUpdateDomain$
  #     verb: Set
  #   set:
  #     subject: ^CloudServiceDomain
  - where:
      subject: ^CloudService$|^CloudServiceInstanceView$|^CloudServiceRoleInstance$|^CloudServiceRoleInstanceView$
      verb: Get
    hide: true
  - where:
      subject: ^CloudServiceRoleInstance$|^CloudService$|^CloudServiceInstance$
      verb: Remove
    hide: true
  - where:
      subject: ^CloudService$|^CloudServiceRoleInstance$
      verb: Restart
    hide: true
  - where:
      subject: ^CloudServiceRoleInstance$|^CloudService$
      verb: Update
    hide: true
  - where:
      subject: ^RebuildCloudService$|^RebuildCloudServiceRoleInstance$
      verb: Invoke
    hide: true
  - where:
      subject: ^CloudServiceRole$
      verb: Get
    hide: true

  - where:
      subject: ^LoadBalancerProbe$|^LoadBalancerNetworkInterface$|^LoadBalancerOutboundRule$|^LoadBalancerLoadBalancingRule$|^LoadBalancerInboundNatRule$|^LoadBalancerFrontendIPConfiguration$|^LoadBalancerBackendAddressPool$|^InboundNatRule$|^LoadBalancer$|^LoadBalancerTag$
    remove: true
  - no-inline:  # choose ONE of these models to disable inlining
    - PublicIPAddressPropertiesFormat
    - IPConfiguration
    - IPConfigurationPropertiesFormat
    - PublicIPAddress
  - where:
      subject: ^LoadBalancerPublicIPAddress$
      verb: Switch
    hide: true
```
