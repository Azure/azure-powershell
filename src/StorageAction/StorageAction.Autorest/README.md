<!-- region Generated -->
# Az.StorageAction
This directory contains the PowerShell module for the StorageAction service.

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
For information on how to develop for `Az.StorageAction`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: 8f196886782fc5b48b75322944dc60d1cafaf7fa
tag: package-2023-01-01
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/storageactions/resource-manager/readme.md
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-local-readme.md

try-require: 
  - $(repo)/specification/storageactions/resource-manager/readme.powershell.md

# The next three configurations are activated by default.
# identity-correction-for-post: true
# resourcegroup-append: true
# nested-object-to-string: true

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: StorageAction
subject-prefix: $(service-name)

directive:
#   # Following are common directives which are normally required in all the RPs
#   # 1. Remove the unexpanded parameter set
#   # 2. For New-* cmdlets, ViaIdentity is not required
#   # Following two directives are v4 specific
  - where:
      variant: ^(Create|Update|Preview)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentity.*$
    remove: true
  # Rename commands
  - where:
      subject: StorageTask
    set:
      subject: Task
  - where:
      verb: Invoke
      subject: PreviewStorageTaskAction
    set:
      subject: TaskPreviewAction
  - where:
      subject: StorageTaskAssignment
    set:
      subject: TaskAssignment
  - where:
      subject: StorageTasksReport
    set:
      subject: TasksReport
  # Add model
  - model-cmdlet:
    - model-name: StorageTaskOperation
      cmdlet-name: New-AzStorageActionTaskOperationObject
    - model-name: StorageTaskPreviewBlobProperties
      cmdlet-name: New-AzStorageActionTaskPreviewBlobPropertiesObject
    - model-name: StorageTaskPreviewKeyValueProperties
      cmdlet-name: New-AzStorageActionTaskPreviewKeyValuePropertiesObject
```
