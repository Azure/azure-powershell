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
param(
    [Parameter(Mandatory = $false, Position = 0)]
    [string] $buildConfig,
    [Parameter(Mandatory = $false, Position = 1)]
    [string] $scope,
    [Parameter(Mandatory=$false)]
    [ValidateSet("Latest", "Stack")]
    [string] $Profile = "Latest"
)

function Create-ModulePsm1
{
  [CmdletBinding()]
  param(
    [string]$ModulePath,
    [string]$TemplatePath,
    [bool]$IsRMModule
  )

  PROCESS
  {
     $manifestDir = Get-Item -Path $ModulePath
     $moduleName = $manifestDir.Name + ".psd1"
     $manifestPath = Join-Path -Path $ModulePath -ChildPath $moduleName
     $file = Get-Item $manifestPath
     Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory $file.DirectoryName -FileName $file.Name
     if ($ModuleMetadata.RootModule)
     {
         # Do not create a psm1 file if the RootModule dependency already has one.
         return
     }
     
     $templateOutputPath = $manifestPath -replace ".psd1", ".psm1"
     [string]$importedModules
     if ($ModuleMetadata.RequiredModules -ne $null)
     {
        foreach ($mod in $ModuleMetadata.RequiredModules)
        {
           if ($mod["ModuleVersion"])
           {
               $importedModules += Create-MinimumVersionEntry -ModuleName $mod["ModuleName"] -MinimumVersion $mod["ModuleVersion"]
           }
           elseif ($mod["RequiredVersion"])
           {
               $importedModules += "Import-Module " + $mod["ModuleName"] + " -RequiredVersion " + $mod["RequiredVersion"] + "`r`n"
           }        
        }
     }

     if ($ModuleMetadata.NestedModules -ne $null)
     {
         foreach ($dll in $ModuleMetadata.NestedModules)
         {
             $importedModules += "Import-Module (Join-Path -Path `$PSScriptRoot -ChildPath " + $dll.Substring(2) + ")`r`n"
         }
     }

     $template = Get-Content -Path $TemplatePath
     $template = $template -replace "%MODULE-NAME%", $file.BaseName
     $template = $template -replace "%DATE%", [string](Get-Date)
     $template = $template -replace "%IMPORTED-DEPENDENCIES%", $importedModules

     if ($ModulePath -like "*Profile*")
     {
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
     }
     else
     {
         $template = $template -replace "%PSVersionDeprecationMessage%", ""
     }

     $completerCommands = Find-CompleterAttribute -ModuleMetadata $ModuleMetadata -ModulePath $ModulePath -IsRMModule $IsRMModule
     $template = $template -replace "%COMPLETERCOMMANDS%", $completerCommands

     $contructedCommands = Find-DefaultResourceGroupCmdlets -IsRMModule $IsRMModule -ModuleMetadata $ModuleMetadata -ModulePath $ModulePath
     $template = $template -replace "%DEFAULTRGCOMMANDS%", $contructedCommands

     Write-Host "Writing psm1 manifest to $templateOutputPath"
     $template | Out-File -FilePath $templateOutputPath -Force
     $file = Get-Item -Path $templateOutputPath

     if($scope -ne 'AzureRM.Netcore') {
        Add-PSM1Dependency -Path $manifestPath
     }
  }
}

function Add-PSM1Dependency
{
  [CmdletBinding()]
  param(
  [string] $Path)

  PROCESS 
  {
    $file = Get-Item -Path $Path
    $manifestFile = $file.Name
    $psm1file = $manifestFile -replace ".psd1", ".psm1"
    Update-ModuleManifest -Path $Path -RootModule $psm1file
  }
}

function Find-CompleterAttribute
{
    [CmdletBinding()]
    param(
        [Hashtable]$ModuleMetadata,
        [string]$ModulePath,
        [bool]$IsRMModule
    )
    PROCESS
    {
        if ($IsRMModule)
        {
            $nestedModules = $ModuleMetadata.NestedModules
            $AllCmdlets = @()
            $nestedModules | ForEach-Object {
                $dllPath = Join-Path -Path $ModulePath -ChildPath $_
                $Assembly = [Reflection.Assembly]::LoadFrom($dllPath)
                $dllCmdlets = $Assembly.GetTypes() | Where-Object {$_.CustomAttributes.AttributeType.Name -contains "CmdletAttribute"}
                $AllCmdlets += $dllCmdlets
            }

            $constructedCommands = "@("
            $AllCmdlets | ForEach-Object {
                $currentCmdlet = $_
                $parameters = $_.GetProperties()
                $parameters | ForEach-Object {
                    $completerAttribute = $_.CustomAttributes | Where-Object {$_.AttributeType.BaseType.Name -eq "PSCompleterBaseAttribute"}
                    if ($completerAttribute -ne $null) {
                        $attributeTypeName = "System.Management.Automation.CmdletAttribute"
                        $constructedCommands += "@{'Command' = '" + $currentCmdlet.GetCustomAttributes($attributeTypeName).VerbName + "-" + $currentCmdlet.GetCustomAttributes($attributeTypeName).NounName + "'; "
                        $constructedCommands += "'Parameter' = '" + $_.Name + "'; "
                        $constructedCommands += "'AttributeType' = '" + $completerAttribute.AttributeType + "'; "
                        if ($completerAttribute.ConstructorArguments.Count -eq 0) 
                        {
                            $constructedCommands += "'ArgumentList' = @()"
                        }

                        else 
                        {
                            $constructedCommands += "'ArgumentList' = @("
                            $completerAttribute.ConstructorArguments.Value | ForEach-Object {
                                $constructedCommands += "'" + $_.Value + "',"
                            }
                            $constructedCommands = $constructedCommands -replace ".$",")"
                        }

                        $constructedCommands += "},"
                    }
                }
            }

            if ($constructedCommands.Substring($constructedCommands.Length - 1) -eq ",")
            {
                $constructedCommands = $constructedCommands -replace ".$",")"
            }
            
            else {
                $constructedCommands += ")"
            }
        }

        else 
        {
            $constructedCommands = "@()"    
        }

        return $constructedCommands
    }
}
function Find-DefaultResourceGroupCmdlets
{
    [CmdletBinding()]
    param(
        [bool]$IsRMModule,
        [Hashtable]$ModuleMetadata,
        [string]$ModulePath
    )
    PROCESS
    {
        if ($IsRMModule) 
        {
        $nestedModules = $ModuleMetadata.NestedModules
        $AllCmdlets = @()
        $nestedModules | ForEach-Object {
            $dllPath = Join-Path -Path $ModulePath -ChildPath $_
            $Assembly = [Reflection.Assembly]::LoadFrom($dllPath)
            $dllCmdlets = $Assembly.GetTypes() | Where-Object {$_.CustomAttributes.AttributeType.Name -contains "CmdletAttribute"}
            $AllCmdlets += $dllCmdlets
        }
        
        $FilteredCommands = $AllCmdlets | Where-Object {Test-CmdletRequiredParameter -Cmdlet $_ -Parameter "ResourceGroupName"}
    
        if ($FilteredCommands.Length -eq 0) {
            $contructedCommands = "@()"
        }
        else {
            $contructedCommands = "@("
            $FilteredCommands | ForEach-Object {
                $contructedCommands += "'" + $_.GetCustomAttributes("System.Management.Automation.CmdletAttribute").VerbName + "-" + $_.GetCustomAttributes("System.Management.Automation.CmdletAttribute").NounName + ":ResourceGroupName" + "',"
            }
            $contructedCommands = $contructedCommands -replace ".$",")"
        }
    
        return $contructedCommands
        }

        else {
        return "@()"
        }
    }
}

function Test-CmdletRequiredParameter
{
    [CmdletBinding()]
    param(
        [Object]$Cmdlet,
        [string]$Parameter
    )

    PROCESS
    {
        $rgParameter = $Cmdlet.GetProperties() | Where-Object {$_.Name -eq $Parameter}
        if ($rgParameter -ne $null) {
            $parameterAttributes = $rgParameter.CustomAttributes | Where-Object {$_.AttributeType.Name -eq "ParameterAttribute"}
            $isMandatory = $true
            $parameterAttributes | ForEach-Object {
                $hasParameterSet = $_.NamedArguments | Where-Object {$_.MemberName -eq "ParameterSetName"}
                $MandatoryParam = $_.NamedArguments | Where-Object {$_.MemberName -eq "Mandatory"}
                if (($hasParameterSet -ne $null) -or (!$MandatoryParam.TypedValue.Value)) {
                    $isMandatory = $false
                }
            }
            if ($isMandatory) {
                return $true
            }
        }
        
        return $false
    }
}

function Create-MinimumVersionEntry
{
    [CmdletBinding()]
    param(
        [string]$ModuleName,
        [string]$MinimumVersion
    )

    PROCESS
    {
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

if ([string]::IsNullOrEmpty($buildConfig))
{
    Write-Verbose "Setting build configuration to 'Release'"
    $buildConfig = "Release"
}

if ([string]::IsNullOrEmpty($scope))
{
    Write-Verbose "Default scope to all"
    $scope = 'All'  
}

Write-Host "Updating $scope package(and its dependencies)" 

$packageFolder = "$PSScriptRoot\..\src\Package"

if ($Profile -eq "Stack")
{
    $packageFolder = "$PSScriptRoot\..\src\Stack"
}

$resourceManagerRootFolder = "$packageFolder\$buildConfig\ResourceManager\AzureResourceManager"
$resourceManagerModules = Get-ChildItem -Path $resourceManagerRootFolder -Directory
$templateLocation = "$PSScriptRoot\AzureRM.Example.psm1"

# If we publish 'All', publish AzureRM.Profile first, because it is the common dependency.
if ($scope -eq 'All' ) {
    Write-Host "Updating profile module"
    Create-ModulePsm1 -ModulePath "$resourceManagerRootFolder\AzureRM.Profile" -TemplatePath $templateLocation -IsRMModule $true
    Write-Host "Updated profile module"
}

# Publish AzureStorage, if needed.
if (($scope -eq 'All') -or ($scope -eq 'AzureStorage')) {
    $modulePath = "$packageFolder\$buildConfig\Storage\Azure.Storage"
    # Publish AzureStorage module
    Write-Host "Updating AzureStorage module from $modulePath"
    Create-ModulePsm1 -ModulePath $modulePath -TemplatePath $templateLocation -IsRMModule $false
} 

# Publish ServiceManagement, if needed.
if (($scope -eq 'All') -or ($scope -eq 'ServiceManagement')) {
    $modulePath = "$packageFolder\$buildConfig\ServiceManagement\Azure"
    # Publish Azure module
    Write-Host "Updating ServiceManagement(aka Azure) module from $modulePath"
    Create-ModulePsm1 -ModulePath $modulePath -TemplatePath $templateLocation -IsRMModule $false
} 

# Publish all of the modules, if specified.
if ($scope -eq 'All') {
    foreach ($module in $resourceManagerModules) {
        # filter out AzureRM.Profile which always gets published first 
        # And "Azure.Storage" which is built out as test dependencies  
        if (($module.Name -ne "AzureRM.Profile") -and ($module.Name -ne "Azure.Storage")) {
            $modulePath = $module.FullName
            Write-Host "Updating $module module from $modulePath"
            Create-ModulePsm1 -ModulePath $modulePath -TemplatePath $templateLocation -IsRMModule $true
            Write-Host "Updated $module module"
        }
    }
}

# Publish a specific module if one of the rollups are not specified.
if (($scope -ne 'All') -and ($scope -ne 'AzureRM') -and $scope -ne 'AzureRM.Netcore') {
    $modulePath = Join-Path $resourceManagerRootFolder "AzureRM.$scope"
    if (Test-Path $modulePath) {
        Write-Host "Updating $scope module from $modulePath"
        Create-ModulePsm1 -ModulePath $modulePath -TemplatePath $templateLocation -IsRMModule $false
        Write-Host "Updated $scope module"        
    } else {
        Write-Error "Can not find module with name $scope to publish"
    }
}

# Publish the rollup modules, if specified.
if (($scope -eq 'All') -or ($scope -eq 'AzureRM')) {
    # Update AzureRM module    
    if ($Profile -eq "Stack")
    {
        $modulePath = "$PSScriptRoot\..\src\StackAdmin\AzureRM"
        Write-Host "Updating AzureRM module from $modulePath"
        Create-ModulePsm1 -ModulePath $modulePath -TemplatePath $templateLocation -IsRMModule $false
        Write-Host "Updated AzureRM module"
        $modulePath = "$PSScriptRoot\..\src\StackAdmin\AzureStack"
        Write-Host "Updating AzureRM module from $modulePath"
        Create-ModulePsm1 -ModulePath $modulePath -TemplatePath $templateLocation -IsRMModule $false
        Write-Host "Updated AzureStack module"
    }
    else {
        $modulePath = "$PSScriptRoot\AzureRM"
        Write-Host "Updating AzureRM module from $modulePath"
        Create-ModulePsm1 -ModulePath $modulePath -TemplatePath $templateLocation -IsRMModule $false
        Write-Host "Updated Azure module"
    }
}

# Publish the Netcore modules and rollup module, if specified.
if($scope -eq 'AzureRM.Netcore') {
    Write-Host "Updating profile module"
    Create-ModulePsm1 -ModulePath "$resourceManagerRootFolder\AzureRM.Profile.Netcore" -TemplatePath $templateLocation -IsRMModule $true
    Write-Host "Updated profile module"

    foreach ($module in $resourceManagerModules) {
        if (($module.Name -ne "AzureRM.Profile.Netcore")) {
            $modulePath = $module.FullName
            Write-Host "Updating $module module from $modulePath"
            Create-ModulePsm1 -ModulePath $modulePath -TemplatePath $templateLocation -IsRMModule $true
            Write-Host "Updated $module module"
        }
    }

    $modulePath = "$PSScriptRoot\AzureRM.Netcore"
    Write-Host "Updating AzureRM.Netcore module from $modulePath"
    Create-ModulePsm1 -ModulePath $modulePath -TemplatePath $templateLocation -IsRMModule $false
    Write-Host "Updated AzureRM.Netcore module"
}