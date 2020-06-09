
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
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Boolean
.Link
https://docs.microsoft.com/en-us/powershell/module/az.monitoringsolutions/new-azmonitorloganalyticssolution
#>
function New-AzMonitorLogAnalyticsSolution {
    [OutputType([System.Boolean])]
    [CmdletBinding(DefaultParameterSetName = 'CreateExpanded', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(
        # fake
        [Parameter(Mandatory)]
        [System.String]
        # User Solution Name.
        ${WorkspaceName},

        [Parameter(Mandatory)]
        [Alias('SolutionType')]
        [System.String]
        # User Solution Name.
        ${Type},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Path')]
        [System.String]
        # The name of the resource group to get.
        # The name is case insensitive.
        ${ResourceGroupName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # Gets subscription credentials which uniquely identify Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Body')]
        [System.String]
        # Resource location
        ${Location},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(PossibleTypes = ([Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ISolutionTags]))]
        [System.Collections.Hashtable]
        # Resource tags
        ${Tag},

        [Parameter(Mandatory)]
        [Alias('WorkspaceResourceId')]
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Body')]
        [System.String]
        # The azure resourceId for the workspace where the solution will be deployed/enabled.
        ${WorkspaceId},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

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

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

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

    process {
        $solutionName = "$Type($WorkspaceName)"
        $PSBoundParameters.Add('Name', $solutionName) | Out-Null
        $PSBoundParameters.Add('PlanName', $solutionName) | Out-Null
        $PSBoundParameters.Add('PlanProduct', "OMSGallery/$Type") | Out-Null
        $PSBoundParameters.Add('PlanPublisher', "Microsoft") | Out-Null
        $PSBoundParameters.Add('PlanPromotionCode', "") | Out-Null
        $PSBoundParameters.Remove('WorkspaceName') | Out-Null
        $PSBoundParameters.Remove('Type') | Out-Null
        $PSBoundParameters.Remove('WorkspaceId') | Out-Null
        $PSBoundParameters.Add('WorkspaceResourceId', $WorkspaceId) | Out-Null
        Az.MonitoringSolutions.internal\New-AzMonitorLogAnalyticsSolution @PSBoundParameters
    }

}
