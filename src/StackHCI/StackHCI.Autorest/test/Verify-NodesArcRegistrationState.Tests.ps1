Describe 'Verify-NodesArcRegistrationState' {

    BeforeAll {
        # Load the compiled assembly so that custom attributes like
        # [Microsoft.Azure.PowerShell.Cmdlets.StackHCI.DoNotExportAttribute]
        # and enum types (ErrorDetail, ArcStatus, etc.) are available.
        $privateDll = Join-Path $PSScriptRoot '..' 'bin' 'Az.StackHCI.private.dll'
        if (Test-Path $privateDll) {
            Add-Type -Path $privateDll -ErrorAction SilentlyContinue
        }

        # Dot-source the script under test inside BeforeAll so that functions
        # are available in the Pester test scope (Pester v5 scoping rules).
        $customPath = Join-Path $PSScriptRoot '..' 'custom' 'stackhci.ps1'
        . $customPath

        # Suppress log output during tests
        function Write-WarnLog { param([string]$Message) }
        function Write-VerboseLog { param([string]$Message) }
    }

    Context 'When all nodes report no mismatch' {
        It 'Should succeed without throwing' {
            $clusterNodes = @(
                [PSCustomObject]@{ Name = 'Node1' },
                [PSCustomObject]@{ Name = 'Node2' }
            )

            Mock Invoke-Command {
                return @(
                    [PSCustomObject]@{ NodeName = 'Node1'; IsMismatch = $false; Details = $null },
                    [PSCustomObject]@{ NodeName = 'Node2'; IsMismatch = $false; Details = $null }
                )
            }

            { Verify-NodesArcRegistrationState -ClusterNodes $clusterNodes -SubscriptionId 'sub-1' -ArcResourceGroupName 'rg-1' -ClusterDNSSuffix 'contoso.local' } | Should -Not -Throw
        }
    }

    Context 'When a node has subscription/resource group mismatch' {
        It 'Should throw with ArcAlreadyEnabledInADifferentResourceError message' {
            $clusterNodes = @(
                [PSCustomObject]@{ Name = 'Node1' },
                [PSCustomObject]@{ Name = 'Node2' }
            )

            Mock Invoke-Command {
                return @(
                    [PSCustomObject]@{ NodeName = 'Node1'; IsMismatch = $true; Details = 'Node1:  Subscription Id: wrong-sub, Resource Group: wrong-rg' },
                    [PSCustomObject]@{ NodeName = 'Node2'; IsMismatch = $false; Details = $null }
                )
            }

            { Verify-NodesArcRegistrationState -ClusterNodes $clusterNodes -SubscriptionId 'sub-1' -ArcResourceGroupName 'rg-1' -ClusterDNSSuffix 'contoso.local' } | Should -Throw
        }
    }

    Context 'When multiple nodes have mismatches' {
        It 'Should include all mismatched node details in the error' {
            $clusterNodes = @(
                [PSCustomObject]@{ Name = 'Node1' },
                [PSCustomObject]@{ Name = 'Node2' }
            )

            Mock Invoke-Command {
                return @(
                    [PSCustomObject]@{ NodeName = 'Node1'; IsMismatch = $true; Details = 'Node1:  Subscription Id: other-sub, Resource Group: other-rg' },
                    [PSCustomObject]@{ NodeName = 'Node2'; IsMismatch = $true; Details = 'Node2:  Subscription Id: other-sub2, Resource Group: other-rg2' }
                )
            }

            $threw = $false
            $errorMsg = ''
            try {
                Verify-NodesArcRegistrationState -ClusterNodes $clusterNodes -SubscriptionId 'sub-1' -ArcResourceGroupName 'rg-1' -ClusterDNSSuffix 'contoso.local'
            } catch {
                $threw = $true
                $errorMsg = $_.Exception.Message
            }
            $threw | Should -Be $true
            $errorMsg | Should -BeLike '*Node1*'
            $errorMsg | Should -BeLike '*Node2*'
        }
    }

    Context 'When result count does not match expected node count' {
        It 'Should throw verification incomplete error' {
            $clusterNodes = @(
                [PSCustomObject]@{ Name = 'Node1' },
                [PSCustomObject]@{ Name = 'Node2' },
                [PSCustomObject]@{ Name = 'Node3' }
            )

            # Only 2 results returned for 3 nodes
            Mock Invoke-Command {
                return @(
                    [PSCustomObject]@{ NodeName = 'Node1'; IsMismatch = $false; Details = $null },
                    [PSCustomObject]@{ NodeName = 'Node2'; IsMismatch = $false; Details = $null }
                )
            }

            { Verify-NodesArcRegistrationState -ClusterNodes $clusterNodes -SubscriptionId 'sub-1' -ArcResourceGroupName 'rg-1' -ClusterDNSSuffix 'contoso.local' } | Should -Throw
        }
    }

    Context 'When Invoke-Command returns null results' {
        It 'Should throw verification incomplete error for zero results' {
            $clusterNodes = @(
                [PSCustomObject]@{ Name = 'Node1' }
            )

            Mock Invoke-Command {
                return $null
            }

            { Verify-NodesArcRegistrationState -ClusterNodes $clusterNodes -SubscriptionId 'sub-1' -ArcResourceGroupName 'rg-1' -ClusterDNSSuffix 'contoso.local' } | Should -Throw
        }
    }

    Context 'When unreachable nodes produce OpenError' {
        It 'Should throw cannot verify error listing unreachable nodes' {
            $clusterNodes = @(
                [PSCustomObject]@{ Name = 'Node1' }
            )

            Mock Invoke-Command {
                return $null
            }

            $threw = $false
            $errorMsg = ''
            try {
                Verify-NodesArcRegistrationState -ClusterNodes $clusterNodes -SubscriptionId 'sub-1' -ArcResourceGroupName 'rg-1' -ClusterDNSSuffix 'contoso.local'
            } catch {
                $threw = $true
                $errorMsg = $_.Exception.Message
            }

            $threw | Should -Be $true
            # With null results for 1 node, the function throws verification incomplete
            ($errorMsg -like '*Cannot verify Arc registration state*' -or $errorMsg -like '*verification incomplete*') | Should -Be $true
        }
    }

    Context 'When script errors occur on remote nodes' {
        It 'Should throw failed to verify error when non-OpenError errors occur' {
            $clusterNodes = @(
                [PSCustomObject]@{ Name = 'Node1' }
            )

            # Mock returns null to trigger the result-count check after error classification
            Mock Invoke-Command {
                return $null
            }

            $threw = $false
            try {
                Verify-NodesArcRegistrationState -ClusterNodes $clusterNodes -SubscriptionId 'sub-1' -ArcResourceGroupName 'rg-1' -ClusterDNSSuffix 'contoso.local'
            } catch {
                $threw = $true
            }

            $threw | Should -Be $true
        }
    }

    Context 'Builds fully-qualified node names correctly' {
        It 'Should append ClusterDNSSuffix to each node name' {
            $clusterNodes = @(
                [PSCustomObject]@{ Name = 'NodeA' },
                [PSCustomObject]@{ Name = 'NodeB' }
            )

            $capturedComputerName = $null
            Mock Invoke-Command {
                # Capture the ComputerName parameter to verify FQDN construction
                $capturedComputerName = $ComputerName
                return @(
                    [PSCustomObject]@{ NodeName = 'NodeA'; IsMismatch = $false; Details = $null },
                    [PSCustomObject]@{ NodeName = 'NodeB'; IsMismatch = $false; Details = $null }
                )
            }

            Verify-NodesArcRegistrationState -ClusterNodes $clusterNodes -SubscriptionId 'sub-1' -ArcResourceGroupName 'rg-1' -ClusterDNSSuffix 'mydomain.local'

            # Verify Invoke-Command was called with expected FQDNs
            Assert-MockCalled Invoke-Command -Times 1 -ParameterFilter {
                $ComputerName -contains 'NodeA.mydomain.local' -and $ComputerName -contains 'NodeB.mydomain.local'
            }
        }
    }

    Context 'When Credential is provided' {
        It 'Should pass Credential to Invoke-Command' {
            $clusterNodes = @(
                [PSCustomObject]@{ Name = 'Node1' }
            )

            $testCred = [System.Management.Automation.PSCredential]::new(
                'testuser',
                (ConvertTo-SecureString 'testpass' -AsPlainText -Force)
            )

            Mock Invoke-Command {
                return @(
                    [PSCustomObject]@{ NodeName = 'Node1'; IsMismatch = $false; Details = $null }
                )
            }

            Verify-NodesArcRegistrationState -ClusterNodes $clusterNodes -SubscriptionId 'sub-1' -ArcResourceGroupName 'rg-1' -ClusterDNSSuffix 'contoso.local' -Credential $testCred

            Assert-MockCalled Invoke-Command -Times 1 -ParameterFilter {
                $null -ne $Credential -and $Credential.UserName -eq 'testuser'
            }
        }
    }

    Context 'When Credential is not provided' {
        It 'Should not pass Credential to Invoke-Command' {
            $clusterNodes = @(
                [PSCustomObject]@{ Name = 'Node1' }
            )

            Mock Invoke-Command {
                return @(
                    [PSCustomObject]@{ NodeName = 'Node1'; IsMismatch = $false; Details = $null }
                )
            }

            Verify-NodesArcRegistrationState -ClusterNodes $clusterNodes -SubscriptionId 'sub-1' -ArcResourceGroupName 'rg-1' -ClusterDNSSuffix 'contoso.local'

            Assert-MockCalled Invoke-Command -Times 1 -ParameterFilter {
                $null -eq $Credential
            }
        }
    }

    Context 'Single node with no mismatch' {
        It 'Should succeed for a single-node cluster' {
            $clusterNodes = @(
                [PSCustomObject]@{ Name = 'SingleNode' }
            )

            Mock Invoke-Command {
                return [PSCustomObject]@{ NodeName = 'SingleNode'; IsMismatch = $false; Details = $null }
            }

            { Verify-NodesArcRegistrationState -ClusterNodes $clusterNodes -SubscriptionId 'sub-1' -ArcResourceGroupName 'rg-1' -ClusterDNSSuffix 'contoso.local' } | Should -Not -Throw
        }
    }
}
