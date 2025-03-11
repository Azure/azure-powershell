<!-- region Generated -->
# Az.DynatraceObservability
This directory contains the PowerShell module for the DynatraceObservability service.

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
For information on how to develop for `Az.DynatraceObservability`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 099640c73c1af7f9410f184d204807f9d0da2edb
tag: package-2023-04-27
require:
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/dynatrace/resource-manager/readme.md

try-require: 
  - $(repo)/specification/dynatrace/resource-manager/readme.powershell.md

title: DynatraceObservability
subject-prefix: Dynatrace

inlining-threshold: 100
resourcegroup-append: true
nested-object-to-string: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

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
      subject: MonitoredResource
  # remove cmdlet
  # unsupport on server
  - where:
      subject: ^MonitorAccountCredential$
    remove: true
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

  #  only name allowed for a rule set is 'default'
  - where:
      verb: Get
      subject: ^MonitorTagRule$|^MonitorSSOConfig$
      variant: ^List$
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
      parameter-name: UserAssignedIdentity

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

  - where:
      verb: Get
      subject: MonitorSSODetail
      parameter-name: Confirm
    hide: true

#  only name allowed for a rule set is 'default'
  - where:
      verb: New|Get|Update|Remove
      subject: MonitorTagRule
      parameter-name: Name
    hide: true
    set:
      default:
        script: '"default"'

  - where:
      verb: New|Get|Update|Remove
      subject: MonitorSSOConfig
      parameter-name: Name
    hide: true
    set:
      default:
        script: '"default"'

  - where:
      model-name: TagRule
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - ProvisioningState
          - LogRuleSendAadLog
  - where:
      model-name: MonitorResource
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - ProvisioningState
          - Location
          - MonitoringStatus
          - SingleSignOnPropertyAadDomain

  - where:
      model-name: DynatraceSingleSignOnResource
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - ProvisioningState
          - SingleSignOnState
          - SingleSignOnUrl
  # - model-cmdlet:
    # - FilteringTag 
    # --> Generate cmdlet: New-AzDynatraceMonitorFilteringTagObject
  - from: GetAzDynatraceMonitorAppService_List.cs
    where: $
    transform: $ = $.replace(", SupportsShouldProcess = true" ,"");

  - from: GetAzDynatraceMonitoredResource_List.cs
    where: $
    transform: $ = $.replace(", SupportsShouldProcess = true" ,"");

  - from: GetAzDynatraceMonitorHost_List.cs
    where: $
    transform: $ = $.replace(", SupportsShouldProcess = true" ,"");

  - from: GetAzDynatraceMonitorLinkableEnv_ListExpanded.cs
    where: $
    transform: $ = $.replace(", SupportsShouldProcess = true" ,"");

  - from: GetAzDynatraceMonitorVMHostPayload_Get.cs
    where: $
    transform: $ = $.replace(", SupportsShouldProcess = true" ,"");

  - from: GetAzDynatraceMonitorSSODetail_GetExpanded.cs
    where: $
    transform: $ = $.replace(", SupportsShouldProcess = true" ,"");
```
