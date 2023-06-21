# Custom
This directory contains custom implementation for non-generated cmdlets for the `Az.NetworkSecurityPerimeter` module. Both scripts (`.ps1`) and C# files (`.cs`) can be implemented here. They will be used during the build process in `build-module.ps1`, and create cmdlets into the `..\exports` folder. The only generated file into this folder is the `Az.NetworkSecurityPerimeter.custom.psm1`. This file should not be modified.

## Info
- Modifiable: yes
- Generated: partial
- Committed: yes
- Packaged: yes

## Details
For `Az.NetworkSecurityPerimeter` to use custom cmdlets, it does this two different ways. We **highly recommend** creating script cmdlets, as they are easier to write and allow access to the other exported cmdlets. C# cmdlets *cannot access exported cmdlets*.

For C# cmdlets, they are compiled with the rest of the generated low-level cmdlets into the `./bin/Az.NetworkSecurityPerimeter.private.dll`. The names of the cmdlets (methods) and files must follow the `[cmdletName]_[variantName]` syntax used for generated cmdlets. The `variantName` is used as the `ParameterSetName`, so use something appropriate that doesn't clash with already created variant or parameter set names. You cannot use the `ParameterSetName` property in the `Parameter` attribute on C# cmdlets. Each cmdlet must be separated into variants using the same pattern as seen in the `generated/cmdlets` folder.

For script cmdlets, these are loaded via the `Az.NetworkSecurityPerimeter.custom.psm1`. Then, during the build process, this module is loaded and processed in the same manner as the C# cmdlets. The fundamental difference is the script cmdlets use the `ParameterSetName` attribute and C# cmdlets do not. To create a script cmdlet variant of a generated cmdlet, simply decorate all parameters in the script with the new `ParameterSetName` in the `Parameter` attribute. This will appropriately treat each parameter set as a separate variant when processed to be exported during the build.

## Purpose
This allows the modules to have cmdlets that were not defined in the REST specification. It also allows combining logic using generated cmdlets. This is a level of customization beyond what can be done using the [readme configuration options](https://github.com/Azure/autorest/blob/master/docs/powershell/options.md) that are currently available. These custom cmdlets are then referenced by the cmdlets created at build-time in the `..\exports` folder.

## Usage
The easiest way currently to start developing custom cmdlets is to copy an existing cmdlet. For C# cmdlets, copy one from the `generated/cmdlets` folder. For script cmdlets, build the project using `build-module.ps1` and copy one of the scripts from the `..\exports` folder. After that, if you want to add new parameter sets, follow the guidelines in the `Details` section above. For implementing a new cmdlets, at minimum, please keep these parameters:
- Break
- DefaultProfile
- HttpPipelineAppend
- HttpPipelinePrepend
- Proxy
- ProxyCredential
- ProxyUseDefaultCredentials

These provide functionality to our HTTP pipeline and other useful features. In script, you can forward these parameters using `$PSBoundParameters` to the other cmdlets you're calling within `Az.NetworkSecurityPerimeter`. For C#, follow the usage seen in the `ProcessRecordAsync` method.

### Attributes
For processing the cmdlets, we've created some additional attributes:
- `Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.DescriptionAttribute`
  - Used in C# cmdlets to provide a high-level description of the cmdlet. This is propagated to reference documentation via [help comments](https://docs.microsoft.com/powershell/module/microsoft.powershell.core/about/about_comment_based_help) in the exported scripts.
- `Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.DoNotExportAttribute`
  - Used in C# and script cmdlets to suppress creating an exported cmdlet at build-time. These cmdlets will *not be exposed* by `Az.NetworkSecurityPerimeter`.
- `Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.InternalExportAttribute`
  - Used in C# cmdlets to route exported cmdlets to the `..\internal`, which are *not exposed* by `Az.NetworkSecurityPerimeter`. For more information, see [README.md](..\internal/README.md) in the `..\internal` folder.
- `Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.ProfileAttribute`
  - Used in C# and script cmdlets to define which Azure profiles the cmdlet supports. This is only supported for Azure (`--azure`) modules.