Describe 'StackHCI Remote Support Functions' {

    BeforeAll {
        $privateDll = Join-Path $PSScriptRoot '..' 'bin' 'Az.StackHCI.private.dll'
        if (Test-Path $privateDll) {
            Add-Type -Path $privateDll -ErrorAction SilentlyContinue
        }
        $customPath = Join-Path $PSScriptRoot '..' 'custom' 'stackhci.ps1'
        . $customPath

        # Stub for Windows-only commands not available on Linux/macOS
        if (-not (Get-Command 'Get-Service' -ErrorAction SilentlyContinue)) {
            function global:Get-Service { }
        }

        # Ensure $env:Temp is set (it's null on Linux/macOS)
        if ([string]::IsNullOrEmpty($env:Temp)) {
            $env:Temp = [System.IO.Path]::GetTempPath()
        }

        function Write-WarnLog { param([string]$Message) }
        function Write-VerboseLog { param([string]$Message) }
        function Write-InfoLog { param([string]$Message) }
        function Write-ErrorLog { param([string]$Message, $Exception, $Category, $ErrorAction) }
    }

    Context 'Assert-IsObservabilityStackPresent' {
        It 'Should return true when RemoteSupportAgent service exists' {
            Mock Get-SetupLoggingDetails {
                return @($null, $false, $null, $null)
            }
            Mock Setup-Logging { }
            Mock Remove-PSSession { }
            Mock Get-Service {
                return [PSCustomObject]@{ Name = 'RemoteSupportAgent'; Status = 'Running' }
            }

            $result = Assert-IsObservabilityStackPresent
            $result | Should -Be $true
        }

        It 'Should return false when RemoteSupportAgent service does not exist' {
            Mock Get-SetupLoggingDetails {
                return @($null, $false, $null, $null)
            }
            Mock Setup-Logging { }
            Mock Remove-PSSession { }
            Mock Get-Service { return $null }

            $result = Assert-IsObservabilityStackPresent
            $result | Should -Be $false
        }

        It 'Should return false when Get-Service throws' {
            Mock Get-SetupLoggingDetails {
                return @($null, $false, $null, $null)
            }
            Mock Setup-Logging { }
            Mock Remove-PSSession { }
            Mock Get-Service { throw 'Service error' }

            $result = Assert-IsObservabilityStackPresent
            $result | Should -Be $false
        }
    }

    Context 'Install-DeployModule' {
        It 'Should skip download when module is already loaded' {
            Mock Get-SetupLoggingDetails {
                return @($null, $false, $null, $null)
            }
            Mock Setup-Logging { }
            Mock Remove-PSSession { }
            Mock Get-Module {
                return [PSCustomObject]@{ Name = 'Microsoft.AzureStack.Deployment.RemoteSupport' }
            }
            Mock Invoke-DeploymentModuleDownload { }
            Mock Import-Module { }

            Install-DeployModule -ModuleName 'Microsoft.AzureStack.Deployment.RemoteSupport'

            Assert-MockCalled Invoke-DeploymentModuleDownload -Times 0 -Scope It
        }

        It 'Should download module when not loaded' {
            Mock Get-SetupLoggingDetails {
                return @($null, $false, $null, $null)
            }
            Mock Setup-Logging { }
            Mock Remove-PSSession { }
            Mock Get-Module { return $null }
            Mock Invoke-DeploymentModuleDownload { }
            Mock Import-Module { }

            Install-DeployModule -ModuleName 'Microsoft.AzureStack.Deployment.RemoteSupport'

            Assert-MockCalled Invoke-DeploymentModuleDownload -Times 1
        }
    }

    Context 'Invoke-DeploymentModuleDownload' {
        It 'Should call Invoke-WebRequest to download module' {
            Mock New-Directory { }
            Mock Invoke-WebRequest { }
            Mock Write-Progress { }
            Mock Get-SetupLoggingDetails {
                return @($null, $false, $null, @{})
            }
            Mock Setup-Logging { return $TestDrive }
            Mock Remove-PSSession { }
            Mock Retry-Command {
                param($ScriptBlock)
                Invoke-Command -ScriptBlock $ScriptBlock
            }

            Invoke-DeploymentModuleDownload

            Assert-MockCalled Invoke-WebRequest -Times 1
        }
    }

    Context 'New-Directory' {
        It 'Should create directory when it does not exist' {
            $testDir = Join-Path $TestDrive 'newdir'
            Mock Write-Progress { }

            New-Directory -Path $testDir
            Test-Path $testDir | Should -Be $true
        }

        It 'Should not fail when directory already exists' {
            $testDir = Join-Path $TestDrive 'existingdir'
            New-Item -ItemType Directory -Path $testDir -Force | Out-Null
            Mock Write-Progress { }

            { New-Directory -Path $testDir } | Should -Not -Throw
        }
    }

    Context 'Install-AzStackHCIRemoteSupport' {
        It 'Should skip install when observability stack is present' {
            Mock Get-SetupLoggingDetails {
                return @([PSCustomObject]@{ RegistrationStatus = 'Registered' }, $true, $null, @{})
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS { }
            Mock Setup-Logging { }
            Mock Remove-PSSession { }
            Mock Get-ItemProperty { return [PSCustomObject]@{ InstallType = 'ArcExtension' } }
            Mock Assert-IsObservabilityStackPresent { return $true }

            Install-AzStackHCIRemoteSupport

            Assert-MockCalled Assert-IsObservabilityStackPresent -Times 1
        }

        It 'Should call Install-DeployModule when observability stack is not present and not ArcExtension' {
            Mock Get-SetupLoggingDetails {
                return @([PSCustomObject]@{ RegistrationStatus = 'Registered' }, $true, $null, @{})
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS { }
            Mock Setup-Logging { }
            Mock Remove-PSSession { }
            Mock Get-ItemProperty { return $null }
            Mock Assert-IsObservabilityStackPresent { return $false }
            Mock Install-DeployModule { }
            # Mock the module-qualified call
            function Microsoft.AzureStack.Deployment.RemoteSupport\Install-RemoteSupport { }
            Mock Microsoft.AzureStack.Deployment.RemoteSupport\Install-RemoteSupport { }

            Install-AzStackHCIRemoteSupport

            Assert-MockCalled Install-DeployModule -Times 1
        }

        It 'Should have SupportsShouldProcess attribute' {
            $cmd = Get-Command Install-AzStackHCIRemoteSupport
            $cmd.Parameters.Keys | Should -Contain 'WhatIf'
        }
    }

    Context 'Remove-AzStackHCIRemoteSupport' {
        It 'Should skip removal when observability stack is present' {
            Mock Get-SetupLoggingDetails {
                return @([PSCustomObject]@{ RegistrationStatus = 'Registered' }, $true, $null, @{})
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS { }
            Mock Setup-Logging { }
            Mock Remove-PSSession { }
            Mock Get-ItemProperty { return [PSCustomObject]@{ InstallType = 'ArcExtension' } }
            Mock Assert-IsObservabilityStackPresent { return $true }

            Remove-AzStackHCIRemoteSupport

            Assert-MockCalled Assert-IsObservabilityStackPresent -Times 1
        }

        It 'Should call Install-DeployModule when observability stack is not present' {
            Mock Get-SetupLoggingDetails {
                return @([PSCustomObject]@{ RegistrationStatus = 'Registered' }, $true, $null, @{})
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS { }
            Mock Setup-Logging { }
            Mock Remove-PSSession { }
            Mock Get-ItemProperty { return $null }
            Mock Assert-IsObservabilityStackPresent { return $false }
            Mock Install-DeployModule { }
            function Microsoft.AzureStack.Deployment.RemoteSupport\Remove-RemoteSupport { }
            Mock Microsoft.AzureStack.Deployment.RemoteSupport\Remove-RemoteSupport { }

            Remove-AzStackHCIRemoteSupport

            Assert-MockCalled Install-DeployModule -Times 1
        }
    }

    Context 'Enable-AzStackHCIRemoteSupport' {
        It 'Should call Enable-RemoteSupport via DiagnosticsInitializer when observability stack is present' {
            Mock Get-SetupLoggingDetails {
                return @($null, $false, $null, @{})
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS { }
            Mock Get-ItemProperty { return [PSCustomObject]@{ InstallType = 'ArcExtension' } }
            Mock Assert-IsObservabilityStackPresent { return $true }
            Mock Import-Module { }
            function Enable-RemoteSupport { param($AccessLevel, $ExpireInMinutes, $SasCredential, [switch]$AgreeToRemoteSupportConsent) }
            Mock Enable-RemoteSupport { }

            Enable-AzStackHCIRemoteSupport -AccessLevel 'Diagnostics' -AgreeToRemoteSupportConsent

            Assert-MockCalled Import-Module -Times 1 -ParameterFilter { $Name -eq 'DiagnosticsInitializer' }
            Assert-MockCalled Enable-RemoteSupport -Times 1
        }

        It 'Should have required AccessLevel parameter' {
            $cmd = Get-Command Enable-AzStackHCIRemoteSupport
            $cmd.Parameters.Keys | Should -Contain 'AccessLevel'
            $cmd.Parameters.Keys | Should -Contain 'ExpireInMinutes'
            $cmd.Parameters.Keys | Should -Contain 'SasCredential'
            $cmd.Parameters.Keys | Should -Contain 'AgreeToRemoteSupportConsent'
        }

        It 'Should call Install-DeployModule when observability stack is not present' {
            Mock Get-SetupLoggingDetails {
                return @($null, $false, $null, @{})
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS { }
            Mock Get-ItemProperty { return $null }
            Mock Assert-IsObservabilityStackPresent { return $false }
            Mock Install-DeployModule { }
            function Microsoft.AzureStack.Deployment.RemoteSupport\Enable-RemoteSupport { param($AccessLevel, $ExpireInMinutes, $SasCredential, [switch]$AgreeToRemoteSupportConsent) }
            Mock Microsoft.AzureStack.Deployment.RemoteSupport\Enable-RemoteSupport { }

            Enable-AzStackHCIRemoteSupport -AccessLevel 'Diagnostics' -AgreeToRemoteSupportConsent

            Assert-MockCalled Install-DeployModule -Times 1
        }
    }

    Context 'Disable-AzStackHCIRemoteSupport' {
        It 'Should call Disable-RemoteSupport via DiagnosticsInitializer when observability stack is present' {
            Mock Get-SetupLoggingDetails {
                return @($null, $false, $null, @{})
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS { }
            Mock Get-ItemProperty { return [PSCustomObject]@{ InstallType = 'ArcExtension' } }
            Mock Assert-IsObservabilityStackPresent { return $true }
            Mock Import-Module { }
            function Disable-RemoteSupport { }
            Mock Disable-RemoteSupport { }

            Disable-AzStackHCIRemoteSupport

            Assert-MockCalled Import-Module -Times 1 -ParameterFilter { $Name -eq 'DiagnosticsInitializer' }
            Assert-MockCalled Disable-RemoteSupport -Times 1
        }

        It 'Should call Install-DeployModule when observability stack is not present' {
            Mock Get-SetupLoggingDetails {
                return @($null, $false, $null, @{})
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS { }
            Mock Get-ItemProperty { return $null }
            Mock Assert-IsObservabilityStackPresent { return $false }
            Mock Install-DeployModule { }
            function Microsoft.AzureStack.Deployment.RemoteSupport\Disable-RemoteSupport { }
            Mock Microsoft.AzureStack.Deployment.RemoteSupport\Disable-RemoteSupport { }

            Disable-AzStackHCIRemoteSupport

            Assert-MockCalled Install-DeployModule -Times 1
        }
    }

    Context 'Get-AzStackHCIRemoteSupportAccess' {
        It 'Should call Get-RemoteSupportAccess via DiagnosticsInitializer when observability stack is present' {
            Mock Get-SetupLoggingDetails {
                return @($null, $false, $null, @{})
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS { }
            Mock Get-ItemProperty { return [PSCustomObject]@{ InstallType = 'ArcExtension' } }
            Mock Assert-IsObservabilityStackPresent { return $true }
            Mock Import-Module { }
            function Get-RemoteSupportAccess { param([switch]$IncludeExpired, [switch]$Cluster) }
            Mock Get-RemoteSupportAccess { return @([PSCustomObject]@{ AccessLevel = 'Diagnostics' }) }

            $result = Get-AzStackHCIRemoteSupportAccess

            Assert-MockCalled Import-Module -Times 1 -ParameterFilter { $Name -eq 'DiagnosticsInitializer' }
            Assert-MockCalled Get-RemoteSupportAccess -Times 1
        }

        It 'Should have Cluster and IncludeExpired parameters' {
            $cmd = Get-Command Get-AzStackHCIRemoteSupportAccess
            $cmd.Parameters.Keys | Should -Contain 'Cluster'
            $cmd.Parameters.Keys | Should -Contain 'IncludeExpired'
        }
    }

    Context 'Get-AzStackHCIRemoteSupportSessionHistory' {
        It 'Should call Get-RemoteSupportSessionHistory via DiagnosticsInitializer when observability stack is present' {
            Mock Get-SetupLoggingDetails {
                return @($null, $false, $null, @{})
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS { }
            Mock Get-ItemProperty { return [PSCustomObject]@{ InstallType = 'ArcExtension' } }
            Mock Assert-IsObservabilityStackPresent { return $true }
            Mock Import-Module { }
            function Get-RemoteSupportSessionHistory { param($SessionId, $FromDate, [switch]$IncludeSessionTranscript) }
            Mock Get-RemoteSupportSessionHistory { return @([PSCustomObject]@{ SessionId = 'sess-123' }) }

            $result = Get-AzStackHCIRemoteSupportSessionHistory

            Assert-MockCalled Import-Module -Times 1 -ParameterFilter { $Name -eq 'DiagnosticsInitializer' }
            Assert-MockCalled Get-RemoteSupportSessionHistory -Times 1
        }

        It 'Should have SessionId, IncludeSessionTranscript, and FromDate parameters' {
            $cmd = Get-Command Get-AzStackHCIRemoteSupportSessionHistory
            $cmd.Parameters.Keys | Should -Contain 'SessionId'
            $cmd.Parameters.Keys | Should -Contain 'IncludeSessionTranscript'
            $cmd.Parameters.Keys | Should -Contain 'FromDate'
        }
    }

    Context 'Get-AzStackHCILogsDirectory' {
        It 'Should return logs directory path from helper' {
            $mockSession = New-MockObject -Type 'System.Management.Automation.Runspaces.PSSession'
            Mock New-PSSession { return $mockSession }
            Mock Confirm-UserAcknowledgmentToUpgradeOS { }
            Mock Get-LogsDirectoryHelper { return 'C:\ProgramData\AzureStackHCI' }
            Mock Remove-PSSession { }

            $result = Get-AzStackHCILogsDirectory 6>&1
            $result | Should -BeLike '*C:\ProgramData\AzureStackHCI*'
        }

        It 'Should fallback to PWD when helper returns empty' {
            $mockSession = New-MockObject -Type 'System.Management.Automation.Runspaces.PSSession'
            Mock New-PSSession { return $mockSession }
            Mock Confirm-UserAcknowledgmentToUpgradeOS { }
            Mock Get-LogsDirectoryHelper { return '' }
            Mock Remove-PSSession { }

            $result = Get-AzStackHCILogsDirectory 6>&1
            $result | Should -BeLike '*Logs directory*'
        }

        It 'Should have SupportsShouldProcess and expected parameters' {
            $cmd = Get-Command Get-AzStackHCILogsDirectory
            $cmd.Parameters.Keys | Should -Contain 'Credential'
            $cmd.Parameters.Keys | Should -Contain 'ComputerName'
            $cmd.Parameters.Keys | Should -Contain 'WhatIf'
        }
    }

    Context 'Get-SetupLoggingDetails' {
        It 'Should return registration context for local node with newSession false' {
            # When newSession is false, it calls Get-AzureStackHCI directly (no PSSession)
            function Get-AzureStackHCI { return [PSCustomObject]@{ RegistrationStatus = 'Registered' } }

            $regContext, $isRegistered, $session, $params = Get-SetupLoggingDetails -newSession $false

            $regContext.RegistrationStatus | Should -Be 'Registered'
            $isRegistered | Should -Be $true
            $session | Should -Be $null
        }

        It 'Should create PSSession when newSession is true' {
            $mockSession = New-MockObject -Type 'System.Management.Automation.Runspaces.PSSession'
            Mock New-PSSession { return $mockSession }
            Mock Invoke-Command {
                return [PSCustomObject]@{ RegistrationStatus = 'NotYet' }
            }

            $regContext, $isRegistered, $session, $params = Get-SetupLoggingDetails -newSession $true

            $isRegistered | Should -Be $false
            Assert-MockCalled New-PSSession -Times 1
        }

        It 'Should add ComputerName to params when isManagementNode is true' {
            $mockSession = New-MockObject -Type 'System.Management.Automation.Runspaces.PSSession'
            Mock New-PSSession { return $mockSession }
            Mock Invoke-Command {
                return [PSCustomObject]@{ RegistrationStatus = 'Registered' }
            }
            Mock Test-ComputerNameHasDnsSuffix { return $true }

            $regContext, $isRegistered, $session, $params = Get-SetupLoggingDetails -ComputerName 'node1.contoso.local' -isManagementNode $true -newSession $true

            $params['ComputerName'] | Should -Be 'node1.contoso.local'
        }

        It 'Should append DNS suffix when ComputerName is not FQDN' {
            $mockSession = New-MockObject -Type 'System.Management.Automation.Runspaces.PSSession'
            Mock New-PSSession { return $mockSession }
            Mock Invoke-Command {
                return [PSCustomObject]@{ RegistrationStatus = 'Registered' }
            }
            Mock Test-ComputerNameHasDnsSuffix { return $false }
            Mock Get-ItemProperty { return [PSCustomObject]@{ Domain = 'contoso.local' } }

            $regContext, $isRegistered, $session, $params = Get-SetupLoggingDetails -ComputerName 'node1' -isManagementNode $true -newSession $true

            $params['ComputerName'] | Should -Be 'node1.contoso.local'
        }
    }
}
