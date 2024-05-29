<!-- region Generated -->
# Az.AppConfigurationdata
This directory contains the PowerShell module for the AppConfigurationdata service.

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
For information on how to develop for `Az.AppConfigurationdata`, see [how-to.md](how-to.md).
<!-- endregion -->

---
## Generation Requirements
Use of the beta version of `autorest.powershell` generator requires the following:
- [NodeJS LTS](https://nodejs.org) (10.15.x LTS preferred)
  - **Note**: It *will not work* with Node < 10.x. Using 11.x builds may cause issues as they may introduce instability or breaking changes.
> If you want an easy way to install and update Node, [NVS - Node Version Switcher](../nodejs/installing-via-nvs.md) or [NVM - Node Version Manager](../nodejs/installing-via-nvm.md) is recommended.
- [AutoRest](https://aka.ms/autorest) v3 beta <br>`npm install -g autorest@beta`<br>&nbsp;
- PowerShell 6.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g pwsh`<br>&nbsp;
- .NET Core SDK 2.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g dotnet-sdk-2.2`<br>&nbsp;

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: 498ccf7ddf78ced8ef515f88b755b2eb3775de9e
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/appconfiguration/data-plane/Microsoft.AppConfiguration/stable/1.0/appconfiguration.json

root-module-name: $(prefix).AppConfiguration
module-version: 1.0.0
title: AppConfigurationdata
subject-prefix: AppConfiguration

# If there are post APIs for some kinds of actions in the RP, you may need to
# uncomment following line to support viaIdentity for these post APIs
identity-correction-for-post: true
resourcegroup-append: true
nested-object-to-string: true
endpoint-resource-id-key-name: AzureAppConfigurationEndpointResourceId

directive:
  # Remove the Etag and Last-Modified in headers from the response
  - from: swagger-document
    where: $.*.*.*.*.*.headers
    transform: delete $.ETag; delete $["Last-Modified"]
  - from: swagger-document
    where: $.paths["/kv"]
    transform: delete $.head

  # Hide the get operation for KeyValue because the parameter key doesn't have a consistent meaning in /kv and /kv/{key}
  - where:
      subject: ^KeyValue$
      verb: Get
    hide: true

  # The head operation for key is not supported.
  - where:
      subject: ^Key$|^Label$|^Revision$
      verb: Test
    remove: true

  - where:
      subject: ^KeyValue$
      variant: ^Put$
      verb: Set
    remove: true
```
