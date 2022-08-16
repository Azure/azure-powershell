<!-- region Generated -->
# Az.DynatraceObservability
This directory contains the PowerShell module for the DynatraceObservability service.

---
## Status
[![Az.DynatraceObservability](https://img.shields.io/powershellgallery/v/Az.DynatraceObservability.svg?style=flat-square&label=Az.DynatraceObservability "Az.DynatraceObservability")](https://www.powershellgallery.com/packages/Az.DynatraceObservability/)

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
For information on how to develop for `Az.DynatraceObservability`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: fd4dd3abc8bf0cdaebdf74215d0dbe3ec705fe9c
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/dynatrace/resource-manager/Dynatrace.Observability/preview/2021-09-01-preview/dynatrace.json
title: DynatraceObservability
subject-prefix: Dynatrace

inlining-threshold: 100
resourcegroup-append: true
nested-object-to-string: true

directive:
  - where:
      verb: Set
    remove: true
  - where:
      variant: ^Create$|^CreateViaIdentityExpanded$|^CreateViaIdentity$|^Update$|^UpdateViaIdentity$
    remove: true
  
  # Rename subject
  - where:
      subject: ^MonitorAccountCredentials$
    set:
      subject: MonitorAccountCredential

  - where:
      subject: ^MonitorLinkableEnvironment$
    set:
      subject: MonitorLinkableEnv

  - where:
      subject: ^MonitorSsoDetail$
    set:
      subject: MonitorSSODetail

  - where:
      subject: ^SingleSignOn$
    set:
      subject: MonitorSSOConfig

  - where:
      subject: ^TagRule$
    set:
      subject: MonitorTagRule

  - where:
      subject: ^MonitorMonitoredResource$
    set:
      subject: MonitorResource

  # remove varinat
  - where:
      subject: ^MonitorSSODetail$
      variant: ^Get$|^GetViaIdentity$|^GetViaIdentityExpanded$
    remove: true

  - where:
      subject: ^MonitorLinkableEnv$
      variant: ^List$
    remove: true

  - where:
      subject: ^MonitorVMHostPayload$|^MonitorAccountCredential$
      variant: ^GetViaIdentity$
    remove: true

  # rename parameter
  - where:
      subject: Monitor
      parameter-name: AccountInfoAccountId
    set:
      parameter-name: AccountId

  - where:
      subject: Monitor
      parameter-name: AccountInfoRegionId
    set:
      parameter-name: AccountRegionId

  - where:
      subject: Monitor
      parameter-name: DynatraceEnvironmentPropertyUserId
    set:
      parameter-name: DynatraceEnvironmentUserId

  - where:
      subject: Monitor
      parameter-name: EnvironmentInfoEnvironmentId
    set:
      parameter-name: EnvironmentId

  - where:
      subject: Monitor
      parameter-name: EnvironmentInfoIngestionKey
    set:
      parameter-name: EnvironmentIngestionKey

  - where:
      subject: Monitor
      parameter-name: EnvironmentInfoLandingUrl
    set:
      parameter-name: EnvironmentLandingUrl

  - where:
      subject: Monitor
      parameter-name: EnvironmentInfoLogsIngestionEndpoint
    set:
      parameter-name: EnvironmentLogsIngestionEndpoint

  - where:
      subject: Monitor
      parameter-name: IdentityUserAssignedIdentity
    set:
      parameter-name: IdentityUserAssigned

  - where:
      subject: Monitor
      parameter-name: PlanDataBillingCycle
    set:
      parameter-name: PlanBillingCycle

  - where:
      subject: Monitor
      parameter-name: PlanDataEffectiveDate
    set:
      parameter-name: PlanEffectiveDate

  - where:
      subject: Monitor
      parameter-name: PlanDataPlanDetail
    set:
      parameter-name: PlanDetail

  - where:
      subject: Monitor
      parameter-name: PlanDataUsageType
    set:
      parameter-name: PlanUsageType

  - where:
      subject: Monitor
      parameter-name: SingleSignOnPropertyAadDomain
    set:
      parameter-name: SingleSignOnAadDomain

  - where:
      subject: Monitor
      parameter-name: SingleSignOnPropertyEnterpriseAppId
    set:
      parameter-name: SingleSignOnEnterpriseAppId

  - where:
      subject: Monitor
      parameter-name: SingleSignOnPropertySingleSignOnState
    set:
      parameter-name: SingleSignOnState

  - where:
      subject: Monitor
      parameter-name: SingleSignOnPropertySingleSignOnUrl
    set:
      parameter-name: SingleSignOnUrl

  - where:
      subject: Monitor
      parameter-name: UserInfo(.*)
    set:
      parameter-name: User$1

  - where:
      subject: Monitor
      parameter-name: ConfigurationName
    set:
      parameter-name: Name

  - where:
      subject: Monitor
      parameter-name: DynatraceEnvironmentUserId
    set:
      parameter-name: EnvironmentUserId

  - where:
      subject: ^MonitorLinkableEnv$|^MonitorMonitoredResource$
      parameter-name: MonitorName
    set:
      parameter-name: Name

  - where:
      subject: ^MonitorSSOConfig$
      parameter-name: ConfigurationName
    set:
      parameter-name: Name

  - where:
      subject: ^MonitorTagRule$
      parameter-name: RuleSetName
    set:
      parameter-name: Name

  # - model-cmdlet:
    # - FilteringTag 
    # --> Generate cmdlet: New-AzDynatraceMonitorFilteringTagObject
```
