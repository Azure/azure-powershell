<!-- region Generated -->
# Az.ConnectedNetwork
This directory contains the PowerShell module for the ConnectedNetwork service.

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
For information on how to develop for `Az.ConnectedNetwork`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 5f32b50e18ed0a91eefe39287078bf66c4d6c3a8
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/hybridnetwork/resource-manager/Microsoft.HybridNetwork/stable/2021-05-01/common.json
  - $(repo)/specification/hybridnetwork/resource-manager/Microsoft.HybridNetwork/stable/2021-05-01/networkFunction.json
  - $(repo)/specification/hybridnetwork/resource-manager/Microsoft.HybridNetwork/stable/2021-05-01/vendor.json
  - $(repo)/specification/hybridnetwork/resource-manager/Microsoft.HybridNetwork/stable/2021-05-01/device.json
  - $(repo)/specification/hybridnetwork/resource-manager/Microsoft.HybridNetwork/stable/2021-05-01/networkFunctionVendor.json
  - $(repo)/specification/hybridnetwork/resource-manager/Microsoft.HybridNetwork/stable/2021-05-01/vendorNetworkFunction.json

module-version: 0.1.0
title: ConnectedNetwork
subject-prefix: $(service-name)
identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      verb: Set
    remove: true
  - where:
      subject: NetworkFunctionVendorSku
    hide: true
  - where:
      subject: ^NetworkFunction$
      parameter-name: NetworkFunctionContainerConfiguration
    set:
      parameter-name: ContainerConfiguration
  - where:
      subject: ^NetworkFunction$
      parameter-name: NetworkFunctionUserConfiguration
    set:
      parameter-name: UserConfiguration
  - where:
      subject: ^VendorNetworkFunction$
    set:
      subject: VendorFunction
  - where:
      subject: ^RoleInstance$
    set:
      subject: VendorFunctionRoleInstance
  - where:
      subject: ^VendorFunction$
      parameter-name: NetworkFunctionVendorConfiguration
    set:
      parameter-name: VendorConfiguration
  - where:
      subject: ^VendorSku$
      parameter-name: NetworkFunctionTemplateNetworkFunctionRoleConfiguration
    set:
      parameter-name: NetworkFunctionRoleConfigurationType
  # - from: swagger-document 
  #   where: $.definitions.VendorNetworkFunctionPropertiesFormat.properties.vendorProvisioningState
  #   transform: >-
  #     return {
  #         "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/5f32b50e18ed0a91eefe39287078bf66c4d6c3a8/specification/hybridnetwork/resource-manager/Microsoft.HybridNetwork/stable/2021-05-01/common.json#/definitions/VendorProvisioningState",
  #         "description": "The vendor controlled provisioning state of the vendor network function.",
  #         "readOnly": true
  #     }
  - from: swagger-document 
    where: $.definitions.VendorNetworkFunctionPropertiesFormat.properties.skuType
    transform: >-
      return {
          "$ref": "https://github.com/Azure/azure-rest-api-specs/blob/5f32b50e18ed0a91eefe39287078bf66c4d6c3a8/specification/hybridnetwork/resource-manager/Microsoft.HybridNetwork/stable/2021-05-01/common.json#/definitions/SkuType",
          "description": "The sku type."
      }
  - from: swagger-document 
    where: $.definitions.NetworkFunctionPropertiesFormat.properties.managedApplicationParameters
    transform: >-
      return {
          "type": "object",
          "additionalProperties": true,
          "description": "The parameters for the managed application."
      }
  - from: swagger-document 
    where: $.definitions.NetworkFunctionPropertiesFormat.properties.networkFunctionContainerConfigurations
    transform: >-
      return {
          "type": "object",
          "additionalProperties": true,
          "description": "The network function container configurations from the user."
      }
  - from: swagger-document 
    where: $.definitions.VendorSkuPropertiesFormat.properties.managedApplicationParameters
    transform: >-
      return {
          "type": "object",
          "additionalProperties": true,
          "description": "The parameters for the managed application to be supplied by the vendor."
      }
  - from: swagger-document 
    where: $.definitions.VendorSkuPropertiesFormat.properties.managedApplicationTemplate
    transform: >-
      return {
          "type": "object",
          "additionalProperties": true,
          "description": "The template for the managed application deployment."
      }
  - no-inline:
      - Device
  #  The generated cmdlet need to Re-Name 
  # - model-cmdlet:
  #     - AzureStackEdgeFormat
  #     - NetworkInterface
  #     - NetworkInterfaceIPConfiguration
  #     - NetworkFunctionUserConfiguration
  #     - NetworkFunctionVendorConfiguration
  #     - NetworkFunctionRoleConfiguration
```
