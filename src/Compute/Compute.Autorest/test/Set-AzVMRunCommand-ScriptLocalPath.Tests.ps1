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
    Unit tests for the ScriptLocalPath processing logic in Set-AzVMRunCommand
    and Set-AzVmssVMRunCommand. These tests validate that local script files
    are correctly transformed into semicolon-delimited single-line scripts
    without producing invalid syntax (e.g., ;; from blank lines).
#>

# Helper function that replicates the .sh script processing logic from
# Set-AzVMRunCommand_ScriptLocalPath.ps1 for isolated unit testing.
function ConvertTo-RunCommandScript {
    param(
        [string]$ScriptLocalPath
    )
    $script = ""
    foreach ($line in Get-Content -Path $ScriptLocalPath) {
        if ([string]::IsNullOrWhiteSpace($line)) { continue }
        $words = $line.trim().split()
        $commentFound = $false
        foreach ($word in $words) {
            if ($word[0] -eq "#" -and $commentFound -eq $false) {
                $commentFound = $true
                $script += "``" + $word + " "
            }
            else {
                $script += $word + " "
            }
        }
        $script = $script.trim()
        if ($commentFound) {
            $script += "``"
        }
        $script += ";"
    }
    return $script
}

Describe 'Set-AzVMRunCommand ScriptLocalPath Processing' {

    $testDir = Join-Path $TestDrive 'runcommand-tests'
    New-Item -ItemType Directory -Path $testDir -Force | Out-Null

    It 'Should not produce ;; when script contains single blank line' {
        $scriptPath = Join-Path $testDir 'single-blank.sh'
        @(
            '#!/bin/bash',
            'echo "hello"',
            '',
            'echo "world"'
        ) | Set-Content -Path $scriptPath

        $result = ConvertTo-RunCommandScript -ScriptLocalPath $scriptPath

        $result | Should Not Match ';;'
        $result | Should Match 'echo "hello"'
        $result | Should Match 'echo "world"'
    }

    It 'Should not produce ;; when script contains multiple consecutive blank lines' {
        $scriptPath = Join-Path $testDir 'multi-blank.sh'
        @(
            '#!/bin/bash',
            'echo "hello"',
            '',
            '',
            '',
            'echo "world"'
        ) | Set-Content -Path $scriptPath

        $result = ConvertTo-RunCommandScript -ScriptLocalPath $scriptPath

        $result | Should Not Match ';;'
    }

    It 'Should handle script with no blank lines' {
        $scriptPath = Join-Path $testDir 'no-blank.sh'
        @(
            '#!/bin/bash',
            'echo "hello"',
            'echo "world"'
        ) | Set-Content -Path $scriptPath

        $result = ConvertTo-RunCommandScript -ScriptLocalPath $scriptPath

        $result | Should Not Match ';;'
        $result | Should Match 'echo "hello";echo "world";'
    }

    It 'Should handle script with trailing blank lines' {
        $scriptPath = Join-Path $testDir 'trailing-blank.sh'
        @(
            '#!/bin/bash',
            'echo "done"',
            '',
            ''
        ) | Set-Content -Path $scriptPath

        $result = ConvertTo-RunCommandScript -ScriptLocalPath $scriptPath

        $result | Should Not Match ';;'
        $result | Should Match 'echo "done";$'
    }

    It 'Should handle script with leading blank lines' {
        $scriptPath = Join-Path $testDir 'leading-blank.sh'
        @(
            '',
            '',
            '#!/bin/bash',
            'echo "start"'
        ) | Set-Content -Path $scriptPath

        $result = ConvertTo-RunCommandScript -ScriptLocalPath $scriptPath

        $result | Should Not Match ';;'
    }

    It 'Should preserve comments correctly' {
        $scriptPath = Join-Path $testDir 'with-comments.sh'
        @(
            '#!/bin/bash',
            '# This is a comment',
            'echo "hello"',
            '',
            '# Another comment',
            'echo "world"'
        ) | Set-Content -Path $scriptPath

        $result = ConvertTo-RunCommandScript -ScriptLocalPath $scriptPath

        $result | Should Not Match ';;'
        $result | Should Match 'echo "hello"'
        $result | Should Match 'echo "world"'
    }

    It 'Should handle whitespace-only lines the same as blank lines' {
        $scriptPath = Join-Path $testDir 'whitespace-only.sh'
        @(
            '#!/bin/bash',
            'echo "hello"',
            '   ',
            '	',
            'echo "world"'
        ) | Set-Content -Path $scriptPath

        $result = ConvertTo-RunCommandScript -ScriptLocalPath $scriptPath

        $result | Should Not Match ';;'
    }
}
