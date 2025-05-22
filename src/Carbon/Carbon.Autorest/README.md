<!-- region Generated -->
# Az.Carbon
This directory contains the PowerShell module for the Carbon service.

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
For information on how to develop for `Az.Carbon`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration

> see https://aka.ms/autorest

```yaml
commit: 3429eaa6ae7e4743c1988917d90b4a4f351ad164
require:
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/carbon/resource-manager/readme.md
# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: Carbon
subject-prefix: $(service-name)

directive:
  # Following are common directives which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required
  # Following two directives are v4 specific
  - where:
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  # Remove the expanded and JsonFilePath parameter sets for Get-AzCarbonEmissionReport
  - where:
      variant: ^(Get)(.*?(Expanded|JsonFilePath|JsonString))
    remove: true

  # Enable detailed error logging
  - from: swagger-document
    where: $.paths
    debug: true
    transform: >
      $["x-ms-client-flatten"] = true

  # Change OperationIds
  - from: swagger-document
    where: $.paths["/providers/Microsoft.Carbon/carbonEmissionReports"].post.operationId
    debug: true
    transform: return "GetEmissionReports"
  - from: swagger-document
    where: $.paths["/providers/Microsoft.Carbon/queryCarbonEmissionDataAvailableDateRange"].post.operationId
    transform: return "GetEmissionDataAvailableDateRange"
  - where:
      verb: Get
    set:
      suppress-should-process: true

  # Table formatting
  - where:
      model-name: CarbonEmissionData
    set:
      suppress-format: true

# Create Model Cmdlets for QueryFilter ChildClasses
  - model-cmdlet:
     - model-name: ItemDetailsQueryFilter
     - model-name: TopItemsMonthlySummaryReportQueryFilter
     - model-name: TopItemsSummaryReportQueryFilter
     - model-name: MonthlySummaryReportQueryFilter
     - model-name: OverallSummaryReportQueryFilter
```
