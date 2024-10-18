<!-- region Generated -->
# Az.ComputeSchedule
This directory contains the PowerShell module for the ComputeSchedule service.

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
For information on how to develop for `Az.ComputeSchedule`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: 0f8b47b1c07039272118cc7e576a548408ba6273
tag: package-2024-08-15-preview
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/computeschedule/resource-manager/readme.md
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-local-readme.md

try-require: 
  - $(repo)/specification/computeschedule/resource-manager/readme.powershell.md

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: ComputeSchedule
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
      variant: ^(Create|Update|Invoke|Execute|Submit)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentity.*$
    remove: true
  # Follow directive is v3 specific. If you are using v3, uncomment following directive and comments out two directives above
  #- where:
  #    variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
  #  remove: true

  - where:
      subject: ScheduledAction
      variant: ^(Get)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true

# Rename cmdlets to expose endpoints
  - where:
      verb: Get
      subject: ScheduledAction
      variant: GetExpanded
    set:
      subject: OperationsErrors

  - where:
      verb: Get
      subject: ScheduledAction
      variant: GetExpanded1
    set:
      subject: OperationsStatus

  - where:
      verb: Invoke
      subject: ExecuteScheduledAction
      variant: ExecuteExpanded
    set:
      subject: ExecuteDeallocate

  - where:
      verb: Invoke
      subject: ExecuteScheduledAction
      variant: ExecuteExpanded1
    set:
      subject: ExecuteHibernate

  - where:
      verb: Invoke
      subject: ExecuteScheduledAction
      variant: ExecuteExpanded2
    set:
      subject: ExecuteStart

  - where:
      verb: Submit
      subject: ScheduledAction
      variant: SubmitExpanded
    set:
      verb: Invoke
      subject: SubmitDeallocate

  - where:
      verb: Submit
      subject: ScheduledAction
      variant: SubmitExpanded1
    set:
      verb: Invoke
      subject: SubmitHibernate

  - where:
      verb: Submit
      subject: ScheduledAction
      variant: SubmitExpanded2
    set:
      verb: Invoke
      subject: SubmitStart

  - where:
      verb: Stop
      subject: ScheduledAction
      variant: CancelExpanded
    set:
      subject: Operations

# Hide initial cmdlets generated with all endpoints grouped
  - where:
      verb: Invoke
      subject: ExecuteScheduledAction
    hide: true

  - where:
      verb: Submit
      subject: ScheduledAction
    hide: true

  - where:
      verb: Stop
      subject: ScheduledAction
    hide: true

  - where:
      verb: Get
      subject: ScheduledAction
    hide: true

# rename parameters
  - where:
      verb: Invoke
      subject: ^(Submit|Execute)(.*)
      parameter-name: RetryPolicyRetryCount
    set:
      parameter-name: RetryCount

  - where:
      verb: Invoke
      subject: ^(Submit|Execute)(.*)
      parameter-name: RetryPolicyRetryWindowInMinute
    set:
      parameter-name: RetryWindowInMinutes

  - where:
      verb: Invoke
      subject: ^(Submit)(.*)
      parameter-name: ScheduleDeadLine
    set:
      parameter-name: Deadline

  - where:
      verb: Invoke
      subject: ^(Submit)(.*)
      parameter-name: ScheduleDeadlineType
    set:
      parameter-name: DeadlineType

  - where:
      verb: Invoke
      subject: ^(Submit)(.*)
      parameter-name: ScheduleTimeZone
    set:
      parameter-name: TimeZone

# Hide OptimizationPreference paramater
  - where:
      verb: Invoke
      subject: ^(Submit|Execute)(.*)
      parameter-name: ExecutionParameterOptimizationPreference
    hide: true

  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
```
