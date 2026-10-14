if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzChaosScenario'))
{
  Import-Module (Join-Path $PSScriptRoot '..\Az.Chaos.psd1') -Force
}

Describe 'Remove-AzChaosScenario' {
    $subscriptionId = '00000000-0000-0000-0000-000000000000'
    $workspaceId = "/subscriptions/$subscriptionId/resourceGroups/rg/providers/Microsoft.Chaos/workspaces/ws"
    $scenarioId = "$workspaceId/scenarios/sc"

    function New-ChaosIdentity {
        param([string]$Id)

        $identity = [Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.ChaosIdentity]::new()
        $identity.Id = $Id
        $identity
    }

    function New-HttpPipelineStep {
        param(
            [System.Net.HttpStatusCode]$StatusCode,
            [string]$Body = $null
        )

        [Microsoft.Azure.PowerShell.Cmdlets.Chaos.Runtime.SendAsyncStep]{
            param($request, $callback, $next)

            $response = [System.Net.Http.HttpResponseMessage]::new($StatusCode)
            if ($Body) {
                $response.Content = [System.Net.Http.StringContent]::new($Body, [System.Text.Encoding]::UTF8, 'application/json')
            }

            [System.Threading.Tasks.Task]::FromResult($response)
        }.GetNewClosure()
    }

    # The generated proxy refuses to run without an Azure login unless it can see a
    # playback-mode PipelineMock in HttpPipelinePrepend:
    #
    #   $testPlayback = $false
    #   $PSBoundParameters['HttpPipelinePrepend'] | Foreach-Object { if ($_) { $testPlayback = $testPlayback -or
    #     ('...Chaos.Runtime.PipelineMock' -eq $_.Target.GetType().FullName -and 'Playback' -eq $_.Target.Mode) } }
    #   $context = Get-AzContext
    #   if (-not $context -and -not $testPlayback) { throw "No Azure login detected..." }
    #
    # A SendAsyncStep built from a script block has a compiler-generated closure as its
    # .Target, so it can never satisfy that check. On a CI agent -- which has no Azure login --
    # the cmdlet therefore throws before any pipeline step runs, and none of the delete
    # behaviour below is exercised. Every generated *.Tests.ps1 gets past the same gate by
    # dot-sourcing generated/runtime/HttpPipelineMocking.ps1, which assigns a playback-mode
    # PipelineMock object to $PSDefaultParameterValues["*:HttpPipelinePrepend"]. These tests
    # need a synthesised response rather than a recording, so they pass both: the mock to
    # satisfy the check, and the responder to answer the request.
    #
    # Order matters and is load-bearing. HttpPipeline.Prepend appends to its step list and
    # builds the chain by wrapping `next` in list order, so the LAST element of the array ends
    # up outermost and runs FIRST. The responder runs first and returns without calling $next,
    # so the mock is never invoked. The mock deliberately names a recording file that does not
    # exist: if that ordering ever changes, PipelineMock.LoadMessage throws "Missing recording
    # file" and these tests fail loudly instead of passing vacuously.
    $unusedRecording = Join-Path $PSScriptRoot 'this-recording-must-never-be-read.json'

    function New-HttpPipelinePrepend {
        param(
            [System.Net.HttpStatusCode]$StatusCode,
            [string]$Body = $null
        )

        $mock = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.Chaos.Runtime.PipelineMock -ArgumentList $unusedRecording
        $mock.SetPlayback()

        @($mock, (New-HttpPipelineStep -StatusCode $StatusCode -Body $Body))
    }

    function Invoke-ScenarioDelete {
        [CmdletBinding()]
        param(
            [string]$Variant,
            [System.Net.HttpStatusCode]$StatusCode,
            [switch]$PassThru,
            [string]$Body = $null
        )

        $params = @{
            HttpPipelinePrepend = New-HttpPipelinePrepend -StatusCode $StatusCode -Body $Body
            Confirm = $false
        }

        switch ($Variant) {
            'Delete' {
                $params.SubscriptionId = $subscriptionId
                $params.ResourceGroupName = 'rg'
                $params.WorkspaceName = 'ws'
                $params.Name = 'sc'
            }
            'DeleteViaIdentityWorkspace' {
                $params.WorkspaceInputObject = New-ChaosIdentity -Id $workspaceId
                $params.Name = 'sc'
            }
            'DeleteViaIdentity' {
                $params.InputObject = New-ChaosIdentity -Id $scenarioId
            }
            default {
                throw "Unknown scenario delete variant '$Variant'."
            }
        }

        if ($PassThru) {
            $params.PassThru = $true
        }
        if ($PSBoundParameters.ContainsKey('ErrorAction')) {
            $params.ErrorAction = $PSBoundParameters.ErrorAction
        }
        if ($PSBoundParameters.ContainsKey('ErrorVariable')) {
            $params.ErrorVariable = $PSBoundParameters.ErrorVariable
        }

        Remove-AzChaosScenario @params
    }

    $deleteVariants = @(
        'Delete',
        'DeleteViaIdentity',
        'DeleteViaIdentityWorkspace'
    )

    foreach ($variant in $deleteVariants) {
        It "treats a present scenario delete 202 as successful in $variant" {
            Invoke-ScenarioDelete -Variant $variant -StatusCode Accepted -PassThru | Should -BeTrue
        }

        It "treats a present scenario delete 204 as successful in $variant" {
            Invoke-ScenarioDelete -Variant $variant -StatusCode NoContent -PassThru | Should -BeTrue
        }

        It "reports an absent scenario delete 404 rather than custom-swallowing it in $variant" {
            $body = '{"error":{"code":"NotFound","message":"The scenario was not found."}}'
            $errors = @()

            Invoke-ScenarioDelete -Variant $variant -StatusCode NotFound -Body $body -PassThru -ErrorAction SilentlyContinue -ErrorVariable errors | Should -BeNullOrEmpty

            $errors.Count | Should -Be 1
            $errors[0].FullyQualifiedErrorId | Should -Be "NotFound,Microsoft.Azure.PowerShell.Cmdlets.Chaos.Cmdlets.RemoveAzChaosScenario_$variant"
        }
    }

    It 'Delete' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentityWorkspace' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
