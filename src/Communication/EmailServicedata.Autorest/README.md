<!-- region Generated -->
# Az.EmailServicedata
This directory contains the PowerShell module for the EmailServicedata service.

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
For information on how to develop for `Az.EmailServicedata`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 512e966e15cd8e6ffd756279971c478702f4e19e
require:
# readme.azure.noprofile.md is the common configuration file
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
# You need to specify your swagger files here.
  - $(repo)/specification/communication/data-plane/Email/stable/2023-03-31/CommunicationServicesEmail.json
# If the swagger has not been put in the repo, you may uncomment the following line and refer to it locally
# - (this-folder)/relative-path-to-your-swagger 

root-module-name: $(prefix).Communication
# For new RP, the version is 0.1.0
module-version: 0.1.0
# Normally, title is the service name
title: EmailServicedata
subject-prefix: $(service-name)

# If there are post APIs for some kinds of actions in the RP, you may need to
# uncomment following line to support viaIdentity for these post APIs
identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true
endpoint-resource-id-key-name: AzureCommunicationEmailEndpointResourceId

directive: 
  # [swagger] change the final-state-via to align with service response
  - from: swagger-document
    where: $.paths["/emails:send"].post["x-ms-long-running-operation-options"]
    transform: $["final-state-via"] = "operation-location"

  # Add 200 status code.
  - from: swagger-document
    where: $.paths["/emails:send"].post.responses
    transform: >-
      return {
          "200": {
            "description": "Message status was successfully retrieved.",
            "headers": {
              "retry-after": {
                "description": "This header will only be present when the status is a non-terminal status. It indicates the minimum amount of time in seconds to wait before polling for operation status again.",
                "type": "integer",
                "format": "int32"
              }
            },
            "schema": {
              "$ref": "#/definitions/EmailSendResult"
            }
          }
        }
```
