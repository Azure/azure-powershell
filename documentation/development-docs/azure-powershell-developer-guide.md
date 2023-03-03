# Azure PowerShell Developer Guide

The Azure PowerShell Developer Guide was created to help with the development and testing of Azure PowerShell cmdlets. This guide contains information on how to set up your environment, create a new project, implement cmdlets, record and run tests, and more.

# Table of Contents

- [Prerequisites](#prerequisites)
- [Environment Setup](#environment-setup)
    - [GitHub Basics](#github-basics)
    - [Building the Environment](#building-the-environment)
    - [Generating Help](#generating-help)
    - [Running Static Analysis](#running-static-analysis)
    - [Running Tests](#running-tests)
- [Before Adding a New Project](#before-adding-a-new-project)
    - [.NET SDK](#net-sdk)
    - [Design Review](#design-review)
    - [Contact](#contact)
- [Setting Up a New Project](#setting-up-a-new-project)
    - [Getting Started](#getting-started)
        - [Creating the Project](#creating-the-project)
        - [Adding Project References](#adding-project-references)
- [Creating Cmdlets](#creating-cmdlets)
    - [PowerShell Cmdlet Design Guidelines](#powershell-cmdlet-design-guidelines)
    - [Enable Running PowerShell when Debugging](#enable-running-powershell-when-debugging)
        - [Importing Modules](#importing-modules)
    - [Adding Help Content](#adding-help-content)
- [Adding Tests](#adding-tests)
    - [Using Azure TestFramework](#using-azure-testframework)
    - [Scenario Tests](#scenario-tests)
        - [Adding Scenario Tests](#adding-scenario-tests)
        - [Using Common Code](#using-common-code)
        - [Using Active Directory](#using-active-directory)
        - [Using Certificate](#using-certificate)
        - [AD Scenario Tests](#ad-scenario-tests)
        - [Recording/Running Tests](#recordingrunning-tests)
- [After Development](#after-development)
- [Misc](#misc)
    - [Publish to PowerShell Gallery](#publish-to-powershell-gallery)
    - [AsJob Parameter](#asjob-parameter)
    - [Argument Completers](#argument-completers)
        - [Resource Group Completer](#resource-group-completers)
        - [Location Completer](#location-completer)
        - [Generic Argument Completer](#generic-argument-completer)

# Prerequisites

The following prerequisites should be completed before contributing to the Azure PowerShell repository:

- Install [Visual Studio 2017](https://www.visualstudio.com/downloads/)
- Install the latest version of [Git](https://git-scm.com/downloads)
- Install the [`platyPS` module](help-generation.md#Installing-platyPS)
- Install the latest [**.NET Core SDK** and **.NET Framework Dev Pack 4.7.2**](https://dotnet.microsoft.com/download) or greater
- Install [PowerShell Core](https://github.com/PowerShell/PowerShell/releases/latest)
- Set the PowerShell [execution policy](https://technet.microsoft.com/en-us/library/ee176961.aspx) to **Unrestricted** for the following versions of PowerShell:
  - `C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe`
  - `C:\Windows\SysWOW64\WindowsPowerShell\v1.0\powershell.exe`
  - `C:\Program Files\PowerShell\{{version}}\pwsh.exe`

# Environment Setup

## GitHub Basics

If you don't have experience with Git and GitHub, some of the terminology and process can be confusing. [Here is a guide to understanding the GitHub flow](https://guides.github.com/introduction/flow/) and [here is a guide to understanding the basic Git commands](https://services.github.com/on-demand/downloads/github-git-cheat-sheet.pdf).

To develop in the Azure PowerShell repository locally, you first need to create your own fork. For more information on how to fork, click [here](https://guides.github.com/activities/forking/).

Once your fork of the Azure PowerShell repository has been created, you need to clone your fork to your local machine. To do so, run the following command:

```
git clone https://github.com/<YOUR GITHUB USERNAME>/azure-powershell.git
```

You now be able to create your own branches, commit changes, and push commits to your fork.

**Note**: we recommend adding the _Azure/azure-powershell_ repository to your list of tracked repositories in Git. This allows you to easily pull changes from the Azure repository. To do this, run the following command:

```
git remote add upstream https://github.com/Azure/azure-powershell.git
```

Then, to pull changes from the **master** branch in _Azure/azure-powershell_ into your local working branch, run the following command:

```
git pull upstream master
```

## Building the Environment

_Note_: to build the environment locally, you need `platyPS` install on your machine. Please see the [Prerequisites](#prerequisites) section for details on how to install this module.

After cloning the repository to your local machine, you want to ensure that you can build the environment. To do so, launch `VS Developer Command Prompt` (which is installed with Visual Studio) and run the following command (from the root of the repository) to do a full build:

```
msbuild build.proj
```

Alternatively, you can open any command prompt (Command Prompt, Windows PowerShell, or PowerShell Core), navigate to the root of the repository, and run:

```powershell
PS C:\azure-powershell> dotnet msbuild build.proj
```

## Generating Help

We build the `dll-Help.xml` files (used to display the help content for cmdlets in PowerShell) from markdown using the `platyPS` module. Since this help generation step can take 10-15 minutes, it is a separate part of the command line build process. Run this to generate help:

```
msbuild build.proj /t:GenerateHelp
```

## Running Static Analysis

To keep consistency across our modules, we've implemented a static analysis system. This verifies various aspects (depdencies, breaking changes, etc.) for your module. Run this command to execute static analysis validation for the built modules:

```
msbuild build.proj /t:StaticAnalysis
```

_Note_: this can add 10-15 minutes to your build time due to help generation.

## Running Tests

Launch `VS Developer Command Prompt` and run the following command (from the root of the repository) to run all of the tests in playback:

```
msbuild build.proj /t:Test
```

Alternatively, you can open any command prompt (Command Prompt, Windows PowerShell, or PowerShell Core), navigate to the root of the repository, and run:

```powershell
PS C:\azure-powershell> dotnet msbuild build.proj /t:Test
```

# Before Adding a New Project

## .NET SDK

Before adding a new project to Azure PowerShell, you must have generated an [SDK for .NET](https://github.com/Azure/azure-sdk-for-net) using [AutoRest](https://github.com/Azure/autorest) for your service, and it must have been merged into the repository.

For more information about on-boarding a new library in the SDK for .NET repository, click [here](https://github.com/Azure/azure-sdk-for-net#to-on-board-new-libraries).

## Design Review

Before development, you must meet with the Azure PowerShell team to have a design review for your proposed PowerShell cmdlets. We advise that this review is held no earlier than three weeks out from code complete of the release you want to ship the cmdlets with. For a small number of cmdlet changes and/or additions, an email containing the markdown files for the proposed changes is suggested. For a large number of changes and/or additions, a meeting is required with the Azure PowerShell team.

Before submitting a design review, please be sure that you have read the documents found in the [Azure PowerShell Design Guidelines](./design-guidelines) folder.

Please submit a design review here: https://github.com/Azure/azure-powershell-cmdlet-review-pr

_Note_: You will need to be part of the `GitHub Azure` org to see this repository. Please go to [this link](aka.ms/azuregithub) to become part of the `Azure` org.

We recommend using the `platyPS` module to easily generate markdown files that contains the above information and including the files in the design submission.

## Point of Contact

You must provide a contact (Microsoft alias + GitHub alias) on your team that is responsible for handling issues with your SDK and cmdlets, as well as open source contributions to your code.

Also, members of your team (who are involved with the SDKs) are advised to join the [Microsoft Teams Azure SDK team](https://teams.microsoft.com/l/team/19%3a9b93b9f4bd1540a486e5ef1a82a74637%40thread.skype/conversations?groupId=da8d67c5-f19d-4799-b158-5dbbef868d49&tenantId=72f988bf-86f1-41af-91ab-2d7cd011db47), and join the **adxsdkpartners** alias on idweb.

# Setting Up a New Project

## Getting Started

When adding a new project, please follow these guidelines:

### Creating the Project

Add a new folder under `src` with your service specific name (_e.g.,_ `Compute`, `Sql`, `Websites`).

We recommend copying an existing module. For example, go to `src/Cdn` and copy the contents of this folder. Paste these to your service folder you just created. **Rename** the following:
- The folders to `<SERVICE>` and `<SERVICE>.Test`
- The solution to `<SERVICE>.sln`
- The projects (within each folder) to `<SERVICE>.csproj` and `<SERVICE>.Test.csproj`
- The PSD1 file (in the `<SERVICE>` folder) to `Az.<SERVICE>.psd1`

Now, you'll need to edit the solution file. Open the `<SERVICE>.sln` in your text editor of choice. Edit these lines to use your `<SERVICE>` name:
- Update the `"<SERVICE>", "<SERVICE>\<SERVICE>.csproj"`
- Update the `"<SERVICE>.Test", "<SERVICE>.Test\<SERVICE>.Test.csproj"`
- **Note**: Leave the `"Accounts", "..\Accounts\Accounts\Accounts.csproj"` entry as is. All modules depend on `Accounts`.

After the solution file is updated, save and close it. Now, open the solution file in Visual Studio. Right click on the `<SERVICE>` project in the `Solution Explorer` and select `Unload project`. Right click on the unloaded project and select `Edit <SERVICE>.csproj`. Once opened, ensure that the following things are changed:
- Update this entry to use your service name (what you used as `<SERVICE>` above):
```xml
  <PropertyGroup>
    <PsModuleName>Cdn</PsModuleName>
  </PropertyGroup>
```
- **Remove the entry**:
```xml
  <PropertyGroup>
    <RootNamespace>$(LegacyAssemblyPrefix)$(PsModuleName)</RootNamespace>
  </PropertyGroup>
```
**Note**: This is not needed since this is a new project and does not use legacy namespace conventions.

- Update this entry to use your SDK:
```xml
  <ItemGroup>
    <PackageReference Include="Microsoft.Azure.Management.Cdn" Version="4.0.2-preview" />
  </ItemGroup>
```
If you have not generated your AutoRest SDK yet, remove this entry for now.

Right click on the project and select `Reload project`, and then build the solution by either right clicking on the solution and selecting `Rebuild Solution` or, from the top of Visual Studio, selecting `Build > Rebuild Solution`. If the build does not succeed, open the `.csproj` file and ensure there are no errors.

### Adding Project References

There are a few existing projects that need to be added before developing any cmdlets. To add a project to the solution, right click on the solution in `Solution Explorer` and select `Add > Existing Project`. This allows you to navigate through folders to find the `.csproj` of the project you want to add. Once a project is added to your solution, you can add it as a reference to the `<SERVICE>` project by right clicking on `<SERVICE>` and selecting `Add > Reference`. This opens the `Reference Manager` window, and once you have selected the `Projects > Solution` option on the left side of the window, you are able to select which projects you want to reference in `<SERVICE>` by checking the box to the left of the name.

# Creating Cmdlets

## PowerShell Cmdlet Design Guidelines

Please check out the [_Cmdlet Best Practices_](./design-guidelines/cmdlet-best-practices.md) document for more information on how to create cmdlets that follow the PowerShell guidelines.

## Enable Running PowerShell when Debugging

- Choose any project and set it as the startup project in Visual Studio
  - Right click on your project in the **Solution Explorer** and select **Set as StartUp project**
- Right-click on the project and select **Properties**
- Go to the **Debug** tab
- Under **Start Action**, pick _Start external program_ and type the PowerShell 6.0 directory
  - For example, `C:\Program Files\PowerShell\6\pwsh.exe`

### Importing Modules

To import modules automatically when debug has started, follow the below steps:

- In the **Debug** tab mentioned previously, go to **Start Options**
- Import the Profile module, along with the module you are testing, by pasting the following in the **Command line arguments** box (_note_: you have to update the <PATH_TO_REPO> and <SERVICE> values provided below):
  - `-NoExit -Command "Import-Module <PATH_TO_REPO>/artifacts/Debug/Az.Accounts/Az.Accounts.psd1;Import-Module <PATH_TO_REPO>/artifacts/Debug/Az.<SERVICE>/Az.<SERVICE>.psd1;$VerbosePreference='Continue'"`
- **Note**: if you do not see all of the changes you made to the cmdlets when importing your module in a PowerShell session (_e.g.,_ a cmdlet you added is not recognized as a cmdlet), you may need to delete any existing Azure PowerShell modules that you have on your machine (installed through the PowerShell Gallery) before you import your module.

## Adding Help Content

All cmdlets that are created must have accompanying help that is displayed when users execute the command `Get-Help <your cmdlet>`.

Each cmdlet has a markdown file that contains the help content that is displayed in PowerShell; these markdown files are created (and maintained) using the platyPS module.

For complete documentation, see [`help-generation.md`](help-generation.md) in the `documentation` folder.

# Adding Tests

_Note_: As mentioned in the prerequisites section, set the PowerShell [execution policy](https://technet.microsoft.com/en-us/library/ee176961.aspx) to **Unrestricted** for the following versions of PowerShell:

- `C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe`
- `C:\Windows\SysWOW64\WindowsPowerShell\v1.0\powershell.exe`
- `C:\Program Files\PowerShell\{{version}}\pwsh.exe`

## Using Azure TestFramework

Please see our guide on [Using Azure TestFramework](../testing-docs/using-azure-test-framework.md) for information on how to setup the appropriate connection string and record tests using the `Microsoft.Rest.ClientRuntime.Azure.TestFramework` package.

## Scenario Tests

### Adding Scenario Tests

- Create a new class in `<SERVICE>.Test`
    - Add `[Fact]` as an attribute to every test
    - Add `[Trait(Category.AcceptanceType, Category.CheckIn)]` as an attribute to any test that should be run during CI in Playback mode.
    - Add `[Trait(Category.AcceptanceType, Category.LiveOnly)]` as an attribute to any test that cannot be run in Playback mode (for example, if a test depends on a Dataplane SDK).
- Create a ps1 file in the same folder that contains the actual tests ([see sample](../../src/Media/Media.Test/ScenarioTests))
    - Use `Assert-AreEqual x y` to verify that values are the same
    - Use `Assert-AreNotEqual x y` to verify that values are not the same
    - Use `Assert-Throws scriptblock message` to verify an exception is being thrown
    - Use `Assert-ThrowsContains scriptblock substring` to verify an exception is being thrown and contains a substring
    - Use `Assert-Env env[]` to verify environment variables
    - Use `Assert-True scriptblock` to verify that a script block returns true
    - Use `Assert-False scriptblock` to verify that a script block returns false
    - Use `Assert-Null object` to verify that an object is null
    - Use `Assert-NotNull object` to verify that an object is not null
    - Use `Assert-Exists path` to verify that a file exists
    - Use `Assert-AreEqualArray a1 a2` to verify that arrays are the same
    - Use `Assert-StartsWith s1 s2` to verify that the string `s2` starts with the string `s1`
    - Use `Assert-Match s1 s2` to verify that the string `s2` matches the regular expression `s1`
    - Use `Assert-NotMatch s1 s2` to verify that the string `s2` does not match the regular expression `s1`

### Using Active Directory

- Use the `Set-TestEnvironment` cmdlet from `Repo-Tasks.psd1` to setup your connection string
- Alternatively, you can set the following environment variables
    - `TEST_CSM_ORGID_AUTHENTICATION` is used for Resource Manager testing

> **Important!**
> 1. Be sure that you have set the `ExecutionPolicy` to `Unrestricted` on both 32-bit and 64-bit PowerShell environments, as mentioned in the [prerequisites](#prerequisites) at the top
> 2. When recording tests, if you are using a Prod environment, use ServicePrincipalName (SPN) and ServicePrincipalSecret. For more information on creating an SPN, click [here](https://learn.microsoft.com/en-us/azure/azure-resource-manager/resource-group-create-service-principal-portal).

### AD Scenario Tests

Create this environment variables for the AD scenario tests:

- `AZURE_SERVICE_PRINCIPAL` should be a service principal - an application defined in the subscription's tenant - that has management access to the subscription (or at least to a resource group in the tenant)
  - `AZURE_SERVICE_PRINCIPAL=UserId=<UserGuid>;Password=<Password>;AADTenant=<TenantGuid>;SubscriptionId=<SubscriptionId>`

### Recording/Running Tests

- Set up environment variables using New-TestCredential as described [here](../testing-docs/using-azure-test-framework.md#new-testcredential)
- Run the test in Visual Studio in the Test Explorer window and make sure you got a generated JSON file that matches the test name in the bin folder under the `SessionRecords` folder
- Copy this `SessionRecords` folder and place it inside the test project
  - Inside Visual Studio, add all of the generated JSON files, making sure to change the "Copy to Output Directory" property for each one to "Copy if newer"
  -  Make sure that all of these JSON files appear in your `<SERVICE>.Test.csproj` file

# After Development

Once all of your cmdlets have been created and the appropriate tests have been added, you can open a pull request in the Azure PowerShell repository to have your cmdlets added to the next release. Please make sure to read [CONTRIBUTING.md](../../CONTRIBUTING.md) for more information on how to open a pull request, clean up commits, make sure appropriate files have been added/changed, and more.

## Change Log

Whenver you make updates to a project, please make sure to update the corresponding service's `ChangeLog.md` file with a snippet of what you changed under the `Upcoming Release` header. This information is later used for the release notes that goes out with each module the next time they are released, and provides users with more information as to what has changed in the module from the previous release. For more information on updating change logs can be found in [`CONTRIBUTING.md`](../../CONTRIBUTING.md#updating-the-change-log)

# Misc

## Publish to PowerShell Gallery

To publish your module to the [official PowerShell gallery](http://www.powershellgallery.com/) or the test gallery site, contact the Azure PowerShell team