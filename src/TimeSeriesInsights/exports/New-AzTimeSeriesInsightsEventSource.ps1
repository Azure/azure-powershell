
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
Create an event source under the specified environment.
.Description
Create an event source under the specified environment.
.Example
PS C:\> New-AzEventHubNamespace -Name spacename002 -ResourceGroupName testgroup -Location eastus
PS C:\> $ev = New-AzEventHub -ResourceGroupName testgroup -NamespaceName spacename002 -Name hubname001 -MessageRetentionInDays 3 -PartitionCount 2
PS C:\> $ks = Get-AzEventHubKey -ResourceGroupName testgroup -NamespaceName spacename002 -AuthorizationRuleName RootManageSharedAccessKey
PS C:\> $k  = $ks.PrimaryKey | ConvertTo-SecureString -AsPlainText -Force
PS C:\> New-AzTimeSeriesInsightsEventSource -ResourceGroupName testgroup -Name estest001 -EnvironmentName tsitest001 -Kind Microsoft.EventHub -ConsumerGroupName testgroup -Location eastus -KeyName RootManageSharedAccessKey -ServiceBusNameSpace spacename002 -EventHubName hubname001 -EventSourceResourceId $ev.id -SharedAccessKey $k

Kind               Location Name      Type
----               -------- ----      ----
Microsoft.EventHub eastus   estest001 Microsoft.TimeSeriesInsights/Environments/EventSources
.Example
PS C:\> $ev = New-AzIotHub -ResourceGroupName testgroup -Location eastus -Name iotname001 -SkuName S1 -Units 100
PS C:\> $ks = Get-AzIotHubKey -ResourceGroupName testgroup -Name iotname001
PS C:\> $k  = $ks[0].PrimaryKey | ConvertTo-SecureString -AsPlainText -Force
PS C:\> New-AzTimeSeriesInsightsEventSource -ResourceGroupName testgroup -Name iots001 -EnvironmentName tsitest001 -Kind Microsoft.IoTHub -ConsumerGroupName testgroup -Location eastus -KeyName RootManageSharedAccessKey -IoTHubName iotname001 -EventSourceResourceId $ev.id -SharedAccessKey $k

Location Name    Type                                                   Kind
-------- ----    ----                                                   ----
eastus   iots001 Microsoft.TimeSeriesInsights/Environments/EventSources Microsoft.IoTHub

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEventSourceResource
.Link
https://docs.microsoft.com/en-us/powershell/module/az.timeseriesinsights/new-aztimeseriesinsightseventsource
#>
function New-AzTimeSeriesInsightsEventSource {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IEventSourceResource])]
[CmdletBinding(DefaultParameterSetName='eventhub', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Path')]
    [System.String]
    # The name of the Time Series Insights environment associated with the specified resource group.
    ${EnvironmentName},

    [Parameter(Mandatory)]
    [Alias('EventSourceName')]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Path')]
    [System.String]
    # Name of the event source.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Path')]
    [System.String]
    # Name of an Azure Resource group.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Azure Subscription ID.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [ArgumentCompleter({param ( $CommandName, $ParameterName, $WordToComplete, $CommandAst, $FakeBoundParameters ) return @('Microsoft.EventHub', 'Microsoft.IoTHub')})]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.Kind]
    # The kind of the event source.
    ${Kind},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
    [System.String]
    # The location of the resource.
    ${Location},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
    [System.String]
    # The name of the event/iot hub's consumer group that holds the partitions from which events will be read.
    ${ConsumerGroupName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
    [System.String]
    # The name of the SAS key that grants the Time Series Insights service access to the event/iot hub.
    ${KeyName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
    [System.String]
    # The resource id of the event source in Azure Resource Manager.
    ${EventSourceResourceId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
    [System.Security.SecureString]
    # The value of the shared access key that grants the Time Series Insights service read access to the event/iot hub.
    ${SharedAccessKey},

    [Parameter(ParameterSetName='eventhub', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
    [System.String]
    # The name of the event hub.
    ${EventHubName},

    [Parameter(ParameterSetName='eventhub', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
    [System.String]
    # The name of the service bus that contains the event hub.
    ${ServiceBusNameSpace},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ICreateOrUpdateTrackedResourcePropertiesTags]))]
    [System.Collections.Hashtable]
    # Key-value pairs of additional properties for the resource.
    ${Tag},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
    [System.String]
    # The event property that will be used as the event source's timestamp.
    ${TimeStampPropertyName},

    [Parameter(ParameterSetName='iothub', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Body')]
    [System.String]
    # The name of the iot hub.
    ${IoTHubName},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Category('Runtime')]
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
            eventhub = 'Az.TimeSeriesInsights.custom\New-AzTimeSeriesInsightsEventSource';
            iothub = 'Az.TimeSeriesInsights.custom\New-AzTimeSeriesInsightsEventSource';
        }
        if (('eventhub', 'iothub') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
