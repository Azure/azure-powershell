<!-- region Generated -->
# Az.Autoscale
This directory contains the PowerShell module for the Autoscale service.

---
## Status
[![Az.Autoscale](https://img.shields.io/powershellgallery/v/Az.Autoscale.svg?style=flat-square&label=Az.Autoscale "Az.Autoscale")](https://www.powershellgallery.com/packages/Az.Autoscale/)

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
For information on how to develop for `Az.Autoscale`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - https://github.com/Azure/azure-rest-api-specs/blob/9ae616c4a5447e9cae43752b68f089bff2e46398/specification/monitor/resource-manager/Microsoft.Insights/stable/2022-10-01/autoscale_API.json

root-module-name: $(prefix).Monitor
title: Autoscale
module-version: 0.1.0
subject-prefix: Autoscale
namespace: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale
nested-object-to-string: true

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      verb: Set
    remove: true
  - where:
      subject: (^Autoscale$)(.*)
    set:
      subject-prefix: ""
  - where:
      verb: Update
      subject: AutoscaleSetting
    hide: true
  # Rename 'Equals'
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('public static Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Support.ComparisonOperationType Equals = @"Equals";', 'public static Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Support.ComparisonOperationType Equal = @"Equals";');

  - from: source-file-csharp
    where: $
    transform: $ = $.replace('public static Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Support.ScaleRuleMetricDimensionOperationType Equals = @"Equals";', 'public static Microsoft.Azure.PowerShell.Cmdlets.Monitor.Autoscale.Support.ScaleRuleMetricDimensionOperationType Equal = @"Equals";');

  - model-cmdlet:
    - AutoscaleProfile
    - ScaleRule
    - AutoscaleNotification
    - WebhookNotification
    - ScaleRuleMetricDimension
```
