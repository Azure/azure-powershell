# PlatyPS Help

- [Description](#description)
- [Getting Started](#getting-started)
    - [Installing the platyPSHelp Module](#installing-the-platypshelp-module)
    - [Running the New-ServiceMarkdownHelp cmdlet](#running-the-new-servicemarkdownhelp-cmdlet)
    - [Running the Validate-ServiceMarkdownHelp cmdlet](#running-the-validate-servicemarkdownhelp-cmdlet)
    - [Running the Update-ServiceMarkdownHelp cmdlet](#running-the-update-servicemarkdownhelp-cmdlet)
- [How it Works](#how-it-works)
    - [Creating markdown](#creating-markdown)
    - [Updating markdown](#updating-markdown)
    - [Updating XML help](#updating-xml-help)
    - [Previewing XML help](#previewing-xml-help)
    - [Steps for creating help](#steps-for-creating-help)
- [Changes to Cmdlets](#changes-to-cmdlets)
- [Markdown Format](#markdown-format)
- [Issue with Example Formatting](#issue-with-example-formatting)

## Description

PlatyPS is used to create PowerShell external help in markdown rather than XML (MAML). Where as XML help (MAML) can be difficult to edit by hand or read, markdown is designed to be human-readable and easy to edit. This will allow service teams to quickly and easily edit any help documentation they have for their cmdlets.

Install (and read more about) platyPS from the README, located [here](https://github.com/PowerShell/platyPS/blob/master/README.md).

## Getting Started

If your service does not currently have any markdown help, follow the below steps to get started.

**NOTE**: Currently, the platyPSHelp module mentioned below is unable to create markdown help for **ServiceManagement** cmdlets. However, markdown help can be created for these cmdlets when running the regular platyPS cmdlets mentioned in the [How it Works](#how-it-works) section.

### Installing the `platyPSHelp` Module

The `platyPSHelp` module contains cmdlets that will help service teams with creating, updating, and validating markdown help. 

There are three cmdlets contained in this module:
- `New-ServiceMarkdownHelp`
- `Update-ServiceMarkdownHelp`
- `Validate-ServiceMarkdownHelp`

Help documentation has been written for each of these cmdlets, outlining the purpose of each cmdlet, the different parameter sets, and examples.

To use this module, change your directory to the **azure-powershell** repo, and from there, go to `tools\platyPS`. Run the following command to import the module:

```powershell
Import-Module .\platyPSHelp.psd1
```

After executing this command, you will have access to the above cmdlets.

### Running the `New-ServiceMarkdownHelp` cmdlet

Once the module is installed, you will need to generate the markdown for your cmdlets; to do so, you will run the `New-ServiceMarkdownHelp` cmdlet.

There are four possible parameter sets to choose from when creating your cmdlets:
- `ResourceManager`
    - This parameter set will be used if you are an ARM service
- `ServiceManagement`
    - This parameter set will be used if you are an RDFE service
- `Storage`
    - This parameter set will be used for the Storage team
- `FullPath`
    - This parameter set will be used if there is an issue when using any of the above parameter sets (*e.g.*, the path to the XML help (MAML) or commands folder does not follow what the cmdlet is expecting); in this case, you can provide the full path to the required items

More information about this cmdlet can be found in the [help]("..\tools\platyPSHelp\help\New-ServiceMarkdownHelp.md").

Once ran, this cmdlet will create markdown files for each of the cmdlets in your module, and will be placed in the help folder located on the same level as your XML help (MAML). It will also regenerate the XML help (MAML) to ensure that the information in the markdown help is seen when `Get-Help` or `Get-HelpPreview` is ran.
 
### Running the `Validate-ServiceMarkdownHelp` cmdlet

Before checking in this markdown, you will need to check to make sure all of the necessary parts are filled out (*i.e.*, synopsis, description, examples, parameter descriptions, and outputs). 

This cmdlet contains the same four parameter sets as the `New-ServiceMarkdownHelp`, and more information about the cmdlet can be found in the [help]("..\tools\platyPSHelp\help\Validate-ServiceMarkdownHelp.md").

Once ran, this cmdlet will output a list of errors for each cmdlet in the following format:

```
==========

File: Some-Cmdlet.md

-- No description found
-- No examples found
-- No description found for parameter Foo

==========
```

This will let you know what parts of the markdown help need to be updated. A recommended tool for editing and visualizing markdown is [Dillinger](http://dillinger.io/), which will display your markdown changes in real-time.

### Running the `Update-ServiceMarkdownHelp` cmdlet

Anytime that you make changes to a cmdlet (*e.g.*, add/edit/remove parameter, edit output type, etc.), you will need to make sure that those changes are reflected in the markdown. The `Update-ServiceMarkdownHelp` cmdlet will update your markdown with the changes made to your cmdlets.

This cmdlet contains the same four parameter sets as the other two cmdlets, and more information about the cmdlet can be found in the [help]("..\tools\platyPSHelp\help\Update-ServiceMarkdownHelp.md").

In addition to updating the markdown help files, it will also regenerate the XML help (MAML) to ensure that the information in the markdown help is seen when `Get-Help` or `Get-HelpPreview` is ran.

## How it Works

### Creating markdown

Using the `New-MarkdownHelp` cmdlet, platyPS generates a markdown file for each cmdlet in a XML help (MAML) file and/or module, depending on the parameters of the call.

For instance, if the following command is called
```powershell
New-MarkdownHelp -OutputFolder $PathToHelp -MamlFile $MAML
```
then the markdown files will be generated from the information in the XML help (MAML) file.

However, if the following command is called
```powershell
New-MarkdownHelp -OutputFolder $PathToHelp -Module $ModuleName -WithModulePage
```
then the markdown files will be generated from the information in the XML help (MAML) file (found in the module) **and** using reflection on the cmdlet implementation in the module.

#### NOTE

Please refer to the [Issue with Example Formatting](#issue-with-example-formatting) section at the bottom to resolve a problem found in cmdlets using rows and columns for variable data in their examples.

### Updating markdown

Once you have created the markdown files for each cmdlet, you must make sure to keep them up to date based on changes to the cmdlets.

The **recommended** way to update the markdown files is to use the cmdlet `Update-MarkdownHelpModule`; this method handles both changes to cmdlets **and** the addition of cmdlets. Use the following command:
```powershell
Update-MarkdownHelpModule -Path $PathToHelp
```
where `$PathToHelp` is the path to the folder containing all of the markdown help.

This command updates all the files in the specified folder based on the cmdlets as loaded into your current session. It is the same as calling `New-MarkdownHelp` and `Update-MarkdownHelp` and merging the results together.

If any changes are made to a cmdlet (*i.e.,* add/remove parameters, add/remove parameter sets, etc.), the corresponding markdown can be updated through reflection by using the following command
```powershell
Update-MarkdownHelp -Path $PathToHelp
```
where `$PathToHelp` is the path to the folder containing all of the markdown help.

If a cmdlet is added to your module, then the above command will not work; you must first add the corresponding markdown file by running the following command (also used in the previous section):
```powershell
New-MarkdownHelp -OutputFolder $output -Module $module -WithModulePage
```

### Updating XML help

After you have created or updated your markdown for the cmdlets, you need to update the XML help (MAML) so it can be used with `Get-Help` in PowerShell. 

Updating XML help (MAML) can be done with the following command:
```powershell
New-ExternalHelp -Path $path -OutputPath $outputPath -Force
```
where `$path` is the path to the folder containing all of the markdown help, and `$outputPath` is the path to the folder containing the existing XML help (MAML) which will be replaced.

This command generates the XML help (MAML) based solely on the markdown files. All the information from the cmdlets (thru reflection) are already incorporated into the markdown thru `New-MarkdownHelp` and `Update-MarkdownHelp` (or `Update-MarkdownHelpModule`). This means that you won't need to build/install/import modules to generate help for them.

### Previewing XML help

After you have created or updated your markdown for the cmdlets, you can preview what the corresponding XML help (MAML) will look like in PowerShell with the `Get-HelpPreview` cmdlet. This cmdlet will generate the XML help (MAML) from the markdown files and display it in PowerShell so you can see if the help looks correct.

Running the following command will display the help for **all** of your cmdlets:
```powershell
Get-HelpPreview -Path $PathToMAML
```
where `$PathToMAML` is the path to the XML help (MAML) help file you generated.

To get the help for a single cmdlet, run the following command:
```powershell
$Help = Get-HelpPreview -Path $PathToMAML
$Help | Where-Object {  $_.Name -eq $CmdletName }
```

### Steps for creating help

The following is a breakdown of the steps taken by the `New-ServiceMarkdownHelp` cmdlet

**1: Create a folder for your service**

In the `azure-powershell` repository, navigate to the `help` folder in the root, and, if your service does not already have one, create a new folder that will hold the markdown files for your service

**2: Import your module**

Run the following command in PowerShell:

```powershell
Import-Module $PathToModule
```
where `$PathToModule` is the path to the psd1 file for the project that was just built

**3: Generate the markdown files**

Run the following command in PowerShell:

```powershell
New-MarkdownHelp -Module $ModuleName -OutputFolder $PathToHelp -WithModulePage -AlphabeticParamsOrder
```
where `$ModuleName` is the name of your module, and `$PathToHelp` is the path to the folder where the markdown help will be placed (which should be on the same level as the XML help (MAML))

This will generate a markdown file for each cmdlet in your XML help (MAML) file. Make sure that all of the cmdlets that you have help for in the XML help (MAML) file have a corresponding markdown file in the folder.

**4: Generate the XML help file**

Run the following command in PowerShell:

```powershell
New-ExternalHelp -Path $PathToHelp -OutputPath $PathToCommandsFolder -Force
```
where `$PathToHelp` is the path to the folder containing the markdown help, and `$PathToCommandsFolder` is the path to the folder containing the XML help (MAML) and the help folder

This will generate a XML help (MAML) file based on the markdown files that you created in the previous step and replace the old XML help (MAML) file.

## Changes to Cmdlets

The following changes to a cmdlet require that the corresponding markdown help file be updated:

- Adding/removing parameters or parameter sets
- Adding/removing cmdlets
- Changing metadata of the cmdlet, parameters, or parameter sets

Begin with the following tasks:
- Build your project
- Open a new PowerShell window and import your project

Next, run the following command:

```powershell
Update-MarkdownHelpModule $PathToHelp
```
where `$PathToHelp` is the path to the folder containing the markdown help

This will automatically update your markdown files with the changes that you have made in your cmdlets.

**Note**: check to make sure that the changes you made to the cmdlets are reflected in their corresponding markdown files

After generating the updated markdown files, make sure to generate the updated XML help (MAML) file by running the following command:

```powershell
New-ExternalHelp -Path $PathToHelp -OutputPath $PathToCommandsFolder -Force
```
where `$PathToHelp` is the path to the folder containing the markdown help, and `$PathToCommandsFolder` is the path to the folder containing the XML help (MAML) and the help folder

## Markdown Format

If you want to edit the markdown files to add or remove your own help, there is a specified format that they need to follow in order to generate the corresponding XML help (MAML) help. A full guide for how the markdown file should be formatted can be found [here](https://github.com/PowerShell/platyPS/blob/master/platyPS.schema.md#version-200).

The following sections should be filled out for each cmdlet:
- SYNOPSIS
    - Gives a short overview of what the cmdlet does
- DESCRIPTION
    - An in-depth overview of what the cmdlet does
- EXAMPLES
    - Shows how to use the cmdlet with different parameter sets and describes how they function differently
- OUTPUTS
    - Defines what the output of the cmdlet is (what is sent out to the pipeline)

## Issue with Example Formatting

Some cmdlets have examples containing rows and columns of information after the PowerShell commands and remarks. For example:

    ### --------------------------  Example 1: Get capabilities for the current subscription for a region  --------------------------
    @{paragraph=PS C:\\\>}
    
    ```
    PS C:\> Get-AzureRmSqlCapability -LocationName "Central US"
    ```

    This command returns the capabilities for SQL Database on the current subscription for the Central US region.

    Location                : Central US
    Status                  : Available
    SupportedServerVersions : {12.0, 2.0}

However, the format of these rows and columns are not preserved when platyPS generates the XML help (MAML). In order to avoid this issue, please move the rows and columns into the code block of the example; this is how help for core PowerShell modules is written.

After making these changes, the resulting markdown would look like the following:

    ### --------------------------  Example 1: Get capabilities for the current subscription for a region  --------------------------
    @{paragraph=PS C:\\\>}
    
    ```
    PS C:\> Get-AzureRmSqlCapability -LocationName "Central US"
    
    Location                : Central US
    Status                  : Available
    SupportedServerVersions : {12.0, 2.0}
    ```

    This command returns the capabilities for SQL Database on the current subscription for the Central US region.

Making these changes will allow the table to preserve the format when the XML help (MAML) is displayed in the PowerShell window.