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
Static, offline correctness checks for authored examples, against the surfaces a
user actually touches.

Two checks:

1. Parameters. Every PowerShell code fence in examples/*.md is parsed and each
   invocation of a module cmdlet is checked against the parameters that cmdlet
   really declares. Added after two shipped examples documented a `-PassThru`
   switch that does not exist on either cmdlet (see DEV-039). A user following
   those examples got a parameter-binding error, and in one case the example also
   asserted a boolean return from a cmdlet that returns an object -- so the
   documented `if (Test-AzChaosScenarioConfiguration ...)` pattern was always true
   and would have treated a failed validation as a success.

2. Properties. Variables assigned from a module cmdlet are tracked, and every
   property read off them is checked against the cmdlet's declared OutputType via
   reflection on the shipped private assembly. Added after the *fix* for the
   first defect introduced a second one of the same class: the corrected example
   read `$validation.ValidationErrorPermission`, a name that exists only on the
   internal `ValidationProperties` bag and not on the `IValidation` the user
   receives (DEV-042). PowerShell returns `$null` silently for an unknown
   property under default StrictMode, so the example failed quietly rather than
   loudly -- the same silent-wrongness as the truthiness bug it replaced.

Both checks validate *every* module cmdlet an example calls, not just the cmdlet
the file is named for, because examples routinely call siblings to set up
context and a wrong name there fails the user identically.

Parameter names are resolved the way PowerShell itself resolves them -- exact
match first, then unambiguous prefix -- so an example is only reported when it
would genuinely fail to bind.

These tests do not depend on HttpPipelineMocking/recordings; they inspect tracked
text files and the built assembly on disk.
#>

Describe 'Authored examples only use parameters that exist' {

    BeforeAll {
        $moduleRoot = Split-Path -Path $PSScriptRoot -Parent
        $exampleRoot = Join-Path $moduleRoot 'examples'
        $exportRoot = Join-Path $moduleRoot 'exports'

        # These are build-time guards over the *source* tree. CI runs this suite against the
        # built module under artifacts, where source-only folders (examples/, docs/) are not
        # present -- a packaged Az module ships bin/custom/exports/internal/utils and nothing
        # else. Skip rather than fail there: an absent examples/ folder means there is nothing
        # to check, not that a check failed. See DEV-056.
        $hasSourceTree = (Test-Path -Path $exampleRoot) -and (Test-Path -Path $exportRoot)

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

    It 'discovers example files and the exported cmdlet parameter surface' -Skip:(-not $hasSourceTree) {
        # Guards the guard: if either collection is empty the parameter check below
        # passes vacuously, which is exactly the failure mode this suite exists to
        # prevent elsewhere.
        $exampleFiles.Count | Should -BeGreaterThan 0 -Because 'examples/*.md must be present for this check to mean anything'
        $declaredParameters.Count | Should -BeGreaterThan 0 -Because 'exports/*.ps1 must be present for this check to mean anything'
    }

    It 'uses only declared parameters in every example invocation of a module cmdlet' -Skip:(-not $hasSourceTree) {
        $invalidParameterUsages | Should -BeNullOrEmpty -Because (
            "the following examples document parameters that do not exist:`n" +
            (($invalidParameterUsages | Sort-Object -Unique) -join "`n")
        )
    }
}

Describe 'Authored examples only read properties that exist' {

    BeforeAll {
        $moduleRoot = Split-Path -Path $PSScriptRoot -Parent
        $exampleRoot = Join-Path $moduleRoot 'examples'
        $exportRoot = Join-Path $moduleRoot 'exports'
        $privateAssembly = Join-Path $moduleRoot 'bin/Az.Chaos.private.dll'

        # Load from bytes rather than LoadFrom so the test never holds a file lock
        # on the assembly a subsequent build needs to overwrite.
        $moduleTypes = @()
        if (Test-Path -Path $privateAssembly) {
            $assembly = [System.Reflection.Assembly]::Load(
                [System.IO.File]::ReadAllBytes($privateAssembly))
            try { $moduleTypes = @($assembly.GetTypes()) }
            catch [System.Reflection.ReflectionTypeLoadException] {
                $moduleTypes = @($_.Exception.Types | Where-Object { $null -ne $_ })
            }
        }

        $typesByFullName = @{}
        foreach ($type in $moduleTypes) {
            if ($type.FullName -and -not $typesByFullName.ContainsKey($type.FullName)) {
                $typesByFullName[$type.FullName] = $type
            }
        }

        # An AutoRest model interface declares its own properties and inherits the
        # rest, so walk the inherited interfaces too or the set comes back short.
        function Get-TypePropertyName {
            param([Type]$Type)

            if ($null -eq $Type) { return @() }
            $names = @($Type.GetProperties() | ForEach-Object { $_.Name })
            foreach ($inherited in $Type.GetInterfaces()) {
                $names += @($inherited.GetProperties() | ForEach-Object { $_.Name })
            }
            return @($names | Sort-Object -Unique)
        }

        function Get-ElementType {
            param([Type]$Type)

            if ($null -eq $Type) { return $null }
            if ($Type.IsArray) { return $Type.GetElementType() }
            if ($Type.IsGenericType -and $Type.GenericTypeArguments.Count -eq 1) {
                return $Type.GenericTypeArguments[0]
            }
            return $Type
        }

        # Map each exported cmdlet to the type it declares it returns.
        $cmdletOutputType = @{}
        if (Test-Path -Path $exportRoot) {
            foreach ($exportFile in Get-ChildItem -Path $exportRoot -Filter '*.ps1' -File) {
                $ast = [System.Management.Automation.Language.Parser]::ParseFile(
                    $exportFile.FullName, [ref]$null, [ref]$null)
                foreach ($fn in $ast.FindAll(
                    { $args[0] -is [System.Management.Automation.Language.FunctionDefinitionAst] }, $true)) {
                    if ($cmdletOutputType.ContainsKey($fn.Name)) { continue }
                    $attr = $fn.Body.ParamBlock.Attributes |
                        Where-Object { $_.TypeName.Name -eq 'OutputType' } | Select-Object -First 1
                    if (-not $attr -or $attr.PositionalArguments.Count -eq 0) { continue }
                    $typeArg = $attr.PositionalArguments[0]
                    if ($typeArg -is [System.Management.Automation.Language.TypeExpressionAst]) {
                        $cmdletOutputType[$fn.Name] = $typeArg.TypeName.FullName
                    }
                }
            }
        }

        $invalidPropertyReads = @()
        $trackedAssignments = 0
        $exampleFiles = @()
        if (Test-Path -Path $exampleRoot) {
            $exampleFiles = @(Get-ChildItem -Path $exampleRoot -Filter '*.md' -File |
                Where-Object { $_.Name -ne 'README.md' })
        }

        # Same layout guard as the parameter check above: skip in the packaged layout where
        # examples/ and the built assembly are not present. See DEV-056.
        $hasSourceTree = (Test-Path -Path $exampleRoot) -and (Test-Path -Path $privateAssembly)

        foreach ($exampleFile in $exampleFiles) {
            $content = Get-Content -Path $exampleFile.FullName -Raw
            if ([System.String]::IsNullOrWhiteSpace($content)) { continue }

            foreach ($codeBlock in [regex]::Matches($content, '(?ms)^```powershell\s*\r?\n(?<Code>.*?)^```')) {
                $parseErrors = $null
                $codeAst = [System.Management.Automation.Language.Parser]::ParseInput(
                    $codeBlock.Groups['Code'].Value, [ref]$null, [ref]$parseErrors)
                if ($parseErrors -and $parseErrors.Count -gt 0) { continue }

                # Track variables assigned the result of a module cmdlet.
                $variableType = @{}
                foreach ($assignment in $codeAst.FindAll(
                    { $args[0] -is [System.Management.Automation.Language.AssignmentStatementAst] }, $true)) {
                    if ($assignment.Left -isnot [System.Management.Automation.Language.VariableExpressionAst]) { continue }
                    $command = $assignment.Right.Find(
                        { $args[0] -is [System.Management.Automation.Language.CommandAst] }, $true)
                    if (-not $command) { continue }
                    $commandName = $command.GetCommandName()
                    if (-not $commandName -or -not $cmdletOutputType.ContainsKey($commandName)) { continue }

                    $typeName = $cmdletOutputType[$commandName]
                    if (-not $typesByFullName.ContainsKey($typeName)) { continue }
                    $variableType[$assignment.Left.VariablePath.UserPath] = $typesByFullName[$typeName]
                    $script:trackedAssignments++
                }

                if ($variableType.Count -eq 0) { continue }

                foreach ($member in $codeAst.FindAll(
                    { $args[0] -is [System.Management.Automation.Language.MemberExpressionAst] }, $true)) {
                    if ($member.Expression -isnot [System.Management.Automation.Language.VariableExpressionAst]) { continue }
                    if ($member.Member -isnot [System.Management.Automation.Language.StringConstantExpressionAst]) { continue }

                    $variableName = $member.Expression.VariablePath.UserPath
                    if (-not $variableType.ContainsKey($variableName)) { continue }

                    $ownerType = $variableType[$variableName]
                    $propertyName = $member.Member.Value
                    $known = Get-TypePropertyName -Type $ownerType
                    if ($known -notcontains $propertyName) {
                        $invalidPropertyReads += "$($exampleFile.Name): `$$variableName.$propertyName -- no such property on $($ownerType.Name)."
                        continue
                    }

                    # `$x.Collection | Format-List A, B` names properties of the
                    # element type, not of $x. Check those too.
                    $parentPipeline = $member.Parent
                    while ($parentPipeline -and $parentPipeline -isnot [System.Management.Automation.Language.PipelineAst]) {
                        $parentPipeline = $parentPipeline.Parent
                    }
                    if (-not $parentPipeline -or $parentPipeline.PipelineElements.Count -lt 2) { continue }

                    $elementType = Get-ElementType -Type (
                        $ownerType.GetProperties() | Where-Object { $_.Name -eq $propertyName } |
                        Select-Object -First 1 -ExpandProperty PropertyType)
                    $elementProperties = Get-TypePropertyName -Type $elementType
                    if ($elementProperties.Count -eq 0) { continue }

                    foreach ($stage in $parentPipeline.PipelineElements) {
                        if ($stage -isnot [System.Management.Automation.Language.CommandAst]) { continue }
                        $stageName = $stage.GetCommandName()
                        if ($stageName -notin @('Format-List', 'Format-Table', 'Select-Object', 'fl', 'ft', 'select')) { continue }

                        foreach ($element in $stage.CommandElements) {
                            # `Format-List A, B, C` parses the comma-separated list as a
                            # single ArrayLiteralAst, not as three command elements, so
                            # flatten before checking or only the single-property form
                            # is ever validated.
                            $candidates = @()
                            if ($element -is [System.Management.Automation.Language.ArrayLiteralAst]) {
                                $candidates = @($element.Elements |
                                    Where-Object { $_ -is [System.Management.Automation.Language.StringConstantExpressionAst] } |
                                    ForEach-Object { $_.Value })
                            }
                            elseif ($element -is [System.Management.Automation.Language.StringConstantExpressionAst]) {
                                $candidates = @($element.Value)
                            }

                            foreach ($candidate in $candidates) {
                                if ($candidate -eq $stageName -or $candidate -eq '*') { continue }
                                if ($elementProperties -notcontains $candidate) {
                                    $invalidPropertyReads += "$($exampleFile.Name): '$stageName $candidate' -- no such property on $($elementType.Name) (element of `$$variableName.$propertyName)."
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    It 'resolves the shipped assembly and tracks at least one cmdlet result variable' -Skip:(-not $hasSourceTree) {
        # Guards the guard: with no types or no tracked assignments the check below
        # passes vacuously.
        $typesByFullName.Count | Should -BeGreaterThan 0 -Because 'bin/Az.Chaos.private.dll must be loadable for this check to mean anything'
        $trackedAssignments | Should -BeGreaterThan 0 -Because 'at least one example must assign a cmdlet result to a variable'
    }

    It 'reads only properties that exist on the declared output type' -Skip:(-not $hasSourceTree) {
        $invalidPropertyReads | Should -BeNullOrEmpty -Because (
            "the following examples read properties that do not exist:`n" +
            (($invalidPropertyReads | Sort-Object -Unique) -join "`n")
        )
    }
}
