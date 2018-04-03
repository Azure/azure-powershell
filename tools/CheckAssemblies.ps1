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

[CmdletBinding()]
Param
(
    [Parameter()]
    [string]$BuildConfig
)

$ProjectPaths = @( "$PSScriptRoot\..\src\ResourceManager" )
$DependencyMapPath = "$PSScriptRoot\..\src\Package\DependencyMap.csv"

$DependencyMap = Import-Csv -Path $DependencyMapPath

$ModuleManifestFiles = $ProjectPaths | % { Get-ChildItem -Path $_ -Filter "*.psd1" -Recurse | where { $_.FullName -notlike "*$BuildConfig*" -and `
                                                                                                                        $_.FullName -notlike "*Netcore*" -and `
                                                                                                                        $_.FullName -notlike "*dll-Help.psd1*" -and `
                                                                                                                        $_.FullName -notlike "*Stack*" } }

foreach ($ModuleManifest in $ModuleManifestFiles)
{
    $ModuleName = $ModuleManifest.Name.Replace(".psd1", "")
    $Assemblies = $DependencyMap | where { $_.Directory.EndsWith($ModuleName) }
    Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory $ModuleManifest.DirectoryName -FileName $ModuleManifest.Name

    $LoadedAssemblies = @()
    if ($ModuleMetadata.RequiredAssemblies.Count -gt 0)
    {
        $LoadedAssemblies += $ModuleMetadata.RequiredAssemblies
    }
    
    $LoadedAssemblies += $ModuleMetadata.NestedModules

    if ($ModuleMetadata.RequiredModules)
    {
        $RequiredModules = $ModuleMetadata.RequiredModules | % { $_["ModuleName"] }
        foreach ($RequiredModule in $RequiredModules)
        {
            $RequiredModuleManifest = $ModuleManifestFiles | where { $_.Name.Replace(".psd1", "") -eq $RequiredModule }
            if (-not $RequiredModuleManifest)
            {
                continue
            }
            
            $RequiredModuleManifest | % {
                Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory $_.DirectoryName -FileName $_.Name
            
                if ($ModuleMetadata.RequiredAssemblies.Count -gt 0)
                {
                    $LoadedAssemblies += $ModuleMetadata.RequiredAssemblies
                }
                
                $LoadedAssemblies += $ModuleMetadata.NestedModules
            }
        }
    }
    
    $LoadedAssemblies = $LoadedAssemblies | % { $_.Substring(2) }
    $LoadedAssemblies = $LoadedAssemblies | % { $_.Replace(".dll", "") }

    $Found = @()
    foreach ($Assembly in $Assemblies)
    {
        if ($Found -notcontains $Assembly.AssemblyName -and $LoadedAssemblies -notcontains $Assembly.AssemblyName)
        {
            $Found += $Assembly.AssemblyName
            Write-Error "ERROR: Assembly $($Assembly.AssemblyName) was not included in the required assemblies field for module $ModuleName"
        }
    }

    if ($Found.Count -gt 0)
    {
        throw
    }
}
