# Azure PowerShell AutoRest Configuration

> Values
``` yaml
azure: true
powershell: true
branch: azs
repo: https://github.com/bganapa/azure-rest-api-specs/tree/$(branch)
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
  - where:
      subject: Operation
    hide: true
  - where:
      parameter-name: SubscriptionId
    set:
      default:
        script: '(Get-AzContext).Subscription.Id'
  - where:
      parameter-name: Location
    set:
      default:
        script: '(Get-AzLocation)[0].Location'
  - where:
      parameter-name: ResourceName
    set:
      parameter-name: Name
```