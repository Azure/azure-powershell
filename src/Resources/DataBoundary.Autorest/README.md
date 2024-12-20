<!-- region Generated -->
# Az.DataBoundary
This directory contains the PowerShell module for the DataBoundary service.

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
For information on how to develop for `Az.DataBoundary`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
root-module-name: $(prefix).Resources
title: DataBoundary
module-version: 0.1.1

# pin the swagger version by using the commit id instead of branch name
commit: a6074b7654c388dec49c9969d0136cfeb03575c9
tag:  package-databoundaries-2024-08
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/resources/resource-manager/readme.md
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-local-readme.md

try-require: 
  - $(repo)/specification/resources/resource-manager/readme.powershell.md

directive:
# Following are common directives which are normally required in all the RPs
# 1. Remove the unexpanded parameter set
# 2. For New-* cmdlets, ViaIdentity is not required
# Following two directives are v4 specific
- where:
    variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
  remove: true
- where:
    variant: ^CreateViaIdentity.*$
  remove: true
- where:
    verb: Update
  remove: true

  ```
