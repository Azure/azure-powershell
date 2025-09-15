<!-- region Generated -->
# Az.DataBox
This directory contains the PowerShell module for the DataBox service.

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
For information on how to develop for `Az.DataBox`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: b64fe48e383ae6d6841fad0538f05dc82130ebb0
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/databox/resource-manager/Microsoft.DataBox/stable/2021-03-01/databox.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger 

# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: DataBox
subject-prefix: $(service-name)
inlining-threshold: 50
disable-transform-identity-type-for-operation:
  - Jobs_Update 
# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$|^UpdateViaIdentityExpanded$|^GetViaIdentity$|^Validate.*$ |^Cancel$|^CancelViaIdentity.*$|^DeleteViaIdentity$
    remove: true
  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true

  - where:
      subject: ServiceAvailableSku
    remove: true

  - where:
      subject: ServiceInput
    remove: true
  
  - where:
      subject: ServiceAddress
    remove: true

  - where:
      verb: Invoke
    remove: true
  
  - where:
      verb: Update
      parameter-name: ^Detail(.*)
    set:
      parameter-name: $1
  
  - where:
      verb: Get
      subject: JobCredentials
      parameter-name: JobName
    set:
      parameter-name: Name

  - where:
      verb: Get
      subject: JobCredentials
    set:
      subject: JobCredential

  - where:
      verb: New
      parameter-name: IdentityUserAssignedIdentity
    set:
      parameter-name: UserAssignedIdentity
  
  - where:
      verb: Update
      parameter-name: IdentityUserAssignedIdentity
    set:
      parameter-name: UserAssignedIdentity

  - where:
      model-name: JobResource 
    set:
      format-table:
        properties:
          - Name
          - Id
          - Location
          - Status
          - TransferType
          - SkuName
          - IdentityType
          - DeliveryType  
          - Detail
          
  - from: source-file-csharp
    where: $
    transform: $ = $.replace('internal Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.IJobSecrets', 'public Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.IJobSecrets');  
    
  - model-cmdlet:
    - model-name: DataBoxDiskJobDetails
    - model-name: DataBoxHeavyJobDetails
    - model-name: DataBoxJobDetails
    - model-name: StorageAccountDetails
    - model-name: ManagedDiskDetails
    - model-name: KeyEncryptionKey
    - model-name: ShippingAddress
    - model-name: ContactDetails
    - model-name: TransferConfiguration
```
``` yaml
directive:
  no-inline:  # the name of the model schema in the swagger file
    - KeyEncryptionKey
    - JobDetails
    - ShippingAddress
    - ContactDetails
    - TransferConfiguration
```
