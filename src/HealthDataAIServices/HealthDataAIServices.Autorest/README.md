### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: cde61328a54d392000b36882fec169fce5a983c1
tag: package-2024-02-28-preview
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/healthdataaiservices/resource-manager/readme.md
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-local-readme.md

try-require: 
  - $(repo)/specification/healthdataaiservices/resource-manager/readme.powershell.md

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: HealthDataAIServices
subject-prefix: Deid

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
  # Remove cmdlet for PrivateLink resource
  - where:
      subject: .*PrivateLink.*
    remove: true
  # Reset subject-prefix as AI as previous setting by subject-prefix tag converts AI to Ai
  - where:
      subject-prefix: Ai(.*)
    set: 
      subject-prefix: AI$1
  # Follow directive is v3 specific. If you are using v3, uncomment following directive and comments out two directives above
  #- where:
  #    variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
  #  remove: true

  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
```
