<!-- region Generated -->
# Az.PrometheusRuleGroups
This directory contains the PowerShell module for the PrometheusRuleGroups service.

---
## Status
[![Az.PrometheusRuleGroups](https://img.shields.io/powershellgallery/v/Az.PrometheusRuleGroups.svg?style=flat-square&label=Az.PrometheusRuleGroups "Az.PrometheusRuleGroups")](https://www.powershellgallery.com/packages/Az.PrometheusRuleGroups/)

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
For information on how to develop for `Az.PrometheusRuleGroups`, see [how-to.md](how-to.md).
<!-- endregion -->

---
## Generation Requirements
Use of the beta version of `autorest.powershell` generator requires the following:
- [NodeJS LTS](https://nodejs.org) (10.15.x LTS preferred)
  - **Note**: It *will not work* with Node < 10.x. Using 11.x builds may cause issues as they may introduce instability or breaking changes.
> If you want an easy way to install and update Node, [NVS - Node Version Switcher](../nodejs/installing-via-nvs.md) or [NVM - Node Version Manager](../nodejs/installing-via-nvm.md) is recommended.
- [AutoRest](https://aka.ms/autorest) v3 beta <br>`npm install -g autorest@autorest`<br>&nbsp;
- PowerShell 6.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g pwsh`<br>&nbsp;
- .NET Core SDK 2.0 or greater
  - If you don't have it installed, you can use the cross-platform npm package <br>`npm install -g dotnet-sdk-2.2`<br>&nbsp;

## Run Generation
In this directory, run AutoRest:
> `autorest-beta`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: fdf43f2fdacf17bd78c0621df44a5c024b61db82
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/alertsmanagement/resource-manager/Microsoft.AlertsManagement/stable/2023-03-01/PrometheusRuleGroups.json
  
module-version: 0.1.0
title: PrometheusRuleGroups
root-module-name: $(prefix).AlertsManagement
subject-prefix: ""
inlining-threshold: 100
resourcegroup-append: true
nested-object-to-string: true

directive:
    # Remove the unexpanded parameter set
    - where:
        variant: ^Create$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
      remove: true
    # Hide CreateViaIdentity for customization
    - where:
        variant: ^CreateViaIdentity$
      remove: true
    - where:
        variant: ^Create$
      remove: true
    - where:
        subject: PrometheuRuleGroup
      set: 
        subject: PrometheusRuleGroup
    - where:
        verb: Set
      hide: true
    - model-cmdlet:
        - PrometheusRule
        - PrometheusRuleGroupAction
    - where:
        model-name: PrometheusRuleGroupResource
      set:
        format-table:
          properties:
            - Name
            - Location
            - ClusterName
            - Enabled
    
```
