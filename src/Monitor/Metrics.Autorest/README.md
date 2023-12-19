<!-- region Generated -->
# Az.Metrics
This directory contains the PowerShell module for the Metrics service.

---
## Status
[![Az.Metrics](https://img.shields.io/powershellgallery/v/Az.Metrics.svg?style=flat-square&label=Az.Metrics "Az.Metrics")](https://www.powershellgallery.com/packages/Az.Metrics/)

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
For information on how to develop for `Az.Metrics`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
# pin the swagger version by using the commit id instead of branch name
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
commit: 0373f0edc4414fd402603fac51d0df93f1f70507

input-file:
    - $(repo)/specification/monitor/data-plane/Microsoft.Insights/stable/2023-10-01/metricBatch.json
    - $(repo)/specification/monitor/resource-manager/Microsoft.Insights/stable/2023-10-01/metricDefinitions_API.json
    - $(repo)/specification/monitor/resource-manager/Microsoft.Insights/stable/2023-10-01/metrics_API.json

root-module-name: $(prefix).Monitor
title: Metrics
module-name: Az.Metrics
module-version: 0.1.0
subject-prefix: Metrics

directive:
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
  # remove non post variant
  - remove-operation: Metrics_ListAtSubscriptionScope
  - where:
      subject: Metric
      variant: ^List$|ListViaJsonFilePath|ListViaJsonString
    remove: true
  # rollupby and orderby rename
  - where:
      subject: Metric
      parameter-name: rollUpBy
    set:
      parameter-name: Rollupby
  - where:
      subject: Metric
      parameter-name: orderBy
    set:
      parameter-name: Orderby
  - where:
      subject: MetricsBatch
      variant: ^(Batch)(?!.*?Expanded)
    remove: true
  - where:
      subject: MetricsBatch
      verb: Invoke
    set:
      verb: Get
  - where:
      parameter-name: Metricname
    set:
      parameter-name: Name
      alias: MetricName
  - where:
      parameter-name: Metricnamespace
    set:
      parameter-name: Namespace
      alias: MetricNamespace
  - where:
      subject: MetricsBatch
      parameter-name: Starttime
    set:
      parameter-name: StartTime
  - where:
      subject: MetricsBatch
      parameter-name: Endtime
    set:
      parameter-name: EndTime
  - where:
      subject: MetricsBatch
      parameter-name: Resourceid
    set:
      parameter-name: ResourceId
