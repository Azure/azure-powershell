<!-- region Generated -->
# Az.DesktopVirtualization
This directory contains the PowerShell module for the DesktopVirtualization service.

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
For information on how to develop for `Az.DesktopVirtualization`, see [how-to.md](how-to.md).
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
commit: 50175f111e9c899249e79eb082a75fb8a7aba0e2
require:
  - $(this-folder)/../../readme.azure.noprofile.md
sanitize-names: true
subject-prefix: 'Wvd'
input-file:
- $(repo)/specification/desktopvirtualization/resource-manager/Microsoft.DesktopVirtualization/stable/2023-09-05/desktopvirtualization.json

module-version: 2.1.0
title: DesktopVirtualizationClient
# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  - where:
      verb: New
      subject: HostPool
      parameter-name: RegistrationInfoRegistrationTokenOperation
    set:
      parameter-name: RegistrationTokenOperation
  - where:
      verb: New
      subject: HostPool
      parameter-name: RegistrationInfoExpirationTime
    set:
      parameter-name: ExpirationTime
  - where:
      parameter-name: SubscriptionId
    set:
      default:
        script: '(Get-AzContext).Subscription.Id'
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^Send$|^SendViaIdentity$
    remove: true
  - where:
      verb: Set
    remove: true
  - where:
      verb: Get
      subject: Operation
    remove: true
  - where:
      verb: Invoke
      subject: LevelApplicationGroupAssignment
    remove: true
  - where:
      verb: Get
      subject: ActiveApplication
    remove: true
  - where:      
      verb: Remove    
      subject: UserSession
      parameter-name: Force
    set:
      parameter-description: 'Specify to force userSession deletion.'
```
