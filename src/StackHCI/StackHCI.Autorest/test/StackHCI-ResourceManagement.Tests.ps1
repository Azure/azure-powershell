Describe 'StackHCI Resource Management Functions' {

    BeforeAll {
        $privateDll = Join-Path $PSScriptRoot '..' 'bin' 'Az.StackHCI.private.dll'
        if (Test-Path $privateDll) {
            Add-Type -Path $privateDll -ErrorAction SilentlyContinue
        }
        $customPath = Join-Path $PSScriptRoot '..' 'custom' 'stackhci.ps1'
        . $customPath

        # Stubs for Az.Resources commands not available when only Az.StackHCI is loaded
        foreach ($cmd in @('Get-AzRoleAssignment','New-AzRoleAssignment','Remove-AzRoleAssignment','Get-AzResource','Get-AzResourceGroup','Get-AzADApplication','Get-AzResourceProvider','Register-AzResourceProvider','New-AzResourceGroup','Remove-AzResourceGroup','Invoke-AzResourceAction')) {
            if (-not (Get-Command $cmd -ErrorAction SilentlyContinue)) {
                Set-Item "function:global:$cmd" { }
            }
        }

        function Write-WarnLog { param([string]$Message) }
        function Write-VerboseLog { param([string]$Message) }
        function Write-ErrorLog {
            param([string]$Message, $Exception, [string]$ErrorAction, [string]$Category)
        }
    }

    # ── Register-ResourceProviderIfRequired ───────────────────────────────
    Context 'Register-ResourceProviderIfRequired' {
        It 'Should skip registration when all resources are already registered' {
            Mock Get-AzResourceProvider {
                return @(
                    [PSCustomObject]@{ RegistrationState = 'Registered' },
                    [PSCustomObject]@{ RegistrationState = 'Registered' }
                )
            }
            Mock Register-AzResourceProvider {}

            Register-ResourceProviderIfRequired -ProviderNamespace 'Microsoft.AzureStackHCI'

            Assert-MockCalled Register-AzResourceProvider -Times 0 -Scope It
        }

        It 'Should register when some resources are not registered' {
            Mock Get-AzResourceProvider {
                return @(
                    [PSCustomObject]@{ RegistrationState = 'Registered' },
                    [PSCustomObject]@{ RegistrationState = 'NotRegistered' }
                )
            }
            Mock Register-AzResourceProvider {}

            Register-ResourceProviderIfRequired -ProviderNamespace 'Microsoft.AzureStackHCI'

            Assert-MockCalled Register-AzResourceProvider -Times 1
        }

        It 'Should throw when registration fails' {
            Mock Get-AzResourceProvider {
                return @(
                    [PSCustomObject]@{ RegistrationState = 'NotRegistered' }
                )
            }
            Mock Register-AzResourceProvider { throw 'Registration failed' }

            { Register-ResourceProviderIfRequired -ProviderNamespace 'Microsoft.AzureStackHCI' } | Should -Throw
        }
    }

    # ── Remove-ResourceGroup ──────────────────────────────────────────────
    Context 'Remove-ResourceGroup' {
        It 'Should not throw when resource group does not exist' {
            Mock Get-AzResourceGroup { return $null }
            { Remove-ResourceGroup -ResourceGroupName 'non-existent-rg' } | Should -Not -Throw
        }

        It 'Should not delete when resource group has no tags' {
            Mock Get-AzResourceGroup {
                return [PSCustomObject]@{ Tags = $null }
            }
            Mock Remove-AzResourceGroup {}

            Remove-ResourceGroup -ResourceGroupName 'rg-no-tags'

            Assert-MockCalled Remove-AzResourceGroup -Times 0 -Scope It
        }

        It 'Should not delete when resource group was not created by Az.StackHCI' {
            Mock Get-AzResourceGroup {
                return [PSCustomObject]@{
                    Tags = @{ CreatedBy = 'SomeOtherTool' }
                }
            }
            Mock Remove-AzResourceGroup {}

            Remove-ResourceGroup -ResourceGroupName 'rg-other'

            Assert-MockCalled Remove-AzResourceGroup -Times 0 -Scope It
        }

        It 'Should delete empty resource group created by Az.StackHCI' {
            Mock Get-AzResourceGroup {
                return [PSCustomObject]@{
                    Tags = @{ CreatedBy = '4C02703C-F5D0-44B0-ADC3-4ED5C2839E61' }
                }
            }
            Mock Get-AzResource { return $null }
            Mock Remove-AzResourceGroup {}

            Remove-ResourceGroup -ResourceGroupName 'rg-hci'

            Assert-MockCalled Remove-AzResourceGroup -Times 1
        }

        It 'Should not delete non-empty resource group even if created by Az.StackHCI' {
            Mock Get-AzResourceGroup {
                return [PSCustomObject]@{
                    Tags = @{ CreatedBy = '4C02703C-F5D0-44B0-ADC3-4ED5C2839E61' }
                }
            }
            Mock Get-AzResource {
                return @([PSCustomObject]@{ Name = 'some-resource' })
            }
            Mock Remove-AzResourceGroup {}

            Remove-ResourceGroup -ResourceGroupName 'rg-hci-notempty'

            Assert-MockCalled Remove-AzResourceGroup -Times 0 -Scope It
        }

        It 'Should not throw when Remove-AzResourceGroup fails' {
            Mock Get-AzResourceGroup {
                return [PSCustomObject]@{
                    Tags = @{ CreatedBy = '4C02703C-F5D0-44B0-ADC3-4ED5C2839E61' }
                }
            }
            Mock Get-AzResource { return $null }
            Mock Remove-AzResourceGroup { throw 'Deletion failed' }

            { Remove-ResourceGroup -ResourceGroupName 'rg-fail' } | Should -Not -Throw
        }
    }
    # ── Remove-ArcRoleAssignments ─────────────────────────────────────────
    Context 'Remove-ArcRoleAssignments' {
        It 'Should not throw when cluster resource does not exist' {
            Mock Get-AzResource { return $null }
            Mock Remove-AzRoleAssignment {}

            { Remove-ArcRoleAssignments -ResourceGroupName 'rg-1' -ResourceId '/sub/rg/providers/Microsoft.AzureStackHCI/clusters/c1' } | Should -Not -Throw
        }

        It 'Should skip removal when arc resources with parentClusterResourceId exist' {
            Mock Get-AzResource {
                param($ResourceGroupName, $ResourceType, $ResourceId, $ApiVersion)
                if ($ResourceType -eq 'Microsoft.HybridCompute/machines') {
                    return @([PSCustomObject]@{ ResourceId = '/sub/rg/machines/m1' })
                }
                if ($ResourceId -and $ApiVersion -eq $HCApiVersion) {
                    return [PSCustomObject]@{
                        Properties = [PSCustomObject]@{ parentClusterResourceId = '/sub/rg/clusters/c1' }
                    }
                }
                return [PSCustomObject]@{
                    Properties = [PSCustomObject]@{ resourceProviderObjectId = 'rp-obj-1' }
                }
            }
            Mock Remove-AzRoleAssignment {}

            Remove-ArcRoleAssignments -ResourceGroupName 'rg-1' -ResourceId '/sub/rg/providers/Microsoft.AzureStackHCI/clusters/c1'

            Assert-MockCalled Remove-AzRoleAssignment -Times 0 -Scope It
        }

        It 'Should not throw on any exception' {
            Mock Get-AzResource { throw 'API error' }
            { Remove-ArcRoleAssignments -ResourceGroupName 'rg-1' -ResourceId '/sub/rg/clusters/c1' } | Should -Not -Throw
        }
    }
}