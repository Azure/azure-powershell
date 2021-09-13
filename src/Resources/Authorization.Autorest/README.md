<!-- region Generated -->
# Az.Resources
This directory contains the PowerShell module for the Authorization service.

---
## Status
[![Az.Resources](https://img.shields.io/powershellgallery/v/Az.Resources.svg?style=flat-square&label=Az.Resources "Az.Resources")](https://www.powershellgallery.com/packages/Az.Resources/)

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
For information on how to develop for `Az.Resources`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/0023223a23b7a8c1693f7d88678787e50fee6c96/specification/authorization/resource-manager/Microsoft.Authorization/preview/2020-10-01-preview/EligibleChildResources.json
  - https://github.com/Azure/azure-rest-api-specs/blob/0023223a23b7a8c1693f7d88678787e50fee6c96/specification/authorization/resource-manager/Microsoft.Authorization/preview/2020-10-01-preview/RoleAssignmentSchedule.json
  - https://github.com/Azure/azure-rest-api-specs/blob/0023223a23b7a8c1693f7d88678787e50fee6c96/specification/authorization/resource-manager/Microsoft.Authorization/preview/2020-10-01-preview/RoleAssignmentScheduleInstance.json
  - https://github.com/Azure/azure-rest-api-specs/blob/0023223a23b7a8c1693f7d88678787e50fee6c96/specification/authorization/resource-manager/Microsoft.Authorization/preview/2020-10-01-preview/RoleAssignmentScheduleRequest.json
  - https://github.com/Azure/azure-rest-api-specs/blob/0023223a23b7a8c1693f7d88678787e50fee6c96/specification/authorization/resource-manager/Microsoft.Authorization/preview/2020-10-01-preview/RoleEligibilitySchedule.json
  - https://github.com/Azure/azure-rest-api-specs/blob/0023223a23b7a8c1693f7d88678787e50fee6c96/specification/authorization/resource-manager/Microsoft.Authorization/preview/2020-10-01-preview/RoleEligibilityScheduleInstance.json
  - https://github.com/Azure/azure-rest-api-specs/blob/0023223a23b7a8c1693f7d88678787e50fee6c96/specification/authorization/resource-manager/Microsoft.Authorization/preview/2020-10-01-preview/RoleEligibilityScheduleRequest.json
  - https://github.com/Azure/azure-rest-api-specs/blob/0023223a23b7a8c1693f7d88678787e50fee6c96/specification/authorization/resource-manager/Microsoft.Authorization/preview/2020-10-01-preview/RoleManagementPolicy.json
  - https://github.com/Azure/azure-rest-api-specs/blob/23800927d61999e655f6fd7fd054deaa80385683/specification/authorization/resource-manager/Microsoft.Authorization/preview/2020-10-01-preview/RoleManagementPolicyAssignment.json

module-name: $(prefix).Resources
title: Authorization
dll-name: Az.Resources.Authorization.private
csproj: Authorization.csproj
psm1: Authorization.psm1
psm1-internal: internal/Authorization.internal.psm1
psm1-custom: custom/Authorization.custom.psm1
format-ps1xml: Authorization.format.ps1xml
namespace: Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization
subject-prefix: ''
identity-correction-for-post: true

directive:
  # Swagger bug: The scope should be readonly according to the server response.
  - from: swagger-document
    where: $.definitions.RoleManagementPolicyProperties.properties.scope
    transform: >-
      return {
        "type": "string",
        "readOnly": true,
        "description": "The role management policy scope."
      }

  - from: swagger-document
    where: $.definitions.RoleManagementPolicyAssignmentProperties.properties.scope
    transform: >-
      return {
        "type": "string",
        "readOnly": true,
        "description": "The role management policy scope."
      }
      
  # Remove "Create", "CreateViaIdentity", "CreateViaIdentityExpanded" syntax variant of the cmdlets because new cmdlet is not supported.
  - where:
      verb: New
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$
      # subject: RoleEligibilityScheduleRequest$|RoleManagementPolicyAssignment$
    remove: true

  # Remove "Update", "UpdateViaIdentity", syntax variant of the cmdlets because update cmdlet is not supported.
  - where:
      verb: Update
      variant: ^Update$|^UpdateViaIdentity$
      subject: RoleManagementPolicy$
    remove: true
  
  # The parameter is not friendly and needs to be renamed.
  - where:
      parameter-name: ^TicketInfoTicketNumber$
    set:
      parameter-name: TicketNumber
  - where:
      parameter-name: ^TicketInfoTicketSystem$
    set:
      parameter-name: TicketSystem

  # Generate cmdlet for RoleManagementPolicyRule memory object and copy to the custom folder for rename cmdlet(New-AzAuthorizationRoleManagementPolicyRuleObject --> New-AzRoleManagementPolicyRuleObject).
  # Then cancel configuration of it.   
  # - model-cmdlet:
  #   - RoleManagementPolicyRule
    
```
