
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
Creates an input or replaces an already existing input under an existing streaming job.
.Description
Creates an input or replaces an already existing input under an existing streaming job.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUT <IInput>: An input object, containing all information associated with the named input. All inputs are contained under a streaming job.
  [ETag <String>]: 
  [Property <IInputProperties>]: The properties that are associated with an input. Required on PUT (CreateOrReplace) requests.
    Type <String>: Indicates whether the input is a source of reference data or stream data. Required on PUT (CreateOrReplace) requests.
    [Compression <ICompression>]: Describes how input data is compressed
      Type <String>: 
    [PartitionKey <String>]: partitionKey Describes a key in the input data which is used for partitioning the input data
    [Serialization <ISerialization>]: Describes how data from an input is serialized or how data is serialized when written to an output. Required on PUT (CreateOrReplace) requests.
      Type <EventSerializationType>: Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.

INPUTOBJECT <IStreamAnalyticsIdentity>: Identity Parameter
  [ClusterName <String>]: The name of the cluster.
  [FunctionName <String>]: The name of the function.
  [Id <String>]: Resource identity path
  [InputName <String>]: The name of the input.
  [JobName <String>]: The name of the streaming job.
  [Location <String>]: The region in which to retrieve the subscription's quota information. You can find out which regions Azure Stream Analytics is supported in here: https://azure.microsoft.com/en-us/regions/
  [OutputName <String>]: The name of the output.
  [ResourceGroupName <String>]: The name of the resource group. The name is case insensitive.
  [SubscriptionId <String>]: The ID of the target subscription.
  [TransformationName <String>]: The name of the transformation.

PROPERTY <IInputProperties>: The properties that are associated with an input. Required on PUT (CreateOrReplace) requests.
  Type <String>: Indicates whether the input is a source of reference data or stream data. Required on PUT (CreateOrReplace) requests.
  [Compression <ICompression>]: Describes how input data is compressed
    Type <String>: 
  [PartitionKey <String>]: partitionKey Describes a key in the input data which is used for partitioning the input data
  [Serialization <ISerialization>]: Describes how data from an input is serialized or how data is serialized when written to an output. Required on PUT (CreateOrReplace) requests.
    Type <EventSerializationType>: Indicates the type of serialization that the input or output uses. Required on PUT (CreateOrReplace) requests.
.Link
https://docs.microsoft.com/powershell/module/az.streamanalytics/new-azstreamanalyticsinput
#>
function New-AzStreamAnalyticsInput {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput])]
[CmdletBinding(DefaultParameterSetName='Create', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Create', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the streaming job.
    ${JobName},

    [Parameter(ParameterSetName='Create', Mandatory)]
    [Alias('InputName')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the input.
    ${Name},

    [Parameter(ParameterSetName='Create', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Create', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [System.String]
    # The name of the streaming job.
    ${File},

    [Parameter(ParameterSetName='Create')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Header')]
    [System.String]
    # The ETag of the input.
    # Omit this value to always overwrite the current input.
    # Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes.
    ${IfMatch},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Header')]
    [System.String]
    # Set to '*' to allow a new input to be created, but to prevent updating an existing input.
    # Other values will result in a 412 Pre-condition Failed response.
    ${IfNoneMatch},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $inputParameters = Get-Content -Path $File | Out-String
          
        if ([Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.InputTypeConverter]::CanConvertFrom($inputParameters))
        {
          $function = [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.InputTypeConverter]::ConvertFrom($inputParameters)
        } else {
          throw "The json format is invalid"
        }
        
        $PSBoundParameters.Add("Input", $function)
        $null = $PSBoundParameters.Remove("File");

        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            Create = 'Az.StreamAnalytics.private\New-AzStreamAnalyticsInput_Create';
        }
        if (('Create') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
