# Contributing to Azure PowerShell

This repository contains PowerShell cmdlets for developers and administrators to develop, deploy,
administer, and manage Microsoft Azure resources.

## Basics

If you would like to become a contributor to this project (or any other open source Microsoft
project), see how to [Get Involved](https://opensource.microsoft.com/collaborate/).

## Before Starting

### Onboarding

All users must sign the
[Microsoft Contributor License Agreement (CLA)](https://cla.opensource.microsoft.com/) before making
any code contributions. For Microsoft employees, make sure that your GitHub account is part of the
Azure organization. [Use this page](http://aka.ms/azuregithub) to link your account.

### Code of Conduct

This project has adopted the
[Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more
information, see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or
comments.

### GitHub Basics

#### GitHub Workflow

The following guides provide basic knowledge for understanding Git command usage and the workflow of
GitHub.

- [Git Cheat Sheet](https://education.github.com/git-cheat-sheet-education.pdf)
- [GitHub Flow](https://guides.github.com/introduction/flow/)

#### Forking the Azure/azure-powershell repository

Unless you are working with multiple contributors on the same file, we ask that you fork the
repository and submit your pull request from there. The following guide explains how to fork a
GitHub repo.

- [Contributing to GitHub projects](https://guides.github.com/activities/forking/).

## Filing Issues

You can find all of the issues that have been filed for Azure PowerShell in the
[Issues](https://github.com/Azure/azure-powershell/issues) section of this repository.

To file an issue, select one of the
[templates](https://github.com/Azure/azure-powershell/issues/new/choose). This ensures that all of
the necessary information is provided. The following are a few of the templates we provide:

- [_Az module bug report_](https://github.com/Azure/azure-powershell/issues/new?assignees=&labels=needs-triage%2Cbug&template=1-AZ-BUG-REPORT.yml)
- [_Feature request_](https://github.com/Azure/azure-powershell/issues/new?assignees=&labels=feature-request%2Cneeds-triage&template=2-FEATURE-REQUEST.yml&title=%5BFeature%5D%3A+)
- [_Az module question or discussion_](https://github.com/Azure/azure-powershell/issues/new?assignees=&labels=needs-triage%2Cquestion&template=3-AZ-QUESTION.yml)

You can find the code complete and release dates of the next three Azure PowerShell releases in the
[Milestones](https://github.com/Azure/azure-powershell/milestones) section of the _Issues_ page.
Each milestone will display the issues that are being worked on for the corresponding release.

## Submitting Changes

### Pull Requests

You can find all of the pull requests that have been opened in the
[Pull Requests](https://github.com/Azure/azure-powershell/pulls) section of this repository.

When creating a pull request, keep the following in mind:

- Verify you are pointing to the fork and branch that your changes were made in.
- Choose the correct branch you want your pull request to be merged into.
  - The **main** branch is for active development; changes in this branch will be in the next Azure
    PowerShell release.
  - The **release-X.X.X** branch is for active development during a release.
  - The **preview** branch is a snapshot of the last `AzureRM` release and _should not_ be used for
    active development.
- The pull request template that is provided **must be filled out**. Do not delete or ignore it when
  the pull request is created.
  - **_IMPORTANT:_** Deleting or ignoring the pull request template will delay the PR review process.
- The SLA for reviewing pull requests is **two business days**.

### Pull Request Guidelines

A pull request template will automatically be included as a part of your PR. Please fill out the
checklist as specified. Pull requests **will not be reviewed** unless they include a properly
completed checklist.

The following set of guidelines must be adhered to when opening pull requests in the Azure
PowerShell repository.

#### General guidelines

The following guidelines must be followed for **every** pull request that is opened.

- Title of the pull request is clear and informative.
- The appropriate `ChangeLog.md` file(s) has been updated:
  - For any service, the `ChangeLog.md` file can be found at
    `src/{{SERVICE}}/{{SERVICE}}/ChangeLog.md`.
  - A snippet outlining the change(s) made in the PR should be written under the
    `## Upcoming Release` header -- no new version header should be added.
- There are a small number of commits in your PR and each commit has an informative commit message.
  - For more information, see
    [Cleaning up commits](documentation/development-docs/cleaning-up-commits.md).
- All files shipped with a module should contain a proper Microsoft license header.
- For public API changes to cmdlets:
  - A [cmdlet design review](https://github.com/Azure/azure-powershell-cmdlet-review-pr) has been
    approved for the changes in this repository. (_Microsoft internal only_).
  - The Markdown help files have been regenerated using the commands listed
    [here](documentation/development-docs/help-generation.md#updating-all-markdown-files-in-a-module).

For a comprehensive list of Azure PowerShell design guidelines and best practices, see
[Azure PowerShell Design Guidelines](documentation/development-docs/design-guidelines).

#### Testing guidelines

The following guidelines must be followed in **every** pull request that is opened.

- Changes made have corresponding test coverage.
- Tests should not include any hardcoded values, such as location, resource id, etc.
- Tests should have proper setup of resources to ensure any user can re-record the test if necessary.
- No existing tests should be skipped.

#### Cmdlet guidelines

- [Cmdlet Best Practices](./documentation/development-docs/design-guidelines/cmdlet-best-practices.md)
- [Examples of standard Azure PowerShell cmdlets](./documentation/development-docs/examples).

#### Parameter guidelines

- [Parameter Best Practices](./documentation/development-docs/design-guidelines/parameter-best-practices.md).

#### Piping guidelines

- [Piping Best Practices](./documentation/development-docs/design-guidelines/piping-best-practices.md).

#### Module guidelines

- [Module Best Practices](./documentation/development-docs/design-guidelines/module-best-practices.md).
