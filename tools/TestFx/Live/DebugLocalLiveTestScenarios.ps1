param (
    [Parameter(Mandatory)]
    [ValidateScript({ Test-Path -LiteralPath $_ -PathType Container })]
    [string] $RepoLocation
)

New-Variable -Name LocalRepoLocation -Value $RepoLocation -Scope Script -Option ReadOnly -Force

function ImportLocalAzModules {
    param ()

    $debugDirectory = Join-Path -Path $script:LocalRepoLocation -ChildPath "artifacts" | Join-Path -ChildPath "Debug"
    $accountsModuleDirectory = Join-Path -Path $debugDirectory -ChildPath "Az.Accounts"
    Write-Host "Start to import Azure PowerShell modules from artifacts/Debug." -ForegroundColor Green
    Write-Host "If you see module import issue, please restart the PowerShell host." -ForegroundColor Magenta

    Write-Host "Importing Az.Accounts" -ForegroundColor Green
    Import-Module (Join-Path -Path $accountsModuleDirectory -ChildPath "Az.Accounts.psd1")
    Get-ChildItem -Path $debugDirectory -Directory -Exclude "Az.Accounts" | Get-ChildItem -File -Filter "*.psd1" | ForEach-Object {
        Write-Host "Importing $($_.FullName)" -ForegroundColor Green
        Import-Module $_.FullName -Force
    }
    Write-Host "Successfully imported Azure PowerShell modules from artifacts/Debug" -ForegroundColor Green
}

function InvokeLocalLiveTestScenarios {
    param (
        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string[]] $TargetModules
    )

    $dataLocation = (Get-AzConfig -TestCoverageLocation).Value
    if ([string]::IsNullOrWhiteSpace($dataLocation) -or !(Test-Path -LiteralPath $dataLocation -PathType Container)) {
        $dataLocation = Join-Path -Path $env:USERPROFILE -ChildPath ".Azure"
    }
    Write-Host "Data location is `"$dataLocation`"" -ForegroundColor Cyan

    $srcDir = Join-Path -Path $script:LocalRepoLocation -ChildPath "src"
    $liveScenarios = Get-ChildItem -Path $srcDir -Recurse -Directory -Filter "LiveTests" | Get-ChildItem -Filter "TestLiveScenarios.ps1" -File
    $liveScenarios | ForEach-Object {
        $moduleName = [regex]::match($_.FullName, "[\\|\/]src[\\|\/](?<ModuleName>[a-zA-Z]+)[\\|\/]").Groups["ModuleName"].Value
        if (!$PSBoundParameters.ContainsKey("TargetModules") -or $moduleName -in $TargetModules) {
            Write-Host "Executing live test scenarios for module $moduleName" -ForegroundColor Cyan
            Import-Module "./tools/TestFx/Assert.ps1" -Force
            Import-Module "./tools/TestFx/Live/LiveTestUtility.psd1" -ArgumentList $moduleName, "LocalDebug", "LocalDebug", "LocalDebug", $dataLocation -Force
            . $_.FullName
        }
    }

    Write-Host "##[section]Waiting for all cleanup jobs to be completed." -ForegroundColor Green
    while (Get-Job -State Running) {
        Write-Host "[section]Waiting for 10 seconds ..." -ForegroundColor Green
        Start-Sleep -Seconds 10
    }
    Write-Host "##[section]All cleanup jobs are completed." -ForegroundColor Green

    Write-Host "##[group]Cleanup jobs information." -ForegroundColor Green
    $cleanupJobs = Get-Job
    $cleanupJobs | Select-Object Name, Command, State, PSBeginTime, PSEndTime, Output
    Write-Host "##[endgroup]"

    $cleanupJobs | Remove-Job
}

ImportLocalAzModules
