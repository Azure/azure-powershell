if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzChaosScenarioConfiguration'))
{
  Import-Module (Join-Path $PSScriptRoot '..\Az.Chaos.psd1') -Force
}

Describe 'Remove-AzChaosScenarioConfiguration' {
    $subscriptionId = '00000000-0000-0000-0000-000000000000'
    $workspaceId = "/subscriptions/$subscriptionId/resourceGroups/rg/providers/Microsoft.Chaos/workspaces/ws"
    $scenarioId = "$workspaceId/scenarios/sc"
    $configurationId = "$scenarioId/configurations/cfg"

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

    function Invoke-ScenarioConfigurationDelete {
        [CmdletBinding()]
        param(
            [string]$Variant,
            [System.Net.HttpStatusCode]$StatusCode,
            [switch]$PassThru,
            [string]$Body = $null
        )

        $params = @{
            HttpPipelinePrepend = New-HttpPipelineStep -StatusCode $StatusCode -Body $Body
            Confirm = $false
        }

        switch ($Variant) {
            'Delete' {
                $params.SubscriptionId = $subscriptionId
                $params.ResourceGroupName = 'rg'
                $params.WorkspaceName = 'ws'
                $params.ScenarioName = 'sc'
                $params.Name = 'cfg'
            }
            'DeleteViaIdentityWorkspace' {
                $params.WorkspaceInputObject = New-ChaosIdentity -Id $workspaceId
                $params.ScenarioName = 'sc'
                $params.Name = 'cfg'
            }
            'DeleteViaIdentityScenario' {
                $params.ScenarioInputObject = New-ChaosIdentity -Id $scenarioId
                $params.Name = 'cfg'
            }
            'DeleteViaIdentity' {
                $params.InputObject = New-ChaosIdentity -Id $configurationId
            }
            default {
                throw "Unknown scenario configuration delete variant '$Variant'."
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

        Remove-AzChaosScenarioConfiguration @params
    }

    $deleteVariants = @(
        'Delete',
        'DeleteViaIdentity',
        'DeleteViaIdentityScenario',
        'DeleteViaIdentityWorkspace'
    )

    foreach ($variant in $deleteVariants) {
        It "treats a present scenario configuration delete 202 as successful in $variant" {
            Invoke-ScenarioConfigurationDelete -Variant $variant -StatusCode Accepted -PassThru | Should -BeTrue
        }

        It "treats a present scenario configuration delete 204 as successful in $variant" {
            Invoke-ScenarioConfigurationDelete -Variant $variant -StatusCode NoContent -PassThru | Should -BeTrue
        }

        It "treats an already-absent scenario configuration delete 404 as successful in $variant" {
            Invoke-ScenarioConfigurationDelete -Variant $variant -StatusCode NotFound -PassThru | Should -BeTrue
        }

        It "does not emit output for an already-absent scenario configuration delete without PassThru in $variant" {
            @(Invoke-ScenarioConfigurationDelete -Variant $variant -StatusCode NotFound).Count | Should -Be 0
        }

        It "does not swallow non-NotFound scenario configuration delete failures in $variant" {
            $body = '{"error":{"code":"InternalError","message":"The service failed.","details":[{"code":"Inner","message":"A nested failure occurred."}]}}'
            $errors = @()

            Invoke-ScenarioConfigurationDelete -Variant $variant -StatusCode InternalServerError -Body $body -PassThru -ErrorAction SilentlyContinue -ErrorVariable errors | Should -BeNullOrEmpty

            $errors.Count | Should -Be 1
            $errors[0].FullyQualifiedErrorId | Should -Be "InternalError,Microsoft.Azure.PowerShell.Cmdlets.Chaos.Cmdlets.RemoveAzChaosScenarioConfiguration_$variant"
        }
    }

    It 'Delete' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentityWorkspace' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentityScenario' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
