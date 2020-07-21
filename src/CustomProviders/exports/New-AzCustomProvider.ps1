
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
Creates or updates the custom resource provider.
.Description
Creates or updates the custom resource provider.
.Example
PS C:\> New-AzCustomProvider -ResourceGroupName myRG -Name Namespace.Type -Location "West US 2" -ResourceType @{Name="CustomRoute1"; Endpoint="https://www.contoso.com/"}


Location  Name             Type
--------  ----             ----
West US 2 Namespace.Type   Microsoft.CustomProviders/resourceproviders
.Example
PS C:\> New-AzCustomProvider -ResourceGroupName myRG -Name Namespace2.Type -Location "West US 2" -ResourceType @{Name="CustomRoute1"; Endpoint="https://www.contoso.com/"}, @{Name="Associations"; Endpoint="https://contoso.com/myService", RoutingType="Proxy,Cache,Extension"}

Location  Name             Type
--------  ----             ----
West US 2 Namespace2.Type   Microsoft.CustomProviders/resourceproviders

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpManifest
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

ACTION <ICustomRpActionRouteDefinition[]>: A list of actions that the custom resource provider implements.
  Endpoint <String>: The route definition endpoint URI that the custom resource provider will proxy requests to. This can be in the form of a flat URI (e.g. 'https://testendpoint/') or can specify to route via a path (e.g. 'https://testendpoint/{requestPath}')
  Name <String>: The name of the route definition. This becomes the name for the ARM extension (e.g. '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CustomProviders/resourceProviders/{resourceProviderName}/{name}')
  [RoutingType <ActionRouting?>]: The routing types that are supported for action requests.

RESOURCETYPE <ICustomRpResourceTypeRouteDefinition[]>: A list of resource types that the custom resource provider implements.
  Endpoint <String>: The route definition endpoint URI that the custom resource provider will proxy requests to. This can be in the form of a flat URI (e.g. 'https://testendpoint/') or can specify to route via a path (e.g. 'https://testendpoint/{requestPath}')
  Name <String>: The name of the route definition. This becomes the name for the ARM extension (e.g. '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CustomProviders/resourceProviders/{resourceProviderName}/{name}')
  [RoutingType <ResourceTypeRouting?>]: The routing types that are supported for resource requests.

VALIDATION <ICustomRpValidations[]>: A list of validations to run on the custom resource provider's requests.
  Specification <String>: A link to the validation specification. The specification must be hosted on raw.githubusercontent.com.
  [ValidationType <ValidationType?>]: The type of validation to run against a matching request.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.customproviders/new-azcustomprovider
#>
function New-AzCustomProvider {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpManifest])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('ResourceProviderName')]
    [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Category('Path')]
    [System.String]
    # The name of the resource provider.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Category('Path')]
    [System.String]
    # The name of the resource group.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The Azure subscription ID.
    # This is a GUID-formatted string (e.g.
    # 00000000-0000-0000-0000-000000000000)
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Category('Body')]
    [System.String]
    # Resource location
    ${Location},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpActionRouteDefinition[]]
    # A list of actions that the custom resource provider implements.
    # To construct, see NOTES section for ACTION properties and create a hash table.
    ${Action},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpResourceTypeRouteDefinition[]]
    # A list of resource types that the custom resource provider implements.
    # To construct, see NOTES section for RESOURCETYPE properties and create a hash table.
    ${ResourceType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceTags]))]
    [System.Collections.Hashtable]
    # Resource tags
    ${Tag},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpValidations[]]
    # A list of validations to run on the custom resource provider's requests.
    # To construct, see NOTES section for VALIDATION properties and create a hash table.
    ${Validation},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Category('Runtime')]
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
            CreateExpanded = 'Az.CustomProviders.private\New-AzCustomProvider_CreateExpanded';
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
