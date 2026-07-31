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
documentation or custom cmdlet source. Also fails if generated cmdlet help loses
authored example prose and ships bare command-only examples. Added after a
`SENTRECURSIVE` placeholder description shipped in five tracked files (see
DEV-012 in the deviation log), and after a no-profile help regeneration order
bug stripped all example descriptions from generated cmdlet help.
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

        $manifest = Import-PowerShellDataFile -Path (Join-Path $moduleRoot 'Az.Chaos.psd1')
        $exportedCmdlets = @($manifest.FunctionsToExport | Where-Object { $_ -like '*-AzChaos*' } | Sort-Object)
        $exampleDescriptionFailures = @()
        foreach ($cmdletName in $exportedCmdlets) {
            $helpFile = Join-Path (Join-Path $moduleRoot 'docs') "$cmdletName.md"
            if (-not (Test-Path -Path $helpFile)) {
                $exampleDescriptionFailures += "$cmdletName has no generated docs file at '$helpFile'."
                continue
            }

            $helpContent = Get-Content -Path $helpFile -Raw
            if ($helpContent -notmatch '(?ms)^## EXAMPLES\s*(?<Examples>.*?)(?=^##\s|\z)') {
                $exampleDescriptionFailures += "$cmdletName has no EXAMPLES section in generated docs."
                continue
            }

            $exampleSection = $Matches.Examples
            $exampleBlocks = [regex]::Matches($exampleSection, '(?ms)^###\s+.*?(?=^###\s+|\z)')
            if ($exampleBlocks.Count -eq 0) {
                $exampleDescriptionFailures += "$cmdletName has no generated example blocks."
                continue
            }

            for ($i = 0; $i -lt $exampleBlocks.Count; $i++) {
                $block = $exampleBlocks[$i].Value
                $exampleNumber = $i + 1
                $withoutCodeFences = [regex]::Replace($block, '(?ms)```.*?```', '')
                $descriptionLines = @($withoutCodeFences -split "`r?`n" | Where-Object {
                    $_ -notmatch '^###\s+' -and -not [System.String]::IsNullOrWhiteSpace($_)
                })
                if ($descriptionLines.Count -eq 0) {
                    $exampleDescriptionFailures += "$cmdletName example $exampleNumber has no description prose in generated docs."
                }
            }
        }
    }

    It 'contains no placeholder sentinel tokens in docs, help, or custom' {
        $sentinelHits | Should -BeNullOrEmpty -Because (
            ($sentinelHits | ForEach-Object { "$($_.File) matched '$($_.Pattern)'" }) -join "`n"
        )
    }

    It 'has description prose for every generated example of every exported cmdlet' {
        $exampleDescriptionFailures | Should -BeNullOrEmpty -Because ($exampleDescriptionFailures -join "`n")
    }
}
