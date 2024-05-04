<!-- region Generated -->
# Az.SecurityInsights
This directory contains the PowerShell module for the SecurityInsights service.

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
  - $(this-folder)/../../readme.azure.noprofile.md
# lock the commit
commit: 59eb5a7f1d09d0be2b80b8497785ffa2d784b5b6

input-file:
  - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/AlertRules.json
  - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/AutomationRules.json
  - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/Bookmarks.json
  - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/Enrichment.json
  - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/Entities.json
  - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/EntityQueries.json
  - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/EntityQueryTemplates.json
  - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/Incidents.json
  - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/Metadata.json
  - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/OfficeConsents.json
  - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/OnboardingStates.json
  - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/Settings.json
  - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/SourceControls.json
  - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/ThreatIntelligence.json
  #- $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/Watchlists.json
  - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/dataConnectors.json
  - $(repo)/specification/securityinsights/resource-manager/Microsoft.SecurityInsights/preview/2021-09-01-preview/operations.json

module-version: 1.2.0
title: SecurityInsights
subject-prefix: Sentinel
  
inlining-threshold: 50

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

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
  #Remove Enrichment
  - where:
      subject: ^Enrichment$
      variant: ^GetViaIdenity$|^GetViaIdenity1$
    remove: true
  # Remove source control (requires OAUTH tokens)
  - where:
      subject: SourceControl
    remove: true
  #Custom Built Commands
  - where:
      verb: Invoke
      subject: DataConnectorsCheckRequirement
    hide: true
  - where:
      subject: ^AlertRule$|^DataConnector$|^EntityQuery$
      variant: ^Create$|^CreateExpanded$|^Update$|^UpdateExpanded$|^UpdateViaIdentity$|^UpdateViaIdentityExpanded$
    hide: true
  - where:
      verb: ^Update$|^Remove$
      subject: Setting
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
  # CCP
  - where:
      verb: ^Connect$|^Disconnect$
      subject: DataConnector
    hide: true
  # cmdlet review feedback
  - where:
      subject: Bookmark
      parameter-name: Created|^CreatedByObjectId&|^Updated$|^UpdatedByObjectId$
    hide: true
  - where:
      subject: DataConnector
      parameter-name: SQSURLs
    set:
      parameter-name: SQSURL
  - where:
      subject: DataConnector
      parameter-name: CommonDataServiceActivities
    set:
      parameter-name: CommonDataServiceActivity
  - where:
      verb: Invoke
      subject: DataConnectorsCheckRequirement
    set:
      verb: Test
  - where:
      verb: Invoke
      subject: DataConnectorsCheckRequirement
    set:
      subject: DataConnectorCheckRequirement
  - where:
      verb: Invoke
      subject: DataConnectorsCheckRequirement
      parameter-name: DataConnectorsCheckRequirement
    set:
      parameter-name: DataConnectorCheckRequirement
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
      subject: ^BookmarkRelation$|^IncidentRelation$
      parameter-name: RelationName
    set:
      default:
        script: '(New-Guid).Guid'
  # Hide Expand
  - where:
      verb: Expand
      subject: ^Bookmark$|^Entity$
    hide: true
  - where:
      verb: ^New$|^Update$|^Remove$
      subject: Metadata
    hide: true
  # Hide Source Control
  - where:
      verb: Get
      subject: SourceControlRepository
    hide: true
  # Hide UpdateViaId and Update
  - where:
      variant: ^Update$|^UpdateViaIdentity$
    hide: true
  # Remove the unexpanded parameter set
  - where:
      variant: ^Append$|^AppendViaIdentity$|^Connect$|^ConnectViaIdentity$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Expand$|^ExpandViaIdentity$|^ExpandViaIdentityExpanded$|^GetViaIdentityExpanded$|^PostViaIdentity$|^Query$|^QueryViaIdentity$|^QueriesViaIdentity$|^Replace$|^ReplaceViaIdentity$
    remove: true
  # fix Equals that conflicts with inhertied property
  - where:
      enum-name: AutomationRulePropertyConditionSupportedOperator
      enum-value-name: Equals
    set:
      enum-value-name: Equal
```
