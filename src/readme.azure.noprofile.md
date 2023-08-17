# Azure PowerShell AutoRest Configuration

> Values
``` yaml
azure: true
powershell: true
help-link-prefix: https://learn.microsoft.com/powershell/module/
license-header: MICROSOFT_MIT_NO_VERSION
pwsh-license-header: MICROSOFT_APACHE_NO_VERSION
branch: main
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

> Exclude some properties in table view
``` yaml
# For a specific module, we could override this configuration by setting default-exclude-tableview-properties to false in readme.md of that module.
default-exclude-tableview-properties: true
```
``` yaml $(default-exclude-tableview-properties)
exclude-tableview-properties:
  - Id
  - Type
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
