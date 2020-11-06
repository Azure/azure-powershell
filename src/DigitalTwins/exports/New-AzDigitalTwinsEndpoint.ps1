
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
Create or update DigitalTwinsInstance endpoint.
.Description
Create or update DigitalTwinsInstance endpoint.
.Example
PS C:\> New-AzDigitalTwinsEndpoint -EndpointName youriEventHubEndPoint  -EndpointType EventHub -ResourceGroupName youritemp -ResourceName youriDigitalTwins -connectionStringPrimaryKey 'Endpoint=sb://yourieventhubnp.servicebus.windows.net/;SharedAccessKeyName=youriEventhubPolicy;SharedAccessKey=********;EntityPath=yourieventhub'

Name                  Type
----                  ----
youriEventHubEndPoint Microsoft.DigitalTwins/digitalTwinsInstances/endpoints
.Example
PS C:\> New-AzDigitalTwinsEndpoint -EndpointName youriEventGridPoint  -EndpointType EventGrid -ResourceGroupName youritemp -ResourceName youriDigitalTwins -TopicEndpoint 'https://yourieventgrid.eastus-1.eventgrid.azure.net/api/events' -AccessKey1 'xxxxxxxxx='

Name                  Type
----                  ----
youriEventGridPoint Microsoft.DigitalTwins/digitalTwinsInstances/endpoints
.Example
PS C:\> New-AzDigitalTwinsEndpoint -EndpointName youriServiceBusPoint  -EndpointType EventGrid -ResourceGroupName youritemp -ResourceName youriDigitalTwins -PrimaryConnectionString "Endpoint=sb://yourieventhubnp.servicebus.windows.net/;SharedAccessKeyName=******;SharedAccessKey=********;EntityPath=yourieventhub"

Name                  Type
----                  ----
youriServiceBusPoint Microsoft.DigitalTwins/digitalTwinsInstances/endpoints

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResource
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResource
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

ENDPOINTDESCRIPTION <IDigitalTwinsEndpointResource>: DigitalTwinsInstance endpoint resource.
  EndpointType <EndpointType>: The type of Digital Twins endpoint
  [DeadLetterSecret <String>]: Dead letter storage secret. Will be obfuscated during read.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.digitaltwins/new-azdigitaltwinsendpoint
#>
function New-AzDigitalTwinsEndpoint {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResource])]
[CmdletBinding(DefaultParameterSetName='EventHub', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Path')]
    [System.String]
    # Name of Endpoint Resource.
    ${EndpointName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Path')]
    [System.String]
    # The name of the resource group that contains the DigitalTwinsInstance.
    ${ResourceGroupName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Path')]
    [System.String]
    # The name of the DigitalTwinsInstance.
    ${ResourceName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription identifier.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Support.EndpointType])]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Support.EndpointType]
    # The type of Digital Twins endpoint
    ${EndpointType},

    [Parameter(ParameterSetName='EventHub', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Body')]
    [System.String]
    # The subscription identifier.
    ${ConnectionStringPrimaryKey},

    [Parameter(ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IDigitalTwinsEndpointResource]
    # DigitalTwinsInstance endpoint resource.
    # To construct, see NOTES section for ENDPOINTDESCRIPTION properties and create a hash table.
    ${EndpointDescription},

    [Parameter(ParameterSetName='EventHub')]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Body')]
    [System.String]
    # The subscription identifier.
    ${ConnectionStringSecondaryKey},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Body')]
    [System.String]
    # Dead letter storage secret.
    # Will be obfuscated during read.
    ${DeadLetterSecret},

    [Parameter(ParameterSetName='ServiceBus', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Body')]
    [System.String]
    # The subscription identifier.
    ${PrimaryConnectionString},

    [Parameter(ParameterSetName='EventGrid', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Body')]
    [System.String]
    # The subscription identifier.
    ${TopicEndpoint},

    [Parameter(ParameterSetName='EventGrid', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Body')]
    [System.String]
    # The subscription identifier.
    ${AccessKey1},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Category('Runtime')]
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
            EventHub = 'Az.DigitalTwins.custom\New-AzDigitalTwinsEndpoint';
            ServiceBus = 'Az.DigitalTwins.custom\New-AzDigitalTwinsEndpoint';
            EventGrid = 'Az.DigitalTwins.custom\New-AzDigitalTwinsEndpoint';
        }
        if (('EventHub', 'ServiceBus', 'EventGrid') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
