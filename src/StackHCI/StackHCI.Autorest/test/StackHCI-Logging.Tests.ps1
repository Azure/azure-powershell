Describe 'StackHCI Logging Functions' {

    BeforeAll {
        $privateDll = Join-Path $PSScriptRoot '..' 'bin' 'Az.StackHCI.private.dll'
        if (Test-Path $privateDll) {
            Add-Type -Path $privateDll -ErrorAction SilentlyContinue
        }
        $customPath = Join-Path $PSScriptRoot '..' 'custom' 'stackhci.ps1'
        . $customPath
    }

    # ── Write-Log ─────────────────────────────────────────────────────────
    Context 'Write-Log' {
        It 'Should write to log file when LogFileName is set' {
            $logFile = Join-Path $TestDrive 'test.log'
            $global:LogFileName = $logFile

            Write-Log -Level 'INFO' -Message 'Test message'

            $logFile | Should -Exist
            $content = Get-Content $logFile -Raw
            $content | Should -BeLike '*INFO*Test message*'
        }

        It 'Should include timestamp in log entry' {
            $logFile = Join-Path $TestDrive 'test-ts.log'
            $global:LogFileName = $logFile

            Write-Log -Level 'WARN' -Message 'Timestamp test'

            $content = Get-Content $logFile -Raw
            # Timestamp format: yyyy/MM/dd HH:mm:ss
            $content | Should -Match '^\d{4}/\d{2}/\d{2} \d{2}:\d{2}:\d{2}'
        }

        It 'Should default to INFO level' {
            $logFile = Join-Path $TestDrive 'test-default.log'
            $global:LogFileName = $logFile

            Write-Log -Message 'Default level test'

            $content = Get-Content $logFile -Raw
            $content | Should -BeLike '*INFO*Default level test*'
        }

        It 'Should not throw when LogFileName is null' {
            $global:LogFileName = $null
            { Write-Log -Level 'ERROR' -Message 'No file' } | Should -Not -Throw
        }

        It 'Should write ERROR level correctly' {
            $logFile = Join-Path $TestDrive 'test-error.log'
            $global:LogFileName = $logFile

            Write-Log -Level 'ERROR' -Message 'Error occurred'

            $content = Get-Content $logFile -Raw
            $content | Should -BeLike '*ERROR*Error occurred*'
        }

        It 'Should write DEBUG level correctly' {
            $logFile = Join-Path $TestDrive 'test-debug.log'
            $global:LogFileName = $logFile

            Write-Log -Level 'DEBUG' -Message 'Debug info'

            $content = Get-Content $logFile -Raw
            $content | Should -BeLike '*DEBUG*Debug info*'
        }

        It 'Should write FATAL level correctly' {
            $logFile = Join-Path $TestDrive 'test-fatal.log'
            $global:LogFileName = $logFile

            Write-Log -Level 'FATAL' -Message 'Fatal error'

            $content = Get-Content $logFile -Raw
            $content | Should -BeLike '*FATAL*Fatal error*'
        }

        AfterEach {
            $global:LogFileName = $null
        }
    }

    # ── Write-VerboseLog ──────────────────────────────────────────────────
    Context 'Write-VerboseLog' {
        It 'Should not throw' {
            $global:LogFileName = $null
            { Write-VerboseLog -Message 'Verbose test' } | Should -Not -Throw
        }

        It 'Should write to log file at DEBUG level' {
            $logFile = Join-Path $TestDrive 'verbose.log'
            $global:LogFileName = $logFile

            Write-VerboseLog -Message 'Verbose msg'

            $content = Get-Content $logFile -Raw
            $content | Should -BeLike '*DEBUG*Verbose msg*'
        }

        AfterEach {
            $global:LogFileName = $null
        }
    }

    # ── Write-InfoLog ─────────────────────────────────────────────────────
    Context 'Write-InfoLog' {
        It 'Should not throw' {
            $global:LogFileName = $null
            { Write-InfoLog -Message 'Info test' } | Should -Not -Throw
        }

        It 'Should write to log file at INFO level' {
            $logFile = Join-Path $TestDrive 'info.log'
            $global:LogFileName = $logFile

            Write-InfoLog -Message 'Info msg'

            $content = Get-Content $logFile -Raw
            $content | Should -BeLike '*INFO*Info msg*'
        }

        AfterEach {
            $global:LogFileName = $null
        }
    }

    # ── Write-WarnLog ─────────────────────────────────────────────────────
    Context 'Write-WarnLog' {
        It 'Should not throw' {
            $global:LogFileName = $null
            { Write-WarnLog -Message 'Warn test' 3>$null } | Should -Not -Throw
        }

        It 'Should write to log file at WARN level' {
            $logFile = Join-Path $TestDrive 'warn.log'
            $global:LogFileName = $logFile

            Write-WarnLog -Message 'Warn msg' 3>$null

            $content = Get-Content $logFile -Raw
            $content | Should -BeLike '*WARN*Warn msg*'
        }

        AfterEach {
            $global:LogFileName = $null
        }
    }

    # ── Write-ErrorLog ────────────────────────────────────────────────────
    Context 'Write-ErrorLog' {
        It 'Should write error to log file' {
            $logFile = Join-Path $TestDrive 'errorlog.log'
            $global:LogFileName = $logFile

            Write-ErrorLog -Message 'Test error' 2>$null

            $content = Get-Content $logFile -Raw
            $content | Should -BeLike '*ERROR*Test error*'
        }

        It 'Should not throw when called with just a message' {
            $global:LogFileName = $null
            { Write-ErrorLog -Message 'Simple error' 2>$null } | Should -Not -Throw
        }

        It 'Should add AlreadyLogged flag when Category is OperationStopped' {
            $global:LogFileName = $null
            $Error.Clear()
            Write-ErrorLog -Message 'Stopped error' -Category 'OperationStopped' 2>$null
            $Error | Should -Contain 'Already Logged'
        }

        AfterEach {
            $global:LogFileName = $null
        }
    }

    # ── Test-FolderAccess ─────────────────────────────────────────────────
    Context 'Test-FolderAccess' {
        It 'Should return true for an accessible folder' {
            $testDir = Join-Path $TestDrive 'accessible'
            New-Item -ItemType Directory -Path $testDir -Force | Out-Null
            Test-FolderAccess -folderPath $testDir | Should -Be $true
        }

        It 'Should return true when folder does not exist but can be created' {
            $testDir = Join-Path $TestDrive 'creatable'
            Test-FolderAccess -folderPath $testDir | Should -Be $true
            Test-Path $testDir | Should -Be $true
        }
    }

    # ── Setup-Logging ─────────────────────────────────────────────────────
    Context 'Setup-Logging' {
        It 'Should create log directory and set LogFileName' {
            $logDir = Join-Path $TestDrive 'logs'
            $result = Setup-Logging -LogsDirectory $logDir -LogFilePrefix 'TestLog' -DebugEnabled $false

            $result | Should -Be $logDir
            Test-Path $logDir | Should -Be $true
            $global:LogFileName | Should -BeLike '*TestLog*'
        }

        It 'Should fallback to default directory when given empty path' {
            $result = Setup-Logging -LogsDirectory '' -LogFilePrefix 'TestLog' -DebugEnabled $false
            $result | Should -Not -BeNullOrEmpty
            $global:LogFileName | Should -Not -BeNullOrEmpty
        }

        AfterEach {
            $global:LogFileName = $null
            try { Stop-Transcript -ErrorAction SilentlyContinue } catch {}
        }
    }

    # ── Tests migrated from stackhci.Tests.ps1 ───────────────────────────

    Describe 'Write-Log' {

        It 'Writes to log file when LogFileName is set' {
            $tempFile = [System.IO.Path]::GetTempFileName()
            try {
                $global:LogFileName = $tempFile
                Write-Log -Level 'INFO' -Message 'Test message'
                $content = Get-Content $tempFile -Raw
                $content | Should -BeLike '*INFO*Test message*'
            } finally {
                $global:LogFileName = $null
                Remove-Item $tempFile -Force -ErrorAction SilentlyContinue
            }
        }

        It 'Does not throw when LogFileName is null' {
            $global:LogFileName = $null
            { Write-Log -Level 'WARN' -Message 'No file' } | Should -Not -Throw
        }

        It 'Writes correct log level' {
            $tempFile = [System.IO.Path]::GetTempFileName()
            try {
                $global:LogFileName = $tempFile
                Write-Log -Level 'ERROR' -Message 'Error occurred'
                $content = Get-Content $tempFile -Raw
                $content | Should -BeLike '*ERROR*Error occurred*'
            } finally {
                $global:LogFileName = $null
                Remove-Item $tempFile -Force -ErrorAction SilentlyContinue
            }
        }

        It 'Defaults to INFO level' {
            $tempFile = [System.IO.Path]::GetTempFileName()
            try {
                $global:LogFileName = $tempFile
                Write-Log -Message 'Default level'
                $content = Get-Content $tempFile -Raw
                $content | Should -BeLike '*INFO*Default level*'
            } finally {
                $global:LogFileName = $null
                Remove-Item $tempFile -Force -ErrorAction SilentlyContinue
            }
        }
    }

    Describe 'Write-ErrorLog' {

        It 'Writes error to log file' {
            $tempFile = [System.IO.Path]::GetTempFileName()
            try {
                $global:LogFileName = $tempFile
                # Redirect error output to avoid console noise
                Write-ErrorLog -Message 'Test error message' 2>$null
                $content = Get-Content $tempFile -Raw
                $content | Should -BeLike '*ERROR*Test error message*'
            } finally {
                $global:LogFileName = $null
                Remove-Item $tempFile -Force -ErrorAction SilentlyContinue
            }
        }

        It 'Adds AlreadyLogged flag when Category is OperationStopped' {
            $tempFile = [System.IO.Path]::GetTempFileName()
            try {
                $global:LogFileName = $tempFile
                $Error.Clear()
                Write-ErrorLog -Message 'Stopped error' -Category 'OperationStopped' 2>$null
                $Error | Should -Contain 'Already Logged'
            } finally {
                $global:LogFileName = $null
                Remove-Item $tempFile -Force -ErrorAction SilentlyContinue
            }
        }
    }

    Describe 'Setup-Logging' {

        It 'Creates log directory and sets LogFileName' {
            $tempDir = Join-Path ([System.IO.Path]::GetTempPath()) ("SetupLog_" + [guid]::NewGuid().ToString('N'))
            try {
                $result = Setup-Logging -LogsDirectory $tempDir -LogFilePrefix 'TestLog' -DebugEnabled $false
                $result | Should -Be $tempDir
                Test-Path $tempDir | Should -Be $true
                $global:LogFileName | Should -BeLike "$tempDir*TestLog_*.log"
            } finally {
                $global:LogFileName = $null
                Remove-Item $tempDir -Recurse -Force -ErrorAction SilentlyContinue
            }
        }

        It 'Falls back to default directory when given empty LogsDirectory' {
            $global:LogFileName = $null
            $result = Setup-Logging -LogsDirectory '' -LogFilePrefix 'TestLog' -DebugEnabled $false
            $result | Should -Not -BeNullOrEmpty
            $global:LogFileName | Should -Not -BeNullOrEmpty
            $global:LogFileName = $null
        }
    }
}
