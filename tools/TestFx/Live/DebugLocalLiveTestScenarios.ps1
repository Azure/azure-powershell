param (
    [Parameter(Mandatory)]
    [ValidateScript({ Test-Path -LiteralPath $_ -PathType Container })]
    [string] $RepoLocation,

    [Parameter()]
    [ValidateNotNullOrEmpty()]
    [string] $RunPlatform = "Windows",

    [Parameter()]
    [switch] $NoModuleImport
)

function ImportLocalAzModules {
    param ()

    $debugDirectory = Join-Path -Path $RepoLocation -ChildPath "artifacts" | Join-Path -ChildPath "Debug"
    $accountsModuleDirectory = Join-Path -Path $debugDirectory -ChildPath "Az.Accounts"
    Write-Host "Start to import Azure PowerShell modules from artifacts/Debug." -ForegroundColor Green
    Write-Host "If you see module import issue, please restart the PowerShell host." -ForegroundColor Magenta

    Write-Host "Importing Az.Accounts" -ForegroundColor Green
    Import-Module (Join-Path -Path $accountsModuleDirectory -ChildPath "Az.Accounts.psd1")
    Get-ChildItem -Path $debugDirectory -Directory -Exclude "Az.Accounts" | Get-ChildItem -File -Filter "*.psd1" | Select-Object -ExpandProperty FullName | ForEach-Object {
        Write-Host "Importing $_" -ForegroundColor Green
        Import-Module $_ -Force
    }
    Write-Host "Successfully imported Azure PowerShell modules from artifacts/Debug" -ForegroundColor Green
}

function InvokeLocalLiveTestScenarios {
    param (
        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string[]] $TargetModule,

        [Parameter()]
        [ValidateScript({ Test-Path -LiteralPath $_ -PathType Container })]
        [string] $Output = (Get-Location)
    )

    $srcDir = Join-Path -Path $RepoLocation -ChildPath "src"
    $liveScenarios = Get-ChildItem -Path $srcDir -Recurse -Directory -Filter "LiveTests" | Get-ChildItem -Filter "TestLiveScenarios.ps1" -File | Select-Object -ExpandProperty FullName
    $liveScenarios | ForEach-Object {
        $moduleName = [regex]::match($_, "[\\|\/]src[\\|\/](?<ModuleName>[a-zA-Z]+)[\\|\/]").Groups["ModuleName"].Value
        if (!$PSBoundParameters.ContainsKey("TargetModule") -or $moduleName -in $TargetModule) {
            Write-Host "Executing live test scenarios for module $moduleName" -ForegroundColor Cyan
            Import-Module "./tools/TestFx/Assert.ps1" -Force
            Import-Module "./tools/TestFx/Live/LiveTestUtility.psd1" -ArgumentList $moduleName, $RunPlatform, $Output -Force
            . $_
        }
    }

    Write-Host "Waiting for all cleanup jobs to be completed." -ForegroundColor Green
    while (Get-Job -State Running) {
        Write-Host "Waiting for 10 seconds ..." -ForegroundColor Green
        Start-Sleep -Seconds 10
    }
    Write-Host "All cleanup jobs are completed." -ForegroundColor Green

    Write-Host "Cleanup jobs information." -ForegroundColor Green

    Write-Host
    $cleanupJobs = Get-Job
    $cleanupJobs | Select-Object Name, Command, State, PSBeginTime, PSEndTime, Output
    Write-Host

    $cleanupJobs | Remove-Job
}

if (!$NoModuleImport.IsPresent) {
    ImportLocalAzModules
}
