<!-- region Generated -->
# Az.DigitalTwins
This directory contains the PowerShell module for the DigitalTwins service.

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
For information on how to develop for `Az.DigitalTwins`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 9a312bb730561b8e8e3c0ea7c224de38a9d05238
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/digitaltwins/resource-manager/Microsoft.DigitalTwins/stable/2022-05-31/digitaltwins.json

module-version: 0.3.0
title: DigitalTwins
subject-prefix: $(service-name)

directive:
  - where:
      subject: DigitalTwin
    set:
      subject: Instance
  - where:
      subject: DigitalTwinNameAvailability
    set:
      subject: InstanceNameAvailability
  - where:
      verb: Set
    remove: true

  - where:
      subject: Instance
      variant: ^(Create|Update)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^(Check)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentityExpanded$
    remove: true

  - where:
      verb: New|Update
      subject: DigitalTwinsEndpoint
    hide: true
  - where:
      verb: New|Update
      subject: TimeSeriesDatabaseConnection
    hide: true

  - where:
      model-name: DigitalTwinsEndpointResource
    set:
      format-table:
        properties:
          - Name
          - EndpointType
          - AuthenticationType
          - ResourceGroupName

  - where:
      model-name: DigitalTwinsDescription
    set:
      format-table:
        properties:
          - Name
          - Location
          - ResourceGroupName

  - where:
      model-name: TimeSeriesDatabaseConnection
    set:
      format-table:
        properties:
          - Name
          - ConnectionType
          - ProvisioningState
          - ResourceGroupName
```
