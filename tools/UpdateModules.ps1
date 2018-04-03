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
    Either All, Latest, Stack, AzureRM.NetCore, ServiceManagement, AzureStorage

#>
param(
    [Parameter(Mandatory = $false, Position = 0)]
    [ValidateSet("Release", "Debug")]
    [string] $BuildConfig,

    [Parameter(Mandatory = $false, Position = 1)]
    [ValidateSet("All", "Latest", "Stack", "AzureRM.NetCore","ServiceManagement","AzureStorage")]
    [string] $Scope
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
                    $importedModules += Get-MinimumVersionEntry -ModuleName $mod["ModuleName"] -MinimumVersion $mod["ModuleVersion"]
                } elseif ($mod["RequiredVersion"]) {
                    $importedModules += "Import-Module " + $mod["ModuleName"] + " -RequiredVersion " + $mod["RequiredVersion"] + "`r`n"
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

        # Handle nested modules
        $completerCommands = Find-CompleterAttribute -ModuleMetadata $ModuleMetadata -ModulePath $ModulePath -IsRMModule:$IsRMModule
        $template = $template -replace "%COMPLETERCOMMANDS%", $completerCommands

        # Handle
        $contructedCommands = Find-DefaultResourceGroupCmdlets -IsRMModule:$IsRMModule -ModuleMetadata $ModuleMetadata -ModulePath $ModulePath
        $template = $template -replace "%DEFAULTRGCOMMANDS%", $contructedCommands

        Write-Host "Writing psm1 manifest to $templateOutputPath"
        $template | Out-File -FilePath $templateOutputPath -Force
        $file = Get-Item -Path $templateOutputPath

        Add-PSM1Dependency -Path $manifestPath -ModuleName $moduleName
    }
}

<#

.SYNOPSIS
    Add psm1 root module to psd1 file for module.

.PARAMETER Path
    Path to the psd1 file.

.PARAMETER ModuleName
    Name of the psd1 file

#>
function Add-PSM1Dependency {
    [CmdletBinding()]
    param(
        [string] $Path,
        [string] $ModuleName
    )

    PROCESS {
        $psm1file = $ModuleName -replace ".psd1", ".psm1"
        Update-ModuleManifest -Path $Path -RootModule $psm1file
    }
}

<#
.SYNOPSIS
    Gets a list of nested module cmdlets

.PARAMETER ModuleMetadata
    Module metadata for the current module.

.PARAMETER ModulePath
    Path to the current module.

#>
function Get-Cmdlets {
    [CmdletBinding()]
    param(
        [Hashtable]$ModuleMetadata,
        [string]$ModulePath
    )
    $nestedModules = $ModuleMetadata.NestedModules
    $cmdlets = @()
    foreach ($module in $nestedModules) {
        $dllPath = Join-Path -Path $ModulePath -ChildPath $module
        $Assembly = [Reflection.Assembly]::LoadFrom($dllPath)
        $dllCmdlets = $Assembly.GetTypes() | Where-Object {$_.CustomAttributes.AttributeType.Name -contains "CmdletAttribute"}
        $cmdlets += $dllCmdlets
    }
    return $cmdlets
}

<#
.SYNOPSIS
    Construct completer attributes for nested modules in resource management modules.

.PARAMETER ModuleMetadata
    Module metadata for the current module.

.PARAMETER ModulePath
    Path to the current module.

.PARAMETER IsRMModule
    Specifies if resource management module.

#>
function Find-CompleterAttribute {
    [CmdletBinding()]
    param(
        [Hashtable]$ModuleMetadata,
        [string]$ModulePath,
        [switch]$IsRMModule
    )
    PROCESS {
        # Only add for resource management modules.
        $constructedCommands = "@("

        if ($IsRMModule) {
            $AllCmdlets = Get-Cmdlets -ModuleMetadata $ModuleMetadata -ModulePath $ModulePath

            foreach ($currentCmdlet in $AllCmdlets) {
                $parameters = $currentCmdlet.GetProperties()
                foreach ($parameter in $parameters) {
                    $completerAttribute = $parameter.CustomAttributes | Where-Object {$_.AttributeType.BaseType.Name -eq "PSCompleterBaseAttribute"}
                    if ($completerAttribute -ne $null) {
                        $attributeTypeName = "System.Management.Automation.CmdletAttribute"
                        $constructedCommands += "@{'Command' = '" + $currentCmdlet.GetCustomAttributes($attributeTypeName).VerbName + "-" + $currentCmdlet.GetCustomAttributes($attributeTypeName).NounName + "'; "
                        $constructedCommands += "'Parameter' = '" + $parameter.Name + "'; "
                        $constructedCommands += "'AttributeType' = '" + $completerAttribute.AttributeType + "'; "
                        $constructedCommands += "'ArgumentList' = @("
                        $completerAttribute.ConstructorArguments.Value | ForEach-Object {
                            $constructedCommands += "'" + $_.Value + "',"
                        }

                        # Remove trailing comma
                        $constructedCommands = $constructedCommands -replace ",$", ""

                        # Close
                        $constructedCommands += ")},"
                    }
                }
            }
            # Remove trailing comma
            $constructedCommands = $constructedCommands -replace ",$", ""
        }

        $constructedCommands += ")"
        return $constructedCommands
    }
}

<#
.SYNOPSIS
    Handle nested modules for resource management modules which required ResourceGroupName

.PARAMETER ModuleMetadata
    Module metadata.

.PARAMETER ModulePath
    Path to the module.

.PARAMETER IsRMModule
    Specifies if resource management module.

#>
function Find-DefaultResourceGroupCmdlets {
    [CmdletBinding()]
    param(
        [Hashtable]$ModuleMetadata,
        [string]$ModulePath,
        [switch]$IsRMModule
    )
    PROCESS {
        $contructedCommands = "@("
        if ($IsRMModule) {
            $AllCmdlets = Get-Cmdlets -ModuleMetadata $ModuleMetadata -ModulePath $ModulePath
            $FilteredCommands = $AllCmdlets | Where-Object {Test-CmdletRequiredParameter -Cmdlet $_ -Parameter "ResourceGroupName"}
            foreach ($command in $FilteredCommands) {
                $contructedCommands += "'" + $command.GetCustomAttributes("System.Management.Automation.CmdletAttribute").VerbName + "-" + $command.GetCustomAttributes("System.Management.Automation.CmdletAttribute").NounName + ":ResourceGroupName" + "',"
            }
            $contructedCommands = $contructedCommands -replace ",$", ""
        }
        $contructedCommands += ")"
        return $contructedCommands
    }
}

<#
.SYNOPSIS
    Test to see if parameter is required.

.PARAMETER Cmdlet
    Cmdlet object.

.PARAMETER Parameter
    Name of the parameter

#>
function Test-CmdletRequiredParameter {
    [CmdletBinding()]
    param(
        [Object]$Cmdlet,
        [string]$Parameter
    )

    PROCESS {
        $rgParameter = $Cmdlet.GetProperties() | Where-Object {$_.Name -eq $Parameter}
        if ($rgParameter -ne $null) {
            $parameterAttributes = $rgParameter.CustomAttributes | Where-Object {$_.AttributeType.Name -eq "ParameterAttribute"}
            foreach ($attr in $parameterAttributes) {
                $hasParameterSet = $attr.NamedArguments | Where-Object {$_.MemberName -eq "ParameterSetName"}
                $MandatoryParam = $attr.NamedArguments | Where-Object {$_.MemberName -eq "Mandatory"}
                if (($hasParameterSet -ne $null) -or (!$MandatoryParam.TypedValue.Value)) {
                    return $false
                }
            }
            return $true
        }
        return $false
    }
}

<#
.SYNOPSIS
    Get the code entry to test for the required minimum version to be loaded for the specified module.

.PARAMETER ModuleName
    Name of the module.

.PARAMETER MinimumVersion
    The minimum version required for the module.

#>
function Get-MinimumVersionEntry {
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
    Update the list of given modules' psm1/psd1 files.

.PARAMETER Modules
    The list of modules.

#>
function Update-RMModule {
    [CmdletBinding()]
    param(
        $Modules
    )
    $Ignore = @('AzureRM.Profile', 'Azure.Storage')
    foreach ($module in $Modules) {
        # filter out AzureRM.Profile which always gets published first
        # And "Azure.Storage" which is built out as test dependencies
        if ( -not ($module.Name -in $Ignore)) {
            $modulePath = $module.FullName
            Write-Host "Updating $module module from $modulePath"
            New-ModulePsm1 -ModulePath $modulePath -TemplatePath $script:TemplateLocation -IsRMModule
            Write-Host "Updated $module module`n"
        }
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
        [String]$Scope,

        [ValidateNotNullOrEmpty()]
        [ValidateSet('Debug', 'Release')]
        [String]$BuildConfig
    )

    if ($Scope -in $script:AzureRMScopes) {
        Write-Host "Updating profile module"
        New-ModulePsm1 -ModulePath "$script:AzureRMRoot\AzureRM.Profile" -TemplatePath $script:TemplateLocation -IsRMModule
        Write-Host "Updated profile module"
        Write-Host " "
    }

    if ($scope -in $script:StorageScopes) {
        $modulePath = "$AzurePackages\$buildConfig\Storage\Azure.Storage"
        Write-Host "Updating AzureStorage module from $modulePath"
        New-ModulePsm1 -ModulePath $modulePath -TemplatePath $templateLocation -IsRMModule:$false
        Write-Host " "
    }

    if ($scope -in $script:ServiceScopes) {
        $modulePath = "$AzurePackages\$buildConfig\ServiceManagement\Azure"
        Write-Host "Updating ServiceManagement(aka Azure) module from $modulePath"
        New-ModulePsm1 -ModulePath $modulePath -TemplatePath $script:TemplateLocation
        Write-Host " "
    }

    # Update all of the modules, if specified.
    if ($Scope -in $script:AzureRMScopes) {
        $resourceManagerModules = Get-ChildItem -Path $script:AzureRMRoot -Directory
        Write-Host "Updating Azure modules"
        Update-RMModule -Modules $resourceManagerModules
        Write-Host " "

    }
}

<#
.SYNOPSIS
    Update stack modules

.PARAMETER BuildConfig
    Either Debug or Release
#>
function Update-Stack {
    [CmdletBinding()]
    param(
        [ValidateNotNullOrEmpty()]
        [ValidateSet('Debug', 'Release')]
        [String]$BuildConfig
    )

    Write-Host "Updating profile module for stack"
    New-ModulePsm1 -ModulePath "$script:StackRMRoot\AzureRM.Profile" -TemplatePath $script:TemplateLocation -IsRMModule
    Write-Host "Updated profile module"
    Write-Host " "

    $StackRMModules = Get-ChildItem -Path $script:StackRMRoot -Directory
    Write-Host "Updating stack modules"
    Update-RMModule -Modules $StackRMModules
    Write-Host " "
}

<#
    Update .NET core modules.
#>
function Update-Netcore {
    [CmdletBinding()]
    param(
        [ValidateNotNullOrEmpty()]
        [ValidateSet('Debug', 'Release')]
        [String]$BuildConfig
    )

    $AzureRMModules = Get-ChildItem -Path $script:AzureRMRoot -Directory

    # Publish the Netcore modules and rollup module, if specified.
    if ($scope -eq 'AzureRM.Netcore') {
        Write-Host "Updating profile module"
        New-ModulePsm1 -ModulePath "$script:AzureRMRoot\AzureRM.Profile.Netcore" -TemplatePath $script:TemplateLocation -IsRMModule
        Write-Host "Updated profile module"

        $env:PSModulePath += "$([IO.Path]::PathSeparator)$script:AzureRMRoot\AzureRM.Profile.Netcore";

        foreach ($module in $AzureRMModules) {
            if (($module.Name -ne "AzureRM.Profile.Netcore")) {
                $modulePath = $module.FullName
                Write-Host "Updating $module module from $modulePath"
                New-ModulePsm1 -ModulePath $modulePath -TemplatePath $script:TemplateLocation -IsRMModule
                Write-Host "Updated $module module"
            }
        }

        $modulePath = "$PSScriptRoot\AzureRM.Netcore"
        Write-Host "Updating AzureRM.Netcore module from $modulePath"
        New-ModulePsm1 -ModulePath $modulePath -TemplatePath $script:TemplateLocation
        Write-Host "Updated AzureRM.Netcore module"
    }

}

<################################################
#  Main
#################################################>

<#
    Constants
#>
$script:TemplateLocation = "$PSScriptRoot\AzureRM.Example.psm1"

# Scopes
$script:NetCoreScopes = @('AzureRM.NetCore')
$script:AzureScopes = @('All', 'Latest', 'ServiceManagement', 'AzureStorage')
$script:StackScopes = @('All', 'Stack')

# Specialty-Scopes used by cmdlets
$script:AzureRMScopes = @('All', 'Latest')
$script:StorageScopes = @('All', 'Latest', 'AzureStorage')
$script:ServiceScopes = @('All', 'Latest', 'ServiceManagement')

# Package locations
$script:AzurePackages = "$PSSCriptRoot\..\src\Package"
$script:StackPackages = "$PSSCriptRoot\..\src\Stack"

# Resource Management folders
$script:AzureRMRoot = "$AzurePackages\$buildConfig\ResourceManager\AzureResourceManager"
$script:StackRMRoot = "$StackPackages\$buildConfig\ResourceManager\AzureResourceManager"


# Begin
Write-Host "Updating $Scope package (and its dependencies)"

if ($Scope -in $NetCoreScopes) {
    Update-Netcore -BuildConfig $BuildConfig
}

if ($Scope -in $AzureScopes) {
    Update-Azure -Scope $Scope -BuildConfig $BuildConfig
}

if ($Scope -in $StackScopes) {
    Update-Stack -BuildConfig $BuildConfig
}

