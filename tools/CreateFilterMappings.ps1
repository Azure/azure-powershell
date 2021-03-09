<#
Returns an ordered hashtable with the following paths having empty mappings:
- All files at the root of the repository
- All folders at the root of the repository (except "src")
- All files in the "src" folder
#>
function Initialize-Mappings
{
    param
    (
        [Parameter(Mandatory = $false)]
        [string[]]$PathsToIgnore,

        [Parameter(Mandatory = $false)]
        [Hashtable]$CustomMappings
    )

    $Mappings = [ordered]@{}
    Get-ChildItem -Path $Script:RootPath -File | ForEach-Object { $Mappings[$_.Name] = @() }
    Get-ChildItem -Path $Script:RootPath -Directory | Where-Object { $_.Name -ne "src" } | ForEach-Object { $Mappings[$_.Name] = @() }
    Get-ChildItem -Path $Script:SrcPath -File | ForEach-Object { $Mappings["src/$_.Name"] = @() }

    if ($CustomMappings -ne $null)
    {
        $CustomMappings.GetEnumerator() | ForEach-Object { $Mappings[$_.Name] = $_.Value }
    }

    if ($null -ne $PathsToIgnore)
    {
        foreach ($Path in $PathsToIgnore)
        {
            $Mappings[$Path] = $null
            $Mappings.Remove($Path)
        }
    }

    return $Mappings
}

<#
Converts a hashtable into a compressed JSON and formats it for display.
#>
function Format-Json
{
    param
    (
        [Parameter(Mandatory = $true, ValueFromPipeline = $true)]
        [hashtable]$InputObject
    )

    $Tab = "    "
    return $InputObject | ConvertTo-Json -Depth 4 -Compress | ForEach-Object { $_.Replace("{", "{`n$Tab").Replace("],", "],`n$Tab").Replace(":[", ":[`n$Tab$Tab").Replace("`",", "`",`n$Tab$Tab").Replace("`"]", "`"`n$Tab]").Replace("]}", "]`n}") }
}

<#
Turns a file path into a normalized key (strips out everything before "src").
#>
function Create-Key
{
    param
    (
        [Parameter(Mandatory = $true)]
        [string]$FilePath
    )

    $Key = ""
    $TempFilePath = $FilePath
    while ($true)
    {
        $TempItem = Get-Item -Path $TempFilePath
        $Name = $TempItem.Name
        $Key = $Name + "/" + $Key
        if ($Name -eq "src")
        {
            break
        }

        if ($null -ne $TempItem.Parent)
        {
            $TempFilePath = $TempItem.Parent.FullName
        }
        else
        {
            $TempFilePath = $TempItem.Directory.FullName
        }
    }

    return $Key
}

function Create-ProjectToFullPathMappings
{
    $Mappings = [ordered]@{}
    foreach ($ServiceFolder in $Script:ServiceFolders)
    {
        $CsprojFiles = Get-ChildItem -Path $ServiceFolder -Filter "*.csproj" -Recurse
        foreach ($CsprojFile in $CsprojFiles)
        {
            $Mappings[$CsprojFile.BaseName] = $CsprojFile.FullName
        }
    }

    return $Mappings
}

<#
Creates a mapping from a solution file to the projects it references. For example:

{
    "C:\\azure-powershell\\src\\Aks\\Aks.sln":[
        "Commands.Aks",
        "Commands.Resources.Rest",
        "Commands.Resources"
    ],
    "C:\\azure-powershell\\src\\AnalysisServices\\AnalysisServices.sln":[
        "Commands.AnalysisServices",
        "Commands.AnalysisServices.Dataplane"
    ],
    ...
}
#>
function Create-SolutionToProjectMappings
{
    $Mappings = [ordered]@{}
    foreach ($ServiceFolder in $Script:ServiceFolders)
    {
        $SolutionFiles = Get-ChildItem -Path $ServiceFolder.FullName -Filter "*.sln"
        foreach ($SolutionFile in $SolutionFiles)
        {
            $Mappings = Add-ProjectDependencies -Mappings $Mappings -SolutionPath $SolutionFile.FullName
        }
    }

    return $Mappings
}

<#
Parses a solution file to find the projects it is composed of (excluding common projects).
#>
function Add-ProjectDependencies
{
    param
    (
        [Parameter(Mandatory = $true)]
        [hashtable]$Mappings,

        [Parameter(Mandatory = $true)]
        [string]$SolutionPath
    )

    $CommonProjectsToIgnore = @("ScenarioTest.ResourceManager", "TestFx", "Tests" )

    $ProjectDependencies = @()
    $Content = Get-Content -Path $SolutionPath
    $Content | Select-String -Pattern "`"[a-zA-Z0-9.]*`"" | ForEach-Object { $_.Matches[0].Value.Trim('"') } | Where-Object { $CommonProjectsToIgnore -notcontains $_ } | ForEach-Object { $ProjectDependencies += $_ }
    $Mappings[$SolutionPath] = $ProjectDependencies
    return $Mappings
}

<#
Creates a mapping from a project to its parent solution. For example:

{
    "Commands.Aks":[
        "C:\\azure-powershell\\src\\Aks\\Aks.sln"
    ],
    "Commands.AnalysisServices":[
        "C:\\azure-powershell\\src\\AnalysisServices\\AnalysisServices.sln"
    ],
    "Commands.AnalysisServices.Dataplane":[
        "C:\\azure-powershell\\src\\AnalysisServices\\AnalysisServices.sln"
    ],
    ...
}
#>
function Create-ProjectToSolutionMappings
{
    $Mappings = [ordered]@{}
    foreach ($ServiceFolder in $Script:ServiceFolders)
    {
        $Mappings = Add-SolutionReference -Mappings $Mappings -ServiceFolderPath $ServiceFolder.FullName
    }

    return $Mappings
}

<#
Map a project to the solution file it should be build with (e.g., Commands.Compute --> src/Compute/Compute.sln)
#>
function Add-SolutionReference
{
    param
    (
        [Parameter(Mandatory = $true)]
        [hashtable]$Mappings,

        [Parameter(Mandatory = $true)]
        [string]$ServiceFolderPath
    )

    .($PSScriptRoot + "\PreloadToolDll.ps1")
    $CsprojFiles = Get-ChildItem -Path $ServiceFolderPath -Filter "*.csproj" -Recurse | Where-Object { (-not [Tools.Common.Utilities.ModuleFilter]::IsAzureStackModule($_.FullName)) -and $_.FullName -notlike "*.Test*" }
    foreach ($CsprojFile in $CsprojFiles)
    {
        $Key = $CsprojFile.BaseName
        $Mappings[$Key] = @()
        $Script:SolutionToProjectMappings.Keys | Where-Object { $Script:SolutionToProjectMappings[$_] -contains $Key } | ForEach-Object { $Mappings[$Key] += $_ }
    }

    return $Mappings
}

<#
Creates the ModuleMappings.json file used during the build to filter StaticAnalysis and help generation by module.
#>
function Create-ModuleMappings
{
    $PathsToIgnore = @("tools")
    $CustomMappings = @{}
    $Script:ModuleMappings = Initialize-Mappings -PathsToIgnore $PathsToIgnore -CustomMappings $CustomMappings
    foreach ($ServiceFolder in $Script:ServiceFolders)
    {
        $Key = "src/$($ServiceFolder.Name)/"
        $ModuleManifestFiles = Get-ChildItem -Path $ServiceFolder.FullName -Filter "*.psd1" -Recurse | Where-Object { $_.FullName -notlike "*.Test*" -and `
                                                                                                                      $_.FullName -notlike "*Release*" -and `
                                                                                                                      $_.FullName -notlike "*Debug*" -and `
                                                                                                                      $_.Name -like "Az.*" }
        if ($null -ne $ModuleManifestFiles)
        {
            $Value = @()
            $ModuleManifestFiles | ForEach-Object { $Value += $_.BaseName }
            $Script:ModuleMappings[$Key] = $Value
        }
    }
}

<#
Creates the CsprojMappings.json file used during the build to filter the build step by project.
#>
function Create-CsprojMappings
{
    $PathsToIgnore = @("tools")
    $CustomMappings = @{}
    $Script:CsprojMappings = Initialize-Mappings -PathsToIgnore $PathsToIgnore -CustomMappings $CustomMappings
    foreach ($ServiceFolder in $Script:ServiceFolders)
    {
        Add-CsprojMappings -ServiceFolderPath $ServiceFolder.FullName
    }
}

<#
Maps a normalized path to the projects to be built based on the service folder provided.
#>

function Get-ModuleFromPath
{
    param
    (
        [Parameter(Mandatory = $true)]
        [string]$FilePath
    )

    return $FilePath.Replace('/', '\').Split('\src\')[1].Split('\')[0]
}
function Add-CsprojMappings
{
    param
    (
        [Parameter(Mandatory = $true)]
        [string]$ServiceFolderPath
    )

    $Key = Create-Key -FilePath $ServiceFolderPath

    $CsprojFiles = Get-ChildItem -Path $ServiceFolderPath -Filter "*.csproj" -Recurse
    if ($null -ne $CsprojFiles)
    {
        $Values = New-Object System.Collections.Generic.HashSet[string]
        foreach ($CsprojFile in $CsprojFiles)
        {
            $Project = Get-ModuleFromPath $CsprojFile.FullName
            foreach ($ProjectName in $Script:ProjectToSolutionMappings.Keys)
            {
                foreach ($Solution in $Script:ProjectToSolutionMappings[$ProjectName])
                {
                    $ProjectNameFromSolution = Get-ModuleFromPath $Solution
                    if ($ProjectNameFromSolution -eq $Project)
                    {
                        foreach ($ReferencedProject in $Script:SolutionToProjectMappings[$Solution])
                        {
                            $TempValue = $Script:ProjectToFullPathMappings[$ReferencedProject]
                            if (-not [string]::IsNullOrEmpty($TempValue))
                            {
                                $Values.Add($TempValue) | Out-Null
                            }
                        }
                    }
                }
            }
        }

        $Script:CsprojMappings[$Key] = $Values
    }
}

$Script:RootPath = (Get-Item -Path $PSScriptRoot).Parent.FullName
$Script:SrcPath = Join-Path -Path $Script:RootPath -ChildPath "src"
$Script:ServiceFolders = Get-ChildItem -Path $Script:SrcPath -Directory
$Script:ProjectToFullPathMappings = Create-ProjectToFullPathMappings
$Script:SolutionToProjectMappings = Create-SolutionToProjectMappings
$Script:ProjectToSolutionMappings = Create-ProjectToSolutionMappings

# Create-ModuleMappings
Create-CsprojMappings

# $Script:ModuleMappings | Format-Json | Set-Content -Path (Join-Path -Path $Script:RootPath -ChildPath "ModuleMappings.json")
$Script:CsprojMappings | Format-Json | Set-Content -Path (Join-Path -Path $Script:RootPath -ChildPath "CsprojMappings.json")