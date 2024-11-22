# Overall
This directory contains management plane service clients of Az.Storage module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@autorest/powershell@4.x
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
isSdkGenerator: true
powershell: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
title: AnalysisServicesManagementClient

commit: b3b961c82028c83e2ef47e5d4884a3c089a68f0f
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/analysisservices/resource-manager/Microsoft.AnalysisServices/stable/2017-08-01/analysisservices.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Analysis

directive:
  - where:
      model-name: AnalysisServicesServer
      property-name: EnablePowerBiService
    set:
      property-name: EnablePowerBIService
  - where:
      model-name:  AnalysisServicesServer
      property-name: Ipv4FirewallSettings
    set:
      property-name: IpV4FirewallSettings
  - where:
      model-name: AnalysisServicesServerUpdateParameters
      property-name: Ipv4FirewallSettings
    set:
      property-name: IpV4FirewallSettings
  - where:
      model-name: Ipv4FirewallSettings
    set:
      model-name: IPv4FirewallSettings
  - where:
      model-name: IPv4FirewallSettings
      property-name: EnablePowerBiService
    set:
      property-name: EnablePowerBIService
```