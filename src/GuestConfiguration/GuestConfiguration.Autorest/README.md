<!-- region Generated -->
# Az.GuestConfiguration
This directory contains the PowerShell module for the GuestConfiguration service.

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
For information on how to develop for `Az.GuestConfiguration`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
commit: d5c524d7228920ac75e27efe2e4616d5e43f71b1
require:
  - $(this-folder)/../../readme.azure.noprofile.md
# lock the commit
input-file:
  - $(repo)/specification/guestconfiguration/resource-manager/Microsoft.GuestConfiguration/stable/2022-01-25/guestconfiguration.json
module-version: 0.10.8
title: GuestConfiguration
subject-prefix: $(service-name)
identity-correction-for-post: true 
nested-object-to-string: true
resourcegroup-append: true
# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^Create1$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true
  # GuestConfigurationAssignmentsVMSS_{Action} -> GuestConfigurationAssignments_{Action}ByVMSS
  - from: swagger-document
    where: $.paths..operationId
    transform: return $.replace(/^(GuestConfiguration)(.+)VMSS(_.+)/g, "$1$2$3ByVMSS")
  # GuestConfigurationHCRPAssignments_{Action} -> GuestConfigurationAssignments_{Action}ByHCRP
  # GuestConfigurationHCRPAssignmentReports_List -> GuestConfigurationAssignmentReports_ListByHCRP
  - from: swagger-document
    where: $.paths..operationId
    transform: return $.replace(/^(GuestConfiguration)HCRP(.+)(_.+)/g, "$1$2$3ByHCRP")
  # GuestConfigurationAssignments_RGList -> GuestConfigurationAssignments_ListByRg
  # GuestConfigurationAssignments_SubscriptionList -> GuestConfigurationAssignments_ListBySubscription
  - from: swagger-document
    where: $.paths..operationId
    transform: return $.replace(/^(GuestConfigurationAssignments_)(.+)(List)$/, "$1$3By$2")
  # Remove all get/create/delete ViaIdentity operations
  - where:
      variant: ^GetViaIdentity.*|^CreateViaIdentity.*|^DeleteViaIdentity.*
    remove: true
  # Hide Remove-AzGuestConfigurationAssignment to customize InputObject case
  - where:
      verb: Remove
      subject: GuestConfigurationAssignment
    hide: true
  # The properties of VmssVMList are read-only
  - where:
      parameter-name: VmssVMList
    hide: true
  # The properties of AssignmentReportResource are read-only
  - where:
      parameter-name: LatestAssignmentReportResource
    hide: true
  # Change GuestConfigurationNavigation to required
  - from: swagger-document 
    where: $.definitions.GuestConfigurationAssignment
    transform: $["required"] = ["properties"]
  # Change GuestConfigurationNavigation to required
  - from: swagger-document 
    where: $.definitions.GuestConfigurationAssignmentProperties
    transform: $["required"] = ["guestConfiguration"]
  # Change GuestConfigurationNavigation.name, 
  # GuestConfigurationNavigation.version 
  # GuestConfigurationNavigation.contentUri 
  # and GuestConfigurationNavigation.contentHash to required
  - from: swagger-document 
    where: $.definitions.GuestConfigurationNavigation
    transform: $["required"] = ["name", "version", "contentUri", "contentHash"]
  # Change reports/{id} -> reports/{reportId} to avoid conflicts when piping an assignment 
  - from: swagger-document
    where: $
    transform: $ = $.replace(/reports\/{id}/g, "reports/{reportId}")
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmssName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{name}/reports/{reportId}"].get.parameters[4]
    transform: >-
      $.name = "reportId"
```
