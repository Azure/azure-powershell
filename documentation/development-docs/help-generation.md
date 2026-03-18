# Azure PowerShell Help Generation

## Description

All MAML files containing the help content for cmdlets have been removed from the Azure PowerShell repository and replaced with markdown files, which are generated and maintained using the [`Microsoft.PowerShell.PlatyPS`](https://github.com/PowerShell/platyPS) module (v1.0+). Each module has a `help` folder (_e.g.,_ `src/Accounts/Accounts/help`) which contains a markdown file for each of the cmdlets found in that given module. When the help content for a cmdlet (or multiple cmdlets) needs to be updated, users will now only have to update the contents of the markdown file, _and not the MAML file as well_.

## Installing `Microsoft.PowerShell.PlatyPS`

In order to use the cmdlets necessary to update the markdown help files (or generate MAML help locally from these markdown files), you must first install the `Microsoft.PowerShell.PlatyPS` module mentioned previously. You will need to install a minimum version of 1.0.1.

To do so, you can follow the below steps:

```powershell
Install-Module -Name Microsoft.PowerShell.PlatyPS -Scope CurrentUser
```

**Note:** this module will need to be installed from the [PowerShell Gallery](http://www.powershellgallery.com/). If, for some reason, this isn't a registered repository when running the `Get-PSRepository` cmdlet, then you will need to register it by running the following command:

```powershell
Register-PSRepository -Default -InstallationPolicy Trusted
```

## Using `Microsoft.PowerShell.PlatyPS`

### Importing your module

Before you run the `Microsoft.PowerShell.PlatyPS` cmdlets to update your markdown help files, you will need to first import the module containing the changes that you have made to your cmdlets into your current PowerShell session. Once you have built your project (either through Visual Studio or with `msbuild`), you can locate the module manifest that you will need to import in the `artifacts/Debug` folder of your local repository.

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
New-MarkdownCommandHelp -ModuleInfo (Get-Module <module>) -OutputFolder $PathToHelpFolder -WithModulePage
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

To update all of the markdown files for a single module, use the `Update-MarkdownCommandHelp` and `Update-MarkdownModuleFile` cmdlets:

```powershell
$PathToModuleManifest = "../../<module>.psd1" # Full path to the module manifest that you have updated
Import-Module -Name $PathToModuleManifest

$PathToHelpFolder = "../../help" # Full path to help folder containing markdown files to be updated

# Update individual command help markdown files
$cmdletHelpFiles = Join-Path $PathToHelpFolder '*-*.md'
Update-MarkdownCommandHelp -Path $cmdletHelpFiles -NoBackup

# Refresh the module page with updated command list
$cmdHelp = Import-MarkdownCommandHelp -Path $cmdletHelpFiles
$moduleFile = Get-ChildItem -Path $PathToHelpFolder -Filter 'Az.*.md' | Where-Object { $_.Name -notlike '*-*' } | Select-Object -First 1
if ($moduleFile) { Update-MarkdownModuleFile -Path $moduleFile.FullName -CommandHelp $cmdHelp -NoBackup }
```

This will update all of the existing markdown files with public interface changes made to corresponding cmdlets and refresh the module page (_e.g.,_ `Az.Accounts.md`) from the markdown files currently on disk.

_This seems to work better when run from within the `help` folder itself (For e.g. to generate the help files for the [`Network`](https://github.com/Azure/azure-powershell/tree/main/src/Network) module run the cmd from under [`Commands.Network/help`](https://github.com/Azure/azure-powershell/tree/main/src/Network/Network/help)). Also, you will have to import the profile module from under <Repo base path>/artifacts/Debug/Az.Accounts/Az.Accounts.psd1_

#### Updating a single markdown file

To update a single markdown file with the changes made to the corresponding cmdlet, use the `Update-MarkdownCommandHelp` cmdlet:

```powershell
$PathToModuleManifest = "../../<module>.psd1" # Full path to the module manifest that you have updated
Import-Module -Name $PathToModuleManifest

$PathToMarkdownFile = "../../<cmdlet>.md" # Full path to the markdown file to be updated
Update-MarkdownCommandHelp -Path $PathToMarkdownFile -NoBackup
```

#### Generating and viewing the MAML help

During the build, the MAML help will be generated from the markdown files in the repository. If you would like to generate the MAML help and preview what the help content will look like for each of your cmdlets, you can do so with two more commands.

To generate the MAML help based on the contents of your markdown files, use the `Import-MarkdownCommandHelp` and `Export-MamlCommandHelp` cmdlets:

```powershell
$PathToHelpFolder = "../../help" # Full path to help folder containing markdown files to be updated
$PathToOutputFolder = "../../.." # Full path to folder where you want the MAML file to be generated
$cmdHelp = Import-MarkdownCommandHelp -Path (Join-Path $PathToHelpFolder '*-*.md')
Export-MamlCommandHelp -CommandHelp $cmdHelp -OutputFolder $PathToOutputFolder -Force
```

To preview the help that you just generated, use the `Show-HelpPreview` cmdlet:

```powershell
$PathToMAML = "../../<maml>.dll-Help.xml" # Full path to the MAML file that was generated

# Save the help locally
$help = Show-HelpPreview -Path $PathToMAML

# Get the help for a specific cmdlet
$help | where { $_.Name -eq "<cmdlet>" }
```
