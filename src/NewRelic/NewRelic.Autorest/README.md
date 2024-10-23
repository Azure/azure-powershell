<!-- region Generated -->
# Az.NewRelic
This directory contains the PowerShell module for the NewRelic service.

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
For information on how to develop for `Az.NewRelic`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
commit: 559f989d2b38bc80db762cfd277614583dddc3bb
tag: package-2024-01-01
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
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

# The next three configurations are exclusive to v3, and in v4, they are activated by default. If you are still using v3, please uncomment them.
# identity-correction-for-post: true
# resourcegroup-append: true
# nested-object-to-string: true

directive:
  - remove-operation: MonitoredSubscriptions_Update
  # Rename operation
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/NewRelic.Observability/monitors/{monitorName}/monitoredSubscriptions/{configurationName}"].put.operationId
    transform: >-
      return "MonitoredSubscriptions_CreateOrUpdate"
  # Delete body/email
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/NewRelic.Observability/monitors/{monitorName}/listConnectedPartnerResources"].post.parameters
    transform: >-
        return [
          {
            "$ref": "../../../../../common-types/resource-management/v3/types.json#/parameters/ApiVersionParameter"
          },
          {
            "$ref": "../../../../../common-types/resource-management/v3/types.json#/parameters/SubscriptionIdParameter"
          },
          {
            "$ref": "../../../../../common-types/resource-management/v3/types.json#/parameters/ResourceGroupNameParameter"
          },
          {
            "name": "monitorName",
            "in": "path",
            "required": true,
            "description": "Name of the Monitors resource",
            "pattern": "^.*$",
            "type": "string"
          }
        ]
  # Following are common directives which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required
  # Following two directives are v4 specific
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentity.*$
    remove: true
  - where:
      variant: ^Switch$|^SwitchViaIdentity$
    remove: true
  - where:
      subject: AppService|Host
      variant: ^List$
    remove: true
  - where:
      subject: MetricRule|MetricStatus
      variant: ^Get$|^GetViaIdentity$
    remove: true
  # duplicate with Get default config
  - where:
      subject: MonitoredSubscription
      variant: List
    remove: true
  # Custom create Monitor
  - where:
      subject: Monitor
      verb: New
    hide: true
  # Custom list linked resource
  - where:
      subject: MonitorLinkedResource
      parameter-name: MonitorName
    set:
      parameter-name: Name
  - where:
      subject: MonitorLinkedResource
    hide: true
  - where:
      subject: Monitor
      verb: Get
    hide: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  # do not support update monitor
  - where:
      subject: Monitor
      verb: update
    remove: true
  # create cmdlet
  - model-cmdlet:
    - model-name: MonitoredSubscription
    - model-name: FilteringTag
  # rename subjects
  - where:
      subject: TagRule
    set:
      subject: MonitorTagRule
  - where:
      subject: MonitorHost
    set:
      subject: MonitoredHost
  - where:
      subject: MonitorAppService
    set:
      subject: MonitoredAppService
  # customize the body property and parameter name
  # - from: source-file-csharp
  #   where: $
  #   transform: $ = $.replace('request.Content = null','request.Content = new global::System.Net.Http.StringContent(body, global::System.Text.Encoding.UTF8);');
  # - where:
  #     verb: Get
  #     subject: ConnectedPartnerResource
  #     variant: List
  #     parameter-name: body
  #   set:
  #     parameter-name: EmailAddress
  # Reset description
  - where:
      verb: Remove
      subject: MonitoredSubscription
    set:
      command-description: Deletes the subscriptions that are being monitored by the NewRelic monitor resource
  # Format setting
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
