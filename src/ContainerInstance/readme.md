<!-- region Generated -->
# Az.ContainerInstance
This directory contains the PowerShell module for the ContainerInstance service.

---
## Status
[![Az.ContainerInstance](https://img.shields.io/powershellgallery/v/Az.ContainerInstance.svg?style=flat-square&label=Az.ContainerInstance "Az.ContainerInstance")](https://www.powershellgallery.com/packages/Az.ContainerInstance/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.2.3 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.ContainerInstance`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
Branch: 2601b21eccaab01da2feb65d232ab6c3cb9c1c45
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/containerinstance/resource-manager/Microsoft.ContainerInstance/stable/2021-03-01/containerInstance.json 
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger 

# For new RP, the version is 0.1.0
module-version: 1.0.3
# Normally, title is the service name
title: ContainerInstance
subject-prefix: $(service-name)
identity-correction-for-post: true
nested-object-to-string: true

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correctiEXon-for-post: true

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^Execute$|^ExecuteViaIdentity$|^ExecuteViaIdentityExpanded$|^AttachViaIdentity$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  - where:
      subject: ContainerGroup
    set:
      subject-prefix: ""
  - where:
      subject: ContainerLog
    set:
      subject: Log
  - where:
      subject: Container
    set:
      subject: Output    
  - where:
      subject: ExecuteContainerCommand
    set:
      subject: Command
  - where:
      subject: (^Location)(.*) 
    set:
      subject: $2
  - where:
      verb: New
      subject: ContainerGroup
    hide: true
  - where:
      verb: Invoke
      subject: Command
    hide: true
  - where:
      verb: Restart
    hide: true
  - from: swagger-document
    where: $
    transform: return $.replace(/resourcegroups/, "resourceGroups")
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerInstance/containerGroups/{containerGroupName}/start"].post.responses
    transform: >-
      return {
          "202": {
            "description": "Started - the container group is starting."
          },
          "204": {
            "description": "No content"
          },
          "default": {
            "description": "Error response describing why the operation failed.",
            "schema": {
              "$ref": "#/definitions/CloudError"
            }
          }
        }
```
