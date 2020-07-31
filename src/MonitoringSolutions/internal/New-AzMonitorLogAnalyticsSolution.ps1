
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
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
Creates or updates the Solution.
.Description
Creates or updates the Solution.
.Example
PS C:\> $workspace = Get-AzOperationalInsightsWorkspace -ResourceGroupName azureps-manual-test -Name monitoringworkspace-2vob7n
PS C:\> New-AzMonitorLogAnalyticsSolution -Type Containers -ResourceGroupName azureps-manual-test -Location $workspace.Location -WorkspaceResourceId $workspace.ResourceId

Name                                   Type                                     Location
----                                   ----                                     --------
Containers(monitoringworkspace-2vob7n) Microsoft.OperationsManagement/solutions East US

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolution
.Link
https://docs.microsoft.com/en-us/powershell/module/az.monitoringsolutions/new-azmonitorloganalyticssolution
#>
function New-AzMonitorLogAnalyticsSolution {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolution])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('SolutionName')]
    [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Path')]
    [System.String]
    # User Solution Name.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Path')]
    [System.String]
    # The name of the resource group to get.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Gets subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Body')]
    [System.String[]]
    # The azure resources that will be contained within the solutions.
    # They will be locked and gets deleted automatically when the solution is deleted.
    ${ContainedResource},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Body')]
    [System.String]
    # Resource location
    ${Location},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Body')]
    [System.String]
    # name of the solution to be created.
    # For Microsoft published solution it should be in the format of solutionType(workspaceName).
    # SolutionType part is case sensitive.
    # For third party solution, it can be anything.
    ${PlanName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Body')]
    [System.String]
    # name of the solution to enabled/add.
    # For Microsoft published gallery solution it should be in the format of OMSGallery/<solutionType>.
    # This is case sensitive
    ${PlanProduct},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Body')]
    [System.String]
    # promotionCode, Not really used now, can you left as empty
    ${PlanPromotionCode},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Body')]
    [System.String]
    # Publisher name.
    # For gallery solution, it is Microsoft.
    ${PlanPublisher},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Body')]
    [System.String[]]
    # The resources that will be referenced from this solution.
    # Deleting any of those solution out of band will break the solution.
    ${ReferencedResource},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionTags]))]
    [System.Collections.Hashtable]
    # Resource tags
    ${Tag},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Body')]
    [System.String]
    # The azure resourceId for the workspace where the solution will be deployed/enabled.
    ${WorkspaceResourceId},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            CreateExpanded = 'Az.MonitoringSolutions.private\New-AzMonitorLogAnalyticsSolution_CreateExpanded';
        }
        if (('CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        throw
    }
}

end {
    try {
        $steppablePipeline.End()
    } catch {
        throw
    }
}
}
