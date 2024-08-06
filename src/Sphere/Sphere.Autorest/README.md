<!-- region Generated -->
# Az.Sphere
This directory contains the PowerShell module for the Sphere service.

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
For information on how to develop for `Az.Sphere`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: ebce1c690af6060f0e5a72d875edf752d41d5769
tag: package-2024-04-01
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/sphere/resource-manager/readme.md
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-local-readme.md

try-require: 
  - $(repo)/specification/sphere/resource-manager/readme.powershell.md

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: Sphere
subject-prefix: $(service-name)

directive:
  # Following are common directives which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required
  - where:
      variant: ^(Create|Update)(?!.*?Expanded|ViaJsonString|ViaJsonFilePath)
    remove: true
  - where:
      variant: ^CreateViaIdentity.*$
    remove: true
  # Remove unavailable feature
  - where:
      verb: Remove
      subject: ^Device$|Image|Deployment
    remove: true
  - where:
      verb: Update
      subject: Image|Deployment
    remove: true
  - where:
      verb: Get
      subject: CatalogDeployment
    remove: true
  # error 'The server responded with an unrecognized response', error message missing in default error response for post path
  - where:
      verb: Invoke
      subject: UploadCatalogImage
    remove: true
  - where:
      verb: Invoke
      subject: ClaimDeviceGroupDevice
    remove: true
  - where:
      verb: Invoke
      variant: ^Count(.*)
    set:
      variant: CountDevice$1
  # Remove unexpanded include json parameter set
  - where:
      variant: ^List(?!.*?Expanded)
      subject: CatalogDeviceGroup
    remove: true
  - where:
      variant: ^(Retrieve)(?!.*?Expanded)
      subject: CertificateProof
    remove: true
  - where:
      variant: ^Claim(?!.*?Expanded)
      subject: ClaimDeviceGroupDevice
    hide: true
  # New-AzSphereDeviceCapabilityImage remove unexpanded parameter set
  - where:
      variant: ^(Generate)(?!.*?(Expanded|JsonString|JsonFilePath))
      subject: DeviceCapabilityImage
    remove: true
  - where:
      variant: GenerateViaIdentityExpanded
      subject: DeviceCapabilityImage
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    hide: true
```
