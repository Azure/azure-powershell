# Azure PowerShell AutoRest Configuration

> Values
``` yaml
azure: true
powershell: true
branch: stackadmin
repo: https://github.com/Azure/azure-rest-api-specs/tree/$(branch)
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
prefix: Azs
module-name: $(prefix).$(service-name)
namespace: Microsoft.Azure.PowerShell.Cmdlets.$(service-name)
```

> Folders
``` yaml
clear-output-folder: true
output-folder: .
```

> Directives
``` yaml
directive:
    # Remove cmdlets for /operations call
  - where:
      subject: Operation
    remove: true
  - where:
      parameter-name: SubscriptionId
    set:
      default:
        script: '(Get-AzContext).Subscription.Id'
  - where:
      parameter-name: Location
    set:
      default:
        script: '(Get-AzLocation)[0].Name'
  - where:
      parameter-name: ResourceName
    set:
      parameter-name: Name
```