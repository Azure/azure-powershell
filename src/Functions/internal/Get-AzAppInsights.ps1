
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
Returns an Application Insights component.
.Description
Returns an Application Insights component.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.IFunctionsIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponent
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
https://docs.microsoft.com/en-us/powershell/module/az.functions/get-azappinsights
#>
function Get-AzAppInsights {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IApplicationInsightsComponent])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='List1', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [System.String]
    # The name of the Application Insights component resource.
    ${ResourceName},

    [Parameter(ParameterSetName='Get')]
    [Parameter(ParameterSetName='List')]
    [Parameter(ParameterSetName='List1')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # Your Azure subscription ID.
    # This is a GUID-formatted string (e.g.
    # 00000000-0000-0000-0000-000000000000).
    ${SubscriptionId},

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
            Get = 'Az.Functions.private\Get-AzAppInsights_Get';
            GetViaIdentity = 'Az.Functions.private\Get-AzAppInsights_GetViaIdentity';
            List = 'Az.Functions.private\Get-AzAppInsights_List';
            List1 = 'Az.Functions.private\Get-AzAppInsights_List1';
        }
        if (('Get', 'List', 'List1') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
