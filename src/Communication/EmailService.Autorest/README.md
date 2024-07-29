<!-- region Generated -->
# Az.EmailService
This directory contains the PowerShell module for the EmailService service.

---
## Status
[![Az.EmailService](https://img.shields.io/powershellgallery/v/Az.EmailService.svg?style=flat-square&label=Az.EmailService "Az.EmailService")](https://www.powershellgallery.com/packages/Az.EmailService/)

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
For information on how to develop for `Az.EmailService`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 663ea6835c33bca216b63f777227db6a459a06b3
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/communication/resource-manager/Microsoft.Communication/preview/2023-06-01-preview/EmailServices.json
  - $(repo)/specification/communication/resource-manager/Microsoft.Communication/preview/2023-06-01-preview/Domains.json
  - $(repo)/specification/communication/resource-manager/Microsoft.Communication/preview/2023-06-01-preview/SenderUsernames.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger 

root-module-name: $(prefix).Communication
# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: EmailService
subject-prefix: $(service-name)

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

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
  # Remove the GetEmailServiceVerifiedExchangeOnlineDomain cmdlet
  - where:
      verb: Get
      subject: EmailServiceVerifiedExchangeOnlineDomain
    remove: true
  # set the location default value to global
  - where:
      parameter-name: Location
    set:     
      default:
        name: Location default
        description: Sets the Location default value to Global.
        script: '"global"'   
```
