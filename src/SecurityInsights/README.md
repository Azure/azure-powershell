<!-- region Generated -->
# Az.SecurityInsights
This directory contains the PowerShell module for the SecurityInsights service.

---
## Status
[![Az.SecurityInsights](https://img.shields.io/powershellgallery/v/Az.SecurityInsights.svg?style=flat-square&label=Az.SecurityInsights "Az.SecurityInsights")](https://www.powershellgallery.com/packages/Az.SecurityInsights/)

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
For information on how to develop for `Az.SecurityInsights`, see [how-to.md](how-to.md).
<!-- endregion -->

---
## Generation Requirements
Use of the beta version of `autorest.powershell` generator requires the following:
- [NodeJS LTS](https://nodejs.org) (10.15.x LTS preferred)
  - **Note**: It *will not work* with Node < 10.x. Using 11.x builds may cause issues as they may introduce instability or breaking changes.
> If you want an easy way to install and update Node, [NVS - Node Version Switcher](../nodejs/installing-via-nvs.md) or [NVM - Node Version Manager](../nodejs/installing-via-nvm.md) is recommended.
- [AutoRest](https://aka.ms/autorest) v3 beta <br>`npm install -g autorest@autorest`<br>&nbsp;
- PowerShell 6.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g pwsh`<br>&nbsp;
- .NET Core SDK 2.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g dotnet-sdk-2.2`<br>&nbsp;

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
  - $(this-folder)/../readme.azure.noprofile.md
# lock the commit
branch: 5bf60a6746bc03fbff78cc68595eb11f2f212d19
tag: package-2023-02

input-file:
  - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/stable/2023-02-01/AlertRules.json
  - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/stable/2023-02-01/AutomationRules.json
  - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/stable/2023-02-01/Bookmarks.json
  - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/stable/2023-02-01/DataConnectors.json
  - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/stable/2023-02-01/Incidents.json
  - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/stable/2023-02-01/Metadata.json
  - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/stable/2023-02-01/OnboardingStates.json
  - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/stable/2023-02-01/SecurityMLAnalyticsSettings.json
  - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/stable/2023-02-01/ThreatIntelligence.json
  # - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/stable/2023-02-01/Watchlists.json
  - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/stable/2023-02-01/operations.json

module-version: 1.2.0
title: SecurityInsights
subject-prefix: Sentinel

inlining-threshold: 50

use-extension:
  "@autorest/powershell": "4.x"
disable-getput: true
support-json-input: false

directive:
  # Customize
  - no-inline:
    - SecurityMlAnalyticsSetting
  - model-cmdlet:
    - model-name: PropertyConditionProperties
    - model-name: PropertyChangedConditionProperties
    - model-name: PropertyArrayChangedConditionProperties
    - model-name: AutomationRuleRunPlaybookAction
    - model-name: AutomationRuleModifyPropertiesAction
    - model-name: SecurityMlAnalyticsSettingsDataSource
  - from: SecurityMLAnalyticsSettings.json
    where: $.definitions.AnomalySecurityMLAnalyticsSettingsProperties.properties.customizableObservations
    transform: >-
      return {
          "description": "The customizable observations of the AnomalySecurityMLAnalyticsSettings.",
          "additionalProperties": true,
          "type": "object"
      }
  # Hide Operation API
  - where:
      subject: Operation
    hide: true
  # Fix Action to be AlertRuleAction
  - where: 
      subject: Action
    set:
      subject: AlertRuleAction
  # Change Sets to Updates to match current module
  - where:
      verb: Set
    set:
      verb: Update
  - where:
      subject: QueryThreatIntelligenceIndicator
    set:
      subject: ThreatIntelligenceIndicatorQuery
  # Fix Update ThreatIntelligenceIndicator
  - select: command
    where:
      verb: New
      subject: ThreatIntelligenceIndicator
      variant: CreateExpanded1
    set:
      verb: Update
      variant: UpdateExpanded
  - select: command
    where:
      verb: New
      subject: ThreatIntelligenceIndicator
      variant: CreateViaIdentity1
    set:
      verb: Update
      variant: UpdateViaIdentity
  - select: command
    where:
      verb: New
      subject: ThreatIntelligenceIndicator
      variant: CreateViaIdentityExpanded1
    set:
      verb: Update
      variant: UpdateViaIdentityExpanded
  - where:
      subject: ThreatIntelligenceIndicatorQuery
      variant: QueryViaIdentityExpanded
    remove: true
  - where:
      subject: ^AlertRule$|^DataConnector$
      variant: ^(Create|Update)(ViaIdentity)?(Workspace)?(Expanded)?$
    hide: true
  # Remove the unexpanded parameter set
  - where:
      variant: ^Query$|^QueryViaIdentity$
    remove: true
  - where:
      variant: ^(Create|Update)(?!.*?Expanded)
      subject: ^AlertRuleAction$|^AutomationRule$|^Bookmark$|^Incident$|^IncidentComment$|^IncidentRelation$|^OnboardingState$
    remove: true
  # Remove the expanded parameter set for SecurityMlAnalyticsSetting
  - where:
      subject: SecurityMlAnalyticsSetting
      variant: ^(Create|Update)(.*Expanded)$
    hide: true
  # Hide Etag as it isnt used
  - where:
      parameter-name: Etag
    hide: true
  # TI API not useful until API changes
  - where:
      verb: ^Add$|^New$|^Update$|^Remove$
      subject: ThreatIntelligenceIndicator
    hide: true
  - where:
      verb: ^Add$|^New$|^Update$|^Remove$
      subject: ThreatIntelligenceIndicatorTag
    hide: true
  # cmdlet review feedback
  - where:
      subject: Bookmark
      parameter-name: Created|^Updated$
    hide: true
  - where:
      verb: New
      subject: AlertRuleAction
      variant: Create
    hide: true
  - where:
      verb: New
      subject: ^AlertRuleAction$|^AutomationRule$|^Bookmark$|^Incident$|^IncidentComment$|
      parameter-name: Id
    set:
      default:
        script: '(New-Guid).Guid'
  - where:
      verb: New
      subject: ^IncidentRelation$
      parameter-name: RelationName
    set:
      default:
        script: '(New-Guid).Guid'
  - where:
      verb: New
      subject: ^AlertRule$
      parameter-name: RuleId
    set:
      default:
        script: '(New-Guid).Guid'
  - where:
      verb: ^New$|^Update$|^Remove$
      subject: Metadata
    hide: true
  # Rename Id for user expierence
  - where:
      subject: AlertRuleAction
      parameter-name: Id
    set:
      alias: ActionId
  - where:
      subject: AlertRuleTemplate
      parameter-name: Id
    set:
      alias: TemplateId
  - where:
      subject: AutomationRule
      parameter-name: Id
    set:
      alias: AutomationRuleId
  - where:
      subject: Bookmark
      parameter-name: Id
    set:
      alias: BookmarkId
  - where:
      subject: DataConnector
      parameter-name: Id
    set:
      alias: DataConnectorId
  - where:
      subject: Incident
      parameter-name: Id
    set:
      alias: IncidentId
  - where:
      subject: IncidentComment
      parameter-name: Id
    set:
      alias: IncidentCommentId
  # fix Equals that conflicts with inhertied property
  - where:
      enum-name: AutomationRulePropertyConditionSupportedOperator
      enum-value-name: Equals
    set:
      enum-value-name: Equal
```
