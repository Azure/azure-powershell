<!-- region Generated -->
# Az.NetworkCloud
This directory contains the PowerShell module for the NetworkCloud service.

---
## Status
[![Az.NetworkCloud](https://img.shields.io/powershellgallery/v/Az.NetworkCloud.svg?style=flat-square&label=Az.NetworkCloud "Az.NetworkCloud")](https://www.powershellgallery.com/packages/Az.NetworkCloud/)

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
For information on how to develop for `Az.NetworkCloud`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
branch: 71bfad87c2ab626149c0d1d543a8f0bb6414c754
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../readme.azure.noprofile.md
  - $(repo)/specification/networkcloud/resource-manager/readme.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/networkcloud/resource-manager/Microsoft.NetworkCloud/preview/2022-12-12-preview/networkcloud.json

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: NetworkCloud
service-name: NetworkCloud
subject-prefix: NetworkCloud

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

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
  - from: networkcloud.json
    where: $.paths..responses.202
    transform: delete $.headers
  - from: networkcloud.json
    where: $.paths..responses.201
```

Step 4. In Azure PowerShell, execute AutoRest in the module folder to generate the code.

Step 5. In Azure PowerShell, execute build-module.ps1 build module in the module folder.

Example: (NetworkCloud module)
Step 1. Define the README.md file in the following path, and fill in the content as follows https://github.com/Azure/azure-powershell/blob/main/src/NetworkCloud/README.md

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
branch: 71bfad87c2ab626149c0d1d543a8f0bb6414c754
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../readme.azure.noprofile.md
  - $(repo)/specification/networkcloud/resource-manager/readme.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/networkcloud/resource-manager/Microsoft.NetworkCloud/preview/2022-12-12-preview/networkcloud.json

# try-require: 
#   - $(repo)/specification/NetworkCloud/resource-manager/readme.powershell.md
```
