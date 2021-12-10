# ----------------------------------------------------------------------------------
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
    [ValidateNotNullOrEmpty()]
    [ValidateSet('Debug', 'Release')]
    [System.String]$BuildConfig
)

function Get-PreloadAssemblies{
    param(
        [Parameter(Mandatory=$True)]
        [string] $ModuleFolder
    )

    if($PSEdition -eq 'Core') {
        $preloadFolderName = @("NetCoreAssemblies", "AzSharedAlcAssemblies")
    } else {
        $preloadFolderName = "PreloadAssemblies"
    }
    $preloadFolderName | ForEach-Object {
        $preloadAssemblies = @()
        $preloadFolder = [System.IO.Path]::Combine($ModuleFolder, $_)
        if(Test-Path $preloadFolder){
            $preloadAssemblies = (Get-ChildItem $preloadFolder -Filter "*.dll").Name | ForEach-Object { $_ -replace ".dll", ""}
        }
        $preloadAssemblies
    }
}

$ProjectPaths = @( "$PSScriptRoot\..\artifacts\$BuildConfig" )
$DependencyMapPath = "$PSScriptRoot\..\artifacts\StaticAnalysisResults\DependencyMap.csv"

$DependencyMap = Import-Csv -Path $DependencyMapPath


.($PSScriptRoot + "\PreloadToolDll.ps1")
$ModuleManifestFiles = $ProjectPaths | ForEach-Object { Get-ChildItem -Path $_ -Filter "*.psd1" -Recurse | Where-Object { $_.FullName -like "*$($BuildConfig)*" -and `
            $_.FullName -notlike "*Netcore*" -and `
            $_.FullName -notlike "*dll-Help.psd1*" -and `
            (-not [Tools.Common.Utilities.ModuleFilter]::IsAzureStackModule($_.FullName)) } }


foreach ($ModuleManifest in $ModuleManifestFiles) {
    Write-Host "checking $($ModuleManifest.Fullname)"
    $ModuleName = $ModuleManifest.Name.Replace(".psd1", "")
    if ("Az.Resources" -eq $ModuleName)
    {
        Continue;
    }
    $Assemblies = $DependencyMap | Where-Object { $_.Directory.EndsWith($ModuleName) }
    Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory $ModuleManifest.DirectoryName -FileName $ModuleManifest.Name

    $LoadedAssemblies = @()
    if ($ModuleMetadata.RequiredAssemblies.Count -gt 0) {
        $LoadedAssemblies += $ModuleMetadata.RequiredAssemblies
    }

    $LoadedAssemblies += Get-PreloadAssemblies $ModuleManifest.Directory
    $LoadedAssemblies += $ModuleMetadata.NestedModules

    if ($ModuleMetadata.RequiredModules) {
        $RequiredModules = $ModuleMetadata.RequiredModules | ForEach-Object { $_["ModuleName"] }
        foreach ($RequiredModule in $RequiredModules) {
            Write-Output ("ModuleManifest: " + $RequiredModuleManifest)
            Write-Output ("Required Module: " + $RequiredModule)

            $RequiredModuleManifest = $ModuleManifestFiles | Where-Object { $_.Name.Replace(".psd1", "") -eq $RequiredModule } | Select-Object -First 1
            if (-not $RequiredModuleManifest) {
                continue
            }

            $RequiredModuleManifest | ForEach-Object {
                Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory $_.DirectoryName -FileName $_.Name
                if ($ModuleMetadata.RequiredAssemblies.Count -gt 0) {
                    $LoadedAssemblies += $ModuleMetadata.RequiredAssemblies
                }
                $LoadedAssemblies += $ModuleMetadata.NestedModules
            }
            $LoadedAssemblies += Get-PreloadAssemblies $RequiredModuleManifest.Directory
        }
    }

    $LoadedAssemblies = $LoadedAssemblies | Where-Object { $_ }
    $LoadedAssemblies = $LoadedAssemblies | ForEach-Object { $_.Replace(".dll", "") }

    $Found = @()
    foreach ($Assembly in $Assemblies) {
        if ($Found -notcontains $Assembly.AssemblyName -and $LoadedAssemblies -notcontains $Assembly.AssemblyName -and $Assembly.AssemblyName -notlike "System.Management.Automation*") {
            $Found += $Assembly.AssemblyName
            Write-Error "ERROR: Assembly $($Assembly.AssemblyName) was not included in the required assemblies field for module $ModuleName"
        }
    }

    if ($Found.Count -gt 0) {
        throw
    }
}