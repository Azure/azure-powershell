# Azure PowerShell Developer Guide

The Azure PowerShell Developer Guide was created to help with the development and testing of Azure PowerShell cmdlets. This guide contains information on how to set up your environment, create a new project, implement cmdlets, record and run tests, and more.

# Table of Contents

- [Prerequisites](#prerequisites)
- [Environment Setup](#environment-setup)
    - [GitHub Basics](#github-basics)
    - [Building the Environment](#building-the-environment)
    - [Running Tests](#running-tests)
- [Before Adding a New Project](#before-adding-a-new-project)
    - [.NET SDK](#net-sdk)
    - [Design Review](#design-review)
    - [Contact](#contact)
- [Setting Up a New Project](#setting-up-a-new-project)
    - [Getting Started](#getting-started)
        - [Creating the Project](#creating-the-project)
        - [Adding Project References](#adding-project-references)
            - [`Commands.Common`](#commandscommon)
            - [`Commands.Common.Authentication`](#commandscommonauthentication)
            - [`Commands.Common.Authentication.Abstractions`](#commandscommonauthenticationabstractions)
            - [`Commands.ResourceManager.Common`](#commandsresourcemanagercommon)
            - [`Commands.ScenarioTests.Common`](#commandsscenariotestscommon)
            - [Other projects](#other-projects)
- [Creating Cmdlets](#creating-cmdlets)
    - [PowerShell Cmdlet Design Guidelines](#powershell-cmdlet-design-guidelines)  
    - [Enable Running PowerShell when Debugging](#enable-running-powershell-when-debugging)
        - [Importing Modules](#importing-modules)
    - [Adding Help Content](#adding-help-content)
    - [Updating the Installer](#updating-the-installer)
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
    - [AsJob Parameters](#asjob-parameters)
    - [Argument Completers](#argument-completers)
        - [Resource Group Completer](#resource-group-completers)
        - [Location Completer](#location-completer)
        - [Generic Argument Completer](#generic-argument-completer)

# Prerequisites

The following prerequisites should be completed before contributing to the Azure PowerShell repository:

- Install [Visual Studio 2015](https://www.visualstudio.com/downloads/)
- Install the latest version of [Git](https://git-scm.com/downloads)
- Install the latest version of [WiX](http://wixtoolset.org/releases/)
    - After installation, ensure that the path to "WiX Toolset\bin" has been added to your `PATH` environment variable
- Install the [`platyPS` module](https://github.com/Azure/azure-powershell/blob/preview/documentation/help-generation.md#installing-platyps)
- Set the PowerShell [execution policy](https://technet.microsoft.com/en-us/library/ee176961.aspx) to **Unrestricted** for the following versions of PowerShell:
    - `C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe`
    - `C:\Windows\SysWOW64\WindowsPowerShell\v1.0\powershell.exe`
    
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

Then, to pull changes from the **preview** branch in _Azure/azure-powershell_ into your local working branch, run the following command:

```
git pull upstream preview
```

## Building the Environment

_Note_: to build the environment locally, you need `platyPS` install on your machine. Please see the [Prerequisites](#prerequisites) section for details on how to install this module.

After cloning the repository to your local machine, you want to ensure that you can build the environment. To do so, launch `VS Developer Command Prompt` (which is installed with Visual Studio) and run the following command (from the root of the repository) to do a full build:

```
msbuild build.proj
```

Another way to build the project is by using the `Repo-Tasks` module found in the repository:

1. In the `tools` folder of the repository, double-click `PS-VSPrompt.lnk`
    - This opens up a terminal that acts as PowerShell and VS Developer Command Prompt
2. Run `Import-Module .\Repo-Tasks.psd1`
    - This imports a [module containing cmdlets and functions that help with miscellaneous environment tasks](../testing-docs/repo-tasks-module.md)
3. Run the `Start-Build` cmdlet to do a full build of the project
    - This builds each of the individual projects in the repository



### Skipping Help Generation During Build

By default, we build the `dll-Help.xml` files (used to display the help content for cmdlets in PowerShell) from markdown using the `platyPS` module. Since this help generation step can take 10-15 minutes, we have added the ability to skip it as a part of the command line build process:

```
msbuild build.proj /p:SkipHelp=true
```

_Note_: when [updating the installer](#updating-the-installer), you **should not** skip the help generation step, as it removes the `dll-Help.xml` files from the wxi file.

## Running Tests

With the same terminal open from the previous section, run the cmdlet `Invoke-CheckinTests` to run all of the tests in the project

Alternatively, you can launch `VS Developer Command Prompt` and run the following command (from the root of the repository) to run all of the tests:

```
msbuild build.proj /t:Test
```

# Before Adding a New Project

## .NET SDK

Before adding a new project to Azure PowerShell, you must have generated an [SDK for .NET](https://github.com/Azure/azure-sdk-for-net) using [AutoRest](https://github.com/Azure/autorest) for your service, and it must have been merged into the repository. 

For more information about on-boarding a new library in the SDK for .NET repository, click [here](https://github.com/Azure/azure-sdk-for-net#to-on-board-new-libraries).

## Design Review

Before development, you must meet with the Azure PowerShell team to have a design review for your proposed PowerShell cmdlets. We advise that this review is held no earlier than three weeks out from code complete of the release you want to ship the cmdlets with. For a small number of cmdlet changes and/or additions, an email containing the markdown files for the proposed changes is suggested. For a large number of changes and/or additions, a meeting is required with the Azure PowerShell team.

Before submitting a design review, please be sure that you have read the [Azure PowerShell Design Guidelines](./azure-powershell-design-guidelines.md) document.

Please email the **azdevxpsdr** alias to set up this review and include the following information:
- Short description of the top-level scenarios
- Proposed cmdlet syntax
- Sample output of cmdlets

We recommend using the `platyPS` module to easily generate markdown files that contains the above information and including the files in the email.

## Point of Contact

You must provide a contact (Microsoft alias + GitHub alias) on your team that is responsible for handling issues with your SDK and cmdlets, as well as open source contributions to your code.

Also, members of your team (who are involved with the SDKs) are advised to join the [Azure SDK slack channel](https://azuresdk.slack.com), and join the **adxsdkpartners** alias on idweb.

# Setting Up a New Project

## Getting Started

When adding a new ResourceManager project, please follow these guidelines:

### Creating the Project

Add a new folder under `src/ResourceManager` with your service specific name (_e.g.,_ `Compute`, `Sql`, `Websites`).

 Open Visual Studio 2015 and create a new project using `File > New > Project`, or <kbd>CTRL</kbd> + <kbd>SHIFT</kbd> + <kbd>N</kbd>. Under `Templates > Visual C#`, select the `Class Library` project (not the `.NET Core` version), name it after your service (_e.g.,_ `Compute`) and set the location to the folder you just created in `src/ResourceManager`.

 > Make sure that the `<SERVICE>.sln` file is saved in the `src/ResourceManager/<SERVICE>` folder.

 Once the solution is opened, open the `Solution Explorer` and right click on the project (not the top-level solution) and select `Remove`. Right click on the `<SERVICE>` solution and create a new project using `Add > New Project`, naming the new project `Commands.<SERVICE>`.

 Once created, right click on the `Commands.<SERVICE>` project in the `Solution Explorer` and select `Unload project`. Right click on the unloaded project and select `Edit Commands.<SERVICE>.csproj`. Once opened, ensure that the following things are changed:
 - The `RootNamespace` and `AssemblyNamespace` attributes of the project _must_ be changed to `Microsoft.Azure.Commands.<SERVICE>`. If these changes are not made, then the assembly produced from this project is not be signed and results in errors when users try to use your module.
 - Under the `Debug|AnyCPU` property group, change the `OutputPath` attribute to `..\..\..\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.<SERVICE>`
 - Under the `Release|AnyCPU` property group, make the following changes:
    - Change the `OutputPath` attribute to `..\..\..\Package\Release\ResourceManager\AzureResourceManager\AzureRM.<SERVICE>`
    - Add the constant `SIGN` to the `DefineConstants` attribute
    - Add `<SignAssembly>true</SignAssembly>`
    - Add `<AssemblyOriginatorKeyFile>MSSharedLibKey.snk</AssemblyOriginatorKeyFile>`, making sure to copy the `MSSharedLibKey.snk` file from another project into the `Commands.<SERVICE>` folder
    - Add `<DelaySign>true</DelaySign>`

Right click on the project and select `Reload project`, and then build the solution by either right clicking on the solution and selecting `Rebuild Solution` or, from the top of Visual Studio, selecting `Build > Rebuild Solution`. If the build does not succeed, open the `.csproj` file and ensure there are no errors.

### Adding Project References

There are a few existing projects that need to be added before developing any cmdlets. To add a project to the solution, right click on the solution in `Solution Explorer` and select `Add > Existing Project`. This allows you to navigate through folders to find the `.csproj` of the project you want to add. Once a project is added to your solution, you can add it as a reference to the `Commands.<SERVICE>` project by right clicking on `Commands.<SERVICE>` and selecting `Add > Reference`. This opens the `Reference Manager` window, and once you have selected the `Projects > Solution` option on the left side of the window, you are able to select which projects you want to reference in `Commands.<SERVICE>` by checking the box to the left of the name.

The following is a list of projects you want to add to your solution and reference:

#### `Commands.Common`

The `Commands.Common` project can be found in `src/Common/Commands.Common`.

#### `Commands.Common.Authentication`

The `Commands.Common.Authentication` project can be found in `src/Common/Commands.Common.Authentication`.

#### `Commands.Common.Authentication.Abstractions`

The `Commands.Common.Authentication.Abstractions` project can be found in `src/Common/Commands.Common.Authentication.Abstractions`.

#### `Commands.ResourceManager.Common`

The `Commands.ResourceManager.Common` project can be found in `src/ResourceManager/Common/Commands.ResourceManager.Common`.

#### `Commands.ScenarioTests.Common`

The `Commands.ScenarioTests.Common` project can be found in `src/ResourceManager/Common/Commands.ScenarioTests.Common`.

#### Other Projects

The following is a list of additional common code projects that can be used:

- `Commands.Common.Authorization`
    - Found in `src/ResourceManager/Common/Commands.Common.Authorization`
- `Commands.Common.Graph.RBAC`
    - Found in `src/ResourceManager/Common/Commands.Common.Graph.RBAC`
- `Commands.Common.Network`
    - Found in `src/ResourceManager/Common/Commands.Common.Network`
- `Commands.Common.Storage`
    - Found in `src/ResourceManager/Common/Commands.Common.Storage`

# Creating Cmdlets

## PowerShell Cmdlet Design Guidelines

Please check out the [PowerShell Cmdlet Design Guidelines](./azure-powershell-design-guidelines.md) page for more information on how to create cmdlets that follow the PowerShell guidelines.

## Enable Running PowerShell when Debugging

- Choose any project and set it as the startup project in Visual Studio
     - Right click on your project in the **Solution Explorer** and select **Set as StartUp project**
- Right-click on the project and select **Properties**
- Go to the **Debug** tab
- Under **Start Action**, pick _Start external program_ and type the PowerShell directory
    - For example, `C:\Windows\SysWOW64\WindowsPowerShell\v1.0\powershell.exe`

### Importing Modules

To import modules automatically when debug has started, follow the below steps:

- In the **Debug** tab mentioned previously, go to **Start Options**
- Import the Profile module, along with the module you are testing, by pasting the following in the **Command line arguments** box (_note_: you have to update the <PATH_TO_REPO> and <SERVICE> values provided below):
    - `-NoExit -Command "Import-Module <PATH_TO_REPO>/src/Package/Debug/ResourceManager/AzureResourceManager/AzureRM.Profile/AzureRM.Profile.psd1;Import-Module <PATH_TO_REPO>/src/Package/Debug/ResourceManager/AzureResourceManager/AzureRM.<SERVICE>/AzureRM.<SERVICE>.psd1;$VerbosePreference='Continue'"`

## Adding Help Content

All cmdlets that are created must have accompanying help that is displayed when users execute the command `Get-Help <your cmdlet>`.

Each cmdlet has a markdown file that contains the help content that is displayed in PowerShell; these markdown files are created (and maintained) using the platyPS module.

For complete documentation, see [`help-generation.md`](./help-generation.md) in the `documentation` folder.

## Updating the Installer

The installer should be updated whenever a library dependency is added/removed from your project module, or file paths are changed.

To regenerate the install wxi file, follow these steps:

- Ensure that the WiX tools bin folder is in your `PATH` environment variable
- Set the `AzurePSRoot` environment variable to the path of your locally cloned Azure PowerShell repository
    - `set AzurePSRoot=C:\<PATH_TO_REPO>\azure-powershell`
- Build the cmdlets
    - Follow the steps mentioned in [building the environment](#building-the-environment)
    - This builds both the cmdlets and the installer - if your changes have removed or renamed files previously contained in the installer, the installer build may fail. In this case, you can ignore installer build failures
-  Generate the new wxi file using the `generate.ps1` script
    - `powershell .\tools\installer\generate.ps1 <BUILD_CONFIG>`
    - `<BUILD_CONFIG>` is `DEBUG` or `RELEASE`, depending on which build configuration you are using
- Verify that the changes look correct uses `git diff`. Often times, unintended changes happen if your repository is not clean; if this occurs, revert the changes made to the wxi file, commit all other changes, and use `git clean -xdf` to wipe out all untracked files from your local git repository

# Adding Tests

_Note_: As mentioned in the prerequisites section, set the PowerShell [execution policy](https://technet.microsoft.com/en-us/library/ee176961.aspx) to **Unrestricted** for the following versions of PowerShell:

- `C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe`
- `C:\Windows\SysWOW64\WindowsPowerShell\v1.0\powershell.exe`

## Using Azure TestFramework

Please see our guide on [Using Azure TestFramework](../testing-docs/using-azure-test-framework.md) for information on how to setup the appropriate connection string and record tests using the `Microsoft.Rest.ClientRuntime.Azure.TestFramework` package. 

## Scenario Tests

### Adding Scenario Tests

- Create a new class in either `Commands.ScenarioTests` or `Commands.SERVICE.Test`
    - If you are setting up a new project, add a reference to `Commands.ScenarioTests.Common`
    - If you are setting up a new project, set the post build event to the following:
        - `xcopy "$(SolutionDir)Package\$(ConfigurationName)\*.*" $(TargetDir) /Y /E`
    - Add a reference to any project that is to be tested
- Create a ps1 file in the same folder that contains the actual tests ([see sample](../../src/ResourceManager/Resources/Commands.Resources.Test/ScenarioTests))
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
- Add a private variable `EnvironmentSetupHelper helper` to the test class
- Set each test as an XUnit test that does the following:

```cs
// Enable undo functionality as well as mock recording
using (UndoContext context = UndoContext.Current)
{
    // Configure recordings
    context.Start(TestUtilities.GetCallingClass(), TestUtilities.GetCurrentMethodName());

    // See explanation below
    SetupManagementClients();

    // Specify either ResourceManager or ServiceManagement mode
    helper.SetupEnvironment(AzureModule.AzureResourceManager);

    // Add all ps1 files used in the test
    helper.SetupModules(AzureModule.AzureResourceManager, "ScenarioTests\\Common.ps1",
        "ScenarioTest\\" + this.GetType().Name + ".ps1");

    // Run actual test
    helper.RunPowerShellTest(scripts); 
}
```

### Using Common code
In Commands.ScenarioTests.ResourceManager.Common, you can find functions to simplify scenario tests.
- Use the Get-Location function (which can be found in Common.ps1) to obtain a valid location for your cmdlet given the provider and the resource type.
    - `Get-Location -providerNamespace "Microsoft.Batch" -resourceType "operations" -preferredLocation "West US"`

### Using Active Directory (works for Resource Manager and Service Manager)

- Use the `Set-TestEnvironment` cmdlet from `Repo-Tasks.psd1` to setup your connection string
- Alternatively, you can set the following environment variables
    - `TEST_CSM_ORGID_AUTHENTICATION` is used for Resource Manager testing
    - `TEST_ORGID_AUTHENTICATION` is used for Service Manager testing
    - Both environment variables need to be set for the test framework to correctly work

> **Important!**
> 1. Be sure that you have set the `ExecutionPolicy` to `Unrestricted` on both 32-bit and 64-bit PowerShell environments, as mentioned in the [prerequisites](#prerequisites) at the top
> 2. When recording tests, if you are using a Prod environment, use ServicePrincipalName (SPN) and ServicePrincipalSecret. For more information on creating an SPN, click [here](https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-create-service-principal-portal).

### Using Certificate (works for Service Manager only)

- In an Azure Storage, create a new container called `testcredentials-production`
- Upload these three files there:
    - `default.publishsettings` - the publish settings file used in the tests
    - `environment.yml` - the environment variables you want to inject (click [here](https://en.wikipedia.org/wiki/YAML) for yml file format)
    - `variables.yml` - the PowerShell variables you want to inject
- On your machine, set these environment variables:
    - `AZURE_TEST_ENVIRONMENT=production`
    - `AZURE_STORAGE_ACCOUNT=<storage account name>`
    - `AZURE_STORAGE_ACCESS_KEY=<storage account key>`
- Run the scenario tests by executing the following command:
    - `msbuild build.proj /t:Scenariotest` 

### AD Scenario Tests

Create these environment variables for the AD scenario tests:

- `AZURE_LIVEID` should be UserId and Password for a valid LiveId account.
    - `AZURE_LIVEID=UserId=<user@hotmail.com>;Password=<Password>`
- `AZURE_ORGID_FPO` should be an orgid and password for an account that does not have any subscriptions or role assignments associated with it. It is supposed to be a foreign principal in your current tenant.
     - `AZURE_ORGID_FPO=UserId=<user@orgid.com>;Password=<Password>`
-  `AZURE_ORGID_ONE_TENANT_ONE_SUBSCRIPTION` should be an account that is in a single tenant and has access to the subscription managed by that AD tenant.
    - `AZURE_ORGID_ONE_TENANT_ONE_SUBSCRIPTION=UserId=<user@orgid.com>;Password=<Password>;SubscriptionId=<SubscriptionId>;AADAuthEndpoint=https://login.windows.net/`
- `AZURE_SERVICE_PRINCIPAL` should be a service principal - an application defined in the subscription's tenant - that has management access to the subscription (or at least to a resource group in the tenant)
    - `AZURE_SERVICE_PRINCIPAL=UserId=<UserGuid>;Password=<Password>;AADTenant=<TenantGuid>;SubscriptionId=<SubscriptionId>`

### Recording/Running Tests 

- Set up environment variables using New-TestCredential as described [here](../testing-docs/using-azure-test-framework.md#new-testcredential)
- [Run the test](#running-tests) and make sure you got a generated JSON file that matches the test name in the bin folder under the `SessionRecords` folder
- Copy this `SessionRecords` folder and place it inside the test project
    - Inside Visual Studio, add all of the generated JSON files, making sure to change the "Copy to Output Directory" property for each one to "Copy if newer"
    -  Make sure that all of these JSON files appear in your `Commands.SERVICE.Test.csproj` file

# After Development

Once all of your cmdlets have been created and the appropriate tests have been added, you can open a pull request in the Azure PowerShell repository to have your cmdlets added to the next release. Please make sure to read [CONTRIBUTING.md](https://github.com/Azure/azure-powershell/blob/preview/CONTRIBUTING.md) for more information on how to open a pull request, clean up commits, make sure appropriate files have been added/changed, and more.

# Misc

## Publish to PowerShell Gallery

- To publish your module to the [official PowerShell gallery](http://www.powershellgallery.com/), or the test gallery site, contact the Azure PowerShell team
- To create a signed module package for local usage, use the [powershell-sign](http://azuresdkci.cloudapp.net/view/1-AzurePowerShell/job/powershell-sign/) job on Jenkins

## AsJob Parameter

All long running operations must implement the `-AsJob` parameter, which will allow the user to create jobs in the background. For more information about PowerShell jobs and the -AsJob parameter, read [this doc](https://docs.microsoft.com/en-us/powershell/azure/using-psjobs).

To implement the `-AsJob` parameter, simply add the parameter to the end of the parameter list:

````cs
[Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
public SwitchParameter AsJob { get; set; }
````

Once you add the parameter, please manually test that the job is created and successfully completes when the parameter is specified.  Additionally, please ensure that the help files are updated with this parameter.

To ensure that `-AsJob` is not broken in future changes, please add a test for this parameter. To update tests to include this parameter, use the following pattern:

````powershell
$job = Get-AzureRmSubscription
$job | Wait-Job
$subcriptions = $job | Receive-Job
````

## Argument Completers

PowerShell uses Argument Completers to provide tab completion for users.  At the moment, Azure PowerShell has two specific argument completers that should be applied to relevant parameters, and one generic argument completer that can be used to tab complete with a given list of values.  To test the completers, run a complete build after you have added the completers (``` msbuild build.proj ```) and ensure that the psm1 file (AzureRM.\<Service\>.psm1) has been added to the psd1 file found in src/Package/Debug/ResourceManager/AzureResourceManager/AzureRM.\<Service\>/AzureRM.\<Service\>.psd1 under "Root Module".

### Resource Group Completer

For any parameter that takes a resource group name, the `ResourceGroupCompleter` should be applied as an attribute.  This will allow the user to tab through all resource groups in the current subscription.

```cs
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
...
[Parameter(Mandatory = false, HelpMessage = "The resource group name")]
[ResourceGroupCompleter]
public string ResourceGroupName { get; set; }
```

### Location Completer

For any parameter that takes a location, the `LocationCompleter` should be applied as an attribute.  In order to use the `LocationCompleter`, you must input as an argument all of the Providers/ResourceTypes used by the cmdlet.  The user will then be able to tab through locations that are valid for all of the Providers/ResourceTypes specified.

```cs
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
...
[Parameter(Mandatory = false, HelpMessage = "The location of the resource")]
[LocationCompleter("Microsoft.Batch/operations")]
public string Location { get; set; }
```

### Generic Argument Completer

For any parameter which you would like the user to tab through a list of suggested values (but you do not want to limit the users to only these values), the generic argument completer should be added.

```cs
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
...
[Parameter(Mandatory = false, HelpMessage = "The tiers of the plan")]
[PSArgumentCompleter("Basic", "Premium", "Elite")]
public string Tier { get; set; }
```
