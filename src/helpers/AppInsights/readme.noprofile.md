<!-- region Generated -->
# Az.AppInsights
This directory contains the PowerShell module for the AppInsights service.

---
## Status
[![Az.AppInsights](https://img.shields.io/powershellgallery/v/Az.AppInsights.svg?style=flat-square&label=Az.AppInsights "Az.AppInsights")](https://www.powershellgallery.com/packages/Az.AppInsights/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 1.6.0 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.AppInsights`, see [how-to.md](how-to.md).
<!-- endregion -->

# Internal
This directory contains a module to handle *internal only* cmdlets. Cmdlets that you **hide** in configuration are created here. For more information on hiding, see [cmdlet hiding](https://github.com/Azure/autorest/blob/master/docs/powershell/options.md#cmdlet-hiding-exportation-suppression). The cmdlets in this directory are generated at **build-time**. Do not put any custom code, files, cmdlets, etc. into this directory. Please use `..\custom` for all custom implementation.

## Info
- Modifiable: no
- Generated: all
- Committed: no
- Packaged: yes

## Details
The `Az.Storage.internal.psm1` file is generated to this folder. This module file handles the hidden cmdlets. These cmdlets will not be exported by `Az.Storage`. Instead, this sub-module is imported by the `..\custom\Az.Storage.custom.psm1` module, allowing you to use hidden cmdlets in your custom, exposed cmdlets. To call these cmdlets in your custom scripts, simply use [module-qualified calls](https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_command_precedence?view=powershell-6#qualified-names). For example, `Az.Storage.internal\Get-Example` would call an internal cmdlet named `Get-Example`.

## Purpose
This allows you to include REST specifications for services that you *do not wish to expose from your module*, but simply want to call within custom cmdlets. For example, if you want to make a custom cmdlet that uses `Storage` services, you could include a simplified `Storage` REST specification that has only the operations you need. When you run the generator and build this module, note the generated `Storage` cmdlets. Then, in your readme configuration, use [cmdlet hiding](https://github.com/Azure/autorest/blob/master/docs/powershell/options.md#cmdlet-hiding-exportation-suppression) on the `Storage` cmdlets and they will *only be exposed to the custom cmdlets* you want to write, and not be exported as part of `Az.Storage`.

## Run Generation
In this directory, run AutoRest:
> `autorest`

---
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
#output-folder: .
#subject-prefix: ''
#title: AppInsights
#module-version: 4.0.0
require: 
  - $(this-folder)/../../readme.azure.noprofile.md
```

## Multi-API/Profile support for AutoRest v3 generators 

AutoRest V3 generators require the use of `--tag=all-api-versions` to select api files.

This block is updated by an automatic script. Edits may be lost!

``` yaml
apprepo: https://github.com/Azure/azure-rest-api-specs/blob/resource-hybrid-profile
# include the azure profile definitions from the standard location
appinsights: $(apprepo)/specification/applicationinsights/resource-manager

# all the input files across all versions
input-file:
  - $(appinsights)/Microsoft.Insights/stable/2015-05-01/componentApiKeys_API.json
  - $(appinsights)/Microsoft.Insights/stable/2015-05-01/components_API.json

subject-prefix: ''
```

# Directives
``` yaml
directive:
  - where:
      verb: Clear|Remove|Set
      subject: ^Component$
    remove: true
  - where:
      verb: Get
      subject: ^ComponentPurgeStatus$
    remove: true
  - where:
      verb: New|Remove
      subject: ^ApiKey$
    remove: true
  - where:
      verb: Update
      subject: ^ComponentTag$
    remove: true
  - where:
      subject: ^Component$
    set:
      subject: AppInsights
  - where:
      subject: ^ApiKey$
    set:
      subject: AppInsightsApiKey
  - where:
      verb: Get|New
      subject: ^AppInsights$
    hide: true
  - where:
      verb: Get
      subject: ^AppInsightsApiKey$
    hide: true
  - where:
      subject: ^AppInsights.*
    set:
      subject-prefix: ''
```
