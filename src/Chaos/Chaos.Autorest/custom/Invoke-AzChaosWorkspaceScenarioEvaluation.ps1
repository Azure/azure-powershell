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
Evaluate a workspace end to end.
.Description
Evaluate a workspace end to end. This is a workflow cmdlet: it discovers the in-scope
resources and evaluates which scenarios apply to them, producing per-scenario
recommendation statuses. Its identity is the discovery-plus-evaluation workflow,
independent of how many API operations implement it.
.Example
Invoke-AzChaosWorkspaceScenarioEvaluation -ResourceGroupName rg -WorkspaceName ws
.Example
Invoke-AzChaosWorkspaceScenarioEvaluation -ResourceGroupName rg -WorkspaceName ws -NoWait
.Outputs
System.Boolean
.Link
https://learn.microsoft.com/powershell/module/az.chaos/invoke-azchaosworkspacescenarioevaluation
#>
function Invoke-AzChaosWorkspaceScenarioEvaluation {
    [OutputType([System.Boolean])]
    [CmdletBinding(DefaultParameterSetName='EvaluateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory, HelpMessage='Name of the workspace.')]
        [System.String]
        ${WorkspaceName},

        [Parameter(Mandatory, HelpMessage='Name of the resource group.')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(HelpMessage='The ID of the target subscription.')]
        [System.String]
        ${SubscriptionId},

        [Parameter(HelpMessage='Run the command asynchronously and return before the evaluation completes.')]
        [System.Management.Automation.SwitchParameter]
        ${NoWait},

        [Parameter(HelpMessage='The DefaultProfile parameter is not functional. Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.')]
        [Alias('AzureRMContext','AzureCredential')]
        [ValidateNotNull()]
        [System.Management.Automation.PSObject]
        ${DefaultProfile}
    )

    process {
        $common = @{
            ResourceGroupName = $ResourceGroupName
            WorkspaceName     = $WorkspaceName
        }
        if ($PSBoundParameters.ContainsKey('SubscriptionId')) { $common['SubscriptionId'] = $SubscriptionId }
        if ($PSBoundParameters.ContainsKey('DefaultProfile')) { $common['DefaultProfile'] = $DefaultProfile }

        # Discover-plus-evaluate is implemented today by the refresh-recommendations operation.
        # Gate the mutation with ShouldProcess so -WhatIf prevents it.
        if ($PSCmdlet.ShouldProcess("Workspace '$WorkspaceName'", 'Evaluate scenarios')) {
            Update-AzChaosWorkspaceRecommendation @common -NoWait:$NoWait
        }
    }
}
