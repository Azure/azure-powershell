Describe 'StackHCI Module Dependency Functions' {

    BeforeAll {
        $privateDll = Join-Path $PSScriptRoot '..' 'bin' 'Az.StackHCI.private.dll'
        if (Test-Path $privateDll) {
            Add-Type -Path $privateDll -ErrorAction SilentlyContinue
        }
        $customPath = Join-Path $PSScriptRoot '..' 'custom' 'stackhci.ps1'
        . $customPath

        function Write-WarnLog { param([string]$Message) }
        function Write-VerboseLog { param([string]$Message) }
    }

    # ── Import-DependentModule ────────────────────────────────────────────
    Context 'Import-DependentModule' {
        It 'Should not throw when module is already loaded with sufficient version' {
            Mock Get-Module {
                return [PSCustomObject]@{ Version = [System.Version]'3.0.0' }
            }
            { Import-DependentModule -ModuleName 'Az.Accounts' -MinVersion '2.11.2' } | Should -Not -Throw
        }

        It 'Should try to import when module is not loaded' {
            Mock Get-Module { return $null }
            Mock Remove-Module {}
            Mock Import-Module {}
            { Import-DependentModule -ModuleName 'Az.Accounts' -MinVersion '2.11.2' } | Should -Not -Throw
            Assert-MockCalled Import-Module -Times 1
        }

        It 'Should try to import when loaded version is too low' {
            Mock Get-Module {
                return [PSCustomObject]@{ Version = [System.Version]'1.0.0' }
            }
            Mock Remove-Module {}
            Mock Import-Module {}
            { Import-DependentModule -ModuleName 'Az.Accounts' -MinVersion '2.11.2' } | Should -Not -Throw
            Assert-MockCalled Import-Module -Times 1
        }

        It 'Should throw module name when import fails' {
            Mock Get-Module { return $null }
            Mock Remove-Module {}
            Mock Import-Module { throw 'Module not found' }

            { Import-DependentModule -ModuleName 'Az.FakeModule' -MinVersion '1.0.0' } | Should -Throw
        }
    }

    # ── Check-DependentModules ────────────────────────────────────────────
    Context 'Check-DependentModules' {
        It 'Should not throw when all modules are available' {
            Mock Get-Module {
                return [PSCustomObject]@{ Version = [System.Version]'99.0.0' }
            }
            { Check-DependentModules } | Should -Not -Throw
        }

        It 'Should throw with missing module names when modules are unavailable' {
            Mock Get-Module { return $null }
            Mock Remove-Module {}
            Mock Import-Module { throw 'Not found' }

            { Check-DependentModules } | Should -Throw
        }
    }

    # ── Show-LatestModuleVersion ──────────────────────────────────────────
    Context 'Show-LatestModuleVersion' {
        It 'Should not throw when Find-Module returns null' {
            Mock Find-Module { return $null }
            { Show-LatestModuleVersion 3>$null } | Should -Not -Throw
        }

        It 'Should not throw when Find-Module throws' {
            Mock Find-Module { throw 'no gallery' }
            { Show-LatestModuleVersion 3>$null } | Should -Not -Throw
        }

        It 'Should not throw when a newer module is available' {
            Mock Find-Module {
                return [PSCustomObject]@{ Version = [System.Version]'2.5.0' }
            }
            Mock Get-Module {
                return [PSCustomObject]@{ Version = [System.Version]'2.0.0' }
            }
            { Show-LatestModuleVersion 3>$null } | Should -Not -Throw
        }

        It 'Should not warn when installed version is up to date' {
            Mock Find-Module {
                return [PSCustomObject]@{ Version = [System.Version]'2.5.0' }
            }
            Mock Get-Module {
                return [PSCustomObject]@{ Version = [System.Version]'2.5.0' }
            }
            { Show-LatestModuleVersion 3>$null } | Should -Not -Throw
        }
    }
}
