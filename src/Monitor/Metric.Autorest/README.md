<!-- region Generated -->
# Az.Metric
This directory contains the PowerShell module for the Metric service.

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
For information on how to develop for `Az.Metric`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest
```yaml
# pin the swagger version by using the commit id instead of branch name
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
commit: 62937afd6872cb4da67787bcc7866725db3366a5

input-file:
    - $(repo)/specification/monitor/resource-manager/Microsoft.Insights/stable/2023-10-01/metricDefinitions_API.json
    - $(repo)/specification/monitor/resource-manager/Microsoft.Insights/stable/2023-10-01/metrics_API.json

root-module-name: $(prefix).Monitor
title: Metric
module-name: Az.Metric
module-version: 0.1.0
subject-prefix: Metric

directive:
  # remove duplicate parameter
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/providers/Microsoft.Insights/metrics"].post.parameters
    transform: >-
      return [
          {
            "$ref": "../../../../../common-types/resource-management/v2/types.json#/parameters/SubscriptionIdParameter"
          },
          {
            "$ref": "../../../../../common-types/resource-management/v2/types.json#/parameters/ApiVersionParameter"
          },
          {
            "$ref": "../../../../common-types/v2/commonMonitoringTypes.json#/parameters/RegionParameter"
          },
          {
            "in": "body",
            "name": "body",
            "description": "Parameters serialized in the body",
            "schema": {
              "$ref": "#/definitions/SubscriptionScopeMetricsRequestBodyParameters"
            }
          }
      ]
  # remove variant: Metrics_ListAtSubscriptionScope and non-expanded Metrics_ListAtSubscriptionScopePost
  - where:
      subject: Metric
      variant: ^List$|^List1$
    remove: true
  # rollupby and orderby use Camel-Case, fix 'Sequence contains no matching element' error when building Metrics_ListAtSubscriptionScopePost
  - where:
      subject: Metric
      parameter-name: rollUpBy
    set:
      parameter-name: RollUpBy
  - where:
      subject: Metric
      parameter-name: orderBy
    set:
      parameter-name: OrderBy
  - where:
      parameter-name: Metricnamespace
    set:
      parameter-name: MetricNamespace
  - where:
      parameter-name: Metricname
    set:
      parameter-name: MetricName
  # Fix breaking change
  - where:
      parameter-name: ResourceUri
    set:
      alias: ResourceId
  - where:
      parameter-name: Filter
    set:
      alias: MetricFilter
  - where:
      parameter-name: Aggregation
    set:
      alias: AggregationType
  - where:
      parameter-name: Interval
    set:
      alias: TimeGrain
  # Customize cmdlets
  - where:
      subject: Metric
    hide: true
