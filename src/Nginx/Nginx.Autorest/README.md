<!-- region Generated -->
# Az.Nginx
This directory contains the PowerShell module for the Nginx service.

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
For information on how to develop for `Az.Nginx`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
commit: d1027c6d6d0994ef3a656a561b0cce8378ac58a4
tag: package-2024-01-01-preview
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/nginx/resource-manager/NGINX.NGINXPLUS/preview/2024-01-01-preview/swagger.json
root-module-name: $(prefix).Nginx
title: Nginx
module-version: 0.1.0
subject-prefix: Nginx

directive:
  # Following is two common directive which are normally required in all the RPs
  # 1. Remove the unexpanded parameter set
  # 2. For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^(Create|Update|Analysis)(?!.*?(Expanded|JsonFilePath|JsonString))|^CreateViaIdentityExpanded$
    remove: true
  - where:
      subject: Configuration|Certificate|Deployment
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
          },
          "scalingProperties": {
            "$ref": "#/definitions/NginxDeploymentScalingProperties"
          },
          "userProfile": {
            "$ref": "#/definitions/NginxDeploymentUserProfile"
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
    - model-name: NginxConfigurationFile
    - model-name: NginxPrivateIPAddress
    - model-name: NginxPublicIPAddress
    - model-name: NginxNetworkProfile
  - no-inline:
    - NginxNetworkProfile
  - where:
      verb: Get|Update|New
      subject: Configuration
    set:
      breaking-change:
        deprecated-output-properties:
          - File
          - ProtectedFile
          - PackageProtectedFile
        new-output-properties:
          - File
          - ProtectedFile
          - PackageProtectedFile
        change-description: The types of the properties File, ProtectedFile and PackageProtectedFile will be changed from fixed array to 'List'.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 15.0.0
        change-effective-date: 2025/11/03
  - where:
      verb: Get|Update|New
      subject: Deployment
    set:
      breaking-change:
        deprecated-output-properties:
          - PrivateIPAddress
          - PublicIPAddress
          - AutoScaleSettingProfile
        new-output-properties:
          - PrivateIPAddress
          - PublicIPAddress
          - AutoScaleSettingProfile
        change-description: The types of the properties PrivateIPAddress, ProtectedFile and AutoScaleSettingProfile will be changed from fixed array to 'List'.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 15.0.0
        change-effective-date: 2025/11/03
  - where:
      verb: Invoke
      subject: AnalysisConfiguration
    set:
      breaking-change:
        deprecated-output-properties:
          - DataError
        new-output-properties:
          - DataError
        change-description: The type of the property DataError will be changed from fixed array to 'List'.
        deprecated-by-version: 7.0.0
        deprecated-by-azversion: 15.0.0
        change-effective-date: 2025/11/03
  - where:
      verb: Invoke
      subject: AnalysisConfiguration
      variant: ^Analysis$|^AnalysisViaIdentity$
    set:
      breaking-change:
        change-description: The parameter set 'Analysis' and 'AnalysisViaIdentity' will be removed.
        deprecated-by-version: 7.0.0
        deprecated-by-azversion: 15.0.0
        change-effective-date: 2025/11/03
  - where:
      parameter-name: IdentityType|IdentityUserAssignedIdentity
    set:
      breaking-change:
        change-description: The cmdlet 'New-AzNginxDeployment' no longer supports the parameter 'IdentityType' and IdentityUserAssignedIdentity.
        deprecated-by-version: 2.0.0
        deprecated-by-azversion: 15.0.0
        change-effective-date: 2025/11/03
```
