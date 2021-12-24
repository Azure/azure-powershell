<!-- region Generated -->
# Az.DataMigration
This directory contains the PowerShell module for the DataMigration service.

---
## Status
[![Az.DataMigration](https://img.shields.io/powershellgallery/v/Az.DataMigration.svg?style=flat-square&label=Az.DataMigration "Az.DataMigration")](https://www.powershellgallery.com/packages/Az.DataMigration/)

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
For information on how to develop for `Az.DataMigration`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 7086ee861c3a6196bb98f8b327af11d03e545a05
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  # - D:\azure-rest-api\azure-rest-api-specs\specification\windowsiot\resource-manager\Microsoft.WindowsIoT\stable\2019-06-01\DataMigration.json
  - $(repo)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2021-10-30-preview/sqlmigration.json

title: DataMigration
module-version: 0.1.0
subject-prefix: ''

directive:

  #Remove the unexpanded parameter set
  #For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true

  - where:
      verb: Remove
      subject: SqlMigrationServiceNode
      variant: 
        ^Delete$|^DeleteViaIdentity$
    remove: true

  - where:
      variant: ^Cutover$|^CutoverViaIdentity$|^CutoverViaIdentityExpanded$ 
    remove: true

  - where:
      variant: ^Cancel$|^CancelViaIdentity$|^CancelViaIdentityExpanded$
    remove: true

  - where:
      variant: ^Regenerate$|^RegenerateViaIdentity$|^RegenerateViaIdentityExpanded$
    remove: true

  #Changing Naming convention
  - where:
      subject: (DatabaseMigrationSqlMi$)
    set:
      subject: ToSqlManagedInstance

  - where:
      subject: DatabaseMigrationsSqlMi
    set:
      subject: ToSqlManagedInstance

  - where:
      subject: (DatabaseMigrationSqlVM$)
    set:
      subject: ToSqlVM

  - where:
      subject: DatabaseMigrationsSqlVM
    set:
      subject: ToSqlVM
  
  - where:
      subject: (^SqlMigrationService)
    set:
      subject: SqlService

  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true

  # Formatting
  - where:
      model-name: SqlMigrationService
    set:
      format-table:
        properties:
          - Location
          - Name
          - Type
          - ProvisioningState
          - IntegrationRuntimeState
  - where:
      model-name: DatabaseMigrationSqlMi
    set:
      format-table:
        properties:
          - Name
          - Type
          - Kind
          - ProvisioningState
          - MigrationStatus
  - where:
      model-name: DatabaseMigrationSqlVm
    set:
      format-table:
        properties:
          - Name
          - Type
          - Kind
          - ProvisioningState
          - MigrationStatus
  - where:
      model-name: DatabaseMigration
    set:
      format-table:
        properties:
          - Name
          - Type
          - Kind
          - ProvisioningState
          - MigrationStatus
```
