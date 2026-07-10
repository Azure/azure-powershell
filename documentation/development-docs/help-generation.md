# Azure PowerShell Help Generation

## Description

All MAML files containing the help content for cmdlets have been removed from the Azure PowerShell repository and replaced with markdown files, which are generated and maintained using the [`Microsoft.PowerShell.PlatyPS`](https://github.com/PowerShell/platyPS) module. Each module has a `help` folder (_e.g.,_ `src/Accounts/Accounts/help`) which contains a markdown file for each of the cmdlets found in that given module. When the help content for a cmdlet (or multiple cmdlets) needs to be updated, users will now only have to update the contents of the markdown file, _and not the MAML file as well_.

## Installing `Microsoft.PowerShell.PlatyPS`

In order to use the cmdlets necessary to update the markdown help files (or generate MAML help locally from these markdown files), you must first install the `Microsoft.PowerShell.PlatyPS` module mentioned previously.  You will need to install a minimum version of 1.0.2, which is the first release to support the `-ExcludeDontShow` switch used by the build.

To do so, you can follow the below steps (which are outlined in the [**Quick start**](https://github.com/PowerShell/platyPS#quick-start) section of the `Microsoft.PowerShell.PlatyPS` README):

```powershell
Install-Module -Name Microsoft.PowerShell.PlatyPS -MinimumVersion 1.0.2 -Scope CurrentUser
```

**Note:** `Microsoft.PowerShell.PlatyPS` is a rewrite of the legacy `platyPS` (v0.x) module with a new cmdlet set, so the two cannot be used interchangeably. If you still have `platyPS` installed, remove it (or make sure it is not imported) before running the commands below, as the two modules depend on conflicting versions of `YamlDotNet` and cannot be loaded into the same session.

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
New-MarkdownCommandHelp -ModuleInfo (Get-Module {{moduleName}}) -OutputFolder $PathToHelpFolder -WithModulePage -ExcludeDontShow
```

`-ExcludeDontShow` omits parameters marked `[Parameter(DontShow)]` from the generated markdown. The switch is opt-in: without it, hidden parameters (such as the AutoRest-generated `Break`, `HttpPipelineAppend`, and `Proxy*` parameters) are documented as if they were public. Always pass it.

`New-MarkdownCommandHelp` writes into an `<ModuleName>` subfolder beneath `-OutputFolder`, so the files land in `$PathToHelpFolder/{{moduleName}}/`.

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

Refreshing a whole module is two steps in v1: [`Update-MarkdownCommandHelp`](https://github.com/PowerShell/platyPS/blob/master/docs/cmdlet-reference/Microsoft.PowerShell.PlatyPS/Update-MarkdownCommandHelp.md) rewrites the per-cmdlet files, then [`Update-MarkdownModuleFile`](https://github.com/PowerShell/platyPS/blob/master/docs/cmdlet-reference/Microsoft.PowerShell.PlatyPS/Update-MarkdownModuleFile.md) refreshes the module page from them.

```powershell
$PathToModuleManifest = "../../<module>.psd1" # Full path to the module manifest that you have updated
Import-Module -Name $PathToModuleManifest

$PathToHelpFolder = "../../help" # Full path to help folder containing markdown files to be updated
$CmdletHelpFiles = Join-Path $PathToHelpFolder '*-*.md'

# Update every cmdlet markdown file in place.
Update-MarkdownCommandHelp -Path $CmdletHelpFiles -NoBackup

# Refresh the module page (e.g., Az.Accounts.md) from the updated command help.
$UpdatedHelp = Import-MarkdownCommandHelp -Path $CmdletHelpFiles
$ModulePage = Join-Path $PathToHelpFolder '<module>.md'
Update-MarkdownModuleFile -Path $ModulePage -CommandHelp $UpdatedHelp -NoBackup -Force
```

This will update all of the markdown files with public interface changes made to corresponding cmdlets and update the module page (_e.g.,_ `Az.Accounts.md`) with any added or removed cmdlets. Unlike legacy `platyPS`, `Update-MarkdownCommandHelp` does not create files for new cmdlets or delete files for removed ones — generate a new cmdlet's markdown with `New-MarkdownCommandHelp` and delete stale files by hand.

**Note:** `Update-MarkdownCommandHelp` writes a `.bak` file next to each updated markdown unless you pass `-NoBackup`. Do not commit the `.bak` files.

_This seems to work better when run from within the `help` folder itself (For e.g. to generate the help files for the [`Network`](https://github.com/Azure/azure-powershell/tree/main/src/Network) module run the cmd from under [`Commands.Network/help`](https://github.com/Azure/azure-powershell/tree/main/src/Network/Network/help)). Also, you will have to import the profile module from under <Repo base path>/artifacts/Debug/Az.Accounts/Az.Accounts.psd1_
 
#### Updating a single markdown file

To update a single markdown file with the changes made to the corresponding cmdlet, use the [`Update-MarkdownCommandHelp`](https://github.com/PowerShell/platyPS/blob/master/docs/cmdlet-reference/Microsoft.PowerShell.PlatyPS/Update-MarkdownCommandHelp.md) cmdlet:

```powershell
$PathToModuleManifest = "../../<module>.psd1" # Full path to the module manifest that you have updated
Import-Module -Name $PathToModuleManifest

$PathToMarkdownFile = "../../<cmdlet>.md" # Full path to the markdown file to be updated
Update-MarkdownCommandHelp -Path $PathToMarkdownFile -NoBackup
```

The v0.x `-AlphabeticParamsOrder`, `-UseFullTypeName`, and `-UpdateInputOutput` switches no longer exist. Parameters are always emitted in alphabetical order.

#### Generating and viewing the MAML help

During the build, the MAML help will be generated from the markdown files in the repository. If you would like to generate the MAML help and preview what the help content will look like for each of your cmdlets, you can do so with two more commands.

To generate the MAML help based on the contents of your markdown files, read the markdown back with [`Import-MarkdownCommandHelp`](https://github.com/PowerShell/platyPS/blob/master/docs/cmdlet-reference/Microsoft.PowerShell.PlatyPS/Import-MarkdownCommandHelp.md) and write it out with [`Export-MamlCommandHelp`](https://github.com/PowerShell/platyPS/blob/master/docs/cmdlet-reference/Microsoft.PowerShell.PlatyPS/Export-MamlCommandHelp.md). The v0.x `New-ExternalHelp` cmdlet was removed in v1.

```powershell
$PathToHelpFolder = "../../help" # Full path to help folder containing markdown files to be updated
$PathToOutputFolder = "../../.." # Full path to folder where you want the MAML file to be generated

$cmdHelp = Import-MarkdownCommandHelp -Path (Join-Path $PathToHelpFolder '*-*.md')
Export-MamlCommandHelp -CommandHelp $cmdHelp -OutputFolder $PathToOutputFolder -Force
```

`Export-MamlCommandHelp` appends a `<ModuleName>` subfolder to `-OutputFolder`, so the MAML lands at `$PathToOutputFolder/<ModuleName>/<module>.dll-Help.xml`.

To preview the help that you just generated, use the [`Show-HelpPreview`](https://github.com/PowerShell/platyPS/blob/master/docs/cmdlet-reference/Microsoft.PowerShell.PlatyPS/Show-HelpPreview.md) function (which replaces the v0.x `Get-HelpPreview`):

```powershell
$PathToMAML = "../../<maml>.dll-Help.xml" # Full path to the MAML file that was generated

# Save the help locally
$help = Show-HelpPreview -Path $PathToMAML

# Get the help for a specific cmdlet
$help | Where-Object { $_.Name -eq "<cmdlet>" }
```
