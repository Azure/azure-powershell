# Troubleshooting Module Version Incompatibilities With Azure PowerShell

Azure PowerShell consists of multiple modules, each of which has a dependency on specific version of the central authentication module 'Az.Profile'. If all versions of Azure PowerShell modules are kept up to date, and all are installed to the same scope, there should never be any incompatibility issues.

However, if some Azure PowerShell modules on a user's machine are updated while others or not, or if modules are installed to different scopes, or if an older version of the Az.Profile module is imported in the current PowerShell session, then incompatibilities can occur.  This document describes how to determine if there is a potential module incompatibility on a user machine, and how to resolve the incompatibility, including the following potential problems:

- [Prompt for Login when a cmdlet is executed after a previous login](#symptom-prompt-for-login-when-a-cmdlet-is-executed-after-a-previous-login)
- [Error when loading an Azure PowerShell module](#symptom-error-when-importing-an-azure-powershell-module)

## Symptom: Prompt for Login When a Cmdlet is Executed After a Previous Login

After logging in, and executing a cmdlet, an error like the following is displayed, prompting for a second login:

```powershell
PS C:\> Get-AzResourceGroup
Get-AzResourceGroup : Run Login-AzAccount to login.
At line:1 char:1
+ Get-AzResourceGroup
+ ~~~~~~~~~~~~~~~~~~~~~~~~
    + CategoryInfo          : CloseError: (:) [Get-AzResourceGroup], PSInvalidOperationException
    + FullyQualifiedErrorId : Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.GetAzureResourceGroupCmd
   let
```

### Potential Reason 1: Older Version Stored in User or Global Scope

PowerShell allows installing multiple versions of modules.  Normally, PowerShell will load the latest version of a module unless specifically instructed to load a specific version by using ```Import-Module -RequiredVersion <version>```. However, if modules are installed in multiple directories of the ```PSModulePath```, then the results can be unexpected.  When PowerShell searches for a module in the module path, it will return the latest version stored in the earliest path component where the module appears, even if a later version of the module is installed in a subsequent directory in the PSModulePath.

For example, if the PSModulePath contains directory A followed by directory B, and if Directory A contains version 1 of a module, and Directory B contains version 2 of the module, PowerShell will *always* load version 1, unless the entire path to the later module in directory B is provided when importing the module.

To determine if this problem occurs on your machine, run ```Get-Module -ListAvailable``` and check for duplicate entries for Az.Profile in different directories in the ```PSModulePath```.  For example:

```powershell
c:\> Get-Module -ListAvailable

    Directory: C:\Users\UserName\Documents\WindowsPowerShell\Modules


ModuleType Version    Name                                ExportedCommands
---------- -------    ----                                ----------------
Script     3.4.0      Az.profile                     {Disable-AzDataCollection, Disable-AzContextAuto...


    Directory: C:\Program Files\WindowsPowerShell\Modules


ModuleType Version    Name                                ExportedCommands
---------- -------    ----                                ----------------
Script     4.0.0      Az.profile                     {Disable-AzDataCollection, Disable-AzContextAuto...

```

In this case, the earlier version of Az.Profile (3.4.0) will *always* be loaded because the directory containing this version appears first in the module path.  This means that newer versions of Azure PowerShell modules will be unable to use the authentication provided when logging in using the cmdlets from this module.  IN other words, logging in using Az.Profile version 3.4.0 will not provide authentication for modules that depend on a  later version of Az.Profile (like 3.4.1).

To resolve this problem, simply remove all versions of Azure PowerShell cmdlets not in the global scope ```%ProgramFiles%\WindowsPowerShell\Modules```.  You can remove modules by physically removing the module directory (for example ```c:\users\<myuser>\Documents\WindowsPowerShell\Modules\Az.Profile```).

### Potential Reason 2: Older / Newer version of Azure Module Installed

Additionally, because the Azure and Az modules are installed separately, they are not always updated at the same time.  If the 'Azure' module is updated without updating any installed Az modules, then a version of Az.profile that is compatible with the new 'Azure' module, but not compatible with the older 'Az' modules may be loaded by default, and authentication will not work for Az modules.

To detect this problem, run ```Get-Module -ListAvailable``` and look for multiple versions of ```Azure``` and ```Az.Profile``` in the same directory in the module path, but fewer versions of other Az Modules.

For example:

```
PS C:\> Get-Module -ListAvailable

PS C:\Users\markcowl> get-module -ListAvailable


    Directory: C:\Program Files\WindowsPowerShell\Modules


ModuleType Version    Name                                ExportedCommands
---------- -------    ----                                ----------------
Script     5.0.0      Azure                               {Add-AzureAccount, Set-AzureSubscription, New...
Script     4.4.1      Azure                               {Add-AzureAccount, Set-AzureSubscription, New...
Script     3.4.1      Az.Compute                     {Remove-AzAvailabilitySet, Get-AzAvailabilitySet...
Script     4.0.0      Az.profile                     {Disable-AzDataCollection, Disable-AzContextAuto...
Script     3.4.1      Az.profile                     {Disable-AzDataCollection, Disable-AzContextAuto...
```

As shown above, the 'Azure' module was updated without updating Az.Compute, resulting in log in problems when using compute cmdlets.

To resolve the issues, update all Az modules (for example ```Update-Module Az.Compute```), or remove the later versions of 'Azure'.

Naturally, this problem can occur when any installed Azure PowerShell module is updated without updating others.

Note that this problem is permanently resolved staring with version 5.0.0 of Azure PowerShell.  Any version of Azure PowerShell modules after this version my be independently updated without updating all installed Azure PowerShell modules.

## Symptom: Error when Importing an Azure PowerShell module

When importing an Azure PowerShell module into the current PowerShell Session, you see a message like the following:

```powershell
PS C:\WINDOWS\system32> Import-Module Az.Compute
C:\Program Files\WindowsPowerShell\Modules\Az.Compute\4.0.0\Az.Compute.psm1 : This module requires
Az.Profile version 4.0.0. An earlier version of Az.Profile is imported in the current PowerShell session. Please
open a new session before importing this module. This error could indicate that multiple incompatible versions of the
Azure PowerShell cmdlets are installed on your system. Please see aka.ms/azps-version-error for troubleshooting
information.
At line:1 char:1
+ Import-Module Az.Compute
+ ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    + CategoryInfo          : NotSpecified: (:) [Write-Error], WriteErrorException
    + FullyQualifiedErrorId : Microsoft.PowerShell.Commands.WriteErrorException,Az.Compute.psm1

Import-Module : The module to process 'Az.Compute.psm1', listed in field 'ModuleToProcess/RootModule' of module
manifest 'C:\Program Files\WindowsPowerShell\Modules\Az.Compute\4.0.0\Az.Compute.psd1' was not processed
because no valid module was found in any module directory.
At line:1 char:1
+ Import-Module Az.Compute
+ ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    + CategoryInfo          : ResourceUnavailable: (Az.Compute:String) [Import-Module], PSInvalidOperationExcepti
   on
    + FullyQualifiedErrorId : Modules_ModuleFileNotFound,Microsoft.PowerShell.Commands.ImportModuleCommand
```

###  Reason: Older Version of Az.Profile Loaded in Session

If an existing PowerShell session has loaded a version of Az.Profile, then that version cannot be replaced with an updated version.  If you receive an error like the one mentioned above, you can determine if this is the issue by looking at the currently imported modules using ```Get-Module```:

```powershell
PS C:\WINDOWS\system32> Get-Module

ModuleType Version    Name                                ExportedCommands
---------- -------    ----                                ----------------
Script     3.4.1      Az.Profile                     {Add-AzAccount, Add-AzEnvironment, Clear-Az...
Manifest   3.1.0.0    Microsoft.PowerShell.Utility        {Add-Member, Add-Type, Clear-Variable, Compare-Object...}
Script     1.2        PSReadline                          {Get-PSReadlineKeyHandler, Get-PSReadlineOption, Remove-PS...

```

If you see a version of Az.Profile installed in the session, you can resolve this issue, by ensuring that all Az modules are up to date as shown [above](#potential-reason-1-older-version-stored-in-user-or-global-scope) and closing the PowerShell session.

## Why Are Incompatibilities Possible

Azure PowerShell is a set of binary modules, meaning that cmdlets are defined and implemented in .Net code.  PowerShell loads cmdlet assemblies into a single AppDomain, and these assemblies cannot be unloaded, even if the module is removed.  Therefore a module assembly and all its dependent assemblies remain loaded in the PowerShell session once it is imported until the PowerShell session is closed.  Additionally, the types defined in a .Net assembly are strongly tied to the assembly version, so that the types from version A and version B of the same assembly will appear as different types in the PowerShell session.  When these types are used in common by multiple assemblies (as in the authentication types in Az.Profile), then the types that are meant to be common are actually different for each module version.  This causes problems when authentication information is instantiated using types from version X of Az.Profile, but an assembly requires version Y of these types.

This underlying problem is resolved in version 5.0 of Az, as all authentication types used by the modules are assured to be fully backward compatible.