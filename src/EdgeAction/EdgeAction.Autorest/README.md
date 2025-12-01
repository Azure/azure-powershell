<!-- region Generated -->
# Az.EdgeAction
This directory contains the PowerShell module for the EdgeAction service.

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
For information on how to develop for `Az.EdgeAction`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
# pin the swagger version by using the commit id instead of branch name
commit: 0eb1d5347c69e4138cde6d74e58a98eedcd889b0
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/cdn/resource-manager/Microsoft.Cdn/EdgeActions/preview/2025-09-01-preview/openapi.json 

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: EdgeAction
subject-prefix: $(service-name)

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
identity-correction-for-post: true

resourcegroup-append: true
nested-object-to-string: true

directive:
  # Remove the unexpanded parameter set
  # For New-* cmdlets, ViaIdentity is not required
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^Patch$|^PatchViaIdentity$
    remove: true
  
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  
  # Fix SubscriptionId parameter type conflict - keep only single string variant
  - where:
      parameter-name: SubscriptionId
    set:
      parameter-name: SubscriptionId

  # Format table to exclude system metadata
  - where:
      model-name: .*
    set:
      format-table:
        exclude-properties:
          - SystemData
          - SystemDataCreatedAt
          - SystemDataCreatedBy
          - SystemDataCreatedByType
          - SystemDataLastModifiedAt
          - SystemDataLastModifiedBy
          - SystemDataLastModifiedByType

  # Hide DeployVersionCode to customize with file deployment
  - where:
      verb: Deploy
      subject: EdgeActionVersionCode
    hide: true
  
  # Remove array variant of SubscriptionId to fix parameter type conflict
  - where:
      parameter-name: SubscriptionId
    clear-alias: true
```
