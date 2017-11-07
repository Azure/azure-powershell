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
    [ValidateSet("SingleModule", "ListOfModules" , "AzureRmAndDependencies", "AzureAndDependencies", "NetCore")]
    [string]$scope,

    [Parameter(Mandatory = $false)]
    [string]$moduleToDelete,

    [Parameter(Mandatory = $false)]
    [string[]]$listOfModulesToDelete,

    [Parameter(Mandatory = $false)]
    [string]$apiKey,

    [Parameter(Mandatory = $false)]
    [string]$buildConfig,

    [Parameter(Mandatory = $false, Position = 4)]
    [string] $repositoryLocation,

    [Parameter(Mandatory = $false, Position = 5)]
    [string] $nugetExe
)

function Unlist-Module
{
    [CmdletBinding()]
    param(
        [string]$ModuleName,
        [string]$ModuleVersion,
        [string]$ApiKey,
        [string]$RepoLocation,
        [string]$nugetExe
    )

    PROCESS
    {
        Write-Output "Unlisting package $ModuleName from nuget source $RepoLocation"
        &$nugetExe delete $ModuleName $ModuleVersion -s $RepoLocation apikey $ApiKey
    }
}

function Get-ModuleToDelete
{
    [CmdletBinding()]
    param(
        [string]$moduleToDelete
    )

    PROCESS
    {
        $packageFolder = "$PSScriptRoot\..\src\Package"
        if (($moduleToDelete -eq "AzureRM") -or ($moduleToDelete -eq "AzureRM.Netcore"))
        {
            $rootFolder = "$packageFolder\$buildConfig"
        }

        elseif ($moduleToDelete -eq "Azure")
        {
            $rootFolder = "$packageFolder\$buildConfig\ServiceManagement\Azure"
        }

        elseif ($moduleToDelete -contains '*NetCore*')
        {
            $rootFolder = "$packageFolder\$buildConfig\ResourceManager"
        }

        elseif ($moduleToDelete -contains '*AzureRm*')
        {
            $rootFolder = "$packageFolder\$buildConfig\ResourceManager\AzureResourceManager"
        }

        elseif ($moduleToDelete -contains "*Storage*")
        {
            $rootFolder = "$packageFolder\$buildConfig\Storage"
        }

        return "$rootFolder\$moduleToDelete"
    }
}

if ($scope -eq "SingleModule")
{
    if ($moduleToDelete -eq $null)
    {
        throw "To delete a single module, moduleToDelete must not be null"
    }

    $targetModulePath = Get-ModuleToDelete -moduleToDelete $moduleToDelete
    $manifestDir = Get-Item -Path $targetModulePath
    $moduleName = $manifestDir.Name + ".psd1"
    $manifestPath = Join-Path -Path $ModulePath -ChildPath $moduleName
    $file = Get-Item $manifestPath
    Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory $file.DirectoryName -FileName $file.Name
    Unlist-Module -ModuleName $moduleToDelete -ModuleVersion $ModuleMetadata.ModuleVersion -ApiKey $apiKey -RepoLocation $repositoryLocation -nugetExe $nugetExe
}

elseif ($scope -eq "ListOfModules")
{
    if ($listOfModulesToDelete -eq $null)
    {
        throw "To delete a list of modules, listOfModulesToDelete must not be null"
    }

    $listOfModulesToDelete | ForEach-Object {
        $targetModulePath = Get-ModuleToDelete -moduleToDelete $_
        $manifestDir = Get-Item -Path $targetModulePath
        $moduleName = $manifestDir.Name + ".psd1"
        $manifestPath = Join-Path -Path $ModulePath -ChildPath $moduleName
        $file = Get-Item $manifestPath
        Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory $file.DirectoryName -FileName $file.Name
        Unlist-Module -ModuleName $moduleToDelete -ModuleVersion $ModuleMetadata.ModuleVersion -ApiKey $apiKey -RepoLocation $repositoryLocation -nugetExe $nugetExe
    }
}

elseif ($scope -eq "AzureRmAndDependencies")
{
    $manifestPath = "$PSScriptRoot\..\src\Package\$buildConfig\AzureRM.psd1"
    $file = Get-Item $manifestPath
    Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory $file.DirectoryName -FileName $file.Name
    $ModuleMetadata.RequiredModules | ForEach-Object {
        Unlist-Module -ModuleName $_.ModuleName -ModuleVersion $_.RequiredVersion -ApiKey $apiKey -RepoLocation $repositoryLocation -nugetExe $nugetExe
    }
    Unlist-Module -ModuleName "AzureRM" -ModuleVersion $ModuleMetadata.ModuleVersion -ApiKey $apiKey -RepoLocation $repositoryLocation -nugetExe $nugetExe
}

elseif ($scope -eq "AzureAndDependencies")
{
    $manifestPath = "$PSScriptRoot\..\src\Package\$buildConfig\ServiceManagement\Azure\Azure.psd1"
    $file = Get-Item $manifestPath
    Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory $file.DirectoryName -FileName $file.Name
    $ModuleMetadata.RequiredModules | ForEach-Object {
        Unlist-Module -ModuleName $_.ModuleName -ModuleVersion $_.RequiredVersion -ApiKey $apiKey -RepoLocation $repositoryLocation -nugetExe $nugetExe
    }
    Unlist-Module -ModuleName "Azure" -ModuleVersion $ModuleMetadata.ModuleVersion -ApiKey $apiKey -RepoLocation $repositoryLocation -nugetExe $nugetExe
}

elseif ($scope -eq "NetCore")
{
    $manifestPath = "$PSScriptRoot\..\src\Package\$buildConfig\AzureRm.Netcore.psd1"
    $file = Get-Item $manifestPath
    Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory $file.DirectoryName -FileName $file.Name
    $ModuleMetadata.RequiredModules | ForEach-Object {
        Unlist-Module -ModuleName $_.ModuleName -ModuleVersion $_.RequiredVersion -ApiKey $apiKey -RepoLocation $repositoryLocation -nugetExe $nugetExe
    }
    Unlist-Module -ModuleName "AzureRM.Netcore" -ModuleVersion $ModuleMetadata.ModuleVersion -ApiKey $apiKey -RepoLocation $repositoryLocation -nugetExe $nugetExe
}