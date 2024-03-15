[CmdletBinding(DefaultParameterSetName="AllSet")]
param (
    [string]$RepoRoot,
    [string]$Configuration,
    [string]$TestsToRun,
    [string]$RepoArtifacts,
    [string]$CoreTests,
    [Parameter(ParameterSetName="PullRequestSet", Mandatory=$true)]
    [string]$BuildCsprojList,
	[Parameter(ParameterSetName="PullRequestSet", Mandatory=$false)]
    [string]$TestCsprojList,
	[Parameter(ParameterSetName="TargetModuleSet", Mandatory=$true)]
    [string]$TargetModule,
	[Parameter(ParameterSetName="ModifiedBuildSet", Mandatory=$true)]
    [string]$ModifiedModuleBuild
)

function Include-CsprojFiles {
    param (
        [string]$Path,
        [string]$Exclude = "",
        [string]$Include = "",
        [string]$Filter = "*.csproj"

    )
    $excludeItems = @()
    foreach ($item in ($Exclude -split ';')) {
        if (-not $item) { continue }
        if (Test-Path -Path $item -PathType Leaf) {
            $excludeItems += Resolve-Path -Path $item
        }
        else {
            try {
                $excludeItems += Get-ChildItem -Path $Path -Filter $item -Recurse
            } catch {
                Write-Warning "Cannot find path or pattern: $item"
            }
        }
    }
    $includeItems = @()
    foreach ($item in ($Include -split ';')) {
        if (-not $item) { continue }
        if (Test-Path -Path $item -PathType Leaf) {
            $includeItems += Resolve-Path -Path $item
        }
        else {
            try {
                $includeItems += Get-ChildItem -Path $Path -Filter $item -Recurse
            } catch {
                Write-Warning "Cannot find path or pattern: $item"
            }
        }
    }
    $allItems = Get-ChildItem -Path $Path -Filter $Filter -Recurse
    if ($null -ne $includeItems -and $includeItems.Count -gt 0) {
        $allItems = $allItems | Where-Object { 
            ($includeItems.Path -contains $_.FullName) -or 
            ($includeItems.FullName -contains $_.FullName) 
        }
    }
    $allItems = $allItems | Where-Object { 
        ($excludeItems.Path -notcontains $_.FullName) -and 
        ($excludeItems.FullName -notcontains $_.FullName) 
    }
    $allItems
    
}

function Add-Project {
    param (
        [string]$Path,
        [string]$Configuration = "Release"
    )
    $result = @()
    $result += Include-CsprojFiles -Path $Path -Exclude "*.Test.csproj;Authenticators.csproj" -Filter "*.csproj"
    if ($Configuration -ne 'Release') {
        if ($TestsToRun -eq 'All') {
            $result += Include-CsprojFiles -Path $Path -Filter "*.Test.csproj"
        } elseif ($TestsToRun -eq 'NonCore') {
            $result += Include-CsprojFiles -Path $Path -Exclude $CoreTests -Filter "*.Test.csproj"
        } elseif ($TestsToRun -eq 'Core') {
            $result += Include-CsprojFiles -Path $Path -Include $CoreTests
        }
    }

    if ($env:OS -eq "Windows_NT") {
        $result += Include-CsprojFiles -Path $Path -Filter "Authenticators.csproj"
    }
    $result
}

$csprojFiles = @()

if ($PSCmdlet.ParameterSetName -eq 'AllSet') {
    $csprojFiles += Add-Project -Path "$RepoRoot/src/" -Configuration $Configuration
}

if ($PSCmdlet.ParameterSetName -eq 'ModifiedBuildSet' -or $PSCmdlet.ParameterSetName -eq 'TargetModuleSet') {
    .${RepoRoot}tools/BuildScripts/CheckChangeLogs.ps1 -outputFile $RepoArtifacts/ModifiedModule.txt -rootPath $RepoRoot -TargetModuleList $TargetModule
    $ModuleList = Get-Content $RepoArtifacts/ModifiedModule.txt
    foreach ($module in $ModuleList) {
        $csprojFiles += Add-Project -Path "$RepoRoot/src/$module" -Configuration $Configuration
    }
}
if ($PSCmdlet.ParameterSetName -eq 'PullRequestSet') {
    if ($PSBoundParameters.ContainsKey('BuildCsprojList') -and $BuildCsprojList) {
        $BuildCsprojList = (($BuildCsprojList -split ';' | ForEach-Object { Resolve-Path $_ }).Path) -join ';'
        $csprojFiles += Include-CsprojFiles -Path "$RepoRoot/src/" -Include $BuildCsprojList
    }
    if ($PSBoundParameters.ContainsKey('TestCsprojList') -and $TestCsprojList) {
        $TestCsprojList = (($TestCsprojList -split ';' | ForEach-Object { Resolve-Path $_ }).Path) -join ';'
        $csprojFiles += Include-CsprojFiles -Path "$RepoRoot/src/" -Include $TestCsprojList
    }
}
& dotnet --version
& dotnet new sln -n Azure.PowerShell -o $RepoArtifacts --force
foreach ($file in $csprojFiles) {
    & dotnet sln $RepoArtifacts/Azure.PowerShell.sln add "$file"
}
Write-Output "Modules are added to sln file"