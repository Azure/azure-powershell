<!-- region Generated -->
# Az.NewRelic
This directory contains the PowerShell module for the NewRelic service.

---
## Status
[![Az.NewRelic](https://img.shields.io/powershellgallery/v/Az.NewRelic.svg?style=flat-square&label=Az.NewRelic "Az.NewRelic")](https://www.powershellgallery.com/packages/Az.NewRelic/)

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
For information on how to develop for `Az.NewRelic`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
branch: 6b992c049ed7d6a95465d5c0a2234fc54c87b9bf
tag: package-2022-07-01
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../readme.azure.noprofile.md
  - $(repo)/specification/newrelic/resource-manager/readme.md
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-local-readme.md

try-require: 
  - $(repo)/specification/newrelic/resource-manager/readme.powershell.md

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: NewRelic
subject-prefix: $(service-name)

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

directive:
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^Switch$|^SwitchViaIdentity$
    remove: true
  - where:
      subject: AppService|Host
      variant: ^List$
    remove: true
  - where:
      subject: MetricRule|MetricStatus
      variant: ^Get$|^GetViaIdentity$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  # do not support update monitor
  - where:
      subject: Monitor
      verb: update
    remove: true
  # rename parameters
  - where:
      subject: ^TagRule(.*)
    set:
      subject: MonitorTagRule
  - where:
      parameter-name: IdentityUserAssignedIdentity
    set:
      parameter-name: UserAssignedIdentity
  - where:
      model-name: AccountResource
    set:
      format-table:
        properties:
          - OrganizationId
          - AccountId
          - AccountName
          - Region
  - where:
      model-name: MonitoredResource
    set:
      format-table:
        properties:
          - ReasonForLogsStatus
          - ReasonForMetricsStatus
          - SendingLog
          - SendingMetric
  - where:
      model-name: PlanDataResource
    set:
      format-table:
        properties:
          - PlanDataUsageType
          - PlanDataBillingCycle
          - PlanDataPlanDetail
          - PlanDataEffectiveDate
          - OrgCreationSource
          - AccountCreationSource
  - where:
      model-name: OrganizationResource
    set:
      format-table:
        properties:
          - OrganizationId
          - OrganizationName
          - BillingSource
```
