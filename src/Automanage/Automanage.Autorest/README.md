<!-- region Generated -->
# Az.Automanage
This directory contains the PowerShell module for the Automanage service.

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
For information on how to develop for `Az.Automanage`, see [how-to.md](how-to.md).
<!-- endregion -->

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 54ad712dbb6f83113574e2c81558cb146740912a
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/automanage/resource-manager/Microsoft.Automanage/stable/2022-05-04/automanage.json

# title: Databricks
# subject-prefix: $(service-name)

inlining-threshold: 100
resourcegroup-append: true
nested-object-to-string: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  - from: swagger-document
    where: $.definitions.ConfigurationDictionary
    transform: >-
      return {
          "description": "The custom configuration for configuration profile. Name and value pairs that define the configuration details of the configuration profile.",
          "type": "object",
          "additionalProperties": true,
          "example": {
            "Antimalware/Enable": true
          }
      }

  # remove cmdlets
  - where:
      verb: Set
    remove: true

  # remove variant
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true

  - where:
      verb: Get
      subject: ^BestPractice$|^BestPracticeVersion$
      variant: ^GetViaIdentity$
    remove: true

  # rename subject
  - where:
      subject: (.*)(Profiles)(.*)
    set:
      subject: $1Profile$3

  - where:
      subject: (.*)(Configuration)(.*)
    set:
      subject: $1Config$3

  - where:
      subject: BestPracticesVersion
    set:
      subject: BestPracticeVersion

  # ConfigurationProfileAssignmentName only one value is default
  - where:
      verb: Get
      subject: ^ConfigProfileAssignment$
      variant: ^List$
    remove: true
  # Those Api not supported in  2022-05-04 version
  # - ConfigurationProfilesVersions_CreateOrUpdate
  # - ConfigurationProfilesVersions_Get
  # - ConfigurationProfilesVersions_Delete
  # - ConfigurationProfilesVersions_ListChildResources
  # - BestPracticesVersions_Get
  # - BestPracticesVersions_ListByTenant
  # - ServicePrincipals_ListBySubscription
  # - ServicePrincipals_Get
  # remove cmdlet 
  - where: 
      subject: ^ConfigProfileVersion$
    remove: true
  - where:
      subject: ^ConfigProfileVersionChildResource$
      verb: Get
    remove: true
  - where:
      subject: ^BestPracticeVersion$
      verb: Get
    remove: true
  - where:
      subject: ^ServicePrincipal$
      verb: Get
    remove: true

  # rename parameter
  - where:
      subject: BestPracticeVersion
      parameter-name: BestPracticeName
    set:
      parameter-name: Name

  - where:
      subject: BestPracticeVersion
      parameter-name: VersionName
    set:
      parameter-name: Version

  - where:
      subject: Report
      parameter-name: ConfigurationProfileName
    set:
      parameter-name: Name

  - where:
      subject: ConfigProfileHciAssignment|ConfigProfileHcrpAssignment
      parameter-name: ConfigurationProfileAssignmentName
    set:
      parameter-name: Name

  - where:
      subject: HciReport|HcrpReport
      parameter-name: ReportName
    set:
      parameter-name: Name

  - where:
      subject: HciReport|HcrpReport|Report
      parameter-name: ConfigurationProfileAssignmentName
    set:
      parameter-name: ConfigProfileAssignmentName

  - where:
      subject: ConfigProfileVersion
      parameter-name: VersionName
    set:
      parameter-name: Version

  # Set default value for parameter
  - where:
      subject: ConfigProfileAssignment|ConfigProfileHciAssignment|ConfigProfileHcrpAssignment
      parameter-name: Name
    hide: true
    set:
      default:
        script: "'default'"

  - where:
      subject: Report|HciReport|HcrpReport
      parameter-name: ConfigProfileAssignmentName
    hide: true
    set:
      default:
        script: "'default'"

  - where:
      model-name: ConfigurationProfileAssignment
    set:
      format-table:
        properties:
          - Name
          - ResourceGroupName
          - ManagedBy
          - Status
          - TargetId
  
  - where:
      model-name: BestPractice
    set:
      format-table:
        properties:
          - Name
          - Type

  - where:
      model-name: ServicePrincipal
    set:
      format-table:
        properties:
          - Name
          - AuthorizationSet
          - ServicePrincipalId
```
