
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
Gets the custom rollout details.
.Description
Gets the custom rollout details.
.Example
PS C:\> Get-AzProviderHubCustomRollout -ProviderNamespace "Microsft.Contoso" -RolloutName "customRollout1"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICustomRollout
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
https://docs.microsoft.com/powershell/module/az.providerhub/get-azproviderhubcustomrollout
#>
function Get-AzProviderHubCustomRollout {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICustomRollout])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='List', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The name of the resource provider hosted within ProviderHub.
    ${ProviderNamespace},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The rollout name.
    ${RolloutName},

    [Parameter(ParameterSetName='Get')]
    [Parameter(ParameterSetName='List')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The ID of the target subscription.
    ${SubscriptionId},

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
            Get = 'Az.ProviderHub.private\Get-AzProviderHubCustomRollout_Get';
            GetViaIdentity = 'Az.ProviderHub.private\Get-AzProviderHubCustomRollout_GetViaIdentity';
            List = 'Az.ProviderHub.private\Get-AzProviderHubCustomRollout_List';
        }
        if (('Get', 'List') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Gets the default rollout details.
.Description
Gets the default rollout details.
.Example
PS C:\> Get-AzProviderHubDefaultRollout -ProviderNamespace "Microsoft.Contoso"
.Example
PS C:\> Get-AzProviderHubDefaultRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "defaultRollout2021w10"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRollout
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
https://docs.microsoft.com/powershell/module/az.providerhub/get-azproviderhubdefaultrollout
#>
function Get-AzProviderHubDefaultRollout {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRollout])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='List', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The name of the resource provider hosted within ProviderHub.
    ${ProviderNamespace},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The rollout name.
    ${RolloutName},

    [Parameter(ParameterSetName='Get')]
    [Parameter(ParameterSetName='List')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The ID of the target subscription.
    ${SubscriptionId},

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
            Get = 'Az.ProviderHub.private\Get-AzProviderHubDefaultRollout_Get';
            GetViaIdentity = 'Az.ProviderHub.private\Get-AzProviderHubDefaultRollout_GetViaIdentity';
            List = 'Az.ProviderHub.private\Get-AzProviderHubDefaultRollout_List';
        }
        if (('Get', 'List') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Gets the notification registration details.
.Description
Gets the notification registration details.
.Example
PS C:\> Get-AzProviderHubNotificationRegistration -ProviderNamespace "Microsoft.Contoso"
.Example
PS C:\> Get-AzProviderHubNotificationRegistration -ProviderNamespace "Microsoft.Contoso" -Name "notificationRegistrationTest"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.INotificationRegistration
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
https://docs.microsoft.com/powershell/module/az.providerhub/get-azproviderhubnotificationregistration
#>
function Get-AzProviderHubNotificationRegistration {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.INotificationRegistration])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Alias('NotificationRegistrationName')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The notification registration.
    ${Name},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='List', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The name of the resource provider hosted within ProviderHub.
    ${ProviderNamespace},

    [Parameter(ParameterSetName='Get')]
    [Parameter(ParameterSetName='List')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The ID of the target subscription.
    ${SubscriptionId},

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
            Get = 'Az.ProviderHub.private\Get-AzProviderHubNotificationRegistration_Get';
            GetViaIdentity = 'Az.ProviderHub.private\Get-AzProviderHubNotificationRegistration_GetViaIdentity';
            List = 'Az.ProviderHub.private\Get-AzProviderHubNotificationRegistration_List';
        }
        if (('Get', 'List') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Gets the provider registration details.
.Description
Gets the provider registration details.
.Example
PS C:\> Get-AzProviderHubProviderRegistration -ProviderNamespace "Microsoft.Contoso"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration
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
https://docs.microsoft.com/powershell/module/az.providerhub/get-azproviderhubproviderregistration
#>
function Get-AzProviderHubProviderRegistration {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The name of the resource provider hosted within ProviderHub.
    ${ProviderNamespace},

    [Parameter(ParameterSetName='Get')]
    [Parameter(ParameterSetName='List')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The ID of the target subscription.
    ${SubscriptionId},

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
            Get = 'Az.ProviderHub.private\Get-AzProviderHubProviderRegistration_Get';
            GetViaIdentity = 'Az.ProviderHub.private\Get-AzProviderHubProviderRegistration_GetViaIdentity';
            List = 'Az.ProviderHub.private\Get-AzProviderHubProviderRegistration_List';
        }
        if (('Get', 'List') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Gets a resource type details in the given subscription and provider.
.Description
Gets a resource type details in the given subscription and provider.
.Example
PS C:\> Get-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso"
.Example
PS C:\> Get-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType1"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration
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
https://docs.microsoft.com/powershell/module/az.providerhub/get-azproviderhubresourcetyperegistration
#>
function Get-AzProviderHubResourceTypeRegistration {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='List', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The name of the resource provider hosted within ProviderHub.
    ${ProviderNamespace},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The resource type.
    ${ResourceType},

    [Parameter(ParameterSetName='Get')]
    [Parameter(ParameterSetName='List')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The ID of the target subscription.
    ${SubscriptionId},

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
            Get = 'Az.ProviderHub.private\Get-AzProviderHubResourceTypeRegistration_Get';
            GetViaIdentity = 'Az.ProviderHub.private\Get-AzProviderHubResourceTypeRegistration_GetViaIdentity';
            List = 'Az.ProviderHub.private\Get-AzProviderHubResourceTypeRegistration_List';
        }
        if (('Get', 'List') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='List', Mandatory)]
    [Parameter(ParameterSetName='List1', Mandatory)]
    [Parameter(ParameterSetName='List2', Mandatory)]
    [Parameter(ParameterSetName='List3', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The name of the resource provider hosted within ProviderHub.
    ${ProviderNamespace},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='List', Mandatory)]
    [Parameter(ParameterSetName='List1', Mandatory)]
    [Parameter(ParameterSetName='List2', Mandatory)]
    [Parameter(ParameterSetName='List3', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The resource type.
    ${ResourceType},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The SKU.
    ${Sku},

    [Parameter(ParameterSetName='Get')]
    [Parameter(ParameterSetName='List')]
    [Parameter(ParameterSetName='List1')]
    [Parameter(ParameterSetName='List2')]
    [Parameter(ParameterSetName='List3')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='List1', Mandatory)]
    [Parameter(ParameterSetName='List2', Mandatory)]
    [Parameter(ParameterSetName='List3', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The first child resource type.
    ${NestedResourceTypeFirst},

    [Parameter(ParameterSetName='List2', Mandatory)]
    [Parameter(ParameterSetName='List3', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The second child resource type.
    ${NestedResourceTypeSecond},

    [Parameter(ParameterSetName='List3', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The third child resource type.
    ${NestedResourceTypeThird},

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
            Get = 'Az.ProviderHub.private\Get-AzProviderHubSku_Get';
            GetViaIdentity = 'Az.ProviderHub.private\Get-AzProviderHubSku_GetViaIdentity';
            List = 'Az.ProviderHub.private\Get-AzProviderHubSku_List';
            List1 = 'Az.ProviderHub.private\Get-AzProviderHubSku_List1';
            List2 = 'Az.ProviderHub.private\Get-AzProviderHubSku_List2';
            List3 = 'Az.ProviderHub.private\Get-AzProviderHubSku_List3';
        }
        if (('Get', 'List', 'List1', 'List2', 'List3') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Checkin the manifest.
.Description
Checkin the manifest.
.Example
PS C:\> Invoke-AzProviderHubManifestCheckin -ProviderNamespace "Microsoft.Contoso" -BaselineArmManifestLocation "NorthEurope" -Environment "Canary"
.Example
PS C:\> Invoke-AzProviderHubManifestCheckin -ProviderNamespace "Microsoft.Contoso" -BaselineArmManifestLocation "EastUS2EUAP" -Environment "Prod"

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckinManifestInfo
.Link
https://docs.microsoft.com/powershell/module/az.providerhub/invoke-azproviderhubmanifestcheckin
#>
function Invoke-AzProviderHubManifestCheckin {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICheckinManifestInfo])]
[CmdletBinding(DefaultParameterSetName='ManifestExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The name of the resource provider hosted within ProviderHub.
    ${ProviderNamespace},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # The baseline ARM manifest location supplied to the checkin manifest operation.
    ${BaselineArmManifestLocation},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # The environment supplied to the checkin manifest operation.
    ${Environment},

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
            ManifestExpanded = 'Az.ProviderHub.private\Invoke-AzProviderHubManifestCheckin_ManifestExpanded';
        }
        if (('ManifestExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Creates or updates the rollout details.
.Description
Creates or updates the rollout details.
.Example
PS C:\> New-AzProviderHubCustomRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "customRollout1" -CanaryRegion "Eastus2EUAP"

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICustomRollout
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

SPECIFICATIONPROVIDERREGISTRATION <IProviderRegistration>: .
  [Capability <IResourceProviderCapabilities[]>]: 
    Effect <ResourceProviderCapabilitiesEffect>: 
    QuotaId <String>: 
    [RequiredFeature <String[]>]: 
  [FeatureRuleRequiredFeaturesPolicy <String>]: 
  [ManagementIncidentContactEmail <String>]: 
  [ManagementIncidentRoutingService <String>]: 
  [ManagementIncidentRoutingTeam <String>]: 
  [ManagementManifestOwner <String[]>]: 
  [ManagementResourceAccessPolicy <String>]: 
  [ManagementResourceAccessRole <IAny[]>]: 
  [ManagementSchemaOwner <String[]>]: 
  [ManagementServiceTreeInfo <IServiceTreeInfo[]>]: 
    [ComponentId <String>]: 
    [ServiceId <String>]: 
  [Metadata <IAny>]: Any object
  [Namespace <String>]: 
  [ProviderAuthenticationAllowedAudience <String[]>]: 
  [ProviderAuthorization <IResourceProviderAuthorization[]>]: 
    [ApplicationId <String>]: 
    [ManagedByRoleDefinitionId <String>]: 
    [RoleDefinitionId <String>]: 
  [ProviderHubMetadataProviderAuthenticationAllowedAudience <String[]>]: 
  [ProviderHubMetadataProviderAuthorization <IResourceProviderAuthorization[]>]: 
  [ProviderType <ResourceProviderType?>]: 
  [ProviderVersion <String>]: 
  [ProvisioningState <ProvisioningState?>]: 
  [RequestHeaderOptionOptInHeader <OptInHeaderType?>]: 
  [RequiredFeature <String[]>]: 
  [SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl <TimeSpan?>]: 
  [SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction <ISubscriptionStateOverrideAction[]>]: 
    Action <SubscriptionNotificationOperation>: 
    State <SubscriptionTransitioningState>: 
  [TemplateDeploymentOptionPreflightOption <PreflightOption[]>]: 
  [TemplateDeploymentOptionPreflightSupported <Boolean?>]: 
  [ThirdPartyProviderAuthorizationAuthorization <ILightHouseAuthorization[]>]: 
    PrincipalId <String>: 
    RoleDefinitionId <String>: 
  [ThirdPartyProviderAuthorizationManagedByTenantId <String>]: 

SPECIFICATIONRESOURCETYPEREGISTRATION <IResourceTypeRegistration[]>: .
  [AllowedUnauthorizedAction <String[]>]: 
  [AuthorizationActionMapping <IAuthorizationActionMapping[]>]: 
    [Desired <String>]: 
    [Original <String>]: 
  [CheckNameAvailabilitySpecificationEnableDefaultValidation <Boolean?>]: 
  [CheckNameAvailabilitySpecificationResourceTypesWithCustomValidation <String[]>]: 
  [DefaultApiVersion <String>]: 
  [DisallowedActionVerb <String[]>]: 
  [EnableAsyncOperation <Boolean?>]: 
  [EnableThirdPartyS2S <Boolean?>]: 
  [Endpoint <IResourceTypeEndpoint[]>]: 
    [ApiVersion <String[]>]: 
    [Enabled <Boolean?>]: 
    [Extension <IResourceTypeExtension[]>]: 
      [EndpointUri <String>]: 
      [ExtensionCategory <ExtensionCategory[]>]: 
      [Timeout <TimeSpan?>]: 
    [FeatureRuleRequiredFeaturesPolicy <String>]: 
    [Location <String[]>]: 
    [RequiredFeature <String[]>]: 
    [Timeout <TimeSpan?>]: 
  [ExtendedLocation <IExtendedLocationOptions[]>]: 
    [SupportedPolicy <String>]: 
    [Type <String>]: 
  [FeatureRuleRequiredFeaturesPolicy <String>]: 
  [IdentityManagementApplicationId <String>]: 
  [IdentityManagementType <IdentityManagementTypes?>]: 
  [IsPureProxy <Boolean?>]: 
  [LinkedAccessCheck <ILinkedAccessCheck[]>]: 
    [ActionName <String>]: 
    [LinkedAction <String>]: 
    [LinkedActionVerb <String>]: 
    [LinkedProperty <String>]: 
    [LinkedType <String>]: 
  [LoggingRule <ILoggingRule[]>]: 
    Action <String>: 
    DetailLevel <LoggingDetails>: 
    Direction <LoggingDirections>: 
    [HiddenPropertyPathHiddenPathsOnRequest <String[]>]: 
    [HiddenPropertyPathHiddenPathsOnResponse <String[]>]: 
  [MarketplaceType <String>]: 
  [ProvisioningState <ProvisioningState?>]: 
  [Regionality <Regionality?>]: 
  [RequestHeaderOptionOptInHeader <OptInHeaderType?>]: 
  [RequiredFeature <String[]>]: 
  [ResourceCreationBeginRequest <ExtensionOptionType[]>]: 
  [ResourceCreationBeginResponse <ExtensionOptionType[]>]: 
  [ResourceDeletionPolicy <ResourceDeletionPolicy?>]: 
  [ResourceMovePolicyCrossResourceGroupMoveEnabled <Boolean?>]: 
  [ResourceMovePolicyCrossSubscriptionMoveEnabled <Boolean?>]: 
  [ResourceMovePolicyValidationRequired <Boolean?>]: 
  [RoutingType <RoutingType?>]: 
  [ServiceTreeInfo <IServiceTreeInfo[]>]: 
    [ComponentId <String>]: 
    [ServiceId <String>]: 
  [SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl <TimeSpan?>]: 
  [SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction <ISubscriptionStateOverrideAction[]>]: 
    Action <SubscriptionNotificationOperation>: 
    State <SubscriptionTransitioningState>: 
  [SubscriptionStateRule <ISubscriptionStateRule[]>]: 
    [AllowedAction <String[]>]: 
    [State <SubscriptionState?>]: 
  [SwaggerSpecification <ISwaggerSpecification[]>]: 
    [ApiVersion <String[]>]: 
    [SwaggerSpecFolderUri <String>]: 
  [TemplateDeploymentOptionPreflightOption <PreflightOption[]>]: 
  [TemplateDeploymentOptionPreflightSupported <Boolean?>]: 
  [ThrottlingRule <IThrottlingRule[]>]: 
    Action <String>: 
    Metric <IThrottlingMetric[]>: 
      Limit <Int64>: 
      Type <ThrottlingMetricType>: 
      [Interval <TimeSpan?>]: 
    [RequiredFeature <String[]>]: 
.Link
https://docs.microsoft.com/powershell/module/az.providerhub/new-azproviderhubcustomrollout
#>
function New-AzProviderHubCustomRollout {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICustomRollout])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The name of the resource provider hosted within ProviderHub.
    ${ProviderNamespace},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The rollout name.
    ${RolloutName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${CanaryRegion},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState]
    # .
    ${ProvisioningState},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration]
    # .
    # To construct, see NOTES section for SPECIFICATIONPROVIDERREGISTRATION properties and create a hash table.
    ${SpecificationProviderRegistration},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration[]]
    # .
    # To construct, see NOTES section for SPECIFICATIONRESOURCETYPEREGISTRATION properties and create a hash table.
    ${SpecificationResourceTypeRegistration},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${StatusCompletedRegion},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICustomRolloutStatusFailedOrSkippedRegions]))]
    [System.Collections.Hashtable]
    # Dictionary of <ExtendedErrorInfo>
    ${StatusFailedOrSkippedRegion},

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
            CreateExpanded = 'Az.ProviderHub.private\New-AzProviderHubCustomRollout_CreateExpanded';
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
Creates or updates the rollout details.
.Description
Creates or updates the rollout details.
.Example
PS C:\> New-AzProviderHubDefaultRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "defaultRollout2021w10" -CanarySkipRegion "brazilus" -NoWait

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRollout
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

SPECIFICATIONPROVIDERREGISTRATION <IProviderRegistration>: .
  [Capability <IResourceProviderCapabilities[]>]: 
    Effect <ResourceProviderCapabilitiesEffect>: 
    QuotaId <String>: 
    [RequiredFeature <String[]>]: 
  [FeatureRuleRequiredFeaturesPolicy <String>]: 
  [ManagementIncidentContactEmail <String>]: 
  [ManagementIncidentRoutingService <String>]: 
  [ManagementIncidentRoutingTeam <String>]: 
  [ManagementManifestOwner <String[]>]: 
  [ManagementResourceAccessPolicy <String>]: 
  [ManagementResourceAccessRole <IAny[]>]: 
  [ManagementSchemaOwner <String[]>]: 
  [ManagementServiceTreeInfo <IServiceTreeInfo[]>]: 
    [ComponentId <String>]: 
    [ServiceId <String>]: 
  [Metadata <IAny>]: Any object
  [Namespace <String>]: 
  [ProviderAuthenticationAllowedAudience <String[]>]: 
  [ProviderAuthorization <IResourceProviderAuthorization[]>]: 
    [ApplicationId <String>]: 
    [ManagedByRoleDefinitionId <String>]: 
    [RoleDefinitionId <String>]: 
  [ProviderHubMetadataProviderAuthenticationAllowedAudience <String[]>]: 
  [ProviderHubMetadataProviderAuthorization <IResourceProviderAuthorization[]>]: 
  [ProviderType <ResourceProviderType?>]: 
  [ProviderVersion <String>]: 
  [ProvisioningState <ProvisioningState?>]: 
  [RequestHeaderOptionOptInHeader <OptInHeaderType?>]: 
  [RequiredFeature <String[]>]: 
  [SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl <TimeSpan?>]: 
  [SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction <ISubscriptionStateOverrideAction[]>]: 
    Action <SubscriptionNotificationOperation>: 
    State <SubscriptionTransitioningState>: 
  [TemplateDeploymentOptionPreflightOption <PreflightOption[]>]: 
  [TemplateDeploymentOptionPreflightSupported <Boolean?>]: 
  [ThirdPartyProviderAuthorizationAuthorization <ILightHouseAuthorization[]>]: 
    PrincipalId <String>: 
    RoleDefinitionId <String>: 
  [ThirdPartyProviderAuthorizationManagedByTenantId <String>]: 

SPECIFICATIONRESOURCETYPEREGISTRATION <IResourceTypeRegistration[]>: .
  [AllowedUnauthorizedAction <String[]>]: 
  [AuthorizationActionMapping <IAuthorizationActionMapping[]>]: 
    [Desired <String>]: 
    [Original <String>]: 
  [CheckNameAvailabilitySpecificationEnableDefaultValidation <Boolean?>]: 
  [CheckNameAvailabilitySpecificationResourceTypesWithCustomValidation <String[]>]: 
  [DefaultApiVersion <String>]: 
  [DisallowedActionVerb <String[]>]: 
  [EnableAsyncOperation <Boolean?>]: 
  [EnableThirdPartyS2S <Boolean?>]: 
  [Endpoint <IResourceTypeEndpoint[]>]: 
    [ApiVersion <String[]>]: 
    [Enabled <Boolean?>]: 
    [Extension <IResourceTypeExtension[]>]: 
      [EndpointUri <String>]: 
      [ExtensionCategory <ExtensionCategory[]>]: 
      [Timeout <TimeSpan?>]: 
    [FeatureRuleRequiredFeaturesPolicy <String>]: 
    [Location <String[]>]: 
    [RequiredFeature <String[]>]: 
    [Timeout <TimeSpan?>]: 
  [ExtendedLocation <IExtendedLocationOptions[]>]: 
    [SupportedPolicy <String>]: 
    [Type <String>]: 
  [FeatureRuleRequiredFeaturesPolicy <String>]: 
  [IdentityManagementApplicationId <String>]: 
  [IdentityManagementType <IdentityManagementTypes?>]: 
  [IsPureProxy <Boolean?>]: 
  [LinkedAccessCheck <ILinkedAccessCheck[]>]: 
    [ActionName <String>]: 
    [LinkedAction <String>]: 
    [LinkedActionVerb <String>]: 
    [LinkedProperty <String>]: 
    [LinkedType <String>]: 
  [LoggingRule <ILoggingRule[]>]: 
    Action <String>: 
    DetailLevel <LoggingDetails>: 
    Direction <LoggingDirections>: 
    [HiddenPropertyPathHiddenPathsOnRequest <String[]>]: 
    [HiddenPropertyPathHiddenPathsOnResponse <String[]>]: 
  [MarketplaceType <String>]: 
  [ProvisioningState <ProvisioningState?>]: 
  [Regionality <Regionality?>]: 
  [RequestHeaderOptionOptInHeader <OptInHeaderType?>]: 
  [RequiredFeature <String[]>]: 
  [ResourceCreationBeginRequest <ExtensionOptionType[]>]: 
  [ResourceCreationBeginResponse <ExtensionOptionType[]>]: 
  [ResourceDeletionPolicy <ResourceDeletionPolicy?>]: 
  [ResourceMovePolicyCrossResourceGroupMoveEnabled <Boolean?>]: 
  [ResourceMovePolicyCrossSubscriptionMoveEnabled <Boolean?>]: 
  [ResourceMovePolicyValidationRequired <Boolean?>]: 
  [RoutingType <RoutingType?>]: 
  [ServiceTreeInfo <IServiceTreeInfo[]>]: 
    [ComponentId <String>]: 
    [ServiceId <String>]: 
  [SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl <TimeSpan?>]: 
  [SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction <ISubscriptionStateOverrideAction[]>]: 
    Action <SubscriptionNotificationOperation>: 
    State <SubscriptionTransitioningState>: 
  [SubscriptionStateRule <ISubscriptionStateRule[]>]: 
    [AllowedAction <String[]>]: 
    [State <SubscriptionState?>]: 
  [SwaggerSpecification <ISwaggerSpecification[]>]: 
    [ApiVersion <String[]>]: 
    [SwaggerSpecFolderUri <String>]: 
  [TemplateDeploymentOptionPreflightOption <PreflightOption[]>]: 
  [TemplateDeploymentOptionPreflightSupported <Boolean?>]: 
  [ThrottlingRule <IThrottlingRule[]>]: 
    Action <String>: 
    Metric <IThrottlingMetric[]>: 
      Limit <Int64>: 
      Type <ThrottlingMetricType>: 
      [Interval <TimeSpan?>]: 
    [RequiredFeature <String[]>]: 
.Link
https://docs.microsoft.com/powershell/module/az.providerhub/new-azproviderhubdefaultrollout
#>
function New-AzProviderHubDefaultRollout {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRollout])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The name of the resource provider hosted within ProviderHub.
    ${ProviderNamespace},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The rollout name.
    ${RolloutName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${CanaryRegion},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${CanarySkipRegion},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${HighTrafficRegion},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.TimeSpan]
    # .
    ${HighTrafficWaitDuration},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${LowTrafficRegion},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.TimeSpan]
    # .
    ${LowTrafficWaitDuration},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${MediumTrafficRegion},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.TimeSpan]
    # .
    ${MediumTrafficWaitDuration},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState]
    # .
    ${ProvisioningState},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${RestOfTheWorldGroupOneRegion},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.TimeSpan]
    # .
    ${RestOfTheWorldGroupOneWaitDuration},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${RestOfTheWorldGroupTwoRegion},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.TimeSpan]
    # .
    ${RestOfTheWorldGroupTwoWaitDuration},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration]
    # .
    # To construct, see NOTES section for SPECIFICATIONPROVIDERREGISTRATION properties and create a hash table.
    ${SpecificationProviderRegistration},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration[]]
    # .
    # To construct, see NOTES section for SPECIFICATIONRESOURCETYPEREGISTRATION properties and create a hash table.
    ${SpecificationResourceTypeRegistration},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${StatusCompletedRegion},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRolloutStatusBaseFailedOrSkippedRegions]))]
    [System.Collections.Hashtable]
    # Dictionary of <ExtendedErrorInfo>
    ${StatusFailedOrSkippedRegion},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TrafficRegionCategory])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TrafficRegionCategory]
    # .
    ${StatusNextTrafficRegion},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.DateTime]
    # .
    ${StatusNextTrafficRegionScheduledTime},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SubscriptionReregistrationResult])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SubscriptionReregistrationResult]
    # .
    ${StatusSubscriptionReregistrationResult},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

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
            CreateExpanded = 'Az.ProviderHub.private\New-AzProviderHubDefaultRollout_CreateExpanded';
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
Generates the manifest for the given provider.
.Description
Generates the manifest for the given provider.
.Example
PS C:\> New-AzProviderHubManifest -ProviderNamespace "Microsoft.Contoso"
.Example
PS C:\> New-AzProviderHubManifest -ProviderNamespace "Microsoft.Contoso"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifest
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
https://docs.microsoft.com/powershell/module/az.providerhub/new-azproviderhubmanifest
#>
function New-AzProviderHubManifest {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderManifest])]
[CmdletBinding(DefaultParameterSetName='Generate', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Generate', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The name of the resource provider hosted within ProviderHub.
    ${ProviderNamespace},

    [Parameter(ParameterSetName='Generate')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='GenerateViaIdentity', Mandatory, ValueFromPipeline)]
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
            Generate = 'Az.ProviderHub.private\New-AzProviderHubManifest_Generate';
            GenerateViaIdentity = 'Az.ProviderHub.private\New-AzProviderHubManifest_GenerateViaIdentity';
        }
        if (('Generate') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Creates or updates a notification registration.
.Description
Creates or updates a notification registration.
.Example
PS C:\> New-AzProviderHubNotificationRegistration -ProviderNamespace "Microsoft.Contoso" -Name "notificationRegistrationTest" -NotificationMode "EventHub" -MessageScope "RegisteredSubscriptions" -IncludedEvent "*/write", "Microsoft.Contoso/testResourceType/delete" -NotificationEndpoint @{Location = "", "East US"; NotificationDestination = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/mgmtexp-eastus/providers/Microsoft.EventHub/namespaces/unitedstates-mgmtexpint/eventhubs/armlinkednotifications"}
.Example
PS C:\> New-AzProviderHubNotificationRegistration -ProviderNamespace "Microsoft.Contoso" -Name "notificationRegistrationTest" -NotificationMode "EventHub" -MessageScope "RegisteredSubscriptions" -IncludedEvent "*/write", "Microsoft.Contoso/testResourceType/delete" -NotificationEndpoint @{Location = "", "East US"; NotificationDestination = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/mgmtexp-eastus/providers/Microsoft.EventHub/namespaces/unitedstates-mgmtexpint/eventhubs/armlinkednotifications"}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.INotificationRegistration
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

NOTIFICATIONENDPOINT <INotificationEndpoint[]>: .
  [Location <String[]>]: 
  [NotificationDestination <String>]: 
.Link
https://docs.microsoft.com/powershell/module/az.providerhub/new-azproviderhubnotificationregistration
#>
function New-AzProviderHubNotificationRegistration {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.INotificationRegistration])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('NotificationRegistrationName')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The notification registration.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The name of the resource provider hosted within ProviderHub.
    ${ProviderNamespace},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${IncludedEvent},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.MessageScope])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.MessageScope]
    # .
    ${MessageScope},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.INotificationEndpoint[]]
    # .
    # To construct, see NOTES section for NOTIFICATIONENDPOINT properties and create a hash table.
    ${NotificationEndpoint},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.NotificationMode])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.NotificationMode]
    # .
    ${NotificationMode},

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
            CreateExpanded = 'Az.ProviderHub.private\New-AzProviderHubNotificationRegistration_CreateExpanded';
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
Creates or updates the provider registration.
.Description
Creates or updates the provider registration.
.Example
PS C:\> New-AzProviderHubProviderRegistration -ProviderNamespace "Microsoft.Contoso" -ProviderHubMetadataProviderAuthenticationAllowedAudience "https://management.core.windows.net/" -ProviderHubMetadataProviderAuthorization @{ApplicationId = "00000000-0000-0000-0000-000000000000"; RoleDefinitionId = "00000000-0000-0000-0000-000000000000"} -Namespace "Microsoft.Contoso" -ProviderVersion "2.0" -ProviderType "Internal" -ManagementManifestOwner "SPARTA-PlatformServiceAdministrator" -ManagementIncidentContactEmail "help@microsoft.com" -ManagementIncidentRoutingService "Contoso Service" -ManagementIncidentRoutingTeam "Contoso Team" -ManagementServiceTreeInfo @{ComponentId = "00000000-0000-0000-0000-000000000000"; ServiceId = "00000000-0000-0000-0000-000000000000"} -Capability @{QuotaId = "CSP_2015-05-01"; Effect = "Allow"}, @{QuotaId = "CSP_MG_2017-12-01"; Effect = "Allow"}
.Example
PS C:\> New-AzProviderHubProviderRegistration -ProviderNamespace "Microsoft.Contoso" -ProviderHubMetadataProviderAuthenticationAllowedAudience "https://management.core.windows.net/" -ProviderHubMetadataProviderAuthorization @{ApplicationId = "00000000-0000-0000-0000-000000000000"; RoleDefinitionId = "00000000-0000-0000-0000-000000000000"} -Namespace "Microsoft.Contoso" -ProviderVersion "2.0" -ProviderType "Hidden" -ManagementManifestOwner "SPARTA-PlatformServiceAdministrator" -ManagementIncidentContactEmail "help@microsoft.com" -ManagementIncidentRoutingService "Contoso Service" -ManagementIncidentRoutingTeam "Contoso Team" -ManagementServiceTreeInfo @{ComponentId = "00000000-0000-0000-0000-000000000000"; ServiceId = "00000000-0000-0000-0000-000000000000"} -Capability @{QuotaId = "CSP_2015-05-01"; Effect = "Allow"}, @{QuotaId = "CSP_MG_2017-12-01"; Effect = "Allow"}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

CAPABILITY <IResourceProviderCapabilities[]>: .
  Effect <ResourceProviderCapabilitiesEffect>: 
  QuotaId <String>: 
  [RequiredFeature <String[]>]: 

MANAGEMENTSERVICETREEINFO <IServiceTreeInfo[]>: .
  [ComponentId <String>]: 
  [ServiceId <String>]: 

PROVIDERAUTHORIZATION <IResourceProviderAuthorization[]>: .
  [ApplicationId <String>]: 
  [ManagedByRoleDefinitionId <String>]: 
  [RoleDefinitionId <String>]: 

PROVIDERHUBMETADATAPROVIDERAUTHORIZATION <IResourceProviderAuthorization[]>: .
  [ApplicationId <String>]: 
  [ManagedByRoleDefinitionId <String>]: 
  [RoleDefinitionId <String>]: 

SUBSCRIPTIONLIFECYCLENOTIFICATIONSPECIFICATIONSUBSCRIPTIONSTATEOVERRIDEACTION <ISubscriptionStateOverrideAction[]>: .
  Action <SubscriptionNotificationOperation>: 
  State <SubscriptionTransitioningState>: 

THIRDPARTYPROVIDERAUTHORIZATIONAUTHORIZATION <ILightHouseAuthorization[]>: .
  PrincipalId <String>: 
  RoleDefinitionId <String>: 
.Link
https://docs.microsoft.com/powershell/module/az.providerhub/new-azproviderhubproviderregistration
#>
function New-AzProviderHubProviderRegistration {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The name of the resource provider hosted within ProviderHub.
    ${ProviderNamespace},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderCapabilities[]]
    # .
    # To construct, see NOTES section for CAPABILITY properties and create a hash table.
    ${Capability},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${FeatureRuleRequiredFeaturesPolicy},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${ManagementIncidentContactEmail},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${ManagementIncidentRoutingService},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${ManagementIncidentRoutingTeam},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${ManagementManifestOwner},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${ManagementResourceAccessPolicy},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny[]]
    # .
    ${ManagementResourceAccessRole},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${ManagementSchemaOwner},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo[]]
    # .
    # To construct, see NOTES section for MANAGEMENTSERVICETREEINFO properties and create a hash table.
    ${ManagementServiceTreeInfo},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny]
    # Any object
    ${Metadata},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${Namespace},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${ProviderAuthenticationAllowedAudience},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization[]]
    # .
    # To construct, see NOTES section for PROVIDERAUTHORIZATION properties and create a hash table.
    ${ProviderAuthorization},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${ProviderHubMetadataProviderAuthenticationAllowedAudience},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceProviderAuthorization[]]
    # .
    # To construct, see NOTES section for PROVIDERHUBMETADATAPROVIDERAUTHORIZATION properties and create a hash table.
    ${ProviderHubMetadataProviderAuthorization},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceProviderType])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceProviderType]
    # .
    ${ProviderType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${ProviderVersion},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState]
    # .
    ${ProvisioningState},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.OptInHeaderType])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.OptInHeaderType]
    # .
    ${RequestHeaderOptionOptInHeader},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${RequiredFeature},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.TimeSpan]
    # .
    ${SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateOverrideAction[]]
    # .
    # To construct, see NOTES section for SUBSCRIPTIONLIFECYCLENOTIFICATIONSPECIFICATIONSUBSCRIPTIONSTATEOVERRIDEACTION properties and create a hash table.
    ${SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.PreflightOption])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.PreflightOption[]]
    # .
    ${TemplateDeploymentOptionPreflightOption},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${TemplateDeploymentOptionPreflightSupported},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILightHouseAuthorization[]]
    # .
    # To construct, see NOTES section for THIRDPARTYPROVIDERAUTHORIZATIONAUTHORIZATION properties and create a hash table.
    ${ThirdPartyProviderAuthorizationAuthorization},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${ThirdPartyProviderAuthorizationManagedByTenantId},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

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
            CreateExpanded = 'Az.ProviderHub.private\New-AzProviderHubProviderRegistration_CreateExpanded';
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
Creates or updates a resource type.
.Description
Creates or updates a resource type.
.Example
PS C:\> New-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType" -RoutingType "Default" -Regionality "Regional" -Endpoint @{ApiVersion = "2021-01-01-preview"; Location = "West US 2", "East US 2 EUAP"; RequiredFeature = "Microsoft.Contoso/SampleApp" } -SwaggerSpecification @{ApiVersion = "2021-01-01-preview"; SwaggerSpecFolderUri = "https://github.com/Azure/azure-rest-api-specs-pr/blob/RPSaaSMaster/specification/rpsaas/resource-manager/Microsoft.Contoso/" } -EnableAsyncOperation
.Example
PS C:\> New-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType" -RoutingType "Default" -Regionality "Regional" -Endpoint @{ApiVersion = "2021-01-01-preview"; Location = "West US 2", "East US 2 EUAP"; RequiredFeature = "Microsoft.Contoso/SampleApp" } -SwaggerSpecification @{ApiVersion = "2021-01-01-preview"; SwaggerSpecFolderUri = "https://github.com/Azure/azure-rest-api-specs-pr/blob/RPSaaSMaster/specification/rpsaas/resource-manager/Microsoft.Contoso/" } -EnableAsyncOperation

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

AUTHORIZATIONACTIONMAPPING <IAuthorizationActionMapping[]>: .
  [Desired <String>]: 
  [Original <String>]: 

ENDPOINT <IResourceTypeEndpoint[]>: .
  [ApiVersion <String[]>]: 
  [Enabled <Boolean?>]: 
  [Extension <IResourceTypeExtension[]>]: 
    [EndpointUri <String>]: 
    [ExtensionCategory <ExtensionCategory[]>]: 
    [Timeout <TimeSpan?>]: 
  [FeatureRuleRequiredFeaturesPolicy <String>]: 
  [Location <String[]>]: 
  [RequiredFeature <String[]>]: 
  [Timeout <TimeSpan?>]: 

EXTENDEDLOCATION <IExtendedLocationOptions[]>: .
  [SupportedPolicy <String>]: 
  [Type <String>]: 

LINKEDACCESSCHECK <ILinkedAccessCheck[]>: .
  [ActionName <String>]: 
  [LinkedAction <String>]: 
  [LinkedActionVerb <String>]: 
  [LinkedProperty <String>]: 
  [LinkedType <String>]: 

LOGGINGRULE <ILoggingRule[]>: .
  Action <String>: 
  DetailLevel <LoggingDetails>: 
  Direction <LoggingDirections>: 
  [HiddenPropertyPathHiddenPathsOnRequest <String[]>]: 
  [HiddenPropertyPathHiddenPathsOnResponse <String[]>]: 

SERVICETREEINFO <IServiceTreeInfo[]>: .
  [ComponentId <String>]: 
  [ServiceId <String>]: 

SUBSCRIPTIONLIFECYCLENOTIFICATIONSPECIFICATIONSUBSCRIPTIONSTATEOVERRIDEACTION <ISubscriptionStateOverrideAction[]>: .
  Action <SubscriptionNotificationOperation>: 
  State <SubscriptionTransitioningState>: 

SUBSCRIPTIONSTATERULE <ISubscriptionStateRule[]>: .
  [AllowedAction <String[]>]: 
  [State <SubscriptionState?>]: 

SWAGGERSPECIFICATION <ISwaggerSpecification[]>: .
  [ApiVersion <String[]>]: 
  [SwaggerSpecFolderUri <String>]: 

THROTTLINGRULE <IThrottlingRule[]>: .
  Action <String>: 
  Metric <IThrottlingMetric[]>: 
    Limit <Int64>: 
    Type <ThrottlingMetricType>: 
    [Interval <TimeSpan?>]: 
  [RequiredFeature <String[]>]: 
.Link
https://docs.microsoft.com/powershell/module/az.providerhub/new-azproviderhubresourcetyperegistration
#>
function New-AzProviderHubResourceTypeRegistration {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The name of the resource provider hosted within ProviderHub.
    ${ProviderNamespace},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The resource type.
    ${ResourceType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${AllowedUnauthorizedAction},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IAuthorizationActionMapping[]]
    # .
    # To construct, see NOTES section for AUTHORIZATIONACTIONMAPPING properties and create a hash table.
    ${AuthorizationActionMapping},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${CheckNameAvailabilitySpecificationEnableDefaultValidation},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${CheckNameAvailabilitySpecificationResourceTypesWithCustomValidation},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${DefaultApiVersion},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${DisallowedActionVerb},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${EnableAsyncOperation},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${EnableThirdPartyS2S},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeEndpoint[]]
    # .
    # To construct, see NOTES section for ENDPOINT properties and create a hash table.
    ${Endpoint},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IExtendedLocationOptions[]]
    # .
    # To construct, see NOTES section for EXTENDEDLOCATION properties and create a hash table.
    ${ExtendedLocation},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${FeatureRuleRequiredFeaturesPolicy},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${IdentityManagementApplicationId},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.IdentityManagementTypes]
    # .
    ${IdentityManagementType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${IsPureProxy},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedAccessCheck[]]
    # .
    # To construct, see NOTES section for LINKEDACCESSCHECK properties and create a hash table.
    ${LinkedAccessCheck},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingRule[]]
    # .
    # To construct, see NOTES section for LOGGINGRULE properties and create a hash table.
    ${LoggingRule},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${MarketplaceType},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState]
    # .
    ${ProvisioningState},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.Regionality])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.Regionality]
    # .
    ${Regionality},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.OptInHeaderType])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.OptInHeaderType]
    # .
    ${RequestHeaderOptionOptInHeader},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String[]]
    # .
    ${RequiredFeature},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType[]]
    # .
    ${ResourceCreationBeginRequest},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ExtensionOptionType[]]
    # .
    ${ResourceCreationBeginResponse},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceDeletionPolicy])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ResourceDeletionPolicy]
    # .
    ${ResourceDeletionPolicy},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${ResourceMovePolicyCrossResourceGroupMoveEnabled},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${ResourceMovePolicyCrossSubscriptionMoveEnabled},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${ResourceMovePolicyValidationRequired},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.RoutingType])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.RoutingType]
    # .
    ${RoutingType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IServiceTreeInfo[]]
    # .
    # To construct, see NOTES section for SERVICETREEINFO properties and create a hash table.
    ${ServiceTreeInfo},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.TimeSpan]
    # .
    ${SubscriptionLifecycleNotificationSpecificationSoftDeleteTtl},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateOverrideAction[]]
    # .
    # To construct, see NOTES section for SUBSCRIPTIONLIFECYCLENOTIFICATIONSPECIFICATIONSUBSCRIPTIONSTATEOVERRIDEACTION properties and create a hash table.
    ${SubscriptionLifecycleNotificationSpecificationSubscriptionStateOverrideAction},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateRule[]]
    # .
    # To construct, see NOTES section for SUBSCRIPTIONSTATERULE properties and create a hash table.
    ${SubscriptionStateRule},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISwaggerSpecification[]]
    # .
    # To construct, see NOTES section for SWAGGERSPECIFICATION properties and create a hash table.
    ${SwaggerSpecification},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.PreflightOption])]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.PreflightOption[]]
    # .
    ${TemplateDeploymentOptionPreflightOption},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${TemplateDeploymentOptionPreflightSupported},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IThrottlingRule[]]
    # .
    # To construct, see NOTES section for THROTTLINGRULE properties and create a hash table.
    ${ThrottlingRule},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

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
            CreateExpanded = 'Az.ProviderHub.private\New-AzProviderHubResourceTypeRegistration_CreateExpanded';
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
Creates or updates the resource type skus in the given resource type.
.Description
Creates or updates the resource type skus in the given resource type.
.Example
PS C:\> New-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "Employees" -Sku "default" -SkuSetting @{Name = "freeSku"; Tier = "Tier1"; Kind = "Standard"}
.Example
PS C:\> New-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "Employees" -Sku "default" -SkuSetting @{Name = "freeSku"; Tier = "Tier1"; Kind = "Standard"}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuResource
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

SKUSETTING <ISkuSetting[]>: .
  Name <String>: 
  [Capability <ISkuCapability[]>]: 
    Name <String>: 
    Value <String>: 
  [CapacityDefault <Int32?>]: 
  [CapacityMaximum <Int32?>]: 
  [CapacityMinimum <Int32?>]: 
  [CapacityScaleType <SkuScaleType?>]: 
  [Cost <ISkuCost[]>]: 
    MeterId <String>: 
    [ExtendedUnit <String>]: 
    [Quantity <Int32?>]: 
  [Family <String>]: 
  [Kind <String>]: 
  [Location <String[]>]: 
  [LocationInfo <ISkuLocationInfo[]>]: 
    Location <String>: 
    [ExtendedLocation <String[]>]: 
    [Type <String>]: 
    [Zone <String[]>]: 
    [ZoneDetail <ISkuZoneDetail[]>]: 
      [Capability <ISkuCapability[]>]: 
      [Name <String[]>]: 
  [RequiredFeature <String[]>]: 
  [RequiredQuotaId <String[]>]: 
  [Size <String>]: 
  [Tier <String>]: 
.Link
https://docs.microsoft.com/powershell/module/az.providerhub/new-azproviderhubsku
#>
function New-AzProviderHubSku {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuResource])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The name of the resource provider hosted within ProviderHub.
    ${ProviderNamespace},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The resource type.
    ${ResourceType},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The SKU.
    ${Sku},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSetting[]]
    # .
    # To construct, see NOTES section for SKUSETTING properties and create a hash table.
    ${SkuSetting},

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
            CreateExpanded = 'Az.ProviderHub.private\New-AzProviderHubSku_CreateExpanded';
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
Deletes the rollout resource.
Rollout must be in terminal state.
.Description
Deletes the rollout resource.
Rollout must be in terminal state.
.Example
PS C:\> Remove-AzProviderHubDefaultRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "defaultRollout2021w10"
.Example
PS C:\> Remove-AzProviderHubDefaultRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "defaultRollout2021w10"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity
.Outputs
System.Boolean
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
https://docs.microsoft.com/powershell/module/az.providerhub/remove-azproviderhubdefaultrollout
#>
function Remove-AzProviderHubDefaultRollout {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='Delete', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Delete', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The name of the resource provider hosted within ProviderHub.
    ${ProviderNamespace},

    [Parameter(ParameterSetName='Delete', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The rollout name.
    ${RolloutName},

    [Parameter(ParameterSetName='Delete')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='DeleteViaIdentity', Mandatory, ValueFromPipeline)]
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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

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
            Delete = 'Az.ProviderHub.private\Remove-AzProviderHubDefaultRollout_Delete';
            DeleteViaIdentity = 'Az.ProviderHub.private\Remove-AzProviderHubDefaultRollout_DeleteViaIdentity';
        }
        if (('Delete') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Deletes a notification registration.
.Description
Deletes a notification registration.
.Example
PS C:\> Remove-AzProviderHubNotificationRegistration -ProviderNamespace "Microsoft.Contoso" -Name "notificationRegistrationTest"
.Example
PS C:\> Remove-AzProviderHubNotificationRegistration -ProviderNamespace "Microsoft.Contoso" -Name "notificationRegistrationTest"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity
.Outputs
System.Boolean
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
https://docs.microsoft.com/powershell/module/az.providerhub/remove-azproviderhubnotificationregistration
#>
function Remove-AzProviderHubNotificationRegistration {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='Delete', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Delete', Mandatory)]
    [Alias('NotificationRegistrationName')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The notification registration.
    ${Name},

    [Parameter(ParameterSetName='Delete', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The name of the resource provider hosted within ProviderHub.
    ${ProviderNamespace},

    [Parameter(ParameterSetName='Delete')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='DeleteViaIdentity', Mandatory, ValueFromPipeline)]
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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

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
            Delete = 'Az.ProviderHub.private\Remove-AzProviderHubNotificationRegistration_Delete';
            DeleteViaIdentity = 'Az.ProviderHub.private\Remove-AzProviderHubNotificationRegistration_DeleteViaIdentity';
        }
        if (('Delete') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Deletes a provider registration.
.Description
Deletes a provider registration.
.Example
PS C:\> Remove-AzProviderHubProviderRegistration -ProviderNamespace "Microsoft.Contoso"
.Example
PS C:\> Remove-AzProviderHubProviderRegistration -ProviderNamespace "Microsoft.Contoso"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity
.Outputs
System.Boolean
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
https://docs.microsoft.com/powershell/module/az.providerhub/remove-azproviderhubproviderregistration
#>
function Remove-AzProviderHubProviderRegistration {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='Delete', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Delete', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The name of the resource provider hosted within ProviderHub.
    ${ProviderNamespace},

    [Parameter(ParameterSetName='Delete')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='DeleteViaIdentity', Mandatory, ValueFromPipeline)]
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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

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
            Delete = 'Az.ProviderHub.private\Remove-AzProviderHubProviderRegistration_Delete';
            DeleteViaIdentity = 'Az.ProviderHub.private\Remove-AzProviderHubProviderRegistration_DeleteViaIdentity';
        }
        if (('Delete') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Deletes a resource type
.Description
Deletes a resource type
.Example
PS C:\> Remove-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType"
.Example
PS C:\> Remove-AzProviderHubResourceTypeRegistration -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity
.Outputs
System.Boolean
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
https://docs.microsoft.com/powershell/module/az.providerhub/remove-azproviderhubresourcetyperegistration
#>
function Remove-AzProviderHubResourceTypeRegistration {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='Delete', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Delete', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The name of the resource provider hosted within ProviderHub.
    ${ProviderNamespace},

    [Parameter(ParameterSetName='Delete', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The resource type.
    ${ResourceType},

    [Parameter(ParameterSetName='Delete')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='DeleteViaIdentity', Mandatory, ValueFromPipeline)]
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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

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
            Delete = 'Az.ProviderHub.private\Remove-AzProviderHubResourceTypeRegistration_Delete';
            DeleteViaIdentity = 'Az.ProviderHub.private\Remove-AzProviderHubResourceTypeRegistration_DeleteViaIdentity';
        }
        if (('Delete') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Deletes a resource type sku.
.Description
Deletes a resource type sku.
.Example
PS C:\> Remove-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType" -Sku "default"
.Example
PS C:\> Remove-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType" -Sku "default"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity
.Outputs
System.Boolean
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
https://docs.microsoft.com/powershell/module/az.providerhub/remove-azproviderhubsku
#>
function Remove-AzProviderHubSku {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='Delete', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Delete', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The name of the resource provider hosted within ProviderHub.
    ${ProviderNamespace},

    [Parameter(ParameterSetName='Delete', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The resource type.
    ${ResourceType},

    [Parameter(ParameterSetName='Delete', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The SKU.
    ${Sku},

    [Parameter(ParameterSetName='Delete')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='DeleteViaIdentity', Mandatory, ValueFromPipeline)]
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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

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
            Delete = 'Az.ProviderHub.private\Remove-AzProviderHubSku_Delete';
            DeleteViaIdentity = 'Az.ProviderHub.private\Remove-AzProviderHubSku_DeleteViaIdentity';
        }
        if (('Delete') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Stops or cancels the rollout, if in progress.
.Description
Stops or cancels the rollout, if in progress.
.Example
PS C:\> Stop-AzProviderHubDefaultRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "defaultRollout2021w10"
.Example
PS C:\> Stop-AzProviderHubDefaultRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "defaultRollout2021w10"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity
.Outputs
System.Boolean
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
https://docs.microsoft.com/powershell/module/az.providerhub/stop-azproviderhubdefaultrollout
#>
function Stop-AzProviderHubDefaultRollout {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='Stop', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Stop', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The name of the resource provider hosted within ProviderHub.
    ${ProviderNamespace},

    [Parameter(ParameterSetName='Stop', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The rollout name.
    ${RolloutName},

    [Parameter(ParameterSetName='Stop')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='StopViaIdentity', Mandatory, ValueFromPipeline)]
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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

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
            Stop = 'Az.ProviderHub.private\Stop-AzProviderHubDefaultRollout_Stop';
            StopViaIdentity = 'Az.ProviderHub.private\Stop-AzProviderHubDefaultRollout_StopViaIdentity';
        }
        if (('Stop') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
