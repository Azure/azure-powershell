param (
    [Parameter(Mandatory)]
    [ValidateScript({ Test-Path -LiteralPath $_ -PathType Container })]
    [string] $RepoLocation,

    [Parameter()]
    [switch] $DebugMode
)

dynamicparam {
    if (!$DebugMode.IsPresent) {
        $dynParams = [Management.Automation.RuntimeDefinedParameterDictionary]::new()
        $paramBuildId = [Management.Automation.RuntimeDefinedParameter]::new(
            "BuildId",
            [string],
            [Attribute[]]@(
                [Parameter]@{ Mandatory = $true }
                [ValidateNotNullOrEmpty]::new()
            )
        )
        $paramOSVersion = [Management.Automation.RuntimeDefinedParameter]::new(
            "OSVersion",
            [string],
            [Attribute[]]@(
                [Parameter]@{ Mandatory = $true }
                [ValidateNotNullOrEmpty]::new()
            )
        )
        $paramPSVersion = [Management.Automation.RuntimeDefinedParameter]::new(
            "PSVersion",
            [string],
            [Attribute[]]@(
                [Parameter]@{ Mandatory = $true }
                [ValidateNotNullOrEmpty]::new()
            )
        )
        $dynParams.Add($paramBuildId.Name, $paramBuildId)
        $dynParams.Add($paramOSVersion.Name, $paramOSVersion)
        $dynParams.Add($paramPSVersion.Name, $paramPSVersion)
        $dynParams
    }
}

process {
    function FillLiveTestCoverageAdditionalInfo {
        [CmdletBinding()]
        param (
            [Parameter(Mandatory)]
            [ValidateScript({ Test-Path -LiteralPath $_ -PathType Container })]
            [string] $TestCoverageDataLocation,

            [Parameter(Mandatory)]
            [ValidateNotNullOrEmpty()]
            [string] $BuildId,

            [Parameter(Mandatory)]
            [ValidateNotNullOrEmpty()]
            [string] $OSVersion,

            [Parameter(Mandatory)]
            [ValidateNotNullOrEmpty()]
            [string] $PSVersion,

            [Parameter(Mandatory)]
            [ValidateNotNullOrEmpty()]
            [string] $ModuleName
        )

        $testCoverageUtility = $PSScriptRoot | Split-Path | Join-Path -ChildPath "Coverage" | Join-Path -ChildPath "TestCoverageUtility.psd1"
        Import-Module $testCoverageUtility
        $module = Get-Module -Name "Az.$ModuleName" -ListAvailable
        $moduleDetails = Get-TestCoverageModuleDetails -Module $module

        $testCoverageRawCsv = Join-Path -Path $TestCoverageDataLocation -ChildPath "TestCoverageAnalysis" | Join-Path -ChildPath "Raw" | Join-Path -ChildPath "Az.$ModuleName.csv"
        (Import-Csv -LiteralPath $testCoverageRawCsv) |
        Select-Object @{ Name = "BuildId"; Expression = { "$BuildId" } }, `
            @{ Name = "OSVersion"; Expression = { "$OSVersion" } }, `
            @{ Name = "PSVersion"; Expression = { "$PSVersion" } }, `
            @{ Name = "Module"; Expression = { "$ModuleName" } }, `
            "CommandName", @{ Name = "TotalCommands"; Expression = { "$($moduleDetails['TotalCommands'])" } }, `
            "ParameterSetName", @{ Name = "TotalParameterSets"; Expression = { "$($moduleDetails['TotalParameterSets'])" } }, `
            "Parameters", @{ Name = "TotalParameters"; Expression = { "$($moduleDetails['TotalParameters'])" } }, `
            "SourceScript", "LineNumber", "StartDateTime", "EndDateTime", "IsSuccess" |
        Export-Csv -LiteralPath $testCoverageRawCsv -Encoding utf8 -NoTypeInformation -Force
    }

    if ($PSVersion -eq "latest") {
        $PSVersion = (Get-Variable -Name PSVersionTable).Value.PSVersion.ToString()
    }
    $DataLocation = (Get-AzConfig -TestCoverageLocation).Value

    if ($DebugMode.IsPresent) {
        $debugDirectory = Join-Path -Path $RepoLocation -ChildPath "artifacts" | Join-Path -ChildPath "Debug"
        $accountsModuleDirectory = Join-Path -Path $debugDirectory -ChildPath "Az.Accounts"
        Write-Host "Start to import Azure PowerShell modules from artifacts/Debug." -ForegroundColor Green
        Write-Host "If you see module import issue, please restart the PowerShell host." -ForegroundColor Magenta

        Write-Host "Importing Az.Accounts." -ForegroundColor Green
        Import-Module (Join-Path -Path $accountsModuleDirectory -ChildPath "Az.Accounts.psd1")
        Get-ChildItem -LiteralPath $debugDirectory -Directory -Exclude "Az.Accounts" | Get-ChildItem -File -Include "*.psd1" | ForEach-Object {
            Write-Host "Importing $_.FullName." -ForegroundColor Green
            Import-Module $_.FullName -Force
        }
        Write-Host "Successfully imported Azure PowerShell modules from artifacts/Debug" -ForegroundColor Green

        $BuildId = "LocalDebug"
        $OSVersion = "LocalDebug"
        $PSVersion = "LocalDebug"
    }

    $srcDir = Join-Path -Path $RepoLocation -ChildPath "src"
    $liveScenarios = Get-ChildItem -LiteralPath $srcDir -Recurse -Directory -Filter "LiveTests" | Get-ChildItem -Filter "TestLiveScenarios.ps1" -File
    $liveScenarios | ForEach-Object {
        $moduleName = [regex]::match($_.FullName, "[\\|\/]src[\\|\/](?<ModuleName>[a-zA-Z]+)[\\|\/]").Groups["ModuleName"].Value
        Import-Module "./tools/TestFx/Assert.ps1" -Force
        Import-Module "./tools/TestFx/Live/LiveTestUtility.psd1" -ArgumentList $moduleName, $BuildId, $OSVersion, $PSVersion, $DataLocation -Force
        . $_
        FillLiveTestCoverageAdditionalInfo -TestCoverageDataLocation $DataLocation -BuildId $BuildId -OSVersion $OSVersion -PSVersion $PSVersion -ModuleName $moduleName
    }
}
