# Internal
This directory contains a module to handle *internal only* cmdlets. Cmdlets that you **hide** in configuration are created here. For more information on hiding, see [cmdlet hiding](https://github.com/Azure/autorest.powershell/blob/main/docs/directives.md#cmdlet-hiding-exportation-suppression). The cmdlets in this directory are generated at **build-time**. Do not put any custom code, files, cmdlets, etc. into this directory. Please use `..\custom` for all custom implementation.

## Info
- Modifiable: no
- Generated: all
- Committed: no
- Packaged: yes

## Details
The `Az.ComputeSchedule.internal.psm1` file is generated to this folder. This module file handles the hidden cmdlets. These cmdlets will not be exported by `Az.ComputeSchedule`. Instead, this sub-module is imported by the `..\custom\Az.ComputeSchedule.custom.psm1` module, allowing you to use hidden cmdlets in your custom, exposed cmdlets. To call these cmdlets in your custom scripts, simply use [module-qualified calls](https://learn.microsoft.com/powershell/module/microsoft.powershell.core/about/about_command_precedence?view=powershell-6#qualified-names). For example, `Az.ComputeSchedule.internal\Get-Example` would call an internal cmdlet named `Get-Example`.

## Purpose
This allows you to include REST specifications for services that you *do not wish to expose from your module*, but simply want to call within custom cmdlets. For example, if you want to make a custom cmdlet that uses `Storage` services, you could include a simplified `Storage` REST specification that has only the operations you need. When you run the generator and build this module, note the generated `Storage` cmdlets. Then, in your readme configuration, use [cmdlet hiding](https://github.com/Azure/autorest/blob/master/docs/powershell/options.md#cmdlet-hiding-exportation-suppression) on the `Storage` cmdlets and they will *only be exposed to the custom cmdlets* you want to write, and not be exported as part of `Az.ComputeSchedule`.
