
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
Gets the sku details for the given resource type and sku name.
.Description
Gets the sku details for the given resource type and sku name.
.Example
PS C:\> Get-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType" -Sku "default"

Name                        Type
----                        ----
testResourceType            Microsoft.ProviderHub/providerRegistrations/skus
.Example
PS C:\> Get-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType/nestedResourceType" -Sku "default"

Name                                        Type
----                                        ----
testResourceType/nestedResourceType         Microsoft.ProviderHub/providerRegistrations/skus

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuResource
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IProviderHubIdentity>: Identity Parameter
  [Id <String>]: Resource identity path
  [NestedResourceTypeFirst <String>]: The first child resource type.
  [NestedResourceTypeSecond <String>]: The second child resource type.
  [NestedResourceTypeThird <String>]: The third child resource type.
  [NotificationRegistrationName <String>]: The notification registration.
  [ProviderNamespace <String>]: The name of the resource provider hosted within ProviderHub.
  [ResourceType <String>]: The resource type.
  [RolloutName <String>]: The rollout name.
  [Sku <String>]: The SKU.
  [SubscriptionId <String>]: The ID of the target subscription.
.Link
https://docs.microsoft.com/powershell/module/az.providerhub/get-azproviderhubsku
#>
function Get-AzProviderHubSku {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuResource])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='List', Mandatory)]
    [Parameter(ParameterSetName='List3', Mandatory)]
    [Parameter(ParameterSetName='List2', Mandatory)]
    [Parameter(ParameterSetName='List1', Mandatory)]
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The name of the resource provider hosted within ProviderHub.
    ${ProviderNamespace},

    [Parameter(ParameterSetName='List', Mandatory)]
    [Parameter(ParameterSetName='List3', Mandatory)]
    [Parameter(ParameterSetName='List2', Mandatory)]
    [Parameter(ParameterSetName='List1', Mandatory)]
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The resource type.
    ${ResourceType},

    [Parameter(ParameterSetName='List')]
    [Parameter(ParameterSetName='List3')]
    [Parameter(ParameterSetName='List2')]
    [Parameter(ParameterSetName='List1')]
    [Parameter(ParameterSetName='Get')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='List3', Mandatory)]
    [Parameter(ParameterSetName='List2', Mandatory)]
    [Parameter(ParameterSetName='List1', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The first child resource type.
    ${NestedResourceTypeFirst},

    [Parameter(ParameterSetName='List3', Mandatory)]
    [Parameter(ParameterSetName='List2', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The second child resource type.
    ${NestedResourceTypeSecond},

    [Parameter(ParameterSetName='List3', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The third child resource type.
    ${NestedResourceTypeThird},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The SKU.
    ${Sku},

    [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
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
            List = 'Az.ProviderHub.custom\Get-AzProviderHubSku';
            List3 = 'Az.ProviderHub.custom\Get-AzProviderHubSku';
            List2 = 'Az.ProviderHub.custom\Get-AzProviderHubSku';
            List1 = 'Az.ProviderHub.custom\Get-AzProviderHubSku';
            Get = 'Az.ProviderHub.custom\Get-AzProviderHubSku';
            GetViaIdentity = 'Az.ProviderHub.custom\Get-AzProviderHubSku';
        }
        if (('List', 'List3', 'List2', 'List1', 'Get') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
