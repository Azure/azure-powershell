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
    Get-ChildItem -Path $Script:RootPath -File | % { $Mappings[$_.Name] = @() }
    Get-ChildItem -Path $Script:RootPath -Directory | where { $_.Name -ne "src" } | % { $Mappings[$_.Name] = @() }
    Get-ChildItem -Path $Script:SrcPath -File | % { $Mappings["src/$_.Name"] = @() }

    if ($CustomMappings -ne $null)
    {
        $CustomMappings.GetEnumerator() | % { $Mappings[$_.Name] = $_.Value }
    }

    if ($PathsToIgnore -ne $null)
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
    return $InputObject | ConvertTo-Json -Depth 4 -Compress | % { $_.Replace("{", "{`n$Tab").Replace("],", "],`n$Tab").Replace(":[", ":[`n$Tab$Tab").Replace("`",", "`",`n$Tab$Tab").Replace("`"]", "`"`n$Tab]").Replace("]}", "]`n}") }
}

<#
Parses the assembly name from a given .csproj file.
#>
function Get-AssemblyName
{
    param
    (
        [Parameter(Mandatory = $true)]
        [string]$TestCsprojPath
    )

    $Content = Get-Content -Path $TestCsprojPath
    $MatchedAssembly = $Content | where { $_ -match "<AssemblyName>[a-zA-Z.]*<\/AssemblyName>" }
    if ($MatchedAssembly -ne $null)
    {
        return $MatchedAssembly.Trim().Trim("<AssemblyName>").Trim("</")
    }
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

        if ($TempItem.Parent -ne $null)
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

<#
Creates a mapping from a solution file to the projects it references. For example:

{
    "C:\\azure-powershell\\src\\ResourceManager\\Aks\\Aks.sln":[
        "Commands.Aks",
        "Commands.Resources.Rest",
        "Commands.Resources"
    ],
    "C:\\azure-powershell\\src\\ResourceManager\\AnalysisServices\\AnalysisServices.sln":[
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
        $SolutionFiles = Get-ChildItem -Path $ServiceFolder.FullName -Filter "*.sln" | where { $_.FullName -notlike "*Stack*" -and $_.FullName -notlike "*Netcore*" }
        foreach ($SolutionFile in $SolutionFiles)
        {
            $Mappings = Add-ProjectDependencies -Mappings $Mappings -SolutionPath $SolutionFile.FullName
        }
    }

    $Mappings = Add-ProjectDependencies -Mappings $Mappings -SolutionPath (Join-Path -Path $Script:ServiceManagementPath -ChildPath "ServiceManagement.sln")
    $Mappings = Add-ProjectDependencies -Mappings $Mappings -SolutionPath (Join-Path -Path $Script:StoragePath -ChildPath "Storage.sln")
    return $Mappings
}

<#
Parses a solution file to find the projects it is composed of (excluding test and common projects).
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

    $ProjectDependencies = @()
    $Content = Get-Content -Path $SolutionPath
    $Content | Select-String -Pattern "`"[a-zA-Z.]*`"" | % { $_.Matches[0].Value.Trim('"') } | where { $_ -notlike "Test*" -and $_ -notlike "*.Test*" -and $_ -notlike "*Common*" } | % { $ProjectDependencies += $_ }
    $Mappings[$SolutionPath] = $ProjectDependencies
    return $Mappings
}

<#
Creates a mapping from a project to its parent solution. For example:

{
    "Commands.Aks":[
        "C:\\azure-powershell\\src\\ResourceManager\\Aks\\Aks.sln"
    ],
    "Commands.AnalysisServices":[
        "C:\\azure-powershell\\src\\ResourceManager\\AnalysisServices\\AnalysisServices.sln"
    ],
    "Commands.AnalysisServices.Dataplane":[
        "C:\\azure-powershell\\src\\ResourceManager\\AnalysisServices\\AnalysisServices.sln"
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

    $Mappings = Add-SolutionReference -Mappings $Mappings -ServiceFolderPath $Script:ServiceManagementPath
    $Mappings = Add-SolutionReference -Mappings $Mappings -ServiceFolderPath $Script:StoragePath
    return $Mappings
}

<#
Map a project to the solution file it should be build with (e.g., Commands.Compute --> src/ResourceManager/Compute/Compute.sln)
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

    $CsprojFiles = Get-ChildItem -Path $ServiceFolderPath -Filter "*.csproj" -Recurse | where { $_.FullName -notlike "*Stack*" -and $_.FullName -notlike "*Netcore*" -and $_.FullName -notlike "*.Test*" }
    foreach ($CsprojFile in $CsprojFiles)
    {
        $Key = $CsprojFile.BaseName
        $Mappings[$Key] = @()
        $Script:SolutionToProjectMappings.Keys | where { $Script:SolutionToProjectMappings[$_] -contains $Key } | % { $Mappings[$Key] += $_ }
    }

    return $Mappings
}

<#
Creates the ModuleMappings.json file used during the build to filter StaticAnalysis and help generation by module.
#>
function Create-ModuleMappings
{
    $PathsToIgnore = @(
        "src/Common",
        "src/ResourceManager/Common",
        "tools"
    )

    $CustomMappings = @{
        "src/ServiceManagement" = @( "Azure" );
        "src/Storage" =           @( "Azure.Storage" )
    }

    $Mappings = Initialize-Mappings -PathsToIgnore $PathsToIgnore -CustomMappings $CustomMappings

    $FilteredServiceFolders = $Script:ServiceFolders | where { $_.FullName -notlike "*src/ResourceManager/Common*" }
    foreach ($ServiceFolder in $FilteredServiceFolders)
    {
        $Key = "src/ResourceManager/$($ServiceFolder.Name)"
        $ModuleManifestFiles = Get-ChildItem -Path $ServiceFolder.FullName -Filter "*.psd1" -Recurse | where { $_.FullName -notlike "*Stack*" -and $_.Name -like "*Azure*" -and $_.FullName -notlike "*Test*" }
        if ($ModuleManifestFiles -ne $null)
        {
            $Value = @()
            $ModuleManifestFiles | % { $Value += $_.BaseName }
            $Mappings[$Key] = $Value
        }
    }

    return $Mappings
}

<#
Creates the SolutionMappings.json file used during the build to filter the build step by solution.
#>
function Create-SolutionMappings
{
    $PathsToIgnore = @(
        "src/Common",
        "src/ResourceManager/Common",
        "tools"
    )

    $CustomMappings = @{}

    $Mappings = Initialize-Mappings -PathsToIgnore $PathsToIgnore -CustomMappings $CustomMappings
    foreach ($ServiceFolder in $Script:ServiceFolders)
    {
        $Mappings = Add-SolutionMappings -Mappings $Mappings -ServiceFolderPath $ServiceFolder.FullName
    }

    $Mappings = Add-SolutionMappings -Mappings $Mappings -ServiceFolderPath $Script:ServiceManagementPath
    $Mappings = Add-SolutionMappings -Mappings $Mappings -ServiceFolderPath $Script:StoragePath
    return $Mappings
}

<#
Maps a normalized path to the solutions to be built based on the service folder provided.
#>
function Add-SolutionMappings
{
    param
    (
        [Parameter(Mandatory = $true)]
        [hashtable]$Mappings,

        [Parameter(Mandatory = $true)]
        [string]$ServiceFolderPath
    )

    $Key = Create-Key -FilePath $ServiceFolderPath

    $CsprojFiles = Get-ChildItem -Path $ServiceFolderPath -Filter "*.csproj" -Recurse | where { $_.FullName -notlike "*Stack*" -and $_.FullName -notlike "*Netcore*" -and $_.FullName -notlike "*.Test*" }
    if ($CsprojFiles -ne $null)
    {
        $Values = New-Object System.Collections.Generic.HashSet[string]
        foreach ($CsprojFile in $CsprojFiles)
        {
            $Project = $CsprojFile.BaseName
            foreach ($Solution in $Script:ProjectToSolutionMappings[$Project])
            {
                $Solution = $Solution -replace "\\","\"
                while ($true)
                {
                    $Index = $Solution.IndexOf("\")
                    if ($Solution.Substring(0, $Index) -eq "src")
                    {
                        $Solution = ".\" + $Solution
                        break
                    }

                    $Solution = $Solution.Substring($Index + 1)
                }

                $Values.Add($Solution) | Out-Null
            }
        }

        $Mappings[$Key] = $Values
    }

    return $Mappings
}

<#
Creates the TestMappings.json file used during the build to filter the tests to run.
#>
function Create-TestMappings
{
    param
    (
        [Parameter(Mandatory = $true)]
        [hashtable]$SolutionMappings
    )

    $PathsToIgnore = @(
        "src/Common",
        "src/ResourceManager/Common",
        "tools"
    )
    $CustomMappings = @{
        "tools/BuildPackagesTask" =                        @( ".\tools\BuildPackagesTask\Microsoft.Azure.Build.Tasks.Test\bin\Debug\Microsoft.Azure.Build.Tasks.Test.dll" );
        "tools/RepoTasks" =                                @( ".\tools\RepoTasks\RepoTasks.Cmdlets.Tests\bin\Debug\RepoTasks.Cmdlets.Tests.dll" );
    }

    $Mappings = Initialize-Mappings -PathsToIgnore $PathsToIgnore -CustomMappings $CustomMappings

    $TestDllMappings = [ordered]@{}
    foreach ($ServiceFolder in $Script:ServiceFolders)
    {
        $TestDllMappings = Add-TestDllMappings -Mappings $TestDllMappings -ServiceFolderPath $ServiceFolder.FullName
    }

    $TestDllMappings = Add-TestDllMappings -Mappings $TestDllMappings -ServiceFolderPath $Script:ServiceManagementPath
    $TestDllMappings = Add-TestDllMappings -Mappings $TestDllMappings -ServiceFolderPath $Script:StoragePath

    foreach ($ServiceFolder in $Script:ServiceFolders)
    {
        $Mappings = Add-TestMappings -Mappings $Mappings -TestDllMappings $TestDllMappings -SolutionMappings $SolutionMappings -ServiceFolderPath $ServiceFolder.FullName
    }

    $Mappings = Add-TestMappings -Mappings $Mappings -TestDllMappings $TestDllMappings -SolutionMappings $SolutionMappings -ServiceFolderPath $Script:ServiceManagementPath
    $Mappings = Add-TestMappings -Mappings $Mappings -TestDllMappings $TestDllMappings -SolutionMappings $SolutionMappings -ServiceFolderPath $Script:StoragePath
    return $Mappings
}

<#
Maps a normalized solution path to the test dlls to be ran based on the service folder provided.
#>
function Add-TestDllMappings
{
    param
    (
        [Parameter(Mandatory = $true)]
        [hashtable]$Mappings,

        [Parameter(Mandatory = $true)]
        [string]$ServiceFolderPath
    )

    $SolutionFiles = Get-ChildItem -Path $ServiceFolderPath -Filter "*.sln" | where { $_.FullName -notlike "*Netcore*" -and $_.FullName -notlike "*Stack*" }
    if ($SolutionFiles -ne $null)
    {
        $SolutionKeys = $SolutionFiles | % { (("./" + (Create-Key -FilePath $_.FullName)) -replace "/", "\").Trim("\") }
        foreach ($Key in $SolutionKeys)
        {
            if ($Mappings[$Key] -eq $null)
            {
                $Mappings[$Key] = @()
            }
        }

        $TestProjects = Get-ChildItem -Path $ServiceFolderPath -Filter "*.Test*csproj" -Recurse | where { $_.FullName -notlike "*Netcore*" -and $_.FullName -notlike "*Stack*" -and $_.FullName -notlike "*Commands.Common.Test*" }
        foreach ($TestProject in $TestProjects)
        {
            $AssemblyName = Get-AssemblyName -TestCsprojPath $TestProject.FullName
            if ($AssemblyName -ne $null)
            {
                $TestBasePath = $TestProject.Directory.FullName
                while ($true)
                {
                    $Index = $TestBasePath.IndexOf("\")
                    if ($TestBasePath.Substring(0, $Index) -eq "src")
                    {
                        $TestBasePath = ".\" + $TestBasePath
                        break
                    }

                    $TestBasePath = $TestBasePath.Substring($Index + 1)
                }

                $TestDllPath = $TestBasePath + "\bin\Debug\$AssemblyName.dll"
                $SolutionKeys | % { $Mappings[$_] += $TestDllPath }
            }
        }
    }

    return $Mappings
}

<#
Maps a normalized path to the test dlls to be ran based on the service folder provided.
#>
function Add-TestMappings
{
    param
    (
        [Parameter(Mandatory = $true)]
        [hashtable]$Mappings,

        [Parameter(Mandatory = $true)]
        [hashtable]$TestDllMappings,

        [Parameter(Mandatory = $true)]
        [hashtable]$SolutionMappings,

        [Parameter(Mandatory = $true)]
        [string]$ServiceFolderPath
    )

    $Values = @()
    $TestDlls = New-Object System.Collections.Generic.HashSet[string]
    $Key = Create-Key -FilePath $ServiceFolderPath
    $Solutions = $SolutionMappings[$Key]
    foreach ($Solution in $Solutions)
    {
        $TestDllMappings[$Solution] | % { $TestDlls.Add($_) | Out-Null }
    }

    $TestDlls | % { $Values += $_ }
    $Mappings[$Key] = $Values
    return $Mappings
}

$Script:RootPath = (Get-Item -Path $PSScriptRoot).Parent.FullName
$Script:SrcPath = Join-Path -Path $Script:RootPath -ChildPath "src"
$Script:ResourceManagerPath = Join-Path $Script:SrcPath -ChildPath "ResourceManager"
$Script:ServiceFolders = Get-ChildItem -Path $Script:ResourceManagerPath -Directory
$Script:ServiceManagementPath = Join-Path -Path $Script:SrcPath -ChildPath "ServiceManagement"
$Script:StoragePath = Join-Path -Path $Script:SrcPath -ChildPath "Storage"
$Script:SolutionToProjectMappings = Create-SolutionToProjectMappings
$Script:ProjectToSolutionMappings = Create-ProjectToSolutionMappings

$ModuleMappings = Create-ModuleMappings
$SolutionMappings = Create-SolutionMappings
$TestMappings = Create-TestMappings -SolutionMappings $SolutionMappings

$ModuleMappings | Format-Json | Set-Content -Path (Join-Path -Path $Script:RootPath -ChildPath "ModuleMappings.json")
$SolutionMappings | Format-Json | Set-Content -Path (Join-Path -Path $Script:RootPath -ChildPath "SolutionMappings.json")
$TestMappings | Format-Json | Set-Content -Path (Join-Path -Path $Script:RootPath -ChildPath "TestMappings.json")