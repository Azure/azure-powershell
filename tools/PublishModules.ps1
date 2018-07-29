# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#

.SYNOPSIS
    Create nuget packages for each module.

.PARAMETER BuildConfig
    Either Debug or Release.

.PARAMETER ApiKey
    ApiKey used to publish nuget to PS repository.

.PARAMETER RepositoryLocation
    Location we want to publish too.

.PARAMETER NugetExe
    Path to the nuget executable.

#>

param(
    [Parameter(Mandatory = $false, Position = 0)]
    [ValidateSet("Debug", "Release")]
    [string]$BuildConfig,

    [Parameter(Mandatory = $false, Position = 1)]
    [string]$ApiKey,

    [Parameter(Mandatory = $false, Position = 2)]
    [string]$RepositoryLocation,

    [Parameter(Mandatory = $false, Position = 3)]
    [string]$NugetExe
)

<#################################################
#
#               Helper functions
#
#################################################>

<#
.SYNOPSIS Write out to a file using UTF-8 without BOM.

.PARAMETER File
The file to write the contents too.

.PARAMETER Text
The new file contents.

#>
function Out-FileNoBom {
    param(
        [System.string]$File,
        [System.string]$Text
    )
    $encoding = New-Object System.Text.UTF8Encoding $False
    [System.IO.File]::WriteAllLines($File, $Text, $encoding)
}

<#
.SYNOPSIS Get the Package and build Output directory.

.PARAMETER BuildConfig
Either debug or release.

#>
function Get-Directories {
    [CmdletBinding()]
    param
    (
        [String]$BuildConfig
    )

    PROCESS {
        $packageFolder = "$PSScriptRoot\..\src\Package"

        Write-Output -InputObject $packageFolder
    }
}

<#################################################
#
#               Get module functions
#
#################################################>

<#

.SYNOPSIS Get the list of Azure modules.

.PARAMETER BuildConfig
Either release or debug.

.PARAMETER PublishLocal
If publishing locally only.

#>
function Get-ClientModules {
    [CmdletBinding()]
    param
    (
        [string]$BuildConfig,
        [bool]$PublishLocal
    )

    PROCESS {
        $targets = @()

        $packageFolder = Get-Directories -BuildConfig $BuildConfig

        $targets += "$packageFolder\$buildConfig\ServiceManagement\Azure"

        Write-Output -InputObject $targets
    }
}

<#
.SYNOPSIS Get the modules to publish.

.PARAMETER BuildConfig
The build configuration, either Release or Debug

.PARAMETER PublishToLocal
$true if publishing locally only, $false otherwise

#>
function Get-AllModules {
    [CmdletBinding()]
    param(
        [ValidateNotNullOrEmpty()]
        [String]$BuildConfig,

        [switch]$PublishLocal
    )
    Write-Host "Getting Azure client modules"
    $clientModules = Get-ClientModules -BuildConfig $BuildConfig -PublishLocal:$PublishLocal
    Write-Host " "

    return @{
        ClientModules = $clientModules;
    }
}

<#################################################
#
#       Create and update nuget functions.
#
#################################################>


<#
.SYNOPSIS Remove the RequiredModules and NestedModules psd1 properties with empty array.

.PARAMETER Path
Path to the psd1 file.

#>
function Remove-ModuleDependencies {
    [CmdletBinding()]
    param(
        [string]$Path
    )

    PROCESS {
        $regex = New-Object System.Text.RegularExpressions.Regex "RequiredModules\s*=\s*@\([^\)]+\)"
        $content = (Get-Content -Path $Path) -join "`r`n"
        $text = $regex.Replace($content, "RequiredModules = @()")
        Out-FileNoBom -File $Path -Text $text

        $regex = New-Object System.Text.RegularExpressions.Regex "NestedModules\s*=\s*@\([^\)]+\)"
        $content = (Get-Content -Path $Path) -join "`r`n"
        $text = $regex.Replace($content, "NestedModules = @()")
        Out-FileNoBom -File $Path -Text $text
    }
}

<#
.SYNOPSIS Update license acceptance to be required.

.PARAMETER TempRepoPath
Path to the local temporary repository.

.PARAMETER ModuleName
Name of the module to update.

.PARAMETER DirPath
Path to the directory holding the modules to update.

.PARAMETER NugetExe
Path to the Nuget executable.
#>
function Update-NugetPackage {
    [CmdletBinding()]
    param(
        [string]$TempRepoPath,
        [string]$ModuleName,
        [string]$DirPath,
        [string]$NugetExe
    )

    PROCESS {
        $regex2 = "<requireLicenseAcceptance>false</requireLicenseAcceptance>"

        $relDir = Join-Path $DirPath -ChildPath "_rels"
        $contentPath = Join-Path $DirPath -ChildPath '`[Content_Types`].xml'
        $packPath = Join-Path $DirPath -ChildPath "package"
        $modulePath = Join-Path $DirPath -ChildPath ($ModuleName + ".nuspec")

        # Cleanup
        Remove-Item -Recurse -Path $relDir -Force
        Remove-Item -Recurse -Path $packPath -Force
        Remove-Item -Path $contentPath -Force

        # Create new output
        $content = (Get-Content -Path $modulePath) -join "`r`n"
        $content = $content -replace $regex2, ("<requireLicenseAcceptance>true</requireLicenseAcceptance>")
        Out-FileNoBom -File (Join-Path (Get-Location) $modulePath) -Text $content

        &$NugetExe pack $modulePath -OutputDirectory $TempRepoPath
    }
}

<#
.SYNOPSIS Add given modules to local repository.

.PARAMETER ModulePaths
List of paths to modules.

.PARAMETER TempRepo
Name of local temporary repository.

.PARAMETER TempRepoPath
path to local temporary repository.

.PARAMETER NugetExe
Path to nuget executable.

#>
function Add-Modules {
    [CmdletBinding()]
    param(
        [String[]]$ModulePaths,

        [ValidateNotNullOrEmpty()]
        [String]$TempRepo,

        [ValidateNotNullOrEmpty()]
        [String]$TempRepoPath,

        [ValidateNotNullOrEmpty()]
        [String]$NugetExe
    )
    PROCESS {
        foreach ($modulePath in $ModulePaths) {
            Write-Output $modulePath
            $module = Get-Item -Path $modulePath
            Write-Output "Updating $module module from $modulePath"
            Add-Module -Path $modulePath -TempRepo $TempRepo -TempRepoPath $TempRepoPath -NugetExe $NugetExe
            Write-Output "Updated $module module"
        }
    }
}

<#
.SYNOPSIS
    Saves a module into the local temporary repository

.PARAMETER Module
    Module information.

.PARAMETER TempRepo
    Name of the local temporary repository

.PARAMETER TempRepoPath
    Path to the local temporary repository
#>
function Save-PackageLocally {
    [CmdletBinding()]
    param(
        $Module,
        [string]$TempRepo,
        [string]$TempRepoPath
    )

    $ModuleName = $module['ModuleName']
    $RequiredVersion = $module['RequiredVersion']

    # Only check for the modules that specifies = required exact dependency version
    if ($RequiredVersion -ne $null) {
        Write-Output "Checking for required module $ModuleName, $RequiredVersion"
        if (Find-Module -Name $ModuleName -RequiredVersion $RequiredVersion -Repository $TempRepo -ErrorAction SilentlyContinue) {
            Write-Output "Required dependency $ModuleName, $RequiredVersion found in the repo $TempRepo"
        } else {
            Write-Warning "Required dependency $ModuleName, $RequiredVersion not found in the repo $TempRepo"
            Write-Output "Downloading the package from PsGallery to the path $TempRepoPath"
            # We try to download the package from the PsGallery as we are likely intending to use the existing version of the module.
            # If the module not found in psgallery, the following commnad would fail and hence publish to local repo process would fail as well
            Save-Package -Name $ModuleName -RequiredVersion $RequiredVersion -ProviderName Nuget -Path $TempRepoPath -Source https://www.powershellgallery.com/api/v2 | Out-Null
            Write-Output "Downloaded the package sucessfully"
        }
    }
}

<#
.SYNOPSIS
Save the packages from PsGallery to local repo path
This is typically used in a scenario where we are intending to use the existing publshed version of the module as a dependency
Checks whether the module is already published in the local temp repo, if not downloads from the PSGallery
This is used only for the rollup modules AzureRm or AzureStack at the moment

.PARAMETER ModulePaths
List of paths to modules.

.PARAMETER TempRepo
Name of local temporary repository.

.PARAMETER TempRepoPath
path to local temporary repository.

#>
function Save-PackagesFromPsGallery {
    [CmdletBinding()]
    param(
        [String[]]$ModulePaths,

        [ValidateNotNullOrEmpty()]
        [String]$TempRepo,

        [ValidateNotNullOrEmpty()]
        [String]$TempRepoPath
    )
    PROCESS {

        Write-Output "Saving..."

        foreach ($modulePath in $ModulePaths) {

            Write-Output "module path $modulePath"

            $module = (Get-Item -Path $modulePath).Name
            $moduleManifest = $module + ".psd1"

            Write-Host "Verifying $module has all the dependencies in the repo $TempRepo"

            $psDataFile = Import-PowershellDataFile (Join-Path $modulePath -ChildPath $moduleManifest)
            $RequiredModules = $psDataFile['RequiredModules']

            if ($RequiredModules -ne $null) {
                foreach ($tmp in $RequiredModules) {
                    foreach ($module in $tmp) {
                        Save-PackageLocally -Module $module -TempRepo $TempRepo -TempRepoPath $TempRepoPath
                    }
                }
            }
        }
    }
}

<#
.SYNOPSIS Add all modules to local repo.

.PARAMETER ModulePaths
A hash table of Modules types and paths.

.PARAMETER TempRepo
The name of the temporary repository.

.PARAMETER TempRepoPath
Path to the temporary reposityroy.

.PARAMETER NugetExe
Location of nuget executable.

#>
function Add-AllModules {
    [CmdletBinding()]
    param(
        $ModulePaths,

        [ValidateNotNullOrEmpty()]
        [String]$TempRepo,

        [ValidateNotNullOrEmpty()]
        [String]$TempRepoPath,

        [ValidateNotNullOrEmpty()]
        [String]$NugetExe
    )
    $Keys = @('ClientModules')
    Write-Output "adding modules to local repo"
    foreach ($module in $Keys) {
        $modulePath = $Modules[$module]
        Write-Output "Adding $module modules to local repo"

        # Save missing dependencies locally from PS gallery.
        Save-PackagesFromPsGallery -TempRepo $TempRepo -TempRepoPath $TempRepoPath -ModulePaths $modulePath

        # Add the modules to the local repository
        Add-Modules -TempRepo $TempRepo -TempRepoPath $TempRepoPath -ModulePath $modulePath -NugetExe $NugetExe
        Write-Output " "
    }
    Write-Output " "
}

<#################################################
#
#           Publish module functions.
#
#################################################>

<#
.SYNOPSIS
Adds Rootmodule


#>
function Add-PSM1Dependency {
    [CmdletBinding()]
    param(
        [string] $Path)

    PROCESS {
        $file = Get-Item -Path $Path
        $manifestFile = $file.Name
        $psm1file = $manifestFile -replace ".psd1", ".psm1"

        # RootModule = ''
        $regex = New-Object System.Text.RegularExpressions.Regex "#\s*RootModule\s*=\s*''"
        $content = (Get-Content -Path $Path) -join "`r`n"
        $text = $regex.Replace($content, "RootModule = '$psm1file'")
        $text | Out-File -FilePath $Path
    }
}

<#

.SYNOPSIS Publish module to local temporary repository.  If no RootModule found create and add new psm1.

.PARAMETER Path
Path to the local module.

.PARAMETER TempRepo
Name of the local temporary repository.

.PARAMETER TempRepoPath
Path to the local temporary repository.

.PARAMETER NugetExe
Path to nuget exectuable.

#>
function Add-Module {
    [CmdletBinding()]
    param(
        [ValidateNotNullOrEmpty()]
        [string]$Path,

        [ValidateNotNullOrEmpty()]
        [string]$TempRepo,

        [ValidateNotNullOrEmpty()]
        [string]$TempRepoPath,

        [ValidateNotNullOrEmpty()]
        [string]$NugetExe
    )

    PROCESS {

        $moduleName = (Get-Item -Path $Path).Name
        $moduleManifest = $moduleName + ".psd1"
        $moduleSourcePath = Join-Path -Path $Path -ChildPath $moduleManifest
        $file = Get-Item $moduleSourcePath
        Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory $file.DirectoryName -FileName $file.Name

        Write-Output "Publishing the module $moduleName"
        Publish-Module -Path $Path -Repository $TempRepo -Force | Out-Null
        Write-Output "$moduleName published"

        # Create a psm1 and alter psd1 dependencies to allow fine-grained
        # control over assembly loading.  Opt out by definitng a RootModule.
        if ($ModuleMetadata.RootModule) {
            Write-Output "Root module found, done"
            return
        }
        Write-Output "No root module found, creating"

        $moduleVersion = $ModuleMetadata.ModuleVersion.ToString()
        if ((!$IsNetCore) -and ($ModuleMetadata.PrivateData.PSData.Prerelease -ne $null)) {
            $moduleVersion += ("-" + $ModuleMetadata.PrivateData.PSData.Prerelease -replace "--", "-")
        }

        Write-Output "Changing to local repository directory for module modifications $TempRepoPath"
        Push-Location $TempRepoPath

        try {

            # Paths
            $nupkgPath = Join-Path -Path . -ChildPath ($moduleName + "." + $moduleVersion + ".nupkg")
            $zipPath = Join-Path -Path . -ChildPath ($moduleName + "." + $moduleVersion + ".zip")
            $dirPath = Join-Path -Path . -ChildPath $moduleName
            $unzippedManifest = Join-Path -Path $dirPath -ChildPath ($moduleName + ".psd1")

            # Validate nuget is there
            if (!(Test-Path -Path $nupkgPath)) {
                throw "Module at $nupkgPath in $TempRepoPath does not exist"
            }

            Write-Output "Renaming package $nupkgPath to zip archive $zipPath"
            Rename-Item $nupkgPath $zipPath

            Write-Output "Expanding $zipPath"
            Expand-Archive $zipPath -DestinationPath $dirPath

            Write-Output "Adding PSM1 dependency to $unzippedManifest"
            Add-PSM1Dependency -Path $unzippedManifest

            Write-Output "Removing module manifest dependencies for $unzippedManifest"
            Remove-ModuleDependencies -Path (Join-Path $TempRepoPath $unzippedManifest)

            Remove-Item -Path $zipPath -Force

            Write-Output "Repackaging $dirPath"
            Update-NugetPackage -TempRepoPath $TempRepoPath -ModuleName $moduleName -DirPath $dirPath -NugetExe $NugetExe
            Write-Output "Removing temporary folder $dirPath"
            Remove-Item -Recurse $dirPath -Force -ErrorAction Stop
        } finally {
            Pop-Location
        }
    }
}

<#
.SYNOPSIS Publish the module to PS Gallery.

.PARAMETER Path
Path to the module.

.PARAMETER ApiKey
Key used to publish.

.PARAMETER TempRepoPath
Path to the local temporary repository containing nuget.

.PARAMETER RepoLocation
Repository we are publishing too.

.PARAMETER NugetExe
Path to nuget executable.

#>
function Publish-PowershellModule {
    [CmdletBinding()]
    param(
        [string]$Path,
        [string]$ApiKey,
        [string]$TempRepoPath,
        [string]$RepoLocation,
        [string]$NugetExe
    )

    PROCESS {
        $moduleName = (Get-Item -Path $Path).Name
        $moduleManifest = $moduleName + ".psd1"
        $moduleSourcePath = Join-Path -Path $Path -ChildPath $moduleManifest
        $manifest = Test-ModuleManifest -Path $moduleSourcePath
        $nupkgPath = Join-Path -Path $TempRepoPath -ChildPath ($moduleName + "." + $manifest.Version.ToString() + ".nupkg")
        if (!(Test-Path -Path $nupkgPath)) {
            throw "Module at $nupkgPath in $TempRepoPath does not exist"
        }

        Write-Output "Pushing package $moduleName to nuget source $RepoLocation"
        &$NugetExe push $nupkgPath $ApiKey -s $RepoLocation
        Write-Output "Pushed package $moduleName to nuget source $RepoLocation"
    }
}

<#
.SYNOPSIS Publish the nugets to PSGallery

.PARAMETER ApiKey
Key used to publish.

.PARAMETER TempRepoPath
Path to the local temporary repository.

.PARAMETER RepoLocation
Name of repository we are publishing too.

.PARAMETER NugetExe
Path to nuget executable.

.PARAMETER PublishLocal
If publishing locally we don't do anything.

#>
function Publish-AllModules {
    [CmdletBinding()]
    param(
        $ModulePaths,

        [ValidateNotNullOrEmpty()]
        [String]$ApiKey,

        [ValidateNotNullOrEmpty()]
        [String]$TempRepoPath,

        [ValidateNotNullOrEmpty()]
        [String]$RepoLocation,

        [ValidateNotNullOrEmpty()]
        [String]$NugetExe,

        [switch]$PublishLocal
    )
    if (!$PublishLocal) {
        foreach ($module in $ModulePaths.Keys) {
            $paths = $Modules[$module]
            foreach ($modulePath in $paths) {
                $module = Get-Item -Path $modulePath
                Write-Host "Pushing $module module from $modulePath"
                Publish-PowershellModule -Path $modulePath -ApiKey $apiKey -TempRepoPath $TempRepoPath -RepoLocation $RepoLocation -NugetExe $NugetExe
                Write-Host "Pushed $module module"
            }
        }
    }
}

<###################################
#
#           Setup/Execute
#
###################################>

if ([string]::IsNullOrEmpty($buildConfig)) {
    Write-Verbose "Setting build configuration to 'Release'"
    $buildConfig = "Release"
}

if ([string]::IsNullOrEmpty($repositoryLocation)) {
    Write-Verbose "Setting repository location to 'https://dtlgalleryint.cloudapp.net/api/v2'"
    $repositoryLocation = "https://dtlgalleryint.cloudapp.net/api/v2"
}

if ([string]::IsNullOrEmpty($nugetExe)) {
    Write-Verbose "Use default nuget path"
    $nugetExe = "$PSScriptRoot\nuget.exe"
}

Write-Host "Publishing $Scope package (and its dependencies)"

Get-PackageProvider -Name NuGet -Force
Write-Host " "

# NOTE: Can only be Azure or Azure Stack, not both.
$packageFolder = "$PSScriptRoot\..\src\Package"

# Set temporary repo location
$PublishLocal = test-path $repositoryLocation
[string]$tempRepoPath = "$packageFolder"
if ($PublishLocal) {
    $tempRepoPath = (Join-Path $repositoryLocation -ChildPath "Package")
}

$tempRepoName = ([System.Guid]::NewGuid()).ToString()
$repo = Get-PSRepository | Where-Object { $_.SourceLocation -eq $tempRepoPath }
if ($repo -ne $null) {
    $tempRepoName = $repo.Name
} else {
    Register-PSRepository -Name $tempRepoName -SourceLocation $tempRepoPath -PublishLocation $tempRepoPath -InstallationPolicy Trusted -PackageManagementProvider NuGet
}

$env:PSModulePath = "$env:PSModulePath;$tempRepoPath"

$Errors = $null

try {
    $modules = Get-AllModules -BuildConfig $BuildConfig -PublishLocal:$PublishLocal
    Add-AllModules -ModulePaths $modules -TempRepo $tempRepoName -TempRepoPath $tempRepoPath -NugetExe $NugetExe
    Publish-AllModules -ModulePaths $modules -ApiKey $apiKey -TempRepoPath $tempRepoPath -RepoLocation $repositoryLocation -NugetExe $NugetExe -PublishLocal:$PublishLocal
} catch {
    $Errors = $_
    Write-Error ($_ | Out-String)
} finally {
    Unregister-PSRepository -Name $tempRepoName
}

if ($Errors -ne $null) {
    exit 1
}
exit 0
