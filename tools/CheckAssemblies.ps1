$ProjectPaths = @( "$PSScriptRoot\..\src\ResourceManager" )
$DependencyMapPath = "$PSScriptRoot\..\src\Package\DependencyMap.csv"

$DependencyMap = Import-Csv -Path $DependencyMapPath

$ModuleManifestFiles = $ProjectPaths | % { Get-ChildItem -Path $_ -Filter "*.psd1" -Recurse | where { $_.FullName -notlike "*Debug*" -and `
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
            Import-LocalizedData -BindingVariable ModuleMetadata -BaseDirectory $RequiredModuleManifest.DirectoryName -FileName $RequiredModuleManifest.Name
            
            if ($ModuleMetadata.RequiredAssemblies.Count -gt 0)
            {
                $LoadedAssemblies += $ModuleMetadata.RequiredAssemblies
            }
            
            $LoadedAssemblies += $ModuleMetadata.NestedModules
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