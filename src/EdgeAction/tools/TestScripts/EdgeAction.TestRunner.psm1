# Copyright Microsoft Corporation. Licensed under the Apache License, Version 2.0.
#Requires -Version 7.3

$script:RepoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..' '..' '..' '..')).Path
$script:Artifact = Join-Path $script:RepoRoot 'artifacts' 'Debug' 'Az.EdgeAction' 'EdgeAction.Autorest'
$script:HowTo = Join-Path $script:RepoRoot 'src' 'EdgeAction' 'EdgeAction.Autorest' 'how-to.md'

function Get-EdgeActionTestConfig {
    param([string]$ConfigPath, [string]$SubscriptionId)
    $config = Import-PowerShellDataFile (Join-Path $PSScriptRoot 'TestSettings.psd1')
    if (-not $ConfigPath) {
        $local = Join-Path $PSScriptRoot 'TestSettings.local.psd1'
        if (Test-Path -LiteralPath $local) { $ConfigPath = $local }
    }
    if ($ConfigPath) {
        $overrides = Import-PowerShellDataFile -LiteralPath $ConfigPath
        foreach ($key in $overrides.Keys) {
            if (-not $config.ContainsKey($key)) { throw "Unknown configuration key '$key'." }
            if ($overrides[$key] -isnot [string]) { throw "Configuration '$key' must be a string." }
            $config[$key] = $overrides[$key]
        }
    }
    if ($SubscriptionId) { $config.SubscriptionId = $SubscriptionId }
    foreach ($key in 'ResourceManagerUrl', 'Audience') {
        $uri = $null
        if (-not [uri]::TryCreate($config[$key], [UriKind]::Absolute, [ref]$uri) -or
            $uri.Scheme -ne 'https' -or $uri.UserInfo -or $uri.Query -or $uri.Fragment) {
            throw "$key must be an absolute HTTPS URL without credentials, query, or fragment."
        }
    }
    if ($config.ResourceGroupName -cne 'powershelltests') {
        throw 'Scenario tests hardcode powershelltests. ResourceGroupName overrides are not supported.'
    }
    if (-not $config.EnvironmentName.Trim()) { throw 'EnvironmentName is required.' }
    Assert-EdgeActionEnvironmentConfig $config
    if ($config.ApiVersion -ne '2026-10-01') { throw 'This workflow expects API 2026-10-01.' }
    if ($config.SubscriptionId -and $config.SubscriptionId -notmatch '^[0-9a-fA-F]{8}(-[0-9a-fA-F]{4}){3}-[0-9a-fA-F]{12}$') {
        throw 'SubscriptionId must be a GUID, not a subscription name or placeholder.'
    }
    $config
}

function Assert-EdgeActionEnvironmentConfig {
    param([hashtable]$Config)
    $endpoint = switch ($Config.EnvironmentName) {
        AzureCloud { 'https://management.azure.com' }
        Brazilus { 'https://brazilus.management.azure.com' }
        default { throw 'EnvironmentName must be AzureCloud or Brazilus.' }
    }
    if (-not $Config.ResourceManagerUrl -or -not $Config.Audience -or
        $Config.ResourceManagerUrl.TrimEnd('/') -ne $endpoint -or
        $Config.Audience.TrimEnd('/') -ne 'https://management.core.windows.net') {
        throw "Configured ARM endpoint or audience is not allowed for $($Config.EnvironmentName)."
    }
}

function Assert-EdgeActionMutation {
    param([hashtable]$Config, [string]$Mode, [switch]$AllowResourceChanges)
    if ($Mode -notin @('Playback', 'Record', 'Live')) { throw "Unsupported mode: $Mode." }
    if ($Mode -ne 'Playback' -and (-not $AllowResourceChanges -or -not $Config.SubscriptionId)) {
        throw 'Record/Live require -AllowResourceChanges and an explicit SubscriptionId (argument, TestSettings.local.psd1, or a file selected with -ConfigPath).'
    }
}

function Assert-EdgeActionContext {
    param([hashtable]$Config, $Context)
    if (-not $Context -or $Context.Subscription.Id -ne $Config.SubscriptionId -or
        $Context.Environment.Name -ne $Config.EnvironmentName -or
        $Context.Environment.ResourceManagerUrl.TrimEnd('/') -ne $Config.ResourceManagerUrl.TrimEnd('/') -or
        $Context.Environment.ActiveDirectoryServiceEndpointResourceId.TrimEnd('/') -ne $Config.Audience.TrimEnd('/')) {
        throw 'Azure context does not match the expected subscription, environment, ARM endpoint, and audience.'
    }
}

function Initialize-EdgeActionTestModules {
    param([hashtable]$Config, [string]$Mode)
    $accounts = Join-Path $script:RepoRoot 'artifacts' 'Debug' 'Az.Accounts' 'Az.Accounts.psd1'
    foreach ($path in @($accounts, (Join-Path $script:Artifact 'test-module.ps1'))) {
        if (-not (Test-Path $path)) { throw "Build first using the repository helpers described in '$script:HowTo'; missing artifact: $path." }
    }
    $pesterPath = $Config.PesterPath
    if (-not $pesterPath) {
        $available = Get-Module -ListAvailable Pester | Where-Object Version -EQ '4.10.1' | Select-Object -First 1
        if ($available) { $pesterPath = Join-Path $available.ModuleBase 'Pester.psd1' }
    }
    if (-not $pesterPath) {
        throw "Install Pester 4.10.1 as described in '$script:HowTo', or set PesterPath to its installed manifest. This runner does not install dependencies."
    }
    $pester = Test-ModuleManifest -Path $pesterPath
    if ($pester.Name -ne 'Pester' -or $pester.Version -ne [version]'4.10.1') { throw 'PesterPath must identify Pester 4.10.1.' }
    # The generated harness selects the highest discoverable Accounts version.
    # Isolate discovery and preload exact modules before it runs.
    $pesterRoot = $pester.ModuleBase
    if ((Split-Path $pester.ModuleBase -Leaf) -eq '4.10.1') { $pesterRoot = Split-Path $pesterRoot }
    $env:PSModulePath = @($pesterRoot,
        (Join-Path $script:RepoRoot 'artifacts' 'Debug'), (Join-Path $PSHOME 'Modules')) -join [IO.Path]::PathSeparator
    $nested = Join-Path $script:Artifact 'generated' 'modules'
    foreach ($name in @('Pester', 'Az.Accounts')) {
        if (Test-Path (Join-Path $nested $name)) {
            throw "Relocate the conflicting artifact-local $name module before running tests: $nested."
        }
    }
    if (-not (Get-Module -ListAvailable Pester | Where-Object Version -EQ '4.10.1')) {
        throw 'Pester 4.10.1 is not discoverable from its module directory. Use a standard Pester/4.10.1 installation layout.'
    }
    $selectedAccounts = Get-Module -ListAvailable Az.Accounts | Sort-Object Version -Descending | Select-Object -First 1
    if (-not $selectedAccounts -or $selectedAccounts.ModuleBase -ne (Split-Path $accounts)) {
        throw 'The generated harness would select a different Az.Accounts module than the Debug artifact.'
    }
    if ($Mode -ne 'Playback') {
        $support = Join-Path $HOME '.PSSharedModules' 'Resources' 'Az.Resources.TestSupport.psd1'
        if (-not (Test-Path $support) -or -not (Test-Path ([IO.Path]::ChangeExtension($support, '.psm1')))) {
            throw "Resources test support is missing. Follow the Record/Live dependency setup in '$script:HowTo'. This runner will not provision it."
        }
    }
    Import-Module $accounts -Force -Global
    Import-Module $pesterPath -Force -Global
    Write-Host "Using built Az.Accounts, Pester 4.10.1, and artifact harness: $script:Artifact"
}

function Invoke-EdgeActionHarness {
    param([string]$Mode, [string[]]$TestName)
    $parameters = @{ NotIsolated = $true; $Mode = $true }
    if ($TestName) { $parameters.TestName = $TestName }
    $global:LASTEXITCODE = 0
    & (Join-Path $script:Artifact 'test-module.ps1') @parameters
    if ($LASTEXITCODE -ne 0) { throw "Scenario harness exited with code $LASTEXITCODE." }
}

function Invoke-EdgeActionScenario {
    param([hashtable]$Config, [string]$Mode = 'Playback',
        [string[]]$TestName, [switch]$AllowResourceChanges, [switch]$Login)
    $ErrorActionPreference = 'Stop'
    $PSNativeCommandUseErrorActionPreference = $true
    Assert-EdgeActionMutation $Config $Mode -AllowResourceChanges:$AllowResourceChanges
    Assert-EdgeActionEnvironmentConfig $Config
    if ($Mode -eq 'Playback' -and $Login) { throw '-Login is only supported for explicit Record/Live runs.' }
    Write-Host 'Starting test dependency validation and loading.'
    Initialize-EdgeActionTestModules $Config $Mode
    Write-Host 'Completed test dependency validation and loading.'
    if ($Mode -ne 'Playback') {
        Write-Host 'Starting live context and resource-group validation.'
        Disable-AzContextAutosave -Scope Process | Out-Null
        $environment = Get-AzEnvironment -Name $Config.EnvironmentName
        Assert-EdgeActionContext $Config ([pscustomobject]@{
            Subscription = @{ Id = $Config.SubscriptionId }; Environment = $environment
        })
        if ($Login) {
            Write-Host 'Starting process-scoped login.'
            Connect-AzAccount -Environment $Config.EnvironmentName -Subscription $Config.SubscriptionId -Scope Process | Out-Null
            Write-Host 'Completed process-scoped login.'
        }
        Assert-EdgeActionContext $Config (Get-AzContext)
        $group = Invoke-AzRestMethod -Method GET -Path "/subscriptions/$($Config.SubscriptionId)/resourcegroups/$($Config.ResourceGroupName)?api-version=2021-04-01"
        if ($group.StatusCode -ne 200) { throw 'The powershelltests resource group must already exist and be readable.' }
        Write-Host 'Completed live context and resource-group validation.'
        Write-Warning 'Scenarios create/delete hardcoded resources in powershelltests. Review collisions, skipped tests, and cleanup. Sanitize recordings before copying to source.'
    }
    Write-Host "Mode: $Mode. Expected API: $($Config.ApiVersion). Configuration does not rewrite test names or recordings."
    Write-Host "Starting $Mode scenario harness."
    Invoke-EdgeActionHarness $Mode $TestName
}

function Assert-EdgeActionResults {
    param([string]$Path, [datetime]$Started, [int]$ExitCode)
    if (-not (Test-Path $Path) -or (Get-Item $Path).LastWriteTimeUtc -lt $Started) {
        throw "Missing or stale test results: $Path (child exit $ExitCode)."
    }
    [xml]$xml = Get-Content $Path -Raw
    $root = $xml.SelectSingleNode('/test-results')
    $cases = @($xml.SelectNodes('//test-case'))
    $executed = @($cases | Where-Object { $_.executed -eq 'True' })
    $failed = @($executed | Where-Object { $_.success -ne 'True' })
    if (-not $root -or $executed.Count -eq 0) { throw 'No executed scenario tests in the fresh NUnit results.' }
    Write-Host "Scenario results: $($executed.Count) executed, $($failed.Count) failed, $($cases.Count - $executed.Count) not executed. XML: $Path"
    if ($ExitCode -ne 0 -or $failed.Count -gt 0 -or [int]$root.failures -gt 0 -or [int]$root.errors -gt 0) {
        throw "Scenario tests failed (child exit $ExitCode). Inspect $Path."
    }
}

function Invoke-EdgeActionTestChild {
    param([hashtable]$Options)
    $data = @{ Module = $PSCommandPath; Options = $Options }
    $serialized = [Convert]::ToBase64String([Text.Encoding]::UTF8.GetBytes([Management.Automation.PSSerializer]::Serialize($data)))
    $command = @'
$ErrorActionPreference = 'Stop'
$PSNativeCommandUseErrorActionPreference = $true
$data = [Management.Automation.PSSerializer]::Deserialize([Text.Encoding]::UTF8.GetString([Convert]::FromBase64String('__DATA__')))
Import-Module $data.Module -Force
$options = $data.Options
Invoke-EdgeActionScenario @options
'@
    $encoded = [Convert]::ToBase64String([Text.Encoding]::Unicode.GetBytes($command.Replace('__DATA__', $serialized)))
    $PSNativeCommandUseErrorActionPreference = $false
    & (Join-Path $PSHOME $(if ($IsWindows) { 'pwsh.exe' } else { 'pwsh' })) -NoLogo -NoProfile -OutputFormat Text -EncodedCommand $encoded | Out-Host
    $LASTEXITCODE
}

function Invoke-EdgeActionTests {
    param([hashtable]$Options)
    $ErrorActionPreference = 'Stop'
    Write-Host 'Starting test configuration validation.'
    $config = Get-EdgeActionTestConfig $Options.ConfigPath $Options.SubscriptionId
    $mode = if ($Options.Mode) { $Options.Mode } else { 'Playback' }
    Assert-EdgeActionMutation $config $mode -AllowResourceChanges:([bool]$Options.AllowResourceChanges)
    Write-Host 'Completed test configuration validation.'
    $childOptions = @{
        Config = $config; Mode = $mode; TestName = $Options.TestName
        AllowResourceChanges = [bool]$Options.AllowResourceChanges; Login = [bool]$Options.Login
    }
    $path = Join-Path $script:Artifact 'test' 'Az.EdgeAction-TestResults.xml'
    if (Test-Path $path) { Remove-Item -LiteralPath $path }
    $started = [datetime]::UtcNow
    $code = Invoke-EdgeActionTestChild $childOptions
    Write-Host 'Starting fresh test-result validation.'
    Assert-EdgeActionResults $path $started $code
    Write-Host 'Completed fresh test-result validation.'
    Write-Host "Completed $mode scenario harness; tests passed."
}

Export-ModuleMember -Function Invoke-EdgeActionTests, Invoke-EdgeActionScenario
