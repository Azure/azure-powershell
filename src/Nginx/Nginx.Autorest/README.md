<!-- region Generated -->
# Az.Nginx
This directory contains the PowerShell module for the Nginx service.

---
## Status
[![Az.Nginx](https://img.shields.io/powershellgallery/v/Az.Nginx.svg?style=flat-square&label=Az.Nginx "Az.Nginx")](https://www.powershellgallery.com/packages/Az.Nginx/)

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
For information on how to develop for `Az.Nginx`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - https://github.com/Azure/azure-rest-api-specs/blob/5dd50f3a923888cae5b77a4d4a48cb57430ba9de/specification/nginx/resource-manager/NGINX.NGINXPLUS/stable/2022-08-01/swagger.json

root-module-name: $(prefix).Nginx
title: Nginx
module-version: 0.1.0
subject-prefix: Nginx
nested-object-to-string: true

# If there are post APIs for some kinds of actions in the RP, you may need to 
# uncomment following line to support viaIdentity for these post APIs
# identity-correction-for-post: true

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true
  - where:
      subject: Configuration
      verb: Set
    remove: true
  # ProvisioningState readonly
  - from: swagger-document
    where: $.definitions.ProvisioningState
    transform: >-
      return {
          "enum": [
          "Accepted",
          "Creating",
          "Updating",
          "Deleting",
          "Succeeded",
          "Failed",
          "Canceled",
          "Deleted",
          "NotSpecified"
        ],
        "type": "string",
        "readOnly": true,
        "x-ms-enum": {
          "modelAsString": true,
          "name": "ProvisioningState"
        }
      }
  # Required properties for deployment
  - from: swagger-document
    where: $.definitions.NginxDeploymentProperties
    transform: >-
      return {
        "type": "object",
        "properties": {
          "provisioningState": {
            "$ref": "#/definitions/ProvisioningState"
          },
          "nginxVersion": {
            "type": "string",
            "readOnly": true
          },
          "managedResourceGroup": {
            "type": "string",
            "description": "The managed resource group to deploy VNet injection related network resources."
          },
          "networkProfile": {
            "$ref": "#/definitions/NginxNetworkProfile"
          },
          "ipAddress": {
            "type": "string",
            "description": "The IP address of the deployment.",
            "readOnly": true
          },
          "enableDiagnosticsSupport": {
            "type": "boolean"
          },
          "logging": {
            "$ref": "#/definitions/NginxLogging"
          }
        },
        "required": [
          "networkProfile"
        ]
      }
  - from: swagger-document
    where: $.definitions.NginxDeployment
    transform: >-
      return {
        "type": "object",
        "x-ms-azure-resource": true,
        "properties": {
          "id": {
            "type": "string",
            "readOnly": true
          },
          "name": {
            "type": "string",
            "readOnly": true
          },
          "type": {
            "type": "string",
            "readOnly": true
          },
          "identity": {
            "$ref": "#/definitions/IdentityProperties"
          },
          "properties": {
            "$ref": "#/definitions/NginxDeploymentProperties"
          },
          "tags": {
            "type": "object",
            "additionalProperties": {
              "type": "string"
            }
          },
          "sku": {
            "$ref": "#/definitions/ResourceSku",
          },
          "location": {
            "type": "string",
          },
          "systemData": {
            "$ref": "../../../../../common-types/resource-management/v2/types.json#/definitions/systemData",
            "readOnly": true
          }
        },
        "required": [
          "properties",
          "location",
          "sku"
        ]
      }
  # Required properties for Certificates
  - from: swagger-document
    where: $.definitions.NginxCertificate
    transform: >-
      return {
        "type": "object",
        "x-ms-azure-resource": true,
        "properties": {
          "id": {
            "type": "string",
            "readOnly": true
          },
          "name": {
            "type": "string",
            "readOnly": true
          },
          "type": {
            "type": "string",
            "readOnly": true
          },
          "properties": {
            "$ref": "#/definitions/NginxCertificateProperties"
          },
          "tags": {
            "type": "object",
            "additionalProperties": {
              "type": "string"
            }
          },
          "location": {
            "type": "string"
          },
          "systemData": {
            "$ref": "../../../../../common-types/resource-management/v2/types.json#/definitions/systemData",
            "readOnly": true
          }
        },
        "required": [
          "properties"
        ]
      }
  - from: swagger-document
    where: $.definitions.NginxCertificateProperties
    transform: >-
      return {
        "type": "object",
        "properties": {
          "provisioningState": {
            "$ref": "#/definitions/ProvisioningState"
          },
          "keyVirtualPath": {
            "type": "string"
          },
          "certificateVirtualPath": {
            "type": "string"
          },
          "keyVaultSecretId": {
            "type": "string"
          }
        },
        "required": [
          "keyVirtualPath",
          "certificateVirtualPath",
          "keyVaultSecretId"
        ]
      }
  - model-cmdlet:
    - NginxConfigurationFile
    - NginxPrivateIPAddress
    - NginxPublicIPAddress
    - NginxNetworkProfile
  - no-inline:
    - NginxNetworkProfile
```
