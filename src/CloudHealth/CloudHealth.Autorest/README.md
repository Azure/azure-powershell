<!-- region Generated -->
# Az.CloudHealth
This directory contains the PowerShell module for the CloudHealth service.

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
For information on how to develop for `Az.CloudHealth`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: 801a60cdad2669e8f824fedfbabbfe7f7093b940
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-local-readme.md

# The cloudhealth spec readme (openapi-type: arm / rpaas) declares no PowerShell tag or
# swagger-to-sdk block, so inputs are resolved directly from the versioned swagger below.
try-require:
  - $(repo)/specification/cloudhealth/resource-manager/readme.powershell.md

input-file:
  - $(repo)/specification/cloudhealth/resource-manager/Microsoft.CloudHealth/CloudHealth/preview/2026-05-01-preview/cloudhealth.json

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: CloudHealth
subject-prefix: MonitorHealthModel
service-name: CloudHealth

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

  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
```
