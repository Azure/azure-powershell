# Azure PowerShell Help Generation

## Description

All MAML files containing the help content for cmdlets have been removed from the Azure PowerShell repository and replaced with markdown files, which are generated and maintained using the [`platyPS`](https://github.com/PowerShell/platyPS) module. Each module has a `help` folder (_e.g.,_ `src/Accounts/Accounts/help`) which contains a markdown file for each of the cmdlets found in that given module. When the help content for a cmdlet (or multiple cmdlets) needs to be updated, users will now only have to update the contents of the markdown file, _and not the MAML file as well_.

## Installing `platyPS`

In order to use the cmdlets necessary to update the markdown help files (or generate MAML help locally from these markdown files), you must first install the `platyPS` module mentioned previously.  You will need to install a minimum version of 0.11.0.

To do so, you can follow the below steps (which are outlined in the [**Quick start**](https://github.com/PowerShell/platyPS#quick-start) section of the `platyPS` README):

```powershell
Install-Module -Name platyPS -Scope CurrentUser
```

**Note:** this module will need to be installed from the [PowerShell Gallery](http://www.powershellgallery.com/). If, for some reason, this isn't a registered repository when running the `Get-PSRepository` cmdlet, then you will need to register it by running the following command:

```powershell
Register-PSRepository -Default -InstallationPolicy Trusted
```

## Using `platyPS`

### Importing your module

Before you run the `platyPS` cmdlets to update your markdown help files, you will need to first import the module containing the changes that you have made to your cmdlets into your current PowerShell session. Once you have built your project (either through Visual Studio or with `msbuild`), you can locate the module manifest that you will need to import in the `artifacts/Debug` folder of your local repository.

For example, if you have made changes to the `Accounts` module, you will find the corresponding module manifest in `artifacts/Debug/Az.Accounts/Az.Accounts.psd1`.

Once you have located the module manifest, you can import it in your current PowerShell session by running the following command:

```powershell
$PathToModuleManifest = "../../<module>.psd1"
Import-Module -Name $PathToModuleManifest
```

**Note**: if you do not see all of the changes you made to the cmdlets in your markdown files (_e.g.,_ a cmdlet you deleted is still appearing), you may need to delete any existing Azure PowerShell modules that you have on your machine (installed either through the PowerShell Gallery or by Web Platform Installer) before you import your module.

### Generating help for a new module

For new modules with no existing `help` folder containing the markdown help files, run the following command to do an initial generation:

```powershell
$PathToHelpFolder = "../../help" # Full path to help folder containing markdown files to be generated (e.g., src/Accounts/Accounts/help)
New-MarkdownHelp -Module {{moduleName}} -OutputFolder $PathToHelpFolder -AlphabeticParamsOrder -UseFullTypeName -WithModulePage
```

Once this folder has been generated, follow the steps provided in the below section to update the files with any changes made to the public interface of the cmdlets.

### Updating help after making cmdlet changes

Whenever the public interface for a cmdlet has changed, the corresponding markdown file for that cmdlet will need to be updated to reflect the changes. Public interface changes include the following:

- Add/change/remove parameter set
- Add/remove parameter
- Change attribute of a parameter
    - Type
    - Parameter set(s)
    - Aliases
    - Mandatory
    - Position
    - Accept pipeline input
- Add/change output type

#### Updating all markdown files in a module

To update all of the markdown files for a single module, use the [`Update-MarkdownHelpModule`](https://github.com/PowerShell/platyPS/blob/master/docs/Update-MarkdownHelpModule.md) cmdlet:

```powershell
$PathToModuleManifest = "../../<module>.psd1" # Full path to the module manifest that you have updated
Import-Module -Name $PathToModuleManifest

$PathToHelpFolder = "../../help" # Full path to help folder containing markdown files to be updated
Update-MarkdownHelpModule -Path $PathToHelpFolder -RefreshModulePage -AlphabeticParamsOrder -UseFullTypeName
```

If you would like to update the inputs/outputs for a markdown file, please run this cmdlet with the -UpdateInputOutput parameter.  Keep in mind that this will overwrite any customized descriptions of inputs and outputs, so you will need to add these descriptions back if still relevant.

This will update all of the markdown files with public interface changes made to corresponding cmdlets, add markdown files for any new cmdlets, remove markdown files for any deleted cmdlets, and update the module page (_e.g.,_ `Az.Accounts.md`) with any added or removed cmdlets.

_This seems to work better when run from within the `help` folder itself (For e.g. to generate the help files for the [`Network`](https://github.com/Azure/azure-powershell/tree/master/src/Network) module run the cmd from under [`Commands.Network/help`](https://github.com/Azure/azure-powershell/tree/master/src/Network/Network/help)). Also, you will have to import the profile module from under <Repo base path>/artifacts/Debug/Az.Accounts/Az.Accounts.psd1_
 
#### Updating a single markdown file

To update a single markdown file with the changes made to the corresponding cmdlet, use the [`Update-MarkdownHelp`](https://github.com/PowerShell/platyPS/blob/master/docs/Update-MarkdownHelp.md) cmdlet:

```powershell
$PathToModuleManifest = "../../<module>.psd1" # Full path to the module manifest that you have updated
Import-Module -Name $PathToModuleManifest

$PathToMarkdownFile = "../../<cmdlet>.md" # Full path to the markdown file to be updated
Update-MarkdownHelp -Path $PathToMarkdownFile -AlphabeticParamsOrder -UseFullTypeName
```

If you would like to update the inputs/outputs for a markdown file, please run this cmdlet with the -UpdateInputOutput parameter.  Keep in mind that this will overwrite any customized descriptions of inputs and outputs, so you will need to add these descriptions back if still relevant.

#### Generating and viewing the MAML help

During the build, the MAML help will be generated from the markdown files in the repository. If you would like to generate the MAML help and preview what the help content will look like for each of your cmdlets, you can do so with two more commands.

To generate the MAML help based on the contents of your markdown files, use the [`New-ExternalHelp`](https://github.com/PowerShell/platyPS/blob/master/docs/New-ExternalHelp.md) cmdlet:

```powershell
$PathToHelpFolder = "../../help" # Full path to help folder containing markdown files to be updated
$PathToOutputFolder = "../../.." # Full path to folder where you want the MAML file to be generated
New-ExternalHelp -Path $PathToHelpFolder -OutputPath $PathToOutputFolder
```

To preview the help that you just generated, use the [`Get-HelpPreview`](https://github.com/PowerShell/platyPS/blob/master/docs/Get-HelpPreview.md) cmdlet:

```powershell
$PathToMAML = "../../<maml>.dll-Help.xml" # Full path to the MAML file that was generated

# Save the help locally
$help = Get-HelpPreview -Path $PathToMAML

# Get the help for a specific cmdlet
$help | where { $_.Name -eq "<cmdlet>" }
```
