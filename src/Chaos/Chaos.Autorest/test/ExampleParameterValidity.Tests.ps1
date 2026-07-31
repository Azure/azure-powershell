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
Static, offline correctness check for authored examples.

Parses every PowerShell code fence in examples/*.md and verifies that each
invocation of a module cmdlet only uses parameters that cmdlet actually
declares. Added after two shipped examples documented a `-PassThru` switch that
does not exist on either cmdlet (see DEV-039). A user following those examples
got a parameter-binding error, and in one case the example also asserted a
boolean return from a cmdlet that returns an object -- so the documented
`if (Test-AzChaosScenarioConfiguration ...)` pattern was always true and would
have treated a failed validation as a success.

This check deliberately validates *every* module cmdlet invoked in an example
file, not just the cmdlet the file is named for. Example files routinely call
sibling cmdlets to set up context, and a wrong parameter there fails the user
exactly the same way.

Parameter names are resolved the way PowerShell itself resolves them -- exact
match first, then unambiguous prefix -- so an example is only reported when it
would genuinely fail to bind.

This test does not depend on HttpPipelineMocking/recordings; it only inspects
tracked text files on disk.
#>

Describe 'Authored examples only use parameters that exist' {

    BeforeAll {
        $moduleRoot = Split-Path -Path $PSScriptRoot -Parent
        $exampleRoot = Join-Path $moduleRoot 'examples'
        $exportRoot = Join-Path $moduleRoot 'exports'

        # Parameters PowerShell adds to every advanced function. These never appear
        # in the param block but always bind.
        $commonParameters = @(
            'Verbose', 'Debug', 'ErrorAction', 'WarningAction', 'InformationAction',
            'ProgressAction', 'ErrorVariable', 'WarningVariable', 'InformationVariable',
            'OutVariable', 'OutBuffer', 'PipelineVariable', 'WhatIf', 'Confirm'
        )

        # Map every exported cmdlet to the parameters it actually declares. Parse every
        # function in each file, not just the first: exports\ProxyCmdletDefinitions.ps1
        # concatenates all cmdlets into one file, so a first-function-only read would
        # silently miss most of the surface.
        $declaredParameters = @{}
        if (Test-Path -Path $exportRoot) {
            foreach ($exportFile in Get-ChildItem -Path $exportRoot -Filter '*.ps1' -File) {
                $exportAst = [System.Management.Automation.Language.Parser]::ParseFile(
                    $exportFile.FullName, [ref]$null, [ref]$null)
                $functionAsts = $exportAst.FindAll(
                    { $args[0] -is [System.Management.Automation.Language.FunctionDefinitionAst] }, $true)
                foreach ($functionAst in $functionAsts) {
                    if (-not $functionAst.Body.ParamBlock) { continue }
                    if ($declaredParameters.ContainsKey($functionAst.Name)) { continue }

                    $names = @($functionAst.Body.ParamBlock.Parameters |
                        ForEach-Object { $_.Name.VariablePath.UserPath })
                    $declaredParameters[$functionAst.Name] = $names + $commonParameters
                }
            }
        }

        # Resolve a parameter name the way PowerShell binds it: exact match wins,
        # otherwise an unambiguous prefix binds, and anything else fails.
        function Resolve-ParameterName {
            param([string]$Name, [string[]]$Candidates)

            if ($Candidates -contains $Name) { return $true }
            $prefixMatches = @($Candidates | Where-Object { $_ -like "$Name*" })
            return ($prefixMatches.Count -eq 1)
        }

        $invalidParameterUsages = @()
        $exampleFiles = @()
        if (Test-Path -Path $exampleRoot) {
            $exampleFiles = @(Get-ChildItem -Path $exampleRoot -Filter '*.md' -File |
                Where-Object { $_.Name -ne 'README.md' })
        }

        foreach ($exampleFile in $exampleFiles) {
            $content = Get-Content -Path $exampleFile.FullName -Raw
            if ([System.String]::IsNullOrWhiteSpace($content)) { continue }

            # Only PowerShell fences carry runnable code. ```output fences hold
            # sample results and must not be parsed as script.
            $codeBlocks = [regex]::Matches($content, '(?ms)^```powershell\s*\r?\n(?<Code>.*?)^```')
            foreach ($codeBlock in $codeBlocks) {
                $code = $codeBlock.Groups['Code'].Value
                $parseErrors = $null
                $codeAst = [System.Management.Automation.Language.Parser]::ParseInput(
                    $code, [ref]$null, [ref]$parseErrors)

                if ($parseErrors -and $parseErrors.Count -gt 0) {
                    $invalidParameterUsages += "$($exampleFile.Name): example code does not parse as PowerShell -- $($parseErrors[0].Message)"
                    continue
                }

                $commandAsts = $codeAst.FindAll(
                    { $args[0] -is [System.Management.Automation.Language.CommandAst] }, $true)
                foreach ($commandAst in $commandAsts) {
                    $commandName = $commandAst.GetCommandName()
                    if (-not $commandName -or -not $declaredParameters.ContainsKey($commandName)) { continue }

                    $candidates = $declaredParameters[$commandName]
                    foreach ($element in $commandAst.CommandElements) {
                        if ($element -isnot [System.Management.Automation.Language.CommandParameterAst]) { continue }
                        $parameterName = $element.ParameterName
                        if (-not (Resolve-ParameterName -Name $parameterName -Candidates $candidates)) {
                            $invalidParameterUsages += "$($exampleFile.Name): '$commandName -$parameterName' -- no such parameter on $commandName."
                        }
                    }
                }
            }
        }
    }

    It 'discovers example files and the exported cmdlet parameter surface' {
        # Guards the guard: if either collection is empty the parameter check below
        # passes vacuously, which is exactly the failure mode this suite exists to
        # prevent elsewhere.
        $exampleFiles.Count | Should -BeGreaterThan 0 -Because 'examples/*.md must be present for this check to mean anything'
        $declaredParameters.Count | Should -BeGreaterThan 0 -Because 'exports/*.ps1 must be present for this check to mean anything'
    }

    It 'uses only declared parameters in every example invocation of a module cmdlet' {
        $invalidParameterUsages | Should -BeNullOrEmpty -Because (
            "the following examples document parameters that do not exist:`n" +
            (($invalidParameterUsages | Sort-Object -Unique) -join "`n")
        )
    }
}
