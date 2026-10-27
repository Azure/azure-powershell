Describe 'MigrationWarning.Unit' {
    BeforeEach {
        $script:migrationTestMode = 'Success'
        $script:migrationTestParameters = @{}
    }

    function Invoke-MigrationWarningTestOperation {
        [CmdletBinding(SupportsShouldProcess)]
        param([switch]$PassThru, [switch]$NoWait, [switch]$AsJob)

        $script:migrationTestParameters = @{} + $PSBoundParameters
        if ($script:migrationTestMode -eq 'Declined') {
            return
        }
        if (-not $PSCmdlet.ShouldProcess('offline profile', 'Commit migration')) {
            return
        }
        if ($script:migrationTestMode -eq 'Throw') {
            throw 'Migration failed'
        }
        if ($script:migrationTestMode -in @('Error', 'ErrorWithOutput')) {
            $PSCmdlet.WriteError([System.Management.Automation.ErrorRecord]::new(
                [System.Exception]::new('Migration failed'), 'MigrationFailed',
                [System.Management.Automation.ErrorCategory]::InvalidOperation, $null))
            if ($script:migrationTestMode -eq 'ErrorWithOutput') {
                $true
            }
            return
        }
        if ($AsJob) {
            [pscustomobject]@{ Kind = 'Job' }
        } elseif ($NoWait -and $script:migrationTestMode -ne 'Immediate') {
            [pscustomobject]@{ Kind = 'Operation' }
        } elseif ($PSBoundParameters.ContainsKey('PassThru')) {
            $true
        }
    }

    foreach ($commandName in @('Enable-AzFrontDoorCdnProfileMigration', 'Invoke-AzCdnCommitProfileToAFDMigration')) {
        Context $commandName {
            $wrapperPath = Join-Path $PSScriptRoot "../custom/$commandName.ps1"
            $parseErrors = $null
            $wrapperAst = [System.Management.Automation.Language.Parser]::ParseFile(
                $wrapperPath, [ref]$null, [ref]$parseErrors)
            if ($parseErrors) { throw $parseErrors[0] }
            $functionAst = $wrapperAst.Find({
                param($node)
                $node -is [System.Management.Automation.Language.FunctionDefinitionAst] -and
                    $node.Name -eq $commandName
            }, $true)
            $processBody = $functionAst.Body.ProcessBlock.Extent.Text.Replace(
                'Az.Cdn.internal\Invoke-AzCdnCommitProfileMigration', 'Invoke-MigrationWarningTestOperation')
            $wrapper = [scriptblock]::Create(
                '[CmdletBinding(SupportsShouldProcess)] param([switch]$PassThru, [switch]$NoWait, [switch]$AsJob) ' + $processBody)

            It 'Suppresses completion warnings and output for explicit WhatIf' {
                $warnings = @()
                $output = & $wrapper -WhatIf -WarningVariable warnings -WarningAction SilentlyContinue
                $warnings.Count | Should Be 0
                $output | Should BeNullOrEmpty
            }

            It 'Suppresses submission warnings for WhatIf with NoWait' {
                $warnings = @()
                $output = & $wrapper -WhatIf -NoWait -WarningVariable warnings -WarningAction SilentlyContinue
                $warnings.Count | Should Be 0
                $output | Should BeNullOrEmpty
            }

            It 'Suppresses submission warnings for WhatIf with AsJob' {
                $warnings = @()
                $output = & $wrapper -WhatIf -AsJob -WarningVariable warnings -WarningAction SilentlyContinue
                $warnings.Count | Should Be 0
                $output | Should BeNullOrEmpty
            }

            It 'Honors inherited WhatIfPreference' {
                $WhatIfPreference = $true
                $warnings = @()
                $output = & $wrapper -WarningVariable warnings -WarningAction SilentlyContinue
                $warnings.Count | Should Be 0
                $output | Should BeNullOrEmpty
            }

            It 'Honors explicit WhatIf false over inherited preference' {
                $WhatIfPreference = $true
                $warnings = @()
                & $wrapper -WhatIf:$false -WarningVariable warnings -WarningAction SilentlyContinue
                $warnings.Count | Should Be 1
            }

            It 'Suppresses warnings when the internal command returns without executing' {
                $script:migrationTestMode = 'Declined'
                $warnings = @()
                $output = & $wrapper -Confirm -WarningVariable warnings -WarningAction SilentlyContinue
                $warnings.Count | Should Be 0
                $output | Should BeNullOrEmpty
                $script:migrationTestParameters['Confirm'] | Should Be $true
            }

            It 'Warns once on synchronous success without adding success output' {
                $warnings = @()
                $output = & $wrapper -WarningVariable warnings -WarningAction SilentlyContinue
                $warnings.Count | Should Be 1
                $warnings[0].Message | Should Match '^Migration completed successfully\.'
                $output | Should BeNullOrEmpty
            }

            It 'Preserves PassThru output' {
                $warnings = @()
                $output = & $wrapper -PassThru -WarningVariable warnings -WarningAction SilentlyContinue
                $warnings.Count | Should Be 1
                $output | Should Be $true
            }

            It 'Preserves NoWait operation output and submission wording' {
                $warnings = @()
                $output = & $wrapper -NoWait -WarningVariable warnings -WarningAction SilentlyContinue
                $output.Kind | Should Be 'Operation'
                $warnings.Count | Should Be 1
                $warnings[0].Message | Should Match '^Migration request submitted successfully\.'
            }

            It 'Does not leak internal PassThru for immediately completed NoWait' {
                $script:migrationTestMode = 'Immediate'
                $warnings = @()
                $output = & $wrapper -NoWait -WarningVariable warnings -WarningAction SilentlyContinue
                $output | Should BeNullOrEmpty
                $warnings.Count | Should Be 1
            }

            It 'Preserves AsJob output without forcing PassThru into the job' {
                $warnings = @()
                $output = & $wrapper -AsJob -WarningVariable warnings -WarningAction SilentlyContinue
                $output.Kind | Should Be 'Job'
                $script:migrationTestParameters.ContainsKey('PassThru') | Should Be $false
                $warnings.Count | Should Be 1
                $warnings[0].Message | Should Match '^Migration request submitted successfully\.'
            }

            It 'Preserves caller PassThru when AsJob is used' {
                $output = & $wrapper -AsJob -PassThru -WarningAction SilentlyContinue
                $output.Kind | Should Be 'Job'
                $script:migrationTestParameters['PassThru'] | Should Be $true
            }

            It 'Does not warn after a terminating failure' {
                $script:migrationTestMode = 'Throw'
                $warnings = @()
                $caught = $false
                try { & $wrapper -WarningVariable warnings -WarningAction SilentlyContinue } catch { $caught = $true }
                $caught | Should Be $true
                $warnings.Count | Should Be 0
            }

            It 'Preserves nonterminating errors without emitting success guidance' {
                $script:migrationTestMode = 'Error'
                $warnings = @()
                $migrationErrors = @()
                $output = & $wrapper -ErrorAction SilentlyContinue -ErrorVariable migrationErrors -WarningVariable warnings
                $migrationErrors.Count | Should BeGreaterThan 0
                $warnings.Count | Should Be 0
                $output | Should BeNullOrEmpty
                $script:migrationTestParameters['ErrorAction'] | Should Be 'SilentlyContinue'
            }

            It 'Checks invocation status even when an error includes success-stream output' {
                $script:migrationTestMode = 'ErrorWithOutput'
                $warnings = @()
                & $wrapper -ErrorAction SilentlyContinue -WarningVariable warnings -WarningAction SilentlyContinue
                $warnings.Count | Should Be 0
            }

            It 'Preserves ErrorAction Stop' {
                $script:migrationTestMode = 'Error'
                $warnings = @()
                $caught = $false
                try { & $wrapper -ErrorAction Stop -WarningVariable warnings } catch { $caught = $true }
                $caught | Should Be $true
                $warnings.Count | Should Be 0
            }
        }
    }
}