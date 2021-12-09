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
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.2.3 or greater

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
input-file:
  - https://github.com/Azure/azure-rest-api-specs/tree/main/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/AlertRules.json
  - https://github.com/Azure/azure-rest-api-specs/tree/main/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/AutomationRules.json
  - https://github.com/Azure/azure-rest-api-specs/tree/main/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/Bookmarks.json
  - https://github.com/Azure/azure-rest-api-specs/tree/main/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/Enrichment.json
  - https://github.com/Azure/azure-rest-api-specs/tree/main/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/Entities.json
  - https://github.com/Azure/azure-rest-api-specs/tree/main/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/EntityQueries.json
  - https://github.com/Azure/azure-rest-api-specs/tree/main/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/EntityQueryTemplates.json
  - https://github.com/Azure/azure-rest-api-specs/tree/main/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/Incidents.json
  - https://github.com/Azure/azure-rest-api-specs/tree/main/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/Metadata.json
  - https://github.com/Azure/azure-rest-api-specs/tree/main/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/OfficeConsents.json
  - https://github.com/Azure/azure-rest-api-specs/tree/main/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/OnboardingStates.json
  - https://github.com/Azure/azure-rest-api-specs/tree/main/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/Settings.json
  - https://github.com/Azure/azure-rest-api-specs/tree/main/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/SourceControls.json
  - https://github.com/Azure/azure-rest-api-specs/tree/main/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/ThreatIntelligence.json
  #- https://github.com/Azure/azure-rest-api-specs/tree/main/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/Watchlists.json
  - https://github.com/Azure/azure-rest-api-specs/tree/main/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/dataConnectors.json
  - https://github.com/Azure/azure-rest-api-specs/tree/main/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/operations.json

module-version: 1.2.0
title: SecurityInsights
subject-prefix: Sentinel
  
inlining-threshold: 50

directive:
  # Fixes/overrides to swaggers
  # Fix to x-ms-enum when integer (https://github.com/Azure/autorest.powershell/issues/856)
  - from: dataConnectors.json
    where: $.definitions.Availability.properties.status
    transform: >-
      return {
          "description": "The connector Availability Status",
          "format": "int32",
          "type": "integer",
          "enum": [
            1
          ]
        }
  # Customize
  # Hide Operation API
  - where:
      subject: Operation
    hide: true
   # Hide OfficeConsent API
  - where:
      subject: OfficeConsent
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
  # fix subject name to encrichment
  - where:
      subject: DomainWhois
    set:
      subject: Enrichment
  - where:
      subject: IPGeodata
    set:
      subject: Enrichment
  # Shorten to just Setting
  - where:
      subject: ProductSetting
    set:
      subject: Setting
  # Fix subject Names
  - where:
      subject: EntitiesGetTimeline
    set:
      subject: EntityTimeline
  - where:
      subject: EntitiesRelation
    set:
      subject: EntityRelation
  - where:
      subject: QueryThreatIntelligenceIndicator
    set:
      subject: ThreatIntelligenceIndicatorQuery
  # Change invoke as this is more a Get operation
  - where:
      verb: Invoke
      subject: QueryEntity
    set:
      verb: Get
      subject: EntityActivity
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
  # Fix Entity Insights
  - where:
      subject: EntityInsight
      variant: ^Get$|^GetViaIdentity$
    remove: true
  # Fix Entity TimeLime
  - where:
      subject: EntityTimeline
      variant: List
    remove: true
  # add Aliases for user expierence
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
      subject: Entity
      parameter-name: Id
    set:
      alias: EntityId
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
  #remove Enrichment
  - where:
      subject: ^Enrichment$
      variant: ^GetViaIdenity$|^GetViaIdenity1$
    remove: true
  #remove Remove Setting as user would just update
  - where:
      subject: Setting
      variant: ^Delete$|^DeleteViaIdentity$
    remove: true
  # Remove source control create/update/delete (requires OAUTH tokens)
  - where:
      subject: SourceControl
      variant: ^Create$|^CreateExpanded$|^Delete$|^DeleteViaIdentity$
    remove: true
  #Custom Built Commands
  - where:
      verb: Invoke
      subject: DataConnectorsCheckRequirement
    hide: true
  - where:
      subject: ^AlertRule$|^DataConnector$|^EntityQuery$
      variant: ^Create$|^CreateExpanded$|^Update$|^UpdateExpanded$|^UpdateViaIdentityExpanded$
    hide: true
  - where:
      verb: Update
      subject: Setting
    hide: true
  # Hide Etag as it isnt used
  - where:
      parameter-name: Etag
    hide: true
  # Remove the unexpanded parameter set
  - where:
      variant: ^Append$|^AppendViaIdentity$|^Connect$|^ConnectViaIdentity$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Expand$|^ExpandViaIdentity$|^ExpandViaIdentityExpanded$|^GetViaIdentityExpanded$|^PostViaIdentity$|^Query$|^QueryViaIdentity$|^QueriesViaIdentity$|^Replace$|^ReplaceViaIdentity$|^UpdateViaIdentity$
    remove: true
  # fix Equals that conflicts with inhertied property
  - where:
      enum-name: AutomationRulePropertyConditionSupportedOperator
      enum-value-name: Equals
    set:
      enum-value-name: Equal
```
