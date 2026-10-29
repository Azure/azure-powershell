# Copyright Microsoft Corporation. Licensed under the Apache License, Version 2.0.
#Requires -Version 7.0
# Offline fixtures only: no Azure module import or network transport.
$script:utilsPath = (Resolve-Path (Join-Path $PSScriptRoot '..' '..' '..' 'EdgeAction.Autorest' 'test' 'utils.ps1')).Path
. $script:utilsPath

Describe 'Fixture recording context isolation' {
    BeforeEach {
        $script:savedDefaults = $PSDefaultParameterValues.Clone()
        $script:fixtureRecorder = [pscustomobject]@{
            Contexts = [System.Collections.Generic.Stack[string]]::new()
            Scenario = 'active scenario'
        }
        $script:fixtureRecorder | Add-Member ScriptMethod PushContext { param($Name) $this.Contexts.Push($Name) }
        $script:fixtureRecorder | Add-Member ScriptMethod PopContext { $null = $this.Contexts.Pop() }
        $script:fixtureRecorder.PushContext('outer context')
        $PSDefaultParameterValues['*:HttpPipelinePrepend'] = $script:fixtureRecorder
    }
    AfterEach { $PSDefaultParameterValues = $script:savedDefaults }

    It 'preserves the active scenario and outer context around both hooks' {
        Initialize-EdgeActionTestScenario {
            $script:fixtureRecorder.Contexts.Peek() | Should -Be 'EdgeActionFixtureSetup'
            $script:fixtureRecorder.Scenario | Should -Be 'active scenario'
        }
        $script:fixtureRecorder.Contexts.Peek() | Should -Be 'outer context'
        Mock Remove-EdgeActionTestResource {
            $script:fixtureRecorder.Contexts.Peek() | Should -Be 'EdgeActionFixtureCleanup'
            $script:fixtureRecorder.Scenario | Should -Be 'active scenario'
        }
        Complete-EdgeActionTestScenario rgps-powershellsdk-edgeaction-tests-0123456789ab eagetdec01
        $script:fixtureRecorder.Contexts.Count | Should -Be 1
        $script:fixtureRecorder.Contexts.Peek() | Should -Be 'outer context'
    }

    It 'balances contexts and preserves setup and cleanup errors' {
        { Initialize-EdgeActionTestScenario { throw 'setup fixture failure' } } | Should -Throw 'setup fixture failure'
        $script:fixtureRecorder.Contexts.Count | Should -Be 1
        Mock Remove-EdgeActionTestResource { throw 'cleanup fixture failure' }
        $message = try { Complete-EdgeActionTestScenario rgps-powershellsdk-edgeaction-tests-0123456789ab eagetdec01 } catch { $_.Exception.Message }
        $message | Should -Match 'setup fixture failure'
        $message | Should -Match 'cleanup fixture failure'
        $script:fixtureRecorder.Contexts.Count | Should -Be 1
        $script:fixtureRecorder.Contexts.Peek() | Should -Be 'outer context'
    }
}

Describe 'Pester 4 recording hook collisions' {
    It 'replays hooks after a trailing skipped test only with context isolation: <Separated>' -TestCases @(
        @{ Separated = $false }, @{ Separated = $true }
    ) {
        param($Separated)
        $fixture = Join-Path $TestDrive "recording-$Separated.Tests.ps1"
        $driver = Join-Path $TestDrive "recording-$Separated-driver.ps1"
        $recording = Join-Path $TestDrive "recording-$Separated.json"
        @'
param($Separated)
Describe 'LifecycleFixture' {
    BeforeAll {
        Mock Invoke-EdgeActionTestCommand { $global:edgeActionOfflineRecorder.Request($Command) }
        $setup = { New-EdgeActionTestResource rgps-powershellsdk-edgeaction-tests-0123456789ab eaget0123456789ab }
        if ($Separated) { Initialize-EdgeActionTestScenario $setup } else { & $setup }
    }
    AfterAll {
        if ($Separated) { Complete-EdgeActionTestScenario rgps-powershellsdk-edgeaction-tests-0123456789ab eaget0123456789ab }
        else { Remove-EdgeActionTestResource rgps-powershellsdk-edgeaction-tests-0123456789ab eaget0123456789ab }
    }
    It 'checks the created resource' {
        $global:edgeActionOfflineRecorder.Request('Get-AzEdgeAction').NotFound | Should -Be $false
    }
    It 'not implemented' -Skip { throw 'must not execute' }
}
'@ | Set-Content $fixture
        @'
param($Pester, $Fixture, $Utils, $Recording, $Mode, [int]$Separated, $Results)
Import-Module $Pester
. $Utils
$TestMode = 'playback'
$env = @{ ResourceGroupName = 'rgps-powershellsdk-edgeaction-tests-0123456789ab'; EdgeActionFixtures = @{ 'Get-AzEdgeAction' = @{ Name = 'eaget0123456789ab'; State = 'NotCreated' } } }
# Model the generated recorder's key and global-counter reset semantics.
class OfflineFixtureRecorder {
    [System.Collections.Generic.Stack[string]] $Contexts = [System.Collections.Generic.Stack[string]]::new()
    [System.Collections.Generic.Stack[string]] $Scenarios = [System.Collections.Generic.Stack[string]]::new()
    [hashtable] $Messages = @{}
    [int] $Counter = 0
    [bool] $Parent = $false
    [string] $Mode
    [void] PushContext([string] $Name) { $this.Contexts.Push($Name) }
    [void] PopContext() { $null = $this.Contexts.Pop() }
    [void] PushScenario([string] $Name) { $this.Counter = 0; $this.Scenarios.Push($Name) }
    [void] PopScenario() { $null = $this.Scenarios.Pop() }
    [hashtable] Request([string] $Command) {
        $context = if ($this.Contexts.Count) { $this.Contexts.Peek() } else { '[NoContext]' }
        $scenario = if ($this.Scenarios.Count) { $this.Scenarios.Peek() } else { '[NoScenario]' }
        $method = switch -Wildcard ($Command) { 'New-*' { 'PUT' }; 'Remove-*' { 'DELETE' }; default { 'GET' } }
        $uri = 'https://example.invalid/parent'
        if ($Command -eq 'Get-AzEdgeActionExecutionFilter') { $uri += '/executionFilters' }
        if ($Command -eq 'Get-AzEdgeActionVersion') { $uri += '/versions' }
        $this.Counter++
        $key = "LifecycleFixture+$context+$scenario+`$$method+$uri+$($this.Counter)"
        if ($this.Mode -eq 'Playback') {
            if (-not $this.Messages.ContainsKey($key)) { throw 'Missing Request in offline recording' }
            return $this.Messages[$key]
        }
        $reply = @{ NotFound = $false; Value = @() }
        switch ($Command) {
            'Get-AzEdgeAction' { $reply.NotFound = -not $this.Parent }
            'New-AzEdgeAction' { $this.Parent = $true }
            'Remove-AzEdgeAction' { $this.Parent = $false }
            'Get-AzEdgeActionExecutionFilter' {}
            'Get-AzEdgeActionVersion' {}
            default { throw "Unexpected offline command $Command" }
        }
        # Like SaveMessage, assigning an existing key replaces the earlier response.
        $this.Messages[$key] = $reply
        return $reply
    }
}
$global:edgeActionOfflineRecorder = [OfflineFixtureRecorder]::new()
$global:edgeActionOfflineRecorder.Mode = $Mode
if ($Mode -eq 'Playback') { $global:edgeActionOfflineRecorder.Messages = Get-Content $Recording -Raw | ConvertFrom-Json -AsHashtable }
$PSDefaultParameterValues['*:HttpPipelinePrepend'] = $global:edgeActionOfflineRecorder
function It {
    param([string]$Name, [scriptblock]$Test, [switch]$Skip)
    $global:edgeActionOfflineRecorder.PushScenario($Name)
    try { Pester\It -Name $Name -Test $Test -Skip:$Skip }
    finally { $global:edgeActionOfflineRecorder.PopScenario() }
}
$result = Invoke-Pester -Script @{ Path=$Fixture; Parameters=@{ Separated=[bool]$Separated } } -PassThru -Show None -OutputFile $Results
if ($Mode -eq 'Record') { $global:edgeActionOfflineRecorder.Messages | ConvertTo-Json -Depth 10 | Set-Content $Recording }
if ($global:edgeActionOfflineRecorder.Contexts.Count -or $global:edgeActionOfflineRecorder.Scenarios.Count) { throw 'Unbalanced recorder scope' }
exit $result.FailedCount
'@ | Set-Content $driver
        foreach ($mode in 'Record', 'Playback') {
            $xml = Join-Path $TestDrive "$Separated-$mode.xml"
            $childOutput = & (Join-Path $PSHOME 'pwsh') -NoLogo -NoProfile -File $driver (Get-Module Pester).Path `
                $fixture $script:utilsPath $recording $mode ([int]$Separated) $xml 2>&1
            $code = $LASTEXITCODE
            [xml]$results = Get-Content $xml -Raw
            if ($mode -eq 'Playback' -and -not $Separated) {
                $code | Should -BeGreaterThan 0
                $results.SelectNodes('//test-case/failure/message').InnerText | Should -Match 'Missing Request|already exists'
            } else {
                if ($code) {
                    throw "$mode fixture failed: $childOutput $($results.SelectNodes('//test-case/failure/message').InnerText)"
                }
                $code | Should -Be 0
                $results.'test-results'.failures | Should -Be 0
                $results.'test-results'.ignored | Should -Be 1
            }
        }
        $messages = Get-Content $recording -Raw | ConvertFrom-Json -AsHashtable
        if ($Separated) {
            $messages['LifecycleFixture+EdgeActionFixtureSetup+[NoScenario]+$GET+https://example.invalid/parent+1'].NotFound |
                Should -Be $true
            $messages['LifecycleFixture+EdgeActionFixtureCleanup+[NoScenario]+$GET+https://example.invalid/parent+1'].NotFound |
                Should -Be $false
        } else {
            $messages['LifecycleFixture+[NoContext]+[NoScenario]+$GET+https://example.invalid/parent+1'].NotFound |
                Should -Be $false
        }
    }
}
