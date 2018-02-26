<meta name="google-site-verification" content="tZgbB2s-hTI0IePQQRCjHqL_Vf0j_XJmehXAHJerrn4" />

# Microsoft Azure PowerShell

This repository contains a set of PowerShell cmdlets for developers and administrators to develop, deploy and manage Microsoft Azure applications.

Take a test run now from Azure Cloud Shell! 

[![](https://shell.azure.com/images/launchcloudshell.png "Launch Azure Cloud Shell")](https://shell.azure.com/powershell) 


## Modules

Below is a table containing the various Azure PowerShell rollup modules found in this repository. For a full list of modules found in this repository, please see the [Azure PowerShell Modules](documentation/azure-powershell-modules.md) page.

| Description                                                     | Module Name       | PowerShell Gallery Link |
| --------------------------------------------------------------- | ----------------- | ----------------------- |
| Rollup Module for ARM Cmdlets                                   | `AzureRM`         | [![AzureRM](https://img.shields.io/powershellgallery/v/AzureRM.svg?style=flat-square&label=AzureRM)](https://www.powershellgallery.com/packages/AzureRM/) |
| Rollup Module for .NET Core Cmdlets                             | `AzureRM.Netcore` | [![AzureRM.Netcore](https://img.shields.io/powershellgallery/v/AzureRM.Netcore.svg?style=flat-square&label=AzureRM.Netcore)](https://www.powershellgallery.com/packages/AzureRM.Netcore/) |
| Rollup Module for Administrative Modules in Azure Stack         | `AzureStack`      | [![AzureStack](https://img.shields.io/powershellgallery/v/AzureStack.svg?style=flat-square&label=AzureStack)](https://www.powershellgallery.com/packages/AzureStack/) |
| Rollup Module for Service Management Cmdlets                  | `Azure`           | [![Azure](https://img.shields.io/powershellgallery/v/Azure.svg?style=flat-square&label=Azure)](https://www.powershellgallery.com/packages/Azure/) |

## Installation

For more detailed instructions on installing Azure PowerShell, please refer to the [installation guide](https://docs.microsoft.com/en-us/powershell/azure/install-azurerm-ps).

### PowerShell Gallery

Run the following command in an elevated PowerShell session to install the rollup module for Azure Resource Manager cmdlets:

```powershell
Install-Module -Name AzureRM
```

To install the module containing the legacy RDFE cmdlets, run the following command in an elevated PowerShell session:

```powershell
Install-Module -Name Azure
```

If you have an earlier version of the Azure PowerShell modules installed from the PowerShell Gallery and would like to update to the latest version, run the following commands in an elevated PowerShell session:

```powershell
# Update to the latest version of AzureRM
Update-Module -Name AzureRM

# Update to the latest version of Azure
Update-Module -Name Azure
```

### Web Platform Installer

Download and install the [Microsoft Web Platform Installer](https://www.microsoft.com/web/downloads/platform.aspx). Once installed, open the program and search for _Microsoft Azure PowerShell_. Click the _Add_ button followed by the _Install_ button at the bottom to begin the installation process.

## Usage

For more detailed instructions on using Azure PowerShell, please refer to the [getting started guide](https://docs.microsoft.com/en-us/powershell/azure/get-started-azureps).

### Log in to Azure

To connect to Azure, use the [`Connect-AzureRmAccount`](https://docs.microsoft.com/en-us/powershell/module/azurerm.profile/connect-azurermaccount) cmdlet.

```powershell
# Interactive login - you will get a dialog box asking for your Azure credentials
Connect-AzureRmAccount

# Non-interactive login - you will need to use a service principal
Connect-AzureRmAccount -ServicePrincipal -ApplicationId "http://my-app" -Credential $PSCredential -TenantId $TenantId
```

To log into a specific cloud (_AzureChinaCloud_, _AzureCloud_, _AzureGermanCloud_, _AzureUSGovernment_), use the `Environment` parameter:

```powershell
# Log into a specific cloud - in this case, the Azure China cloud
Connect-AzureRmAccount -Environment AzureChinaCloud
```

### Getting and setting your session context

To view the context you are using in the current session, which contains the subscription and tenant, use the [`Get-AzureRmContext`](https://docs.microsoft.com/en-us/powershell/module/azurerm.profile/get-azurermcontext) cmdlet:

```powershell
# Get the context you are currently using
Get-AzureRmContext

# List all available contexts in the current session
Get-AzureRmContext -ListAvailable
```

To get the subscriptions in a tenant, use the [`Get-AzureRmSubscription`](https://docs.microsoft.com/en-us/powershell/module/azurerm.profile/get-azurermsubscription) cmdlet:

```powershell
# Get all of the subscriptions in your current tenant
Get-AzureRmSubscription

# Get all of the subscriptions in a specific tenant
Get-AzureRmSubscription -TenantId $TenantId
```

To change the subscription that you are using for your current context, use the [`Set-AzureRmContext`]() cmdlet:

```powershell
# Set the context to a specific subscription
Set-AzureRmContext -Subscription $SubscriptionName -Name "MyContext"

# Set the context using piping
Get-AzureRmSubscription -SubscriptionName $SubscriptionName | Set-AzureRmContext -Name "MyContext"
```

### Discovering cmdlets

Use the `Get-Command` cmdlet to discover cmdlets within a specific module, or cmdlets that follow a specific search pattern:

```powershell
# View all cmdlets in the AzureRM.Profile module
Get-Command -Module AzureRM.Profile

# View all cmdlets that contain "VirtualNetwork"
Get-Command -Name "*VirtualNetwork*"

# View all cmdlets that contain "VM" in the AzureRM.Compute module
Get-Command -Module AzureRM.Compute -Name "*VM*"
```

### Cmdlet help and examples

To view the help content for a cmdlet, use the `Get-Help` cmdlet:

```powershell
# View the basic help content for Get-AzureRmSubscription
Get-Help -Name Get-AzureRmSubscription

# View the examples for Get-AzureRmSubscription
Get-Help -Name Get-AzureRmSubscription -Examples

# View the full help content for Get-AzureRmSubscription
Get-Help -Name Get-AzureRmSubscription -Full

# View the help content for Get-AzureRmSubscription on https://docs.microsoft.com
Get-Help -Name Get-AzureRmSubscription -Online
```

## Reporting Issues and Feedback

### Issues

If you find any bugs when using the Azure PowerShell modules, please file an issue [here](https://github.com/Azure/azure-powershell/issues), making sure to fill out the provided template with the appropriate information.

Alternatively, be sure to check out the [Azure Support Community](https://azure.microsoft.com/en-us/support/forums/) if you have trouble with any of the cmdlets or Azure services.

### Feedback

If there is a feature you would like to see in Azure PowerShell, please use the [`Send-Feedback`](https://docs.microsoft.com/en-us/powershell/module/azurerm.profile/send-feedback) cmdlet, or file an issue [here](https://github.com/Azure/azure-powershell/issues), to send the team direct feedback.

## Contribute Code

If you would like to become an active contributor to this project please follow the instructions provided in [Microsoft Azure Projects Contribution Guidelines](https://azure.github.io/guidelines/).

More information about contributing to this repo can be found in [CONTRIBUTING md](https://github.com/Azure/azure-powershell/blob/preview/CONTRIBUTING.md) and the [Azure PowerShell Developer Guide](https://github.com/Azure/azure-powershell/wiki/Azure-Powershell-Developer-Guide) folder.

## Learn More

* [Microsoft Azure Documentation](https://docs.microsoft.com/en-us/azure/)
* [PowerShell Documentation](https://docs.microsoft.com/en-us/powershell/)

---
_This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments._
