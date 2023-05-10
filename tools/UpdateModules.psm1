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
    Constants
#>
$script:TemplateLocation = "$PSScriptRoot\AzureRM.Example.psm1"

# Specialty-Scopes used by cmdlets
$script:AzureRMScopes = @('All', 'Latest')
$script:StorageScopes = @('All', 'Latest', 'AzureStorage')
$script:ServiceScopes = @('All', 'Latest', 'ServiceManagement')

# Package locations
$script:AzurePackages = "$PSScriptRoot\..\artifacts"
$script:StackPackages = "$PSScriptRoot\..\src\Stack"
$script:StackProjects = "$PSScriptRoot\..\src\StackAdmin"

# Resource Management folders
$script:AzureRMRoot = "$script:AzurePackages\$buildConfig"
$script:StackRMRoot = "$script:StackPackages\$buildConfig"

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
        [switch]$IsRMModule,
        [switch]$IsNetcore,
        [switch]$IgnorePwshVersion #Ignore pwsh version check in Debug configuration
    )

    PROCESS {
        $manifestDir = Get-Item -Path $ModulePath
        $moduleName = $manifestDir.Name + ".psd1"
        $manifestPath = (Get-Item "$manifestDir/$moduleName").FullName
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
                if ($dll.EndsWith("dll")) {
                    $importedModules += "Import-Module (Join-Path -Path `$PSScriptRoot -ChildPath " + $dll + ")`r`n"
                } elseif ($dll -eq ($manifestDir.Name + ".psm1")) {
                    $importedModules += "Import-Module (Join-Path -Path `$PSScriptRoot -ChildPath Microsoft.Azure.PowerShell.Cmdlets." + $manifestDir.Name.Split(".")[-1] + ".dll" + ")`r`n"
                }
            }
        }

        # Grab the template and replace with information.
        $template = Get-Content -Path $TemplatePath
        $template = $template -replace "%MODULE-NAME%", $file.BaseName
        $template = $template -replace "%DATE%", [string](Get-Date)
        $template = $template -replace "%IMPORTED-DEPENDENCIES%", $importedModules

        #Az.Storage is using Azure.Core, so need to check PS version
        if ($IsNetcore)
        {
            if($IgnorePwshVersion)
            {
                $template = $template -replace "%AZURECOREPREREQUISITE%", ""
            }
            elseif($file.BaseName -ieq 'Az.Accounts')
            {
                $template = $template -replace "%AZURECOREPREREQUISITE%", 
@"
if (%ISAZMODULE% -and (`$PSEdition -eq 'Core'))
{
    if (`$PSVersionTable.PSVersion -lt [Version]'6.2.4')
    {
        throw "Current Az version doesn't support PowerShell Core versions lower than 6.2.4. Please upgrade to PowerShell Core 6.2.4 or higher."
    }
    if (`$PSVersionTable.PSVersion -lt [Version]'7.0.6')
    {
        Write-Warning "This version of Az.Accounts is only supported on Windows PowerShell 5.1 and PowerShell 7.0.6 or greater, open https://aka.ms/install-powershell to learn how to upgrade. For further information, go to https://aka.ms/azpslifecycle."
    }
}
"@
            }
            else
            {
                $template = $template -replace "%AZURECOREPREREQUISITE%", 
@"
if (%ISAZMODULE% -and (`$PSEdition -eq 'Core'))
{
    if (`$PSVersionTable.PSVersion -lt [Version]'6.2.4')
    {
        throw "Current Az version doesn't support PowerShell Core versions lower than 6.2.4. Please upgrade to PowerShell Core 6.2.4 or higher."
    }
}
"@
            }
        }
        # Replace Az or AzureRM with correct information
        if ($IsNetcore)
        {
            $template = $template -replace "%AZORAZURERM%", "AzureRM"
            $template = $template -replace "%ISAZMODULE%", "`$true"
        }
        else
        {
            $template = $template -replace "%AZORAZURERM%", "`Az"
            $template = $template -replace "%ISAZMODULE%", "`$false"
        }

        # Register CommandNotFound event in Az.Accounts
        if ($IsNetcore -and $file.BaseName -ieq 'Az.Accounts')
        {
            $template = $template -replace "%COMMAND-NOT-FOUND%",
@"
[Microsoft.Azure.Commands.Profile.Utilities.CommandNotFoundHelper]::RegisterCommandNotFoundAction(`$ExecutionContext.InvokeCommand)
"@
        }
        else
        {
            $template = $template -replace "%COMMAND-NOT-FOUND%"
        }

        # Handle
        $contructedCommands = Find-DefaultResourceGroupCmdlets -IsRMModule:$IsRMModule -ModuleMetadata $ModuleMetadata -ModulePath $ModulePath
        $template = $template -replace "%DEFAULTRGCOMMANDS%", $contructedCommands

        Write-Host "Writing psm1 manifest to $templateOutputPath"
        $template | Out-File -FilePath $templateOutputPath -Force
        $file = Get-Item -Path $templateOutputPath
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
        if('.dll' -ne [System.IO.Path]::GetExtension($module)) 
        {
            continue;
        }
        $dllPath = Join-Path -Path $ModulePath -ChildPath $module
        if ($dllPath.EndsWith("dll")) {
            $Assembly = [Reflection.Assembly]::LoadFrom($dllPath)
            $dllCmdlets = $Assembly.GetTypes() | Where-Object {$_.CustomAttributes.AttributeType.Name -contains "CmdletAttribute"}
            $cmdlets += $dllCmdlets
        }
    }
    return $cmdlets
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
        if (`$module -ne `$null -and `$module.Version -lt [System.Version]`"$MinimumVersion`") `
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
        $modulePath = "$script:AzurePackages\$buildConfig\Storage\Azure.Storage"
        Write-Host "Updating AzureStorage module from $modulePath"
        New-ModulePsm1 -ModulePath $modulePath -TemplatePath $script:TemplateLocation -IsRMModule:$false
        Write-Host " "
    }

    if ($scope -in $script:ServiceScopes) {
        $modulePath = "$script:AzurePackages\$buildConfig\ServiceManagement\Azure"
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

    # Update AzureRM
    if ($Scope -in $script:AzureRMScopes) {
        $modulePath = "$PSScriptRoot\AzureRM"
        Write-Host "Updating AzureRM module from $modulePath"
        New-ModulePsm1 -ModulePath $modulePath -TemplatePath $script:TemplateLocation
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

    $modulePath = "$script:StackPackages\$buildConfig\Storage\Azure.Storage"
    Write-Host "Updating AzureStorage module from $modulePath"
    New-ModulePsm1 -ModulePath $modulePath -TemplatePath $script:TemplateLocation -IsRMModule:$false
    Write-Host " "

    $StackRMModules = Get-ChildItem -Path $script:StackRMRoot -Directory
    Write-Host "Updating stack modules"
    Update-RMModule -Modules $StackRMModules
    Write-Host " "

    $modulePath = "$script:StackProjects\AzureRM"
    Write-Host "Updating AzureRM module from $modulePath"
    New-ModulePsm1 -ModulePath $modulePath -TemplatePath $script:TemplateLocation
    Write-Host " "

    $modulePath = "$script:StackProjects\AzureStack"
    Write-Host "Updating AzureStack module from $modulePath"
    New-ModulePsm1 -ModulePath $modulePath -TemplatePath $script:TemplateLocation
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
    Write-Host "Updating Accounts module"
    New-ModulePsm1 -ModulePath "$script:AzureRMRoot\Az.Accounts" -TemplatePath $script:TemplateLocation -IsRMModule -IsNetcore
    Write-Host "Updated Accounts module"

    $env:PSModulePath += "$([IO.Path]::PathSeparator)$script:AzureRMRoot\Az.Accounts";

    foreach ($module in $AzureRMModules) {
        if (($module.Name -ne "Az.Accounts")) {
            $modulePath = $module.FullName
            Write-Host "Updating $module module from $modulePath"
            New-ModulePsm1 -ModulePath $modulePath -TemplatePath $script:TemplateLocation -IsRMModule -IsNetcore
            Write-Host "Updated $module module"
        }
    }

    $modulePath = "$PSScriptRoot\Az"
    Write-Host "Updating Netcore module from $modulePath"
    New-ModulePsm1 -ModulePath $modulePath -TemplatePath $script:TemplateLocation -IsNetcore
    Write-Host "Updated Netcore module"

    $modulePath = "$PSScriptRoot\AzPreview"
    Write-Host "Updating Netcore module from $modulePath"
    New-ModulePsm1 -ModulePath $modulePath -TemplatePath $script:TemplateLocation -IsNetcore
    Write-Host "Updated Netcore module"
}
