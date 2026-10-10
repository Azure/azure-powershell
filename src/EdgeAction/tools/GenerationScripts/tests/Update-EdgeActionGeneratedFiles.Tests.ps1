# Copyright Microsoft Corporation. Licensed under the Apache License, Version 2.0.
#Requires -Version 7.3
# Installed generation prerequisites; synthetic modules, no builds or Azure requests.
Describe 'Generation runbook with local fixtures' {
    BeforeEach {
        $root = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $source = Join-Path $root 'src' 'EdgeAction' 'EdgeAction.Autorest'
        $parentHelp = Join-Path $root 'src' 'EdgeAction' 'EdgeAction' 'help'
        $artifact = Join-Path $root 'artifacts' 'Debug' 'Az.EdgeAction'
        $accounts = Join-Path $root 'artifacts' 'Debug' 'Az.Accounts'
        $scripts = Join-Path $root 'src' 'EdgeAction' 'tools' 'GenerationScripts'
        $buildScripts = Join-Path $root 'tools' 'BuildScripts'
        $helpScripts = Join-Path $root 'tools' 'HelpGeneration'
        $null = New-Item $source, $parentHelp, $artifact, $accounts, $scripts, $buildScripts, $helpScripts -ItemType Directory -Force
        $repo = (Resolve-Path (Join-Path $PSScriptRoot '..' '..' '..' '..' '..')).Path
        Copy-Item (Join-Path $PSScriptRoot '..' 'Update-EdgeActionGeneratedFiles.ps1') $scripts
        Copy-Item (Join-Path $repo 'tools' 'BuildScripts' 'HelpMarkDown.psm1') $buildScripts
        Copy-Item (Join-Path $repo 'tools' 'HelpGeneration' 'HelpGeneration.psm1') $helpScripts
        "@{ ModuleVersion = '1.0.0'; GUID = '00000000-0000-0000-0000-000000000001' }" |
            Set-Content (Join-Path $accounts 'Az.Accounts.psd1')
        "@{ RootModule = 'Az.EdgeAction.psm1'; ModuleVersion = '1.0.0'; GUID = '00000000-0000-0000-0000-000000000002'; FunctionsToExport = @('Get-EdgeActionFixture') }" |
            Set-Content (Join-Path $artifact 'Az.EdgeAction.psd1')
        @'
function Get-EdgeActionFixture {
    <#
    .SYNOPSIS
    Reads the fixture.
    .DESCRIPTION
    Fixture description.
    #>
    [CmdletBinding(DefaultParameterSetName='Read')]
    param(
        [Parameter(Mandatory)][string]$Name,
        [Parameter(Mandatory, ParameterSetName='Save')][string]$OutputPath
    )
    throw 'This fixture command must never execute.'
}
Export-ModuleMember Get-EdgeActionFixture
'@ | Set-Content (Join-Path $artifact 'Az.EdgeAction.psm1')
        @'
---
Module Name: Az.EdgeAction
Module Guid: 00000000-0000-0000-0000-000000000002
Download Help Link: https://learn.microsoft.com/powershell/module/az.edgeaction
Help Version: 1.0.0.0
Locale: en-US
---
# Az.EdgeAction Module
## Description
Retain this manual description.
## Az.EdgeAction Cmdlets
'@ | Set-Content (Join-Path $parentHelp 'Az.EdgeAction.md')
        $originalPage = Get-Content (Join-Path $parentHelp 'Az.EdgeAction.md') -Raw
        [IO.File]::WriteAllText((Join-Path $source 'how-to.md'), "maintained`r`nguide`r`n")
        $guideHash = (Get-FileHash (Join-Path $source 'how-to.md')).Hash
        @'
## Example, not configuration
```yaml
commit: ignored-example
input-file: ignored-example.json
```
### AutoRest Configuration
``` yaml
# commit: ignored-comment
commit: fixture-original-commit
input-file:
# An input comment is not another path.
  - $(repo)/fixture.json
  - $(repo)/second.json
title: EdgeAction
```
'@ | Set-Content (Join-Path $source 'README.md')
        '{"generate_Id":"unchanged-fixture-marker"}' | Set-Content (Join-Path $source 'generate-info.json')
        $prepare = Join-Path $buildScripts 'PrepareAutorestModule.ps1'
        $build = Join-Path $buildScripts 'BuildModules.ps1'
        @'
param([string]$RepoRoot, [string]$ModuleRootName, [switch]$ForceRegenerate)
if($ModuleRootName -ne 'EdgeAction' -or -not $ForceRegenerate){throw 'Wrong prepare arguments'}
Add-Content (Join-Path $RepoRoot 'sequence.txt') 'prepare'
@{ Registry=$env:autorest_registry; Sources=$env:RestoreSources; Dotnet=(Get-Command dotnet).Source } |
    ConvertTo-Json | Set-Content (Join-Path $RepoRoot 'child-environment.json')
$source=Join-Path $RepoRoot 'src' 'EdgeAction' 'EdgeAction.Autorest'
Set-Content (Join-Path $source 'how-to.md') 'upstream scaffold'
Import-Module (Join-Path $RepoRoot 'artifacts' 'Debug' 'Az.EdgeAction' 'Az.EdgeAction.psd1') -Global
New-MarkdownHelp -Module Az.EdgeAction -OutputFolder (Join-Path $source 'docs') -Force | Out-Null
Set-Location $HOME
'@ | Set-Content $prepare
        @'
param([string]$RepoRoot, [string]$Configuration, [string]$TargetModule, [switch]$ForceRegenerate)
if($Configuration -ne 'Debug' -or $TargetModule -ne 'EdgeAction' -or $ForceRegenerate){throw 'Wrong build arguments'}
if((Get-Location).Path -ne $RepoRoot){throw 'Wrong build cwd'}
Add-Content (Join-Path $RepoRoot 'sequence.txt') 'build'
Set-Location $HOME
'@ | Set-Content $build
        $runner = Join-Path $scripts 'Update-EdgeActionGeneratedFiles.ps1'
    }
    It 'runs the sequence with stale caller state and generates complete help without changing parent identity' {
        $environment = @{}
        foreach ($name in @('REPO_ROOT', 'PATH', 'autorest_registry', 'RestoreSources')) {
            $environment[$name] = [Environment]::GetEnvironmentVariable($name)
        }
        $shim = Join-Path $root 'npm-shims'
        $null = New-Item $shim -ItemType Directory
        "throw 'Do not execute npm dotnet shim'" | Set-Content (Join-Path $shim 'dotnet.ps1')
        Push-Location $source
        try {
            $repoRoot = 'wrong root'
            $env:REPO_ROOT = 'wrong environment'
            $env:PATH = $shim + [IO.Path]::PathSeparator + $env:PATH
            $callerPath = $env:PATH
            $env:autorest_registry = 'https://caller.invalid/npm/'
            $env:RestoreSources = 'caller sources'
            $log = Join-Path $root 'steps.log'
            & $runner *> $log
            (Get-Location).Path | Should -Be $source
            $repoRoot | Should -Be 'wrong root'
            $env:PATH | Should -Be $callerPath
            $env:autorest_registry | Should -Be 'https://caller.invalid/npm/'
            $env:RestoreSources | Should -Be 'caller sources'
        } finally {
            Pop-Location
            foreach ($name in $environment.Keys) { [Environment]::SetEnvironmentVariable($name, $environment[$name]) }
        }
        $markers = @(Get-Content $log | Where-Object { $_ -match '^(Starting|Completed) ' })
        $expected = foreach ($step in @('build output lock preflight', 'prerequisite version checks', 'process-local build feed setup', 'AutoRest preparation',
            'targeted EdgeAction build', 'parent Markdown help refresh', 'XML help generation and artifact publication')) {
            "Starting $step."
            "Completed $step."
        }
        ($markers -join '|') | Should -Be ($expected -join '|')
        $child = Get-Content (Join-Path $root 'child-environment.json') -Raw | ConvertFrom-Json
        $child.Registry | Should -Be 'https://packagefeedproxy.microsoft.io/npm/'
        $child.Sources | Should -Be (@(
            (Join-Path $root 'tools' 'LocalFeed')
            'https://pkgs.dev.azure.com/azclitools/public/_packaging/azure-powershell/nuget/v3/index.json'
            'https://packagefeedproxy.microsoft.io/nuget/v3/index.json'
        ) -join ';')
        $child.Dotnet | Should -Not -Match 'npm-shims'
        (Get-Content (Join-Path $root 'sequence.txt')) -join ',' | Should -Be 'prepare,build'
        (Get-FileHash (Join-Path $source 'how-to.md')).Hash | Should -Be $guideHash
        $prefix = '(?s)\A.*?(?=## Az\.EdgeAction Cmdlets)'
        [regex]::Match((Get-Content (Join-Path $parentHelp 'Az.EdgeAction.md') -Raw), $prefix).Value |
            Should -Be ([regex]::Match($originalPage, $prefix).Value)
        [xml]$xml = Get-Content (Join-Path $artifact 'Az.EdgeAction-help.xml') -Raw
        $nodes = @($xml.SelectNodes("//*[local-name()='command']"))
        $nodes.Count | Should -Be 1
        $sets = @($nodes[0].SelectNodes("*[local-name()='syntax']/*[local-name()='syntaxItem']"))
        $sets.Count | Should -Be 2
        $setMembers = @($sets | ForEach-Object {
            (@($_.SelectNodes("*[local-name()='parameter']/*[local-name()='name']") | ForEach-Object InnerText | Sort-Object) -join ',')
        } | Sort-Object)
        ($setMembers -join ';') | Should -Be 'Name;Name,OutputPath'
        foreach ($file in Get-ChildItem $parentHelp -Filter '*.md') {
            (Get-FileHash (Join-Path $artifact 'help' $file.Name)).Hash | Should -Be (Get-FileHash $file.FullName).Hash
        }
        # A second invocation must not require clean Git state or a prior-output registry.
        $readme = Join-Path $source 'README.md'
        (Get-Content $readme -Raw).Replace('fixture-original-commit', 'fixture-updated-commit') | Set-Content $readme
        & $runner *> $log
        $messages = Get-Content $log -Raw
        $messages | Should -Match 'commit: fixture-updated-commit'
        $messages | Should -Not -Match 'ignored-example|ignored-comment|fixture-original-commit'
        $messages | Should -Match ([regex]::Escape('  - $(repo)/fixture.json'))
        $messages | Should -Match ([regex]::Escape('  - $(repo)/second.json'))
        $messages | Should -Match ([regex]::Escape($readme))
        $messages.IndexOf('Configured AutoRest input') | Should -BeLessThan $messages.IndexOf('Starting AutoRest preparation.')
        $messages | Should -Match 'Forced regeneration is enabled\. generate-info IDs are bookkeeping, not the specification commit SHA\.'
        (Get-Content (Join-Path $source 'generate-info.json') -Raw | ConvertFrom-Json).generate_Id | Should -Be 'unchanged-fixture-marker'
        (Get-Content (Join-Path $root 'sequence.txt')) -join ',' | Should -Be 'prepare,build,prepare,build'
    }
    It 'rejects ambiguous configuration excerpts before preparation' {
        Add-Content (Join-Path $source 'README.md') "`n``````yaml`ncommit: second-block`n``````"
        { & $runner *> (Join-Path $root 'ambiguous.log') } | Should -Throw 'EdgeAction generation failed'
        (Get-Content (Join-Path $root 'ambiguous.log') -Raw) | Should -Match 'cannot report configured input unambiguously'
        Test-Path (Join-Path $root 'sequence.txt') | Should -Be $false
    }
    It 'stops the real child before prerequisites or preparation when the Accounts output is held' -Skip:(-not $IsWindows) {
        $dll = Join-Path $accounts 'Microsoft.Azure.PowerShell.AssemblyLoading.dll'
        [IO.File]::WriteAllBytes($dll, [byte[]](1, 2, 3, 4))
        $hash = (Get-FileHash $dll).Hash
        $held = [IO.File]::Open($dll, [IO.FileMode]::Open, [IO.FileAccess]::Read, [IO.FileShare]::Read)
        $log = Join-Path $root 'locked.log'
        try {
            { & $runner *> $log } | Should -Throw 'EdgeAction generation failed'
            $messages = Get-Content $log -Raw
            $messages | Should -Match 'Build output preflight failed'
            $messages | Should -Match ([regex]::Escape($dll))
            $messages | Should -Not -Match 'Completed build output lock preflight|Starting prerequisite|Starting AutoRest'
            Test-Path (Join-Path $root 'sequence.txt') | Should -Be $false
            (Get-FileHash (Join-Path $source 'how-to.md')).Hash | Should -Be $guideHash
            (Get-Content (Join-Path $parentHelp 'Az.EdgeAction.md') -Raw) | Should -Be $originalPage
        } finally {
            $held.Dispose()
        }
        (Get-FileHash $dll).Hash | Should -Be $hash
    }
    It 'propagates <Failure> from prepare and restores the maintained guide' -TestCases @(
        @{ Failure = 'PowerShell error'; Command = "Write-Error 'fixture failure'" }
        @{ Failure = 'native exit'; Command = '& (Join-Path $PSHOME $(if ($IsWindows) { "pwsh.exe" } else { "pwsh" })) -NoProfile -Command "exit 7"' }
    ) {
        param($Failure, $Command)
        Add-Content $prepare $Command
        $log = Join-Path $root 'failure.log'
        { & $runner *> $log } | Should -Throw 'EdgeAction generation failed'
        $messages = Get-Content $log -Raw
        $messages | Should -Match 'Starting AutoRest preparation\.'
        $messages | Should -Not -Match 'Completed AutoRest preparation\.|Starting targeted EdgeAction build\.'
        (Get-FileHash (Join-Path $source 'how-to.md')).Hash | Should -Be $guideHash
        Get-Content (Join-Path $root 'sequence.txt') | Should -Be 'prepare'
        Test-Path (Join-Path $artifact 'Az.EdgeAction-help.xml') | Should -Be $false
    }
    It 'does not publish help after a build failure' {
        Add-Content $build "throw 'fixture build failure'"
        $log = Join-Path $root 'failure.log'
        { & $runner *> $log } | Should -Throw 'EdgeAction generation failed'
        $messages = Get-Content $log -Raw
        $messages | Should -Match 'Completed AutoRest preparation\.'
        $messages | Should -Match 'Starting targeted EdgeAction build\.'
        $messages | Should -Not -Match 'Completed targeted EdgeAction build\.|Starting parent Markdown help refresh\.'
        (Get-Content (Join-Path $root 'sequence.txt')) -join ',' | Should -Be 'prepare,build'
        Test-Path (Join-Path $artifact 'Az.EdgeAction-help.xml') | Should -Be $false
    }
    It 'rejects an incompatible active CLI in the real child before preparing outputs' {
        $cliDirectory = Join-Path $root 'incompatible-cli'
        $packageDirectory = Join-Path $cliDirectory 'node_modules' 'autorest'
        $null = New-Item $packageDirectory -ItemType Directory -Force
        "throw 'Version inspection must not launch AutoRest'" | Set-Content (Join-Path $cliDirectory 'autorest.ps1')
        '{"name":"autorest","version":"3.7.2"}' | Set-Content (Join-Path $packageDirectory 'package.json')
        $path = $env:PATH
        try {
            $env:PATH = $cliDirectory + [IO.Path]::PathSeparator + $env:PATH
            { & $runner } | Should -Throw 'EdgeAction generation failed'
        } finally { $env:PATH = $path }
        Test-Path (Join-Path $root 'sequence.txt') | Should -Be $false
        (Get-FileHash (Join-Path $source 'how-to.md')).Hash | Should -Be $guideHash
        (Get-Content (Join-Path $parentHelp 'Az.EdgeAction.md') -Raw) | Should -Be $originalPage
    }
}

Describe 'Generation output lock probe' {
    BeforeAll {
        $runner = Join-Path $PSScriptRoot '..' 'Update-EdgeActionGeneratedFiles.ps1'
        $tokens = $null
        $errors = $null
        $ast = [Management.Automation.Language.Parser]::ParseFile($runner, [ref]$tokens, [ref]$errors)
        foreach ($function in $ast.FindAll({ param($node)
            $node -is [Management.Automation.Language.FunctionDefinitionAst] -and
            $node.Name -in @('Get-EdgeActionBuildLockGuidance', 'Assert-EdgeActionBuildOutputAvailable')
        }, $false)) {
            . ([scriptblock]::Create($function.Extent.Text))
        }
    }
    BeforeEach {
        Mock Get-Process { @() }
        Mock Stop-Process { throw 'Process termination must never execute.' }
    }
    It 'accepts absent artifacts without creating files or directories' {
        $missing = Join-Path $TestDrive 'not-built' 'output.dll'
        { Assert-EdgeActionBuildOutputAvailable $missing } | Should -Not -Throw
        Test-Path (Split-Path $missing) | Should -Be $false
        Assert-MockCalled Get-Process -Scope It -Times 0 -Exactly
    }
    It 'leaves an unlocked file unchanged and releases the probe handle' {
        $file = Join-Path $TestDrive 'unlocked.dll'
        [IO.File]::WriteAllBytes($file, [byte[]](1, 2, 3, 4))
        $hash = (Get-FileHash $file).Hash
        $modified = (Get-Item $file).LastWriteTimeUtc
        Assert-EdgeActionBuildOutputAvailable $file
        (Get-FileHash $file).Hash | Should -Be $hash
        (Get-Item $file).LastWriteTimeUtc | Should -Be $modified
        $exclusive = [IO.File]::Open($file, [IO.FileMode]::Open, [IO.FileAccess]::ReadWrite, [IO.FileShare]::None)
        $exclusive.Dispose()
        Assert-MockCalled Get-Process -Scope It -Times 0 -Exactly
    }
    It 'fails on a held Windows file and succeeds once the owner releases it' -Skip:(-not $IsWindows) {
        $file = Join-Path $TestDrive 'held.dll'
        [IO.File]::WriteAllBytes($file, [byte[]](1, 2, 3, 4))
        $held = [IO.File]::Open($file, [IO.FileMode]::Open, [IO.FileAccess]::Read, [IO.FileShare]::Read)
        try {
            { Assert-EdgeActionBuildOutputAvailable $file } | Should -Throw 'locked or inaccessible'
            $held.CanRead | Should -Be $true
        } finally {
            $held.Dispose()
        }
        { Assert-EdgeActionBuildOutputAvailable $file } | Should -Not -Throw
    }
    It 'does not treat an inaccessible output as an absent artifact' -Skip:(-not $IsWindows) {
        $file = Join-Path $TestDrive 'readonly.dll'
        [IO.File]::WriteAllBytes($file, [byte[]](1, 2, 3, 4))
        [IO.File]::SetAttributes($file, [IO.FileAttributes]::ReadOnly)
        try {
            { Assert-EdgeActionBuildOutputAvailable $file } | Should -Throw 'Build output preflight failed'
        } finally {
            [IO.File]::SetAttributes($file, [IO.FileAttributes]::Normal)
        }
    }
    It 'reports only exact normalized DLL matches and supports multiple PowerShell holders' {
        $target = Join-Path $TestDrive 'Accounts' 'output.dll'
        $equivalent = Join-Path $TestDrive 'Accounts' '..' 'Accounts' 'output.dll'
        Mock Get-Process {
            @(
                [pscustomobject]@{ Id = 101; ProcessName = 'pwsh'; Modules = @([pscustomobject]@{ FileName = $equivalent }) }
                [pscustomobject]@{ Id = 102; ProcessName = 'powershell'; Modules = @([pscustomobject]@{ FileName = $target.ToUpperInvariant() }) }
                [pscustomobject]@{ Id = 103; ProcessName = 'pwsh'; Modules = @([pscustomobject]@{ FileName = (Join-Path $TestDrive 'OtherCheckout' 'output.dll') }) }
            )
        }
        $message = Get-EdgeActionBuildLockGuidance $target
        $message | Should -Match 'pwsh \(PID 101\)'
        $message | Should -Match 'powershell \(PID 102\)'
        $message | Should -Not -Match 'PID 103|Stop-Process -Id 103'
        $message | Should -Match 'Stop-Process -Id 101 -Confirm'
        $message | Should -Match 'Stop-Process -Id 102 -Confirm'
        $message | Should -Match '\$PID'
        $message | Should -Match 'interrupts all work'
        $message | Should -Match ([regex]::Escape('& ..\tools\GenerationScripts\Update-EdgeActionGeneratedFiles.ps1'))
        Assert-MockCalled Get-Process -Scope It -Times 1 -Exactly -ParameterFilter {
            $Name -contains 'pwsh*' -and $Name -contains 'powershell*'
        }
        Assert-MockCalled Stop-Process -Scope It -Times 0 -Exactly
    }
    It 'reports incomplete inspection without inventing an owner when module access fails' {
        $target = Join-Path $TestDrive 'output.dll'
        Mock Get-Process {
            $denied = [pscustomobject]@{ Id = 104; ProcessName = 'pwsh' }
            $denied | Add-Member -MemberType ScriptProperty -Name Modules -Value { throw 'fixture access denied' }
            $denied
        }
        $message = Get-EdgeActionBuildLockGuidance $target
        $message | Should -Match 'PID 104.*incomplete'
        $message | Should -Match 'No PowerShell holder could be verified'
        $message | Should -Match ([regex]::Escape($target))
        $message | Should -Not -Match 'Stop-Process'
    }
    It 'reports process enumeration failure and a fallback rather than claiming no lock' {
        Mock Get-Process { throw 'fixture enumeration failed' }
        $message = Get-EdgeActionBuildLockGuidance (Join-Path $TestDrive 'output.dll')
        $message | Should -Match 'enumeration failed; owner inspection is incomplete'
        $message | Should -Match 'Process Explorer'
        $message | Should -Not -Match 'Stop-Process'
    }
    It 'includes verified holder guidance in a real lock failure without terminating it' -Skip:(-not $IsWindows) {
        $file = Join-Path $TestDrive 'diagnostic.dll'
        [IO.File]::WriteAllBytes($file, [byte[]](1, 2, 3, 4))
        Mock Get-Process {
            [pscustomobject]@{ Id = 105; ProcessName = 'pwsh'; Modules = @([pscustomobject]@{ FileName = $file }) }
        }
        $held = [IO.File]::Open($file, [IO.FileMode]::Open, [IO.FileAccess]::Read, [IO.FileShare]::Read)
        try {
            $message = try { Assert-EdgeActionBuildOutputAvailable $file } catch { $_.Exception.Message }
            $message | Should -Match 'preparation has not started'
            $message | Should -Match 'Stop-Process -Id 105 -Confirm'
            $held.CanRead | Should -Be $true
            Assert-MockCalled Stop-Process -Scope It -Times 0 -Exactly
        } finally {
            $held.Dispose()
        }
    }
}

Describe 'Generation prerequisite checks before preparation' {
    BeforeEach {
        $runner = Join-Path $PSScriptRoot '..' 'Update-EdgeActionGeneratedFiles.ps1'
        $tokens = $null
        $errors = $null
        $ast = [Management.Automation.Language.Parser]::ParseFile($runner, [ref]$tokens, [ref]$errors)
        $outer = $ast.EndBlock.Statements | Where-Object { $_ -is [Management.Automation.Language.TryStatementAst] }
        # Exercise the actual prerequisite block, without invoking Prepare or build.
        $preflight = $outer.Body.Statements | Where-Object { $_ -is [Management.Automation.Language.TryStatementAst] } | Select-Object -First 1
        $check = [scriptblock]::Create($preflight.Extent.Text)
        $source = Join-Path $TestDrive 'source'
        $package = Join-Path $TestDrive 'node_modules' 'autorest' 'package.json'
        $null = New-Item (Split-Path $package) -ItemType Directory -Force
        '{"name":"autorest","version":"3.8.0"}' | Set-Content $package
        $autoPath = Join-Path $TestDrive 'autorest.ps1'
        '' | Set-Content $autoPath
        $script:fixtureNode = 'v20.20.2'
        $script:fixtureSdk = '8.0.100'
        function Test-NodeVersion { $script:fixtureNode }
        function Test-Dotnet.exe { $script:fixtureSdk }
        Mock Get-Command {
            switch ($Name) {
                node { [pscustomobject]@{ Source = 'Test-NodeVersion' } }
                dotnet { [pscustomobject]@{ Source = 'Test-Dotnet.exe' } }
                autorest { [pscustomobject]@{ Source = $autoPath } }
                default { throw "Unexpected command lookup: $Name" }
            }
        }
        Mock Import-Module {}
        $oldPath = $env:PATH
    }
    AfterEach { $env:PATH = $oldPath }

    It 'accepts minimum SDK without requiring the validated SDK patch' {
        & $check
        Assert-MockCalled Import-Module -Scope It -Times 1 -Exactly -ParameterFilter {
            $Name -eq 'platyPS' -and $RequiredVersion -eq '0.14.2'
        }
        $ast.ScriptRequirements.RequiredPSVersion | Should -Be ([version]'7.3')
        $preflight.Extent.StartOffset | Should -BeLessThan ($outer.Body.Statements |
            Where-Object { $_ -is [Management.Automation.Language.AssignmentStatementAst] -and $_.Left.Extent.Text -eq '$env:autorest_registry' }).Extent.StartOffset
    }
    It 'rejects <Prerequisite> before generation' -TestCases @(
        @{ Prerequisite = 'Node'; Node = 'v18.20.0'; Sdk = '8.0.100'; Cli = '3.8.0'; FailureMessage = 'Node.js 20+ required' }
        @{ Prerequisite = 'SDK'; Node = 'v20.20.2'; Sdk = '7.0.100'; Cli = '3.8.0'; FailureMessage = '.NET SDK 8+ required' }
        @{ Prerequisite = 'AutoRest'; Node = 'v20.20.2'; Sdk = '8.0.100'; Cli = '3.7.2'; FailureMessage = 'AutoRest CLI 3.8.0 required' }
    ) {
        param($Prerequisite, $Node, $Sdk, $Cli, $FailureMessage)
        $script:fixtureNode = $Node
        $script:fixtureSdk = $Sdk
        @{ name = 'autorest'; version = $Cli } | ConvertTo-Json | Set-Content $package
        { & $check } | Should -Throw $FailureMessage
        Assert-MockCalled Import-Module -Scope It -Times 0 -Exactly
    }
    It 'reports missing platyPS with the resolved guide path' {
        Mock Import-Module { throw 'platyPS 0.14.2 unavailable' }
        { & $check } | Should -Throw (Join-Path $source 'how-to.md')
    }
    It 'rejects an npm dotnet executable rather than accepting its version' {
        Mock Get-Command { [pscustomobject]@{ Source = (Join-Path $TestDrive 'node_modules' 'dotnet.exe') } } -ParameterFilter { $Name -eq 'dotnet' }
        { & $check } | Should -Throw 'npm dotnet shims are not supported'
        Assert-MockCalled Import-Module -Scope It -Times 0 -Exactly
    }
}
