if(($null -eq $TestName) -or ($TestName -contains 'Start-AzChaosScenarioRun'))
{
  # Porcelain workflow cmdlets orchestrate the exported plumbing cmdlets. These tests
  # dot-source the custom cmdlet and mock the plumbing cmdlets so the workflow logic is
  # exercised without any HTTP traffic. They therefore pass in playback with no recording.
  . (Join-Path $PSScriptRoot '..\custom\Start-AzChaosScenarioRun.ps1')

  function Test-AzChaosScenarioConfiguration {
    [CmdletBinding()]
    param([string]$ResourceGroupName, [string]$WorkspaceName, [string]$ScenarioName, [string]$Name, [string]$SubscriptionId, $DefaultProfile)
  }
  function Get-AzChaosScenario {
    [CmdletBinding()]
    param([string]$ResourceGroupName, [string]$WorkspaceName, [string]$Name, [string]$SubscriptionId, $DefaultProfile)
  }
  function Invoke-AzChaosScenarioConfigurationExecution {
    [CmdletBinding()]
    param([string]$ResourceGroupName, [string]$WorkspaceName, [string]$ScenarioName, [string]$ScenarioConfigurationName, [string]$SubscriptionId, $DefaultProfile, [switch]$NoWait)
    $script:executeCallCount++
    $script:executeBoundParameters = @{} + $MyInvocation.BoundParameters
    if ($NoWait) {
        return $script:operation
    }
    $script:executeResult
  }
}

Describe 'Start-AzChaosScenarioRun' {
    $customScenario = [pscustomobject]@{ CreatedFrom = ''; RecommendationStatus = '' }
    $evaluatedCatalog = [pscustomobject]@{ CreatedFrom = '/subscriptions/x/scenarioTemplates/t/versions/1'; RecommendationStatus = 'Recommended' }
    $unevaluatedCatalog = [pscustomobject]@{ CreatedFrom = '/subscriptions/x/scenarioTemplates/t/versions/1'; RecommendationStatus = 'NotEvaluated' }
    $operation = [pscustomobject]@{ Target = 'https://management.azure.com/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Chaos/workspaces/ws/scenarios/sc/runs/run1?api-version=2026-05-01-preview' }
    $succeededRun = [pscustomobject]@{ RunId = 'run1'; Status = 'Succeeded' }
    $succeededValidation = [pscustomobject]@{ Status = 'Succeeded' }

    BeforeEach {
        $script:executeBoundParameters = $null
        $script:executeCallCount = 0
        $script:operation = $operation
        $script:executeResult = $succeededRun
        $script:validationBoundParameters = $null
        Mock Start-Sleep { }
    }

    It 'validates first, then executes when validation succeeds' {
        Mock Test-AzChaosScenarioConfiguration {
            $script:validationBoundParameters = @{} + $MyInvocation.BoundParameters
            $succeededValidation
        }
        Mock Get-AzChaosScenario { $customScenario }

        $run = Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg

        Assert-MockCalled Test-AzChaosScenarioConfiguration -Scope It -Times 1 -Exactly -ParameterFilter { $Name -eq 'cfg' }
        $script:validationBoundParameters.ContainsKey('PassThru') | Should -Be $false
        $script:executeCallCount | Should -Be 1
        $script:executeBoundParameters['ScenarioConfigurationName'] | Should -Be 'cfg'
        $script:executeBoundParameters.ContainsKey('NoWait') | Should -Be $false
        $run.Status | Should -Be 'Succeeded'
    }

    It 'does not execute when validation fails' {
        Mock Test-AzChaosScenarioConfiguration { [pscustomobject]@{ Status = 'NoResolvedResources' } }
        Mock Get-AzChaosScenario { $customScenario }

        Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg -ErrorAction SilentlyContinue -ErrorVariable startError

        $startError | Should -Not -BeNullOrEmpty
        $script:executeCallCount | Should -Be 0
    }

    It 'does not fail open when validation returns RequiresAttention with resource errors' {
        Mock Test-AzChaosScenarioConfiguration {
            [pscustomobject]@{
                Properties = [pscustomobject]@{
                    Status = 'RequiresAttention'
                    ValidationErrors = [pscustomobject]@{
                        Permission = @()
                        Resource = @([pscustomobject]@{ ResourceId = '/subscriptions/s/resourceGroups/rg/providers/Microsoft.Compute/virtualMachines/vm1'; ErrorMessage = 'Unsupported state.' })
                    }
                }
            }
        }
        Mock Get-AzChaosScenario { $customScenario }

        Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg -ErrorAction SilentlyContinue -ErrorVariable startError

        $script:executeCallCount | Should -Be 0
        $startError[0].Exception.Message | Should -BeLike '*Resource error on*vm1*Unsupported state*'
        Assert-MockCalled Start-Sleep -Scope It -Times 0 -Exactly
    }

    It 'retries permission-only validation errors to tolerate RBAC propagation' {
        $script:validationAttempt = 0
        Mock Test-AzChaosScenarioConfiguration {
            $script:validationAttempt++
            if ($script:validationAttempt -eq 1) {
                return [pscustomobject]@{
                    Properties = [pscustomobject]@{
                        Status = 'RequiresAttention'
                        ValidationErrors = [pscustomobject]@{
                            Permission = @([pscustomobject]@{
                                ResourceId = '/subscriptions/s/resourceGroups/rg/providers/Microsoft.Compute/virtualMachines/vm1'
                                MissingPermission = @('Microsoft.Compute/virtualMachines/start/action')
                                RecommendedRole = @('9980e02c-c2be-4d73-94e8-173b1dc7cf3c')
                            })
                            Resource = @()
                        }
                    }
                }
            }
            $succeededValidation
        }
        Mock Get-AzChaosScenario { $customScenario }

        Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg -Verbose

        $script:validationAttempt | Should -Be 2
        $script:executeCallCount | Should -Be 1
        Assert-MockCalled Start-Sleep -Scope It -Times 1 -Exactly -ParameterFilter { $Seconds -eq 15 }
    }

    It 'retries generated permission errors when other error collections contain only empty placeholders' {
        $script:validationAttempt = 0
        Mock Test-AzChaosScenarioConfiguration {
            $script:validationAttempt++
            if ($script:validationAttempt -eq 1) {
                return [pscustomobject]@{
                    Status = 'RequiresAttention'
                    ErrorPermission = @([pscustomobject]@{
                        ResourceId = '/subscriptions/s/resourceGroups/rg/providers/Microsoft.Compute/virtualMachines/vm1'
                        MissingPermission = @('Microsoft.Compute/virtualMachines/start/action')
                        RecommendedRole = @('9980e02c-c2be-4d73-94e8-173b1dc7cf3c')
                    })
                    ErrorResource = @([pscustomobject]@{ ResourceId = $null; ErrorMessage = $null })
                    Errors = @([pscustomobject]@{ ErrorCode = $null; ErrorMessage = $null })
                }
            }
            $succeededValidation
        }
        Mock Get-AzChaosScenario { $customScenario }

        Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg -Verbose

        $script:validationAttempt | Should -Be 2
        $script:executeCallCount | Should -Be 1
        Assert-MockCalled Start-Sleep -Scope It -Times 1 -Exactly -ParameterFilter { $Seconds -eq 15 }
    }

    It 'retries permission validation errors when operation errors carry the service RBAC validation code' {
        $script:validationAttempt = 0
        Mock Test-AzChaosScenarioConfiguration {
            $script:validationAttempt++
            if ($script:validationAttempt -eq 1) {
                return [pscustomobject]@{
                    Properties = [pscustomobject]@{
                        Status = 'RequiresAttention'
                        ValidationErrors = [pscustomobject]@{
                            Permission = @([pscustomobject]@{
                                ResourceId = '/subscriptions/s/resourceGroups/rg/providers/Microsoft.Compute/virtualMachines/vm1'
                                MissingPermission = @('Microsoft.Compute/virtualMachines/start/action')
                                RecommendedRole = @('9980e02c-c2be-4d73-94e8-173b1dc7cf3c')
                            })
                            Resource = @()
                        }
                        Errors = @([pscustomobject]@{
                            ErrorCode = 'ScenarioExecutionRbacValidationError'
                            ErrorMessage = 'Performed RBAC validation and found failures.'
                        })
                    }
                }
            }
            $succeededValidation
        }
        Mock Get-AzChaosScenario { $customScenario }

        Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg -Verbose

        $script:validationAttempt | Should -Be 2
        $script:executeCallCount | Should -Be 1
        Assert-MockCalled Start-Sleep -Scope It -Times 1 -Exactly -ParameterFilter { $Seconds -eq 15 }
    }

    It 'does not retry permission validation errors with discovery operation errors' {
        Mock Test-AzChaosScenarioConfiguration {
            [pscustomobject]@{
                Status = 'RequiresAttention'
                ErrorPermission = @([pscustomobject]@{
                    ResourceId = '/subscriptions/s/resourceGroups/rg/providers/Microsoft.Compute/virtualMachines/vm1'
                    MissingPermission = @('Microsoft.Compute/virtualMachines/start/action')
                    RecommendedRole = @('9980e02c-c2be-4d73-94e8-173b1dc7cf3c')
                })
                ErrorResource = @()
                Errors = @([pscustomobject]@{
                    ErrorCode = 'ResourceDiscoveryPermissionError'
                    ErrorMessage = 'The workspace identity cannot discover resources. HTTP 403.'
                })
            }
        }
        Mock Get-AzChaosScenario { $customScenario }

        Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg -ErrorAction SilentlyContinue -ErrorVariable startError

        $script:executeCallCount | Should -Be 0
        Assert-MockCalled Test-AzChaosScenarioConfiguration -Scope It -Times 1 -Exactly
        Assert-MockCalled Start-Sleep -Scope It -Times 0 -Exactly
        $startError[0].Exception.Message | Should -BeLike "*ResourceDiscoveryPermissionError*"
    }

    It 'does not retry permission validation errors with unrelated operation errors' {
        Mock Test-AzChaosScenarioConfiguration {
            [pscustomobject]@{
                Status = 'RequiresAttention'
                ErrorPermission = @([pscustomobject]@{
                    ResourceId = '/subscriptions/s/resourceGroups/rg/providers/Microsoft.Compute/virtualMachines/vm1'
                    MissingPermission = @('Microsoft.Compute/virtualMachines/start/action')
                    RecommendedRole = @('9980e02c-c2be-4d73-94e8-173b1dc7cf3c')
                })
                ErrorResource = @()
                Errors = @([pscustomobject]@{
                    ErrorCode = 'InternalServerError'
                    ErrorMessage = 'The validation service failed.'
                })
            }
        }
        Mock Get-AzChaosScenario { $customScenario }

        Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg -ErrorAction SilentlyContinue -ErrorVariable startError

        $script:executeCallCount | Should -Be 0
        Assert-MockCalled Test-AzChaosScenarioConfiguration -Scope It -Times 1 -Exactly
        Assert-MockCalled Start-Sleep -Scope It -Times 0 -Exactly
        $startError[0].Exception.Message | Should -BeLike "*InternalServerError*"
    }

    It 'does not retry NoResolvedResources because empty target resolution is terminal' {
        Mock Test-AzChaosScenarioConfiguration {
            [pscustomobject]@{
                Status = 'NoResolvedResources'
                ErrorPermission = @()
                ErrorResource = @()
                Errors = @([pscustomobject]@{
                    ErrorCode = 'ResourceTargetingNoResourcesError'
                    ErrorMessage = 'No resources matched the scenario filters.'
                })
            }
        }
        Mock Get-AzChaosScenario { $customScenario }

        Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg -ErrorAction SilentlyContinue -ErrorVariable startError

        $script:executeCallCount | Should -Be 0
        Assert-MockCalled Test-AzChaosScenarioConfiguration -Scope It -Times 1 -Exactly
        Assert-MockCalled Start-Sleep -Scope It -Times 0 -Exactly
        $startError[0].Exception.Message | Should -BeLike "*status 'NoResolvedResources'*"
    }

    It 'does not retry NoResolvedResources even if permission errors are present' {
        Mock Test-AzChaosScenarioConfiguration {
            [pscustomobject]@{
                Status = 'NoResolvedResources'
                ErrorPermission = @([pscustomobject]@{
                    ResourceId = '/subscriptions/s/resourceGroups/rg/providers/Microsoft.Compute/virtualMachines/vm1'
                    MissingPermission = @('Microsoft.Compute/virtualMachines/start/action')
                    RecommendedRole = @('9980e02c-c2be-4d73-94e8-173b1dc7cf3c')
                })
                ErrorResource = @()
                Errors = @()
            }
        }
        Mock Get-AzChaosScenario { $customScenario }

        Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg -ErrorAction SilentlyContinue -ErrorVariable startError

        $script:executeCallCount | Should -Be 0
        Assert-MockCalled Test-AzChaosScenarioConfiguration -Scope It -Times 1 -Exactly
        Assert-MockCalled Start-Sleep -Scope It -Times 0 -Exactly
        $startError[0].Exception.Message | Should -BeLike "*status 'NoResolvedResources'*"
    }

    It 'does not retry RequiresAttention when permission errors are empty' {
        Mock Test-AzChaosScenarioConfiguration {
            [pscustomobject]@{
                Status = 'RequiresAttention'
                ErrorPermission = @()
                ErrorResource = @()
                Errors = @()
            }
        }
        Mock Get-AzChaosScenario { $customScenario }

        Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg -ErrorAction SilentlyContinue -ErrorVariable startError

        $script:executeCallCount | Should -Be 0
        Assert-MockCalled Test-AzChaosScenarioConfiguration -Scope It -Times 1 -Exactly
        Assert-MockCalled Start-Sleep -Scope It -Times 0 -Exactly
        $startError[0].Exception.Message | Should -BeLike "*status 'RequiresAttention'*"
    }

    It 'retries transient validation states instead of failing fast' {
        $script:validationAttempt = 0
        Mock Test-AzChaosScenarioConfiguration {
            $script:validationAttempt++
            if ($script:validationAttempt -eq 1) {
                return [pscustomobject]@{ Status = 'NotStarted' }
            }
            $succeededValidation
        }
        Mock Get-AzChaosScenario { $customScenario }

        Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg -Verbose

        $script:validationAttempt | Should -Be 2
        $script:executeCallCount | Should -Be 1
        Assert-MockCalled Start-Sleep -Scope It -Times 1 -Exactly -ParameterFilter { $Seconds -eq 15 }
    }

    It 'reports permission details after bounded RBAC propagation retries are exhausted' {
        Mock Test-AzChaosScenarioConfiguration {
            [pscustomobject]@{
                Properties = [pscustomobject]@{
                    Status = 'RequiresAttention'
                    ValidationErrors = [pscustomobject]@{
                        Permission = @([pscustomobject]@{
                            ResourceId = '/subscriptions/s/resourceGroups/rg/providers/Microsoft.Compute/virtualMachines/vm1'
                            MissingPermission = @('Microsoft.Compute/virtualMachines/powerOff/action')
                            RecommendedRole = @('9980e02c-c2be-4d73-94e8-173b1dc7cf3c')
                        })
                        Resource = @()
                    }
                }
            }
        }
        Mock Get-AzChaosScenario { $customScenario }

        Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg -ErrorAction SilentlyContinue -ErrorVariable startError

        $script:executeCallCount | Should -Be 0
        Assert-MockCalled Test-AzChaosScenarioConfiguration -Scope It -Times 21 -Exactly
        Assert-MockCalled Start-Sleep -Scope It -Times 20 -Exactly -ParameterFilter { $Seconds -eq 15 }
        $startError[0].Exception.Message | Should -BeLike '*Missing permissions: Microsoft.Compute/virtualMachines/powerOff/action*'
        $startError[0].Exception.Message | Should -BeLike '*Recommended roles: 9980e02c-c2be-4d73-94e8-173b1dc7cf3c*'
    }

    It 'keeps the permission retry budget to the measured 300 second RBAC propagation window' {
        $script:retrySleepSeconds = 0
        Mock Start-Sleep { $script:retrySleepSeconds += $Seconds }
        Mock Test-AzChaosScenarioConfiguration {
            [pscustomobject]@{
                Status = 'RequiresAttention'
                ErrorPermission = @([pscustomobject]@{
                    ResourceId = '/subscriptions/s/resourceGroups/rg/providers/Microsoft.Compute/virtualMachines/vm1'
                    MissingPermission = @('Microsoft.Compute/virtualMachines/powerOff/action')
                    RecommendedRole = @('9980e02c-c2be-4d73-94e8-173b1dc7cf3c')
                })
                ErrorResource = @()
                Errors = @()
            }
        }
        Mock Get-AzChaosScenario { $customScenario }

        Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg -ErrorAction SilentlyContinue -ErrorVariable startError

        $script:executeCallCount | Should -Be 0
        Assert-MockCalled Test-AzChaosScenarioConfiguration -Scope It -Times 21 -Exactly
        Assert-MockCalled Start-Sleep -Scope It -Times 20 -Exactly -ParameterFilter { $Seconds -eq 15 }
        $script:retrySleepSeconds | Should -Be 300
        $startError | Should -Not -BeNullOrEmpty
    }

    It 'does not execute when validation returns an unrecognized status' {
        Mock Test-AzChaosScenarioConfiguration { [pscustomobject]@{ Status = 'MysteryState' } }
        Mock Get-AzChaosScenario { $customScenario }

        { Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg -ErrorAction Stop } |
            Should -Throw "unrecognized status 'MysteryState'"

        $script:executeCallCount | Should -Be 0
    }

    It 'skips validation with -SkipValidation' {
        Mock Test-AzChaosScenarioConfiguration { $succeededValidation }
        Mock Get-AzChaosScenario { $customScenario }

        Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg -SkipValidation

        Assert-MockCalled Test-AzChaosScenarioConfiguration -Scope It -Times 0 -Exactly
        $script:executeCallCount | Should -Be 1
    }

    It 'runs a catalog scenario once the workspace is evaluated' {
        Mock Test-AzChaosScenarioConfiguration { $succeededValidation }
        Mock Get-AzChaosScenario { $evaluatedCatalog }

        Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg

        $script:executeCallCount | Should -Be 1
    }

    It 'fails with a friendly error for an unevaluated catalog scenario and does not evaluate or execute' {
        Mock Test-AzChaosScenarioConfiguration { $succeededValidation }
        Mock Get-AzChaosScenario { $unevaluatedCatalog }

        { Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg -ErrorAction Stop } |
            Should -Throw 'catalog scenario'

        $script:executeCallCount | Should -Be 0
    }

    It 'does not mutate under -WhatIf' {
        Mock Test-AzChaosScenarioConfiguration { $succeededValidation }
        Mock Get-AzChaosScenario { $customScenario }

        Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg -WhatIf

        $script:executeCallCount | Should -Be 0
    }

    It 'returns the operation handle with -NoWait' {
        Mock Test-AzChaosScenarioConfiguration { $succeededValidation }
        Mock Get-AzChaosScenario { $customScenario }
        $result = Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg -NoWait

        $result.Target | Should -Be $operation.Target
        $script:executeBoundParameters.ContainsKey('NoWait') | Should -Be $true
    }

    It 'returns the scenario run from the plumbing cmdlet by default' {
        Mock Test-AzChaosScenarioConfiguration { $succeededValidation }
        Mock Get-AzChaosScenario { $customScenario }

        $run = Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg

        $script:executeBoundParameters.ContainsKey('NoWait') | Should -Be $false
        $run.Status | Should -Be 'Succeeded'
    }

    It 'reports an error when the scenario run reaches a failed terminal state' {
        Mock Test-AzChaosScenarioConfiguration { $succeededValidation }
        Mock Get-AzChaosScenario { $customScenario }
        $script:executeResult = [pscustomobject]@{ RunId = 'run1'; Status = 'Failed' }

        $run = Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg -ErrorAction SilentlyContinue -ErrorVariable runError

        $run.Status | Should -Be 'Failed'
        $runError | Should -Not -BeNullOrEmpty
        $runError[0].Exception.Message | Should -Be "Scenario run 'run1' completed with status 'Failed'."
    }
}
