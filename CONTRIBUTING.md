# Contribute Code or Provide Feedback for Azure PowerShell

This repository contains a set of PowerShell cmdlets for developers and administrators to develop, deploy, and manage Microsoft Azure applications.

## Basics

If you would like to become an active contributor to this project please follow the instructions provided in [Microsoft Azure Projects Contribution Guidelines](http://azure.github.io/guidelines/).

In the Azure Developer Experience, you are at Step 5:

[API Design Review](https://github.com/Azure/adx-documentation-pr#begin-api-design-review) -> [Engage with ADX team](https://github.com/Azure/adx-documentation-pr/blob/master/README.md#engage-with-adx-team) -> [Swagger specification](https://github.com/Azure/adx-documentation-pr#create-swagger-specification) -> [SDKs](https://github.com/Azure/adx-documentation-pr#sdks) -> _**[CLIs](https://github.com/Azure/adx-documentation-pr#clis)**_

## Table of Contents

[Before Starting](#before-starting)
- [Onboarding](#onboarding)
- [GitHub Basics](#github-basics)
    - [GitHub Workflow](#github-workflow)
    - [Forking the Azure/azure-powershell repository](#forking-the-azureazure-powershell-repository)
- [Code of Conduct](#code-of-conduct)

[Filing Issues](#filing-issues)

[Submitting Changes](#submitting-changes)
- [Pull Requests](#pull-requests)
- [SDK for .NET](#sdk-for-net)
- [Pull Request Guidelines](#pull-request-guidelines)
    - [Cleaning up commits](#cleaning-up-commits)
    - [Updating the change log](#updating-the-change-log)
    - [General guidelines](#general-guidelines)
    - [Testing guidelines](#testing-guidelines)
    - [Cmdlet signature guidelines](#cmdlet-signature-guidelines)
    - [Cmdlet parameter guidelines](#cmdlet-parameter-guidelines)
    - [Cmdlet pipeline guidelines](#cmdlet-pipeline-guidelines)

## Before Starting

### Onboarding

Make sure that your GitHub account is part of the Azure organization. [Use this page](http://aka.ms/azuregithub) to link your account.

Before cloning this repository, please make sure you have started in our [documentation repository](https://github.com/Azure/adx-documentation-pr) (you will only have access to that page if you are part of the Azure organization).

### GitHub Basics

#### GitHub Workflow

If you don't have experience with Git and GitHub, some of the terminology and process can be confusing. [Here is a guide to understanding the GitHub flow](https://guides.github.com/introduction/flow/) and [here is a guide to understanding the basic Git commands](https://education.github.com/git-cheat-sheet-education.pdf).

#### Forking the Azure/azure-powershell repository

Unless you are working with multiple contributors on the same file, we ask that you fork the repository and submit your pull request from there. [Here is a guide to forks in GitHub](https://guides.github.com/activities/forking/).

### Code of Conduct

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## Filing Issues

You can find all of the issues that have been filed in the [Issues](https://github.com/Azure/azure-powershell/issues) section of the repository.

If you encounter any bugs with Microsoft Azure PowerShell, please file an issue [here](https://github.com/Azure/azure-powershell/issues/new) and make sure to fill out the provided template with the requested information.

To suggest a new feature or changes that could be made to Azure PowerShell, file an issue the same way you would for a bug, but remove the provided template and replace it with information about your suggestion.

You can find the code complete and release dates of the next three Azure PowerShell releases in the [Milestones](https://github.com/Azure/azure-powershell/milestones) section of the Issue page. Each milestone will display the issues that are being worked on for the corresponding release. 

## Submitting Changes

### Pull Requests

You can find all of the pull requests that have been opened in the [Pull Request](https://github.com/Azure/azure-powershell/pulls) section of the repository.

To open your own pull request, click [here](https://github.com/Azure/azure-powershell/compare). When creating a pull request, keep the following in mind:
- Make sure you are pointing to the fork and branch that your changes were made in
- Choose the correct branch you want your pull request to be merged into
    - The **preview** branch is for active development; changes in this branch will be in the next Azure PowerShell release
    - The **master** branch contains a snapshot of the source code at the time of the last release
    - The **release-X.X.X** branch is for active development during a release
- The pull request template that is provided **should be filled out**; this is not something that should just be deleted or ignored when the pull request is created
    - Deleting or ignoring this template will elongate the time it takes for your pull request to be reviewed
- The SLA for reviewing pull requests is **two business days**

### SDK for .NET

If your changes require a new version of an Azure management library, please ensure that the corresponding NuGet package has been published from the [Azure SDK for .NET repository](https://github.com/Azure/azure-sdk-for-net).

For more information on how to make changes to the SDK for .NET repository and publish packages to NuGet, please see the [`README.md`](https://github.com/Azure/azure-sdk-for-net/blob/psSdkJson6/README.md) in the Azure SDK for .NET repository.

### Pull Request Guidelines

A pull request template will automatically be included as a part of your PR. Please fill out the checklist as specified. Pull requests **will not be reviewed** unless they include a properly completed checklist.

The following is a list of guidelines that pull requests opened in the Azure PowerShell repository must adhere to. You can find a more complete discussion of Azure PowerShell design guidelines [here](./documentation/development-docs/azure-powershell-design-guidelines.md).

#### Cleaning up Commits

If you are thinking about making a large change to your Azure PowerShell cmdlets, **break up the change into small, logical, testable chunks, and organize your pull requests accordingly**.

Often when a pull request is created with a large number of files changed and/or a large number of lines of code added and/or removed, GitHub will have a difficult time opening up the changes on their site. This forces the Azure PowerShell team to uses separate software, such as CodeFlow or Beyond Compare, to do a code review on the pull request.

If you find yourself creating a pull request and are unable to see all the changes on GitHub, we recommend **splitting the pull request into multiple pull requests that are able to be reviewed on GitHub**.

If splitting up the pull request is not an option, we recommend **creating individual commits for different parts of the pull request, which can be reviewed individually on GitHub**.

For more information on cleaning up the commits in a pull request, such as how to rebase, squash, and cherry-pick, click [here](./documentation/development-docs/cleaning-up-commits.md).

#### Updating the change log

Any changes that are made must be reflected in the respecitve service's change log. This change log will allow customers to easily track what has been changed between releases of a service.

For ARM service projects, the change log is located at `src\ResourceManager\{{service}}\ChangeLog.md`.

For RDFE service projects, the change log is located at `src\ServiceManagement\ChangeLog.md`.

For the Storage data plane project, this change log is located at `src\Storage\ChangeLog.md`.

#### Breaking Changes

Breaking changes should **not** be introduced into the repository without giving customers at least six months notice. For a description of breaking changes in Azure PowerShell, see [here](documentation/breaking-changes/breaking-changes-definition.md).

Whenever a service team announces a breaking change, they must add it to the `upcoming-breaking-changes.md` file in their respective service folder. When the service team is ready to release the module with the breaking change, they must move the corresponding information from `upcoming-breaking-changes.md` into the `current-breaking-changes.md` file located in their service folder.

#### General guidelines

The following guidelines must be followed in **EVERY** pull request that is opened.

- Title of the pull request is clear and informative
- There are a small number of commits that each have an informative message
- A description of the changes the pull request makes is included, and a reference to the bug/issue the pull request fixes is included, if applicable
- All files have the Microsoft copyright header
- Cmdlets refer to the management libraries through NuGet references - no dlls are checked in
- The pull request does not introduce [breaking changes](https://github.com/markcowl/azure-powershell/blob/doc1/documentation/changes.md#breaking-change-definition) (unless a major version change occurs in the assembly and module)

#### Testing guidelines

The following guidelines must be followed in **EVERY** pull request that is opened.

- Pull request includes test coverage for the included changes
- Tests must use xunit, and should either use Moq to mock management client calls, or use the scenario test framework
- Test code should not contain hard coded values for resource names, resource locations, subscriptions, tenants, or similar values. Test scripts, when run live, should be executable using any subscription and any location in Azure
- PowerShell scripts used in tests must do any necessary setup as part of the test or suite setup, and should not use hard-coded values for existing resources
- Test should not use App.config files for settings
- Tests should use the built-in PowerShell functions for generating random names when unique names are necessary - this will store names in the test recording
- Tests should use `Start-Sleep` to pause rather than `Thread.Sleep`

#### Cmdlet signature guidelines

The following guidelines must be followed in pull requests that add, edit, or remove a cmdlet.

- Cmdlet name uses an approved PowerShell verb - use enums for `VerbsCommon`, `VerbsCommunication`, `VerbsData`, `VerbsDiagnostic`, `VerbsLifecycle`, `VerbsOther`, and `VerbsSecurity` whenever possible
    - Note that you can see a list of all approved PowerShell verbs by running `Get-Verb` in PowerShell
    - When a verb you would like to use is not in the list of approved verbs, or to get ideas on how to use verbs, consult the [Approved Verbs for Windows PowerShell Commands](https://msdn.microsoft.com/en-us/library/ms714428\(v=vs.85\).aspx) documentation where you will find descriptions of approved verbs as well as related verbs in the comments so that you can find one appropriate for your command
- Cmdlet noun name uses the AzureRm prefix for management cmdlets, and the Azure prefix for data plane cmdlets
- Cmdlet specifies the `OutputType` attribute; if the cmdlet produces no output, it should have an `OutputType` of `bool` and implement a `PassThrough` parameter
- If the cmdlet makes changes or has side effects, it should implement `ShouldProcess` and have `SupportsShouldProcess = true` specified in the cmdlet attribute. See a discussion about correct `ShouldProcess` implementation [here](https://gist.github.com/markcowl/338e16fe5c8bbf195aff9f8af0db585d#what-is-the-change).
- Cmdlets should derive from [`AzureRmCmdlet`](src/ResourceManager/Common/Commands.ResourceManager.Common/AzureRMCmdlet.cs) class for management cmdlets, and [`AzureDataCmdlet`](src/Common/Commands.Common/AzureDataCmdlet.cs) for data cmdlets
- If multiple parameter sets are implemented, the cmdlet should specify a `DefaultParameterSetName` in its cmdlet attribute

#### Cmdlet parameter guidelines

The following guidelines must be followed in pull requests that add, edit, or remove a parameter.

- Cmdlets should have no more than four positional parameters
- Cmdlet parameter sets should be mutually exclusive - each parameter set must have at least one mandatory parameter not in other parameter sets
- Parameter types should not expose types from the management library - complex parameter types should be defined in the module
- Complex parameter types are discouraged - a parameter type should be simple types as often as possible. If complex types are used, they should be shallow and easily creatable from a constructor or another cmdlet
- Parameters should be explicitly marked as `Mandatory` or not, and should contain a `HelpMessage`
- No parameter is of type `object`
- Management cmdlets should have the following parameters and aliases:
    - `ResourceGroupName` with (optional) alias to `ResourceGroupName` type `string` marked as `[ValueFromPipelineByPropertyName]`
    - `Name` with alias to `ResourceName` type `string` marked as `[ValueFromPipelineByPropertyName]`
    - `Location` (if appropriate) type `string`
    - `Tag` type `HashTable`

#### Cmdlet pipeline guidelines

The following guidelines must be followed in pull requests that make changes to pipeline parameters.

- Complex parameters should take values from the pipeline when possible, and certainly when they match the output type of another cmdlets
- Only one parameter should use `ValueFromPipeline` per parameter set; parameters from different parameter sets may have this attribute, but should not be convertible
- No parameter is of type `object`
- Each management cmdlet should have a parameter set that takes `ResourceGroupName` and `Name` from the pipeline by property value
- For a given resource type, it should be possible to pipe the output of `Get` and `New` cmdlets to the input of `Set`, `Update`, `Remove` and other action cmdlets for that resource
