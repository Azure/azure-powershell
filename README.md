<meta name="google-site-verification" content="tZgbB2s-hTI0IePQQRCjHqL_Vf0j_XJmehXAHJerrn4" />

# ![AzureIcon] ![PowershellIcon] Microsoft Azure PowerShell

This repository contains PowerShell cmdlets for developers and administrators to develop, deploy, and manage Microsoft Azure applications.

Try it out in Azure Cloud Shell!

[![CloudShellIcon]][CloudShell]

## Modules
Below is a table containing our Azure PowerShell rollup module.

Description       | Module Name  | PowerShell Gallery Link
----------------- | ------------ | -----------------------
Azure PowerShell  | `Az`         | [![Az]][AzGallery]

For a full list of modules found in this repository, please see the [Azure PowerShell Modules][AzurePowerShelModules] document.

## Installation

### PowerShell Gallery

Run the following command in an elevated PowerShell session to install the rollup module for Azure PowerShell cmdlets:

```powershell
Install-Module -Name Az
```

This module runs on Windows PowerShell with [.NET Framework 4.7.2][DotNetFramework] or greater, or [PowerShell Core][PowerShellCore]. The `Az` module replaces `AzureRM`. You should not install `Az` side-by-side with `AzureRM`.

If you have an earlier version of the Azure PowerShell modules installed from the PowerShell Gallery and would like to update to the latest version, run the following commands in an elevated PowerShell session:

```powershell
Update-Module -Name Az
```

`Update-Module` installs the new version side-by-side with previous versions. It does not uninstall the previous versions.

For detailed instructions on installing Azure PowerShell, please refer to the [installation guide][InstallationGuide].

## Usage

### Log into Azure

To connect to Azure, use the [`Connect-AzAccount`][ConnectAzAccount] cmdlet:

```powershell
# Device Code login - Provides a link to sign into Azure via your web browser
Connect-AzAccount

# Service Principal login - Use a previously created service principal to log in
Connect-AzAccount -ServicePrincipal -ApplicationId 'http://my-app' -Credential $PSCredential -TenantId $TenantId
```

To log into a specific cloud (_AzureChinaCloud_, _AzureCloud_, _AzureGermanCloud_, _AzureUSGovernment_), use the `-Environment` parameter:

```powershell
# Specific cloud login - Logs into the Azure China cloud
Connect-AzAccount -Environment AzureChinaCloud
```

### Getting and setting your Azure PowerShell session context

A session context persists login information across Azure PowerShell modules and PowerShell instances. To view the context you are using in the current session, which contains the subscription and tenant, use the [`Get-AzContext`][GetAzContext] cmdlet:

```powershell
# Gets the Azure PowerShell context for the current PowerShell session
Get-AzContext

# Lists all available Azure PowerShell contexts in the current PowerShell session
Get-AzContext -ListAvailable
```

To get the subscriptions in a tenant, use the [`Get-AzSubscription`][GetAzSubscription] cmdlet:

```powershell
# Get all of the Azure subscriptions in your current Azure tenant
Get-AzSubscription

# Get all of the Azure subscriptions in a specific Azure tenant
Get-AzSubscription -TenantId $TenantId
```

To change the subscription that you are using for your current context, use the [`Set-AzContext`][SetAzContext] cmdlet:

```powershell
# Set the Azure PowerShell context to a specific Azure subscription
Set-AzContext -Subscription $SubscriptionName -Name 'MyContext'

# Set the Azure PowerShell context using piping
Get-AzSubscription -SubscriptionName $SubscriptionName | Set-AzContext -Name 'MyContext'
```

For details on Azure PowerShell contexts, see our [persisted credentials guide][PersistedCredentialsGuide].

### Discovering cmdlets

Use the `Get-Command` cmdlet to discover cmdlets within a specific module, or cmdlets that follow a specific search pattern:

```powershell
# List all cmdlets in the Az.Accounts module
Get-Command -Module Az.Accounts

# List all cmdlets that contain VirtualNetwork
Get-Command -Name '*VirtualNetwork*'

# List all cmdlets that contain VM in the Az.Compute module
Get-Command -Module Az.Compute -Name '*VM*'
```

### Cmdlet help and examples

To view the help content for a cmdlet, use the `Get-Help` cmdlet:

```powershell
# View the basic help content for Get-AzSubscription
Get-Help -Name Get-AzSubscription

# View the examples for Get-AzSubscription
Get-Help -Name Get-AzSubscription -Examples

# View the full help content for Get-AzSubscription
Get-Help -Name Get-AzSubscription -Full

# View the help content for Get-AzSubscription on https://learn.microsoft.com
Get-Help -Name Get-AzSubscription -Online
```

For detailed instructions on using Azure PowerShell, please refer to the [getting started guide][GettingStartedGuide].

## Reporting Issues and Feedback

### Issues

If you find any bugs when using the Azure PowerShell modules, please file an issue in our [GitHub issues][GitHubIssues] page. Please fill out the provided template with the appropriate information.

Alternatively, be sure to check out the [Azure Community Support](https://azure.microsoft.com/en-us/support/community/) if you have issues with the cmdlets or Azure services.

### Feedback

If there is a feature you would like to see in Azure PowerShell, please use the [`Send-Feedback`][SendFeedback] cmdlet, or file an issue in our [GitHub issues][GitHubIssues] page to provide the Azure PowerShell team direct feedback.

## Contribute Code

If you would like to become an active contributor to this project, please follow the instructions provided in [Microsoft Azure Projects Contribution Guidelines][ContributionGuidelines].

Additional information about contributing to this repository can be found in the [`CONTRIBUTING.md`][Contributing] document and the [_Azure PowerShell Developer Guide_][DeveloperGuide] document.

## Learn More

* [Microsoft Azure Documentation][MicrosoftAzureDocs]
* [PowerShell Documentation][PowerShellDocs]

---
_This project has adopted the [Microsoft Open Source Code of Conduct][CodeOfConduct]. For more information see the [Code of Conduct FAQ][CodeOfConductFaq] or contact [opencode@microsoft.com][OpenCodeEmail] with any additional questions or comments._

<!-- References -->

<!-- Local -->
[GitHubIssues]: https://github.com/Azure/azure-powershell/issues

[Contributing]: CONTRIBUTING.md

[AzureIcon]: documentation/images/MicrosoftAzure-32px.png
[PowershellIcon]: documentation/images/MicrosoftPowerShellCore-32px.png
[AzurePowerShelModules]: documentation/azure-powershell-modules.md
[DeveloperGuide]: documentation/development-docs/azure-powershell-developer-guide.md

<!-- External -->
[Az]: https://img.shields.io/powershellgallery/v/Az.svg?style=flat-square&label=Az
[AzGallery]: https://www.powershellgallery.com/packages/Az/

[DotNetFramework]: https://dotnet.microsoft.com/download/dotnet-framework-runtime
[PowerShellCore]: https://github.com/PowerShell/PowerShell/releases/latest

[CloudShell]: https://shell.azure.com/powershell
[CloudShellIcon]: https://shell.azure.com/images/launchcloudshell.png "Launch Azure Cloud Shell"

[ContributionGuidelines]: https://azure.github.io/guidelines/
[CodeOfConduct]: https://opensource.microsoft.com/codeofconduct/
[CodeOfConductFaq]: https://opensource.microsoft.com/codeofconduct/faq/
[OpenCodeEmail]: mailto:opencode@microsoft.com

<!-- Docs -->
[MicrosoftAzureDocs]: https://learn.microsoft.com/en-us/azure/
[PowerShellDocs]: https://learn.microsoft.com/en-us/powershell/

[InstallationGuide]: https://learn.microsoft.com/en-us/powershell/azure/install-az-ps
[GettingStartedGuide]: https://learn.microsoft.com/en-us/powershell/azure/get-started-azureps
[PersistedCredentialsGuide]: https://learn.microsoft.com/en-us/powershell/azure/context-persistence

[ConnectAzAccount]: https://learn.microsoft.com/en-us/powershell/module/az.accounts/connect-azaccount
[GetAzContext]: https://learn.microsoft.com/en-us/powershell/module/az.accounts/get-azcontext
[GetAzSubscription]: https://learn.microsoft.com/en-us/powershell/module/az.accounts/get-azsubscription
[SetAzContext]: https://learn.microsoft.com/en-us/powershell/module/az.accounts/set-azcontext
[SendFeedback]: https://learn.microsoft.com/en-us/powershell/module/az.accounts/send-feedback
