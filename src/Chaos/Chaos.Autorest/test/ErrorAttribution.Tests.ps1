# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
Static, offline check that custom cmdlets attribute errors to themselves.

Two rules, both regression guards for defects that shipped:

1. No bare `throw` or `Write-Error` in custom/. PowerShell attributes those to the
   nearest script frame, which inside a private helper is this module's own source
   and the helper's name -- a function the caller cannot invoke (DEV-040). Errors
   must be emitted via $PSCmdlet.ThrowTerminatingError or $PSCmdlet.WriteError so
   they carry the cmdlet name and the caller's own command line.

2. Every call from a custom cmdlet to a module cmdlet or to an Az.Resources cmdlet
   must sit inside a try block. Without one, a failure in the callee is rendered
   against the internal generated variant name (e.g.
   `Test-AzChaosScenarioConfiguration_Validate`) and this file's line number
   (DEV-044). That name resolves to nothing -- `Get-Command` and `Get-Help` both
   reject it -- so the user is shown a command they did not call and cannot look
   up, and a support triager can be routed to the wrong owner.

Rule 2 is deliberately structural rather than behavioural. A per-call-site fix is
invisible to a future contributor adding call site number twelve; asserting the
property over the whole file means a new unwrapped call fails the suite.

Note this checks only that a try exists, not what the catch does. Two call sites
legitimately catch and handle rather than re-attribute (a retry loop that logs and
continues, and one that converts to a timeout error), and both are correct.

This test does not depend on HttpPipelineMocking/recordings and does not import the
module; it statically inspects custom/*.ps1 and reads Az.Chaos.psd1. It runs against
both the source tree and the packaged module under artifacts/, whose exports/ folder
holds only the merged ProxyCmdletDefinitions.ps1 -- hence the manifest rather than a
file listing as the source of the exported cmdlet surface.
#>

Describe 'Custom cmdlets attribute errors to the cmdlet, not to module internals' {

    BeforeAll {
        $moduleRoot = Split-Path -Path $PSScriptRoot -Parent
        $customRoot = Join-Path $moduleRoot 'custom'
        $exportRoot = Join-Path $moduleRoot 'exports'

        $customFiles = @()
        if (Test-Path -Path $customRoot) {
            $customFiles = @(Get-ChildItem -Path $customRoot -Filter '*.ps1' -File)
        }

        # Cmdlets whose failures would otherwise be rendered against an internal name.
        $seedCommands = @('Get-AzResourceGroup', 'New-AzResourceGroup', 'New-AzRoleAssignment')

        # The module's own exported surface. exports/*.ps1 exists only in the source tree: the
        # packaged module under artifacts/ ships one merged exports/ProxyCmdletDefinitions.ps1
        # and nothing else, so a file listing contributes zero names there. Az.Chaos.psd1 is
        # identical in both layouts, so read FunctionsToExport and union in the per-cmdlet
        # files when they happen to be present. Deriving the surface from the manifest is what
        # keeps this check at full strength in CI -- with the file listing alone the list
        # collapses to the three seeds above and the call-site check below quietly inspects a
        # tenth of the surface it is supposed to cover.
        $manifestPath = Join-Path $moduleRoot 'Az.Chaos.psd1'
        $exportedFunctions = @()
        if (Test-Path -Path $manifestPath) {
            $manifest = Import-PowerShellDataFile -Path $manifestPath
            $exportedFunctions = @($manifest.FunctionsToExport | Where-Object { $_ -and $_ -ne '*' })
        }

        $exportFileNames = @()
        if (Test-Path -Path $exportRoot) {
            $exportFileNames = @(Get-ChildItem -Path $exportRoot -Filter '*.ps1' -File |
                Where-Object { $_.Name -ne 'ProxyCmdletDefinitions.ps1' } |
                ForEach-Object { $_.BaseName })
        }

        $plumbingCommands = @($seedCommands + $exportedFunctions + $exportFileNames | Sort-Object -Unique)

        $bareErrorSites = @()
        $unwrappedCallSites = @()

        foreach ($file in $customFiles) {
            foreach ($line in (Get-Content -Path $file.FullName)) {
                if ($line -match '^\s*(throw|Write-Error)\s') {
                    $bareErrorSites += "$($file.Name): $($line.Trim())"
                }
            }

            $ast = [System.Management.Automation.Language.Parser]::ParseFile(
                $file.FullName, [ref]$null, [ref]$null)
            $commands = $ast.FindAll(
                { $args[0] -is [System.Management.Automation.Language.CommandAst] }, $true)

            foreach ($command in $commands) {
                $name = $command.GetCommandName()
                if (-not $name -or $plumbingCommands -notcontains $name) { continue }

                $node = $command.Parent
                $insideTry = $false
                while ($node) {
                    if ($node -is [System.Management.Automation.Language.TryStatementAst]) {
                        $insideTry = $true
                        break
                    }
                    $node = $node.Parent
                }

                if (-not $insideTry) {
                    $unwrappedCallSites += "$($file.Name):$($command.Extent.StartLineNumber) calls $name outside any try block."
                }
            }
        }
    }

    It 'discovers custom cmdlet sources and the plumbing command surface' {
        # Guards the guard: with either collection empty both checks below pass
        # vacuously, which is the failure mode this suite exists to prevent.
        $customFiles.Count | Should -BeGreaterThan 0 -Because 'custom/*.ps1 must be present for these checks to mean anything'
        $exportedFunctions.Count | Should -BeGreaterThan 0 -Because 'Az.Chaos.psd1 FunctionsToExport must resolve; it is the only source of the exported surface in the packaged layout'
        $plumbingCommands.Count | Should -BeGreaterThan 3 -Because 'the exported cmdlet surface must resolve for the call-site check to mean anything'
    }

    It 'emits no bare throw or Write-Error from custom cmdlet source' {
        $bareErrorSites | Should -BeNullOrEmpty -Because (
            "these sites render module-internal paths and private function names to the user; " +
            "use `$PSCmdlet.ThrowTerminatingError or `$PSCmdlet.WriteError instead:`n" +
            (($bareErrorSites | Sort-Object -Unique) -join "`n")
        )
    }

    It 'wraps every plumbing call so failures are attributed to the calling cmdlet' {
        $unwrappedCallSites | Should -BeNullOrEmpty -Because (
            "an unwrapped call renders errors against the internal generated cmdlet variant, " +
            "a name that does not resolve for the user:`n" +
            (($unwrappedCallSites | Sort-Object -Unique) -join "`n")
        )
    }
}
