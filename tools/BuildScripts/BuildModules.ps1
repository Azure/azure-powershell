[CmdletBinding(DefaultParameterSetName="AllSet")]
param (
    [string]$RepoRoot,
    [string]$Configuration = 'Debug',
    [Parameter(ParameterSetName="AllSet")]
    [string]$TestsToRun = 'All',
    [string]$RepoArtifacts,
    [Parameter(ParameterSetName="CIPlanSet", Mandatory=$true)]
    [switch]$CIPlan,
    [Parameter(ParameterSetName="ModifiedBuildSet", Mandatory=$true)]
    [switch]$ModifiedModuleBuild,
	[Parameter(ParameterSetName="TargetModuleSet")]
    [string[]]$TargetModule
)
function Get-CsprojFromModule {
    param (
        [string[]]$BuildModuleList,
        [string]$SourceDirectory,
        [string]$GeneratedDirectory
    )

    $modulePath = @()
    foreach ($moduleName in $BuildModuleList) {
        if ($SourceDirectory -And '' -ne $SourceDirectory) {
            $modulePath += "$SourceDirectory/$moduleName"
        }
        if ($SourceDirectory -And '' -ne $GeneratedDirectory) {
            $modulePath += "$GeneratedDirectory/$moduleName"
        }
    }
    return Get-ChildItem -Path $modulePath -Filter "*.csproj" -Recurse | foreach-object { $_.FullName }
}

<#
    TODO: add comments
#>
$notModules = @('lib')
$coreTestModules = @('Compute', 'Network', 'Resources', 'Sql', 'Websites')
$renamedModules = @{
    'Storage' = @('Storage.Management');
    'DataFactory' = @('DataFactoryV1', 'DataFactoryV2')
}

$csprojFiles = @()
$sourceDirectory = Resolve-Path "$RepoRoot/src"
$generatedDirectory = Resolve-Path "$RepoRoot/generated"
$testModules = @()
if (-not (Test-Path $sourceDirectory)) {
    Write-Warning "Cannot find source directory: $sourceDirectory"
} elseif (-not (Test-Path $generatedDirectory)) {
    Write-Warning "Cannot find generated directory: $generatedDirectory"
}

switch ($PSCmdlet.ParameterSetName) {
    'AllSet' {
        $TargetModule = Get-Childitem -Path $sourceDirectory -Directory | ForEach-Object {$_.Name} | Where-Object { $_ -notin $notModules}
        if ('Core' -eq $TestsToRun) {
            $testModules = $coreTestModules
        } elseif ('NonCore') {
            $testModules = $TargetModule | Where-Object { $_ -notin $coreTestModules}
        } else {
            $testModules = $TargetModule
        }
    }
    'CIPlanSet' {
        $CIPlanPath = Resolve-Path "$RepoArtifacts/PipelineResult/CIPlan.json"
        If (Test-Path $CIPlanPath) {
            $CIPlan = Get-Content $CIPlanPath | ConvertFrom-Json
            $TargetModule = $CIPlan.build
            $testModules = $CIPlan.test
        }
    }
    'ModifiedBuildSet' {
        $changelogPath = Resolve-Path "$RepoRoot/tools/Azpreview/changelog.md"
        if (Test-Path $changelogPath) {
            $content = Get-Content -Path $changelogPath
            $continueReading = $false
            foreach ($line in $content) {
                if ($line -match "^##\s\d+\.\d+\.\d+") {
                    if ($continueReading) {
                        break
                    } else {
                        $continueReading = $true
                    }
                }
                elseif ($continueReading -and $line -match "^####\sAz\.(\w+)") {
                    $TargetModule += $matches[1]
                }
            }
        }
        $testModules = $TargetModule
    }
    'TargetModuleSet' {
        $testModules = $TargetModule
    }
}

$csprojFiles = Get-CsprojFromModule -BuildModuleList $TargetModule -SourceDirectory $sourceDirectory -GeneratedDirectory $generatedDirectory
$testCsprojPattern = @()
foreach ($testModule in $testModules) {
    if ($testModule -in $renamedModules) {
        foreach ($renamedTestModule in $renamedModules[$testModule]) {
            $testCsprojPattern += "^*.$renamedTestModule.Test.csproj$"
        }
    }
    $testCsprojPattern += "^*.$testModule.Test.csproj$"
}
$testCsprojPattern = ($testCsprojPattern | Join-String -Separator '|')
$testCsproj = $csprojFiles | Where-Object { $_ -match $testCsprojPattern }
# can be simplified by more complex regex maybe
$csprojFiles | Where-Object { ($_ -notmatch '^*.test.csproj$') -or $_ -in $testCsproj }
if ($testModule -and $testModule.Length -ne 0) {
    $csprojFiles += (Resolve-Path "$RepoRoot/tools/TestFx/TestFx.csproj")
}
if ('Release' -eq $Configuration) {
    $csprojFiles | Where-Object { $_ -notmatch '^*.test.csproj$' }
}
$csprojFiles | Select-Object -Unique

<#
    insert generation
#>

& dotnet --version
& dotnet new sln -n Azure.PowerShell -o $RepoArtifacts --force
foreach ($file in $csprojFiles) {
    & dotnet sln $RepoArtifacts/Azure.PowerShell.sln add "$file"
}
Write-Output "Modules are added to sln file"