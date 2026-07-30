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
Stand up a ready-to-use Chaos Studio workspace end to end.
.Description
Stand up a ready-to-use Chaos Studio workspace end to end. This is a first-day
workflow cmdlet that runs the five setup steps: ensure the resource group exists,
create the workspace with a system-assigned managed identity, grant that identity
the Reader role on each scope, evaluate scenarios, and report the discovered
scenarios plus suggested next commands. Discovery and evaluation run under the
workspace identity and cannot enumerate resources without the Reader grant. Pass
-SkipPermission to opt out of the RBAC grant. Pass -SkipEvaluationWait to run a
single evaluation attempt instead of waiting out Azure Resource Graph propagation.
The default Reader grant enables discovery and evaluation only; most run actions
need additional permissions. Use Repair-AzChaosScenarioConfigurationResourcePermission
after creating a scenario configuration to inspect or grant those permissions.
.Example
Initialize-AzChaosWorkspace -ResourceGroupName rg -WorkspaceName ws -Location eastus -Scope '/subscriptions/00000000-0000-0000-0000-000000000000'
.Example
Initialize-AzChaosWorkspace -ResourceGroupName rg -WorkspaceName ws -Location eastus -Scope $scopes -SkipPermission -SkipEvaluationWait
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IScenario
.Link
https://learn.microsoft.com/powershell/module/az.chaos/initialize-azchaosworkspace
#>
function Initialize-AzChaosWorkspace {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IScenario')]
    [CmdletBinding(DefaultParameterSetName='InitializeExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory, HelpMessage='Name of the workspace.')]
        [System.String]
        ${WorkspaceName},

        [Parameter(Mandatory, HelpMessage='Name of the resource group.')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='The geo-location where the workspace lives.')]
        [System.String]
        ${Location},

        [Parameter(Mandatory, HelpMessage='The list of ARM resource scopes the workspace discovers and evaluates.')]
        [System.String[]]
        ${Scope},

        [Parameter(HelpMessage='The ID of the target subscription.')]
        [System.String]
        ${SubscriptionId},

        [Parameter(HelpMessage='Resource tags applied to the workspace.')]
        [System.Collections.Hashtable]
        ${Tag},

        [Parameter(HelpMessage='The role definition name granted to the workspace identity on each scope. Defaults to Reader.')]
        [System.String]
        ${RoleDefinitionName} = 'Reader',

        [Parameter(HelpMessage='Do not grant the workspace identity an RBAC role on the scopes.')]
        [System.Management.Automation.SwitchParameter]
        ${SkipPermission},

        [Parameter(HelpMessage='Run a single evaluation attempt instead of waiting for Azure Resource Graph propagation.')]
        [System.Management.Automation.SwitchParameter]
        ${SkipEvaluationWait},

        [Parameter(HelpMessage='The DefaultProfile parameter is not functional. Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.')]
        [Alias('AzureRMContext','AzureCredential')]
        [ValidateNotNull()]
        [System.Management.Automation.PSObject]
        ${DefaultProfile}
    )

    process {
        function Assert-AzChaosAzResourcesAvailable {
            $moduleName = 'Az.Resources'
            $requiredCommands = @('Get-AzResourceGroup', 'New-AzResourceGroup', 'New-AzRoleAssignment')

            if (-not (Get-Module -Name $moduleName)) {
                $availableModule = Get-Module -ListAvailable -Name $moduleName | Select-Object -First 1
                if ($null -eq $availableModule) {
                    throw "Initialize-AzChaosWorkspace requires the $moduleName module for resource group and role assignment operations. Install it with: Install-Module $moduleName -Scope CurrentUser"
                }

                try {
                    Import-Module -Name $moduleName -ErrorAction Stop
                }
                catch {
                    throw "Initialize-AzChaosWorkspace found $moduleName but could not load it: $($_.Exception.Message). Update $moduleName or resolve conflicting Az.Accounts versions, then retry."
                }
            }

            $missingCommands = @($requiredCommands | Where-Object { -not (Get-Command -Name $_ -ErrorAction SilentlyContinue) })
            if ($missingCommands.Count -gt 0) {
                throw "Initialize-AzChaosWorkspace requires $moduleName commands that are not available: $($missingCommands -join ', '). Reinstall or update $moduleName, then retry."
            }
        }

        function Test-AzChaosScenarioRecommendationPending {
            param([object[]]$Scenario)

            foreach ($item in @($Scenario)) {
                $status = $item.RecommendationStatus
                $isCatalogScenario = -not [System.String]::IsNullOrEmpty($item.CreatedFrom)
                # Keep in sync with generated\api\Models\ScenarioProperties.cs:178.
                if ($status -in @('NotEvaluated', 'Evaluating') -or ($isCatalogScenario -and [System.String]::IsNullOrEmpty($status))) {
                    return $true
                }

                if (-not [System.String]::IsNullOrEmpty($status) -and $status -notin @('Recommended', 'NotApplicable', 'EvaluationFailed', 'EvaluationCancelled')) {
                    return $true
                }
            }

            return $false
        }

        function Wait-AzChaosWorkspaceScenarioRecommendation {
            param(
                [hashtable]$CommonParameter,
                [string]$ResourceGroupName,
                [string]$WorkspaceName
            )

            $deadline = [System.DateTimeOffset]::UtcNow.AddMinutes(10)
            $intervalSeconds = 15
            $knownStatuses = @('NotEvaluated', 'Recommended', 'NotApplicable', 'Evaluating', 'EvaluationFailed', 'EvaluationCancelled')
            $warnedUnknownStatus = @{}
            $lastErrorMessage = $null

            do {
                try {
                    $scenarios = Get-AzChaosScenario @CommonParameter -ResourceGroupName $ResourceGroupName -WorkspaceName $WorkspaceName -ErrorAction Stop
                    $lastErrorMessage = $null
                }
                catch {
                    $lastErrorMessage = $_.Exception.Message
                    if ([System.DateTimeOffset]::UtcNow -ge $deadline) {
                        throw "Timed out waiting for scenario recommendations in workspace '$WorkspaceName' after 10 minutes. The last Get-AzChaosScenario attempt failed: $lastErrorMessage"
                    }

                    Write-Verbose "Get-AzChaosScenario failed while waiting for workspace '$WorkspaceName': $lastErrorMessage. Waiting $intervalSeconds seconds before retrying."
                    Start-Sleep -Seconds $intervalSeconds
                    continue
                }

                foreach ($scenario in @($scenarios)) {
                    $status = $scenario.RecommendationStatus
                    if (-not [System.String]::IsNullOrEmpty($status) -and $status -notin $knownStatuses -and -not $warnedUnknownStatus.ContainsKey($status)) {
                        Write-Warning "Scenario '$($scenario.Name)' in workspace '$WorkspaceName' returned unrecognized recommendation status '$status'. Continuing to poll until the wait timeout."
                        $warnedUnknownStatus[$status] = $true
                    }
                }

                if (-not (Test-AzChaosScenarioRecommendationPending -Scenario $scenarios)) {
                    if ($null -eq $scenarios -or 0 -eq @($scenarios).Count) {
                        Write-Verbose "No scenarios were discovered for workspace '$WorkspaceName'."
                    }
                    else {
                        Write-Verbose "Scenario recommendations for workspace '$WorkspaceName' reached a terminal state."
                    }
                    return $scenarios
                }

                if ([System.DateTimeOffset]::UtcNow -ge $deadline) {
                    throw "Timed out waiting for scenario recommendations in workspace '$WorkspaceName' to reach Recommended, NotApplicable, EvaluationFailed, or EvaluationCancelled after 10 minutes. Re-run Get-AzChaosScenario to inspect current status, or use -SkipEvaluationWait to skip this propagation wait."
                }

                Write-Verbose "Waiting $intervalSeconds seconds for Azure Resource Graph propagation before checking scenario recommendations again."
                Start-Sleep -Seconds $intervalSeconds
            } while ($true)
        }

        $common = @{}
        if ($PSBoundParameters.ContainsKey('SubscriptionId')) { $common['SubscriptionId'] = $SubscriptionId }
        if ($PSBoundParameters.ContainsKey('DefaultProfile')) { $common['DefaultProfile'] = $DefaultProfile }

        # This dependency is unconditional: -SkipPermission avoids New-AzRoleAssignment,
        # but resource-group discovery/creation still needs Az.Resources.
        Assert-AzChaosAzResourcesAvailable

        if (-not $PSCmdlet.ShouldProcess("Workspace '$WorkspaceName'", 'Initialize Chaos Studio workspace')) {
            return
        }

        # Step 1: ensure the resource group exists.
        $resourceGroup = Get-AzResourceGroup -Name $ResourceGroupName -ErrorAction SilentlyContinue
        if ($null -eq $resourceGroup) {
            Write-Verbose "Creating resource group '$ResourceGroupName' in '$Location'."
            $null = New-AzResourceGroup -Name $ResourceGroupName -Location $Location
        }

        # Step 2: create the workspace with a system-assigned managed identity.
        $workspaceParams = @{
            Name                         = $WorkspaceName
            ResourceGroupName            = $ResourceGroupName
            Location                     = $Location
            Scope                        = $Scope
            EnableSystemAssignedIdentity = $true
        }
        if ($PSBoundParameters.ContainsKey('Tag')) { $workspaceParams['Tag'] = $Tag }
        $workspace = New-AzChaosWorkspace @common @workspaceParams

        # Step 3: grant the workspace identity the Reader role on each scope.
        if (-not $SkipPermission) {
            $principalId = $workspace.IdentityPrincipalId
            if ([System.String]::IsNullOrEmpty($principalId)) {
                Write-Warning "Workspace '$WorkspaceName' has no system-assigned identity principal id. Skipping the RBAC grant. Discovery and evaluation may not enumerate resources."
            }
            else {
                foreach ($resourceScope in $Scope) {
                    Write-Verbose "Granting '$RoleDefinitionName' to identity '$principalId' on '$resourceScope'."
                    $null = New-AzRoleAssignment -ObjectId $principalId -RoleDefinitionName $RoleDefinitionName -Scope $resourceScope -ErrorAction Stop
                }
            }
        }

        # Step 4: evaluate scenarios. Wait for the evaluation and ARG propagation unless a single attempt is requested.
        $evaluationParams = @{
            ResourceGroupName = $ResourceGroupName
            WorkspaceName     = $WorkspaceName
        }
        if ($PSBoundParameters.ContainsKey('SubscriptionId')) { $evaluationParams['SubscriptionId'] = $SubscriptionId }
        if ($PSBoundParameters.ContainsKey('DefaultProfile')) { $evaluationParams['DefaultProfile'] = $DefaultProfile }
        $null = Invoke-AzChaosWorkspaceScenarioEvaluation @evaluationParams

        if (-not $SkipEvaluationWait) {
            $scenarios = Wait-AzChaosWorkspaceScenarioRecommendation -CommonParameter $common -ResourceGroupName $ResourceGroupName -WorkspaceName $WorkspaceName
        }
        else {
            $scenarios = Get-AzChaosScenario @common -ResourceGroupName $ResourceGroupName -WorkspaceName $WorkspaceName -ErrorAction SilentlyContinue
        }

        # Step 5: report the discovered scenarios and suggest next commands.
        Write-Host "Workspace '$WorkspaceName' is ready. Suggested next commands:"
        Write-Host "  Get-AzChaosScenario -ResourceGroupName $ResourceGroupName -WorkspaceName $WorkspaceName"
        Write-Host "  Repair-AzChaosScenarioConfigurationResourcePermission -ResourceGroupName $ResourceGroupName -WorkspaceName $WorkspaceName -ScenarioName <name> -Name <configuration> -WhatIfMode"
        Write-Host "  Start-AzChaosScenarioRun -ResourceGroupName $ResourceGroupName -WorkspaceName $WorkspaceName -ScenarioName <name> -Name <configuration>"

        return $scenarios
    }
}
