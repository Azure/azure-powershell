---
external help file: AzureRM.Bootstrapper-help.xml
online version: 
schema: 2.0.0
---

# About Version Profiles

Different concrete instances of Azure (AzureCloud, AzureChinaCloud, AzureGermanCloud, AzureUSGovernmentCloud, AzureStack) may have different versions of Azure services installed, with different capabilities. Azure Version Profiles provide a mechanism for managing these version differences.  Each Azure instance has a discoverable set of supported version profiles.  A user can select a version profile supported by the instances of Azure they target, and this version profile corresponds to versions of the Azure PowerShell modules. Users can then select these Azure PowerShell module versions and be confident that their scripts will work when targeting those Azure instances.

The AzureRM.Bootstrapper module provides cmdlets to discover, acquire, and use modules that are appropriate for the azure version profile you are targeting.

You can also use Tags in the AzureRM modules to discover profile information for each module version.  Tags for a Profile use the form ```VersionProfile:2017-03-09-profile```

# Finding appropriate version profiles

Use the ```Get-AzureRmProfile``` cmdlet to discover available profile versions, and profile versions supported by an Azure instance.

```Get-AzureRmProfile -ListAvailable``` lists all available version profiles.

Use ```Use-AzureRmProfile -Profile 2017-03-09-profile``` to install and load cmdlets for one of the listed profiles.

## Targeting all Azure Instances

```Get-AzureRmProfile``` lists the profiles that are currently installed on the machine.

Use ```Use-AzureRmProfile -Profile 2017-03-09-profile``` to install and load cmdlets for one of the listed profiles.

## Targeting the Latest Stable Features

Use ```Use-AzureRmProfile -Profile Latest``` to install and load cmdlets for one of the listed profiles.

# Using a Version Profile in a PowerShell Session

The AzureRM bootstrapper uses the PowerShell Gallery to install and load needed modules when you want to target a specific version profile.

## Acquire and Load All Azure modules using the BootStrapper

```
Use-AzureRmProfile -Profile 2017-03-09-profile -Force
```

Checks if the modules associated with the ```2017-03-09-profile``` profile are installed in the current scope, downloads and installs the modules if necessary, and then loads the modules in the current session.  You must open a new PowerShell session to target a different version profile.  Using the ```Force``` parameter installs the necessary modules without prompting.

## Acquire and Load Selected Azure modules using the Bootstrapper

```
Use-AzureRmProfile -Profile 2017-03-09-profile -Module AzureRM.Compute, AzureRM.Storage, AzureRM.Network
```

Checks if the AzureRM.Compute, AzureRM.Storage, and AzureRM.Network modules associated with the ```2017-03-09-profile``` profile are installed in the current scope, downloads and installs the modules if necessary, and then loads the modules in the current session.  You must open a new PowerShell session to target a different module.

# Switching Between Version Profiles

To switch between version profiles on a machine, in a new PowerShell window, execute the following cmdlet:

```
Use-AzureRmProfile -Profile 2017-03-09-profile
```

This loads the modules associated with the ```2017-03-09-profile``` profile in the current session.  You must open a new PowerShell session to target a different version profile.  

# Updating and Removing Profiles

To update a profile to the latest versions in that profile and import updated modules to the current session, execute the following cmdlet:

```
Update-AzureRmProfile -Profile '2016-09'
```

This checks if the latest versions of the module in profile ```2016-09``` are installed, if not prompts the user if it should be installed and imports them into the current session. This should always be executed in a new PowerShell session.

If you would like to update to the latest modules in a Profile and remove previously installed versions of the modules, use:

```
Update-AzureRmProfile -Profile '2016-09' -RemovePreviousVersions
```

