<!-- region Generated -->
# Az.KubernetesRuntime
This directory contains the PowerShell module for the KubernetesRuntime service.

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
For information on how to develop for `Az.KubernetesRuntime`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: 2608e811fafd18657b224a0d59e1c3924a534adb
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
#   - (this-folder)/../../../../swagger-pr/specification/kubernetesruntime/resource-manager/readme.md
input-file:
  - $(repo)/specification/kubernetesruntime/resource-manager/Microsoft.KubernetesRuntime/stable/2024-03-01/kubernetesruntime.json
try-require: 
  - $(repo)/specification/kubernetesruntime/resource-manager/readme.powershell.md

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: KubernetesRuntime
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
  # Follow directive is v3 specific. If you are using v3, uncomment following directive and comments out two directives above
  #- where:
  #    variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
  #  remove: true

  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true

  - no-inline:
    - StorageClassTypeProperties

  - where:
      parameter-name: ResourceUri
    set:
      parameter-name: ArcConnectedClusterId
      alias: ResourceUri

  - model-cmdlet:
    - model-name: NativeStorageClassTypeProperties
    - model-name: RwxStorageClassTypeProperties
    - model-name: BlobStorageClassTypeProperties
    - model-name: NfsStorageClassTypeProperties
    - model-name: SmbStorageClassTypeProperties
    - model-name: AksArcDiskStorageClassTypeProperties
```
