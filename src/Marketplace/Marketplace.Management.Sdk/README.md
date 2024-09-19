# Overall
This directory contains management plane service clients of Az.Marketplace module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@autorest/powershell@4.x
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
isSdkGenerator: true
powershell: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
payload-flattening-threshold: 2
```



###
``` yaml
commit: 2fa64c84cf861c79be334fddbe3eca547fee6d2b
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/marketplace/resource-manager/Microsoft.Marketplace/stable/2020-01-01/Marketplace.json

output-folder: Generated

namespace: Microsoft.Azure.Management.Marketplace

directive:
  - from: swagger-document
    where: $.paths["/providers/Microsoft.Marketplace/privateStores/{privateStoreId}/offers/{offerId}"].delete
    transform: >-
      return {
        "tags": [
          "PrivateStores"
        ],
        "operationId": "PrivateStoreOffer_Delete",
        "description": "Deletes an offer from the given private store.",
        "produces": [
          "application/json"
        ],
        "responses": {
          "200": {
            "description": "Offer was deleted successfully"
          },
          "default": {
            "description": "Microsoft.Marketplace error response describing why the operation failed.",
            "schema": {
              "$ref": "#/definitions/ErrorResponse"
            }
          }
        },
        "x-ms-examples": {
          "DeletePrivateStoreOffer": {
            "$ref": "./examples/DeletePrivateStoreOffer.json"
          }
        }
      }
  - from: swagger-document
    where: $.paths["/providers/Microsoft.Marketplace/operations"].get
    transform: >-
      return {
        "tags": [
          "Operations"
        ],
        "description": "Lists all of the available Microsoft.Marketplace REST API operations.",
        "operationId": "Operations_List",
        "parameters": [
          {
            "$ref": "#/parameters/ApiVersionParameter"
          }
        ],
        "produces": [
          "application/json"
        ],
        "responses": {
          "200": {
            "description": "OK. The request has succeeded.",
            "schema": {
              "$ref": "#/definitions/OperationListResult"
            }
          },
          "default": {
            "description": "Microsoft.Marketplace error response describing why the operation failed.",
            "schema": {
              "$ref": "#/definitions/ErrorResponse"
            }
          }
        }
      }
```