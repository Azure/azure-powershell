<meta name="google-site-verification" content="tZgbB2s-hTI0IePQQRCjHqL_Vf0j_XJmehXAHJerrn4" />

# ![AzureIcon] ![PowershellIcon] Microsoft Azure PowerShell

This repository contains PowerShell cmdlets for developers and administrators to develop, deploy,
administer, and manage Microsoft Azure resources.

The Az PowerShell module is preinstalled in [Azure Cloud Shell][AzureCloudShell].

## Modules

The following table contains a list of the Azure PowerShell rollup modules.

Description       | Module Name  | PowerShell Gallery Link
----------------- | ------------ | -----------------------
Azure PowerShell  | `Az`         | [![Az]][AzGallery]
Azure PowerShell with preview modules | `AzPreview`                             | [![AzPreview]][AzPreviewGallery]

For a complete list of the modules found in this repository, see
[Azure PowerShell Modules][AzurePowerShellModules].

## Installation

### PowerShell Gallery

Run the following command in a PowerShell session to install the Az PowerShell module:

```powershell
Install-Module -Name Az -Scope CurrentUser -Repository PSGallery -Force
```

[The latest version of PowerShell 7][PowerShellCore] is the recommended version of PowerShell for
use with the Az PowerShell module on all platforms including Windows, Linux, and macOS. This module
also runs on Windows PowerShell 5.1 with [.NET Framework 4.7.2][DotNetFramework] or higher.

The `Az` module replaces `AzureRM`. You should not install `Az` side-by-side with `AzureRM`.

If you have an earlier version of the Azure PowerShell module installed from the PowerShell Gallery
and would like to update to the latest version, run the following command in a PowerShell session:

```powershell
Update-Module -Name Az -Scope CurrentUser -Force
```

`Update-Module` installs the new version side-by-side with previous versions. It does not uninstall
the previous versions.

For more information on installing Azure PowerShell, see the
[installation guide][InstallationGuide].

## Usage

### Log into Azure

To connect to Azure, use the [`Connect-AzAccount`][ConnectAzAccount] cmdlet:

```powershell
# Opens a new browser window to log into your Azure account.
Connect-AzAccount

# Log in with a previously created service principal. Use the application ID as the username, and the secret as password.
$Credential = Get-Credential
Connect-AzAccount -ServicePrincipal -Credential $Credential -TenantId $TenantId
```

To log into a specific cloud (_AzureChinaCloud_, _AzureCloud_, _AzureUSGovernment_), use the
`Environment` parameter:

```powershell
# Log into a specific cloud, for example the Azure China cloud.
Connect-AzAccount -Environment AzureChinaCloud
```

### Session context

A session context persists login information across Azure PowerShell modules and PowerShell
instances. Use the [`Get-AzContext`][GetAzContext] cmdlet to view the context you are using in the
current session. The results contain the Azure tenant and subscription.

```powershell
# Get the Azure PowerShell context for the current PowerShell session
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

To change the subscription that you are using for your current context, use the
[`Set-AzContext`][SetAzContext] cmdlet:

```powershell
# Set the Azure PowerShell context to a specific Azure subscription
Set-AzContext -Subscription $SubscriptionName -Name 'MyContext'

# Set the Azure PowerShell context using piping
Get-AzSubscription -SubscriptionName $SubscriptionName | Set-AzContext -Name 'MyContext'
```

For details on Azure PowerShell contexts, see [Azure PowerShell context objects][PersistedCredentialsGuide].

### Discovering cmdlets

Use `Get-Command` to discover cmdlets within a specific module, or cmdlets that follow a specific
search pattern:

```powershell
# List all cmdlets in the Az.Accounts module
Get-Command -Module Az.Accounts

# List all cmdlets that contain VirtualNetwork in their name
Get-Command -Name '*VirtualNetwork*'

# List all cmdlets that contain VM in their name in the Az.Compute module
Get-Command -Module Az.Compute -Name '*VM*'
```

### Cmdlet help and examples

To view the help content for a cmdlet, use the `Get-Help` cmdlet:

```powershell
# View basic help information for Get-AzSubscription
Get-Help -Name Get-AzSubscription

# View the examples for Get-AzSubscription
Get-Help -Name Get-AzSubscription -Examples

# View the full help for Get-AzSubscription
Get-Help -Name Get-AzSubscription -Full

# View the online version of the help from https://learn.microsoft.com for Get-AzSubscription
Get-Help -Name Get-AzSubscription -Online
```

For detailed instructions on using Azure PowerShell, see the [getting started guide][GettingStartedGuide].

## Reporting Issues and Feedback

### Issues

If you find any bugs when using Azure PowerShell, file an issue in our [GitHub repo][GitHubRepo].
Fill out the issue template with the appropriate information.

Alternatively, see [Azure Community Support][AzureCommunitySupport] if you
have issues with Azure PowerShell or Azure services.

### Feedback

If there is a feature you would like to see in Azure PowerShell, use the
[`Send-Feedback`][SendFeedback] cmdlet, or file an issue in our [GitHub repo][GitHubRepo].

## Contribute Code

If you would like to become a contributor to this project, see the instructions provided in
[Microsoft Azure Projects Contribution Guidelines][ContributionGuidelines].

Additional information about contributing to this repository can be found in
[`CONTRIBUTING.md`][Contributing] and the [_Azure PowerShell Developer Guide_][DeveloperGuide].

## Telemetry

Azure PowerShell collects telemetry data by default. Microsoft aggregates collected data to identify
patterns of usage to identify common issues and to improve the experience of Azure PowerShell.
Microsoft Azure PowerShell does not collect any private or personal data. For example, the usage
data helps identify issues such as cmdlets with low success and helps prioritize our work. While we
appreciate the insights this data provides, we also understand that not everyone wants to send usage
data. You can disable data collection with the
[`Disable-AzDataCollection`][DisableAzDataCollection] cmdlet. To learn more, see our
[privacy statement][PrivacyStatement].

## Learn More

* [Microsoft Azure Documentation][MicrosoftAzureDocs]
* [PowerShell Documentation][PowerShellDocs]

---
_This project has adopted the [Microsoft Open Source Code of Conduct][CodeOfConduct]. For more
information see the [Code of Conduct FAQ][CodeOfConductFaq] or contact
[opencode@microsoft.com][OpenCodeEmail] with any additional questions or comments._

<!-- References -->

<!-- Local -->
[GitHubRepo]: https://github.com/Azure/azure-powershell/issues

[Contributing]: CONTRIBUTING.md

[AzureIcon]: documentation/images/MicrosoftAzure-32px.png
[PowershellIcon]: documentation/images/MicrosoftPowerShellCore-32px.png
[AzurePowerShellModules]: documentation/azure-powershell-modules.md
[DeveloperGuide]: documentation/development-docs/azure-powershell-developer-guide.md

<!-- External -->
[Az]: https://img.shields.io/powershellgallery/v/Az.svg?style=flat-square&label=Az
[AzPreview]: https://img.shields.io/powershellgallery/v/AzPreview.svg?style=flat-square&label=AzPreview
[AzGallery]: https://www.powershellgallery.com/packages/Az/
[AzPreviewGallery]: https://www.powershellgallery.com/packages/AzPreview/

[DotNetFramework]: https://dotnet.microsoft.com/download/dotnet-framework-runtime
[PowerShellCore]: https://github.com/PowerShell/PowerShell/releases/latest

[ContributionGuidelines]: https://opensource.microsoft.com/collaborate/
[CodeOfConduct]: https://opensource.microsoft.com/codeofconduct/
[CodeOfConductFaq]: https://opensource.microsoft.com/codeofconduct/faq/
[OpenCodeEmail]: mailto:opencode@microsoft.com

[AzureCloudShell]: https://shell.azure.com/
[AzureCommunitySupport]: https://azure.microsoft.com/support/community/
[PrivacyStatement]: https://privacy.microsoft.com/privacystatement

<!-- Docs -->
[MicrosoftAzureDocs]: https://learn.microsoft.com/azure/
[PowerShellDocs]: https://learn.microsoft.com/powershell/

[InstallationGuide]: https://learn.microsoft.com/powershell/azure/install-az-ps
[GettingStartedGuide]: https://learn.microsoft.com/powershell/azure/get-started-azureps
[PersistedCredentialsGuide]: https://learn.microsoft.com/powershell/azure/context-persistence

[ConnectAzAccount]: https://learn.microsoft.com/powershell/module/az.accounts/connect-azaccount
[GetAzContext]: https://learn.microsoft.com/powershell/module/az.accounts/get-azcontext
[GetAzSubscription]: https://learn.microsoft.com/powershell/module/az.accounts/get-azsubscription
[SetAzContext]: https://learn.microsoft.com/powershell/module/az.accounts/set-azcontext
[SendFeedback]: https://learn.microsoft.com/powershell/module/az.accounts/send-feedback
[DisableAzDataCollection]: https://learn.microsoft.com/powershell/module/az.accounts/disable-azdatacollection
