<!-- region Generated -->
# Az.Authorization
This directory contains the PowerShell module for the Authorization service.

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
For information on how to develop for `Az.Authorization`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 0023223a23b7a8c1693f7d88678787e50fee6c96
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/authorization/resource-manager/Microsoft.Authorization/preview/2020-10-01-preview/EligibleChildResources.json

  - $(repo)/specification/authorization/resource-manager/Microsoft.Authorization/preview/2020-10-01-preview/RoleAssignmentSchedule.json
  - $(repo)/specification/authorization/resource-manager/Microsoft.Authorization/preview/2020-10-01-preview/RoleAssignmentScheduleInstance.json
  - $(repo)/specification/authorization/resource-manager/Microsoft.Authorization/preview/2020-10-01-preview/RoleAssignmentScheduleRequest.json

  - $(repo)/specification/authorization/resource-manager/Microsoft.Authorization/preview/2020-10-01-preview/RoleEligibilitySchedule.json
  - $(repo)/specification/authorization/resource-manager/Microsoft.Authorization/preview/2020-10-01-preview/RoleEligibilityScheduleInstance.json
  - $(repo)/specification/authorization/resource-manager/Microsoft.Authorization/preview/2020-10-01-preview/RoleEligibilityScheduleRequest.json

  - $(repo)/specification/authorization/resource-manager/Microsoft.Authorization/preview/2020-10-01-preview/RoleManagementPolicy.json
  - $(repo)/specification/authorization/resource-manager/Microsoft.Authorization/preview/2020-10-01-preview/RoleManagementPolicyAssignment.json

root-module-name: $(prefix).Resources
title: Authorization
namespace: Microsoft.Azure.PowerShell.Cmdlets.Resources.Authorization
# remove subject-prefix for all generated cmdlets.
subject-prefix: ''
identity-correction-for-post: true
resourcegroup-append: true
default-exclude-tableview-properties: false

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  # Swaager bug: The scope should be readonly according to the server response.
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
      
  # Remove "Create", "CreateViaIdentity", "CreateViaIdentityExpanded" syntax variant of the cmdlets. Because of new cmdlet does unsupport.
  - where:
      verb: New
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$
      # subject: RoleEligibilityScheduleRequest$|RoleManagementPolicyAssignment$
    remove: true

  # Remove "Update", "UpdateViaIdentity", syntax variant of the cmdlets. Because of update cmdlet does unsupport.
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
  
  - where:
      model-name: EligibleChildResource
    set:
      format-table:
        properties:
          - Name
          - Id
          - Type
  - where:
      model-name: RoleAssignmentSchedule
    set:
      format-table:
        properties:
          - Name
          - Id
          - Type
          - Scope
          - RoleDefinitionId
          - PrincipalId
  - where:
      model-name: RoleAssignmentScheduleInstance
    set:
      format-table:
        properties:
          - Name
          - Id
          - Type
          - Scope
          - RoleDefinitionId
          - PrincipalId
  - where:
      model-name: RoleAssignmentScheduleRequest
    set:
      format-table:
        properties:
          - Name
          - Id
          - Type
          - Scope
          - RoleDefinitionId
          - PrincipalId
  - where:
      model-name: RoleEligibilitySchedule
    set:
      format-table:
        properties:
          - Name
          - Id
          - Type
          - Scope
          - RoleDefinitionId
          - PrincipalId
  - where:
      model-name: RoleEligibilityScheduleInstance
    set:
      format-table:
        properties:
          - Name
          - Id
          - Type
          - Scope
          - RoleDefinitionId
          - PrincipalId
  - where:
      model-name: RoleEligibilityScheduleRequest
    set:
      format-table:
        properties:
          - Name
          - Id
          - Type
          - Scope
          - RoleDefinitionId
          - PrincipalId
  - where:
      model-name: RoleManagementPolicy
    set:
      format-table:
        properties:
          - Name
          - Id
          - Type
          - Scope
  - where:
      model-name: RoleManagementPolicyAssignment
    set:
      format-table:
        properties:
          - Name
          - Id
          - Type
          - Scope
          - RoleDefinitionId
          - PolicyId
  # rename cmdlet   
  - where:
      subject: ^EligibleChildResource$
    set:
      subject: RoleEligibleChildResource       
```
