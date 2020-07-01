
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
Creates or updates a Dashboard.
.Description
Creates or updates a Dashboard.
.Example
PS C:\> New-AzPortalDashboard -DashboardPath .\resources\dash1.json -ResourceGroupName mydash-rg -DashboardName my-dashboard03

Location Name           Type
-------- ----           ----
eastasia my-dashboard03 Microsoft.Portal/dashboards

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboard
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboard
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

DASHBOARD <IDashboard>: The shared dashboard resource definition.
  Location <String>: Resource location
  [Lens <IDashboardPropertiesLenses>]: The dashboard lenses.
    [(Any) <IDashboardLens>]: This indicates any property can be added to this object.
  [Metadata <IDashboardPropertiesMetadata>]: The dashboard metadata.
    [(Any) <Object>]: This indicates any property can be added to this object.
  [Tag <IDashboardTags>]: Resource tags
    [(Any) <String>]: This indicates any property can be added to this object.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.portal/new-azportaldashboard
#>
function New-AzPortalDashboard {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboard])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('DashboardName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Portal.Category('Path')]
    [System.String]
    # The name of the dashboard.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Portal.Category('Path')]
    [System.String]
    # The name of the resource group.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Portal.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The Azure subscription ID.
    # This is a GUID-formatted string (e.g.
    # 00000000-0000-0000-0000-000000000000)
    ${SubscriptionId},

    [Parameter(ParameterSetName='Create', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Portal.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboard]
    # The shared dashboard resource definition.
    # To construct, see NOTES section for DASHBOARD properties and create a hash table.
    ${Dashboard},

    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Portal.Category('Body')]
    [System.String]
    # Resource location
    ${Location},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Portal.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPropertiesLenses]))]
    [System.Collections.Hashtable]
    # The dashboard lenses.
    ${Lens},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Portal.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPropertiesMetadata]))]
    [System.Collections.Hashtable]
    # The dashboard metadata.
    ${Metadata},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Portal.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardTags]))]
    [System.Collections.Hashtable]
    # Resource tags
    ${Tag},

    [Parameter(ParameterSetName='CreateByFile', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Portal.Category('Body')]
    [System.String]
    # The Path to an existing dashboard template.
    # Dashboard templates may be downloaded from the portal.
    ${DashboardPath},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Portal.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Portal.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Portal.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Portal.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Portal.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Portal.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Portal.Category('Runtime')]
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
            Create = 'Az.Portal.private\New-AzPortalDashboard_Create';
            CreateExpanded = 'Az.Portal.private\New-AzPortalDashboard_CreateExpanded';
            CreateByFile = 'Az.Portal.custom\New-AzPortalDashboard';
        }
        if (('Create', 'CreateExpanded', 'CreateByFile') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
