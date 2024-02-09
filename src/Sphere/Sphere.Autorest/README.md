<!-- region Generated -->
# Az.Sphere
This directory contains the PowerShell module for the Sphere service.

---
## Status
[![Az.Sphere](https://img.shields.io/powershellgallery/v/Az.Sphere.svg?style=flat-square&label=Az.Sphere "Az.Sphere")](https://www.powershellgallery.com/packages/Az.Sphere/)

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
  - from: swagger-document
    where: $.definitions.ImageProperties.properties.image
    transform: >-
      return {
          "type": "string",
          "format": "byte",
          "description": "Image as a UTF-8 encoded base 64 string on image create. This field contains the image URI on image reads.",
          "x-ms-mutability": [
            "read",
            "create"
          ]
      }
  - where:
      variant: ^(Create|Update|Generate|Claim)(?!.*?Expanded)
    remove: true
  - where:
      variant: List
      subject: CatalogDeviceGroup
    hide: true
  - where:
      variant: ^(Retrieve)(?!.*?Expanded)
      subject: CertificateProof
    hide: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    hide: true
```
