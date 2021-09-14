<!-- region Generated -->
# Az.Logz
This directory contains the PowerShell module for the Logz service.

---
## Status
[![Az.Logz](https://img.shields.io/powershellgallery/v/Az.Logz.svg?style=flat-square&label=Az.Logz "Az.Logz")](https://www.powershellgallery.com/packages/Az.Logz/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.2.3 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.Logz`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# lock the commit
branch: b4f133f7c44af4189d61d35e34c5ed05fd9fa72b
require:
  - $(this-folder)/../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/logz/resource-manager/Microsoft.Logz/preview/2020-10-01-preview/logz.json

title: Logz
module-version: 0.1.0
subject-prefix: $(service-name)

identity-correction-for-post: true
resourcegroup-append: true

directive:
  # Remove cmdlets
  # Set-AzLogzSingleSignOn, Set-AzLogzSubAccountTagRule, Set-AzLogzTagRule
  - where:
      verb: Set
    remove: true
  # Change monitor sub resource  to Account for be consistent with the logz display in the azure portal
  - where:
      subject: ^Monitor(.*)
    set:
      subject: Account$1

  - where:
      subject: ^HostMonitor$
    set:
      subject: HostAccount

  - where:
      subject: ^SingleSignOn$
    set:
      subject: AccountSSOConfiguration

  - where:
      subject: ^TagRule$
    set:
      subject: AccountTagRule

  # Rename parameter
  - where:
      verb: Get
      subject: ^AccountMonitoredResource$|^AccountUserRole$|^AccountVMHost$|^AccountVMHost$|^AccountVMHostUpdate$|^AccountTagRule$|^HostAccount$
      parameter-name: MonitorName
    set:
      parameter-name: Name

  - where:
      subject: ^AccountSSOConfiguration$
      parameter-name: ConfigurationName
    set:
      parameter-name: Name

  - where:
      verb: Get
      subject: ^SubAccountMonitoredResource$|^SubAccountVMHost$|^SubAccountVMHostUpdate$|^HostSubAccount$
      parameter-name: SubAccountName
    set:
      parameter-name: Name
      
  # Remove variant
  # Remove List variant because parameters include Body <IVMHostUpdateRequest> parameter
  - where:
      verb: Get
      subject: ^AccountUserRole$|^AccountVMHostUpdate$|^SubAccountVMHostUpdate$
      variant: List
    remove: true

  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
      subject: ^Account$|^AccountSSOConfiguration$|^SubAccount$|^SubAccountTagRule$|^AccountTagRule$
    remove: true

  # Only name allowed for a tag rule is default.
  - where: 
      verb: Get
      subject: ^SubAccountTagRule$|^AccountTagRule$
      variant: List
    remove: true
  
  # Rename MonitorName to AccountName
  - where:
      parameter-name: MonitorName
    set:
      parameter-name: AccountName

  # Rename verb name
  # - where:
  #     verb: Invoke
  #     subject: ^HostMonitor$|^HostSubAccount$
  #   set:
  #     verb: Get

  # The service not planning to support it in the near future.
  - where:
      verb: Remove
      subject: TagRule
    remove: true
# Only name allowed for a tag rule is default.
  - where:
      verb: Get|New
      subject: ^SubAccountTagRule$|^AccountTagRule$
      parameter-name: RuleSetName
    hide: true
    set:
      default:
        script: '"default"'

  - where:
      model-name: LogzMonitorResource
    set:
      format-table:
        properties:
          - Name
          - MonitoringStatus
          - Location
  # Hide cmdlet for merge Get-AzLogzSubAccountMonitoredResource and Get-AzLogzSubAccountMonitoredResource into Get-AzLogzAccountMonitoredResource
  - where:
      verb: Get
      subject: ^AccountMonitoredResource$|^SubAccountMonitoredResource$
    hide: true

  - model-cmdlet:
      - VMResources
      # Comment this modle after generated cmdlet then add support ArgumentCompleter functioan for Action parameter.
      # - FilteringTag
```
