if(($null -eq $TestName) -or ($TestName -contains 'Initialize-AzChaosWorkspace'))
{
  # Porcelain workflow cmdlet. The test dot-sources the custom cmdlet and mocks the
  # plumbing and Az.Resources cmdlets it orchestrates, so it passes in playback with no
  # recording.
  Import-Module (Join-Path $PSScriptRoot '..\Az.Chaos.psd1') -Force
  . (Join-Path $PSScriptRoot '..\custom\Initialize-AzChaosWorkspace.ps1')

  function Get-AzResourceGroup { [CmdletBinding()] param([string]$Name) }
  function New-AzResourceGroup { [CmdletBinding()] param([string]$Name, [string]$Location) }
  function New-AzChaosWorkspace {
    [CmdletBinding()]
    param([string]$Name, [string]$ResourceGroupName, [string]$Location, [string[]]$Scope, [switch]$EnableSystemAssignedIdentity, [hashtable]$Tag, [string]$SubscriptionId, $DefaultProfile)
  }
  function New-AzRoleAssignment { [CmdletBinding()] param([string]$ObjectId, [string]$RoleDefinitionName, [string]$Scope) }
  function Invoke-AzChaosWorkspaceScenarioEvaluation {
    [CmdletBinding()]
    param([string]$ResourceGroupName, [string]$WorkspaceName, [string]$SubscriptionId, $DefaultProfile, [switch]$NoWait)
    $script:evaluationCallCount++
    $script:evaluationBoundParameters = @{} + $MyInvocation.BoundParameters
    $true
  }
  function Get-AzChaosScenario {
    [CmdletBinding()]
    param([string]$ResourceGroupName, [string]$WorkspaceName, [string]$Name, [string]$SubscriptionId, $DefaultProfile)
  }
  function Get-AzChaosWorkspaceEvaluation {
    [CmdletBinding()]
    param([string]$ResourceGroupName, [string]$WorkspaceName, [string]$SubscriptionId, $DefaultProfile)
  }
}

Describe 'Initialize-AzChaosWorkspace' {
    $scope = '/subscriptions/00000000-0000-0000-0000-000000000000'
    $workspaceWithIdentity = [pscustomobject]@{ Name = 'ws'; IdentityPrincipalId = '11111111-1111-1111-1111-111111111111' }

    BeforeEach {
        $script:evaluationBoundParameters = $null
        $script:evaluationCallCount = 0
        Mock New-AzResourceGroup { }
        Mock New-AzChaosWorkspace { $workspaceWithIdentity }
        Mock New-AzRoleAssignment { }
        Mock Invoke-AzChaosWorkspaceScenarioEvaluation {
            $script:evaluationCallCount++
            $script:evaluationBoundParameters = @{} + $MyInvocation.BoundParameters
            $true
        }
        Mock Get-AzChaosScenario { @([pscustomobject]@{ Name = 'sc' }) }
        Mock Get-AzChaosWorkspaceEvaluation { $null }
        Mock Start-Sleep { }
        Mock Get-Module { $null } -ParameterFilter { $Name -eq 'Az.Resources' -and -not $ListAvailable }
        Mock Get-Module { [pscustomobject]@{ Name = 'Az.Resources' } } -ParameterFilter { $Name -eq 'Az.Resources' -and $ListAvailable }
        Mock Import-Module { }
    }

    It 'runs the five setup steps' {
        Mock Get-AzResourceGroup { $null }

        Initialize-AzChaosWorkspace -ResourceGroupName rg -WorkspaceName ws -Location eastus -Scope $scope | Out-Null

        Assert-MockCalled New-AzResourceGroup -Scope It -Times 1 -Exactly
        Assert-MockCalled New-AzChaosWorkspace -Scope It -Times 1 -Exactly -ParameterFilter { $EnableSystemAssignedIdentity.IsPresent }
        Assert-MockCalled New-AzRoleAssignment -Scope It -Times 1 -Exactly -ParameterFilter { $Scope -eq '/subscriptions/00000000-0000-0000-0000-000000000000' -and $RoleDefinitionName -eq 'Reader' }
        $script:evaluationCallCount | Should -Be 1
        Assert-MockCalled Get-AzChaosScenario -Scope It -Times 1 -Exactly
        Assert-MockCalled Import-Module -Scope It -Times 1 -Exactly -ParameterFilter { $Name -eq 'Az.Resources' }
    }

    It 'fails before mutation when Az.Resources is not installed even with -SkipPermission' {
        Mock Get-Module { $null } -ParameterFilter { $Name -eq 'Az.Resources' -and -not $ListAvailable }
        Mock Get-Module { $null } -ParameterFilter { $Name -eq 'Az.Resources' -and $ListAvailable }

        { Initialize-AzChaosWorkspace -ResourceGroupName rg -WorkspaceName ws -Location eastus -Scope $scope -SkipPermission -ErrorAction Stop } |
            Should -Throw 'Install-Module Az.Resources'

        Assert-MockCalled New-AzResourceGroup -Scope It -Times 0 -Exactly
        Assert-MockCalled New-AzChaosWorkspace -Scope It -Times 0 -Exactly
        Assert-MockCalled New-AzRoleAssignment -Scope It -Times 0 -Exactly
        $script:evaluationCallCount | Should -Be 0
    }

    It 'does not create the resource group when it already exists' {
        Mock Get-AzResourceGroup { [pscustomobject]@{ ResourceGroupName = 'rg' } }

        Initialize-AzChaosWorkspace -ResourceGroupName rg -WorkspaceName ws -Location eastus -Scope $scope | Out-Null

        Assert-MockCalled New-AzResourceGroup -Scope It -Times 0 -Exactly
    }

    It 'discloses every resource it creates in the ShouldProcess target' {
        # -WhatIf is the surface a careful user reaches for to learn the blast radius before
        # committing. Naming only the workspace hid a resource group, an identity and an RBAC
        # grant, so a typo'd -ResourceGroupName silently created four objects (DEV-045).
        #
        # The "What if:" line is written straight to the host and cannot be captured by any
        # stream redirection, so this asserts the target is built from the right inputs at the
        # source level instead. Paired with the ordering test below, that pins both halves:
        # the data is available, and it reaches the target.
        $source = Get-Content -Path (Join-Path (Split-Path $PSScriptRoot -Parent) 'custom/Initialize-AzChaosWorkspace.ps1') -Raw
        $ast = [System.Management.Automation.Language.Parser]::ParseInput($source, [ref]$null, [ref]$null)
        $shouldProcess = $ast.FindAll({
            $args[0] -is [System.Management.Automation.Language.InvokeMemberExpressionAst] -and
            $args[0].Member.Value -eq 'ShouldProcess'
        }, $true) | Select-Object -First 1

        $shouldProcess | Should -Not -BeNullOrEmpty -Because 'the cmdlet must gate its mutations behind ShouldProcess'

        $targetExpression = $shouldProcess.Arguments[0].Extent.Text
        $targetVariable = ($targetExpression -replace '[^\w$]', ' ') -split '\s+' |
            Where-Object { $_ -like '$*' } | Select-Object -First 1
        $targetVariable | Should -Not -BeNullOrEmpty -Because 'the target must be composed, not a fixed string naming only the workspace'

        # The composed list must mention the resource group, the identity and the role grant.
        $assignments = $ast.FindAll({
            $args[0] -is [System.Management.Automation.Language.AssignmentStatementAst] -and
            $args[0].Left.Extent.Text -like "$targetVariable*"
        }, $true)
        $composed = ($assignments | ForEach-Object { $_.Right.Extent.Text }) -join ' '

        $composed | Should -Match 'ResourceGroupName' -Because 'a created resource group must be disclosed before it is created'
        $composed | Should -Match 'identity' -Because 'the system-assigned identity is a security principal the user should be told about'
        $composed | Should -Match 'RoleDefinitionName' -Because 'the RBAC grant must be disclosed'
    }

    It 'checks resource group existence before asking for confirmation' {
        # The existence check has to run before ShouldProcess or the target cannot name the
        # resource group. Asserting the read happens under -WhatIf pins that ordering: if the
        # check moves back after ShouldProcess, -WhatIf returns early and never calls it.
        Mock Get-AzResourceGroup { $null }

        Initialize-AzChaosWorkspace -ResourceGroupName rg -WorkspaceName ws -Location eastus -Scope $scope -WhatIf | Out-Null

        Assert-MockCalled Get-AzResourceGroup -Scope It -Times 1 -Exactly
        Assert-MockCalled New-AzResourceGroup -Scope It -Times 0 -Exactly
        Assert-MockCalled New-AzRoleAssignment -Scope It -Times 0 -Exactly
    }

    It 'skips the RBAC grant with -SkipPermission' {
        Mock Get-AzResourceGroup { $null }

        Initialize-AzChaosWorkspace -ResourceGroupName rg -WorkspaceName ws -Location eastus -Scope $scope -SkipPermission | Out-Null

        Assert-MockCalled New-AzRoleAssignment -Scope It -Times 0 -Exactly
    }

    It 'grants the role on each scope' {
        Mock Get-AzResourceGroup { $null }
        $scopes = @('/subscriptions/00000000-0000-0000-0000-000000000000', '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg2')

        Initialize-AzChaosWorkspace -ResourceGroupName rg -WorkspaceName ws -Location eastus -Scope $scopes | Out-Null

        Assert-MockCalled New-AzRoleAssignment -Scope It -Times 2 -Exactly
    }

    It 'runs a single evaluation attempt with -SkipEvaluationWait' {
        Mock Get-AzResourceGroup { $null }

        Initialize-AzChaosWorkspace -ResourceGroupName rg -WorkspaceName ws -Location eastus -Scope $scope -SkipEvaluationWait | Out-Null

        $script:evaluationCallCount | Should -Be 1
        $script:evaluationBoundParameters.ContainsKey('NoWait') | Should -Be $false
        Assert-MockCalled Get-AzChaosScenario -Scope It -Times 1 -Exactly
    }

    It 'surfaces a failed evaluation immediately when -SkipEvaluationWait is used' {
        Mock Get-AzResourceGroup { $null }
        Mock Invoke-AzChaosWorkspaceScenarioEvaluation {
            $script:evaluationCallCount++
            [pscustomobject]@{
                Status = 'Failed'
                Error = @([pscustomobject]@{
                    ErrorCode = 'ResourceDiscoveryPermissionError'
                    ErrorMessage = 'The workspace identity cannot discover resources. HTTP 403.'
                })
            }
        }

        try {
            Initialize-AzChaosWorkspace -ResourceGroupName rg -WorkspaceName ws -Location eastus -Scope $scope -SkipEvaluationWait -ErrorAction Stop
            throw 'Expected Initialize-AzChaosWorkspace to fail.'
        }
        catch {
            $_.Exception.Message | Should -BeLike '*ResourceDiscoveryPermissionError*'
        }

        $script:evaluationCallCount | Should -Be 1
        Assert-MockCalled Get-AzChaosScenario -Scope It -Times 0 -Exactly
        Assert-MockCalled Start-Sleep -Scope It -Times 0 -Exactly
    }

    It 'waits for the evaluation by default' {
        Mock Get-AzResourceGroup { $null }
        $script:scenarioPoll = 0
        Mock Get-AzChaosScenario {
            $script:scenarioPoll++
            if ($script:scenarioPoll -eq 1) {
                return @([pscustomobject]@{ Name = 'sc'; CreatedFrom = '/subscriptions/x/scenarioTemplates/t/versions/1'; RecommendationStatus = 'NotEvaluated' })
            }
            @([pscustomobject]@{ Name = 'sc'; CreatedFrom = '/subscriptions/x/scenarioTemplates/t/versions/1'; RecommendationStatus = 'Recommended' })
        }

        Initialize-AzChaosWorkspace -ResourceGroupName rg -WorkspaceName ws -Location eastus -Scope $scope | Out-Null

        $script:evaluationCallCount | Should -Be 1
        $script:evaluationBoundParameters.ContainsKey('NoWait') | Should -Be $false
        Assert-MockCalled Get-AzChaosScenario -Scope It -Times 2 -Exactly
        Assert-MockCalled Start-Sleep -Scope It -Times 1 -Exactly -ParameterFilter { $Seconds -eq 15 }
    }

    It 'stops waiting when the latest workspace evaluation has failed with a non-transient error' {
        Mock Get-AzResourceGroup { $null }
        Mock Get-AzChaosScenario { @([pscustomobject]@{ Name = 'sc'; CreatedFrom = '/subscriptions/x/scenarioTemplates/t/versions/1'; RecommendationStatus = 'NotEvaluated' }) }
        Mock Get-AzChaosWorkspaceEvaluation {
            [pscustomobject]@{
                Status = 'Failed'
                Error = @([pscustomobject]@{
                    ErrorCode = 'WorkspaceIdentityError'
                    ErrorMessage = 'The workspace identity is not available.'
                })
            }
        }

        try {
            Initialize-AzChaosWorkspace -ResourceGroupName rg -WorkspaceName ws -Location eastus -Scope $scope -SkipPermission -ErrorAction Stop
            throw 'Expected Initialize-AzChaosWorkspace to fail.'
        }
        catch {
            $_.Exception.Message | Should -BeLike '*WorkspaceIdentityError*'
        }

        Assert-MockCalled Get-AzChaosScenario -Scope It -Times 0 -Exactly
        Assert-MockCalled Start-Sleep -Scope It -Times 0 -Exactly
    }

    It 're-runs evaluation when the latest workspace evaluation failed from RBAC propagation' {
        Mock Get-AzResourceGroup { $null }
        Mock Invoke-AzChaosWorkspaceScenarioEvaluation {
            $script:evaluationCallCount++
            $true
        }
        $script:workspaceEvaluationPoll = 0
        Mock Get-AzChaosWorkspaceEvaluation {
            $script:workspaceEvaluationPoll++
            if ($script:workspaceEvaluationPoll -eq 1) {
                return [pscustomobject]@{
                    Status = 'Failed'
                    Error = @([pscustomobject]@{
                        ErrorCode = 'ResourceDiscoveryPermissionError'
                        ErrorMessage = 'The workspace identity cannot discover resources. HTTP 403.'
                    })
                }
            }

            [pscustomobject]@{ Status = 'Succeeded' }
        }
        Mock Get-AzChaosScenario { @([pscustomobject]@{ Name = 'sc'; CreatedFrom = '/subscriptions/x/scenarioTemplates/t/versions/1'; RecommendationStatus = 'Recommended' }) }

        Initialize-AzChaosWorkspace -ResourceGroupName rg -WorkspaceName ws -Location eastus -Scope $scope | Out-Null

        $script:evaluationCallCount | Should -Be 2
        Assert-MockCalled Get-AzChaosWorkspaceEvaluation -Scope It -Times 2 -Exactly
        Assert-MockCalled Start-Sleep -Scope It -Times 1 -Exactly -ParameterFilter { $Seconds -eq 15 }
        Assert-MockCalled Get-AzChaosScenario -Scope It -Times 1 -Exactly
    }

    It 'keeps re-running failed discovery evaluations to a 300 second RBAC propagation budget' {
        Mock Get-AzResourceGroup { $null }
        Mock Invoke-AzChaosWorkspaceScenarioEvaluation {
            $script:evaluationCallCount++
            $true
        }
        Mock Get-AzChaosWorkspaceEvaluation {
            [pscustomobject]@{
                Status = 'Failed'
                Error = @([pscustomobject]@{
                    ErrorCode = 'ResourceDiscoveryPermissionError'
                    ErrorMessage = 'The workspace identity cannot discover resources. HTTP 403.'
                })
            }
        }
        Mock Get-AzChaosScenario { @([pscustomobject]@{ Name = 'sc'; CreatedFrom = '/subscriptions/x/scenarioTemplates/t/versions/1'; RecommendationStatus = 'NotEvaluated' }) }

        try {
            Initialize-AzChaosWorkspace -ResourceGroupName rg -WorkspaceName ws -Location eastus -Scope $scope -ErrorAction Stop
            throw 'Expected Initialize-AzChaosWorkspace to fail.'
        }
        catch {
            $_.Exception.Message | Should -BeLike '*ResourceDiscoveryPermissionError*'
        }

        $script:evaluationCallCount | Should -Be 21
        Assert-MockCalled Get-AzChaosWorkspaceEvaluation -Scope It -Times 21 -Exactly
        Assert-MockCalled Start-Sleep -Scope It -Times 20 -Exactly -ParameterFilter { $Seconds -eq 15 }
        Assert-MockCalled Get-AzChaosScenario -Scope It -Times 0 -Exactly
    }

    It 'retries RBAC propagation failures from the evaluation it just triggered' {
        Mock Get-AzResourceGroup { $null }
        $script:workspaceEvaluationAttempt = 0
        Mock Invoke-AzChaosWorkspaceScenarioEvaluation {
            $script:workspaceEvaluationAttempt++
            if ($script:workspaceEvaluationAttempt -eq 1) {
                return [pscustomobject]@{
                    Status = 'Failed'
                    Error = @([pscustomobject]@{
                        ErrorCode = 'ResourceDiscoveryPermissionError'
                        ErrorMessage = 'The workspace identity cannot discover resources. HTTP 403.'
                    })
                }
            }

            [pscustomobject]@{ Status = 'Succeeded' }
        }
        Mock Get-AzChaosScenario { @([pscustomobject]@{ Name = 'sc'; CreatedFrom = '/subscriptions/x/scenarioTemplates/t/versions/1'; RecommendationStatus = 'Recommended' }) }

        Initialize-AzChaosWorkspace -ResourceGroupName rg -WorkspaceName ws -Location eastus -Scope $scope | Out-Null

        $script:workspaceEvaluationAttempt | Should -Be 2
        Assert-MockCalled Start-Sleep -Scope It -Times 1 -Exactly -ParameterFilter { $Seconds -eq 15 }
        Assert-MockCalled Get-AzChaosScenario -Scope It -Times 1 -Exactly
    }

    It 'declares the Reader default for RoleDefinitionName' {
        $command = Get-Command Initialize-AzChaosWorkspace

        $defaultInfo = $command.Parameters['RoleDefinitionName'].Attributes |
            Where-Object { $_ -is [Microsoft.Azure.PowerShell.Cmdlets.Chaos.Runtime.DefaultInfoAttribute] } |
            Select-Object -First 1

        $defaultInfo.Script | Should -Be '"Reader"'
    }

    It 'treats an empty scenario list as a completed discovery result' {
        Mock Get-AzResourceGroup { $null }
        Mock Get-AzChaosScenario { @() }

        $scenarios = Initialize-AzChaosWorkspace -ResourceGroupName rg -WorkspaceName ws -Location eastus -Scope $scope

        @($scenarios).Count | Should -Be 0
        Assert-MockCalled Get-AzChaosScenario -Scope It -Times 1 -Exactly
        Assert-MockCalled Start-Sleep -Scope It -Times 0 -Exactly
    }

    It 'does not mutate under -WhatIf' {
        Mock Get-AzResourceGroup { $null }

        Initialize-AzChaosWorkspace -ResourceGroupName rg -WorkspaceName ws -Location eastus -Scope $scope -WhatIf | Out-Null

        Assert-MockCalled New-AzChaosWorkspace -Scope It -Times 0 -Exactly
        Assert-MockCalled New-AzRoleAssignment -Scope It -Times 0 -Exactly
        $script:evaluationCallCount | Should -Be 0
    }
}
