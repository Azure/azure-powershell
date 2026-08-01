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

        It "reports an absent scenario configuration delete 404 rather than swallowing it in $variant" {
            # A 404 here does not mean "the configuration is already gone". The service returns
            # 404 with a different code for every absent ancestor -- ResourceGroupNotFound,
            # ResourceNotFound, NotFound -- and none of them identifies the configuration
            # itself, so a wrong resource group, workspace or scenario name is indistinguishable
            # from an already-deleted configuration. Swallowing 404 reported a successful delete
            # while the configuration was still live under the correctly-spelled parent
            # (DEV-046). Surfacing it matches Remove-AzChaosScenario.
            $body = '{"error":{"code":"ResourceGroupNotFound","message":"Resource group ''contos-rg'' could not be found."}}'
            $errors = @()

            Invoke-ScenarioConfigurationDelete -Variant $variant -StatusCode NotFound -Body $body -PassThru -ErrorAction SilentlyContinue -ErrorVariable errors | Should -BeNullOrEmpty

            $errors.Count | Should -Be 1
            $errors[0].FullyQualifiedErrorId | Should -Be "ResourceGroupNotFound,Microsoft.Azure.PowerShell.Cmdlets.Chaos.Cmdlets.RemoveAzChaosScenarioConfiguration_$variant"
            $errors[0].Exception.Message | Should -BeLike '*contos-rg*'
        }

        It "reports a 404 naming an absent parent scenario in $variant" {
            # Second 404 shape, distinct error code. Guards against a fix that special-cases
            # only the resource-group code and leaves the other ancestors swallowed.
            $body = '{"error":{"code":"NotFound","message":"Parent workspace could not be found."}}'
            $errors = @()

            Invoke-ScenarioConfigurationDelete -Variant $variant -StatusCode NotFound -Body $body -PassThru -ErrorAction SilentlyContinue -ErrorVariable errors | Should -BeNullOrEmpty

            $errors.Count | Should -Be 1
            $errors[0].FullyQualifiedErrorId | Should -Be "NotFound,Microsoft.Azure.PowerShell.Cmdlets.Chaos.Cmdlets.RemoveAzChaosScenarioConfiguration_$variant"
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
