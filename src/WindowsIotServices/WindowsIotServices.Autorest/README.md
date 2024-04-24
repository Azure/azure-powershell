<!-- region Generated -->
# Az.WindowsIotServices
This directory contains the PowerShell module for the WindowsIotServices service.

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
For information on how to develop for `Az.WindowsIotServices`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: cae75058ed79deb758e08021315ce5a7fc27d403
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  # - D:\azure-rest-api\azure-rest-api-specs\specification\windowsiot\resource-manager\Microsoft.WindowsIoT\stable\2019-06-01\WindowsIotServices.json
  - $(repo)/specification/windowsiot/resource-manager/Microsoft.WindowsIoT/stable/2019-06-01/WindowsIotServices.json
   
title: WindowsIotServices
module-version: 0.1.0
subject-prefix: WindowsIotServices

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  # Changed schema ref of the patch and put request.
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.WindowsIoT/deviceServices/{deviceName}"].patch.parameters[4].schema["$ref"]
    transform: return "#/definitions/DeviceService"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.WindowsIoT/deviceServices/{deviceName}"].put.parameters[4].schema["$ref"]
    transform: return "#/definitions/DeviceService"
  # Add status code 200 of the response status code after created or updated windows iot services.
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.WindowsIoT/deviceServices/{deviceName}"].put.responses
    transform: >-
        return {
          "200": {
            "description": "OK. The request has succeeded.",
            "schema": {
              "$ref": "#/definitions/DeviceService"
            }
          },
          "201": {
            "description": "OK. The request has succeeded.",
            "schema": {
              "$ref": "#/definitions/DeviceService"
            }
          },
          "default": {
            "description": "DefaultErrorResponse",
            "schema": {
              "$ref": "#/definitions/ErrorDetails"
            }
          }
        }
  # Uppercase to lowercase of the path
  - from: swagger-document
    where: $
    transform: return $.replace(/\/subscriptions\/\{subscriptionId\}\/resourceGroups\/\{resourceGroupName\}\/providers\/Microsoft\.WindowsIoT\/deviceServices/g, "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.WindowsIoT/DeviceServices")
  # Remove set- cmdlet
  - where:
      verb: Set
      subject: Service$
    remove: true
  # Remove parameter set name
  - where:
      verb: New
      subject: Service$
      variant: Create$|CreateViaIdentity$|CreateViaIdentityExpanded$
    remove: true
  - where:
      verb: Update
      subject: Service$
      variant: Update$|UpdateViaIdentity$
    remove: true
  # Rename parameter name
  - where:
      verb: Get|New|Update|Remove
      subject: Service$
      parameter-name: DeviceName$
    set:
      parameter-name: Name
  # Remove cmdlet
  - where:
      verb: Test
      subject: ServiceDeviceServiceNameAvailability$
    remove: true
  - where:
      verb: Get|New|Update|Remove
      subject: Service$
    set:
      subject: Device
```
