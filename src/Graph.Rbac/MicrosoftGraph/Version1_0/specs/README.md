# Overall
This directory contains the service clients of other services for Azure PowerShell Websites module.
1. Download v1.0 yaml files from https://github.com/microsoftgraph/msgraph-sdk-powershell/blob/dev/openApiDocs/v1.0
1. Convert OpenApi 3.0 yaml to Swagger 2.0 by using [`api-spec-converter`](https://www.npmjs.com/package/api-spec-converter).
1. Edit swagger
  1. Remove the useless methods and defintions in swagger.
  1. Remove the `examples` and `links` properties in swagger.
  1. Update the `tags` and `operationId` of each operation.

## Run Generation
In this directory, run AutoRest:
```
autorest.cmd README.md --version=v2 --tag=Applications
autorest.cmd README.md --version=v2 --tag=DirectoryObjects
autorest.cmd README.md --version=v2 --tag=Groups
autorest.cmd README.md --version=v2 --tag=Users
```

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
csharp: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: date-plane
license-header: MICROSOFT_MIT_NO_VERSION
payload-flattening-threshold: 2
public-clients: false

directive:
  - from: source-file-csharp
    where: $
    transform: >-
            $ = $.replace(/new System\.Uri\(_baseUrl \+ \(_baseUrl\.EndsWith\("\/"\) \? "" : "\/"\)\)/g, 'new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/") + Client.ApiVersion + "/")')
  - from: source-file-csharp
    where: $
    transform: >-
            $ = $.replace(/\/\/ Serialize Request/g, '// Set Credentials\n            if (Client.Credentials != null)\n            {\n                cancellationToken.ThrowIfCancellationRequested();\n                await Client.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);\n            }\n\n            // Serialize Request')
  - from: source-file-csharp
    where: $
    transform: >-
            $ = $.replace(/\/\/ Set Headers/g, '// Set Headers\n            if (Client.GenerateClientRequestId != null && Client.GenerateClientRequestId.Value)\n            {\n                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", System.Guid.NewGuid().ToString());\n            }\n            if (Client.AcceptLanguage != null)\n            {\n                if (_httpRequest.Headers.Contains("accept-language"))\n                {\n                    _httpRequest.Headers.Remove("accept-language");\n                }\n                _httpRequest.Headers.TryAddWithoutValidation("accept-language", Client.AcceptLanguage);\n            }')
```


### Tag: Applications
``` yaml $(tag) == 'Applications'
title: Applications
input-file:
  - Applications.json

output-folder: Applications

namespace: Microsoft.Azure.Commands.Common.MSGraph.Applications
```

### Tag: DirectoryObjects
``` yaml $(tag) == 'DirectoryObjects'
input-file:
  - DirectoryObjects.json

output-folder: DirectoryObjects

namespace: Microsoft.Azure.Commands.Common.MSGraph.DirectoryObjects

```

### Tag: Groups
``` yaml $(tag) == 'Groups'
input-file:
  - Groups.json

output-folder: Groups

namespace: Microsoft.Azure.Commands.Common.MSGraph.Groups

```

### Tag: Users
``` yaml $(tag) == 'Users'
input-file:
  - Users.json

output-folder: Users

namespace: Microsoft.Azure.Commands.Common.MSGraph.Users

```