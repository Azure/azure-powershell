Describe 'StackHCI Attestation Functions' {

    BeforeAll {
        $privateDll = Join-Path $PSScriptRoot '..' 'bin' 'Az.StackHCI.private.dll'
        if (Test-Path $privateDll) {
            Add-Type -Path $privateDll -ErrorAction SilentlyContinue
        }
        $customPath = Join-Path $PSScriptRoot '..' 'custom' 'stackhci.ps1'
        . $customPath

        function Write-WarnLog { param([string]$Message) }
        function Write-VerboseLog { param([string]$Message) }
        function Write-InfoLog { param([string]$Message) }
        function Write-ErrorLog { param([string]$Message, $Exception, $Category, $ErrorAction) }
    }

    Context 'IsAttestationV2Supported' {
        It 'Should return true when LegacyOsSupport property exists' {
            Mock Invoke-Command {
                return $true
            }

            $result = IsAttestationV2Supported -SessionParams @{ ErrorAction = 'Stop' }
            $result | Should -Be $true
        }

        It 'Should return false when LegacyOsSupport property does not exist' {
            Mock Invoke-Command {
                return $false
            }

            $result = IsAttestationV2Supported -SessionParams @{ ErrorAction = 'Stop' }
            $result | Should -Be $false
        }
    }

    Context 'IsAttestedDataLegacyOsSupportEnabled' {
        It 'Should return result from Invoke-Command' {
            Mock Invoke-Command {
                return $true
            }

            $result = IsAttestedDataLegacyOsSupportEnabled -SessionParams @{ ErrorAction = 'Stop' }
            $result | Should -Be $true
        }

        It 'Should return false when attestation is not enabled' {
            Mock Invoke-Command {
                return $false
            }

            $result = IsAttestedDataLegacyOsSupportEnabled -SessionParams @{ ErrorAction = 'Stop' }
            $result | Should -Be $false
        }
    }

    Context 'Set-AttestationFirewallRules' {
        It 'Should call Invoke-Command with Enabled parameter' {
            Mock Invoke-Command { }

            Set-AttestationFirewallRules -Enabled $true -SessionParams @{ ErrorAction = 'Stop' }
            Assert-MockCalled Invoke-Command -Times 1
        }

        It 'Should call Invoke-Command with Disabled parameter' {
            Mock Invoke-Command { }

            Set-AttestationFirewallRules -Enabled $false -SessionParams @{ ErrorAction = 'Stop' }
            Assert-MockCalled Invoke-Command -Times 1
        }
    }

    Context 'Add-VMDevicesForImds' {
        It 'Should call Invoke-Command and return adapter' {
            $mockReturn = @{ Return = [PSCustomObject]@{ Name = 'TestAdapter' }; Exception = $null }
            Mock Invoke-Command { return $mockReturn }

            $vmAdapterParams = @{ VM = 'vm1'; Name = 'YOURSWITCH'; VMSwitch = 'switch1' }
            $vmAdapterAdditionalParams = @{ MacAddressSpoofing = 'On' }
            $vmAdapterVlanParams = @{ Isolated = $true; PrimaryVlanId = 10; SecondaryVlanId = 200 }
            $sessionParams = @{ ErrorAction = 'Stop' }

            $result = Add-VMDevicesForImds -VmAdapterParams $vmAdapterParams `
                -VmAdapterAdditionalParams $vmAdapterAdditionalParams `
                -VmAdapterVlanParams $vmAdapterVlanParams -SessionParams $sessionParams

            $result.Name | Should -Be 'TestAdapter'
        }

        It 'Should throw when Invoke-Command returns an exception' {
            $mockReturn = @{ Return = $null; Exception = [System.Exception]::new('VM config failed') }
            Mock Invoke-Command { return $mockReturn }

            $vmAdapterParams = @{ VM = 'vm1'; Name = 'YOURSWITCH'; VMSwitch = 'switch1' }
            $sessionParams = @{ ErrorAction = 'Stop' }

            { Add-VMDevicesForImds -VmAdapterParams $vmAdapterParams `
                -VmAdapterAdditionalParams @{} `
                -VmAdapterVlanParams @{} -SessionParams $sessionParams } | Should -Throw
        }
    }

    Context 'Add-HostDevicesForImds' {
        It 'Should call Invoke-Command and return switch Id' {
            $mockReturn = @{ Return = 'switch-guid-123'; Exception = $null }
            Mock Invoke-Command { return $mockReturn }

            $vmSwitchParams = @{ Name = 'IMDS'; SwitchType = 'Internal'; SwitchId = $null }
            $hostAdapterVlanParams = @{ Promiscuous = $true; PrimaryVlanId = 10 }
            $netAdapterIpParams = @{ IPAddress = '169.254.169.253'; PrefixLength = 16 }
            $sessionParams = @{ ErrorAction = 'Stop' }

            $result = Add-HostDevicesForImds -VmSwitchParams $vmSwitchParams `
                -HostAdapterVlanParams $hostAdapterVlanParams `
                -NetAdapterIpParams $netAdapterIpParams -SessionParams $sessionParams

            $result | Should -Be 'switch-guid-123'
        }

        It 'Should throw when Invoke-Command returns an exception' {
            $mockReturn = @{ Return = $null; Exception = [System.Exception]::new('Switch config failed') }
            Mock Invoke-Command { return $mockReturn }

            $vmSwitchParams = @{ Name = 'IMDS'; SwitchType = 'Internal' }
            $sessionParams = @{ ErrorAction = 'Stop' }

            { Add-HostDevicesForImds -VmSwitchParams $vmSwitchParams `
                -HostAdapterVlanParams @{} `
                -NetAdapterIpParams @{} -SessionParams $sessionParams } | Should -Throw
        }
    }

    Context 'Enable-AzStackHCIAttestation' {
        It 'Should throw when cluster is not registered' {
            Mock Get-SetupLoggingDetails {
                return @($null, $false, $null, @{})
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS { }
            Mock Write-Progress { }
            Mock IsAttestationV2Supported { return $false }
            Mock Invoke-Command {
                return [PSCustomObject]@{ RegistrationStatus = 'NotYet' }
            }

            { Enable-AzStackHCIAttestation -Force } | Should -Throw
        }

        It 'Should have SupportsShouldProcess attribute' {
            $cmd = Get-Command Enable-AzStackHCIAttestation
            $cmd.Parameters.Keys | Should -Contain 'WhatIf'
            $cmd.Parameters.Keys | Should -Contain 'Confirm'
        }

        It 'Should have expected parameters' {
            $cmd = Get-Command Enable-AzStackHCIAttestation
            $cmd.Parameters.Keys | Should -Contain 'ComputerName'
            $cmd.Parameters.Keys | Should -Contain 'Credential'
            $cmd.Parameters.Keys | Should -Contain 'AddVM'
            $cmd.Parameters.Keys | Should -Contain 'Force'
        }
    }

    Context 'Disable-AzStackHCIAttestation' {
        It 'Should have SupportsShouldProcess attribute' {
            $cmd = Get-Command Disable-AzStackHCIAttestation
            $cmd.Parameters.Keys | Should -Contain 'WhatIf'
            $cmd.Parameters.Keys | Should -Contain 'Confirm'
        }

        It 'Should have expected parameters' {
            $cmd = Get-Command Disable-AzStackHCIAttestation
            $cmd.Parameters.Keys | Should -Contain 'ComputerName'
            $cmd.Parameters.Keys | Should -Contain 'Credential'
            $cmd.Parameters.Keys | Should -Contain 'RemoveVM'
            $cmd.Parameters.Keys | Should -Contain 'Force'
        }

        It 'Should call Get-SetupLoggingDetails on invocation' {
            Mock Get-SetupLoggingDetails {
                return @($null, $false, $null, @{})
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS { }
            Mock Write-Progress { }
            Mock IsAttestationV2Supported { return $false }
            Mock Invoke-Command {
                return [PSCustomObject]@{ Name = 'TestCluster' }
            } -ParameterFilter { $ScriptBlock -ne $null }
            Mock Invoke-Command {
                return @([PSCustomObject]@{ Name = 'Node1'; State = 'Up' })
            }

            # Should complete the begin block at least (we're just verifying it calls the setup)
            try { Disable-AzStackHCIAttestation -Force -ErrorAction SilentlyContinue } catch { }
            Assert-MockCalled Get-SetupLoggingDetails -Times 1
        }
    }

    Context 'Add-AzStackHCIVMAttestation' {
        It 'Should throw when cluster is not registered' {
            Mock Get-SetupLoggingDetails {
                return @($null, $false, $null, @{})
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS { }
            Mock IsAttestationV2Supported { return $false }
            Mock IsAttestedDataLegacyOsSupportEnabled { return $true }
            Mock Write-Progress { }
            Mock Invoke-Command {
                return [PSCustomObject]@{ RegistrationStatus = 'NotYet' }
            }

            { Add-AzStackHCIVMAttestation -AddAll -Force } | Should -Throw
        }

        It 'Should have VMName, VM, and AddAll parameter sets' {
            $cmd = Get-Command Add-AzStackHCIVMAttestation
            $cmd.ParameterSets.Name | Should -Contain 'VMName'
            $cmd.ParameterSets.Name | Should -Contain 'VMObject'
            $cmd.ParameterSets.Name | Should -Contain 'AddAll'
        }

        It 'Should have expected parameters' {
            $cmd = Get-Command Add-AzStackHCIVMAttestation
            $cmd.Parameters.Keys | Should -Contain 'VMName'
            $cmd.Parameters.Keys | Should -Contain 'VM'
            $cmd.Parameters.Keys | Should -Contain 'AddAll'
            $cmd.Parameters.Keys | Should -Contain 'Force'
        }
    }

    Context 'Remove-AzStackHCIVMAttestation' {
        It 'Should have VMName, VM, and RemoveAll parameter sets' {
            $cmd = Get-Command Remove-AzStackHCIVMAttestation
            $cmd.ParameterSets.Name | Should -Contain 'VMName'
            $cmd.ParameterSets.Name | Should -Contain 'VMObject'
            $cmd.ParameterSets.Name | Should -Contain 'RemoveAll'
        }

        It 'Should have expected parameters' {
            $cmd = Get-Command Remove-AzStackHCIVMAttestation
            $cmd.Parameters.Keys | Should -Contain 'VMName'
            $cmd.Parameters.Keys | Should -Contain 'VM'
            $cmd.Parameters.Keys | Should -Contain 'RemoveAll'
            $cmd.Parameters.Keys | Should -Contain 'Force'
        }

        It 'Should call Get-SetupLoggingDetails on invocation' {
            Mock Get-SetupLoggingDetails {
                return @($null, $false, $null, @{})
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS { }
            Mock IsAttestationV2Supported { return $false }
            Mock IsAttestedDataLegacyOsSupportEnabled { return $true }
            Mock Write-Progress { }
            Mock Invoke-Command { return $null }

            try { Remove-AzStackHCIVMAttestation -RemoveAll -Force -ErrorAction SilentlyContinue } catch { }
            Assert-MockCalled Get-SetupLoggingDetails -Times 1
        }
    }

    Context 'Get-AzStackHCIVMAttestation' {
        It 'Should have Local switch parameter' {
            $cmd = Get-Command Get-AzStackHCIVMAttestation
            $cmd.Parameters.Keys | Should -Contain 'Local'
            $cmd.Parameters['Local'].SwitchParameter | Should -Be $true
        }

        It 'Should call Get-SetupLoggingDetails on invocation' {
            Mock Get-SetupLoggingDetails {
                return @($null, $false, $null, @{})
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS { }
            Mock Write-Progress { }
            Mock Invoke-Command { return @() }

            try { Get-AzStackHCIVMAttestation -Local -ErrorAction SilentlyContinue } catch { }
            Assert-MockCalled Get-SetupLoggingDetails -Times 1
        }
    }
}
