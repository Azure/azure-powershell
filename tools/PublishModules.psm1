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

.PARAMETER Profile
Either Latest or Stack.

#>
function Get-Directories {
    [CmdletBinding()]
    param
    (
        [String]$BuildConfig,
        [String]$Scope
    )

    PROCESS {
        $packageFolder = "$PSScriptRoot\..\artifacts"

        $resourceManagerRootFolder = "$packageFolder\$buildConfig"

        Write-Output -InputObject $packageFolder, $resourceManagerRootFolder
    }
}

<#################################################
#
#               Get module functions
#
#################################################>

<#
.SYNOPSIS Get the list of rollup modules.  Currently AzureRM, for Stack and Azure, or AzureStack.

.PARAMETER BuildConfig
Either debug or release.

.PARAMETER SCOPE
All, AzureRM, and Stack are valid Rollup modules.

.PARAMETER IsNetCore
If built using .NET core.

#>
function Get-RollupModules {
    [CmdletBinding()]
    param
    (
        [string]$BuildConfig,
        [string]$Scope,
        [switch]$IsNetCore
    )

    PROCESS {
        $targets = @()

        if ($Scope -eq 'Stack') {
            Write-Host "Publishing AzureRM"
            $targets += "$PSScriptRoot\..\src\StackAdmin\AzureRM"
            $targets += "$PSScriptRoot\..\src\StackAdmin\AzureStack"
        }

        if ($Scope -eq 'All' -or $Scope -eq 'Latest' -or $Scope -eq 'NetCore') {
            if ($IsNetCore) {
                # For .NetCore publish AzureRM.Netcore
                $targets += "$PSScriptRoot\Az"
                $targets += "$PSScriptRoot\AzPreview"
            } else {
                $targets += "$PSScriptRoot\AzureRM"
            }
        }

        Write-Output -InputObject $targets
    }
}

<#
.SYNOPSIS Find and return all AzureStack admin modules.

.PARAMETER BuildConfig
Either debug or release.

.PARAMETER Profile
Either Latest or Stack.

.PARAMETER Scope
The Module or class of Modules to build.

#>
function Get-AdminModules {
    [CmdletBinding()]
    param
    (
        [string]$BuildConfig,
        [string]$Scope
    )

    PROCESS {
        $targets = @()
        if ($Scope -eq "Stack") {
            $packageFolder, $resourceManagerRootFolder = Get-Directories -BuildConfig $BuildConfig -Scope $Scope

            $resourceManagerModules = Get-ChildItem -Path $resourceManagerRootFolder -Directory -Filter Azs.*
            foreach ($module in $resourceManagerModules) {
                $targets += $module.FullName
            }
        }
        Write-Output -InputObject $targets
    }
}


<#

.SYNOPSIS Get the list of Azure modules.

.PARAMETER BuildConfig
Either release or debug.

.PARAMETER Profile
Either Latest or Stack

.PARAMETER Scope
The scope, either a specific Module or class of modules.

.PARAMETER PublishLocal
If publishing locally only.

.PARAMETER IsNetCore
If built with .NET core.

#>
function Get-ClientModules {
    [CmdletBinding()]
    param
    (
        [string]$BuildConfig,
        [string]$Scope,
        [bool]$PublishLocal,
        [switch]$IsNetCore
    )

    PROCESS {
        $targets = @()

        $packageFolder, $resourceManagerRootFolder = Get-Directories -BuildConfig $BuildConfig -Scope $Scope

        # Everyone but Storage
        $AllScopes = @('Stack', 'All', 'Latest', 'NetCore')
        if ($Scope -in $AllScopes -or $PublishLocal) {
            if ($Scope -eq "Netcore")
            {
                $targets += "$resourceManagerRootFolder\Az.Accounts"
            }
            else
            {
                $targets += "$resourceManagerRootFolder\AzureRM.Profile"
            }
        }

        $StorageScopes = @('All', 'Latest', 'Stack', 'AzureStorage')
        if ($Scope -in $StorageScopes) {
            $targets += "$packageFolder\$buildConfig\Storage\Azure.Storage"
        }

        # Handle things which don't support netcore yet.
        if (-not $IsNetCore) {
            $ServiceScopes = @('All', 'Latest', 'ServiceManagement')
            if ($Scope -in $ServiceScopes) {
                $targets += "$packageFolder\$buildConfig\ServiceManagement\Azure"
            }
        }

        # Get the list of targets
        if ($Scope -in $AllScopes) {

            # Get all module directories
            if ($IsNetCore) {
                $resourceManagerModules = Get-ChildItem -Path $resourceManagerRootFolder -Directory -Exclude Azs.* | Where-Object {$_.Name -like "*Az.*" -or $_.Name -eq "Az"}
            } else {
                $resourceManagerModules = Get-ChildItem -Path $resourceManagerRootFolder -Directory -Exclude Azs.* | Where-Object {$_.Name -like "*Azure*"}
            }

            # We should ignore these, they are handled separatly.
            $excludedModules = @('AzureRM.Profile', 'Azure.Storage', 'Az.Accounts')

            # Add all modules for AzureRM for Azure
            foreach ($module in $resourceManagerModules) {
                # AzureRM.Profile already added, Azure.Storage built from test dependencies
                if (-not ($module.Name -in $excludedModules)) {
                    $targets += $module.FullName
                }
            }
        }
        Write-Output -InputObject $targets
    }
}

<#
.SYNOPSIS Get the modules to publish.

.PARAMETER BuildConfig
The build configuration, either Release or Debug

.PARAMETER Scope
The module scope, either All, Storage, or Stack.

.PARAMETER PublishToLocal
$true if publishing locally only, $false otherwise

.PARAMETER Profile
Either Latest or Stack

.PARAMETER IsNetCore
If the modules are built using Net Core.

#>
function Get-AllModules {
    [CmdletBinding()]
    param(
        [ValidateNotNullOrEmpty()]
        [String]$BuildConfig,

        [ValidateNotNullOrEmpty()]
        [String]$Scope,

        [String]$TargetBuild,

        [switch]$PublishLocal,

        [switch]$IsNetCore
    )
    Write-Host "Getting Azure client modules"
    $clientModules = Get-ClientModules -BuildConfig $BuildConfig -Scope $Scope -PublishLocal:$PublishLocal -IsNetCore:$isNetCore
    Write-Host  "$clientModules"
    if($clientModules.Count -le 2 -and  $TargetBuild -eq "true") {
        return @{
            ClientModules = $clientModules
        }
    }

    Write-Host "Getting admin modules"
    $adminModules = Get-AdminModules -BuildConfig $BuildConfig -Scope $Scope
    Write-Host "$adminModules"

    Write-Host "Getting rollup modules"
    $rollupModules = Get-RollupModules -BuildConfig $BuildConfig -Scope $Scope -IsNetCore:$isNetCore
    Write-Host "$rollupModules"

    return @{
        ClientModules = $clientModules;
        AdminModules  = $adminModules;
        RollUpModules = $rollUpModules
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

.PARAMETER KeepRequiredModules
Switch to keep RequiredModules.

#>
function Remove-ModuleDependencies {
    [CmdletBinding()]
    param(
        [string]$Path,

        [Parameter(Mandatory=$false)]
        [switch]$KeepRequiredModules
    )

    PROCESS {
        if (-not $KeepRequiredModules.IsPresent){
            $regexRequiredModules = New-Object System.Text.RegularExpressions.Regex "RequiredModules\s*=\s*@\([^\)]+\)"
            $regexModuleList = New-Object System.Text.RegularExpressions.Regex "# ModuleList = @\(\)"
            $content = (Get-Content -Path $Path) -join "`r`n"
            $requiredModulesMatch = $regexRequiredModules.Match($content)
            if ($requiredModulesMatch.Success) {
                $requiredModulesContent = $requiredModulesMatch.Value
            } else {
                $requiredModulesContent = "RequiredModules = @()"
            }
            $content = $regexRequiredModules.Replace($content, "RequiredModules = @()")
            $text = $regexModuleList.Replace($content,  ($requiredModulesContent -replace "RequiredModules", "ModuleList"))
            Out-FileNoBom -File $Path -Text $text
        }

        $regex = New-Object System.Text.RegularExpressions.Regex "NestedModules\s*=\s*@\([^\)]+\)"
        $content = (Get-Content -Path $Path) -join "`r`n"

        $file = Get-Item $Path
        Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory $file.DirectoryName -FileName $file.Name
        $ReplacedNestedModules = ""
        foreach ($nestedModule in $ModuleMetadata.NestedModules)
        {
            if('.dll' -ne [System.IO.Path]::GetExtension($nestedModule)) 
            {
                $ReplacedNestedModules += "'$nestedModule', ";
            }
        }
        if("" -ne $ReplacedNestedModules){
            $ReplacedNestedModules = $ReplacedNestedModules.Substring(0, $ReplacedNestedModules.Length - 2)
        }

        $text = $regex.Replace($content, "NestedModules = @($ReplacedNestedModules)")
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

        # https://stackoverflow.com/a/36369540/294804
        &$NugetExe pack $modulePath -OutputDirectory $TempRepoPath -NoPackageAnalysis
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
            $NupkgFilePath = Join-Path -Path $TempRepoPath -ChildPath "$ModuleName.$RequiredVersion.nupkg"
            $ModulePaths = $env:PSModulePath -split ';'
            $DestinationModulePath = [System.IO.Path]::Combine($ModulePaths[0], $ModuleName, $RequiredVersion)
            Expand-Archive -Path $NupkgFilePath -DestinationPath $DestinationModulePath -Force
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
    $Keys = @('ClientModules', 'AdminModules', 'RollupModules')
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
    Write-Output "Removing lower version Az.Accounts packages"
    $packages = Get-ChildItem -Path "./artifacts" -Filter "Az.Accounts.*.nupkg"
    $latestVersion = [version]"0.0.0"
    $latestPackage = $null
    
    foreach ($package in $packages) {
        $fileName = $package.Name
        $versionString = $fileName.Replace('Az.Accounts.', '').Replace('.nupkg', '')
        if ($versionString -match 'preview') {
            return 
        }
        $version = [version]$versionString
        
        if ($version -gt $latestVersion) {
            $latestVersion = $version
            $latestPackage = $package
        }
    }
    
    foreach ($package in $packages) {
        if ($package.FullName -ne $latestPackage.FullName) {
            Remove-Item $package.FullName -Force
        }
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

        $moduleVersion = $ModuleMetadata.ModuleVersion.ToString()
        if ($ModuleMetadata.PrivateData.PSData.Prerelease -ne $null) {
            $moduleVersion += ("-" + $ModuleMetadata.PrivateData.PSData.Prerelease -replace "--", "-")
        }

        if (Find-Module -Name $moduleName -Repository $TempRepo -RequiredVersion $moduleVersion -AllowPrerelease -ErrorAction SilentlyContinue)
        {
            Write-Output "Existing module found: $moduleName"
            $moduleNupkgPath = Join-Path -Path $TempRepoPath -ChildPath ($moduleName + "." + $moduleVersion + ".nupkg")
            Write-Output "Deleting the module: $moduleNupkgPath"
            Remove-Item -Path $moduleNupkgPath -Force
        }

        Write-Output "Publishing the module $moduleName"
        Publish-Module -Path $Path -Repository $TempRepo -Force | Out-Null
        Write-Output "$moduleName published"

        # Create a psm1 and alter psd1 dependencies to allow fine-grained
        # control over assembly loading.  Opt out by definitng a RootModule.
        if ($ModuleMetadata.RootModule) {
            Write-Output "Root module found, done"
            #return
        } else {
            Write-Output "No root module found, creating"
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

            if ($ModuleMetadata.RootModule) {
                Write-Output "Adding PSM1 dependency is skipped because root module is found"
            } else {
                Write-Output "Adding PSM1 dependency to $unzippedManifest"
                Add-PSM1Dependency -Path $unzippedManifest 
            }

            Write-Output "Removing module manifest dependencies for $unzippedManifest"
            Remove-ModuleDependencies -Path (Join-Path $TempRepoPath $unzippedManifest -Resolve)

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
