<!-- region Generated -->
# Az.Metricdata
This directory contains the PowerShell module for the Metricdata service.

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
For information on how to develop for `Az.Metricdata`, see [how-to.md](how-to.md).
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

root-module-name: $(prefix).Monitor
title: Metricdata
module-version: 0.1.0
subject-prefix: ""
namespace: Microsoft.Azure.PowerShell.Cmdlets.Metric

directive:
  - where:
      subject: BatchMetricsBatch
      verb: Invoke
    set:
      verb: Get
      subject: MetricsBatch
  - where:
      subject: MetricsBatch
      variant: ^(Batch)(?!.*?Expanded)
    remove: true
  # Case Sensitive
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
