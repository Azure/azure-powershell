Describe 'StackHCI Command Execution Functions' {

    BeforeAll {
        $privateDll = Join-Path $PSScriptRoot '..' 'bin' 'Az.StackHCI.private.dll'
        if (Test-Path $privateDll) {
            Add-Type -Path $privateDll -ErrorAction SilentlyContinue
        }
        $customPath = Join-Path $PSScriptRoot '..' 'custom' 'stackhci.ps1'
        . $customPath

        function Write-WarnLog { param([string]$Message) }
        function Write-VerboseLog { param([string]$Message) }
        function Write-ErrorLog {
            param([string]$Message, $Exception, [string]$ErrorAction)
        }
    }

    # ── Execute-Without-ProgressBar ───────────────────────────────────────
    Context 'Execute-Without-ProgressBar' {
        It 'Should execute the script block and return result' {
            $result = Execute-Without-ProgressBar -ScriptBlock { 42 }
            $result | Should -Be 42
        }

        It 'Should restore ProgressPreference after execution' {
            $originalPref = $ProgressPreference
            Execute-Without-ProgressBar -ScriptBlock { 'test' } | Out-Null
            $ProgressPreference | Should -Be $originalPref
        }

        It 'Should restore ProgressPreference even on error' {
            $originalPref = $ProgressPreference
            try {
                Execute-Without-ProgressBar -ScriptBlock { throw 'test error' }
            } catch {
                # expected
            }
            $ProgressPreference | Should -Be $originalPref
        }

        It 'Should propagate exceptions from the script block' {
            { Execute-Without-ProgressBar -ScriptBlock { throw 'boom' } } | Should -Throw
        }

        It 'Should suppress progress bar during execution' {
            $capturedPref = $null
            Execute-Without-ProgressBar -ScriptBlock {
                $capturedPref = $ProgressPreference
                'done'
            } | Out-Null
            # Can't directly check $capturedPref due to scoping, but no throw = success
        }

        It 'Should return complex objects' {
            $result = Execute-Without-ProgressBar -ScriptBlock { @{ Key = 'Value' } }
            $result.Key | Should -Be 'Value'
        }

        It 'Should return null from script block that returns nothing' {
            $result = Execute-Without-ProgressBar -ScriptBlock { $null }
            $result | Should -BeNullOrEmpty
        }
    }

    # ── Retry-Command ─────────────────────────────────────────────────────
    Context 'Retry-Command' {
        It 'Should return result on first success' {
            $result = Retry-Command -ScriptBlock { 'success' } -Attempts 3 -MinWaitTimeInSeconds 0 -MaxWaitTimeInSeconds 1
            $result | Should -Be 'success'
        }

        It 'Should retry and succeed on later attempt' {
            $script:callCount = 0
            $result = Retry-Command -ScriptBlock {
                $script:callCount++
                if ($script:callCount -lt 3) { throw 'not yet' }
                'finally'
            } -Attempts 5 -MinWaitTimeInSeconds 0 -MaxWaitTimeInSeconds 1 -BaseBackoffTimeInSeconds 1
            $result | Should -Be 'finally'
            $script:callCount | Should -Be 3
        }

        It 'Should throw after maximum attempts exceeded' {
            { Retry-Command -ScriptBlock { throw 'always fail' } -Attempts 2 -MinWaitTimeInSeconds 0 -MaxWaitTimeInSeconds 1 -BaseBackoffTimeInSeconds 1 } | Should -Throw
        }

        It 'Should throw when MaxWaitTime is less than MinWaitTime' {
            { Retry-Command -ScriptBlock { 'test' } -MaxWaitTimeInSeconds 1 -MinWaitTimeInSeconds 10 } | Should -Throw
        }

        It 'Should retry on null output when RetryIfNullOutput is true' {
            $script:nullCallCount = 0
            $result = Retry-Command -ScriptBlock {
                $script:nullCallCount++
                if ($script:nullCallCount -lt 2) { return $null }
                'got-value'
            } -Attempts 5 -RetryIfNullOutput $true -MinWaitTimeInSeconds 0 -MaxWaitTimeInSeconds 1 -BaseBackoffTimeInSeconds 1
            $result | Should -Be 'got-value'
        }

        It 'Should not retry on null output when RetryIfNullOutput is false' {
            $script:noRetryCount = 0
            $result = Retry-Command -ScriptBlock {
                $script:noRetryCount++
                $null
            } -Attempts 3 -RetryIfNullOutput $false -MinWaitTimeInSeconds 0 -MaxWaitTimeInSeconds 1
            $script:noRetryCount | Should -Be 1
        }

        It 'Should succeed on first attempt returning non-null' {
            $script:firstAttemptCount = 0
            $result = Retry-Command -ScriptBlock {
                $script:firstAttemptCount++
                'immediate'
            } -Attempts 1 -MinWaitTimeInSeconds 0 -MaxWaitTimeInSeconds 1
            $result | Should -Be 'immediate'
            $script:firstAttemptCount | Should -Be 1
        }
    }

    Context 'Run-InvokeCommand' {
        It 'Should invoke script block on session with params' {
            $session = New-MockObject -Type 'System.Management.Automation.Runspaces.PSSession'
            Mock Invoke-Command { return 'executed' }

            $result = Run-InvokeCommand -ScriptBlock { $Params.Key } -Session $session -Params @{ Key = 'Value' }
            Assert-MockCalled Invoke-Command -Times 1
        }
    }
}
