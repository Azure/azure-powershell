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
    [OutputType([System.Object])]
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

        [Parameter(HelpMessage='The role definition name granted to the workspace identity on each scope.')]
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
        $common = @{}
        if ($PSBoundParameters.ContainsKey('SubscriptionId')) { $common['SubscriptionId'] = $SubscriptionId }
        if ($PSBoundParameters.ContainsKey('DefaultProfile')) { $common['DefaultProfile'] = $DefaultProfile }

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

        # Step 4: evaluate scenarios. Wait for the evaluation unless a single attempt is requested.
        $evaluationParams = @{
            ResourceGroupName = $ResourceGroupName
            WorkspaceName     = $WorkspaceName
        }
        if ($PSBoundParameters.ContainsKey('SubscriptionId')) { $evaluationParams['SubscriptionId'] = $SubscriptionId }
        if ($PSBoundParameters.ContainsKey('DefaultProfile')) { $evaluationParams['DefaultProfile'] = $DefaultProfile }
        $null = Invoke-AzChaosWorkspaceScenarioEvaluation @evaluationParams -NoWait:$SkipEvaluationWait

        # Step 5: report the discovered scenarios and suggest next commands.
        $scenarios = Get-AzChaosScenario @common -ResourceGroupName $ResourceGroupName -WorkspaceName $WorkspaceName -ErrorAction SilentlyContinue

        Write-Host "Workspace '$WorkspaceName' is ready. Suggested next commands:"
        Write-Host "  Get-AzChaosScenario -ResourceGroupName $ResourceGroupName -WorkspaceName $WorkspaceName"
        Write-Host "  Start-AzChaosScenarioRun -ResourceGroupName $ResourceGroupName -WorkspaceName $WorkspaceName -ScenarioName <name> -Name <configuration>"

        return $scenarios
    }
}
