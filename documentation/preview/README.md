# Azure PowerShell module 4 preview - User documentation

This article explains how to get started with the preview of the Az 4.0 PowerShell module.

## Table of contents

1. [Benefits](##Benefits)
2. [Getting Started](##Getting\ Started)
    - [Installation](###Installation)
    - [Log into Azure](###Log\ into\ Azure)
3. [Tutorials and Examples](##Tutorials\ and\ Examples)
4. [Release Notes](##Release\ Notes)
5. [Request for Comments](##Request\ for\ Comments)
    - [Add support for Azure profiles][RFC0001]
    - [Ability tp run GET commands accross subscriptions][RFC0002]
    - [Support for Asynchronous operations][RFC0003]
    - [Add Model flattening to cmdlets][RFC0004]
    - [Support for Etags][RFC0005]
    - [Consistent Create and Modify Cmdlets Across Services][RFC0006]
6. [Issues and Feedback](##Issues\ and\ Feedback)

## Benefits

This new module is introducing the following changes to Azure PowerShell:

- Azure Profiles
- Cmdlet Consistency
- Asynchronous Operations
- Parameter Simplification
- Subscription Parameters
- ETag Support

The [feature Page][Features] gives more details on what has been implemented with each of these features and the [Azure Profile page][AzureProfiles] will give more details on this concept.

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

## Release notes

We are aware of several known issues and limitations of this preview.
The release notes of each module have a more details:

- AppServices
- Billing
- Compute
- [DNS](../../src/Dns/resources/release-notes.md)
- KeyVault
- Monitor
- [Network](../../src/Network/resources/release-notes.md)
- Resources
- ServiceBus
- Storage

## Request for comments

With this preview, we are specifically looking at hearing your feedback on the following topics. Each link will give more details for each feature and has a section where you can provide comments:

- [Add support for Azure profiles][RFC0001]
- [Ability tp run GET commands accross subscriptions][RFC0002]
- [Support for Asynchronous operations][RFC0003]
- [Add Model flattening to cmdlets][RFC0004]
- [Support for Etags][RFC0005]
- [Consistent Create and Modify Cmdlets Across Services][RFC0006]

## Issues and feedback

This is a preview version of the Azure PowerShell module and we are looking to get your feedback

If there is a feature you would like to see in Azure PowerShell or if your encounter issues with this preview, please [create an issue][GitHubIssues] in this repo. The Azure PowerShell team is reviewing those isses and may come back to you with additional questions.

<!-- References -->

<!-- Local -->
[GitHubIssues]:https://aka.ms/azps4issue
[SendFeedback]:http://aka.ms/azps4feedback
[Features]:Features.md
[AzureProfiles]:AzureProfiles.md

[RFC0001]:../RFC/RFC0001-Azure-Profiles.md
[RFC0002]:../RFC/RFC0002-SubscriptionList-in-Get.md
[RFC0003]:../RFC/RFC0003-AsynchronousOperations.md
[RFC0004]:../RFC/RFC0004-Model-Flattening-and-Inline-Creation.md
[RFC0005]:../RFC/RFC0005-ETags.md
[RFC0006]:../RFC/RFC0006-Creation-and-Modification-Cmdlets.md

<!-- Exteral -->
[AzGallery]: https://www.powershellgallery.com/packages/Az/

<!-- Docs -->
[ConnectAzAccount]: https://docs.microsoft.com/en-us/powershell/module/az.accounts/connect-azaccount
