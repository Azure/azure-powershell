param (
    [string]$RepoRoot,
    [string]$Configuration,
    [string]$TestsToRun,
    [string]$PullRequestNumber,
    [string]$TargetModule,
    [string]$ModifiedModuleBuild,
    [string]$CoreTests,
    [string]$RepoArtifacts
)

function Include-CsprojFiles {
    param (
        [string]$Path,
        [string]$Exclude = ""
    )

    $excludeItems = $Exclude -split ";"
    Get-ChildItem -Path $Path -Filter "*.csproj" -Recurse | Where-Object {
        $include = $true
        foreach ($item in $excludeItems) {
            if ($_ -match $item) {
                $include = $false
                break
            }
        }
        return $include
    }
}

$csprojFiles = @()

if ($PullRequestNumber -eq 'null' -and $TargetModule -eq 'null' -and $ModifiedModuleBuild -eq 'false') {
    $csprojFiles += Include-CsprojFiles -Path "$RepoRoot/src/" -Exclude ".Test.csproj;Authenticators.csproj"
    if ($Configuration -ne 'Release' -and $TestsToRun -eq 'All') {
        $csprojFiles += Include-CsprojFiles -Path "$RepoRoot/src/**/**/*.Test.csproj"
    }

    if ($Configuration -ne 'Release' -and $TestsToRun -eq 'NonCore') {
        $csprojFiles += Include-CsprojFiles -Path "$RepoRoot/src/**/**/*.Test.csproj" -Exclude $CoreTests
    }

    if ($Configuration -ne 'Release' -and $TestsToRun -eq 'Core') {
        $csprojFiles += Include-CsprojFiles -Path $CoreTests
    }

    if ($env:OS -eq "Windows_NT") {
        $csprojFiles += Include-CsprojFiles -Path "$RepoRoot/src/**/**/Authenticators.csproj"
    }

}

if ($ModifiedModuleBuild -eq "true" -or $TargetModule -ne 'null') {
    .$RepoRoot\tools\BuildScripts\CheckChangeLogs.ps1 -outputFile $RepoArtifacts/ModifiedModule.txt -rootPath $RepoRoot -TargetModuleList $TargetModule
    $ModuleList = Get-Content $RepoArtifacts/ModifiedModule.txt
    foreach ($module in $ModuleList) {
        $modulePath = "$RepoRoot/src/$module"
        $csprojFiles += Get-ChildItem -Path "$modulePath/**/" -Recurse | Where-Object { -not $_.FullName.Contains(".Test.csproj") -and -not $_.FullName.Contains("Authenticators.csproj") }

        if ($Configuration -ne 'Release') {
            if ($TestsToRun -eq 'All') {
                $csprojFiles += Get-ChildItem -Path "$modulePath/**/*.Test.csproj" -Recurse
            } elseif ($TestsToRun -eq 'NonCore') {
                $csprojFiles += Get-ChildItem -Path "$modulePath/**/*.Test.csproj" -Recurse | Where-Object { -not $_.FullName.Contains($CoreTests) }
            } elseif ($TestsToRun -eq 'Core') {
                $csprojFiles += Get-ChildItem -Path $CoreTests -Recurse
            }
        }

        if ($env:OS -eq "Windows_NT") {
            $csprojFiles += Get-ChildItem -Path "$modulePath/**/Authenticators.csproj" -Recurse
        }
    }
}

foreach ($file in $csprojFiles) {
    & dotnet sln $RepoArtifacts/Azure.PowerShell.sln add "$file"
}
