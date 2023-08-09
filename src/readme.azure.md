# Azure PowerShell AutoRest Configuration

> Values
``` yaml
azure: true
powershell: true
license-header: MICROSOFT_MIT_NO_VERSION
branch: resource-hybrid-profile-fix
repo: https://github.com/Azure/azure-rest-api-specs/blob/$(branch)
metadata:
  authors: Microsoft Corporation
  owners: Microsoft Corporation
  description: 'Microsoft Azure PowerShell: $(service-name) cmdlets'
  copyright: Microsoft Corporation. All rights reserved.
  tags: Azure ResourceManager ARM PSModule $(service-name)
  companyName: Microsoft Corporation
  requireLicenseAcceptance: true
  licenseUri: https://aka.ms/azps-license
  projectUri: https://github.com/Azure/azure-powershell
```

> Names
``` yaml
prefix: Az
subject-prefix: $(service-name)
module-name: $(prefix).$(service-name)
namespace: Microsoft.Azure.PowerShell.Cmdlets.$(service-name)
```

> Folders
``` yaml
clear-output-folder: true
output-folder: .
```

> Profiles
``` yaml
require: $(repo)/profiles/readme.md
profile:
  - hybrid-2019-03-01
  - latest-2019-04-30
```

> Directives
``` yaml
directive:
  - from: swagger-document
    where: $.paths..responses.202.headers
    transform: delete $["Location"]
  - from: swagger-document
    where: $.paths..responses.202.headers
    transform: delete $["Retry-After"]
  - from: swagger-document
    where: $.paths..responses.202.headers
    transform: delete $["Azure-AsyncOperation"]
  - from: swagger-document
    where: $.paths..responses.201.headers
    transform: delete $["Location"]
  - from: swagger-document
    where: $.paths..responses.201.headers
    transform: delete $["Retry-After"]
  - from: swagger-document
    where: $.paths..responses.201.headers
    transform: delete $["Azure-AsyncOperation"]
  - where:
      subject: Operation
    hide: true
  - where:
      parameter-name: SubscriptionId
    set:
      default:
        script: '(Get-AzContext).Subscription.Id'
```