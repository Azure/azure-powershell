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
commit: 0dd49a444195fef7f3555cad038cb7665cbd928c
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - "https://raw.githubusercontent.com/Azure/azure-rest-api-specs/cb5ef7fc4cb443bd5f6b21d02cbce41051beb6ae/specification/databox/resource-manager/Microsoft.DataBox/stable/2025-02-01/databox.json"
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

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^(Create)(?!.*?(Expanded|JsonFilePath|JsonString))
    remove: true
  - where:
      variant: ^CreateViaIdentity$|^CreateViaIdentityExpanded$|^GetViaIdentity$|^Validate.*$ |^Cancel$|^CancelViaIdentity.*$|^DeleteViaIdentity$
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
      parameter-name: PreferenceStorageAccountAccessTierPreference
    set:
      parameter-name: StorageAccountAccessTierPreference
      
  - where:
      parameter-name: ReverseShippingDetailShippingAddress
    set:
      parameter-name: ReverseShippingDetail

  - where:
      parameter-name: ReverseTransportPreferencePreferredShipmentType
    set:
      parameter-name: ReverseTransportPreferredShipmentType

  - where:
      parameter-name: TransportPreferencePreferredShipmentType
    set:
      parameter-name: TransportPreferredShipmentType

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

  - model-cmdlet:
      - model-name: DataBoxDiskJobDetails
        cmdlet-name: New-AzDataBoxDiskJobDetailsObject
      - model-name: DataBoxHeavyJobDetails
        cmdlet-name: New-AzDataBoxHeavyJobDetailsObject
      - model-name: DataBoxJobDetails
        cmdlet-name: New-AzDataBoxJobDetailsObject
      - model-name: StorageAccountDetails
        cmdlet-name: New-AzDataBoxStorageAccountDetailsObject
      - model-name: ManagedDiskDetails
        cmdlet-name: New-AzDataBoxManagedDiskDetailsObject
      - model-name: KeyEncryptionKey
        cmdlet-name: New-AzDataBoxKeyEncryptionKeyObject
      - model-name: ShippingAddress
        cmdlet-name: New-AzDataBoxShippingAddressObject
      - model-name: ContactDetails
        cmdlet-name: New-AzDataBoxContactDetailsObject
      - model-name: TransferConfiguration
        cmdlet-name: New-AzDataBoxTransferConfigurationObject
      - model-name: DataBoxCustomerDiskJobDetails
        cmdlet-name: New-AzDataBoxCustomerDiskJobDetailsObject

  - no-inline:  # the name of the model schema in the swagger file
    - KeyEncryptionKey
    - JobDetails
    - ShippingAddress
    - ContactDetails
    - TransferConfiguration

  - where:
      verb: Update
    hide: true
```
