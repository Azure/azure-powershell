<!-- region Generated -->
# Az.NetworkCloud
This directory contains the PowerShell module for the NetworkCloud service.

---
## Status
[![Az.NetworkCloud](https://img.shields.io/powershellgallery/v/Az.NetworkCloud.svg?style=flat-square&label=Az.NetworkCloud "Az.NetworkCloud")](https://www.powershellgallery.com/packages/Az.NetworkCloud/)

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
For information on how to develop for `Az.NetworkCloud`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
# the 2023-05-01-preview in a temp branch: 7a92098c9b3cf46ec9158ae91dc8c5cdf87b6c12
# the 2023-05-01 stable  in a temp branch: 7844ed528107240d0ce605d108d6b4bec3cc2f96
branch: 7a92098c9b3cf46ec9158ae91dc8c5cdf87b6c12
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../readme.azure.noprofile.md
  - $(repo)/specification/networkcloud/resource-manager/readme.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/networkcloud/resource-manager/Microsoft.NetworkCloud/preview/2023-05-01-preview/networkcloud.json

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: NetworkCloud
service-name: NetworkCloud
subject-prefix: NetworkCloud

# If there are post APIs for some kinds of actions in the RP, you may need to
# uncomment following line to support viaIdentity for these post APIs
identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  # Swagger has location/Azure-AsyncOperation headers defined in 201/202 response which actually leads to the errors while
  # generating the modules using `pwsh build-module.ps1`. The API review board rejected the change to remove it.
  # The directives below removes those headers on the fly when generating the code.
  - from: networkcloud.json
    where: $.paths..responses.202
    transform: delete $.headers
  - from: networkcloud.json
    where: $.paths..responses.201
  # This is a known issue related to singularizing. To workaround the issue, please rename the cmdlet by following https://github.com/Azure/autorest.powershell/blob/main/docs/directives.md#Cmdlet-Rename
  - where:
      verb: Get
      subject: CloudServiceNetwork
    set:
      subject: CloudServicesNetwork
  - where:
      verb: New
      subject: CloudServiceNetwork
    set:
      subject: CloudServicesNetwork
  - where:
      verb: Get
      subject: MetricConfiguration
    set:
      subject: MetricsConfiguration
  - where:
      verb: New
      subject: MetricConfiguration
    set:
      subject: MetricsConfiguration
  - where:
      verb: Get
      subject: KuberneteCluster
    set:
      subject: KubernetesCluster
  - where:
      verb: New
      subject: KuberneteCluster
    set:
      subject: KubernetesCluster
  - where:
      verb: Restart
      subject: KubernetesClusterNode
    set:
      subject: KubernetesClusterNode
