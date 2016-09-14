---
external help file: AzureRM.Bootstrapper-help.xml
online version: 
schema: 2.0.0
---

# About Version Profiles

Different concrete instances of Azure (AzureCloud, AzureChinaCloud, AzureGermanCloud, AzureUSGovernmentCloud, AzureStack) may have different versions of Azure services installed, with different capabilities. Azure Version Profiles provide a mechanism for managing these version differences.  Each Azure instance has a discoverable set of supported version profiles.  A user can select a version profile supported by the instances of Azure they target, and this version profile corresponds to versions of the Azure PowerShell modules. Users cna then select these Azure PowerShell module versions and be confident that their scripts will work when targeting those Azure instances.

The AzureRM.Bootstrapper module provides cmdlets to discover, acquire, and use modules that are appropriate for the azure version profile you are targeting.

You can also use Tags in the AzureRM modules to discover profile information for each module version.  Tags for a Profile use the form ```VersionProfile:2015-05```

# Finding appropriate version profiles

Use the ```Get-AzureRMVersionProfile``` cmdlet to discover availabel profile versions, and profile versions supported by an Azure instance.

```Get-AzureRmProfile -ListAvailable``` lists all available version profiles.

```Get-AzureRMProfile -Environment AzureChinaCloud``` lists the profiles supported by the Azure China cloud.

```Get-AzureRMProfile -Endpoint https://manage.myazurestackinstance.com``` lists the profiles supported by the azure instance at the given endpoint

## Targeting a concrete Azure instance

```Get-AzureRMProfile -Environment AzureChinaCloud``` lists the profiles supported by the Azure China cloud.

Use ```Use-AzureRmProfile -Profile 2015-05``` to install and load cmdlets for one of the listed profiles.

```Get-AzureRMProfile -Endpoint https://manage.myazurestackinstance.com``` lists the profiles supported by the azure instance at the 

## Targeting all Azure Instances

```Get-AzureRMProfile -Common``` lists the profiles that are supported by all Azure endpoints

Use ```Use-AzureRmProfile -Profile 2015-05``` to install and load cmdlets for one of the listed profiles.

## Targeting the Latest Stable Features

```Get-AzureRMProfile -Latest``` lists the latest profile supported by any Azure instance

Use ```Use-AzureRmProfile -Profile Latest``` to install and load cmdlets for one of the listed profiles.

## Targeting the latest preview features

Some very new Azure features may not be included in any Azure Profile.  To access these features, Install and Load the latest version of the associated Azure module.

To load the latest version of Compute cmdlets, use:
```Install-Module AzureRM.Compute```
```Import-Module AzureRM.Compute```

# Using a Version Profile in a PowerShell Session

The AzureRM bootstrapper uses the PowerShell Gallery to install and load needed modules when you want to target a specific version profile.

## Acquire and Load All Azure modules using the BootStrapper

```
Use-AzureRmProfile -Profile 2015-05 -Force
```

Checks if the modules associated with the ```2015-05``` profile are installed in the current scope, downloads and installs the modules if necessary, and then loads the modules in the current session.  You must open a new PowerShell session to target a different version profile.  Using the ```Force``` parameter installs the necessary module swithout prompting.

## Acquire and Load Selected Azure modules using the Bootstrapper

```
Use-AzureRmProfile -Profile 2015-05 -Module Compute, Storage, Network
```

Checks if the AzureRM.Compute, AzureRM.Storage, and AzureRM.Network modules associated with the ```2015-05``` profile are installed in the current scope, downloads and installs the modules if necessary, and then loads the modules in the current session.  You must open a new PowerShell session to target a different module.

## Acquire and Load Modules using PowerShellGet

```
Find-Module -Name AzureRM -Tags "Profile:2015-05" | Install-Module
```

Downloads the AzureRM modules associated with version Profile ```2015-05```

# Switching Between Version Profiles

To switch between version profiles on a machine, in a new PowerShell window, execute the following cmdlet:

```
Use-AzureRmProfile -Profile 2015-05
```

This loads the modules associated with the ```2015-05``` profile in the current session.  You must open a new PowerShell session to target a different version profile.  

# Setting the Default Version Profile for all PowerShell sessions

# Updating and Removing Profiles
