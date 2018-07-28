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
    Update the modules.

.PARAMETER BuildConfig
    The build configuration, either Debug or Release

.PARAMETER Scope
    Either All, Latest, Stack, NetCore, ServiceManagement, AzureStorage

#>
param(
    [Parameter(Mandatory = $false, Position = 0)]
    [ValidateSet("Release", "Debug")]
    [string] $BuildConfig
)

<#
.SYNOPSIS
    Creates a new psm1 root module if one does not exist.

.PARAMETER ModulePath
    Path to the module.

.PARAMETER TemplatePath
    Path to the template

.PARAMETER IsRMModule
    Specifies if resource management module.

#>
function New-ModulePsm1 {
    [CmdletBinding()]
    param(
        [string]$ModulePath,
        [string]$TemplatePath,
        [switch]$IsRMModule
    )

    PROCESS {
        $manifestDir = Get-Item -Path $ModulePath
        $moduleName = $manifestDir.Name + ".psd1"
        $manifestPath = Join-Path -Path $ModulePath -ChildPath $moduleName
        $file = Get-Item $manifestPath
        Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory $file.DirectoryName -FileName $file.Name

        # Do not create a psm1 file if the RootModule dependency already has one.
        if ($ModuleMetadata.RootModule) {
            Write-Host "root modules exists, skipping..."
            return
        }

        # Create the actual file and insert import statements.
        $templateOutputPath = $manifestPath -replace ".psd1", ".psm1"
        [string]$importedModules
        if ($ModuleMetadata.RequiredModules -ne $null) {
            foreach ($mod in $ModuleMetadata.RequiredModules) {
                if ($mod["ModuleVersion"]) {
                    $importedModules += New-MinimumVersionEntry -ModuleName $mod["ModuleName"] -MinimumVersion $mod["ModuleVersion"]
                } elseif ($mod["RequiredVersion"]) {
                    $importedModules += "Import-Module " + $mod["ModuleName"] + " -RequiredVersion " + $mod["RequiredVersion"] + " -Global`r`n"
                }
            }
        }

        # Create imports for nested modules.
        if ($ModuleMetadata.NestedModules -ne $null) {
            foreach ($dll in $ModuleMetadata.NestedModules) {
                $importedModules += "Import-Module (Join-Path -Path `$PSScriptRoot -ChildPath " + $dll.Substring(2) + ")`r`n"
            }
        }

        # Grab the template and replace with information.
        $template = Get-Content -Path $TemplatePath
        $template = $template -replace "%MODULE-NAME%", $file.BaseName
        $template = $template -replace "%DATE%", [string](Get-Date)
        $template = $template -replace "%IMPORTED-DEPENDENCIES%", $importedModules

        # Add deprecation messages
        if ($ModulePath -like "*Profile*") {
            $WarningMessage = "`"PowerShell version 3 and 4 will no longer be supported starting in May 2018. Please update to the latest version of PowerShell 5.1`""
            $template = $template -replace "%PSVersionDeprecationMessage%",
            "`$SpecialFolderPath = Join-Path -Path ([Environment]::GetFolderPath('ApplicationData')) -ChildPath 'Windows Azure Powershell' `
            `$DeprecationFile = Join-Path -Path `$SpecialFolderPath -ChildPath 'PSDeprecationWarning.txt' `
            if (!(Test-Path `$DeprecationFile)) { `
                Write-Warning $WarningMessage `
                try { `
                $WarningMessage | Out-File -FilePath `$DeprecationFile `
                } catch {} `
            }"
        } else {
            $template = $template -replace "%PSVersionDeprecationMessage%", ""
        }

        Write-Host "Writing psm1 manifest to $templateOutputPath"
        $template | Out-File -FilePath $templateOutputPath -Force
        $file = Get-Item -Path $templateOutputPath

    }
}

<#
.SYNOPSIS
    Create the code entry to test for the required minimum version to be loaded for the specified module.

.PARAMETER ModuleName
    Name of the module.

.PARAMETER MinimumVersion
    The minimum version required for the module.

#>
function New-MinimumVersionEntry {
    [CmdletBinding()]
    param(
        [string]$ModuleName,
        [string]$MinimumVersion
    )

    PROCESS {
        return "`$module = Get-Module $ModuleName `
if (`$module -ne `$null -and `$module.Version.ToString().CompareTo(`"$MinimumVersion`") -lt 0) `
{ `
    Write-Error `"This module requires $ModuleName version $MinimumVersion. An earlier version of $ModuleName is imported in the current PowerShell session. Please open a new session before importing this module. This error could indicate that multiple incompatible versions of the Azure PowerShell cmdlets are installed on your system. Please see https://aka.ms/azps-version-error for troubleshooting information.`" -ErrorAction Stop `
} `
elseif (`$module -eq `$null) `
{ `
    Import-Module $ModuleName -MinimumVersion $MinimumVersion -Scope Global `
}`r`n"
    }
}

<#
.SYNOPSIS
    Update the Azure modules.

.PARAMETER Scope
    The class of modules or a specific module.

.PARAMETER BuildConfig
    Debug or Release

#>
function Update-Azure {
    [CmdletBinding()]
    param(
        [ValidateNotNullOrEmpty()]
        [ValidateSet('Debug', 'Release')]
        [String]$BuildConfig
    )

    $modulePath = "$script:AzurePackages\$buildConfig\ServiceManagement\Azure"
    Write-Host "Updating ServiceManagement(aka Azure) module from $modulePath"
    New-ModulePsm1 -ModulePath $modulePath -TemplatePath $script:TemplateLocation
    Write-Host " "
}

<################################################
#  Main
#################################################>

<#
    Constants
#>
$script:TemplateLocation = "$PSScriptRoot\AzureRM.Example.psm1"

# Package locations
$script:AzurePackages = "$PSSCriptRoot\..\src\Package"


# Begin
Write-Host "Updating Azure package (and its dependencies)"
Update-Azure -BuildConfig $BuildConfig

