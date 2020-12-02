
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
Gets the systemAssignedIdentity available under the specified RP scope.
.Description
Gets the systemAssignedIdentity available under the specified RP scope.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.IFunctionsIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.ISystemAssignedIdentity
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IFunctionsIdentity>: Identity Parameter
  [AccountName <String>]: The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.
  [AnalysisName <String>]: Analysis Name
  [AppSettingKey <String>]: App Setting key name.
  [Authprovider <String>]: The auth provider for the users.
  [BackupId <String>]: ID of the backup.
  [BaseAddress <String>]: Module base address.
  [BlobServicesName <String>]: The name of the blob Service within the specified storage account. Blob Service Name must be 'default'
  [CertificateOrderName <String>]: Name of the certificate order..
  [ContainerName <String>]: The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.
  [DeletedSiteId <String>]: The numeric ID of the deleted app, e.g. 12345
  [DetectorName <String>]: Detector Resource Name
  [DiagnosticCategory <String>]: Diagnostic Category
  [DiagnosticsName <String>]: Name of the diagnostics item.
  [DomainName <String>]: Name of the domain.
  [DomainOwnershipIdentifierName <String>]: Name of domain ownership identifier.
  [EntityName <String>]: Name of the hybrid connection.
  [FunctionName <String>]: Function name.
  [GatewayName <String>]: Name of the gateway. Currently, the only supported string is "primary".
  [HostName <String>]: Hostname in the hostname binding.
  [HostingEnvironmentName <String>]: Name of the hosting environment.
  [Id <String>]: Deployment ID.
  [Id1 <String>]: Resource identity path
  [ImmutabilityPolicyName <String>]: The name of the blob container immutabilityPolicy within the specified storage account. ImmutabilityPolicy Name must be 'default'
  [Instance <String>]: Name of the instance in the multi-role pool.
  [InstanceId <String>]: 
  [KeyId <String>]: The API Key ID. This is unique within a Application Insights component.
  [KeyName <String>]: The name of the key.
  [KeyType <String>]: The type of host key.
  [Location <String>]: 
  [ManagementPolicyName <ManagementPolicyName?>]: The name of the Storage Account Management Policy. It should always be 'default'
  [Name <String>]: Name of the certificate.
  [NamespaceName <String>]: The namespace for this hybrid connection.
  [OperationId <String>]: GUID of the operation.
  [PrId <String>]: The stage site identifier.
  [PremierAddOnName <String>]: Add-on name.
  [PrivateEndpointConnectionName <String>]: 
  [ProcessId <String>]: PID.
  [PublicCertificateName <String>]: Public certificate name.
  [PurgeId <String>]: In a purge status request, this is the Id of the operation the status of which is returned.
  [RelayName <String>]: The relay name for this hybrid connection.
  [ResourceGroupName <String>]: Name of the resource group to which the resource belongs.
  [ResourceName <String>]: The name of the Application Insights component resource.
  [RouteName <String>]: Name of the Virtual Network route.
  [Scope <String>]: The resource provider scope of the resource. Parent resource being extended by Managed Identities.
  [SiteExtensionId <String>]: Site extension name.
  [SiteName <String>]: Site Name
  [Slot <String>]: Slot Name
  [SnapshotId <String>]: The ID of the snapshot to read.
  [SourceControlType <String>]: Type of source control
  [SubscriptionId <String>]: Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
  [Userid <String>]: The user id of the user.
  [View <String>]: The type of view. This can either be "summary" or "detailed".
  [VnetName <String>]: Name of the virtual network.
  [WebJobName <String>]: Name of Web Job.
  [WorkerName <String>]: Name of worker machine, which typically starts with RD.
  [WorkerPoolName <String>]: Name of the worker pool.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/get-azsystemassignedidentity
#>
function Get-AzSystemAssignedIdentity {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.ISystemAssignedIdentity])]
[CmdletBinding(DefaultParameterSetName='Get', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # The resource provider scope of the resource.
    # Parent resource being extended by Managed Identities.
    ${Scope},

    [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.IFunctionsIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
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
            Get = 'Az.Functions.private\Get-AzSystemAssignedIdentity_Get';
            GetViaIdentity = 'Az.Functions.private\Get-AzSystemAssignedIdentity_GetViaIdentity';
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
Description for Get function keys for a function in a web site, or a deployment slot.
.Description
Description for Get function keys for a function in a web site, or a deployment slot.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStringDictionary
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/get-azwebappfunctionkeyslot
#>
function Get-AzWebAppFunctionKeySlot {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStringDictionary])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Function name.
    ${FunctionName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Site name.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the resource group to which the resource belongs.
    ${ResourceGroupName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the deployment slot.
    ${Slot},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # Your Azure subscription ID.
    # This is a GUID-formatted string (e.g.
    # 00000000-0000-0000-0000-000000000000).
    ${SubscriptionId},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
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
            List = 'Az.Functions.private\Get-AzWebAppFunctionKeySlot_List';
        }
        if (('List') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Description for Get function keys for a function in a web site, or a deployment slot.
.Description
Description for Get function keys for a function in a web site, or a deployment slot.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStringDictionary
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/get-azwebappfunctionkey
#>
function Get-AzWebAppFunctionKey {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStringDictionary])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Function name.
    ${FunctionName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Site name.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the resource group to which the resource belongs.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # Your Azure subscription ID.
    # This is a GUID-formatted string (e.g.
    # 00000000-0000-0000-0000-000000000000).
    ${SubscriptionId},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
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
            List = 'Az.Functions.private\Get-AzWebAppFunctionKey_List';
        }
        if (('List') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Description for Gets the config reference app settings and status of an app
.Description
Description for Gets the config reference app settings and status of an app
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.IFunctionsIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IKeyVaultReferenceCollection
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IKeyVaultReferenceResource
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IFunctionsIdentity>: Identity Parameter
  [AccountName <String>]: The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.
  [AnalysisName <String>]: Analysis Name
  [AppSettingKey <String>]: App Setting key name.
  [Authprovider <String>]: The auth provider for the users.
  [BackupId <String>]: ID of the backup.
  [BaseAddress <String>]: Module base address.
  [BlobServicesName <String>]: The name of the blob Service within the specified storage account. Blob Service Name must be 'default'
  [CertificateOrderName <String>]: Name of the certificate order..
  [ContainerName <String>]: The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.
  [DeletedSiteId <String>]: The numeric ID of the deleted app, e.g. 12345
  [DetectorName <String>]: Detector Resource Name
  [DiagnosticCategory <String>]: Diagnostic Category
  [DiagnosticsName <String>]: Name of the diagnostics item.
  [DomainName <String>]: Name of the domain.
  [DomainOwnershipIdentifierName <String>]: Name of domain ownership identifier.
  [EntityName <String>]: Name of the hybrid connection.
  [FunctionName <String>]: Function name.
  [GatewayName <String>]: Name of the gateway. Currently, the only supported string is "primary".
  [HostName <String>]: Hostname in the hostname binding.
  [HostingEnvironmentName <String>]: Name of the hosting environment.
  [Id <String>]: Deployment ID.
  [Id1 <String>]: Resource identity path
  [ImmutabilityPolicyName <String>]: The name of the blob container immutabilityPolicy within the specified storage account. ImmutabilityPolicy Name must be 'default'
  [Instance <String>]: Name of the instance in the multi-role pool.
  [InstanceId <String>]: 
  [KeyId <String>]: The API Key ID. This is unique within a Application Insights component.
  [KeyName <String>]: The name of the key.
  [KeyType <String>]: The type of host key.
  [Location <String>]: 
  [ManagementPolicyName <ManagementPolicyName?>]: The name of the Storage Account Management Policy. It should always be 'default'
  [Name <String>]: Name of the certificate.
  [NamespaceName <String>]: The namespace for this hybrid connection.
  [OperationId <String>]: GUID of the operation.
  [PrId <String>]: The stage site identifier.
  [PremierAddOnName <String>]: Add-on name.
  [PrivateEndpointConnectionName <String>]: 
  [ProcessId <String>]: PID.
  [PublicCertificateName <String>]: Public certificate name.
  [PurgeId <String>]: In a purge status request, this is the Id of the operation the status of which is returned.
  [RelayName <String>]: The relay name for this hybrid connection.
  [ResourceGroupName <String>]: Name of the resource group to which the resource belongs.
  [ResourceName <String>]: The name of the Application Insights component resource.
  [RouteName <String>]: Name of the Virtual Network route.
  [Scope <String>]: The resource provider scope of the resource. Parent resource being extended by Managed Identities.
  [SiteExtensionId <String>]: Site extension name.
  [SiteName <String>]: Site Name
  [Slot <String>]: Slot Name
  [SnapshotId <String>]: The ID of the snapshot to read.
  [SourceControlType <String>]: Type of source control
  [SubscriptionId <String>]: Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
  [Userid <String>]: The user id of the user.
  [View <String>]: The type of view. This can either be "summary" or "detailed".
  [VnetName <String>]: Name of the virtual network.
  [WebJobName <String>]: Name of Web Job.
  [WorkerName <String>]: Name of worker machine, which typically starts with RD.
  [WorkerPoolName <String>]: Name of the worker pool.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/get-azwebappsettingkeyvaultreference
#>
function Get-AzWebAppSettingKeyVaultReference {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IKeyVaultReferenceCollection], [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IKeyVaultReferenceResource])]
[CmdletBinding(DefaultParameterSetName='Get', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='Get1', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the app.
    ${Name},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='Get1', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the resource group to which the resource belongs.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Get')]
    [Parameter(ParameterSetName='Get1')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # Your Azure subscription ID.
    # This is a GUID-formatted string (e.g.
    # 00000000-0000-0000-0000-000000000000).
    ${SubscriptionId},

    [Parameter(ParameterSetName='Get1', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # App Setting key name.
    ${AppSettingKey},

    [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='GetViaIdentity1', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.IFunctionsIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
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
            Get = 'Az.Functions.private\Get-AzWebAppSettingKeyVaultReference_Get';
            Get1 = 'Az.Functions.private\Get-AzWebAppSettingKeyVaultReference_Get1';
            GetViaIdentity = 'Az.Functions.private\Get-AzWebAppSettingKeyVaultReference_GetViaIdentity';
            GetViaIdentity1 = 'Az.Functions.private\Get-AzWebAppSettingKeyVaultReference_GetViaIdentity1';
        }
        if (('Get', 'Get1') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Description for This is to allow calling via powershell and ARM template.
.Description
Description for This is to allow calling via powershell and ARM template.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Boolean
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/get-azwebappsyncstatusslot
#>
function Get-AzWebAppSyncStatusSlot {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the app.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the resource group to which the resource belongs.
    ${ResourceGroupName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the deployment slot.
    ${Slot},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # Your Azure subscription ID.
    # This is a GUID-formatted string (e.g.
    # 00000000-0000-0000-0000-000000000000).
    ${SubscriptionId},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
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
            List = 'Az.Functions.private\Get-AzWebAppSyncStatusSlot_List';
        }
        if (('List') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Description for This is to allow calling via powershell and ARM template.
.Description
Description for This is to allow calling via powershell and ARM template.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Boolean
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/get-azwebappsyncstatus
#>
function Get-AzWebAppSyncStatus {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the app.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the resource group to which the resource belongs.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # Your Azure subscription ID.
    # This is a GUID-formatted string (e.g.
    # 00000000-0000-0000-0000-000000000000).
    ${SubscriptionId},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
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
            List = 'Az.Functions.private\Get-AzWebAppSyncStatus_List';
        }
        if (('List') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Description for Move resources between resource groups.
.Description
Description for Move resources between resource groups.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmMoveResourceEnvelope
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.IFunctionsIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IFunctionsIdentity>: Identity Parameter
  [AccountName <String>]: The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.
  [AnalysisName <String>]: Analysis Name
  [AppSettingKey <String>]: App Setting key name.
  [Authprovider <String>]: The auth provider for the users.
  [BackupId <String>]: ID of the backup.
  [BaseAddress <String>]: Module base address.
  [BlobServicesName <String>]: The name of the blob Service within the specified storage account. Blob Service Name must be 'default'
  [CertificateOrderName <String>]: Name of the certificate order..
  [ContainerName <String>]: The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.
  [DeletedSiteId <String>]: The numeric ID of the deleted app, e.g. 12345
  [DetectorName <String>]: Detector Resource Name
  [DiagnosticCategory <String>]: Diagnostic Category
  [DiagnosticsName <String>]: Name of the diagnostics item.
  [DomainName <String>]: Name of the domain.
  [DomainOwnershipIdentifierName <String>]: Name of domain ownership identifier.
  [EntityName <String>]: Name of the hybrid connection.
  [FunctionName <String>]: Function name.
  [GatewayName <String>]: Name of the gateway. Currently, the only supported string is "primary".
  [HostName <String>]: Hostname in the hostname binding.
  [HostingEnvironmentName <String>]: Name of the hosting environment.
  [Id <String>]: Deployment ID.
  [Id1 <String>]: Resource identity path
  [ImmutabilityPolicyName <String>]: The name of the blob container immutabilityPolicy within the specified storage account. ImmutabilityPolicy Name must be 'default'
  [Instance <String>]: Name of the instance in the multi-role pool.
  [InstanceId <String>]: 
  [KeyId <String>]: The API Key ID. This is unique within a Application Insights component.
  [KeyName <String>]: The name of the key.
  [KeyType <String>]: The type of host key.
  [Location <String>]: 
  [ManagementPolicyName <ManagementPolicyName?>]: The name of the Storage Account Management Policy. It should always be 'default'
  [Name <String>]: Name of the certificate.
  [NamespaceName <String>]: The namespace for this hybrid connection.
  [OperationId <String>]: GUID of the operation.
  [PrId <String>]: The stage site identifier.
  [PremierAddOnName <String>]: Add-on name.
  [PrivateEndpointConnectionName <String>]: 
  [ProcessId <String>]: PID.
  [PublicCertificateName <String>]: Public certificate name.
  [PurgeId <String>]: In a purge status request, this is the Id of the operation the status of which is returned.
  [RelayName <String>]: The relay name for this hybrid connection.
  [ResourceGroupName <String>]: Name of the resource group to which the resource belongs.
  [ResourceName <String>]: The name of the Application Insights component resource.
  [RouteName <String>]: Name of the Virtual Network route.
  [Scope <String>]: The resource provider scope of the resource. Parent resource being extended by Managed Identities.
  [SiteExtensionId <String>]: Site extension name.
  [SiteName <String>]: Site Name
  [Slot <String>]: Slot Name
  [SnapshotId <String>]: The ID of the snapshot to read.
  [SourceControlType <String>]: Type of source control
  [SubscriptionId <String>]: Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
  [Userid <String>]: The user id of the user.
  [View <String>]: The type of view. This can either be "summary" or "detailed".
  [VnetName <String>]: Name of the virtual network.
  [WebJobName <String>]: Name of Web Job.
  [WorkerName <String>]: Name of worker machine, which typically starts with RD.
  [WorkerPoolName <String>]: Name of the worker pool.

MOVERESOURCEENVELOPE <ICsmMoveResourceEnvelope>: Object with a list of the resources that need to be moved and the resource group they should be moved to.
  [Resource <String[]>]: 
  [TargetResourceGroup <String>]: 
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/move-az
#>
function Move-Az {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='MoveExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Move', Mandatory)]
    [Parameter(ParameterSetName='MoveExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the resource group to which the resource belongs.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Move')]
    [Parameter(ParameterSetName='MoveExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Your Azure subscription ID.
    # This is a GUID-formatted string (e.g.
    # 00000000-0000-0000-0000-000000000000).
    ${SubscriptionId},

    [Parameter(ParameterSetName='MoveViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='MoveViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.IFunctionsIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Move', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='MoveViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICsmMoveResourceEnvelope]
    # Object with a list of the resources that need to be moved and the resource group they should be moved to.
    # To construct, see NOTES section for MOVERESOURCEENVELOPE properties and create a hash table.
    ${MoveResourceEnvelope},

    [Parameter(ParameterSetName='MoveExpanded')]
    [Parameter(ParameterSetName='MoveViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String[]]
    # .
    ${Resource},

    [Parameter(ParameterSetName='MoveExpanded')]
    [Parameter(ParameterSetName='MoveViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # .
    ${TargetResourceGroup},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
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
            Move = 'Az.Functions.private\Move-Az_Move';
            MoveExpanded = 'Az.Functions.private\Move-Az_MoveExpanded';
            MoveViaIdentity = 'Az.Functions.private\Move-Az_MoveViaIdentity';
            MoveViaIdentityExpanded = 'Az.Functions.private\Move-Az_MoveViaIdentityExpanded';
        }
        if (('Move', 'MoveExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Description for Syncs function trigger metadata to the management database
.Description
Description for Syncs function trigger metadata to the management database
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.IFunctionsIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IFunctionsIdentity>: Identity Parameter
  [AccountName <String>]: The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.
  [AnalysisName <String>]: Analysis Name
  [AppSettingKey <String>]: App Setting key name.
  [Authprovider <String>]: The auth provider for the users.
  [BackupId <String>]: ID of the backup.
  [BaseAddress <String>]: Module base address.
  [BlobServicesName <String>]: The name of the blob Service within the specified storage account. Blob Service Name must be 'default'
  [CertificateOrderName <String>]: Name of the certificate order..
  [ContainerName <String>]: The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.
  [DeletedSiteId <String>]: The numeric ID of the deleted app, e.g. 12345
  [DetectorName <String>]: Detector Resource Name
  [DiagnosticCategory <String>]: Diagnostic Category
  [DiagnosticsName <String>]: Name of the diagnostics item.
  [DomainName <String>]: Name of the domain.
  [DomainOwnershipIdentifierName <String>]: Name of domain ownership identifier.
  [EntityName <String>]: Name of the hybrid connection.
  [FunctionName <String>]: Function name.
  [GatewayName <String>]: Name of the gateway. Currently, the only supported string is "primary".
  [HostName <String>]: Hostname in the hostname binding.
  [HostingEnvironmentName <String>]: Name of the hosting environment.
  [Id <String>]: Deployment ID.
  [Id1 <String>]: Resource identity path
  [ImmutabilityPolicyName <String>]: The name of the blob container immutabilityPolicy within the specified storage account. ImmutabilityPolicy Name must be 'default'
  [Instance <String>]: Name of the instance in the multi-role pool.
  [InstanceId <String>]: 
  [KeyId <String>]: The API Key ID. This is unique within a Application Insights component.
  [KeyName <String>]: The name of the key.
  [KeyType <String>]: The type of host key.
  [Location <String>]: 
  [ManagementPolicyName <ManagementPolicyName?>]: The name of the Storage Account Management Policy. It should always be 'default'
  [Name <String>]: Name of the certificate.
  [NamespaceName <String>]: The namespace for this hybrid connection.
  [OperationId <String>]: GUID of the operation.
  [PrId <String>]: The stage site identifier.
  [PremierAddOnName <String>]: Add-on name.
  [PrivateEndpointConnectionName <String>]: 
  [ProcessId <String>]: PID.
  [PublicCertificateName <String>]: Public certificate name.
  [PurgeId <String>]: In a purge status request, this is the Id of the operation the status of which is returned.
  [RelayName <String>]: The relay name for this hybrid connection.
  [ResourceGroupName <String>]: Name of the resource group to which the resource belongs.
  [ResourceName <String>]: The name of the Application Insights component resource.
  [RouteName <String>]: Name of the Virtual Network route.
  [Scope <String>]: The resource provider scope of the resource. Parent resource being extended by Managed Identities.
  [SiteExtensionId <String>]: Site extension name.
  [SiteName <String>]: Site Name
  [Slot <String>]: Slot Name
  [SnapshotId <String>]: The ID of the snapshot to read.
  [SourceControlType <String>]: Type of source control
  [SubscriptionId <String>]: Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
  [Userid <String>]: The user id of the user.
  [View <String>]: The type of view. This can either be "summary" or "detailed".
  [VnetName <String>]: Name of the virtual network.
  [WebJobName <String>]: Name of Web Job.
  [WorkerName <String>]: Name of worker machine, which typically starts with RD.
  [WorkerPoolName <String>]: Name of the worker pool.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/sync-azwebappfunctionslot
#>
function Sync-AzWebAppFunctionSlot {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='Sync', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Sync', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the app.
    ${Name},

    [Parameter(ParameterSetName='Sync', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the resource group to which the resource belongs.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Sync', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the deployment slot.
    ${Slot},

    [Parameter(ParameterSetName='Sync')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Your Azure subscription ID.
    # This is a GUID-formatted string (e.g.
    # 00000000-0000-0000-0000-000000000000).
    ${SubscriptionId},

    [Parameter(ParameterSetName='SyncViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.IFunctionsIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
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
            Sync = 'Az.Functions.private\Sync-AzWebAppFunctionSlot_Sync';
            SyncViaIdentity = 'Az.Functions.private\Sync-AzWebAppFunctionSlot_SyncViaIdentity';
        }
        if (('Sync') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Description for Validate if a resource can be created.
.Description
Description for Validate if a resource can be created.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequest
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.IFunctionsIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateResponse
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IFunctionsIdentity>: Identity Parameter
  [AccountName <String>]: The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.
  [AnalysisName <String>]: Analysis Name
  [AppSettingKey <String>]: App Setting key name.
  [Authprovider <String>]: The auth provider for the users.
  [BackupId <String>]: ID of the backup.
  [BaseAddress <String>]: Module base address.
  [BlobServicesName <String>]: The name of the blob Service within the specified storage account. Blob Service Name must be 'default'
  [CertificateOrderName <String>]: Name of the certificate order..
  [ContainerName <String>]: The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.
  [DeletedSiteId <String>]: The numeric ID of the deleted app, e.g. 12345
  [DetectorName <String>]: Detector Resource Name
  [DiagnosticCategory <String>]: Diagnostic Category
  [DiagnosticsName <String>]: Name of the diagnostics item.
  [DomainName <String>]: Name of the domain.
  [DomainOwnershipIdentifierName <String>]: Name of domain ownership identifier.
  [EntityName <String>]: Name of the hybrid connection.
  [FunctionName <String>]: Function name.
  [GatewayName <String>]: Name of the gateway. Currently, the only supported string is "primary".
  [HostName <String>]: Hostname in the hostname binding.
  [HostingEnvironmentName <String>]: Name of the hosting environment.
  [Id <String>]: Deployment ID.
  [Id1 <String>]: Resource identity path
  [ImmutabilityPolicyName <String>]: The name of the blob container immutabilityPolicy within the specified storage account. ImmutabilityPolicy Name must be 'default'
  [Instance <String>]: Name of the instance in the multi-role pool.
  [InstanceId <String>]: 
  [KeyId <String>]: The API Key ID. This is unique within a Application Insights component.
  [KeyName <String>]: The name of the key.
  [KeyType <String>]: The type of host key.
  [Location <String>]: 
  [ManagementPolicyName <ManagementPolicyName?>]: The name of the Storage Account Management Policy. It should always be 'default'
  [Name <String>]: Name of the certificate.
  [NamespaceName <String>]: The namespace for this hybrid connection.
  [OperationId <String>]: GUID of the operation.
  [PrId <String>]: The stage site identifier.
  [PremierAddOnName <String>]: Add-on name.
  [PrivateEndpointConnectionName <String>]: 
  [ProcessId <String>]: PID.
  [PublicCertificateName <String>]: Public certificate name.
  [PurgeId <String>]: In a purge status request, this is the Id of the operation the status of which is returned.
  [RelayName <String>]: The relay name for this hybrid connection.
  [ResourceGroupName <String>]: Name of the resource group to which the resource belongs.
  [ResourceName <String>]: The name of the Application Insights component resource.
  [RouteName <String>]: Name of the Virtual Network route.
  [Scope <String>]: The resource provider scope of the resource. Parent resource being extended by Managed Identities.
  [SiteExtensionId <String>]: Site extension name.
  [SiteName <String>]: Site Name
  [Slot <String>]: Slot Name
  [SnapshotId <String>]: The ID of the snapshot to read.
  [SourceControlType <String>]: Type of source control
  [SubscriptionId <String>]: Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
  [Userid <String>]: The user id of the user.
  [View <String>]: The type of view. This can either be "summary" or "detailed".
  [VnetName <String>]: Name of the virtual network.
  [WebJobName <String>]: Name of Web Job.
  [WorkerName <String>]: Name of worker machine, which typically starts with RD.
  [WorkerPoolName <String>]: Name of the worker pool.

VALIDATEREQUEST <IValidateRequest>: Resource validation request content.
  Location <String>: Expected location of the resource.
  Name <String>: Resource name to verify.
  Type <ValidateResourceTypes>: Resource type used for verification.
  [Capacity <Int32?>]: Target capacity of the App Service plan (number of VMs).
  [ContainerImagePlatform <String>]: Platform (windows or linux)
  [ContainerImageRepository <String>]: Repository name (image name)
  [ContainerImageTag <String>]: Image tag
  [ContainerRegistryBaseUrl <String>]: Base URL of the container registry
  [ContainerRegistryPassword <String>]: Password for to access the container registry
  [ContainerRegistryUsername <String>]: Username for to access the container registry
  [HostingEnvironment <String>]: Name of App Service Environment where app or App Service plan should be created.
  [IsSpot <Boolean?>]: <code>true</code> if App Service plan is for Spot instances; otherwise, <code>false</code>.
  [IsXenon <Boolean?>]: <code>true</code> if App Service plan is running as a windows container
  [NeedLinuxWorker <Boolean?>]: <code>true</code> if App Service plan is for Linux workers; otherwise, <code>false</code>.
  [ServerFarmId <String>]: ARM resource ID of an App Service plan that would host the app.
  [SkuName <String>]: Name of the target SKU for the App Service plan.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/test-az
#>
function Test-Az {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateResponse])]
[CmdletBinding(DefaultParameterSetName='ValidateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Validate', Mandatory)]
    [Parameter(ParameterSetName='ValidateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the resource group to which the resource belongs.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Validate')]
    [Parameter(ParameterSetName='ValidateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Your Azure subscription ID.
    # This is a GUID-formatted string (e.g.
    # 00000000-0000-0000-0000-000000000000).
    ${SubscriptionId},

    [Parameter(ParameterSetName='ValidateViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='ValidateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.IFunctionsIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Validate', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='ValidateViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequest]
    # Resource validation request content.
    # To construct, see NOTES section for VALIDATEREQUEST properties and create a hash table.
    ${ValidateRequest},

    [Parameter(ParameterSetName='ValidateExpanded', Mandatory)]
    [Parameter(ParameterSetName='ValidateViaIdentityExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Expected location of the resource.
    ${Location},

    [Parameter(ParameterSetName='ValidateExpanded', Mandatory)]
    [Parameter(ParameterSetName='ValidateViaIdentityExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Resource name to verify.
    ${Name},

    [Parameter(ParameterSetName='ValidateExpanded', Mandatory)]
    [Parameter(ParameterSetName='ValidateViaIdentityExpanded', Mandatory)]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ValidateResourceTypes])]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ValidateResourceTypes]
    # Resource type used for verification.
    ${Type},

    [Parameter(ParameterSetName='ValidateExpanded')]
    [Parameter(ParameterSetName='ValidateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Int32]
    # Target capacity of the App Service plan (number of VMs).
    ${Capacity},

    [Parameter(ParameterSetName='ValidateExpanded')]
    [Parameter(ParameterSetName='ValidateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Platform (windows or linux)
    ${ContainerImagePlatform},

    [Parameter(ParameterSetName='ValidateExpanded')]
    [Parameter(ParameterSetName='ValidateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Repository name (image name)
    ${ContainerImageRepository},

    [Parameter(ParameterSetName='ValidateExpanded')]
    [Parameter(ParameterSetName='ValidateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Image tag
    ${ContainerImageTag},

    [Parameter(ParameterSetName='ValidateExpanded')]
    [Parameter(ParameterSetName='ValidateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Base URL of the container registry
    ${ContainerRegistryBaseUrl},

    [Parameter(ParameterSetName='ValidateExpanded')]
    [Parameter(ParameterSetName='ValidateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Password for to access the container registry
    ${ContainerRegistryPassword},

    [Parameter(ParameterSetName='ValidateExpanded')]
    [Parameter(ParameterSetName='ValidateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Username for to access the container registry
    ${ContainerRegistryUsername},

    [Parameter(ParameterSetName='ValidateExpanded')]
    [Parameter(ParameterSetName='ValidateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Name of App Service Environment where app or App Service plan should be created.
    ${HostingEnvironment},

    [Parameter(ParameterSetName='ValidateExpanded')]
    [Parameter(ParameterSetName='ValidateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # <code>true</code> if App Service plan is for Spot instances; otherwise, <code>false</code>.
    ${IsSpot},

    [Parameter(ParameterSetName='ValidateExpanded')]
    [Parameter(ParameterSetName='ValidateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # <code>true</code> if App Service plan is running as a windows container
    ${IsXenon},

    [Parameter(ParameterSetName='ValidateExpanded')]
    [Parameter(ParameterSetName='ValidateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # <code>true</code> if App Service plan is for Linux workers; otherwise, <code>false</code>.
    ${NeedLinuxWorker},

    [Parameter(ParameterSetName='ValidateExpanded')]
    [Parameter(ParameterSetName='ValidateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # ARM resource ID of an App Service plan that would host the app.
    ${ServerFarmId},

    [Parameter(ParameterSetName='ValidateExpanded')]
    [Parameter(ParameterSetName='ValidateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Name of the target SKU for the App Service plan.
    ${SkuName},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
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
            Validate = 'Az.Functions.private\Test-Az_Validate';
            ValidateExpanded = 'Az.Functions.private\Test-Az_ValidateExpanded';
            ValidateViaIdentity = 'Az.Functions.private\Test-Az_ValidateViaIdentity';
            ValidateViaIdentityExpanded = 'Az.Functions.private\Test-Az_ValidateViaIdentityExpanded';
        }
        if (('Validate', 'ValidateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/addfunctionappplanworkertype
#>
function AddFunctionAppPlanWorkerType {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${AppPlan},

    [Parameter(Position=1)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${SubscriptionId},

    [Parameter(Position=2)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelineAppend},

    [Parameter(Position=3)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelinePrepend}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\AddFunctionAppPlanWorkerType';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/addfunctionappsettings
#>
function AddFunctionAppSettings {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${App},

    [Parameter(Position=1)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${SubscriptionId},

    [Parameter(Position=2)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelineAppend},

    [Parameter(Position=3)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelinePrepend}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\AddFunctionAppSettings';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/containsreservedfunctionappsettingname
#>
function ContainsReservedFunctionAppSettingName {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String[]]
    ${AppSettingName}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\ContainsReservedFunctionAppSettingName';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/convertwebappapplicationsettingtohashtable
#>
function ConvertWebAppApplicationSettingToHashtable {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${ApplicationSetting}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\ConvertWebAppApplicationSettingToHashtable';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/createapplicationinsightsproject
#>
function CreateApplicationInsightsProject {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${ResourceName},

    [Parameter(Position=1, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${ResourceGroupName},

    [Parameter(Position=2, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${Location},

    [Parameter(Position=3)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${SubscriptionId},

    [Parameter(Position=4)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelineAppend},

    [Parameter(Position=5)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelinePrepend}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\CreateApplicationInsightsProject';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/createfunctionsidentity
#>
function CreateFunctionsIdentity {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${InputObject}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\CreateFunctionsIdentity';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/formatlisttostring
#>
function FormatListToString {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String[]]
    ${List}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\FormatListToString';
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
Gets function apps in a subscription.
.Description
Gets function apps in a subscription.
.Example
PS C:\> Get-AzFunctionApp

Name                     Status  OSType  Runtime Location    AppServicePlan ResourceGroupName         SubscriptionId
----                     ------  ------  ------- --------    -------------- -----------------         --------------
Functions1-Windows-DoNet Running Windows DotNet  Central US  CentralUSPlan  Functions-West-Europe-Win fe16564a-d943-4bf8-8c28-cf01708c3f8b
Functions1-Windows-Java  Running Windows Java    West Europe Premium1-WE    Functions-West-Europe1    fe16564a-d943-4bf8-8c28-cf01708c3f8b
.Example
PS C:\> Get-AzFunctionApp -ResourceGroupName Functions-West-Europe-Win -Name Functions1-Windows-DoNet

Name                     Status  OSType  Runtime Location   AppServicePlan ResourceGroupName         SubscriptionId
----                     ------  ------  ------- --------   -------------- -----------------         --------------
Functions1-Windows-DoNet Running Windows DotNet  Central US CentralUSPlan  Functions-West-Europe-Win fe16564a-d943-4bf8-8c28-cf01708c3f8b
.Example
PS C:\> Get-AzFunctionApp -ResourceGroupName Functions-West-Europe-Win

Name                     Status  OSType  Runtime Location   AppServicePlan ResourceGroupName         SubscriptionId
----                     ------  ------  ------- --------   -------------- -----------------         --------------
Functions1-Windows-DoNet Running Windows DotNet  Central US CentralUSPlan  Functions-West-Europe-Win fe16564a-d943-4bf8-8c28-cf01708c3f8b
.Example
PS C:\> Get-AzFunctionApp -SubscriptionId fe16564a-d943-4bf8-8c28-cf01708c3f8b

Name                     Status  OSType  Runtime Location   AppServicePlan ResourceGroupName         SubscriptionId
----                     ------  ------  ------- --------   -------------- -----------------         --------------
Functions1-Windows-DoNet Running Windows DotNet  Central US CentralUSPlan  Functions-West-Europe-Win fe16564a-d943-4bf8-8c28-cf01708c3f8b
.Example
PS C:\> Get-AzFunctionApp -Location "Central US"

Name                     Status  OSType  Runtime Location   AppServicePlan ResourceGroupName         SubscriptionId
----                     ------  ------  ------- --------   -------------- -----------------         --------------
Functions1-Windows-DoNet Running Windows DotNet  Central US CentralUSPlan  Functions-West-Europe-Win fe16564a-d943-4bf8-8c28-cf01708c3f8b

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISite
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/get-azfunctionapp
#>
function Get-AzFunctionApp {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISite])]
[CmdletBinding(DefaultParameterSetName='GetAll', PositionalBinding=$false)]
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The Azure subscription ID.
    ${SubscriptionId},

    [Parameter(ParameterSetName='ByLocation', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # The location of the function app.
    ${Location},

    [Parameter(ParameterSetName='ByResourceGroupName', Mandatory)]
    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # The name of the resource group.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # The name of the function app.
    ${Name},

    [Parameter(ParameterSetName='ByResourceGroupName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Use to specify whether to include deployment slots in results.
    ${IncludeSlot},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Uri]
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
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
            GetAll = 'Az.Functions.custom\Get-AzFunctionApp';
            ByLocation = 'Az.Functions.custom\Get-AzFunctionApp';
            ByResourceGroupName = 'Az.Functions.custom\Get-AzFunctionApp';
            ByName = 'Az.Functions.custom\Get-AzFunctionApp';
        }
        if (('GetAll', 'ByLocation', 'ByResourceGroupName', 'ByName') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Gets the location where a function app for the given os and plan type is available.
.Description
Gets the location where a function app for the given os and plan type is available.
.Example
PS C:\> Get-AzFunctionAppAvailableLocation

Name
----
Central US
North Europe
West Europe
Southeast Asia
East Asia
West US
East US
Japan West
Japan East
East US 2
North Central US
South Central US
Brazil South
Australia East
Australia Southeast
East Asia (Stage)
West India
South India
Canada Central
West US 2
UK West
UK South
East US 2 EUAP
Central US EUAP
Korea Central
France Central
Australia Central 2
Australia Central
Germany West Central
Norway East
.Example
PS C:\> Get-AzFunctionAppAvailableLocation -PlanType Premium -OSType Linux

Name
----
Central US
North Europe
West Europe
Southeast Asia
East Asia
West US
East US
Japan West
Japan East
East US 2
North Central US
South Central US
Brazil South
Australia East
Australia Southeast
West India
Canada Central
West Central US
West US 2
UK West
UK South
Central US EUAP
Korea Central
France Central
Norway East
.Example
PS C:\> Get-AzFunctionAppAvailableLocation -PlanType Consumption -OSType Windows

Name
----
Central US
North Europe
West Europe
Southeast Asia
East Asia
West US
East US
Japan West
Japan East
East US 2
North Central US
South Central US
Brazil South
Australia East
Australia Southeast
East Asia (Stage)
Central India
West India
South India
Canada Central
Canada East
West Central US
West US 2
UK West
UK South
East US 2 EUAP
Central US EUAP
Korea Central
France Central
Australia Central 2
Australia Central
South Africa North
Switzerland North
Germany West Central

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegion
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/get-azfunctionappavailablelocation
#>
function Get-AzFunctionAppAvailableLocation {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IGeoRegion])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The Azure subscription ID.
    ${SubscriptionId},

    [Parameter(Position=1)]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AvailablePlanType])]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # The plan type.
    # Valid inputs: Consumption or Premium
    ${PlanType},

    [Parameter(Position=2)]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WorkerType])]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # The OS type for the service plan.
    ${OSType},

    [Parameter(Position=3)]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    ${Break},

    [Parameter(Position=4, DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelineAppend},

    [Parameter(Position=5, DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelinePrepend},

    [Parameter(Position=6, DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Uri]
    ${Proxy},

    [Parameter(Position=7, DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
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
            __AllParameterSets = 'Az.Functions.custom\Get-AzFunctionAppAvailableLocation';
        }
        if (('__AllParameterSets') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Get function apps plans in a subscription.
.Description
Get function apps plans in a subscription.
.Example
PS C:\> Get-AzFunctionAppPlan

Name                               WorkerType SkuTier        SkuName Location    ResourceGroupName                SubscriptionId
----                               ---------- -------        ------- --------    -----------------                --------------
Func99-West-Europe-Linux-Premium   Linux      ElasticPremium EP1     West Europe Func99-West-Europe-Linux-Premium fe16564a-d943-4bf8-8c28-cf01708c3f8b
Func99-West-Europe-Windows-Premium Windows    ElasticPremium EP1     West Europe Func99-West-Europe-Win-Premium   fe16564a-d943-4bf8-8c28-cf01708c3f8b
Func99-Windows-Premium1680894595   Windows    ElasticPremium EP1     West Europe Func99-West-Europe-Win-Premium   fe16564a-d943-4bf8-8c28-cf01708c3f8b
Func99-Windows-Premium428118799    Windows    ElasticPremium EP1     West Europe Func99-West-Europe-Win-Premium   fe16564a-d943-4bf8-8c28-cf01708c3f8b
Func99-Windows-Premium677505437    Windows    ElasticPremium EP1     West Europe Func99-West-Europe-Win-Premium   fe16564a-d943-4bf8-8c28-cf01708c3f8b
Func99-Windows-Premium711892854    Windows    ElasticPremium EP1     West Europe Func99-West-Europe-Win-Premium   fe16564a-d943-4bf8-8c28-cf01708c3f8b
Func99-Windows-Premium819994758    Windows    ElasticPremium EP1     West Europe Func99-West-Europe-Win-Premium   fe16564a-d943-4bf8-8c28-cf01708c3f8b
.Example
PS C:\> Get-AzFunctionAppPlan -ResourceGroupName "West Europe"

Name                               WorkerType SkuTier        SkuName Location    ResourceGroupName                SubscriptionId
----                               ---------- -------        ------- --------    -----------------                --------------
Func99-West-Europe-Linux-Premium   Linux      ElasticPremium EP1     West Europe Func99-West-Europe-Linux-Premium fe16564a-d943-4bf8-8c28-cf01708c3f8b
Func99-West-Europe-Windows-Premium Windows    ElasticPremium EP1     West Europe Func99-West-Europe-Win-Premium   fe16564a-d943-4bf8-8c28-cf01708c3f8b
Func99-Windows-Premium1680894595   Windows    ElasticPremium EP1     West Europe Func99-West-Europe-Win-Premium   fe16564a-d943-4bf8-8c28-cf01708c3f8b
.Example
PS C:\> Get-AzFunctionAppPlan -SubscriptionId fe16564a-d943-4bf8-8c28-cf01708c3f8z

Name                               WorkerType SkuTier        SkuName Location    ResourceGroupName                SubscriptionId
----                               ---------- -------        ------- --------    -----------------                --------------
Func99-West-Europe-Windows-Premium Windows    ElasticPremium EP1     West Europe Func99-West-Europe-Win-Premium   fe16564a-d943-4bf8-8c28-cf01708c3f8z
.Example
PS C:\> Get-AzFunctionAppPlan -Location "Central US"

Name                               WorkerType SkuTier        SkuName Location   ResourceGroupName                SubscriptionId
----                               ---------- -------        ------- --------   -----------------                --------------
Func99-West-Europe-Windows-Premium Windows    ElasticPremium EP1     Central US Func99-West-Europe-Win-Premium   3r16564a-d943-4bf8-8c28-cf01708c3f8b

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlan
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/get-azfunctionappplan
#>
function Get-AzFunctionAppPlan {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlan])]
[CmdletBinding(DefaultParameterSetName='GetAll', PositionalBinding=$false)]
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The Azure subscription ID.
    ${SubscriptionId},

    [Parameter(ParameterSetName='ByLocation', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # The location of the function app plan.
    ${Location},

    [Parameter(ParameterSetName='ByResourceGroupName')]
    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # The name of the resource group.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # The service plan name.
    ${Name},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Uri]
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
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
            GetAll = 'Az.Functions.custom\Get-AzFunctionAppPlan';
            ByLocation = 'Az.Functions.custom\Get-AzFunctionAppPlan';
            ByResourceGroupName = 'Az.Functions.custom\Get-AzFunctionAppPlan';
            ByName = 'Az.Functions.custom\Get-AzFunctionAppPlan';
        }
        if (('GetAll', 'ByLocation', 'ByResourceGroupName', 'ByName') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Gets app settings for a function app.
.Description
Gets app settings for a function app.
.Example
PS C:\> Get-AzFunctionAppSetting -Name MyAppName -ResourceGroupName MyResourceGroupName

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISite
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStringDictionary
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <ISite>: 
  Location <String>: Resource Location.
  CloningInfoSourceWebAppId <String>: ARM resource ID of the source app. App resource ID is of the form         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots and         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for other slots.
  [Kind <String>]: Kind of resource.
  [Tag <IResourceTags>]: Resource tags.
    [(Any) <String>]: This indicates any property can be added to this object.
  [ClientAffinityEnabled <Boolean?>]: <code>true</code> to enable client affinity; <code>false</code> to stop sending session affinity cookies, which route client requests in the same session to the same instance. Default is <code>true</code>.
  [ClientCertEnabled <Boolean?>]: <code>true</code> to enable client certificate authentication (TLS mutual authentication); otherwise, <code>false</code>. Default is <code>false</code>.
  [ClientCertExclusionPath <String>]: client certificate authentication comma-separated exclusion paths
  [CloningInfoAppSettingsOverride <ICloningInfoAppSettingsOverrides>]: Application setting overrides for cloned app. If specified, these settings override the settings cloned         from source app. Otherwise, application settings from source app are retained.
    [(Any) <String>]: This indicates any property can be added to this object.
  [CloningInfoCloneCustomHostName <Boolean?>]: <code>true</code> to clone custom hostnames from source app; otherwise, <code>false</code>.
  [CloningInfoCloneSourceControl <Boolean?>]: <code>true</code> to clone source control from source app; otherwise, <code>false</code>.
  [CloningInfoConfigureLoadBalancing <Boolean?>]: <code>true</code> to configure load balancing for source and destination app.
  [CloningInfoCorrelationId <String>]: Correlation ID of cloning operation. This ID ties multiple cloning operations         together to use the same snapshot.
  [CloningInfoHostingEnvironment <String>]: App Service Environment.
  [CloningInfoOverwrite <Boolean?>]: <code>true</code> to overwrite destination app; otherwise, <code>false</code>.
  [CloningInfoSourceWebAppLocation <String>]: Location of source app ex: West US or North Europe
  [CloningInfoTrafficManagerProfileId <String>]: ARM resource ID of the Traffic Manager profile to use, if it exists. Traffic Manager resource ID is of the form         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficManagerProfiles/{profileName}.
  [CloningInfoTrafficManagerProfileName <String>]: Name of Traffic Manager profile to create. This is only needed if Traffic Manager profile does not already exist.
  [Config <ISiteConfig>]: Configuration of the app.
    IsPushEnabled <Boolean>: Gets or sets a flag indicating whether the Push endpoint is enabled.
    [ActionMinProcessExecutionTime <String>]: Minimum time the process must execute         before taking the action
    [ActionType <AutoHealActionType?>]: Predefined action to be taken.
    [AlwaysOn <Boolean?>]: <code>true</code> if Always On is enabled; otherwise, <code>false</code>.
    [ApiDefinitionUrl <String>]: The URL of the API definition.
    [ApiManagementConfigId <String>]: APIM-Api Identifier.
    [AppCommandLine <String>]: App command line to launch.
    [AppSetting <INameValuePair[]>]: Application settings.
      [Name <String>]: Pair name.
      [Value <String>]: Pair value.
    [AutoHealEnabled <Boolean?>]: <code>true</code> if Auto Heal is enabled; otherwise, <code>false</code>.
    [AutoSwapSlotName <String>]: Auto-swap slot name.
    [ConnectionString <IConnStringInfo[]>]: Connection strings.
      [ConnectionString <String>]: Connection string value.
      [Name <String>]: Name of connection string.
      [Type <ConnectionStringType?>]: Type of database.
    [CorAllowedOrigin <String[]>]: Gets or sets the list of origins that should be allowed to make cross-origin         calls (for example: http://example.com:12345). Use "*" to allow all.
    [CorSupportCredentials <Boolean?>]: Gets or sets whether CORS requests with credentials are allowed. See         https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Requests_with_credentials         for more details.
    [CustomActionExe <String>]: Executable to be run.
    [CustomActionParameter <String>]: Parameters for the executable.
    [DefaultDocument <String[]>]: Default documents.
    [DetailedErrorLoggingEnabled <Boolean?>]: <code>true</code> if detailed error logging is enabled; otherwise, <code>false</code>.
    [DocumentRoot <String>]: Document root.
    [DynamicTagsJson <String>]: Gets or sets a JSON string containing a list of dynamic tags that will be evaluated from user claims in the push registration endpoint.
    [ExperimentRampUpRule <IRampUpRule[]>]: List of ramp-up rules.
      [ActionHostName <String>]: Hostname of a slot to which the traffic will be redirected if decided to. E.g. myapp-stage.azurewebsites.net.
      [ChangeDecisionCallbackUrl <String>]: Custom decision algorithm can be provided in TiPCallback site extension which URL can be specified. See TiPCallback site extension for the scaffold and contracts.         https://www.siteextensions.net/packages/TiPCallback/
      [ChangeIntervalInMinute <Int32?>]: Specifies interval in minutes to reevaluate ReroutePercentage.
      [ChangeStep <Double?>]: In auto ramp up scenario this is the step to add/remove from <code>ReroutePercentage</code> until it reaches \n<code>MinReroutePercentage</code> or         <code>MaxReroutePercentage</code>. Site metrics are checked every N minutes specified in <code>ChangeIntervalInMinutes</code>.\nCustom decision algorithm         can be provided in TiPCallback site extension which URL can be specified in <code>ChangeDecisionCallbackUrl</code>.
      [MaxReroutePercentage <Double?>]: Specifies upper boundary below which ReroutePercentage will stay.
      [MinReroutePercentage <Double?>]: Specifies lower boundary above which ReroutePercentage will stay.
      [Name <String>]: Name of the routing rule. The recommended name would be to point to the slot which will receive the traffic in the experiment.
      [ReroutePercentage <Double?>]: Percentage of the traffic which will be redirected to <code>ActionHostName</code>.
    [FtpsState <FtpsState?>]: State of FTP / FTPS service
    [HandlerMapping <IHandlerMapping[]>]: Handler mappings.
      [Argument <String>]: Command-line arguments to be passed to the script processor.
      [Extension <String>]: Requests with this extension will be handled using the specified FastCGI application.
      [ScriptProcessor <String>]: The absolute path to the FastCGI application.
    [HealthCheckPath <String>]: Health check path
    [Http20Enabled <Boolean?>]: Http20Enabled: configures a web site to allow clients to connect over http2.0
    [HttpLoggingEnabled <Boolean?>]: <code>true</code> if HTTP logging is enabled; otherwise, <code>false</code>.
    [IPSecurityRestriction <IIPSecurityRestriction[]>]: IP security restrictions for main.
      [Action <String>]: Allow or Deny access for this IP range.
      [Description <String>]: IP restriction rule description.
      [IPAddress <String>]: IP address the security restriction is valid for.         It can be in form of pure ipv4 address (required SubnetMask property) or         CIDR notation such as ipv4/mask (leading bit match). For CIDR,         SubnetMask property must not be specified.
      [Name <String>]: IP restriction rule name.
      [Priority <Int32?>]: Priority of IP restriction rule.
      [SubnetMask <String>]: Subnet mask for the range of IP addresses the restriction is valid for.
      [SubnetTrafficTag <Int32?>]: (internal) Subnet traffic tag
      [Tag <IPFilterTag?>]: Defines what this IP filter will be used for. This is to support IP filtering on proxies.
      [VnetSubnetResourceId <String>]: Virtual network resource id
      [VnetTrafficTag <Int32?>]: (internal) Vnet traffic tag
    [JavaContainer <String>]: Java container.
    [JavaContainerVersion <String>]: Java container version.
    [JavaVersion <String>]: Java version.
    [LimitMaxDiskSizeInMb <Int64?>]: Maximum allowed disk size usage in MB.
    [LimitMaxMemoryInMb <Int64?>]: Maximum allowed memory usage in MB.
    [LimitMaxPercentageCpu <Double?>]: Maximum allowed CPU usage percentage.
    [LinuxFxVersion <String>]: Linux App Framework and version
    [LoadBalancing <SiteLoadBalancing?>]: Site load balancing.
    [LocalMySqlEnabled <Boolean?>]: <code>true</code> to enable local MySQL; otherwise, <code>false</code>.
    [LogsDirectorySizeLimit <Int32?>]: HTTP logs directory size limit.
    [MachineKeyDecryption <String>]: Algorithm used for decryption.
    [MachineKeyDecryptionKey <String>]: Decryption key.
    [MachineKeyValidation <String>]: MachineKey validation.
    [MachineKeyValidationKey <String>]: Validation key.
    [ManagedPipelineMode <ManagedPipelineMode?>]: Managed pipeline mode.
    [ManagedServiceIdentityId <Int32?>]: Managed Service Identity Id
    [MinTlsVersion <SupportedTlsVersions?>]: MinTlsVersion: configures the minimum version of TLS required for SSL requests
    [NetFrameworkVersion <String>]: .NET Framework version.
    [NodeVersion <String>]: Version of Node.js.
    [NumberOfWorker <Int32?>]: Number of workers.
    [PhpVersion <String>]: Version of PHP.
    [PowerShellVersion <String>]: Version of PowerShell.
    [PreWarmedInstanceCount <Int32?>]: Number of preWarmed instances.         This setting only applies to the Consumption and Elastic Plans
    [PublishingUsername <String>]: Publishing user name.
    [PushKind <String>]: Kind of resource.
    [PythonVersion <String>]: Version of Python.
    [RemoteDebuggingEnabled <Boolean?>]: <code>true</code> if remote debugging is enabled; otherwise, <code>false</code>.
    [RemoteDebuggingVersion <String>]: Remote debugging version.
    [RequestCount <Int32?>]: Request Count.
    [RequestTimeInterval <String>]: Time interval.
    [RequestTracingEnabled <Boolean?>]: <code>true</code> if request tracing is enabled; otherwise, <code>false</code>.
    [RequestTracingExpirationTime <DateTime?>]: Request tracing expiration time.
    [ScmIPSecurityRestriction <IIPSecurityRestriction[]>]: IP security restrictions for scm.
    [ScmIPSecurityRestrictionsUseMain <Boolean?>]: IP security restrictions for scm to use main.
    [ScmType <ScmType?>]: SCM type.
    [SlowRequestCount <Int32?>]: Request Count.
    [SlowRequestTimeInterval <String>]: Time interval.
    [SlowRequestTimeTaken <String>]: Time taken.
    [TagWhitelistJson <String>]: Gets or sets a JSON string containing a list of tags that are whitelisted for use by the push registration endpoint.
    [TagsRequiringAuth <String>]: Gets or sets a JSON string containing a list of tags that require user authentication to be used in the push registration endpoint.         Tags can consist of alphanumeric characters and the following:         '_', '@', '#', '.', ':', '-'.         Validation should be performed at the PushRequestHandler.
    [TracingOption <String>]: Tracing options.
    [TriggerPrivateBytesInKb <Int32?>]: A rule based on private bytes.
    [TriggerStatusCode <IStatusCodesBasedTrigger[]>]: A rule based on status codes.
      [Count <Int32?>]: Request Count.
      [Status <Int32?>]: HTTP status code.
      [SubStatus <Int32?>]: Request Sub Status.
      [TimeInterval <String>]: Time interval.
      [Win32Status <Int32?>]: Win32 error code.
    [Use32BitWorkerProcess <Boolean?>]: <code>true</code> to use 32-bit worker process; otherwise, <code>false</code>.
    [VirtualApplication <IVirtualApplication[]>]: Virtual applications.
      [PhysicalPath <String>]: Physical path.
      [PreloadEnabled <Boolean?>]: <code>true</code> if preloading is enabled; otherwise, <code>false</code>.
      [VirtualDirectory <IVirtualDirectory[]>]: Virtual directories for virtual application.
        [PhysicalPath <String>]: Physical path.
        [VirtualPath <String>]: Path to virtual application.
      [VirtualPath <String>]: Virtual path.
    [VnetName <String>]: Virtual Network name.
    [WebSocketsEnabled <Boolean?>]: <code>true</code> if WebSocket is enabled; otherwise, <code>false</code>.
    [WindowsFxVersion <String>]: Xenon App Framework and version
    [XManagedServiceIdentityId <Int32?>]: Explicit Managed Service Identity Id
  [ContainerSize <Int32?>]: Size of the function container.
  [DailyMemoryTimeQuota <Int32?>]: Maximum allowed daily memory-time quota (applicable on dynamic apps only).
  [Enabled <Boolean?>]: <code>true</code> if the app is enabled; otherwise, <code>false</code>. Setting this value to false disables the app (takes the app offline).
  [HostNameSslState <IHostNameSslState[]>]: Hostname SSL states are used to manage the SSL bindings for app's hostnames.
    [HostType <HostType?>]: Indicates whether the hostname is a standard or repository hostname.
    [Name <String>]: Hostname.
    [SslState <SslState?>]: SSL type.
    [Thumbprint <String>]: SSL certificate thumbprint.
    [ToUpdate <Boolean?>]: Set to <code>true</code> to update existing hostname.
    [VirtualIP <String>]: Virtual IP address assigned to the hostname if IP based SSL is enabled.
  [HostNamesDisabled <Boolean?>]: <code>true</code> to disable the public hostnames of the app; otherwise, <code>false</code>.          If <code>true</code>, the app is only accessible via API management process.
  [HostingEnvironmentProfileId <String>]: Resource ID of the App Service Environment.
  [HttpsOnly <Boolean?>]: HttpsOnly: configures a web site to accept only https requests. Issues redirect for         http requests
  [HyperV <Boolean?>]: Hyper-V sandbox.
  [IdentityType <ManagedServiceIdentityType?>]: Type of managed service identity.
  [IdentityUserAssignedIdentity <IManagedServiceIdentityUserAssignedIdentities>]: The list of user assigned identities associated with the resource. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}
    [(Any) <IComponents1Jq1T4ISchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>]: This indicates any property can be added to this object.
  [IsXenon <Boolean?>]: Obsolete: Hyper-V sandbox.
  [RedundancyMode <RedundancyMode?>]: Site redundancy mode
  [Reserved <Boolean?>]: <code>true</code> if reserved; otherwise, <code>false</code>.
  [ScmSiteAlsoStopped <Boolean?>]: <code>true</code> to stop SCM (KUDU) site when the app is stopped; otherwise, <code>false</code>. The default is <code>false</code>.
  [ServerFarmId <String>]: Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/get-azfunctionappsetting
#>
function Get-AzFunctionAppSetting {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStringDictionary])]
[CmdletBinding(DefaultParameterSetName='ByName', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the function app.
    ${Name},

    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the resource group to which the resource belongs.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='ByName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The Azure subscription ID.
    ${SubscriptionId},

    [Parameter(ParameterSetName='ByObjectInput', Mandatory, ValueFromPipeline)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISite]
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
    [System.Management.Automation.PSObject]
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Uri]
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
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
            ByName = 'Az.Functions.custom\Get-AzFunctionAppSetting';
            ByObjectInput = 'Az.Functions.custom\Get-AzFunctionAppSetting';
        }
        if (('ByName') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/getapplicationinsightsproject
#>
function GetApplicationInsightsProject {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${Name},

    [Parameter(Position=1)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${SubscriptionId},

    [Parameter(Position=2)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelineAppend},

    [Parameter(Position=3)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelinePrepend}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\GetApplicationInsightsProject';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/getazwebappconfig
#>
function GetAzWebAppConfig {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${Name},

    [Parameter(Position=1, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    ${ErrorIfResultIsNull},

    [Parameter(Position=2)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${SubscriptionId},

    [Parameter(Position=3)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelineAppend},

    [Parameter(Position=4)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelinePrepend}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\GetAzWebAppConfig';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/getconnectionstring
#>
function GetConnectionString {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${StorageAccountName},

    [Parameter(Position=1)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${SubscriptionId},

    [Parameter(Position=2)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelineAppend},

    [Parameter(Position=3)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelinePrepend}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\GetConnectionString';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/getdefaultostype
#>
function GetDefaultOSType {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${Runtime}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\GetDefaultOSType';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/geterrormessage
#>
function GetErrorMessage {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${Response}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\GetErrorMessage';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/getfunctionappbyname
#>
function GetFunctionAppByName {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${Name},

    [Parameter(Position=1, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${ResourceGroupName},

    [Parameter(Position=2)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${SubscriptionId},

    [Parameter(Position=3)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelineAppend},

    [Parameter(Position=4)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelinePrepend}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\GetFunctionAppByName';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/getfunctionappplans
#>
function GetFunctionAppPlans {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object[]]
    ${Plans},

    [Parameter(Position=1)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${Location},

    [Parameter(Position=2)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${SubscriptionId},

    [Parameter(Position=3)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelineAppend},

    [Parameter(Position=4)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelinePrepend}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\GetFunctionAppPlans';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/getfunctionapps
#>
function GetFunctionApps {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object[]]
    ${Apps},

    [Parameter(Position=1)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${Location},

    [Parameter(Position=2)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${SubscriptionId},

    [Parameter(Position=3)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelineAppend},

    [Parameter(Position=4)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelinePrepend}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\GetFunctionApps';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/getfunctionappserviceplaninfo
#>
function GetFunctionAppServicePlanInfo {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${ServerFarmId},

    [Parameter(Position=1)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${SubscriptionId},

    [Parameter(Position=2)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelineAppend},

    [Parameter(Position=3)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelinePrepend}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\GetFunctionAppServicePlanInfo';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/getparameterkeyvalues
#>
function GetParameterKeyValues {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Collections.Generic.Dictionary[System.String,System.Object]]
    ${PSBoundParametersDictionary},

    [Parameter(Position=1, Mandatory)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String[]]
    ${ParameterList}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\GetParameterKeyValues';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/getruntimejsondefinition
#>
function GetRuntimeJsonDefinition {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${FunctionsVersion},

    [Parameter(Position=1, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${Runtime},

    [Parameter(Position=3, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${OSType},

    [Parameter(Position=2)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${RuntimeVersion}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\GetRuntimeJsonDefinition';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/getserviceplan
#>
function GetServicePlan {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${Name},

    [Parameter(Position=1)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${SubscriptionId},

    [Parameter(Position=2)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelineAppend},

    [Parameter(Position=3)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelinePrepend}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\GetServicePlan';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/getskuname
#>
function GetSkuName {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${Sku}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\GetSkuName';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/getstorageaccount
#>
function GetStorageAccount {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${Name},

    [Parameter(Position=1)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${SubscriptionId},

    [Parameter(Position=2)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelineAppend},

    [Parameter(Position=3)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelinePrepend}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\GetStorageAccount';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/getsupportedruntimes
#>
function GetSupportedRuntimes {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${OSType}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\GetSupportedRuntimes';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/getsupportedruntimeversions
#>
function GetSupportedRuntimeVersions {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${FunctionsVersion},

    [Parameter(Position=1, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${Runtime},

    [Parameter(Position=2, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${OSType}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\GetSupportedRuntimeVersions';
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
Creates a function app.
.Description
Creates a function app.
.Example
PS C:\> New-AzFunctionApp -Name MyUniqueFunctionAppName `
                          -ResourceGroupName MyResourceGroupName `
                          -Location centralUS `
                          -StorageAccount MyStorageAccountName `
                          -Runtime PowerShell
.Example
PS C:\> New-AzFunctionApp -Name MyUniqueFunctionAppName `
                          -ResourceGroupName MyResourceGroupName `
                          -PlanName MyPlanName `
                          -StorageAccount MyStorageAccountName `
                          -Runtime PowerShell
.Example
PS C:\> New-AzFunctionApp -Name MyUniqueFunctionAppName `
                          -ResourceGroupName MyResourceGroupName `
                          -PlanName MyPlanName `
                          -StorageAccount MyStorageAccountName `
                          -DockerImageName myacr.azurecr.io/myimage:tag


.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISite
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/new-azfunctionapp
#>
function New-AzFunctionApp {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISite])]
[CmdletBinding(DefaultParameterSetName='Consumption', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # The name of the resource group.
    ${ResourceGroupName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # The name of the function app.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # The name of the storage account.
    ${StorageAccountName},

    [Parameter(ParameterSetName='Consumption', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # The location for the consumption plan.
    ${Location},

    [Parameter(ParameterSetName='Consumption', Mandatory)]
    [Parameter(ParameterSetName='ByAppServicePlan', Mandatory)]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RuntimeType])]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # The function runtime.
    ${Runtime},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The Azure subscription ID.
    ${SubscriptionId},

    [Parameter()]
    [Alias('AppInsightsName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Name of the existing App Insights project to be added to the function app.
    ${ApplicationInsightsName},

    [Parameter()]
    [Alias('AppInsightsKey')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Instrumentation key of App Insights to be added.
    ${ApplicationInsightsKey},

    [Parameter(ParameterSetName='Consumption')]
    [Parameter(ParameterSetName='ByAppServicePlan')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WorkerType])]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # The OS to host the function app.
    ${OSType},

    [Parameter(ParameterSetName='Consumption')]
    [Parameter(ParameterSetName='ByAppServicePlan')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # The function runtime.
    ${RuntimeVersion},

    [Parameter(ParameterSetName='Consumption')]
    [Parameter(ParameterSetName='ByAppServicePlan')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FunctionsVersionType])]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # The Functions version.
    ${FunctionsVersion},

    [Parameter()]
    [Alias('DisableAppInsights')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Disable creating application insights resource during the function app creation.
    # No logs will be available.
    ${DisableApplicationInsights},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds.
    ${PassThru},

    [Parameter()]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceTags]))]
    [System.Collections.Hashtable]
    # Resource tags.
    ${Tag},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Collections.Hashtable]
    # Function app settings.
    ${AppSetting},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FunctionAppManagedServiceIdentityCreateType])]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedServiceIdentityType]
    # Specifies the type of identity used for the function app.
    #             The acceptable values for this parameter are:
    #             - SystemAssigned
    #             - UserAssigned
    ${IdentityType},

    [Parameter()]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String[]]
    # Specifies the list of user identities associated with the function app.
    #             The user identity references will be ARM resource ids in the form:
    #             '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/identities/{identityName}'
    ${IdentityID},

    [Parameter(ParameterSetName='CustomDockerImage', Mandatory)]
    [Parameter(ParameterSetName='ByAppServicePlan', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # The name of the service plan.
    ${PlanName},

    [Parameter(ParameterSetName='CustomDockerImage', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Linux only.
    # Container image name from Docker Registry, e.g.
    # publisher/image-name:tag.
    ${DockerImageName},

    [Parameter(ParameterSetName='CustomDockerImage')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.PSCredential]
    # The container registry user name and password.
    # Required for private registries.
    ${DockerRegistryCredential},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
    [System.Management.Automation.PSObject]
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Starts the operation and returns immediately, before the operation is completed.
    # In order to determine if the operation has successfully been completed, use some other mechanism.
    ${NoWait},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Runs the cmdlet as a background job.
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Uri]
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
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
            Consumption = 'Az.Functions.custom\New-AzFunctionApp';
            CustomDockerImage = 'Az.Functions.custom\New-AzFunctionApp';
            ByAppServicePlan = 'Az.Functions.custom\New-AzFunctionApp';
        }
        if (('Consumption', 'CustomDockerImage', 'ByAppServicePlan') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Creates a function app service plan.
.Description
Creates a function app service plan.
.Example
PS C:\> New-AzFunctionAppPlan -ResourceGroupName MyResourceGroupName `
                              -Name MyPremiumPlan `
                              -Location WestEurope `
                              -MinimumWorkerCount 1 `
                              -MaximumWorkerCount 10 `
                              -Sku EP1 `
                              -WorkerType Windows


.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlan
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/new-azfunctionappplan
#>
function New-AzFunctionAppPlan {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlan])]
[CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the App Service plan.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the resource group to which the resource belongs.
    ${ResourceGroupName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # The location for the consumption plan.
    ${Location},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The Azure subscription ID.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuType])]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # The plan sku.
    # Valid inputs are: EP1, EP2, EP3
    ${Sku},

    [Parameter()]
    [Alias('MaxBurst')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Int32]
    # The maximum number of workers for the app service plan.
    ${MaximumWorkerCount},

    [Parameter()]
    [Alias('MinInstances')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Int32]
    # The minimum number of workers for the app service plan.
    ${MinimumWorkerCount},

    [Parameter()]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceTags]))]
    [System.Collections.Hashtable]
    # Resource tags.
    ${Tag},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
    [System.Management.Automation.PSObject]
    ${DefaultProfile},

    [Parameter(Mandatory)]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.WorkerType])]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.String]
    # The worker type for the plan.
    # Valid inputs are: Windows or Linux.
    ${WorkerType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously.
    ${NoWait},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job.
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Uri]
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
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
            __AllParameterSets = 'Az.Functions.custom\New-AzFunctionAppPlan';
        }
        if (('__AllParameterSets') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/newappsetting
#>
function NewAppSetting {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${Name},

    [Parameter(Position=1, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${Value}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\NewAppSetting';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/newappsettingobject
#>
function NewAppSettingObject {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Collections.Hashtable]
    ${CurrentAppSetting}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\NewAppSettingObject';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/newidentityuserassignedidentity
#>
function NewIdentityUserAssignedIdentity {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String[]]
    ${IdentityID}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\NewIdentityUserAssignedIdentity';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/newresourcetag
#>
function NewResourceTag {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Collections.Hashtable]
    ${Tag}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\NewResourceTag';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/normalizesku
#>
function NormalizeSku {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${Sku}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\NormalizeSku';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/parsedockerimage
#>
function ParseDockerImage {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${DockerImageName}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\ParseDockerImage';
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
Deletes a function app.
.Description
Deletes a function app.
.Example
PS C:\> Get-AzFunctionApp -Name MyAppName -ResourceGroupName MyResourceGroupName | Remove-AzFunctionApp -Force
.Example
PS C:\> Remove-AzFunctionApp -Name MyAppName -ResourceGroupName MyResourceGroupName -Force

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISite
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <ISite>: 
  Location <String>: Resource Location.
  CloningInfoSourceWebAppId <String>: ARM resource ID of the source app. App resource ID is of the form         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots and         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for other slots.
  [Kind <String>]: Kind of resource.
  [Tag <IResourceTags>]: Resource tags.
    [(Any) <String>]: This indicates any property can be added to this object.
  [ClientAffinityEnabled <Boolean?>]: <code>true</code> to enable client affinity; <code>false</code> to stop sending session affinity cookies, which route client requests in the same session to the same instance. Default is <code>true</code>.
  [ClientCertEnabled <Boolean?>]: <code>true</code> to enable client certificate authentication (TLS mutual authentication); otherwise, <code>false</code>. Default is <code>false</code>.
  [ClientCertExclusionPath <String>]: client certificate authentication comma-separated exclusion paths
  [CloningInfoAppSettingsOverride <ICloningInfoAppSettingsOverrides>]: Application setting overrides for cloned app. If specified, these settings override the settings cloned         from source app. Otherwise, application settings from source app are retained.
    [(Any) <String>]: This indicates any property can be added to this object.
  [CloningInfoCloneCustomHostName <Boolean?>]: <code>true</code> to clone custom hostnames from source app; otherwise, <code>false</code>.
  [CloningInfoCloneSourceControl <Boolean?>]: <code>true</code> to clone source control from source app; otherwise, <code>false</code>.
  [CloningInfoConfigureLoadBalancing <Boolean?>]: <code>true</code> to configure load balancing for source and destination app.
  [CloningInfoCorrelationId <String>]: Correlation ID of cloning operation. This ID ties multiple cloning operations         together to use the same snapshot.
  [CloningInfoHostingEnvironment <String>]: App Service Environment.
  [CloningInfoOverwrite <Boolean?>]: <code>true</code> to overwrite destination app; otherwise, <code>false</code>.
  [CloningInfoSourceWebAppLocation <String>]: Location of source app ex: West US or North Europe
  [CloningInfoTrafficManagerProfileId <String>]: ARM resource ID of the Traffic Manager profile to use, if it exists. Traffic Manager resource ID is of the form         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficManagerProfiles/{profileName}.
  [CloningInfoTrafficManagerProfileName <String>]: Name of Traffic Manager profile to create. This is only needed if Traffic Manager profile does not already exist.
  [Config <ISiteConfig>]: Configuration of the app.
    IsPushEnabled <Boolean>: Gets or sets a flag indicating whether the Push endpoint is enabled.
    [ActionMinProcessExecutionTime <String>]: Minimum time the process must execute         before taking the action
    [ActionType <AutoHealActionType?>]: Predefined action to be taken.
    [AlwaysOn <Boolean?>]: <code>true</code> if Always On is enabled; otherwise, <code>false</code>.
    [ApiDefinitionUrl <String>]: The URL of the API definition.
    [ApiManagementConfigId <String>]: APIM-Api Identifier.
    [AppCommandLine <String>]: App command line to launch.
    [AppSetting <INameValuePair[]>]: Application settings.
      [Name <String>]: Pair name.
      [Value <String>]: Pair value.
    [AutoHealEnabled <Boolean?>]: <code>true</code> if Auto Heal is enabled; otherwise, <code>false</code>.
    [AutoSwapSlotName <String>]: Auto-swap slot name.
    [ConnectionString <IConnStringInfo[]>]: Connection strings.
      [ConnectionString <String>]: Connection string value.
      [Name <String>]: Name of connection string.
      [Type <ConnectionStringType?>]: Type of database.
    [CorAllowedOrigin <String[]>]: Gets or sets the list of origins that should be allowed to make cross-origin         calls (for example: http://example.com:12345). Use "*" to allow all.
    [CorSupportCredentials <Boolean?>]: Gets or sets whether CORS requests with credentials are allowed. See         https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Requests_with_credentials         for more details.
    [CustomActionExe <String>]: Executable to be run.
    [CustomActionParameter <String>]: Parameters for the executable.
    [DefaultDocument <String[]>]: Default documents.
    [DetailedErrorLoggingEnabled <Boolean?>]: <code>true</code> if detailed error logging is enabled; otherwise, <code>false</code>.
    [DocumentRoot <String>]: Document root.
    [DynamicTagsJson <String>]: Gets or sets a JSON string containing a list of dynamic tags that will be evaluated from user claims in the push registration endpoint.
    [ExperimentRampUpRule <IRampUpRule[]>]: List of ramp-up rules.
      [ActionHostName <String>]: Hostname of a slot to which the traffic will be redirected if decided to. E.g. myapp-stage.azurewebsites.net.
      [ChangeDecisionCallbackUrl <String>]: Custom decision algorithm can be provided in TiPCallback site extension which URL can be specified. See TiPCallback site extension for the scaffold and contracts.         https://www.siteextensions.net/packages/TiPCallback/
      [ChangeIntervalInMinute <Int32?>]: Specifies interval in minutes to reevaluate ReroutePercentage.
      [ChangeStep <Double?>]: In auto ramp up scenario this is the step to add/remove from <code>ReroutePercentage</code> until it reaches \n<code>MinReroutePercentage</code> or         <code>MaxReroutePercentage</code>. Site metrics are checked every N minutes specified in <code>ChangeIntervalInMinutes</code>.\nCustom decision algorithm         can be provided in TiPCallback site extension which URL can be specified in <code>ChangeDecisionCallbackUrl</code>.
      [MaxReroutePercentage <Double?>]: Specifies upper boundary below which ReroutePercentage will stay.
      [MinReroutePercentage <Double?>]: Specifies lower boundary above which ReroutePercentage will stay.
      [Name <String>]: Name of the routing rule. The recommended name would be to point to the slot which will receive the traffic in the experiment.
      [ReroutePercentage <Double?>]: Percentage of the traffic which will be redirected to <code>ActionHostName</code>.
    [FtpsState <FtpsState?>]: State of FTP / FTPS service
    [HandlerMapping <IHandlerMapping[]>]: Handler mappings.
      [Argument <String>]: Command-line arguments to be passed to the script processor.
      [Extension <String>]: Requests with this extension will be handled using the specified FastCGI application.
      [ScriptProcessor <String>]: The absolute path to the FastCGI application.
    [HealthCheckPath <String>]: Health check path
    [Http20Enabled <Boolean?>]: Http20Enabled: configures a web site to allow clients to connect over http2.0
    [HttpLoggingEnabled <Boolean?>]: <code>true</code> if HTTP logging is enabled; otherwise, <code>false</code>.
    [IPSecurityRestriction <IIPSecurityRestriction[]>]: IP security restrictions for main.
      [Action <String>]: Allow or Deny access for this IP range.
      [Description <String>]: IP restriction rule description.
      [IPAddress <String>]: IP address the security restriction is valid for.         It can be in form of pure ipv4 address (required SubnetMask property) or         CIDR notation such as ipv4/mask (leading bit match). For CIDR,         SubnetMask property must not be specified.
      [Name <String>]: IP restriction rule name.
      [Priority <Int32?>]: Priority of IP restriction rule.
      [SubnetMask <String>]: Subnet mask for the range of IP addresses the restriction is valid for.
      [SubnetTrafficTag <Int32?>]: (internal) Subnet traffic tag
      [Tag <IPFilterTag?>]: Defines what this IP filter will be used for. This is to support IP filtering on proxies.
      [VnetSubnetResourceId <String>]: Virtual network resource id
      [VnetTrafficTag <Int32?>]: (internal) Vnet traffic tag
    [JavaContainer <String>]: Java container.
    [JavaContainerVersion <String>]: Java container version.
    [JavaVersion <String>]: Java version.
    [LimitMaxDiskSizeInMb <Int64?>]: Maximum allowed disk size usage in MB.
    [LimitMaxMemoryInMb <Int64?>]: Maximum allowed memory usage in MB.
    [LimitMaxPercentageCpu <Double?>]: Maximum allowed CPU usage percentage.
    [LinuxFxVersion <String>]: Linux App Framework and version
    [LoadBalancing <SiteLoadBalancing?>]: Site load balancing.
    [LocalMySqlEnabled <Boolean?>]: <code>true</code> to enable local MySQL; otherwise, <code>false</code>.
    [LogsDirectorySizeLimit <Int32?>]: HTTP logs directory size limit.
    [MachineKeyDecryption <String>]: Algorithm used for decryption.
    [MachineKeyDecryptionKey <String>]: Decryption key.
    [MachineKeyValidation <String>]: MachineKey validation.
    [MachineKeyValidationKey <String>]: Validation key.
    [ManagedPipelineMode <ManagedPipelineMode?>]: Managed pipeline mode.
    [ManagedServiceIdentityId <Int32?>]: Managed Service Identity Id
    [MinTlsVersion <SupportedTlsVersions?>]: MinTlsVersion: configures the minimum version of TLS required for SSL requests
    [NetFrameworkVersion <String>]: .NET Framework version.
    [NodeVersion <String>]: Version of Node.js.
    [NumberOfWorker <Int32?>]: Number of workers.
    [PhpVersion <String>]: Version of PHP.
    [PowerShellVersion <String>]: Version of PowerShell.
    [PreWarmedInstanceCount <Int32?>]: Number of preWarmed instances.         This setting only applies to the Consumption and Elastic Plans
    [PublishingUsername <String>]: Publishing user name.
    [PushKind <String>]: Kind of resource.
    [PythonVersion <String>]: Version of Python.
    [RemoteDebuggingEnabled <Boolean?>]: <code>true</code> if remote debugging is enabled; otherwise, <code>false</code>.
    [RemoteDebuggingVersion <String>]: Remote debugging version.
    [RequestCount <Int32?>]: Request Count.
    [RequestTimeInterval <String>]: Time interval.
    [RequestTracingEnabled <Boolean?>]: <code>true</code> if request tracing is enabled; otherwise, <code>false</code>.
    [RequestTracingExpirationTime <DateTime?>]: Request tracing expiration time.
    [ScmIPSecurityRestriction <IIPSecurityRestriction[]>]: IP security restrictions for scm.
    [ScmIPSecurityRestrictionsUseMain <Boolean?>]: IP security restrictions for scm to use main.
    [ScmType <ScmType?>]: SCM type.
    [SlowRequestCount <Int32?>]: Request Count.
    [SlowRequestTimeInterval <String>]: Time interval.
    [SlowRequestTimeTaken <String>]: Time taken.
    [TagWhitelistJson <String>]: Gets or sets a JSON string containing a list of tags that are whitelisted for use by the push registration endpoint.
    [TagsRequiringAuth <String>]: Gets or sets a JSON string containing a list of tags that require user authentication to be used in the push registration endpoint.         Tags can consist of alphanumeric characters and the following:         '_', '@', '#', '.', ':', '-'.         Validation should be performed at the PushRequestHandler.
    [TracingOption <String>]: Tracing options.
    [TriggerPrivateBytesInKb <Int32?>]: A rule based on private bytes.
    [TriggerStatusCode <IStatusCodesBasedTrigger[]>]: A rule based on status codes.
      [Count <Int32?>]: Request Count.
      [Status <Int32?>]: HTTP status code.
      [SubStatus <Int32?>]: Request Sub Status.
      [TimeInterval <String>]: Time interval.
      [Win32Status <Int32?>]: Win32 error code.
    [Use32BitWorkerProcess <Boolean?>]: <code>true</code> to use 32-bit worker process; otherwise, <code>false</code>.
    [VirtualApplication <IVirtualApplication[]>]: Virtual applications.
      [PhysicalPath <String>]: Physical path.
      [PreloadEnabled <Boolean?>]: <code>true</code> if preloading is enabled; otherwise, <code>false</code>.
      [VirtualDirectory <IVirtualDirectory[]>]: Virtual directories for virtual application.
        [PhysicalPath <String>]: Physical path.
        [VirtualPath <String>]: Path to virtual application.
      [VirtualPath <String>]: Virtual path.
    [VnetName <String>]: Virtual Network name.
    [WebSocketsEnabled <Boolean?>]: <code>true</code> if WebSocket is enabled; otherwise, <code>false</code>.
    [WindowsFxVersion <String>]: Xenon App Framework and version
    [XManagedServiceIdentityId <Int32?>]: Explicit Managed Service Identity Id
  [ContainerSize <Int32?>]: Size of the function container.
  [DailyMemoryTimeQuota <Int32?>]: Maximum allowed daily memory-time quota (applicable on dynamic apps only).
  [Enabled <Boolean?>]: <code>true</code> if the app is enabled; otherwise, <code>false</code>. Setting this value to false disables the app (takes the app offline).
  [HostNameSslState <IHostNameSslState[]>]: Hostname SSL states are used to manage the SSL bindings for app's hostnames.
    [HostType <HostType?>]: Indicates whether the hostname is a standard or repository hostname.
    [Name <String>]: Hostname.
    [SslState <SslState?>]: SSL type.
    [Thumbprint <String>]: SSL certificate thumbprint.
    [ToUpdate <Boolean?>]: Set to <code>true</code> to update existing hostname.
    [VirtualIP <String>]: Virtual IP address assigned to the hostname if IP based SSL is enabled.
  [HostNamesDisabled <Boolean?>]: <code>true</code> to disable the public hostnames of the app; otherwise, <code>false</code>.          If <code>true</code>, the app is only accessible via API management process.
  [HostingEnvironmentProfileId <String>]: Resource ID of the App Service Environment.
  [HttpsOnly <Boolean?>]: HttpsOnly: configures a web site to accept only https requests. Issues redirect for         http requests
  [HyperV <Boolean?>]: Hyper-V sandbox.
  [IdentityType <ManagedServiceIdentityType?>]: Type of managed service identity.
  [IdentityUserAssignedIdentity <IManagedServiceIdentityUserAssignedIdentities>]: The list of user assigned identities associated with the resource. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}
    [(Any) <IComponents1Jq1T4ISchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>]: This indicates any property can be added to this object.
  [IsXenon <Boolean?>]: Obsolete: Hyper-V sandbox.
  [RedundancyMode <RedundancyMode?>]: Site redundancy mode
  [Reserved <Boolean?>]: <code>true</code> if reserved; otherwise, <code>false</code>.
  [ScmSiteAlsoStopped <Boolean?>]: <code>true</code> to stop SCM (KUDU) site when the app is stopped; otherwise, <code>false</code>. The default is <code>false</code>.
  [ServerFarmId <String>]: Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/remove-azfunctionapp
#>
function Remove-AzFunctionApp {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='ByName', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # The name of function app.
    ${Name},

    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    ${ResourceGroupName},

    [Parameter(ParameterSetName='ByName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The Azure subscription ID.
    ${SubscriptionId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Forces the cmdlet to remove the function app without prompting for confirmation.
    ${Force},

    [Parameter(ParameterSetName='ByObjectInput', Mandatory, ValueFromPipeline)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISite]
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds.
    ${PassThru},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Uri]
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
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
            ByName = 'Az.Functions.custom\Remove-AzFunctionApp';
            ByObjectInput = 'Az.Functions.custom\Remove-AzFunctionApp';
        }
        if (('ByName') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Deletes a function app plan.
.Description
Deletes a function app plan.
.Example
PS C:\> Get-AzFunctionAppPlan -Name MyAppName -ResourceGroupName MyResourceGroupName | Remove-AzFunctionAppPlan -Force
.Example
PS C:\> Remove-AzFunctionAppPlan -Name MyAppName -ResourceGroupName MyResourceGroupName -Force

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlan
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IAppServicePlan>: 
  Location <String>: Resource Location.
  [Kind <String>]: Kind of resource.
  [Tag <IResourceTags>]: Resource tags.
    [(Any) <String>]: This indicates any property can be added to this object.
  [Capacity <Int32?>]: Current number of instances assigned to the resource.
  [FreeOfferExpirationTime <DateTime?>]: The time when the server farm free offer expires.
  [HostingEnvironmentProfileId <String>]: Resource ID of the App Service Environment.
  [HyperV <Boolean?>]: If Hyper-V container app service plan <code>true</code>, <code>false</code> otherwise.
  [IsSpot <Boolean?>]: If <code>true</code>, this App Service Plan owns spot instances.
  [IsXenon <Boolean?>]: Obsolete: If Hyper-V container app service plan <code>true</code>, <code>false</code> otherwise.
  [MaximumElasticWorkerCount <Int32?>]: Maximum number of total workers allowed for this ElasticScaleEnabled App Service Plan
  [PerSiteScaling <Boolean?>]: If <code>true</code>, apps assigned to this App Service plan can be scaled independently.         If <code>false</code>, apps assigned to this App Service plan will scale to all instances of the plan.
  [Reserved <Boolean?>]: If Linux app service plan <code>true</code>, <code>false</code> otherwise.
  [SkuCapability <ICapability[]>]: Capabilities of the SKU, e.g., is traffic manager enabled?
    [Name <String>]: Name of the SKU capability.
    [Reason <String>]: Reason of the SKU capability.
    [Value <String>]: Value of the SKU capability.
  [SkuCapacityDefault <Int32?>]: Default number of workers for this App Service plan SKU.
  [SkuCapacityMaximum <Int32?>]: Maximum number of workers for this App Service plan SKU.
  [SkuCapacityMinimum <Int32?>]: Minimum number of workers for this App Service plan SKU.
  [SkuCapacityScaleType <String>]: Available scale configurations for an App Service plan.
  [SkuFamily <String>]: Family code of the resource SKU.
  [SkuLocation <String[]>]: Locations of the SKU.
  [SkuName <String>]: Name of the resource SKU.
  [SkuSize <String>]: Size specifier of the resource SKU.
  [SkuTier <String>]: Service tier of the resource SKU.
  [SpotExpirationTime <DateTime?>]: The time when the server farm expires. Valid only if it is a spot server farm.
  [TargetWorkerCount <Int32?>]: Scaling worker count.
  [TargetWorkerSizeId <Int32?>]: Scaling worker size ID.
  [WorkerTierName <String>]: Target worker tier assigned to the App Service plan.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/remove-azfunctionappplan
#>
function Remove-AzFunctionAppPlan {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='ByName', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # The name of function app.
    ${Name},

    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    ${ResourceGroupName},

    [Parameter(ParameterSetName='ByName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The Azure subscription ID.
    ${SubscriptionId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Forces the cmdlet to remove the function app plan without prompting for confirmation.
    ${Force},

    [Parameter(ParameterSetName='ByObjectInput', Mandatory, ValueFromPipeline)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlan]
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds.
    ${PassThru},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    ${Break},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Uri]
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
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
            ByName = 'Az.Functions.custom\Remove-AzFunctionAppPlan';
            ByObjectInput = 'Az.Functions.custom\Remove-AzFunctionAppPlan';
        }
        if (('ByName') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Removes app settings from a function app.
.Description
Removes app settings from a function app.
.Example
PS C:\> Remove-AzFunctionAppSetting -Name MyAppName -ResourceGroupName MyResourceGroupName -AppSettingName "MyAppSetting1", "MyAppSetting2"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISite
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStringDictionary
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <ISite>: 
  Location <String>: Resource Location.
  CloningInfoSourceWebAppId <String>: ARM resource ID of the source app. App resource ID is of the form         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots and         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for other slots.
  [Kind <String>]: Kind of resource.
  [Tag <IResourceTags>]: Resource tags.
    [(Any) <String>]: This indicates any property can be added to this object.
  [ClientAffinityEnabled <Boolean?>]: <code>true</code> to enable client affinity; <code>false</code> to stop sending session affinity cookies, which route client requests in the same session to the same instance. Default is <code>true</code>.
  [ClientCertEnabled <Boolean?>]: <code>true</code> to enable client certificate authentication (TLS mutual authentication); otherwise, <code>false</code>. Default is <code>false</code>.
  [ClientCertExclusionPath <String>]: client certificate authentication comma-separated exclusion paths
  [CloningInfoAppSettingsOverride <ICloningInfoAppSettingsOverrides>]: Application setting overrides for cloned app. If specified, these settings override the settings cloned         from source app. Otherwise, application settings from source app are retained.
    [(Any) <String>]: This indicates any property can be added to this object.
  [CloningInfoCloneCustomHostName <Boolean?>]: <code>true</code> to clone custom hostnames from source app; otherwise, <code>false</code>.
  [CloningInfoCloneSourceControl <Boolean?>]: <code>true</code> to clone source control from source app; otherwise, <code>false</code>.
  [CloningInfoConfigureLoadBalancing <Boolean?>]: <code>true</code> to configure load balancing for source and destination app.
  [CloningInfoCorrelationId <String>]: Correlation ID of cloning operation. This ID ties multiple cloning operations         together to use the same snapshot.
  [CloningInfoHostingEnvironment <String>]: App Service Environment.
  [CloningInfoOverwrite <Boolean?>]: <code>true</code> to overwrite destination app; otherwise, <code>false</code>.
  [CloningInfoSourceWebAppLocation <String>]: Location of source app ex: West US or North Europe
  [CloningInfoTrafficManagerProfileId <String>]: ARM resource ID of the Traffic Manager profile to use, if it exists. Traffic Manager resource ID is of the form         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficManagerProfiles/{profileName}.
  [CloningInfoTrafficManagerProfileName <String>]: Name of Traffic Manager profile to create. This is only needed if Traffic Manager profile does not already exist.
  [Config <ISiteConfig>]: Configuration of the app.
    IsPushEnabled <Boolean>: Gets or sets a flag indicating whether the Push endpoint is enabled.
    [ActionMinProcessExecutionTime <String>]: Minimum time the process must execute         before taking the action
    [ActionType <AutoHealActionType?>]: Predefined action to be taken.
    [AlwaysOn <Boolean?>]: <code>true</code> if Always On is enabled; otherwise, <code>false</code>.
    [ApiDefinitionUrl <String>]: The URL of the API definition.
    [ApiManagementConfigId <String>]: APIM-Api Identifier.
    [AppCommandLine <String>]: App command line to launch.
    [AppSetting <INameValuePair[]>]: Application settings.
      [Name <String>]: Pair name.
      [Value <String>]: Pair value.
    [AutoHealEnabled <Boolean?>]: <code>true</code> if Auto Heal is enabled; otherwise, <code>false</code>.
    [AutoSwapSlotName <String>]: Auto-swap slot name.
    [ConnectionString <IConnStringInfo[]>]: Connection strings.
      [ConnectionString <String>]: Connection string value.
      [Name <String>]: Name of connection string.
      [Type <ConnectionStringType?>]: Type of database.
    [CorAllowedOrigin <String[]>]: Gets or sets the list of origins that should be allowed to make cross-origin         calls (for example: http://example.com:12345). Use "*" to allow all.
    [CorSupportCredentials <Boolean?>]: Gets or sets whether CORS requests with credentials are allowed. See         https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Requests_with_credentials         for more details.
    [CustomActionExe <String>]: Executable to be run.
    [CustomActionParameter <String>]: Parameters for the executable.
    [DefaultDocument <String[]>]: Default documents.
    [DetailedErrorLoggingEnabled <Boolean?>]: <code>true</code> if detailed error logging is enabled; otherwise, <code>false</code>.
    [DocumentRoot <String>]: Document root.
    [DynamicTagsJson <String>]: Gets or sets a JSON string containing a list of dynamic tags that will be evaluated from user claims in the push registration endpoint.
    [ExperimentRampUpRule <IRampUpRule[]>]: List of ramp-up rules.
      [ActionHostName <String>]: Hostname of a slot to which the traffic will be redirected if decided to. E.g. myapp-stage.azurewebsites.net.
      [ChangeDecisionCallbackUrl <String>]: Custom decision algorithm can be provided in TiPCallback site extension which URL can be specified. See TiPCallback site extension for the scaffold and contracts.         https://www.siteextensions.net/packages/TiPCallback/
      [ChangeIntervalInMinute <Int32?>]: Specifies interval in minutes to reevaluate ReroutePercentage.
      [ChangeStep <Double?>]: In auto ramp up scenario this is the step to add/remove from <code>ReroutePercentage</code> until it reaches \n<code>MinReroutePercentage</code> or         <code>MaxReroutePercentage</code>. Site metrics are checked every N minutes specified in <code>ChangeIntervalInMinutes</code>.\nCustom decision algorithm         can be provided in TiPCallback site extension which URL can be specified in <code>ChangeDecisionCallbackUrl</code>.
      [MaxReroutePercentage <Double?>]: Specifies upper boundary below which ReroutePercentage will stay.
      [MinReroutePercentage <Double?>]: Specifies lower boundary above which ReroutePercentage will stay.
      [Name <String>]: Name of the routing rule. The recommended name would be to point to the slot which will receive the traffic in the experiment.
      [ReroutePercentage <Double?>]: Percentage of the traffic which will be redirected to <code>ActionHostName</code>.
    [FtpsState <FtpsState?>]: State of FTP / FTPS service
    [HandlerMapping <IHandlerMapping[]>]: Handler mappings.
      [Argument <String>]: Command-line arguments to be passed to the script processor.
      [Extension <String>]: Requests with this extension will be handled using the specified FastCGI application.
      [ScriptProcessor <String>]: The absolute path to the FastCGI application.
    [HealthCheckPath <String>]: Health check path
    [Http20Enabled <Boolean?>]: Http20Enabled: configures a web site to allow clients to connect over http2.0
    [HttpLoggingEnabled <Boolean?>]: <code>true</code> if HTTP logging is enabled; otherwise, <code>false</code>.
    [IPSecurityRestriction <IIPSecurityRestriction[]>]: IP security restrictions for main.
      [Action <String>]: Allow or Deny access for this IP range.
      [Description <String>]: IP restriction rule description.
      [IPAddress <String>]: IP address the security restriction is valid for.         It can be in form of pure ipv4 address (required SubnetMask property) or         CIDR notation such as ipv4/mask (leading bit match). For CIDR,         SubnetMask property must not be specified.
      [Name <String>]: IP restriction rule name.
      [Priority <Int32?>]: Priority of IP restriction rule.
      [SubnetMask <String>]: Subnet mask for the range of IP addresses the restriction is valid for.
      [SubnetTrafficTag <Int32?>]: (internal) Subnet traffic tag
      [Tag <IPFilterTag?>]: Defines what this IP filter will be used for. This is to support IP filtering on proxies.
      [VnetSubnetResourceId <String>]: Virtual network resource id
      [VnetTrafficTag <Int32?>]: (internal) Vnet traffic tag
    [JavaContainer <String>]: Java container.
    [JavaContainerVersion <String>]: Java container version.
    [JavaVersion <String>]: Java version.
    [LimitMaxDiskSizeInMb <Int64?>]: Maximum allowed disk size usage in MB.
    [LimitMaxMemoryInMb <Int64?>]: Maximum allowed memory usage in MB.
    [LimitMaxPercentageCpu <Double?>]: Maximum allowed CPU usage percentage.
    [LinuxFxVersion <String>]: Linux App Framework and version
    [LoadBalancing <SiteLoadBalancing?>]: Site load balancing.
    [LocalMySqlEnabled <Boolean?>]: <code>true</code> to enable local MySQL; otherwise, <code>false</code>.
    [LogsDirectorySizeLimit <Int32?>]: HTTP logs directory size limit.
    [MachineKeyDecryption <String>]: Algorithm used for decryption.
    [MachineKeyDecryptionKey <String>]: Decryption key.
    [MachineKeyValidation <String>]: MachineKey validation.
    [MachineKeyValidationKey <String>]: Validation key.
    [ManagedPipelineMode <ManagedPipelineMode?>]: Managed pipeline mode.
    [ManagedServiceIdentityId <Int32?>]: Managed Service Identity Id
    [MinTlsVersion <SupportedTlsVersions?>]: MinTlsVersion: configures the minimum version of TLS required for SSL requests
    [NetFrameworkVersion <String>]: .NET Framework version.
    [NodeVersion <String>]: Version of Node.js.
    [NumberOfWorker <Int32?>]: Number of workers.
    [PhpVersion <String>]: Version of PHP.
    [PowerShellVersion <String>]: Version of PowerShell.
    [PreWarmedInstanceCount <Int32?>]: Number of preWarmed instances.         This setting only applies to the Consumption and Elastic Plans
    [PublishingUsername <String>]: Publishing user name.
    [PushKind <String>]: Kind of resource.
    [PythonVersion <String>]: Version of Python.
    [RemoteDebuggingEnabled <Boolean?>]: <code>true</code> if remote debugging is enabled; otherwise, <code>false</code>.
    [RemoteDebuggingVersion <String>]: Remote debugging version.
    [RequestCount <Int32?>]: Request Count.
    [RequestTimeInterval <String>]: Time interval.
    [RequestTracingEnabled <Boolean?>]: <code>true</code> if request tracing is enabled; otherwise, <code>false</code>.
    [RequestTracingExpirationTime <DateTime?>]: Request tracing expiration time.
    [ScmIPSecurityRestriction <IIPSecurityRestriction[]>]: IP security restrictions for scm.
    [ScmIPSecurityRestrictionsUseMain <Boolean?>]: IP security restrictions for scm to use main.
    [ScmType <ScmType?>]: SCM type.
    [SlowRequestCount <Int32?>]: Request Count.
    [SlowRequestTimeInterval <String>]: Time interval.
    [SlowRequestTimeTaken <String>]: Time taken.
    [TagWhitelistJson <String>]: Gets or sets a JSON string containing a list of tags that are whitelisted for use by the push registration endpoint.
    [TagsRequiringAuth <String>]: Gets or sets a JSON string containing a list of tags that require user authentication to be used in the push registration endpoint.         Tags can consist of alphanumeric characters and the following:         '_', '@', '#', '.', ':', '-'.         Validation should be performed at the PushRequestHandler.
    [TracingOption <String>]: Tracing options.
    [TriggerPrivateBytesInKb <Int32?>]: A rule based on private bytes.
    [TriggerStatusCode <IStatusCodesBasedTrigger[]>]: A rule based on status codes.
      [Count <Int32?>]: Request Count.
      [Status <Int32?>]: HTTP status code.
      [SubStatus <Int32?>]: Request Sub Status.
      [TimeInterval <String>]: Time interval.
      [Win32Status <Int32?>]: Win32 error code.
    [Use32BitWorkerProcess <Boolean?>]: <code>true</code> to use 32-bit worker process; otherwise, <code>false</code>.
    [VirtualApplication <IVirtualApplication[]>]: Virtual applications.
      [PhysicalPath <String>]: Physical path.
      [PreloadEnabled <Boolean?>]: <code>true</code> if preloading is enabled; otherwise, <code>false</code>.
      [VirtualDirectory <IVirtualDirectory[]>]: Virtual directories for virtual application.
        [PhysicalPath <String>]: Physical path.
        [VirtualPath <String>]: Path to virtual application.
      [VirtualPath <String>]: Virtual path.
    [VnetName <String>]: Virtual Network name.
    [WebSocketsEnabled <Boolean?>]: <code>true</code> if WebSocket is enabled; otherwise, <code>false</code>.
    [WindowsFxVersion <String>]: Xenon App Framework and version
    [XManagedServiceIdentityId <Int32?>]: Explicit Managed Service Identity Id
  [ContainerSize <Int32?>]: Size of the function container.
  [DailyMemoryTimeQuota <Int32?>]: Maximum allowed daily memory-time quota (applicable on dynamic apps only).
  [Enabled <Boolean?>]: <code>true</code> if the app is enabled; otherwise, <code>false</code>. Setting this value to false disables the app (takes the app offline).
  [HostNameSslState <IHostNameSslState[]>]: Hostname SSL states are used to manage the SSL bindings for app's hostnames.
    [HostType <HostType?>]: Indicates whether the hostname is a standard or repository hostname.
    [Name <String>]: Hostname.
    [SslState <SslState?>]: SSL type.
    [Thumbprint <String>]: SSL certificate thumbprint.
    [ToUpdate <Boolean?>]: Set to <code>true</code> to update existing hostname.
    [VirtualIP <String>]: Virtual IP address assigned to the hostname if IP based SSL is enabled.
  [HostNamesDisabled <Boolean?>]: <code>true</code> to disable the public hostnames of the app; otherwise, <code>false</code>.          If <code>true</code>, the app is only accessible via API management process.
  [HostingEnvironmentProfileId <String>]: Resource ID of the App Service Environment.
  [HttpsOnly <Boolean?>]: HttpsOnly: configures a web site to accept only https requests. Issues redirect for         http requests
  [HyperV <Boolean?>]: Hyper-V sandbox.
  [IdentityType <ManagedServiceIdentityType?>]: Type of managed service identity.
  [IdentityUserAssignedIdentity <IManagedServiceIdentityUserAssignedIdentities>]: The list of user assigned identities associated with the resource. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}
    [(Any) <IComponents1Jq1T4ISchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>]: This indicates any property can be added to this object.
  [IsXenon <Boolean?>]: Obsolete: Hyper-V sandbox.
  [RedundancyMode <RedundancyMode?>]: Site redundancy mode
  [Reserved <Boolean?>]: <code>true</code> if reserved; otherwise, <code>false</code>.
  [ScmSiteAlsoStopped <Boolean?>]: <code>true</code> to stop SCM (KUDU) site when the app is stopped; otherwise, <code>false</code>. The default is <code>false</code>.
  [ServerFarmId <String>]: Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/remove-azfunctionappsetting
#>
function Remove-AzFunctionAppSetting {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStringDictionary])]
[CmdletBinding(DefaultParameterSetName='ByName', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the function app.
    ${Name},

    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the resource group to which the resource belongs.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='ByName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The Azure subscription ID.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String[]]
    # List of function app settings to be removed from the function app.
    ${AppSettingName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Forces the cmdlet to remove function app setting without prompting for confirmation.
    ${Force},

    [Parameter(ParameterSetName='ByObjectInput', Mandatory, ValueFromPipeline)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISite]
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
    [System.Management.Automation.PSObject]
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Uri]
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
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
            ByName = 'Az.Functions.custom\Remove-AzFunctionAppSetting';
            ByObjectInput = 'Az.Functions.custom\Remove-AzFunctionAppSetting';
        }
        if (('ByName') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Restarts a function app.
.Description
Restarts a function app.
.Example
PS C:\> Get-AzFunctionApp -Name MyAppName -ResourceGroupName MyResourceGroupName | Restart-AzFunctionApp -Force
.Example
PS C:\> Restart-AzFunctionApp -Name MyAppName -ResourceGroupName MyResourceGroupName -Force

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISite
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <ISite>: 
  Location <String>: Resource Location.
  CloningInfoSourceWebAppId <String>: ARM resource ID of the source app. App resource ID is of the form         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots and         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for other slots.
  [Kind <String>]: Kind of resource.
  [Tag <IResourceTags>]: Resource tags.
    [(Any) <String>]: This indicates any property can be added to this object.
  [ClientAffinityEnabled <Boolean?>]: <code>true</code> to enable client affinity; <code>false</code> to stop sending session affinity cookies, which route client requests in the same session to the same instance. Default is <code>true</code>.
  [ClientCertEnabled <Boolean?>]: <code>true</code> to enable client certificate authentication (TLS mutual authentication); otherwise, <code>false</code>. Default is <code>false</code>.
  [ClientCertExclusionPath <String>]: client certificate authentication comma-separated exclusion paths
  [CloningInfoAppSettingsOverride <ICloningInfoAppSettingsOverrides>]: Application setting overrides for cloned app. If specified, these settings override the settings cloned         from source app. Otherwise, application settings from source app are retained.
    [(Any) <String>]: This indicates any property can be added to this object.
  [CloningInfoCloneCustomHostName <Boolean?>]: <code>true</code> to clone custom hostnames from source app; otherwise, <code>false</code>.
  [CloningInfoCloneSourceControl <Boolean?>]: <code>true</code> to clone source control from source app; otherwise, <code>false</code>.
  [CloningInfoConfigureLoadBalancing <Boolean?>]: <code>true</code> to configure load balancing for source and destination app.
  [CloningInfoCorrelationId <String>]: Correlation ID of cloning operation. This ID ties multiple cloning operations         together to use the same snapshot.
  [CloningInfoHostingEnvironment <String>]: App Service Environment.
  [CloningInfoOverwrite <Boolean?>]: <code>true</code> to overwrite destination app; otherwise, <code>false</code>.
  [CloningInfoSourceWebAppLocation <String>]: Location of source app ex: West US or North Europe
  [CloningInfoTrafficManagerProfileId <String>]: ARM resource ID of the Traffic Manager profile to use, if it exists. Traffic Manager resource ID is of the form         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficManagerProfiles/{profileName}.
  [CloningInfoTrafficManagerProfileName <String>]: Name of Traffic Manager profile to create. This is only needed if Traffic Manager profile does not already exist.
  [Config <ISiteConfig>]: Configuration of the app.
    IsPushEnabled <Boolean>: Gets or sets a flag indicating whether the Push endpoint is enabled.
    [ActionMinProcessExecutionTime <String>]: Minimum time the process must execute         before taking the action
    [ActionType <AutoHealActionType?>]: Predefined action to be taken.
    [AlwaysOn <Boolean?>]: <code>true</code> if Always On is enabled; otherwise, <code>false</code>.
    [ApiDefinitionUrl <String>]: The URL of the API definition.
    [ApiManagementConfigId <String>]: APIM-Api Identifier.
    [AppCommandLine <String>]: App command line to launch.
    [AppSetting <INameValuePair[]>]: Application settings.
      [Name <String>]: Pair name.
      [Value <String>]: Pair value.
    [AutoHealEnabled <Boolean?>]: <code>true</code> if Auto Heal is enabled; otherwise, <code>false</code>.
    [AutoSwapSlotName <String>]: Auto-swap slot name.
    [ConnectionString <IConnStringInfo[]>]: Connection strings.
      [ConnectionString <String>]: Connection string value.
      [Name <String>]: Name of connection string.
      [Type <ConnectionStringType?>]: Type of database.
    [CorAllowedOrigin <String[]>]: Gets or sets the list of origins that should be allowed to make cross-origin         calls (for example: http://example.com:12345). Use "*" to allow all.
    [CorSupportCredentials <Boolean?>]: Gets or sets whether CORS requests with credentials are allowed. See         https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Requests_with_credentials         for more details.
    [CustomActionExe <String>]: Executable to be run.
    [CustomActionParameter <String>]: Parameters for the executable.
    [DefaultDocument <String[]>]: Default documents.
    [DetailedErrorLoggingEnabled <Boolean?>]: <code>true</code> if detailed error logging is enabled; otherwise, <code>false</code>.
    [DocumentRoot <String>]: Document root.
    [DynamicTagsJson <String>]: Gets or sets a JSON string containing a list of dynamic tags that will be evaluated from user claims in the push registration endpoint.
    [ExperimentRampUpRule <IRampUpRule[]>]: List of ramp-up rules.
      [ActionHostName <String>]: Hostname of a slot to which the traffic will be redirected if decided to. E.g. myapp-stage.azurewebsites.net.
      [ChangeDecisionCallbackUrl <String>]: Custom decision algorithm can be provided in TiPCallback site extension which URL can be specified. See TiPCallback site extension for the scaffold and contracts.         https://www.siteextensions.net/packages/TiPCallback/
      [ChangeIntervalInMinute <Int32?>]: Specifies interval in minutes to reevaluate ReroutePercentage.
      [ChangeStep <Double?>]: In auto ramp up scenario this is the step to add/remove from <code>ReroutePercentage</code> until it reaches \n<code>MinReroutePercentage</code> or         <code>MaxReroutePercentage</code>. Site metrics are checked every N minutes specified in <code>ChangeIntervalInMinutes</code>.\nCustom decision algorithm         can be provided in TiPCallback site extension which URL can be specified in <code>ChangeDecisionCallbackUrl</code>.
      [MaxReroutePercentage <Double?>]: Specifies upper boundary below which ReroutePercentage will stay.
      [MinReroutePercentage <Double?>]: Specifies lower boundary above which ReroutePercentage will stay.
      [Name <String>]: Name of the routing rule. The recommended name would be to point to the slot which will receive the traffic in the experiment.
      [ReroutePercentage <Double?>]: Percentage of the traffic which will be redirected to <code>ActionHostName</code>.
    [FtpsState <FtpsState?>]: State of FTP / FTPS service
    [HandlerMapping <IHandlerMapping[]>]: Handler mappings.
      [Argument <String>]: Command-line arguments to be passed to the script processor.
      [Extension <String>]: Requests with this extension will be handled using the specified FastCGI application.
      [ScriptProcessor <String>]: The absolute path to the FastCGI application.
    [HealthCheckPath <String>]: Health check path
    [Http20Enabled <Boolean?>]: Http20Enabled: configures a web site to allow clients to connect over http2.0
    [HttpLoggingEnabled <Boolean?>]: <code>true</code> if HTTP logging is enabled; otherwise, <code>false</code>.
    [IPSecurityRestriction <IIPSecurityRestriction[]>]: IP security restrictions for main.
      [Action <String>]: Allow or Deny access for this IP range.
      [Description <String>]: IP restriction rule description.
      [IPAddress <String>]: IP address the security restriction is valid for.         It can be in form of pure ipv4 address (required SubnetMask property) or         CIDR notation such as ipv4/mask (leading bit match). For CIDR,         SubnetMask property must not be specified.
      [Name <String>]: IP restriction rule name.
      [Priority <Int32?>]: Priority of IP restriction rule.
      [SubnetMask <String>]: Subnet mask for the range of IP addresses the restriction is valid for.
      [SubnetTrafficTag <Int32?>]: (internal) Subnet traffic tag
      [Tag <IPFilterTag?>]: Defines what this IP filter will be used for. This is to support IP filtering on proxies.
      [VnetSubnetResourceId <String>]: Virtual network resource id
      [VnetTrafficTag <Int32?>]: (internal) Vnet traffic tag
    [JavaContainer <String>]: Java container.
    [JavaContainerVersion <String>]: Java container version.
    [JavaVersion <String>]: Java version.
    [LimitMaxDiskSizeInMb <Int64?>]: Maximum allowed disk size usage in MB.
    [LimitMaxMemoryInMb <Int64?>]: Maximum allowed memory usage in MB.
    [LimitMaxPercentageCpu <Double?>]: Maximum allowed CPU usage percentage.
    [LinuxFxVersion <String>]: Linux App Framework and version
    [LoadBalancing <SiteLoadBalancing?>]: Site load balancing.
    [LocalMySqlEnabled <Boolean?>]: <code>true</code> to enable local MySQL; otherwise, <code>false</code>.
    [LogsDirectorySizeLimit <Int32?>]: HTTP logs directory size limit.
    [MachineKeyDecryption <String>]: Algorithm used for decryption.
    [MachineKeyDecryptionKey <String>]: Decryption key.
    [MachineKeyValidation <String>]: MachineKey validation.
    [MachineKeyValidationKey <String>]: Validation key.
    [ManagedPipelineMode <ManagedPipelineMode?>]: Managed pipeline mode.
    [ManagedServiceIdentityId <Int32?>]: Managed Service Identity Id
    [MinTlsVersion <SupportedTlsVersions?>]: MinTlsVersion: configures the minimum version of TLS required for SSL requests
    [NetFrameworkVersion <String>]: .NET Framework version.
    [NodeVersion <String>]: Version of Node.js.
    [NumberOfWorker <Int32?>]: Number of workers.
    [PhpVersion <String>]: Version of PHP.
    [PowerShellVersion <String>]: Version of PowerShell.
    [PreWarmedInstanceCount <Int32?>]: Number of preWarmed instances.         This setting only applies to the Consumption and Elastic Plans
    [PublishingUsername <String>]: Publishing user name.
    [PushKind <String>]: Kind of resource.
    [PythonVersion <String>]: Version of Python.
    [RemoteDebuggingEnabled <Boolean?>]: <code>true</code> if remote debugging is enabled; otherwise, <code>false</code>.
    [RemoteDebuggingVersion <String>]: Remote debugging version.
    [RequestCount <Int32?>]: Request Count.
    [RequestTimeInterval <String>]: Time interval.
    [RequestTracingEnabled <Boolean?>]: <code>true</code> if request tracing is enabled; otherwise, <code>false</code>.
    [RequestTracingExpirationTime <DateTime?>]: Request tracing expiration time.
    [ScmIPSecurityRestriction <IIPSecurityRestriction[]>]: IP security restrictions for scm.
    [ScmIPSecurityRestrictionsUseMain <Boolean?>]: IP security restrictions for scm to use main.
    [ScmType <ScmType?>]: SCM type.
    [SlowRequestCount <Int32?>]: Request Count.
    [SlowRequestTimeInterval <String>]: Time interval.
    [SlowRequestTimeTaken <String>]: Time taken.
    [TagWhitelistJson <String>]: Gets or sets a JSON string containing a list of tags that are whitelisted for use by the push registration endpoint.
    [TagsRequiringAuth <String>]: Gets or sets a JSON string containing a list of tags that require user authentication to be used in the push registration endpoint.         Tags can consist of alphanumeric characters and the following:         '_', '@', '#', '.', ':', '-'.         Validation should be performed at the PushRequestHandler.
    [TracingOption <String>]: Tracing options.
    [TriggerPrivateBytesInKb <Int32?>]: A rule based on private bytes.
    [TriggerStatusCode <IStatusCodesBasedTrigger[]>]: A rule based on status codes.
      [Count <Int32?>]: Request Count.
      [Status <Int32?>]: HTTP status code.
      [SubStatus <Int32?>]: Request Sub Status.
      [TimeInterval <String>]: Time interval.
      [Win32Status <Int32?>]: Win32 error code.
    [Use32BitWorkerProcess <Boolean?>]: <code>true</code> to use 32-bit worker process; otherwise, <code>false</code>.
    [VirtualApplication <IVirtualApplication[]>]: Virtual applications.
      [PhysicalPath <String>]: Physical path.
      [PreloadEnabled <Boolean?>]: <code>true</code> if preloading is enabled; otherwise, <code>false</code>.
      [VirtualDirectory <IVirtualDirectory[]>]: Virtual directories for virtual application.
        [PhysicalPath <String>]: Physical path.
        [VirtualPath <String>]: Path to virtual application.
      [VirtualPath <String>]: Virtual path.
    [VnetName <String>]: Virtual Network name.
    [WebSocketsEnabled <Boolean?>]: <code>true</code> if WebSocket is enabled; otherwise, <code>false</code>.
    [WindowsFxVersion <String>]: Xenon App Framework and version
    [XManagedServiceIdentityId <Int32?>]: Explicit Managed Service Identity Id
  [ContainerSize <Int32?>]: Size of the function container.
  [DailyMemoryTimeQuota <Int32?>]: Maximum allowed daily memory-time quota (applicable on dynamic apps only).
  [Enabled <Boolean?>]: <code>true</code> if the app is enabled; otherwise, <code>false</code>. Setting this value to false disables the app (takes the app offline).
  [HostNameSslState <IHostNameSslState[]>]: Hostname SSL states are used to manage the SSL bindings for app's hostnames.
    [HostType <HostType?>]: Indicates whether the hostname is a standard or repository hostname.
    [Name <String>]: Hostname.
    [SslState <SslState?>]: SSL type.
    [Thumbprint <String>]: SSL certificate thumbprint.
    [ToUpdate <Boolean?>]: Set to <code>true</code> to update existing hostname.
    [VirtualIP <String>]: Virtual IP address assigned to the hostname if IP based SSL is enabled.
  [HostNamesDisabled <Boolean?>]: <code>true</code> to disable the public hostnames of the app; otherwise, <code>false</code>.          If <code>true</code>, the app is only accessible via API management process.
  [HostingEnvironmentProfileId <String>]: Resource ID of the App Service Environment.
  [HttpsOnly <Boolean?>]: HttpsOnly: configures a web site to accept only https requests. Issues redirect for         http requests
  [HyperV <Boolean?>]: Hyper-V sandbox.
  [IdentityType <ManagedServiceIdentityType?>]: Type of managed service identity.
  [IdentityUserAssignedIdentity <IManagedServiceIdentityUserAssignedIdentities>]: The list of user assigned identities associated with the resource. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}
    [(Any) <IComponents1Jq1T4ISchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>]: This indicates any property can be added to this object.
  [IsXenon <Boolean?>]: Obsolete: Hyper-V sandbox.
  [RedundancyMode <RedundancyMode?>]: Site redundancy mode
  [Reserved <Boolean?>]: <code>true</code> if reserved; otherwise, <code>false</code>.
  [ScmSiteAlsoStopped <Boolean?>]: <code>true</code> to stop SCM (KUDU) site when the app is stopped; otherwise, <code>false</code>. The default is <code>false</code>.
  [ServerFarmId <String>]: Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/restart-azfunctionapp
#>
function Restart-AzFunctionApp {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='RestartByName', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='RestartByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # The name of function app.
    ${Name},

    [Parameter(ParameterSetName='RestartByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    ${ResourceGroupName},

    [Parameter(ParameterSetName='RestartByName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The Azure subscription ID.
    ${SubscriptionId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Forces the cmdlet to restart the function app without prompting for confirmation.
    ${Force},

    [Parameter(ParameterSetName='ByObjectInput', Mandatory, ValueFromPipeline)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISite]
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds.
    ${PassThru},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Uri]
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
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
            RestartByName = 'Az.Functions.custom\Restart-AzFunctionApp';
            ByObjectInput = 'Az.Functions.custom\Restart-AzFunctionApp';
        }
        if (('RestartByName') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Starts a function app.
.Description
Starts a function app.
.Example
PS C:\> Get-AzFunctionApp -Name MyAppName -ResourceGroupName MyResourceGroupName | Start-AzFunctionApp
.Example
PS C:\> Start-AzFunctionApp -Name MyAppName -ResourceGroupName MyResourceGroupName

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISite
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <ISite>: 
  Location <String>: Resource Location.
  CloningInfoSourceWebAppId <String>: ARM resource ID of the source app. App resource ID is of the form         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots and         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for other slots.
  [Kind <String>]: Kind of resource.
  [Tag <IResourceTags>]: Resource tags.
    [(Any) <String>]: This indicates any property can be added to this object.
  [ClientAffinityEnabled <Boolean?>]: <code>true</code> to enable client affinity; <code>false</code> to stop sending session affinity cookies, which route client requests in the same session to the same instance. Default is <code>true</code>.
  [ClientCertEnabled <Boolean?>]: <code>true</code> to enable client certificate authentication (TLS mutual authentication); otherwise, <code>false</code>. Default is <code>false</code>.
  [ClientCertExclusionPath <String>]: client certificate authentication comma-separated exclusion paths
  [CloningInfoAppSettingsOverride <ICloningInfoAppSettingsOverrides>]: Application setting overrides for cloned app. If specified, these settings override the settings cloned         from source app. Otherwise, application settings from source app are retained.
    [(Any) <String>]: This indicates any property can be added to this object.
  [CloningInfoCloneCustomHostName <Boolean?>]: <code>true</code> to clone custom hostnames from source app; otherwise, <code>false</code>.
  [CloningInfoCloneSourceControl <Boolean?>]: <code>true</code> to clone source control from source app; otherwise, <code>false</code>.
  [CloningInfoConfigureLoadBalancing <Boolean?>]: <code>true</code> to configure load balancing for source and destination app.
  [CloningInfoCorrelationId <String>]: Correlation ID of cloning operation. This ID ties multiple cloning operations         together to use the same snapshot.
  [CloningInfoHostingEnvironment <String>]: App Service Environment.
  [CloningInfoOverwrite <Boolean?>]: <code>true</code> to overwrite destination app; otherwise, <code>false</code>.
  [CloningInfoSourceWebAppLocation <String>]: Location of source app ex: West US or North Europe
  [CloningInfoTrafficManagerProfileId <String>]: ARM resource ID of the Traffic Manager profile to use, if it exists. Traffic Manager resource ID is of the form         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficManagerProfiles/{profileName}.
  [CloningInfoTrafficManagerProfileName <String>]: Name of Traffic Manager profile to create. This is only needed if Traffic Manager profile does not already exist.
  [Config <ISiteConfig>]: Configuration of the app.
    IsPushEnabled <Boolean>: Gets or sets a flag indicating whether the Push endpoint is enabled.
    [ActionMinProcessExecutionTime <String>]: Minimum time the process must execute         before taking the action
    [ActionType <AutoHealActionType?>]: Predefined action to be taken.
    [AlwaysOn <Boolean?>]: <code>true</code> if Always On is enabled; otherwise, <code>false</code>.
    [ApiDefinitionUrl <String>]: The URL of the API definition.
    [ApiManagementConfigId <String>]: APIM-Api Identifier.
    [AppCommandLine <String>]: App command line to launch.
    [AppSetting <INameValuePair[]>]: Application settings.
      [Name <String>]: Pair name.
      [Value <String>]: Pair value.
    [AutoHealEnabled <Boolean?>]: <code>true</code> if Auto Heal is enabled; otherwise, <code>false</code>.
    [AutoSwapSlotName <String>]: Auto-swap slot name.
    [ConnectionString <IConnStringInfo[]>]: Connection strings.
      [ConnectionString <String>]: Connection string value.
      [Name <String>]: Name of connection string.
      [Type <ConnectionStringType?>]: Type of database.
    [CorAllowedOrigin <String[]>]: Gets or sets the list of origins that should be allowed to make cross-origin         calls (for example: http://example.com:12345). Use "*" to allow all.
    [CorSupportCredentials <Boolean?>]: Gets or sets whether CORS requests with credentials are allowed. See         https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Requests_with_credentials         for more details.
    [CustomActionExe <String>]: Executable to be run.
    [CustomActionParameter <String>]: Parameters for the executable.
    [DefaultDocument <String[]>]: Default documents.
    [DetailedErrorLoggingEnabled <Boolean?>]: <code>true</code> if detailed error logging is enabled; otherwise, <code>false</code>.
    [DocumentRoot <String>]: Document root.
    [DynamicTagsJson <String>]: Gets or sets a JSON string containing a list of dynamic tags that will be evaluated from user claims in the push registration endpoint.
    [ExperimentRampUpRule <IRampUpRule[]>]: List of ramp-up rules.
      [ActionHostName <String>]: Hostname of a slot to which the traffic will be redirected if decided to. E.g. myapp-stage.azurewebsites.net.
      [ChangeDecisionCallbackUrl <String>]: Custom decision algorithm can be provided in TiPCallback site extension which URL can be specified. See TiPCallback site extension for the scaffold and contracts.         https://www.siteextensions.net/packages/TiPCallback/
      [ChangeIntervalInMinute <Int32?>]: Specifies interval in minutes to reevaluate ReroutePercentage.
      [ChangeStep <Double?>]: In auto ramp up scenario this is the step to add/remove from <code>ReroutePercentage</code> until it reaches \n<code>MinReroutePercentage</code> or         <code>MaxReroutePercentage</code>. Site metrics are checked every N minutes specified in <code>ChangeIntervalInMinutes</code>.\nCustom decision algorithm         can be provided in TiPCallback site extension which URL can be specified in <code>ChangeDecisionCallbackUrl</code>.
      [MaxReroutePercentage <Double?>]: Specifies upper boundary below which ReroutePercentage will stay.
      [MinReroutePercentage <Double?>]: Specifies lower boundary above which ReroutePercentage will stay.
      [Name <String>]: Name of the routing rule. The recommended name would be to point to the slot which will receive the traffic in the experiment.
      [ReroutePercentage <Double?>]: Percentage of the traffic which will be redirected to <code>ActionHostName</code>.
    [FtpsState <FtpsState?>]: State of FTP / FTPS service
    [HandlerMapping <IHandlerMapping[]>]: Handler mappings.
      [Argument <String>]: Command-line arguments to be passed to the script processor.
      [Extension <String>]: Requests with this extension will be handled using the specified FastCGI application.
      [ScriptProcessor <String>]: The absolute path to the FastCGI application.
    [HealthCheckPath <String>]: Health check path
    [Http20Enabled <Boolean?>]: Http20Enabled: configures a web site to allow clients to connect over http2.0
    [HttpLoggingEnabled <Boolean?>]: <code>true</code> if HTTP logging is enabled; otherwise, <code>false</code>.
    [IPSecurityRestriction <IIPSecurityRestriction[]>]: IP security restrictions for main.
      [Action <String>]: Allow or Deny access for this IP range.
      [Description <String>]: IP restriction rule description.
      [IPAddress <String>]: IP address the security restriction is valid for.         It can be in form of pure ipv4 address (required SubnetMask property) or         CIDR notation such as ipv4/mask (leading bit match). For CIDR,         SubnetMask property must not be specified.
      [Name <String>]: IP restriction rule name.
      [Priority <Int32?>]: Priority of IP restriction rule.
      [SubnetMask <String>]: Subnet mask for the range of IP addresses the restriction is valid for.
      [SubnetTrafficTag <Int32?>]: (internal) Subnet traffic tag
      [Tag <IPFilterTag?>]: Defines what this IP filter will be used for. This is to support IP filtering on proxies.
      [VnetSubnetResourceId <String>]: Virtual network resource id
      [VnetTrafficTag <Int32?>]: (internal) Vnet traffic tag
    [JavaContainer <String>]: Java container.
    [JavaContainerVersion <String>]: Java container version.
    [JavaVersion <String>]: Java version.
    [LimitMaxDiskSizeInMb <Int64?>]: Maximum allowed disk size usage in MB.
    [LimitMaxMemoryInMb <Int64?>]: Maximum allowed memory usage in MB.
    [LimitMaxPercentageCpu <Double?>]: Maximum allowed CPU usage percentage.
    [LinuxFxVersion <String>]: Linux App Framework and version
    [LoadBalancing <SiteLoadBalancing?>]: Site load balancing.
    [LocalMySqlEnabled <Boolean?>]: <code>true</code> to enable local MySQL; otherwise, <code>false</code>.
    [LogsDirectorySizeLimit <Int32?>]: HTTP logs directory size limit.
    [MachineKeyDecryption <String>]: Algorithm used for decryption.
    [MachineKeyDecryptionKey <String>]: Decryption key.
    [MachineKeyValidation <String>]: MachineKey validation.
    [MachineKeyValidationKey <String>]: Validation key.
    [ManagedPipelineMode <ManagedPipelineMode?>]: Managed pipeline mode.
    [ManagedServiceIdentityId <Int32?>]: Managed Service Identity Id
    [MinTlsVersion <SupportedTlsVersions?>]: MinTlsVersion: configures the minimum version of TLS required for SSL requests
    [NetFrameworkVersion <String>]: .NET Framework version.
    [NodeVersion <String>]: Version of Node.js.
    [NumberOfWorker <Int32?>]: Number of workers.
    [PhpVersion <String>]: Version of PHP.
    [PowerShellVersion <String>]: Version of PowerShell.
    [PreWarmedInstanceCount <Int32?>]: Number of preWarmed instances.         This setting only applies to the Consumption and Elastic Plans
    [PublishingUsername <String>]: Publishing user name.
    [PushKind <String>]: Kind of resource.
    [PythonVersion <String>]: Version of Python.
    [RemoteDebuggingEnabled <Boolean?>]: <code>true</code> if remote debugging is enabled; otherwise, <code>false</code>.
    [RemoteDebuggingVersion <String>]: Remote debugging version.
    [RequestCount <Int32?>]: Request Count.
    [RequestTimeInterval <String>]: Time interval.
    [RequestTracingEnabled <Boolean?>]: <code>true</code> if request tracing is enabled; otherwise, <code>false</code>.
    [RequestTracingExpirationTime <DateTime?>]: Request tracing expiration time.
    [ScmIPSecurityRestriction <IIPSecurityRestriction[]>]: IP security restrictions for scm.
    [ScmIPSecurityRestrictionsUseMain <Boolean?>]: IP security restrictions for scm to use main.
    [ScmType <ScmType?>]: SCM type.
    [SlowRequestCount <Int32?>]: Request Count.
    [SlowRequestTimeInterval <String>]: Time interval.
    [SlowRequestTimeTaken <String>]: Time taken.
    [TagWhitelistJson <String>]: Gets or sets a JSON string containing a list of tags that are whitelisted for use by the push registration endpoint.
    [TagsRequiringAuth <String>]: Gets or sets a JSON string containing a list of tags that require user authentication to be used in the push registration endpoint.         Tags can consist of alphanumeric characters and the following:         '_', '@', '#', '.', ':', '-'.         Validation should be performed at the PushRequestHandler.
    [TracingOption <String>]: Tracing options.
    [TriggerPrivateBytesInKb <Int32?>]: A rule based on private bytes.
    [TriggerStatusCode <IStatusCodesBasedTrigger[]>]: A rule based on status codes.
      [Count <Int32?>]: Request Count.
      [Status <Int32?>]: HTTP status code.
      [SubStatus <Int32?>]: Request Sub Status.
      [TimeInterval <String>]: Time interval.
      [Win32Status <Int32?>]: Win32 error code.
    [Use32BitWorkerProcess <Boolean?>]: <code>true</code> to use 32-bit worker process; otherwise, <code>false</code>.
    [VirtualApplication <IVirtualApplication[]>]: Virtual applications.
      [PhysicalPath <String>]: Physical path.
      [PreloadEnabled <Boolean?>]: <code>true</code> if preloading is enabled; otherwise, <code>false</code>.
      [VirtualDirectory <IVirtualDirectory[]>]: Virtual directories for virtual application.
        [PhysicalPath <String>]: Physical path.
        [VirtualPath <String>]: Path to virtual application.
      [VirtualPath <String>]: Virtual path.
    [VnetName <String>]: Virtual Network name.
    [WebSocketsEnabled <Boolean?>]: <code>true</code> if WebSocket is enabled; otherwise, <code>false</code>.
    [WindowsFxVersion <String>]: Xenon App Framework and version
    [XManagedServiceIdentityId <Int32?>]: Explicit Managed Service Identity Id
  [ContainerSize <Int32?>]: Size of the function container.
  [DailyMemoryTimeQuota <Int32?>]: Maximum allowed daily memory-time quota (applicable on dynamic apps only).
  [Enabled <Boolean?>]: <code>true</code> if the app is enabled; otherwise, <code>false</code>. Setting this value to false disables the app (takes the app offline).
  [HostNameSslState <IHostNameSslState[]>]: Hostname SSL states are used to manage the SSL bindings for app's hostnames.
    [HostType <HostType?>]: Indicates whether the hostname is a standard or repository hostname.
    [Name <String>]: Hostname.
    [SslState <SslState?>]: SSL type.
    [Thumbprint <String>]: SSL certificate thumbprint.
    [ToUpdate <Boolean?>]: Set to <code>true</code> to update existing hostname.
    [VirtualIP <String>]: Virtual IP address assigned to the hostname if IP based SSL is enabled.
  [HostNamesDisabled <Boolean?>]: <code>true</code> to disable the public hostnames of the app; otherwise, <code>false</code>.          If <code>true</code>, the app is only accessible via API management process.
  [HostingEnvironmentProfileId <String>]: Resource ID of the App Service Environment.
  [HttpsOnly <Boolean?>]: HttpsOnly: configures a web site to accept only https requests. Issues redirect for         http requests
  [HyperV <Boolean?>]: Hyper-V sandbox.
  [IdentityType <ManagedServiceIdentityType?>]: Type of managed service identity.
  [IdentityUserAssignedIdentity <IManagedServiceIdentityUserAssignedIdentities>]: The list of user assigned identities associated with the resource. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}
    [(Any) <IComponents1Jq1T4ISchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>]: This indicates any property can be added to this object.
  [IsXenon <Boolean?>]: Obsolete: Hyper-V sandbox.
  [RedundancyMode <RedundancyMode?>]: Site redundancy mode
  [Reserved <Boolean?>]: <code>true</code> if reserved; otherwise, <code>false</code>.
  [ScmSiteAlsoStopped <Boolean?>]: <code>true</code> to stop SCM (KUDU) site when the app is stopped; otherwise, <code>false</code>. The default is <code>false</code>.
  [ServerFarmId <String>]: Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/start-azfunctionapp
#>
function Start-AzFunctionApp {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='StartByName', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='StartByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # The name of function app.
    ${Name},

    [Parameter(ParameterSetName='StartByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    ${ResourceGroupName},

    [Parameter(ParameterSetName='StartByName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The Azure subscription ID.
    ${SubscriptionId},

    [Parameter(ParameterSetName='ByObjectInput', Mandatory, ValueFromPipeline)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISite]
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds.
    ${PassThru},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Uri]
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
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
            StartByName = 'Az.Functions.custom\Start-AzFunctionApp';
            ByObjectInput = 'Az.Functions.custom\Start-AzFunctionApp';
        }
        if (('StartByName') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Stops a function app.
.Description
Stops a function app.
.Example
PS C:\> Get-AzFunctionApp -Name MyAppName -ResourceGroupName MyResourceGroupName | Stop-AzFunctionApp -Force
.Example
PS C:\> Stop-AzFunctionApp -Name MyAppName -ResourceGroupName MyResourceGroupName -Force

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISite
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <ISite>: 
  Location <String>: Resource Location.
  CloningInfoSourceWebAppId <String>: ARM resource ID of the source app. App resource ID is of the form         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots and         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for other slots.
  [Kind <String>]: Kind of resource.
  [Tag <IResourceTags>]: Resource tags.
    [(Any) <String>]: This indicates any property can be added to this object.
  [ClientAffinityEnabled <Boolean?>]: <code>true</code> to enable client affinity; <code>false</code> to stop sending session affinity cookies, which route client requests in the same session to the same instance. Default is <code>true</code>.
  [ClientCertEnabled <Boolean?>]: <code>true</code> to enable client certificate authentication (TLS mutual authentication); otherwise, <code>false</code>. Default is <code>false</code>.
  [ClientCertExclusionPath <String>]: client certificate authentication comma-separated exclusion paths
  [CloningInfoAppSettingsOverride <ICloningInfoAppSettingsOverrides>]: Application setting overrides for cloned app. If specified, these settings override the settings cloned         from source app. Otherwise, application settings from source app are retained.
    [(Any) <String>]: This indicates any property can be added to this object.
  [CloningInfoCloneCustomHostName <Boolean?>]: <code>true</code> to clone custom hostnames from source app; otherwise, <code>false</code>.
  [CloningInfoCloneSourceControl <Boolean?>]: <code>true</code> to clone source control from source app; otherwise, <code>false</code>.
  [CloningInfoConfigureLoadBalancing <Boolean?>]: <code>true</code> to configure load balancing for source and destination app.
  [CloningInfoCorrelationId <String>]: Correlation ID of cloning operation. This ID ties multiple cloning operations         together to use the same snapshot.
  [CloningInfoHostingEnvironment <String>]: App Service Environment.
  [CloningInfoOverwrite <Boolean?>]: <code>true</code> to overwrite destination app; otherwise, <code>false</code>.
  [CloningInfoSourceWebAppLocation <String>]: Location of source app ex: West US or North Europe
  [CloningInfoTrafficManagerProfileId <String>]: ARM resource ID of the Traffic Manager profile to use, if it exists. Traffic Manager resource ID is of the form         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficManagerProfiles/{profileName}.
  [CloningInfoTrafficManagerProfileName <String>]: Name of Traffic Manager profile to create. This is only needed if Traffic Manager profile does not already exist.
  [Config <ISiteConfig>]: Configuration of the app.
    IsPushEnabled <Boolean>: Gets or sets a flag indicating whether the Push endpoint is enabled.
    [ActionMinProcessExecutionTime <String>]: Minimum time the process must execute         before taking the action
    [ActionType <AutoHealActionType?>]: Predefined action to be taken.
    [AlwaysOn <Boolean?>]: <code>true</code> if Always On is enabled; otherwise, <code>false</code>.
    [ApiDefinitionUrl <String>]: The URL of the API definition.
    [ApiManagementConfigId <String>]: APIM-Api Identifier.
    [AppCommandLine <String>]: App command line to launch.
    [AppSetting <INameValuePair[]>]: Application settings.
      [Name <String>]: Pair name.
      [Value <String>]: Pair value.
    [AutoHealEnabled <Boolean?>]: <code>true</code> if Auto Heal is enabled; otherwise, <code>false</code>.
    [AutoSwapSlotName <String>]: Auto-swap slot name.
    [ConnectionString <IConnStringInfo[]>]: Connection strings.
      [ConnectionString <String>]: Connection string value.
      [Name <String>]: Name of connection string.
      [Type <ConnectionStringType?>]: Type of database.
    [CorAllowedOrigin <String[]>]: Gets or sets the list of origins that should be allowed to make cross-origin         calls (for example: http://example.com:12345). Use "*" to allow all.
    [CorSupportCredentials <Boolean?>]: Gets or sets whether CORS requests with credentials are allowed. See         https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Requests_with_credentials         for more details.
    [CustomActionExe <String>]: Executable to be run.
    [CustomActionParameter <String>]: Parameters for the executable.
    [DefaultDocument <String[]>]: Default documents.
    [DetailedErrorLoggingEnabled <Boolean?>]: <code>true</code> if detailed error logging is enabled; otherwise, <code>false</code>.
    [DocumentRoot <String>]: Document root.
    [DynamicTagsJson <String>]: Gets or sets a JSON string containing a list of dynamic tags that will be evaluated from user claims in the push registration endpoint.
    [ExperimentRampUpRule <IRampUpRule[]>]: List of ramp-up rules.
      [ActionHostName <String>]: Hostname of a slot to which the traffic will be redirected if decided to. E.g. myapp-stage.azurewebsites.net.
      [ChangeDecisionCallbackUrl <String>]: Custom decision algorithm can be provided in TiPCallback site extension which URL can be specified. See TiPCallback site extension for the scaffold and contracts.         https://www.siteextensions.net/packages/TiPCallback/
      [ChangeIntervalInMinute <Int32?>]: Specifies interval in minutes to reevaluate ReroutePercentage.
      [ChangeStep <Double?>]: In auto ramp up scenario this is the step to add/remove from <code>ReroutePercentage</code> until it reaches \n<code>MinReroutePercentage</code> or         <code>MaxReroutePercentage</code>. Site metrics are checked every N minutes specified in <code>ChangeIntervalInMinutes</code>.\nCustom decision algorithm         can be provided in TiPCallback site extension which URL can be specified in <code>ChangeDecisionCallbackUrl</code>.
      [MaxReroutePercentage <Double?>]: Specifies upper boundary below which ReroutePercentage will stay.
      [MinReroutePercentage <Double?>]: Specifies lower boundary above which ReroutePercentage will stay.
      [Name <String>]: Name of the routing rule. The recommended name would be to point to the slot which will receive the traffic in the experiment.
      [ReroutePercentage <Double?>]: Percentage of the traffic which will be redirected to <code>ActionHostName</code>.
    [FtpsState <FtpsState?>]: State of FTP / FTPS service
    [HandlerMapping <IHandlerMapping[]>]: Handler mappings.
      [Argument <String>]: Command-line arguments to be passed to the script processor.
      [Extension <String>]: Requests with this extension will be handled using the specified FastCGI application.
      [ScriptProcessor <String>]: The absolute path to the FastCGI application.
    [HealthCheckPath <String>]: Health check path
    [Http20Enabled <Boolean?>]: Http20Enabled: configures a web site to allow clients to connect over http2.0
    [HttpLoggingEnabled <Boolean?>]: <code>true</code> if HTTP logging is enabled; otherwise, <code>false</code>.
    [IPSecurityRestriction <IIPSecurityRestriction[]>]: IP security restrictions for main.
      [Action <String>]: Allow or Deny access for this IP range.
      [Description <String>]: IP restriction rule description.
      [IPAddress <String>]: IP address the security restriction is valid for.         It can be in form of pure ipv4 address (required SubnetMask property) or         CIDR notation such as ipv4/mask (leading bit match). For CIDR,         SubnetMask property must not be specified.
      [Name <String>]: IP restriction rule name.
      [Priority <Int32?>]: Priority of IP restriction rule.
      [SubnetMask <String>]: Subnet mask for the range of IP addresses the restriction is valid for.
      [SubnetTrafficTag <Int32?>]: (internal) Subnet traffic tag
      [Tag <IPFilterTag?>]: Defines what this IP filter will be used for. This is to support IP filtering on proxies.
      [VnetSubnetResourceId <String>]: Virtual network resource id
      [VnetTrafficTag <Int32?>]: (internal) Vnet traffic tag
    [JavaContainer <String>]: Java container.
    [JavaContainerVersion <String>]: Java container version.
    [JavaVersion <String>]: Java version.
    [LimitMaxDiskSizeInMb <Int64?>]: Maximum allowed disk size usage in MB.
    [LimitMaxMemoryInMb <Int64?>]: Maximum allowed memory usage in MB.
    [LimitMaxPercentageCpu <Double?>]: Maximum allowed CPU usage percentage.
    [LinuxFxVersion <String>]: Linux App Framework and version
    [LoadBalancing <SiteLoadBalancing?>]: Site load balancing.
    [LocalMySqlEnabled <Boolean?>]: <code>true</code> to enable local MySQL; otherwise, <code>false</code>.
    [LogsDirectorySizeLimit <Int32?>]: HTTP logs directory size limit.
    [MachineKeyDecryption <String>]: Algorithm used for decryption.
    [MachineKeyDecryptionKey <String>]: Decryption key.
    [MachineKeyValidation <String>]: MachineKey validation.
    [MachineKeyValidationKey <String>]: Validation key.
    [ManagedPipelineMode <ManagedPipelineMode?>]: Managed pipeline mode.
    [ManagedServiceIdentityId <Int32?>]: Managed Service Identity Id
    [MinTlsVersion <SupportedTlsVersions?>]: MinTlsVersion: configures the minimum version of TLS required for SSL requests
    [NetFrameworkVersion <String>]: .NET Framework version.
    [NodeVersion <String>]: Version of Node.js.
    [NumberOfWorker <Int32?>]: Number of workers.
    [PhpVersion <String>]: Version of PHP.
    [PowerShellVersion <String>]: Version of PowerShell.
    [PreWarmedInstanceCount <Int32?>]: Number of preWarmed instances.         This setting only applies to the Consumption and Elastic Plans
    [PublishingUsername <String>]: Publishing user name.
    [PushKind <String>]: Kind of resource.
    [PythonVersion <String>]: Version of Python.
    [RemoteDebuggingEnabled <Boolean?>]: <code>true</code> if remote debugging is enabled; otherwise, <code>false</code>.
    [RemoteDebuggingVersion <String>]: Remote debugging version.
    [RequestCount <Int32?>]: Request Count.
    [RequestTimeInterval <String>]: Time interval.
    [RequestTracingEnabled <Boolean?>]: <code>true</code> if request tracing is enabled; otherwise, <code>false</code>.
    [RequestTracingExpirationTime <DateTime?>]: Request tracing expiration time.
    [ScmIPSecurityRestriction <IIPSecurityRestriction[]>]: IP security restrictions for scm.
    [ScmIPSecurityRestrictionsUseMain <Boolean?>]: IP security restrictions for scm to use main.
    [ScmType <ScmType?>]: SCM type.
    [SlowRequestCount <Int32?>]: Request Count.
    [SlowRequestTimeInterval <String>]: Time interval.
    [SlowRequestTimeTaken <String>]: Time taken.
    [TagWhitelistJson <String>]: Gets or sets a JSON string containing a list of tags that are whitelisted for use by the push registration endpoint.
    [TagsRequiringAuth <String>]: Gets or sets a JSON string containing a list of tags that require user authentication to be used in the push registration endpoint.         Tags can consist of alphanumeric characters and the following:         '_', '@', '#', '.', ':', '-'.         Validation should be performed at the PushRequestHandler.
    [TracingOption <String>]: Tracing options.
    [TriggerPrivateBytesInKb <Int32?>]: A rule based on private bytes.
    [TriggerStatusCode <IStatusCodesBasedTrigger[]>]: A rule based on status codes.
      [Count <Int32?>]: Request Count.
      [Status <Int32?>]: HTTP status code.
      [SubStatus <Int32?>]: Request Sub Status.
      [TimeInterval <String>]: Time interval.
      [Win32Status <Int32?>]: Win32 error code.
    [Use32BitWorkerProcess <Boolean?>]: <code>true</code> to use 32-bit worker process; otherwise, <code>false</code>.
    [VirtualApplication <IVirtualApplication[]>]: Virtual applications.
      [PhysicalPath <String>]: Physical path.
      [PreloadEnabled <Boolean?>]: <code>true</code> if preloading is enabled; otherwise, <code>false</code>.
      [VirtualDirectory <IVirtualDirectory[]>]: Virtual directories for virtual application.
        [PhysicalPath <String>]: Physical path.
        [VirtualPath <String>]: Path to virtual application.
      [VirtualPath <String>]: Virtual path.
    [VnetName <String>]: Virtual Network name.
    [WebSocketsEnabled <Boolean?>]: <code>true</code> if WebSocket is enabled; otherwise, <code>false</code>.
    [WindowsFxVersion <String>]: Xenon App Framework and version
    [XManagedServiceIdentityId <Int32?>]: Explicit Managed Service Identity Id
  [ContainerSize <Int32?>]: Size of the function container.
  [DailyMemoryTimeQuota <Int32?>]: Maximum allowed daily memory-time quota (applicable on dynamic apps only).
  [Enabled <Boolean?>]: <code>true</code> if the app is enabled; otherwise, <code>false</code>. Setting this value to false disables the app (takes the app offline).
  [HostNameSslState <IHostNameSslState[]>]: Hostname SSL states are used to manage the SSL bindings for app's hostnames.
    [HostType <HostType?>]: Indicates whether the hostname is a standard or repository hostname.
    [Name <String>]: Hostname.
    [SslState <SslState?>]: SSL type.
    [Thumbprint <String>]: SSL certificate thumbprint.
    [ToUpdate <Boolean?>]: Set to <code>true</code> to update existing hostname.
    [VirtualIP <String>]: Virtual IP address assigned to the hostname if IP based SSL is enabled.
  [HostNamesDisabled <Boolean?>]: <code>true</code> to disable the public hostnames of the app; otherwise, <code>false</code>.          If <code>true</code>, the app is only accessible via API management process.
  [HostingEnvironmentProfileId <String>]: Resource ID of the App Service Environment.
  [HttpsOnly <Boolean?>]: HttpsOnly: configures a web site to accept only https requests. Issues redirect for         http requests
  [HyperV <Boolean?>]: Hyper-V sandbox.
  [IdentityType <ManagedServiceIdentityType?>]: Type of managed service identity.
  [IdentityUserAssignedIdentity <IManagedServiceIdentityUserAssignedIdentities>]: The list of user assigned identities associated with the resource. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}
    [(Any) <IComponents1Jq1T4ISchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>]: This indicates any property can be added to this object.
  [IsXenon <Boolean?>]: Obsolete: Hyper-V sandbox.
  [RedundancyMode <RedundancyMode?>]: Site redundancy mode
  [Reserved <Boolean?>]: <code>true</code> if reserved; otherwise, <code>false</code>.
  [ScmSiteAlsoStopped <Boolean?>]: <code>true</code> to stop SCM (KUDU) site when the app is stopped; otherwise, <code>false</code>. The default is <code>false</code>.
  [ServerFarmId <String>]: Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/stop-azfunctionapp
#>
function Stop-AzFunctionApp {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='StopByName', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='StopByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # The name of function app.
    ${Name},

    [Parameter(ParameterSetName='StopByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    ${ResourceGroupName},

    [Parameter(ParameterSetName='StopByName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The Azure subscription ID.
    ${SubscriptionId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Forces the cmdlet to stop the function app without prompting for confirmation.
    ${Force},

    [Parameter(ParameterSetName='ByObjectInput', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISite]
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds.
    ${PassThru},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Uri]
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
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
            StopByName = 'Az.Functions.custom\Stop-AzFunctionApp';
            ByObjectInput = 'Az.Functions.custom\Stop-AzFunctionApp';
        }
        if (('StopByName') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/throwruntimenotsupportedexception
#>
function ThrowRuntimeNotSupportedException {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${Message},

    [Parameter(Position=1, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${ErrorId}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\ThrowRuntimeNotSupportedException';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/throwterminatingerror
#>
function ThrowTerminatingError {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${ErrorId},

    [Parameter(Position=1, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${ErrorMessage},

    [Parameter(Position=2, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.ErrorCategory]
    ${ErrorCategory},

    [Parameter(Position=3)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Exception]
    ${Exception},

    [Parameter(Position=4)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${TargetObject}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\ThrowTerminatingError';
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
Updates a function app.
.Description
Updates a function app.
.Example
PS C:\> Update-AzFunctionApp -Name MyUniqueFunctionAppName -ResourceGroupName MyResourceGroupName -PlanName NewPlanName 
.Example
PS C:\> Update-AzFunctionApp -Name MyUniqueFunctionAppName -ResourceGroupName MyResourceGroupName -IdentityType SystemAssigned 
.Example
PS C:\> Update-AzFunctionApp -Name MyUniqueFunctionAppName -ResourceGroupName MyResourceGroupName -ApplicationInsightsName ApplicationInsightsProjectName 
.Example
PS C:\> Update-AzFunctionApp -Name MyUniqueFunctionAppName -ResourceGroupName MyResourceGroupName -IdentityType None 

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISite
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISite
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <ISite>: 
  Location <String>: Resource Location.
  CloningInfoSourceWebAppId <String>: ARM resource ID of the source app. App resource ID is of the form         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots and         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for other slots.
  [Kind <String>]: Kind of resource.
  [Tag <IResourceTags>]: Resource tags.
    [(Any) <String>]: This indicates any property can be added to this object.
  [ClientAffinityEnabled <Boolean?>]: <code>true</code> to enable client affinity; <code>false</code> to stop sending session affinity cookies, which route client requests in the same session to the same instance. Default is <code>true</code>.
  [ClientCertEnabled <Boolean?>]: <code>true</code> to enable client certificate authentication (TLS mutual authentication); otherwise, <code>false</code>. Default is <code>false</code>.
  [ClientCertExclusionPath <String>]: client certificate authentication comma-separated exclusion paths
  [CloningInfoAppSettingsOverride <ICloningInfoAppSettingsOverrides>]: Application setting overrides for cloned app. If specified, these settings override the settings cloned         from source app. Otherwise, application settings from source app are retained.
    [(Any) <String>]: This indicates any property can be added to this object.
  [CloningInfoCloneCustomHostName <Boolean?>]: <code>true</code> to clone custom hostnames from source app; otherwise, <code>false</code>.
  [CloningInfoCloneSourceControl <Boolean?>]: <code>true</code> to clone source control from source app; otherwise, <code>false</code>.
  [CloningInfoConfigureLoadBalancing <Boolean?>]: <code>true</code> to configure load balancing for source and destination app.
  [CloningInfoCorrelationId <String>]: Correlation ID of cloning operation. This ID ties multiple cloning operations         together to use the same snapshot.
  [CloningInfoHostingEnvironment <String>]: App Service Environment.
  [CloningInfoOverwrite <Boolean?>]: <code>true</code> to overwrite destination app; otherwise, <code>false</code>.
  [CloningInfoSourceWebAppLocation <String>]: Location of source app ex: West US or North Europe
  [CloningInfoTrafficManagerProfileId <String>]: ARM resource ID of the Traffic Manager profile to use, if it exists. Traffic Manager resource ID is of the form         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficManagerProfiles/{profileName}.
  [CloningInfoTrafficManagerProfileName <String>]: Name of Traffic Manager profile to create. This is only needed if Traffic Manager profile does not already exist.
  [Config <ISiteConfig>]: Configuration of the app.
    IsPushEnabled <Boolean>: Gets or sets a flag indicating whether the Push endpoint is enabled.
    [ActionMinProcessExecutionTime <String>]: Minimum time the process must execute         before taking the action
    [ActionType <AutoHealActionType?>]: Predefined action to be taken.
    [AlwaysOn <Boolean?>]: <code>true</code> if Always On is enabled; otherwise, <code>false</code>.
    [ApiDefinitionUrl <String>]: The URL of the API definition.
    [ApiManagementConfigId <String>]: APIM-Api Identifier.
    [AppCommandLine <String>]: App command line to launch.
    [AppSetting <INameValuePair[]>]: Application settings.
      [Name <String>]: Pair name.
      [Value <String>]: Pair value.
    [AutoHealEnabled <Boolean?>]: <code>true</code> if Auto Heal is enabled; otherwise, <code>false</code>.
    [AutoSwapSlotName <String>]: Auto-swap slot name.
    [ConnectionString <IConnStringInfo[]>]: Connection strings.
      [ConnectionString <String>]: Connection string value.
      [Name <String>]: Name of connection string.
      [Type <ConnectionStringType?>]: Type of database.
    [CorAllowedOrigin <String[]>]: Gets or sets the list of origins that should be allowed to make cross-origin         calls (for example: http://example.com:12345). Use "*" to allow all.
    [CorSupportCredentials <Boolean?>]: Gets or sets whether CORS requests with credentials are allowed. See         https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Requests_with_credentials         for more details.
    [CustomActionExe <String>]: Executable to be run.
    [CustomActionParameter <String>]: Parameters for the executable.
    [DefaultDocument <String[]>]: Default documents.
    [DetailedErrorLoggingEnabled <Boolean?>]: <code>true</code> if detailed error logging is enabled; otherwise, <code>false</code>.
    [DocumentRoot <String>]: Document root.
    [DynamicTagsJson <String>]: Gets or sets a JSON string containing a list of dynamic tags that will be evaluated from user claims in the push registration endpoint.
    [ExperimentRampUpRule <IRampUpRule[]>]: List of ramp-up rules.
      [ActionHostName <String>]: Hostname of a slot to which the traffic will be redirected if decided to. E.g. myapp-stage.azurewebsites.net.
      [ChangeDecisionCallbackUrl <String>]: Custom decision algorithm can be provided in TiPCallback site extension which URL can be specified. See TiPCallback site extension for the scaffold and contracts.         https://www.siteextensions.net/packages/TiPCallback/
      [ChangeIntervalInMinute <Int32?>]: Specifies interval in minutes to reevaluate ReroutePercentage.
      [ChangeStep <Double?>]: In auto ramp up scenario this is the step to add/remove from <code>ReroutePercentage</code> until it reaches \n<code>MinReroutePercentage</code> or         <code>MaxReroutePercentage</code>. Site metrics are checked every N minutes specified in <code>ChangeIntervalInMinutes</code>.\nCustom decision algorithm         can be provided in TiPCallback site extension which URL can be specified in <code>ChangeDecisionCallbackUrl</code>.
      [MaxReroutePercentage <Double?>]: Specifies upper boundary below which ReroutePercentage will stay.
      [MinReroutePercentage <Double?>]: Specifies lower boundary above which ReroutePercentage will stay.
      [Name <String>]: Name of the routing rule. The recommended name would be to point to the slot which will receive the traffic in the experiment.
      [ReroutePercentage <Double?>]: Percentage of the traffic which will be redirected to <code>ActionHostName</code>.
    [FtpsState <FtpsState?>]: State of FTP / FTPS service
    [HandlerMapping <IHandlerMapping[]>]: Handler mappings.
      [Argument <String>]: Command-line arguments to be passed to the script processor.
      [Extension <String>]: Requests with this extension will be handled using the specified FastCGI application.
      [ScriptProcessor <String>]: The absolute path to the FastCGI application.
    [HealthCheckPath <String>]: Health check path
    [Http20Enabled <Boolean?>]: Http20Enabled: configures a web site to allow clients to connect over http2.0
    [HttpLoggingEnabled <Boolean?>]: <code>true</code> if HTTP logging is enabled; otherwise, <code>false</code>.
    [IPSecurityRestriction <IIPSecurityRestriction[]>]: IP security restrictions for main.
      [Action <String>]: Allow or Deny access for this IP range.
      [Description <String>]: IP restriction rule description.
      [IPAddress <String>]: IP address the security restriction is valid for.         It can be in form of pure ipv4 address (required SubnetMask property) or         CIDR notation such as ipv4/mask (leading bit match). For CIDR,         SubnetMask property must not be specified.
      [Name <String>]: IP restriction rule name.
      [Priority <Int32?>]: Priority of IP restriction rule.
      [SubnetMask <String>]: Subnet mask for the range of IP addresses the restriction is valid for.
      [SubnetTrafficTag <Int32?>]: (internal) Subnet traffic tag
      [Tag <IPFilterTag?>]: Defines what this IP filter will be used for. This is to support IP filtering on proxies.
      [VnetSubnetResourceId <String>]: Virtual network resource id
      [VnetTrafficTag <Int32?>]: (internal) Vnet traffic tag
    [JavaContainer <String>]: Java container.
    [JavaContainerVersion <String>]: Java container version.
    [JavaVersion <String>]: Java version.
    [LimitMaxDiskSizeInMb <Int64?>]: Maximum allowed disk size usage in MB.
    [LimitMaxMemoryInMb <Int64?>]: Maximum allowed memory usage in MB.
    [LimitMaxPercentageCpu <Double?>]: Maximum allowed CPU usage percentage.
    [LinuxFxVersion <String>]: Linux App Framework and version
    [LoadBalancing <SiteLoadBalancing?>]: Site load balancing.
    [LocalMySqlEnabled <Boolean?>]: <code>true</code> to enable local MySQL; otherwise, <code>false</code>.
    [LogsDirectorySizeLimit <Int32?>]: HTTP logs directory size limit.
    [MachineKeyDecryption <String>]: Algorithm used for decryption.
    [MachineKeyDecryptionKey <String>]: Decryption key.
    [MachineKeyValidation <String>]: MachineKey validation.
    [MachineKeyValidationKey <String>]: Validation key.
    [ManagedPipelineMode <ManagedPipelineMode?>]: Managed pipeline mode.
    [ManagedServiceIdentityId <Int32?>]: Managed Service Identity Id
    [MinTlsVersion <SupportedTlsVersions?>]: MinTlsVersion: configures the minimum version of TLS required for SSL requests
    [NetFrameworkVersion <String>]: .NET Framework version.
    [NodeVersion <String>]: Version of Node.js.
    [NumberOfWorker <Int32?>]: Number of workers.
    [PhpVersion <String>]: Version of PHP.
    [PowerShellVersion <String>]: Version of PowerShell.
    [PreWarmedInstanceCount <Int32?>]: Number of preWarmed instances.         This setting only applies to the Consumption and Elastic Plans
    [PublishingUsername <String>]: Publishing user name.
    [PushKind <String>]: Kind of resource.
    [PythonVersion <String>]: Version of Python.
    [RemoteDebuggingEnabled <Boolean?>]: <code>true</code> if remote debugging is enabled; otherwise, <code>false</code>.
    [RemoteDebuggingVersion <String>]: Remote debugging version.
    [RequestCount <Int32?>]: Request Count.
    [RequestTimeInterval <String>]: Time interval.
    [RequestTracingEnabled <Boolean?>]: <code>true</code> if request tracing is enabled; otherwise, <code>false</code>.
    [RequestTracingExpirationTime <DateTime?>]: Request tracing expiration time.
    [ScmIPSecurityRestriction <IIPSecurityRestriction[]>]: IP security restrictions for scm.
    [ScmIPSecurityRestrictionsUseMain <Boolean?>]: IP security restrictions for scm to use main.
    [ScmType <ScmType?>]: SCM type.
    [SlowRequestCount <Int32?>]: Request Count.
    [SlowRequestTimeInterval <String>]: Time interval.
    [SlowRequestTimeTaken <String>]: Time taken.
    [TagWhitelistJson <String>]: Gets or sets a JSON string containing a list of tags that are whitelisted for use by the push registration endpoint.
    [TagsRequiringAuth <String>]: Gets or sets a JSON string containing a list of tags that require user authentication to be used in the push registration endpoint.         Tags can consist of alphanumeric characters and the following:         '_', '@', '#', '.', ':', '-'.         Validation should be performed at the PushRequestHandler.
    [TracingOption <String>]: Tracing options.
    [TriggerPrivateBytesInKb <Int32?>]: A rule based on private bytes.
    [TriggerStatusCode <IStatusCodesBasedTrigger[]>]: A rule based on status codes.
      [Count <Int32?>]: Request Count.
      [Status <Int32?>]: HTTP status code.
      [SubStatus <Int32?>]: Request Sub Status.
      [TimeInterval <String>]: Time interval.
      [Win32Status <Int32?>]: Win32 error code.
    [Use32BitWorkerProcess <Boolean?>]: <code>true</code> to use 32-bit worker process; otherwise, <code>false</code>.
    [VirtualApplication <IVirtualApplication[]>]: Virtual applications.
      [PhysicalPath <String>]: Physical path.
      [PreloadEnabled <Boolean?>]: <code>true</code> if preloading is enabled; otherwise, <code>false</code>.
      [VirtualDirectory <IVirtualDirectory[]>]: Virtual directories for virtual application.
        [PhysicalPath <String>]: Physical path.
        [VirtualPath <String>]: Path to virtual application.
      [VirtualPath <String>]: Virtual path.
    [VnetName <String>]: Virtual Network name.
    [WebSocketsEnabled <Boolean?>]: <code>true</code> if WebSocket is enabled; otherwise, <code>false</code>.
    [WindowsFxVersion <String>]: Xenon App Framework and version
    [XManagedServiceIdentityId <Int32?>]: Explicit Managed Service Identity Id
  [ContainerSize <Int32?>]: Size of the function container.
  [DailyMemoryTimeQuota <Int32?>]: Maximum allowed daily memory-time quota (applicable on dynamic apps only).
  [Enabled <Boolean?>]: <code>true</code> if the app is enabled; otherwise, <code>false</code>. Setting this value to false disables the app (takes the app offline).
  [HostNameSslState <IHostNameSslState[]>]: Hostname SSL states are used to manage the SSL bindings for app's hostnames.
    [HostType <HostType?>]: Indicates whether the hostname is a standard or repository hostname.
    [Name <String>]: Hostname.
    [SslState <SslState?>]: SSL type.
    [Thumbprint <String>]: SSL certificate thumbprint.
    [ToUpdate <Boolean?>]: Set to <code>true</code> to update existing hostname.
    [VirtualIP <String>]: Virtual IP address assigned to the hostname if IP based SSL is enabled.
  [HostNamesDisabled <Boolean?>]: <code>true</code> to disable the public hostnames of the app; otherwise, <code>false</code>.          If <code>true</code>, the app is only accessible via API management process.
  [HostingEnvironmentProfileId <String>]: Resource ID of the App Service Environment.
  [HttpsOnly <Boolean?>]: HttpsOnly: configures a web site to accept only https requests. Issues redirect for         http requests
  [HyperV <Boolean?>]: Hyper-V sandbox.
  [IdentityType <ManagedServiceIdentityType?>]: Type of managed service identity.
  [IdentityUserAssignedIdentity <IManagedServiceIdentityUserAssignedIdentities>]: The list of user assigned identities associated with the resource. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}
    [(Any) <IComponents1Jq1T4ISchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>]: This indicates any property can be added to this object.
  [IsXenon <Boolean?>]: Obsolete: Hyper-V sandbox.
  [RedundancyMode <RedundancyMode?>]: Site redundancy mode
  [Reserved <Boolean?>]: <code>true</code> if reserved; otherwise, <code>false</code>.
  [ScmSiteAlsoStopped <Boolean?>]: <code>true</code> to stop SCM (KUDU) site when the app is stopped; otherwise, <code>false</code>. The default is <code>false</code>.
  [ServerFarmId <String>]: Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/update-azfunctionapp
#>
function Update-AzFunctionApp {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISite])]
[CmdletBinding(DefaultParameterSetName='ByName', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # The name of the resource group.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # The name of the function app.
    ${Name},

    [Parameter(ParameterSetName='ByName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The Azure subscription ID.
    ${SubscriptionId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # The name of the service plan.
    ${PlanName},

    [Parameter()]
    [Alias('AppInsightsName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Name of the existing App Insights project to be added to the function app.
    ${ApplicationInsightsName},

    [Parameter()]
    [Alias('AppInsightsKey')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Instrumentation key of App Insights to be added.
    ${ApplicationInsightsKey},

    [Parameter()]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceTags]))]
    [System.Collections.Hashtable]
    # Resource tags.
    ${Tag},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FunctionAppManagedServiceIdentityUpdateType])]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedServiceIdentityType]
    # Specifies the type of identity used for the function app.
    #             The type 'None' will remove any identities from the function app.
    # The acceptable values for this parameter are:
    #             - SystemAssigned
    #             - UserAssigned
    #             - None
    ${IdentityType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # Specifies the list of user identities associated with the function app.
    #             The user identity references will be ARM resource ids in the form:
    #             '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/identities/{identityName}'
    ${IdentityID},

    [Parameter(ParameterSetName='ByObjectInput', Mandatory, ValueFromPipeline)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISite]
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
    [System.Management.Automation.PSObject]
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Starts the operation and returns immediately, before the operation is completed.
    # In order to determine if the operation has successfully been completed, use some other mechanism.
    ${NoWait},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Runs the cmdlet as a background job.
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Uri]
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
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
            ByName = 'Az.Functions.custom\Update-AzFunctionApp';
            ByObjectInput = 'Az.Functions.custom\Update-AzFunctionApp';
        }
        if (('ByName') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Updates a function app service plan.
.Description
Updates a function app service plan.
.Example
PS C:\> Update-AzFunctionAppPlan -ResourceGroupName MyResourceGroupName `
                                 -Name MyPremiumPlan `
                                 -MaximumWorkerCount 20 `
                                 -Sku EP2


.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlan
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlan
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IAppServicePlan>: 
  Location <String>: Resource Location.
  [Kind <String>]: Kind of resource.
  [Tag <IResourceTags>]: Resource tags.
    [(Any) <String>]: This indicates any property can be added to this object.
  [Capacity <Int32?>]: Current number of instances assigned to the resource.
  [FreeOfferExpirationTime <DateTime?>]: The time when the server farm free offer expires.
  [HostingEnvironmentProfileId <String>]: Resource ID of the App Service Environment.
  [HyperV <Boolean?>]: If Hyper-V container app service plan <code>true</code>, <code>false</code> otherwise.
  [IsSpot <Boolean?>]: If <code>true</code>, this App Service Plan owns spot instances.
  [IsXenon <Boolean?>]: Obsolete: If Hyper-V container app service plan <code>true</code>, <code>false</code> otherwise.
  [MaximumElasticWorkerCount <Int32?>]: Maximum number of total workers allowed for this ElasticScaleEnabled App Service Plan
  [PerSiteScaling <Boolean?>]: If <code>true</code>, apps assigned to this App Service plan can be scaled independently.         If <code>false</code>, apps assigned to this App Service plan will scale to all instances of the plan.
  [Reserved <Boolean?>]: If Linux app service plan <code>true</code>, <code>false</code> otherwise.
  [SkuCapability <ICapability[]>]: Capabilities of the SKU, e.g., is traffic manager enabled?
    [Name <String>]: Name of the SKU capability.
    [Reason <String>]: Reason of the SKU capability.
    [Value <String>]: Value of the SKU capability.
  [SkuCapacityDefault <Int32?>]: Default number of workers for this App Service plan SKU.
  [SkuCapacityMaximum <Int32?>]: Maximum number of workers for this App Service plan SKU.
  [SkuCapacityMinimum <Int32?>]: Minimum number of workers for this App Service plan SKU.
  [SkuCapacityScaleType <String>]: Available scale configurations for an App Service plan.
  [SkuFamily <String>]: Family code of the resource SKU.
  [SkuLocation <String[]>]: Locations of the SKU.
  [SkuName <String>]: Name of the resource SKU.
  [SkuSize <String>]: Size specifier of the resource SKU.
  [SkuTier <String>]: Service tier of the resource SKU.
  [SpotExpirationTime <DateTime?>]: The time when the server farm expires. Valid only if it is a spot server farm.
  [TargetWorkerCount <Int32?>]: Scaling worker count.
  [TargetWorkerSizeId <Int32?>]: Scaling worker size ID.
  [WorkerTierName <String>]: Target worker tier assigned to the App Service plan.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/update-azfunctionappplan
#>
function Update-AzFunctionAppPlan {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlan])]
[CmdletBinding(DefaultParameterSetName='ByName', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the resource group to which the resource belongs.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the App Service plan.
    ${Name},

    [Parameter(ParameterSetName='ByName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The Azure subscription ID.
    ${SubscriptionId},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SkuType])]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    # The plan sku.
    # Valid inputs are: EP1, EP2, EP3
    ${Sku},

    [Parameter()]
    [Alias('MaxBurst')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Int32]
    # The maximum number of workers for the app service plan.
    ${MaximumWorkerCount},

    [Parameter()]
    [Alias('MinInstances')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Int32]
    # The minimum number of workers for the app service plan.
    ${MinimumWorkerCount},

    [Parameter()]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceTags]))]
    [System.Collections.Hashtable]
    # Resource tags.
    ${Tag},

    [Parameter(ParameterSetName='ByObjectInput', Mandatory, ValueFromPipeline)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServicePlan]
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
    [System.Management.Automation.PSObject]
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously.
    ${NoWait},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job.
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Uri]
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
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
            ByName = 'Az.Functions.custom\Update-AzFunctionAppPlan';
            ByObjectInput = 'Az.Functions.custom\Update-AzFunctionAppPlan';
        }
        if (('ByName') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Adds or updates app settings in a function app.
.Description
Adds or updates app settings in a function app.
.Example
PS C:\> Update-AzFunctionAppSetting -Name MyAppName -ResourceGroupName MyResourceGroupName -AppSetting @{"Name1" = "Value1"}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISite
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStringDictionary
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <ISite>: 
  Location <String>: Resource Location.
  CloningInfoSourceWebAppId <String>: ARM resource ID of the source app. App resource ID is of the form         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots and         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for other slots.
  [Kind <String>]: Kind of resource.
  [Tag <IResourceTags>]: Resource tags.
    [(Any) <String>]: This indicates any property can be added to this object.
  [ClientAffinityEnabled <Boolean?>]: <code>true</code> to enable client affinity; <code>false</code> to stop sending session affinity cookies, which route client requests in the same session to the same instance. Default is <code>true</code>.
  [ClientCertEnabled <Boolean?>]: <code>true</code> to enable client certificate authentication (TLS mutual authentication); otherwise, <code>false</code>. Default is <code>false</code>.
  [ClientCertExclusionPath <String>]: client certificate authentication comma-separated exclusion paths
  [CloningInfoAppSettingsOverride <ICloningInfoAppSettingsOverrides>]: Application setting overrides for cloned app. If specified, these settings override the settings cloned         from source app. Otherwise, application settings from source app are retained.
    [(Any) <String>]: This indicates any property can be added to this object.
  [CloningInfoCloneCustomHostName <Boolean?>]: <code>true</code> to clone custom hostnames from source app; otherwise, <code>false</code>.
  [CloningInfoCloneSourceControl <Boolean?>]: <code>true</code> to clone source control from source app; otherwise, <code>false</code>.
  [CloningInfoConfigureLoadBalancing <Boolean?>]: <code>true</code> to configure load balancing for source and destination app.
  [CloningInfoCorrelationId <String>]: Correlation ID of cloning operation. This ID ties multiple cloning operations         together to use the same snapshot.
  [CloningInfoHostingEnvironment <String>]: App Service Environment.
  [CloningInfoOverwrite <Boolean?>]: <code>true</code> to overwrite destination app; otherwise, <code>false</code>.
  [CloningInfoSourceWebAppLocation <String>]: Location of source app ex: West US or North Europe
  [CloningInfoTrafficManagerProfileId <String>]: ARM resource ID of the Traffic Manager profile to use, if it exists. Traffic Manager resource ID is of the form         /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficManagerProfiles/{profileName}.
  [CloningInfoTrafficManagerProfileName <String>]: Name of Traffic Manager profile to create. This is only needed if Traffic Manager profile does not already exist.
  [Config <ISiteConfig>]: Configuration of the app.
    IsPushEnabled <Boolean>: Gets or sets a flag indicating whether the Push endpoint is enabled.
    [ActionMinProcessExecutionTime <String>]: Minimum time the process must execute         before taking the action
    [ActionType <AutoHealActionType?>]: Predefined action to be taken.
    [AlwaysOn <Boolean?>]: <code>true</code> if Always On is enabled; otherwise, <code>false</code>.
    [ApiDefinitionUrl <String>]: The URL of the API definition.
    [ApiManagementConfigId <String>]: APIM-Api Identifier.
    [AppCommandLine <String>]: App command line to launch.
    [AppSetting <INameValuePair[]>]: Application settings.
      [Name <String>]: Pair name.
      [Value <String>]: Pair value.
    [AutoHealEnabled <Boolean?>]: <code>true</code> if Auto Heal is enabled; otherwise, <code>false</code>.
    [AutoSwapSlotName <String>]: Auto-swap slot name.
    [ConnectionString <IConnStringInfo[]>]: Connection strings.
      [ConnectionString <String>]: Connection string value.
      [Name <String>]: Name of connection string.
      [Type <ConnectionStringType?>]: Type of database.
    [CorAllowedOrigin <String[]>]: Gets or sets the list of origins that should be allowed to make cross-origin         calls (for example: http://example.com:12345). Use "*" to allow all.
    [CorSupportCredentials <Boolean?>]: Gets or sets whether CORS requests with credentials are allowed. See         https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Requests_with_credentials         for more details.
    [CustomActionExe <String>]: Executable to be run.
    [CustomActionParameter <String>]: Parameters for the executable.
    [DefaultDocument <String[]>]: Default documents.
    [DetailedErrorLoggingEnabled <Boolean?>]: <code>true</code> if detailed error logging is enabled; otherwise, <code>false</code>.
    [DocumentRoot <String>]: Document root.
    [DynamicTagsJson <String>]: Gets or sets a JSON string containing a list of dynamic tags that will be evaluated from user claims in the push registration endpoint.
    [ExperimentRampUpRule <IRampUpRule[]>]: List of ramp-up rules.
      [ActionHostName <String>]: Hostname of a slot to which the traffic will be redirected if decided to. E.g. myapp-stage.azurewebsites.net.
      [ChangeDecisionCallbackUrl <String>]: Custom decision algorithm can be provided in TiPCallback site extension which URL can be specified. See TiPCallback site extension for the scaffold and contracts.         https://www.siteextensions.net/packages/TiPCallback/
      [ChangeIntervalInMinute <Int32?>]: Specifies interval in minutes to reevaluate ReroutePercentage.
      [ChangeStep <Double?>]: In auto ramp up scenario this is the step to add/remove from <code>ReroutePercentage</code> until it reaches \n<code>MinReroutePercentage</code> or         <code>MaxReroutePercentage</code>. Site metrics are checked every N minutes specified in <code>ChangeIntervalInMinutes</code>.\nCustom decision algorithm         can be provided in TiPCallback site extension which URL can be specified in <code>ChangeDecisionCallbackUrl</code>.
      [MaxReroutePercentage <Double?>]: Specifies upper boundary below which ReroutePercentage will stay.
      [MinReroutePercentage <Double?>]: Specifies lower boundary above which ReroutePercentage will stay.
      [Name <String>]: Name of the routing rule. The recommended name would be to point to the slot which will receive the traffic in the experiment.
      [ReroutePercentage <Double?>]: Percentage of the traffic which will be redirected to <code>ActionHostName</code>.
    [FtpsState <FtpsState?>]: State of FTP / FTPS service
    [HandlerMapping <IHandlerMapping[]>]: Handler mappings.
      [Argument <String>]: Command-line arguments to be passed to the script processor.
      [Extension <String>]: Requests with this extension will be handled using the specified FastCGI application.
      [ScriptProcessor <String>]: The absolute path to the FastCGI application.
    [HealthCheckPath <String>]: Health check path
    [Http20Enabled <Boolean?>]: Http20Enabled: configures a web site to allow clients to connect over http2.0
    [HttpLoggingEnabled <Boolean?>]: <code>true</code> if HTTP logging is enabled; otherwise, <code>false</code>.
    [IPSecurityRestriction <IIPSecurityRestriction[]>]: IP security restrictions for main.
      [Action <String>]: Allow or Deny access for this IP range.
      [Description <String>]: IP restriction rule description.
      [IPAddress <String>]: IP address the security restriction is valid for.         It can be in form of pure ipv4 address (required SubnetMask property) or         CIDR notation such as ipv4/mask (leading bit match). For CIDR,         SubnetMask property must not be specified.
      [Name <String>]: IP restriction rule name.
      [Priority <Int32?>]: Priority of IP restriction rule.
      [SubnetMask <String>]: Subnet mask for the range of IP addresses the restriction is valid for.
      [SubnetTrafficTag <Int32?>]: (internal) Subnet traffic tag
      [Tag <IPFilterTag?>]: Defines what this IP filter will be used for. This is to support IP filtering on proxies.
      [VnetSubnetResourceId <String>]: Virtual network resource id
      [VnetTrafficTag <Int32?>]: (internal) Vnet traffic tag
    [JavaContainer <String>]: Java container.
    [JavaContainerVersion <String>]: Java container version.
    [JavaVersion <String>]: Java version.
    [LimitMaxDiskSizeInMb <Int64?>]: Maximum allowed disk size usage in MB.
    [LimitMaxMemoryInMb <Int64?>]: Maximum allowed memory usage in MB.
    [LimitMaxPercentageCpu <Double?>]: Maximum allowed CPU usage percentage.
    [LinuxFxVersion <String>]: Linux App Framework and version
    [LoadBalancing <SiteLoadBalancing?>]: Site load balancing.
    [LocalMySqlEnabled <Boolean?>]: <code>true</code> to enable local MySQL; otherwise, <code>false</code>.
    [LogsDirectorySizeLimit <Int32?>]: HTTP logs directory size limit.
    [MachineKeyDecryption <String>]: Algorithm used for decryption.
    [MachineKeyDecryptionKey <String>]: Decryption key.
    [MachineKeyValidation <String>]: MachineKey validation.
    [MachineKeyValidationKey <String>]: Validation key.
    [ManagedPipelineMode <ManagedPipelineMode?>]: Managed pipeline mode.
    [ManagedServiceIdentityId <Int32?>]: Managed Service Identity Id
    [MinTlsVersion <SupportedTlsVersions?>]: MinTlsVersion: configures the minimum version of TLS required for SSL requests
    [NetFrameworkVersion <String>]: .NET Framework version.
    [NodeVersion <String>]: Version of Node.js.
    [NumberOfWorker <Int32?>]: Number of workers.
    [PhpVersion <String>]: Version of PHP.
    [PowerShellVersion <String>]: Version of PowerShell.
    [PreWarmedInstanceCount <Int32?>]: Number of preWarmed instances.         This setting only applies to the Consumption and Elastic Plans
    [PublishingUsername <String>]: Publishing user name.
    [PushKind <String>]: Kind of resource.
    [PythonVersion <String>]: Version of Python.
    [RemoteDebuggingEnabled <Boolean?>]: <code>true</code> if remote debugging is enabled; otherwise, <code>false</code>.
    [RemoteDebuggingVersion <String>]: Remote debugging version.
    [RequestCount <Int32?>]: Request Count.
    [RequestTimeInterval <String>]: Time interval.
    [RequestTracingEnabled <Boolean?>]: <code>true</code> if request tracing is enabled; otherwise, <code>false</code>.
    [RequestTracingExpirationTime <DateTime?>]: Request tracing expiration time.
    [ScmIPSecurityRestriction <IIPSecurityRestriction[]>]: IP security restrictions for scm.
    [ScmIPSecurityRestrictionsUseMain <Boolean?>]: IP security restrictions for scm to use main.
    [ScmType <ScmType?>]: SCM type.
    [SlowRequestCount <Int32?>]: Request Count.
    [SlowRequestTimeInterval <String>]: Time interval.
    [SlowRequestTimeTaken <String>]: Time taken.
    [TagWhitelistJson <String>]: Gets or sets a JSON string containing a list of tags that are whitelisted for use by the push registration endpoint.
    [TagsRequiringAuth <String>]: Gets or sets a JSON string containing a list of tags that require user authentication to be used in the push registration endpoint.         Tags can consist of alphanumeric characters and the following:         '_', '@', '#', '.', ':', '-'.         Validation should be performed at the PushRequestHandler.
    [TracingOption <String>]: Tracing options.
    [TriggerPrivateBytesInKb <Int32?>]: A rule based on private bytes.
    [TriggerStatusCode <IStatusCodesBasedTrigger[]>]: A rule based on status codes.
      [Count <Int32?>]: Request Count.
      [Status <Int32?>]: HTTP status code.
      [SubStatus <Int32?>]: Request Sub Status.
      [TimeInterval <String>]: Time interval.
      [Win32Status <Int32?>]: Win32 error code.
    [Use32BitWorkerProcess <Boolean?>]: <code>true</code> to use 32-bit worker process; otherwise, <code>false</code>.
    [VirtualApplication <IVirtualApplication[]>]: Virtual applications.
      [PhysicalPath <String>]: Physical path.
      [PreloadEnabled <Boolean?>]: <code>true</code> if preloading is enabled; otherwise, <code>false</code>.
      [VirtualDirectory <IVirtualDirectory[]>]: Virtual directories for virtual application.
        [PhysicalPath <String>]: Physical path.
        [VirtualPath <String>]: Path to virtual application.
      [VirtualPath <String>]: Virtual path.
    [VnetName <String>]: Virtual Network name.
    [WebSocketsEnabled <Boolean?>]: <code>true</code> if WebSocket is enabled; otherwise, <code>false</code>.
    [WindowsFxVersion <String>]: Xenon App Framework and version
    [XManagedServiceIdentityId <Int32?>]: Explicit Managed Service Identity Id
  [ContainerSize <Int32?>]: Size of the function container.
  [DailyMemoryTimeQuota <Int32?>]: Maximum allowed daily memory-time quota (applicable on dynamic apps only).
  [Enabled <Boolean?>]: <code>true</code> if the app is enabled; otherwise, <code>false</code>. Setting this value to false disables the app (takes the app offline).
  [HostNameSslState <IHostNameSslState[]>]: Hostname SSL states are used to manage the SSL bindings for app's hostnames.
    [HostType <HostType?>]: Indicates whether the hostname is a standard or repository hostname.
    [Name <String>]: Hostname.
    [SslState <SslState?>]: SSL type.
    [Thumbprint <String>]: SSL certificate thumbprint.
    [ToUpdate <Boolean?>]: Set to <code>true</code> to update existing hostname.
    [VirtualIP <String>]: Virtual IP address assigned to the hostname if IP based SSL is enabled.
  [HostNamesDisabled <Boolean?>]: <code>true</code> to disable the public hostnames of the app; otherwise, <code>false</code>.          If <code>true</code>, the app is only accessible via API management process.
  [HostingEnvironmentProfileId <String>]: Resource ID of the App Service Environment.
  [HttpsOnly <Boolean?>]: HttpsOnly: configures a web site to accept only https requests. Issues redirect for         http requests
  [HyperV <Boolean?>]: Hyper-V sandbox.
  [IdentityType <ManagedServiceIdentityType?>]: Type of managed service identity.
  [IdentityUserAssignedIdentity <IManagedServiceIdentityUserAssignedIdentities>]: The list of user assigned identities associated with the resource. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}
    [(Any) <IComponents1Jq1T4ISchemasManagedserviceidentityPropertiesUserassignedidentitiesAdditionalproperties>]: This indicates any property can be added to this object.
  [IsXenon <Boolean?>]: Obsolete: Hyper-V sandbox.
  [RedundancyMode <RedundancyMode?>]: Site redundancy mode
  [Reserved <Boolean?>]: <code>true</code> if reserved; otherwise, <code>false</code>.
  [ScmSiteAlsoStopped <Boolean?>]: <code>true</code> to stop SCM (KUDU) site when the app is stopped; otherwise, <code>false</code>. The default is <code>false</code>.
  [ServerFarmId <String>]: Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/update-azfunctionappsetting
#>
function Update-AzFunctionAppSetting {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStringDictionary])]
[CmdletBinding(DefaultParameterSetName='ByName', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the function app.
    ${Name},

    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # Name of the resource group to which the resource belongs.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='ByName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The Azure subscription ID.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Collections.Hashtable]
    # Hashtable with keys and values describe the app settings to be added or updated in the function app.
    # For example: @{"myappsetting"="123"}
    ${AppSetting},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Forces the cmdlet to update function app setting without prompting for confirmation.
    ${Force},

    [Parameter(ParameterSetName='ByObjectInput', Mandatory, ValueFromPipeline)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISite]
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Azure')]
    [System.Management.Automation.PSObject]
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Uri]
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
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
            ByName = 'Az.Functions.custom\Update-AzFunctionAppSetting';
            ByObjectInput = 'Az.Functions.custom\Update-AzFunctionAppSetting';
        }
        if (('ByName') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/validateconsumptionplanlocation
#>
function ValidateConsumptionPlanLocation {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${Location},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    ${OSIsLinux},

    [Parameter(Position=1)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${SubscriptionId},

    [Parameter(Position=2)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelineAppend},

    [Parameter(Position=3)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelinePrepend}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\ValidateConsumptionPlanLocation';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/validatefunctionname
#>
function ValidateFunctionName {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${Name},

    [Parameter(Position=1)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${SubscriptionId},

    [Parameter(Position=2)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelineAppend},

    [Parameter(Position=3)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelinePrepend}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\ValidateFunctionName';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/validatefunctionsv2notavailablelocation
#>
function ValidateFunctionsV2NotAvailableLocation {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${Location}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\ValidateFunctionsV2NotAvailableLocation';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/validatefunctionsversion
#>
function ValidateFunctionsVersion {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${FunctionsVersion}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\ValidateFunctionsVersion';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/validateplanlocation
#>
function ValidatePlanLocation {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${Location},

    [Parameter(Position=1, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${PlanType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    ${OSIsLinux},

    [Parameter(Position=2)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${SubscriptionId},

    [Parameter(Position=3)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelineAppend},

    [Parameter(Position=4)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelinePrepend}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\ValidatePlanLocation';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/validateplanswitchcompatibility
#>
function ValidatePlanSwitchCompatibility {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${CurrentServicePlan},

    [Parameter(Position=1, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${NewServicePlan}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\ValidatePlanSwitchCompatibility';
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
System.Object
.Link
https://docs.microsoft.com/en-us/powershell/module/az.functions/validatepremiumplanlocation
#>
function ValidatePremiumPlanLocation {
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.String]
    ${Location},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    ${OSIsLinux},

    [Parameter(Position=1)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${SubscriptionId},

    [Parameter(Position=2)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelineAppend},

    [Parameter(Position=3)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Body')]
    [System.Object]
    ${HttpPipelinePrepend}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.Functions.custom\ValidatePremiumPlanLocation';
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
