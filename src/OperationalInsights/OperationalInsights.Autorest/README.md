<!-- region Generated -->
# Az.OperationalInsights
This directory contains the PowerShell module for the OperationalInsights service.

---
## Status
[![Az.OperationalInsights](https://img.shields.io/powershellgallery/v/Az.OperationalInsights.svg?style=flat-square&label=Az.OperationalInsights "Az.OperationalInsights")](https://www.powershellgallery.com/packages/Az.OperationalInsights/)

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
For information on how to develop for `Az.OperationalInsights`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 11126e93093e14fa30fd2bf314cc3992a6b1c4f1 
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/operationalinsights/resource-manager/Microsoft.OperationalInsights/preview/2021-12-01-preview/Operations.json
  - $(repo)/specification/operationalinsights/resource-manager/Microsoft.OperationalInsights/preview/2021-12-01-preview/Tables.json
  - $(repo)/specification/operationalinsights/resource-manager/Microsoft.OperationalInsights/preview/2021-12-01-preview/Workspaces.json

title: OperationalInsights
module-version: 0.1.0
subject-prefix: $(service-name)

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

directive:
  # Autorest only support enum for type string.
  - from: swagger-document
    where: $.definitions.WorkspaceSku.properties.capacityReservationLevel
    transform: >-
      return {
          "type": "integer",
          "format": "int32",
          "description": "The capacity reservation level in GB for this workspace, when CapacityReservation sku is selected.",
          "enum": [
            100,
            200,
            300,
            400,
            500,
            1000,
            2000,
            5000
          ]
        }	
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true

  - where: 
      verb: New|Update
      subject: Workspace
      parameter-name: SkuName
    set:
      parameter-name: Sku
	  
  - where: 
      verb: New|Update
      subject: Table
      parameter-name: RestoredLogsStartRestoreTime
    hide: true 
	
  - where: 
      verb: New|Update
      subject: Table
      parameter-name: RestoredLogsEndRestoreTime
    hide: true 
	
  - where: 
      verb: New|Update
      subject: Table
      parameter-name: SearchResultsLimit
    hide: true 

  - where: 
      verb: New|Update
      subject: Table
      parameter-name: SearchResultsDescription
    hide: true 
	
  - where: 
      verb: New|Update
      subject: Table
      parameter-name: SearchResultsStartSearchTime
    hide: true 
	
  - where: 
      verb: New|Update
      subject: Table
      parameter-name: SearchResultsEndSearchTime
    hide: true 
	
  - where: 
      verb: New|Update
      subject: Table
      parameter-name: SearchResultsQuery
    hide: true 
	
  - where: 
      verb: New|Update
      subject: Workspace
      parameter-name: SkuCapacityReservationLevel
    set:
      parameter-name: SkuCapacity
 
  - where: 
      verb: New|Update
      subject: Workspace
      parameter-name: WorkspaceCappingDailyQuotaGb
    set:
      parameter-name: DailyQuotaGb

  - where: 
      verb: Remove
      subject: Workspace
      parameter-name: Force
    set:
      parameter-name: ForceDelete
	  
   - where:
      verb: Update
      subject: Workspace
    set:
      alias:
        - Set-AzOperationalInsightsWorkspace
        
  # For memory object that generate cmdlet.  
  #- model-cmdlet:
    # - Column # Successfull generated after hide it for custom.
```
