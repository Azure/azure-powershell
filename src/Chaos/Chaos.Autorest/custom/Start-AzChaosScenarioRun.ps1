# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Start a scenario run for a scenario configuration.
.Description
Start a scenario run for a scenario configuration. This is a workflow cmdlet: it
validates the scenario configuration first and starts the run only if validation
succeeds, mirroring the Azure Portal where validation precedes the Run action. Pass
-SkipValidation to bypass the pre-flight check. For a catalog (non-custom) scenario
the workspace must have been evaluated before a run can start; if it has not, the
cmdlet fails with a friendly error and does not trigger evaluation as a side effect.
.Example
Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg
.Example
Start-AzChaosScenarioRun -ResourceGroupName rg -WorkspaceName ws -ScenarioName sc -Name cfg -SkipValidation -NoWait
.Outputs
System.Boolean
.Link
https://learn.microsoft.com/powershell/module/az.chaos/start-azchaosscenariorun
#>
function Start-AzChaosScenarioRun {
    [OutputType([System.Boolean])]
    [CmdletBinding(DefaultParameterSetName='StartExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory, HelpMessage='Name of the scenario configuration to run.')]
        [Alias('ScenarioConfigurationName')]
        [System.String]
        ${Name},

        [Parameter(Mandatory, HelpMessage='Name of the scenario.')]
        [System.String]
        ${ScenarioName},

        [Parameter(Mandatory, HelpMessage='Name of the workspace.')]
        [System.String]
        ${WorkspaceName},

        [Parameter(Mandatory, HelpMessage='Name of the resource group.')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(HelpMessage='The ID of the target subscription.')]
        [System.String]
        ${SubscriptionId},

        [Parameter(HelpMessage='Bypass the pre-flight validation of the scenario configuration.')]
        [System.Management.Automation.SwitchParameter]
        ${SkipValidation},

        [Parameter(HelpMessage='Run the command asynchronously and return before the scenario run completes.')]
        [System.Management.Automation.SwitchParameter]
        ${NoWait},

        [Parameter(HelpMessage='The DefaultProfile parameter is not functional. Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.')]
        [Alias('AzureRMContext','AzureCredential')]
        [ValidateNotNull()]
        [System.Management.Automation.PSObject]
        ${DefaultProfile}
    )

    process {
        # Parameters common to every plumbing call. ScenarioName is added per call because
        # Get-AzChaosScenario exposes the scenario name as -Name, not -ScenarioName.
        $common = @{
            ResourceGroupName = $ResourceGroupName
            WorkspaceName     = $WorkspaceName
        }
        if ($PSBoundParameters.ContainsKey('SubscriptionId')) { $common['SubscriptionId'] = $SubscriptionId }
        if ($PSBoundParameters.ContainsKey('DefaultProfile')) { $common['DefaultProfile'] = $DefaultProfile }

        # Step 1: validate the scenario configuration first, unless bypassed.
        if (-not $SkipValidation) {
            $isValid = Test-AzChaosScenarioConfiguration @common -ScenarioName $ScenarioName -Name $Name -PassThru -ErrorAction Stop
            if (-not $isValid) {
                Write-Error "Validation failed for scenario configuration '$Name'. The scenario run was not started. Fix the reported validation errors, or re-run with -SkipValidation to bypass the pre-flight check."
                return
            }
        }

        # Step 2: guard catalog (non-custom) scenarios that the workspace has not evaluated.
        # A catalog scenario carries a CreatedFrom template reference; a run needs a prior
        # workspace evaluation. Do not trigger evaluation here as a side effect.
        $scenario = Get-AzChaosScenario @common -Name $ScenarioName -ErrorAction Stop
        if ($null -ne $scenario -and -not [System.String]::IsNullOrEmpty($scenario.CreatedFrom)) {
            $recommendationStatus = $scenario.RecommendationStatus
            if ([System.String]::IsNullOrEmpty($recommendationStatus) -or $recommendationStatus -eq 'NotEvaluated') {
                throw "Scenario '$ScenarioName' is a catalog scenario, but workspace '$WorkspaceName' has not been evaluated yet. Evaluate the workspace first with 'Invoke-AzChaosWorkspaceScenarioEvaluation -ResourceGroupName $ResourceGroupName -WorkspaceName $WorkspaceName', then start the run again."
            }
        }

        # Step 3: execute the run. Gate the mutation with ShouldProcess so -WhatIf prevents it.
        if ($PSCmdlet.ShouldProcess("Scenario configuration '$Name'", 'Start scenario run')) {
            Invoke-AzChaosScenarioConfigurationExecution @common -ScenarioName $ScenarioName -ScenarioConfigurationName $Name -NoWait:$NoWait
        }
    }
}
