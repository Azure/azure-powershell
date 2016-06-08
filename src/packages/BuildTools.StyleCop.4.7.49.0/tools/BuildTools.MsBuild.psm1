<#
    BuildTools.MsBuild - Copyright(c) 2013 - Jon Wagner
    See https://github.com/jonwagner/BuildTools for licensing and other information.
    Version: 1.0.2
    Changeset: 091dc2aea8a0ad4d78fc80d1dd7d1aa7c030557c
#>

# Need to load MSBuild assembly if it's not loaded yet.
Add-Type -AssemblyName 'Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'

# gets a path relative to another path
function Get-RelativePath {
    param (
        [string] $ReferencePath,
        [string] $Path
    )

    $referenceUri = new-object Uri('file://' + $ReferencePath)
    $uri = new-object Uri('file://' + $Path)
    $relativeUri = $referenceUri.MakeRelativeUri($uri).ToString()

    return $relativeUri.Replace([System.IO.Path]::AltDirectorySeparatorChar, [System.IO.Path]::DirectorySeparatorChar)
}

<#
.Synopsis
    Returns a Microsoft.Build.Evaluation.Project given a Project, path, or Visual Studio DTE Project.
.Description
    Returns a Microsoft.Build.Evaluation.Project given a Project, path, or Visual Studio DTE Project.

    If $null is passed in, Get-MsBuildProject will attempt to call Get-Project in case the script is running
    inside a NuGet window, where the current project will be returned.
.Parameter Project
    The project to open. It can be a Project object, path, or Visual Studio DTE Project object.
.Example
    $project = Get-MsBuildProject 'project.csproj'

    Opens and returns the project.csproj file.
#>
function Get-MsBuildProject {
    param (
        $Project
    )

    # if project is null, let's try the Get-Project command, in case we are in a nuget window
    if (!($Project) -and (Get-Command 'Get-Project')) {
        $Project = Get-Project
    }

    # if the project is a build file, return it
    if ($Project -is [Microsoft.Build.Evaluation.Project]) {
        return $Project
    }

    # if the project is from the Visual Studio DTE, get the fullname
    if ($Project -isnot [string]) {
        $Project = $Project.FullName
    }

    # load the project from memory, or from the file
    $p = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($Project)
    if (!$p) {
        $p = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.LoadProject($Project)
    }

    return $p
}

<#
.Synopsis
    Adds an Import to the given project.
.Description
    Adds a project Import into the given project. 
    
    To support NuGet package restore, if a PackageID and TestProperty are specified, then a target is also added
    to automatically detect when the given package containing the import has not been installed.
.Parameter Project
    The project file to modify.
.Parameter ImportFile
    The import file to include in the project.
.Parameter PackageID
    To support NuGet package restore, the ID of the Package that should be restored if the TestProperty is missing.
.Parameter TestProperty
    To support NuGet package restore, a property that should be defined by the import file. If the property is not defined,
    then an error is displayed instructing the user on how to restore the given package.
.Example
    Add-MsBuildImport $project 'nuget.targets'

    Adds an import for nuget.targets.
.Example
    Add-MsBuildImport $project 'stylecop.targets' 'BuildTools.StyleCop' 'StyleCopOutputFile'

    Adds an import for stylecop.targets. Adds a target to check at build time to see if StyleCopOutputFile is defined.
    If it is not defined, then the user is instructed to restore the package BuildTools.StyleCop.
#>
function Add-MsBuildImport {
    param (
        $Project,
        [string] $ImportFile,
        [string] $PackageID,
        [string] $TestProperty
    )

    # make sure we always have an msbuild project
    $Project = Get-MsBuildProject $Project

    # clean up any mess
    Remove-MsBuildImport $Project $ImportFile

    # add the target, then the warning message
    $relativePath = Get-RelativePath -ReferencePath $Project.FullPath -Path $ImportFile
    $Project.Xml.AddImport($relativePath).Condition = "Exists('$relativePath')"

    if (($PackageID -eq '') -xor ($TestProperty -eq '')) {
        throw "PackageID and TestProperty must both be specified if either is specified."
    }

    if ($PackageID -ne '') {
        Add-PackageRestoreErrorForTarget -Project $Project -TargetFile $relativePath -PackageID $PackageID -TestProperty $TestProperty
    }
}

<#
.Synopsis
    Removes an import from the given project.
.Description
    Removes an import from the given project. If there is a package restore warning for the project, it is also removed.
.Parameter Project
    The project to modify.
.Parameter ImportFile
    The import file to remove from the project.
.Example
    Remove-MsBuildImport $project 'nuget.targets'

    Removes the import for nuget.targets.
#>
function Remove-MsBuildImport {
    param (
        $Project,
        [string] $ImportFile
    )

    # make sure we always have an msbuild project
    $Project = Get-MsBuildProject -Project $Project

    # remove the import and the package restore error
    $relativePath = Get-RelativePath $project.FullPath $ImportFile
    $Project.Xml.Imports | Where { $_.Project -eq $relativePath } |% { $Project.Xml.RemoveChild($_) }

    Remove-PackageRestoreErrorForTarget -Project $Project -TargetFile $relativePath
}

# gets a string that can be used for a build target
function Get-TargetId {
    param (
        [string] $String
    )

    return $String -replace '[^\w]', '_'
}

# adds a build error if package restore has not restored the target file
function Add-PackageRestoreErrorForTarget {
    param (
        $Project,
        [string] $TargetFile,
        [string] $PackageID,
        [string] $TestProperty
    )

    # make sure we always have an msbuild project
    $Project = Get-MsBuildProject -Project $Project

    $target = $Project.Xml.AddTarget("$(Get-TargetId $TargetFile)")
    $target.Condition = "`$($TestProperty)==''"
    $target.BeforeTargets = 'BeforeBuild'
    $task = $target.AddTask('Error')
    $task.SetParameter('Text', 
@"
$PackageID - the $PackageID package has not been restored.
If you are running this from an IDE, make sure NuGet Package Restore has been enabled, then reload the solution and re-run the build.
If you are running this from the command line, run the build again.
If this is a CI server, you may want to make sure NuGet Package Restore runs before your build with:
	msbuild solution.sln /t:restorepackages
"@)
}

# remove the build error for the package target import
function Remove-PackageRestoreErrorForTarget {
    param (
        $Project,
        [string] $TargetFile
    )

    # make sure we always have an msbuild project
    $Project = Get-MsBuildProject -Project $Project

    $Project.Xml.Targets | Where { $_.Name -eq $(Get-TargetId $TargetFile) } |% { $Project.Xml.RemoveChild($_) }
}

<#
.Synopsis
    Gets all of the global build properties that are not tied to configurations.
.Description
    Gets all of the global build properties that are not tied to configurations. This returns global properties only.
.Parameter Project
    The project to analyze.
.Parameter Name
    The name of the property to filter on.
.Example
    Get-MsBuildProperty $Project

    Returns all of the global properties in the project.
.Example
    Get-MsBuildProperty $Project -Name TargetFrameworkVersion

    Returns the TargetFrameworkVersion property.
#>
function Get-MsBuildProperty {
    param (
        $Project,
        [string] $Name
    )

    # make sure we always have an msbuild project
    $Project = Get-MsBuildProject -Project $Project

    $props = $Project.Xml.PropertyGroups |? Condition -eq '' |% Properties
    if ($Name) {
        return $props |? Name -eq $Name
    }
    else {
        return $props
    }
}

<#
.Synopsis
    Sets a global build properties that not tied to any configuration.
.Description
    Sets a global build properties that not tied to any configuration.
    By default, the property is only set in the first global PropertyGroup that is found.
    Use the -All switch to set the property in all of the global PropertyGroups.

.Parameter Project
    The project to analyze.
.Parameter Name
    The name of the property to set.
.Parameter Value
    The value of the property to set.
.Parameter All
    By default, the property is only set in the first global PropertyGroup that is found.
    Use the -All switch to set the property in all of the global PropertyGroups.
.Example
    Set-MsBuildProperty $Project -Name TargetFrameworkVersion -Value v4.5

    Sets the TargetFrameworkVersion to v4.5 for the project.
#>
function Set-MsBuildProperty {
    param (
        $Project,
        [Parameter(Mandatory=$true)]
        [string] $Name,
        [Parameter(Mandatory=$true)]
        [string] $Value,
        [switch] $All
    )

    # make sure we always have an msbuild project
    $Project = Get-MsBuildProject -Project $Project

    $groups = $Project.Xml.PropertyGroups |? Condition -eq ''

    if (! $all) { $groups = $groups | Select-Object -First 1 }

    $groups |% {
        $_.SetProperty($Name, $Value) | Out-Null
    }
}

<#
.Synopsis
    Removes A the global build properties that are not tied to configuration.
.Description
    Removes A the global build properties that are not tied to configuration. This removes global properties only.
.Parameter Project
    The project to modify.
.Parameter Name
    The name of the property to remove
Example
    Remove-MsBuildProperty $Project -Name DebugType

    Removes the DebugType property from all configurations.
#>
function Remove-MsBuildProperty {
    param (
        $Project,
        [Parameter(Mandatory=$true)]
        [string] $Name
    )

    # make sure we always have an msbuild project
    $Project = Get-MsBuildProject -Project $Project

    # remove it from all of the matching configurations
    Get-MsBuildProperty -Project $Project -Name $Name |% {
        $_.Parent.RemoveChild($_) | Out-Null
    }
}

<#
.Synopsis
    Gets all of the MSBuild configurations in a project.
.Description
    Gets all of the MSBuild configurations in a project. This looks for Property Groups with the Condition
    matching the pattern " '$(Configuration)|$(Platform)' == 'Config|Platform'
.Parameter Project
    The project to analyze.
.Parameter Configuration
    Filters the results by the name of the configuration (e.g. Debug or Release)
.Parameter Platform
    Filters the results by the name of the platform (e.g. AnyCPU or x86)
.Example
    Get-MsBuildConfiguration $Project

    Returns all of the configurations in the project.
.Example
    Get-MsBuildConfiguration $Project -Configuration Release

    Returns all of the release configurations in the project.
#>
# gets all of the msbuild configurations in a project
function Get-MsBuildConfiguration {
    param (
        $Project,
        [string] $Configuration,
        [string] $Platform
    )

    # make sure we always have an msbuild project
    $Project = Get-MsBuildProject -Project $Project

    # default configuration and platform to any configuration or platform
    if ($Configuration) {
        $Configuration = [System.Text.RegularExpressions.Regex]::Escape($Configuration)
    }
    else {
        $Configuration = '\w+'
    }

    if ($Platform) {
        $Platform = [System.Text.RegularExpressions.Regex]::Escape($Platform)
    }
    else {
        $Platform = '\w+'
    }

    # match the standard conditions
    $configurationMatch = " '`\$\(Configuration\)\|`\$\(Platform\)' == '$Configuration\|$Platform' "

    $Project.Xml.PropertyGroups |? Condition -match $configurationMatch
}

<#
.Synopsis
    Gets all of the build properties that are tied to configurations.
.Description
    Gets all of the build properties that are tied to configurations. This does not return global properties.
.Parameter Project
    The project to analyze.
.Parameter Name
    The name of the property to filter on.
.Parameter Configuration
    Filters the results by the name of the configuration (e.g. Debug or Release)
.Parameter Platform
    Filters the results by the name of the platform (e.g. AnyCPU or x86)
.Example
    Get-MsBuildConfigurationProperty $Project

    Returns all of the properties for all configurations in the project.
.Example
    Get-MsBuildConfigurationProperty $Project -Name DebugType -Configuration Release

    Returns the DebugType property for the Release configurations.
#>
function Get-MsBuildConfigurationProperty {
    param (
        $Project,
        [string] $Name,
        [string] $Configuration,
        [string] $Platform
    )

    # add it to all of the matching configurations
    $props = Get-MsBuildConfiguration -Project $Project -Configuration $Configuration -Platform $Platform |% Properties
    if ($Name) {
        return $props |? Name -eq $Name
    }
    else {
        return $props
    }
}

<#
.Synopsis
    Sets a build property that tied to a configuration.
.Description
    Sets a build property that tied to a configuration. This does not set global properties.
.Parameter Project
    The project to modify.
.Parameter Name
    The name of the property to set.
.Parameter Value
    The value of the property to set.
.Parameter Configuration
    Only sets the property on the given configuration (e.g. Debug or Release)
.Parameter Platform
    Only sets the property on the given platform (e.g. AnyCPU or x86)
.Example
    Set-MsBuildConfigurationProperty $Project -Name DebugType -Value full

    Sets DebugType to full for all of the configurations.
.Example
    Get-MsBuildConfigurationProperty $Project -Name DebugType -Value pdbonly -Configuration Release

    Sets DebugType to pdbonly for the release configuration.
#>
function Set-MsBuildConfigurationProperty {
    param (
        $Project,
        [Parameter(Mandatory=$true)]
        [string] $Name,
        [Parameter(Mandatory=$true)]
        [string] $Value,
        [string] $Configuration,
        [string] $Platform
    )

    # add it to all of the matching configurations
    Get-MsBuildConfiguration -Project $Project -Configuration $Configuration -Platform $Platform |% {
        $_.SetProperty($Name, $Value) | Out-Null
    }
}

<#
.Synopsis
    Removes A the build properties that tied to configuration.
.Description
    Removes A the build properties that tied to configuration. This does not return global properties.
.Parameter Project
    The project to modify.
.Parameter Name
    The name of the property to remove
.Parameter Configuration
    Filters the results by the name of the configuration (e.g. Debug or Release)
.Parameter Platform
    Filters the results by the name of the platform (e.g. AnyCPU or x86)
.Example
    Remove-MsBuildConfigurationProperty $Project -Name DebugType

    Removes the DebugType property from all configurations.
.Example
    Remove-MsBuildConfigurationProperty $Project -Name DebugType -Configuration Release

    Removes the DebugType property from the Release configuration.
#>function Remove-MsBuildConfigurationProperty {
    param (
        $Project,
        [Parameter(Mandatory=$true)]
        [string] $Name,
        [string] $Configuration,
        [string] $Platform
    )

    # remove it from all of the matching configurations
    Get-MsBuildConfiguration -Project $Project -Configuration $Configuration -Platform $Platform |% {
        $_.Properties |? Name -eq $Name |% { 
            $_.Parent.RemoveChild($_) | Out-Null
        }
    }
}

<#
.Synopsis
    Adds the CODE_ANALYSIS constant to DefineConstants for a configuration.
.Description
    Adds the CODE_ANALYSIS constant to DefineConstants for a configuration.
.Parameter Project
    The project to modify.
.Parameter Configuration
    Filters the results by the name of the configuration (e.g. Debug or Release)
.Parameter Platform
    Filters the results by the name of the platform (e.g. AnyCPU or x86)
.Example
    Enable-CodeAnalysisConstant $Project -Configuration Release

    Enables the CODE_ANALYSIS constant for Release configurations.
#>
function Enable-CodeAnalysisConstant {
    param (
        $Project,
        [string] $Configuration,
        [string] $Platform
    )

    # add CODE_ANALYSIS to the defined constants
    Get-MsBuildConfigurationProperty -Project $Project `
        -Name "DefineConstants" `
        -Configuration $Configuration -Platform $Platform |
        ? Value -notmatch 'CODE_ANALYSIS' |
        % {
            $_.Value = ($_.Value, 'CODE_ANALYSIS') -join ';'
        }
}

<#
.Synopsis
    Removes the CODE_ANALYSIS constant to DefineConstants for a configuration if it is not in use.
.Description
    Removes the CODE_ANALYSIS constant to DefineConstants for a configuration if it is not in use.

    CODE_ANALYSIS is considered to be in use if RunCodeAnalysis or StyleCopEnabled is defined for the given configuration.
.Parameter Project
    The project to modify.
.Parameter Configuration
    Filters the results by the name of the configuration (e.g. Debug or Release)
.Parameter Platform
    Filters the results by the name of the platform (e.g. AnyCPU or x86)
.Example
    Enable-CodeAnalysisConstant $Project -Configuration Release

    Enables the CODE_ANALYSIS constant for Release configurations.
#>
function Disable-CodeAnalysisConstant {
    param (
        $Project,
        [string] $Configuration,
        [string] $Platform
    )

    Get-MsBuildConfigurationProperty -Project $Project `
        -Name "DefineConstants" `
        -Configuration $Configuration -Platform $Platform |
        ? Value -notcontains 'CODE_ANALYSIS' |
        ? { 
            # where the parent doesn't have RunCodeAnalysis set to true
            ($_.Parent.Properties |? Name -in ('RunCodeAnalysis','StyleCopEnabled') |? Value -eq $true).Count -eq 0
        } |
        % {
            $_.Value = (($_.Value -split ';') |? { $_ -ne 'CODE_ANALYSIS' }) -join ';'
        }
}

Export-ModuleMember Add-MsBuildImport, Remove-MsBuildImport,
    Get-MsBuildProject, Get-MsBuildConfiguration, 
    Get-MsBuildProperty, Set-MsBuildProperty, Remove-MsBuildProperty,
    Get-MsBuildConfigurationProperty, Set-MsBuildConfigurationProperty, Remove-MsBuildConfigurationProperty,
    Enable-CodeAnalysisConstant, Disable-CodeAnalysisConstant
