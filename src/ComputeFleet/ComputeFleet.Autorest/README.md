<!-- region Generated -->
# Az.ComputeFleet
This directory contains the PowerShell module for the ComputeFleet service.

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
For information on how to develop for `Az.ComputeFleet`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# lock the commit
commit: 366aaa13cdd218b9adac716680e49473673410c8

require:
  - $(this-folder)/../../readme.azure.noprofile.md
  - $(repo)/specification/azurefleet/resource-manager/readme.md
try-require:
  - $(repo)/specification/azurefleet/resource-manager/readme.powershell.md

module-version: 0.1.0
title: ComputeFleet
subject-prefix: $(service-name)

identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true
auto-switch-view: false

inlining-threshold: 50

use-extension: 
  "@autorest/powershell": "4.x"

directive:

  # Remove Create & Update Expanded/JsonFilePath/JsonString cmdlets
  # Replace Get-AzComputeFleet List with ListBySubscriptionId
  # Replace Get-AzComputeFleet List1 with ListByResourceGroup
  # Rename Get-AzComputeFleetVirtualMachineScaleSet with Get-AzComputeFleetVMSS
  # Add Alias FleetName to parameter Name
  # Remove Set-* cmdlets
  - where:
      variant: ^(Create|Update)(?=.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      subject: Fleet
      variant: ^List$
    set:
      variant: ListBySubscriptionId
  - where:
      subject: Fleet
      variant: ^List1$
    set:
      variant: ListByResourceGroup
  - where:
      verb: Get
      subject: FleetVirtualMachineScaleSet
    set:
      subject: FleetVMSS
  - where:
      parameter-name: Name
    set:
      alias: FleetName
  - where:
      verb: (Set|SetViaIdentity|SetExpanded|SetExpandedViaIdentity)
    remove: true
    
```
