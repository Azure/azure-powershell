[CmdletBinding(DefaultParameterSetName="AllSet")]
param (
    [string]$RepoRoot,
    [string]$Configuration,
    [string]$TestsToRun,
    [string]$RepoArtifacts,
    [string]$CoreTests,
    [Parameter(ParameterSetName="PullRequestSet", Mandatory=$true)]
    [string]$BuildCsprojList,
	[Parameter(ParameterSetName="PullRequestSet", Mandatory=$true)]
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

    $excludeItems = $Exclude -split ";"
    $includeItems = $Include -split ";"

    Get-ChildItem -Path $Path -Filter $Filter -Recurse -Exclude $excludeItems -Include $includeItems
}

$csprojFiles = @()

if ($PSCmdlet.ParameterSetName -eq 'AllSet') {
    $csprojFiles += Include-CsprojFiles -Path "$RepoRoot/src/" -Exclude "*.Test.csproj;Authenticators.csproj" -Filter "*.csproj"
    if ($Configuration -ne 'Release' -and $TestsToRun -eq 'All') {
        $csprojFiles += Include-CsprojFiles -Path "$RepoRoot/src/" -Filter "*.Test.csproj"
    }

    if ($Configuration -ne 'Release' -and $TestsToRun -eq 'NonCore') {
        $csprojFiles += Include-CsprojFiles -Path "$RepoRoot/src" -Exclude $CoreTests -Filter "*.Test.csproj"
    }

    if ($Configuration -ne 'Release' -and $TestsToRun -eq 'Core') {
        $csprojFiles += Include-CsprojFiles -Path "$RepoRoot/src" -Include $CoreTests
    }

    if ($env:OS -eq "Windows_NT") {
        $csprojFiles += Include-CsprojFiles -Path "$RepoRoot/src" -Filter "Authenticators.csproj"
    }

}

if ($PSCmdlet.ParameterSetName -eq 'ModifiedBuildSet' -or $PSCmdlet.ParameterSetName -eq 'TargetModuleSet') {
    .$RepoRoot\tools\BuildScripts\CheckChangeLogs.ps1 -outputFile $RepoArtifacts/ModifiedModule.txt -rootPath $RepoRoot -TargetModuleList $TargetModule
    $ModuleList = Get-Content $RepoArtifacts/ModifiedModule.txt
    foreach ($module in $ModuleList) {
        $modulePath = "$RepoRoot/src/$module"
        $csprojFiles += Include-CsprojFiles -Path "$modulePath" -Exclude "*.Test.csproj;Authenticators.csproj" -Filter "*.csproj"
        if ($Configuration -ne 'Release') {
            if ($TestsToRun -eq 'All') {
                $csprojFiles += Include-CsprojFiles -Path $modulePath -Filter "*.Test.csproj"
            } elseif ($TestsToRun -eq 'NonCore') {
                $csprojFiles += Include-CsprojFiles -Path $modulePath -Exclude $CoreTests -Filter "*.Test.csproj"
            } elseif ($TestsToRun -eq 'Core') {
                $csprojFiles += Include-CsprojFiles -Path $modulePath -Include $CoreTests
            }
        }

        if ($env:OS -eq "Windows_NT") {
            $csprojFiles += Include-CsprojFiles -Path "$modulePath" -Filter "Authenticators.csproj"
        }
    }
}
if ($PSCmdlet.ParameterSetName -eq 'PullRequestSet') {
    $BuildCsprojList = $BuildCsprojList -replace ' ', ';'
    $TestCsprojList = $TestCsprojList -replace ' ', ';'
    $csprojFiles += Include-CsprojFiles -Path "$RepoRoot/src/" -Include $BuildCsprojList
    $csprojFiles += Include-CsprojFiles -Path "$RepoRoot/src/" -Include $TestCsprojList
}
foreach ($file in $csprojFiles) {
    & dotnet sln $RepoArtifacts/Azure.PowerShell.sln add "$file"
}

Write-Output "Modules are added to sln file"