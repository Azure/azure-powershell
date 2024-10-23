<!-- region Generated -->
# Az.Logz
This directory contains the PowerShell module for the Logz service.

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
For information on how to develop for `Az.Logz`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
# lock the commit
commit: b4f133f7c44af4189d61d35e34c5ed05fd9fa72b
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/logz/resource-manager/Microsoft.Logz/preview/2020-10-01-preview/logz.json

title: Logz
module-version: 0.1.0
subject-prefix: $(service-name)

identity-correction-for-post: true
resourcegroup-append: true

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:
  # Remove cmdlets
  # Set-AzLogzSingleSignOn, Set-AzLogzSubAccountTagRule, Set-AzLogzTagRule
  - where:
      verb: Set
    remove: true

  - where:
      subject: ^SingleSignOn$
    set:
      subject: MonitorSSOConfiguration

  - where:
      subject: ^TagRule$
    set:
      subject: MonitorTagRule

  # Rename parameter
  - where:
      verb: Get
      subject: ^MonitorUserRole$|^MonitorVMHost$|^MonitorVMHost$|^MonitorVMHostUpdate$|^HostMonitor$
      parameter-name: MonitorName
    set:
      parameter-name: Name

  - where:
      parameter-name: LogzOrganizationProperty(.*)
    set:
      parameter-name: $1

  - where:
      parameter-name: PlanData(.*)
    set:
      parameter-name: Plan$1

  - where:
      parameter-name: PlanPlanDetail
    set:
      parameter-name: PlanDetail

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
      subject: ^MonitorUserRole$|^MonitorVMHostUpdate$|^SubAccountVMHostUpdate$
      variant: List
    remove: true

  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
      subject: ^Monitor$|^MonitorSSOConfiguration$|^SubAccount$|^SubAccountTagRule$|^MonitorTagRule$
    remove: true

  # Only name allowed for a tag rule is default.
  - where: 
      verb: Get
      subject: ^SubAccountTagRule$|^MonitorTagRule$|^MonitorSSOConfiguration$
      variant: List
    remove: true
  
  # The command set request to install or delete vm.
  - where:
      verb: Get
      subject: (.*)VMHostUpdate$
    set:
      verb: Update
      subject: $1VMHost
  - where: 
      verb: Update
      subject: (.*)VMHost$
      parameter-name: VMResourceId
    set:
      parameter-name: VMResource

  # Wait confirm from the service team.
  # - where:
  #     verb: Invoke
  #     subject: ^HostMonitor$|^HostSubAccount$
  #   set:
  #     verb: Get
    
# Only name allowed for a tag rule is default.
  - where:
      verb: Get|New|Remove
      subject: ^SubAccountTagRule$|^MonitorTagRule$
      parameter-name: RuleSetName
    hide: true
    set:
      default:
        script: '"default"'

# Only name allowed for a sso configuration is default.
  - where:
      verb: Get|New
      subject: MonitorSSOConfiguration
      parameter-name: ConfigurationName
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
  - where:
      model-name: LogzSingleSignOnResource
    set:
      format-table:
        properties:
          - Name
          - ProvisioningState
          - SingleSignOnState
          - SingleSignOnUrl
  - where:
      model-name: VMResources
    set:
      format-table:
        properties:
          - Id
  - where:
      model-name: MonitoringTagRules
    set:
      format-table:
        properties:
          - Name
          - ProvisioningState

# Hide cmdlet for merge Get-AzLogzMonitorMonitoredResource and Get-AzLogzSubAccountMonitoredResource into Get-AzLogzMonitorMonitoredResource
  - where:
      verb: Get
      subject: ^MonitorMonitoredResource$|^SubAccountMonitoredResource$
    hide: true

  - model-cmdlet:
      - VMResources
      # Comment this modle after generated cmdlet then add support ArgumentCompleter functioan for Action parameter.
      # - FilteringTag
```
