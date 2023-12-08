<!-- region Generated -->
# Az.Metric
This directory contains the PowerShell module for the Metric service.

---
## Status
[![Az.Metric](https://img.shields.io/powershellgallery/v/Az.Metric.svg?style=flat-square&label=Az.Metric "Az.Metric")](https://www.powershellgallery.com/packages/Az.Metric/)

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
commit: 21f5332f2dc7437d1446edf240e9a3d4c90c6431

input-file:
    - $(repo)/specification/monitor/data-plane/Microsoft.Insights/preview/2023-05-01-preview/metricBatch.json

root-module-name: $(prefix).Monitor
title: MetricData
module-version: 0.1.0
subject-prefix: ''

directive:
  - where:
      variant: ^(Batch)(?!.*?Expanded)
    remove: true
  - where:
      subject: BatchMetricsBatch
      verb: Invoke
    set:
      subject: MetricsBatch
      verb: Get
  - where:
      subject: MetricsBatch
      parameter-name: Metricname
    set:
      parameter-name: Name
      alias: MetricName
  - where:
      subject: MetricsBatch
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
