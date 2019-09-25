# Azure PowerShell module 4 preview - User documentation

This article explains how to get started with the preview of the Az 4.x PowerShell module.

## Benefits

With this new module we are introducting several changes to Azure PowerShell. The links below will provide more details for each feature and allow you to submit comments:

- [Add support for Azure profiles](../RFC/RFC0001-Azure-Profiles.md)
- [Ability tp run GET commands accross subscriptions](../RFC/RFC0002-SubscriptionList-in-Get.md)
- Support for Etags
- [Add Model flattening to cmdlets](../RFC/Update\ Model\ Flattening\ and\ Inline\ Creation.md)
- Support for Asynchronous operations

## Getting started

### Installation

Install the preview version of Az PowerShell 4 module from the PowerShell Gallery

```powershell
Install-Module -Name Az -AllowPrerelease
```

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

## Tutorials and examples

The following pages will guide you through some scenarios supported with this preview of the Az 4.0 module

Work in progress:

- Create an Azure Virtual Machine
- Create a VNet and Subnet
- Create a log analytics workspace

We are planning to add more to this list over time.

Contribute to the list by submitting a PR or submit an issue describing the scenario that you would like to see covered.

### Release notes

We are aware of several known issues and limitations of this preview. The ReleaseNotes.md files in the directory corresponding to each module compiles those kwown issues.

- AppServices
- Billing
- [Compute]
- DNS
- KeyVault
- [Monitor]
- [Network]
- Resources
- ServiceBus
- Storage

## Feedback

If there is a feature you would like to see in Azure PowerShell, please use the [`Send-Feedback`][SendFeedback] cmdlet, or file an issue in our [GitHub issues][GitHubIssues] page to provide the Azure PowerShell team direct feedback.

<!-- References -->

<!-- Local -->
[GitHubIssues]: https://aka.ms/azps4issue

<!-- Exteral -->
[AzGallery]: https://www.powershellgallery.com/packages/Az/

<!-- Docs -->
[ConnectAzAccount]: https://docs.microsoft.com/en-us/powershell/module/az.accounts/connect-azaccount
