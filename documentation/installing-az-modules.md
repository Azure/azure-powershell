# Installing `Az` Modules

## Overview

By default, modules are installed from the [PowerShell Gallery](https://www.powershellgallery.com/), which is the central repository for accessing published PowerShell modules (equivalent to NuGet for .NET, npm for JavaScript, etc.). With the [`Install-Module`](https://learn.microsoft.com/en-us/powershell/module/powershellget/install-module) cmdlet, users can specify which modules they want to install; in addition, users can provide the `-Repository` parameter to specify which repository they want to install modules from (if this parameter isn't provided, then the cmdlet defaults to using PowerShell Gallery).

## Removing Modules

In some cases, existing `Az` modules will need to be removed before a new version can be installed. Since the `Uninstall-Module` cmdlet does not currently remove modules and their dependencies, users will need to manually delete the folders where the modules were installed to.

To figure out if you have any `Az` modules currently installed, as well as the location they are found, use the following command:

```
Get-Module -Name Az* -ListAvailable
```

This command will list all modules installed on your machine that are found in your `$env:PSModulePath`. Deleting the corresponding `Az.*` folders in the file explorer will remove these modules from your machine.

## Registering Repositories

In some cases, users will need to install modules from a different repository than the PowerShell Gallery -- this can be a new endpoint, or even a local folder containing `.nupkg` files. In either case, the [`Register-PSRepository`](https://learn.microsoft.com/en-us/powershell/module/powershellget/register-psrepository) cmdlet should be used to create a new local repository that can be used to install modules from.

Below is an example of registering a new repository from a local folder containing `.nupkg` files:

```
Register-PSRepository -Name "{{repository_name}}" -SourceLocation "{{folder_with_nupkg_files}}" -PackageManagementProvider NuGet -InstallationPolicy Trusted
```

### Registering the Test Gallery

Before a module is published to the PowerShell Gallery, it must first be published to the [Test Gallery](https://www.poshtestgallery.com/) to ensure there are no problems during the publishing and installation process. If you ever need to use this gallery for testing an installation, first register it by running the following command:

```
Register-PSRepository -Name TestGallery -SourceLocation https://poshtestgallery.com/api/v2 -PackageManagementProvider NuGet -InstallationPolicy
```

Modules can then be installed from this gallery by providing "TestGallery" to the `-Repository` parameter for the `Install-Module` cmdlet.

## Installing Modules

To install a module from the PowerShell Gallery, run the following command:

```
Install-Module -Name "{{module_name}}"
```

To install a module from a specific repository, run the following command:

```
Install-Module -Name "{{module_name}}" -Repository "{{repository_name}}"
```

### Installing `Az` Modules

To install the latest stable `Az` modules from the PowerShell Gallery, run the following command:

```
Install-Module -Name Az
```

To install a specific `Az` module from the PowerShell Gallery, run the following command:

```
Install-Module -Name Az.{{service}}
```

To install a preview version of a specific `Az` module, run the following command:

```
Install-Module -Name Az.{{service}} -RequiredVersion {{version}} -AllowPrelease
```

_Note_: to install preview versions of modules, version 1.6.0 or greater of the `PowerShellGet` module will be needed. Users can run the following command to get the latest version of this module:

```
Install-Module -Name PowerShellGet -Force
```

Full documentation around installing the `Az` module can be found in the [_Install the Azure PowerShell module_](https://learn.microsoft.com/en-us/powershell/azure/install-az-ps) article.