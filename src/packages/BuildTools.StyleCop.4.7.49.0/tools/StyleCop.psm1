<#
    BuildTools.StyleCop - Copyright(c) 2013 - Jon Wagner
    See https://github.com/jonwagner/BuildTools for licensing and other information.
    Version: 4.7.44.0
    Changeset: 229a24b9227fc8b03e1bf0add607a0b59b662eb5
#>

# define our variables
$thisFolder = (Split-Path $MyInvocation.MyCommand.Definition -Parent)
$packageID = 'BuildTools_StyleCop'
$targetsFile = Join-Path $thisFolder 'StyleCop.targets'

# import the standard build module
$msbuildModule = (Join-Path $thisFolder BuildTools.MsBuild.psm1)
if (!(Test-Path $msbuildModule)) {
    # in dev mode, this file is not in this path
    $msbuildModule = (Join-Path $thisFolder ..\..\BuildTools.MsBuild\BuildTools.MsBuild.psm1)
}
Import-Module $msbuildModule -Force

<#
.Synopsis
    Installs StyleCop into the given project.
.Description
    Installs StyleCop into the given project.

    The default installation enables StyleCop for Release builds and treats Errors as Errors.
    You can change the behavior by running Enable-StyleCop or Set-StyleCopErrorsAs.
.Parameter Project
    The project to modify.
.Example
    Install-StyleCop $Project

    Installs StyleCop into the given project.
#>
function Install-StyleCop {
    param (
        $Project,
        [switch] $Quiet
    )

    # make sure that we always have an msbuild project
    $Project = Get-MsBuildProject $project

    if (!$Quiet) {
        Write-Host "Installing StyleCop in $($Project.FullPath)"
    }

    # import StyleCop.targets
    Add-MsBuildImport -Project $Project -ImportFile $targetsFile -PackageID $packageID -TestProperty 'StyleCopOutputFile'

    # install our override
    Set-MsBuildProperty -Project $Project -Name "StyleCopOverrideSettingsFile" -Value 'Settings.StyleCop' 

    if (!(Get-MsBuildProperty -Project $Project -Name BuildToolsStyleCopVersion)) {
        # the stylecop default is enabled for debug and release, but that is excessive
        # let's just validate only on release mode, but we will treat those as errors
        # other users can run the scripts to change that if they want to
        Disable-StyleCop -Project $Project -Quiet
        Enable-StyleCop -Project $Project -Configuration Release -TreatErrorsAs Errors -Quiet:$Quiet

        # tag the installation with the version so we don't overwrite peoples' settings
        Set-MsBuildProperty -Project $Project -Name BuildToolsStyleCopVersion -Value '4.7.44.0'
    }
    else {
        if (!$Quiet) {
            Write-Host 'BuildTools.StyleCop was already installed. Not modifying settings.'
        }
    }
}

<#
.Synopsis
    Uninstalls StyleCop into the given project.
.Description
    Uninstalls StyleCop into the given project.
.Parameter Project
    The project to modify.
.Example
    Uninstall-StyleCop $Project

    Uninstall StyleCop from the given project.
#>
function Uninstall-StyleCop {
    param (
        $Project,
        [switch] $Quiet
    )

    # make sure that we always have an msbuild project
    $Project = Get-MsBuildProject $project

    if (!$Quiet) {
        Write-Host "Uninstalling StyleCop in $($Project.FullPath)"
    }

    # remove the import so the build doesn't use it anymore
    # leave the StyleCop variables around so our settings can survive an upgrade
    Remove-MsBuildImport -Project $Project -ImportFile $targetsFile -PackageID $packageID
}

<#
.Synopsis
    Enables StyleCop for a given project configuration.
.Description
    Enables StyleCop for a given project configuration.

    If Configuration and Platform are not specified, this enables StyleCop for all configurations.
    The Error setting is not modified uless TreatErrorsAs is specified.
.Parameter Project
    The project to modify.
.Parameter TreatErrorsAs
    Sets Errors as Errors or Warnings for the given configurations.
.Parameter Configuration
    The configuration to modify (e.g. Debug or Release).
.Parameter Platform
    The platform configuration to modify (e.g. AnyCPU or x86)
.Parameter Quiet
    Suppresses installation messages.
.Example
    Enable-StyleCop $Project

    Enables StyleCop for all configurations.
.Example
    Enable-StyleCop $Project -Configuration Release

    Enables StyleCop for all Release configurations.
#>
function Enable-StyleCop {
    param (
        $Project,
        [ValidateSet('Errors', 'Warnings')] [string] $TreatErrorsAs,
        [string] $Configuration,
        [string] $Platform,
        [switch] $Quiet
    )

    # make sure that we always have an msbuild project
    $Project = Get-MsBuildProject $project

    if (!$Quiet) {
        $whichConfig = $Configuration
        if (!$whichConfig) { $whichConfig = 'All Configurations' }
        $whichPlat = $Platform
        if (!$whichPlat) { $whichPlat = 'All Platforms' }
        Write-Host "Enabling StyleCop in $($Project.FullPath) for $whichConfig $whichPlat"
    }

    # enable stylecop for the specified configurations
    Set-MsBuildConfigurationProperty -Project $Project `
        -Name "StyleCopEnabled" -Value $true `
        -Configuration $Configuration -Platform $Platform

    # set errors as warnings/error if not null
    if ($TreatErrorsAs) {
        Set-StyleCopErrorsAs $Project -TreatErrorsAs $TreatErrorsAs -Configuration $Configuration -Platform $Platform -Quiet:$Quiet
    }

    # add CODE_ANALYSIS to the constants so code suppression works
    Enable-CodeAnalysisConstant -Project $Project `
        -Configuration $Configuration -Platform $Platform
}

<#
.Synopsis
    Disables StyleCop for a given project configuration.
.Description
    Disables StyleCop for a given project configuration.

    If Configuration and Platform are not specified, this disables StyleCop for all configurations.
.Parameter Project
    The project to modify.
.Parameter Configuration
    The configuration to modify (e.g. Debug or Release).
.Parameter Platform
    The platform configuration to modify (e.g. AnyCPU or x86)
.Parameter Quiet
    Suppresses installation messages.
.Example
    Disable-StyleCop $Project

    Disables StyleCop for all configurations.
.Example
    Disable-StyleCop $Project -Configuration Debug

    Disables StyleCop for all Debug configurations.
#>
function Disable-StyleCop {
    param (
        $Project,
        [string] $Configuration,
        [string] $Platform,
        [switch] $Quiet
    )

    # make sure that we always have an msbuild project
    $Project = Get-MsBuildProject $project

    if (!$Quiet) {
        Write-Host "Disabling StyleCop in $($Project.FullPath)"
    }

    # set StyleCopEnabled to false (default is true)
    Set-MsBuildConfigurationProperty -Project $Project `
        -Name "StyleCopEnabled" -Value $false `
        -Configuration $Configuration -Platform $Platform

    # remove CODE_ANALYSIS from the constants unless fxcop is enabled
    Disable-CodeAnalysisConstant -Project $Project `
        -Configuration $Configuration -Platform $Platform
}

<#
.Synopsis
    Sets StyleCop Errors as compile Errors or Warnings.
.Description
    Sets StyleCop Errors as compile Errors or Warnings.
.Parameter TreatErrorsAs
    Sets Errors as Errors or Warnings for the given configurations.
.Parameter Project
    The project to modify.
.Parameter Configuration
    The configuration to modify (e.g. Debug or Release).
.Parameter Platform
    The platform configuration to modify (e.g. AnyCPU or x86)
.Example
    Set-StyleCopErrorsAs Warnings

    Sets StyleCop errors to be treated as warnings for all configurations of the active project.

.Example
    Set-StyleCopErrorsAs Warnings $Project -Configuration Debug

    Sets StyleCop errors to be treated as warnings for all Debug configurations of the given project.
#>
function Set-StyleCopErrorsAs {
    param (
        [Parameter(Mandatory=$true)]
        [ValidateSet('Errors', 'Warnings')] [string] $TreatErrorsAs,
        $Project,
        [string] $Configuration,
        [string] $Platform,
        [switch] $Quiet
    )

    # make sure that we always have an msbuild project
    $Project = Get-MsBuildProject $project

    if (!$Quiet) {
        Write-Host "StyleCop Errors are now $TreatErrorsAs in $($Project.FullPath)"
    }

    if ($TreatErrorsAs -eq 'Errors') {
        $TreatErrorsAsWarnings = $false
    }
    else {
        $TreatErrorsAsWarnings = $true
    }

    Set-MsBuildConfigurationProperty -Project $Project `
        -Name "StyleCopTreatErrorsAsWarnings" -Value $TreatErrorsAsWarnings `
        -Configuration $Configuration -Platform $Platform
}

Export-ModuleMember Install-StyleCop, Uninstall-StyleCop, Enable-StyleCop, Disable-StyleCop, Set-StyleCopErrorsAs
