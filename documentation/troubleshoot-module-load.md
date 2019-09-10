# Troubleshooting Module Loading With Azure PowerShell

## Potential Incompatibilities

Azure PowerShell consists of multiple modules, each of which has a dependency on specific version of the central authentication module 'Az.Accounts'. If all versions of Azure PowerShell modules are kept up to date, and all are installed to the same scope, there should never be any incompatibility issues.

However, if some Azure PowerShell modules on a user's machine are updated while others or not, or if modules are installed to different scopes, or if an older version of the Az.Accounts module is imported in the current PowerShell session, then incompatibilities can occur. This document describes how to determine if there is a potential module incompatibility on a user machine, and how to resolve the incompatibility, including the following potential problems:

- [Prompt for Login when a cmdlet is executed after a previous login](#symptom-prompt-for-login-when-a-cmdlet-is-executed-after-a-previous-login)
- [Error when loading an Azure PowerShell module](#symptom-error-when-importing-an-azure-powershell-module)

## Symptom: Cannot load Az modules in Windows PowerShell

The Az modules are built against .NET Standard. This will cause them to fail in Windows PowerShell if a certain .NET Framework version is not installed. Here is an example error of this kind:

```powershell
Connect-AzAccount : The 'Connect-AzAccount' command was found in the module 'Az.Accounts', but the module could not be loaded. For more information, run 'Import-Module Az.Profile'.
At line:1 char:1
+ Connect-AzAccount
+ ~~~~~~~~~~~~~~~~~
    + CategoryInfo          : ObjectNotFound: (Connect-AzAccount:String) [], CommandNotFoundException
    + FullyQualifiedErrorId : CouldNotAutoloadMatchingModule
```

Or, you'd see an error like this when using `Import-Module`:
```powershell
Import-Module : The following error occurred while loading the extended type data file: , C:\Program Files\WindowsPowerShell\Modules\Az.Accounts\1.0.0\Microsoft.Azure.Commands.Profile.types.ps1xml(85) : Error: Unable
to find type [Microsoft.Azure.Commands.Profile.Models.AzureContextConverter].

At line:1 char:1
+ Import-Module Az.Accounts
+ ~~~~~~~~~~~~~~~~~~~~~~~~
    + CategoryInfo          : InvalidOperation: (:) [Import-Module], RuntimeException
    + FullyQualifiedErrorId : FormatXmlUpdateException,Microsoft.PowerShell.Commands.ImportModuleCommand
```

## Reason: Missing .NET Framework 4.7.2 or greater

If you are receiving type loading errors when trying to import/run Az modules in Windows PowerShell, you'll need to install [.NET Framework 4.7.2](https://dotnet.microsoft.com/download) or greater. This is required as Windows PowerShell does not natively support .NET Standard.

You can also avoid this issue by using [PowerShell Core](https://github.com/PowerShell/PowerShell/releases/latest). PowerShell Core natively supports .NET Standard assemblies. PowerShell Core also works cross platform, so Linux and Mac can use Az modules in PowerShell Core.

## Symptom: Prompt for Login When a Cmdlet is Executed After a Previous Login

After logging in, and executing a cmdlet, an error like the following is displayed, prompting for a second login:

```powershell
PS C:\> Get-AzResourceGroup
Get-AzResourceGroup : Run Connect-AzAccount to login.
At line:1 char:1
+ Get-AzResourceGroup
+ ~~~~~~~~~~~~~~~~~~~~~~~~
    + CategoryInfo          : CloseError: (:) [Get-AzResourceGroup], PSInvalidOperationException
    + FullyQualifiedErrorId : Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.GetAzureResourceGroupCmd
   let
```

### Potential Reason 1: Older Version Stored in User or Global Scope

PowerShell allows installing multiple versions of modules. Normally, PowerShell will load the latest version of a module unless specifically instructed to load a specific version by using `Import-Module -RequiredVersion <version>`. However, if modules are installed in multiple directories of the `PSModulePath`, then the results can be unexpected. When PowerShell searches for a module in the module path, it will return the latest version stored in the earliest path component where the module appears, even if a later version of the module is installed in a subsequent directory in the PSModulePath.

For example, if the PSModulePath contains directory `A` followed by directory `B`, and if Directory `A` contains version 1 of a module, and Directory `B` contains version 2 of the module, PowerShell will *always* load version 1, unless the entire path to the later module in directory `B` is provided when importing the module.

To determine if this problem occurs on your machine, run `Get-Module -ListAvailable` and check for duplicate entries for Az.Accounts in different directories in the `PSModulePath`. For example:

```powershell
c:\> Get-Module -ListAvailable

    Directory: C:\Users\UserName\Documents\PowerShell\Modules


ModuleType Version    Name                                ExportedCommands
---------- -------    ----                                ----------------
Script     0.7.0      Az.Accounts                         {Disable-AzDataCollection, Disable-AzContextAuto...


    Directory: C:\Program Files\PowerShell\Modules


ModuleType Version    Name                                ExportedCommands
---------- -------    ----                                ----------------
Script     1.0.0      Az.Accounts                         {Disable-AzDataCollection, Disable-AzContextAuto...

```

In this case, the earlier version of Az.Accounts (0.7.0) will *always* be loaded because the directory containing this version appears first in the module path.  This means that newer versions of Azure PowerShell modules will be unable to use the authentication provided when logging in using the cmdlets from this module.  IN other words, logging in using Az.Accounts version 0.7.0 will not provide authentication for modules that depend on a later version of Az.Accounts (like 0.7.1).

To resolve this problem, simply remove all versions of Azure PowerShell cmdlets not in the global scope `%ProgramFiles%\PowerShell\Modules`.  You can remove modules by physically removing the module directory (for example `C:\Users\<myuser>\Documents\PowerShell\Modules\Az.Accounts`).

### Potential Reason 2: Azure/AzureRM installed side-by-side with Az

Azure and AzureRM, our prior Azure PowerShell modules, cannot load **in the same PowerShell session** as the Az modules. Here an example of what you might see when you run `Get-Module` if both AzureRM and Az are in the same PowerShell session:

```powershell
c:\> Get-Module

ModuleType Version    Name                                ExportedCommands
---------- -------    ----                                ----------------
Script     1.0.0      Az.Accounts                         {Disable-AzDataCollection, Disable-AzContextAuto...
Script     5.8.2      AzureRM.profile                     {Disable-AzureRmDataCollection, Disable-AzureRmContextAuto...

```

To remedy, open a new PowerShell session and run `Import-Module Az`. This will cause the Az modules to be loaded into the session. It is preferred to use the `Az` prefix for the cmdlets (such as `Connect-AzAccount`). However, if you need to use the Azure/AzureRm prefix, then run `Enable-AzureRmAlias`. This will use the Az cmdlets with aliases to the Azure/AzureRm prefixes.

Similarly, if you want to use the Azure/AzureRM cmdlets, run `Import-Module Azure` or `Import-Module AzureRM` in a new PowerShell session. As long as you don't use **any Az prefixed cmdlets**, the session will only contain Azure and AzureRM cmdlets. It is highly recommended you **do not mix usage of Az and Azure/AzureRM prefixed cmdlets**. This may inadvertently load modules from Az or Azure/AzureRM, which can potentially cause issues.

If you do not need to use Azure/AzureRM, it is **highly recommended** that you uninstall Azure/AzureRM. To do so, use `Uninstall-Module Azure` or `Uninstall-Module AzureRM` respectively.

## Symptom: Error when Importing an Azure PowerShell module

When importing an Azure PowerShell module into the current PowerShell Session, you see a message like the following:

```powershell
PS C:\WINDOWS\system32> Import-Module Az.Compute
C:\Program Files\PowerShell\Modules\Az.Compute\1.0.0\Az.Compute.psm1 : This module requires
Az.Accounts version 1.0.0. An earlier version of Az.Accounts is imported in the current PowerShell session. Please
open a new session before importing this module. This error could indicate that multiple incompatible versions of the
Azure PowerShell cmdlets are installed on your system. Please see aka.ms/azps-version-error for troubleshooting
information.
At line:1 char:1
+ Import-Module Az.Compute
+ ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    + CategoryInfo          : NotSpecified: (:) [Write-Error], WriteErrorException
    + FullyQualifiedErrorId : Microsoft.PowerShell.Commands.WriteErrorException,Az.Compute.psm1

Import-Module : The module to process 'Az.Compute.psm1', listed in field 'ModuleToProcess/RootModule' of module
manifest 'C:\Program Files\PowerShell\Modules\Az.Compute\1.0.0\Az.Compute.psd1' was not processed
because no valid module was found in any module directory.
At line:1 char:1
+ Import-Module Az.Compute
+ ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    + CategoryInfo          : ResourceUnavailable: (Az.Compute:String) [Import-Module], PSInvalidOperationExcepti
   on
    + FullyQualifiedErrorId : Modules_ModuleFileNotFound,Microsoft.PowerShell.Commands.ImportModuleCommand
```

###  Reason: Older Version of Az.Accounts Loaded in Session

If an existing PowerShell session has loaded a version of Az.Accounts, then that version cannot be replaced with an updated version. If you receive an error like the one mentioned above, you can determine if this is the issue by looking at the currently imported modules using `Get-Module`:

```powershell
PS C:\WINDOWS\system32> Get-Module

ModuleType Version    Name                                ExportedCommands
---------- -------    ----                                ----------------
Script     1.0.0      Az.Accounts                         {Add-AzAccount, Add-AzEnvironment, Clear-Az...
Manifest   3.1.0.0    Microsoft.PowerShell.Utility        {Add-Member, Add-Type, Clear-Variable, Compare-Object...}
Script     1.2        PSReadline                          {Get-PSReadlineKeyHandler, Get-PSReadlineOption, Remove-PS...

```

If you see a version of Az.Accounts installed in the session, you can resolve this issue, by ensuring that all Az modules are up to date as shown [above](#potential-reason-1-older-version-stored-in-user-or-global-scope) and closing the PowerShell session.

## Why Are Incompatibilities Possible

Azure PowerShell is a set of binary modules, meaning that cmdlets are defined and implemented in .NET Standard code. PowerShell loads cmdlet assemblies into a single AppDomain, and these assemblies cannot be unloaded, even if the module is removed. Therefore, a module assembly and all its dependent assemblies remain loaded in the PowerShell session once it is imported until the PowerShell session is closed. Additionally, the types defined in a .NET Standard assembly are strongly tied to the assembly version, so that the types from version `A` and version `B` of the same assembly will appear as different types in the PowerShell session. When these types are used in common by multiple assemblies (as in the authentication types in Az.Accounts), then the types that are meant to be common are actually different for each module version. This causes problems when authentication information is instantiated using types from version `X` of Az.Accounts, but an assembly requires version `Y` of these types.

This underlying problem is solved in Az by requiring all authentication types used by the modules to be fully backward compatible.

### Newtonsoft.Json versions per PowerShell edition

The library `Newtonsoft.Json` is used throughout our cmdlets to handle JSON information. However, we do not have control of the version of this library that is loaded in PowerShell. To troubleshoot serialization issues, here is a table of the versions of `Newtonsoft.Json` that are loaded by the various editions of PowerShell.

| | Windows PowerShell 5.1 | PowerShell Core 6.0 | PowerShell Core 6.1 | PowerShell Core 6.2
| - | - | - | - | - |
| **Newtonsoft.Json** | 6.0.8 | 10.0.3 | 11.0.2 | 12.0.1
