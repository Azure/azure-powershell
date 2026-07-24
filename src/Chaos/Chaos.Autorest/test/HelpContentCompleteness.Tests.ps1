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
Static, offline completeness check. Fails if a debugging/experiment placeholder
sentinel (e.g. a stray swagger-transform artifact) leaks into shipped
documentation or custom cmdlet source. Added after a `SENTRECURSIVE` placeholder
description shipped in five tracked files (see DEV-012 in the deviation log).
This test intentionally does not depend on HttpPipelineMocking/recordings — it
only inspects tracked text files on disk.
#>

Describe 'Shipped help and custom cmdlet content is free of placeholder sentinels' {

    BeforeAll {
        $moduleRoot = Split-Path -Path $PSScriptRoot -Parent
        $scanRoots = @('docs', 'help', 'custom') | ForEach-Object {
            Join-Path $moduleRoot $_
        } | Where-Object { Test-Path -Path $_ }

        # Patterns that indicate leftover debugging/experiment placeholders rather
        # than authored content. Kept intentionally narrow to avoid false positives
        # on legitimate text (for example, avoid matching common words).
        $placeholderPatterns = @(
            'SENTRECURSIVE',
            '\{\{\s*\}\}',
            'TODO_PLACEHOLDER',
            'FIXME_PLACEHOLDER'
        )

        $sentinelHits = @()
        foreach ($root in $scanRoots) {
            $files = Get-ChildItem -Path $root -Recurse -File -Include '*.md', '*.ps1'
            foreach ($file in $files) {
                $content = Get-Content -Path $file.FullName -Raw
                foreach ($pattern in $placeholderPatterns) {
                    if ($content -match $pattern) {
                        $sentinelHits += [PSCustomObject]@{
                            File    = $file.FullName
                            Pattern = $pattern
                        }
                    }
                }
            }
        }
    }

    It 'contains no placeholder sentinel tokens in docs, help, or custom' {
        $sentinelHits | Should -BeNullOrEmpty -Because (
            ($sentinelHits | ForEach-Object { "$($_.File) matched '$($_.Pattern)'" }) -join "`n"
        )
    }
}
