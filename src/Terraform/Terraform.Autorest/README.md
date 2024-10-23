<!-- region Generated -->
# Az.Terraform
This directory contains the PowerShell module for the Terraform service.

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
For information on how to develop for `Az.Terraform`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: 46b386376ab0d53228a7f366d28e44bac8d592c3
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/terraform/resource-manager/readme.md

try-require: 
  - $(repo)/specification/xxx/resource-manager/readme.powershell.md

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: Terraform
subject-prefix: $(service-name)

# The next three configurations are exclusive to v3, and in v4, they are activated by default. If you are still using v3, please uncomment them.
# identity-correction-for-post: true
# resourcegroup-append: true
# nested-object-to-string: true

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
  
  # Remove the expanded cmdlet
  - where:
      variant: ExportExpanded
    remove: true
  
  - where:
      verb: Get
      subject: Operation(Statuses)?
    remove: true

  # Remove ` to workaround an issue
  - from: swagger-document
    where: $
    transform: return $.replace(/`/g, "")

  # Disable Inline on the Baseclass(Model)
  - no-inline:
    - BaseExportModel

  # Create Model Cmdlets for ChildClasses
  - model-cmdlet:
    - model-name: ExportQuery
    - model-name: ExportResource
    - model-name: ExportResourceGroup

  # Add preview message
  - where:
      verb: Export
      subjet: Terraform
    set:
      preview-announcement:
        preview-message: The Export Azure Terraform module is in preview.
        estimated-ga-date: 2025-10-01
```
